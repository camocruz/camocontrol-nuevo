Public Class fm_0600_relacionar_items_accion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"

    Public id_accion As Integer
    Public id_tercero As String
    Public NIT As String
    Public emisor_accion As String

    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand
    Private odr As NpgsqlDataReader

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String


    Private otb_items As DataTable
    Private otb_items_rel As DataTable
    Private otb_unidades As DataTable
    Private otb_info_mef As DataTable
    Private otb_lotes As DataTable


    Private Sub fm_0600_relacionar_items_accion_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        'cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
        'vg_usuario_autoriza, Me, vf_id_notas_archivos)

        bt_editar.Enabled = False
        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False
        bt_generar_informe.Enabled = False
        dg_lotes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_lotes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_productos_rel.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_productos_rel.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

        'Solo el emisor puede modificar la informacion de los productos
        If vg_usuario_autoriza <> emisor_accion Then
            If vg_usuario_autoriza <> "00000001" Then
                bt_grabar.Enabled = False
                bt_anular.Enabled = False
            End If
        End If

        tx_id_accion.Text = id_accion
        vf_id_notas_archivos = id_accion
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
        csql = "SELECT *" _
    & " FROM " & database.obtener_esquema & ".tb0609_modos_efectos_falla"
        otb_info_mef = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_mef
            'Valor que se muestra al usuario
            .DisplayMember = "f0609_mef"
            'Valor interno que almacena el objeto
            .ValueMember = "f0609_id_mef"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_mef
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        cargar_datos_items_relacionados()
    End Sub
    Private Sub cargar_datos_items_relacionados()
        csql = "select *,"
        csql += " f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item"
        csql += " from " & database.obtener_esquema & ".tb0610_items_acciones"
        csql += " left join " & database.obtener_esquema & ".tb0300_items"
        csql += " on f0300_id_item = f0610_id_item"
        csql += " left join " & database.obtener_esquema & ".tb0609_modos_efectos_falla"
        csql += " on f0609_id_mef = f0610_id_mef"
        csql += " where f0610_id_accion = '" & id_accion & "' and f0610_anulado = 'N' and"
        csql += " f0610_id_cia = '" & vg_id_cia & "'"
        otb_items_rel = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_productos_rel.Rows.Clear()
        For Each orow As DataRow In otb_items_rel.Rows
            agregar_fila_dg_items_relacionados(orow("f0610_id_it_ac"), orow("f0610_id_item"), orow("item"),
                                               orow("f0610_cantidad_texto"), orow("f0610_id_mef"), orow("f0609_mef"),
                                               orow("f0610_lote"))
        Next
    End Sub
    Private Sub tx_id_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_id_item.Validating
        If IsNumeric(tx_id_item.Text) = False Or tx_id_item.Text.Trim = "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        cm_descripcion.Focus()
        cm_descripcion.SelectedValue = CInt(tx_id_item.Text)
        mostrar_informacion_lotes(CInt(tx_id_item.Text))
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
            mostrar_informacion_lotes(CInt(cm_descripcion.SelectedValue))
        End If
    End Sub
    Private Sub validar_item()
        If tx_id_item.Text.ToString = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Seleccione un Item."
        End If
    End Sub
    Private Sub mostrar_informacion_lotes(ByVal id_item As Integer)
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-21", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_item)
        csql = csql.Replace("$003$", NIT)
        'Clipboard.SetDataObject(csql)
        'MsgBox("Hola")
        otb_lotes = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_lotes.DataSource = otb_lotes
    End Sub

    Private Sub dg_lotes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_lotes.CellDoubleClick
        If dg_lotes.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim olote As String = ""
        olote = dg_lotes.CurrentRow.Cells("lote").Value
        tx_lote.Text = olote
    End Sub

    Private Sub limpiar_textos()
        tx_id_it_ac.Text = ""
        tx_id_item.Text = ""
        cm_descripcion.Text = ""
        cm_mef.Text = ""
        tx_lote.Text = ""
        tx_cantidad_texto.Text = ""
        dg_lotes.DataSource = vbEmpty
    End Sub
    Private Sub agregar_fila_dg_items_relacionados(ByVal id_it_ac As String, ByVal id_tem As Integer,
                                        ByVal item As String, ByVal cantidad_texto As String, ByVal id_mef As Integer,
                                        ByVal mef As String, ByVal lote As String)
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = id_it_ac
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = id_tem
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = item
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = cantidad_texto
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = id_mef
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = mef
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = lote
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_productos_rel.Rows.Add(orowgrid)
    End Sub
    Private Sub add_nuevo_item_bd(ByVal id_item As Integer, ByVal id_mef As Integer,
                                  ByVal cantidad_texto As String, ByVal lote As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0610_items_acciones" _
                & " (f0610_id_cia, f0610_id_accion, f0610_id_item, f0610_id_mef, f0610_lote, f0610_cantidad_texto," _
                & " f0610_usuario_modificar, f0610_usuario_crear, f0610_fm)" _
                & " VALUES" _
                & " (@f0610_id_cia, @f0610_id_accion, @f0610_id_item, @f0610_id_mef, @f0610_lote, @f0610_cantidad_texto," _
                & " @f0610_usuario_modificar, @f0610_usuario_crear, @f0610_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0610_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0610_id_accion", NpgsqlDbType.Integer).Value = id_accion
        ocmd.Parameters.Add("@f0610_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0610_id_mef", NpgsqlDbType.Integer).Value = id_mef
        ocmd.Parameters.Add("@f0610_lote", NpgsqlDbType.Varchar).Value = lote
        ocmd.Parameters.Add("@f0610_cantidad_texto", NpgsqlDbType.Varchar).Value = cantidad_texto
        ocmd.Parameters.Add("@f0610_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0610_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0610_fm", NpgsqlDbType.Timestamp).Value = fecha_act

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
    Private Sub edit_item_bd(ByVal id_it_ac As Integer, ByVal id_item As Integer, ByVal id_mef As Integer,
                             ByVal cantidad_texto As String, ByVal lote As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0610_items_acciones set "
        csql += "f0610_id_item = @f0610_id_item,"
        csql += "f0610_id_mef = @f0610_id_mef,"
        csql += "f0610_lote = @f0610_lote,"
        csql += "f0610_cantidad_texto = @f0610_cantidad_texto,"
        csql += "f0610_usuario_modificar = @f0610_usuario_modificar,"
        csql += "f0610_fm = @f0610_fm"
        csql += " where f0610_id_it_ac = @f0610_id_it_ac"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0610_id_it_ac", NpgsqlDbType.Integer).Value = id_it_ac
        ocmd.Parameters.Add("@f0610_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0610_id_mef", NpgsqlDbType.Integer).Value = id_mef
        ocmd.Parameters.Add("@f0610_lote", NpgsqlDbType.Varchar).Value = lote
        ocmd.Parameters.Add("@f0610_cantidad_texto", NpgsqlDbType.Varchar).Value = cantidad_texto
        ocmd.Parameters.Add("@f0610_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0610_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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
    Private Sub anular_item_bd(ByVal id_it_ac As Integer)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0610_items_acciones set "
        csql += "f0610_anulado = @f0610_anulado,"
        csql += "f0610_usuario_modificar = @f0610_usuario_modificar,"
        csql += "f0610_usuario_anular = @f0610_usuario_anular,"
        csql += "f0610_fm = @f0610_fm"
        csql += " where f0610_id_it_ac = @f0610_id_it_ac"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0610_id_it_ac", NpgsqlDbType.Integer).Value = id_it_ac
        ocmd.Parameters.Add("@f0610_anulado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0610_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0610_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0610_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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
    Private Sub validar_producto()
        If tx_id_item.Text = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina un Producto"
        End If
    End Sub
    Private Sub validar_mef()
        If cm_mef.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la Falla presentada"
        End If
    End Sub
    Private Sub validar_cant_texto()
        If tx_cantidad_texto.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Describa la cantidad en la que se encontro la falla"
        End If
    End Sub
    Private Sub validar_lote()
        If tx_lote.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Identifique el lote en el que se presento la falla"
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_cant_texto()
        validar_item()
        validar_lote()
        validar_mef()
        validar_producto()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If tx_id_it_ac.Text = "" Then
            vf_elemento_nuevo = "S"
        End If

        If vf_elemento_nuevo = "S" Then
            add_nuevo_item_bd(tx_id_item.Text, cm_mef.SelectedValue, tx_cantidad_texto.Text, tx_lote.Text)
        Else
            edit_item_bd(tx_id_it_ac.Text, tx_id_item.Text, cm_mef.SelectedValue, tx_cantidad_texto.Text, tx_lote.Text)
        End If
        cargar_datos_items_relacionados()
        limpiar_textos()
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        If tx_id_it_ac.Text = "" Then
            Exit Sub
        End If

        tx_id_item.Text = dg_productos_rel.CurrentRow.Cells("dgocell_id_item").Value
        cm_descripcion.SelectedValue = dg_productos_rel.CurrentRow.Cells("dgocell_id_item").Value
        cm_mef.SelectedValue = dg_productos_rel.CurrentRow.Cells("dgocell_id_mef").Value
        tx_cantidad_texto.Text = dg_productos_rel.CurrentRow.Cells("dgocell_cantidad").Value
        tx_lote.Text = dg_productos_rel.CurrentRow.Cells("dgocell_lote").Value

        Dim respuesta As String
        respuesta = comunes.g_mensaje_YesNo("Anular", "Desea Anular este item?")
        If respuesta = "S" Then
            anular_item_bd(tx_id_it_ac.Text)
            cargar_datos_items_relacionados()
            limpiar_textos()
        Else
            limpiar_textos()
        End If
    End Sub

    Private Sub bt_nuevo_Click(sender As Object, e As EventArgs) Handles bt_nuevo.Click
        limpiar_textos()
    End Sub

    Private Sub dg_productos_rel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_productos_rel.CellDoubleClick
        If dg_productos_rel.Rows.Count = 0 Then
            Exit Sub
        End If
        tx_id_it_ac.Text = dg_productos_rel.CurrentRow.Cells("dgocell_id_it_ac").Value
        tx_id_item.Text = dg_productos_rel.CurrentRow.Cells("dgocell_id_item").Value
        cm_descripcion.SelectedValue = dg_productos_rel.CurrentRow.Cells("dgocell_id_item").Value
        cm_mef.SelectedValue = dg_productos_rel.CurrentRow.Cells("dgocell_id_mef").Value
        tx_cantidad_texto.Text = dg_productos_rel.CurrentRow.Cells("dgocell_cantidad").Value
        tx_lote.Text = dg_productos_rel.CurrentRow.Cells("dgocell_lote").Value
        mostrar_informacion_lotes(tx_id_item.Text)
        'vf_elemento_nuevo = "N"
    End Sub
End Class
