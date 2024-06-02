Public Class fm_0300_facturas_compras_recepcion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_recepcion_compras As Integer 'se asigna cuando se llama al formulario desde el fm_padre

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

    Private otb_proveedores As DataTable
    Private otb_solicitudes As DataTable
    Private otb_items_programados As DataTable
    Private otb_info_personal As DataTable
    Private otb_info_factura As DataTable

    Private path_file As String = ""
    Private extension As String = ""
    Private new_name_file As String = ""
    Private new_path_file As String = ""
    Private oaprovada As String = "N" 'Indica si la factura ya esta aprovada
    Private ocosto As Decimal = 0 'Acumulara el valor de cada item para obtener el costo total


    Private Sub fm_0300_facturas_compras_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_creacion.Value = comunes.g_fechahora
        dtp_fecha_creacion.Format = DateTimePickerFormat.Custom
        dtp_fecha_creacion.CustomFormat = "yyyy/MM/dd  hh:mm tt"
        dtp_fecha_creacion.Enabled = False

        tx_id_recepcion.ReadOnly = True
        tx_estado.ReadOnly = True
        tx_id_item_cons_mov.ReadOnly = True
        'bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_generar_informe.Enabled = False
        'bt_aprobar.Enabled = False
        bt_aprobar_recepcion.Enabled = False
        cargar_proveedores()
        cargar_personal()

        If vf_elemento_nuevo = "S" Then
            tx_estado.Text = "Nuevo"
            cm_nit.SelectedIndex = -1
            cm_proveedor.SelectedIndex = -1
            cm_responsable.SelectedIndex = -1
        Else
            cargar_elemento_existente()
            llenar_items_solicitados()
        End If
    End Sub
    Private Sub activar_botones_aprobaciones()
        Select Case tx_estado.Text
            Case "Sin Aprobar Recepcion"
                cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_aprobar_recepcion, "")
                'bt_aprobar.Enabled = False
            Case "Recepcion Aprobada"
                'cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_aprobar, "")
                bt_aprobar_recepcion.Enabled = False
            Case Else
                'bt_aprobar.Enabled = False
                bt_aprobar_recepcion.Enabled = False
        End Select
    End Sub
    Private Sub inicializar_campos()
        tx_id_recepcion.Text = ""
        tx_estado.Text = "Sin Aprobar"
        'cm_proveedor.SelectedIndex = -1
        'cm_nit.SelectedIndex = -1
        cm_proveedor.Focus()
        tx_factura_proveedor.Text = ""
        tx_id_item_sc.Text = ""
        dg_listado.Rows.Clear()
        oaprovada = "N"
        vf_elemento_nuevo = "S"
        tx_valor_factura.Text = "$0.00"
        dtp_fecha_factura.Value = comunes.g_fechahora
        dtp_vencimiento_factura.Value = comunes.g_fechahora
    End Sub
    Private Sub cargar_elemento_existente()
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0319_recepciones_compras" _
            & " where f0319_id_recepcion = '" & id_recepcion_compras & "'"
        otb_info_factura = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_factura.Rows
            tx_id_recepcion.Text = orow("f0319_id_recepcion")
            ' If orow("f0307_aprobada") = "N" Then
            'If orow("f0307_recepcion_aprobada") = "S" Then
            'tx_estado.Text = "Recepcion Aprobada"
            'Else
            'tx_estado.Text = "Sin Aprobar Recepcion"
            'End If
            'Else
            'tx_estado.Text = "Aprobada"
            'End If
            cm_proveedor.SelectedValue = orow("f0319_id_tercero")
            cm_nit.SelectedValue = orow("f0319_id_tercero")
            tx_factura_proveedor.Text = orow("f0319_factura_proveedor")
            oaprovada = orow("f0319_aprobada")
            dtp_fecha_factura.Value = orow("f0307_fecha_factura")
            dtp_vencimiento_factura.Value = orow("f0307_fecha_vencimiento_factura")
            activar_botones_aprobaciones()
        Next
    End Sub
    Private Sub cargar_personal()
        csql = "select f0200_id_tercero," _
            & " trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" & " and f0200_ind_empleado = 'S'" _
            & " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        With cm_responsable
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_personal
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub
    Private Sub cargar_proveedores()
        csql = "select *, trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2 || ' - ' || f0200_id) as razon_social" _
            & " FROM " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_ind_principal = 'S'"
        '& " and f0200_id_cia ='" & vg_id_cia & "'"
        otb_proveedores = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_proveedor
            'Valor que se muestra al usuario
            .DisplayMember = "razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_proveedores
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.Text = ""
        End With
        With cm_nit
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_id"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_proveedores
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.Text = ""
        End With
    End Sub
    Private Sub llenar_items_solicitados()
        dg_listado.Rows.Clear()
        csql = "select tb0305_items_solicitados.*, f0300_id_item, f0300_codigo_cguno," _
            & " f0300_descripcion_item || ' - ' || f0300_referencia || ' - ' || f0300_contenido_x_empaque as descripcion," _
            & " f0305_ampliacion_item as descripcion_comp," _
            & " f0002_sigla_unidad_medicion," _
            & " to_char(f0305_costo_unitario_planificado,'LFM999,999,999.00') as costo_unitario," _
            & " to_char((f0305_costo_unitario_planificado*f0305_cantidad),'LFM999,999,999.00') as costo_subtotal," _
            & " to_char(f0305_costo_total_planificado,'LFM999,999,999.00') as costo_total," _
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
                & " on f0304_id_estructura = otb_estructura_referida.f0100_id_estructura" _
            & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as otb_estructura_madre" _
                & " on otb_estructura_referida.f0100_id_maquina_padre = otb_estructura_madre.f0100_id_estructura" _
            & " where f0305_id_recepcion_compras = '" & tx_id_recepcion.Text.ToString.Trim & "'"
        otb_items_programados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        ocosto = 0
        For Each orow As DataRow In otb_items_programados.Rows
            agregar_fila_items(orow)
            ocosto += orow("f0305_costo_total_planificado")
        Next
        tx_valor_factura.Text = ocosto.ToString("C2")
    End Sub
    Private Sub agregar_fila_items(ByVal orow As DataRow)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow


        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0305_id_solicitud_compra"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0305_id_item_solicitud"))
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
        otextgrid.Value = orow.Item("f0305_cantidad").ToString
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

        'crea columna 9
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("costo_unitario").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 10
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("costo_subtotal").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 11
        otextgrid = New DataGridViewTextBoxCell
        Dim result As String = String.Format("{0:0.0%}", orow.Item("f0305_descuento"))
        otextgrid.Value = result
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 12
        otextgrid = New DataGridViewTextBoxCell
        Dim result2 As String = String.Format("{0:0.0%}", orow.Item("f0305_iva"))
        otextgrid.Value = result2
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'crea columna 13
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("costo_total").ToString
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
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0305_anotacion_item").ToString
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
    Private Sub validar_factura_Aprovada()
        If oaprovada = "S" Then
            vmensaje_requisitos = "Una factura aprovada no se puede modificar"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_proveedor()
        If cm_nit.SelectedIndex = -1 Or cm_proveedor.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione un proveedor"
            verror_requisitos = "S"
            cm_nit.Text = ""
            cm_proveedor.Text = ""
        End If
    End Sub
    Private Sub validar_factura_cliente()
        If tx_factura_proveedor.Text.Trim = "" Then
            vmensaje_requisitos = "Registre el numero de factura del proveedor"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validaciones()
        validar_proveedor()
        validar_factura_Aprovada()
        validar_factura_cliente()
    End Sub
    Private Sub cm_nit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_nit.Validating
        If cm_nit.SelectedIndex <> -1 Then
            cm_proveedor.SelectedValue = cm_nit.SelectedValue
        Else
            cm_nit.Text = ""
            cm_proveedor.Text = ""
        End If
    End Sub
    Private Sub cm_proveedor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_proveedor.Validating
        If cm_proveedor.SelectedIndex <> -1 Then
            cm_nit.SelectedValue = cm_proveedor.SelectedValue
        Else
            cm_nit.Text = ""
            cm_proveedor.Text = ""
        End If
    End Sub
    Private Sub grabar_nuevo_grupo_recepcion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0319_recepciones_compras" _
                & " (f0319_id_cia, f0319_id_tercero," _
                & " f0319_usuario_modificar, f0319_usuario_crear, f0319_fm)" _
                & " VALUES" _
                & " (@f0319_id_cia, @f0319_id_tercero," _
                & " @f0319_usuario_modificar, @f0319_usuario_crear, @f0319_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_nuevo_grupo_recepcion(ocmd)

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
            tx_id_recepcion.Text = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0307_id_recepcion_compras", "f0307_usuario_crear", vg_usuario_autoriza, "tb0307_facturas_compras")
            id_recepcion_compras = tx_id_recepcion.Text
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-FCC-001", vg_id_cia)
            new_name_file += "-" & tx_id_recepcion.Text.PadLeft(8, "0")
            If vf_elemento_nuevo = "S" Then
                tx_estado.Text = "Sin Aprobar Recepcion"
            End If
            vf_elemento_nuevo = "N"
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_nuevo_grupo_recepcion(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            'ocmd.Parameters.Add("@f0307_id_recepcion_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text.ToString
        End If
        ocmd.Parameters.Add("@f0319_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0319_id_tercero", NpgsqlDbType.Varchar).Value = cm_nit.SelectedValue
        ocmd.Parameters.Add("@f0319_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub grabar_nuevo_item_recepcion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0308_items_recibidos" _
                & " (f0308_id_cia, f0308_id_item_solicitud, f0308_cantidad," _
                & " f0308_usuario_modificar, f0308_usuario_crear, f0308_fm)" _
                & " VALUES" _
                & " (@f0308_id_cia, @f0308_id_item_solicitud, @f0308_cantidad," _
                & " @f0308_usuario_modificar, @f0308_usuario_crear, @f0308_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_nuevo_grupo_recepcion(ocmd)

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
            tx_id_recepcion.Text = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0307_id_recepcion_compras", "f0307_usuario_crear", vg_usuario_autoriza, "tb0307_facturas_compras")
            id_recepcion_compras = tx_id_recepcion.Text
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-FCC-001", vg_id_cia)
            new_name_file += "-" & tx_id_recepcion.Text.PadLeft(8, "0")
            If vf_elemento_nuevo = "S" Then
                tx_estado.Text = "Sin Aprobar Recepcion"
            End If
            vf_elemento_nuevo = "N"
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_nuevo_item_recepcion(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            'ocmd.Parameters.Add("@f0307_id_recepcion_compras", NpgsqlDbType.Integer).Value = tx_id_factura.Text.ToString
        End If
        ocmd.Parameters.Add("@f0319_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0319_id_tercero", NpgsqlDbType.Varchar).Value = cm_nit.SelectedValue
        ocmd.Parameters.Add("@f0319_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0319_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub actualizar_factura()
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
        csql += " where f0307_id_recepcion_compras = @f0307_id_recepcion_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_nuevo_grupo_recepcion(ocmd)
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
            grabar_nuevo_grupo_recepcion()
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-FCC-001", vg_id_cia)
            new_name_file += "-" & tx_id_recepcion.Text.PadLeft(8, "0")
        Else
            actualizar_factura()
        End If
        If verror = "N" Then
            activar_botones_aprobaciones()
            MsgBox("Grabado")
        End If
    End Sub

    Private Sub aprobar_items_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_factura_c_aprov = 'S'"
        csql += " where f0305_id_recepcion_compras = '" & tx_id_recepcion.Text.ToString & "' and f0305_anulado = 'N'"

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
    Private Sub aprobar_recepcion_factura()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0307_facturas_compras set "
        csql += "f0307_recepcion_aprobada = 'S',"
        csql += "f0307_fecha_aprobacion_recepcion = @f0307_fecha_aprobacion_recepcion,"
        csql += "f0307_usuario_aprobar_recepcion = @f0307_usuario_aprobar_recepcion"
        csql += " where f0307_id_recepcion_compras = @f0307_id_recepcion_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_aprobar_recepcion_facturas(ocmd)
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
    Private Sub crear_parametros_aprobar_recepcion_facturas(ByVal ocmd As NpgsqlCommand)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0307_id_recepcion_compras", NpgsqlDbType.Integer).Value = tx_id_recepcion.Text.ToString
        End If
        ocmd.Parameters.Add("@f0307_fecha_aprobacion_recepcion", NpgsqlDbType.Timestamp).Value = ofecha
        ocmd.Parameters.Add("@f0307_usuario_aprobar_recepcion", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub
    Private Sub entrada_inventario_items_factura()

    End Sub
    Private Sub bt_aprobar_recepcion_Click(sender As System.Object, e As System.EventArgs) Handles bt_aprobar_recepcion.Click
        If tx_id_recepcion.Text.ToString = "" Or dg_listado.Rows.Count = 0 Then
            Exit Sub
        End If
        aprobar_recepcion_factura()
        If verror = "N" Then
            tx_estado.Text = "Recepcion Aprobada"
            MsgBox("Recepcion de MP y/o Insumos aprobados", MsgBoxStyle.Information, "Aprobado")
            activar_botones_aprobaciones()
            bt_aprobar_recepcion.Enabled = False
            'bt_aprobar.Enabled = False
        End If
    End Sub
    Private Sub bt_add_item_Click(sender As System.Object, e As System.EventArgs) Handles bt_add_item.Click
        adicionar_items_factura()
    End Sub
    Private Sub adicionar_items_factura()
        If tx_id_item_sc.Text.ToString.Trim = "" Then
            Exit Sub
        End If
        If tx_id_recepcion.Text.Trim = "" Then
            verror_requisitos = "N"
            validaciones()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                verror = "N"
                grabar_nuevo_grupo_recepcion()
                If verror = "S" Then
                    Exit Sub
                End If
            End If
        End If
        Dim otb_info_item As DataTable
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_item_solicitud = '" & tx_id_item_sc.Text.Trim & "'"
        otb_info_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        verror_requisitos = "N"
        validar_factura_Aprovada()
        'Valida que exista el registro
        If otb_info_item.Rows.Count = 0 Then
            vmensaje_requisitos = "El Item no existe"
            verror_requisitos = "S"
        End If
        'Valida que no se halla utilizado antes
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_recepcion_compras")) = False Then
                vmensaje_requisitos = "El item ya fue facturado en el registro: " & orow("f0305_id_recepcion_compras")
                verror_requisitos = "S"
            End If
        Next
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Abro la informacion del item
        abrir_form_info_item(tx_id_item_sc.Text.Trim)
        'Actualizo el item
        actualizar_item_solicitado("S")
        If verror = "N" Then
            MsgBox("Registrado", MsgBoxStyle.Information, "Vinculado")
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
        If tx_id_recepcion.Text.Trim = "" Then
            Exit Sub
        End If
        Dim otb_info_item As DataTable
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
            & " where f0305_id_item_solicitud = '" & tx_id_item_sc.Text.Trim & "'"
        otb_info_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        verror_requisitos = "N"
        validar_factura_Aprovada()
        'Valida que exista el registro
        If otb_info_item.Rows.Count = 0 Then
            vmensaje_requisitos = "El Item no existe"
            verror_requisitos = "S"
        End If
        'Valida que no se halla utilizado antes en otra factura
        For Each orow As DataRow In otb_info_item.Rows
            If IsDBNull(orow("f0305_id_recepcion_compras")) = False Then
                If orow("f0305_id_recepcion_compras").ToString <> tx_id_recepcion.Text Then
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
        actualizar_item_solicitado("N")
        If verror = "N" Then
            MsgBox("Borrado", MsgBoxStyle.Information, "Eliminar")
            tx_id_item_sc.Text = ""
            llenar_items_solicitados()
        End If
    End Sub
    Private Sub actualizar_item_solicitado(vincular As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_id_recepcion_compras = @f0305_id_recepcion_compras,"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_modificar = @f0305_usuario_modificar"
        csql += " where f0305_id_item_solicitud = '" & tx_id_item_sc.Text.Trim & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_facturas(ocmd)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vincular = "S" Then
            ocmd.Parameters.Add("@f0305_id_recepcion_compras", NpgsqlDbType.Integer).Value = tx_id_recepcion.Text.ToString
        Else
            ocmd.Parameters.Add("@f0305_id_recepcion_compras", NpgsqlDbType.Integer).Value = DBNull.Value
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
            Case "dgocell_id_sc"
                tx_sol_compra.Text = dg_listado.CurrentRow.Cells("dgocell_id_sc").Value
                abrir_info_solicitud_compra(tx_sol_compra.Text)
                tx_sol_compra.Text = ""
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
        End Select
    End Sub
    Private Sub abrir_info_solicitud_compra(id_sc As String)
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_agregar_solicitud As New camocontrol.fm_0300_sc_solicitud
        oform_agregar_solicitud.vf_oform_padre = Me
        oform_agregar_solicitud.vg_id_cia = vg_id_cia
        oform_agregar_solicitud.id_solicitud_compra = tx_sol_compra.Text
        oform_agregar_solicitud.vg_usuario_autoriza = vg_usuario_autoriza
        oform_agregar_solicitud.vf_elemento_nuevo = "N"
        oform_agregar_solicitud.ShowDialog()
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
        cargar_proveedores()
    End Sub

    Private Sub bt_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo.Click
        inicializar_campos()
    End Sub
    Private Sub bt_solicitud_compra_Click(sender As System.Object, e As System.EventArgs) Handles bt_solicitud_compra.Click
        If tx_sol_compra.Text.Trim = "" Then
            Exit Sub
        End If
        abrir_info_solicitud_compra(tx_sol_compra.Text)
        tx_sol_compra.Text = ""
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        If vf_elemento_nuevo = "S" Then
            Exit Sub
        End If
        verror = "N"
        liberar_item_solicitud()
        If verror = "N" Then
            anular_factura()
        End If
        If verror = "N" Then
            MsgBox("Factura Anulada", MsgBoxStyle.Information)
            Dispose()
        Else
            MsgBox("Error anulando", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub anular_factura()
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
        csql += " where f0307_id_recepcion_compras = @f0307_id_recepcion_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_recepcion_facturas(ocmd)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0307_numero_factura", NpgsqlDbType.Varchar).Value = "ANU" & tx_id_recepcion.Text.ToString
        ocmd.Parameters.Add("@f0307_id_recepcion_compras", NpgsqlDbType.Integer).Value = tx_id_recepcion.Text.ToString
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

    Private Sub liberar_item_solicitud()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_id_recepcion_compras = null,"
        csql += "f0305_factura_c_aprov = 'N',"
        csql += "f0305_fm = @f0305_fm,"
        csql += "f0305_usuario_modificar = @f0305_usuario_modificar"
        csql += " where f0305_id_recepcion_compras = @f0305_id_recepcion_compras"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_aprobar_facturas(ocmd)
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0305_id_recepcion_compras", NpgsqlDbType.Integer).Value = tx_id_recepcion.Text.ToString
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
End Class
