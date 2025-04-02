Public Class fm_0600_p3_mef
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_accion As Integer
    '$Public$vf_elemento_nuevo As String = "N"
    Public id_estructura As Integer
    Public path_accion_base As String 'el path del numero de accion raiz o del problema analizado
    Public orow_info_accion As DataRow 'contiene el registro completo de la tabla de la accion principal.
    Public trasladar As String = "N"

    Private mef_seleccionado As Integer
    Private tipo_registro As String
    Private id_accion_padre As String 'el id de la accion seleccionada para crearle un hijo
    Private path_padre As String 'el path de la accion, causa, tarea seleccionada para crearle un hijo
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
    Private fila_actual As Integer 'fila actualmente activa en el datagrid

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private otb_info_mef As DataTable
    Private otb_estructura_mantenimiento As DataTable
    Private otb_acciones_hijos As DataTable


    Private Sub fm_0600_p3_mef_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos,
                                                                   vf_elemento_nuevo, vg_usuario_autoriza,
                                                                   Me, vf_id_notas_archivos, vf_otipo_nota,
                                                                   vf_var_config_archivos)
        cargar_mef()
        tx_mef.ReadOnly = True
        tx_id_mef.Enabled = False
        lb_accion.Text = ""
        'bt_editar.Enabled = False
        'bt_grabar.Enabled = False
    End Sub
    Private Sub cargar_mef()
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0609_modos_efectos_falla" _
            & " order by f0609_mef"
        otb_info_mef = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_mef
            'Valor que se muestra al usuario
            .DisplayMember = "f0609_mef"
            'Valor interno que almacena el objeto
            .ValueMember = "f0609_id_mef"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_mef
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub bt_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nuevo.Click
        cm_mef.SelectedIndex = -1
        cm_mef.Enabled = False
        vf_elemento_nuevo = "S"
        tx_id_mef.Text = ""
        tx_mef.Text = ""
        tx_mef.Enabled = False
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos,
                                                                   vf_elemento_nuevo, vg_usuario_autoriza,
                                                                   Me, vf_id_notas_archivos, vf_otipo_nota,
                                                                   vf_var_config_archivos)
    End Sub
    Private Sub validar_mef()
        If Len(tx_mef.Text.Trim) > 100 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "La longitud maxima del texto es de 100 caracteres"
        End If
        If tx_mef.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Describa algun Modo o Efecto de Falla"
        End If
    End Sub
    Private Sub cm_mef_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_mef.Validating
        If cm_mef.SelectedIndex = -1 Then
            lb_accion.Text = "Nuevo Registro"
            tx_mef.ReadOnly = True
            tx_mef.Text = cm_mef.Text
            tx_id_mef.Text = ""
            vf_elemento_nuevo = "S"
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos,
                                                                   vf_elemento_nuevo, vg_usuario_autoriza,
                                                                   Me, vf_id_notas_archivos, vf_otipo_nota,
                                                                   vf_var_config_archivos)
        Else
            tx_mef.Text = cm_mef.Text
            tx_id_mef.Text = cm_mef.SelectedValue
            lb_accion.Text = "Editar Registro"
            tx_mef.ReadOnly = False
            vf_elemento_nuevo = "N"
            vf_id_notas_archivos = cm_mef.SelectedValue
            'MsgBox(vf_id_notas_archivos)
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos,
                                                                   vf_elemento_nuevo, vg_usuario_autoriza,
                                                                   Me, vf_id_notas_archivos, vf_otipo_nota,
                                                                   vf_var_config_archivos)
        End If
    End Sub

    Private Sub grabar_nuevo_mef()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0609_modos_efectos_falla" _
                & " (f0609_mef," _
                & " f0609_usuario_crear, f0609_usuario_modificar, f0609_fm)" _
                & " VALUES" _
                & " (@f0609_mef," _
                & " @f0609_usuario_crear, @f0609_usuario_modificar, @f0609_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_nuevo_mef(ocmd)

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
    Private Sub crear_parametros_nuevo_mef(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0609_mef", NpgsqlDbType.Varchar).Value = tx_mef.Text.Trim
        ocmd.Parameters.Add("@f0609_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0609_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0609_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub actualizar_mef()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0609_modos_efectos_falla set " _
                    & " f0609_mef = '" & tx_mef.Text.Trim & "'" _
                    & " where f0609_id_mef = '" & tx_id_mef.Text & "'"
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
    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_mef()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            grabar_nuevo_mef()
            mef_seleccionado = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0609_id_mef", "f0609_usuario_crear", vg_usuario_autoriza, "tb0609_modos_efectos_falla")
            If IsNothing(vf_oform_padre) = False Then
                'vf_oform_padre.mef_seleccionado = mef_seleccionado
            End If
        Else
            mef_seleccionado = cm_mef.SelectedValue
            If IsNothing(vf_oform_padre) = False Then
                'vf_oform_padre.mef_seleccionado = cm_mef.SelectedValue
            End If
            'MsgBox("Hola")
            actualizar_mef()
        End If
        Dispose()
    End Sub
End Class
