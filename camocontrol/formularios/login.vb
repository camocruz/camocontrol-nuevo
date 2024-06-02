Public Class login
    'Objetos publicos que reciben valores desde el Formulario padre
    Public vf_oform_padre As Object
    Public ocontexto_form As String = "1"
    '1 = modo normal, devuelve valores hacia un form padre
    '2 = modo que actualiza valor hacia el form de inicio para usar en clases

    'Public ods_hijo As DataSet
    'Variable a usar para determinar si el formulario fue instanciado en otro formulario para validar usuarios
    Public paso_autorizacion = "N"

    Private vg_id_cia As String = ""
    Private vcerrar As String = "N"
    Private vexiste As String = "N"
    Private vusuario As String = ""
    Private vempleado As String = ""
    Private vnombreu As String = ""
    Private vclave As String = ""
    Private vestado As String = ""
    Private csql As String = ""
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand
    Private odr As NpgsqlDataReader

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tx_compania.Text = "MASDULCES"

        csql = "select f0021_id_usuario, f0021_nombre_completo, f0200_estado" _
           & " from " + database.obtener_esquema & ".tb0021_usuarios" _
             & " join " & database.obtener_esquema & ".tb0200_terceros" _
               & " on f0021_id_usuario = f0200_id_tercero" _
           & " order  by tb0021_usuarios.f0021_nombre_completo"
        oconn_form = database.obtener_conexion()

        Dim oda As New NpgsqlDataAdapter(csql, oconn_form)
        Dim ods As New DataSet
        Try
            oda.Fill(ods, "usuarios")
        Catch ex As Exception
            MsgBox("(Proveedor: proveedor de canalizaciones con nombre, error: 40 - No se pudo abrir la conexión con SQL Server)", MsgBoxStyle.Critical, "System")
            Application.Exit()
        End Try


        With cm_empleados
            .DisplayMember = "f0021_nombre_completo"
            .ValueMember = "f0021_id_usuario"
            .DataSource = ods.Tables("usuarios")
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        oconn_form.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ejecutar()
    End Sub
    Private Sub ejecutar()
        If Trim(tx_usuario.Text) = "" Then
            validaciones.g_mensajes("1", "Digite usuario")
            Exit Sub
        End If
        If Trim(tx_clave.Text) = "" Then
            validaciones.g_mensajes("1", "Digite clave del usuario")
            Exit Sub
        End If
        If Trim(tx_compania.Text) = "" Then
            validaciones.g_mensajes("1", "Digite la Compañia")
            Exit Sub
        End If

        csql = "select f0001_id_cia from " & database.obtener_esquema & ".tb0001_compania"
        csql += " where f0001_codigo = '" & tx_compania.Text.Trim & "'"

        Try
            odr = database.get_data_reader(csql)
        Catch ex As Exception
            MsgBox("(Proveedor: proveedor de canalizaciones con nombre, error: 40 - No se pudo abrir la conexión con SQL Server)", MsgBoxStyle.Critical, "System")
            Application.Exit()
        End Try

        vexiste = "N"
        While odr.Read
            vg_id_cia = odr.Item("f0001_id_cia")
            vexiste = "S"
        End While
        odr.Close()
        If vexiste = "N" Then
            validaciones.g_mensajes("1", "La compañia no existe")
            Exit Sub
        End If


        '**** este bloque era para trabajar con el combo cm_empleados.
        'If cm_empleados.SelectedValue = String.Empty Then
        'validaciones.g_mensajes("1", "Seleccione un empleado")
        'Exit Sub
        'End If
        'vempleado = cm_empleados.SelectedValue
        'csql = "select * from " + database.obtener_esquema + ".tb_usuarios where identificacion = '" + vempleado + "' "
        'odr = database.get_data_reader(csql)
        'vexiste = "N"
        'While odr.Read
        'vclave = odr.Item("clave")
        'vnombreu = odr.Item("nombre_completo")
        'vempleado = odr.Item("identificacion")
        'End While
        'odr.Close()

        'PARA IDENTIFICAR EL USUARIO Y SUS DATOS
        csql = "select *" _
              & " from " & database.obtener_esquema & ".tb0021_usuarios" _
              & " join " & database.obtener_esquema & ".tb0200_terceros" _
               & " on f0021_id_usuario = f0200_id_tercero" _
               & " where f0021_nombre_completo = '" + Trim(tx_usuario.Text.ToString) + "' and" _
               & " f0021_id_cia = '" & vg_id_cia & "'"
        Try
            odr = database.get_data_reader(csql)
        Catch ex As Exception
            MsgBox("(Proveedor: proveedor de canalizaciones con nombre, error: 40 - No se pudo abrir la conexión con SQL Server)", MsgBoxStyle.Critical, "System")
            Application.Exit()
        End Try

        vexiste = "N"
        While odr.Read
            vclave = odr.Item("f0021_clave")
            vnombreu = odr.Item("f0021_nombre_completo")
            vempleado = odr.Item("f0021_id_usuario")
            'vg_id_cia = odr.Item("f0021_id_cia")
            vexiste = "S"
            vestado = odr.Item("f0200_estado")
        End While
        odr.Close()

        If Trim(vclave) <> Trim(tx_clave.Text) Then
            validaciones.g_mensajes("1", "Clave o usuario incorrecto")
            tx_clave.Text = ""
            Exit Sub
        End If
        If vestado = "I" Then
            validaciones.g_mensajes("1", "Clave o usuario incorrecto I")
            tx_clave.Text = ""
            Exit Sub
        End If
        Dim oform_menu As New camocontrol.formulario_inicio

        Me.Hide()

        Select Case ocontexto_form
            Case "1"
                If paso_autorizacion = "N" Then
                    oform_menu.vlogin = vempleado
                    oform_menu.vg_id_cia = vg_id_cia
                    oform_menu.vpassword = tx_clave.Text
                    oform_menu.vnombreusuario = vnombreu
                    oform_menu.ShowDialog()
                Else
                    vf_oform_padre.autoriza = "S"
                    vf_oform_padre.vg_usuario_autoriza = vempleado
                    vf_oform_padre.nombre_usuario_autoriza = vnombreu
                End If
            Case "2"
                formulario_inicio.usuario_validado = vempleado
                'MsgBox(vempleado)
        End Select

        Me.Close()
    End Sub
    Private Sub bt_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_cancelar.Click
        Me.Close()
    End Sub
    Private Sub permisos_usuario()
        Dim opermiso_usuario As New cl_permiso_usuario
        'Dim ogestion_permisos As New cl_gestion_permisos
        Dim olista_permisos_usuario As New List(Of cl_permiso_usuario)()

    End Sub
    Private Sub tx_clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_clave.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            ejecutar()
        End If
    End Sub
    Private Sub tx_usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_usuario.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            tx_clave.Focus()
        End If
    End Sub

    Private Sub tx_compania_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_compania.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            tx_usuario.Focus()
        End If
    End Sub
End Class
