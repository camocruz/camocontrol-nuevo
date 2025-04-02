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
        csql = "SELECT *, f0300_descripcion_item || ' ' || ' ' || f0300_contenido_x_empaque as descripcion_larga" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_id_cia = '" & vg_id_cia & "' and f0300_anulado = 'N'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)

    End Sub
    Private Sub tx_id_item_Validated(sender As Object, e As EventArgs) Handles tx_id_item.Validated
        If IsNumeric(tx_id_item.Text) = False Or tx_id_item.Text.Trim = "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        Cargar_informacion_item()
    End Sub

#Region "ControlaBusquedaItems"
    Private Sub Bt_listado_general_items_Click(sender As Object, e As EventArgs) Handles bt_listado_general_items.Click
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0300-34", vg_id_cia, vg_usuario_autoriza,
        '                                                    "Listado General de Items", {vg_id_cia})
        Buscar_item()
    End Sub
    Private Sub tx_item_descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles tx_item_descripcion.KeyDown
        If (e.KeyCode = Keys.B AndAlso e.Modifiers = Keys.Control) Then
            'PARA USAR CUANDO EL FORMULARIO ES PARA SELECCIONAR UN DATO
            'MsgBox(dg_datos.CurrentRow.Cells("id_sc").Value)
            Buscar_item()
        End If
        If (e.KeyCode = Keys.Enter) Then
            'PARA USAR CUANDO EL FORMULARIO ES PARA SELECCIONAR UN DATO
            'MsgBox(dg_datos.CurrentRow.Cells("id_sc").Value)
            Buscar_item()
        End If
    End Sub

    Private Sub Buscar_item()
        Dim filtro As String = ""
        If tx_item_descripcion.Text <> "" Then
            'filtro = "descripcion_larga LIKE '%" & tx_item_descripcion.Text.Trim & "%'"
            filtro = comunes.generador_filtro_like("descripcion_larga", tx_item_descripcion.Text.Trim)
        End If
        tx_item_descripcion.Text = ""

        Dim id_it As Integer = comunes.Buscador_item(vg_id_cia, vg_usuario_autoriza, filtro)
        If id_it = 0 Then
            tx_id_item.Text = ""
        Else
            tx_id_item.Text = id_it
            tx_id_item.Focus()
        End If
        bt_consultar_movimientos.Focus()
    End Sub

    Private Sub Cargar_informacion_item()
        'Identificamos informacion de la estructura seleccionada.
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If
        Dim rowprod As DataRow() = otb_items.Select("f0300_id_item ='" & tx_id_item.Text & "'")
        For Each orow As DataRow In rowprod
            tx_item_descripcion.Text = orow("f0300_descripcion_item").ToString.Trim
        Next
    End Sub
#End Region

    Private Sub bt_consultar_movimientos_Click(sender As Object, e As EventArgs) Handles bt_consultar_movimientos.Click
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If
        cl_utilidades_gestion_compras.movimientos_compras_item(tx_id_item.Text, vg_usuario_autoriza, vg_id_cia)
    End Sub


End Class
