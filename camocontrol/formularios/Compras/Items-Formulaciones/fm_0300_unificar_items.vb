Imports System.ComponentModel

Public Class fm_0300_unificar_items
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    Public id_item As Integer = 0

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
    Private otb_items2 As DataTable

    Private Sub fm_0300_unificar_items_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************


        csql = "SELECT f0300_id_item, f0300_descripcion_item,"
        csql += " count(f0350_id_plantilla) As plantillas"
        csql += " from " & database.obtener_esquema & ".tb0300_items"
        csql += " left join " & database.obtener_esquema & ".tb0350_plantillas"
        csql += " On f0300_id_item = f0350_id_item"
        csql += " where f0300_id_cia = '00000001' and f0300_anulado = 'N'"
        csql += " group by f0300_id_item"
        csql += " having count(f0350_id_plantilla) = 0"
        csql += " order by f0300_descripcion_item"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Clipboard.SetText(csql)
        'MsgBox("hola")
        With cm_descripcion_queda
            'Valor que se muestra al usuario
            .DisplayMember = "f0300_descripcion_item"
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

    Private Sub tx_id_item_queda_Validating(sender As Object, e As CancelEventArgs) Handles tx_id_item_queda.Validating
        If IsNumeric(tx_id_item_queda.Text) = False And tx_id_item_queda.Text <> "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item_queda.Text = ""
            Exit Sub
        End If
        If tx_id_item_queda.Text.Trim = "" Then
            Exit Sub
        End If

        cm_descripcion_queda.Focus()
        cm_descripcion_queda.SelectedValue = CInt(tx_id_item_queda.Text)
        vf_elemento_nuevo = "S"
        'cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, "S",
        'vg_usuario_autoriza, Me)
    End Sub

    Private Sub cm_descripcion_queda_Validating(sender As Object, e As CancelEventArgs) Handles cm_descripcion_queda.Validating
        If cm_descripcion_queda.Text.Trim = "" Then
            Exit Sub
        End If
        If cm_descripcion_queda.SelectedIndex = -1 Then
            cm_descripcion_queda.SelectedText = ""
        Else
            vf_elemento_nuevo = "N"
            tx_id_item_queda.Text = cm_descripcion_queda.SelectedValue
        End If
    End Sub

    Private Sub bt_procesar_Click(sender As Object, e As EventArgs) Handles bt_procesar.Click
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Unificar Item", "Desea UNIFICAR los items?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0300_items set "
        csql += "f0300_descripcion_item = f0300_descripcion_item || ' (ANULADO)',"
        csql += "f0300_referencia = 'CM-' || f0300_id_item,"
        csql += "f0300_codigo_cguno = 'CM-' || f0300_id_item,"
        csql += "f0300_id_item_new = @f0300_id_item_new,"
        csql += "f0300_anulado = 'S',"
        csql += "f0300_fm = @f0300_fm,"
        csql += "f0300_usuario_modificar = @f0300_usuario_modificar,"
        csql += "f0300_usuario_anular = @f0300_usuario_modificar"
        csql += " where f0300_id_item = @f0300_id_item"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_facturas(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0300_id_item_new", NpgsqlDbType.Integer).Value = tx_id_item_queda.Text
        ocmd.Parameters.Add("@f0300_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0300_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0300_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()

        'Actualizo la informacion en el formulario padre items y muestro el nuevo item
        'vf_oform_padre.id_item = tx_id_item_queda.Text

        'Cierro el formulario
        Dispose()
    End Sub
End Class
