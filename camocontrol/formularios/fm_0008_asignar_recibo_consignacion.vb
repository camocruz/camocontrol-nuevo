Public Class fm_0008_asignar_recibo_consignacion

    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    'Private$vf_otabla_permisos$As DataTable

    Public id_recaudo As Integer
    Private editando_registro As String = "N"
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand

    Private req_soporte As String = "S"

    Private recaudo As String = "N" 'indica si se trata del regsitro del recauudo-recibo cg o es identificacion.
    Private orow_info_recaudo As DataRow
    Private otb_tercero As DataTable
    Private path_file As String = ""
    Private extension As String = ""
    Private new_name_file As String = ""
    Private new_path_file As String = ""


    Private Sub fm_0008_asignar_recibo_consignacion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        'Recordar definir la variable vf_id_notas_archivos
        vf_var_config_archivos = "CD-SRB"
        vf_var_config_notas = "TN-SRB-001"
        vf_id_notas_archivos = id_recaudo
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)

        bt_nuevo.Enabled = False
        bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_generar_informe.Enabled = False
        bt_grabar.Enabled = False

        'Activar grabar si tiene permisos para esto
        cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_grabar, ocontexto_form)
        cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_anular, ocontexto_form)

        tx_fecha_reportado.ReadOnly = True
        tx_funcionario_reporta.ReadOnly = True
        tx_fecha_identificado.ReadOnly = True
        tx_funcionario_identifica.ReadOnly = True

        cargar_info_recaudo(id_recaudo)
        cargar_info_terceros()

        'Identificamos los tipos de documentos que identifican un recibo de caja. alimenta el listado tipo de recibo.
        Dim ovarvalue As String = comunes.suministrar_valor_variable_configuracion("CONFIG-0010-01", vg_id_cia)
        Dim olist_doc As String()
        olist_doc = Split(ovarvalue, ",")
        For Each oitem As String In olist_doc
            cm_tipo_recibo.Items.Add(oitem)
        Next
        With cm_tipo_recibo
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

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

        req_soporte = orow_info_recaudo("f0010_req_soporte")
        If req_soporte = "N" Then
            lb_convenio.Visible = False
        Else
            lb_convenio.Visible = True
        End If
        tx_id_recaudo.Text = orow_info_recaudo("f0010_id_recaudo")
        tx_valor.Text = orow_info_recaudo("f0010_col_credito")
        Label8.Text = "Registrado: " & CDate(orow_info_recaudo("f0010_fr")).ToString("yyyy-MM-dd hh:mm tt")
        Dim info_tercero(1) As String 'crea el arreglo con informacion de cedula y nombre del funcionario
        If orow_info_recaudo("f0010_anulado") = "S" Then
            lb_titulo.Text = "REGISTRO ANULADO"
            bt_grabar.Visible = False
            bt_anular.Visible = False
        End If

        If orow_info_recaudo("f0010_cliente_identificado").ToString.Trim = "" Then
            recaudo = "N"
            'MsgBox("Este recaudo no ha sido identificado!", MsgBoxStyle.Exclamation, "Alerta")
            tx_numero_recibo.Enabled = False
            tx_nota_recibo.ReadOnly = True
            cm_tipo_recibo.Enabled = False
        Else
            recaudo = "S"
            cm_nit.Enabled = False
            cm_razon_social.Enabled = False
            txt_nota_identificacion.ReadOnly = True
            tx_fecha_identificado.Text = CDate(orow_info_recaudo("f0010_fecha_identificado")).ToString("yyyy-MM-dd hh:mm tt")
            info_tercero = comunes.traer_nit_nombre_usuario(orow_info_recaudo("f0010_usuario_identifica").ToString)
            tx_funcionario_identifica.Text = info_tercero(1)
            info_tercero = comunes.traer_nit_nombre_usuario(orow_info_recaudo("f0010_cliente_identificado").ToString)
            cm_nit.SelectedValue = orow_info_recaudo("f0010_cliente_identificado")
            cm_razon_social.SelectedValue = orow_info_recaudo("f0010_cliente_identificado")
            txt_nota_identificacion.Text = orow_info_recaudo("f0010_nota_identificacion").ToString
        End If
        If orow_info_recaudo("f0010_identificado") = "S" And orow_info_recaudo("f0010_recibo") = "S" Then
            bt_grabar.Enabled = False
            tx_fecha_identificado.ReadOnly = True
            cm_nit.Enabled = False
            cm_razon_social.Enabled = False
            txt_nota_identificacion.ReadOnly = True
            cm_tipo_recibo.Enabled = False
            tx_numero_recibo.Enabled = False
            tx_nota_recibo.ReadOnly = True
            tx_fecha_reportado.Text = CDate(orow_info_recaudo("f0010_fecha_registro_recibo")).ToString("yyyy-MM-dd hh:mm tt")
            info_tercero = comunes.traer_nit_nombre_usuario(orow_info_recaudo("f0010_funcionario_recibo").ToString)
            tx_funcionario_reporta.Text = info_tercero(1)
            cm_tipo_recibo.Text = Mid(orow_info_recaudo("f0010_documento_recibo"), 1, 2)
            tx_numero_recibo.Text = CInt(Mid(orow_info_recaudo("f0010_documento_recibo"), 4, 15))
            tx_nota_recibo.Text = orow_info_recaudo("f0010_nota_recibo").ToString
            'Activamos el boton de editar si tiene permisos
            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_editar, ocontexto_form)
        End If
        'calcular_archivos_asociados()
        'activar_grabar()
        'new_name_file = comunes.suministrar_valor_variable_configuracion("CD-SRB-001", vg_id_cia)
        'new_name_file += "-" & tx_id_recaudo.Text.PadLeft(8, "0")
        'new_path_file = comunes.suministrar_valor_variable_configuracion("CD-SRB-002", vg_id_cia)
    End Sub
    Private Sub activar_grabar()
        'MsgBox(req_soporte)
        If req_soporte = "S" Then
            If CInt(bt_g_archivos.Text) >= 1 Then
                'bt_grabar.Enabled = True
                cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_grabar, ocontexto_form)
            End If
        Else
            If orow_info_recaudo("f0010_identificado") = "S" And orow_info_recaudo("f0010_recibo") = "S" Then
                'No lo active porque ya es un registro grabado, se activara cuando se precione editar
            Else
                cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_grabar, ocontexto_form)
            End If
        End If
    End Sub

    Private Sub cargar_info_terceros()
        csql = "select f0200_id_tercero, f0200_id, f0200_nombres" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_ind_cliente = 'S'" _
            & " order by f0200_nombres"
        otb_tercero = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub cargar_info_recaudo(id_recaudo As Integer)
        'cargamos los registros gravados para este banco con el fin de impedir duplicados
        Dim otb_registro_recaudo As DataTable
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0010_bancos_recaudos" _
            & " where f0010_id_recaudo = '" & id_recaudo & "'"
        otb_registro_recaudo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_registro_recaudo.Rows
            orow_info_recaudo = orow
        Next
    End Sub
    Private Sub tx_recibo_cg_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tx_numero_recibo.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub validar_recibo()
        If tx_numero_recibo.Text = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Registre el numero del recibo creado en el sistema!"
            Exit Sub
        End If

        If editando_registro = "N" Then
            'verificamos que el recaudo no tenga asignado un recibo o que se este trabajando en diferentes comp al mismo tiempo.
            cargar_info_recaudo(id_recaudo)
            If orow_info_recaudo("f0010_recibo") = "S" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "El recaudo ya tiene un recibo asignado."
                Dispose()
            End If
        End If

        'verificamos si existe algun registro con el mismo numero de recibo
        Dim otb_registro_recibo As DataTable
        Dim tx_registro_con_recibo As String = ""
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0010_bancos_recaudos" _
            & " where f0010_documento_recibo = '" & cm_tipo_recibo.Text & "-" & tx_numero_recibo.Text.Trim.PadLeft(8, "0") & "'"
        otb_registro_recibo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_registro_recibo.Rows
            tx_registro_con_recibo = orow("f0010_id_recaudo")
        Next
        If otb_registro_recibo.Rows.Count > 0 And tx_registro_con_recibo <> tx_id_recaudo.Text Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El numero del recibo ya esta asignado en el recaudo: " & tx_registro_con_recibo
        End If
    End Sub
    Private Sub cm_nit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_nit.Validating
        If cm_nit.SelectedIndex <> -1 Then
            cm_razon_social.SelectedValue = cm_nit.SelectedValue
            Exit Sub
        End If
        cm_razon_social.Text = ""
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Crear Tercero", "El NIT no existe" & vbCrLf & "Desea crear un nuevo Tercero?")
        If respuesta = "N" Then
            Exit Sub
        Else
            cm_nit.Text = ""
            cm_razon_social.Text = ""
        End If
        cm_nit.SelectedIndex = -1
        cm_razon_social.SelectedIndex = -1
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_terceros As New camocontrol.fm_0200_tercero
        'oform_grilla_programacion.ods_hijo = ods
        oform_terceros.vf_oform_padre = Me
        oform_terceros.vg_id_cia = vg_id_cia
        oform_terceros.vg_usuario_autoriza = vg_usuario_autoriza
        oform_terceros.ShowDialog()
        If respuesta = "S" Then
            cargar_info_terceros()
            cm_nit.DataSource = otb_tercero
            cm_razon_social.DataSource = otb_tercero
            cm_razon_social.SelectedValue = cm_nit.SelectedValue
        End If
    End Sub
    Private Sub validar_nit()
        If cm_nit.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Identifique al cliente que se le esta asignado la consignacion!."
        End If
    End Sub
    Private Sub validar_tipo_recibo()
        If cm_tipo_recibo.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Identifique el tipo de recibo que esta generando!."
        End If
    End Sub
    Private Sub validar_archivo_soporte()
        If req_soporte = "S" Then
            If CInt(bt_g_archivos.Text) = 0 Then
                verror_requisitos = "S"
                vmensaje_requisitos = "El soporte de la consignacion es requerido!."
            End If
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        If recaudo = "N" Then
            validar_nit()
        Else
            validar_tipo_recibo()
            validar_recibo()
            validar_archivo_soporte()
        End If
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Grabar Accion", "Desea grabar cambios en este registro?")
        If respuesta = "N" Then
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

        actualizar_recaudo()
        If verror = "N" Then
            MsgBox("Recibo registrado", MsgBoxStyle.Information, "Informacion")
            Dispose()
        End If
    End Sub
    Private Sub actualizar_recaudo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0010_bancos_recaudos set "
        csql += "f0010_usuario_identifica = @f0010_usuario_identifica,"
        csql += "f0010_fecha_identificado = @f0010_fecha_identificado,"
        csql += "f0010_cliente_identificado = @f0010_cliente_identificado,"
        csql += "f0010_nota_identificacion = @f0010_nota_identificacion,"
        csql += "f0010_identificado = @f0010_identificado,"

        csql += "f0010_recibo = @f0010_recibo,"
        csql += "f0010_documento_recibo = @f0010_documento_recibo,"
        csql += "f0010_nota_recibo = @f0010_nota_recibo,"
        csql += "f0010_fecha_registro_recibo = @f0010_fecha_registro_recibo,"
        csql += "f0010_funcionario_recibo = @f0010_funcionario_recibo,"

        csql += "f0010_fm = @f0010_fm,"
        csql += "f0010_usuario_modificar = @f0010_usuario_modificar"
        csql += " where f0010_id_recaudo = @f0010_id_recaudo"
        '
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_recaudos(ocmd)
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
    Private Sub crear_parametros_recaudos(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0010_id_recaudo", NpgsqlDbType.Integer).Value = id_recaudo
        If recaudo = "N" Then
            ocmd.Parameters.Add("@f0010_usuario_identifica", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
            ocmd.Parameters.Add("@f0010_fecha_identificado", NpgsqlDbType.Timestamp).Value = ofecha
            ocmd.Parameters.Add("@f0010_cliente_identificado", NpgsqlDbType.Varchar).Value = cm_nit.SelectedValue
            ocmd.Parameters.Add("@f0010_nota_identificacion", NpgsqlDbType.Varchar).Value = txt_nota_identificacion.Text.Trim
            ocmd.Parameters.Add("@f0010_identificado", NpgsqlDbType.Varchar).Value = "S"

            ocmd.Parameters.Add("@f0010_recibo", NpgsqlDbType.Varchar).Value = "N"
            ocmd.Parameters.Add("@f0010_documento_recibo", NpgsqlDbType.Varchar).Value = ""
            ocmd.Parameters.Add("@f0010_nota_recibo", NpgsqlDbType.Varchar).Value = ""
            ocmd.Parameters.Add("@f0010_fecha_registro_recibo", NpgsqlDbType.Timestamp).Value = DBNull.Value
            ocmd.Parameters.Add("@f0010_funcionario_recibo", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0010_usuario_identifica", NpgsqlDbType.Varchar).Value = orow_info_recaudo("f0010_usuario_identifica")
            ocmd.Parameters.Add("@f0010_fecha_identificado", NpgsqlDbType.Timestamp).Value = orow_info_recaudo("f0010_fecha_identificado")
            ocmd.Parameters.Add("@f0010_cliente_identificado", NpgsqlDbType.Varchar).Value = cm_nit.SelectedValue
            ocmd.Parameters.Add("@f0010_nota_identificacion", NpgsqlDbType.Varchar).Value = txt_nota_identificacion.Text.Trim
            ocmd.Parameters.Add("@f0010_identificado", NpgsqlDbType.Varchar).Value = "S"

            ocmd.Parameters.Add("@f0010_recibo", NpgsqlDbType.Varchar).Value = "S"
            Dim numero_recibo As String = cm_tipo_recibo.Text & "-" & tx_numero_recibo.Text.Trim.PadLeft(8, "0")
            ocmd.Parameters.Add("@f0010_documento_recibo", NpgsqlDbType.Varchar).Value = numero_recibo
            ocmd.Parameters.Add("@f0010_nota_recibo", NpgsqlDbType.Varchar).Value = tx_nota_recibo.Text.ToString.Trim
            ocmd.Parameters.Add("@f0010_fecha_registro_recibo", NpgsqlDbType.Timestamp).Value = ofecha
            ocmd.Parameters.Add("@f0010_funcionario_recibo", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        End If
        ocmd.Parameters.Add("@f0010_fm", NpgsqlDbType.Timestamp).Value = ofecha
        ocmd.Parameters.Add("@f0010_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub

    Private Sub bt_editar_Click(sender As System.Object, e As System.EventArgs) Handles bt_editar.Click
        editando_registro = "S"
        tx_numero_recibo.Enabled = True
        tx_nota_recibo.ReadOnly = False
        cm_tipo_recibo.Enabled = True
        cm_nit.Enabled = True
        cm_razon_social.Enabled = True
        txt_nota_identificacion.ReadOnly = False
        'cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_nuevo_soporte, ocontexto_form)
        'cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_grabar, ocontexto_form)
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular", "Desea ANULAR este registro?")
        If respuesta = "N" Then
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

        anular_recaudo()
        If verror = "N" Then
            MsgBox("Recibo anulado", MsgBoxStyle.Information, "Informacion")
            Dispose()
        End If
    End Sub
    Private Sub anular_recaudo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0010_bancos_recaudos set "
        csql += "f0010_anulado = 'S',"
        csql += "f0010_usuario_anular = @f0010_usuario_modificar,"
        csql += "f0010_fm = @f0010_fm,"
        csql += "f0010_usuario_modificar = @f0010_usuario_modificar"
        csql += " where f0010_id_recaudo = @f0010_id_recaudo"
        '
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_recaudos(ocmd)
        ocmd.Parameters.Clear()
        Dim ofecha As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0010_id_recaudo", NpgsqlDbType.Integer).Value = id_recaudo
        ocmd.Parameters.Add("@f0010_fm", NpgsqlDbType.Timestamp).Value = ofecha
        ocmd.Parameters.Add("@f0010_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
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
End Class
