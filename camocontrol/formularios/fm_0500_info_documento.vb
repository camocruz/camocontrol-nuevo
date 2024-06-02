Public Class fm_0500_info_documento
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_documento As Integer = 0
    Public id_tipo_documento As Integer = 0

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

    Private otb_documentos

    Private Sub fm_0500_info_documento_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0501_documentos" _
            & " order by f0501_codigo_documento desc"
        otb_documentos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_codigo_documento
            'Valor que se muestra al usuario
            .DisplayMember = "f0501_codigo_documento"
            'Valor interno que almacena el objeto
            .ValueMember = "f0501_id_documento"
            'Origen de Datos del ComboBox
            .DataSource = otb_documentos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        csql = "select f0060_id_proceso, f0060_nombre_proceso"
        csql += " from " & database.obtener_esquema & ".tb0060_procesos_compania"
        csql += " where f0060_id_cia = '" & vg_id_cia & "'"
        Dim otb_proceso As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_proceso
            'Valor que se muestra al usuario
            .DisplayMember = "f0060_nombre_proceso"
            'Valor interno que almacena el objeto
            .ValueMember = "f0060_id_proceso"
            'Origen de Datos del ComboBox
            .DataSource = otb_proceso
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With


        If vf_elemento_nuevo = "N" Then
            cargar_info_documento()
        End If
    End Sub

    Private Sub cargar_info_documento()
        Dim orow_documento() As DataRow
        orow_documento = otb_documentos.select("f0501_id_documento = '" & id_documento & "'")
        For Each orow As DataRow In orow_documento
            tx_id_documento.Text = orow("f0501_id_documento")
            cm_codigo_documento.SelectedValue = orow("f0501_id_documento")
            tx_titulo_documento.Text = orow("f0501_titulo_documento")
            cm_proceso.SelectedValue = orow("f0501_proceso")
            tx_conservacion.Text = orow("f0501_conservacion")
        Next
    End Sub

    Private Sub validar_codigo_nuevo()
        Dim orow_documento() As DataRow
        orow_documento = otb_documentos.select("f0501_codigo_documento = '" & cm_codigo_documento.Text.Trim & "'")
        If vf_elemento_nuevo = "S" Then
            If orow_documento.Length >= 1 Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Codigo de documento ya existente, defina uno nuevo."
            End If
        Else
            For Each orow As DataRow In orow_documento
                If orow("f0501_id_documento") <> id_documento Then
                    verror_requisitos = "S"
                    vmensaje_requisitos = "Codigo de documento ya existente, defina uno nuevo."
                End If
            Next
        End If
    End Sub
    Private Sub validar_titulo_documento()
        If tx_titulo_documento.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el titulo o nombre del documento."
        End If
    End Sub
    Private Sub validar_conservacion()
        If tx_conservacion.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el tiempo de conservacion."
        End If
    End Sub
    Private Sub validar_proceso()
        If cm_proceso.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el proceso al que pertenece."
        End If
    End Sub
    Private Sub grabar_nuevo_documento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0501_documentos" _
                & " (f0501_id_cia, f0501_id_tipo_documento, f0501_codigo_documento, f0501_titulo_documento," _
                & " f0501_usuario_modificar, f0501_usuario_crear, f0501_fm, f0501_proceso, f0501_conservacion)" _
                & " VALUES" _
                & " (@f0501_id_cia, @f0501_id_tipo_documento, @f0501_codigo_documento, @f0501_titulo_documento," _
                & " @f0501_usuario_modificar, @f0501_usuario_crear, @f0501_fm, @f0501_proceso, @f0501_conservacion)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0501_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0501_id_tipo_documento", NpgsqlDbType.Integer).Value = id_tipo_documento
        ocmd.Parameters.Add("@f0501_proceso", NpgsqlDbType.Integer).Value = cm_proceso.SelectedValue
        ocmd.Parameters.Add("@f0501_codigo_documento", NpgsqlDbType.Varchar).Value = UCase(cm_codigo_documento.Text.Trim)
        ocmd.Parameters.Add("@f0501_conservacion", NpgsqlDbType.Varchar).Value = UCase(tx_conservacion.Text.Trim)
        ocmd.Parameters.Add("@f0501_titulo_documento", NpgsqlDbType.Varchar).Value = tx_titulo_documento.Text.Trim.ToUpper
        ocmd.Parameters.Add("@f0501_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0501_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0501_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora


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
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub actualizar_info_documento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0501_documentos set "
        csql += "f0501_codigo_documento = @f0501_codigo_documento,"
        csql += "f0501_proceso = @f0501_proceso,"
        csql += "f0501_conservacion = @f0501_conservacion,"
        csql += "f0501_titulo_documento = @f0501_titulo_documento,"
        csql += "f0501_fm = @f0501_fm,"
        csql += "f0501_usuario_modificar = @f0501_usuario_modificar"
        csql += " where f0501_id_documento = @f0501_id_documento"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0501_id_documento", NpgsqlDbType.Integer).Value = id_documento
        ocmd.Parameters.Add("@f0501_proceso", NpgsqlDbType.Integer).Value = cm_proceso.SelectedValue
        ocmd.Parameters.Add("@f0501_codigo_documento", NpgsqlDbType.Varchar).Value = cm_codigo_documento.Text.ToUpper.Trim
        ocmd.Parameters.Add("@f0501_titulo_documento", NpgsqlDbType.Varchar).Value = tx_titulo_documento.Text.ToUpper.Trim
        ocmd.Parameters.Add("@f0501_conservacion", NpgsqlDbType.Varchar).Value = UCase(tx_conservacion.Text.Trim)
        ocmd.Parameters.Add("@f0501_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0501_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_codigo_nuevo()
        validar_titulo_documento()
        validar_proceso()
        validar_conservacion()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            grabar_nuevo_documento()
            If verror = "N" Then
                id_documento = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0501_id_documento",
                                                                                            "f0501_usuario_crear",
                                                                                            vg_usuario_autoriza,
                                                                                            "tb0501_documentos")
                grabar_nueva_edicion()
                MsgBox("Nuevo documento creado", MsgBoxStyle.Information, "Creado")
                Dispose()
            End If
        Else
            actualizar_info_documento()
            If verror = "N" Then
                MsgBox("Documento actualizado", MsgBoxStyle.Information, "Actualizado")
                Dispose()
            End If
        End If
    End Sub

    Private Sub grabar_nueva_edicion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0502_documentos_ed" _
                & " (f0502_id_cia, f0502_id_documento, f0502_ed, f0502_descripcion_ed," _
                & " f0502_usuario_modificar, f0502_usuario_crear, f0502_fm)" _
                & " VALUES" _
                & " (@f0502_id_cia, @f0502_id_documento, @f0502_ed, @f0502_descripcion_ed," _
                & " @f0502_usuario_modificar, @f0502_usuario_crear, @f0502_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0502_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0502_id_documento", NpgsqlDbType.Integer).Value = id_documento
        ocmd.Parameters.Add("@f0502_ed", NpgsqlDbType.Integer).Value = 1
        ocmd.Parameters.Add("@f0502_descripcion_ed", NpgsqlDbType.Varchar).Value = "SE EMITE DOCUMENTO."
        ocmd.Parameters.Add("@f0502_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0502_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0502_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
End Class
