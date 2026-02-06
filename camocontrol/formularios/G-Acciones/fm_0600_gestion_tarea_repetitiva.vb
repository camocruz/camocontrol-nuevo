Public Class fm_0600_gestion_tarea_repetitiva
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_estructura As Integer
    Public id_accion As Integer
    Public id_accion_principal As Integer
    Public id_accion_padre As Integer
    Public path_padre As String = "-"

    Private path_accion As String
    Private usuario_creador As String = ""
    Private usuario_evaluador As String = ""
    Private actividad_cerrada As String = "N" 'Si una actividad fue cerrada queda bloqueada
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
    Private repeticiones As Integer = 1
    Private fecha_limite As DateTime
    Private id_tipo_registro As String

    Private otb_unidad_tiempo As DataTable
    Private otb_info_personal As DataTable
    Private otb_estructura_mantenimiento As DataTable
    Private otb_accion As DataTable

    Private Sub fm_0100_programacion_actividad_manto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        cl_utilidades_gestion_acciones.actualizar_estado_acciones(0, vg_usuario_autoriza, vg_id_cia) 'Actualizamos el estado de las acciones
        cargar_todos_los_combos_y_formatos()

    End Sub
    Private Sub cargar_todos_los_combos_y_formatos()
        tx_id_accion.Enabled = False
        tx_repeticiones.Text = "1"
        tx_periodo.Text = "1"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_inicio_prog.Format = DateTimePickerFormat.Custom
        dtp_fecha_inicio_prog.CustomFormat = "yyyy/MM/dd"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_fin_prog.Format = DateTimePickerFormat.Custom
        dtp_fecha_fin_prog.CustomFormat = "yyyy/MM/dd"
        dtp_fecha_fin_prog.Enabled = False

        csql = "SELECT *" _
    & " FROM " & database.obtener_esquema & ".tb0002_unidades_medicion" _
    & " where f0002_id_tipo_unidad = '00000005'"
        otb_unidad_tiempo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_unidad_duracion
            'Valor que se muestra al usuario
            .DisplayMember = "f0002_unidad_medicion"
            'Valor interno que almacena el objeto
            .ValueMember = "f0002_id_unidad_medicion"
            'Origen de Datos del ComboBox
            .DataSource = otb_unidad_tiempo
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" _
            & " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        With cm_evaluador
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
    Private Sub chk_permanente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles chk_permanente.Validating
        If chk_permanente.Checked = True Then
            tx_repeticiones.Text = "N/A"
            tx_repeticiones.ReadOnly = True
        Else
            tx_repeticiones.Text = "1"
            tx_repeticiones.ReadOnly = False
        End If
        calcular_fecha_finalizacion()
    End Sub
    Private Sub tx_repeticiones_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_repeticiones.Validating
        validar_repeticiones()
        calcular_fecha_finalizacion()
    End Sub
    Private Sub tx_repeticiones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_repeticiones.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub validar_repeticiones()
        If tx_repeticiones.Text = "N/A" Then
            repeticiones = 1000000
            Exit Sub
        End If
        If tx_repeticiones.Text = "" Then
            tx_repeticiones.Text = "1"
        End If
        If CInt(tx_repeticiones.Text) = 0 Then
            tx_repeticiones.Text = "1"
        End If
        repeticiones = tx_repeticiones.Text
    End Sub
    Private Sub validar_periodo()
        If tx_periodo.Text = "" Then
            tx_periodo.Text = "1"
        End If
        If CInt(tx_periodo.Text) = 0 Then
            tx_periodo.Text = "1"
        End If
    End Sub
    Private Sub tx_periodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_periodo.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub tx_periodo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_periodo.Validating
        validar_periodo()
        calcular_fecha_finalizacion()
    End Sub
    Private Sub calcular_fecha_finalizacion_tarea()
        Dim odatarow() As DataRow = otb_unidad_tiempo.Select("f0002_id_unidad_medicion = '" & cm_unidad_duracion.SelectedValue & "'")
        ' Loop and display.
        For Each orow As DataRow In odatarow
            fecha_limite = DateAdd(DateInterval.Second, (orow("f0002_factor_conversion") * CInt(tx_duracion.Text)), CDate(dtp_fecha_inicio_prog.Value.ToString("yyyy/MM/dd")))
        Next
    End Sub
    Private Sub calcular_fecha_finalizacion()
        If tx_repeticiones.Text = "N/A" Then
            fecha_limite = "2200/01/01"
        Else
            fecha_limite = DateAdd(DateInterval.Day, CInt(tx_periodo.Text) * CInt(tx_repeticiones.Text) - 1, dtp_fecha_inicio_prog.Value)
        End If
        dtp_fecha_fin_prog.Value = fecha_limite
    End Sub
    Private Sub validar_que()
        If tx_texto_tarea.Text.Trim = "" Then
            vmensaje_requisitos = "No hay una descripcion (Que) de la actividad a realizar."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub tx_duracion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_duracion.Validating
        If tx_duracion.Text.Trim = "" Or CInt(tx_duracion.Text.Trim) = 0 Then
            tx_duracion.Text = 1
        End If
    End Sub
    Private Sub tx_duracion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_duracion.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub validar_duracion()
        If tx_duracion.Text.Trim = "" Or IsNumeric(tx_duracion.Text.Trim) = False Or cm_unidad_duracion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Defina una duracion valida."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub grabar_nueva_tarea()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0600_acciones" _
                & " (f0600_id_cia, f0600_id_accion_principal, f0600_id_accion_padre, f0600_id_estructura," _
                & " f0600_titulo, f0600_descripcion, f0600_id_estado_accion," _
                & " f0600_id_fuente_accion, f0600_unidad_duracion, f0600_duracion, f0600_periodo_repeticion," _
                & " f0600_id_tipo_accion, f0600_responsable, f0600_evaluador, f0600_id_tipo_registro," _
                & " f0600_emisor, f0600_fecha_inicio, f0600_path," _
                & " f0600_usuario_modificar, f0600_usuario_crear, f0600_fm, f0600_fecha_limite," _
                & " f0600_repeticiones_programadas, f0600_repeticiones_indefinidas, f0600_repetitiva, f0600_repeticiones_ejecutadas)" _
                & " VALUES" _
                & " (@f0600_id_cia, @f0600_id_accion_principal, @f0600_id_accion_padre, @f0600_id_estructura," _
                & " @f0600_titulo, @f0600_descripcion, @f0600_id_estado_accion," _
                & " @f0600_id_fuente_accion, @f0600_unidad_duracion, @f0600_duracion, @f0600_periodo_repeticion," _
                & " @f0600_id_tipo_accion, @f0600_responsable, @f0600_evaluador, @f0600_id_tipo_registro," _
                & " @f0600_emisor, @f0600_fecha_inicio, @f0600_path," _
                & " @f0600_usuario_modificar, @f0600_usuario_crear, @f0600_fm, @f0600_fecha_limite," _
                & " @f0600_repeticiones_programadas, @f0600_repeticiones_indefinidas, @f0600_repetitiva, @f0600_repeticiones_ejecutadas)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_tarea(ocmd)

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
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub actualizar_tarea()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += "f0600_titulo = @f0600_titulo,"
        csql += "f0600_descripcion = @f0600_descripcion,"
        csql += "f0600_id_estado_accion = @f0600_id_estado_accion,"
        csql += "f0600_unidad_duracion = @f0600_unidad_duracion, "
        csql += "f0600_duracion = @f0600_duracion,"
        csql += "f0600_id_tipo_accion = @f0600_id_tipo_accion,"
        csql += "f0600_responsable = @f0600_responsable,"
        csql += "f0600_evaluador = @f0600_evaluador,"
        csql += "f0600_fecha_inicio = @f0600_fecha_inicio,"
        csql += "f0600_fecha_limite = @f0600_fecha_limite,"
        csql += "f0600_fm = @f0600_fm,"
        csql += "f0600_usuario_modificar = @f0600_usuario_modificar"
        csql += " where f0600_id_accion = @f0600_id_accion"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_tarea(ocmd)
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
    Private Sub crear_parametros_tarea(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0600_id_accion", NpgsqlDbType.Integer).Value = id_accion
        End If
        ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        If id_accion_principal = 0 Then
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = id_accion_principal
        End If

        If id_accion_padre <> 0 Then
            ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = id_accion_padre
            ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = path_padre & id_accion_padre & "-"
        Else
            'MsgBox("si es nulo")
            ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = DBNull.Value
            ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = "-"
        End If
        ocmd.Parameters.Add("@f0600_id_estructura", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0600_titulo", NpgsqlDbType.Varchar).Value = UCase(tx_titulo.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = UCase(tx_texto_tarea.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_id_tipo_registro", NpgsqlDbType.Varchar).Value = id_tipo_registro
        ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = 3 '03 = actividad manto
        ocmd.Parameters.Add("@f0600_id_tipo_accion", NpgsqlDbType.Varchar).Value = "02" '02 = preventiva
        ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = "03" '03 = implementacion
        ocmd.Parameters.Add("@f0600_unidad_duracion", NpgsqlDbType.Varchar).Value = cm_unidad_duracion.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_duracion", NpgsqlDbType.Integer).Value = CInt(tx_duracion.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_periodo_repeticion", NpgsqlDbType.Integer).Value = CInt(tx_periodo.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = "00000001" 'el administrador, no definido.
        ocmd.Parameters.Add("@f0600_evaluador", NpgsqlDbType.Varchar).Value = cm_evaluador.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_emisor", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fecha_inicio", NpgsqlDbType.Date).Value = dtp_fecha_inicio_prog.Value
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("@f0600_fecha_limite", NpgsqlDbType.Timestamp).Value = fecha_limite
        ocmd.Parameters.Add("@f0600_repeticiones_programadas", NpgsqlDbType.Integer).Value = repeticiones
        If chk_permanente.Checked = True Then
            ocmd.Parameters.Add("@f0600_repeticiones_indefinidas", NpgsqlDbType.Varchar).Value = "S"
        Else
            ocmd.Parameters.Add("@f0600_repeticiones_indefinidas", NpgsqlDbType.Varchar).Value = "N"
        End If
        ocmd.Parameters.Add("@f0600_repetitiva", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0600_repeticiones_ejecutadas", NpgsqlDbType.Integer).Value = 1
    End Sub
    Private Sub grabar()
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Grabar Actividad", "Desea grabar cambios en este registro?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'primer bloque de validaciones que no se relacionan con el usuario
        verror_requisitos = "N"
        validar_que()
        validar_duracion()
        validar_repeticiones()
        calcular_fecha_finalizacion()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        autoriza = "N"
        Dim oform_login As New camocontrol.login
        'oform_grilla_programacion.ods_hijo = ods
        oform_login.vf_oform_padre = Me
        oform_login.paso_autorizacion = "S"
        oform_login.ShowDialog()
        If autoriza = "N" Then
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            id_tipo_registro = "04" '04=tarea repetitiva
            grabar_nueva_tarea()
            tx_id_accion.Text = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0600_id_accion", "f0600_usuario_crear", vg_usuario_autoriza, "tb0600_acciones")
            'creamos la primer tarea del programa de manto.
            id_tipo_registro = "03" '03=tarea
            id_accion_padre = tx_id_accion.Text
            id_accion_principal = tx_id_accion.Text
            calcular_fecha_finalizacion_tarea()
            grabar_nueva_tarea()
            'funcion que actualiza los path de un arbol a partir de la rama seleccionada.
            'cl_utilidades_gestion_acciones.actualizar_ramal(id_accion_padre, path_padre, "tb0600_acciones", "f0600_id_accion", _
            '"f0600_path", "f0600_id_accion_padre")
        Else
            actualizar_tarea()
        End If
        If verror = "N" Then
            MsgBox("La actividad fue grabada", MsgBoxStyle.Information, "Grabar")
            Dispose()
        End If
    End Sub

    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        grabar()
    End Sub
End Class
