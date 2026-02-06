Public Class fm_0800_registro_pedidos
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_despacho As Integer
    Public mostrar_solo_despacho As String = "S"

    Public id_accion As Integer = 0 'Varibale que se llenara cuando se genere una reclamacion

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private otb_ciudades As DataTable
    Private otb_unidad_tiempo As DataTable
    Private otb_tercero As DataTable
    Private otb_info_personal As DataTable
    Private otb_info_despacho As DataTable
    Private otb_accion As DataTable

    Private pedido_en_edicion As String = "N"

    Private Sub fm_0800_registro_pedidos_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        'Para ocultar las fichas con la informacion del pedido y sus costos
        If mostrar_solo_despacho = "S" Then
            'Deshabilitar los controles y las tabpage que tienen informacion del pedido y sus valores
            TabControl1.TabPages("tbpg_pedido").Parent = Nothing
            TabControl1.TabPages("tbpg_aprobaciones").Parent = Nothing
            TabControl1.TabPages("tbpg_seguimiento").Parent = Nothing
            'TabControl1.TabPages("tbpg_reclamacion").Parent = Nothing
        End If

        gb_soportes_cumplido.Enabled = False

        tx_id_despacho.Enabled = False
        tx_unidades_pedidas.Text = 0
        tx_unidades_bono_pedido.Text = 0
        tx_unidades_totales_pedido.Enabled = False
        tx_total_unidades_aprobadas.Enabled = False
        tx_valor_bono_pedido.Text = 0.ToString("C2")
        tx_valor_pedido_cliente.Text = 0.ToString("C2")
        tx_flete_calculado.Text = 0.ToString("C2")
        tx_valor_facturado.Text = 0.ToString("C2")
        tx_unidades_totales_factura.Enabled = False
        tx_valor_despachado.Text = 0.ToString("C2")
        tx_unidades_facturadas.Text = 0
        tx_unidades_despachadas.Text = 0
        bt_editar_despacho.Enabled = False
        bt_grabar.Enabled = False
        bt_editar.Enabled = False
        bt_nuevo.Enabled = False
        bt_anular.Enabled = False
        bt_generar_informe.Enabled = False
        tx_funcionario_registra_pedido.Enabled = False
        tx_funcionario_revisa_pedido.Enabled = False
        tx_funcionario_aprueba_pedido.Enabled = False
        tx_funcionario_factura.Enabled = False
        tx_funcionario_registra_guia_transp.Enabled = False
        tx_funcionario_verifica_recibo.Enabled = False
        tx_funcionario_registra_cumplido_transp.Enabled = False
        tx_funcionario_registra_devolucion.Enabled = False
        tx_funcionario_cierra_pedido.Enabled = False
        dtp_fecha_registro_devolucion.Enabled = False
        tx_funcionario_niega_pedido.Enabled = False
        tx_id_accion.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_registro.Format = DateTimePickerFormat.Custom
        dtp_fecha_registro.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_registro.Enabled = False
        'dtp_fecha_registro.Value = comunes.g_fechahora

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_revision.Format = DateTimePickerFormat.Custom
        dtp_fecha_revision.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_revision.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_aprobacion.Format = DateTimePickerFormat.Custom
        dtp_fecha_aprobacion.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_aprobacion.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_facturacion.Format = DateTimePickerFormat.Custom
        dtp_fecha_facturacion.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_facturacion.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_negacion.Format = DateTimePickerFormat.Custom
        dtp_fecha_negacion.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_negacion.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_factura_2.Format = DateTimePickerFormat.Custom
        dtp_fecha_factura_2.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_factura_2.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_registro_pedido.Format = DateTimePickerFormat.Custom
        dtp_fecha_registro_pedido.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_registro_pedido.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_verificacion_recibo.Format = DateTimePickerFormat.Custom
        dtp_fecha_verificacion_recibo.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_verificacion_recibo.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_cumplido.Format = DateTimePickerFormat.Custom
        dtp_fecha_cumplido.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_cumplido.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_registro_devolucion.Format = DateTimePickerFormat.Custom
        dtp_fecha_registro_devolucion.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_registro_devolucion.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_cierre_pedido.Format = DateTimePickerFormat.Custom
        dtp_fecha_cierre_pedido.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_cierre_pedido.Enabled = False

        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" & " and f0200_ind_empleado = 'S'" _
            & " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        Dim otb_asesor As DataTable = otb_info_personal.Copy

        With cm_asesor
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_asesor
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_asesor_2
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_asesor
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_funcionario_recibe_devolucion
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
        'carga la informacion de los clientes.
        cargar_info_terceros()

        csql = "select f0052_codigo_ciudad, f0052_ciudad || ' - ' || f0051_departamento as ciudad" _
            & " from " & database.obtener_esquema & ".tb0052_ciudades" _
            & " join " & database.obtener_esquema & ".tb0051_departamentos" _
            & " on f0051_codigo_departamento = f0052_codigo_departamento"
        otb_ciudades = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        With cm_ciudad_destino
            'Valor que se muestra al usuario
            .DisplayMember = "ciudad"
            'Valor interno que almacena el objeto
            .ValueMember = "f0052_codigo_ciudad"
            'Origen de Datos del ComboBox
            .DataSource = otb_ciudades
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_ciudad_destino_2
            'Valor que se muestra al usuario
            .DisplayMember = "ciudad"
            'Valor interno que almacena el objeto
            .ValueMember = "f0052_codigo_ciudad"
            'Origen de Datos del ComboBox
            .DataSource = otb_ciudades
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "select f0200_id_tercero, f0200_id," _
            & " trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as tercero" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_ind_proveedor = 'S'" _
            & " order by f0200_nombres"
        Dim otb_tercero_proveedor = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim otb_transportadora_despacho As DataTable = otb_tercero_proveedor.Copy
        With cm_transportadora
            'Valor que se muestra al usuario
            .DisplayMember = "tercero"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_tercero_proveedor
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_transportadora_2
            'Valor que se muestra al usuario
            .DisplayMember = "tercero"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_tercero_proveedor
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_transportadora_despacho
            'Valor que se muestra al usuario
            .DisplayMember = "tercero"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_transportadora_despacho
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        'Bloquear paneles
        bloquear_paneles()

        If vf_elemento_nuevo = "S" Then

            'dtp_fecha_revision.Visible = False
            'dtp_fecha_aprobacion.Visible = False
            'dtp_fecha_negacion.Visible = False
            'tx_unidades_aprobadas.Visible = False
            'tx_valor_aprobado.Visible = False
            pnl_reg_pedido.Enabled = True

            'Activar grabar si tiene permisos para esto
            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_grabar, ocontexto_form)
        Else
            llenar_form_info_despacho()

            'Para el control de documentos asociados
            calcular_archivos_asociados_cumplido()
            lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas("TN-PDC-001", tx_id_despacho.Text, vg_id_cia)
            'activar_grabar()
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-DRC-001", vg_id_cia)
            new_name_file += "-" & tx_id_despacho.Text.PadLeft(8, "0")

            'habilitar_aprobaciones()
            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_anular, ocontexto_form)
        End If

    End Sub

    Private Function buscar_nombre_funcionario(id_tercero As String)
        Dim orow_funcionario() As DataRow
        Dim nombre_funcionario As String = ""
        orow_funcionario = otb_info_personal.Select("f0200_id_tercero = '" & id_tercero & "'")
        For Each orow As DataRow In orow_funcionario
            nombre_funcionario = orow("nombre")
        Next
        Return nombre_funcionario
    End Function

    Private Sub bloquear_paneles()
        'Bloquear todos los paneles
        pnl_reg_pedido.Enabled = False
        pnl_reg_pedido_2.Enabled = False
        pnl_revisado.Enabled = False
        pnl_aprobado.Enabled = False
        'pnl_negado.Enabled = False
        pnl_facturado.Enabled = False
        pnl_reg_guia.Enabled = False
        pnl_verif_cliente.Enabled = False
        pnl_cumplido_transportadora.Enabled = False
        pnl_devolucion.Enabled = False
        pnl_cierre_despacho.Enabled = False
    End Sub

    Private Sub cargar_info_terceros()
        csql = "select f0200_id_tercero, f0200_id," _
            & " trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as tercero" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_ind_cliente = 'S'" _
            & " order by f0200_nombres"
        otb_tercero = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_nit
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_id"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_tercero
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_nit_2
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_id"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_tercero
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_razon_social
            'Valor que se muestra al usuario
            .DisplayMember = "tercero"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_tercero
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_razon_social_2
            'Valor que se muestra al usuario
            .DisplayMember = "tercero"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_tercero
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub cargar_otb_info_despacho()
        csql = "select * from " & database.obtener_esquema & ".tb0800_despachos_comercial" _
                    & " where f0800_id_despacho = '" & id_despacho & "'"
        otb_info_despacho = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub

    Private Sub llenar_form_info_despacho()
        'bloquear paneles
        bloquear_paneles()

        cargar_otb_info_despacho()
        For Each orow As DataRow In otb_info_despacho.Rows
            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_editar_despacho, ocontexto_form)
            tx_id_despacho.Text = orow("f0800_id_despacho")
            tx_id_despacho_2.Text = orow("f0800_id_despacho")
            tx_funcionario_registra_pedido.Text = buscar_nombre_funcionario(orow("f0800_usuario_crear"))
            dtp_fecha_registro.Value = orow("f0800_fr")
            cm_nit.SelectedValue = orow("f0800_cliente")
            cm_nit_2.SelectedValue = orow("f0800_cliente")
            cm_asesor.SelectedValue = orow("f0800_vendedor")
            cm_asesor_2.SelectedValue = orow("f0800_vendedor")
            cm_ciudad_destino.SelectedValue = orow("f0800_id_ciudad_destino")
            cm_ciudad_destino_2.SelectedValue = orow("f0800_id_ciudad_destino")
            tx_cotizacion.Text = orow("f0800_id_cotizacion")
            tx_cotizacion_2.Text = orow("f0800_id_cotizacion")
            cm_transportadora.SelectedValue = orow("f0800_transportadora_programada")
            cm_transportadora_2.SelectedValue = orow("f0800_transportadora_programada")
            dtp_programacion_despacho.Value = orow("f0800_fecha_programacion_despacho")
            dtp_programacion_despacho_2.Value = orow("f0800_fecha_programacion_despacho")
            tx_unidades_pedidas.Text = orow("f0800_tot_cajas_cotizadas")
            Dim valor_p As Decimal = orow("f0800_costo_total_cotizado")
            tx_valor_pedido_cliente.Text = valor_p.ToString("C2")
            tx_unidades_bono_pedido.Text = orow("f0800_tot_cajas_bono_cotizadas")
            valor_p = orow("f0800_costo_total_bono_cotizado")
            tx_valor_bono_pedido.Text = valor_p.ToString("C2")
            tx_unidades_totales_pedido.Text = orow("f0800_tot_cajas_cotizadas") + orow("f0800_tot_cajas_bono_cotizadas")
            If orow("f0800_aprobado") = "N" Then
                'Activar panel correspondiente
                pnl_aprobado.Enabled = True
                tx_valor_aprobado.Text = 0.ToString("C2")
                tx_unidades_aprobadas.Text = 0
                tx_valor_bono_aprobado.Text = 0.ToString("C2")
                tx_unidades_bono_aprobadas.Text = 0
                lb_titulo.Text = "Pedido Pendiente por Aprobar"
                GoTo line1
            Else
                tx_funcionario_aprueba_pedido.Text = buscar_nombre_funcionario(orow("f0800_funcionario_aprueba"))
                dtp_fecha_aprobacion.Value = orow("f0800_fecha_aprobacion")
                valor_p = orow("f0800_costo_total_aprobado")
                tx_valor_aprobado.Text = valor_p.ToString("C2")
                tx_unidades_aprobadas.Text = orow("f0800_tot_cajas_aprobadas")
                valor_p = orow("f0800_costo_total_bono_aprobado")
                tx_valor_bono_aprobado.Text = valor_p.ToString("C2")
                tx_unidades_bono_aprobadas.Text = orow("f0800_tot_cajas_bono_aprobadas")
                tx_total_unidades_aprobadas.Text = orow("f0800_tot_cajas_aprobadas") + orow("f0800_tot_cajas_bono_aprobadas")
            End If
            If orow("f0800_aprobado") = "S" And orow("f0800_facturado") = "N" Then
                pnl_facturado.Enabled = True
                tx_unidades_bono_facturadas.Text = 0
                tx_valor_bono_factura.Text = 0.ToString("C2")
                lb_titulo.Text = "Pedido Pendiente Facturar"
                'pnl_reg_guia.Enabled = False
                GoTo line1
            Else
                tx_funcionario_factura.Text = buscar_nombre_funcionario(orow("f0800_funcionario_factura"))
                dtp_fecha_facturacion.Value = orow("f0800_fecha_factura")
                tx_remision.Text = orow("f0800_id_remision").ToString
                tx_factura.Text = orow("f0800_id_factura").ToString
                valor_p = orow("f0800_costo_flete_calculado")
                tx_flete_calculado.Text = valor_p.ToString("C2")
                tx_unidades_facturadas.Text = orow("f0800_total_cajas_facturadas")
                valor_p = orow("f0800_costo_total_facturado")
                tx_valor_facturado.Text = valor_p.ToString("C2")
                tx_id_bono.Text = orow("f0800_id_doc_bono").ToString
                tx_unidades_bono_facturadas.Text = orow("f0800_tot_cajas_bono_factura")
                valor_p = orow("f0800_costo_total_bono_factura")
                tx_valor_bono_factura.Text = valor_p.ToString("C2")
                tx_unidades_totales_factura.Text = orow("f0800_total_cajas_facturadas") + orow("f0800_tot_cajas_bono_factura")
                'seccion del despacho
                dtp_fecha_factura_2.Value = orow("f0800_fecha_factura")
                tx_remision_2.Text = orow("f0800_id_remision").ToString
                tx_factura_2.Text = orow("f0800_id_factura").ToString
                tx_unidades_facturadas_2.Text = orow("f0800_total_cajas_facturadas")
                tx_id_bono_2.Text = orow("f0800_id_doc_bono").ToString
                tx_unidades_bono_facturadas_2.Text = orow("f0800_tot_cajas_bono_factura")
                tx_unidades_totales_factura_2.Text = orow("f0800_total_cajas_facturadas") + orow("f0800_tot_cajas_bono_factura")
            End If
            If orow("f0800_facturado") = "S" And orow("f0800_revisado") = "N" Then
                pnl_revisado.Enabled = True
                lb_titulo.Text = "Pedido pendiente por Revisar"
                'MsgBox("Hola")
                GoTo line1
            Else
                tx_funcionario_revisa_pedido.Text = buscar_nombre_funcionario(orow("f0800_funcionario_revisa"))
                dtp_fecha_revision.Value = orow("f0800_fecha_revicion")
            End If
            If orow("f0800_revisado") = "S" And orow("f0800_guia_registrada") = "N" Then
                pnl_reg_guia.Enabled = True
                lb_titulo.Text = "Pedido Pendiente Asignar Guia Transp."
                GoTo line1
            Else
                tx_funcionario_registra_guia_transp.Text = buscar_nombre_funcionario(orow("f0800_funcionario_registra_guia_transp"))
                cm_transportadora_despacho.SelectedValue = orow("f0800_transportadora")
                tx_guia_transportadora.Text = orow("f0800_guia_transportadora")
                tx_unidades_despachadas.Text = orow("f0800_tot_cajas_despachadas")
                If orow("f0800_cumplido_recibido") = "N" Then
                    pnl_reg_guia.Enabled = True
                Else
                    pnl_reg_guia.Enabled = False
                End If
            End If
            If orow("f0800_guia_registrada") = "S" And orow("f0800_recibo_verificado") = "N" Then
                pnl_verif_cliente.Enabled = True
                lb_titulo.Text = "Pedido Pendiente Verificar Recibo Cliente"
                GoTo line1
            Else
                tx_funcionario_verifica_recibo.Text = buscar_nombre_funcionario(orow("f0800_funcionario_verifica_recibo"))
                dtp_fecha_verificacion_recibo.Value = orow("f0800_fecha_verifica_recibo")
                tx_info_cliente_recibo.Text = orow("f0800_info_cliente_recibo")
                gb_soportes_cumplido.Enabled = True
            End If
            If orow("f0800_recibo_verificado") = "S" And orow("f0800_cumplido_recibido") = "N" Then
                pnl_cumplido_transportadora.Enabled = True
                lb_titulo.Text = "Pedido Pendiente Recibir Cumplido Transportadora"
                GoTo line1
            Else
                tx_funcionario_registra_cumplido_transp.Text = buscar_nombre_funcionario(orow("f0800_funcionario_cumplido_transp"))
                dtp_fecha_cumplido.Value = orow("f0800_fecha_cumplido_transp")
                tx_id_cumplido_transportadora.Text = orow("f0800_id_cumplido_transp")
            End If
            If orow("f0800_cumplido_recibido") = "S" And orow("f0800_despacho_cerrado") = "N" Then
                pnl_cierre_despacho.Enabled = True
                lb_titulo.Text = "Pedido Pendiente por Cerrar"
                GoTo line1
            Else
                dtp_fecha_cierre_pedido.Value = orow("f0800_fecha_cierre")
                tx_funcionario_cierra_pedido.Text = buscar_nombre_funcionario(orow("f0800_funcionario_cierra"))
            End If
