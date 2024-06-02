Public Class fm_0500_documentos_interrelaciones
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_despacho As Integer
    Public mostrar_solo_despacho As String = "S"

    Private otipo_nota As String

    Public id_documento As Integer = 0
    Public config_archivos As String

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private verror_cargue As String = "N"
    Private cargue_bloqueado As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private orowgrid As DataGridViewRow
    Private ocmb_grid As DataGridViewComboBoxCell
    Private otextgrid As DataGridViewTextBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell
    Private obuttongrid As DataGridViewButtonCell
    Private olinkcell As DataGridViewLinkCell

    Private otb_documentos As DataTable
    Private otb_doctos_relacionados As DataTable
    Private doc_ed As Integer
    Private otipo_rel As String = ""


    Private Sub fm_0500_documentos_interrelaciones_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        'Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        csql = "select f0501_id_documento, f0501_codigo_documento,"
        csql += " f0501_codigo_documento || '  <=>  ' || f0501_titulo_documento as titulo"
        csql += " from " & database.obtener_esquema & ".tb0501_documentos"
        csql += " where f0501_id_cia = '" & vg_id_cia & "' and f0501_id_documento <> '" & id_documento & "'"
        csql += " and f0501_anulado = 'N'"
        otb_documentos = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        With cm_codigo_documento
            'Valor que se muestra al usuario
            .DisplayMember = "titulo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0501_id_documento"
            'Origen de Datos del ComboBox
            .DataSource = otb_documentos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        actualizar_grids()
    End Sub
    Private Sub actualizar_grids()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0500-01", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_documento)
        otb_doctos_relacionados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_referenciados.Rows.Clear()
        dg_referenciador.Rows.Clear()

        For Each orow As DataRow In otb_doctos_relacionados.Rows
            If orow("f0504_id_documento_padre") = id_documento Then
                agregar_fila_indicador_productivo(orow("f0504_id_documento_hijo"),
                                                  orow("hijos_titulo"),
                                                  dg_referenciados)
            Else
                agregar_fila_indicador_productivo(orow("f0504_id_documento_padre"),
                                                  orow("padres_titulo"),
                                                  dg_referenciador)
            End If
        Next
    End Sub
    Private Sub agregar_fila_indicador_productivo(ByVal id As Integer, ByVal formato As String, ByVal dg_grid As DataGridView)
        'Crea objeto fila del Datagridview
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1 -- esta oculta
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = id
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = formato
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_grid.Rows.Add(orowgrid)
    End Sub

    Private Sub dg_referenciador_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_referenciador.CellClick
        If dg_referenciador.Rows.Count = 0 Then
            Exit Sub
        End If
        otipo_rel = "padre"
        tx_id_documento_relacion.Text = dg_referenciador.CurrentRow.Cells("dgocell_id_documento_referenciador").Value
        tx_titulo_documento.Text = dg_referenciador.CurrentRow.Cells("dgocell_documento_referenciador").Value
        'cm_codigo_documento.SelectedValue = dg_referenciador.CurrentRow.Cells("dgocell_id_documento_referenciador").Value
    End Sub

    Private Sub dg_referenciados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_referenciados.CellClick
        If dg_referenciados.Rows.Count = 0 Then
            Exit Sub
        End If
        otipo_rel = "hijo"
        tx_id_documento_relacion.Text = dg_referenciados.CurrentRow.Cells("dgocell_id_documento_referenciado").Value
        tx_titulo_documento.Text = dg_referenciados.CurrentRow.Cells("dgocell_documento_referenciado").Value
        'cm_codigo_documento.SelectedValue = dg_referenciados.CurrentRow.Cells("dgocell_id_documento_referenciado").Value
    End Sub

    Private Sub crear_relacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0504_documentos_interrelaciones" _
                & " (f0504_id_cia, f0504_id_documento_padre, f0504_id_documento_hijo," _
                & " f0504_usuario_modificar, f0504_usuario_crear, f0504_fm)" _
                & " VALUES" _
                & " (@f0504_id_cia, @f0504_id_documento_padre, @f0504_id_documento_hijo," _
                & " @f0504_usuario_modificar, @f0504_usuario_crear, @f0504_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If otipo_rel = "hijo" Then
            ocmd.Parameters.Add("@f0504_id_documento_padre", NpgsqlDbType.Integer).Value = id_documento
            ocmd.Parameters.Add("@f0504_id_documento_hijo", NpgsqlDbType.Integer).Value = cm_codigo_documento.SelectedValue
        Else
            ocmd.Parameters.Add("@f0504_id_documento_padre", NpgsqlDbType.Integer).Value = cm_codigo_documento.SelectedValue
            ocmd.Parameters.Add("@f0504_id_documento_hijo", NpgsqlDbType.Integer).Value = id_documento
        End If

        ocmd.Parameters.Add("@f0504_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0504_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0504_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0504_fm", NpgsqlDbType.Timestamp).Value = fecha_act

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

    Private Sub eliminar_relacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "delete from " & database.obtener_esquema & ".tb0504_documentos_interrelaciones" _
                & " where f0504_id_documento_padre = @f0504_id_documento_padre and" _
                & " f0504_id_documento_hijo = @f0504_id_documento_hijo"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If otipo_rel = "hijo" Then
            ocmd.Parameters.Add("@f0504_id_documento_padre", NpgsqlDbType.Integer).Value = id_documento
            ocmd.Parameters.Add("@f0504_id_documento_hijo", NpgsqlDbType.Integer).Value = tx_id_documento_relacion.Text
        Else
            ocmd.Parameters.Add("@f0504_id_documento_padre", NpgsqlDbType.Integer).Value = tx_id_documento_relacion.Text
            ocmd.Parameters.Add("@f0504_id_documento_hijo", NpgsqlDbType.Integer).Value = id_documento
        End If

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

    Private Sub limpiar_datos()
        tx_id_documento_relacion.Text = ""
        tx_titulo_documento.Text = ""
        cm_codigo_documento.SelectedIndex = -1
    End Sub
    Private Sub validar_nueva_relacion()
        If cm_codigo_documento.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione un documento para crear relacion"
            verror_requisitos = "S"
        End If

    End Sub
    Private Sub bt_referenciado_Click(sender As Object, e As EventArgs) Handles bt_referenciado.Click
        otipo_rel = "hijo"
        verror_requisitos = "N"
        validar_nueva_relacion()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical)
            Exit Sub
        End If
        crear_relacion()
        actualizar_grids()
        limpiar_datos()
    End Sub

    Private Sub bt_referenciador_Click(sender As Object, e As EventArgs) Handles bt_referenciador.Click
        otipo_rel = "padre"
        verror_requisitos = "N"
        validar_nueva_relacion()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical)
            Exit Sub
        End If
        crear_relacion()
        actualizar_grids()
        limpiar_datos()
    End Sub

    Private Sub bt_eliminar_relacion_Click(sender As Object, e As EventArgs) Handles bt_eliminar_relacion.Click
        Dim respuesta As String
        respuesta = comunes.g_mensaje_YesNo("Eliminar", "Desea eliminar una relacion?")
        If respuesta = "N" Then
            limpiar_datos()
            Exit Sub
        End If
        If tx_id_documento_relacion.Text = "" Then
            Exit Sub
        End If
        eliminar_relacion()
        actualizar_grids()
        limpiar_datos()
    End Sub
End Class
