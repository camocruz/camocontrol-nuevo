Public Class fm_0500_version_del_documento
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_documento As Integer = 0
    Public id_doc_ed As Integer = 0
    Public doc_ed As Integer = 0
    Public config_archivos As String = ""

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

    Private ed_actual As Integer

    Private otb_ediciones_doc As DataTable

    Private Sub fm_0500_version_del_documento_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        vf_var_config_archivos = config_archivos ' "CD-ITM" ESTA VARIABLE LA ENTREGA EL FORMATO DE GESTION DEL DOCUMENTO
        vf_var_config_notas = "TN-DOC-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        'vf_elemento_nuevo = "S"
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)

        csql = "select * from " & database.obtener_esquema & ".tb0502_documentos_ed" _
            & " where f0502_id_documento = '" & id_documento & "'"
        otb_ediciones_doc = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        ed_actual = otb_ediciones_doc.Rows.Count

        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" & " and f0200_ind_empleado = 'S'" _
            & " order by nombre"
        Dim otb_revisadopor As DataTable
        otb_revisadopor = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim otb_aprobadopor As DataTable = otb_revisadopor.Copy

        With cm_revisadopor
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_revisadopor
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = vg_usuario_nn
        End With
        With cm_aprobadopor
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_aprobadopor
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = vg_usuario_nn
        End With

        'Usuario NN
        vg_usuario_nn = comunes.suministrar_valor_variable_configuracion("CONFIG-0500-01", vg_id_cia)

        If vf_elemento_nuevo = "N" Then
            Dim rows_info_ed As DataRow()
            rows_info_ed = otb_ediciones_doc.Select("f0502_ed = '" & doc_ed & "'")
            For Each orow As DataRow In rows_info_ed
                id_doc_ed = orow("f0502_id_ed")
                tx_id_doc_ed.Text = id_doc_ed
                vf_id_notas_archivos = id_doc_ed
                tx_version.Text = orow("f0502_ed") & " / " & ed_actual
                tx_cambio.Text = orow("f0502_descripcion_ed")
                If orow("f0502_usuario_revision").ToString.Trim <> "" Then
                    cm_revisadopor.SelectedValue = orow("f0502_usuario_revision")
                Else
                    cm_revisadopor.SelectedValue = vg_usuario_nn
                End If
                If orow("f0502_usuario_aprobacion").ToString.Trim <> "" Then
                    cm_aprobadopor.SelectedValue = orow("f0502_usuario_aprobacion")
                Else
                    cm_aprobadopor.SelectedValue = vg_usuario_nn
                End If

                If orow("f0502_fecha_revision").ToString <> "" Then
                    tx_fecha_revision.Text = CDate(orow("f0502_fecha_revision")).ToString("yyyy/MM/dd")
                    'tx_revisado_por.Text = comunes.traer_nombre_usuario(orow("f0502_usuario_revision"))
                Else
                    'tx_revisado_por.Text = "Pendiente"
                    tx_fecha_revision.Text = ""
                End If
                If orow("f0502_fecha_aprobacion").ToString <> "" Then
                    tx_fecha_aprobacion.Text = CDate(orow("f0502_fecha_aprobacion")).ToString("yyyy/MM/dd")
                    'tx_aprobado_por.Text = comunes.traer_nombre_usuario(orow("f0502_usuario_aprobacion"))
                Else
                    'tx_aprobado_por.Text = "Pendiente"
                    tx_fecha_aprobacion.Text = ""
                End If
                If orow("f0502_fecha_max_vigencia").ToString <> "" Then
                    tx_fecha_max_vigencia.Text = CDate(orow("f0502_fecha_max_vigencia")).ToString("yyyy/MM/dd")
                    'tx_aprobado_por.Text = comunes.traer_nombre_usuario(orow("f0502_usuario_aprobacion"))
                Else
                    'tx_aprobado_por.Text = "Pendiente"
                    tx_fecha_max_vigencia.Text = ""
                End If
                If orow("f0502_fecha_inicio_tramites").ToString <> "" Then
                    tx_fecha_ini_tramites.Text = CDate(orow("f0502_fecha_inicio_tramites")).ToString("yyyy/MM/dd")
                    'tx_aprobado_por.Text = comunes.traer_nombre_usuario(orow("f0502_usuario_aprobacion"))
                Else
                    'tx_aprobado_por.Text = "Pendiente"
                    tx_fecha_ini_tramites.Text = ""
                End If
            Next

            'Para activar el control de gestion de notas y archivos
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)

        End If

    End Sub
    Private Sub grabar_nueva_edicion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0502_documentos_ed" _
                & " (f0502_id_cia, f0502_id_documento, f0502_ed, f0502_descripcion_ed," _
                & " f0502_fecha_revision, f0502_usuario_revision," _
                & " f0502_fecha_aprobacion, f0502_usuario_aprobacion," _
                & " f0502_fecha_max_vigencia, f0502_fecha_inicio_tramites," _
                & " f0502_usuario_modificar, f0502_usuario_crear, f0502_fm)" _
                & " VALUES" _
                & " (@f0502_id_cia, @f0502_id_documento, @f0502_ed, @f0502_descripcion_ed," _
                & " @f0502_fecha_revision, @f0502_usuario_revision," _
                & " @f0502_fecha_aprobacion, @f0502_usuario_aprobacion," _
                & " @f0502_fecha_max_vigencia, @f0502_fecha_inicio_tramites," _
                & " @f0502_usuario_modificar, @f0502_usuario_crear, @f0502_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0502_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0502_id_documento", NpgsqlDbType.Integer).Value = id_documento
        ocmd.Parameters.Add("@f0502_ed", NpgsqlDbType.Integer).Value = ed_actual + 1
        ocmd.Parameters.Add("@f0502_descripcion_ed", NpgsqlDbType.Varchar).Value = tx_cambio.Text.Trim
        If tx_fecha_revision.Text = "" Or cm_revisadopor.SelectedValue = vg_usuario_nn Then
            ocmd.Parameters.Add("@f0502_fecha_revision", NpgsqlDbType.Timestamp).Value = DBNull.Value
            ocmd.Parameters.Add("@f0502_usuario_revision", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0502_fecha_revision", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_revision.Text)
            ocmd.Parameters.Add("@f0502_usuario_revision", NpgsqlDbType.Varchar).Value = cm_revisadopor.SelectedValue
        End If
        If tx_fecha_aprobacion.Text = "" Or cm_aprobadopor.SelectedValue = vg_usuario_nn Then
            ocmd.Parameters.Add("@f0502_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = DBNull.Value
            ocmd.Parameters.Add("@f0502_usuario_aprobacion", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0502_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_aprobacion.Text)
            ocmd.Parameters.Add("@f0502_usuario_aprobacion", NpgsqlDbType.Varchar).Value = cm_aprobadopor.SelectedValue
        End If
        If tx_fecha_max_vigencia.Text = "" Then
            ocmd.Parameters.Add("@f0502_fecha_max_vigencia", NpgsqlDbType.Timestamp).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0502_fecha_max_vigencia", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_max_vigencia.Text)
        End If
        If tx_fecha_ini_tramites.Text = "" Then
            ocmd.Parameters.Add("@f0502_fecha_inicio_tramites", NpgsqlDbType.Timestamp).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0502_fecha_inicio_tramites", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_ini_tramites.Text)
        End If
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

    Private Sub actualizar_edicion_documento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0502_documentos_ed set "
        csql += "f0502_descripcion_ed = @f0502_descripcion_ed,"
        csql += "f0502_fecha_revision = @f0502_fecha_revision,"
        csql += "f0502_usuario_revision = @f0502_usuario_revision,"
        csql += "f0502_fecha_aprobacion = @f0502_fecha_aprobacion,"
        csql += "f0502_usuario_aprobacion = @f0502_usuario_aprobacion,"
        csql += "f0502_fecha_max_vigencia = @f0502_fecha_max_vigencia,"
        csql += "f0502_fecha_inicio_tramites = @f0502_fecha_inicio_tramites,"
        csql += "f0502_fm = @f0502_fm,"
        csql += "f0502_usuario_modificar = @f0502_usuario_modificar"
        csql += " where f0502_id_ed = @f0502_id_ed"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0502_id_ed", NpgsqlDbType.Integer).Value = tx_id_doc_ed.Text
        ocmd.Parameters.Add("@f0502_descripcion_ed", NpgsqlDbType.Varchar).Value = tx_cambio.Text.Trim
        If tx_fecha_revision.Text = "" Or cm_revisadopor.SelectedValue = vg_usuario_nn Then
            ocmd.Parameters.Add("@f0502_fecha_revision", NpgsqlDbType.Timestamp).Value = DBNull.Value
            ocmd.Parameters.Add("@f0502_usuario_revision", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0502_fecha_revision", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_revision.Text)
            ocmd.Parameters.Add("@f0502_usuario_revision", NpgsqlDbType.Varchar).Value = cm_revisadopor.SelectedValue
        End If
        If tx_fecha_aprobacion.Text = "" Or cm_aprobadopor.SelectedValue = vg_usuario_nn Then
            ocmd.Parameters.Add("@f0502_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = DBNull.Value
            ocmd.Parameters.Add("@f0502_usuario_aprobacion", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0502_fecha_aprobacion", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_aprobacion.Text)
            ocmd.Parameters.Add("@f0502_usuario_aprobacion", NpgsqlDbType.Varchar).Value = cm_aprobadopor.SelectedValue
        End If
        If tx_fecha_max_vigencia.Text = "" Then
            ocmd.Parameters.Add("@f0502_fecha_max_vigencia", NpgsqlDbType.Timestamp).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0502_fecha_max_vigencia", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_max_vigencia.Text)
        End If
        If tx_fecha_ini_tramites.Text = "" Then
            ocmd.Parameters.Add("@f0502_fecha_inicio_tramites", NpgsqlDbType.Timestamp).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0502_fecha_inicio_tramites", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_ini_tramites.Text)
        End If
        ocmd.Parameters.Add("@f0502_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0502_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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

    Private Sub validar_descripcion_cambio()
        If tx_cambio.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Describa el cambio realizado en el documento."
        End If

    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_descripcion_cambio()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            grabar_nueva_edicion()
            Dispose()
        Else
            actualizar_edicion_documento()
        End If
        If verror = "N" Then
            MsgBox("Registro grabado", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub bt_fecha_rev_Click(sender As Object, e As EventArgs) Handles bt_fecha_rev.Click
        Try
            tx_fecha_revision.Text = CDate(comunes.formulario_fecha_hora(Now, "N")).ToString("yyyy/MM/dd")
        Catch ex As Exception
            tx_fecha_revision.Text = ""
        End Try
    End Sub

    Private Sub bt_fecha_aprob_Click(sender As Object, e As EventArgs) Handles bt_fecha_aprob.Click
        Try
            tx_fecha_aprobacion.Text = CDate(comunes.formulario_fecha_hora(Now, "N")).ToString("yyyy/MM/dd")
        Catch ex As Exception
            tx_fecha_aprobacion.Text = ""
        End Try
    End Sub

    Private Sub bt_fecha_max_vigencia_Click(sender As Object, e As EventArgs) Handles bt_fecha_max_vigencia.Click
        Try
            tx_fecha_max_vigencia.Text = CDate(comunes.formulario_fecha_hora(Now, "N")).ToString("yyyy/MM/dd")
        Catch ex As Exception
            tx_fecha_max_vigencia.Text = ""
        End Try
    End Sub

    Private Sub bt_fecha_ini_tramites_Click(sender As Object, e As EventArgs) Handles bt_fecha_ini_tramites.Click
        Try
            tx_fecha_ini_tramites.Text = CDate(comunes.formulario_fecha_hora(Now, "N")).ToString("yyyy/MM/dd")
        Catch ex As Exception
            tx_fecha_ini_tramites.Text = ""
        End Try
    End Sub

End Class