line1:
            If orow("f0800_g_reclamacion") = "S" Then
                tx_id_accion.Text = orow("f0800_id_accion")
                pnl_devolucion.Enabled = True
            End If
            If orow("f0800_g_devolucion") = "S" Then
                dtp_fecha_registro_devolucion.Value = orow("f0800_fecha_registro_devolucion")
                tx_funcionario_registra_devolucion.Text = buscar_nombre_funcionario(orow("f0800_funcionario_registra_devolucion"))
                cm_funcionario_recibe_devolucion.SelectedValue = orow("f0800_funcionario_recibe_devolucion")
                dtp_fecha_recibo_devolucion.Value = orow("f0800_fecha_devolucion")
                tx_informacion_devolucion.Text = orow("f0800_info_devolucion")
            End If
            If orow("f0800_negado") = "S" Then
                tx_funcionario_niega_pedido.Text = buscar_nombre_funcionario(orow("f0800_funcionario_niega"))
                dtp_fecha_negacion.Value = orow("f0800_fecha_negacion")
            End If
        Next
    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click

        verror_requisitos = "N"
        validar_cliente()
        validar_ciudad()
        validar_cotizacion()
        validar_transportadora()
        validar_unidades_pedidas()
        validar_valor_pedido()
        validar_vendedor()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            grabar_nuevo_pedido()
            If verror = "N" Then
                Dim despacho_creado As String = ""
                despacho_creado = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0800_id_despacho", "f0800_usuario_crear", vg_usuario_autoriza, "tb0800_despachos_comercial")
                MsgBox("Se creo el pedido #: " & despacho_creado, MsgBoxStyle.Information, "Pedido")
            End If
        Else
            If pedido_en_edicion = "S" Then
                grabar_despacho_habilitado()
            End If
        End If

        If verror = "N" Then
            MsgBox("Registro grabado", MsgBoxStyle.Information, "Grabado")
            Dispose()
        End If
    End Sub
    Private Sub grabar_nuevo_pedido()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0800_despachos_comercial" _
                & " (f0800_id_cia, f0800_id_cotizacion, f0800_fecha_cotizacion," _
                & " f0800_vendedor, f0800_funcionario_cotizacion, f0800_cliente," _
                & " f0800_id_ciudad_destino, f0800_costo_total_cotizado, f0800_tot_cajas_cotizadas, " _
                & " f0800_transportadora_programada, f0800_fecha_programacion_despacho," _
                & " f0800_tot_cajas_bono_cotizadas, f0800_costo_total_bono_cotizado," _
                & " f0800_usuario_modificar, f0800_usuario_crear, f0800_fm)" _
                & " VALUES" _
                & " (@f0800_id_cia, @f0800_id_cotizacion, @f0800_fecha_cotizacion," _
                & " @f0800_vendedor, @f0800_funcionario_cotizacion, @f0800_cliente," _
                & " @f0800_id_ciudad_destino, @f0800_costo_total_cotizado, @f0800_tot_cajas_cotizadas, " _
                & " @f0800_transportadora_programada, @f0800_fecha_programacion_despacho," _
                & " @f0800_tot_cajas_bono_cotizadas, @f0800_costo_total_bono_cotizado," _
                & " @f0800_usuario_modificar, @f0800_usuario_crear, @f0800_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_pedido(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nuevo pedido! " + vbCrLf + ex.ToString + vbCrLf + csql)
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

    Private Sub crear_parametros_pedido(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0800_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0800_id_cotizacion", NpgsqlDbType.Varchar).Value = tx_cotizacion.Text
        ocmd.Parameters.Add("@f0800_fecha_cotizacion", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_vendedor", NpgsqlDbType.Varchar).Value = cm_asesor.SelectedValue
        ocmd.Parameters.Add("@f0800_funcionario_cotizacion", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_cliente", NpgsqlDbType.Varchar).Value = cm_razon_social.SelectedValue
        ocmd.Parameters.Add("@f0800_id_ciudad_destino", NpgsqlDbType.Varchar).Value = cm_ciudad_destino.SelectedValue
        ocmd.Parameters.Add("@f0800_costo_total_cotizado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_pedido_cliente.Text)
        ocmd.Parameters.Add("@f0800_tot_cajas_cotizadas", NpgsqlDbType.Integer).Value = CInt(tx_unidades_pedidas.Text)
        ocmd.Parameters.Add("@f0800_transportadora_programada", NpgsqlDbType.Varchar).Value = cm_transportadora.SelectedValue
        ocmd.Parameters.Add("@f0800_fecha_programacion_despacho", NpgsqlDbType.Timestamp).Value = dtp_programacion_despacho.Value
        ocmd.Parameters.Add("@f0800_tot_cajas_bono_cotizadas", NpgsqlDbType.Integer).Value = CInt(tx_unidades_bono_pedido.Text)
        ocmd.Parameters.Add("@f0800_costo_total_bono_cotizado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_bono_pedido.Text)
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub

    Private Sub bt_editar_despacho_Click(sender As Object, e As EventArgs) Handles bt_editar_despacho.Click
        pnl_reg_pedido.Enabled = True
        'Activar grabar si tiene permisos para esto
        'Deshabilitar los controles y las tabpage que tienen informacion del pedido y sus valores
        TabControl1.TabPages("tbpg_despacho").Parent = Nothing
        TabControl1.TabPages("tbpg_aprobaciones").Parent = Nothing
        TabControl1.TabPages("tbpg_seguimiento").Parent = Nothing
        TabControl1.TabPages("tbpg_reclamacion").Parent = Nothing
        cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_grabar, ocontexto_form)
        If tx_funcionario_niega_pedido.Text <> "" Or tx_funcionario_registra_guia_transp.Text <> "" Then
            MsgBox("Este pedido solo puede modificarlo el Administrador del sistema", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        pedido_en_edicion = "S"
    End Sub

    Private Sub grabar_despacho_habilitado()
        'Pregunta si realmente desea HABILITAR
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Editar Registro", "Desea grabar los cambios en este registro?")
        If respuesta = "N" Then
            Exit Sub
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_id_cotizacion = @f0800_id_cotizacion,"
        csql += "f0800_fecha_cotizacion = @f0800_fecha_cotizacion,"
        csql += "f0800_vendedor = @f0800_vendedor,"
        csql += "f0800_funcionario_cotizacion = @f0800_funcionario_cotizacion,"
        csql += "f0800_cliente = @f0800_cliente,"
        csql += "f0800_id_ciudad_destino = @f0800_id_ciudad_destino,"
        csql += "f0800_costo_total_cotizado = @f0800_costo_total_cotizado,"
        csql += "f0800_tot_cajas_cotizadas = @f0800_tot_cajas_cotizadas,"
        csql += "f0800_transportadora_programada = @f0800_transportadora_programada,"
        csql += "f0800_fecha_programacion_despacho = @f0800_fecha_programacion_despacho,"
        csql += "f0800_aprobado = @f0800_aprobado,"
        csql += "f0800_revisado = @f0800_revisado,"
        csql += "f0800_facturado = @f0800_facturado,"
        csql += "f0800_id_cumplido_transp = @f0800_id_cumplido_transp,"
        csql += "f0800_id_factura = @f0800_id_factura,"
        csql += "f0800_id_remision = @f0800_id_remision,"
        csql += "f0800_tot_cajas_bono_cotizadas = @f0800_tot_cajas_bono_cotizadas,"
        csql += "f0800_costo_total_bono_cotizado = @f0800_costo_total_bono_cotizado,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("@f0800_id_cotizacion", NpgsqlDbType.Varchar).Value = tx_cotizacion.Text
        ocmd.Parameters.Add("@f0800_fecha_cotizacion", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_vendedor", NpgsqlDbType.Varchar).Value = cm_asesor.SelectedValue
        ocmd.Parameters.Add("@f0800_funcionario_cotizacion", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_cliente", NpgsqlDbType.Varchar).Value = cm_razon_social.SelectedValue
        ocmd.Parameters.Add("@f0800_id_ciudad_destino", NpgsqlDbType.Varchar).Value = cm_ciudad_destino.SelectedValue
        ocmd.Parameters.Add("@f0800_costo_total_cotizado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_pedido_cliente.Text)
        ocmd.Parameters.Add("@f0800_tot_cajas_cotizadas", NpgsqlDbType.Integer).Value = CInt(tx_unidades_pedidas.Text)
        ocmd.Parameters.Add("@f0800_transportadora_programada", NpgsqlDbType.Varchar).Value = cm_transportadora.SelectedValue
        ocmd.Parameters.Add("@f0800_fecha_programacion_despacho", NpgsqlDbType.Timestamp).Value = dtp_programacion_despacho.Value
        ocmd.Parameters.Add("@f0800_aprobado", NpgsqlDbType.Varchar).Value = "N"
        ocmd.Parameters.Add("@f0800_revisado", NpgsqlDbType.Varchar).Value = "N"
        ocmd.Parameters.Add("@f0800_facturado", NpgsqlDbType.Varchar).Value = "N"
        ocmd.Parameters.Add("@f0800_id_cumplido_transp", NpgsqlDbType.Varchar).Value = DBNull.Value
        ocmd.Parameters.Add("@f0800_id_factura", NpgsqlDbType.Varchar).Value = DBNull.Value
        ocmd.Parameters.Add("@f0800_id_remision", NpgsqlDbType.Varchar).Value = DBNull.Value
        ocmd.Parameters.Add("@f0800_tot_cajas_bono_cotizadas", NpgsqlDbType.Integer).Value = CInt(tx_unidades_bono_pedido.Text)
        ocmd.Parameters.Add("@f0800_costo_total_bono_cotizado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_bono_pedido.Text)
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub bt_revisar_Click(sender As Object, e As EventArgs) Handles bt_revisar.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Revicion", "Desea reportar la revicion del pedido?")
        If respuesta = "N" Then
            Exit Sub
        End If
        verror = "N"
        grabar_revision()
        If verror = "N" Then
            cargar_otb_info_despacho()
            llenar_form_info_despacho()
            'habilitar_aprobaciones()
            bt_revisar.Enabled = False
            MsgBox("Revision Registrada", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub grabar_revision()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_revisa = @f0800_funcionario_revisa,"
        csql += "f0800_fecha_revicion = @f0800_fecha_revicion,"
        csql += "f0800_revisado = @f0800_revisado,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("@f0800_funcionario_revisa", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fecha_revicion", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_revisado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub tx_valor_pedido_cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_valor_pedido_cliente.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_valor_pedido_cliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_valor_pedido_cliente.Validating
        If tx_valor_pedido_cliente.Text.ToString = "" Or IsNumeric(tx_valor_pedido_cliente.Text.ToString) = False Then
            tx_valor_pedido_cliente.Text = "0"
        End If
        Dim valor_p As Decimal = tx_valor_pedido_cliente.Text
        tx_valor_pedido_cliente.Text = valor_p.ToString("C2")
    End Sub

    Private Sub tx_valor_bono_pedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_valor_bono_pedido.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_valor_bono_pedido_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_valor_bono_pedido.Validating
        If tx_valor_bono_pedido.Text.ToString = "" Or IsNumeric(tx_valor_bono_pedido.Text.ToString) = False Then
            tx_valor_bono_pedido.Text = "0"
        End If
        Dim valor_p As Decimal = tx_valor_bono_pedido.Text
        tx_valor_bono_pedido.Text = valor_p.ToString("C2")
    End Sub

    Private Sub tx_unidades_pedidas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_unidades_pedidas.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_unidades_pedidas_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_unidades_pedidas.Validating
        If tx_unidades_pedidas.Text.ToString = "" Or IsNumeric(tx_unidades_pedidas.Text.ToString) = False Then
            tx_unidades_pedidas.Text = "0"
        End If
        tx_unidades_totales_pedido.Text = CInt(tx_unidades_pedidas.Text) + CInt(tx_unidades_bono_pedido.Text)
    End Sub

    Private Sub tx_unidades_bono_pedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_unidades_bono_pedido.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_unidades_bono_pedido_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_unidades_bono_pedido.Validating
        If tx_unidades_bono_pedido.Text.ToString = "" Or IsNumeric(tx_unidades_bono_pedido.Text.ToString) = False Then
            tx_unidades_bono_pedido.Text = "0"
        End If
        tx_unidades_totales_pedido.Text = CInt(tx_unidades_pedidas.Text) + CInt(tx_unidades_bono_pedido.Text)
    End Sub

    Private Sub validar_cliente()
        If cm_nit.SelectedIndex = -1 Or cm_razon_social.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione un Cliente"
            verror_requisitos = "S"
            cm_nit.Text = ""
            cm_razon_social_2.Text = ""
        End If
    End Sub

    Private Sub validar_vendedor()
        If cm_asesor.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione un Asesor Comercial"
            verror_requisitos = "S"
            cm_asesor.Text = ""
        End If
    End Sub

    Private Sub validar_ciudad()
        If cm_ciudad_destino.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione una Ciudad de Destino"
            verror_requisitos = "S"
            cm_ciudad_destino.Text = ""
        End If
    End Sub

    Private Sub validar_cotizacion()
        If tx_cotizacion.Text.Trim = "" Then
            vmensaje_requisitos = "Identifique la cotizacion realizada"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_transportadora()
        If cm_transportadora.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione una Transportadora"
            verror_requisitos = "S"
            cm_transportadora.Text = ""
        End If
    End Sub

    Private Sub validar_unidades_pedidas()
        If tx_unidades_pedidas.Text = "0" Then
            vmensaje_requisitos = "Identifique la cantidad de cajas por despachar"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_valor_pedido()
        If CInt(tx_valor_pedido_cliente.Text) = "0" Then 'El valor puede ser cero en las muestras y promociones.
            'vmensaje_requisitos = "Identifique el valor del pedido"
            'verror_requisitos = "S"
        End If
    End Sub

    Private Sub bt_aprobar_Click(sender As Object, e As EventArgs) Handles bt_aprobar.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Aprobacion", "Desea reportar la aprobacion del pedido?")
        If respuesta = "N" Then
            Exit Sub
        End If
        verror_requisitos = "N"
        validar_unidades_aprobadas()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        verror = "N"
        grabar_aprobacion()
        If verror = "N" Then
            cargar_otb_info_despacho()
            llenar_form_info_despacho()
            'habilitar_aprobaciones()
            bt_revisar.Enabled = False
            MsgBox("Aprobacion Registrada", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub grabar_aprobacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_aprueba = @f0800_funcionario_aprueba,"
        csql += "f0800_fecha_aprobacion = @f0800_fecha_aprobacion,"
        csql += "f0800_aprobado = @f0800_aprobado,"
        csql += "f0800_tot_cajas_aprobadas = @f0800_tot_cajas_aprobadas,"
        csql += "f0800_costo_total_aprobado = @f0800_costo_total_aprobado,"
        csql += "f0800_tot_cajas_bono_aprobadas = @f0800_tot_cajas_bono_aprobadas,"
        csql += "f0800_costo_total_bono_aprobado = @f0800_costo_total_bono_aprobado,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("@f0800_funcionario_aprueba", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_aprobado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_tot_cajas_aprobadas", NpgsqlDbType.Integer).Value = CInt(tx_unidades_aprobadas.Text)
        ocmd.Parameters.Add("@f0800_costo_total_aprobado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_aprobado.Text)

        ocmd.Parameters.Add("@f0800_tot_cajas_bono_aprobadas", NpgsqlDbType.Integer).Value = CInt(tx_unidades_bono_aprobadas.Text)
        ocmd.Parameters.Add("@f0800_costo_total_bono_aprobado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_bono_aprobado.Text)

        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub tx_valor_aprobado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_valor_aprobado.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_valor_aprobado_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_valor_aprobado.Validating
        If tx_valor_aprobado.Text.ToString = "" Or IsNumeric(tx_valor_aprobado.Text.ToString) = False Then
            tx_valor_aprobado.Text = "0"
        End If
        Dim valor_p As Decimal = tx_valor_aprobado.Text
        tx_valor_aprobado.Text = valor_p.ToString("C2")
    End Sub

    Private Sub tx_unidades_aprobadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_unidades_aprobadas.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_unidades_aprobadas_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_unidades_aprobadas.Validating
        If tx_unidades_aprobadas.Text.ToString = "" Or IsNumeric(tx_unidades_aprobadas.Text.ToString) = False Then
            tx_unidades_aprobadas.Text = "0"
        End If
        tx_total_unidades_aprobadas.Text = CInt(tx_unidades_aprobadas.Text) + CInt(tx_unidades_bono_aprobadas.Text)
    End Sub

    Private Sub tx_unidades_bono_aprobadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_unidades_bono_aprobadas.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_unidades_bono_aprobadas_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_unidades_bono_aprobadas.Validating
        If tx_unidades_bono_aprobadas.Text.ToString = "" Or IsNumeric(tx_unidades_bono_aprobadas.Text.ToString) = False Then
            tx_unidades_bono_aprobadas.Text = "0"
        End If
        tx_total_unidades_aprobadas.Text = CInt(tx_unidades_aprobadas.Text) + CInt(tx_unidades_bono_aprobadas.Text)
    End Sub

    Private Sub validar_unidades_aprobadas()
        If tx_unidades_aprobadas.Text = "0" Then
            vmensaje_requisitos = "Identifique la cantidad de cajas que esta aprobando. El valor debe ser diferente de 0"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub bt_negar_Click(sender As Object, e As EventArgs) Handles bt_negar.Click
        If tx_id_despacho.Text = "" Then
            Exit Sub
        End If
        'Pregunta si realmente desea NEGAR
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Negar Despacho", "Desea NEGAR este despacho?")
        If respuesta = "N" Then
            Exit Sub
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_niega = @f0800_funcionario_niega,"
        csql += "f0800_fecha_negacion = @f0800_fecha_negacion,"
        csql += "f0800_negado = @f0800_negado,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("@f0800_funcionario_niega", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fecha_negacion", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_negado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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
        If verror = "N" Then
            MsgBox("Pedido Negado")
            Dispose()
        End If
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        'Pregunta si realmente desea anular
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Registro", "Desea ANULAR este registro?")
        If respuesta = "N" Then
            Exit Sub
        End If
        'primero debo anular el movimiento de inventarios
        anular_documento_contable()
        If verror = "S" Then
            Exit Sub
        End If
        'Anular el documento de remision
        anular_remision()
        If verror = "S" Then
            Exit Sub
        End If
        'Anular el despacho
        anular_despacho()

        If verror = "N" Then
            MsgBox("Pedido Anulado")
            Dispose()
        End If
    End Sub

    Private Sub anular_despacho()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_anulado = @f0800_anulado,"
        csql += "f0800_usuario_anular = @f0800_usuario_anular,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("@f0800_anulado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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
    Private Sub anular_documento_contable()
        cl_utilidades_gestion_compras.anular_documento("IR", vg_usuario_autoriza, vg_id_cia)

    End Sub
    Private Sub anular_remision()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_anulado = @f0800_anulado,"
        csql += "f0800_usuario_anular = @f0800_usuario_anular,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("@f0800_anulado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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
    Private Sub bt_facturar_Click(sender As Object, e As EventArgs) Handles bt_facturar.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Factura", "Desea reportar la facturacion del pedido?")
        If respuesta = "N" Then
            Exit Sub
        End If

        verror_requisitos = "N"
        validar_unidades_facturadas()
        validar_remision_factura()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        verror = "N"
        grabar_facturacion()
        If verror = "N" Then
            cargar_otb_info_despacho()
            llenar_form_info_despacho()
            MsgBox("Facturacion Registrada", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub grabar_facturacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_factura = @f0800_funcionario_factura,"
        csql += "f0800_fecha_factura = @f0800_fecha_factura,"
        csql += "f0800_facturado = @f0800_facturado,"
        csql += "f0800_total_cajas_facturadas = @f0800_total_cajas_facturadas,"
        csql += "f0800_costo_total_facturado = @f0800_costo_total_facturado,"
        csql += "f0800_id_remision = @f0800_id_remision,"
        csql += "f0800_id_factura = @f0800_id_factura,"
        csql += "f0800_costo_flete_calculado = @f0800_costo_flete_calculado,"
        csql += "f0800_id_doc_bono = @f0800_id_doc_bono,"
        csql += "f0800_tot_cajas_bono_factura = @f0800_tot_cajas_bono_factura,"
        csql += "f0800_costo_total_bono_factura = @f0800_costo_total_bono_factura,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("@f0800_funcionario_factura", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fecha_factura", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_facturado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_total_cajas_facturadas", NpgsqlDbType.Integer).Value = CInt(tx_unidades_facturadas.Text)
        ocmd.Parameters.Add("@f0800_costo_total_facturado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_facturado.Text)
        ocmd.Parameters.Add("@f0800_costo_flete_calculado", NpgsqlDbType.Numeric).Value = CDec(tx_flete_calculado.Text)
        If tx_remision.Text.ToString.Trim = "" Then
            ocmd.Parameters.Add("@f0800_id_remision", NpgsqlDbType.Varchar).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0800_id_remision", NpgsqlDbType.Varchar).Value = tx_remision.Text.ToString
        End If
        If tx_factura.Text.ToString.Trim = "" Then
            ocmd.Parameters.Add("@f0800_id_factura", NpgsqlDbType.Varchar).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0800_id_factura", NpgsqlDbType.Varchar).Value = tx_factura.Text.ToString
        End If

        If tx_id_bono.Text.ToString.Trim = "" Then
            ocmd.Parameters.Add("@f0800_id_doc_bono", NpgsqlDbType.Varchar).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0800_id_doc_bono", NpgsqlDbType.Varchar).Value = tx_id_bono.Text.ToString
        End If
        ocmd.Parameters.Add("@f0800_tot_cajas_bono_factura", NpgsqlDbType.Integer).Value = CInt(tx_unidades_bono_facturadas.Text)
        ocmd.Parameters.Add("@f0800_costo_total_bono_factura", NpgsqlDbType.Numeric).Value = CDec(tx_valor_bono_factura.Text)
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub tx_unidades_facturadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_unidades_facturadas.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_unidades_facturadas_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_unidades_facturadas.Validating
        If tx_unidades_facturadas.Text.ToString = "" Or IsNumeric(tx_unidades_facturadas.Text.ToString) = False Then
            tx_unidades_facturadas.Text = "0"
        End If
        tx_unidades_totales_factura.Text = CInt(tx_unidades_facturadas.Text) + CInt(tx_unidades_bono_facturadas.Text)
    End Sub

    Private Sub validar_unidades_facturadas()
        If tx_unidades_facturadas.Text = "0" Then
            vmensaje_requisitos = "Identifique la cantidad de cajas que esta Facturando. El valor debe ser diferente de 0"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_remision_factura()
        If tx_remision.Text.Trim = "" And tx_factura.Text.Trim = "" Then
            vmensaje_requisitos = "Identifique una Remision y/o una Factura"
            verror_requisitos = "S"
        End If
        If tx_remision.Text.Trim = "" And tx_factura.Text.Trim <> "" Then
            vmensaje_requisitos = "Identifique una Remision"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub tx_valor_facturado_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_valor_facturado.Validating
        If tx_valor_facturado.Text.ToString = "" Or IsNumeric(tx_valor_facturado.Text.ToString) = False Then
            tx_valor_facturado.Text = "0"
        End If
        Dim valor_p As Decimal = tx_valor_facturado.Text
        tx_valor_facturado.Text = valor_p.ToString("C2")
    End Sub

    Private Sub tx_flete_calculado_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_flete_calculado.Validating
        If tx_flete_calculado.Text.ToString = "" Or IsNumeric(tx_flete_calculado.Text.ToString) = False Then
            tx_flete_calculado.Text = "0"
        End If
        Dim valor_p As Decimal = tx_flete_calculado.Text
        tx_flete_calculado.Text = valor_p.ToString("C2")
    End Sub

    Private Sub tx_unidades_bono_facturadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_unidades_bono_facturadas.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_unidades_bono_facturadas_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_unidades_bono_facturadas.Validating
        If tx_unidades_bono_facturadas.Text.ToString = "" Or IsNumeric(tx_unidades_bono_facturadas.Text.ToString) = False Then
            tx_unidades_bono_facturadas.Text = "0"
        End If
        tx_unidades_totales_factura.Text = CInt(tx_unidades_facturadas.Text) + CInt(tx_unidades_bono_facturadas.Text)
    End Sub

    Private Sub tx_valor_bono_factura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_valor_bono_factura.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_valor_bono_factura_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_valor_bono_factura.Validating

    End Sub

    Private Sub bt_guia_Click(sender As Object, e As EventArgs) Handles bt_guia.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Guia Transportadora", "Desea reportar la guia asignada por la transportadora?")
        If respuesta = "N" Then
            Exit Sub
        End If

        verror_requisitos = "N"
        validar_guia_transportadora()
        validar_transportadora_despacho()
        validar_unidades_despachas()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        verror = "N"
        actualizar_guia_trans()
        cargar_otb_info_despacho()
        llenar_form_info_despacho()
        If verror = "N" Then
            MsgBox("Guia Transportadora Registrada", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub actualizar_guia_trans()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_registra_guia_transp = @f0800_funcionario_registra_guia_transp,"
        csql += "f0800_fecha_registro_guia_transp = @f0800_fecha_registro_guia_transp,"
        csql += "f0800_transportadora = @f0800_transportadora,"
        csql += "f0800_guia_transportadora = @f0800_guia_transportadora,"
        csql += "f0800_tot_cajas_despachadas = @f0800_tot_cajas_despachadas,"
        csql += "f0800_guia_registrada = @f0800_guia_registrada,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_guia_trans(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub crear_parametros_guia_trans(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0800_funcionario_registra_guia_transp", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fecha_registro_guia_transp", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_transportadora", NpgsqlDbType.Varchar).Value = cm_transportadora_despacho.SelectedValue
        ocmd.Parameters.Add("@f0800_guia_transportadora", NpgsqlDbType.Varchar).Value = tx_guia_transportadora.Text.ToString.Trim
        ocmd.Parameters.Add("@f0800_tot_cajas_despachadas", NpgsqlDbType.Integer).Value = CInt(tx_unidades_despachadas.Text)
        ocmd.Parameters.Add("@f0800_guia_registrada", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub

    Private Sub validar_guia_transportadora()
        If tx_guia_transportadora.Text.Trim = "" Then
            vmensaje_requisitos = "Identifique el numero de guia de la transportadora"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_transportadora_despacho()
        If cm_transportadora_despacho.SelectedIndex = -1 Then
            vmensaje_requisitos = "Identifique la transportadora por la que realiza el despacho."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub tx_unidades_despachadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_unidades_despachadas.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_unidades_despachadas_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_unidades_despachadas.Validating
        If tx_unidades_despachadas.Text.ToString = "" Then
            tx_unidades_despachadas.Text = "0"
        End If
    End Sub

    Private Sub validar_unidades_despachas()
        If CInt(tx_unidades_despachadas.Text) = 0 Then
            vmensaje_requisitos = "Identifique las unidades que esta despachando."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub bt_verificacion_recepcion_Click(sender As Object, e As EventArgs) Handles bt_verificacion_recepcion.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Verificacion con Cliente", "Desea Reportar Retroalimentacion del cliente sobre mercancia Recibida?")
        If respuesta = "N" Then
            Exit Sub
        End If
        verror_requisitos = "N"
        validar_info_cliente_recibo()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        verror = "N"
        actualizar_verificacion_recepcion()
        If verror = "N" Then
            cargar_otb_info_despacho()
            llenar_form_info_despacho()
            MsgBox("Verificacion Recepcion Registrada", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub actualizar_verificacion_recepcion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_verifica_recibo = @f0800_funcionario_verifica_recibo,"
        csql += "f0800_fecha_verifica_recibo = @f0800_fecha_verifica_recibo,"
        csql += "f0800_info_cliente_recibo = @f0800_info_cliente_recibo,"
        csql += "f0800_costo_total_despachado = @f0800_costo_total_despachado,"
        csql += "f0800_recibo_verificado = @f0800_recibo_verificado,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_verificacion_recepcion(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub crear_parametros_verificacion_recepcion(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0800_funcionario_verifica_recibo", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fecha_verifica_recibo", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_info_cliente_recibo", NpgsqlDbType.Varchar).Value = tx_info_cliente_recibo.Text.Trim
        ocmd.Parameters.Add("@f0800_costo_total_despachado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_despachado.Text)
        ocmd.Parameters.Add("@f0800_recibo_verificado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub

    Private Sub validar_info_cliente_recibo()
        If tx_info_cliente_recibo.Text.Trim = "" Then
            vmensaje_requisitos = "Registre el funcionario del cliente y sus observaciones respecto a este despacho."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub tx_valor_despachado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_valor_despachado.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_valor_despachado_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_valor_despachado.Validating
        If tx_valor_despachado.Text.ToString = "" Or IsNumeric(tx_valor_despachado.Text.ToString) = False Then
            tx_valor_despachado.Text = "0"
        End If
        Dim valor_p As Decimal = tx_valor_despachado.Text
        tx_valor_despachado.Text = valor_p.ToString("C2")
    End Sub

    Private Sub bt_recepcion_cumplido_Click(sender As Object, e As EventArgs) Handles bt_recepcion_cumplido.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Cumplido", "Desea reportar el cumplido de la transportadora?")
        If respuesta = "N" Then
            Exit Sub
        End If

        verror_requisitos = "N"
        validar_id_cumplido()
        validar_soportes_cumplido_transportadora()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        verror = "N"
        actualizar_recepcion_cumplido()
        If verror = "N" Then
            cargar_otb_info_despacho()
            llenar_form_info_despacho()
            MsgBox("Cumplido Registrado", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub actualizar_recepcion_cumplido()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_cumplido_transp = @f0800_funcionario_cumplido_transp,"
        csql += "f0800_fecha_cumplido_transp = @f0800_fecha_cumplido_transp,"
        csql += "f0800_id_cumplido_transp = @f0800_id_cumplido_transp,"
        csql += "f0800_cumplido_recibido = @f0800_cumplido_recibido,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_recepcion_cumplido(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub crear_parametros_recepcion_cumplido(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0800_funcionario_cumplido_transp", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fecha_cumplido_transp", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_id_cumplido_transp", NpgsqlDbType.Varchar).Value = tx_id_cumplido_transportadora.Text.Trim
        ocmd.Parameters.Add("@f0800_cumplido_recibido", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub

    Private Sub validar_id_cumplido()
        If tx_id_cumplido_transportadora.Text.Trim = "" Then
            vmensaje_requisitos = "Registre el codigo de cumplido de la transportadora."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_soportes_cumplido_transportadora()
        If lb_total_soportes_cumplido.Text = 0 Then
            vmensaje_requisitos = "Registre documentacion soporte del cumplido."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub bt_reclamacion_Click(sender As Object, e As EventArgs) Handles bt_reclamacion.Click
        If tx_id_despacho.Text = "" Then
            Exit Sub
        End If
        If tx_id_accion.Text = "" Then
            'Pregunta si realmente desea reportar
            Dim respuesta As String = "N"
            respuesta = comunes.g_mensaje_YesNo("Reportar Reclamo", "Desea reportar una reclamacion del cliente?")
            If respuesta = "N" Then
                Exit Sub
            End If

            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_reportar_falla As New camocontrol.fm_0100_reportar_falla_maquina
            'oform_grilla_programacion.ods_hijo = ods
            oform_reportar_falla.vf_oform_padre = Me
            oform_reportar_falla.vg_id_cia = vg_id_cia
            oform_reportar_falla.id_estructura = 0
            oform_reportar_falla.id_fuente_falla = "00000004"
            oform_reportar_falla.cm_fuente_accion.Enabled = False
            oform_reportar_falla.vg_usuario_autoriza = vg_usuario_autoriza
            oform_reportar_falla.retornar_numero_accion_creada = "S" 'la varibale publica id_accion de este formulario se llenara con el id_accion creada
            oform_reportar_falla.ShowDialog()
            If id_accion <> 0 Then
                tx_id_accion.Text = id_accion
                pnl_devolucion.Enabled = True

                actualizar_reclamo_creado()
            End If
        Else
            cl_utilidades_gestion_acciones.abrir_actividad(tx_id_accion.Text, vg_usuario_autoriza, vg_id_cia)
        End If
    End Sub

    Private Sub actualizar_reclamo_creado()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_id_accion = @f0800_id_accion,"
        csql += "f0800_g_reclamacion = @f0800_g_reclamacion,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_reclamo(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub crear_parametros_reclamo(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0800_id_accion", NpgsqlDbType.Integer).Value = id_accion
        ocmd.Parameters.Add("@f0800_g_reclamacion", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub

    Private Sub bt_devolucion_Click(sender As Object, e As EventArgs) Handles bt_devolucion.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Devolucion", "Desea reportar una devolucion del cliente?")
        If respuesta = "N" Then
            Exit Sub
        End If
        verror_requisitos = "N"
        validar_funcionario_devolucion()
        validar_informacion_devolucion()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        verror = "N"
        actualizar_devolucion()
        If verror = "N" Then
            tx_funcionario_registra_devolucion.Text = buscar_nombre_funcionario(vg_usuario_autoriza)
            MsgBox("Devolucion Registrada", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub actualizar_devolucion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_fecha_devolucion = @f0800_fecha_devolucion,"
        csql += "f0800_funcionario_recibe_devolucion = @f0800_funcionario_recibe_devolucion,"
        csql += "f0800_info_devolucion = @f0800_info_devolucion,"
        csql += "f0800_g_devolucion = @f0800_g_devolucion,"
        csql += "f0800_fecha_registro_devolucion = @f0800_fecha_registro_devolucion,"
        csql += "f0800_funcionario_registra_devolucion = @f0800_funcionario_registra_devolucion,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_devolucion(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub crear_parametros_devolucion(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0800_fecha_devolucion", NpgsqlDbType.Timestamp).Value = dtp_fecha_recibo_devolucion.Value
        ocmd.Parameters.Add("@f0800_funcionario_recibe_devolucion", NpgsqlDbType.Varchar).Value = cm_funcionario_recibe_devolucion.SelectedValue
        ocmd.Parameters.Add("@f0800_g_devolucion", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_info_devolucion", NpgsqlDbType.Varchar).Value = tx_informacion_devolucion.Text
        ocmd.Parameters.Add("@f0800_fecha_registro_devolucion", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_funcionario_registra_devolucion", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub

    Private Sub validar_funcionario_devolucion()
        If cm_funcionario_recibe_devolucion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Identifique el funcionario que recibio la devolucion."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_informacion_devolucion()
        If tx_informacion_devolucion.Text.Trim = "" Then
            vmensaje_requisitos = "Registre informacion relevante de la devolucion (Cantiades, Causas, etc)."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub bt_gestionar_tercero_Click(sender As Object, e As EventArgs) Handles bt_gestionar_tercero.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim gestion_terceros As New camocontrol.fm_0200_tercero
        'oform_grilla_programacion.ods_hijo = ods
        gestion_terceros.vf_oform_padre = Me
        gestion_terceros.vg_id_cia = vg_id_cia
        gestion_terceros.vg_usuario_autoriza = vg_usuario_autoriza
        gestion_terceros.ShowDialog()
    End Sub

    Private Sub bt_nuevo_soporte_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo_soporte.Click
        If tx_id_despacho.Text.Trim = "" Then
            Exit Sub
        End If
        cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-DRC", tx_id_despacho.Text, vg_id_cia, vg_usuario_autoriza, "N")
        calcular_archivos_asociados_cumplido()
    End Sub

    Private Sub bt_ver_archivos_asociados_Click(sender As System.Object, e As System.EventArgs) Handles bt_ver_archivos_asociados.Click
        csql = "SELECT f0503_id_archivo as id_file, f0503_ed as documento, f0503_descripcion_archivo as descripcion," _
            & " to_char(f0503_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_carga" _
            & " from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
            & " where f0503_nombre_archivo = '" & new_name_file & "' and f0503_id_cia = '" & vg_id_cia & "'"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_archivos As New camocontrol.fm_visor_datos
        oform_mostrar_archivos.vf_oform_padre = Me
        oform_mostrar_archivos.csql = csql
        oform_mostrar_archivos.titulo_formulario = "Facturas Compras"
        oform_mostrar_archivos.vg_id_cia = vg_id_cia
        oform_mostrar_archivos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_archivos.ShowDialog()
    End Sub

    Private Sub calcular_archivos_asociados_cumplido()
        lb_total_soportes_cumplido.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-DRC-001", tx_id_despacho.Text, vg_id_cia)
    End Sub

    Private Sub bt_nueva_nota_Click(sender As System.Object, e As System.EventArgs) Handles bt_nueva_nota.Click
        If tx_id_despacho.Text = "" Then
            Exit Sub
        End If
        Dim id_documento As Integer = CInt(tx_id_despacho.Text)
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_nuevo_seg_accion As New camocontrol.fm_0600_gestion_seguimiento
        'oform_grilla_programacion.ods_hijo = ods
        oform_nuevo_seg_accion.vf_oform_padre = Me
        oform_nuevo_seg_accion.vg_id_cia = vg_id_cia
        oform_nuevo_seg_accion.tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-PDC-001", vg_id_cia)
        oform_nuevo_seg_accion.id_accion = id_documento
        oform_nuevo_seg_accion.vf_elemento_nuevo = "S"
        oform_nuevo_seg_accion.vg_usuario_autoriza = vg_usuario_autoriza
        oform_nuevo_seg_accion.ShowDialog()
        lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas("TN-PDC-001", id_documento, vg_id_cia)
    End Sub

    Private Sub bt_consultar_notas_Click(sender As System.Object, e As System.EventArgs) Handles bt_consultar_notas.Click
        If tx_id_despacho.Text = "" Then
            Exit Sub
        End If
        Dim id_documento As Integer = CInt(tx_id_despacho.Text)
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
            & " where f0606_id_documento = '" & id_documento & "'" & " and f0606_tipo_nota = 'PDC'" _
            & " order by f0606_fecha_fin desc"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos  '
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.titulo_formulario = "Listado de Seguimientos"
        oform_mostrar_datos.ocontexto_form = "Anotaciones Recepciones MP e Insumos"
        oform_mostrar_datos.id_oreg_padre = id_documento
        oform_mostrar_datos.ShowDialog()
        lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas("TN-PDC-001", id_documento, vg_id_cia)
    End Sub

    Private Sub bt_cerrar_pedido_Click(sender As Object, e As EventArgs) Handles bt_cerrar_pedido.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Cumplido", "Desea reportar el cierre del Pedido?")
        If respuesta = "N" Then
            Exit Sub
        End If

        verror_requisitos = "N"

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        verror = "N"
        actualizar_cierre_pedido()
        If verror = "N" Then
            cargar_otb_info_despacho()
            llenar_form_info_despacho()
            MsgBox("Cumplido Registrado", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub actualizar_cierre_pedido()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_cierra = @f0800_funcionario_cierra,"
        csql += "f0800_fecha_cierre = @f0800_fecha_cierre,"
        csql += "f0800_despacho_cerrado = @f0800_despacho_cerrado,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_cierre_pedido(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString)
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

    Private Sub crear_parametros_cierre_pedido(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0800_funcionario_cierra", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fecha_cierre", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_despacho_cerrado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub


End Class
