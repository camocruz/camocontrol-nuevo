Public Class fm_0052_equivalencias_ciudades_cg
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String



    Private Sub fm_0052_equivalencias_ciudades_cg_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        'Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        Dim otb_ciudades As DataTable
        csql = "select f0052_codigo_ciudad, f0052_ciudad || ' - ' || f0051_departamento as ciudad" _
            & " from " & database.obtener_esquema & ".tb0052_ciudades" _
            & " join " & database.obtener_esquema & ".tb0051_departamentos" _
            & " on f0051_codigo_departamento = f0052_codigo_departamento"
        otb_ciudades = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        With cm_ciudad_camo
            'Valor que se muestra al usuario
            .DisplayMember = "ciudad"
            'Valor interno que almacena el objeto
            .ValueMember = "f0052_codigo_ciudad"
            'Origen de Datos del ComboBox
            .DataSource = otb_ciudades
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        'Pregunta si realmente desea HABILITAR
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Editar Registro", "Desea crear equivalencia?")
        If respuesta = "N" Then
            Exit Sub
        End If
        If cm_ciudad_camo.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una ciudad de la lista", MsgBoxStyle.Critical, "Info")
            Exit Sub
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0052_ciudades set "
        csql += "f0052_ciudad_cg = @f0052_ciudad_cg"
        csql += " where f0052_codigo_ciudad = @f0052_codigo_ciudad"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0052_ciudad_cg", NpgsqlDbType.Varchar).Value = tx_ciudad_cg.Text.Trim
        ocmd.Parameters.Add("@f0052_codigo_ciudad", NpgsqlDbType.Varchar).Value = cm_ciudad_camo.SelectedValue

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
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
        vf_oform_padre.id_ciudad = cm_ciudad_camo.SelectedValue
        Dispose()
    End Sub
End Class
