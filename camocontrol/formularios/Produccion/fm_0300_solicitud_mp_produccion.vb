Imports System.ComponentModel

Public Class fm_0300_solicitud_mp_produccion
    'Objetos publicos que reciben valores desde el Formulario padre
    Public ocontexto_form As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    Public id_estructura As Integer
    Public id_accion As Integer

    Public id_item As Integer = 0
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell

    Private otb_items As DataTable
    Private otb_plantillas As DataTable
    Private otb_items_plantillas As DataTable
    Private otb_bodegas As DataTable
    Private otb_puntos_control_inventario As DataTable

    Private id_sol_almacen As Integer = 0
    Private item_restringido As String = "S"
    Private sin_plantilla As String = "N"
    Private usuario_con_acceso_total As String = "N"
    Private id_bodega As Integer
    Private criterio_minimo As Decimal
    Private criterio_maximo As Decimal
    Private criterio_consumo_dia As Decimal

    Private Sub fm_0300_solicitud_almacen_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-ITMvvvvvvv"
        vf_var_config_notas = "TN-ITM-001vvvvvvvv"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        vf_elemento_nuevo = "S"
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
        'Si entro en este formulario es porque puede crear nueva solicitud
        bt_grabar.Enabled = True
        bt_editar.Enabled = False
        'Identificamos si ul usuario tiene acceso total a las formulaciones
        Dim temp_otabla_permiso As DataTable
        temp_otabla_permiso = cl_gestion_permisos.identificar_permisos_usuario(vg_usuario_autoriza, "fm_0300_gestion_items", "")
        usuario_con_acceso_total = cl_gestion_permisos.identificar_permisos_especiales_formularios("ACCESO_RESTRINGIDO",
                                                                                            temp_otabla_permiso,
                                                                                            vg_usuario_autoriza)

        tx_cantidad.Text = 0
        tx_produccion_x_bache.Text = 0
        tx_numero_baches.Text = 0
        bt_solicitar.Enabled = False
        dg_items_solicitud.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_items_solicitud.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_items_solicitud.AllowUserToAddRows = False
        dg_items_solicitud.AllowUserToDeleteRows = True
        'dg_items_solicitud.ReadOnly = True
        'dg_items_solicitud.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader

        dg_prog_produccion.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_prog_produccion.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_prog_produccion.AllowUserToAddRows = False
        dg_prog_produccion.AllowUserToDeleteRows = True

        csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
            & " from " & database.obtener_esquema & ".tb0005_bodegas" _
            & " where f0005_anulado = 'N'"
        otb_bodegas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = "SELECT *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
            & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
            & " on f0002_id_unidad_medicion = f0300_id_unidad_medicion" _
            & " where f0300_id_cia = '" & vg_id_cia & "' and f0300_anulado = 'N'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_descripcion
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

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0005_bodegas"
        Dim otb_bodega_destino As DataTable
        otb_bodega_destino = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_bodega_solicitante
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

        'Cargo informacion de las plantillas y sus items
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-06", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        otb_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        otb_items_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        proteger_columnas()
    End Sub
    Private Sub proteger_columnas()
        For Each ocolum As DataGridViewColumn In dg_items_solicitud.Columns
            If ocolum.Name <> "dgocell_ppal_chk_aprobado" _
                And ocolum.Name <> "dgocell_ppal_cant_solicitada" _
                And ocolum.Name <> "dgocell_ppal_id_bodega" Then
                ocolum.ReadOnly = True
            Else
                ocolum.ReadOnly = False
            End If
        Next
    End Sub
    Private Sub tx_id_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_id_item.Validating
        If IsNumeric(tx_id_item.Text) = False And tx_id_item.Text.Trim <> "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If
        cm_descripcion.Focus()
        cm_descripcion.SelectedValue = CInt(tx_id_item.Text)
        buscar_info_item()
    End Sub
    Private Sub cm_descripcion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_descripcion.Validating
        If cm_descripcion.SelectedIndex = -1 Then
            MsgBox("Item no existente", MsgBoxStyle.Information, "Alerta")
        Else
            id_item = CInt(cm_descripcion.SelectedValue)
            tx_id_item.Text = id_item
            buscar_info_bache()
            buscar_info_item()
        End If
    End Sub
    Private Sub buscar_info_bache()
        Dim orow As DataRow()
        orow = otb_plantillas.Select("f0350_id_item = '" & id_item & "'")
        For Each orowp As DataRow In orow
            tx_produccion_x_bache.Text = Math.Round(orowp("f0350_produccion_x_bache"), 2)
            lb_unidad_medicion.Text = orowp("f0002_unidad_medicion")
        Next
        If orow.Length = 0 Then
            sin_plantilla = "S"
        Else
            sin_plantilla = "N"
        End If
    End Sub
    Private Sub buscar_info_item()
        Dim orow As DataRow()
        orow = otb_items.Select("f0300_id_item = '" & id_item & "'")
        'MsgBox("hola")
        For Each orowp As DataRow In orow
            item_restringido = orowp("f0300_ar")
            lb_unidad_medicion.Text = orowp("f0002_unidad_medicion")
            'MsgBox(item_restringido)
        Next
    End Sub
    Private Function buscar_info_bodega(ByVal id_obodegab As Integer)
        Dim orow As DataRow()
        Dim nombre_bodega As String = ""
        orow = otb_bodegas.Select("f0005_id_bodega = '" & id_obodegab & "'")
        For Each orowp As DataRow In orow
            nombre_bodega = orowp("f0005_descripcion_bodega")
        Next
        Return nombre_bodega
    End Function
    Private Sub bt_solicitar_Click(sender As Object, e As EventArgs) Handles bt_solicitar.Click
        If tx_cantidad.Text = "0" Then
            Exit Sub
        End If
        id_item = tx_id_item.Text

        'Identifico si es un item con informacion restringida
        buscar_info_item()
        If item_restringido = "S" Then
            If usuario_con_acceso_total = "N" Then
                MsgBox("No Disponible", MsgBoxStyle.Exclamation, "Acceso Restringido")
                Exit Sub
            End If
        End If
        Dim otb_formula As DataTable
        otb_formula = cl_utilidades_gestion_compras.formulacion_entregar_formula_item_directa(id_item, tx_cantidad.Text, "1", otb_plantillas, otb_items_plantillas)
        'MsgBox(otb_formula.Rows.Count)
        'Clipboard.SetDataObject(csql) 
        'MsgBox(csql)
        Dim list_eliminar As New List(Of DataRow) 'Listado auxiliar para luego elimar los  rows que no son consumibles.

        'Cuando el item no tiene explosion entonces lo registro directamente a la solicitud.
        If otb_formula.Rows.Count = 0 Then
            'tx_produccion_x_bache.Text = 1
            'Creo un datarow para poder llenar el datagrid con la informacion del item
            Dim orow As DataRow
            orow = otb_formula.NewRow

            orow.Item("id_item") = tx_id_item.Text
            orow.Item("nombre") = cm_descripcion.Text
            orow.Item("cantidad") = tx_cantidad.Text
            orow.Item("unidad") = lb_unidad_medicion.Text
            orow.Item("tamaño_bache_produccion") = tx_cantidad.Text
            orow.Item("baches_requeridos") = 1
            orow.Item("consumible") = "S"
            'agrego el datorow al datetable
            otb_formula.Rows.Add(orow)
        End If
        'si el item tiene formulacion
        For Each orow As DataRow In otb_formula.Rows
            'Si es un item no consumible no lo tengo en cuenta.
            If orow("consumible") = "N" Then
                'identifico el orow para su eliminacion de la tabla
                'Como no puedo eliminar en bucle for each, entocen agrego el row al listado auxiliar para luego eliminarlos
                list_eliminar.Add(orow)
            End If
        Next
        'en este bucle elimino los datarows identificados como no consumubles
        For Each dr As DataRow In list_eliminar
            otb_formula.Rows.Remove(dr)
        Next
        'Agrego los items a la datagridview
        For Each orow As DataRow In otb_formula.Rows
            agregar_fila_items(orow)
        Next
        cm_bodega_solicitante.Enabled = False
        agregar_fila_programa_produccion()
        'tx_id_item.Text = ""
        'tx_cantidad.Text = "0"
        'tx_produccion_x_bache.Text = "0"
        'tx_numero_baches.Text = "0"
        dtp_f_requerida_entrega.Focus()
    End Sub

    Private Sub tx_cantidad_Validating(sender As Object, e As CancelEventArgs) Handles tx_cantidad.Validating
        If tx_cantidad.Text.Trim = "" Then
            tx_cantidad.Text = "0"
            tx_numero_baches.Text = "0"
            Exit Sub
        End If
        If sin_plantilla = "N" Then
            tx_numero_baches.Text = Math.Round(tx_cantidad.Text / tx_produccion_x_bache.Text, 4)
        Else
            tx_numero_baches.Text = "1"
            tx_produccion_x_bache.Text = tx_cantidad.Text
        End If
    End Sub

    Private Sub tx_numero_baches_Validating(sender As Object, e As CancelEventArgs) Handles tx_numero_baches.Validating
        If sin_plantilla = "N" Then
            tx_cantidad.Text = Math.Round(tx_numero_baches.Text * tx_produccion_x_bache.Text, 2)
        Else
            tx_cantidad.Text = "1"
        End If
    End Sub

    Private Sub agregar_fila_items(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("id_item"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("nombre").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = Math.Round(orow.Item("cantidad"), 2)
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("unidad").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        If IsDBNull(orow.Item("tamaño_bache_produccion")) = False Then
            otextgrid.Value = Math.Round(orow.Item("tamaño_bache_produccion"), 2)
        Else
            otextgrid.Value = ""
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        If IsDBNull(orow.Item("baches_requeridos")) = False Then
            otextgrid.Value = Math.Round(orow.Item("baches_requeridos"), 2)
        Else
            otextgrid.Value = ""
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = ""
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 8
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = ""
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 9
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = Math.Round(cl_utilidades_gestion_compras.suministrar_inventario_item_bodega(cm_bodega_solicitante.SelectedValue,
                                                                                           orow.Item("id_item")), 2)
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 10
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = ""
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 11 CANTIDAD A SOLICITAR
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = Math.Round(orow.Item("cantidad"), 2)
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 12 fecha requerida de entrega
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = dtp_f_requerida_entrega.Value.ToString("yyyy/MM/dd")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_items_solicitud.Rows.Add(orowgrid)
    End Sub
    Private Sub agregar_fila_programa_produccion()

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = tx_id_item.Text
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = cm_descripcion.Text
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = tx_cantidad.Text
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = lb_unidad_medicion.Text
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = tx_produccion_x_bache.Text
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = tx_numero_baches.Text
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7 fecha programada de produccion
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = dtp_f_requerida_entrega.Value.ToString("yyyy/MM/dd")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_prog_produccion.Rows.Add(orowgrid)
    End Sub
    Private Sub dg_items_solicitud_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_items_solicitud.CellDoubleClick
        If dg_items_solicitud.Rows.Count = 0 Then
            Exit Sub
        End If
        id_item = dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_item").Value
        'Identifico si es un item con informacion restringida
        buscar_info_item()
        If item_restringido = "S" Then
            If usuario_con_acceso_total = "N" Then
                MsgBox("No Disponible", MsgBoxStyle.Exclamation, "Acceso Restringido")
                Exit Sub
            End If
        End If
        If dg_items_solicitud.Columns(dg_items_solicitud.CurrentCell.ColumnIndex).Name = "dgocell_ppal_bodega" Then
            Dim id_bodega As String = ""
            Dim csql As String
            csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
                & " from " & database.obtener_esquema & ".tb0005_bodegas" _
                & " where f0005_anulado = 'N'"
            Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            Dim ODisplayMember As String = "f0005_descripcion_bodega"
            Dim OValueMember As String = "f0005_id_bodega"
            id_bodega = comunes.formulario_parametro_texto("", "Bodega", False, otb_bodegas, ODisplayMember, OValueMember)
            If id_bodega.Trim = "" Then
                Exit Sub
            End If
            Dim orow_inf_bodega As DataRow()
            orow_inf_bodega = otb_bodegas.Select("f0005_id_bodega = '" & id_bodega & "'")
            Dim nombre_bodega As String = orow_inf_bodega(0)("f0005_descripcion_bodega")

            dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_bodega").Value = id_bodega
            dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_bodega").Value = nombre_bodega
            dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_inv_disponible").Value = Math.Round(cl_utilidades_gestion_compras.suministrar_inventario_item_bodega(id_bodega,
                                                                                                                                               dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_item").Value), 2)
        End If
        If dg_items_solicitud.Columns(dg_items_solicitud.CurrentCell.ColumnIndex).Name = "dgocell_ppal_id_item" Then
            tx_id_item.Text = dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_item").Value
            tx_cantidad.Text = dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_cantidad").Value
            tx_produccion_x_bache.Text = dg_items_solicitud.CurrentRow.Cells("dgocell_tamano_bache").Value
            tx_numero_baches.Text = dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_baches_requeridos").Value
            dg_items_solicitud.Rows.Remove(dg_items_solicitud.CurrentRow)
            tx_id_item.Focus()
            tx_cantidad.Focus()

        End If
    End Sub

    Private Sub cm_bodega_solicitante_Validating(sender As Object, e As CancelEventArgs) Handles cm_bodega_solicitante.Validating
        If cm_bodega_solicitante.SelectedIndex = -1 Then
            MsgBox("Seleccione una bodega", MsgBoxStyle.Information, "Info")
            bt_solicitar.Enabled = False
        Else
            bt_solicitar.Enabled = True
            tx_inventario.Text = Math.Round(cl_utilidades_gestion_compras.suministrar_inventario_item_bodega(cm_bodega_solicitante.SelectedValue, id_item), 2)
        End If
    End Sub

    Private Sub dg_items_solicitud_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_items_solicitud.CellContentClick
        If dg_items_solicitud.Rows.Count = 0 Then
            Exit Sub
        End If

        If dg_items_solicitud.Columns(dg_items_solicitud.CurrentCell.ColumnIndex).Name = "dgocell_ppal_chk_aprobado" Then
            If dg_items_solicitud.CurrentCell.Value = -1 Then
                dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_cant_solicitada").ReadOnly = False
                'MsgBox(dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_item").Value & " A")
            Else
                dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_cant_solicitada").ReadOnly = True
                'MsgBox(dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_item").Value & " B")
            End If
            dg_items_solicitud.CurrentCell = dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_cant_solicitada")
        End If
    End Sub

    Private Sub dg_items_solicitud_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_items_solicitud.CellFormatting
        If dg_items_solicitud.Columns(e.ColumnIndex).Name = "dgocell_ppal_chk_aprobado" Then
            If e.Value = -1 Then
                e.CellStyle.BackColor = System.Drawing.Color.Green
            End If
        End If
        If dg_items_solicitud.Columns(e.ColumnIndex).Name = "dgocell_ppal_cant_solicitada" Then
            If IsNumeric(e.Value) = False Or e.Value = 0 Then
                e.Value = 0
                e.CellStyle.BackColor = System.Drawing.Color.Violet
            End If
        End If
    End Sub

    'El siguiente codigo es para que la celda de cantidad de la dg solo registre numeros
    Private Sub evento_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
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

    Private Sub dg_items_solicitud_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dg_items_solicitud.EditingControlShowing
        If dg_items_solicitud.Columns(dg_items_solicitud.CurrentCell.ColumnIndex).Name = "dgocell_ppal_cant_solicitada" Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf evento_keyPress
        End If
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

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        If dg_items_solicitud.Rows.Count = 0 Then
            Exit Sub
        End If
        'Identifico si todos los items estan con bodega origen y cantidad definida.
        Dim dg_diligenciada As String = "S"
        For Each orow As DataGridViewRow In dg_items_solicitud.Rows
            If orow.Cells("dgocell_ppal_id_bodega").Value = "" Then
                MsgBox("Defina todas las bodegas a las que solicita insumos", MsgBoxStyle.Critical, "Info")
                Exit Sub
            End If
            If orow.Cells("dgocell_ppal_cant_solicitada").Value = "0" Then
                MsgBox("Las cantidades solicitadas deben ser mayores a 0", MsgBoxStyle.Critical, "Info")
                Exit Sub
            End If
        Next
        'creo el nuevo encabezado
        grabar_nuevo_encabezado_solicitud()
        If verror = "N" Then

            id_sol_almacen = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0316_id_sol_alm",
                                                                                          "f0316_usuario_crear",
                                                                                          vg_usuario_autoriza,
                                                                                          "tb0316_solicitudes_almacen_encabezado")
            'creo los items de la solicitud
            For Each orow As DataGridViewRow In dg_items_solicitud.Rows
                grabar_nuevo_item_solicitud(orow)
            Next
            If IsDBNull(id_accion) = False Then
                cl_informes_comunes.reporte_solicitud_almacen(vg_id_cia, id_sol_almacen, 2)
            Else
                cl_informes_comunes.reporte_solicitud_almacen(vg_id_cia, id_sol_almacen, 1)
            End If

            dg_prog_produccion.Rows.Clear()
            dg_items_solicitud.Rows.Clear()
            cm_descripcion.Text = ""
            cm_bodega_solicitante.Text = ""
            tx_id_item.Text = ""
            cm_bodega_solicitante.Enabled = True
        End If
    End Sub
    Private Sub grabar_nuevo_encabezado_solicitud()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0316_solicitudes_almacen_encabezado" _
                & " (f0316_id_cia, f0316_bodega_solicita, f0316_id_accion," _
                & " f0316_usuario_modificar, f0316_usuario_crear, f0316_fm)" _
                & " VALUES" _
                & " (@f0316_id_cia, @f0316_bodega_solicita, @f0316_id_accion," _
                & " @f0316_usuario_modificar, @f0316_usuario_crear, @f0316_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_encabezado(ocmd)

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
    End Sub
    Private Sub crear_parametros_encabezado(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0316_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0316_bodega_solicita", NpgsqlDbType.Integer).Value = CInt(cm_bodega_solicitante.SelectedValue)
        If IsDBNull(id_accion) = False Then
            ocmd.Parameters.Add("@f0316_id_accion", NpgsqlDbType.Integer).Value = id_accion
        Else
            ocmd.Parameters.Add("@f0316_id_accion", NpgsqlDbType.Integer).Value = DBNull.Value
        End If
        ocmd.Parameters.Add("@f0316_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0316_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0316_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub grabar_nuevo_item_solicitud(orow As DataGridViewRow)

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0317_solicitudes_almacen_detalle" _
                & " (f0317_id_sol_alm, f0317_id_cia, f0317_bodega_solicita, f0317_bodega_entrega," _
                & " f0317_id_item, f0317_cantidad_solicitada, f0317_fecha_req_entrega," _
                & " f0317_usuario_modificar, f0317_usuario_crear, f0317_fm)" _
                & " VALUES" _
                & " (@f0317_id_sol_alm, @f0317_id_cia, @f0317_bodega_solicita, @f0317_bodega_entrega," _
                & " @f0317_id_item, @f0317_cantidad_solicitada, @f0317_fecha_req_entrega," _
                & " @f0317_usuario_modificar, @f0317_usuario_crear, @f0317_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_encabezado(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0317_id_sol_alm", NpgsqlDbType.Integer).Value = id_sol_almacen
        ocmd.Parameters.Add("@f0317_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0317_bodega_solicita", NpgsqlDbType.Integer).Value = CInt(cm_bodega_solicitante.SelectedValue)
        ocmd.Parameters.Add("@f0317_bodega_entrega", NpgsqlDbType.Integer).Value = CInt(orow.Cells("dgocell_ppal_id_bodega").Value)
        ocmd.Parameters.Add("@f0317_id_item", NpgsqlDbType.Integer).Value = CInt(orow.Cells("dgocell_ppal_id_item").Value)
        ocmd.Parameters.Add("@f0317_cantidad_solicitada", NpgsqlDbType.Numeric).Value = orow.Cells("dgocell_ppal_cant_solicitada").Value
        ocmd.Parameters.Add("@f0317_fecha_req_entrega", NpgsqlDbType.Timestamp).Value = CDate(orow.Cells("dgocell_ppal_fecha_entrega_requerida").Value)
        ocmd.Parameters.Add("@f0317_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0317_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0317_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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
    End Sub

    Private Sub dg_items_solicitud_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dg_items_solicitud.CellValidated
        If dg_items_solicitud.Columns(dg_items_solicitud.CurrentCell.ColumnIndex).Name = "dgocell_ppal_id_bodega" Then
            'MsgBox(dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_bodega").Value)
            Dim oidbod As String = ""
            oidbod = dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_bodega").Value
            If IsNumeric(oidbod) = False Then
                dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_bodega").Value = ""
                dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_bodega").Value = ""
                MsgBox("Bodega no existe", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim nom_bod As String = ""
            nom_bod = buscar_info_bodega(oidbod)
            If nom_bod = "" Then
                dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_id_bodega").Value = ""
                dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_bodega").Value = ""
                MsgBox("Bodega no existe", MsgBoxStyle.Information, "Info")
                Exit Sub
            Else
                dg_items_solicitud.CurrentRow.Cells("dgocell_ppal_bodega").Value = nom_bod
            End If
        End If
    End Sub
End Class
