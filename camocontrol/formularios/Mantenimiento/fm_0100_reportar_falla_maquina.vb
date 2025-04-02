Imports System.ComponentModel

Public Class fm_0100_reportar_falla_maquina
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public trasladar As String = "N"
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_fuente_falla As Integer = 0
    'Para retornar el numero de accion creado el formulario padre debe tener una variable publica "id_accion"
    Public retornar_numero_accion_creada As String = "N"
    'Para identificar el tipo de documento padre que genera la accion
    Public otipo_docto_padre As String = ""
    'Para identificar el consecutivo del documento padre
    Public id_docto_padre As Integer
    Public id_tercero As String = 0

    Private new_name_file As String = ""

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String

    Public id_estructura As Integer
    Private id_accion As Integer
    Private csql As String
    Private mef_seleccionado As Integer

    Private otb_subfuente As DataTable
    Private otb_info_mef As DataTable
    Private otb_info_personal As DataTable


    Private Sub fm_0100_reportar_falla_maquina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        ' Set the Format type and the CustomFormat string.
        dtp_fecha_ocurrencia.Format = DateTimePickerFormat.Custom
        dtp_fecha_ocurrencia.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_ocurrencia.Visible = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_cierre_correccion.Format = DateTimePickerFormat.Custom
        dtp_fecha_cierre_correccion.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_cierre_correccion.Visible = False

        csql = "SELECT f0611_id_sub_fuente as id, f0611_sub_fuente as descripcion" _
        & " FROM " & database.obtener_esquema & ".tb0611_mef_sub_fuentes_acc" _
        & " where f0611_id_fuente = " & id_fuente_falla
        otb_subfuente = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_subfuente_accion
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion"
            'Valor interno que almacena el objeto
            .ValueMember = "id"
            'Origen de Datos del ComboBox
            .DataSource = otb_subfuente
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = mef_seleccionado
        End With


        csql = "SELECT f0609_id_mef as id, f0609_mef as descripcion, f0612_id_sub_fuente" _
            & " FROM " & database.obtener_esquema & ".tb0609_modos_efectos_falla" _
            & " join " & database.obtener_esquema & ".tb0612_mef_x_sub_fuente on f0609_id_mef = f0612_id_mef"
        otb_info_mef = cl_utilidades_datatables.cargar_informacion_postgres(csql)


        bt_gestionar.Enabled = False
        tx_id_accion.ReadOnly = True
        tx_estructura.ReadOnly = True
        gb_soportes_falla.Enabled = False
        cargar_combos()
        If id_fuente_falla <> 0 Then
            cm_fuente_accion.SelectedValue = id_fuente_falla
        End If
        If id_estructura <> 0 Then
            tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura.ToString)
        End If
        'MsgBox(cm_fuente_accion.SelectedValue)
    End Sub
    Private Sub cargar_combos()
        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "' and f0200_ind_empleado = 'S'" _
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
            .SelectedIndex = -1
        End With

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0601_fuentes_acciones"
        Dim otb_fuentes As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_fuente_accion
            'Valor que se muestra al usuario
            .DisplayMember = "f0601_descriptor_fuente"
            'Valor interno que almacena el objeto
            .ValueMember = "f0601_id_fuente"
            'Origen de Datos del ComboBox
            .DataSource = otb_fuentes
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.SelectedIndex = -1
        End With
        csql = "select f0200_id_tercero, f0200_id," _
            & " trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as tercero" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " order by f0200_nombres"  '& " where f0200_ind_cliente = 'S'" _
        Dim otb_tercero As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
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
            If id_tercero = 0 Then
                .SelectedIndex = -1
            Else
                .SelectedValue = id_tercero
            End If

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
            If id_tercero = 0 Then
                .SelectedIndex = -1
            Else
                .SelectedValue = id_tercero
            End If
        End With
    End Sub


    Private Sub cm_subfuente_accion_Validating(sender As Object, e As CancelEventArgs) Handles cm_subfuente_accion.Validating
        tx_MEF.Text = ""
        If cm_subfuente_accion.SelectedIndex <> -1 Then
            Dim dv_mef As New DataView(otb_info_mef)
            dv_mef.RowFilter = "f0612_id_sub_fuente = " & cm_subfuente_accion.SelectedValue
            With cm_mef
                'Valor que se muestra al usuario
                .DisplayMember = "descripcion"
                'Valor interno que almacena el objeto
                .ValueMember = "id"
                'Origen de Datos del ComboBox
                .DataSource = dv_mef
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
                '.SelectedValue = mef_seleccionado
            End With
        End If

    End Sub
    Private Sub tx_MEF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_MEF.Validating
        If tx_MEF.Text.ToString <> "" Then
            cm_mef.SelectedValue = tx_MEF.Text
            If cm_mef.SelectedIndex = -1 Then
                MsgBox("El codigo no pertenece a la lista", MsgBoxStyle.Critical)
                tx_MEF.Text = ""
            End If
        End If

    End Sub
    Private Sub tx_MEF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_MEF.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            cm_mef.SelectedValue = tx_MEF.Text
            If cm_mef.SelectedIndex = -1 Then
                MsgBox("El codigo no pertenece a la lista", MsgBoxStyle.Critical)
                tx_MEF.Text = ""
            End If
        End If
    End Sub

    Private Sub cm_mef_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_mef.Validating
        If cm_mef.SelectedIndex <> -1 Then
            tx_MEF.Text = cm_mef.SelectedValue
        End If
    End Sub
    Private Sub validar_modo_falla()
        If tx_modo_efecto_falla.Text.Trim = "" Then
            vmensaje_requisitos = "No hay una descripcion del modo o efecto de falla."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_receptor()
        If cm_responsable.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione un receptor."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_fechas()
        If dtp_fecha_ocurrencia.Visible = False Then
            vmensaje_requisitos = "Identifique la fecha y hora en que la falla ocurrio."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_fuente()
        If cm_fuente_accion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Identifique la fuente."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_subfuente()
        If cm_subfuente_accion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Identifique la Sub Fuente."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_req_tercero()
        If cm_fuente_accion.SelectedValue = "00000004" And cm_razon_social.SelectedIndex = -1 Then
            vmensaje_requisitos = "Por ser una reclamacion se debe identificar al Cliente."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_mef()
        If cm_mef.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione un modo o efecto de falla del listado."
            verror_requisitos = "S"
        Else
            tx_MEF.Text = cm_mef.SelectedValue
        End If
    End Sub
    Private Sub cm_nit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_nit.Validating
        If cm_nit.SelectedIndex = -1 Then
            cm_razon_social.SelectedIndex = -1
        End If
    End Sub

    Private Sub cm_razon_social_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_razon_social.Validating
        If cm_razon_social.SelectedIndex = -1 Then
            cm_nit.SelectedIndex = -1
        End If
    End Sub

    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_modo_falla()
        validar_receptor()
        validar_fechas()
        validar_fuente()
        validar_subfuente()

        validar_mef()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Falla", "Desea grabar este reporte de falla?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        'autoriza = "N"
        'Dim oform_login As New camocontrol.login
        'oform_grilla_programacion.ods_hijo = ods
        'oform_login.vf_oform_padre = Me
        'oform_login.paso_autorizacion = "S"
        'oform_login.ShowDialog()
        'If autoriza = "N" Then
        'Exit Sub
        'End If

        If vf_elemento_nuevo = "S" Then
            Dim id_creado As Integer
            id_creado = grabar_nueva_falla()
            If verror = "N" Then
                bt_gestionar.Enabled = True
                id_accion = id_creado ' cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0600_id_accion", "f0600_emisor", vg_usuario_autoriza, "tb0600_acciones")
                If tx_anotacion.Text.Trim <> "" Then
                    grabar_nuevo_seguimiento()
                End If
                MsgBox("Falla #: " & id_accion & " reportada", MsgBoxStyle.Information, "Reporte de Falla")
                If retornar_numero_accion_creada = "S" Then
                    vf_oform_padre.id_accion = id_accion
                    retornar_numero_accion_creada = "N"
                End If
                tx_id_accion.Text = id_accion
                vf_elemento_nuevo = "N"
                'PARA CONTROLAR LA INFORMACION DE LOS DOCUMENTOS ASOCIADOS
                new_name_file = comunes.suministrar_valor_variable_configuracion("CD-ACC-001", vg_id_cia)
                new_name_file += "-" & tx_id_accion.Text.PadLeft(8, "0")
                calcular_archivos_asociados()
                gb_soportes_falla.Enabled = True
                tx_anotacion.Enabled = False
            End If
        Else
            actualizar_falla()
            If verror = "N" Then
                MsgBox("Falla actualizada", MsgBoxStyle.Information, "Reporte de Falla")
            End If
        End If
    End Sub

    Private Function grabar_nueva_falla()
        Dim id_creado As Integer
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0600_acciones" _
                & " (f0600_id_cia, f0600_id_estructura, f0600_descripcion, f0600_id_fuente_accion, f0600_id_subfuente, f0600_id_estado_accion," _
                & " f0600_id_mef," _
                & " f0600_id_tipo_accion, f0600_emisor, f0600_responsable, f0600_evaluador, f0600_fecha_ocurrencia_evento," _
                & " f0600_unidad_duracion, f0600_usuario_modificar, f0600_usuario_crear, f0600_fm, f0600_fecha_cierre_correctivo," _
                & " f0600_tercero_relacionado,f0600_tipo_docto_padre,f0600_id_docto_padre)" _
                & " VALUES" _
                & " (@f0600_id_cia, @f0600_id_estructura, @f0600_descripcion, @f0600_id_fuente_accion, @f0600_id_subfuente, @f0600_id_estado_accion," _
                & " @f0600_id_mef," _
                & " @f0600_id_tipo_accion, @f0600_emisor, @f0600_responsable, @f0600_evaluador, @f0600_fecha_ocurrencia_evento," _
                & " @f0600_unidad_duracion, @f0600_usuario_modificar, @f0600_usuario_crear, @f0600_fm, @f0600_fecha_cierre_correctivo," _
                & " @f0600_tercero_relacionado, @f0600_tipo_docto_padre, @f0600_id_docto_padre)" _
                & " RETURNING f0600_id_accion"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_reporte_falla(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nueva falla! " + vbCrLf + ex.ToString + vbCrLf + csql)
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
    Private Sub actualizar_falla()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += "f0600_descripcion = @f0600_descripcion,"
        csql += "f0600_id_subfuente = @f0600_id_subfuente,"
        csql += "f0600_id_mef = @f0600_id_mef,"
        csql += "f0600_responsable = @f0600_responsable,"
        csql += "f0600_fecha_ocurrencia_evento = @f0600_fecha_ocurrencia_evento,"
        csql += "f0600_fecha_cierre_correctivo = @f0600_fecha_cierre_correctivo"
        csql += " where f0600_id_accion = @f0600_id_accion"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_reporte_falla(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0600_id_accion", NpgsqlDbType.Integer).Value = id_accion
        ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = UCase(tx_modo_efecto_falla.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_id_subfuente", NpgsqlDbType.Integer).Value = cm_subfuente_accion.SelectedValue
        ocmd.Parameters.Add("@f0600_id_mef", NpgsqlDbType.Integer).Value = cm_mef.SelectedValue
        ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = cm_responsable.SelectedValue

        If dtp_fecha_ocurrencia.Visible = True Then
            ocmd.Parameters.Add("@f0600_fecha_ocurrencia_evento", NpgsqlDbType.Timestamp).Value = dtp_fecha_ocurrencia.Value
        Else
            ocmd.Parameters.Add("@f0600_fecha_ocurrencia_evento", NpgsqlDbType.Timestamp).Value = DBNull.Value
        End If
        If dtp_fecha_cierre_correccion.Visible = True Then
            ocmd.Parameters.Add("@f0600_fecha_cierre_correctivo", NpgsqlDbType.Timestamp).Value = dtp_fecha_cierre_correccion.Value
        Else
            ocmd.Parameters.Add("@f0600_fecha_cierre_correctivo", NpgsqlDbType.Timestamp).Value = DBNull.Value
        End If

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

    Private Sub crear_parametros_reporte_falla(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0600_id_estructura", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = UCase(tx_modo_efecto_falla.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_id_mef", NpgsqlDbType.Integer).Value = cm_mef.SelectedValue
        ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = cm_fuente_accion.SelectedValue
        ocmd.Parameters.Add("@f0600_id_subfuente", NpgsqlDbType.Integer).Value = cm_subfuente_accion.SelectedValue
        If cm_razon_social.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0600_tercero_relacionado", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0600_tercero_relacionado", NpgsqlDbType.Varchar).Value = cm_razon_social.SelectedValue
        End If

        ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = "02"
        ocmd.Parameters.Add("@f0600_id_tipo_accion", NpgsqlDbType.Varchar).Value = "01"
        ocmd.Parameters.Add("@f0600_emisor", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = cm_responsable.SelectedValue
        ocmd.Parameters.Add("@f0600_evaluador", NpgsqlDbType.Varchar).Value = "00000004"
        If dtp_fecha_ocurrencia.Visible = True Then
            ocmd.Parameters.Add("@f0600_fecha_ocurrencia_evento", NpgsqlDbType.Timestamp).Value = dtp_fecha_ocurrencia.Value
        Else
            ocmd.Parameters.Add("@f0600_fecha_ocurrencia_evento", NpgsqlDbType.Timestamp).Value = DBNull.Value
        End If
        ocmd.Parameters.Add("@f0600_unidad_duracion", NpgsqlDbType.Varchar).Value = "00000028"
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        If dtp_fecha_cierre_correccion.Visible = True Then
            ocmd.Parameters.Add("@f0600_fecha_cierre_correctivo", NpgsqlDbType.Timestamp).Value = dtp_fecha_cierre_correccion.Value
        Else
            ocmd.Parameters.Add("@f0600_fecha_cierre_correctivo", NpgsqlDbType.Timestamp).Value = DBNull.Value
        End If
        If otipo_docto_padre <> "" Then
            ocmd.Parameters.Add("@f0600_tipo_docto_padre", NpgsqlDbType.Varchar).Value = otipo_docto_padre
            ocmd.Parameters.Add("@f0600_id_docto_padre", NpgsqlDbType.Integer).Value = id_docto_padre
        Else
            ocmd.Parameters.Add("@f0600_tipo_docto_padre", NpgsqlDbType.Varchar).Value = ""
            ocmd.Parameters.Add("@f0600_id_docto_padre", NpgsqlDbType.Integer).Value = DBNull.Value
        End If
    End Sub

    Private Sub grabar_nuevo_seguimiento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0606_seguimientos_acciones" _
                & " (f0606_id_documento, f0606_id_cia, f0606_seguimiento_accion, f0606_tipo_nota," _
                & " f0606_usuario_crear, f0606_usuario_modificar)" _
                & " VALUES" _
                & " (@f0606_id_documento, @f0606_id_cia, @f0606_seguimiento_accion, @f0606_tipo_nota," _
                & " @f0606_usuario_crear, @f0606_usuario_modificar)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_seguimiento(ocmd)

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
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_seguimiento(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0606_id_documento", NpgsqlDbType.Integer).Value = id_accion
        ocmd.Parameters.Add("@f0606_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0606_seguimiento_accion", NpgsqlDbType.Varchar).Value = UCase(tx_anotacion.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0606_tipo_nota", NpgsqlDbType.Varchar).Value = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
        ocmd.Parameters.Add("@f0606_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0606_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub
    Private Sub calcular_archivos_asociados()
        lb_total_soportes.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-ACC-001", tx_id_accion.Text, vg_id_cia)
    End Sub
    Private Sub bt_nuevo_soporte_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo_soporte.Click
        cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-ACC", tx_id_accion.Text, vg_id_cia, vg_usuario_autoriza, "N")
        calcular_archivos_asociados()
    End Sub
    Private Sub bt_ver_archivos_asociados_Click(sender As System.Object, e As System.EventArgs) Handles bt_ver_archivos_asociados.Click
        csql = "SELECT f0503_id_archivo as id_file, f0503_ed as documento, f0503_descripcion_archivo as descripcion," _
    & " to_char(f0503_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_carga, f0503_nombre_original as origen" _
    & " from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
    & " where f0503_nombre_archivo = '" & new_name_file & "' and f0503_id_cia = '" & vg_id_cia & "'" _
    & " order by f0503_id_archivo desc"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_archivos As New camocontrol.fm_visor_datos
        oform_mostrar_archivos.vf_oform_padre = Me
        oform_mostrar_archivos.csql = csql
        oform_mostrar_archivos.titulo_formulario = "Archivos Asociados"
        oform_mostrar_archivos.vg_id_cia = vg_id_cia
        oform_mostrar_archivos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_archivos.ShowDialog()
    End Sub

    Private Sub bt_fecha_ocurrencia_Click(sender As Object, e As EventArgs) Handles bt_fecha_ocurrencia.Click
        lb_f_inicio.Visible = False
        dtp_fecha_ocurrencia.Visible = True
    End Sub

    Private Sub bt_f_cierre_correccion_Click(sender As Object, e As EventArgs) Handles bt_f_cierre_correccion.Click
        lb_f_correccion.Visible = False
        dtp_fecha_cierre_correccion.Visible = True
    End Sub

    Private Sub bt_gestionar_Click(sender As Object, e As EventArgs) Handles bt_gestionar.Click
        bt_grabar.Enabled = False
        bt_f_cierre_correccion.Enabled = False
        bt_fecha_ocurrencia.Enabled = False
        cl_utilidades_gestion_acciones.abrir_actividad(id_accion, vg_usuario_autoriza, vg_id_cia)
    End Sub

    Private Sub bt_rel_items_Click(sender As Object, e As EventArgs) Handles bt_rel_items.Click
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_relacionar_items As New camocontrol.fm_0600_relacionar_items_accion
        oform_relacionar_items.vf_oform_padre = Me
        oform_relacionar_items.id_accion = id_accion
        oform_relacionar_items.id_tercero = cm_razon_social.SelectedValue
        oform_relacionar_items.vg_id_cia = vg_id_cia
        oform_relacionar_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_relacionar_items.ShowDialog()
    End Sub
    Private Sub bt_cambiar_infraestructura_Click(sender As Object, e As EventArgs) Handles bt_cambiar_infraestructura.Click
        verror_requisitos = "N"
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
            Exit Sub
        End If
        Dim id_nueva_estructura As String = id_estructura.ToString
        id_nueva_estructura = cl_utilidades_gestion_mantenimiento.suministrar_estructura_mantenimiento(vg_id_cia, vg_usuario_autoriza, id_estructura)
        Dim id_estructura_anterior As Integer = id_estructura
        If id_estructura.ToString <> id_nueva_estructura Then
            id_estructura = id_nueva_estructura
            tx_estructura.Text = comunes.traer_nombre_estructura(id_nueva_estructura)
        End If
    End Sub

    Private Sub bt_informe_Click(sender As Object, e As EventArgs) Handles bt_informe.Click
        If tx_id_accion.Text.Trim = "" Then
            MsgBox("Actividad fallida", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        cl_informes_comunes.reporte_plan_accion_proyecto(vg_id_cia, tx_id_accion.Text)
    End Sub


End Class
