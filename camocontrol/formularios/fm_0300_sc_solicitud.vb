Public Class fm_0300_sc_solicitud
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_estructura As Integer
    Public id_accion As Integer = 0
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_solicitud_compra As Integer 'se asigna cuando se llama al formulario desde el fm_padre
    Public cambiar_estructura As String = "N"

    'Private$vf_otabla_permisos$As DataTable

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell

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

    Private id_tipo_item As Integer
    Private permitir_var_costo As String = "N"
    Private var_costo_promedio_actual As Decimal = 0 'variacion del valor actual con respecto al costo promedio actual
    Private costo_promedio_actual As Decimal = 0
    Private valores() As Decimal = Nothing
    Private actualizar_grilla As String = "N"

    Private otb_info_item_sc As DataTable 'para buscar la informacion actualizada del item que se esta editando
    Private otb_doc_mov_invent_relacionados As DataTable 'documentos de movimientos de inventario relacionados

    Private otb_solicitudes As DataTable
    Private otb_recursos As DataTable
    Private otb_info_personal As DataTable
    Private id_item_accion As Integer 'registro del item solicitado en la tabla tb0305_items_solicitudes


    Private Sub Fm_0300_sc_solicitud_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        'Recordar definir la variable vf_id_notas_archivos
        vf_var_config_archivos = "CD-SCM"
        vf_var_config_notas = "TN-SCM-001"
        vf_id_notas_archivos = id_solicitud_compra
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)

        tx_solicitud.Enabled = False
        tx_estructura.ReadOnly = True
        cm_usuario.Enabled = False
        'bt_anular.Enabled = False
        bt_editar.Enabled = False
        Formatear_grilla()

        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" _
            & " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        With cm_usuario
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_personal
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = vg_usuario_autoriza
        End With

        csql = "select * from " & database.obtener_esquema & ".tb0306_estados_compras"
        csql += " where f0306_anulado = 'N'"
        Dim otb_estado As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_estado
            'Valor que se muestra al usuario
            .DisplayMember = "f0306_estado_compras"
            'Valor interno que almacena el objeto
            .ValueMember = "f0306_id_estado_compras"
            'Origen de Datos del ComboBox
            .DataSource = otb_estado
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        'cm_estado.Enabled = False
        cm_estado.SelectedValue = 1

        csql = "select * from " & database.obtener_esquema & ".tb0006_centro_costo"
        Dim otb_centro_costo As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_centro_costo
            'Valor que se muestra al usuario
            .DisplayMember = "f0006_descripcion_c_costo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0006_id_c_costo"
            'Origen de Datos del ComboBox
            .DataSource = otb_centro_costo
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        dg_listado.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_listado.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_listado.AllowUserToAddRows = False
        dg_listado.AllowUserToDeleteRows = False
        dg_listado.ReadOnly = False

        dg_listado.Columns("dgocell_id_sc_item").ReadOnly = True
        'dg_listado.Columns("dgocell_cantidad_solicitada").ReadOnly = 

        If id_accion <> 0 Then
            tx_id_accion.Text = id_accion
        End If

        If vf_elemento_nuevo = "N" Then
            Cargar_datatables()

            For Each orow As DataRow In otb_solicitudes.Rows
                tx_id_accion.Text = orow("f0304_id_accion")
                tx_solicitud.Text = orow("f0304_id_solicitud")
                cm_estado.SelectedValue = orow("f0304_id_estado")
                cm_centro_costo.SelectedValue = orow("f0304_id_centro_costo")
                tx_anotacion.Text = orow("f0304_anotacion")
                cm_usuario.SelectedValue = orow("f0304_usuario_crear")
                dtp_fecha_solicitud.Value = orow("f0304_fr")
                id_estructura = orow("f0304_id_estructura")
                id_accion = orow("f0304_id_accion")
                tx_estructura.Text = comunes.traer_nombre_estructura(orow("f0304_id_estructura").ToString)
            Next
            'dg_listado.DataSource = otb_recursos
            'crear_columnas_dg()
            Llenar_items_solicitados()
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
        End If
    End Sub
    Private Sub Formatear_grilla()
        dg_listado.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        'dg_listado.ReadOnly = False
        ' Este for es para que solo sea editable el checkbox de la grilla es decir poder hacerle click
        For ocol As Integer = 0 To dg_listado.Columns.Count - 1
            Select Case dg_listado.Columns(ocol).Name
                Case "dgocell_costo_unitario", "dgocell_cantidad_solicitada", "dgocell_costo_total",
                     "dgocell_costo_total_iva", "dgocell_iva", "dgocell_descuento", "dgocell_costo_unit_iva"
                    dg_listado.Columns(ocol).ReadOnly = False
                    dg_listado.Columns(ocol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    dg_listado.Columns(ocol).ReadOnly = True
            End Select
            dg_listado.Columns(ocol).DefaultCellStyle.Format = "N2"
        Next
    End Sub

    Private Sub Dg_listado_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_listado.CellClick
        If dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        tx_id_item_cons_mov.Text = dg_listado.CurrentRow.Cells("dgocell_item").Value
        Dim nombre_columna As String = dg_listado.Columns(dg_listado.CurrentCell.ColumnIndex).Name
        Select Case nombre_columna
            Case "dgocell_id_sc"

            Case "dgocell_id_sc_item"

        End Select
    End Sub

    Private Sub Dg_listado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_listado.CellDoubleClick
        If dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim nombre_columna As String = dg_listado.Columns(dg_listado.CurrentCell.ColumnIndex).Name
        Select Case nombre_columna
            Case "dgocell_item"
                Dim oform_item As New fm_0300_gestion_items With {
                    .vf_oform_padre = Me,
                    .vg_id_cia = vg_id_cia,
                    .cerrar_al_actualizar = "S",
                    .id_item = dg_listado.CurrentCell.Value,
                    .vg_usuario_autoriza = vg_usuario_autoriza,
                    .vf_elemento_nuevo = "N"
                }
                oform_item.ShowDialog()

            Case "dgocell_id_sc_item"
                id_item_accion = dg_listado.CurrentCell.Value
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_agregar_recurso As New camocontrol.fm_0300_sc_items With {
                    .vf_oform_padre = Me,
                    .id_solicitud_compra = id_solicitud_compra,
                    .vg_usuario_autoriza = vg_usuario_autoriza,
                    .vg_id_cia = vg_id_cia,
                    .id_estructura = id_estructura,
                    .id_accion = id_accion,
                    .id_item_solicitud = id_item_accion,
                    .vf_elemento_nuevo = "N"
                }
                oform_agregar_recurso.ShowDialog()
                Cargar_datatables()
                'dg_listado.DataSource = otb_recursos
                Llenar_items_solicitados()
            Case "dgocell_id_accion"
                If dg_listado.CurrentCell.Value.ToString <> "0" And dg_listado.CurrentCell.Value.ToString.Trim <> "" Then
                    Dim id_accion As Integer
                    id_accion = dg_listado.CurrentCell.Value
                    'ajecutamos clase que abre el formulario adecuado segun el tipo de actividad
                    cl_utilidades_gestion_acciones.abrir_actividad(id_accion, vg_usuario_autoriza, vg_id_cia)
                End If
            Case "dgocell_id_fcc"
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                'oform_factura_compra.vf_var_config_notas = "TN-FCP-001"
                'oform_factura_compra.vf_var_config_archivos = "CD-FCC"
                Dim oform_factura_compra As New camocontrol.fm_0300_facturas_compras With {
                    .vf_oform_padre = Me,
                    .vg_id_cia = vg_id_cia,
                    .vf_id_notas_archivos = dg_listado.CurrentCell.Value,
                    .id_factura_compras = dg_listado.CurrentCell.Value,
                    .vg_usuario_autoriza = vg_usuario_autoriza,
                    .vf_elemento_nuevo = "N"
                }
                oform_factura_compra.Show() 'Para que no sea un formulario modal
        End Select

        If dg_listado.Columns(dg_listado.CurrentCell.ColumnIndex).Name = "dgocell_id_sc_item" Then

        End If
    End Sub

    Private Sub Dg_listado_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_listado.CellContentDoubleClick
        If dg_listado.CurrentRow.Cells("dgocell_doc_inv").Value.ToString <> "" Then
            MsgBox("Un item con recepcion de inventario no puede modificarse", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Dg_listado_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_listado.CellFormatting
        If dg_listado.Columns(e.ColumnIndex).Name = "dgocell_var_costo" Then
            If e.Value IsNot Nothing Then
                If IsDBNull(e.Value) = True Then
                    Exit Sub
                End If
                Dim BuscValue As Decimal = e.Value
                Select Case BuscValue
                    Case 1 To 3
                        e.CellStyle.BackColor = System.Drawing.Color.Yellow
                    Case >= 3
                        e.CellStyle.BackColor = System.Drawing.Color.Red
                End Select
            End If
        End If
    End Sub
    Private Sub Dg_listado_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dg_listado.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)

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
    Private Sub Dg_listado_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dg_listado.CellEndEdit
        Dim tipo_calculo As Integer = 1
        Dim ocol As String = ""
        'MsgBox(dg_listado.Columns(e.ColumnIndex).Name)
        ocol = dg_listado.Columns(e.ColumnIndex).Name
        'si no hay valor coloco 0 o 1 si es la cantidad
        If IsDBNull(dg_listado.CurrentRow.Cells(ocol).Value) = True Then
            dg_listado.CurrentRow.Cells(ocol).Value = 0
        End If
        If IsNumeric(dg_listado.CurrentRow.Cells(ocol).Value) = False Then
            dg_listado.CurrentRow.Cells(ocol).Value = 0
        End If
        If dg_listado.CurrentRow.Cells(ocol).Value.ToString.Trim = "" Then
            If ocol = "dgocell_cantidad_solicitada" Then
                dg_listado.CurrentRow.Cells(ocol).Value = 1
            Else
                dg_listado.CurrentRow.Cells(ocol).Value = 0
                'MsgBox("hola")
            End If
            'si la cantidad es 0 no es un valor valido y coloca 1
        Else
            If ocol = "dgocell_cantidad_solicitada" Then
                If CDec(dg_listado.CurrentRow.Cells(ocol).Value) = 0 Then
                    dg_listado.CurrentRow.Cells(ocol).Value = 1
                End If
            End If
        End If

        Dim ocantidad As Decimal = dg_listado.CurrentRow.Cells("dgocell_cantidad_solicitada").Value
        Dim ocosto_unit As Decimal = dg_listado.CurrentRow.Cells("dgocell_costo_unitario").Value
        Dim oimpuesto As Decimal = dg_listado.CurrentRow.Cells("dgocell_iva").Value
        Dim descuento As Decimal = dg_listado.CurrentRow.Cells("dgocell_descuento").Value
        Dim ocosto_total As Decimal = dg_listado.CurrentRow.Cells("dgocell_costo_total").Value
        Dim ocosto_unit_iva As Decimal = dg_listado.CurrentRow.Cells("dgocell_costo_unit_iva").Value
        Dim ocosto_total_iva As Decimal = dg_listado.CurrentRow.Cells("dgocell_costo_total_iva").Value

        Select Case ocol
            Case "dgocell_cantidad_solicitada", "dgocell_costo_unitario", "dgocell_iva", "dgocell_descuento"
                valores = cl_utilidades_gestion_compras.calcular_costos_compra(1, ocantidad, ocosto_unit,
                                                                               oimpuesto,
                                                                               descuento, ocosto_total,
                                                                               ocosto_unit_iva,
                                                                               ocosto_total_iva)
            Case "dgocell_costo_unit_iva"
                valores = cl_utilidades_gestion_compras.calcular_costos_compra(2, ocantidad, ocosto_unit,
                                                                               oimpuesto,
                                                                               descuento, ocosto_total,
                                                                               ocosto_unit_iva,
                                                                               ocosto_total_iva)
            Case "dgocell_costo_total_iva"
                valores = cl_utilidades_gestion_compras.calcular_costos_compra(3, ocantidad, ocosto_unit,
                                                                               oimpuesto,
                                                                               descuento, ocosto_total,
                                                                               ocosto_unit_iva,
                                                                               ocosto_total_iva)
            Case "dgocell_costo_total"
                valores = cl_utilidades_gestion_compras.calcular_costos_compra(4, ocantidad, ocosto_unit,
                                                                               oimpuesto,
                                                                               descuento, ocosto_total,
                                                                               ocosto_unit_iva,
                                                                               ocosto_total_iva)
        End Select
        dg_listado.CurrentRow.Cells("dgocell_costo_unitario").Value = valores(1) / (1 - dg_listado.CurrentRow.Cells("dgocell_descuento").Value / 100)
        dg_listado.CurrentRow.Cells("dgocell_costo_total").Value = valores(2)
        dg_listado.CurrentRow.Cells("dgocell_costo_unit_iva").Value = valores(3)
        dg_listado.CurrentRow.Cells("dgocell_costo_total_iva").Value = valores(4)
        'busco y valido el cambio solicitado
        Buscar_info_item_solicitado(dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value)
        'lb_valor_factura.Text = "Actualizar"
        'lb_valor_subtotal.Text = "Actualizar"
        If verror_requisitos = "N" Then
            Actualizar_item()
            Cargar_datatables()
            'MsgBox("Ahora puedo grabar")
        Else
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Information, "Info")
            'vuelvo a cargar la informacion anterior
            Dim orow As DataRow() = otb_recursos.Select("f0305_id_item_solicitud = '" &
                                                                 dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value & "'")
            dg_listado.CurrentRow.Cells("dgocell_cantidad_solicitada").Value = orow(0)("f0305_cantidad")
            dg_listado.CurrentRow.Cells("dgocell_var_costo").Value = Math.Round(orow(0)("f0305_var_cost_prom") * 100, 1)
            dg_listado.CurrentRow.Cells("dgocell_costo_unitario").Value = orow(0)("costo_unitario") / (1 - orow(0)("f0305_descuento"))
            dg_listado.CurrentRow.Cells("dgocell_costo_total").Value = orow(0)("costo_subtotal")
            dg_listado.CurrentRow.Cells("dgocell_descuento").Value = orow(0)("f0305_descuento") * 100
            dg_listado.CurrentRow.Cells("dgocell_iva").Value = orow(0)("f0305_iva") * 100
            dg_listado.CurrentRow.Cells("dgocell_costo_unit_iva").Value = orow(0)("costo_unit_iva")
            dg_listado.CurrentRow.Cells("dgocell_costo_total_iva").Value = orow(0)("costo_total")
        End If
    End Sub
    Private Sub Actualizar_item()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_cantidad = @f0305_cantidad,"
        csql += "f0305_iva = @f0305_iva,"
        csql += "f0305_descuento = @f0305_descuento,"
        csql += "f0305_costo_unitario_planificado = @f0305_costo_unitario_planificado,"
        csql += "f0305_costo_total_planificado = @f0305_costo_total_planificado,"
        csql += "f0305_var_cost_prom = @f0305_var_cost_prom,"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_modificar = @f0305_usuario_modificar"
        csql += " where f0305_id_item_solicitud = @f0305_id_item_solicitud"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_item(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
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
    Private Sub Crear_parametros_item(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0305_id_item_solicitud", NpgsqlDbType.Integer).Value = dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value
        ocmd.Parameters.Add("@f0305_cantidad", NpgsqlDbType.Numeric).Value = dg_listado.CurrentRow.Cells("dgocell_cantidad_solicitada").Value
        ocmd.Parameters.Add("@f0305_iva", NpgsqlDbType.Numeric).Value = dg_listado.CurrentRow.Cells("dgocell_iva").Value / 100
        ocmd.Parameters.Add("@f0305_descuento", NpgsqlDbType.Numeric).Value = dg_listado.CurrentRow.Cells("dgocell_descuento").Value / 100
        ocmd.Parameters.Add("@f0305_var_cost_prom", NpgsqlDbType.Numeric).Value = var_costo_promedio_actual
        ocmd.Parameters.Add("@f0305_costo_unitario_planificado", NpgsqlDbType.Numeric).Value = valores(1)
        ocmd.Parameters.Add("@f0305_costo_total_planificado", NpgsqlDbType.Numeric).Value = valores(4)
        ocmd.Parameters.Add("@f0305_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub

    Private Sub Buscar_info_item_solicitado(ByVal id_sc_item As Integer)
        csql = "select * from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " join " & database.obtener_esquema & ".tb0300_items" _
            & " on f0300_id_item = f0305_id_item" _
            & " where f0305_id_item_solicitud = '" & id_sc_item & "'"
        otb_info_item_sc = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        verror_requisitos = "N"
        vmensaje_requisitos = ""
        For Each orow As DataRow In otb_info_item_sc.Rows
            costo_promedio_actual = orow("f0300_costo_promedio")
            id_tipo_item = orow("f0300_id_tipo_item")
            If orow("f0305_factura_c_aprov") = "S" And permitir_var_costo = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Este Item esta registrado en una factura Aprobada!"
            End If
            If orow("f0305_docto_mov_inventario") <> "" And permitir_var_costo = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Este Item esta registrado en una factura con Recepcion Aprobada!"
            End If
            If orow("f0305_estado") = "A" And permitir_var_costo = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Este Item esta registrado en una Solicitud Aprobada!"
            End If
        Next

        'calculo la desviacion del valor respecto al costo promedio actual
        If costo_promedio_actual > 0 Then
            var_costo_promedio_actual = ((valores(1) - costo_promedio_actual) / costo_promedio_actual)
            dg_listado.CurrentRow.Cells("dgocell_var_costo").Value = Math.Round(var_costo_promedio_actual * 100, 1)
        Else
            var_costo_promedio_actual = 0
            dg_listado.CurrentRow.Cells("dgocell_var_costo").Value = 0
        End If
        If Math.Abs(var_costo_promedio_actual) > 999.999 Then
            var_costo_promedio_actual = 999.9999
        End If
        'valido la variacion de costo 
        Dim ovar_costo_aceptable As Decimal
        ovar_costo_aceptable = comunes.suministrar_valor_variable_configuracion("CONFIG-0300-06", vg_id_cia) / 100
        If (Math.Abs(var_costo_promedio_actual) > 0.15 And Math.Abs(var_costo_promedio_actual) <> 1) And (id_tipo_item = 1 Or id_tipo_item = 2) Then
            If permitir_var_costo = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Variacion de costo exagerada, requiere AUTORIZACION."
            End If
        End If
    End Sub
    Private Sub Inicializar_campos()
        vf_elemento_nuevo = "S"
        id_solicitud_compra = 0
        tx_id_accion.Text = ""
        tx_solicitud.Text = ""
        cm_estado.SelectedIndex = -1
        cm_centro_costo.SelectedIndex = -1
        tx_anotacion.Text = ""
        'cm_usuario.SelectedIndex = -1
        dtp_fecha_solicitud.Value = comunes.g_fechahora
        id_estructura = 0
        id_accion = 0
        tx_estructura.Text = ""
        dg_listado.Rows.Clear()
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
    End Sub
    Private Sub Cargar_datatables()
        'carga informacion del ecabezado de las solicitudes de compra
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0304_solicitud_compra" _
            & " Where f0304_id_solicitud = '" & id_solicitud_compra & "' and f0304_anulado = 'N'"
        otb_solicitudes = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'carga informacion de los items en las solictudes
        'carga informacion de los items en las solictudes
        csql = "select tb0305_items_solicitados.*, f0300_id_item, f0300_codigo_cguno," _
            & " f0300_descripcion_item || ' - ' || f0300_referencia || ' - ' || f0300_contenido_x_empaque as descripcion," _
            & " f0305_ampliacion_item as descripcion_comp," _
            & " f0002_sigla_unidad_medicion," _
            & " f0305_costo_unitario_planificado as costo_unitario," _
            & " f0305_costo_unitario_planificado * f0305_cantidad as costo_subtotal," _
            & " f0305_costo_total_planificado / f0305_cantidad as costo_unit_iva," _
            & " f0305_costo_total_planificado as costo_total," _
            & " case when f0305_cantidad_aprobada = 0 then f0305_cantidad end as cantidad_aprobada," _
            & " f0305_id_solicitud_compra as id_solic," _
            & " COALESCE(otb_estructura_madre.f0100_codigo || ' -- { ' || otb_estructura_madre.f0100_nombre || ' }'," _
                    & " otb_estructura_referida.f0100_codigo || ' -- { ' || otb_estructura_referida.f0100_nombre || ' }')" _
                    & " as descripcion_codigo," _
            & " f0305_id_accion" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " join " & database.obtener_esquema & ".tb0300_items" _
                & " on f0305_id_item = f0300_id_item" _
            & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                & " on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
            & " join " & database.obtener_esquema & ".tb0304_solicitud_compra" _
                & " on f0305_id_solicitud_compra = f0304_id_solicitud" _
            & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as otb_estructura_referida" _
                & " on f0305_id_estructura = otb_estructura_referida.f0100_id_estructura" _
            & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as otb_estructura_madre" _
                & " on otb_estructura_referida.f0100_id_maquina_padre = otb_estructura_madre.f0100_id_estructura" _
            & " where f0305_id_solicitud_compra = '" & id_solicitud_compra & "' and f0305_anulado = 'N'"
        otb_recursos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Calcular_costos_totales()
    End Sub
    Private Sub Calcular_costos_totales()
        ' Declare an object variable.
        Dim sumObject As Object
        Dim ovalor As Decimal = 0
        sumObject = otb_recursos.Compute("Sum(costo_subtotal)", "")
        Try
            ovalor = sumObject
        Catch ex As Exception
            ovalor = 0
        End Try
        lb_valor_subtotal.Text = ovalor.ToString("C2")

        sumObject = otb_recursos.Compute("Sum(costo_total)", "")
        Try
            ovalor = sumObject
        Catch ex As Exception
            ovalor = 0
        End Try
        lb_valor_factura.Text = ovalor.ToString("C2")
    End Sub
    Private Sub Crear_columnas_dg()
        'Dim ocolumgrid As New DataGridViewColumn
        'Dim col1 As New DataGridViewCheckBoxColumn
        'col1.Name = "dgocell_aprovado"
        'col1.HeaderText = "Aprov"
        'col1.Width = 40
        'col1.ReadOnly = False
        'dg_listado.Columns.Add(col1)
    End Sub
    Private Sub Llenar_items_solicitados()
        dg_listado.Rows.Clear()
        For Each orow As DataRow In otb_recursos.Rows
            Agregar_fila_items(orow)
        Next
    End Sub
    Private Sub Agregar_fila_items(ByVal orow As DataRow)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_id_item_solicitud").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0300_id_item").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0300_codigo_cguno").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("descripcion").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("descripcion_comp").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_cantidad")
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        If orow.Item("f0305_chkinventario") = "N" Then
            ochkgrid = New DataGridViewCheckBoxCell With {
                .Value = False
            }
        Else
            ochkgrid = New DataGridViewCheckBoxCell With {
                .Value = True
            }
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna 7
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_inventario")
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 8
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0002_sigla_unidad_medicion").ToString
        }
        'otextgrid.MaxInputLength = 100 
        'Agrega columna al objeto fila 
        orowgrid.Cells.Add(otextgrid)

        'crea columna 9
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = Math.Round(orow.Item("f0305_var_cost_prom") * 100, 1)
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 9
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("costo_unitario") / (1 - orow.Item("f0305_descuento"))
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 11
        'Dim result As String = String.Format("{0:0.0%}", orow.Item("f0305_descuento"))
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_descuento") * 100 'result
            }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 10
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("costo_subtotal")
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 12
        'Dim result2 As String = String.Format("{0:0.0%}", orow.Item("f0305_iva"))
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_iva") * 100 'result2
            }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 10
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("costo_unit_iva")
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 13
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("costo_total")
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 14
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("descripcion_codigo").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 14
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_id_accion").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 14
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_anotacion_item").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 14
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_id_factura_compras").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 14
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_docto_mov_inventario").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 13
        'otextgrid = New DataGridViewTextBoxCell
        'CDate(tx_fecha_hora.Text).ToString("yyyy/MM/dd")
        'otextgrid.Value = orow.Item("f0700_observacion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        'orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_listado.Rows.Add(orowgrid)
    End Sub
    Private Sub Proteger_celdas()
        If dg_listado.CurrentRow.Cells("dgocell_aprovado").Value = -1 Then
            'MsgBox("protegida")
            dg_listado.CurrentRow.ReadOnly = True
            dg_listado.CurrentRow.Cells("dgocell_cant_aprov").ReadOnly = True
            dg_listado.CurrentRow.Cells("dgocell_aprovado").ReadOnly = False
        Else
            dg_listado.CurrentRow.Cells("dgocell_cant_aprov").ReadOnly = False
            dg_listado.CurrentRow.ReadOnly = False
            dg_listado.CurrentRow.Cells("dgocell_aprovado").ReadOnly = False
        End If
    End Sub

    Private Sub Procedimiento_grabado()
        verror_requisitos = "N"
        Validar_centro_costo()
        Validar_estructura()
        ValidarAccion()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        'autoriza = "N"
        'Dim oform_login As New camocontrol.login
        'oform_login.vf_oform_padre = Me
        'oform_login.paso_autorizacion = "S"
        'oform_login.ShowDialog()

        'If autoriza = "N" Then
        'Exit Sub
        'End If

        If tx_solicitud.Text.ToString = "" Then
            vf_elemento_nuevo = "S"
        Else
            vf_elemento_nuevo = "N"
        End If

        If vf_elemento_nuevo = "S" Then
            Grabar_nueva_solicitud()
            If vf_oform_padre.name = "fm_0300_facturas_compras" Then
                vf_oform_padre.id_sc_creada = id_solicitud_compra
            End If
        Else
            Actualizar_solicitud()
        End If
        vf_elemento_nuevo = "N"
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
    End Sub

    Private Sub Grabar_nueva_solicitud()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0304_solicitud_compra" _
                & " (f0304_id_cia, f0304_id_accion, f0304_id_estructura, f0304_id_centro_costo, f0304_anotacion," _
                & " f0304_usuario_modificar, f0304_usuario_crear, f0304_fm)" _
                & " VALUES" _
                & " (@f0304_id_cia, @f0304_id_accion, @f0304_id_estructura, @f0304_id_centro_costo, @f0304_anotacion," _
                & " @f0304_usuario_modificar, @f0304_usuario_crear, @f0304_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_solicitud(ocmd)

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
        If verror = "N" Then
            tx_solicitud.Text = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0304_id_solicitud", "f0304_usuario_crear", vg_usuario_autoriza, "tb0304_solicitud_compra")
            id_solicitud_compra = tx_solicitud.Text
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Actualizar_solicitud()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0304_solicitud_compra set "
        csql += "f0304_id_cia = @f0304_id_cia,"
        'csql += "f0304_id_estado = @f0304_id_estado,"
        'csql += "f0304_id_accion = @f0304_id_accion,"
        csql += "f0304_id_estructura = @f0304_id_estructura, "
        csql += "f0304_id_centro_costo = @f0304_id_centro_costo,"
        csql += "f0304_anotacion = @f0304_anotacion,"
        csql += "f0304_fm = @f0304_fm,"
        csql += "f0304_usuario_modificar = @f0304_usuario_modificar"
        csql += " where f0304_id_solicitud = @f0304_id_solicitud"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_solicitud(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
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
    Private Sub Crear_parametros_solicitud(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0304_id_solicitud", NpgsqlDbType.Integer).Value = tx_solicitud.Text.ToString
        End If
        ocmd.Parameters.Add("@f0304_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        'ocmd.Parameters.Add("@f0304_id_estado", NpgsqlDbType.Integer).Value = cm_estado.SelectedValue
        ocmd.Parameters.Add("@f0304_id_accion", NpgsqlDbType.Integer).Value = id_accion
        ocmd.Parameters.Add("@f0304_id_estructura", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0304_id_centro_costo", NpgsqlDbType.Integer).Value = cm_centro_costo.SelectedValue
        ocmd.Parameters.Add("@f0304_anotacion", NpgsqlDbType.Varchar).Value = tx_anotacion.Text.ToString
        ocmd.Parameters.Add("@f0304_usuario_modificar", NpgsqlDbType.Varchar).Value = cm_usuario.SelectedValue
        ocmd.Parameters.Add("@f0304_usuario_crear", NpgsqlDbType.Varchar).Value = cm_usuario.SelectedValue
        ocmd.Parameters.Add("@f0304_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub ValidarAccion()
        If tx_id_accion.Text = String.Empty Then
            vmensaje_requisitos = "Toda compra debe estar relacionada a una accion!"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub Validar_estructura()
        If tx_estructura.Text = String.Empty Then
            vmensaje_requisitos = "Seleccione un Equipo/Estructura"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub Validar_centro_costo()
        If cm_centro_costo.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione un centro de costo"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub Validar_aprobaciones()
        Dim otb_oc As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0304_solicitud_compra" _
            & " where f0304_id_solicitud = '" & id_solicitud_compra & "'"
        otb_oc = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_oc.Rows
            If orow("f0304_id_estado") <> "1" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Una solicitud aprobada no puede modificarse!"
            End If
        Next
    End Sub
    Private Sub Bt_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nuevo.Click
        Inicializar_campos()
    End Sub
    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click

        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Grabar Actividad", "Desea grabar este recurso?")
        If respuesta = "N" Then
            Exit Sub
        End If
        If dg_listado.Rows.Count = 0 Then
            MsgBox("No hay ningun Item solicitado", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        verror_requisitos = "N"
        Validar_aprobaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Procedimiento_grabado()

        If verror = "N" Then
            MsgBox("Solicitud Grabada", MsgBoxStyle.Information, "Grabar")
        End If
        If dg_listado.Rows.Count > 0 Then
            'Dispose()
        End If
    End Sub
    Private Sub Validar_item_aprobaciones()
        Dim otb_item As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_solicitud_compra = '" & id_solicitud_compra.ToString & "' and f0305_anulado = 'N'"
        otb_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim info As String = ""
        For Each orow As DataRow In otb_item.Rows
            info = "id_item_sc: " & orow("f0305_id_item_solicitud") & " id_item: " & orow("f0305_id_item")
            If orow("f0305_factura_c_aprov") = "S" Then
                verror_requisitos = "S"
                vmensaje_requisitos = info & " Esta registrado en una factura Aprobada!"
            End If
            If orow("f0305_docto_mov_inventario") <> "" Then
                verror_requisitos = "S"
                vmensaje_requisitos = info & " Esta registrado en una factura con Recepcion Aprobada!"
            End If
            If orow("f0305_estado") <> "P" Then
                'verror_requisitos = "S"
                'vmensaje_requisitos = "Este Item esta registrado en una Solicitud Aprobada!"
            End If
        Next
    End Sub
    Private Sub Bt_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_anular.Click
        'Pregunta si realmente desea anular
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Registro", "Desea Anular esta solicitud y todos sus Items?")
        If respuesta = "N" Then
            Exit Sub
        End If

        If tx_solicitud.Text.ToString = "" Then
            vf_elemento_nuevo = "S"
        Else
            vf_elemento_nuevo = "N"
        End If
        If vf_elemento_nuevo = "S" Then
            Exit Sub
        End If

        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        'autoriza = "N"
        'Dim oform_login As New camocontrol.login
        'oform_login.vf_oform_padre = Me
        'oform_login.paso_autorizacion = "S"
        'oform_login.ShowDialog()

        'If autoriza = "N" Then
        'Exit Sub
        'End If
        verror_requisitos = "N"
        Validar_item_aprobaciones()
        Validar_aprobaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Anular_todos_los_items_sc()
        'Si la solicitud queda es porque items factura aprovada
        'carga informacion de los items en las solictudes
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " Where f0305_id_solicitud_compra = '" & id_solicitud_compra & "' and f0305_anulado = 'N'"
        Dim otb_cont As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_cont.Rows.Count = 0 Then
            Anular_solicitud_compra()
        Else
            MsgBox("La solicitud contiene items que ya fueron registrados en una factura", MsgBoxStyle.Information, "Informacion")
            Cargar_datatables()
            Llenar_items_solicitados()
            Exit Sub
        End If
        Dispose()
    End Sub
    Private Sub Anular_solicitud_compra()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0304_solicitud_compra set "
        csql += "f0304_anulado = @f0304_anulado,"
        csql += "f0304_fm = @f0304_fm,"
        csql += "f0304_usuario_anular = @f0304_usuario_anular"
        csql += " where f0304_id_solicitud = @f0304_id_solicitud"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0304_id_solicitud", NpgsqlDbType.Integer).Value = id_solicitud_compra
        ocmd.Parameters.Add("@f0304_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0304_anulado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0304_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
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
    Private Sub Anular_todos_los_items_sc()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_anulado = @f0305_anulado,"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_anular = @f0305_usuario_anular"
        csql += " where f0305_id_solicitud_compra = @f0305_id_solicitud_compra and f0305_factura_c_aprov = 'N'"
        csql += " And f0305_id_factura_compras Is null"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0305_id_solicitud_compra", NpgsqlDbType.Integer).Value = id_solicitud_compra
        ocmd.Parameters.Add("@f0305_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_anulado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0305_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar eliminar Items! " + vbCrLf + ex.ToString)
        End Try
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Bt_generar_informe_Click(sender As System.Object, e As System.EventArgs) Handles bt_generar_informe.Click
        If tx_solicitud.Text.Trim = "" Then
            MsgBox("Solicitud fallida", MsgBoxStyle.Information, "Seleccionar")
            Exit Sub
        End If
        cl_informes_comunes.informe_solicitud_compra(tx_solicitud.Text, vg_id_cia)
    End Sub

    Private Sub Bt_catalago_items_Click(sender As System.Object, e As System.EventArgs) Handles bt_catalago_items.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0300_gestion_items With {
            .vf_oform_padre = Me,
            .vg_usuario_autoriza = vg_usuario_autoriza,
            .vg_id_cia = vg_id_cia
        }
        'oform_catalogo_items.vf_elemento_nuevo = "N"
        oform_catalogo_items.ShowDialog()
    End Sub

    Private Sub Bt_cambiar_infraestructura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_cambiar_infraestructura.Click
        verror_requisitos = "N"
        Validar_aprobaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        cambiar_estructura = "N"
        verror_requisitos = "N"
        Dim nueva_estructura As String = id_estructura.ToString
        nueva_estructura = cl_utilidades_gestion_mantenimiento.suministrar_estructura_mantenimiento(vg_id_cia, vg_usuario_autoriza, id_estructura)
        Dim id_estructura_anterior As Integer = id_estructura
        If id_estructura.ToString <> nueva_estructura Then
            id_estructura = nueva_estructura
            If id_estructura_anterior <> id_estructura Then
                'validar_cambios_solo_creador()
                If verror_requisitos = "S" Then
                    MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
                    Exit Sub
                End If
                If vf_elemento_nuevo = "N" Then
                    Cambiar_estructura_seleccionada()
                End If
                tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura.ToString)
            End If
        End If
    End Sub
    Private Sub Cambiar_estructura_seleccionada()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0304_solicitud_compra set " _
                    & " f0304_id_estructura = '" & id_estructura & "'" _
                    & " where f0304_id_solicitud = '" & id_solicitud_compra & "'"
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
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
    Private Sub Aprobar_items_sc(id_item_solicitud As Integer, estado As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_fecha_aprobacion = @f0305_fecha_aprobacion,"
        csql += "f0305_estado = @f0305_estado,"
        csql += "f0305_usuario_aprobar = @f0305_usuario_aprobar"
        csql += " where f0305_id_item_solicitud = @f0305_id_item_solicitud"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0305_id_item_solicitud", NpgsqlDbType.Integer).Value = id_item_solicitud
        ocmd.Parameters.Add("@f0305_usuario_aprobar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_estado", NpgsqlDbType.Varchar).Value = estado
        ocmd.Parameters.Add("@f0305_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Aprobar los Items! " + vbCrLf + ex.ToString)
        End Try
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Aprobar_solicitud()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0304_solicitud_compra set " _
                    & " f0304_id_estado = '" & cm_estado.SelectedValue & "'" _
                    & " where f0304_id_solicitud = '" & id_solicitud_compra & "'"
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
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

    Private Sub Bt_cambiar_estado_Click(sender As System.Object, e As System.EventArgs) Handles bt_cambiar_estado.Click
        If dg_listado.Rows.Count = 0 Then
            MsgBox("No hay ningun Item solicitado", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Dim id_itemdetalle_sc As Integer
        Dim oestado As String = "P"
        Select Case cm_estado.SelectedValue
            'P=pendiente,A=aprovado,N=negado
            Case 1
                oestado = "P"
            Case 4
                oestado = "N"
            Case 5
                oestado = "A"
        End Select
        For Each orow As DataGridViewRow In dg_listado.Rows
            id_itemdetalle_sc = orow.Cells("dgocell_id_sc_item").Value
            Aprobar_items_sc(id_itemdetalle_sc, oestado)
            'If orow.Cells("dgocell_chk_aprobar").Value = -1 Then
            'aprobar_items_sc(id_itemdetalle_sc, oestado)
            'Else
            'If oestado = "A" Then
            'anular_un_solo_item_sc(id_itemdetalle_sc)
            'Else
            'aprobar_items_sc(id_itemdetalle_sc, oestado)
            'End If
            'End If
            'MsgBox(id_item)
        Next
        Aprobar_solicitud()
        MsgBox("Estado de la solicitud cambiado", MsgBoxStyle.Information, "Info")
    End Sub
    Private Sub Anular_un_solo_item_sc(ByVal id_itemdetalle_sc As Integer)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_anulado = @f0305_anulado,"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_anular = @f0305_usuario_anular"
        csql += " where f0305_id_item_solicitud = @f0305_id_item_solicitud and f0305_factura_c_aprov = 'N'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0305_id_item_solicitud", NpgsqlDbType.Integer).Value = id_itemdetalle_sc
        ocmd.Parameters.Add("@f0305_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_anulado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0305_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar eliminar Items! " + vbCrLf + ex.ToString)
        End Try
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Bt_agregar_item_Click(sender As Object, e As EventArgs) Handles bt_agregar_item.Click

        verror_requisitos = "N"
        Validar_aprobaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Procedimiento_grabado()
        If verror_requisitos = "S" Then
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_agregar_recurso As New camocontrol.fm_0300_sc_items With {
            .vf_oform_padre = Me,
            .id_solicitud_compra = id_solicitud_compra,
            .vg_usuario_autoriza = vg_usuario_autoriza,
            .vg_id_cia = vg_id_cia,
            .id_estructura = id_estructura,
            .id_accion = id_accion,
            .vf_elemento_nuevo = "S"
        }
        oform_agregar_recurso.ShowDialog()
        Cargar_datatables()
        Llenar_items_solicitados()
        'dg_listado.DataSource = otb_recursos
    End Sub

    Private Sub Bt_historico_compras_Click(sender As Object, e As EventArgs) Handles bt_historico_compras.Click
        If tx_id_item_cons_mov.Text = "" Then
            MsgBox("Seleccione un item para consultar", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_compras.movimientos_compras_item(tx_id_item_cons_mov.Text, vg_usuario_autoriza, vg_id_cia)
    End Sub

    Private Sub Bt_generar_recepcion_Click(sender As Object, e As EventArgs) Handles bt_generar_recepcion.Click
        If tx_solicitud.Text.Trim = "" Then
            MsgBox("Solicitud fallida", MsgBoxStyle.Information, "Seleccionar")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_factura_compra As New camocontrol.fm_0300_facturas_compras With {
            .vf_oform_padre = Me,
            .vg_id_cia = vg_id_cia
        }
        'oform_factura_compra.vf_var_config_notas = "TN-FCP-001"
        'oform_factura_compra.vf_var_config_archivos = "CD-FCC"
        oform_factura_compra.tx_sol_compra.Text = id_solicitud_compra
        'oform_factura_compra.id_factura_compras = dg_datos.CurrentCell.Value
        oform_factura_compra.vg_usuario_autoriza = vg_usuario_autoriza
        oform_factura_compra.vf_elemento_nuevo = "S"
        oform_factura_compra.Show()
    End Sub
End Class
