Imports System.ComponentModel

Public Class fm_0400_pp_edicion_programa
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_prog_prod As Integer
    Public id_item_clonar As Integer 'Es el id del item padre de todo el arbol
    Public id_item_pp As Integer 'el f0401_id_ipp de un programa de produccion.
    Public tree_path_base As String
    Public nodo_buscar As String = ""
    Public cantidad_original As Decimal = 0
    Public otb_items_programa_produccion As DataTable
    Public item_principal_seleccionado_tree As String = "N" 'Para indicar si es un IPP inicial, para saber si permito o no dividir en varios registros la cantidad.

    Private otipo_nota As String

    Private orowgrid As DataGridViewRow
    Private ocmb_grid As DataGridViewComboBoxCell
    Private otextgrid As DataGridViewTextBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell
    Private obuttongrid As DataGridViewButtonCell
    Private olinkcell As DataGridViewLinkCell

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private otb_items_plantillas As DataTable
    Private otb_plantillas As DataTable
    Private otb_info_personal As DataTable
    Private otb_edicion As DataTable 'Datatable que almacenara los cambios a realizar en las IPP
    Private otb_reportes_produccion As DataTable
    Private otb_info_personal_seg As DataTable
    Private otb_personal_grillas As DataTable

    Private path_registro_original As String = ""
    Private id_estructura_padre_filtrado As Integer


    Private tipo_registro As String
    Private filtro_rama As String = "N"
    Private cantidad_dimanica As Decimal 'Cantidad que usare para asignar cantidad de items de acuerdo a recorrido por treeview
    Private cantidad_programada As Decimal  'Cantidad total programada, sumatoria de todos los rows de la dg_datos
    Private tamano_bache As Decimal
    Private fecha_op_inicio As Date
    Private fecha_op_final As Date
    Private id_item_seleccionado_tree As Integer 'El id_item del nodo seleccionado
    Public name_nodo_creado As String
    Private id_ipp_nodo_padre As String 'el id_ipp del nodo inicial de un ramal del arbol
    Private row_dg_activo As Integer

    Private Sub fm_0400_pp_edicion_programa_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_generar_informe.Enabled = False
        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False
        bt_nuevo.Enabled = False

        bt_grabar_item_dg.Enabled = False 'Para asegurar que se halla seleccionado un item del dg_datos
        bt_eliminar_item_dg.Enabled = False 'Para asegurar que se halla seleccionado un item del dg_datos

        If item_principal_seleccionado_tree = "S" Then
            bt_eliminar_item_dg.Visible = False
            bt_nuevo_item_dg.Visible = False
        End If
        tx_diferencia_cantidades.Text = 0


        ' Set the Format type and the CustomFormat string.
        dtp_fecha_ini.Format = DateTimePickerFormat.Custom
        dtp_fecha_ini.CustomFormat = "yyyy/MM/dd  HH:mm"

        dtp_fecha_fin.Format = DateTimePickerFormat.Custom
        dtp_fecha_fin.CustomFormat = "yyyy/MM/dd  HH:mm"

        tx_cantidad_original.Text = cantidad_original


        dg_personal.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_personal.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_personal.AllowUserToAddRows = True
        dg_personal.AllowUserToDeleteRows = True
        otb_info_personal = comunes.suministrar_otb_info_personal(vg_id_cia, "S")
        otb_personal_grillas = otb_info_personal.Copy
        With dgocell_id_tercero
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_personal_grillas
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        End With
        Dim otb_plantas_produccion As DataTable
        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-13", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        otb_plantas_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_planta
            'Valor que se muestra al usuario
            .DisplayMember = "f0100_nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0100_id_estructura"
            'Origen de Datos del ComboBox
            .DataSource = otb_plantas_produccion
            .DropDownStyle = ComboBoxStyle.DropDown
            '.AutoCompleteMode = AutoCompleteMode.Suggest
            '.AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        'Agrego la informacion del IPP que voy a editar
        adicionar_ipp()
    End Sub


    Private Sub adicionar_ipp()
        'Cargo la informacion del IPP que voy a editar
        Dim orows_prog As DataRow()
        orows_prog = otb_items_programa_produccion.Select("f0401_id_ipp = '" & id_item_pp & "'")
        Dim unid_add As Decimal = 0
        For Each orow As DataRow In orows_prog
            tamano_bache = orow("f0401_unid_x_bache")
            If dg_datos.Rows.Count = 0 Then
                unid_add = orow("f0401_cantidad")
            Else
                If CDec(tx_diferencia_cantidades.Text) > 0 Then
                    unid_add = CDec(tx_diferencia_cantidades.Text)
                Else
                    unid_add = orow("f0401_cantidad")
                End If
            End If
            path_registro_original = orow("f0401_tree_path") & id_item_pp & "-"
            agregar_fila_dg_programacion(unid_add, orow("f0401_cant_baches"),
                                         CDate(orow("f0401_fecha_inicio")).ToString("yyyy/MM/dd HH:mm"),
                                         CDate(orow("f0401_fecha_final")).ToString("yyyy/MM/dd HH:mm"))
        Next
    End Sub
    Private Sub cargar_funcionarios()
        Dim seleyo As String = "N"
        dg_personal.Rows.Clear()
        csql = "select * from " & database.obtener_esquema & ".tb0607_seg_acc_personal" _
                        & " where f0607_id_seguimiento_accion = '" & id_item_pp & "'" _
                        & " and f0607_anulado = 'N'" _
                        & " order by f0607_id_seg_personal"
        otb_info_personal_seg = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub agregar_fila_dg_programacion(ByVal ocantidad As Decimal,
                                            ByVal baches As Decimal, ByVal fecha_ini As String,
                                            ByVal fecha_fin As String)
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = ocantidad
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = baches
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = fecha_ini
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = fecha_fin
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_datos.Rows.Add(orowgrid)
    End Sub

    Private Sub bt_nuevo_item_dg_Click(sender As Object, e As EventArgs) Handles bt_nuevo_item_dg.Click
        adicionar_ipp()
        validar_cant_tot_programada()
    End Sub

    Private Sub bt_eliminar_item_dg_Click(sender As Object, e As EventArgs) Handles bt_eliminar_item_dg.Click
        dg_datos.Rows.Remove(dg_datos.Rows.Item(row_dg_activo))
        validar_cant_tot_programada()
        bt_eliminar_item_dg.Enabled = False
        If dg_datos.Rows.Count = 0 Then
            tx_diferencia_cantidades.Text = cantidad_original * -1
        End If
    End Sub

    Private Sub dg_datos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_datos.CellClick
        If dg_datos.Rows.Count = 0 Then
            Exit Sub
        End If
        bt_grabar_item_dg.Enabled = True
        bt_eliminar_item_dg.Enabled = True
        row_dg_activo = dg_datos.CurrentRow.Index
        'MsgBox(row_dg_activo)
        tx_cantidad.Text = dg_datos.CurrentRow.Cells("dgocell_cantidad").Value
        tx_baches.Text = dg_datos.CurrentRow.Cells("dgocell_baches").Value
        dtp_fecha_ini.Value = dg_datos.CurrentRow.Cells("dgocell_fecha_inicio").Value
        dtp_fecha_fin.Value = dg_datos.CurrentRow.Cells("dgocell_fecha_fin").Value
    End Sub

    Private Sub tx_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_cantidad.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_baches_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_baches.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_baches_DoubleClick(sender As Object, e As EventArgs) Handles tx_baches.DoubleClick
        If tx_baches.Text = "" Then
            tx_baches.Text = 0
        End If
        If IsNumeric(tx_baches.Text) = False Or tx_baches.Text = 0 Then
            Exit Sub
        End If
        tx_cantidad.Text = Math.Round(tx_baches.Text * tamano_bache, 4)
    End Sub

    Private Sub tx_cantidad_Validating(sender As Object, e As CancelEventArgs) Handles tx_cantidad.Validating
        If tx_cantidad.Text = "" Then
            tx_cantidad.Text = 0
        End If
        If IsNumeric(tx_cantidad.Text) = False Or tx_cantidad.Text = 0 Then
            Exit Sub
        End If
        tx_baches.Text = Math.Round(tx_cantidad.Text / tamano_bache, 4)
    End Sub

    Private Sub bt_grabar_item_dg_Click(sender As Object, e As EventArgs) Handles bt_grabar_item_dg.Click
        verror_requisitos = "N"
        validar_fechas()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        dg_datos.Rows(row_dg_activo).Cells("dgocell_cantidad").Value = CDec(tx_cantidad.Text)
        dg_datos.Rows(row_dg_activo).Cells("dgocell_baches").Value = tx_baches.Text
        dg_datos.Rows(row_dg_activo).Cells("dgocell_fecha_inicio").Value = dtp_fecha_ini.Value.ToString("yyyy/MM/dd HH:mm")
        dg_datos.Rows(row_dg_activo).Cells("dgocell_fecha_fin").Value = dtp_fecha_fin.Value.ToString("yyyy/MM/dd HH:mm")
        bt_grabar_item_dg.Enabled = False
        validar_cant_tot_programada()
    End Sub
    Private Sub validar_fechas()
        If dtp_fecha_fin.Value < dtp_fecha_ini.Value Then
            verror_requisitos = "S"
            vmensaje_requisitos = "La fecha final no puede ser menor que la fecha de inicio."
        End If
    End Sub
    Private Sub validar_cant_tot_programada()
        If dg_datos.Rows.Count = 0 Then
            cantidad_programada = 0
            Exit Sub
        End If
        cantidad_programada = 0
        For Each orow As DataGridViewRow In dg_datos.Rows
            cantidad_programada += orow.Cells("dgocell_cantidad").Value
        Next
        cantidad_programada = Math.Round(cantidad_programada, 4)
        tx_diferencia_cantidades.Text = cantidad_original - cantidad_programada
        If cantidad_programada <> cantidad_original Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Cantidad programada diferente a cantidad base."
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        If dg_datos.Rows.Count = 0 Then
            Exit Sub
        End If
        verror_requisitos = "N"
        validar_cant_tot_programada()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'anular registro antiguo
        Dim path_anular As String = path_registro_original
        otb_edicion = New DataTable
        'Creo la estructura de la datatable
        Dim dccantidad As New DataColumn("cantidad")
        dccantidad.DataType = GetType(Decimal)
        Dim dcfechaini As New DataColumn("fecha_ini")
        dcfechaini.DataType = GetType(Date)
        Dim dcfechafin As New DataColumn("fecha_fin")
        dcfechafin.DataType = GetType(Date)
        otb_edicion.Columns.Add(dccantidad)
        otb_edicion.Columns.Add(dcfechaini)
        otb_edicion.Columns.Add(dcfechafin)
        'Cargo la datatabla con los valores de edicion del ipp

        For Each dg_row As DataGridViewRow In dg_datos.Rows
            If dg_row.Cells("dgocell_cantidad").Value = "0" Then
                MsgBox("No pueden haber registros con cantidades 0", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If
            Dim orow As DataRow = otb_edicion.NewRow()
            orow("cantidad") = dg_row.Cells("dgocell_cantidad").Value
            orow("fecha_ini") = dg_row.Cells("dgocell_fecha_inicio").Value
            orow("fecha_fin") = dg_row.Cells("dgocell_fecha_fin").Value
            otb_edicion.Rows.Add(orow)
        Next
        'MsgBox(otb_edicion.Rows.Count)

        'Defino la accion que se debe realizar en la programacion
        If dg_datos.Rows.Count = 1 Then
            vf_oform_padre.proceder_edicion_ipp = "MOD"
        Else
            vf_oform_padre.proceder_edicion_ipp = "DIV"
        End If
        vf_oform_padre.otb_edicion = otb_edicion
        'cierro el formulario
        Dispose()
    End Sub

End Class
