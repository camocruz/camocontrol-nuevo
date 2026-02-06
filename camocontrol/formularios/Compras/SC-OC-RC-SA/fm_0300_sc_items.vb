Public Class fm_0300_sc_items
    'OJO EN LA BASE DE DATOS CREE UN TRIGGER PARA ACTUALIZAR LA PLANTA QUE ORIGINA LA COMPRA,
    'FUE MAS RAPIDO HACERLO ASI, EVALUAR SI MEJOR ESTA INFORMACION SE LLENA DESDE ESTE FORMULARIO

    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_estructura As Integer = 0
    Public id_accion As Integer = 0
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_solicitud_compra As Integer 'se asigna cuando se llama al formulario desde el fm_padre
    Public id_item_solicitud As Integer 'registro del item solicitado en la tabla tb0305_items_solicitados

    Public cambiar_estructura As String = "N"

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

    Private otb_recursos As DataTable
    Private otb_items As DataTable
    Private otb_unidades As DataTable
    Private otb_item_programado As DataTable

    Private habilita_descripcion As String = "N"
    Private factura_c_aprov As String = "N"
    Private sc_aprobada As String = "N"
    Private id_unidad_medicion As String
    Private id_tipo_item As Integer
    Private cantidad As Decimal = 0 'cantidad requerida
    Private cantidad_inicial As Decimal = 0
    Private inventario As Integer = 0
    'Private cantidad_stock As Decimal = 0 'cantidad requerida
    Private costo_promedio_actual As Decimal = 0 'costo promedio actual del item
    Private var_costo_promedio_registro As Decimal = 0 'variacion del costo grabada en el registro
    Private var_costo_promedio_actual As Decimal = 0 'variacion del valor actual con respecto al costo promedio actual
    Private v_var_costo As String = "N" 'variable que identifica si se recalculo la variacion de costo
    Private costo_unitADescuento As Decimal = 0 'Costo unitario antes del descuento
    Private cost_unit_p As Decimal = 0 'costo unitario planificado
    Private cost_tot_p As Decimal = 0 'costo total planificado
    Private cost_tot_r As Decimal = 0 'costo total real
    Private cost_unit_r As Decimal = 0 'costo total real
    Private nueva_accion As Integer = 0 'para cuando creo acciones genericas desde la compra
    Private permitir_var_costo As String = "N"

    Private Sub Fm_0300_sc_items_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        csql = "select * from " & database.obtener_esquema & ".tb0002_unidades_medicion"
        otb_unidades = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = "SELECT *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_id_cia = '" & vg_id_cia & "' and f0300_anulado = 'N'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'With cm_descripcion
        '    'Valor que se muestra al usuario
        '    .DisplayMember = "descripcion_larga"
        '    'Valor interno que almacena el objeto
        '    .ValueMember = "f0300_id_item"
        '    'Origen de Datos del ComboBox
        '    .DataSource = otb_items
        '    .DropDownStyle = ComboBoxStyle.DropDown
        '    .AutoCompleteMode = AutoCompleteMode.Suggest
        '    .AutoCompleteSource = AutoCompleteSource.ListItems
        '    .SelectedIndex = -1
        'End With

        If id_accion <> 0 Then
            tx_id_accion.Text = id_accion
        End If

        Inicializar_campos()
        If vf_elemento_nuevo = "N" Then
            Cargar_informacion_item_programado()
        End If
        tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura)
    End Sub
    Private Sub Inicializar_campos()
        tx_id_accion.Enabled = False
        tx_id_item.Text = ""
        tx_id_item_sc.Enabled = False
        'cm_descripcion.SelectedIndex = -1
        tx_item_descripcion.Text = ""
        tx_id_registro.Enabled = False
        tx_id_registro.Text = ""
        tx_descripcion_manual.Text = ""
        tx_descripcion_manual.Enabled = False
        tx_impuesto.Text = "19"
        tx_descuento.Text = "0"
        cost_unit_r = 0
        tx_cantidad.Text = "0"
        chk_inventario.Checked = False
        tx_cost_unit_iva.Text = "0"
        tx_cost_total.Text = "0"
        tx_cost_total_iva.Text = "0"
        cost_tot_r = 0
        tx_cost_unit.Text = "0"
        'cm_descripcion.Focus()
        tx_id_item.Focus()
        'tx_id_fact_compras.Text = ""
        'tx_id_fact_compras.Enabled = False
        lb_oc.Text = "O.C: "
        lb_id_fcc.Text = "id_fcc: "
        lb_doc_inv.Text = "Doc-Inv: "
        tx_observacion.Text = ""
        lb_costo_promedio.Text = "0"
        lb_var_costo_prom.Text = "0"
    End Sub
    Private Sub Cargar_informacion_item_programado()
        csql = "select tb0305_items_solicitados.*, f0300_descripcion_item" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " left join " & database.obtener_esquema & ".tb0300_items" _
            & " on f0300_id_item = f0305_id_item" _
            & " where f0305_id_item_solicitud = '" & id_item_solicitud.ToString & "'"
        otb_item_programado = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_item_programado.Rows
            id_accion = orow("f0305_id_accion")
            tx_id_accion.Text = orow("f0305_id_accion")
            id_estructura = orow("f0305_id_estructura")
            factura_c_aprov = orow("f0305_factura_c_aprov")
            id_solicitud_compra = orow("f0305_id_solicitud_compra")
            tx_id_registro.Text = orow("f0305_id_item_solicitud")
            'cm_descripcion.SelectedValue = orow("f0305_id_item")
            tx_id_item.Text = orow("f0305_id_item")
            tx_item_descripcion.Text = orow("f0300_descripcion_item")
            tx_descripcion_manual.Text = orow("f0305_ampliacion_item")
            cost_tot_p = orow("f0305_costo_total_planificado")

            tx_cantidad.Text = orow("f0305_cantidad")
            inventario = orow("f0305_inventario")
            lb_inventario.Text = "Inventario Tot: " & Math.Round(orow("f0305_inventario"), 2)
            cantidad = orow("f0305_cantidad")
            cantidad_inicial = cantidad
            If orow("f0305_chkinventario") = "N" Then
                chk_inventario.Checked = False
            Else
                chk_inventario.Checked = True
            End If
            'cantidad_stock = orow("f0305_cantidad_stock")
            tx_impuesto.Text = orow("f0305_iva") * 100
            tx_descuento.Text = orow("f0305_descuento") * 100
            Dim ocosto As Decimal = 0
            'MsgBox(orow("f0305_costo_unitario_planificado") & " -- " & 1 - orow("f0305_descuento"))
            ocosto = orow("f0305_costo_unitario_planificado")
            tx_cost_unit_planificado.Text = ocosto.ToString("C2")

            ocosto = orow("f0305_costo_unitario_planificado")
            tx_cost_unit_planificado.Text = ocosto.ToString("C2") 'Costo menos el descuento, es el valor con el calculo costos de manto
            ocosto = orow("f0305_costo_unitario_planificado") / (1 - orow("f0305_descuento")) 'Costo antes del descuento - para referencia del usuario
            tx_cost_unit.Text = ocosto.ToString("C2")

            cost_unit_p = orow("f0305_costo_unitario_planificado")
            ocosto = orow("f0305_costo_total_planificado")
            tx_cost_total_iva.Text = ocosto.ToString("C2")
            ocosto = orow("f0305_costo_total_planificado") / orow("f0305_cantidad")
            tx_cost_unit_iva.Text = ocosto.ToString("C2")
            ocosto = orow("f0305_costo_unitario_planificado") * orow("f0305_cantidad")
            tx_cost_total.Text = ocosto.ToString("C2")
            dtp_fecha_requerido.Value = orow("f0305_fecha_requerido")
            tx_observacion.Text = orow("f0305_anotacion_item")
            'tx_id_fact_compras.Text = orow("f0305_id_factura_compras").ToString
            lb_oc.Text = "O.C: " & orow("f0305_id_oc").ToString
            lb_id_fcc.Text = "id_fcc: " & orow("f0305_id_factura_compras").ToString
            lb_doc_inv.Text = "Doc-Inv: " & orow("f0305_docto_mov_inventario").ToString
            var_costo_promedio_registro = orow("f0305_var_cost_prom")
            costo_promedio_actual = orow("f0305_costo_unitario_planificado") / (1 + orow("f0305_var_cost_prom"))
            lb_var_costo_prom.Text = "Variacion Costo: " & Math.Round(orow("f0305_var_cost_prom") * 100, 1) & "%"
            lb_costo_promedio.Text = "Costo Prom Actual: $" & Math.Round(costo_promedio_actual, 0)
            'bloquea cambios cuando es una solicitud aprobada
            If orow("f0305_estado") = "A" Then
                tx_id_item.ReadOnly = True
                'cm_descripcion.Enabled = False
                sc_aprobada = "S"
                'tx_cantidad.Enabled = False
            End If
        Next
    End Sub
    Private Sub Validar_item_aprobaciones()
        Dim otb_item As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_item_solicitud = '" & id_item_solicitud.ToString & "'"
        otb_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_item.Rows
            If orow("f0305_factura_c_aprov") = "S" And permitir_var_costo = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Este Item esta registrado en una factura Aprobada!"
            End If
            If orow("f0305_docto_mov_inventario") <> "" And permitir_var_costo = "N" Then
                'MsgBox("hola = " & permitir_var_costo)
                verror_requisitos = "S"
                vmensaje_requisitos = "Este Item esta registrado en una factura con Recepcion Aprobada!"
            End If
            If IsDBNull(orow("f0305_id_oc")) = False And permitir_var_costo = "N" Then
                'MsgBox("hola = " & permitir_var_costo)
                verror_requisitos = "S"
                vmensaje_requisitos = "Este Item esta registrado en una Orden de Compra y no puede modificarse!: OC-" _
                    & orow("f0305_id_oc")
            End If
            If orow("f0305_estado") <> "P" Then
                'verror_requisitos = "S"
                'vmensaje_requisitos = "Este Item esta registrado en una Solicitud Aprobada!"
            End If
        Next
    End Sub

    Private Sub Tx_id_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_id_item.Validating
        'If IsNumeric(tx_id_item.Text) = False Or tx_id_item.Text.Trim = "" Then
        If IsNumeric(tx_id_item.Text) = False And tx_id_item.Text.Trim <> "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        Cargar_informacion_item()
        'cm_descripcion.Focus()
        'cm_descripcion.SelectedValue = CInt(tx_id_item.Text)
    End Sub
    'Private Sub Cm_descripcion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If cm_descripcion.SelectedIndex = -1 Then
    '        If cm_descripcion.Text.ToString.Trim <> "" Then
    '            MsgBox("El Item no existe", MsgBoxStyle.Information, "Error")
    '        End If
    '        cm_descripcion.Text = ""
    '        tx_id_item.Text = ""
    '    Else
    '        tx_id_item.Text = CInt(cm_descripcion.SelectedValue)
    '        Cargar_informacion_item()
    '    End If
    'End Sub

    Private Sub Validar_item()
        If tx_id_item.Text.ToString = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Seleccione un Item."
        End If
    End Sub

    Private Sub Validar_cantidad()
        If CDec(tx_cantidad.Text) = 0 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "La Cantidad no puede ser 0."
        End If
    End Sub

    Private Sub Calcular_variacion_costo()
        'calculo la desviacion del valor respecto al costo promedio actual
        If costo_promedio_actual > 0 Then
            var_costo_promedio_actual = ((tx_cost_unit.Text - costo_promedio_actual) / costo_promedio_actual)
            lb_var_costo_prom.Text = "Variacion Costo: " & Math.Round(var_costo_promedio_actual * 100, 1) & "%"
            lb_costo_promedio.Text = "Costo Prom Actual: $" & Math.Round(costo_promedio_actual, 0)
        Else
            var_costo_promedio_actual = 0
            lb_var_costo_prom.Text = "0"
            lb_costo_promedio.Text = "0"
        End If
        If Math.Abs(var_costo_promedio_actual) > 999.999 Then
            var_costo_promedio_actual = 999.9999
        End If
        'MsgBox(var_costo_promedio_actual)
        v_var_costo = "S"
    End Sub
    Private Sub Validar_variacion_costo()
        Dim ovar_costo_aceptable As Decimal
        ovar_costo_aceptable = comunes.suministrar_valor_variable_configuracion("CONFIG-0300-06", vg_id_cia) / 100
        If (Math.Abs(var_costo_promedio_actual) > 0.15 And Math.Abs(var_costo_promedio_actual) <> 1) And (id_tipo_item = 1 Or id_tipo_item = 2) Then
            If permitir_var_costo = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Variacion de costo exagerada, requiere AUTORIZACION."
            End If
        End If
    End Sub



    Private Sub Tx_cantidad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_cantidad.Validating
        If tx_cantidad.Text.ToString = "" Or IsNumeric(tx_cantidad.Text.ToString) = False Then
            tx_cantidad.Text = "0"
        End If
        If sc_aprobada = "S" Then
            If tx_cantidad.Text > cantidad_inicial Or tx_cantidad.Text < 0 Then
                MsgBox("La cantidad maxima aprobada es: " & cantidad_inicial, MsgBoxStyle.Exclamation, "Error")
                tx_cantidad.Text = cantidad_inicial
            End If
        End If
        Calcular_valores_1(1)
    End Sub
    Private Sub Tx_costo_unit_planificado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_cost_unit_planificado.Validating
        If tx_cost_unit_planificado.Text.ToString = "" Or IsNumeric(tx_cost_unit_planificado.Text.ToString) = False Then
            tx_cost_unit_planificado.Text = "0"
        End If
        Calcular_valores_1(1)
    End Sub
    Private Sub Tx_cost_unit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_cost_unit.Validating
        If tx_cost_unit.Text.ToString = "" Or IsNumeric(tx_cost_unit.Text.ToString) = False Then
            tx_cost_unit.Text = "0"
        End If
        Calcular_valores_1(1)
    End Sub
    Private Sub Tx_impuesto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_impuesto.Validating
        If tx_impuesto.Text.ToString = "" Or IsNumeric(tx_impuesto.Text.ToString) = False Then
            tx_impuesto.Text = "19"
        End If
        Calcular_valores_1(1)
    End Sub
    Private Sub Tx_descuento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_descuento.Validating
        If tx_descuento.Text.ToString = "" Or IsNumeric(tx_descuento.Text.ToString) = False Then
            tx_descuento.Text = "0"
        End If
        Calcular_valores_1(1)
    End Sub
    Private Sub Tx_cost_unit_iva_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_cost_unit_iva.Validating
        If tx_cost_unit_iva.Text.ToString = "" Or IsNumeric(tx_cost_unit_iva.Text.ToString) = False Then
            tx_cost_unit_iva.Text = "0"
        End If
        Calcular_valores_1(2)
    End Sub

    Private Sub Tx_cost_total_iva_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_cost_total_iva.Validating
        If tx_cost_total_iva.Text.ToString = "" Or IsNumeric(tx_cost_total_iva.Text.ToString) = False Then
            tx_cost_total_iva.Text = "0"
        End If
        Calcular_valores_1(3)
    End Sub

    Private Sub Tx_cost_total_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_cost_total.Validating
        If tx_cost_total.Text.ToString = "" Or IsNumeric(tx_cost_total.Text.ToString) = False Then
            tx_cost_total.Text = "0"
        End If
        Calcular_valores_1(4)
    End Sub
    Private Sub Calcular_valores_1(ByVal tipo_calculo As Integer)
        Dim valores() As Decimal
        valores = cl_utilidades_gestion_compras.calcular_costos_compra(tipo_calculo, tx_cantidad.Text,
                                                                       tx_cost_unit.Text, tx_impuesto.Text,
                                                                       tx_descuento.Text, tx_cost_total.Text,
                                                                       tx_cost_unit_iva.Text, tx_cost_total_iva.Text)
        'valores(1) = costo unitario Con descuento sin IVA. BASE DE TODOS LOS CALCULOS SIGUIENTES
        'valores(2) = Subtotal SinIVA
        'valores(3) = Costo unitario con IVA
        'valores(4) = Subtotal ConIVA
        'valores(5) = Costo unitario SinDescuento y SinIVA

        tx_cost_unit_planificado.Text = valores(1).ToString("C4")
        tx_cost_unit.Text = valores(5).ToString("C4")
        tx_cost_total.Text = valores(2).ToString("C4")
        tx_cost_unit_iva.Text = valores(3).ToString("C4")
        tx_cost_total_iva.Text = valores(4).ToString("C4")
        cost_unit_p = valores(1)
        Calcular_variacion_costo()
    End Sub
    Private Sub Cargar_informacion_item()
        'Identificamos informacion de la estructura seleccionada.
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If
        Dim rowprod As DataRow() = otb_items.Select("f0300_id_item ='" & tx_id_item.Text & "'")
        For Each orow As DataRow In rowprod
            tx_item_descripcion.Text = orow("f0300_descripcion_item").ToString.Trim
            id_unidad_medicion = orow("f0300_id_unidad_medicion").ToString.Trim
            Cargar_informacion_unidades_medicion()
            habilita_descripcion = orow("f0300_descripcion_usuario").ToString.Trim
            costo_promedio_actual = orow("f0300_costo_promedio")
            id_tipo_item = orow("f0300_id_tipo_item")
            Dim inventario As Integer = 0
            inventario = cl_utilidades_gestion_compras.suministrar_inventario_item_compania(tx_id_item.Text, vg_id_cia)
            lb_inventario.Text = "Inventario Tot: " & Math.Round(inventario, 2)

            If habilita_descripcion = "N" Then
                tx_descripcion_manual.Enabled = False
                tx_descripcion_manual.Text = ""
            Else
                tx_descripcion_manual.Enabled = True
                tx_descripcion_manual.Focus()
            End If
        Next
    End Sub
    Private Sub Cargar_informacion_unidades_medicion()
        'Identificamos informacion de la estructura seleccionada.
        Dim rowprod As DataRow() = otb_unidades.Select("f0002_id_unidad_medicion ='" & id_unidad_medicion & "'")
        For Each orow As DataRow In rowprod
            lb_unidad.Text = orow("f0002_unidad_medicion").ToString.Trim
        Next
    End Sub

    Private Sub Bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"

        Validar_item()
        Validar_cantidad()
        Validar_variacion_costo()
        Validar_item_aprobaciones()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Grabar Actividad", "Desea grabar este recurso?")
        If respuesta = "N" Then
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

        cantidad = tx_cantidad.Text
        'cantidad_stock = tx_cantidad_stock.Text
        cost_unit_p = tx_cost_unit_planificado.Text
        cost_tot_p = tx_cost_total_iva.Text

        If tx_id_registro.Text.ToString = "" Then
            vf_elemento_nuevo = "S"
        Else
            vf_elemento_nuevo = "N"
        End If

        If vf_elemento_nuevo = "S" Then
            Grabar_nuevo_item()
        Else
            verror_requisitos = "N"
            Validar_item_aprobaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Dispose()
                Exit Sub
            End If
            If sc_aprobada = "N" Then
                Actualizar_item()
            Else
                If permitir_var_costo = "S" Then
                    Actualizar_item()
                Else
                    MsgBox("Una solicitud aprobada no puede ser modificada.", MsgBoxStyle.Information, "Info")
                End If
            End If
            'bloqueo la variacion de costos
            permitir_var_costo = "N"
        End If
        If verror = "N" Then
            Actualizar_costo_total_solicitud()
            MsgBox("El Item fue grabado", MsgBoxStyle.Information, "Grabar")
            'Dispose()
            Inicializar_campos()
            If vf_elemento_nuevo = "N" Then
                Dispose()
            End If
        End If
    End Sub
    Private Sub Grabar_nuevo_item()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0305_items_solicitados" _
                & " (f0305_id_cia, f0305_id_solicitud_compra, f0305_id_accion, f0305_id_item, f0305_ampliacion_item, f0305_anotacion_item," _
                & " f0305_cantidad, f0305_chkinventario, f0305_iva, f0305_descuento, f0305_inventario," _
                & " f0305_costo_unitario_planificado, f0305_costo_total_planificado, f0305_fecha_requerido," _
                & " f0305_id_estructura, f0305_var_cost_prom," _
                & " f0305_usuario_modificar, f0305_usuario_crear, f0305_fm)" _
                & " VALUES" _
                & " (@f0305_id_cia, @f0305_id_solicitud_compra, @f0305_id_accion, @f0305_id_item, @f0305_ampliacion_item, @f0305_anotacion_item," _
                & " @f0305_cantidad, @f0305_chkinventario, @f0305_iva, @f0305_descuento, @f0305_inventario," _
                & " @f0305_costo_unitario_planificado, @f0305_costo_total_planificado, @f0305_fecha_requerido," _
                & " @f0305_id_estructura, @f0305_var_cost_prom," _
                & " @f0305_usuario_modificar, @f0305_usuario_crear, @f0305_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_item(ocmd)

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
    Private Sub Actualizar_item()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_id_cia = @f0305_id_cia,"
        csql += "f0305_id_accion = @f0305_id_accion,"
        csql += "f0305_id_item = @f0305_id_item,"
        csql += "f0305_ampliacion_item = @f0305_ampliacion_item, "
        csql += "f0305_anotacion_item = @f0305_anotacion_item,"
        csql += "f0305_cantidad = @f0305_cantidad,"
        csql += "f0305_chkinventario = @f0305_chkinventario,"
        csql += "f0305_iva = @f0305_iva,"
        csql += "f0305_descuento = @f0305_descuento,"
        csql += "f0305_inventario = @f0305_inventario,"
        csql += "f0305_costo_unitario_planificado = @f0305_costo_unitario_planificado,"
        csql += "f0305_costo_total_planificado = @f0305_costo_total_planificado,"
        csql += "f0305_fecha_requerido = @f0305_fecha_requerido,"
        'csql += "f0305_id_factura_compras = @f0305_id_factura_compras,"
        csql += "f0305_id_estructura = @f0305_id_estructura,"
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
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0305_id_item_solicitud", NpgsqlDbType.Integer).Value = CInt(tx_id_registro.Text.ToString)
        End If
        ocmd.Parameters.Add("@f0305_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0305_id_solicitud_compra", NpgsqlDbType.Integer).Value = id_solicitud_compra
        If nueva_accion <> 0 Then
            ocmd.Parameters.Add("@f0305_id_accion", NpgsqlDbType.Integer).Value = nueva_accion
        Else
            ocmd.Parameters.Add("@f0305_id_accion", NpgsqlDbType.Integer).Value = id_accion
        End If

        ocmd.Parameters.Add("@f0305_id_item", NpgsqlDbType.Integer).Value = CInt(tx_id_item.Text.ToString)
        ocmd.Parameters.Add("@f0305_ampliacion_item", NpgsqlDbType.Varchar).Value = tx_descripcion_manual.Text.ToString
        ocmd.Parameters.Add("@f0305_anotacion_item", NpgsqlDbType.Varchar).Value = tx_observacion.Text.ToString
        ocmd.Parameters.Add("@f0305_cantidad", NpgsqlDbType.Numeric).Value = CDbl(tx_cantidad.Text)
        If chk_inventario.Checked = True Then
            ocmd.Parameters.Add("@f0305_chkinventario", NpgsqlDbType.Char).Value = "S"
        Else
            ocmd.Parameters.Add("@f0305_chkinventario", NpgsqlDbType.Char).Value = "N"
        End If

        ocmd.Parameters.Add("@f0305_iva", NpgsqlDbType.Numeric).Value = tx_impuesto.Text / 100
        ocmd.Parameters.Add("@f0305_descuento", NpgsqlDbType.Numeric).Value = tx_descuento.Text / 100
        ocmd.Parameters.Add("@f0305_inventario", NpgsqlDbType.Numeric).Value = inventario
        If v_var_costo = "S" Then
            ocmd.Parameters.Add("@f0305_var_cost_prom", NpgsqlDbType.Numeric).Value = var_costo_promedio_actual
        Else
            ocmd.Parameters.Add("@f0305_var_cost_prom", NpgsqlDbType.Numeric).Value = var_costo_promedio_registro
        End If
        ocmd.Parameters.Add("@f0305_costo_unitario_planificado", NpgsqlDbType.Numeric).Value = cost_unit_p
        ocmd.Parameters.Add("@f0305_costo_total_planificado", NpgsqlDbType.Numeric).Value = cost_tot_p
        ocmd.Parameters.Add("@f0305_fecha_requerido", NpgsqlDbType.Timestamp).Value = dtp_fecha_requerido.Value
        'If tx_id_fact_compras.Text.Trim = "" Then
        '    ocmd.Parameters.Add("@f0305_id_factura_compras", NpgsqlDbType.Integer).Value = DBNull.Value
        'Else
        '    ocmd.Parameters.Add("@f0305_id_factura_compras", NpgsqlDbType.Integer).Value = tx_id_fact_compras.Text.ToString.Trim
        'End If
        ocmd.Parameters.Add("@f0305_id_estructura", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0305_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub Bt_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_anular.Click
        'Pregunta si realmente desea anular
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Registro", "Desea Anular este Item?")
        If respuesta = "N" Then
            Exit Sub
        End If

        If tx_id_registro.Text.ToString = "" Then
            vf_elemento_nuevo = "S"
        Else
            vf_elemento_nuevo = "N"
        End If
        If vf_elemento_nuevo = "S" Then
            Exit Sub
        End If

        verror_requisitos = "N"
        Validar_item_aprobaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Dispose()
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

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_anulado = @f0305_anulado,"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_anular = @f0305_usuario_anular"
        csql += " where f0305_id_item_solicitud = @f0305_id_item_solicitud"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0305_id_item_solicitud", NpgsqlDbType.Integer).Value = CInt(tx_id_registro.Text.ToString)
        ocmd.Parameters.Add("@f0305_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0305_anulado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0305_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
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
        Actualizar_costo_total_solicitud()
        Dispose()
    End Sub
    Private Sub Actualizar_costo_total_solicitud()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0304_solicitud_compra set f0304_costo_total_planificado =" _
        & " (select coalesce(sum(f0305_costo_total_planificado),0) as suma" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_solicitud_compra = '" & id_solicitud_compra & "' and f0305_anulado = 'N')" _
        & " where f0304_id_solicitud = '" & id_solicitud_compra & "'"
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

    'SECCION RECEPCION DE ITEMS---------------------------------------

    Private Sub Grabar_nuevo_item_recepcion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0308_items_recibidos" _
                & " (f0308_id_cia, f0308_id_item_solicitud, f0308_id_factura_compras, f0308_observacion," _
                & " f0308_cantidad, f0308_iva, f0308_descuento," _
                & " f0308_costo_unitario, f0308_costo_total," _
                & " f0308_usuario_recepcion, f0308_fecha_recepcion," _
                & " f0305_usuario_modificar, f0305_usuario_crear, f0305_fm)" _
                & " VALUES" _
                & " (@f0308_id_cia, @f0308_id_item_solicitud, @f0308_id_factura_compras, @f0308_observacion," _
                & " @f0308_cantidad, @f0308_iva, @f0308_descuento," _
                & " @f0308_costo_unitario, @f0308_costo_total," _
                & " @f0308_usuario_recepcion, @f0308_fecha_recepcion," _
                & " @f0305_usuario_modificar, @f0305_usuario_crear, @f0305_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_item_recepcion(ocmd)

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
    Private Sub Crear_parametros_item_recepcion(ByVal ocmd As NpgsqlCommand)
        Dim factual As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0308_id_item_recepcion", NpgsqlDbType.Integer).Value = CInt(tx_id_registro.Text.ToString)
        End If
        ocmd.Parameters.Add("@f0308_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0308_id_item_solicitud", NpgsqlDbType.Integer).Value = CInt(tx_id_item_sc.Text)
        ocmd.Parameters.Add("@f0308_id_factura_compras", NpgsqlDbType.Integer).Value = "" 'tx_id_fact_compras.Text.ToString.Trim
        'ocmd.Parameters.Add("@f0305_id_item", NpgsqlDbType.Integer).Value = CInt(tx_id_item.Text.ToString)
        ocmd.Parameters.Add("@f0308_observacion", NpgsqlDbType.Varchar).Value = tx_observacion.Text.ToString
        ocmd.Parameters.Add("@f0308_cantidad", NpgsqlDbType.Numeric).Value = tx_cantidad.Text
        ocmd.Parameters.Add("@f0308_iva", NpgsqlDbType.Numeric).Value = tx_impuesto.Text / 100
        ocmd.Parameters.Add("@f0308_descuento", NpgsqlDbType.Numeric).Value = tx_descuento.Text / 100
        ocmd.Parameters.Add("@f0308_costo_unitario", NpgsqlDbType.Numeric).Value = cost_unit_p
        ocmd.Parameters.Add("@f0308_costo_total", NpgsqlDbType.Numeric).Value = cost_tot_p
        ocmd.Parameters.Add("@f0308_usuario_recepcion", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0308_fecha_recepcion", NpgsqlDbType.Timestamp).Value = factual
        ocmd.Parameters.Add("@f0308_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0308_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0308_fm", NpgsqlDbType.Timestamp).Value = factual
    End Sub
    Private Function Suministrar_path_estructura_manto(ByVal id_estructura_buscada As String)
        csql = "select f0100_path from " & database.obtener_esquema & ".tb0100_estructura_mantenimiento"
        csql += " where f0100_id_estructura = '" & id_estructura_buscada & "'"
        Dim otb_info As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim path_estructura As String = otb_info.Rows(0)("f0100_path") & id_estructura_buscada & "-"
        Return path_estructura
    End Function
    Private Sub Bt_cambiar_infraestructura_Click(sender As Object, e As EventArgs) Handles bt_cambiar_infraestructura.Click
        ' COLOQUE ESTE BOTON EN ESTADO INVISIBLE
        ' Porque decidi que el id_estructura para toda la solicitud deberia ser la misma,
        ' coloque un disparador en la base de datos para la tabla tb0304_solicitud_compra para que
        ' cuando se cambie la estructura en la solictud se cambie tanbien en todos los items de la misma

        verror_requisitos = "N"
        'validar_cambios_solo_creador()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
            Exit Sub
        End If
        'busco el path del padre para validar dependencia
        Dim path_padre As String = Suministrar_path_estructura_manto(id_estructura.ToString)
        Dim nueva_estructura As String = id_estructura.ToString
        nueva_estructura = cl_utilidades_gestion_mantenimiento.suministrar_estructura_mantenimiento(vg_id_cia, vg_usuario_autoriza, id_estructura)
        Dim id_estructura_anterior As Integer = id_estructura
        If id_estructura.ToString <> nueva_estructura Then
            Dim path_nuevo As String = Suministrar_path_estructura_manto(nueva_estructura)
            id_estructura = nueva_estructura
            'If Strings.Left(path_nuevo, Strings.Len(path_padre)) = path_padre Then

            'Else
            'MsgBox("Solo se puede cambiar la estructura por elementos hijo de la estructura original", MsgBoxStyle.Information, "Info")
            'End If
            If id_estructura_anterior <> id_estructura Then
                'cambiar_estructura_seleccionada()
                tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura)
                MsgBox("Estructura definida", MsgBoxStyle.Information, "Estructura")
            End If
        End If
    End Sub

#Region "ControlaBusquedaItems"
    Private Sub Bt_listado_general_items_Click(sender As Object, e As EventArgs) Handles bt_listado_general_items.Click
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0300-34", vg_id_cia, vg_usuario_autoriza,
        '                                                    "Listado General de Items", {vg_id_cia})
        Buscar_item()
    End Sub
    Private Sub tx_item_descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles tx_item_descripcion.KeyDown
        If (e.KeyCode = Keys.B AndAlso e.Modifiers = Keys.Control) Then
            'PARA USAR CUANDO EL FORMULARIO ES PARA SELECCIONAR UN DATO
            'MsgBox(dg_datos.CurrentRow.Cells("id_sc").Value)
            Buscar_item()
        End If
    End Sub

    Private Sub Buscar_item()
        Dim filtro As String = ""
        If tx_item_descripcion.Text <> "" Then
            'filtro = "descripcion_larga LIKE '%" & tx_item_descripcion.Text.Trim & "%'"
            filtro = comunes.generador_filtro_like("descripcion_larga", tx_item_descripcion.Text.Trim)
        End If
        tx_item_descripcion.Text = ""

        Dim id_it As Integer = comunes.Buscador_item(vg_id_cia, vg_usuario_autoriza, filtro)
        If id_it = 0 Then
            tx_id_item.Text = ""
        Else
            tx_id_item.Text = id_it
            tx_id_item.Focus()
            tx_cantidad.Focus()
        End If
    End Sub
#End Region

    Private Sub Bt_actualizar_creando_accion_Click(sender As Object, e As EventArgs) Handles bt_actualizar_creando_accion.Click
        If vf_elemento_nuevo = "S" Then
            MsgBox("Solo para elementos existentes creando accion", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        verror_requisitos = "N"
        Validar_item()
        Validar_item_aprobaciones()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Grabar Actividad", "OJO SOLO PARA CREAR ACCION GENERICA Desea grabar este recurso?")
        If respuesta = "N" Then
            Exit Sub
        End If


        Dim titulo As String = "INSTALACION, REEMPLAZO O CAMBIO DE ELEMENTO"
        Dim texto_accion As String = "INSTALACION, REEMPLAZO O CAMBIO DE ELEMENTO"
        Dim id_fuente As String = "00000003"
        Dim responsable As String = "00000003"
        Dim evaluador As String = "00001563"
        nueva_accion = cl_utilidades_gestion_acciones.crear_accion_generica(id_fuente,
                                                                            texto_accion,
                                                                            titulo,
                                                                            responsable,
                                                                            vg_usuario_autoriza,
                                                                            evaluador, vg_id_cia,
                                                                            dtp_fecha_requerido.Value,
                                                                            id_estructura, id_accion)
        Actualizar_item()
        MsgBox("Accion creada: " & nueva_accion)
    End Sub

    Private Sub Bt_autorizar_variacion_costo_Click(sender As Object, e As EventArgs) Handles bt_autorizar_variacion_costo.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Autorizar Variacion de Costo", "Autoriza la compra de este item con una variacion de costo excesiva?")
        If respuesta = "N" Then
            Exit Sub
        End If
        permitir_var_costo = "S"
    End Sub

    Private Sub bt_historico_compras_Click(sender As Object, e As EventArgs) Handles bt_historico_compras.Click
        If tx_id_item.Text = "" Then
            MsgBox("Seleccione un item para consultar", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_compras.movimientos_compras_item(tx_id_item.Text, vg_usuario_autoriza, vg_id_cia)
    End Sub

    Private Sub bt_info_item_Click(sender As Object, e As EventArgs) Handles bt_info_item.Click
        verror_requisitos = "N"
        Validar_item()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Dim oform_item As New fm_0300_gestion_items With {
                    .vf_oform_padre = Me,
                    .vg_id_cia = vg_id_cia,
                    .cerrar_al_actualizar = "S",
                    .id_item = tx_id_item.Text.Trim,
                    .vg_usuario_autoriza = vg_usuario_autoriza,
                    .vf_elemento_nuevo = "N"
                }
        oform_item.ShowDialog()
    End Sub

End Class
