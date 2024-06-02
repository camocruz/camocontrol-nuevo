Public Class fm_0600_gestion_tareas_cambio_fecha
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

    Private id_estado As String
    Private fecha_inicio_anterior As String = ""
    Private fecha_fin_anterior As String = ""
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
    Private fecha_limite As DateTime

    Private otb_unidad_tiempo As DataTable

    Private otb_info_personal As DataTable
    Private otb_estructura_mantenimiento As DataTable
    Private otb_accion As DataTable

    Private Sub fm_0600_gestion_tareas_cambio_fecha_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        csql = " select *" _
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

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_inicio_prog.Format = DateTimePickerFormat.Custom
        dtp_fecha_inicio_prog.CustomFormat = "yyyy/MM/dd  HH:mm"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_fin_prog.Format = DateTimePickerFormat.Custom
        dtp_fecha_fin_prog.CustomFormat = "yyyy/MM/dd  HH:mm"
        dtp_fecha_fin_prog.Enabled = False

        traer_informacion_accion()

    End Sub
    Private Sub traer_informacion_accion()
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones where f0600_id_accion = " & id_accion
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_accion.Rows
            id_estado = orow("f0600_id_estado_accion")
            If orow("f0600_id_estado_accion").ToString = "08" Then '08 es estado cerrado
                actividad_cerrada = "S"
            End If
            tx_duracion.Text = orow("f0600_duracion")
            cm_unidad_duracion.SelectedValue = orow("f0600_unidad_duracion")
            dtp_fecha_inicio_prog.Value = orow("f0600_fecha_inicio")
            dtp_fecha_fin_prog.Value = orow("f0600_fecha_limite")
            fecha_inicio_anterior = dtp_fecha_inicio_prog.Value.ToString("yyyy/MM/dd  HH:mm")
            fecha_fin_anterior = dtp_fecha_fin_prog.Value.ToString("yyyy/MM/dd  HH:mm")
        Next
    End Sub
    Private Sub calcular_fecha_finalizacion_tarea()
        Dim odatarow() As DataRow = otb_unidad_tiempo.Select("f0002_id_unidad_medicion = '" & cm_unidad_duracion.SelectedValue & "'")
        ' Loop and display.
        For Each orow As DataRow In odatarow
            fecha_limite = DateAdd(DateInterval.Second, orow("f0002_factor_conversion") * CInt(tx_duracion.Text), dtp_fecha_inicio_prog.Value)
            dtp_fecha_fin_prog.Value = fecha_limite
        Next
    End Sub
    Private Sub cm_unidad_duracion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_unidad_duracion.Validating
        calcular_fecha_finalizacion_tarea()
    End Sub
    Private Sub validar_fechas_inicio_fin()
        If dtp_fecha_fin_prog.Value <= dtp_fecha_inicio_prog.Value Then
            vmensaje_requisitos = "La fecha de finalizacion no pude ser menor que la fecha de inicial"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub tx_duracion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_duracion.Validating
        If tx_duracion.Text.Trim = "" Or CInt(tx_duracion.Text.Trim) = 0 Then
            tx_duracion.Text = 1
        End If
        calcular_fecha_finalizacion_tarea()
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
    Private Sub dtp_fecha_inicio_prog_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtp_fecha_inicio_prog.Validating
        calcular_fecha_finalizacion_tarea()
    End Sub
    Private Sub validar_modificacion_actividad_cerrada()
        If actividad_cerrada = "S" Then
            If vg_usuario_autoriza <> "00000001" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Una actividad cerrada solo puede ser modificada por el Administrador!"
            End If
        End If
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
        validar_fechas_inicio_fin()
        validar_duracion()
        validar_modificacion_actividad_cerrada()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        actualizar_tarea()
        If verror = "N" Then
            Dim txt_seguimiento As String
            txt_seguimiento = "CAMBIO DE FECHAS: " & vbCrLf _
            & "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo el siguiente cambio:" & vbCrLf _
            & "VALORES INICIALES:" & vbCrLf _
            & "Fecha inicio: " & fecha_inicio_anterior & vbCrLf _
            & "Fecha fin: " & fecha_fin_anterior & vbCrLf _
            & "CAMBIARON A:" & vbCrLf _
            & "Fecha inicio: " & dtp_fecha_inicio_prog.Value.ToString("yyyy/MM/dd  HH:mm") & vbCrLf _
            & "Fecha fin: " & dtp_fecha_fin_prog.Value.ToString("yyyy/MM/dd  HH:mm")
            Dim tipo_nota As String = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
            cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia)
            actualizar_estado_accion()
            MsgBox("La actividad fue grabada", MsgBoxStyle.Information, "Grabar")
            Dispose()
        End If
    End Sub
    Private Sub actualizar_tarea()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += "f0600_unidad_duracion = @f0600_unidad_duracion, "
        csql += "f0600_duracion = @f0600_duracion,"
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
        ocmd.Parameters.Add("f0600_id_accion", NpgsqlDbType.Integer).Value = id_accion
        ocmd.Parameters.Add("@f0600_unidad_duracion", NpgsqlDbType.Varchar).Value = cm_unidad_duracion.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_duracion", NpgsqlDbType.Integer).Value = tx_duracion.Text.ToString.Trim
        ocmd.Parameters.Add("@f0600_fecha_inicio", NpgsqlDbType.Timestamp).Value = dtp_fecha_inicio_prog.Value
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("@f0600_fecha_limite", NpgsqlDbType.Timestamp).Value = dtp_fecha_fin_prog.Value
    End Sub

    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        grabar()
    End Sub

    Private Sub actualizar_estado_accion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        csql = "update " + database.obtener_esquema + ".tb0600_acciones set" _
        & " f0600_id_estado_accion = '03'" _
        & " where f0600_id_accion = '" & id_accion & "'"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        ocmd.Parameters.Clear()
        'ocmd.Parameters.Add("@fecha_actual", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar estado" + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! estado" + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
End Class
