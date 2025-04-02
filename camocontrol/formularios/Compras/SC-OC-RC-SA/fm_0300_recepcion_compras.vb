Public Class fm_0300_recepcion_compras
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_factura_compras As Integer 'se asigna cuando se llama al formulario desde el fm_padre
    Public id_sc_creada As Integer = 0 'para recoger el numero de la solicitud de compra que creo desde el formulario
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
    Private otipo_nota As String

    'Private recep_aprov As String = "N" 'para identificar si ya se aprovo la recepcion.

    Private otb_proveedores As DataTable
    Private otb_solicitudes As DataTable
    Private otb_items_programados As DataTable
    Private otb_ItemsSinEntrada As DataTable 'datatable que contiene los items de la factura sin entrada
    Private otb_info_personal As DataTable
    Private otb_info_factura As DataTable
    Private otb_info_item_sc As DataTable 'para buscar la informacion actualizada del item que se esta editando
    Private otb_doc_mov_invent_relacionados As DataTable 'documentos de movimientos de inventario relacionados

    Private id_tercero As String = ""
    Private id_tipo_item As Integer
    Private permitir_var_costo As String = "N"
    Private var_costo_promedio_actual As Decimal = 0 'variacion del valor actual con respecto al costo promedio actual
    Private costo_promedio_actual As Decimal = 0
    Private valores() As Decimal = Nothing
    Private actualizar_grilla As String = "N"

    Private path_file As String = ""
    Private extension As String = ""
    Private new_name_file As String = ""
    Private new_path_file As String = ""
    Private oaprovada As String = "N" 'Indica si la factura ya esta aprovada
    Private ocosto As Decimal = 0 'Acumulara el valor de cada item para obtener el costo total
    Private docto_mov_inv As String = ""
    Private valor_anterior As Decimal


    Private Sub Fm_0300_facturas_compras_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-FCC"
        vf_var_config_notas = "TN-FCP-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)

        'formatear_grilla()
        ' Set the Format type and the CustomFormat string.
        dtp_fecha.Format = DateTimePickerFormat.Custom
        dtp_fecha.CustomFormat = "yyyy/MM/dd  HH:mm"

        tx_id_factura.ReadOnly = True
        tx_estado.ReadOnly = True
        tx_cuadre_caja.ReadOnly = True
        tx_id_item_cons_mov.ReadOnly = True
        'bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_generar_informe.Enabled = False
        bt_aprobar.Enabled = True

        'OJO CAMBIAR LOS PERMISOS EN LA TABLA DE PERMISOS, ESTE BOTON APLICA PARA LAS RECEPCIONES, SALE DE FACTURAS
        cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_aprobar_recepcion, "")

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0005_bodegas"
        Dim otb_bodega_consumos As DataTable
        otb_bodega_consumos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_bodega
            'Valor que se muestra al usuario
            .DisplayMember = "f0005_descripcion_bodega"
            'Valor interno que almacena el objeto
            .ValueMember = "f0005_id_bodega"
            'Origen de Datos del ComboBox
            .DataSource = otb_bodega_consumos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        If vf_elemento_nuevo = "S" Then
            tx_estado.Text = "Nuevo"

        Else
            Tx_Nit.Enabled = False
            Tx_Nombre_Tercero.Enabled = False
            Cargar_elemento_existente()
            Llenar_items_solicitados()

            'identifico el tipo de nota
            vf_id_notas_archivos = tx_id_factura.Text
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
            'activar_grabar()
            'new_name_file = comunes.suministrar_valor_variable_configuracion("CD-FCC-001", vg_id_cia)
            'new_name_file += "-" & tx_id_factura.Text.PadLeft(8, "0")
        End If
        Formatear_grilla()
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
        tx_sol_compra.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc").Value
        tx_id_item_sc.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value
        tx_id_item_cons_mov.Text = dg_listado.CurrentRow.Cells("dgocell_item").Value
        'tx_id_oc.Text = dg_listado.CurrentRow.Cells("dgocell_id_oc").Value
        lb_doc_entrada.Text = dg_listado.CurrentRow.Cells("dgocell_DocEntrada").Value
        Dim nombre_columna As String = dg_listado.Columns(dg_listado.CurrentCell.ColumnIndex).Name
        Select Case nombre_columna
            Case "dgocell_id_sc"

            Case "dgocell_id_sc_item"

        End Select
    End Sub
    Private Sub Dg_listado_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_listado.CellDoubleClick
        If dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim nombre_columna As String = dg_listado.Columns(dg_listado.CurrentCell.ColumnIndex).Name
        Select Case nombre_columna
            Case "dgocell_item"
                Dim oform_item As New camocontrol.fm_0300_gestion_items With {
                    .vf_oform_padre = Me,
                    .vg_id_cia = vg_id_cia,
                    .cerrar_al_actualizar = "S",
                    .id_item = dg_listado.CurrentCell.Value,
                    .vg_usuario_autoriza = vg_usuario_autoriza,
                    .vf_elemento_nuevo = "N"
                }
                oform_item.ShowDialog()
            Case "dgocell_id_sc"
                'me esta generando un error incosntante, tengo que averiguar por que
                'Esta operación no se puede realizar cuando se está cambiando de tamaño una columna de relleno automático.
                'tx_sol_compra.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc").Value
                'abrir_info_solicitud_compra(tx_sol_compra.Text)
                'tx_sol_compra.Text = ""
            Case "dgocell_id_sc_item"
                tx_id_item_sc.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value
                Abrir_form_info_item(dg_listado.CurrentCell.Value)
                Llenar_items_solicitados()
            Case "dgocell_id_oc"
                Dim oform_OC As New camocontrol.fm_0300_orden_compra With {
                    .vf_oform_padre = Me,
                    .vg_id_cia = vg_id_cia,
                    .id_orden_compra = dg_listado.CurrentRow.Cells("dgocell_id_oc").Value,
                    .vg_usuario_autoriza = vg_usuario_autoriza,
                    .vf_elemento_nuevo = "N"
                }

                oform_OC.ShowDialog()
            Case "dgocell_id_accion"
                If dg_listado.CurrentCell.Value.ToString <> "0" And dg_listado.CurrentCell.Value.ToString.Trim <> "" Then
                    Dim id_accion As Integer
                    id_accion = dg_listado.CurrentCell.Value
                    'ajecutamos clase que abre el formulario adecuado segun el tipo de actividad
                    cl_utilidades_gestion_acciones.abrir_actividad(id_accion, vg_usuario_autoriza, vg_id_cia)
                End If
            Case "dgocell_id_accion_raiz"
                If dg_listado.CurrentCell.Value.ToString <> "0" And dg_listado.CurrentCell.Value.ToString.Trim <> "" Then
                    Dim id_accion As Integer
                    id_accion = dg_listado.CurrentCell.Value
                    'ajecutamos clase que abre el formulario adecuado segun el tipo de actividad
                    cl_utilidades_gestion_acciones.abrir_actividad(id_accion, vg_usuario_autoriza, vg_id_cia)
                End If
        End Select
    End Sub
    Private Sub Dg_listado_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_listado.CellContentDoubleClick
        If dg_listado.CurrentRow.Cells("dgocell_chk_item_aprobado").Value = -1 Then
            MsgBox("Un item aprobado no puede modificarse", MsgBoxStyle.Information, "Info")
        End If
    End Sub
    Private Sub Dg_listado_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dg_listado.CellEnter
        If dg_listado.CurrentRow.Cells("dgocell_chk_item_aprobado").Value = -1 Then
            'MsgBox("bloqueado")
            dg_listado.CurrentRow.ReadOnly = True
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
        lb_valor_factura.Text = "Actualizar"
        lb_valor_subtotal.Text = "Actualizar"
        If verror_requisitos = "N" Then
            Actualizar_item()
            'MsgBox("Ahora puedo grabar")
        Else
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Information, "Info")
            'vuelvo a cargar la informacion anterior
            Dim orow As DataRow() = otb_items_programados.Select("f0305_id_item_solicitud = '" &
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
    Private Sub Activar_botones_aprobaciones()
        If oaprovada = "N" Then
            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_aprobar, "")
        Else
            bt_aprobar.Enabled = False
            bt_aprobar_recepcion.Enabled = False
            bt_aprobar_recepcion_sin_ea.Enabled = False
        End If
    End Sub
    Private Sub Inicializar_campos()
        tx_id_factura.Text = ""
        tx_estado.Text = "Sin Aprobar"
        'cm_proveedor.SelectedIndex = -1
        'cm_nit.SelectedIndex = -1
        tx_factura_proveedor.Focus()
        tx_oc_uno.Text = ""
        tx_cuadre_caja.Text = ""
        tx_factura_proveedor.Text = ""
        tx_remision_proveedor.Text = ""
        tx_id_item_sc.Text = ""
        dg_listado.Rows.Clear()
        oaprovada = "N"
        vf_elemento_nuevo = "S"
        'lb_valor_aprobado.Text = "$0.00"
        lb_valor_factura.Text = "$0.00"
        lb_valor_subtotal.Text = "$0.00"
        dtp_fecha_factura.Value = comunes.g_fechahora
        dtp_vencimiento_factura.Value = comunes.g_fechahora
        vf_id_notas_archivos = ""
        Tx_Nit.Enabled = True
        Tx_Nombre_Tercero.Enabled = True
        Tx_Nit.Text = ""
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
        Tx_Nombre_Tercero.Text = ""
        Tx_Nombre_Tercero.SelectedText = "--BUSCAR--"
        Tx_Nombre_Tercero.Focus()
    End Sub
    Private Sub Cargar_elemento_existente()
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0307_facturas_compras" _
            & " where f0307_id_factura_compras = '" & id_factura_compras & "'"
        otb_info_factura = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_factura.Rows
            tx_id_factura.Text = orow("f0307_id_factura_compras")
            vf_id_notas_archivos = orow("f0307_id_factura_compras")
            vf_elemento_nuevo = "N"
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
            If bt_g_archivos.Text = "0" Then
                bt_aprobar.BackColor = Color.Red
            End If

            lb_doc_entrada.Text = orow("f0307_doc_entrada").ToString
            If IsDBNull(orow("f0307_fecha_aprobacion")) = False Then
                lb_fecha_aprob.Text = CDate(orow("f0307_fecha_aprobacion")).ToString("yyyy/MM/dd HH:mm:ss")
            End If


            If orow("f0307_recepcion_aprobada") = "S" Then
                'tx_estado.Text = "Recepcion Aprobada"
                'recep_aprov = "S"
                'cm_bodega.SelectedValue = orow("f0307_id_bodega_entrada")
                'cm_bodega.Enabled = False
            End If
            If orow("f0307_aprobada") = "S" Then
                tx_estado.Text = "Aprobada"
            Else
                tx_estado.Text = "Sin Aprobar Factura"
                Tx_Nit.Enabled = True
                Tx_Nombre_Tercero.Enabled = True
            End If
            'cargo la informacion del tercero
            id_tercero = orow("f0307_id_tercero")
            cargar_info_tercero()

            tx_oc_uno.Text = orow("f0307_oc_uno").ToString
            tx_factura_proveedor.Text = orow("f0307_numero_factura")
            tx_remision_proveedor.Text = orow("f0307_remision_proveedor")

            Dim val_fact As Decimal = orow("f0307_valor_factura")
            'lb_valor_aprobado.Text = val_fact.ToString("C2")
            oaprovada = orow("f0307_aprobada")
            dtp_fecha_factura.Value = orow("f0307_fecha_factura")
            dtp_vencimiento_factura.Value = orow("f0307_fecha_vencimiento_factura")
            Activar_botones_aprobaciones()
        Next
    End Sub
    Private Sub cargar_info_tercero()
        csql = "select f0200_id_tercero, f0200_id || '-' ||f0200_dig_ver_nit as nit," _
            & "trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2 || ' - ' || f0200_id) as razon_social" _
            & " FROM " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_ind_principal = 'S' and f0200_id_tercero = '" & id_tercero & "'"
        '& " and f0200_id_cia ='" & vg_id_cia & "'"
        otb_proveedores = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_proveedores.Rows
            tx_id_tercero.Text = orow("f0200_id_tercero")
            Tx_Nit.Text = orow("nit")
            Tx_Nombre_Tercero.Text = orow("razon_social")
        Next

    End Sub
    Private Sub Tx_Nombre_Tercero_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_Nombre_Tercero.KeyDown
        If (e.KeyCode = Keys.B AndAlso e.Modifiers = Keys.Control) Then
            'PARA USAR CUANDO EL FORMULARIO ES PARA SELECCIONAR UN DATO
            'MsgBox(dg_datos.CurrentRow.Cells("id_sc").Value)
            Buscar_tercero(1)
        End If
    End Sub
    Private Sub Tx_Nit_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_Nit.KeyDown
        If (e.KeyCode = Keys.B AndAlso e.Modifiers = Keys.Control) Then
            'PARA USAR CUANDO EL FORMULARIO ES PARA SELECCIONAR UN DATO
            'MsgBox(dg_datos.CurrentRow.Cells("id_sc").Value)
            MsgBox("hola")
            Buscar_tercero(2)
        End If
    End Sub
    Private Sub Buscar_tercero(ByVal tipofiltro As Integer)
        Dim filtro As String = ""

        If Tx_Nombre_Tercero.Text <> "" And tipofiltro = 1 Then
            filtro = "razon_social LIKE '%" & Tx_Nombre_Tercero.Text.Trim & "%'"
        End If
        If Tx_Nit.Text <> "" And tipofiltro = 2 Then
            filtro = "nit LIKE '%" & Tx_Nit.Text.Trim & "%'"
        End If

        Tx_Nombre_Tercero.Text = ""
        Tx_Nit.Text = ""

        Dim id_ter As String = comunes.Buscador_Terceros(vg_id_cia, vg_usuario_autoriza, filtro)
        If id_ter = "0" Then
            tx_id_tercero.Text = ""
            Tx_Nit.Text = ""
            Tx_Nombre_Tercero.Text = ""
        Else
            id_tercero = id_ter
            cargar_info_tercero()
            'tx_cantidad.Focus()
        End If
    End Sub

    Private Sub CargarItemsSinEntrada()
        csql = "select * from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_factura_compras = '" & id_factura_compras & "'" _
            & " and f0305_docto_mov_inventario = ''"
        otb_ItemsSinEntrada = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub Llenar_items_solicitados()
        dg_listado.Rows.Clear()
        csql = "with estructura_planta as (" _
                & " SELECT tb0100_estructura_mantenimiento.f0100_id_estructura as id," _
                    & " temp1.f0100_nombre as planta" _
                & " FROM camocontrol.tb0100_estructura_mantenimiento" _
                    & " left join camocontrol.tb0100_estructura_mantenimiento as temp1" _
                        & " on temp1.f0100_id_estructura = (string_to_array(tb0100_estructura_mantenimiento.f0100_path||tb0100_estructura_mantenimiento.f0100_id_estructura||'-','-'))[2]::int" _
                & " where tb0100_estructura_mantenimiento.f0100_id_cia = '00000001' and tb0100_estructura_mantenimiento.f0100_anulado = 'N'" _
                    & " and array_length(string_to_array(tb0100_estructura_mantenimiento.f0100_path,'-'), 1)>1" _
                & ")"
        csql += " select tb0305_items_solicitados.*, f0300_id_item, f0300_codigo_cguno," _
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
            & " f0305_id_accion," _
            & " coalesce(f0600_id_accion_principal,0) as acc_raiz," _
            & " coalesce(planta, otb_estructura_referida.f0100_nombre) as planta" _
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
            & " left join estructura_planta" _
                & " on id = f0305_id_estructura" _
            & " left join " & database.obtener_esquema & " .tb0600_acciones" _
                & " on f0305_id_accion = f0600_id_accion" _
            & " where f0305_id_factura_compras = '" & tx_id_factura.Text.ToString.Trim & "'"

        otb_items_programados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        ocosto = 0
        Dim subtotal As Decimal = 0
        Dim cumplerequisitos As String = "S"
        For Each orow As DataRow In otb_items_programados.Rows
            Agregar_fila_items(orow)
            ocosto += orow("f0305_costo_total_planificado")
            subtotal += orow("f0305_cantidad") * orow("f0305_costo_unitario_planificado")
            If orow("f0305_oc_aprov") = "N" Or orow("f0305_estado") <> "A" Then
                cumplerequisitos = "N"
            End If
        Next
        lb_valor_factura.Text = ocosto.ToString("C2")
        lb_valor_subtotal.Text = subtotal.ToString("C2")

        If cumplerequisitos = "N" Then
            lb_IncumpleRequisitos.Text = "No cumple con Aprobaciones de SC u OC"
        Else
            lb_IncumpleRequisitos.Text = "..."
        End If
    End Sub
    Private Sub Agregar_fila_items(ByVal orow As DataRow)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_id_solicitud_compra").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item("f0305_estado") = "A" Then
            ochkgrid.Value = -1
        Else
            ochkgrid.Value = 0
        End If
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_id_item_solicitud").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_id_oc").ToString
        }
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item("f0305_oc_aprov") = "S" Then
            ochkgrid.Value = -1
        Else
            ochkgrid.Value = 0
        End If
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna orden de compra siesa
        otextgrid = New DataGridViewTextBoxCell With {
            .Value = orow.Item("f0305_oc_uno").ToString
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
        otextgrid = New DataGridViewTextBoxCell
        If orow.Item("f0305_docto_mov_inventario").ToString = "" Then
            otextgrid.Value = "PENDIENTE!!!"
        Else
            otextgrid.Value = orow.Item("f0305_docto_mov_inventario").ToString
        End If
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
            .Value = orow.Item("acc_raiz").ToString
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
            .Value = orow.Item("planta").ToString
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
    Private Sub Validar_factura_Aprovada()
        If oaprovada = "S" Then
            vmensaje_requisitos = "Una factura aprovada no se puede modificar"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub Validar_proveedor()
        If tx_id_tercero.Text = "" Then
            vmensaje_requisitos = "Seleccione un proveedor"
            verror_requisitos = "S"
            Tx_Nombre_Tercero.Text = ""
            Tx_Nit.Text = ""
        End If
    End Sub
    Private Sub Validar_factura_cliente()
        If tx_factura_proveedor.Text.Trim = "" Then
            vmensaje_requisitos = "Registre el numero de factura del proveedor"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub Validar_fecha_factura()
        Dim factu As Date = comunes.g_fechahora
        If dtp_fecha_factura.Value > factu Then
            vmensaje_requisitos = "Fecha de factura mayor a fecha del sistema"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub Validaciones()
        Validar_proveedor()
        Validar_factura_Aprovada()
        Validar_factura_cliente()
        Validar_fecha_factura()
    End Sub

    Private Sub Grabar_nueva_factura()
        Dim id_creado As Integer
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0307_facturas_compras" _
                & " (f0307_id_cia, f0307_id_tercero, f0307_numero_factura, f0307_remision_proveedor, f0307_fecha_factura," _
                & " f0307_fecha_vencimiento_factura," _
                & " f0307_usuario_modificar, f0307_usuario_crear, f0307_fm)" _
                & " VALUES" _
                & " (@f0307_id_cia, @f0307_id_tercero, @f0307_numero_factura, @f0307_remision_proveedor, @f0307_fecha_factura," _
                & " @f0307_fecha_vencimiento_factura," _
                & " @f0307_usuario_modificar, @f0307_usuario_crear, @f0307_fm)" _
                & " RETURNING f0307_id_factura_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_facturas(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + vbCrLf + ex.ToString + vbCrLf + csql)
        End Try
        If verror = "N" Then
            Try
                id_creado = ocmd.ExecuteScalar()
            Catch ex As Exception
                If ex.ToString.Trim <> "" And InStr(ex.ToString.ToUpper, "23505".ToUpper) <> 0 Then
                    MsgBox("Esta factura ya ha sido registrada!")
                Else
                    MsgBox("Hubo un error al Grabar! ") ' + vbCrLf + ex.ToString)
                End If
                verror = "S"
            End Try
        End If
        If verror = "N" Then
            tx_id_factura.Text = id_creado   ' cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0307_id_factura_compras", "f0307_usuario_crear", vg_usuario_autoriza, "tb0307_facturas_compras")
            id_factura_compras = tx_id_factura.Text
            'tx_estado.Text = "Sin Aprobar Recepcion"
            vf_id_notas_archivos = tx_id_factura.Text
            vf_elemento_nuevo = "N"
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Crear_parametros_facturas(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0307_id_factura_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text.ToString
        End If
        ocmd.Parameters.Add("@f0307_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0307_id_tercero", NpgsqlDbType.Varchar).Value = tx_id_tercero.Text
        ocmd.Parameters.Add("@f0307_numero_factura", NpgsqlDbType.Varchar).Value = tx_factura_proveedor.Text
        ocmd.Parameters.Add("@f0307_remision_proveedor", NpgsqlDbType.Varchar).Value = tx_remision_proveedor.Text.ToString.Trim
        ocmd.Parameters.Add("@f0307_fecha_factura", NpgsqlDbType.Timestamp).Value = dtp_fecha_factura.Value
        ocmd.Parameters.Add("@f0307_fecha_vencimiento_factura", NpgsqlDbType.Timestamp).Value = dtp_vencimiento_factura.Value
        ocmd.Parameters.Add("@f0307_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0307_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0307_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub Actualizar_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0307_facturas_compras set "
        csql += "f0307_id_tercero = @f0307_id_tercero,"
        csql += "f0307_numero_factura = @f0307_numero_factura,"
        csql += "f0307_remision_proveedor = @f0307_remision_proveedor,"
        csql += "f0307_fecha_factura = @f0307_fecha_factura,"
        csql += "f0307_fecha_vencimiento_factura = @f0307_fecha_vencimiento_factura,"
        csql += "f0307_fm = @f0307_fm,"
        csql += "f0307_usuario_modificar = @f0307_usuario_modificar"
        csql += " where f0307_id_factura_compras = @f0307_id_factura_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_facturas(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        Validaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            Grabar_nueva_factura()
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-FCC-001", vg_id_cia)
            new_name_file += "-" & tx_id_factura.Text.PadLeft(8, "0")
        Else
            Actualizar_factura()
        End If
        If verror = "N" Then
            Activar_botones_aprobaciones()
            vf_id_notas_archivos = tx_id_factura.Text
            vf_elemento_nuevo = "N"
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
            MsgBox("Grabado")
        End If
    End Sub

    Private Sub Bt_aprobar_Click(sender As System.Object, e As System.EventArgs) Handles bt_aprobar.Click
        If tx_id_factura.Text.ToString = "" Or dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        verror_requisitos = "N"
        Validaciones()
        CargarItemsSinEntrada()
        If otb_ItemsSinEntrada.Rows.Count <> 0 Then
            MsgBox("Todos los items deben tener una entrada de almacen", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Dim respuestas As String = "N"
        respuestas = comunes.g_mensaje_YesNo("Aprobar Factura", "Desea Aprobar esta factura?")
        If respuestas = "N" Then
            Exit Sub
        End If
        Llenar_items_solicitados()
        Aprobar_factura()
        Aprobar_items_factura()
        If verror = "N" Then
            MsgBox("Factura aprobada", MsgBoxStyle.Information, "Aprobada")
            'inicializar_campos()
            Dispose()
        End If
    End Sub
    Private Sub Actualizar_costo_ultima_compra()
        Dim inventario As Decimal = 0
        For Each orow As DataGridViewRow In dg_listado.Rows
            inventario = cl_utilidades_gestion_compras.suministrar_inventario_item_compania(orow.Cells("dgocell_item").Value, vg_id_cia)
            Actualizar_ultimo_costo_db(orow.Cells("dgocell_item").Value,
                                       orow.Cells("dgocell_costo_unitario").Value,
                                       orow.Cells("dgocell_cantidad_solicitada").Value,
                                       dtp_fecha_factura.Value,
                                       tx_id_factura.Text,
                                       inventario)
            'MsgBox(orow.Cells("dgocell_item").Value & " -- " & orow.Cells("dgocell_costo_unitario").Value)
        Next

    End Sub
    Private Sub Actualizar_ultimo_costo_db(ByVal did_item As Integer, ByVal dcosto As Decimal,
                                           ByVal dcantidad As Decimal,
                                           ByVal dfecha As Date, ByVal did_factura As Integer,
                                           ByVal inv_total As Decimal)
        'MsgBox(did_item & " -- " & dcosto)
        'Calculamos el costo del inventario actual en toda la compañia, para usar cuando los inventarios funcionen bien
        'Dim inv_actual As Decimal = cl_utilidades_gestion_compras.suministrar_inventario_item_compania(did_item)
        'MsgBox(inv_actual)
        'MsgBox("inv: " & inv_total & " costo: " & dcosto)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0300_items set "
        'csql += "f0300_ultimo_costo = ((" & inv_actual & " * f0300_ultimo_costo)" _
        '& " + " & dcantidad * dcosto & ") / (" & dcantidad + inv_actual & "),"
        csql += "f0300_ultimo_costo = @f0300_ultimo_costo,"
        csql += "f0300_fecha_ultima_factura = @f0300_fecha_ultima_factura,"
        csql += "f0300_costo_promedio =" _
            & " case when f0300_costo_promedio <> 0 then " _
                        & " ((" & inv_total & " * f0300_costo_promedio) + " _
                        & (dcosto * dcantidad) & ") / " _
                        & "(" & dcantidad + inv_total & ") " _
                        & " else @f0300_ultimo_costo" _
                     & " end,"
        csql += "f0300_id_ultima_factura = @f0300_id_ultima_factura"
        csql += " where f0300_id_item = @f0300_id_item And"
        csql += " (f0300_fecha_ultima_factura <= @f0300_fecha_ultima_factura Or f0300_fecha_ultima_factura Is null)"
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_facturas(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0300_id_item", NpgsqlDbType.Integer).Value = did_item
        ocmd.Parameters.Add("@f0300_ultimo_costo", NpgsqlDbType.Numeric).Value = dcosto
        ocmd.Parameters.Add("@f0300_fecha_ultima_factura", NpgsqlDbType.Timestamp).Value = dfecha
        ocmd.Parameters.Add("@f0300_id_ultima_factura", NpgsqlDbType.Integer).Value = did_factura
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Aprobar_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0307_facturas_compras set "
        csql += "f0307_aprobada = @f0307_aprobada,"
        csql += "f0307_valor_factura = @f0307_valor_factura,"
        csql += "f0307_fecha_aprobacion = @f0307_fecha_aprobacion,"
        csql += "f0307_usuario_aprobar = @f0307_usuario_aprobar,"
        csql += "f0307_fm = @f0307_fm,"
        csql += "f0307_usuario_modificar = @f0307_usuario_modificar"
        csql += " where f0307_id_factura_compras = @f0307_id_factura_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_aprobar_facturas(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Crear_parametros_aprobar_facturas(ByVal ocmd As NpgsqlCommand)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0307_id_factura_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text.ToString
        End If
        ocmd.Parameters.Add("@f0307_aprobada", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0307_valor_factura", NpgsqlDbType.Numeric).Value = ocosto
        ocmd.Parameters.Add("@f0307_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = ofecha
        ocmd.Parameters.Add("@f0307_usuario_aprobar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0307_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0307_fm", NpgsqlDbType.Timestamp).Value = ofecha
    End Sub
    Private Sub Aprobar_items_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_factura_c_aprov = 'S'"
        csql += " where f0305_id_factura_compras = '" & tx_id_factura.Text.ToString & "' and f0305_anulado = 'N'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_facturas(ocmd)

        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
        End Try
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Registrar_documento_mov_inventario_items()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_docto_mov_inventario = '" & docto_mov_inv & "'"
        csql += " where f0305_id_factura_compras = '" & tx_id_factura.Text.ToString & "' and f0305_anulado = 'N'"
        csql += " and f0305_docto_mov_inventario = ''"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_facturas(ocmd)

        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
        End Try
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Aprobar_recepcion_factura(aprobada As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0307_facturas_compras set "
        csql += "f0307_recepcion_aprobada = '" & aprobada & "',"
        csql += "f0307_fecha_aprobacion_recepcion = @f0307_fecha_aprobacion_recepcion,"
        csql += "f0307_usuario_aprobar_recepcion = @f0307_usuario_aprobar_recepcion"
        csql += " where f0307_id_factura_compras = @f0307_id_factura_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_aprobar_recepcion_facturas(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Crear_parametros_aprobar_recepcion_facturas(ByVal ocmd As NpgsqlCommand)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0307_id_factura_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text.ToString
        End If
        ocmd.Parameters.Add("@f0307_fecha_aprobacion_recepcion", NpgsqlDbType.Timestamp).Value = ofecha
        ocmd.Parameters.Add("@f0307_usuario_aprobar_recepcion", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub
    Private Sub Bt_aprobar_recepcion_Click(sender As System.Object, e As System.EventArgs) Handles bt_aprobar_recepcion.Click
        If tx_id_factura.Text.ToString = "" Or dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        If dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        Cargar_elemento_existente()
        If oaprovada = "N" Then
            Actualizar_costo_ultima_compra()
            Generar_entrada_almacen()
        Else
            MsgBox("La recepcion ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
        End If
    End Sub
    Private Sub Generar_entrada_almacen()
        If tx_id_factura.Text = "" Then
            Exit Sub
        End If
        If cm_bodega.SelectedIndex = -1 Then
            Exit Sub
        End If
        CargarItemsSinEntrada()
        If otb_ItemsSinEntrada.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim nuevo_docto As Integer
        Dim registro_recien_creado As String = "N"
        'Identifico si hay creado un CNP
        Dim documento As String = Suministrar_documento_mov_invent_relacionado(13)
        'MsgBox(documento)

        'Pregunta si realmente desea reportar un consumo irregular
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Entrada de Almacen", "Desea registrar una entrada de almacen?")
        If respuesta = "N" Then
            Exit Sub
        End If

        Dim fecha_movimiento As DateTime = dtp_fecha.Value

        registro_recien_creado = "S"
        nuevo_docto = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(13, vg_id_cia)
        docto_mov_inv = "EAR-" & nuevo_docto.ToString.PadLeft(8, "0")
        'MsgBox(nuevo_docto)
        'Creo el nuevo documento de movimiento de inventarios
        'MsgBox("CPR-" & nuevo_docto.ToString.PadLeft(8, "0"))
        Dim ocreado As String = "N"
        ocreado = cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(docto_mov_inv,
                                                                                cm_bodega.SelectedValue,
                                                                                13,
                                                                                fecha_movimiento,
                                                                                vg_usuario_autoriza, vg_id_cia,
                                                                                "FCP-" & tx_id_factura.Text, tx_docto_contable.Text)
        'movimiento de entrada
        If ocreado = "N" Then
            Exit Sub
        End If
        Dim oconta As Integer = 1
        For Each orow As DataRow In otb_ItemsSinEntrada.Rows
            cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario(docto_mov_inv,
                                                                             cm_bodega.SelectedValue,
                                                                             oconta,
                                                                             orow.Item("f0305_id_item"),
                                                                             orow.Item("f0305_cantidad"),
                                                                             0, fecha_movimiento,
                                                                             vg_usuario_autoriza, vg_id_cia, 0, 1,, "FCP-" & tx_id_factura.Text,
                                                                             orow.Item("f0305_costo_unitario_planificado") / (1 - orow.Item("f0305_descuento")),
                                                                                     orow.Item("f0305_id_item_solicitud"),
                                                                                     orow.Item("f0305_id_solicitud_compra"))
            oconta += 1
        Next
        'Actualizo la bodega de consumo del reporte
        Actualizar_bodega_entrada(docto_mov_inv)
        'Aprobar_recepcion_factura("S")
        Registrar_documento_mov_inventario_items()
        'tx_estado.Text = "Recepcion Aprobada"
        'MsgBox("Recepcion de MP y/o Insumos aprobados", MsgBoxStyle.Information, "Aprobado")
        Activar_botones_aprobaciones()
        'bt_aprobar_recepcion.Enabled = False
        ' utiliso la variable registro_recien_creado para habilitar o no la modificacion del documento
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(docto_mov_inv,
                                                                                  vg_usuario_autoriza,
                                                                                  vg_id_cia,
                                                                                  "N", "S", "D", "S", "S", "S", "S", "S")
        Cargar_documentos_mov_inventario_relacionados()
        Llenar_items_solicitados()

    End Sub
    Private Sub Bt_aprobar_recepcion_sin_ea_Click(sender As Object, e As EventArgs) Handles bt_aprobar_recepcion_sin_ea.Click
        If tx_id_factura.Text = "" Then
            Exit Sub
        End If
        If dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        'Aprobar_recepcion_factura("S")
        tx_estado.Text = "Recepcion Aprobada"
        MsgBox("Recepcion de MP y/o Insumos aprobados", MsgBoxStyle.Information, "Aprobado")
        Activar_botones_aprobaciones()
        'bt_aprobar_recepcion.Enabled = False
        'bt_aprobar_recepcion_sin_ea.Enabled = False
    End Sub
    Private Sub Actualizar_bodega_entrada(ByVal doc_entrada As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0307_facturas_compras set "
        csql += "f0307_id_bodega_entrada = @f0307_id_bodega_entrada,"
        csql += "f0307_doc_entrada = @f0307_doc_entrada"
        csql += " where f0307_id_factura_compras = @f0307_id_factura_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0307_id_factura_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text
        ocmd.Parameters.Add("@f0307_id_bodega_entrada", NpgsqlDbType.Numeric).Value = cm_bodega.SelectedValue
        ocmd.Parameters.Add("@f0307_doc_entrada", NpgsqlDbType.Varchar).Value = docto_mov_inv
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
    Private Sub Cargar_documentos_mov_inventario_relacionados()
        csql = "select * from " & database.obtener_esquema & ".tb0309_items_movimientos" _
               & " join " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                 & " on f0309_id_documento = f0310_id_documento" _
            & " where f0309_id_cia = '" & vg_id_cia & "'" & " and" _
               & " f0310_id_documento_origen = 'FCP-" & tx_id_factura.Text & "'" _
               & " and f0309_anulado = 'N'"
        'Clipboard.SetDataObject(csql)
        'MsgBox(csql)
        otb_doc_mov_invent_relacionados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Identificar_label_doc_creados()
    End Sub
    Private Function Suministrar_documento_mov_invent_relacionado(ByVal tipo As Integer)
        Dim id_documento As String = ""
        Dim orow As DataRow()
        Cargar_documentos_mov_inventario_relacionados()
        orow = otb_doc_mov_invent_relacionados.Select("f0310_id_tipo_documento = '" & tipo & "'")
        For Each orow2 As DataRow In orow
            id_documento = orow2("f0310_id_documento")
        Next
        Return id_documento
    End Function
    Private Sub Identificar_label_doc_creados()
        lb_doc_entrada.Text = "ND"
        Dim exist As String = "N"
        For Each orow As DataRow In otb_doc_mov_invent_relacionados.Rows
            If orow("f0310_id_tipo_documento") = 13 Then
                lb_doc_entrada.Text = orow("f0310_id_documento")
                exist = "S"
            End If
        Next
        If exist = "N" Then
            'cm_bodegas.Enabled = True
        End If
    End Sub

    Private Sub Bt_add_item_Click(sender As System.Object, e As System.EventArgs) Handles bt_add_item.Click
        If tx_id_item_sc.Text.ToString.Trim = "" Then
            Exit Sub
        End If
        Cargar_elemento_existente()
        If oaprovada = "N" Then
            Adicionar_items_factura(tx_id_item_sc.Text)
        Else
            MsgBox("La recepcion ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
        End If
    End Sub
    Private Sub Adicionar_items_factura(ByVal id_item_sc As Integer)
        If tx_id_item_sc.Text.ToString.Trim = "" Then
            Exit Sub
        End If
        If tx_id_factura.Text.Trim = "" Then
            verror_requisitos = "N"
            Validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                Grabar_nueva_factura()
                If verror = "S" Then
                    Exit Sub
                End If
            End If
        End If
        Dim otb_info_item As DataTable
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_item_solicitud = '" & id_item_sc & "' and f0305_anulado = 'N'"
        otb_info_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        verror_requisitos = "N"
        Validar_factura_Aprovada()
        'Valida que exista el registro
        If otb_info_item.Rows.Count = 0 Then
            vmensaje_requisitos = "El Item no existe"
            verror_requisitos = "S"
        End If
        'Valida que no se halla utilizado antes
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_factura_compras")) = False Then
                vmensaje_requisitos = "El item ya fue facturado en el registro: " & orow("f0305_id_factura_compras")
                verror_requisitos = "S"
            End If
        Next
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Abro la informacion del item
        'abrir_form_info_item(tx_id_item_sc.Text.Trim)
        'Actualizo el item
        Actualizar_item_solicitado("S", id_item_sc)
        'Aprobar_recepcion_factura("N")
        If verror = "N" Then
            'MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
            tx_id_item_sc.Text = ""
            Llenar_items_solicitados()
            tx_id_item_sc.Focus()
            Activar_botones_aprobaciones()
        End If
    End Sub
    Private Sub Bt_eliminar_item_Click(sender As System.Object, e As System.EventArgs) Handles bt_eliminar_item.Click
        If tx_id_item_sc.Text.ToString.Trim = "" Then
            Exit Sub
        End If
        If tx_id_factura.Text.Trim = "" Then
            Exit Sub
        End If
        Cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La recepcion ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim otb_info_item As DataTable
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_item_solicitud = '" & tx_id_item_sc.Text.Trim & "'"
        otb_info_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        verror_requisitos = "N"
        Validar_factura_Aprovada()
        'Valida que exista el registro
        If otb_info_item.Rows.Count = 0 Then
            vmensaje_requisitos = "El Item no existe"
            verror_requisitos = "S"
        End If
        'Valida que no se halla utilizado antes en otra factura
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_factura_compras")) = False Then
                If orow("f0305_id_factura_compras").ToString <> tx_id_factura.Text Then
                    vmensaje_requisitos = "El item no corresponde a esta factura"
                    verror_requisitos = "S"
                End If
            Else
                vmensaje_requisitos = "El item no corresponde a esta factura"
                verror_requisitos = "S"
            End If
        Next
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Actualizo el item
        Actualizar_item_solicitado("N", tx_id_item_sc.Text.Trim)
        If verror = "N" Then
            MsgBox("Borrado", MsgBoxStyle.Information, "Eliminar")
            tx_id_item_sc.Text = ""
            Llenar_items_solicitados()
        End If
    End Sub
    Private Sub Actualizar_item_solicitado(vincular As String, ByVal id_item_sc As Integer)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_id_factura_compras = @f0305_id_factura_compras,"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_modificar = @f0305_usuario_modificar"
        csql += " where f0305_id_item_solicitud = '" & id_item_sc & "'"
        'tx_id_item_sc.Text.Trim
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_facturas(ocmd)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vincular = "S" Then
            ocmd.Parameters.Add("@f0305_id_factura_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text.ToString
        Else
            ocmd.Parameters.Add("@f0305_id_factura_compras", NpgsqlDbType.Integer).Value = DBNull.Value
        End If

        ocmd.Parameters.Add("@f0305_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_fm", NpgsqlDbType.Timestamp).Value = ofecha
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub Abrir_info_solicitud_compra(ByVal id_sc As String, ByVal elemento_nuevo As String)
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_agregar_solicitud As New camocontrol.fm_0300_sc_solicitud With {
            .vf_oform_padre = Me,
            .vg_id_cia = vg_id_cia
        }
        oform_agregar_solicitud.bt_generar_recepcion.Enabled = False
        If elemento_nuevo = "N" Then
            oform_agregar_solicitud.id_solicitud_compra = tx_sol_compra.Text
        End If
        oform_agregar_solicitud.vg_usuario_autoriza = vg_usuario_autoriza
        oform_agregar_solicitud.vf_elemento_nuevo = elemento_nuevo
        oform_agregar_solicitud.ShowDialog()
        If elemento_nuevo = "S" Then
            tx_sol_compra.Text = id_sc_creada
        End If
    End Sub
    Private Sub Abrir_form_info_item(oid_item_sc As Integer)
        'id_item_accion = dg_listado.CurrentCell.Value
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        'oform_agregar_recurso.id_solicitud_compra = id_solicitud_compra
        'oform_agregar_recurso.id_estructura = id_estructura
        'oform_agregar_recurso.id_accion = id_accion
        Dim oform_agregar_recurso As New camocontrol.fm_0300_sc_items With {
            .vf_oform_padre = Me,
            .vg_usuario_autoriza = vg_usuario_autoriza,
            .vg_id_cia = vg_id_cia,
            .id_item_solicitud = oid_item_sc,
            .vf_elemento_nuevo = "N"
        }
        oform_agregar_recurso.ShowDialog()
        Llenar_items_solicitados()
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

    Private Sub Bt_gestionar_tercero_Click(sender As System.Object, e As System.EventArgs) Handles bt_gestionar_tercero.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_terceros As New camocontrol.fm_0200_tercero With {
            .vf_oform_padre = Me,
            .vg_usuario_autoriza = vg_usuario_autoriza,
            .vg_id_cia = vg_id_cia
        }
        'oform_catalogo_terceros.vf_elemento_nuevo = "N"
        oform_catalogo_terceros.ShowDialog()
    End Sub

    Private Sub Bt_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo.Click
        Inicializar_campos()
    End Sub
    Private Sub Bt_solicitud_compra_Click(sender As System.Object, e As System.EventArgs) Handles bt_solicitud_compra.Click
        If tx_sol_compra.Text.Trim = "" Then
            Abrir_info_solicitud_compra(tx_sol_compra.Text, "S")
            If tx_sol_compra.Text.Trim <> "" Then
                Cargar_todos_items_de_una_sc()
            End If
            Exit Sub
        End If
        Dim otb_sc As DataTable
        csql = "select f0304_id_solicitud from " & database.obtener_esquema & ".tb0304_solicitud_compra" _
            & " where f0304_id_cia = '" & vg_id_cia & "'" & " and" _
               & " f0304_id_solicitud = '" & tx_sol_compra.Text & "'" _
               & " and f0304_anulado = 'N'"
        'Clipboard.SetDataObject(csql)
        'MsgBox(csql)
        otb_sc = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_sc.Rows.Count > 0 Then
            Abrir_info_solicitud_compra(tx_sol_compra.Text, "N")
        Else
            tx_sol_compra.Text = ""
            MsgBox("La Solicitud de Compra no existe.", MsgBoxStyle.Information, "Error")
        End If
    End Sub
    Private Sub Bt_nueva_sc_Click(sender As Object, e As EventArgs) Handles bt_nueva_sc.Click
        Abrir_info_solicitud_compra(tx_sol_compra.Text, "S")
    End Sub

    Private Sub Bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        If vf_elemento_nuevo = "S" Then
            Exit Sub
        End If
        Dim respuestas As String = "N"
        respuestas = comunes.g_mensaje_YesNo("Anular Factura", "Desea anular esta factura?")
        If respuestas = "N" Then
            Exit Sub
        End If
        verror = "N"
        Liberar_item_solicitud()
        If verror = "N" Then
            Anular_factura()
        End If
        If verror = "N" Then
            MsgBox("Factura Anulada", MsgBoxStyle.Information)
            Dispose()
        Else
            MsgBox("Error anulando", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Anular_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0307_facturas_compras set "
        csql += "f0307_numero_factura = @f0307_numero_factura,"
        csql += "f0307_recepcion_aprobada = 'N',"
        csql += "f0307_aprobada = 'N',"
        csql += "f0307_fecha_aprobacion = null,"
        csql += "f0307_fecha_aprobacion_recepcion = null,"
        csql += "f0307_usuario_aprobar_recepcion = '',"
        csql += "f0307_usuario_modificar = @f0307_usuario_modificar,"
        csql += "f0307_fm = @f0307_fm,"
        csql += "f0307_anulado = 'S',"
        csql += "f0307_usuario_anular = @f0307_usuario_modificar"
        csql += " where f0307_id_factura_compras = @f0307_id_factura_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_recepcion_facturas(ocmd)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0307_numero_factura", NpgsqlDbType.Varchar).Value = "ANU" & tx_id_factura.Text.ToString
        ocmd.Parameters.Add("@f0307_id_factura_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text.ToString
        ocmd.Parameters.Add("@f0307_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0307_fm", NpgsqlDbType.Timestamp).Value = ofecha
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
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

    Private Sub Liberar_item_solicitud()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_id_factura_compras = null,"
        csql += "f0305_factura_c_aprov = 'N',"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_modificar = @f0305_usuario_modificar"
        csql += " where f0305_id_factura_compras = @f0305_id_factura_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_facturas(ocmd)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0305_id_factura_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text.ToString
        ocmd.Parameters.Add("@f0305_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_fm", NpgsqlDbType.Timestamp).Value = ofecha
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
                MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub Bt_historico_compras_Click(sender As Object, e As EventArgs) Handles bt_historico_compras.Click
        If tx_id_item_cons_mov.Text = "" Then
            MsgBox("Seleccione un item para consultar", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_compras.movimientos_compras_item(tx_id_item_cons_mov.Text, vg_usuario_autoriza, vg_id_cia)
    End Sub

    Private Sub Bt_docto_inv_Click(sender As Object, e As EventArgs) Handles bt_docto_inv.Click
        'Verifico que el documento exista
        Dim otb_docto As DataTable
        Dim csql As String = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                             & " where f0310_id_documento = '" & lb_doc_entrada.Text & "'"
        otb_docto = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_docto.Rows.Count = 0 Then
            MsgBox("El documento no existe", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(lb_doc_entrada.Text,
                                                                              vg_usuario_autoriza,
                                                                              vg_id_cia,
                                                                              "N", "S", "D")
    End Sub

    Private Sub Bt_cargar_items_sc_Click(sender As Object, e As EventArgs) Handles bt_cargar_items_sc.Click
        Cargar_todos_items_de_una_sc()
    End Sub
    Private Sub Cargar_todos_items_de_una_sc()
        Cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La recepcion ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If tx_sol_compra.Text.Trim = "" Then
            Exit Sub
        End If

        'creo una nueva factura si no existe
        If tx_id_factura.Text.Trim = "" Then
            verror_requisitos = "N"
            Validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                Grabar_nueva_factura()
                If verror = "S" Then
                    Exit Sub
                End If
            End If
        End If
        Dim otb_info_item As DataTable
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_solicitud_compra = '" & tx_sol_compra.Text.Trim & "' and f0305_anulado = 'N'"
        otb_info_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        verror_requisitos = "N"
        Validar_factura_Aprovada()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'Valida que no se halla utilizado antes
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_factura_compras")) = True Then
                'Actualizo el item
                'MsgBox(orow("f0305_id_item_solicitud"))
                Actualizar_item_solicitado("S", orow("f0305_id_item_solicitud"))
            End If
        Next

        If verror = "N" Then
            MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
            tx_id_item_sc.Text = ""
            Llenar_items_solicitados()
            tx_id_item_sc.Focus()
            Activar_botones_aprobaciones()
        End If
    End Sub
    Private Sub Cargar_todos_items_de_una_oc()
        Cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La recepcion ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If tx_id_oc.Text.Trim = "" Then
            Exit Sub
        End If

        'creo una nueva factura si no existe
        If tx_id_factura.Text.Trim = "" Then
            verror_requisitos = "N"
            Validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                Grabar_nueva_factura()
                If verror = "S" Then
                    Exit Sub
                End If
            End If
        End If
        Dim otb_info_item As DataTable
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_oc = '" & tx_id_oc.Text.Trim & "' and f0305_anulado = 'N'"
        otb_info_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        verror_requisitos = "N"
        Validar_factura_Aprovada()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'Valida que no se halla utilizado antes
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_factura_compras")) = True Then
                'Actualizo el item
                'MsgBox(orow("f0305_id_item_solicitud"))
                Actualizar_item_solicitado("S", orow("f0305_id_item_solicitud"))
            End If
        Next

        If verror = "N" Then
            'MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
            tx_id_item_sc.Text = ""
            Llenar_items_solicitados()
            tx_id_item_sc.Focus()
            Activar_botones_aprobaciones()
        End If
    End Sub
    Private Sub Bt_actualizar_grilla_Click(sender As Object, e As EventArgs) Handles bt_actualizar_grilla.Click
        Llenar_items_solicitados()
    End Sub

    Private Sub Bt_listado_items_pend_Click(sender As Object, e As EventArgs) Handles bt_listado_items_pend.Click
        Cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La recepcion ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'creo una nueva factura si no existe
        If tx_id_factura.Text.Trim = "" Then
            verror_requisitos = "N"
            Validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                Grabar_nueva_factura()
                If verror = "S" Then
                    Exit Sub
                End If
            End If
        End If

        Dim otb_items_selected As DataTable = Nothing
        Dim otb_tablas_array() As DataTable = Nothing
        'arreglo de tablas (1)= tabla total de datos mostrados, (2) tabla datos seleccionados
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            otb_tablas_array = cl_utilidades_datatables.visualizar_datos_visor("ST-0300-44", vg_id_cia, vg_usuario_autoriza,
                                                            "Items Solicitados para Comprar Sin Recibir",
                                                            {vg_id_cia, rango_fechas(1), rango_fechas(2)},
                                                            , "Items Solicitados",,, "S", "id_sc_item",, "S")

            If IsNothing(otb_tablas_array(2)) = False Then
                otb_items_selected = otb_tablas_array(2)
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        'cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La FC ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'agrego a la OC los items seleccionados
        For Each orow As DataRow In otb_items_selected.Rows
            'Actualizo el item
            'MsgBox(orow("id_sc_item"))
            tx_id_item_sc.Text = orow("id_sc_item")
            Adicionar_items_factura(orow("id_sc_item"))
        Next
        tx_id_item_sc.Text = ""
        Llenar_items_solicitados()
        tx_id_item_sc.Focus()
        Activar_botones_aprobaciones()
        MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
    End Sub

    Private Sub Tx_sol_compra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_sol_compra.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            'e.Handled = False
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Cargar_todos_items_de_una_sc()
        End If
    End Sub

    Private Sub Tx_id_item_sc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_id_item_sc.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            'e.Handled = False
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Cargar_elemento_existente()
            If oaprovada = "N" Then
                Adicionar_items_factura(tx_id_item_sc.Text)
            Else
                MsgBox("La recepcion ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub Tx_id_oc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_id_oc.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            'e.Handled = False
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Cargar_todos_items_de_una_oc()
        End If
    End Sub

    Private Sub Bt_listado_oc_Click(sender As Object, e As EventArgs) Handles bt_listado_oc.Click
        Cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La recepcion ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'MsgBox("aqui")
        'creo una nueva factura si no existe
        If tx_id_factura.Text.Trim = "" Then
            verror_requisitos = "N"
            Validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                Grabar_nueva_factura()
                If verror = "S" Then
                    Exit Sub
                End If
            End If
        End If

        Dim otb_items_selected As DataTable = Nothing
        Dim otb_tablas_array() As DataTable = Nothing
        'arreglo de tablas (1)= tabla total de datos mostrados, (2) tabla datos seleccionados
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            otb_tablas_array = cl_utilidades_datatables.visualizar_datos_visor("ST-0300-41", vg_id_cia, vg_usuario_autoriza,
                                                            "Listado Ordenes de Compra",
                                                            {vg_id_cia, rango_fechas(1), rango_fechas(2)},
                                                            , "Ordenes de Compra",,, "S", "id_oc",, "S")

            If IsNothing(otb_tablas_array(2)) = False Then
                otb_items_selected = otb_tablas_array(2)
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        'cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La FC ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'agrego a la OC los items seleccionados
        For Each orow As DataRow In otb_items_selected.Rows
            'Actualizo el item
            'MsgBox(orow("id_sc_item"))
            tx_id_oc.Text = orow("id_oc")
            Cargar_todos_items_de_una_oc()
        Next
        tx_id_oc.Text = ""
        Llenar_items_solicitados()
        tx_id_item_sc.Focus()
        Activar_botones_aprobaciones()
        MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
    End Sub

End Class
