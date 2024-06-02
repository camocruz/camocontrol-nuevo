Public Class fm_0500_digitalizar_registro
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_accion As Integer
    '$Public$vf_elemento_nuevo As String = "N"
    Public id_registro As Integer = 0

    Private new_name_file As String = ""

    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private verror As String = "N"


    Private Sub fm_0500_digitalizar_registro_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False
        bt_generar_informe.Enabled = False
        bt_editar.Enabled = False


        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0501_documentos" 
        Dim otb_documentos As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
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
        With cm_titulo_documento
            'Valor que se muestra al usuario
            .DisplayMember = "f0501_titulo_documento"
            'Valor interno que almacena el objeto
            .ValueMember = "f0501_id_documento"
            'Origen de Datos del ComboBox
            .DataSource = otb_documentos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        If id_registro = 0 Then
            vf_elemento_nuevo = "S"
        Else
            cargar_info_registro()
            vf_elemento_nuevo = "N"
            'PARA CONTROLAR LA INFORMACION DE LOS DOCUMENTOS ASOCIADOS
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-RGT-001", vg_id_cia)
            new_name_file += "-" & tx_id_registro.Text.PadLeft(8, "0")
            lb_total_soportes.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-RGT-001", tx_id_registro.Text, vg_id_cia) 'calcular_archivos_asociados()
            bt_nuevo_soporte.Enabled = True
            bt_ver_archivos_asociados.Enabled = True
        End If

    End Sub

    Private Sub cargar_info_registro()
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0550_registros" _
            & " where f0550_id_registro = '" & id_registro & "'"
        Dim otb_info_registro As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_registro.Rows
            tx_id_registro.Text = orow("f0550_id_registro")
            cm_codigo_documento.SelectedValue = orow("f0550_id_documento")
            cm_titulo_documento.SelectedValue = orow("f0550_id_documento")
            dtp_fecha_registro.Value = orow("f0550_fecha_registro")
            tx_turno.Text = orow("f0550_turno").ToString
            tx_anotacion.Text = orow("f0550_nota").ToString
        Next
    End Sub

    Private Sub cm_codigo_documento_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_codigo_documento.Validating
        If cm_codigo_documento.SelectedIndex = -1 Then
            cm_codigo_documento.Text = ""
            cm_titulo_documento.Text = ""
        Else
            cm_titulo_documento.SelectedValue = cm_codigo_documento.SelectedValue
        End If
    End Sub

    Private Sub cm_titulo_documento_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_titulo_documento.Validating
        If cm_titulo_documento.SelectedIndex = -1 Then
            cm_codigo_documento.Text = ""
            cm_titulo_documento.Text = ""
        Else
            cm_codigo_documento.SelectedValue = cm_titulo_documento.SelectedValue
        End If
    End Sub

    Private Sub grabar_nuevo_registro()

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "insert into " + database.obtener_esquema + ".tb0550_registros" _
            & " (" _
            & " f0550_id_cia, f0550_id_documento, f0550_fecha_registro, f0550_turno, f0550_nota," _
            & " f0550_fm, f0550_usuario_crear," _
            & " f0550_usuario_modificar" _
            & ") values" _
            & " (" _
            & " @f0550_id_cia, @f0550_id_documento, @f0550_fecha_registro, @f0550_turno, @f0550_nota," _
            & " @f0550_fm, @f0550_usuario_crear," _
            & " @f0550_usuario_modificar" _
            & ")"

        ocmd.CommandText = csql

        'Inserción parametrizada
        crear_parametros_registro(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! grabando tercero" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error grabando tercero" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub actualizar_registro()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0550_registros set" _
            & " f0550_id_documento = @f0550_id_documento," _
            & " f0550_fecha_registro = @f0550_fecha_registro," _
            & " f0550_turno = @f0550_turno," _
            & " f0550_nota = @f0550_nota," _
            & " f0550_fm = @f0550_fm," _
            & " f0550_usuario_modificar = @f0550_usuario_modificar" _
            & " where f0550_id_registro = '" & id_registro & "'"

        ocmd.CommandText = csql

        'Inserción parametrizada
        crear_parametros_registro(ocmd)
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar Registro! " + vbCrLf + ex.ToString)
        End Try
    End Sub

    Private Sub crear_parametros_registro(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0550_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0550_id_documento", NpgsqlDbType.Integer).Value = cm_codigo_documento.SelectedValue
        ocmd.Parameters.Add("f0550_fecha_registro", NpgsqlDbType.Timestamp).Value = dtp_fecha_registro.Value
        ocmd.Parameters.Add("f0550_turno", NpgsqlDbType.Varchar).Value = tx_turno.Text.ToString.Trim
        ocmd.Parameters.Add("f0550_nota", NpgsqlDbType.Varchar).Value = tx_anotacion.Text.ToString.Trim
        ocmd.Parameters.Add("f0550_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("f0550_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0550_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub

    Private Sub validar_id_documento()
        If cm_codigo_documento.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione el documento que va a digitalizar"
            verror_requisitos = "S"
            Exit Sub
        End If
    End Sub

    Private Sub grabar()
        verror_requisitos = "N"
        validar_id_documento()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            grabar_nuevo_registro()
            id_registro = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0550_id_registro", "f0550_usuario_crear", vg_usuario_autoriza, "tb0550_registros")
            tx_id_registro.Text = id_registro
            new_name_file = comunes.suministrar_valor_variable_configuracion("CD-RGT-001", vg_id_cia)
            new_name_file += "-" & tx_id_registro.Text.PadLeft(8, "0")
            vf_elemento_nuevo = "N"
        Else
            actualizar_registro()
        End If

        If verror = "N" Then
            MsgBox("Actualización Terminada", MsgBoxStyle.Information, "Proceso terminado")
        End If
    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        grabar()
    End Sub

    Private Sub bt_nuevo_soporte_Click(sender As Object, e As EventArgs) Handles bt_nuevo_soporte.Click
        If tx_id_registro.Text.ToString.Trim = "" Then
            MsgBox("Debe grabar primero el registro", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-RGT", tx_id_registro.Text, vg_id_cia, vg_usuario_autoriza, "N")
        lb_total_soportes.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-RGT-001", tx_id_registro.Text, vg_id_cia)
    End Sub

    Private Sub bt_ver_archivos_asociados_Click(sender As Object, e As EventArgs) Handles bt_ver_archivos_asociados.Click
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

    Private Sub bt_nuevo_Click(sender As Object, e As EventArgs) Handles bt_nuevo.Click
        id_registro = 0
        vf_elemento_nuevo = "S"
        tx_id_registro.Text = ""
        cm_codigo_documento.SelectedIndex = -1
        cm_titulo_documento.SelectedIndex = -1
        tx_turno.Text = ""
        dtp_fecha_registro.Value = comunes.g_fechahora
        tx_anotacion.Text = ""
    End Sub
End Class
