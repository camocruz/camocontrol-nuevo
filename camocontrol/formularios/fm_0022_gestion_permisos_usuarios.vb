Public Class fm_0022_gestion_permisos_usuarios
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Private ocmd As NpgsqlCommand ' objeto que va a contener el o los comandos a ejecutar tipo postgresql
    Private ods As DataSet
    Private oconexion As NpgsqlConnection ' objeto que va a contener la conexion a postgresql
    Private vexiste As String = "N" 'variable bandera para saber si un select trajo o no datos
    Private oconn_form As NpgsqlConnection
    Private csql As String = ""
    Private verror As String = ""
    Private verror_grabar As String = "N"
    Private vusuario As String = ""
    Private dataSetArbol As System.Data.DataSet
    Private otabla As DataTable
    Private cod_asig As String = "" 'codigo del permiso asignado o revocado


    Private Sub fm_0022_gestion_permisos_usuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        csql = "select f0021_id_usuario, f0021_nombre_completo from " + database.obtener_esquema + ".tb0021_usuarios order by f0021_nombre_completo"
        oconn_form = database.obtener_conexion()

        Dim oda As New NpgsqlDataAdapter(csql, oconn_form)
        Dim ods As New DataSet
        oda.Fill(ods, "usuarios")

        With cm_usuarios
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

    Private Sub cm_usuarios_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_usuarios.Validating
        If cm_usuarios.SelectedIndex = -1 Then
            TreeView1.Nodes.Clear()
            cm_usuarios.Text = ""
            MsgBox("El usuario no existe", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'conseguir todos los permisos del usuario
        vusuario = cm_usuarios.SelectedValue
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, "", ocontexto_form) 'llenamos el datatable con los permisos
        'MsgBox(vusuario)

        TreeView1.Nodes.Clear()
        ' Llamar al método por primera vez que llenará el TreeView, este método se llamará luego
        ' a sí mismo recurrentemente.
        CrearNodosDelPadre(0, Nothing)
    End Sub

    Private Sub CrearNodosDelPadre(ByVal indicePadre As String, ByVal nodePadre As TreeNode)
        Dim ods As New DataSet
        Dim dataViewHijos As New DataView
        'MsgBox(vf_otabla_permisos.Columns("f0020_codigo_padre").ColumnName & " = '" & indicePadre.ToString().Trim & "'")
        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(vf_otabla_permisos)

        dataViewHijos.RowFilter = vf_otabla_permisos.Columns("f0020_codigo_padre").ColumnName & " = '" & indicePadre.ToString().Trim & "'"

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = "   " & dataRowCurrent("f0020_descripcion").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("f0020_codigo").ToString().Trim()

            If Not DBNull.Value.Equals(dataRowCurrent("f0022_acceso")) Then
                'Trim(nconsecutivo.ToString("F0")).PadLeft(10, "0")
                nuevoNodo.Checked = True
            End If
            'Next

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            'CrearNodosDelPadre(Int64.Parse(dataRowCurrent("f0020_codigo").ToString()), nuevoNodo)
            CrearNodosDelPadre(dataRowCurrent("f0020_codigo").ToString(), nuevoNodo)
        Next dataRowCurrent
    End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        cod_asig = e.Node.Tag.ToString
        If e.Node.Checked = True Then
            grabar_permiso()
            'MsgBox("se activa: " & e.Node.Tag.ToString)
        Else
            eliminar_permiso()
            'MsgBox("se desactiva: " & e.Node.Tag.ToString)
        End If
    End Sub
    Private Sub grabar_permiso()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "insert into " + database.obtener_esquema + ".tb0022_usuarios_permiso (f0022_id_usuario, f0022_codigo, f0022_acceso)" _
        + " values (@f0022_id_usuario, @f0022_codigo, @f0022_acceso)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros(ocmd)

        verror_grabar = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror_grabar = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror_grabar = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror_grabar = "S"
                MsgBox("Hubo un error al Insertar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        oconn_form.Close()
        ocmd = Nothing
    End Sub
    Private Sub crear_parametros(ByVal ocmd_update As NpgsqlCommand)
        ocmd_update.Parameters.Clear()
        ocmd_update.Parameters.Add("@f0022_id_usuario", NpgsqlDbType.Varchar).Value = cm_usuarios.SelectedValue 'id_turno.ToString.PadLeft(8, "0")
        ocmd_update.Parameters.Add("@f0022_codigo", NpgsqlDbType.Varchar).Value = cod_asig
        ocmd_update.Parameters.Add("@f0022_acceso", NpgsqlDbType.Boolean).Value = True
    End Sub
    Private Sub eliminar_permiso()
        csql = "DELETE FROM " + database.obtener_esquema + ".tb0022_usuarios_permiso " _
       + " WHERE f0022_id_usuario = '" + cm_usuarios.SelectedValue.ToString + "' and f0022_codigo = '" + cod_asig + "'"

        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        ocmd.ExecuteNonQuery()
        ocmd = Nothing
        oconn_form.Close()
    End Sub


End Class
