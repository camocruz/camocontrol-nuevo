Public Class fm_0002_edicion_unidades_medicion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Public id_unidad As String = ""
    Public vnuevo As String = "N"

    Private verror As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String = ""
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet

    Private otb_unidades_medicion As DataTable
    Private otb_tipo_unidad As DataTable

    Private Sub fm_0002_edicion_unidades_medicion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        csql = "SELECT f0003_id_tipo_unidad, f0003_tipo_unidad_medicion" _
            & " FROM " & database.obtener_esquema & ".tb0003_tipos_unidades_medicion"
        otb_tipo_unidad = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_tipo_unidad
            'Valor que se muestra al usuario
            .DisplayMember = "f0003_tipo_unidad_medicion"
            'Valor interno que almacena el objeto
            .ValueMember = "f0003_id_tipo_unidad"
            'Origen de Datos del ComboBox
            .DataSource = otb_tipo_unidad
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        If vnuevo = "N" Then
            cargar_info_existente()
        End If
    End Sub
    Private Sub cargar_info_existente()
        csql = "select * from " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                & " where f0002_id_unidad_medicion = '" & id_unidad & "'"
        otb_unidades_medicion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_unidades_medicion.Rows
            tx_sigla.Text = orow("f0002_sigla_unidad_medicion")
            tx_sigla_cguno.Text = orow("f0002_sigla_unidad_cguno")
            cm_tipo_unidad.SelectedValue = orow("f0002_id_tipo_unidad")
            tx_unidad.Text = orow("f0002_unidad_medicion")
        Next
    End Sub

    Private Sub grabar_nueva_unidad()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        id_unidad = cl_utilidades_datatables.obtener_nuevo_consecutivo_tablas("f0002_id_unidad_medicion", "tb0002_unidades_medicion")

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                & " (f0002_id_unidad_medicion, f0002_id_cia, f0002_sigla_unidad_medicion," _
                & " f0002_sigla_unidad_cguno, f0002_unidad_medicion, f0002_id_tipo_unidad," _
                & " f0002_fm, f0002_usuario_crear, f0002_usuario_modificar)" _
                & " VALUES" _
                & " (@f0002_id_unidad_medicion, @f0002_id_cia, @f0002_sigla_unidad_medicion," _
                & " @f0002_sigla_unidad_cguno, @f0002_unidad_medicion, @f0002_id_tipo_unidad," _
                & " @f0002_fm, @f0002_usuario_crear, @f0002_usuario_modificar)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_grabar_unidad(ocmd)

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
    Private Sub grabar_cambios_unidad()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0002_unidades_medicion set "
        csql += "f0002_id_cia = @f0002_id_cia,"
        csql += "f0002_sigla_unidad_medicion = @f0002_sigla_unidad_medicion,"
        csql += "f0002_sigla_unidad_cguno = @f0002_sigla_unidad_cguno,"
        csql += "f0002_unidad_medicion = @f0002_unidad_medicion,"
        csql += "f0002_id_tipo_unidad = @f0002_id_tipo_unidad,"
        csql += "f0002_fm = @f0002_fm,"
        csql += "f0002_usuario_modificar = @f0002_usuario_modificar"
        csql += " where f0002_id_unidad_medicion = '" & id_unidad & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_grabar_unidad(ocmd)
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
    Private Sub crear_parametros_grabar_unidad(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0002_id_unidad_medicion", NpgsqlDbType.Varchar).Value = id_unidad.ToString.Trim.PadLeft(8, "0")
        ocmd.Parameters.Add("@f0002_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0002_sigla_unidad_medicion", NpgsqlDbType.Varchar).Value = tx_sigla.Text.ToString.Trim
        ocmd.Parameters.Add("@f0002_sigla_unidad_cguno", NpgsqlDbType.Varchar).Value = tx_sigla_cguno.Text.ToString.Trim
        ocmd.Parameters.Add("@f0002_unidad_medicion", NpgsqlDbType.Varchar).Value = tx_unidad.Text.ToString.Trim
        ocmd.Parameters.Add("@f0002_id_tipo_unidad", NpgsqlDbType.Varchar).Value = cm_tipo_unidad.SelectedValue
        ocmd.Parameters.Add("@f0002_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza.ToString.Trim
        ocmd.Parameters.Add("@f0002_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza.ToString.Trim
        ocmd.Parameters.Add("@f0002_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub validar_sigla()
        If tx_sigla.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la sigla de la unidad."
        End If
    End Sub
    Private Sub validar_unidad()
        If tx_unidad.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la unidad de medicion."
        End If
    End Sub
    Private Sub validar_tipo()
        If cm_tipo_unidad.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el tipo de la unidad de medicion."
        End If
    End Sub
    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_sigla()
        validar_tipo()
        validar_unidad()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If vnuevo = "S" Then
            grabar_nueva_unidad()
        Else
            grabar_cambios_unidad()
        End If
        If verror = "N" Then
            MsgBox("Unidad grabada exitosamente", MsgBoxStyle.Information, "Grabar")
        End If
        Dispose()
    End Sub
End Class
