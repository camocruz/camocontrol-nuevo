Imports System.ComponentModel
Imports App.ApiClient.CS.Services
Imports App.ApiClient.CS.Services.SpecificServices
Imports App.ApiClient.CS.Helpers.Commons
Imports App.ApiClient.CS.Utilities
Imports App.ApiClient.CS.DTOs.SpecificDtos
Public Class fm_0300_doc_movimientos_inventarios
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public codigo_documento As String ' el texto con el codigo del documento eje: AJU-00000001
    Public modificacion_activada As String = "N"
    Public editable As String = "N"
    Public bloq_info_encab As String = "S" 'Para bloquear la informacion del encabezado del documento.
    'Public traslado As String = "N"
    Public id_item As Integer
    Public m_clasificador As String = "S"
    Public m_inventario As String = "N"
    Public m_tipo_mov As String = "N"
    Public m_edit_item As String = "N"
    Public m_ent_sal As String = "N" 'Para determinar comportamiento del grupo de RB entrada y salida
    '''''''' E = Activado entrada edicion de grupo RB deshabilitada
    '''''''' S = Activado salida edicion de grupo RB deshabilitada
    '''''''' D = Edicion de grupo RB Habilitada
    '''''''' N = Edicion de grupo RB deshabilitada
    Public m_cantidad As String = "S"
    Public m_info_trazabilidad As String = "N"
    Public otb_items_programa_produccion As DataTable
    Public identifica_receptor As String = "N"

    Private permitir_costos As String = "N"
    Private traslado As String = "N"
    Private transformacion As String = "N"
    Private basado_sol_alm As String = "N" 'Indica si la informacion del movimiento se basa en una solicitud de almacen
    Private id_item_sol As Integer = 0 'Indica el id del item de una solicitud de compra
    Private cant_solalm_tot As Decimal = 0 'cantidad total que se esta solicitando en la solicitud de almacen.
    Private cant_solalm_ent As Decimal = 0  'cantidad entragada actual del item solicitado
    Private cant_solalm_pend As Decimal = 0  'cantidad pendiente por entregar del item solicitado
    Private otipo_nota As String
    Private id_documento As Integer = 0       'El entero id de la tabla
    Private id_doc_ref As String = ""   'El codigo del documento de referencia eje TRI-00000234
    Private info_trazable As String = ""
    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private registro_sel As Integer

    Private anulado As String = "N"
    Private verror As String = "S"
    Private verror_docto As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private otb_enc_documento As DataTable
    Private otb_items_documento As DataTable
    Private otb_info_trazabilidad_items As DataTable


    Private Sub fm_0300_doc_movimientos_inventarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        'Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        'Identifico si el usuario pueder ver informacion de los costos promedio del movimiento.
        permitir_costos = cl_gestion_permisos.identificar_un_permiso_especial_usuario("VER_COSTOS", vg_usuario_autoriza)

        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False
        'bloqueo todos los botones ppales
        If editable = "N" Then
            bloquear_botones()
        End If
        Select Case m_ent_sal
            Case "E"

        End Select

        ' Set the Format type and the CustomFormat string.
        dtp_fecha.Format = DateTimePickerFormat.Custom
        dtp_fecha.CustomFormat = "yyyy/MM/dd  HH:mm"

        'Cargo la informacion del documento
        If bloq_info_encab = "S" Then
            bloquear_encabezado()
        Else
            'Solo se puede cambiar la fecha del documento, no es posible cambiar las bodegas pues ya existen movimientos.
            bloquear_encabezado("S")
        End If

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0005_bodegas"
        Dim otb_bodega_origen As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim otb_bodega_destino As DataTable = otb_bodega_origen.Copy
        With cm_bodegas
            'Valor que se muestra al usuario
            .DisplayMember = "f0005_descripcion_bodega"
            'Valor interno que almacena el objeto
            .ValueMember = "f0005_id_bodega"
            'Origen de Datos del ComboBox
            .DataSource = otb_bodega_origen
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_bodega_destino
            'Valor que se muestra al usuario
            .DisplayMember = "f0005_descripcion_bodega"
            'Valor interno que almacena el objeto
            .ValueMember = "f0005_id_bodega"
            'Origen de Datos del ComboBox
            .DataSource = otb_bodega_destino
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
              & " from " & database.obtener_esquema & ".tb0200_terceros" _
              & " where f0200_id_cia = '" & vg_id_cia & "'" & " and f0200_ind_empleado = 'S'" _
              & " order by nombre"
        Dim otb_info_personal As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_recibio
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_personal
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        'identifico el tipo de nota
        otipo_nota = comunes.suministrar_valor_variable_configuracion("TN-INV-001", vg_id_cia)
        cargar_info_documento()
        cargar_items_dg()

        If otb_items_documento.Rows.Count = 0 And bloq_info_encab = "N" Then
            tx_docto_contable.ReadOnly = False
            cm_bodegas.Enabled = True
            cm_bodega_destino.Enabled = True
            cm_recibio.Enabled = True
            desbloquear_botones()
        End If
    End Sub

    Private Sub bloquear_botones()
        bt_grabar.Enabled = False
        bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_g_archivos.Enabled = False
        'bt_g_notas.Enabled = False
        'bt_generar_informe.Enabled = False
        bt_nuevo.Enabled = False
    End Sub

    Private Sub desbloquear_botones()
        bt_anular.Enabled = True
        bt_editar.Enabled = True
        bt_nuevo.Enabled = True
    End Sub

    Private Sub cargar_info_documento()

        csql = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
            & " where f0310_id_documento = '" & codigo_documento & "'"
        otb_enc_documento = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        For Each orow As DataRow In otb_enc_documento.Rows
            id_documento = orow("f0310_id_doc") 'Lo uso para asociar notas, pues solo puedo vincular numeros enteros.
            lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_documento, vg_id_cia)
            'identifico el tipo de movimiento que estoy haciendo.
            Select Case Strings.Left(orow("f0310_id_documento"), 3)
                Case "TRI"
                    traslado = "S"
                Case "RGR"
                    transformacion = "S"
            End Select
            If traslado = "N" Then
                cm_bodega_destino.Visible = False
                Label4.Visible = False
                bt_genmov_apartir_solalm.Enabled = False
            Else
                cm_bodega_destino.Visible = True
                Label4.Visible = True
                bt_genmov_apartir_solalm.Enabled = True
            End If

            'Identifico si se permite o no la edicion de los items del documento.
            If orow("f0310_habilitado") = "S" Then
                'Si un documento fue habilitado al momento de abrirse se vuelve a bloquear pero permite editar mientras que el 
                'form este abierto.
                bloquear_documento()
                desbloquear_botones()
                'MsgBox("Documento habilitado")

                If traslado = "S" Then
                    bt_anular.Enabled = False
                    bt_editar.Enabled = False
                End If
            End If
            If orow("f0310_anulado") = "S" Then
                lb_titulo.Text += " ( ANULADO )"
                anulado = "S"
                'Agrego columna al dg para mostrar fecha y hora de anulacion
                Dim obj As New DataGridViewColumn
                Dim col As New DataGridViewTextBoxColumn
                obj = col
                obj.HeaderText = "Fecha Anulacion"
                obj.Name = "dgocell_f_anulacion"
                dg_items.Columns.Add(obj)
            End If
            If orow("f0310_usuario_recibio") <> "" Then
                cm_recibio.SelectedValue = orow("f0310_usuario_recibio")
            End If
            lb_cod_documento.Text = orow("f0310_id_documento")
            tx_docto_contable.Text = orow("f0310_documento_contabilidad")
            tx_docto_origen.Text = orow("f0310_id_documento_origen")
            dtp_fecha.Value = orow("f0310_fecha")
            cm_bodegas.SelectedValue = orow("f0310_id_bodega")
            cm_bodega_destino.SelectedValue = orow("f0310_id_bodega_destino")
            lb_usuario.Text = comunes.traer_nombre_usuario(orow("f0310_usuario_crear"))
        Next

    End Sub

    Private Sub bloquear_encabezado(Optional edit_fecha As String = "N")
        cm_bodegas.Enabled = False
        cm_bodega_destino.Enabled = False
        tx_docto_contable.ReadOnly = True
        cm_recibio.Enabled = False
        If edit_fecha = "N" Then
            dtp_fecha.Enabled = False
        Else
            dtp_fecha.Enabled = True
        End If
    End Sub

    Private Sub cargar_items_dg()
        If Strings.Left(codigo_documento, 3) = "DAC" Then
            dg_items.Rows.Clear()
            csql = comunes.suministrar_valor_variable_configuracion("ST-0400-09", vg_id_cia)
            csql = csql.Replace("$df001$", database.obtener_esquema)
            csql = csql.Replace("$001$", vg_id_cia)
            csql = csql.Replace("$002$", codigo_documento)

            otb_items_documento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            For Each orow As DataRow In otb_items_documento.Rows
                agregar_fila_items_DAC(orow)
            Next
        Else
            dg_items.Rows.Clear()
            csql = comunes.suministrar_valor_variable_configuracion("ST-0300-18", vg_id_cia)
            csql = csql.Replace("$df001$", database.obtener_esquema)
            csql = csql.Replace("$001$", vg_id_cia)
            csql = csql.Replace("$002$", codigo_documento)

            If anulado = "S" Then
                csql = csql.Replace("f0309_anulado = 'N'", "f0309_anulado = 'S'")
            End If

            otb_items_documento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            'busco la informacion de trazabilidad
            csql = "SELECT *" _
                 & " FROM " & database.obtener_esquema & ".tb0318_trazabilidad_movimientos" _
                 & " where f0318_id_documento = '" & codigo_documento & "' and f0318_anulado = 'N'"
            otb_info_trazabilidad_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)

            Dim costo_absoluto As Decimal = 0
            Dim costo_total As Decimal = 0
            For Each orow As DataRow In otb_items_documento.Rows
                info_trazable = ""
                info_trazable = formar_info_trazabilidad(orow("f0309_id_mov_item"))
                agregar_fila_items(orow)
                'actualizo los costos globales del documento
                If orow("f0309_entrada") = 0 Then
                    costo_total = costo_total - (orow("f0309_costo_unit_promedio") * orow("f0309_salida"))
                Else
                    costo_total = costo_total + (orow("f0309_costo_unit_promedio") * orow("f0309_entrada"))
                End If
                costo_absoluto = costo_absoluto + (orow("f0309_costo_unit_promedio") * (orow("f0309_entrada") + orow("f0309_salida")))
            Next
            If permitir_costos = "N" Then
                lb_costo_absoluto.Text = "ND"
                lb_costo_total.Text = "ND"
            Else
                lb_costo_absoluto.Text = Math.Round(costo_absoluto, 2).ToString("C2")
                lb_costo_total.Text = Math.Round(costo_total, 2).ToString("C2")
            End If

        End If

    End Sub
    Private Function formar_info_trazabilidad(ByVal id_mov_item As Integer)
        Dim info_trazabilidad As String = ""
        Dim orows_trazabilidad As DataRow()
        orows_trazabilidad = otb_info_trazabilidad_items.Select("f0318_id_mov_item = '" & id_mov_item & "'")
        For Each orow As DataRow In orows_trazabilidad
            info_trazabilidad += orow("f0318_info_trazable") & ", "
        Next
        Return info_trazabilidad
    End Function
    Private Sub agregar_fila_items(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1 
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0309_id_mov_docto"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        Dim t_mov As String = "S"
        If orow.Item("f0309_entrada") = 0 Then
            t_mov = "S"
        Else
            t_mov = "E"
        End If
        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = t_mov
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0309_id_item")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0300_referencia").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("descripcion_larga").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0002_unidad_medicion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        If t_mov = "S" Then
            otextgrid.Value = orow.Item("f0309_salida")
        Else
            otextgrid.Value = orow.Item("f0309_entrada")
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0309_teorico")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 8
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0312_clasificador").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 9
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = info_trazable
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 10
        'documento de referencia
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0309_id_doc_ref")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 11
        'Costo promedio del movimiento
        otextgrid = New DataGridViewTextBoxCell
        If permitir_costos = "N" Then
            otextgrid.Value = "ND"
        Else
            otextgrid.Value = CDec(orow.Item("f0309_costo_unit_promedio") * (orow.Item("f0309_entrada") + orow.Item("f0309_salida"))).ToString("C2") _
                & " -->> Unit_prom: " & CDec(orow.Item("f0309_costo_unit_promedio")).ToString("C2")
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 11 si el documento esta anulado
        If anulado = "S" Then
            otextgrid = New DataGridViewTextBoxCell
            otextgrid.Value = CDate(orow.Item("f0309_fm")).ToString("yyyy/MMM/dd HH:mm:ss")
            'otextgrid.MaxInputLength = 100
            'Agrega columna al objeto fila
            orowgrid.Cells.Add(otextgrid)
        End If


        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_items.Rows.Add(orowgrid)
    End Sub


    Private Sub agregar_fila_items_DAC(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = "----"
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = "S"
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("id_item")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("item").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("und").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("salida")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_items.Rows.Add(orowgrid)
    End Sub

    Private Sub actualizar_cambios_encabezado()
        Dim bodega_destino As Integer = 0
        If cm_bodega_destino.SelectedIndex = -1 Then
            bodega_destino = 0
        Else
            bodega_destino = cm_bodega_destino.SelectedValue
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0310_documentos_movimientos_inventarios set"
        csql += " f0310_documento_contabilidad = '" & tx_docto_contable.Text.Trim & "',"
        csql += " f0310_id_bodega = '" & cm_bodegas.SelectedValue & "',"
        csql += " f0310_id_bodega_destino = '" & bodega_destino & "',"
        csql += " f0310_usuario_recibio = @f0310_usuario_recibio,"
        csql += " f0310_fecha = '" & dtp_fecha.Value.ToString("yyyy/MMM/dd HH:mm:ss.f") & "'"
        csql += " where f0310_id_documento = @f0310_id_documento"

        'Clipboard.SetDataObject(csql)
        'MsgBox(csql)

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0310_id_documento", NpgsqlDbType.Varchar).Value = codigo_documento
        If cm_recibio.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0310_usuario_recibio", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0310_usuario_recibio", NpgsqlDbType.Varchar).Value = cm_recibio.SelectedValue
        End If
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub bloquear_documento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0310_documentos_movimientos_inventarios set"
        csql += " f0310_habilitado = 'N'"
        csql += " where f0310_id_documento = @f0310_id_documento"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0310_id_documento", NpgsqlDbType.Varchar).Value = codigo_documento
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub dg_items_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_items.CellClick
        If dg_items.RowCount = 0 Then
            Exit Sub
        End If
        tx_registro_seleccionado.Text = dg_items.CurrentRow.Cells("dgocell_ident_doc").Value
        registro_sel = dg_items.CurrentRow.Cells("dgocell_ident_doc").Value

    End Sub
    Private Sub dg_items_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_items.CellDoubleClick
        If dg_items.RowCount = 0 Then
            Exit Sub
        End If
        If dg_items.Columns(dg_items.CurrentCell.ColumnIndex).Name = "dgocell_info_trazabilidad" Then
            'MsgBox(codigo_documento)
            If 1 = 1 Then 'If Strings.Left(codigo_documento, 3) = "CPR" Then
                Dim row_item_modificar As DataRow()
                row_item_modificar = otb_items_documento.Select("f0309_id_mov_docto ='" & registro_sel & "'" & " and f0309_id_documento = '" & codigo_documento & "'")
                Dim id_mov_item As Integer = row_item_modificar(0)("f0309_id_mov_item")
                'MsgBox(id_mov_item)
                If tx_registro_seleccionado.Text = "" Then
                    Exit Sub
                End If
                Dim info_item As cl_estructuras_variables.info_item_mov_inventario
                info_item = cl_utilidades_gestion_compras.form_suministrar_item_cantidad(vg_usuario_autoriza, vg_id_cia, dtp_fecha.Value, "",
                                                                     dg_items.CurrentRow.Cells("dgocell_id_item").Value,
                                                                     dg_items.CurrentRow.Cells("dgocell_cant_movimiento").Value, cm_bodegas.SelectedValue,, "N",,, "N", "S")
                If info_item.id_item = 0 Then
                    Exit Sub
                End If

                'Anulo cualquier informacion de trazabilidad anterior
                anular_info_trazabilidad_item(dg_items.CurrentRow.Cells("dgocell_ident_doc").Value)


                Dim otb_info_trazabilidad As DataTable = info_item.info_trazabilidad

                'si hay informacion de trazabilidad asociada entonces la guardo
                If IsNothing(otb_info_trazabilidad) = False Then
                    For Each orow As DataRow In otb_info_trazabilidad.Rows

                        'Instancia la conexión que estará vigente para todas las operaciones CRUD
                        oconn_form = database.obtener_conexion()

                        'Inserción parametrizada
                        csql = "INSERT INTO " & database.obtener_esquema & ".tb0318_trazabilidad_movimientos" _
                                & " (f0318_id_cia, f0318_id_mov_item, f0318_id_mov_docto, f0318_id_item, f0318_id_bodega, f0318_id_documento," _
                                & " f0318_fecha_movimiento, f0318_info_trazable," _
                                & " f0318_usuario_crear, f0318_usuario_modificar)" _
                                & " VALUES" _
                                & " (@f0318_id_cia, @f0318_id_mov_item, @f0318_id_mov_docto, @f0318_id_item, @f0318_id_bodega, @f0318_id_documento," _
                                & " @f0318_fecha_movimiento, @f0318_info_trazable," _
                                & " @f0318_usuario_crear, @f0318_usuario_modificar)"

                        ocmd = database.obtener_comando(oconn_form)
                        ocmd.CommandText = csql
                        'crear_parametros_item_prog_prod(ocmd)
                        Dim fecha_act As Date = comunes.g_fechahora
                        ocmd.Parameters.Clear()
                        ocmd.Parameters.Add("@f0318_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
                        ocmd.Parameters.Add("@f0318_id_mov_item", NpgsqlDbType.Numeric).Value = id_mov_item
                        ocmd.Parameters.Add("@f0318_id_mov_docto", NpgsqlDbType.Numeric).Value = dg_items.CurrentRow.Cells("dgocell_ident_doc").Value
                        ocmd.Parameters.Add("@f0318_id_item", NpgsqlDbType.Integer).Value = CInt(dg_items.CurrentRow.Cells("dgocell_id_item").Value)
                        ocmd.Parameters.Add("@f0318_id_bodega", NpgsqlDbType.Integer).Value = CInt(cm_bodegas.SelectedValue)
                        ocmd.Parameters.Add("@f0318_id_documento", NpgsqlDbType.Varchar).Value = codigo_documento
                        ocmd.Parameters.Add("@f0318_fecha_movimiento", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value
                        ocmd.Parameters.Add("@f0318_info_trazable", NpgsqlDbType.Varchar).Value = orow("info_trazable")
                        ocmd.Parameters.Add("@f0318_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
                        ocmd.Parameters.Add("@f0318_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza

                        verror = "N"
                        Try
                            'Compila el comando en la Base de datos.
                            ocmd.Prepare()
                        Catch ex As Exception
                            verror = "S"
                            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString + vbCrLf + csql)
                        End Try
                        If verror = "N" Then
                            Try
                                ocmd.ExecuteNonQuery()
                            Catch ex As Exception
                                verror = "S"
                                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
                            End Try
                        End If

                        ocmd = Nothing
                        oconn_form.Close()


                    Next
                End If
                cargar_items_dg()
            End If
        End If
    End Sub
    Private Sub anular_info_trazabilidad_item(ByVal id_mov_docto As Integer)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0318_trazabilidad_movimientos set "
        csql += "f0318_anulado = 'S',"
        csql += "f0318_usuario_anular = @f0318_usuario_modificar,"
        csql += "f0318_usuario_modificar = @f0318_usuario_modificar,"
        csql += "f0318_fm = @f0318_fm"
        csql += " where f0318_id_documento = '" & codigo_documento & "' and f0318_id_mov_docto = '" & id_mov_docto & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0318_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0318_fm", NpgsqlDbType.Timestamp).Value = fecha_act
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        If tx_registro_seleccionado.Text = "" Then
            Exit Sub
        End If
        If traslado = "S" Then
            MsgBox("Comando no desarrollado para Traslados.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim row_item_modificar As DataRow()
        row_item_modificar = otb_items_documento.Select("f0309_id_mov_docto ='" & registro_sel & "'" & " and f0309_id_documento = '" & codigo_documento & "'")
        Dim id_mov_item As Integer = row_item_modificar(0)("f0309_id_mov_item")
        cl_utilidades_gestion_compras.modificar_movimientos_inventarios(id_mov_item, dg_items.CurrentRow.Cells("dgocell_id_item").Value,
                                                                        cm_bodegas.SelectedValue, 0, 0, "S",
                                                                        vg_id_cia, vg_usuario_autoriza)
        cargar_items_dg()

    End Sub

    Private Sub bt_editar_Click(sender As Object, e As EventArgs) Handles bt_editar.Click
        If tx_registro_seleccionado.Text = "" Then
            Exit Sub
        End If
        Dim info_item As cl_estructuras_variables.info_item_mov_inventario
        info_item = cl_utilidades_gestion_compras.form_suministrar_item_cantidad(vg_usuario_autoriza, vg_id_cia, dtp_fecha.Value, "",
                                                                     dg_items.CurrentRow.Cells("dgocell_id_item").Value,
                                                                     dg_items.CurrentRow.Cells("dgocell_cant_movimiento").Value)
        If info_item.id_item = 0 Then
            Exit Sub
        End If
        Dim row_item_modificar As DataRow()
        row_item_modificar = otb_items_documento.Select("f0309_id_mov_docto ='" & registro_sel & "'" & " and f0309_id_documento = '" & codigo_documento & "'")
        Dim id_mov_item As Integer = row_item_modificar(0)("f0309_id_mov_item")
        Dim entrada As Decimal = 0
        Dim salida As Decimal = 0
        If row_item_modificar(0)("f0309_entrada") = 0 Then
            salida = info_item.cantidad
        Else
            entrada = info_item.cantidad
        End If
        cl_utilidades_gestion_compras.modificar_movimientos_inventarios(id_mov_item, dg_items.CurrentRow.Cells("dgocell_id_item").Value,
                                                                        cm_bodegas.SelectedValue, entrada, salida, "N",
                                                                        vg_id_cia, vg_usuario_autoriza)
        cargar_items_dg()

    End Sub

    Private Sub validar_bodegas_traslado()
        If cm_bodegas.SelectedIndex = -1 Or (cm_bodega_destino.SelectedIndex = -1 And cm_bodega_destino.Visible = True) Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Seleccione valores de bodega de origen y/o bodega destino"
            Exit Sub
        End If
        If cm_bodegas.SelectedValue = cm_bodega_destino.SelectedValue Then
            verror_requisitos = "S"
            vmensaje_requisitos = "La bodega de origen y la bodega de destino no puede ser la misma."
        End If
    End Sub


    Private Sub generar_nuevo_movimiento()
        verror_requisitos = "N"
        id_item = 0
        cant_solalm_pend = 0
        id_doc_ref = ""

        validar_bodegas_traslado()
        'id_item
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If dg_items.Rows.Count = 0 Then
            actualizar_cambios_encabezado()
        End If
        'Si el movimiento se genera basado en una solicitud de almacen
        If basado_sol_alm = "S" Then
            csql = comunes.suministrar_valor_variable_configuracion("ST-0300-28", vg_id_cia)
            csql = csql.Replace("$df001$", database.obtener_esquema)
            csql = csql.Replace("$001$", vg_id_cia)
            csql = csql.Replace("$002$", cm_bodega_destino.SelectedValue)
            csql = csql.Replace("$003$", cm_bodegas.SelectedValue)
            Dim orow As DataRow() = Nothing
            'Identificamos el item que queremos entregar abriendo seleccionandolo con doble clik
            'desde el visor de datos con todos los pendientes por entregar.
            orow = cl_utilidades_datatables.suministrar_datagridviewrows_visor(csql, vg_id_cia,
                                                                                              vg_usuario_autoriza,
                                                                                              "Pendientes por entregar",
                                                                                              "Pendientes por entregar")
            If IsNothing(orow) = True Then
                Exit Sub
            End If
            'asigno el valor a las variables para poder generar el movimiento de inventario del item.
            id_item = orow(0)("item")
            id_item_sol = orow(0)("id_itsalm")
            cant_solalm_pend = orow(0)("cant_pendiente")
            cant_solalm_tot = orow(0)("cantidad")
            id_doc_ref = orow(0)("id_salm")
        End If

        'Dim info_item(10) As Decimal
        'creo la estructura de la variable que usaremos para realizar el movimiento de inventario.
        Dim info_item_mov_inventario As cl_estructuras_variables.info_item_mov_inventario = Nothing
        If traslado = "N" Then
            info_item_mov_inventario = cl_utilidades_gestion_compras.form_suministrar_item_cantidad(vg_usuario_autoriza, vg_id_cia, dtp_fecha.Value, "",
                                                                                 id_item,
                                                                                 cant_solalm_pend, cm_bodegas.SelectedValue, m_inventario,
                                                                                                    m_edit_item, m_ent_sal, m_clasificador, m_cantidad,
                                                                                                    m_info_trazabilidad)
        Else
            info_item_mov_inventario = cl_utilidades_gestion_compras.form_suministrar_item_cantidad(vg_usuario_autoriza, vg_id_cia, dtp_fecha.Value, "",
                                                                                 id_item,
                                                                                 cant_solalm_pend, cm_bodegas.SelectedValue, "N", "S", "S", "N", "S", "S")
        End If

        If info_item_mov_inventario.id_item = 0 Then
            Exit Sub
        End If
        Dim id_mov_docto As Integer
        Dim fecha_movimiento As DateTime
        Dim cant_ent As Decimal = 0
        Dim cant_sal As Decimal = 0
        Dim clasificador As Decimal = info_item_mov_inventario.clasificador 'info_item(4)

        If info_item_mov_inventario.tipo_movimiento = 1 Then  'info_item(3)
            cant_ent = info_item_mov_inventario.cantidad 'info_item(2)
        Else
            cant_sal = info_item_mov_inventario.cantidad 'info_item(2)
        End If

        'Identifico el consecutivo de registros en el documento
        csql = "select max(f0309_id_mov_docto) as id_mov_docto, max(f0309_fecha_movimiento) as fecha_movimiento" _
            & " from " & database.obtener_esquema & ".tb0309_items_movimientos" _
            & " where f0309_id_documento = '" & codigo_documento & "'"
        'Clipboard.SetDataObject(csql)
        'MsgBox(csql)
        Dim otb_maxi As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim rowmax As DataRow()
        rowmax = otb_maxi.Select("")
        If IsDBNull(rowmax(0)("id_mov_docto")) = False Then
            id_mov_docto = rowmax(0)("id_mov_docto") + 1
            fecha_movimiento = rowmax(0)("fecha_movimiento")
        Else
            id_mov_docto = 1
            fecha_movimiento = dtp_fecha.Value
        End If

        'MsgBox(id_mov_docto & " -- " & fecha_movimiento.ToString)

        'Verifico si es viable la insercion del nuevo movimiento puesto que puedo variar la fecha del documento y usar fechas anteriores.
        Dim otb_con_nuevo_mov As DataTable
        otb_con_nuevo_mov = cl_utilidades_gestion_compras.verificar_viabilidad_modificacion_movimiento_inventario(0,
                                                                                                                  info_item_mov_inventario.id_item,
                                                                                                                  cm_bodegas.SelectedValue,
                                                                                                                  dtp_fecha.Value,
                                                                                                                  cant_ent,
                                                                                                                  cant_sal,
                                                                                                                  "N", vg_id_cia,
                                                                                                                  vg_usuario_autoriza)
        If otb_con_nuevo_mov Is Nothing Then
            MsgBox("Cambio no realizado, Inventario Negativo", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario(codigo_documento, cm_bodegas.SelectedValue, id_mov_docto,
                                                                         info_item_mov_inventario.id_item,
                                                                         cant_ent, cant_sal,
                                                                         fecha_movimiento, vg_usuario_autoriza,
                                                                         vg_id_cia, 0,
                                                                         info_item_mov_inventario.clasificador,
                                                                         info_item_mov_inventario.info_trazabilidad,
                                                                         id_doc_ref)
        csql = "select f0309_id_mov_item, f0309_costo_unit_promedio from " & database.obtener_esquema & ".tb0309_items_movimientos"
        csql += " where f0309_id_documento = '" & codigo_documento & "'"
        Dim otb_corr As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim item_correl As Integer
        If otb_corr.Rows.Count > 0 Then
            item_correl = otb_corr(0)("f0309_id_mov_item")
        Else
            MsgBox("Movimiento no realizado", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim costo_unit As Decimal = otb_corr(0)("f0309_costo_unit_promedio")
        If traslado = "S" Then
            'la cantidad que entra a la bodega destino es igual a la cantidad que sale de la bodega origen
            cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario(codigo_documento, cm_bodega_destino.SelectedValue, id_mov_docto + 1,
                                                                             info_item_mov_inventario.id_item,
                                                                             cant_sal, 0, fecha_movimiento, vg_usuario_autoriza,
                                                                             vg_id_cia, 0, clasificador,
                                                                             info_item_mov_inventario.info_trazabilidad,
                                                                             id_doc_ref, costo_unit,,, item_correl)
            If basado_sol_alm = "S" Then
                cant_solalm_ent = cant_solalm_ent + cant_sal
                'MsgBox(id_item_sol)
                actualizar_entrega_solalm()
            End If
        End If
        basado_sol_alm = "N"
        bloquear_encabezado()
        cargar_items_dg()
    End Sub

    Private Sub actualizar_entrega_solalm()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0317_solicitudes_almacen_detalle set"
        csql += " f0317_cantidad_entregada = @f0317_cantidad_entregada,"
        csql += " f0317_estado = @f0317_estado"
        csql += " where f0317_id_item_sol = @f0317_id_item_sol"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0317_cantidad_entregada", NpgsqlDbType.Numeric).Value = cant_solalm_ent
        'MsgBox(cant_solalm_ent)
        Dim estado As String = "A"
        If cant_solalm_tot - cant_solalm_ent <= 0 Then
            estado = "C"
        End If
        ocmd.Parameters.Add("@f0317_estado", NpgsqlDbType.Varchar).Value = estado
        ocmd.Parameters.Add("@f0317_id_item_sol", NpgsqlDbType.Integer).Value = id_item_sol
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub bt_nuevo_Click(sender As Object, e As EventArgs) Handles bt_nuevo.Click
        basado_sol_alm = "N"
        generar_nuevo_movimiento()
    End Sub
    Private Sub dg_items_KeyDown(sender As Object, e As KeyEventArgs) Handles dg_items.KeyDown
        If (e.KeyCode = Keys.A AndAlso e.Modifiers = Keys.Control) Then
            basado_sol_alm = "N"
            generar_nuevo_movimiento()
        End If
    End Sub

    Private Sub bt_genmov_apartir_solalm_Click(sender As Object, e As EventArgs) Handles bt_genmov_apartir_solalm.Click
        basado_sol_alm = "S"
        generar_nuevo_movimiento()
        basado_sol_alm = "N"
    End Sub

    Private Sub dtp_fecha_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtp_fecha.Validating
        Dim odate As DateTime = comunes.g_fechahora
        If dtp_fecha.Value > odate Then
            dtp_fecha.Value = odate
            MsgBox("Fecha invalida", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Private Sub bt_nueva_nota_Click(sender As System.Object, e As System.EventArgs) Handles bt_nueva_nota.Click
        If id_documento = 0 Then
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_nuevo_seg_accion As New camocontrol.fm_0600_gestion_seguimiento
        'oform_grilla_programacion.ods_hijo = ods
        oform_nuevo_seg_accion.vf_oform_padre = Me
        oform_nuevo_seg_accion.vg_id_cia = vg_id_cia
        oform_nuevo_seg_accion.tipo_nota = otipo_nota
        oform_nuevo_seg_accion.id_accion = id_documento
        oform_nuevo_seg_accion.vf_elemento_nuevo = "S"
        oform_nuevo_seg_accion.vg_usuario_autoriza = vg_usuario_autoriza
        oform_nuevo_seg_accion.ShowDialog()
        lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_documento, vg_id_cia)
    End Sub
    Private Sub bt_consultar_notas_Click(sender As System.Object, e As System.EventArgs) Handles bt_consultar_notas.Click
        If id_documento = 0 Then
            Exit Sub
        End If
        csql = "SELECT f0606_id_seguimiento_accion as id_sgmnto, f0606_seguimiento_accion as seguimiento," _
            & " to_number(f0606_nivel_cumplimiento, '999') || '%' as cumplimiento," _
            & " to_char(f0606_fecha_fin, 'YYYY-MM-DD HH12:MI AM') as fecha_fin," _
            & " EXTRACT(DAY FROM f0606_fecha_fin - f0606_fecha_inicio) || ' dias ' ||" _
            & " EXTRACT(HOUR FROM f0606_fecha_fin - f0606_fecha_inicio) || ' horas ' ||" _
            & " EXTRACT(MINUTE FROM f0606_fecha_fin - f0606_fecha_inicio) || ' minutos' as duracion," _
            & " f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as emisor" _
            & " FROM " & database.obtener_esquema & ".tb0606_seguimientos_acciones" _
             & " join " & database.obtener_esquema & ".tb0200_terceros" _
                & " on f0606_usuario_crear = f0200_id_tercero" _
            & " where f0606_id_documento = '" & id_documento & "'" & " and f0606_tipo_nota = '" & otipo_nota & "'" _
            & " order by f0606_fecha_fin desc"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.titulo_formulario = "Listado de Seguimientos"
        oform_mostrar_datos.ocontexto_form = "Anotaciones Documentos Movimientos de Inventario"
        oform_mostrar_datos.id_oreg_padre = id_documento
        oform_mostrar_datos.ShowDialog()
        lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_documento, vg_id_cia)
    End Sub

    Private Sub bt_generar_informe_Click(sender As Object, e As EventArgs) Handles bt_generar_informe.Click
        cl_informes_comunes.reporte_doc_mov_inventario(vg_id_cia, lb_cod_documento.Text)
    End Sub

#Region "Funciones para crear archivo plano SIESA"


    '''PARA CREAR EL ARCHIVO PLANO DE LA OC EN SIESA
    ''' <summary>
    ''' Genera un archivo de texto con N líneas construidas mediante las funciones de línea fija.
    ''' </summary>
    Public Sub GenerarArchivoTexto(rutaArchivo As String)

        'Para usar los servicios de EstructuraSiesaService, creo la variable de servicio svc
        Dim svc As New EstructuraSiesaService()

        Dim lineas As New List(Of String)

        'asegurarte de que siempre use la cultura invariable (útil en sistemas configurados con distintos formatos regionales):
        Dim fechaActual As String = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)

#Region "SECCION INICIO"

        ''MATRIZ DE DEFINICION DE CAMPOS SECCION INICIO
        Dim MatSeccion(,) As String = {
            {"F_NUMERO_REG", "Numérico", "1", "7", "0", "ND"},
            {"F_TIPO_REG", "Numérico", "8", "4", "0", "0000"},
            {"F_SUBTIPO_REG", "Numérico", "12", "2", "0", "00"},
            {"F_VERSION_REG", "Numérico", "14", "2", "0", "01"},
            {"F_CIA", "Numérico", "16", "3", "0", "001"}
        }
        'CONVIERTO LA MATRIZ EN UNA LISTA DE OBJETOS DTO PARA LINEA INICIAL
        Dim ListaDtosSeccion As IEnumerable(Of DefinicionEstructuraSiesaDto) = svc.ConvertirMatriz(MatSeccion)
        ' 1. Crear una línea inicial con espacios
        Dim lineaDinamica As String = svc.CrearLineaInicial(18)
        'Apartir de aqui se pueden usar los campos para construir la linea inicial dinamicamente
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_NUMERO_REG", "1")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_TIPO_REG", "0")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_SUBTIPO_REG", "00")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_VERSION_REG", "01")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_CIA", "1")
        lineas.Add(lineaDinamica)
#End Region

#Region "SECCION INICIO DOCUMENTO"

        Dim id_tipo_docto As String = "OC" 'OC o OS SEGÚN LO QUE ESTE HACIENDO debe tener tamaño 3
        Dim f420_id_tercero_sol_comp As String = "94492746" ''CEDULA DEL COMPRADOR
        Dim f462_notas As String = lb_cod_documento.Text.Trim & " <=> " & tx_docto_origen.Text.Trim '"ESTA ES LA NOTA DEL DOCUMENTO" 'NOTA DEL DOCUMENTO
        Dim f420_num_docto_referencia As String = "CIM-" & tx_docto_contable.Text.Trim ' PARA REFERENCIAR EL RSC DEL CAMO

        'CONVIERTO LA MATRIZ EN UNA LISTA DE OBJETOS DTO PARA LINEA INICIO DOCUMENTO (DOCUMENTOS VERSION 03)
        MatSeccion = {
            {"F_NUMERO_REG", "Numérico", "1", "7", "0", "ND"},
            {"F_TIPO_REG", "Numérico", "8", "4", "0", "450"},
            {"F_SUBTIPO_REG", "Numérico", "12", "2", "0", "00"},
            {"F_VERSION_REG", "Numérico", "14", "2", "0", "02"},
            {"F_CIA", "Numérico", "16", "3", "0", "001"},
            {"F_CONSEC_AUTO_REG", "Numérico", "19", "1", "0", "1"},
            {"f350_id_co ", "Alfanumérico", "20", "3", "0", "001"},
            {"f350_id_tipo_docto", "Alfanumérico", "23", "3", " ", "SA"},
            {"f350_consec_docto", "Numérico", "26", "8", "0", "0"},
            {"f350_fecha", "Alfanumérico", "34", "8", " ", "20260216"},
            {"f350_id_tercero", "Alfanumérico", "42", "15", " ", " "},
            {"f350_id_clase_docto", "Numérico", "57", "3", "0", "62"},
            {"f350_ind_estado", "Numérico", "60", "1", "0", "1"},
            {"f350_ind_impresión", "Numérico", "61", "1", "0", "0"},
            {"f350_notas", "Alfanumérico", "62", "255", " ", "NOTAS 255"},
            {"f450_id_concepto", "Numérico", "317", "3", "0", "603"},
            {"f450_id_bodega_salida", "Alfanumérico", "320", "5", " ", "09"},
            {"f450_id_bodega_entrada", "Alfanumérico", "325", "5", " ", " "},
            {"f450_docto_alterno", "Alfanumérico", "330", "15", " ", " "},
            {"f350_id_co_base", "Alfanumérico", "345", "3", " ", "001"},
            {"f350_id_tipo_docto_base", "Alfanumérico", "348", "3", " ", "SA"},
            {"f350_consec_docto_base", "Numérico", "351", "8", "0", "0"},
            {"f462_id_vehiculo", "Alfanumérico", "359", "10", " ", " "},
            {"f462_id_tercero_transp", "Alfanumérico", "369", "15", " ", " "},
            {"f462_id_sucursal_transp", "Alfanumérico", "384", "3", " ", " "},
            {"f462_id_tercero_conductor", "Alfanumérico", "387", "15", " ", " "},
            {"f462_nombre_conductor", "Alfanumérico", "402", "50", " ", " "},
            {"f462_identif_conductor", "Alfanumérico", "452", "15", " ", " "},
            {"f462_numero_guia", "Alfanumérico", "467", "30", " ", " "},
            {"f462_cajas", "Numérico", "497", "15", " ", " "},
            {"f462_peso", "Numérico", "512", "20", " ", " "},
            {"f462_volumen", "Numérico", "532", "20", " ", " "},
            {"f462_valor_seguros", "Numérico", "552", "20", " ", " "},
            {"f462_notas", "Alfanumérico", "572", "255", " ", " "}
        }
        'CONVIERTO LA MATRIZ EN UNA LISTA DE OBJETOS DTO PARA LINEA INICIO
        ListaDtosSeccion = svc.ConvertirMatriz(MatSeccion)
        ' 1. Crear una línea inicial con espacios
        lineaDinamica = svc.CrearLineaInicial(745)
        'Apartir de aqui se pueden usar los campos para construir la linea inicial dinamicamente
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_NUMERO_REG", "2")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_TIPO_REG", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_SUBTIPO_REG", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_VERSION_REG", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_CONSEC_AUTO_REG", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_id_co", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_id_tipo_docto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_consec_docto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_fecha", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_id_tercero", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_id_clase_docto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_ind_estado", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_ind_impresión", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_notas", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f450_id_concepto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f450_id_bodega_salida", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f450_id_bodega_entrada", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f450_docto_alterno", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_id_co_base", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_id_tipo_docto_base", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f350_consec_docto_base", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_id_vehiculo", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_id_tercero_transp", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_id_sucursal_transp", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_id_tercero_conductor", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_nombre_conductor", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_identif_conductor", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_numero_guia", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_cajas", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_peso", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_volumen", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_valor_seguros", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f462_notas", "")

#End Region

#Region "SECCION MOVIMIENTOS ITEM DEL DOCUMENTO"
        'Hago un recorrido por cada item del datagridview para crear las lineas de items

        Dim lineaItemContador As Integer = 3 'INICIA EN 3 PORQUE LA LINEA 1 ES INICIO Y LA 2 ES DOCUMENTO
        Dim f421_cant_pedida_base As String = vbEmpty
        Dim f421_precio_unitario As String = vbEmpty
        Dim f421_referencia_item As String = vbEmpty
        Dim f421_id_motivo As String = "01" '01 PARA PRODUCTOS Y 73 PARA SERVICIOS
        Dim f421_notas As String = vbEmpty

        'CONVIERTO LA MATRIZ EN UNA LISTA DE OBJETOS DTO PARA LINEA MOVIIENTO DEL DOCUMENTO (MOVIMIENTO VERSION 04)
        MatSeccion = {
            {"F_NUMERO_REG", "Numérico", "1", "7", "0", "CONSEC GLOBAL"},
            {"F_TIPO_REG", "Numérico", "8", "4", "0", "421"},
            {"F_SUBTIPO_REG", "Numérico", "12", "2", "0", "00"},
            {"F_VERSION_REG", "Numérico", "14", "2", "0", "04"},
            {"F_CIA", "Numérico", "16", "3", "0", "001"},
            {"f421_id_co", "Alfanumérico", "19", "3", "0", "001"},
            {"f421_id_tipo_docto", "Alfanumérico", "22", "3", " ", "OC o OS SEGÚN LO QUE ESTE HACIENDO"},
            {"f421_consec_docto", "Numérico", "25", "8", "0", "1"},
            {"f421_nro_registro", "Numérico", "33", "10", "0", "1"},
            {"F_CAMPO", "Alfanumérico", "43", "55", " ", " "},
            {"f421_id_bodega", "Alfanumérico", "98", "5", " ", "09"},
            {"f421_id_concepto", "Numérico", "103", "3", "0", "401"},
            {"f421_id_motivo", "Alfanumérico", "106", "2", " ", "01 PARA PRODUCTOS Y 73 PARA SERVICIOS"},
            {"f421_ind_obsequio", "Numérico", "108", "1", "0", "0"},
            {"f421_id_co_movto", "Alfanumérico", "109", "3", " ", "001"},
            {"F_CAMPO", "Alfanumérico", "112", "2", " ", " "},
            {"f421_id_ccosto_movto", "Alfanumérico", "114", "15", " ", " "},
            {"f421_id_proyecto", "Alfanumérico", "129", "15", " ", " "},
            {"f421_id_unidad_medida", "Alfanumérico", "144", "4", " ", "UND"},
            {"f421_cant_pedida_base", "Numérico", "148", "20", "0", "Cantidad pedida"},
            {"f421_fecha_entrega", "Alfanumérico", "168", "8", " ", "FECHA REQUERIDA O LA DEL SISTEMA"},
            {"f421_cod_item_prov", "Alfanumérico", "176", "15", " ", " "},
            {"f421_precio_unitario", "Numérico", "191", "20", "0", "Precio unitario"},
            {"f421_notas", "Alfanumérico", "211", "255", " ", "NOTA DEL MOV"},
            {"f421_detalle", "Alfanumérico", "466", "2000", " ", " "},
            {"F_DESC_ITEM", "Alfanumérico", "2466", "40", " ", " "},
            {"F_ID_UM_INVENTARIO", "Alfanumérico", "2506", "4", " ", " "},
            {"f421_id_item", "Numérico", "2510", "7", "0", "0"},
            {"f421_referencia_item", "Alfanumérico", "2517", "50", " ", "REFERENCIA"},
            {"f421_codigo_barras", "Alfanumérico", "2567", "20", " ", " "},
            {"f421_id_ext1_detalle", "Alfanumérico", "2587", "20", " ", " "},
            {"f421_id_ext2_detalle", "Alfanumérico", "2607", "20", " ", " "},
            {"f421_id_un_movto", "Alfanumérico", "2627", "20", " ", "099"},
            {"f421_tasa_dscto_condicionado", "Numérico", "2647", "8", "0", "000.0000"}
        }
        'CONVIERTO LA MATRIZ EN UNA LISTA DE OBJETOS DTO PARA LINEA INICIO
        ListaDtosSeccion = svc.ConvertirMatriz(MatSeccion)
        lineaItemContador = 3 'INICIA EN 3 PORQUE LA LINEA 1 ES INICIO Y LA 2 ES DOCUMENTO

        'Hago un recorrido por cada item del datagridview para crear las lineas de items
        For Each row As DataGridViewRow In dg_items.Rows
            f421_cant_pedida_base = DecimalFormatter.Format(CDbl(row.Cells("dgocell_cantidad_solicitada").Value.ToString), 4)
            f421_precio_unitario = DecimalFormatter.Format(CDbl(row.Cells("dgocell_costo_unitario").Value.ToString), 4)
            f421_referencia_item = row.Cells("dgocell_cod_uno").Value.ToString


            ' Buscar items en el datatable de items servicios camo
            'Dim t_item = (From c In otb_items_servicios_camo.AsEnumerable()
            '              Where c.Field(Of Integer)("f0300_id_item") = row.Cells("dgocell_item").Value
            '              Select c).FirstOrDefault()
            'If t_item IsNot Nothing Then
            '    If t_item.Field(Of Integer)("f0300_id_tipo_item") <> 4 Then
            '        f421_id_motivo = "01" '01 PARA PRODUCTOS Y 73 PARA SERVICIOS
            '    Else
            '        f421_id_motivo = "73" '01 PARA PRODUCTOS Y 73 PARA SERVICIOS
            '    End If

            'End If


            Dim notas As String = lb_cod_documento.Text.Trim & " <=> " & tx_docto_origen.Text.Trim

            f421_notas = notas.PadLeft(255) 'NOTA DEL MOVIMIENTO LIMITADA A 255 CARACTERES
            f421_notas = f421_notas.Replace(vbCrLf, " ").Replace(vbLf, " ")

            ' 1. Crear una línea inicial con espacios
            lineaDinamica = svc.CrearLineaInicial(2654)

            'Apartir de aqui se pueden usar los campos para construir la linea inicial dinamicamente
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_NUMERO_REG", lineaItemContador.ToString) 'CONTEO DE LINEA INICIA EN 3 Y AUMENTA
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_TIPO_REG", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_SUBTIPO_REG", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_VERSION_REG", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_CIA", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_co", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_tipo_docto", id_tipo_docto) 'Cambiar a OS cuando corresponda
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_consec_docto", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_nro_registro", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_bodega", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_concepto", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_motivo", f421_id_motivo) '01 PARA PRODUCTOS Y 73 PARA SERVICIOS
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_ind_obsequio", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_co_movto", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_unidad_medida", "") 'UNIDAD DE MEDIDA
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_cant_pedida_base", f421_cant_pedida_base) 'Cantidad pedida
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_fecha_entrega", fechaActual)
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_precio_unitario", f421_precio_unitario)
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_notas", f421_notas) 'NOTA DEL MOVIMIENTO
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_item", "") 'ID DEL PRODUCTO SE LO METI
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_referencia_item", f421_referencia_item) 'REFERENCIA DEL PRODUCTO
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_id_un_movto", "")
            lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f421_tasa_dscto_condicionado", "")
            lineas.Add(lineaDinamica)

            lineaItemContador += 1
        Next

#End Region

#Region "SECCION CIERRE"

        'lineaItemContador += 1

        'CONVIERTO LA MATRIZ EN UNA LISTA DE OBJETOS DTO PARA LINEA FINAL DEL DOCUMENTO
        MatSeccion = {
            {"F_NUMERO_REG", "Numérico", "1", "7", "0", "CONSECUTIVO DE LINEA"},
            {"F_TIPO_REG", "Numérico", "8", "4", "0", "9999"},
            {"F_SUBTIPO_REG", "Numérico", "12", "2", "0", "00"},
            {"F_VERSION_REG", "Numérico", "14", "2", "0", "01"},
            {"F_CIA", "Numérico", "16", "3", "0", "001"}
        }
        'CONVIERTO LA MATRIZ EN UNA LISTA DE OBJETOS DTO PARA LINEA INICIO
        ListaDtosSeccion = svc.ConvertirMatriz(MatSeccion)
        ' 1. Crear una línea inicial con espacios
        lineaDinamica = svc.CrearLineaInicial(18)
        'Apartir de aqui se pueden usar los campos para construir la linea inicial dinamicamente
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_NUMERO_REG", lineaItemContador.ToString) 'CONTEO DE LINEA INICIA EN 3 Y AUMENTA
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_TIPO_REG", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_SUBTIPO_REG", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_VERSION_REG", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_CIA", "")
        lineas.Add(lineaDinamica)
#End Region

        System.IO.File.WriteAllLines(rutaArchivo, lineas, System.Text.Encoding.UTF8)
    End Sub



#End Region

End Class
