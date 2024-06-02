Public Class fm_parametro_texto
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = "1"
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public ocombobox As String = "N"
    Public otb_combobox As DataTable
    Public ODisplayMember As String = ""
    Public OValueMember As String = ""
    Public Oselectedvalue As String = ""
    Public OselectedText As String = ""
    Public otexto_descripcion As String = ""
    Public ocancelar As String = "S"

    Private Sub fm_parametro_texto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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
        bt_nuevo.Enabled = False
        bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_generar_informe.Enabled = False
        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False

        If ocombobox = "S" Then
            tx_texto.ReadOnly = True
            tx_texto.Visible = False
            cm_combo.Enabled = True
            cm_combo.Visible = True
            With cm_combo
                'Valor que se muestra al usuario
                .DisplayMember = ODisplayMember
                'Valor interno que almacena el objeto
                .ValueMember = OValueMember
                'Origen de Datos del ComboBox
                .DataSource = otb_combobox
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
                If Oselectedvalue <> "" Then
                    .SelectedValue = Oselectedvalue
                Else
                    If OselectedText <> "" Then
                        .Text = OselectedText
                    End If
                End If
            End With
            cm_combo.Select()
        Else
            tx_texto.ReadOnly = False
            tx_texto.Visible = True
            cm_combo.Visible = False
            cm_combo.Enabled = False
            tx_texto.Select()
        End If
    End Sub
    Private Sub ejecutar()
        If ocombobox = "S" Then
            If cm_combo.SelectedIndex = -1 Then
                otexto_descripcion = ""
            Else
                otexto_descripcion = cm_combo.SelectedValue
            End If
        Else
            otexto_descripcion = tx_texto.Text.ToString.Trim
        End If
        ocancelar = "N"
        Me.Hide()
    End Sub
    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        ejecutar()
    End Sub

    Private Sub tx_texto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_texto.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            ejecutar()
        End If
    End Sub
End Class
