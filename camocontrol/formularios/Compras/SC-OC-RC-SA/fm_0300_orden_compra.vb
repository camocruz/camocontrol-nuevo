Imports System.ComponentModel
Imports App.ApiClient.CS.Services
Imports App.ApiClient.CS.Services.SpecificServices
Imports App.ApiClient.CS.Helpers.Commons
Imports App.ApiClient.CS.Utilities
Imports App.ApiClient.CS.DTOs.SpecificDtos

Public Class fm_0300_orden_compra
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_orden_compra As Integer 'se asigna cuando se llama al formulario desde el fm_padre
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

    Private otb_items_servicios_camo As DataTable
    Private otb_proveedores As DataTable
    Private otb_solicitudes As DataTable
    Private otb_items_programados As DataTable
    Private otb_info_personal As DataTable
    Private otb_info_oc As DataTable
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
    Private oanulada As String = "N"

    Private Sub fm_0300_orden_compra_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-OCM"
        vf_var_config_notas = "TN-OCM-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)

        'formatear_grilla()
        ' Set the Format type and the CustomFormat string.
        dtp_fecha.Format = DateTimePickerFormat.Custom
        dtp_fecha.CustomFormat = "yyyy/MM/dd  HH:mm"

        tx_id_orden_compra.ReadOnly = True
        tx_estado.ReadOnly = True
        tx_id_item_cons_mov.ReadOnly = True
        'bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_generar_informe.Enabled = False
        bt_aprobar.Enabled = False
        bt_desaprobar_oc.Enabled = False
        cargar_otb_items_servicios_camo()
        'cargar_proveedores()
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0005_bodegas"
        Dim otb_bodega_consumos As DataTable
        otb_bodega_consumos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If vf_elemento_nuevo = "S" Then
            inicializar_campos()
        Else
            Tx_Nit.Enabled = False
            Tx_Nombre_Tercero.Enabled = False
            cargar_elemento_existente()
            llenar_items_solicitados()

            'identifico el tipo de nota
            vf_id_notas_archivos = tx_id_orden_compra.Text
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
            'activar_grabar()
            'new_name_file = comunes.suministrar_valor_variable_configuracion("CD-FCC-001", vg_id_cia)
            'new_name_file += "-" & tx_id_factura.Text.PadLeft(8, "0")
        End If
        formatear_grilla()
    End Sub

    Private Sub cargar_otb_items_servicios_camo()
        'Para calcular la cantidad de cajas a despachar debo traer la informacion de los
        'items del cg, e identificar el factor de empaque.
        csql = "select * from " & database.obtener_esquema & ".tb0300_items"
        csql += " where f0300_id_cia = '" & vg_id_cia & "' and f0300_id_tipo_item = 4"
        otb_items_servicios_camo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub formatear_grilla()
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
    Private Sub dg_listado_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_listado.CellClick
        If dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        tx_sol_compra.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc").Value
        tx_id_item_sc.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value
        tx_id_item_cons_mov.Text = dg_listado.CurrentRow.Cells("dgocell_item").Value
        Dim nombre_columna As String = dg_listado.Columns(dg_listado.CurrentCell.ColumnIndex).Name
        Select Case nombre_columna
            Case "dgocell_id_sc"

            Case "dgocell_id_sc_item"

        End Select
    End Sub
    Private Sub dg_listado_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_listado.CellDoubleClick
        If dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim nombre_columna As String = dg_listado.Columns(dg_listado.CurrentCell.ColumnIndex).Name
        Select Case nombre_columna
            Case "dgocell_item"
                Dim oform_item As New camocontrol.fm_0300_gestion_items
                oform_item.vf_oform_padre = Me
                oform_item.vg_id_cia = vg_id_cia
                oform_item.cerrar_al_actualizar = "S"
                oform_item.id_item = dg_listado.CurrentCell.Value
                oform_item.vg_usuario_autoriza = vg_usuario_autoriza
                oform_item.vf_elemento_nuevo = "N"
                oform_item.ShowDialog()
                llenar_items_solicitados()
            Case "dgocell_id_sc"
                'me esta generando un error incosntante, tengo que averiguar por que
                'Esta operación no se puede realizar cuando se está cambiando de tamaño una columna de relleno automático.
                'tx_sol_compra.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc").Value
                'abrir_info_solicitud_compra(tx_sol_compra.Text)
                'tx_sol_compra.Text = ""

                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_agregar_solicitud As New camocontrol.fm_0300_sc_solicitud
                oform_agregar_solicitud.vf_oform_padre = Me
                oform_agregar_solicitud.vg_id_cia = vg_id_cia
                oform_agregar_solicitud.id_solicitud_compra = dg_listado.CurrentCell.Value
                oform_agregar_solicitud.vg_usuario_autoriza = vg_usuario_autoriza
                oform_agregar_solicitud.vf_elemento_nuevo = "N"
                oform_agregar_solicitud.ShowDialog()

            Case "dgocell_id_sc_item"
                tx_id_item_sc.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value
                abrir_form_info_item(dg_listado.CurrentCell.Value)
                llenar_items_solicitados()
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
            Case "dgocell_id_fcc"
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_factura_compra As New camocontrol.fm_0300_facturas_compras
                oform_factura_compra.vf_oform_padre = Me
                oform_factura_compra.vg_id_cia = vg_id_cia
                'oform_factura_compra.vf_var_config_notas = "TN-FCP-001"
                'oform_factura_compra.vf_var_config_archivos = "CD-FCC"
                oform_factura_compra.vf_id_notas_archivos = dg_listado.CurrentCell.Value
                oform_factura_compra.id_factura_compras = dg_listado.CurrentCell.Value
                oform_factura_compra.vg_usuario_autoriza = vg_usuario_autoriza
                oform_factura_compra.vf_elemento_nuevo = "N"
                oform_factura_compra.Show() 'Para que no sea un formulario modal
        End Select
    End Sub
    Private Sub dg_listado_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_listado.CellContentDoubleClick
        If dg_listado.CurrentRow.Cells("dgocell_chk_item_aprobado").Value = -1 Then
            MsgBox("Un item aprobado no puede modificarse", MsgBoxStyle.Information, "Info")
        End If
    End Sub
    Private Sub dg_listado_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dg_listado.CellEnter
        If dg_listado.CurrentRow.Cells("dgocell_chk_item_aprobado").Value = -1 Then
            'MsgBox("bloqueado")
            dg_listado.CurrentRow.ReadOnly = True
        End If
    End Sub
    Private Sub dg_listado_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_listado.CellFormatting
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
    Private Sub dg_listado_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dg_listado.EditingControlShowing
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
    Private Sub dg_listado_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dg_listado.CellEndEdit
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
        buscar_info_item_solicitado(dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value)
        lb_valor_factura.Text = "Actualizar"
        lb_valor_subtotal.Text = "Actualizar"
        If verror_requisitos = "N" Then
            actualizar_item()
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
    Private Sub actualizar_item()
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
        crear_parametros_item(ocmd)
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
    Private Sub crear_parametros_item(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0305_id_item_solicitud", NpgsqlDbType.Integer).Value = CInt(dg_listado.CurrentRow.Cells("dgocell_id_sc_item").Value)
        ocmd.Parameters.Add("@f0305_cantidad", NpgsqlDbType.Numeric).Value = dg_listado.CurrentRow.Cells("dgocell_cantidad_solicitada").Value
        ocmd.Parameters.Add("@f0305_iva", NpgsqlDbType.Numeric).Value = dg_listado.CurrentRow.Cells("dgocell_iva").Value / 100
        ocmd.Parameters.Add("@f0305_descuento", NpgsqlDbType.Numeric).Value = dg_listado.CurrentRow.Cells("dgocell_descuento").Value / 100
        ocmd.Parameters.Add("@f0305_var_cost_prom", NpgsqlDbType.Numeric).Value = var_costo_promedio_actual
        ocmd.Parameters.Add("@f0305_costo_unitario_planificado", NpgsqlDbType.Numeric).Value = valores(1)
        ocmd.Parameters.Add("@f0305_costo_total_planificado", NpgsqlDbType.Numeric).Value = valores(4)
        ocmd.Parameters.Add("@f0305_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub buscar_info_item_solicitado(ByVal id_sc_item As Integer)
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
    Private Sub activar_botones_aprobaciones()
        If oanulada = "S" Then
            bt_aprobar.Enabled = False
            bt_add_item.Enabled = False
            bt_anular.Enabled = False
            bt_cargar_items_sc.Enabled = False
            bt_generar_informe.Enabled = False
            bt_listado_items_pend.Enabled = False
            bt_nueva_sc.Enabled = False
            bt_solicitud_compra.Enabled = False
            Exit Sub
        End If
        Select Case tx_estado.Text
            Case "Aprobada"
                bt_aprobar.Enabled = False
                cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_desaprobar_oc, "")
            Case "Sin Aprobar"
                cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_aprobar, "")
            Case Else
                bt_aprobar.Enabled = False
        End Select
    End Sub
    Private Sub inicializar_campos()

        tx_estado.Text = "Nuevo"
        'cm_proveedor.SelectedIndex = -1
        'cm_nit.SelectedIndex = -1
        'tx_id_orden_compra.Focus()
        tx_oc_uno.Text = ""
        tx_id_orden_compra.Text = ""
        tx_id_item_sc.Text = ""
        dg_listado.Rows.Clear()
        oaprovada = "N"
        vf_elemento_nuevo = "S"
        lb_valor_aprobado.Text = "$0.00"
        lb_valor_factura.Text = "$0.00"
        lb_valor_subtotal.Text = "$0.00"
        dtp_fecha.Value = comunes.g_fechahora
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
    Private Sub cargar_elemento_existente()
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0319_ordenes_compra" _
            & " where f0319_id_oc = '" & id_orden_compra & "'"
        otb_info_oc = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_oc.Rows
            tx_id_orden_compra.Text = orow("f0319_id_oc")
            vf_id_notas_archivos = orow("f0319_id_oc")
            vf_elemento_nuevo = "N"
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
            If orow("f0319_aprobada") = "S" Then
                tx_estado.Text = "Aprobada"
            Else
                tx_estado.Text = "Sin Aprobar"
            End If
            If IsDBNull(orow("f0319_fecha_aprobacion")) = False Then
                lb_fecha_aprob.Text = CDate(orow("f0319_fecha_aprobacion")).ToString("yyyy/MM/dd HH:mm:ss")
            End If
            If orow("f0319_anulado") = "S" Then
                tx_estado.Text = "Anulado"
                lb_titulo.Text = "Orden de Compra (ANULADA)"
                oanulada = "S"
            End If
            'cargo la informacion del tercero-
            id_tercero = orow("f0319_id_tercero")
            cargar_info_tercero()

            tx_oc_uno.Text = orow("f0319_oc_uno").ToString
            Dim val_fact As Decimal = orow("f0319_valor_factura")
            lb_valor_aprobado.Text = val_fact.ToString("C2")
            oaprovada = orow("f0319_aprobada")
            dtp_fecha.Value = orow("f0319_fr")
            activar_botones_aprobaciones()
        Next
    End Sub
    Private Async Sub cargar_info_tercero()
        csql = "select f0200_id_tercero, f0200_id as nit, f0200_id_sucursal_unoee," _
            & "trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2 || ' - ' || f0200_id) as razon_social" _
            & " FROM " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_ind_principal = 'S' and f0200_id_tercero = '" & id_tercero & "'"
        '& " and f0200_id_cia ='" & vg_id_cia & "'"
        otb_proveedores = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_proveedores.Rows
            tx_id_tercero.Text = orow("f0200_id_tercero")
            Tx_Nit.Text = orow("nit")
            Tx_Nombre_Tercero.Text = orow("razon_social")

            'Busco informacion adicional del tercero en Siesa
            Dim baseService = App.ApiClient.CS.AppServices.SiesaFactory.CreateBaseService()
            Dim servicio = New ProveedoresApiService(baseService)
            Dim filtro As String = "f200_id_cia = 1 and f200_id like " & orow("nit")
            Dim items = Await servicio.ObtenerAsync(9174, filtro)  'f200_id_cia = 1 and f200_id like 890903790
            Dim dt As DataTable = items.ToDataTable()
            If dt.Rows.Count = 0 Then
                Tx_SucursalUnoEE.Text = "ND"
                Exit Sub
            End If
            Tx_SucursalUnoEE.Text = dt.Rows(0).Item("f202_id_sucursal").ToString()
            If orow("f0200_id_sucursal_unoee").ToString() <> dt.Rows(0).Item("f202_id_sucursal").ToString() Then
                actualizar_sucursal_tercero(orow("f0200_id_tercero").ToString(), dt.Rows(0).Item("f202_id_sucursal").ToString())
            End If
        Next

    End Sub
    Private Sub actualizar_sucursal_tercero(ByVal id_tercero As String, ByVal sucursalEE As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0200_terceros set "
        csql += "f0200_id_sucursal_unoee = '" & sucursalEE & "'"
        csql += " where f0200_id_tercero = '" & id_tercero & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item(ocmd)
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
            filtro = "razon_social Like '%" & Tx_Nombre_Tercero.Text.Trim & "%'"
        End If
        If Tx_Nit.Text <> "" And tipofiltro = 2 Then
            filtro = "nit LIKE '%" & Tx_Nit.Text.Trim & "%'"
        End If

        Tx_Nombre_Tercero.Text = ""
        Tx_Nit.Text = ""

        Dim id_ter As String = comunes.Buscador_Terceros("ST-0210-01", vg_id_cia, vg_usuario_autoriza, filtro)
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
    Private Sub llenar_items_solicitados()
        dg_listado.Rows.Clear()
        csql = "select tb0305_items_solicitados.*, f0304_id_estado, f0300_id_item, f0300_codigo_cguno," _
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
            & " coalesce(f0600_id_accion_principal,0) as acc_raiz" _
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
            & " left join " & database.obtener_esquema & " .tb0600_acciones" _
                & " on f0305_id_accion = f0600_id_accion" _
            & " where f0305_id_oc = '" & tx_id_orden_compra.Text.ToString.Trim & "'"
        otb_items_programados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        ocosto = 0
        Dim cumplerequisitos As String = "S"
        Dim subtotal As Decimal = 0
        For Each orow As DataRow In otb_items_programados.Rows
            agregar_fila_items(orow)
            ocosto += orow("f0305_costo_total_planificado")
            subtotal += orow("f0305_cantidad") * orow("f0305_costo_unitario_planificado")
            If orow("f0305_estado") <> "A" Then
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
    Private Sub agregar_fila_items(ByVal orow As DataRow)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_id_solicitud_compra").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_id_item_solicitud").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0300_id_item").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0300_codigo_cguno").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("descripcion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("descripcion_comp").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_cantidad")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_inventario")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 8
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0002_sigla_unidad_medicion").ToString
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

        'Crea columna 8
        ochkgrid = New DataGridViewCheckBoxCell
        If IsDBNull(orow.Item("f0305_id_factura_compras")) = False Then
            ochkgrid.Value = -1
        Else
            ochkgrid.Value = 0
        End If
        orowgrid.Cells.Add(ochkgrid)

        'crea columna 9
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = Math.Round(orow.Item("f0305_var_cost_prom") * 100, 1)
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 9
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("costo_unitario") / (1 - orow.Item("f0305_descuento"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 11
        otextgrid = New DataGridViewTextBoxCell
        'Dim result As String = String.Format("{0:0.0%}", orow.Item("f0305_descuento"))
        otextgrid.Value = orow.Item("f0305_descuento") * 100 'result
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 10
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("costo_subtotal")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 12
        otextgrid = New DataGridViewTextBoxCell
        'Dim result2 As String = String.Format("{0:0.0%}", orow.Item("f0305_iva"))
        otextgrid.Value = orow.Item("f0305_iva") * 100 'result2
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 10
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("costo_unit_iva")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 13
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("costo_total")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 14
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("descripcion_codigo").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 14
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_id_accion").ToString
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
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_anotacion_item").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 15
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_id_factura_compras").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 16
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_docto_mov_inventario").ToString
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
    Private Sub validar_oc_aprovada()
        If oaprovada = "S" Then
            vmensaje_requisitos = "Una OC aprovada no se puede modificar"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_proveedor()
        If tx_id_tercero.Text = "" Then
            vmensaje_requisitos = "Seleccione un proveedor"
            verror_requisitos = "S"
            Tx_Nombre_Tercero.Text = ""
            Tx_Nit.Text = ""
        End If
    End Sub
    Private Sub validaciones()
        validar_proveedor()
    End Sub

    Private Sub grabar_nueva_oc()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0319_ordenes_compra" _
                & " (f0319_id_cia, f0319_id_tercero," _
                & " f0319_usuario_modificar, f0319_usuario_crear, f0319_fm)" _
                & " VALUES" _
                & " (@f0319_id_cia, @f0319_id_tercero," _
                & " @f0319_usuario_modificar, @f0319_usuario_crear, @f0319_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_oc(ocmd)

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
                ocmd.ExecuteNonQuery()
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
            tx_id_orden_compra.Text = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0319_id_oc", "f0319_usuario_crear", vg_usuario_autoriza, "tb0319_ordenes_compra")
            id_orden_compra = tx_id_orden_compra.Text
            tx_estado.Text = "Sin Aprobar"
            vf_id_notas_archivos = tx_id_orden_compra.Text
            vf_elemento_nuevo = "N"
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_oc(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0319_id_oc", NpgsqlDbType.Integer).Value = CInt(tx_id_orden_compra.Text.ToString)
        End If
        ocmd.Parameters.Add("@f0319_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0319_id_tercero", NpgsqlDbType.Varchar).Value = tx_id_tercero.Text
        ocmd.Parameters.Add("@f0319_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub actualizar_oc()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0319_ordenes_compra set "
        csql += "f0319_id_tercero = @f0319_id_tercero,"
        csql += "f0319_fm = @f0319_fm,"
        csql += "f0319_usuario_modificar = @f0319_usuario_modificar"
        csql += " where f0319_id_factura_compras = @f0319_id_factura_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_oc(ocmd)
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
    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            grabar_nueva_oc()
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-FCC-001", vg_id_cia)
            new_name_file += "-" & tx_id_orden_compra.Text.PadLeft(8, "0")
        Else
            actualizar_oc()
        End If
        If verror = "N" Then
            activar_botones_aprobaciones()
            vf_id_notas_archivos = tx_id_orden_compra.Text
            vf_elemento_nuevo = "N"
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
            MsgBox("Grabado")
        End If
    End Sub
    Private Sub bt_add_item_Click(sender As System.Object, e As System.EventArgs) Handles bt_add_item.Click
        cargar_un_item_solicitud_compra()
    End Sub
    Private Sub cargar_un_item_solicitud_compra()
        cargar_elemento_existente()
        'creo una nueva factura si no existe
        If tx_id_orden_compra.Text.Trim = "" Then
            verror_requisitos = "N"
            validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                grabar_nueva_oc()
                If verror = "S" Then
                    Exit Sub
                End If
            End If
        End If

        If oaprovada = "N" Then
            adicionar_items_factura(tx_id_item_sc.Text)
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            End If
        Else
            MsgBox("La OC ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
        End If
    End Sub
    Private Sub validaciones_para_adicionar_item(ByVal id_item_sc As Integer)
        verror_requisitos = "N"
        If id_item_sc.ToString = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El item es invalido"
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If tx_estado.Text = "Anulado" Then
            vmensaje_requisitos = "OC Anulada"
            verror_requisitos = "S"
        End If
        If tx_id_orden_compra.Text.Trim = "" Then
            validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                grabar_nueva_oc()
                If verror = "S" Then
                    verror_requisitos = "S"
                    Exit Sub
                End If
            End If
        End If
        Dim otb_info_item As DataTable
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_item_solicitud = '" & id_item_sc & "' and f0305_anulado = 'N'"
        otb_info_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        validar_oc_aprovada()

        'Valida que exista el registro
        If otb_info_item.Rows.Count = 0 Then
            vmensaje_requisitos = "El Item no existe"
            verror_requisitos = "S"
        End If
        'Valida que no se halla utilizado antes y que la solicitud de compra este aprobada
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_factura_compras")) = False Then
                vmensaje_requisitos = "El item ya fue facturado en el registro: " & orow("f0305_id_factura_compras")
                verror_requisitos = "S"
            End If
            If IsDBNull(orow("f0305_id_oc")) = False Then
                vmensaje_requisitos = "El item ya tiene OC en el registro: " & orow("f0305_id_oc")
                verror_requisitos = "S"
            End If
            If orow("f0305_estado") = "P" Then
                vmensaje_requisitos = "La SC no esta aprobada."
                verror_requisitos = "S"
            End If
        Next
        If verror_requisitos = "S" Then
            'MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
    End Sub
    Private Sub adicionar_items_factura(ByVal id_item_sc As Integer)
        'realizo las validaciones necesarias para actualizar item
        verror_requisitos = "N"
        validaciones_para_adicionar_item(id_item_sc)
        'Abro la informacion del item
        'abrir_form_info_item(tx_id_item_sc.Text.Trim)
        'Actualizo el item
        If verror_requisitos = "N" Then
            actualizar_item_solicitado("S", id_item_sc)
        Else
            'MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
        End If
        If verror = "N" Then
            'MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
            tx_id_item_sc.Text = ""
            llenar_items_solicitados()
            tx_id_item_sc.Focus()
            activar_botones_aprobaciones()
        End If
    End Sub
    Private Sub bt_eliminar_item_Click(sender As System.Object, e As System.EventArgs) Handles bt_eliminar_item.Click
        If tx_id_item_sc.Text.ToString.Trim = "" Then
            Exit Sub
        End If
        If tx_id_orden_compra.Text.Trim = "" Then
            Exit Sub
        End If
        cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La OC ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim otb_info_item As DataTable
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_oc = '" & tx_id_orden_compra.Text.Trim & "'"
        otb_info_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        verror_requisitos = "N"
        validar_oc_aprovada()
        'Valida que exista el registro
        If otb_info_item.Rows.Count = 0 Then
            vmensaje_requisitos = "El Item no existe"
            verror_requisitos = "S"
        End If
        'Valida que no se halla utilizado antes en otra factura
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_oc")) = False Then
                If orow("f0305_id_oc").ToString <> tx_id_orden_compra.Text Then
                    vmensaje_requisitos = "El item no corresponde a esta OC"
                    verror_requisitos = "S"
                End If
            End If
        Next
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Actualizo el item
        actualizar_item_solicitado("N", tx_id_item_sc.Text.Trim)
        If verror = "N" Then
            MsgBox("Borrado", MsgBoxStyle.Information, "Eliminar")
            tx_id_item_sc.Text = ""
            llenar_items_solicitados()
        End If
    End Sub
    Private Sub actualizar_item_solicitado(vincular As String, ByVal id_item_sc As Integer)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_id_oc = @f0305_id_oc,"
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
            ocmd.Parameters.Add("@f0305_id_oc", NpgsqlDbType.Integer).Value = CInt(tx_id_orden_compra.Text.ToString)
        Else
            ocmd.Parameters.Add("@f0305_id_oc", NpgsqlDbType.Integer).Value = DBNull.Value
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

    Private Sub abrir_info_solicitud_compra(ByVal id_sc As String, ByVal elemento_nuevo As String)
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_agregar_solicitud As New camocontrol.fm_0300_sc_solicitud
        oform_agregar_solicitud.vf_oform_padre = Me
        oform_agregar_solicitud.vg_id_cia = vg_id_cia
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
    Private Sub abrir_form_info_item(oid_item_sc As Integer)
        'id_item_accion = dg_listado.CurrentCell.Value
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_agregar_recurso As New camocontrol.fm_0300_sc_items
        oform_agregar_recurso.vf_oform_padre = Me
        'oform_agregar_recurso.id_solicitud_compra = id_solicitud_compra
        oform_agregar_recurso.vg_usuario_autoriza = vg_usuario_autoriza
        oform_agregar_recurso.vg_id_cia = vg_id_cia
        'oform_agregar_recurso.id_estructura = id_estructura
        'oform_agregar_recurso.id_accion = id_accion
        oform_agregar_recurso.id_item_solicitud = oid_item_sc
        oform_agregar_recurso.vf_elemento_nuevo = "N"
        oform_agregar_recurso.ShowDialog()
        llenar_items_solicitados()
    End Sub

    Private Sub bt_catalago_items_Click(sender As System.Object, e As System.EventArgs) Handles bt_catalago_items.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0300_gestion_items
        oform_catalogo_items.vf_oform_padre = Me
        oform_catalogo_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_catalogo_items.vg_id_cia = vg_id_cia
        'oform_catalogo_items.vf_elemento_nuevo = "N"
        oform_catalogo_items.ShowDialog()
    End Sub

    Private Sub bt_gestionar_tercero_Click(sender As System.Object, e As System.EventArgs) Handles bt_gestionar_tercero.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_terceros As New camocontrol.fm_0200_tercero
        oform_catalogo_terceros.vf_oform_padre = Me
        oform_catalogo_terceros.vg_usuario_autoriza = vg_usuario_autoriza
        oform_catalogo_terceros.vg_id_cia = vg_id_cia
        'oform_catalogo_terceros.vf_elemento_nuevo = "N"
        oform_catalogo_terceros.ShowDialog()
        'cargar_proveedores()
    End Sub

    Private Sub bt_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo.Click
        inicializar_campos()
    End Sub
    Private Sub bt_solicitud_compra_Click(sender As System.Object, e As System.EventArgs) Handles bt_solicitud_compra.Click
        If tx_sol_compra.Text.Trim = "" Then
            Exit Sub
        End If
        abrir_info_solicitud_compra(tx_sol_compra.Text, "N")
        tx_sol_compra.Text = ""
    End Sub
    Private Sub bt_nueva_sc_Click(sender As Object, e As EventArgs) Handles bt_nueva_sc.Click
        'abrir_info_solicitud_compra(tx_sol_compra.Text, "S")
        MsgBox("Pendiente desarrollo")
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        If vf_elemento_nuevo = "S" Then
            Exit Sub
        End If
        If oanulada = "S" Then
            Exit Sub
        End If
        Dim respuestas As String = "N"
        respuestas = comunes.g_mensaje_YesNo("Anular Orden de Compra", "Desea anular esta OC?")
        If respuestas = "N" Then
            Exit Sub
        End If
        verror = "N"
        liberar_items_solicitud()
        If verror = "N" Then
            anular_oc()
        End If
        If verror = "N" Then
            MsgBox("Factura Anulada", MsgBoxStyle.Information)
            Dispose()
        Else
            MsgBox("Error anulando", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub anular_oc()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0319_ordenes_compra set "
        csql += "f0319_aprobada = 'N',"
        csql += "f0319_fecha_aprobacion = null,"
        csql += "f0319_usuario_aprobar = '',"
        csql += "f0319_usuario_modificar = @f0319_usuario_modificar,"
        csql += "f0319_fm = @f0319_fm,"
        csql += "f0319_anulado = 'S',"
        csql += "f0319_usuario_anular = @f0319_usuario_modificar"
        csql += " where f0319_id_oc = @f0319_id_oc"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_recepcion_facturas(ocmd)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0319_id_oc", NpgsqlDbType.Integer).Value = CInt(tx_id_orden_compra.Text.ToString)
        ocmd.Parameters.Add("@f0319_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_fm", NpgsqlDbType.Timestamp).Value = ofecha
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

    Private Sub liberar_items_solicitud()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_id_oc = null,"
        csql += "f0305_oc_uno = '',"
        csql += "f0305_oc_aprov = 'N',"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_modificar = @f0305_usuario_modificar"
        csql += " where f0305_id_oc = @f0305_id_oc"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_facturas(ocmd)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0305_id_oc", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(tx_id_orden_compra.Text)
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

    Private Sub bt_historico_compras_Click(sender As Object, e As EventArgs) Handles bt_historico_compras.Click
        If tx_id_item_cons_mov.Text = "" Then
            MsgBox("Seleccione un item para consultar", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_compras.movimientos_compras_item(tx_id_item_cons_mov.Text, vg_usuario_autoriza, vg_id_cia)
    End Sub

    Private Sub bt_cargar_items_sc_Click(sender As Object, e As EventArgs) Handles bt_cargar_items_sc.Click
        cargar_todos_items_solicitud_compra()
    End Sub
    Private Sub cargar_todos_items_solicitud_compra()
        cargar_elemento_existente()
        If oaprovada = "N" Then
            'adicionar_items_factura()
        Else
            MsgBox("La OC ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
        End If
        If tx_sol_compra.Text.Trim = "" Then
            Exit Sub
        End If

        'creo una nueva factura si no existe
        If tx_id_orden_compra.Text.Trim = "" Then
            verror_requisitos = "N"
            validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                grabar_nueva_oc()
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
        validar_oc_aprovada()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'Valida que no se halla utilizado antes
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_oc")) = True Then
                'Actualizo el item
                'MsgBox(orow("f0305_id_item_solicitud"))
                'actualizar_item_solicitado("S", orow("f0305_id_item_solicitud"))
                adicionar_items_factura(orow("f0305_id_item_solicitud"))
                If verror_requisitos = "S" Then
                    MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
                End If
            End If
        Next

        If verror = "N" Then
            MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
            tx_id_item_sc.Text = ""
            llenar_items_solicitados()
            tx_id_item_sc.Focus()
            activar_botones_aprobaciones()
        End If
    End Sub
    Private Sub bt_actualizar_grilla_Click(sender As Object, e As EventArgs) Handles bt_actualizar_grilla.Click
        llenar_items_solicitados()
    End Sub

    Private Sub bt_listado_items_pend_Click(sender As Object, e As EventArgs) Handles bt_listado_items_pend.Click
        cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La OC ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If


        'creo una nueva factura si no existe
        If tx_id_orden_compra.Text.Trim = "" Then
            verror_requisitos = "N"
            validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                grabar_nueva_oc()
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
            otb_tablas_array = cl_utilidades_datatables.visualizar_datos_visor("ST-0300-39", vg_id_cia, vg_usuario_autoriza,
                                                            "Items Solicitados para Comprar sin OC",
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

        cargar_elemento_existente()
        If oaprovada = "S" Then
            MsgBox("La OC ya esta aprovada, no puede modificarse.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'agrego a la OC los items seleccionados
        For Each orow As DataRow In otb_items_selected.Rows
            'realizo las validaciones necesarias para actualizar item
            validaciones_para_adicionar_item(orow("id_sc_item"))
            'Actualizo el item
            If verror_requisitos = "N" Then
                actualizar_item_solicitado("S", orow("id_sc_item"))
            End If
        Next
        tx_id_item_sc.Text = ""
        llenar_items_solicitados()
        tx_id_item_sc.Focus()
        activar_botones_aprobaciones()
        MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
    End Sub

    Private Sub bt_generar_informe_Click(sender As Object, e As EventArgs) Handles bt_generar_informe.Click
        If tx_id_orden_compra.Text.Trim = "" Then
            MsgBox("OC fallida", MsgBoxStyle.Information, "Seleccionar")
            Exit Sub
        End If
        cl_informes_comunes.informe_orden_compra(tx_id_orden_compra.Text, vg_id_cia)
    End Sub

    Private Sub bt_aprobar_Click(sender As Object, e As EventArgs) Handles bt_aprobar.Click
        If tx_id_orden_compra.Text.ToString = "" Or dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        verror_requisitos = "N"
        validaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        llenar_items_solicitados()
        aprobar_factura()
        aprobar_items_oc()
        'aprobar_items_factura()
        If verror = "N" Then
            MsgBox("OC aprobada", MsgBoxStyle.Information, "Aprobada")
            'inicializar_campos()
            'Dispose()
            cargar_elemento_existente()
        End If
    End Sub
    Private Sub aprobar_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0319_ordenes_compra set "
        csql += "f0319_aprobada = @f0319_aprobada,"
        csql += "f0319_valor_oc = @f0319_valor_oc,"
        csql += "f0319_fecha_aprobacion = @f0319_fecha_aprobacion,"
        csql += "f0319_usuario_aprobar = @f0319_usuario_aprobar,"
        csql += "f0319_fm = @f0319_fm,"
        csql += "f0319_usuario_modificar = @f0319_usuario_modificar"
        csql += " where f0319_id_oc = @f0319_id_oc"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_aprobar_facturas(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
        End Try
        If verror = "N" Then
            'ocmd.ExecuteNonQuery()
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
    Private Sub crear_parametros_aprobar_facturas(ByVal ocmd As NpgsqlCommand)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0319_id_oc", NpgsqlDbType.Integer).Value = CInt(tx_id_orden_compra.Text.ToString)
        End If
        ocmd.Parameters.Add("@f0319_aprobada", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0319_valor_oc", NpgsqlDbType.Numeric).Value = ocosto
        ocmd.Parameters.Add("@f0319_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = ofecha
        ocmd.Parameters.Add("@f0319_usuario_aprobar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_fm", NpgsqlDbType.Timestamp).Value = ofecha
    End Sub
    Private Sub aprobar_items_oc()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_oc_aprov = 'S'"
        csql += " where f0305_id_oc = '" & tx_id_orden_compra.Text.ToString & "' and f0305_anulado = 'N'"

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
    Private Sub desaprobar_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0319_ordenes_compra set "
        csql += "f0319_aprobada = @f0319_aprobada,"
        csql += "f0319_valor_oc = @f0319_valor_oc,"
        csql += "f0319_fecha_aprobacion = @f0319_fecha_aprobacion,"
        csql += "f0319_usuario_aprobar = @f0319_usuario_aprobar,"
        csql += "f0319_fm = @f0319_fm,"
        csql += "f0319_usuario_modificar = @f0319_usuario_modificar"
        csql += " where f0319_id_oc = @f0319_id_oc"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_desaprobar_facturas(ocmd)
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
    Private Sub crear_parametros_desaprobar_facturas(ByVal ocmd As NpgsqlCommand)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0319_id_oc", NpgsqlDbType.Integer).Value = CInt(tx_id_orden_compra.Text.ToString)
        End If
        ocmd.Parameters.Add("@f0319_aprobada", NpgsqlDbType.Varchar).Value = "N"
        ocmd.Parameters.Add("@f0319_valor_oc", NpgsqlDbType.Numeric).Value = ocosto
        ocmd.Parameters.Add("@f0319_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = DBNull.Value
        ocmd.Parameters.Add("@f0319_usuario_aprobar", NpgsqlDbType.Varchar).Value = ""
        ocmd.Parameters.Add("@f0319_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_fm", NpgsqlDbType.Timestamp).Value = ofecha
    End Sub
    Private Sub desaprobar_items_oc()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_oc_aprov = 'N'"
        csql += " where f0305_id_oc = '" & tx_id_orden_compra.Text.ToString & "' and f0305_anulado = 'N'"

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
    Private Sub bt_desaprobar_oc_Click(sender As Object, e As EventArgs) Handles bt_desaprobar_oc.Click
        If tx_id_orden_compra.Text.ToString = "" Or dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        If tx_estado.Text = "Sin Aprobar" Then
            Exit Sub
        End If
        verror_requisitos = "N"
        'validaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        llenar_items_solicitados()
        desaprobar_factura()
        desaprobar_items_oc()
        'aprobar_items_factura()
        If verror = "N" Then
            MsgBox("OC desaprobada", MsgBoxStyle.Information, "Aprobada")
            'inicializar_campos()
            Dispose()
        End If
    End Sub
    Private Sub tx_sol_compra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_sol_compra.KeyPress
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
            cargar_todos_items_solicitud_compra()
        End If
    End Sub

    Private Sub tx_id_item_sc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_id_item_sc.KeyPress
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
            cargar_un_item_solicitud_compra()
        End If
    End Sub

    Private Sub bt_gen_plano_oc_uno_Click(sender As Object, e As EventArgs) Handles bt_gen_plano_oc_uno.Click
        If tx_estado.Text <> "Aprobada" Then
            MsgBox("La OC debe estar aprobada", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Tx_SucursalUnoEE.Text.Trim() = "ND" Or Tx_SucursalUnoEE.Text.Trim() = "" Then
            MsgBox("La sucursal uno EE no está definida", MsgBoxStyle.Information)
            Exit Sub
        End If


        Dim dlg As New OpenFileDialog()

        dlg.Title = "Seleccione un archivo"
        dlg.Filter = "Todos los archivos (*.*)|*.*"
        'dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim txtPath As String

        If dlg.ShowDialog() = DialogResult.OK Then
            txtPath = dlg.FileName   ' ← Aquí obtienes el path completo
        Else
            MsgBox("No se seleccionó ninguna archivo.", MsgBoxStyle.Information)
            Exit Sub
        End If

        GenerarArchivoTexto(txtPath) '"\oc_siesa.txt"

        MessageBox.Show("Archivo generado correctamente.")

        MsgBox("Ejecute cargar archivo en SIESA", MsgBoxStyle.Information)
    End Sub
    Private Sub actualizar_oc_siesa_encabezado_oc()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0319_ordenes_compra Set "
        csql += "f0319_oc_uno = '" & tx_oc_uno.Text.ToString & "'"
        csql += " where f0319_id_oc = '" & tx_id_orden_compra.Text.ToString & "' and f0319_anulado = 'N'"

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
    Private Sub actualizar_oc_siesa_items()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_oc_uno = '" & tx_oc_uno.Text.ToString & "'"
        csql += " where f0305_id_oc = '" & tx_id_orden_compra.Text.ToString & "' and f0305_anulado = 'N'"

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

    Private Sub tx_oc_uno_KeyPress(sender As Object, e As KeyPressEventArgs)
        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        'End If
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
        '    e.Handled = False
        'End If
        'If e.KeyChar = "." Or e.KeyChar = "," Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub bt_actualizar_info_oc_siesa_Click(sender As Object, e As EventArgs) Handles bt_actualizar_info_oc_siesa.Click
        If tx_oc_uno.Text = "" Then
            Exit Sub
        End If
        If IsNumeric(tx_oc_uno.Text) = False Then
            MsgBox("Solo valores numericos", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'Dim t_doc As String = ""
        tx_oc_uno.Text = "EOC-" & tx_oc_uno.Text

        actualizar_oc_siesa_encabezado_oc()
        actualizar_oc_siesa_items()
        If verror = "N" Then
            MsgBox("Listo")
        End If

        'MsgBox("Actualizado", MsgBoxStyle.Information)
    End Sub


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
        Dim f420_id_tercero_prov As String = Tx_Nit.Text.Trim '"800034768"  ' NIT DEL PROVEEDOR
        Dim f420_id_sucursal_prov As String = Tx_SucursalUnoEE.Text.Trim() '"000" 'CODIGO DE LA SUCURSAL DEL PROVEEDOR
        Dim f420_notas As String = "" '"ESTA ES LA NOTA DEL DOCUMENTO" 'NOTA DEL DOCUMENTO
        Dim f420_num_docto_referencia As String = "RSC-" & tx_id_orden_compra.Text.Trim ' PARA REFERENCIAR EL RSC DEL CAMO

        'CONVIERTO LA MATRIZ EN UNA LISTA DE OBJETOS DTO PARA LINEA INICIO DOCUMENTO (DOCUMENTOS VERSION 03)
        MatSeccion = {
            {"F_NUMERO_REG", "Numérico", "1", "7", "0", "CONSECUTIVO"},
            {"F_TIPO_REG", "Numérico", "8", "4", "0", "420"},
            {"F_SUBTIPO_REG", "Numérico", "12", "2", "0", "00"},
            {"F_VERSION_REG", "Numérico", "14", "2", "0", "03"},
            {"F_CIA", "Numérico", "16", "3", "0", "1"},
            {"F_LIQUIDA_IMPUESTO", "Numérico", "19", "1", "0", "1"},
            {"F_CONSEC_AUTO_REG", "Numérico", "20", "1", "0", "1"},
            {"f420_id_co", "Alfanumérico", "21", "3", " ", "001"},
            {"f420_id_tipo_docto", "Alfanumérico", "24", "3", " ", "OS o  OC"},
            {"f420_consec_docto", "Numérico", "27", "8", "0", "1"},
            {"f420_fecha", "Alfanumérico", "35", "8", " ", "FECHA"},
            {"f420_id_concepto", "Numérico", "43", "3", "0", "401"},
            {"f420_id_grupo_clase_docto", "Numérico", "46", "3", "0", "402"},
            {"f420_id_clase_docto", "Numérico", "49", "3", "0", "404"},
            {"f420_ind_estado", "Numérico", "52", "1", "0", "1"},
            {"f420_ind_impresion", "Numérico", "53", "1", "0", "0"},
            {"f420_id_tercero_sol_comp", "Alfanumérico", "54", "15", " ", "CEDULA DEL COMPRADOR"},
            {"f420_id_tercero_prov", "Alfanumérico", "69", "15", " ", "NIT DEL TERCERO"},
            {"f420_id_sucursal_prov", "Alfanumérico", "84", "3", " ", "000"},
            {"f420_id_cond_pago", "Alfanumérico", "87", "3", " ", "30D"},
            {"f420_ind_tasa", "Numérico", "90", "1", "0", "1"},
            {"f420_id_moneda_docto", "Alfanumérico", "91", "3", " ", "COP"},
            {"f420_id_moneda_conv", "Alfanumérico", "94", "3", " ", "COP"},
            {"f420_tasa_conv", "Numérico", "97", "13", "0", "1"},
            {"f420_id_moneda_local", "Alfanumérico", "110", "3", " ", "COP"},
            {"f420_tasa_local", "Numérico", "113", "13", "0", "00000001.0000"},
            {"f420_tasa_dscto_global1", "Numérico", "126", "8", "0", "0"},
            {"f420_tasa_dscto_global2", "Numérico", "134", "8", "0", "0"},
            {"f420_notas", "Alfanumérico", "142", "255", " ", " "},
            {"F_IND_CONTACTO", "Numérico", "397", "1", "0", "0"},
            {"f419_contacto", "Alfanumérico", "398", "50", " ", " "},
            {"f419_direccion1", "Alfanumérico", "448", "40", " ", " "},
            {"f419_direccion2", "Alfanumérico", "488", "40", " ", " "},
            {"f419_direccion3", "Alfanumérico", "528", "40", " ", " "},
            {"f419_id_pais", "Alfanumérico", "568", "3", " ", " "},
            {"f419_id_depto", "Alfanumérico", "571", "2", " ", " "},
            {"f419_id_ciudad", "Alfanumérico", "573", "3", " ", " "},
            {"f419_id_barrio", "Alfanumérico", "576", "40", " ", " "},
            {"f419_telefono", "Alfanumérico", "616", "20", " ", " "},
            {"f419_fax", "Alfanumérico", "636", "20", " ", " "},
            {"f419_cod_postal", "Alfanumérico", "656", "10", " ", " "},
            {"f419_email", "Alfanumérico", "666", "50", " ", " "},
            {"f420_num_docto_referencia", "Alfanumérico", "716", "15", " ", "USAR OC DATO CAMO"},
            {"f420_id_mandato", "Alfanumérico", "731", "15", " ", " "}
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
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_CIA", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_LIQUIDA_IMPUESTO", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_CONSEC_AUTO_REG", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_co", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_tipo_docto", id_tipo_docto) 'Cambiar a OS cuando corresponda
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_consec_docto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_fecha", fechaActual)
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_concepto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_grupo_clase_docto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_clase_docto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_ind_estado", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_ind_impresion", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_tercero_sol_comp", f420_id_tercero_sol_comp) 'CEDULA DEL COMPRADOR
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_tercero_prov", f420_id_tercero_prov) 'NIT DEL TERCERO
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_sucursal_prov", f420_id_sucursal_prov) 'implementar consulta de api para obtener esta informacion
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_cond_pago", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_ind_tasa", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_moneda_docto", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_moneda_conv", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_tasa_conv", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_id_moneda_local", "COP") 'CAMBIE "" 00000000.0000
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_tasa_local", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_tasa_dscto_global1", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_tasa_dscto_global2", "")
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_notas", f420_notas) 'ESPACIO PARA NOTAS
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "F_IND_CONTACTO", "") 'LO METI PARA PROBAR
        lineaDinamica = svc.ReemplazarValores(ListaDtosSeccion, lineaDinamica, "f420_num_docto_referencia", f420_num_docto_referencia) 'USAR OC DATO CAMO
        lineas.Add(lineaDinamica)
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
        For Each row As DataGridViewRow In dg_listado.Rows
            f421_cant_pedida_base = DecimalFormatter.Format(CDbl(row.Cells("dgocell_cantidad_solicitada").Value.ToString), 4)
            f421_precio_unitario = DecimalFormatter.Format(CDbl(Math.Round(row.Cells("dgocell_costo_unitario").Value, 2).ToString), 4)
            f421_referencia_item = row.Cells("dgocell_cod_uno").Value.ToString


            ' Buscar items en el datatable de items servicios camo
            Dim t_item = (From c In otb_items_servicios_camo.AsEnumerable()
                          Where c.Field(Of Integer)("f0300_id_item") = row.Cells("dgocell_item").Value
                          Select c).FirstOrDefault()
            If t_item IsNot Nothing Then
                If t_item.Field(Of Integer)("f0300_id_tipo_item") <> 4 Then
                    f421_id_motivo = "01" '01 PARA PRODUCTOS Y 73 PARA SERVICIOS
                Else
                    f421_id_motivo = "73" '01 PARA PRODUCTOS Y 73 PARA SERVICIOS
                End If

            End If


            Dim notas As String = "RSC-" & tx_id_orden_compra.Text.Trim & "-" & row.Cells("dgocell_id_sc_item").Value.ToString.Trim & " " &
                row.Cells("dgocell_descripcion_complementaria").Value.ToString.Trim &
                                " " & row.Cells("dgocell_nota").Value.ToString.Trim

            ' Normalizar saltos de línea, recortar espacios y truncar a 255 caracteres
            notas = notas.Replace(vbCrLf, " ").Replace(vbLf, " ").Trim()
            If notas.Length > 255 Then
                notas = notas.Substring(0, 255)
            End If

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

    Private Async Sub btn_consultarOcUnoEE_Click(sender As Object, e As EventArgs) Handles btn_consultarOcUnoEE.Click

        Dim baseService = App.ApiClient.CS.AppServices.SiesaFactory.CreateBaseService()
        Dim servicio = New OrdenCompraApiService(baseService)

        Dim ordenes = Await servicio.ObtenerOrdenesCompraAsync(9174, "f420_rowid > 7")

        Dim dt As DataTable = ordenes.ToDataTable()

        cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Ordenes de Compra", {}, dt,,,,,,, "N")

    End Sub

    Private Async Sub btn_ItemsUnoEE_Click(sender As Object, e As EventArgs) Handles btn_ItemsUnoEE.Click
        Dim baseService = App.ApiClient.CS.AppServices.SiesaFactory.CreateBaseService()
        Dim servicio = New ItemsReferenciasApiService(baseService)

        Dim items = Await servicio.ObtenerAsync(9174, "")
        Dim dt As DataTable = items.ToDataTable()

        cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Items UnoEE", {}, dt,,,,,,, "N")

    End Sub
    Private Async Sub btn_proveedoresSiesa_Click(sender As Object, e As EventArgs) Handles btn_proveedoresSiesa.Click
        Dim baseService = App.ApiClient.CS.AppServices.SiesaFactory.CreateBaseService()
        Dim servicio = New ProveedoresApiService(baseService)

        Dim items = Await servicio.ObtenerAsync(9174, "")  'f200_id_cia = 1 and f200_id like 890903790
        Dim dt As DataTable = items.ToDataTable()

        cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Proveedores UnoEE", {}, dt,,,,,,, "N")

    End Sub
    Private Sub btn_listado_items_Click(sender As Object, e As EventArgs) Handles btn_listado_items.Click
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-34", vg_id_cia, vg_usuario_autoriza,
                                                        "Listado de Items",
                                                        {vg_id_cia},
                                                            , "Items",,, "S", "id_item",, "S", "N")
        llenar_items_solicitados()
    End Sub


End Class
