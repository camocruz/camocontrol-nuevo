Public Class fm_0300_formulacion_items
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public otipo_nota As String = ""

    Public id_plantilla As Integer
    Public id_lmnto As Integer

    Public carga_calculadora_costos As String = "N"

    'Private$vf_otabla_permisos$As DataTable

    Private odr As NpgsqlDataReader
    Private oconn_form As NpgsqlConnection

    Private ocmd As NpgsqlCommand
    Private csql As String = ""
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private vexiste As String = ""
    Private verror As String = "N"
    Private otb_info_elemento As DataTable
    Private otb_items As DataTable


    Private Sub fm_0300_formulacion_items_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        'Para registrar las notas asociadas.
        otipo_nota = comunes.suministrar_valor_variable_configuracion("TN-FRE-001", vg_id_cia)
        bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_lmnto, vg_id_cia)

        'bt_anular.Enabled = False
        bt_generar_informe.Enabled = False
        bt_editar.Enabled = False
        'bt_nuevo.Enabled = False
        'bt_grabar.Enabled = False

        cargar_informacion_items()

        If carga_calculadora_costos = "S" Then
            lb_titulo.Text = "Costo Sugerido"
            Label6.Text = "Costo ($)"
            bt_anular.Enabled = False
        End If

        If vf_elemento_nuevo = "N" Then
            csql = "select * from " & database.obtener_esquema & ".tb0351_elementos" _
                & " Where f0351_id_elemento = '" & id_lmnto & "'"
            otb_info_elemento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            For Each orow As DataRow In otb_info_elemento.Rows
                tx_id_lmto.Text = orow("f0351_id_elemento")
                tx_id_item.Text = orow("f0351_id_item")
                cm_descripcion.SelectedValue = orow("f0351_id_item")
                tx_cantidad.Text = orow("f0351_cantidad")
                buscar_info_item(orow("f0351_id_item"))
            Next
        Else
            bt_anular.Enabled = False
        End If
    End Sub
    Private Sub cargar_informacion_items()
        csql = "SELECT tb0300_items.*, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga," _
            & " f0002_unidad_medicion" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
              & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                & "  on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
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
        If (IsNumeric(tx_id_item.Text) = False And tx_id_item.Text <> "") Or tx_id_item.Text = "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        cm_descripcion.Focus()
        cm_descripcion.SelectedValue = CInt(tx_id_item.Text)
    End Sub

    Private Sub cm_descripcion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_descripcion.Validating
        If cm_descripcion.SelectedIndex = -1 Then
            cm_descripcion.Text = ""
            tx_id_item.Text = ""
        Else
            tx_id_item.Text = cm_descripcion.SelectedValue
            buscar_info_item(cm_descripcion.SelectedValue)
            'bt_grabar.Enabled = False
            'bt_editar.Enabled = True
            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_editar, "")
        End If
    End Sub

    Private Sub buscar_info_item(id_oitem As Integer)
        Dim orow_item() As DataRow
        orow_item = otb_items.Select("f0300_id_item = '" & id_oitem & "'")
        For Each orow As DataRow In orow_item
            lb_unidad_medicion.Text = orow("f0002_unidad_medicion")
        Next
    End Sub

    Private Sub nuevo_item_formulacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0351_elementos" _
                & " (f0351_id_plantilla, f0351_id_cia, f0351_id_item, f0351_cantidad," _
                & " f0351_usuario_modificar, f0351_usuario_crear)" _
                & " VALUES" _
                & " (@f0351_id_plantilla, @f0351_id_cia, @f0351_id_item, @f0351_cantidad," _
                & " @f0351_usuario_modificar, @f0351_usuario_crear)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0351_id_plantilla", NpgsqlDbType.Integer).Value = id_plantilla
        ocmd.Parameters.Add("@f0351_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0351_id_item", NpgsqlDbType.Integer).Value = tx_id_item.Text
        ocmd.Parameters.Add("@f0351_cantidad", NpgsqlDbType.Numeric).Value = tx_cantidad.Text
        ocmd.Parameters.Add("@f0351_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0351_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString + vbCrLf + csql)
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

    Private Sub actualizar_item_formulacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0351_elementos set "
        csql += "f0351_id_item = @f0351_id_item,"
        csql += "f0351_cantidad = @f0351_cantidad,"
        csql += "f0351_fm = @f0351_fm,"
        csql += "f0351_usuario_modificar = @f0351_usuario_modificar"
        csql += " where f0351_id_elemento = @f0351_id_elemento"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0351_id_elemento", NpgsqlDbType.Integer).Value = id_lmnto
        End If
        ocmd.Parameters.Add("@f0351_id_item", NpgsqlDbType.Integer).Value = tx_id_item.Text
        ocmd.Parameters.Add("@f0351_cantidad", NpgsqlDbType.Numeric).Value = tx_cantidad.Text
        ocmd.Parameters.Add("@f0351_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0351_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub validar_descripcion_item()
        If cm_descripcion.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina una descripcion para el Item."
        End If
    End Sub
    Private Sub validar_cantidad()
        If tx_cantidad.Text = "" Or tx_cantidad.Text = "0" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina una Cantidad."
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_descripcion_item()
        validar_cantidad()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If carga_calculadora_costos = "S" Then
            vf_oform_padre.orow_item_calculadora(1) = tx_id_item.Text
            vf_oform_padre.orow_item_calculadora(2) = tx_cantidad.Text
            vf_oform_padre.orow_item_calculadora(3) = cm_descripcion.Text
            Dispose()
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            nuevo_item_formulacion()
            If verror = "N" Then
                MsgBox("Grabado", MsgBoxStyle.Information, "Info")
                Dispose()
            End If
        Else
            actualizar_item_formulacion()
            If verror = "N" Then
                MsgBox("Actualizado", MsgBoxStyle.Information, "Info")
            End If
        End If

    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0351_elementos set "
        csql += "f0351_anulado = 'S',"
        csql += "f0351_usuario_anular = @f0351_usuario_anular,"
        csql += "f0351_fm = @f0351_fm,"
        csql += "f0351_usuario_modificar = @f0351_usuario_modificar"
        csql += " where f0351_id_elemento = @f0351_id_elemento"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0351_id_elemento", NpgsqlDbType.Integer).Value = id_lmnto
        ocmd.Parameters.Add("@f0351_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0351_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0351_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
        If verror = "N" Then
            MsgBox("Elemento Anulada", MsgBoxStyle.Information, "Info")
            Dispose()
        End If
    End Sub

    Private Sub bt_g_notas_Click(sender As Object, e As EventArgs) Handles bt_g_notas.Click
        If vf_elemento_nuevo = "S" Then
            MsgBox("Primero debe grabar el item", MsgBoxStyle.Information)
            Exit Sub
        End If
        If id_plantilla <> 0 And id_plantilla.ToString <> "" Then
            cl_gestion_anotaciones.consultar_anotaciones_acciones(id_lmnto, otipo_nota, vg_usuario_autoriza, vg_id_cia, "ST-0606-04", "2")
            bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_lmnto, vg_id_cia)
        Else
            MsgBox("No ha definido una Disociacion", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub bt_nuevo_Click(sender As Object, e As EventArgs) Handles bt_nuevo.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_items As New camocontrol.fm_0300_gestion_items
        oform_items.vf_oform_padre = Me
        oform_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_items.vg_id_cia = vg_id_cia
        oform_items.vf_elemento_nuevo = "S"
        'oform_items.vf_elemento_nuevo = "N"
        oform_items.ShowDialog()
        cargar_informacion_items()
    End Sub

    Private Sub tx_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_cantidad.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        End If
    End Sub


End Class
