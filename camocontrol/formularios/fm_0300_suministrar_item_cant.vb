Public Class fm_0300_suministrar_item_cant
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public otipo_nota As String = ""

    Public filtro_items As String = ""
    Public id_item As Integer = 0
    Public cant_item As Decimal = 0

    Public info_gestionada As String = "N"

    Public fecha_cort_inventario As DateTime
    Public id_bodega As Integer
    Public info_item_mov As cl_estructuras_variables.info_item_mov_inventario
    'Public rango_item(10) As Decimal  '1=id_item, 2=cantidad, 3 {1 entrada; 2 salida}
    Public m_clasificador As String = "N"
    Public m_inventario As String = "N"
    Public m_tipo_mov As String = "N"
    Public m_edit_item As String = "N"
    Public m_ent_sal As String = "N" 'Para determinar comportamiento del grupo de RB entrada y salida
    '''''''' E = Activado entrada edicion de grupo RB deshabilitada
    '''''''' S = Activado salida edicion de grupo RB deshabilitada
    '''''''' D = Edicion de grupo RB Habilitada
    '''''''' N = Edicion de grupo RB deshabilitada
    Public m_cantidad As String = "S" 'Para habilitar la capacidad de modificar la cantidad.
    'Private$vf_otabla_permisos$As DataTable
    Public m_info_trazabilidad As String = "N" 'Habilita editar la informacion de trazabilidad del item

    Private odr As NpgsqlDataReader
    Private oconn_form As NpgsqlConnection

    Private ocmd As NpgsqlCommand
    Private csql As String = ""
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private vexiste As String = ""
    Private verror As String = "N"
    Private otb_info_elemento As DataTable
    Private otb_items As DataTable
    Private otb_info_trazabilidad As DataTable

    Private Sub fm_0300_suministrar_item_cant_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        bt_editar.Enabled = False
        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False
        bt_generar_informe.Enabled = False
        bt_nuevo.Enabled = False
        dg_trazabilidad.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        'formateo el datatable que usare para trazabilidad
        otb_info_trazabilidad = New DataTable
        otb_info_trazabilidad.Columns.Add("info_trazable", Type.GetType("System.String"))

        If m_clasificador = "S" Then
            Dim otb_clasificadores As DataTable
            csql = "select * from " & database.obtener_esquema & ".tb0312_clasificadores_movimientos" _
                & " where f0312_anulado = 'N'" _
                & " order by f0312_clasificador ASC"
            otb_clasificadores = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            With cm_clasificador
                'Valor que se muestra al usuario
                .DisplayMember = "f0312_clasificador"
                'Valor interno que almacena el objeto
                .ValueMember = "f0312_id_clasificador"
                'Origen de Datos del ComboBox
                .DataSource = otb_clasificadores
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Else
            cm_clasificador.Enabled = False
        End If

        Select Case m_ent_sal
            Case "E"
                rb_entrada.Checked = True
                gb_tipo_movimiento.Enabled = False
            Case "S"
                rb_salida.Checked = True
                gb_tipo_movimiento.Enabled = False
            Case "D"
                rb_salida.Checked = True
                gb_tipo_movimiento.Enabled = True
            Case "N"
                gb_tipo_movimiento.Enabled = False
        End Select
        tx_cantidad.Text = cant_item
        If m_cantidad = "N" Then
            tx_cantidad.ReadOnly = True
        End If
        If m_info_trazabilidad = "N" Then
            dg_trazabilidad.Enabled = False
        End If
        If m_edit_item = "N" Then
            tx_id_item.ReadOnly = True
            cm_descripcion.Enabled = False
        End If
        cargar_informacion_items()
    End Sub
    Private Sub cargar_informacion_items()
        csql = "SELECT tb0300_items.*," _
            & " f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as descripcion_larga," _
            & " f0002_unidad_medicion" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
              & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                & "  on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
            & " where f0300_id_cia = '" & vg_id_cia & "' and f0300_anulado = 'N'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        Dim dataviewitems As New DataView
        dataviewitems = New DataView(otb_items, filtro_items, "", DataViewRowState.CurrentRows)

        With cm_descripcion
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion_larga"
            'Valor interno que almacena el objeto
            .ValueMember = "f0300_id_item"
            'Origen de Datos del ComboBox
            .DataSource = dataviewitems
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.SelectedIndex = -1
        End With
        If id_item <> 0 Then
            tx_id_item.Text = id_item
            tx_cantidad.Text = cant_item
            cm_descripcion.SelectedValue = id_item
            buscar_info_item(id_item)
        Else
            cm_descripcion.SelectedIndex = -1
        End If

    End Sub
    Private Sub tx_id_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_id_item.Validating
        If (IsNumeric(tx_id_item.Text) = False And tx_id_item.Text <> "") Or tx_id_item.Text = "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        cm_descripcion.Focus()
        cm_descripcion.SelectedValue = CInt(tx_id_item.Text)
        tx_inventario.Text = cl_utilidades_gestion_compras.suministrar_inventario_item_bodega_fecha(id_bodega, tx_id_item.Text, fecha_cort_inventario)
        id_item = CInt(tx_id_item.Text)
    End Sub

    Private Sub cm_descripcion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_descripcion.Validating
        If cm_descripcion.SelectedIndex = -1 Then
            cm_descripcion.Text = ""
            tx_id_item.Text = ""
        Else
            tx_id_item.Text = cm_descripcion.SelectedValue
            buscar_info_item(cm_descripcion.SelectedValue)
            'bt_grabar.Enabled = False
            'bt_editar.Enabled = True
            tx_inventario.Text = cl_utilidades_gestion_compras.suministrar_inventario_item_bodega_fecha(id_bodega, tx_id_item.Text, fecha_cort_inventario)
            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_editar, "")
            id_item = cm_descripcion.SelectedValue
        End If
    End Sub

    Private Sub buscar_info_item(id_oitem As Integer)
        Dim orow_item() As DataRow
        orow_item = otb_items.Select("f0300_id_item = '" & id_oitem & "'")
        For Each orow As DataRow In orow_item
            lb_unidad_medicion.Text = orow("f0002_unidad_medicion")
        Next
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

    Private Sub validar_item()
        If cm_descripcion.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe seleccionar un Item."
        End If
    End Sub

    Private Sub validar_cantidad()
        If tx_cantidad.Text = "" Or tx_cantidad.Text = "0" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina una Cantidad."
        End If
    End Sub

    Private Sub validar_clasificador()
        If m_clasificador = "S" Then
            If cm_clasificador.SelectedIndex = -1 Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Debe seleccionar un clasificador del registro."
            End If
        End If
    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        If tx_id_item.Text = "0" Then
            Exit Sub
        End If

        verror_requisitos = "N"
        validar_y_llenar_info_trazabilidad()
        validar_item()
        validar_cantidad()
        validar_clasificador()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        info_gestionada = "S"
        info_item_mov.id_item = tx_id_item.Text
        info_item_mov.cantidad = tx_cantidad.Text
        info_item_mov.info_trazabilidad = otb_info_trazabilidad
        'rango_item(1) = tx_id_item.Text
        'rango_item(2) = tx_cantidad.Text
        If rb_entrada.Checked = True Then
            info_item_mov.tipo_movimiento = 1
            'rango_item(3) = 1
        Else
            info_item_mov.tipo_movimiento = 2
            'rango_item(3) = 2
        End If

        If m_clasificador = "S" Then
            info_item_mov.clasificador = cm_clasificador.SelectedValue
            'rango_item(4) = cm_clasificador.SelectedValue
        Else
            info_item_mov.clasificador = 0
            'rango_item(4) = 0
        End If

        Me.Hide()

    End Sub

    Private Sub validar_y_llenar_info_trazabilidad()
        If dg_trazabilidad.Enabled = False Then
            Exit Sub
        End If
        dg_trazabilidad.AllowUserToAddRows = False
        If dg_trazabilidad.Rows.Count = 0 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe digitar informacion de trazabilidad del item"
            dg_trazabilidad.AllowUserToAddRows = True
            Exit Sub
        End If
        Dim row_vacio As String = "N"
        For Each orow As DataGridViewRow In dg_trazabilidad.Rows
            If orow.Cells("dgocell_info_trazabilidad").Value.ToString.Trim = "" Then
                row_vacio = "S"
            End If
        Next
        If row_vacio = "S" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe digitar informacion de trazabilidad del item, no puede haber renglones en blanco"
            dg_trazabilidad.AllowUserToAddRows = True
            Exit Sub
        End If
        For Each orow As DataGridViewRow In dg_trazabilidad.Rows
            otb_info_trazabilidad.Rows.Add(orow.Cells("dgocell_info_trazabilidad").Value.ToString.Trim)
        Next
    End Sub

    Private Sub bt_buscar_trazabilidad_Click(sender As Object, e As EventArgs) Handles bt_buscar_trazabilidad.Click
        'MsgBox("id_bodega: " & id_bodega & "  id_item: " & id_item)
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-30", vg_id_cia, vg_usuario_autoriza, "Trazabilidad de Lotes", {vg_id_cia, id_bodega, id_item},,,, Me)
        'vf_t_string variable que contiene el lote seleccionado en el visor de datos
        'MsgBox(vf_t_string)
        If vf_t_string <> "" Then
            dg_trazabilidad.Rows.Add({vf_t_string})
        End If
    End Sub

    Private Sub bt_listado_general_items_Click(sender As Object, e As EventArgs) Handles bt_listado_general_items.Click
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-34", vg_id_cia, vg_usuario_autoriza,
                                                    "Listado General de Items", {vg_id_cia})
    End Sub
End Class
