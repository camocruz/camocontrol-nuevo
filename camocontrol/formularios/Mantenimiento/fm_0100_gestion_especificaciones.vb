
Public Class fm_0100_gestion_especificaciones
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"

    '$Public$vg_id_cia As String
    Public id_estructura As Integer
    Public vnuevo As String = "S" 'Indica que el registro es nuevo.
    Public id_especificacion As Integer

    Private csql As String
    Private otb_tipos_especificacion As DataTable
    Private otb_info_especificacion As DataTable
    Private otb_unidades_medicion As DataTable

    Private verror As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet

    Private Sub fm_0100_gestion_especificaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        csql = "select *" _
            & " FROM " & database.obtener_esquema & ".tb0702_tipos_especificaciones" _
            & " order by f0702_tipo_especificacion"
        otb_tipos_especificacion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_tipo_especificacion
            'Valor que se muestra al usuario
            .DisplayMember = "f0702_tipo_especificacion"
            'Valor interno que almacena el objeto
            .ValueMember = "f0702_id_tipo_especificacion"
            'Origen de Datos del ComboBox
            .DataSource = otb_tipos_especificacion
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        csql = "select *, f0002_sigla_unidad_medicion || ' (' || f0002_unidad_medicion || ')' as unidad" _
            & " from " & database.obtener_esquema & ".tb0002_unidades_medicion" _
            & " where f0002_id_cia = '" & vg_id_cia & "' order by f0002_id_tipo_unidad, f0002_sigla_unidad_medicion"
        otb_unidades_medicion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_unidad
            'Valor que se muestra al usuario
            .DisplayMember = "unidad"
            'Valor interno que almacena el objeto
            .ValueMember = "f0002_id_unidad_medicion"
            'Origen de Datos del ComboBox
            .DataSource = otb_unidades_medicion
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        If vnuevo = "S" Then
            limpiar()
        Else
            traer_informacion_especificacion()
        End If
    End Sub
    Private Sub limpiar()
        cm_tipo_especificacion.SelectedIndex = -1
        cm_unidad.SelectedIndex = -1
        tx_nombre_especificacion.Text = ""
        tx_especificacion.Text = "0"
        tx_maximo.Text = "0"
        tx_minimo.Text = "0"
        tx_observacion.Text = ""
    End Sub
    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_tipo()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If vnuevo = "S" Then
            grabar_nueva_especificacion()
        Else
            actualizar_especificacion()
        End If
        If verror = "N" Then
            MsgBox("Elemento grabado exitosamente", MsgBoxStyle.Information, "Grabar")
            If vnuevo = "S" Then
                limpiar()
            Else
                Dispose()
            End If

        End If
    End Sub
    Private Sub validar_tipo()
        If cm_tipo_especificacion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione el tipo de especificación"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub grabar_nueva_especificacion()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0700_indicadores_especificaciones" _
                & " (f0700_id_cia, f0700_id_tipo_especificacion, f0700_nombre_especificacion," _
                & " f0700_id_unidad_medicion, f0700_especificacion, f0700_tolerancia_maxima," _
                & " f0700_tolerancia_minima, f0700_id_estructura, f0700_observacion," _
                & " f0700_usuario_crear, f0700_usuario_modificar, f0700_fm)" _
                & " VALUES" _
                & " (@f0700_id_cia, @f0700_id_tipo_especificacion, @f0700_nombre_especificacion," _
                & " @f0700_id_unidad_medicion, @f0700_especificacion, @f0700_tolerancia_maxima," _
                & " @f0700_tolerancia_minima, @f0700_id_estructura, @f0700_observacion," _
                & " @f0700_usuario_crear, @f0700_usuario_modificar, @f0700_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_especificaciones(ocmd)

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
    Private Sub actualizar_especificacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0700_indicadores_especificaciones set "
        csql += "f0700_id_tipo_especificacion = @f0700_id_tipo_especificacion,"
        csql += "f0700_nombre_especificacion = @f0700_nombre_especificacion,"
        csql += "f0700_id_unidad_medicion = @f0700_id_unidad_medicion,"
        csql += "f0700_especificacion = @f0700_especificacion, "
        csql += "f0700_tolerancia_maxima = @f0700_tolerancia_maxima,"
        csql += "f0700_tolerancia_minima = @f0700_tolerancia_minima,"
        csql += "f0700_id_estructura = @f0700_id_estructura,"
        csql += "f0700_observacion = @f0700_observacion,"
        csql += "f0700_usuario_crear = @f0700_usuario_crear,"
        csql += "f0700_fm = @f0700_fm,"
        csql += "f0700_usuario_modificar = @f0700_usuario_modificar"
        csql += " where f0700_id_especificacion = '" & id_especificacion & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_especificaciones(ocmd)
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
    Private Sub anular_especificacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0700_indicadores_especificaciones set "
        csql += "f0700_anulado = 'S',"
        csql += "f0700_fm = @f0700_fm,"
        csql += "f0700_usuario_modificar = @f0700_usuario_modificar,"
        csql += "f0700_usuario_anular = @f0700_usuario_modificar"
        csql += " where f0700_id_especificacion = '" & id_especificacion & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'crear_parametros_especificaciones(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0700_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0700_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando anular! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al anular ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_especificaciones(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0700_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0700_id_tipo_especificacion", NpgsqlDbType.Integer).Value = cm_tipo_especificacion.SelectedValue
        ocmd.Parameters.Add("@f0700_nombre_especificacion", NpgsqlDbType.Varchar).Value = tx_nombre_especificacion.Text
        ocmd.Parameters.Add("@f0700_id_unidad_medicion", NpgsqlDbType.Varchar).Value = cm_unidad.SelectedValue
        ocmd.Parameters.Add("@f0700_especificacion", NpgsqlDbType.Numeric).Value = CDec(tx_especificacion.Text)
        ocmd.Parameters.Add("@f0700_tolerancia_maxima", NpgsqlDbType.Numeric).Value = CDec(tx_maximo.Text)
        ocmd.Parameters.Add("@f0700_tolerancia_minima", NpgsqlDbType.Numeric).Value = CDec(tx_minimo.Text)
        ocmd.Parameters.Add("@f0700_id_estructura", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0700_observacion", NpgsqlDbType.Varchar).Value = tx_observacion.Text.ToString.Trim
        ocmd.Parameters.Add("@f0700_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0700_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0700_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub traer_informacion_especificacion()
        csql = "select *" _
            & " FROM " & database.obtener_esquema & ".tb0700_indicadores_especificaciones" _
            & " where f0700_id_especificacion = '" & id_especificacion & "'"
        otb_info_especificacion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_especificacion.Rows
            cm_tipo_especificacion.SelectedValue = orow("f0700_id_tipo_especificacion")
            cm_unidad.SelectedValue = orow("f0700_id_unidad_medicion")
            If orow("f0700_id_tipo_especificacion") = "00000001" Then
                chk_estandar.Checked = False
            End If
            tx_nombre_especificacion.Text = orow("f0700_nombre_especificacion")
            tx_especificacion.Text = orow("f0700_especificacion")
            tx_maximo.Text = orow("f0700_tolerancia_maxima")
            tx_minimo.Text = orow("f0700_tolerancia_minima")
            tx_observacion.Text = orow("f0700_observacion")
        Next
    End Sub

    Private Sub tx_especificacion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_especificacion.Validating
        If IsNumeric(tx_especificacion.Text) = True Then
            tx_especificacion.Text = CDec(tx_especificacion.Text)
        Else
            MsgBox("La especificacion debe ser numerica")
            tx_especificacion.Text = "0"
        End If
    End Sub

    Private Sub tx_maximo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_maximo.Validating
        If IsNumeric(tx_maximo.Text) = True Then
            tx_maximo.Text = CDec(tx_maximo.Text)
        Else
            MsgBox("La tolerancia superior debe ser numerica")
            tx_maximo.Text = "0"
        End If
    End Sub

    Private Sub tx_minimo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_minimo.Validating
        If IsNumeric(tx_minimo.Text) = True Then
            tx_minimo.Text = CDec(tx_minimo.Text)
        Else
            MsgBox("La tolerancia inferior debe ser numerica")
            tx_minimo.Text = "0"
        End If
    End Sub

    Private Sub chk_estandar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_estandar.CheckedChanged
        If chk_estandar.Checked = True Then
            tx_nombre_especificacion.Text = ""
            tx_nombre_especificacion.ReadOnly = True
            cm_tipo_especificacion.Enabled = True
            cm_unidad.Enabled = False
        Else
            tx_nombre_especificacion.Text = ""
            tx_nombre_especificacion.ReadOnly = False
            cm_tipo_especificacion.Enabled = False
            cm_tipo_especificacion.Text = "N/A"
            cm_unidad.Enabled = True
        End If
    End Sub

    Private Sub cm_tipo_especificacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cm_tipo_especificacion.SelectedIndexChanged
        If cm_tipo_especificacion.SelectedIndex = -1 Then
            Exit Sub
        End If
        tx_nombre_especificacion.Text = cm_tipo_especificacion.Text
        'Identificamos la unidad de medicion del tipo seleccionado
        Dim rowprod As DataRow() = otb_tipos_especificacion.Select("f0702_id_tipo_especificacion ='" & cm_tipo_especificacion.SelectedValue & "'")
        For Each Row As DataRow In rowprod
            cm_unidad.SelectedValue = Row("f0702_id_unidad_medicion")
        Next
    End Sub

    Private Sub bt_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_anular.Click
        'Pregunta si realmente desea eliminar la especificacion.
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular", "Desea ANULAR la especificacion?")
        If respuesta = "N" Then
            Exit Sub
        End If
        anular_especificacion()
        Dispose()
    End Sub
End Class
