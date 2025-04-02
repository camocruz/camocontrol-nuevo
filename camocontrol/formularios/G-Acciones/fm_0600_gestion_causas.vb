Public Class fm_0600_gestion_causas
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_estructura As String = "0"
    '$Public$vf_elemento_nuevo As String = "N"
    Public id_accion As Integer
    Public id_accion_principal As Integer
    Public id_accion_padre As Integer
    Public path_padre As String
    Public orow_info_accion As DataRow 'contiene el registro completo de la tabla de la accion principal.

    Public cambiar_estructura As String = "N"

    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String

    Private otb_accion As DataTable
    Private otb_info_personal As DataTable
    Private cumplimiento_actual As Integer = 0
    Private usuario_creador As String = ""
    Private usuario_evaluador As String = ""

    Private Sub fm_0600_gestion_causas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        tx_estructura.Enabled = False
        rb_causa.Checked = True
        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" _
            & " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        With cm_emisor
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

        If vf_elemento_nuevo = "S" Then
            cm_emisor.SelectedIndex = -1
            If IsDBNull(id_estructura) = False Then
                tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura)
            End If
        End If
        If vf_elemento_nuevo = "N" Then
            csql = "select * from " & database.obtener_esquema & ".tb0600_acciones where f0600_id_accion = " & id_accion
            otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            For Each orow As DataRow In otb_accion.Rows
                id_estructura = orow("f0600_id_estructura")
                tx_texto_tarea.Text = orow("f0600_descripcion")
                'rtx_texto.LoadFile("C:\Users\camoc\Documents\prueba1.rtf")
                tx_id_accion.Text = id_accion
                tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura)
                cm_emisor.SelectedValue = orow("f0600_emisor")
                usuario_creador = orow("f0600_emisor")
                usuario_evaluador = orow("f0600_evaluador")
                If orow("f0600_id_tipo_registro") = "02" Then
                    rb_causa.Checked = True
                Else
                    rb_grupo.Checked = True
                End If
            Next
        End If
        'MsgBox(path_padre & id_accion_padre & "-")
    End Sub
    Private Sub validar_que()
        If tx_texto_tarea.Text.Trim = "" Then
            vmensaje_requisitos = "No hay una descripcion de la causa."
            verror_requisitos = "S" '
        End If
    End Sub
    Private Sub grabar_nueva_causa()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0600_acciones" _
                & " (f0600_id_cia, f0600_id_tipo_registro, f0600_id_accion_padre, f0600_id_accion_principal," _
                & " f0600_id_estructura, f0600_descripcion," _
                & " f0600_emisor, f0600_path, f0600_id_fuente_accion, f0600_id_estado_accion," _
                & " f0600_usuario_modificar, f0600_usuario_crear, f0600_fm)" _
                & " VALUES" _
                & " (@f0600_id_cia, @f0600_id_tipo_registro, @f0600_id_accion_padre, @f0600_id_accion_principal," _
                & " @f0600_id_estructura, @f0600_descripcion," _
                & " @f0600_emisor, @f0600_path, @f0600_id_fuente_accion, @f0600_id_estado_accion," _
                & " @f0600_usuario_modificar, @f0600_usuario_crear, @f0600_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_causa(ocmd)

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
    Private Sub actualizar_causa()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += "f0600_descripcion = @f0600_descripcion,"
        csql += "f0600_id_tipo_registro = @f0600_id_tipo_registro,"
        csql += "f0600_fm = @f0600_fm,"
        csql += "f0600_usuario_modificar = @f0600_usuario_modificar"
        csql += " where f0600_id_accion = @f0600_id_accion"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_causa(ocmd)
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
    Private Sub crear_parametros_causa(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0600_id_accion", NpgsqlDbType.Integer).Value = id_accion
        End If
        ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = id_accion_padre
        If id_accion_principal = 0 Then
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = id_accion_principal
        End If
        ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = path_padre & id_accion_padre & "-"
        ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = orow_info_accion("f0600_id_fuente_accion")
        ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = "03" '03=implementacion
        ocmd.Parameters.Add("@f0600_id_estructura", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = UCase(tx_texto_tarea.Text.ToString.Trim)
        If rb_causa.Checked = True Then
            ocmd.Parameters.Add("@f0600_id_tipo_registro", NpgsqlDbType.Varchar).Value = "02" '02=causa
        Else
            ocmd.Parameters.Add("@f0600_id_tipo_registro", NpgsqlDbType.Varchar).Value = "07" '07=grupo
        End If

        ocmd.Parameters.Add("@f0600_emisor", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub

    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_que()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Grabar esta Causa", "Desea grabar cambios en este registro?")
        If respuesta = "N" Then
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            grabar_nueva_causa()
            'funcion que actualiza los path de un arbol a partir de la rama seleccionada.
            'cl_utilidades_gestion_acciones.actualizar_ramal(id_accion_padre, path_padre, "tb0600_acciones", "f0600_id_accion", _
            '"f0600_path", "f0600_id_accion_padre")
        Else
            actualizar_causa()
        End If
        If verror = "N" Then
            MsgBox("La causa fue grabada", MsgBoxStyle.Information, "Grabar")
            Dispose()
        End If

    End Sub
    Private Sub bt_cambiar_infraestructura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_cambiar_infraestructura.Click
        verror_requisitos = "N"
        Dim id_nueva_estructura As String = id_estructura.ToString
        id_nueva_estructura = cl_utilidades_gestion_mantenimiento.suministrar_estructura_mantenimiento(vg_id_cia, vg_usuario_autoriza, id_estructura)
        Dim id_estructura_anterior As Integer = id_estructura
        If id_estructura_anterior <> id_nueva_estructura Then
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
                Exit Sub
            End If
            id_estructura = id_nueva_estructura
            'cambia la estructura solo cuando este definida, antes no
            If tx_id_accion.Text <> "" Then
                cambiar_estructura_seleccionada()
            End If
            tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura)
        End If
    End Sub
    Private Sub cambiar_estructura_seleccionada()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set " _
                    & " f0600_id_estructura = '" & id_estructura & "'" _
                    & " where f0600_id_accion = '" & id_accion & "'"
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
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

    Private Sub bt_actividades_hijo_Click(sender As Object, e As EventArgs) Handles bt_actividades_hijo.Click
        If tx_id_accion.Text = "" Then
            MsgBox("La actividad padre no existe!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        'MsgBox(path_padre & id_accion_padre & "-")
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_analisis As New camocontrol.fm_0600_p3_analisis_y_solucion
        'oform_grilla_programacion.ods_hijo = ods
        oform_analisis.vf_oform_padre = Me
        oform_analisis.Text = "Actividades hijo"
        oform_analisis.lb_titulo.Text = "Actividades hijo"
        oform_analisis.bt_mef.Visible = False
        oform_analisis.cm_mef.Visible = False
        'oform_analisis.tx_mef.Visible = False
        oform_analisis.vg_id_cia = vg_id_cia
        oform_analisis.orow_info_accion = orow_info_accion
        oform_analisis.id_accion = id_accion
        oform_analisis.path_accion_base = path_padre '& id_accion_padre & "-"
        oform_analisis.id_estructura = id_estructura
        oform_analisis.vg_usuario_autoriza = vg_usuario_autoriza
        oform_analisis.ShowDialog()
    End Sub
End Class
