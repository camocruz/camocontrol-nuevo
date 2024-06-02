Public Class fm_0300_historico_compras_item
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_estructura As Integer
    Public id_accion As Integer
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_solicitud_compra As Integer 'se asigna cuando se llama al formulario desde el fm_padre
    Public id_item_solicitud As Integer 'registro del item solicitado en la tabla tb0305_items_solicitados

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
    Private otb_items As DataTable
    Private otb_unidades As DataTable

    Private Sub fm_0300_historico_compras_item_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        csql = "select * from " & database.obtener_esquema & ".tb0002_unidades_medicion"
        otb_unidades = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = "SELECT *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_id_cia = '" & vg_id_cia & "'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_descripcion
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion_larga"
            'Valor interno que almacena el objeto
            .ValueMember = "f0300_id_item"
            'Origen de Datos del ComboBox
            .DataSource = otb_items
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub tx_id_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_id_item.Validating
        If IsNumeric(tx_id_item.Text) = False Or tx_id_item.Text.Trim = "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        cm_descripcion.Focus()
        cm_descripcion.SelectedValue = CInt(tx_id_item.Text)
    End Sub
    Private Sub cm_descripcion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_descripcion.Validating
        If cm_descripcion.SelectedIndex = -1 Then
            If cm_descripcion.Text.ToString.Trim <> "" Then
                MsgBox("El Item no existe", MsgBoxStyle.Information, "Error")
            End If
            cm_descripcion.Text = ""
            tx_id_item.Text = ""
        Else
            tx_id_item.Text = CInt(cm_descripcion.SelectedValue)
        End If
    End Sub
    Private Sub bt_consultar_movimientos_Click(sender As Object, e As EventArgs) Handles bt_consultar_movimientos.Click
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If
        cl_utilidades_gestion_compras.movimientos_compras_item(tx_id_item.Text, vg_usuario_autoriza, vg_id_cia)
    End Sub
End Class
