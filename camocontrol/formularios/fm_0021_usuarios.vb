Public Class fm_0021_usuarios
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private usuario_nuevo As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private verror_grabar As String = ""
    Private vexiste As String = "N"
    Private verror As String = "N"
    Private vactivo As String = "N"
    Private vdato As String = ""
    Private local As String = ""
    Private MensajeError As String
    Private vemail_ok As Boolean
    Private vestado As String
    Private vgrabar As String
    Private identificacion_usuario As String = ""
    Private nombre_tercero As String = ""
    Private clave_anterior As String = "ND"

    Private f0021_id_cia As String = ""
    Private f0021_fecha_cambiar_clave As DateTime
    Private f0021_id_usuario As String 'es el f0200_id de la tabla terceros
    Private f0021_nombre_completo As String = ""
    Private f0021_clave As String = ""
    Private f0021_clave_caduca As String = ""
    Private f0021_fecha_caduca As DateTime
    Private f0021_cambio_clave_periodica As String = ""
    Private f0021_estado As String = ""
    Private f0021_fm As DateTime
    Private f0021_usuario_modifica As String = ""

    Private Sub fm_0021_usuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        f0021_id_cia = vg_id_cia
    End Sub
    Private Sub limpiar()
        tx_id_tercero.Text = ""
        tx_identificacion.Text = ""
        tx_nombre_tercero.Text = ""
        tx_codigo.Text = ""
        tx_codigo_v.Text = ""
        tx_usuario.Text = ""
        dtp_fecha_caducidad.Value = DateAdd(DateInterval.Month, 2, Now())  'a = dtp_fecha_inicial.Value.ToString("yyyy/MM/dd")
        chk_clave_periodica.Checked = True
        chk_usuario_no_caduca.Checked = False
        rb_activo.Checked = True
    End Sub
    Private Sub buscar_identificacion()
        usuario_nuevo = "N"
        identificacion_usuario = tx_identificacion.Text.Trim
        clave_anterior = "ND"
        limpiar()
        csql = "select * FROM " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id = '" & identificacion_usuario & "'" _
                    & " and f0200_id_cia ='" & vg_id_cia & "'"
        Dim otb_info_terceros As DataTable
        otb_info_terceros = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_info_terceros.Rows.Count = 0 Then
            MsgBox("Para crear este usuario debe primero crearlo como tercero.", MsgBoxStyle.Information, "Funcionarios")
            Exit Sub
        Else
            For Each orow As DataRow In otb_info_terceros.Rows
                f0021_id_usuario = orow("f0200_id_tercero")
                nombre_tercero = Trim(orow("f0200_nombres").ToString & " " & orow("f0200_apellido1").ToString & " " & orow("f0200_apellido2").ToString)
            Next
            tx_id_tercero.Text = f0021_id_usuario
            tx_identificacion.Text = identificacion_usuario
            tx_nombre_tercero.Text = nombre_tercero
            Dim otb_info_usuario As DataTable
            csql = "select * from " & database.obtener_esquema & ".tb0021_usuarios" _
                & " where f0021_id_usuario = '" & f0021_id_usuario & "'"
            otb_info_usuario = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            If otb_info_usuario.Rows.Count = 0 Then
                usuario_nuevo = "S"
                MsgBox("Usuario nuevo", MsgBoxStyle.Information, "Nuevo")
                rb_activo.Checked = True
                f0021_fecha_cambiar_clave = DateAdd(DateInterval.Month, 1, Now())
                tx_usuario.Focus()
            Else
                For Each orow As DataRow In otb_info_usuario.Rows
                    tx_usuario.Text = orow("f0021_nombre_completo")
                    tx_codigo.Text = orow("f0021_clave")
                    tx_codigo_v.Text = orow("f0021_clave")
                    clave_anterior = orow("f0021_clave")
                    dtp_fecha_caducidad.Value = orow("f0021_fecha_caduca")
                    If orow("f0021_cambio_clave_periodica") = "S" Then
                        chk_clave_periodica.Checked = True
                    Else
                        chk_clave_periodica.Checked = False
                    End If
                    If orow("f0021_clave_caduca") = "S" Then
                        chk_usuario_no_caduca.Checked = False
                    Else
                        chk_usuario_no_caduca.Checked = True
                    End If
                    If orow("f0021_estado") = "A" Then
                        rb_activo.Checked = True
                    Else
                        rb_inactivo.Checked = True
                    End If
                    f0021_fecha_cambiar_clave = orow("f0021_fecha_cambiar_clave")
                Next
            End If
        End If
    End Sub
    Private Sub validar_identificacion()
        If tx_identificacion.Text.ToString.Trim = "" Then 'Is DBNull.Value Then
            vmensaje_requisitos = "Defina la identificacion"
            verror_requisitos = "S"
            Exit Sub
        End If
        If IsNumeric(tx_identificacion.Text.ToString) = False Then
            vmensaje_requisitos = "La identificacion debe ser numerica"
            verror_requisitos = "S"
            Exit Sub
        End If
    End Sub

    Private Sub tx_identificacion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_identificacion.Validating
        verror_requisitos = "N"
        validar_identificacion()
        'tx_dig_verificacion.Focus()
        If verror_requisitos = "N" Then
            buscar_identificacion()
        End If
    End Sub

    Private Sub validar_claves()
        If tx_codigo.Text.ToString.Trim = "" Then 'Is DBNull.Value Then
            vmensaje_requisitos = "Defina una clave"
            verror_requisitos = "S"
            Exit Sub
        End If
        If tx_codigo.Text.Trim <> tx_codigo_v.Text.Trim Then
            vmensaje_requisitos = "Las claves no coinciden."
            tx_codigo.Text = ""
            tx_codigo_v.Text = ""
            verror_requisitos = "S"
            Exit Sub
        End If
        If tx_codigo.Text.Trim = clave_anterior.Trim And f0021_fecha_cambiar_clave < Today And chk_clave_periodica.Checked = True Then
            vmensaje_requisitos = "No puede usar la misma clave."
            verror_requisitos = "S"
            Exit Sub
        End If
        'Actualiza la fecha de cambio de clave
        If tx_codigo.Text.Trim <> clave_anterior.Trim Then
            f0021_fecha_cambiar_clave = DateAdd(DateInterval.Month, 1, Now())
        End If
    End Sub
    Private Sub validar_nombre_usuario()
        If tx_usuario.Text.ToString.Trim = "" Then
            vmensaje_requisitos = "Defina un nombre del usuario"
            verror_requisitos = "S"
            Exit Sub
        End If
    End Sub
    Private Sub validar_usuario()
        If tx_id_tercero.Text.ToString.Trim = "" Then
            vmensaje_requisitos = "Defina una identificacion valida"
            verror_requisitos = "S"
            Exit Sub
        End If
    End Sub
    Private Sub chk_usuario_no_caduca_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_usuario_no_caduca.CheckStateChanged
        If chk_usuario_no_caduca.Checked = True Then
            dtp_fecha_caducidad.Enabled = False
            dtp_fecha_caducidad.Value = "2050-01-01"
        Else
            dtp_fecha_caducidad.Enabled = True
            dtp_fecha_caducidad.Value = DateAdd(DateInterval.Month, 2, Now())
        End If
    End Sub
    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_usuario()
        validar_claves()
        validar_nombre_usuario()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        'f0021_id_usuario = ""
        f0021_nombre_completo = tx_usuario.Text.ToString.Trim
        f0021_clave = tx_codigo.Text.ToString.Trim
        If chk_usuario_no_caduca.Checked = True Then
            f0021_clave_caduca = "N"
        Else
            f0021_clave_caduca = "S"
        End If
        f0021_fecha_caduca = dtp_fecha_caducidad.Value.ToString("yyyy/MM/dd")
        If chk_clave_periodica.Checked = True Then
            f0021_cambio_clave_periodica = "S"
        Else
            f0021_cambio_clave_periodica = "N"
        End If
        If rb_activo.Checked = True Then
            f0021_estado = "A"
        Else
            f0021_estado = "I"
        End If
        f0021_fm = comunes.g_fechahora()
        f0021_usuario_modifica = vg_usuario_autoriza

        If usuario_nuevo = "S" Then
            grabar_nuevo_usuario()
        Else
            actualizar_usuario()
        End If

        If verror = "N" Then
            MsgBox("Actualización Terminada", MsgBoxStyle.Information, "Proceso terminado")
            Me.limpiar()
        End If
        tx_identificacion.Focus()
    End Sub
    Private Sub grabar_nuevo_usuario()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "insert into " + database.obtener_esquema + ".tb0021_usuarios" _
            & " (" _
            & " f0021_id_usuario," _
            & " f0021_id_cia," _
            & " f0021_nombre_completo," _
            & " f0021_clave," _
            & " f0021_clave_caduca," _
            & " f0021_fecha_caduca," _
            & " f0021_cambio_clave_periodica," _
            & " f0021_fecha_cambiar_clave," _
            & " f0021_estado," _
            & " f0021_fm," _
            & " f0021_usuario_modifica" _
            & ") values" _
            & " (" _
            & " @f0021_id_usuario," _
            & " @f0021_id_cia," _
            & " @f0021_nombre_completo," _
            & " @f0021_clave," _
            & " @f0021_clave_caduca," _
            & " @f0021_fecha_caduca," _
            & " @f0021_cambio_clave_periodica," _
            & " @f0021_fecha_cambiar_clave," _
            & " @f0021_estado," _
            & " @f0021_fm," _
            & " @f0021_usuario_modifica" _
            & ")"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_usuario(ocmd)

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

    Private Sub actualizar_usuario()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0021_usuarios set" _
                & " f0021_nombre_completo = @f0021_nombre_completo," _
                & " f0021_clave = @f0021_clave," _
                & " f0021_clave_caduca = @f0021_clave_caduca," _
                & " f0021_fecha_caduca = @f0021_fecha_caduca," _
                & " f0021_cambio_clave_periodica = @f0021_cambio_clave_periodica," _
                & " f0021_fecha_cambiar_clave = @f0021_fecha_cambiar_clave," _
                & " f0021_estado = @f0021_estado," _
                & " f0021_fm = @f0021_fm," _
                & " f0021_usuario_modifica = @f0021_usuario_modifica" _
                & " where f0021_id_usuario = @f0021_id_usuario"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_usuario(ocmd)
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
    Private Sub crear_parametros_usuario(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0021_id_usuario", NpgsqlDbType.Varchar).Value = f0021_id_usuario
        ocmd.Parameters.Add("f0021_id_cia", NpgsqlDbType.Varchar).Value = f0021_id_cia
        ocmd.Parameters.Add("f0021_nombre_completo", NpgsqlDbType.Varchar).Value = f0021_nombre_completo
        ocmd.Parameters.Add("f0021_clave", NpgsqlDbType.Varchar).Value = f0021_clave
        ocmd.Parameters.Add("f0021_clave_caduca", NpgsqlDbType.Varchar).Value = f0021_clave_caduca
        ocmd.Parameters.Add("f0021_fecha_caduca", NpgsqlDbType.Timestamp).Value = f0021_fecha_caduca
        ocmd.Parameters.Add("f0021_cambio_clave_periodica", NpgsqlDbType.Varchar).Value = f0021_cambio_clave_periodica
        ocmd.Parameters.Add("f0021_fecha_cambiar_clave", NpgsqlDbType.Timestamp).Value = f0021_fecha_cambiar_clave
        ocmd.Parameters.Add("f0021_estado", NpgsqlDbType.Varchar).Value = f0021_estado
        ocmd.Parameters.Add("f0021_fm", NpgsqlDbType.Timestamp).Value = f0021_fm
        ocmd.Parameters.Add("f0021_usuario_modifica", NpgsqlDbType.Varchar).Value = f0021_usuario_modifica
    End Sub

End Class
