Public Class fm_0800_programacion_despacho
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
    Private verror_cargue As String = "N"
    Private cargue_bloqueado As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private orowgrid As DataGridViewRow
    Private ocmb_grid As DataGridViewComboBoxCell
    Private otextgrid As DataGridViewTextBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell
    Private obuttongrid As DataGridViewButtonCell
    Private olinkcell As DataGridViewLinkCell

    Private ofactura As String = ""
    Private veditar_factura As String = "N"
    Private otb_ciudades As DataTable
    Private otb_unidad_tiempo As DataTable
    Private otb_tercero As DataTable
    Private otb_info_personal As DataTable
    Private otb_info_despacho As DataTable
    Private otb_accion As DataTable
    Private otb_remisiones As DataTable
    Private otb_items_remisiones As DataTable
    Private direccionOriginal As String = String.Empty
    Private pedido_en_edicion As String = "N"

    Private Sub fm0800_programacion_despacho_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-PDC"
        vf_var_config_notas = "TN-PDC-001"
        vf_id_notas_archivos = id_despacho
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)

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
        bt_grabar.Enabled = False
        bt_editar.Enabled = False
        bt_nuevo.Enabled = False
        bt_anular.Enabled = False
        bt_generar_informe.Enabled = False
        tx_funcionario_registra_pedido.Enabled = False
        tx_funcionario_registra_guia_transp.Enabled = False
        tx_funcionario_verifica_recibo.Enabled = False
        tx_funcionario_registra_cumplido_transp.Enabled = False
        tx_funcionario_registra_devolucion.Enabled = False
        tx_funcionario_cierra_pedido.Enabled = False
        dtp_fecha_registro_devolucion.Enabled = False
        tx_id_accion.Enabled = False
        tx_unidades_guia.Text = "0"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_registro.Format = DateTimePickerFormat.Custom
        dtp_fecha_registro.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_registro.Enabled = False
        'dtp_fecha_registro.Value = comunes.g_fechahora

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_registro_guia.Format = DateTimePickerFormat.Custom
        dtp_fecha_registro_guia.CustomFormat = "yyyy/MM/dd  HH:mm:ss"
        dtp_fecha_registro_guia.Enabled = True

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

        csql = "select f0200_id_tercero, ltrim(f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres,' ') as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" _
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

        csql = "select f0200_id_tercero, f0200_id, f0200_nombres" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " order by f0200_nombres"
        Dim otb_tercero_proveedor = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim otb_transportadora_despacho As DataTable = otb_tercero_proveedor.Copy
        With cm_transportadora_despacho
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_nombres"
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
            Llenar_form_info_despacho()



            'Para el control de documentos asociados al registro del soporte del cumplido
            calcular_archivos_asociados_cumplido()
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-DRC-001", vg_id_cia)
            new_name_file += "-" & tx_id_despacho.Text.PadLeft(8, "0")

            'habilitar_aprobaciones()
            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_anular, ocontexto_form)
        End If
        cargar_dg_remisiones()
        cargar_dg_items()
    End Sub
    Private Sub cargar_dg_remisiones()
        'llenar informacion de productos a despachar
        dg_remisiones.AllowUserToAddRows = False
        dg_remisiones.AllowUserToDeleteRows = False
        dg_remisiones.AllowUserToResizeColumns = True
        dg_remisiones.AllowUserToResizeRows = False
        dg_remisiones.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        'dg_remisiones.DataSource = otb_remisiones
        csql = "select f0850_id_rm as id_rm, f0850_rm as rm, f0850_num_factura as fv," _
            & " f0850_bonificado as bonificado" _
            & " from " & database.obtener_esquema & ".tb0850_remisiones_cguno_encabezado" _
            & " where f0850_id_despacho = '" & id_despacho & "'"
        otb_remisiones = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_remisiones.Rows
            agregar_fila_remisiones(orow)
        Next
        'dg_remisiones.AutoResizeColumns()
    End Sub
    Private Sub agregar_fila_remisiones(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1 -- esta oculta
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("id_rm")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2 -- esta oculta
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("rm")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3 -- esta oculta
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("fv")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3 -- esta oculta
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item("bonificado") = "N" Then
            ochkgrid.Value = False
        Else
            ochkgrid.Value = True
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ochkgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_remisiones.Rows.Add(orowgrid)
    End Sub
    Private Sub cargar_dg_items()
        verror_cargue = "N"
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-05", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        otb_items_remisiones = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_items_rms.AllowUserToAddRows = False
        dg_items_rms.AllowUserToDeleteRows = False
        dg_items_rms.AllowUserToResizeColumns = True
        dg_items_rms.AllowUserToResizeRows = False
        dg_items_rms.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_items_rms.DataSource = otb_items_remisiones
        dg_items_rms.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dg_items_rms.Columns("ped").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Alineado a la derecha
        dg_items_rms.Columns("car").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Alineado a la derecha
        Dim unid_ped As Decimal = 0
        Dim unid_car As Decimal = 0
        Dim odiferencia As Decimal = 0
        pnl_reg_guia.BackColor = Color.Lime
        For Each orow As DataRow In otb_items_remisiones.Rows
            unid_ped += CDec(orow("ped"))
            unid_car += CDec(orow("car"))
            odiferencia = unid_ped - unid_car
            Select Case odiferencia
                Case < 0
                    pnl_reg_guia.BackColor = Color.HotPink
                Case > 0
                    pnl_reg_guia.BackColor = Color.Yellow
            End Select
        Next
        tx_unidades_solicitadas.Text = unid_ped
        tx_unidades_despachadas.Text = unid_car
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
        pnl_reg_guia.Enabled = False
        pnl_verif_cliente.Enabled = False
        pnl_cumplido_transportadora.Enabled = False
        pnl_devolucion.Enabled = False
        pnl_cierre_despacho.Enabled = False
        pnl_DireccionDespacho.Enabled = False
    End Sub

    Private Sub cargar_info_terceros()
        csql = "select f0200_id_tercero, f0200_id, f0200_nombres" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
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
        With cm_razon_social
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_nombres"
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
            & " join " & database.obtener_esquema & ".tb0200_terceros as tb_cliente" _
            & " on f0800_cliente = tb_cliente.f0200_id_tercero" _
            & " where f0800_id_despacho = '" & id_despacho & "'"
        otb_info_despacho = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub

    Private Sub Llenar_form_info_despacho()
        'bloquear paneles
        bloquear_paneles()

        cargar_otb_info_despacho()
        For Each orow As DataRow In otb_info_despacho.Rows
            tx_id_despacho.Text = orow("f0800_id_despacho")
            If orow("f0800_direccion_destino").ToString <> String.Empty Then
                tx_direccion.Text = orow("f0800_direccion_destino")
            Else
                tx_direccion.Text = orow("f0200_direccion_residencia")
            End If
            tx_funcionario_registra_pedido.Text = buscar_nombre_funcionario(orow("f0800_usuario_crear"))
            dtp_fecha_registro.Value = orow("f0800_fr")
            cm_nit.SelectedValue = orow("f0800_cliente")
            cm_asesor.SelectedValue = orow("f0800_vendedor")
            cm_ciudad_destino.SelectedValue = orow("f0800_id_ciudad_destino")
            'cm_transportadora.SelectedValue = orow("f0800_transportadora_programada")
            'tx_unidades_pedidas.Text = orow("f0800_tot_cajas_cotizadas")

            If orow("f0800_guia_registrada") = "N" Then
                pnl_reg_guia.Enabled = True
                lb_titulo.Text = "Pedido Pendiente Asignar Guia Transp."
                GoTo line1
            Else
                tx_funcionario_registra_guia_transp.Text = buscar_nombre_funcionario(orow("f0800_funcionario_registra_guia_transp"))
                cm_transportadora_despacho.SelectedValue = orow("f0800_transportadora")
                tx_guia_transportadora.Text = orow("f0800_guia_transportadora").ToString
                tx_unidades_despachadas.Text = orow("f0800_tot_cajas_despachadas").ToString
                tx_unidades_guia.Text = orow("f0800_tot_cajas_registro_guia").ToString
                dtp_fecha_registro_guia.Value = orow("f0800_fecha_despacho")
                cargue_bloqueado = "S" 'Para bloquear la edicion de datos de cajas cargadas en el form cargar cajas
                If orow("f0800_cumplido_recibido") = "N" Then
                    'pnl_reg_guia.Enabled = True
                Else
                    'pnl_reg_guia.Enabled = False
                End If
            End If
            If orow("f0800_guia_registrada") = "S" And orow("f0800_recibo_verificado") = "N" Then
                pnl_verif_cliente.Enabled = True
                lb_titulo.Text = "Pedido Pendiente Verificar Recibo Cliente"
                GoTo line1
            Else
                tx_funcionario_verifica_recibo.Text = buscar_nombre_funcionario(orow("f0800_funcionario_verifica_recibo"))
                dtp_fecha_verificacion_recibo.Value = orow("f0800_fecha_verifica_recibo")
                tx_info_cliente_recibo.Text = orow("f0800_info_cliente_recibo").ToString
                gb_soportes_cumplido.Enabled = True
            End If
            If orow("f0800_recibo_verificado") = "S" And orow("f0800_cumplido_recibido") = "N" Then
                pnl_cumplido_transportadora.Enabled = True
                lb_titulo.Text = "Pedido Pendiente Recibir Cumplido Transportadora"
                tx_id_cumplido_transportadora.Text = orow("f0800_guia_transportadora").ToString
                GoTo line1
            Else
                tx_funcionario_registra_cumplido_transp.Text = buscar_nombre_funcionario(orow("f0800_funcionario_cumplido_transp"))
                dtp_fecha_cumplido.Value = orow("f0800_fecha_cumplido_transp")
                tx_id_cumplido_transportadora.Text = orow("f0800_id_cumplido_transp").ToString
            End If
            If orow("f0800_cumplido_recibido") = "S" And orow("f0800_despacho_cerrado") = "N" Then
                pnl_cierre_despacho.Enabled = True
                lb_titulo.Text = "Pedido Pendiente por Cerrar"
                GoTo line1
            Else
                'dtp_fecha_cierre_pedido.Value = orow("f0800_fecha_cierre")
                tx_funcionario_cierra_pedido.Text = buscar_nombre_funcionario(orow("f0800_funcionario_cierra"))
            End If
line1:
            If orow("f0800_g_reclamacion") = "S" Then
                tx_id_accion.Text = orow("f0800_id_accion").ToString
                If tx_id_accion.Text <> "" Then
                    csql = "select * from " & database.obtener_esquema & ".tb0600_acciones" _
                        & " where f0600_id_accion = '" & tx_id_accion.Text & "'"
                    Dim otb_accion As DataTable
                    otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                    For Each orow_acc As DataRow In otb_accion.Rows
                        tx_texto_reclamo.Text = orow_acc("f0600_descripcion")
                    Next
                End If
                pnl_devolucion.Enabled = True
            End If
            If orow("f0800_g_devolucion") = "S" Then
                dtp_fecha_registro_devolucion.Value = orow("f0800_fecha_registro_devolucion")
                tx_funcionario_registra_devolucion.Text = buscar_nombre_funcionario(orow("f0800_funcionario_registra_devolucion"))
                cm_funcionario_recibe_devolucion.SelectedValue = orow("f0800_funcionario_recibe_devolucion")
                dtp_fecha_recibo_devolucion.Value = orow("f0800_fecha_devolucion")
                tx_informacion_devolucion.Text = orow("f0800_info_devolucion")
                tx_docto_devolucion.Text = orow("f0800_docto_devolucion")
            End If

        Next
    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click

        verror_requisitos = "N"
        validar_cliente()
        validar_ciudad()
        validar_vendedor()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            Dim id_creado As Integer
            id_creado = grabar_nuevo_pedido()
            If verror = "N" Then
                Dim despacho_creado As String = ""
                despacho_creado = id_creado  'cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0800_id_despacho", "f0800_usuario_crear", vg_usuario_autoriza, "tb0800_despachos_comercial")
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
    Private Function grabar_nuevo_pedido()
        Dim id_creado As Integer = 0
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0800_despachos_comercial" _
                & " (f0800_id_cia, f0800_id_cotizacion, f0800_fecha_cotizacion," _
                & " f0800_vendedor, f0800_funcionario_cotizacion, f0800_cliente," _
                & " f0800_id_ciudad_destino, f0800_costo_total_cotizado," _
                & " f0800_fecha_programacion_despacho," _
                & " f0800_tot_cajas_bono_cotizadas, f0800_costo_total_bono_cotizado," _
                & " f0800_usuario_modificar, f0800_usuario_crear, f0800_fm)" _
                & " VALUES" _
                & " (@f0800_id_cia, @f0800_id_cotizacion, @f0800_fecha_cotizacion," _
                & " @f0800_vendedor, @f0800_funcionario_cotizacion, @f0800_cliente," _
                & " @f0800_id_ciudad_destino, @f0800_costo_total_cotizado," _
                & " @f0800_fecha_programacion_despacho," _
                & " @f0800_tot_cajas_bono_cotizadas, @f0800_costo_total_bono_cotizado," _
                & " @f0800_usuario_modificar, @f0800_usuario_crear, @f0800_fm)" _
                & " RETURNING f0800_id_despacho"

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
                id_creado = ocmd.ExecuteScalar()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        Return id_creado
    End Function

    Private Sub crear_parametros_pedido(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0800_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        'ocmd.Parameters.Add("@f0800_id_cotizacion", NpgsqlDbType.Varchar).Value = tx_cotizacion.Text
        ocmd.Parameters.Add("@f0800_fecha_cotizacion", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_vendedor", NpgsqlDbType.Varchar).Value = cm_asesor.SelectedValue
        ocmd.Parameters.Add("@f0800_funcionario_cotizacion", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_cliente", NpgsqlDbType.Varchar).Value = cm_razon_social.SelectedValue
        ocmd.Parameters.Add("@f0800_id_ciudad_destino", NpgsqlDbType.Varchar).Value = cm_ciudad_destino.SelectedValue
        'ocmd.Parameters.Add("@f0800_costo_total_cotizado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_pedido_cliente.Text)
        'ocmd.Parameters.Add("@f0800_fecha_programacion_despacho", NpgsqlDbType.Timestamp).Value = dtp_programacion_despacho.Value
        'ocmd.Parameters.Add("@f0800_tot_cajas_bono_cotizadas", NpgsqlDbType.Integer).Value = tx_unidades_bono_pedido.Text
        'zocmd.Parameters.Add("@f0800_costo_total_bono_cotizado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_bono_pedido.Text)
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
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
        'ocmd.Parameters.Add("@f0800_id_cotizacion", NpgsqlDbType.Varchar).Value = tx_cotizacion.Text
        ocmd.Parameters.Add("@f0800_fecha_cotizacion", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_vendedor", NpgsqlDbType.Varchar).Value = cm_asesor.SelectedValue
        ocmd.Parameters.Add("@f0800_funcionario_cotizacion", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_cliente", NpgsqlDbType.Varchar).Value = cm_razon_social.SelectedValue
        ocmd.Parameters.Add("@f0800_id_ciudad_destino", NpgsqlDbType.Varchar).Value = cm_ciudad_destino.SelectedValue
        'ocmd.Parameters.Add("@f0800_costo_total_cotizado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_pedido_cliente.Text)
        'ocmd.Parameters.Add("@f0800_fecha_programacion_despacho", NpgsqlDbType.Timestamp).Value = dtp_programacion_despacho.Value
        ocmd.Parameters.Add("@f0800_aprobado", NpgsqlDbType.Varchar).Value = "N"
        ocmd.Parameters.Add("@f0800_revisado", NpgsqlDbType.Varchar).Value = "N"
        ocmd.Parameters.Add("@f0800_facturado", NpgsqlDbType.Varchar).Value = "N"
        ocmd.Parameters.Add("@f0800_id_cumplido_transp", NpgsqlDbType.Varchar).Value = DBNull.Value
        ocmd.Parameters.Add("@f0800_id_factura", NpgsqlDbType.Varchar).Value = DBNull.Value
        ocmd.Parameters.Add("@f0800_id_remision", NpgsqlDbType.Varchar).Value = DBNull.Value
        'ocmd.Parameters.Add("@f0800_tot_cajas_bono_cotizadas", NpgsqlDbType.Integer).Value = tx_unidades_bono_pedido.Text
        'ocmd.Parameters.Add("@f0800_costo_total_bono_cotizado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_bono_pedido.Text)
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

    Private Sub tx_unidades_pedidas_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub validar_cliente()
        If cm_nit.SelectedIndex = -1 Or cm_razon_social.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione un Cliente"
            verror_requisitos = "S"
            cm_nit.Text = ""
            'cm_razon_social_2.Text = ""
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

    Private Sub ValidarDireccionDestino()
        If tx_direccion.Text.Trim = "" Then
            vmensaje_requisitos = "Identifique la direccion destino del despacho."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        'Solo el administrador puede eliminar el despacho en cualquier etapa.
        If vg_usuario_autoriza <> "00000001" Then
            If pnl_reg_guia.Enabled = False Then
                MsgBox("Un despacho con guia asignada no puede anularse", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
        End If

        'Pregunta si realmente desea anular
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Registro", "Desea ANULAR este registro?")
        If respuesta = "N" Then
            Exit Sub
        End If

        Dim cant_notas_actual As Integer = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(vf_otipo_nota, id_despacho, vg_id_cia)
        'Obligar justificacion de anulacion.
        Dim registro_explicacion As String = "N"
        Dim oencabezado As String = "Justificacion de anulacion de despacho."
        registro_explicacion = cl_gestion_anotaciones.obligar_anotacion(oencabezado, "Justificación de Anulacion", vg_usuario_autoriza, id_despacho, vf_otipo_nota, vg_id_cia)
        If registro_explicacion = "N" Then
            MsgBox("Es obligatorio justificar la anulacion del despacho!", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        Dim cant_notas_nueva As Integer = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(vf_otipo_nota, id_despacho, vg_id_cia)
        'MsgBox(cant_notas_nueva)
        If cant_notas_actual = cant_notas_nueva Then
            MsgBox("Es obligatorio justificar la anulacion del despacho!", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If

        'Liberar todas las cajas cargadas
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-09", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        cl_utilidades_datatables.ejecutar_csql(csql)

        'ANULAR LOS DOCUMENTOS CONTABLES QUE MUEVEN INVENTARIOS DE BODEGA
        csql = "select f0850_rm, f0310_id_documento" _
            & " from camocontrol.tb0850_remisiones_cguno_encabezado" _
                & " Join camocontrol.tb0310_documentos_movimientos_inventarios" _
                    & " on f0850_rm = f0310_documento_contabilidad and f0310_anulado = 'N'" _
                    & " and coalesce((string_to_array(f0310_id_documento_origen,'-'))[2]::int,0) = f0850_id_rm" _
            & " where f0850_id_despacho = '" & id_despacho & "'"
        Dim otb_remisiones_desp As DataTable
        otb_remisiones_desp = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_remisiones_desp.Rows
            cl_utilidades_gestion_compras.anular_documento(orow("f0310_id_documento"), vg_usuario_autoriza, vg_id_cia)
        Next

        'ANULAR LAS REMISIONES ASIGNADAS
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-10", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        csql = csql.Replace("$002$", vg_usuario_autoriza)
        cl_utilidades_datatables.ejecutar_csql(csql)


        'ANULAR EL DESPACHO
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
        If verror = "N" Then
            MsgBox("Despacho Anulado")
            Dispose()
        End If
    End Sub

    Private Sub bt_guia_Click(sender As Object, e As EventArgs) Handles bt_guia.Click
        'Informamos si hay diferencia entre lo pedido y lo despachado
        If verror_cargue = "S" Then
            MsgBox("Alerta, Hay DIFERENCIA entre lo pedido y lo despachado", MsgBoxStyle.Critical, "Info")
            MsgBox("Alerta, Hay DIFERENCIA entre lo pedido y lo despachado", MsgBoxStyle.Critical, "Info")
            'Exit Sub
        End If
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Guia Transportadora", "Desea reportar la guia asignada por la transportadora?")
        If respuesta = "N" Then
            Exit Sub
        End If

        verror_requisitos = "N"
        validar_unidades_guia()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Identifico que hay una diferncia entre unidades cargadas o pistoliadas y las unidades de la guia
        If CDec(tx_unidades_despachadas.Text) <> CDec(tx_unidades_guia.Text) Then
            'si ademas las unidades de la guia son diferentes a las unidades del pedido hay un problema que debe explicarse
            If CDec(tx_unidades_solicitadas.Text) <> CDec(tx_unidades_guia.Text) Then
                MsgBox("Debe explicar diferencia entre unidades reportadas en la guia y las unidades despachadas.", MsgBoxStyle.Exclamation, "Error")
                verror_cargue = "S"
            End If
        End If

        If verror_cargue = "S" Then
            Dim usuario_nota As String = comunes.traer_nombre_usuario(vg_usuario_autoriza)
            Dim encabezado As String = "Asignacion de Guia con diferencias identificadas." & vbCrLf
            encabezado += "El usuario: " & usuario_nota & " Justifica el despacho con descuadre " _
                & "( " & tx_unidades_solicitadas.Text & " unidades solicitadas vs " & tx_unidades_despachadas.Text _
                & " unidades despachadas vs " & tx_unidades_guia.Text & " unidades guia ) asi:" & vbCrLf
            encabezado = UCase(encabezado)
            Dim cant_not_actual As Integer = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(vf_otipo_nota, id_despacho, vg_id_cia)
            Dim anot As String = cl_gestion_anotaciones.obligar_anotacion(encabezado, "Justificacion del Despacho", vg_usuario_autoriza, id_despacho, vf_otipo_nota, vg_id_cia)
            If anot = "N" Then
                'MsgBox("No anota nada")
                vmensaje_requisitos = "Debe Justificar su decisión de despachar con diferecias en cantidades identificadas."
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                'MsgBox("Anota")
                bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(vf_otipo_nota, id_despacho, vg_id_cia)
            End If

            'Valido que se halla creado una nueva nota donde se explica el cargue con descuadre
            Dim nueva_cant_notas As Integer = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(vf_otipo_nota, id_despacho, vg_id_cia)
            If nueva_cant_notas <= cant_not_actual Then
                Exit Sub
            End If
        End If

        verror_requisitos = "N"
        validar_guia_transportadora()
        validar_transportadora_despacho()
        validar_unidades_guia()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        verror = "N"
        actualizar_guia_trans()
        cargar_otb_info_despacho()
        Llenar_form_info_despacho()
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
        csql += "f0800_fecha_despacho = @f0800_fecha_despacho,"
        csql += "f0800_transportadora = @f0800_transportadora,"
        csql += "f0800_guia_transportadora = @f0800_guia_transportadora,"
        csql += "f0800_tot_cajas_aprobadas = @f0800_tot_cajas_aprobadas,"
        csql += "f0800_tot_cajas_despachadas = @f0800_tot_cajas_despachadas,"
        csql += "f0800_tot_cajas_registro_guia = @f0800_tot_cajas_registro_guia,"
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
        ocmd.Parameters.Add("@f0800_fecha_despacho", NpgsqlDbType.Timestamp).Value = dtp_fecha_registro_guia.Value
        ocmd.Parameters.Add("@f0800_transportadora", NpgsqlDbType.Varchar).Value = cm_transportadora_despacho.SelectedValue
        ocmd.Parameters.Add("@f0800_guia_transportadora", NpgsqlDbType.Varchar).Value = tx_guia_transportadora.Text.ToString.Trim
        ocmd.Parameters.Add("@f0800_tot_cajas_aprobadas", NpgsqlDbType.Integer).Value = CDec(tx_unidades_solicitadas.Text)
        ocmd.Parameters.Add("@f0800_tot_cajas_despachadas", NpgsqlDbType.Integer).Value = CDec(tx_unidades_despachadas.Text)
        ocmd.Parameters.Add("@f0800_tot_cajas_registro_guia", NpgsqlDbType.Integer).Value = CDec(tx_unidades_guia.Text)
        ocmd.Parameters.Add("@f0800_guia_registrada", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub

    Private Sub anular_guia_trans()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set "
        csql += "f0800_funcionario_registra_guia_transp = @f0800_funcionario_registra_guia_transp,"
        csql += "f0800_fecha_registro_guia_transp = @f0800_fecha_registro_guia_transp,"
        csql += "f0800_fecha_despacho = @f0800_fecha_despacho,"
        csql += "f0800_transportadora = @f0800_transportadora,"
        csql += "f0800_guia_transportadora = @f0800_guia_transportadora,"
        csql += "f0800_tot_cajas_aprobadas = @f0800_tot_cajas_aprobadas,"
        csql += "f0800_tot_cajas_despachadas = @f0800_tot_cajas_despachadas,"
        csql += "f0800_tot_cajas_registro_guia = @f0800_tot_cajas_registro_guia,"
        csql += "f0800_guia_registrada = @f0800_guia_registrada,"
        csql += "f0800_fm = @f0800_fm,"
        csql += "f0800_usuario_modificar = @f0800_usuario_modificar"
        csql += " where f0800_id_despacho = @f0800_id_despacho"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_guia_trans(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("@f0800_funcionario_registra_guia_transp", NpgsqlDbType.Varchar).Value = ""
        ocmd.Parameters.Add("@f0800_fecha_registro_guia_transp", NpgsqlDbType.Timestamp).Value = DBNull.Value
        ocmd.Parameters.Add("@f0800_fecha_despacho", NpgsqlDbType.Timestamp).Value = DBNull.Value
        ocmd.Parameters.Add("@f0800_transportadora", NpgsqlDbType.Varchar).Value = ""
        ocmd.Parameters.Add("@f0800_guia_transportadora", NpgsqlDbType.Varchar).Value = ""
        ocmd.Parameters.Add("@f0800_tot_cajas_aprobadas", NpgsqlDbType.Integer).Value = 0
        ocmd.Parameters.Add("@f0800_tot_cajas_despachadas", NpgsqlDbType.Integer).Value = 0
        ocmd.Parameters.Add("@f0800_tot_cajas_registro_guia", NpgsqlDbType.Integer).Value = 0
        ocmd.Parameters.Add("@f0800_guia_registrada", NpgsqlDbType.Varchar).Value = "N"
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

    Private Sub validar_unidades_guia()
        If tx_unidades_guia.Text = "0" Then
            vmensaje_requisitos = "Identifique las unidades reportadas en la guia de la transportadora. No puede ser 0"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub tx_unidades_despachadas_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
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
            Llenar_form_info_despacho()
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
        'ocmd.Parameters.Add("@f0800_costo_total_despachado", NpgsqlDbType.Numeric).Value = CDec(tx_valor_despachado.Text)
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
            Llenar_form_info_despacho()
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
            oform_reportar_falla.id_tercero = cm_razon_social.SelectedValue
            oform_reportar_falla.cm_nit.Enabled = False
            oform_reportar_falla.cm_razon_social.Enabled = False
            oform_reportar_falla.bt_cambiar_infraestructura.Enabled = False
            oform_reportar_falla.lb_titulo.Text = "Reporte de Reclamación de Cliente"
            oform_reportar_falla.id_estructura = 0
            oform_reportar_falla.id_fuente_falla = "00000004"
            oform_reportar_falla.otipo_docto_padre = vf_otipo_nota
            oform_reportar_falla.id_docto_padre = id_despacho

            oform_reportar_falla.cm_fuente_accion.Enabled = False
            oform_reportar_falla.vg_usuario_autoriza = vg_usuario_autoriza
            'oform_reportar_falla.tx_estructura.Text = "Reclamacion Cliente"
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
        If tx_docto_devolucion.Text.Trim <> "" Then
            cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(tx_docto_devolucion.Text.Trim, vg_usuario_autoriza, vg_id_cia, "N", "N", "E", "N", "S", "S", "S", "S")
            Exit Sub
        End If
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

        'Genero el movimiento de inventario
        Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(15, vg_id_cia)
        Dim cod_documento As String = "DEV-" & consecutivo.ToString.PadLeft(8, "0")
        cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, 12, 15, comunes.g_fechahora, vg_usuario_autoriza, vg_id_cia)
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(cod_documento, vg_usuario_autoriza, vg_id_cia, "S", "N", "E", "N", "S", "S", "S", "S")
        tx_docto_devolucion.Text = cod_documento
        tx_informacion_devolucion.Text = "Documento de Devolucion: " & cod_documento & vbCrLf & tx_informacion_devolucion.Text

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
        csql += "f0800_docto_devolucion = @f0800_docto_devolucion,"
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
        ocmd.Parameters.Add("@f0800_docto_devolucion", NpgsqlDbType.Varchar).Value = tx_docto_devolucion.Text
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
            Llenar_form_info_despacho()
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

    Private Sub bt_registrar_caja_Click(sender As Object, e As EventArgs) Handles bt_registrar_caja.Click
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_reg_cajas As New camocontrol.fm_0800_cargar_cajas_despacho
        oform_reg_cajas.vf_oform_padre = Me
        oform_reg_cajas.vg_id_cia = vg_id_cia
        oform_reg_cajas.vg_usuario_autoriza = vg_usuario_autoriza
        oform_reg_cajas.id_despacho = id_despacho
        oform_reg_cajas.cargue_bloqueado = cargue_bloqueado
        oform_reg_cajas.ShowDialog()
        cargar_dg_items()
    End Sub
    Private Sub dg_items_rms_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_items_rms.CellFormatting
        ' If the column is the Artist column, check the
        ' value.
        If dg_items_rms.Columns(e.ColumnIndex).Name _
            = "car" Then
            If e.Value IsNot Nothing Then
                Dim cant_ped As Integer = dg_items_rms.Rows.Item(e.RowIndex).Cells("ped").Value
                Dim cant_car As Integer = e.Value
                Dim odif As Integer = cant_ped - cant_car
                Select Case odif
                    Case 0
                        e.CellStyle.BackColor = Color.Green
                    Case Is > 0
                        e.CellStyle.BackColor = Color.Yellow
                        verror_cargue = "S"
                    Case Is < 0
                        e.CellStyle.BackColor = Color.Red
                        verror_cargue = "S"
                End Select
            End If
        End If
    End Sub

    Private Sub bt_nuevo_soporte_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo_soporte.Click
        If tx_id_despacho.Text.Trim = "" Then
            Exit Sub
        End If
        cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-DRC", tx_id_despacho.Text, vg_id_cia, vg_usuario_autoriza, "N")
        calcular_archivos_asociados_cumplido()
    End Sub

    Private Sub calcular_archivos_asociados_cumplido()
        lb_total_soportes_cumplido.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-DRC-001", tx_id_despacho.Text, vg_id_cia)
    End Sub

    Private Sub bt_ver_archivos_asociados_Click(sender As Object, e As EventArgs) Handles bt_ver_archivos_asociados.Click
        csql = "SELECT f0503_id_archivo as id_file, f0503_ed as documento, f0503_descripcion_archivo as descripcion," _
                            & " to_char(f0503_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_carga" _
                            & " from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
                            & " where f0503_nombre_archivo = '" & new_name_file & "' and f0503_id_cia = '" & vg_id_cia & "'"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_archivos As New camocontrol.fm_visor_datos
        oform_mostrar_archivos.vf_oform_padre = Me
        oform_mostrar_archivos.csql = csql
        oform_mostrar_archivos.titulo_formulario = "Documentacion soporte Recibido por el Cliente."
        oform_mostrar_archivos.vg_id_cia = vg_id_cia
        oform_mostrar_archivos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_archivos.ShowDialog()
    End Sub

    Private Sub tx_unidades_guia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_unidades_guia.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_unidades_guia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_unidades_guia.Validating
        If tx_unidades_guia.Text.Trim = "" Then
            tx_unidades_guia.Text = "0"
        End If
    End Sub

    Private Sub bt_anular_guia_Click(sender As Object, e As EventArgs) Handles bt_anular_guia.Click
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Guia", "Desea Anular la Guia de la Transportadora?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'Dim cant_notas_actual As Integer = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(vf_otipo_nota, id_despacho, vg_id_cia)
        'Obligar justificacion de anulacion.
        Dim registro_explicacion As String = "N"
        Dim oencabezado As String = "Justificacion de anulacion de Guia."
        Dim info_complemento As String = "Información Anulada:" & vbCrLf
        info_complemento += "Numero de Guia: " & tx_guia_transportadora.Text & vbCrLf
        info_complemento += "Fecha Guia: " & dtp_fecha_registro_guia.Text & vbCrLf
        info_complemento += "Guia registrada por: " & tx_funcionario_registra_guia_transp.Text & vbCrLf
        info_complemento += "Transportadora: " & cm_transportadora_despacho.Text & vbCrLf
        info_complemento += "Unidades Guia: " & tx_unidades_guia.Text & vbCrLf
        info_complemento += "Unidades Pedido: " & tx_unidades_solicitadas.Text & vbCrLf
        info_complemento += "Unidades Cargadas: " & tx_unidades_despachadas.Text
        registro_explicacion = cl_gestion_anotaciones.obligar_anotacion(oencabezado,
                                                                        "Justificación de Anulacion",
                                                                        vg_usuario_autoriza,
                                                                        id_despacho,
                                                                        vf_otipo_nota,
                                                                        vg_id_cia,
                                                                        info_complemento)
        If registro_explicacion = "N" Then
            MsgBox("Es obligatorio justificar la anulacion de la guia!", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        'Dim cant_notas_nueva As Integer = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(vf_otipo_nota, id_despacho, vg_id_cia)
        'MsgBox(cant_notas_nueva)
        'If cant_notas_actual = cant_notas_nueva Then
        'MsgBox("Es obligatorio justificar la anulacion del despacho!", MsgBoxStyle.Exclamation, "Info")
        'Exit Sub
        'End If
        anular_guia_trans()
        If verror = "N" Then
            dtp_fecha_registro_guia.Value = comunes.g_fechahora
            tx_funcionario_registra_guia_transp.Text = ""
            Llenar_form_info_despacho()
        Else
            MsgBox("Fallo anulando guia", MsgBoxStyle.Exclamation, "Info")
        End If
    End Sub

    Private Sub editar_remision_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "UPDATE " & database.obtener_esquema & ".tb0850_remisiones_cguno_encabezado SET"
        csql += " f0850_num_factura = @f0850_num_factura,"
        csql += " f0850_bonificado = @f0850_bonificado"
        csql += " where f0850_id_rm = @f0850_id_rm"
        csql += " and f0850_id_cia = @f0850_id_cia"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_remision_factura(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando personal! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar personal! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub crear_parametros_remision_factura(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If IsNothing(dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value) = True Then
            ocmd.Parameters.Add("@f0850_num_factura", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0850_num_factura", NpgsqlDbType.Varchar).Value = dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value.ToString.ToUpper().Trim
        End If
        If dg_remisiones.CurrentRow.Cells("dgocell_rms_bonificado").Value = True Then
            ocmd.Parameters.Add("@f0850_bonificado", NpgsqlDbType.Varchar).Value = "S"
        Else
            ocmd.Parameters.Add("@f0850_bonificado", NpgsqlDbType.Varchar).Value = "N"
        End If
        ocmd.Parameters.Add("@f0850_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0850_id_rm", NpgsqlDbType.Integer).Value = CInt(dg_remisiones.CurrentRow.Cells("dgocell_rms_id_rem").Value)
    End Sub

    Private Sub dg_remisiones_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dg_remisiones.CellEnter
        If dg_remisiones.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim nombre_columna As String = dg_remisiones.Columns(dg_remisiones.CurrentCell.ColumnIndex).Name
        If nombre_columna = "dgocell_rms_factura" Then
            If IsNothing(dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value) = True Then
                ofactura = ""
            Else
                ofactura = dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value.ToString.Trim
            End If
            'MsgBox("Hola entre " & dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value)
        End If
    End Sub

    Private Sub dg_remisiones_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dg_remisiones.RowValidating
        If dg_remisiones.CurrentRow.IsNewRow = True Then
            Exit Sub
        End If
        If dg_remisiones.IsCurrentRowDirty = False Then
            Exit Sub
        End If

        If IsNothing(dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value) = True Then
            dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value = ""
        End If
        If dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value.ToString.Trim.Length > 10 Then
            MsgBox("Se permiten maximo 10 caracteres", MsgBoxStyle.Information, "Error")
            dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value = ofactura
            Exit Sub
        End If

        Dim oeditar As String = "N"
        oeditar = cl_gestion_permisos.identificar_permisos_especiales_formularios("DEFIN_FACTURA", vf_otabla_permisos, vg_usuario_autoriza)
        If oeditar = "S" Then
            editar_remision_factura()
            If verror = "N" Then
                dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value = dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value.ToString.ToUpper()
                MsgBox("Factura definida", MsgBoxStyle.Information, "Actualizado")
            End If
        Else
            dg_remisiones.CurrentRow.Cells("dgocell_rms_factura").Value = ofactura
            MsgBox("No tiene permisos para editar esta informacion", MsgBoxStyle.Critical, "Cambio no realizado")
        End If
    End Sub

    Private Sub Btn_CambiarDireccion_Click(sender As Object, e As EventArgs) Handles Btn_CambiarDireccion.Click
        pnl_DireccionDespacho.Enabled = True
        direccionOriginal = cm_ciudad_destino.Text & " >> " & tx_direccion.Text
    End Sub

    Private Sub bt_GrabarNuevaDireccion_Click(sender As Object, e As EventArgs) Handles bt_GrabarNuevaDireccion.Click

        verror_requisitos = "N"
        ValidarDireccionDestino()
        validar_ciudad()

        If verror_requisitos = "S" Then
            Exit Sub
        End If

        'Creo una anotacion en el despacho registrando la direccion original segun factura y la direccion nueva del despacho.

        Dim usuario_nota As String = comunes.traer_nombre_usuario(vg_usuario_autoriza)
        Dim encabezado As String = "Cambio de direccion de entrega del despacho." & vbCrLf
        encabezado += "El usuario: " & usuario_nota & " realiza cambio en la direccion de recepcion del despacho asi:" _
                & vbCrLf & "Direccion Original: " & direccionOriginal _
                & vbCrLf & "Nueva Direccion: " & cm_ciudad_destino.Text & " >> " & tx_direccion.Text
        encabezado = UCase(encabezado)
        cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_despacho, encabezado, vf_otipo_nota, vg_id_cia, "")
        bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(vf_otipo_nota, id_despacho, vg_id_cia)


        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "UPDATE " & database.obtener_esquema & ".tb0800_despachos_comercial SET"
        csql += " f0800_id_ciudad_destino = '" & cm_ciudad_destino.SelectedValue & "',"
        csql += " f0800_direccion_destino = '" & tx_direccion.Text & "'"
        csql += " where f0800_id_despacho = " & id_despacho

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_remision_factura(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando personal! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar nueva direccion de despacho! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()

        If verror = "N" Then
            MsgBox("Direccion Actualizada", MsgBoxStyle.Information, "Actualizado")
            pnl_DireccionDespacho.Enabled = False
        End If

    End Sub
End Class
