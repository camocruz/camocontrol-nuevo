Imports System.ComponentModel

Public Class fm_0300_formulacion
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
    Public id_item_padre As Integer

    'Private$vf_otabla_permisos$As DataTable

    Private odr As NpgsqlDataReader
    Private oconn_form As NpgsqlConnection

    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private csql As String = ""
    Private vcerrar As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private vexiste As String = ""
    Private vdia_semana As String = ""
    Private vcodigo_conductor As String = ""
    Private vnuevo_registro As String = "S"
    Private verror As String = "N"
    Private item_salida_plantilla As Integer
    Private cantidad_bache_global As Decimal
    Private otb_items As DataTable
    Private otb_formula As DataTable
    Private otb_plantillas As DataTable
    Private otb_items_plantilla As DataTable
    Private otb_items_equivalentes As DataTable
    Private otb_costo_items As DataTable
    Private ocosto As Decimal = 0
    Private plantilla_activa As String = "S"
    Private id_item_alterno As Integer
    Private cantidad_item_alterno As Decimal

    Public orow_item_calculadora(3) As String
    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell


    Private Sub fm_0300_plantillas_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        otipo_nota = comunes.suministrar_valor_variable_configuracion("TN-FRM-001", vg_id_cia)
        bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_plantilla, vg_id_cia)

        bt_anular.Enabled = False
        bt_generar_informe.Enabled = False
        bt_editar.Enabled = False
        'bt_nuevo.Enabled = False
        'bt_grabar.Enabled = False

        cargar_costo_horas_hombre()

        dg_items.AllowUserToAddRows = False
        dg_items.AllowUserToDeleteRows = False
        dg_items.AllowUserToResizeColumns = True
        dg_items.AllowUserToResizeRows = False
        dg_items.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige

        'cargar_costos_todos_items()

        If vf_elemento_nuevo = "N" Then
            cargar_info_plantilla()
            cargar_items()
        Else
            lb_titulo.Text = "Nueva Explosion de Materiales"
        End If
    End Sub

    Private Sub cargar_costo_horas_hombre()
        'cargamos los valores de hora hombre
        Dim valores_h_hombre As String() = Split(comunes.suministrar_valor_variable_configuracion("CONFIG-0300-01", vg_id_cia), "|")
        Dim valor_h_h As String()
        For Each ostring As String In valores_h_hombre
            'MsgBox(ostring)
            valor_h_h = Split(ostring, ",")
            'MsgBox(valor_h_h(0))
            Select Case valor_h_h(0)
                Case "3181"
                    tx_h_operario.Text = valor_h_h(1)
                Case "3182"
                    tx_h_operario_lider.Text = valor_h_h(1)
                Case "3183"
                    tx_h_supervisor.Text = valor_h_h(1)
            End Select
        Next
    End Sub

    Private Sub cargar_informacion_otb_items()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-00", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub

    Private Sub cargar_info_plantilla()
        Dim p_activa As String = "S"
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-06", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        'para mostrar el encabezado de todas las plantillas
        csql = csql.Replace(" and f0350_activa = 'S'", "")
        otb_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'MsgBox(id_plantilla)
        otb_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim orow_plantilla() As DataRow
        orow_plantilla = otb_plantillas.Select("f0350_id_plantilla = '" & id_plantilla & "'")
        For Each orow As DataRow In orow_plantilla
            item_salida_plantilla = orow("f0350_id_item")
            tx_id_exmtp.Text = orow("f0350_id_plantilla")
            tx_descripcion.Text = orow("f0350_descripcion")
            tx_cantidad_x_bache.Text = orow("f0350_produccion_x_bache")
            lb_unidad_medicion.Text = orow("f0002_unidad_medicion") & " (S) de: " & orow("descripcion_larga")
            lb_unid_cost_unit.Text = "$ / " & orow("f0002_unidad_medicion")
            tx_h_prod_x_bache.Text = CDec(orow("f0350_t_prod_bache")).ToString("N2")
            tx_hh_bache.Text = CDec(orow("f0350_hh_prod_bache")).ToString("N2")
            cargar_items()
            If orow("f0350_activa") = "S" Then
                'MsgBox("pase")
                plantilla_activa = "S"
                lb_titulo.Text = "Plantilla de Produccion (Activa)"
            Else
                plantilla_activa = "N"
                lb_titulo.Text = "Plantilla de Produccion (Inactiva)"
                'Pregunta si realmente desea activar plantilla
                'Dim respuesta As String = "N"
                'respuesta = comunes.g_mensaje_YesNo("Activar Plantilla", "Desea activar esta plantilla?")
                'If respuesta = "N" Then
                'Dispose()
                'Exit Sub
                'End If
                'desactivar_todas_las_plantillas()
                'activar_la_plantilla()
                'MsgBox("La plantilla fue activada, ingrese nuevamente para visualizar los datos")
                'Dispose()
            End If
        Next
    End Sub

    Private Sub cargar_costos_todos_items()
        'entrega un array de dos dimensiones, donde la columna 1 es el costo sin IVA
        ' y la segunda columna es el costo con IVA.
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-03", vg_id_cia)

        otb_costo_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'MsgBox(otb_costo_items.Rows.Count)
    End Sub

    Private Sub cargar_items()
        dg_items.Rows.Clear()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-14", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_plantilla)
        otb_items_plantilla = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        ocosto = 0
        For Each orow As DataRow In otb_items_plantilla.Rows
            agregar_fila_items(orow)
        Next
        dg_items_opcionales.Rows.Clear()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-15", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_plantilla)
        otb_items_equivalentes = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub

    Private Sub agregar_fila_items(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0351_id_elemento"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0300_id_item"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0300_descripcion_item").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0002_unidad_medicion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0351_cantidad").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        'Dim cost_item As Decimal = 0
        'Try
        'cost_item = calcular_costo_item_total(CInt(orow.Item("f0300_id_item")), orow.Item("f0351_cantidad"), 1)
        'Catch ex As Exception
        'cost_item = 0
        'MsgBox("Hubo un error calculando costo " + vbCrLf + ex.ToString)
        'End Try
        otextgrid.Value = 0.ToString("C2")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'calculo es costo total sumando el valor de cada item
        'ocosto += cost_item
        'tx_costo_unitario.Text = CDec(ocosto / tx_cantidad_x_bache.Text).ToString("C2")
        'tx_costo_bache.Text = CDec(ocosto).ToString("C2")

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_items.Rows.Add(orowgrid)
    End Sub

    Private Sub cargar_dg_items_equivalentes(ByVal id_elemento As Integer)
        dg_items_opcionales.Rows.Clear()
        Dim orows_items_equivalentes As DataRow()
        orows_items_equivalentes = otb_items_equivalentes.Select("f0352_id_elemento = '" & id_elemento & "'")

        For Each orow As DataRow In orows_items_equivalentes
            agregar_fila_items_opcionales(orow)
        Next
    End Sub

    Private Sub agregar_fila_items_opcionales(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0352_id_elemento"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0300_id_item"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0300_descripcion_item").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0002_unidad_medicion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0352_cantidad").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        'Dim cost_item As Decimal = 0
        'Try
        'cost_item = calcular_costo_item_total(CInt(orow.Item("f0300_id_item")), orow.Item("f0351_cantidad"), 1)
        'Catch ex As Exception
        'cost_item = 0
        'MsgBox("Hubo un error calculando costo " + vbCrLf + ex.ToString)
        'End Try
        otextgrid.Value = 0.ToString("C2")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'calculo es costo total sumando el valor de cada item
        'ocosto += cost_item
        'tx_costo_unitario.Text = CDec(ocosto / tx_cantidad_x_bache.Text).ToString("C2")
        'tx_costo_bache.Text = CDec(ocosto).ToString("C2")

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_items_opcionales.Rows.Add(orowgrid)
    End Sub
    Private Sub nuevo_encabezado_formulacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0350_plantillas" _
                & " (f0350_id_cia, f0350_id_item, f0350_descripcion, f0350_produccion_x_bache," _
                & " f0350_t_prod_bache, f0350_hh_prod_bache," _
                & " f0350_usuario_modificar, f0350_usuario_crear, f0350_fm)" _
                & " VALUES" _
                & " (@f0350_id_cia, @f0350_id_item, @f0350_descripcion, @f0350_produccion_x_bache," _
                & " @f0350_t_prod_bache, @f0350_hh_prod_bache," _
                & " @f0350_usuario_modificar, @f0350_usuario_crear, @f0350_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_formula(ocmd)

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

    Private Sub actualizar_encabezado_formulacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0350_plantillas set "
        csql += "f0350_descripcion = @f0350_descripcion,"
        csql += "f0350_produccion_x_bache = @f0350_produccion_x_bache,"
        csql += "f0350_t_prod_bache = @f0350_t_prod_bache,"
        csql += "f0350_hh_prod_bache = @f0350_hh_prod_bache,"
        csql += "f0350_fm = @f0350_fm,"
        csql += "f0350_usuario_modificar = @f0350_usuario_modificar"
        csql += " where f0350_id_plantilla = @f0350_id_plantilla"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0350_id_plantilla", NpgsqlDbType.Integer).Value = id_plantilla
        End If
        ocmd.Parameters.Add("@f0350_descripcion", NpgsqlDbType.Varchar).Value = tx_descripcion.Text
        ocmd.Parameters.Add("@f0350_produccion_x_bache", NpgsqlDbType.Numeric).Value = tx_cantidad_x_bache.Text
        ocmd.Parameters.Add("@f0350_t_prod_bache", NpgsqlDbType.Numeric).Value = tx_h_prod_x_bache.Text
        ocmd.Parameters.Add("@f0350_hh_prod_bache", NpgsqlDbType.Numeric).Value = tx_hh_bache.Text
        ocmd.Parameters.Add("@f0350_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0350_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando1! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar1 ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_formula(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0350_id_plantilla", NpgsqlDbType.Integer).Value = id_plantilla
        End If
        ocmd.Parameters.Add("@f0350_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0350_id_item", NpgsqlDbType.Integer).Value = id_item_padre
        ocmd.Parameters.Add("@f0350_descripcion", NpgsqlDbType.Varchar).Value = UCase(tx_descripcion.Text)
        ocmd.Parameters.Add("@f0350_produccion_x_bache", NpgsqlDbType.Numeric).Value = tx_cantidad_x_bache.Text
        ocmd.Parameters.Add("@f0350_t_prod_bache", NpgsqlDbType.Numeric).Value = tx_h_prod_x_bache.Text
        ocmd.Parameters.Add("@f0350_hh_prod_bache", NpgsqlDbType.Numeric).Value = tx_hh_bache.Text
        ocmd.Parameters.Add("@f0350_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0350_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0350_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub

    Private Sub dg_items_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_items.CellClick

        If dg_items.Rows.Count = 0 Then
            Exit Sub
        End If
        tx_id_lmnto.Text = dg_items.CurrentRow.Cells("dgocell_id_elemento").Value
        tx_id_item.Text = dg_items.CurrentRow.Cells("dgocell_id_item").Value
        cargar_dg_items_equivalentes(dg_items.CurrentRow.Cells("dgocell_id_elemento").Value)
    End Sub

    Private Sub dg_items_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_items.CellDoubleClick
        Dim nombre_columna As String = dg_items.Columns(dg_items.CurrentCell.ColumnIndex).Name

        If dg_items.Rows.Count = 0 Then
            Exit Sub
        End If
        Select Case nombre_columna
            Case "dgocell_id_item"
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_items As New camocontrol.fm_0300_gestion_items
                oform_items.vf_oform_padre = Me
                oform_items.vg_usuario_autoriza = vg_usuario_autoriza
                oform_items.vg_id_cia = vg_id_cia
                oform_items.id_item = dg_items.CurrentRow.Cells("dgocell_id_item").Value
                'oform_items.cm_descripcion.SelectedValue = dg_items.CurrentRow.Cells("dgocell_id_item").Value
                'oform_items.tx_id_item.Focus()
                'oform_items.tx_id_item.Text = dg_items.CurrentRow.Cells("dgocell_id_item").Value
                oform_items.vf_elemento_nuevo = "N"
                'oform_items.vf_elemento_nuevo = "N"
                oform_items.ShowDialog()
            Case "dgocell_id_elemento"
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_catalogo_items As New camocontrol.fm_0300_formulacion_items
                oform_catalogo_items.vf_oform_padre = Me
                oform_catalogo_items.vg_usuario_autoriza = vg_usuario_autoriza
                oform_catalogo_items.vg_id_cia = vg_id_cia
                oform_catalogo_items.id_plantilla = id_plantilla
                oform_catalogo_items.id_lmnto = dg_items.CurrentRow.Cells("dgocell_id_elemento").Value
                oform_catalogo_items.vf_elemento_nuevo = "N"
                'oform_catalogo_items.vf_elemento_nuevo = "N"
                oform_catalogo_items.ShowDialog()
        End Select
        cargar_items()
    End Sub

    Private Sub tx_cantidad_x_bache_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_cantidad_x_bache.KeyPress
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

    Private Sub tx_cantidad_x_bache_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_cantidad_x_bache.Validating
        If Not IsNumeric(tx_cantidad_x_bache.Text) Then
            MsgBox("Digite un Numero Valido", MsgBoxStyle.Information, "Info")
            tx_cantidad_x_bache.Text = "1"
        Else
            Dim onum As Decimal = tx_cantidad_x_bache.Text
            If onum = 0 Then
                MsgBox("La cantidad por bache no puede ser 0", MsgBoxStyle.Information, "Info")
                tx_cantidad_x_bache.Text = "1"
            Else
                tx_cantidad_x_bache.Text = onum
            End If
        End If
    End Sub
    Private Sub tx_h_prod_x_bache_Validating(sender As Object, e As CancelEventArgs) Handles tx_h_prod_x_bache.Validating
        If Not IsNumeric(tx_h_prod_x_bache.Text) Then
            MsgBox("Digite un Numero Valido", MsgBoxStyle.Information, "Info")
            tx_h_prod_x_bache.Text = "1"
        Else
            Dim onum As Decimal = tx_h_prod_x_bache.Text
            If onum = 0 Then
                MsgBox("Las horas de produccion del bache no pueden ser 0", MsgBoxStyle.Information, "Info")
                tx_h_prod_x_bache.Text = "1"
            Else
                tx_h_prod_x_bache.Text = onum
            End If
        End If
    End Sub

    Private Sub tx_hh_bache_Validating(sender As Object, e As CancelEventArgs) Handles tx_hh_bache.Validating
        If Not IsNumeric(tx_hh_bache.Text) Then
            MsgBox("Digite un Numero Valido", MsgBoxStyle.Information, "Info")
            tx_hh_bache.Text = "1"
        Else
            Dim onum As Decimal = tx_hh_bache.Text
            If onum = 0 Then
                MsgBox("Las horas hombre de produccion del bache no pueden ser 0", MsgBoxStyle.Information, "Info")
                tx_hh_bache.Text = "1"
            Else
                tx_hh_bache.Text = onum
            End If
        End If
    End Sub
    Private Sub validar_cant_bache()
        If tx_cantidad_x_bache.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina una Cantidad por Bache."
        End If
    End Sub
    Private Sub validar_descripcion()
        If tx_descripcion.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina una descripción del Proceso."
        End If
    End Sub
    Private Sub validar_t_prod_bache()
        If tx_h_prod_x_bache.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el tiempo de produccion Bache."
        End If
    End Sub
    Private Sub validar_hh_bache()
        If tx_hh_bache.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina las horas hombre de produccion Bache."
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_cant_bache()
        validar_descripcion()
        validar_t_prod_bache()
        validar_hh_bache()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            verror = "N"
            nuevo_encabezado_formulacion()
            If verror = "N" Then
                MsgBox("Creado", MsgBoxStyle.Information, "Info")
            Else
                Exit Sub
            End If
            vf_elemento_nuevo = "N"
            tx_id_exmtp.Text = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0350_id_plantilla",
                                                                                            "f0350_usuario_crear",
                                                                                            vg_usuario_autoriza,
                                                                                            "tb0350_plantillas")

            id_plantilla = tx_id_exmtp.Text
            'Activo la nueva plantilla. las anteriores se inactivan
            desactivar_todas_las_plantillas()
            activar_la_plantilla()


            cargar_info_plantilla()
            cargar_items()
        Else
            verror = "N"
            actualizar_encabezado_formulacion()
            cargar_info_plantilla()
            If verror = "N" Then
                MsgBox("Actualizado", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub bt_nuevo_Click(sender As Object, e As EventArgs) Handles bt_nuevo.Click
        If vf_elemento_nuevo = "S" Then
            MsgBox("Primero debe grabar una Plantilla", MsgBoxStyle.Information)
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0300_formulacion_items
        oform_catalogo_items.vf_oform_padre = Me
        oform_catalogo_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_catalogo_items.vg_id_cia = vg_id_cia
        oform_catalogo_items.id_plantilla = id_plantilla
        oform_catalogo_items.vf_elemento_nuevo = "S"
        'oform_catalogo_items.vf_elemento_nuevo = "N"
        oform_catalogo_items.ShowDialog()
        cargar_items()
    End Sub

    Private Sub nuevo_item_formula()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0350_plantillas" _
                & " (f0351_id_cia, f0351_id_plantilla, f0351_id_item, f0351_cantidad," _
                & " f0351_usuario_modificar, f0351_usuario_crear, f0351_fm)" _
                & " VALUES" _
                & " (@f0351_id_cia, @f0351_id_plantilla, @f0351_id_item, @f0351_cantidad," _
                & " @f0351_usuario_modificar, @f0351_usuario_crear, @f0351_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_formula(ocmd)

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

    Private Sub bt_g_notas_Click(sender As Object, e As EventArgs) Handles bt_g_notas.Click
        If id_plantilla <> 0 And id_plantilla.ToString <> "" Then
            'MsgBox(otipo_nota & "---" & id_plantilla)
            cl_gestion_anotaciones.consultar_anotaciones_acciones(id_plantilla, otipo_nota, vg_usuario_autoriza, vg_id_cia, "ST-0606-03", "2")
            bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_plantilla, vg_id_cia)
        Else
            MsgBox("No ha definido una Disociacion", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0350_plantillas set "
        csql += "f0350_anulado = 'S',"
        csql += "f0350_usuario_anular = @f0350_usuario_anular,"
        csql += "f0350_fm = @f0350_fm,"
        csql += "f0350_usuario_modificar = @f0350_usuario_modificar"
        csql += " where f0350_id_plantilla = @f0350_id_plantilla"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_formula(ocmd)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0350_id_plantilla", NpgsqlDbType.Integer).Value = id_plantilla
        End If
        ocmd.Parameters.Add("@f0350_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0350_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0350_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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
            MsgBox("Disociacion Anulada", MsgBoxStyle.Information, "Info")
        End If
    End Sub


    Private Sub bt_calcular_costo_Click(sender As Object, e As EventArgs) Handles bt_calcular_costo.Click
        cargar_costos_todos_items()
        llenar_costos_plantilla()
    End Sub

    Private Sub llenar_costos_plantilla()
        Dim cost_item As Decimal = 0
        Dim cost_item_iva As Decimal = 0
        Dim arraycostos() As Decimal = {0, 0}
        Dim ocosto_iva As Decimal = 0
        ocosto = 0
        'inicializo el arreglo de matriz escalonada cob valores de 0
        Dim array_costos_sugeridos As Decimal()() = llenar_array_costos_sugeridos()
        Dim otb_items_todas_plantillas As DataTable
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_plantilla)
        otb_items_todas_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'calculamos los costos de cada item en el datagrid
        For Each orow As DataGridViewRow In dg_items.Rows
            'MsgBox(orow.Cells("dgocell_id_item").Value)
            Try
                arraycostos = cl_utilidades_gestion_compras.calcular_costo_item_total(orow.Cells("dgocell_id_item").Value,
                                                                                      orow.Cells("dgocell_cantidad").Value, 1, otb_plantillas,
                                                                       otb_items_todas_plantillas, otb_costo_items, array_costos_sugeridos)
                orow.Cells("dgocell_cost_total").Value = arraycostos(0).ToString("C2")
                orow.Cells("dgocell_cost_unit").Value = CDec(arraycostos(0) / orow.Cells("dgocell_cantidad").Value).ToString("C2")

                cost_item = arraycostos(0)
                cost_item_iva = arraycostos(1)


            Catch ex As Exception
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
                MsgBox("Falla llenada de costos en dg")
                cost_item = 0
            End Try

            'calculo es costo total sumando el valor de cada item
            ocosto += cost_item
            ocosto_iva += cost_item_iva
            tx_costo_unitario.Text = CDec(ocosto / tx_cantidad_x_bache.Text).ToString("C2")
            tx_costo_bache.Text = CDec(ocosto).ToString("C2")
            tx_costo_unitario_iva.Text = CDec(ocosto_iva / tx_cantidad_x_bache.Text).ToString("C2")
            tx_costo_bache_iva.Text = CDec(ocosto_iva).ToString("C2")

        Next

    End Sub

    Private Sub bt_historico_compras_Click(sender As Object, e As EventArgs) Handles bt_historico_compras.Click
        If tx_id_item.Text = "" Then
            MsgBox("Seleccione un item para consultar", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_compras.movimientos_compras_item(tx_id_item.Text, vg_usuario_autoriza, vg_id_cia)
    End Sub

    Private Sub bt_exportar_formula_Click(sender As Object, e As EventArgs) Handles bt_exportar_formula.Click
        If plantilla_activa = "N" Then
            MsgBox("No permitido para plantillas desactivadas.", MsgBoxStyle.Exclamation, "Denegado")
            Exit Sub
        End If
        Dim contador As Integer = 0
        llenar_costos_plantilla()
        'inicializo el arreglo de matriz escalonada cob valores de 0
        Dim array_costos_sugeridos As Decimal()() = llenar_array_costos_sugeridos()

        'MsgBox(array_costos_sugeridos.Length)
        Dim otb_formula As DataTable
        'Entrego otb_costo_items para reducir el tiempo de calculo. (se puede entregar el objeto vacio la consulta 
        'se realizaria en la funcion
        otb_formula = cl_utilidades_gestion_compras.entregar_formula_item(id_item_padre, vg_id_cia, otb_costo_items, array_costos_sugeridos)
        cl_utilidades_datatables.exportar_datatable_excel(otb_formula)
        'MsgBox(otb_formula.Rows.Count)
        Exit Sub
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        'oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.otb_datos = otb_formula
        oform_mostrar_datos.titulo_formulario = "Plantilla de Producción"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.dg_datos.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable
        oform_mostrar_datos.ShowDialog()

    End Sub


    Private Sub bt_calculadora_costos_Click(sender As Object, e As EventArgs) Handles bt_calculadora_costos.Click
        orow_item_calculadora = {0, 0, 0, 0}

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0300_formulacion_items
        oform_catalogo_items.vf_oform_padre = Me
        oform_catalogo_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_catalogo_items.vg_id_cia = vg_id_cia
        oform_catalogo_items.id_plantilla = id_plantilla
        oform_catalogo_items.bt_g_notas.Enabled = False
        oform_catalogo_items.bt_g_archivos.Enabled = False
        oform_catalogo_items.bt_nuevo.Enabled = False
        oform_catalogo_items.vf_elemento_nuevo = "S"
        oform_catalogo_items.carga_calculadora_costos = "S"
        oform_catalogo_items.ShowDialog()

        If CInt(orow_item_calculadora(1)) = 0 Then
            Exit Sub
        End If

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow_item_calculadora(1))
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow_item_calculadora(2)
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow_item_calculadora(3)
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_var_costos.Rows.Add(orowgrid)

    End Sub

    Private Sub dg_var_costos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_var_costos.CellClick
        If dg_var_costos.Rows.Count = 0 Then
            Exit Sub
        End If
        tx_id_item.Text = dg_var_costos.CurrentRow.Cells("dgocell_varcost_id_item").Value
    End Sub

    Private Function llenar_array_costos_sugeridos()
        'inicializo el arreglo de matriz escalonada cob valores de 0
        Dim array_costos_sugeridos As Decimal()() = New Decimal(0)() {}
        array_costos_sugeridos(0) = New Decimal() {0, 0}
        'creo el arreglo de los costos sugeridos para items
        If dg_var_costos.Rows.Count > 0 Then
            Dim long_array As Integer = dg_var_costos.Rows.Count + 2
            ReDim array_costos_sugeridos(long_array)
            Dim contador As Integer = 0

            For Each orow As DataGridViewRow In dg_var_costos.Rows
                array_costos_sugeridos(contador) = New Decimal() {orow.Cells("dgocell_varcost_id_item").Value, orow.Cells("dgocell_varcost_costo").Value}
                contador += 1
            Next
            array_costos_sugeridos(contador) = {3181, CDec(tx_h_operario.Text)}
            array_costos_sugeridos(contador + 1) = {3182, CDec(tx_h_operario_lider.Text)}
            array_costos_sugeridos(contador + 2) = {3183, CDec(tx_h_supervisor.Text)}
        Else
            'agrego los valores sugeridos de mano de obra al array costos
            'redimensiono el array sumandole 2 elementos pues son 3 valores de mano de obra
            ReDim array_costos_sugeridos(2)
            array_costos_sugeridos(0) = {3181, CDec(tx_h_operario.Text)}
            array_costos_sugeridos(1) = {3182, CDec(tx_h_operario_lider.Text)}
            array_costos_sugeridos(2) = {3183, CDec(tx_h_supervisor.Text)}
        End If
        'para leer el array formado
        'For Each oarray As Array In array_costos_sugeridos
        'MsgBox(oarray(0) & " - " & oarray(1))
        'Next
        Return array_costos_sugeridos
    End Function

    Private Sub tx_h_operario_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_h_operario.Validating
        If IsNumeric(tx_h_operario.Text) = False Then
            tx_h_operario.Text = 0
        End If
    End Sub

    Private Sub tx_h_operario_lider_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_h_operario_lider.Validating
        If IsNumeric(tx_h_operario_lider.Text) = False Then
            tx_h_operario_lider.Text = 0
        End If
    End Sub

    Private Sub tx_h_supervisor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_h_supervisor.Validating
        If IsNumeric(tx_h_supervisor.Text) = False Then
            tx_h_supervisor.Text = 0
        End If
    End Sub

    Private Sub bt_recargar_costos_personal_Click(sender As Object, e As EventArgs) Handles bt_recargar_costos_personal.Click
        cargar_costo_horas_hombre()
    End Sub

    Private Sub desactivar_todas_las_plantillas()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0350_plantillas set"
        csql += " f0350_activa = 'N'"
        csql += " where f0350_id_item = '" & id_item_padre & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

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

    Private Sub activar_la_plantilla()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0350_plantillas set"
        csql += " f0350_activa = 'S'"
        csql += " where f0350_id_plantilla = '" & id_plantilla & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

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
            MsgBox("Plantilla Activada", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub bt_activar_plantilla_Click(sender As Object, e As EventArgs) Handles bt_activar_plantilla.Click
        'Pregunta si realmente desea activar plantilla
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Activar Plantilla", "Desea activar esta plantilla?")
        If respuesta = "N" Then
            Exit Sub
        End If
        desactivar_todas_las_plantillas()
        activar_la_plantilla()
        cargar_info_plantilla()
    End Sub

    Private Sub tx_h_prod_x_bache_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_h_prod_x_bache.KeyPress
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

    Private Sub tx_hh_bache_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_hh_bache.KeyPress
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

    Private Sub mi_nuevo_item_alterno_Click(sender As Object, e As EventArgs) Handles mi_nuevo_item_alterno.Click
        If dg_items.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim info_item_mov_inventario As cl_estructuras_variables.info_item_mov_inventario = Nothing
        info_item_mov_inventario.id_item = 0
        'Dim info_item() As Decimal
        info_item_mov_inventario = cl_utilidades_gestion_compras.form_suministrar_item_cantidad(vg_usuario_autoriza, vg_id_cia, Now, , ,
                                                                                dg_items.CurrentRow.Cells("dgocell_cantidad").Value)
        If info_item_mov_inventario.id_item = 0 Then
            Exit Sub
        End If
        id_item_alterno = info_item_mov_inventario.id_item
        cantidad_item_alterno = info_item_mov_inventario.cantidad
        nuevo_item_alterno()
        cargar_items()
        'cargar_dg_items_equivalentes(dg_items.CurrentRow.Cells("dgocell_id_elemento").Value)
        MsgBox("Item alterno creado", MsgBoxStyle.Information, "Info")
    End Sub

    Private Sub nuevo_item_alterno()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "INSERT INTO " & database.obtener_esquema & ".tb0352_elementos_equivalentes" _
                & " (f0352_id_cia, f0352_id_plantilla, f0352_id_elemento, f0352_id_item, f0352_cantidad," _
                & " f0352_usuario_modificar, f0352_usuario_crear, f0352_fm)" _
                & " VALUES" _
                & " (@f0352_id_cia, @f0352_id_plantilla, @f0352_id_elemento, @f0352_id_item, @f0352_cantidad," _
                & " @f0352_usuario_modificar, @f0352_usuario_crear, @f0352_fm)"

        ocmd.CommandText = csql

        'Inserción parametrizada
        crear_parametros_item_alterno(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! grabando item alterno" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error grabando item alterno" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_item_alterno(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0352_id_plantilla", NpgsqlDbType.Integer).Value = id_plantilla
        ocmd.Parameters.Add("@f0352_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0352_id_elemento", NpgsqlDbType.Integer).Value = CInt(dg_items.CurrentRow.Cells("dgocell_id_elemento").Value)
        ocmd.Parameters.Add("@f0352_id_item", NpgsqlDbType.Integer).Value = id_item_alterno
        ocmd.Parameters.Add("@f0352_cantidad", NpgsqlDbType.Numeric).Value = cantidad_item_alterno
        ocmd.Parameters.Add("@f0352_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0352_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0352_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub

    Private Sub mi_eliminar_item_opcional_Click(sender As Object, e As EventArgs) Handles mi_eliminar_item_opcional.Click
        If dg_items_opcionales.Rows.Count = 0 Then
            Exit Sub
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0352_elementos_equivalentes set "
        csql += "f0352_anulado = 'S',"
        csql += "f0352_usuario_modificar = @f0352_usuario_modificar,"
        csql += "f0352_fm = @f0352_fm"
        csql += " where f0352_id_plantilla = @f0352_id_plantilla and f0352_id_item = @f0352_id_item and f0352_anulado = 'N'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0352_id_plantilla", NpgsqlDbType.Integer).Value = id_plantilla
        ocmd.Parameters.Add("@f0352_id_item", NpgsqlDbType.Integer).Value = CInt(dg_items_opcionales.CurrentRow.Cells("dgocell_dgopcional_id_item").Value)
        ocmd.Parameters.Add("@f0352_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0352_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
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

        cargar_items()
        MsgBox("Item alterno eliminado", MsgBoxStyle.Information, "Info")
    End Sub


End Class
