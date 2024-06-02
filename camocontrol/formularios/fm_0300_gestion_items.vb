Imports System.ComponentModel

Public Class fm_0300_gestion_items
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    'Public vg_id_cia As String = ""
    'Public vf_elemento_nuevo As String = "S"
    Public id_estructura As Integer
    'Public otipo_nota As String = ""

    'Private$vf_otabla_permisos$As DataTable

    Public id_item As Integer = 0
    Public cerrar_al_actualizar As String = "N"
    Private acceso_restringido As String = "N"
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
    Private otb_bodegas As DataTable
    Private otb_puntos_control_inventario As DataTable

    Private id_bodega As Integer
    Private criterio_ubicacion As String = ""
    Private criterio_minimo As Decimal
    Private criterio_maximo As Decimal
    Private criterio_consumo_dia As Decimal

    Private Sub fm_0300_gestion_items_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-ITM"
        vf_var_config_notas = "TN-ITM-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        vf_elemento_nuevo = "S"
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)

        'bt_anular.Enabled = False
        'bt_generar_informe.Enabled = False
        'bt_editar.Enabled = False
        chk_descripcion_manual.Checked = False
        'Identificar si el usuario tiene acceso a informacion restringida.

        chk_acceso_restringido.Enabled = False
        chk_acceso_restringido.Checked = False

        dg_def_inventarios.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_def_inventarios.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_def_inventarios.AllowUserToAddRows = False
        dg_def_inventarios.AllowUserToDeleteRows = False
        dg_def_inventarios.ReadOnly = False
        dg_def_inventarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        tx_peso_unitario.Text = 1
        tx_peso_bruto.Text = 1
        tx_peso_neto.Text = 1
        tx_factor_conv_ref_emp_alt.Text = "0"
        cm_oper_fact_conv_alt_ppal.Text = "*"

        csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
            & " from " & database.obtener_esquema & ".tb0005_bodegas" _
            & " where f0005_anulado = 'N'"
        otb_bodegas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = "SELECT *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_id_cia = '" & vg_id_cia & "'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'este combo ayuda a definir las descripciones de los items
        'otb_items2 = otb_items.Copy


        csql = "SELECT f0002_id_unidad_medicion, f0002_unidad_medicion" _
            & " FROM " & database.obtener_esquema & ".tb0002_unidades_medicion" _
            & " where f0002_id_cia = '" & vg_id_cia & "' order by f0002_unidad_medicion"
        Dim otb_unidad_tiempo As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_unidad_medicion
            'Valor que se muestra al usuario
            .DisplayMember = "f0002_unidad_medicion"
            'Valor interno que almacena el objeto
            .ValueMember = "f0002_id_unidad_medicion"
            'Origen de Datos del ComboBox
            .DataSource = otb_unidad_tiempo
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "SELECT f0302_id_tipo_item, f0302_descripcion_tipo_item" _
            & " FROM " & database.obtener_esquema & ".tb0302_tipos_items" _
            & " where f0302_id_cia = '" & vg_id_cia & "'"
        Dim otb_tipo_item As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_tipo_item
            'Valor que se muestra al usuario
            .DisplayMember = "f0302_descripcion_tipo_item"
            'Valor interno que almacena el objeto
            .ValueMember = "f0302_id_tipo_item"
            'Origen de Datos del ComboBox
            .DataSource = otb_tipo_item
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "SELECT f0303_id_linea_item, f0303_descripcion_linea_item" _
            & " FROM " & database.obtener_esquema & ".tb0303_lineas_items" _
            & " where f0303_id_cia = '" & vg_id_cia & "'"
        Dim otb_linea As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_linea
            'Valor que se muestra al usuario
            .DisplayMember = "f0303_descripcion_linea_item"
            'Valor interno que almacena el objeto
            .ValueMember = "f0303_id_linea_item"
            'Origen de Datos del ComboBox
            .DataSource = otb_linea
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        If id_item <> 0 Then
            tx_id_item.Text = id_item
            'cm_descripcion.SelectedValue = id_item
            cargar_informacion_existente()
        End If
    End Sub
    Private Sub cargar_informacion_existente()
        'Identificamos informacion de la estructura seleccionada.
        Dim rowprod As DataRow() = otb_items.Select("f0300_id_item ='" & id_item & "'")
        If rowprod.Length > 0 Then
            vf_elemento_nuevo = "N"
        Else
            vf_elemento_nuevo = "S"
        End If
        For Each orow As DataRow In rowprod
            vf_elemento_nuevo = "N"
            tx_descripcion.Text = orow("f0300_descripcion_item").ToString.Trim
            tx_id_item.Text = orow("f0300_id_item")
            'variable parametro para almacenar notas y archivos
            vf_id_notas_archivos = orow("f0300_id_item")
            'actualizo permisos de botones basicos y calculo cantidad de documentos y notas
            'cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos,
            'vf_elemento_nuevo,
            'vg_usuario_autoriza, Me,
            'vf_id_notas_archivos, vf_otipo_nota)
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
            id_item = orow("f0300_id_item")
            tx_id_item_unificado.Text = orow("f0300_id_item_new").ToString
            acceso_restringido = orow("f0300_ar")
            tx_referencia.Text = orow("f0300_referencia").ToString.Trim
            tx_referencia_empaque.Text = orow("f0300_referencia_empaque")
            tx_codigo_barras.Text = orow("f0300_codigo_barras").ToString.Trim
            tx_ref_emp_alt.Text = orow("f0300_referencia_empaque_alterna").ToString.Trim
            tx_factor_conv_ref_emp_alt.Text = orow("f0300_facto_conv_ref_emp_alterna")
            cm_oper_fact_conv_alt_ppal.Text = orow("f0300_oper_conversion")

            tx_cguno.Text = orow("f0300_codigo_cguno")
            cm_unidad_medicion.SelectedValue = orow("f0300_id_unidad_medicion")
            'tx_cantidad_x_bache.Text = orow("f0300_cantidad_bache_produccion")
            cm_tipo_item.SelectedValue = orow("f0300_id_tipo_item")
            tx_cont_empaque.Text = orow("f0300_contenido_x_empaque")
            cm_linea.SelectedValue = orow("f0300_id_linea")
            tx_observacion.Text = orow("f0300_nota")
            tx_peso_unitario.Text = orow("f0300_peso_unitario")
            tx_peso_neto.Text = orow("f0300_peso_neto")
            tx_peso_bruto.Text = orow("f0300_peso_bruto")
            If orow("f0300_descripcion_usuario") = "S" Then
                chk_descripcion_manual.Checked = True
            Else
                chk_descripcion_manual.Checked = False
            End If
            If orow("f0300_vende") = "S" Then
                chk_venta.Checked = True
            Else
                chk_venta.Checked = False
            End If
            If orow("f0300_pp_programable") = "S" Then
                chk_pp_programable.Checked = True
            Else
                chk_pp_programable.Checked = False
            End If
            If orow("f0300_ar") = "S" Then
                chk_acceso_restringido.Checked = True
            Else
                chk_acceso_restringido.Checked = False
            End If
            If orow("f0300_anulado") = "S" Then
                lb_titulo.Text = lb_titulo.Text & " ANULADO."
                tx_descripcion.BackColor = Color.Red
            Else
                lb_titulo.Text = "Gestion de Items."
                tx_descripcion.BackColor = SystemColors.Window
            End If
        Next
        cargar_dg_inventarios()
        'bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_item, vg_id_cia)
    End Sub
    Private Sub inicilaizar1()
        tx_id_item.Text = ""
        csql = "SELECT *, f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion_larga" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_id_cia = '" & vg_id_cia & "'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'otb_items2 = otb_items.Copy

        tx_descripcion.Text = ""
        'cm_descripcion_edit.Text = ""
        tx_referencia.Text = ""
        tx_referencia_empaque.Text = ""
        tx_codigo_barras.Text = ""
        tx_ref_emp_alt.Text = ""
        tx_factor_conv_ref_emp_alt.Text = "0"
        cm_oper_fact_conv_alt_ppal.Text = "*"
        tx_cguno.Text = ""
        'cm_descripcion.SelectedIndex = -1
        cm_unidad_medicion.SelectedIndex = -1
        cm_tipo_item.SelectedIndex = -1
        tx_cont_empaque.Text = ""
        tx_peso_unitario.Text = 1
        tx_peso_neto.Text = 1
        tx_peso_bruto.Text = 1
        cm_linea.SelectedIndex = -1
        tx_observacion.Text = ""
        chk_venta.Checked = False
        chk_descripcion_manual.Checked = False
        'cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_grabar, "")
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
    End Sub

    Private Sub tx_id_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_id_item.Validating
        If IsNumeric(tx_id_item.Text) = False And tx_id_item.Text <> "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If

        'cm_descripcion.Focus()
        'cm_descripcion.SelectedValue = CInt(tx_id_item.Text)
        id_item = tx_id_item.Text
        inicilaizar1()
        tx_id_item.Text = id_item
        cargar_informacion_existente()
        If tx_descripcion.Text.Trim = "" Then
            tx_id_item.Text = ""
            id_item = 0
            MsgBox("El Item no existe", MsgBoxStyle.Information, "Error")
            vf_elemento_nuevo = "S"
            tx_id_item.Focus()
        Else
            vf_elemento_nuevo = "N"
        End If

        'cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, "S",
        'vg_usuario_autoriza, Me)
    End Sub
    Private Sub tx_descripcion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If tx_descripcion.Text.Trim = "" Then
            Exit Sub
        End If
        If tx_id_item.Text = "" Then
            MsgBox("Item nuevo", MsgBoxStyle.Information, "Nuevo")
            vf_elemento_nuevo = "S"
            inicilaizar1()
        Else
            vf_elemento_nuevo = "N"
            id_item = CInt(tx_id_item.Text)
            cargar_informacion_existente()
            bt_grabar.Enabled = False
            bt_editar.Enabled = True
            'cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_editar, "")

        End If
    End Sub
    Private Sub grabar_nuevo_item()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0300_items" _
                & " (f0300_id_cia, f0300_descripcion_item, f0300_id_unidad_medicion, f0300_id_tipo_item, f0300_contenido_x_empaque," _
                & " f0300_referencia_empaque, f0300_peso_unitario, f0300_peso_neto, f0300_peso_bruto," _
                & " f0300_id_linea, f0300_vende, f0300_pp_programable, f0300_ar," _
                & " f0300_referencia, f0300_codigo_cguno, f0300_nota," _
                & " f0300_codigo_barras, f0300_referencia_empaque_alterna, f0300_facto_conv_ref_emp_alterna," _
                & " f0300_oper_conversion," _
                & " f0300_usuario_modificar, f0300_usuario_crear, f0300_fm, f0300_descripcion_usuario)" _
                & " VALUES" _
                & " (@f0300_id_cia, @f0300_descripcion_item, @f0300_id_unidad_medicion, @f0300_id_tipo_item, @f0300_contenido_x_empaque," _
                & " @f0300_referencia_empaque, @f0300_peso_unitario, @f0300_peso_neto, @f0300_peso_bruto," _
                & " @f0300_id_linea, @f0300_vende, @f0300_pp_programable, @f0300_ar," _
                & " @f0300_referencia, @f0300_codigo_cguno, @f0300_nota," _
                & " @f0300_codigo_barras, @f0300_referencia_empaque_alterna, @f0300_facto_conv_ref_emp_alterna," _
                & " @f0300_oper_conversion," _
                & " @f0300_usuario_modificar, @f0300_usuario_crear, @f0300_fm, @f0300_descripcion_usuario)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_item(ocmd)

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
    Private Sub actualizar_item()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0300_items set "
        csql += "f0300_descripcion_item = @f0300_descripcion_item,"
        csql += "f0300_id_unidad_medicion = @f0300_id_unidad_medicion,"
        csql += "f0300_id_tipo_item = @f0300_id_tipo_item,"
        csql += "f0300_contenido_x_empaque = @f0300_contenido_x_empaque,"
        csql += "f0300_id_linea = @f0300_id_linea,"
        csql += "f0300_referencia = @f0300_referencia,"
        csql += "f0300_referencia_empaque = @f0300_referencia_empaque,"
        csql += "f0300_codigo_barras = @f0300_codigo_barras,"
        csql += "f0300_referencia_empaque_alterna = @f0300_referencia_empaque_alterna,"
        csql += "f0300_facto_conv_ref_emp_alterna = @f0300_facto_conv_ref_emp_alterna,"
        csql += "f0300_oper_conversion = @f0300_oper_conversion,"
        csql += "f0300_peso_unitario = @f0300_peso_unitario,"
        csql += "f0300_peso_neto = @f0300_peso_neto,"
        csql += "f0300_peso_bruto = @f0300_peso_bruto,"
        csql += "f0300_codigo_cguno = @f0300_codigo_cguno,"
        csql += "f0300_nota = @f0300_nota,"
        csql += "f0300_fm = @f0300_fm,"
        csql += "f0300_usuario_modificar = @f0300_usuario_modificar,"
        csql += "f0300_vende = @f0300_vende,"
        csql += "f0300_pp_programable = @f0300_pp_programable,"
        csql += "f0300_ar = @f0300_ar,"
        'csql += "f0300_cantidad_bache_produccion = @f0300_cantidad_bache_produccion,"
        csql += "f0300_descripcion_usuario = @f0300_descripcion_usuario"
        csql += " where f0300_id_item = @f0300_id_item"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_item(ocmd)
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
    Private Sub crear_parametros_item(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        'MsgBox(csql)
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0300_id_item", NpgsqlDbType.Integer).Value = tx_id_item.Text
            'MsgBox("ELEMENTO NUEVO: " & vf_elemento_nuevo & "  " & cm_descripcion.SelectedValue)
        End If
        If chk_descripcion_manual.Checked = True Then
            ocmd.Parameters.Add("@f0300_descripcion_usuario", NpgsqlDbType.Varchar).Value = "S"
        Else
            ocmd.Parameters.Add("@f0300_descripcion_usuario", NpgsqlDbType.Varchar).Value = "N"
        End If
        If chk_venta.Checked = True Then
            ocmd.Parameters.Add("@f0300_vende", NpgsqlDbType.Varchar).Value = "S"
        Else
            ocmd.Parameters.Add("@f0300_vende", NpgsqlDbType.Varchar).Value = "N"
        End If
        If chk_pp_programable.Checked = True Then
            ocmd.Parameters.Add("@f0300_pp_programable", NpgsqlDbType.Varchar).Value = "S"
        Else
            ocmd.Parameters.Add("@f0300_pp_programable", NpgsqlDbType.Varchar).Value = "N"
        End If
        If chk_acceso_restringido.Checked = True Then
            ocmd.Parameters.Add("f0300_ar", NpgsqlDbType.Varchar).Value = "S"
        Else
            ocmd.Parameters.Add("f0300_ar", NpgsqlDbType.Varchar).Value = "N"
        End If
        ocmd.Parameters.Add("@f0300_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0300_descripcion_item", NpgsqlDbType.Varchar).Value = UCase(tx_descripcion.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0300_id_unidad_medicion", NpgsqlDbType.Varchar).Value = cm_unidad_medicion.SelectedValue
        'ocmd.Parameters.Add("@f0300_cantidad_bache_produccion", NpgsqlDbType.Numeric).Value = tx_cantidad_x_bache.Text
        ocmd.Parameters.Add("@f0300_id_tipo_item", NpgsqlDbType.Integer).Value = cm_tipo_item.SelectedValue
        ocmd.Parameters.Add("@f0300_contenido_x_empaque", NpgsqlDbType.Varchar).Value = tx_cont_empaque.Text.ToString.Trim
        ocmd.Parameters.Add("@f0300_id_linea", NpgsqlDbType.Integer).Value = CInt(cm_linea.SelectedValue)
        ocmd.Parameters.Add("@f0300_referencia", NpgsqlDbType.Varchar).Value = UCase(tx_referencia.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0300_referencia_empaque", NpgsqlDbType.Varchar).Value = UCase(tx_referencia_empaque.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0300_codigo_barras", NpgsqlDbType.Varchar).Value = UCase(tx_codigo_barras.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0300_referencia_empaque_alterna", NpgsqlDbType.Varchar).Value = UCase(tx_ref_emp_alt.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0300_facto_conv_ref_emp_alterna", NpgsqlDbType.Numeric).Value = tx_factor_conv_ref_emp_alt.Text.ToString.Trim
        ocmd.Parameters.Add("@f0300_oper_conversion", NpgsqlDbType.Varchar).Value = cm_oper_fact_conv_alt_ppal.Text
        ocmd.Parameters.Add("@f0300_peso_unitario", NpgsqlDbType.Numeric).Value = tx_peso_unitario.Text
        ocmd.Parameters.Add("@f0300_peso_neto", NpgsqlDbType.Numeric).Value = tx_peso_neto.Text
        ocmd.Parameters.Add("@f0300_peso_bruto", NpgsqlDbType.Numeric).Value = tx_peso_bruto.Text
        ocmd.Parameters.Add("@f0300_codigo_cguno", NpgsqlDbType.Varchar).Value = tx_cguno.Text.ToString.Trim
        ocmd.Parameters.Add("@f0300_nota", NpgsqlDbType.Varchar).Value = UCase(tx_observacion.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0300_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0300_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0300_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub

    Private Sub validar_descripcion()
        If tx_descripcion.Text.ToString = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina una descripcion para el Item."
        End If
    End Sub
    Private Sub validar_unidad_med()
        If cm_unidad_medicion.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la unidad de medicion para el Item."
        End If
    End Sub
    Private Sub validar_tipo()
        If cm_tipo_item.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el tipo de Item."
        End If
    End Sub
    Private Sub validar_linea()
        If cm_linea.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la linea del Item."
        End If
    End Sub
    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        'Pregunta si realmente desea reportar
        If cerrar_al_actualizar = "N" Then
            Dim respuesta As String = "N"
            respuesta = comunes.g_mensaje_YesNo("Grabar Item", "Desea grabar los cambios?")
            If respuesta = "N" Then
                Exit Sub
            End If
        End If
        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        'autoriza = "N"
        'Dim oform_login As New camocontrol.login
        'oform_grilla_programacion.ods_hijo = ods
        'oform_login.vf_oform_padre = Me
        'oform_login.paso_autorizacion = "S"
        'oform_login.ShowDialog()

        'If autoriza = "N" Then
        'Exit Sub
        'End If

        verror_requisitos = "N"
        validar_descripcion()
        validar_unidad_med()
        validar_tipo()
        validar_linea()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            grabar_nuevo_item()
        Else
            actualizar_item()
            If verror = "N" Then
                'MsgBox("El Item fue actualizado", MsgBoxStyle.Information, "Grabar")
            End If
            'Dispose()
            'Exit Sub
        End If
        If verror = "N" Then
            If cerrar_al_actualizar = "S" Then
                Me.Dispose()
                Exit Sub
            End If
            MsgBox("El Item fue grabado", MsgBoxStyle.Information, "Grabar")
            'Dispose()
            inicilaizar1()
        End If
    End Sub

    Private Sub bt_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nuevo.Click
        vf_elemento_nuevo = "S"
        inicilaizar1()
    End Sub

    'Private Sub bt_editar_Click(sender As Object, e As EventArgs) Handles bt_editar.Click
    'bt_grabar.Enabled = True
    'End Sub

    'Private Sub bt_g_notas_Click(sender As Object, e As EventArgs) Handles bt_g_notas.Click
    'If id_item <> 0 And id_item.ToString <> "" Then
    'cl_gestion_anotaciones.consultar_anotaciones_acciones(id_item, otipo_nota, vg_usuario_autoriza, vg_id_cia, "ST-0606-05", "2")
    'bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_item, vg_id_cia)
    'Else
    ' MsgBox("No ha definido un Item", MsgBoxStyle.Information, "Info")
    'End If
    'End Sub

    Private Sub bt_explosion_materiales_Click(sender As Object, e As EventArgs) Handles bt_explosion_materiales.Click
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If
        'verifico si el item es de acceso restringido para validar permisos
        If acceso_restringido = "S" Then
            'Si el item es de acceso restringido y no tengo permiso entonces no permito ingresar.
            Dim tiene_permiso As String = "N"
            tiene_permiso = cl_gestion_permisos.identificar_permisos_especiales_formularios("300_ACCESO_FORMULAS_RESTRINGIDAS",
                                                                                            vf_otabla_permisos, vg_usuario_autoriza)
            If tiene_permiso = "N" Then
                MsgBox("Error en procesamiento de informacion form.")
                Exit Sub
            End If
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_0300_formulacion_menu
        oform_mostrar_datos.vf_oform_padre = Me
        'definimos el contexto para habilitar el boton nuevo
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.id_item = id_item
        oform_mostrar_datos.ShowDialog()
    End Sub

    Private Sub tx_peso_unitario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_peso_unitario.KeyPress
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

    Private Sub tx_peso_unitario_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_peso_unitario.Validating
        If tx_peso_unitario.Text.Trim = "" Then
            tx_peso_unitario.Text = 1
        End If
        tx_peso_unitario.Text = CDec(tx_peso_unitario.Text)
    End Sub

    Private Sub tx_peso_bruto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_peso_bruto.KeyPress
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

    Private Sub tx_peso_bruto_Validating(sender As Object, e As CancelEventArgs) Handles tx_peso_bruto.Validating
        If tx_peso_bruto.Text.Trim = "" Then
            tx_peso_bruto.Text = 1
        End If
        tx_peso_bruto.Text = CDec(tx_peso_bruto.Text)
    End Sub

    Private Sub tx_peso_neto_Validating(sender As Object, e As CancelEventArgs) Handles tx_peso_neto.Validating
        If tx_peso_neto.Text.Trim = "" Then
            tx_peso_neto.Text = 1
        End If
        tx_peso_neto.Text = CDec(tx_peso_neto.Text)
    End Sub

    Private Sub tx_peso_neto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_peso_neto.KeyPress
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
    Private Sub tx_factor_conv_ref_emp_alt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_factor_conv_ref_emp_alt.KeyPress
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

    Private Sub tx_factor_conv_ref_emp_alt_Validating(sender As Object, e As CancelEventArgs) Handles tx_factor_conv_ref_emp_alt.Validating
        If tx_factor_conv_ref_emp_alt.Text.Trim = "" Then
            tx_factor_conv_ref_emp_alt.Text = 0
        End If
        tx_factor_conv_ref_emp_alt.Text = CDec(tx_factor_conv_ref_emp_alt.Text)
    End Sub

    Private Sub cm_oper_fact_conv_alt_ppal_Validating(sender As Object, e As CancelEventArgs) Handles cm_oper_fact_conv_alt_ppal.Validating
        If cm_oper_fact_conv_alt_ppal.SelectedIndex = -1 Then
            cm_oper_fact_conv_alt_ppal.Text = "*"
        End If
    End Sub

    Private Sub bt_acceso_restringido_Click(sender As Object, e As EventArgs) Handles bt_acceso_restringido.Click
        'Pregunta si realmente desea restringir acceso
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Mod Bloq", "Desea modificar el Bloqueo Acceso?")
        If respuesta = "N" Then
            Exit Sub
        End If
        If chk_acceso_restringido.Checked = True Then
            chk_acceso_restringido.Checked = False
        Else
            chk_acceso_restringido.Checked = True
            'los items con acceso restringido no pueden ser programables.
            'chk_pp_programable.Enabled = False
            'chk_pp_programable.Checked = False
        End If
    End Sub
    Private Sub cargar_dg_inventarios()
        'dg_def_inventarios.Rows.Clear()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-24", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_item)
        otb_puntos_control_inventario = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_def_inventarios.DataSource = otb_puntos_control_inventario
        If dg_def_inventarios.Rows.Count > 0 Then
            tx_id_criterio.Text = dg_def_inventarios.CurrentRow.Cells("id").Value
        Else
            tx_id_criterio.Text = ""
        End If
    End Sub
    Private Sub validar_no_repeticion_de_bodega(ByVal id_bodega As String)
        cargar_dg_inventarios()
        Dim orows_bodega As DataRow()
        orows_bodega = otb_puntos_control_inventario.Select("id_bodega = '" & id_bodega & "'")
        If orows_bodega.Length <> 0 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Esta bodega ya tiene un criterio de control asociado"
        End If
    End Sub
    Private Sub dg_def_inventarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_def_inventarios.CellClick
        If dg_def_inventarios.Rows.Count = 0 Then
            Exit Sub
        End If
        tx_id_criterio.Text = dg_def_inventarios.CurrentRow.Cells("id").Value
    End Sub

    Private Sub bt_editar_criterio_Click(sender As Object, e As EventArgs) Handles bt_editar_criterio.Click
        If tx_id_criterio.Text = "" Then
            Exit Sub
        End If
        'Pregunta si realmente desea editar un criterio
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Editar Criterio", "Desea Editar el Criterio " & tx_id_criterio.Text & " ?")
        If respuesta = "N" Then
            Exit Sub
        End If
        criterio_ubicacion = dg_def_inventarios.CurrentRow.Cells("ubicacion").Value
        verror = "N"
        criterio_ubicacion = comunes.formulario_parametro_texto(criterio_ubicacion, "La ubicacion del item es:")
        If criterio_ubicacion = "" Then
            Exit Sub
        End If
        If verror = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        actualizar_criterio()
        If verror = "N" Then
            cargar_dg_inventarios()
            MsgBox("Criterio Actualizado", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub actualizar_criterio()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0301_items_inventario_x_bodega set "
        csql += "f0301_ubicacion = @f0301_ubicacion,"
        csql += "f0301_fm = @f0301_fm,"
        csql += "f0301_usuario_modificar = @f0301_usuario_modificar"
        csql += " where f0301_id_bodega = @f0301_id_bodega"
        csql += " and f0301_id_item = @f0301_id_item"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_facturas(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0301_id_bodega", NpgsqlDbType.Integer).Value = tx_id_criterio.Text
        ocmd.Parameters.Add("@f0301_id_item", NpgsqlDbType.Integer).Value = tx_id_item.Text
        ocmd.Parameters.Add("@f0301_ubicacion", NpgsqlDbType.Varchar).Value = criterio_ubicacion
        ocmd.Parameters.Add("@f0301_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0301_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
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
    End Sub
    Private Sub anular_criterio()
        Exit Sub ' no es logico anular debido a que se actualiza desde la consulta de inventarios

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0301_items_inventario_x_bodega set "
        csql += "f0301_anulado = 'S',"
        csql += "f0301_usuario_anular =  @f0301_usuario_modificar,"
        csql += "f0301_fm = @f0301_fm,"
        csql += "f0301_usuario_modificar = @f0301_usuario_modificar"
        csql += " where f0301_id_def_inv = @f0301_id_def_inv"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_facturas(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0301_id_def_inv", NpgsqlDbType.Integer).Value = tx_id_criterio.Text
        ocmd.Parameters.Add("@f0301_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0301_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
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
    End Sub

    Private Sub bt_costos_Click(sender As Object, e As EventArgs) Handles bt_costos.Click
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_costos As New camocontrol.fm_0300_gestion_items_costos
        oform_costos.vf_oform_padre = Me
        'definimos el contexto para habilitar el boton nuevo
        oform_costos.vg_id_cia = vg_id_cia
        oform_costos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_costos.id_item = id_item
        oform_costos.vf_id_notas_archivos = id_item
        oform_costos.vf_elemento_nuevo = "N"
        oform_costos.ShowDialog()
    End Sub

    Private Sub bt_unificar_Click(sender As Object, e As EventArgs) Handles bt_unificar.Click
        If tx_id_item.Text.Trim = "" Then
            Exit Sub
        End If

        csql = "select f0350_id_item from " & database.obtener_esquema & ".tb0350_plantillas"
        csql += " where f0350_id_item = '" & tx_id_item.Text.Trim & "'"
        Dim otb As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        If otb.Rows.Count > 0 Then
            MsgBox("Este item tiene formulaciones y no puede unificarse a otro item", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_unificar As New camocontrol.fm_0300_unificar_items
        oform_unificar.vf_oform_padre = Me
        'definimos el contexto para habilitar el boton nuevo
        oform_unificar.vg_id_cia = vg_id_cia
        oform_unificar.vg_usuario_autoriza = vg_usuario_autoriza
        oform_unificar.id_item = id_item
        oform_unificar.Label5.Text = tx_id_item.Text & ": " & tx_descripcion.Text
        oform_unificar.vf_elemento_nuevo = "N"
        oform_unificar.ShowDialog()
        Dispose()
    End Sub

    Private Sub bt_ajuste_inventario_Click(sender As Object, e As EventArgs) Handles bt_ajuste_inventario.Click
        If tx_id_item.Text = "" Then
            Exit Sub
        End If
        'Pregunta si realmente desea editar un criterio
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Ajuste de Inventario", "Desea realizar un Ajuste de Inventario?")
        If respuesta = "N" Then
            Exit Sub
        End If
        Dim obodega As Integer
        If tx_id_criterio.Text <> "" Then
            obodega = tx_id_criterio.Text
        Else
            obodega = 1
        End If
        Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(3, vg_id_cia)
        Dim cod_documento As String = "AJU-" & consecutivo.ToString.PadLeft(8, "0")
        cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, obodega, 3, comunes.g_fechahora, vg_usuario_autoriza, vg_id_cia)
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(cod_documento, vg_usuario_autoriza, vg_id_cia, "S", "N", "D", "S", "S", "S", "S", "N")
        cargar_dg_inventarios()
    End Sub

    Private Sub bt_movimientos_item_Click(sender As Object, e As EventArgs) Handles bt_movimientos_item.Click
        If tx_id_criterio.Text = "" Then
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-13", vg_id_cia, vg_id_cia, "Bodega", {vg_id_cia, tx_id_item.Text, tx_id_criterio.Text})
        cargar_dg_inventarios()
    End Sub
    Private Sub ejecutar_modo_busqueda_item()
        Dim otb_items_selected As DataTable = Nothing
        Dim otb_tablas_array() As DataTable = Nothing
        otb_tablas_array = cl_utilidades_datatables.visualizar_datos_visor("ST-0300-34", vg_id_cia, vg_usuario_autoriza,
                                                        "Listado de Items",
                                                        {vg_id_cia},
                                                            , "Items",,, "S", "id_item",, "S", "N")

        If IsNothing(otb_tablas_array(2)) = False Then
            otb_items_selected = otb_tablas_array(2)
        Else
            Exit Sub
        End If
        'agrego el tercero seleccionado
        For Each orow As DataRow In otb_items_selected.Rows
            'Actualizo el item
            'MsgBox(orow("id_sc_item"))
            tx_id_item.Text = orow("id_item")
            id_item = orow("id_item")
            tx_id_item.Focus()
        Next
    End Sub

    Private Sub fm_0300_gestion_items_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F2) Then
            ejecutar_modo_busqueda_item()
            cargar_informacion_existente()
        End If
    End Sub

End Class
