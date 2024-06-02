Public Class fm_0400_pp_progamas_produccion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    'Private$vf_otabla_permisos$As DataTable

    Public id_prog_prod As Integer = 0

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""

    Private descripcion_producto As String
    Private nuevo_id_prog_prod As Integer
    Private id_item_clonar As Integer
    Private cantidad_clonar As Decimal
    Private otb_programa_produccion As DataTable
    Private otb_items_programa As DataTable
    Private odosificacion As String = "N"

    Private otb_datos_desplegados As New DataTable
    Private nombre_columna_desecadenadora As String 'El nombre de la columna en que hago doble click
    Private DD As String = "N" 'indica que un indice o dato ya fue desplegado
    Private fila_actual As Integer 'fila actualmente activa en el datagrid

    Private Sub fm0400_pp_progamas_produccion_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False
        bt_generar_informe.Enabled = False

        dg_datos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_datos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

        cargar_items_programa()

        If vf_elemento_nuevo = "S" Then
            lb_titulo.Text = "Nuevo Programa de Produccion"
        Else
            cargar_info_programa_existente()
        End If
        'Para poder marcar la fila desplegada
        Dim workCol As DataColumn = otb_datos_desplegados.Columns.Add(
            "id_desplegado", Type.GetType("System.Int32"))
        workCol.AllowDBNull = False
        workCol.Unique = True
    End Sub

    Private Sub cargar_info_programa_existente()
        csql = "select * from " & database.obtener_esquema & ".tb0400_programa_produccion" _
            & " where f0400_id_pp = '" & id_prog_prod & "'"
        otb_programa_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_programa_produccion.Rows.Count = 0 Then
            Exit Sub
        End If
        For Each orow As DataRow In otb_programa_produccion.Rows
            tx_id_prog_prod.Text = orow("f0400_id_pp")
            tx_nombre.Text = orow("f0400_nombre")
            dtp_f_ini.Value = orow("f0400_fecha_inicio")
            dtp_f_fin.Value = orow("f0400_fecha_final")
            odosificacion = orow("f0400_dosificacion")
        Next
        cargar_items_programa()
    End Sub

    Private Sub cargar_items_programa()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-02", vg_id_cia)
        csql = csql.Replace("$001$", id_prog_prod)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        otb_items_programa = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_datos.DataSource = otb_items_programa
        tx_item_prog_prod.Text = ""
    End Sub

    Private Sub agregar_dato_desplegado(ByVal ocolum_desecadenadora As String)
        nombre_columna_desecadenadora = ocolum_desecadenadora
        Dim workRow As DataRow = otb_datos_desplegados.NewRow()
        workRow("id_desplegado") = dg_datos.CurrentCell.Value.ToString
        fila_actual = dg_datos.FirstDisplayedScrollingRowIndex 'dg_datos.CurrentRow.Index
        Try
            otb_datos_desplegados.Rows.Add(workRow)
        Catch ex As Exception
            'el dato ya fue desplegado
        End Try

    End Sub
    Private Sub dg_datos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dg_datos.CellFormatting
        If dg_datos.Columns(e.ColumnIndex).Name = nombre_columna_desecadenadora Then
            If e.Value IsNot Nothing Then
                If IsDBNull(e.Value) = True Then
                    Exit Sub
                End If
                Dim BuscValue As Integer = e.Value
                buscar_si_dato_desplegado(BuscValue)
                If DD = "S" Then
                    e.CellStyle.BackColor = System.Drawing.Color.Green
                End If
            End If
        End If
    End Sub
    Private Sub buscar_si_dato_desplegado(ByVal buscar)
        ' Presuming the DataTable has a column named Date.
        Dim expression As String
        DD = "N" 'Documento Encontrado
        expression = "id_desplegado =" & buscar
        Dim foundRows() As DataRow
        ' Use the Select method to find all rows matching the filter.
        foundRows = otb_datos_desplegados.Select(expression)
        For Each orow As DataRow In foundRows
            'n_documento = orow("id_solicitud")
            'MsgBox(n_documento)
            DD = "S"
        Next
    End Sub

    Private Sub dg_datos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_datos.CellClick
        If dg_datos.Rows.Count = 0 Then
            Exit Sub
        End If
        id_item_clonar = dg_datos.CurrentRow.Cells("id_producto").Value
        tx_item_prog_prod.Text = dg_datos.CurrentRow.Cells("id_ipp").Value
        descripcion_producto = dg_datos.CurrentRow.Cells("producto").Value
    End Sub

    Private Sub dg_datos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_datos.CellDoubleClick
        Dim nombre_columna As String = dg_datos.Columns(dg_datos.CurrentCell.ColumnIndex).Name

        If dg_datos.Rows.Count = 0 Then
            Exit Sub
        End If
        Select Case nombre_columna
            Case "id_ipp"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                If tx_item_prog_prod.Text.Trim = "" Then
                    Exit Sub
                End If
                desplegar_programa_prod_item()

        End Select
        cargar_items_programa()
        If dg_datos.Rows.Count > 0 Then
            'Para dejar seleccionado el mismo elemento que se abrio
            dg_datos.FirstDisplayedScrollingRowIndex = fila_actual
            dg_datos.CurrentCell = dg_datos.Rows.Item(fila_actual).Cells(1)
        End If
    End Sub

    Private Sub bt_clonar_pp_Click(sender As Object, e As EventArgs) Handles bt_clonar_pp.Click
        If tx_id_prog_prod.Text.Trim = "" Then
            Exit Sub
        End If
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Clonar Programa", "Desea clonar este programa en uno nuevo?")
        If respuesta = "N" Then
            Exit Sub
        End If
        nuevo_encabezado_prog_prod()
        nuevo_id_prog_prod = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0400_id_pp", "f0400_usuario_crear",
                                                                                                         vg_usuario_autoriza, "tb0400_programa_produccion")
        For Each orow As DataRow In otb_items_programa.Rows
            nuevo_item_prog_prod(nuevo_id_prog_prod, orow("id_producto"), orow("cantidad"))
        Next
        MsgBox("Programa Clonado en el registro: " & nuevo_id_prog_prod, MsgBoxStyle.Information, "Info")
        Dispose()
    End Sub

    Private Sub nuevo_encabezado_prog_prod()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0400_programa_produccion" _
                & " (f0400_id_cia, f0400_nombre, f0400_fecha_inicio, f0400_fecha_final," _
                & " f0400_dosificacion," _
                & " f0400_usuario_modificar, f0400_usuario_crear, f0400_fm)" _
                & " VALUES" _
                & " (@f0400_id_cia, @f0400_nombre, @f0400_fecha_inicio, @f0400_fecha_final," _
                & " @f0400_dosificacion," _
                & " @f0400_usuario_modificar, @f0400_usuario_crear, @f0400_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_enc_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            'ocmd.Parameters.Add("f0400_id_pp", NpgsqlDbType.Integer).Value = id_prog_prod
        End If
        ocmd.Parameters.Add("@f0400_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0400_nombre", NpgsqlDbType.Varchar).Value = "Clonado"
        ocmd.Parameters.Add("@f0400_fecha_inicio", NpgsqlDbType.Timestamp).Value = fecha_act
        ocmd.Parameters.Add("@f0400_fecha_final", NpgsqlDbType.Timestamp).Value = fecha_act
        ocmd.Parameters.Add("@f0400_dosificacion", NpgsqlDbType.Varchar).Value = odosificacion
        ocmd.Parameters.Add("@f0400_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0400_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0400_fm", NpgsqlDbType.Timestamp).Value = fecha_act

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

    Private Sub editar_encabezado_prog_prod()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0400_programa_produccion set "
        csql += "f0400_nombre = @f0400_nombre,"
        csql += "f0400_fecha_inicio = @f0400_fecha_inicio,"
        csql += "f0400_fecha_final = @f0400_fecha_final,"
        csql += "f0400_usuario_modificar = @f0400_usuario_modificar,"
        csql += "f0400_fm = @f0400_fm"
        csql += " where f0400_id_pp = '" & id_prog_prod & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_enc_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            'ocmd.Parameters.Add("f0400_id_pp", NpgsqlDbType.Integer).Value = id_prog_prod
        End If
        ocmd.Parameters.Add("@f0400_nombre", NpgsqlDbType.Varchar).Value = tx_nombre.Text
        ocmd.Parameters.Add("@f0400_fecha_inicio", NpgsqlDbType.Timestamp).Value = dtp_f_ini.Value
        ocmd.Parameters.Add("@f0400_fecha_final", NpgsqlDbType.Timestamp).Value = dtp_f_fin.Value
        ocmd.Parameters.Add("@f0400_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0400_fm", NpgsqlDbType.Timestamp).Value = fecha_act

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

    Private Sub nuevo_item_prog_prod(ByVal oid_prog_prod As Integer, ByVal id_item As Integer, ByVal cantidad As Decimal)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0401_items_prog_prod" _
                & " (f0401_id_cia, f0401_id_prog_prod, f0401_id_item, f0401_cantidad," _
                & " f0401_tree_path," _
                & " f0401_usuario_modificar, f0401_usuario_crear, f0401_fm)" _
                & " VALUES" _
                & " (@f0401_id_cia, @f0401_id_prog_prod, @f0401_id_item, @f0401_cantidad," _
                & " @f0401_tree_path," _
                & " @f0401_usuario_modificar, @f0401_usuario_crear, @f0401_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0401_id_prog_prod", NpgsqlDbType.Integer).Value = oid_prog_prod
        ocmd.Parameters.Add("@f0401_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0401_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0401_cantidad", NpgsqlDbType.Numeric).Value = cantidad
        ocmd.Parameters.Add("@f0401_tree_path", NpgsqlDbType.Varchar).Value = "-" & oid_prog_prod & "-"
        ocmd.Parameters.Add("@f0401_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_fm", NpgsqlDbType.Timestamp).Value = fecha_act

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

    Private Sub editar_item_pp(ByVal id_ipp As Integer, ByVal id_item As Integer, ByVal cantidad As Decimal)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0401_items_prog_prod set "
        csql += "f0401_id_item = @f0401_id_item,"
        csql += "f0401_cantidad = @f0401_cantidad,"
        csql += "f0401_usuario_modificar = @f0401_usuario_modificar,"
        csql += "f0401_fm = @f0401_fm"
        csql += " where f0401_id_ipp = '" & id_ipp & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0401_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0401_cantidad", NpgsqlDbType.Numeric).Value = cantidad
        ocmd.Parameters.Add("@f0401_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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

    Private Sub anular_op(ByVal id_ipp As Integer, ByVal path_anular As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0401_items_prog_prod set "
        csql += "f0401_anulado = 'S',"
        csql += "f0401_usuario_anular = @f0401_usuario_modificar,"
        csql += "f0401_usuario_modificar = @f0401_usuario_modificar,"
        csql += "f0401_fm = @f0401_fm"
        csql += " where f0401_id_ipp = '" & id_ipp & "' or substring(f0401_tree_path from 1 for char_length('" & path_anular & "')) = '" & path_anular & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0401_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0401_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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

    Private Sub desplegar_programa_prod_item()
        If tx_item_prog_prod.Text.Trim = "" Then
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0400_pp_ordenes_produccion_arbol
        oform_catalogo_items.vf_oform_padre = Me
        oform_catalogo_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_catalogo_items.vg_id_cia = vg_id_cia
        oform_catalogo_items.lb_producto.Text = "PRODUCTO: " & descripcion_producto
        oform_catalogo_items.id_prog_prod = id_prog_prod
        oform_catalogo_items.id_item_clonar = id_item_clonar
        oform_catalogo_items.id_item_pp = tx_item_prog_prod.Text
        oform_catalogo_items.tree_path_base = "-" & id_prog_prod & "-" & tx_item_prog_prod.Text & "-"
        oform_catalogo_items.vf_elemento_nuevo = "N"
        'oform_catalogo_items.vf_elemento_nuevo = "N"
        oform_catalogo_items.ShowDialog()
    End Sub

    Private Sub bt_orden_produccion_Click(sender As Object, e As EventArgs) Handles bt_orden_produccion.Click
        If tx_item_prog_prod.Text.Trim = "" Then
            Exit Sub
        End If
        desplegar_programa_prod_item()
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        If tx_item_prog_prod.Text = "" Then
            Exit Sub
        End If

        'Pregunta si realmente desea crear anular el item
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Item", "Desea ANULAR las: " & dg_datos.CurrentRow.Cells("cantidad").Value _
            & " unidades programadas del producto " & dg_datos.CurrentRow.Cells("producto").Value)
        If respuesta = "N" Then
            Exit Sub
        End If

        'me aseguro que el item programado no tenga informacion anexa
        Dim path_id_ipp As String = "-" & id_prog_prod & "-" & tx_item_prog_prod.Text & "-"
        csql = " select * from " & database.obtener_esquema & ".tb0401_items_prog_prod" _
            & " where substring(f0401_tree_path from 1 for char_length('" & path_id_ipp & "')) = '" & path_id_ipp & "' and f0401_anulado = 'N'"
        Dim otb_info_anexa As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_info_anexa.Rows.Count > 0 Then
            MsgBox("No se puede anular un item programado ya gestionado.", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If


        anular_op(tx_item_prog_prod.Text, path_id_ipp)
        If verror = "N" Then
            MsgBox("Item anulado", MsgBoxStyle.Information, "Info")
            cargar_items_programa()
        End If
    End Sub

    Private Sub bt_nuevo_Click(sender As Object, e As EventArgs) Handles bt_nuevo.Click
        Dim filtro_items As String
        If odosificacion = "N" Then
            filtro_items = "(f0300_id_tipo_item = '15' or f0300_id_tipo_item = '25') and f0300_ar = 'N'"
        Else
            filtro_items = "(f0300_id_tipo_item = '15' or f0300_id_tipo_item = '25') and f0300_ar = 'S'"
        End If
        ' 15=producto terminado y 25 = producto semiterminado
        ' Recordar que los productos con acceso restringido no se pueden programar en este modulo

        Dim info_item_mov_inventario As cl_estructuras_variables.info_item_mov_inventario = Nothing
        info_item_mov_inventario.id_item = 0
        info_item_mov_inventario = cl_utilidades_gestion_compras.form_suministrar_item_cantidad(vg_usuario_autoriza, vg_id_cia, comunes.g_fechahora,
                                                                                                filtro_items,,,,,,,,, "N")
        Dim orow As DataRow() = otb_items_programa.Select("id_producto = '" & info_item_mov_inventario.id_item & "'")
        If orow.Length > 0 Then
            MsgBox("Este item ya esta programado", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If info_item_mov_inventario.id_item <> 0 Then
            nuevo_item_prog_prod(id_prog_prod, info_item_mov_inventario.id_item, info_item_mov_inventario.cantidad)
            If verror = "N" Then
                MsgBox("Nuevo item creado", MsgBoxStyle.Information, "Info")
                cargar_items_programa()
            End If
        End If
    End Sub

    Private Sub bt_editar_Click(sender As Object, e As EventArgs) Handles bt_editar.Click
        If tx_item_prog_prod.Text = "" Then
            Exit Sub
        End If

        'si el item programado ya tiene info anexa entonces solo modifica cantidad
        Dim path_id_ipp As String = "-" & id_prog_prod & "-" & tx_item_prog_prod.Text & "-"
        'MsgBox(path_id_ipp)
        Dim permitir_edicion_item As String = "S"
        csql = " select * from " & database.obtener_esquema & ".tb0401_items_prog_prod" _
            & " where substring(f0401_tree_path from 1 for char_length('" & path_id_ipp & "')) = '" & path_id_ipp & "' and f0401_anulado = 'N'"
        Dim otb_info_anexa As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_info_anexa.Rows.Count > 0 Then
            permitir_edicion_item = "N"
        End If

        Dim filtro_items As String = "f0300_id_tipo_item = '15' or f0300_id_tipo_item = '25'"
        ' 15=producto terminado y 25 = producto semiterminado
        Dim info_item_mov_inventario As cl_estructuras_variables.info_item_mov_inventario = Nothing
        info_item_mov_inventario.id_item = 0
        info_item_mov_inventario = cl_utilidades_gestion_compras.form_suministrar_item_cantidad(vg_usuario_autoriza, vg_id_cia, comunes.g_fechahora, filtro_items,
                                                                                  dg_datos.CurrentRow.Cells("id_producto").Value,
                                                                                  dg_datos.CurrentRow.Cells("cantidad").Value, 0,
                                                                                  permitir_edicion_item,,,,, "N")
        If info_item_mov_inventario.id_item <> 0 Then
            editar_item_pp(tx_item_prog_prod.Text, info_item_mov_inventario.id_item, info_item_mov_inventario.cantidad)
            If verror = "N" Then
                MsgBox("Item editado", MsgBoxStyle.Information, "Info")
                cargar_items_programa()
            End If
        End If
    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        'Pregunta si realmente desea editar encabezado de programa
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Actualizar", "Desea EDITAR ENCABEZADO DE PROGRAMA: " & tx_nombre.Text)
        If respuesta = "N" Then
            Exit Sub
        End If
        editar_encabezado_prog_prod()
        If verror = "N" Then
            MsgBox("Encabezado del programa actualizado", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub bt_prog_diaria_Click(sender As Object, e As EventArgs) Handles bt_prog_diaria.Click
        Dim rango_fechas() As String
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0400-12", vg_id_cia, vg_usuario_autoriza,
                                                            "Programa de Produccion Diario", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub
End Class
