Imports System.ComponentModel

Public Class fm_0400_impresion_etiquetas
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public generada As String = "PTERM" '"N"
    Public id_item As Integer = 0
    Public id_ipp As Integer = 0
    Public id_rp As String
    Public fecha_produccion As Date
    Public fecha_vencimiento As Date
    Public lote As String

    'Private$vf_otabla_permisos$As DataTable

    Private odr As NpgsqlDataReader
    Private oconn_form As NpgsqlConnection

    Private impresion_remota As String = "N"

    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private csql As String = ""
    Private consecutivo_impresion As Integer
    Private consecutivo_etiqueta As Integer
    Private oproducto As String = ""
    Private oreferencia As String = ""
    Private ocontenido As String = ""
    Private olote As String = ""
    Private ovence As String = ""
    Private oop1 As String = ""
    Private oop2 As String = ""
    Private onum_etiqueta As Integer = 1
    Private ofecha As Date
    Private impreso As Boolean = True
    Private vcerrar As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private vexiste As String = ""
    Private vdia_semana As String = ""
    Private vcodigo_conductor As String = ""
    Private vnuevo_registro As String = "S"
    Private verror As String = "N"
    Private otb_formato_etiquetas As DataTable
    Private otb_items As DataTable
    Private otb_listado_etiq_creadas As DataTable

    Private oda As NpgsqlDataAdapter
    Private ods As New DataSet


    Private Sub fm_0400_impresion_etiquetas_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        bt_anular.Enabled = False
        bt_generar_informe.Enabled = False
        bt_editar.Enabled = False
        bt_nuevo.Enabled = False
        bt_grabar.Enabled = False
        nud_cantidad.Maximum = comunes.suministrar_valor_variable_configuracion("CONFIG-0400-01", vg_id_cia)
        nud_cant_englobada.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_produccion.Format = DateTimePickerFormat.Custom
        dtp_fecha_produccion.CustomFormat = "yyyy/MM/dd"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_vence.Format = DateTimePickerFormat.Custom
        dtp_fecha_vence.CustomFormat = "yyyy/MM/dd"
        dtp_fecha_vence.Value = DateAdd(DateInterval.Year, 1, dtp_fecha_produccion.Value)
        Select Case generada
            Case "PTERM"
                csql = "SELECT *, f0300_descripcion_item || ' - REF:(' || f0300_referencia || ') -" _
                                        & " P:(' || f0300_contenido_x_empaque || ')' as descripcion_larga" _
                                        & " FROM " & database.obtener_esquema & ".tb0300_items" _
                                        & " where f0300_id_cia = '" & vg_id_cia & "' and " & "f0300_vende = 'S'" _
                                        & " order by descripcion_larga"
            Case "PPROS"
                csql = "SELECT *, f0300_descripcion_item || ' - REF:(' || f0300_referencia || ') -" _
                                        & " P:(' || f0300_contenido_x_empaque || ')' as descripcion_larga" _
                                        & " FROM " & database.obtener_esquema & ".tb0300_items" _
                                        & " where f0300_id_cia = '" & vg_id_cia & "'" _
                                        & " order by descripcion_larga"
            Case "MATPRIM"
                csql = "SELECT *, f0300_descripcion_item || ' - REF:(' || f0300_referencia || ') -" _
                                        & " P:(' || f0300_contenido_x_empaque || ')' as descripcion_larga" _
                                        & " FROM " & database.obtener_esquema & ".tb0300_items" _
                                        & " where f0300_id_cia = '" & vg_id_cia & "' and" _
                                        & " f0300_id_tipo_item <> 15 and f0300_id_tipo_item <> 25" _
                                        & " order by descripcion_larga"
        End Select

        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_producto
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion_larga"
            'Valor interno que almacena el objeto
            .ValueMember = "f0300_id_item"
            'Origen de Datos del ComboBox
            .DataSource = otb_items
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        If id_item <> 0 Then
            cm_producto.SelectedValue = id_item
        End If

        csql = "select * from " & database.obtener_esquema & ".tb0422_formato_etiquetas order by f0422_descripcion"
        otb_formato_etiquetas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_formato_etiqueta
            'Valor que se muestra al usuario
            .DisplayMember = "f0422_descripcion"
            'Valor interno que almacena el objeto
            .ValueMember = "f0422_id_formato"
            'Origen de Datos del ComboBox
            .DataSource = otb_formato_etiquetas
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        'Controla la edicion de campos que deben partir desde la informacion de un reporte de produccion.
        Select Case generada
            Case "PTERM"
                'no hago nada
            Case "PPROS"
                cm_producto.SelectedValue = id_item
                tx_id_item.Text = id_item
                tx_id_item.ReadOnly = True
                cm_producto.Enabled = False
                tx_op_alterna.Text = id_rp
                tx_op_alterna.ReadOnly = True
                tx_op_ppal.Text = id_ipp
                tx_op_ppal.ReadOnly = True
                dtp_fecha_produccion.Value = fecha_produccion
                dtp_fecha_produccion.Enabled = False
                dtp_fecha_vence.Enabled = False
                tx_lote.Text = lote
                tx_lote.Enabled = False
                dtp_fecha_vence.Value = fecha_vencimiento 'DateAdd(DateInterval.Year, 1, fecha_produccion)
            Case "MATPRIM"
                tx_op_ppal.ReadOnly = True
                tx_op_alterna.ReadOnly = True
                cm_formato_etiqueta.SelectedValue = 5
                cm_formato_etiqueta.Enabled = False
                Label5.Text = "Cod CGUNO"
                Label4.Text = "Cod. CAMO"
        End Select
    End Sub
    Private Sub imprimir()
        Dim f, fs, i, nmro_tqtes
        Dim codigo_fuente_01 As String, codigo_fuente_02 As String, p2 As String, p3 As String, cod_formato As String, path_impresora As String, file_temp_path As String
        codigo_fuente_01 = ""
        cod_formato = ""
        path_impresora = ""
        file_temp_path = ""
        codigo_fuente_02 = ""
        p2 = ""
        p3 = ""
        'MsgBox("hola")
        For Each orow As DataRow In otb_formato_etiquetas.Rows
            If CInt(orow.Item("f0422_id_formato")) = CInt(cm_formato_etiqueta.SelectedValue) Then
                codigo_fuente_01 = orow.Item("f0422_codigo_fuente_01")
                codigo_fuente_02 = orow.Item("f0422_codigo_fuente_02") & vbCrLf
                'cod_formato = orow.Item("codigo_alterno")
                path_impresora = orow.Item("f0422_print_path") 'La direccion de la impresora
                file_temp_path = orow.Item("f0422_file_temp_path") 'En donde se encuentra el archivo que es copiado hacia la impresora
            End If
        Next
        'MsgBox(codigo_fuente_02)
        'traer datos del producto
        Dim orow_producto As DataRow()
        orow_producto = otb_items.Select("f0300_id_item = '" & cm_producto.SelectedValue & "'")
        For Each orow As DataRow In orow_producto
            oproducto = Mid(orow("f0300_descripcion_item").ToString, 1, 50)
            oreferencia = orow("f0300_referencia").ToString
            oreferencia = oreferencia.Replace("-", "").PadLeft(4, "0")

            If chk_englobe.Checked = True And nud_cant_englobada.Value > 1 Then
                ocontenido = "( " & nud_cant_englobada.Value & " ) " & Mid(orow("f0300_contenido_x_empaque").ToString, 1, 30)
            Else
                ocontenido = Mid(orow("f0300_contenido_x_empaque").ToString, 1, 45)
            End If

            If generada = "MATPRIM" Then
                ocontenido = orow("f0300_peso_neto")
            End If

        Next
        'asignar variables definidas por el usuario
        olote = Mid(tx_lote.Text.ToString, 1, 20)
        If chk_fvence_aaaa_mm.Checked = False Then
            ovence = Format(dtp_fecha_vence.Value, "dd/MM/yyyy")
        Else
            ovence = Format(dtp_fecha_vence.Value, "yyyy-MM")
        End If

        If tx_op_ppal.Text = "" Then
            oop1 = "N/A"
        Else
            oop1 = UCase(tx_op_ppal.Text.Trim)
        End If

        If tx_op_alterna.Text.Trim = "" Then
            oop2 = "N/A"
        Else
            oop2 = UCase(tx_op_alterna.Text.Trim)
        End If
        Try
            My.Computer.FileSystem.DeleteFile(file_temp_path) 'My.Computer.FileSystem.DeleteFile("C:\Etiquetas\test.txt")
        Catch ex As Exception

        End Try
        verror = "N"

        guardar_orden_impresion()
        If verror = "S" Then
            Exit Sub
        End If
        'consecutivo_impresion = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0420_id_impresion", "f0420_usuario_crear", vg_usuario_autoriza, "tb0420_orden_imp_etiquetas")
        'consecutivo_etiqueta = cl_utilidades_datatables.obtener_nuevo_consecutivo_tablas("f0421_id_etiqueta", "tb0421_etiquetas")
        'codigo_fuente_01 = My.Computer.FileSystem.ReadAllText("C:\Etiquetas\etiqueta_codigo_fuente_02.txt")
        'codigo_fuente_01 = "Texto fijo"
        'p3 = ""


        codigo_fuente_02 = Replace(codigo_fuente_02, "$$PRODUCTO$$", oproducto) 'Producto
        codigo_fuente_02 = Replace(codigo_fuente_02, "$$CONTENIDO$$", ocontenido) 'CONTENIDO
        codigo_fuente_02 = Replace(codigo_fuente_02, "$$LOTE$$", olote) ' LOTE Trim(num_tic_ini.ToString("F0")).PadLeft(8, "0"))
        codigo_fuente_02 = Replace(codigo_fuente_02, "$$VENCE$$", ovence) 'VENCE
        codigo_fuente_02 = Replace(codigo_fuente_02, "$$OP1$$", oop1) 'OP PRINCIPAL
        codigo_fuente_02 = Replace(codigo_fuente_02, "$$OP2$$", oop2) 'OP SECUNDARIA
        codigo_fuente_02 = Replace(codigo_fuente_02, "$$REFERENCIA$$", oreferencia) 'REFERENCIA DEL PRODUCTO
        'MsgBox(codigo_fuente_02)


        For Each orow As DataRow In otb_listado_etiq_creadas.Rows
            consecutivo_etiqueta = orow.Item("id_etiqueta")
            consecutivo_impresion = orow.Item("id_ordenimpresion")
            'codigo_fuente_01 = Replace(codigo_fuente_01, "$$NUM-ETIQUETA$$", "12345678") 'NUMERO ETIQUETA
            p2 = Replace(codigo_fuente_02, "$$NUM-ETIQUETA$$", Trim(consecutivo_etiqueta.ToString("F0")).PadLeft(8, "0"))
            'p2 = p2 & vbCrLf
            p3 = p3 + p2
        Next

        'MsgBox(p3)
        'Coloco la primer parte del codigo de las etiquetas
        If codigo_fuente_01 <> "" Then
            p3 = codigo_fuente_01 & vbCrLf & p3
        End If


        'My.Computer.FileSystem.WriteAllText("C:\Etiquetas\test.txt", _
        'codigo_fuente_01 & vbCrLf & p3, True)

        Try
            My.Computer.FileSystem.WriteAllText(file_temp_path, p3, True)
        Catch ex As Exception
            verror = "S"
            MsgBox("Error fuente tabla formato! " + ex.ToString)
        End Try

        'MsgBox(p3)

        Try
            fs = CreateObject("Scripting.FileSystemObject")
            f = fs.GetFile(file_temp_path)  'f = fs.GetFile("C:\Etiquetas\test.txt")
            'fs.CopyFile("C:\Etiquetas\test.txt", "\\metrologo1.calidad1.net\monarch")
            'fs.CopyFile("C:\Etiquetas\test.txt", "\\metrologo1\monarch")


            If impresion_remota = "N" Then
                fs.CopyFile(file_temp_path, path_impresora) 'fs.CopyFile("C:\Etiquetas\test.txt", path_impresora)
            Else
                Dim path_file As String = comunes.suministrar_valor_variable_configuracion("DIR-I-003", vg_id_cia)
                fs.CopyFile(file_temp_path, path_file)
            End If

        Catch ex As Exception
            verror = "S"
            MsgBox("Error enviando archivo! " + ex.ToString)
        End Try

        If verror = "S" Then
            MsgBox("La orden de impresion no llego a la impresora")
            'Especifica que se imprimieron 0 etiquetas
            csql = "update " + database.obtener_esquema + ".tb0420_orden_imp_etiquetas set"
            csql += " f0420_cantidad = '0'"
            csql += " where f0420_id_impresion = '" & consecutivo_impresion & "'"
            oconn_form = database.obtener_conexion()
            ocmd = database.obtener_comando(oconn_form)
            ocmd.CommandText = csql
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar no impresion! " + vbCrLf + ex.ToString)
            End Try
            'csql = "DELETE FROM " & database.obtener_esquema & ".tb0421_etiquetas where f0421_id_impresion = '" & consecutivo_impresion & "'"
            'oconn_form = database.obtener_conexion()
            'ocmd = database.obtener_comando(oconn_form)
            'ocmd.CommandText = csql
            'Try
            '    ocmd.ExecuteNonQuery()
            'Catch ex As Exception
            '    verror = "S"
            '    MsgBox("Hubo un error al eliminar etiquetas! " + vbCrLf + ex.ToString)
            'End Try
        Else
            MsgBox("Orden de impresion enviada con exito!")
        End If
        vcerrar = "S"
        Dispose() 'Para que no tengan dos ventanas abiertas al mismo tiempo.
    End Sub

    Private Function guardar_orden_impresion()

        Dim oenglobe As String, ounidenglobe As Integer
        If chk_englobe.Checked = True And nud_cant_englobada.Value > 1 Then
            oenglobe = "S"
            ounidenglobe = nud_cant_englobada.Value
        Else
            oenglobe = "N"
            ounidenglobe = 1
        End If

        'Cooro la funcion en postgres que crea los registros en la base de datos
        csql = "select * from " & database.obtener_esquema & ".fnc_400_06_generar_etiquetas_pt("
        csql += nud_cantidad.Value & ",'" & vg_id_cia & "'," & cm_producto.SelectedValue & "," & oop1 & ",'" & oop2 & "','"
        csql += Format(dtp_fecha_produccion.Value, "dd/MM/yyyy") & "','" & olote & "','" & Format(dtp_fecha_vence.Value, "dd/MM/yyyy") & "'," & nud_cantidad.Value & ",'"
        csql += oenglobe & "'," & ounidenglobe & ",'" & vg_usuario_autoriza & "')"

        otb_listado_etiq_creadas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

    End Function
    Private Sub validar_producto()
        If cm_producto.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Seleccione un producto."
        End If
    End Sub

    Private Sub validar_lote()
        If tx_lote.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el lote de produccion."
        End If
    End Sub

    Private Sub validar_formato()
        If cm_formato_etiqueta.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Seleccione el formato de impresion."
        End If
    End Sub

    Private Sub bt_imprimir_Click(sender As Object, e As EventArgs) Handles bt_imprimir.Click
        orden_impresion()
    End Sub

    Private Sub bt_imp_remota_Click(sender As Object, e As EventArgs) Handles bt_imp_remota.Click
        impresion_remota = "S"
        orden_impresion()
    End Sub

    Private Sub orden_impresion()
        verror_requisitos = "N"
        validar_producto()
        validar_lote()
        validar_formato()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        ofecha = comunes.g_fechahora
        imprimir()
    End Sub

    Private Sub tx_op_ppal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_op_ppal.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub chk_englobe_CheckedChanged(sender As Object, e As EventArgs) Handles chk_englobe.CheckedChanged
        If chk_englobe.Checked = True Then
            nud_cant_englobada.Enabled = True
        Else
            nud_cant_englobada.Value = 1
            nud_cant_englobada.Enabled = False
        End If
    End Sub

    Private Sub bt_calcular_lote_Click(sender As Object, e As EventArgs) Handles bt_calcular_lote.Click
        tx_lote.Text = DatePart(DateInterval.DayOfYear, dtp_fecha_produccion.Value) _
            & DatePart(DateInterval.Month, dtp_fecha_produccion.Value).ToString.PadLeft(2, "0") _
            & dtp_fecha_produccion.Value.ToString("yy")
    End Sub

    Private Sub tx_id_item_Validating(sender As Object, e As CancelEventArgs) Handles tx_id_item.Validating
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If
        If IsNumeric(tx_id_item.Text) = False Then
            MsgBox("El dato no es numerico", MsgBoxStyle.Exclamation, "Error")
            tx_id_item.Text = ""
        End If
        cm_producto.SelectedValue = tx_id_item.Text
        If cm_producto.SelectedIndex = -1 Then
            MsgBox("El codigo no existe", MsgBoxStyle.Exclamation, "Error")
            tx_id_item.Text = ""
        Else
            buscar_info_item(tx_id_item.Text)
        End If

    End Sub

    Private Sub cm_producto_Validating(sender As Object, e As CancelEventArgs) Handles cm_producto.Validating
        If cm_producto.Text.Trim = "" Then
            Exit Sub
        End If
        If cm_producto.SelectedIndex = -1 Then
            MsgBox("El producto no existe", MsgBoxStyle.Exclamation, "Error")
            cm_producto.Text = ""
            tx_id_item.Text = ""
            Exit Sub
        End If
        tx_id_item.Text = cm_producto.SelectedValue
        buscar_info_item(tx_id_item.Text)
    End Sub
    Private Sub buscar_info_item(ByVal oid_item As Integer)
        'MsgBox(oid_item)
        Dim orow_item As DataRow()
        orow_item = otb_items.Select("f0300_id_item = '" & cm_producto.SelectedValue & "'")
        For Each orow As DataRow In orow_item
            If orow("f0300_codigo_cguno") <> "" Then
                tx_op_ppal.Text = orow("f0300_codigo_cguno")
            Else
                tx_op_ppal.Text = "0"
            End If
            tx_op_alterna.Text = orow("f0300_id_item")
        Next

    End Sub
End Class
