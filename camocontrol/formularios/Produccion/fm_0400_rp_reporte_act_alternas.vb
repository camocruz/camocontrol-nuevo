Public Class fm_0400_rp_reporte_act_alternas
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_prog_prod As Integer
    Public id_rp As Integer
    Public id_ipp As Integer
    Public tree_path As String = ""
    Public id_item As Integer
    Public id_estructura As Integer = 0
    Public otb_items_programa_produccion As DataTable

    'Private otipo_nota As String

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private orowgrid As DataGridViewRow
    Private ocmb_grid As DataGridViewComboBoxCell
    Private otextgrid As DataGridViewTextBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell
    Private obuttongrid As DataGridViewButtonCell
    Private olinkcell As DataGridViewLinkCell

    Private dg_row_id_personal_rp As Integer = 0
    Private dg_row_id_tercero As String
    Private dg_row_horas As Decimal
    Private dg_row_nota As String = ""

    Private estado_rp As String = "C" 'A = abierto  C = cerrado  B = cerrado por administrador sin cumplir requisitos
    Private descripcion_producto As String = ""
    Private verror As String = "S"
    Private vexiste As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private item_restringido As String = "S"
    Private usuario_con_acceso_total As String = "N"
    Private t_improd_total As Decimal = 0 'Tiempo improductivo total
    Private tot_produccion As Decimal = 0 'Produccion total
    Private ind_productividad As Decimal = 0 'Indice de productividad
    Private recorte_consumido As Decimal = 0
    Private recorte_generado As Decimal = 0

    Private otb_items As DataTable
    Private otb_reporte_produccion As DataTable
    Private otb_doc_mov_invent_relacionados As DataTable
    Private otb_info_personal As DataTable
    Private otb_personal_grillas As DataTable
    Private otb_personal_rp As DataTable 'es la datatable con los registros actuales relacionados en el rp
    Private otb_indicadores_productivos As DataTable

    Private Sub fm_0400_rp_reporte_act_alternas_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-RPD"
        vf_var_config_notas = "TN-RPD-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
        vf_id_notas_archivos = id_rp
        'identifico informacion del item del programa de produccion
        'Dim dataviewprogprod As New DataView
        'Dim filtro_plantilla As String = "f0401_id_ipp = '" & id_ipp & "'"
        'dataviewprogprod = New DataView(otb_items_programa_produccion, filtro_plantilla, "", DataViewRowState.CurrentRows)
        'MsgBox(otb_items_programa_produccion.Rows.Count)
        'MsgBox(dataviewprogprod.Count)
        'For Each orowprogprod As DataRowView In dataviewprogprod
        'id_item = orowprogprod("f0401_id_item")
        'MsgBox(id_item)
        'Next

        'bt_grabar.Enabled = False

        dg_personal.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_personal.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_personal.AllowUserToAddRows = True
        dg_personal.AllowUserToDeleteRows = True
        otb_info_personal = comunes.suministrar_otb_info_personal(vg_id_cia, "S")
        otb_personal_grillas = otb_info_personal.Copy
        With dgocell_id_tercero
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_personal_grillas
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        End With


        ' Set the Format type and the CustomFormat string.
        dtp_fecha.Format = DateTimePickerFormat.Custom
        dtp_fecha.CustomFormat = "yyyy/MM/dd  HH:mm"


        tx_horas_hombre.Text = 1000
        tx_horas_hombre.ReadOnly = True
        'tx_recorte_consumido.Text = 0
        'tx_recorte_generado.Text = 0

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0005_bodegas"
        Dim otb_bodega_consumos As DataTable
        otb_bodega_consumos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_bodegas
            'Valor que se muestra al usuario
            .DisplayMember = "f0005_descripcion_bodega"
            'Valor interno que almacena el objeto
            .ValueMember = "f0005_id_bodega"
            'Origen de Datos del ComboBox
            .DataSource = otb_bodega_consumos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0404_actividades_alternas_produccion"
        Dim otb_act_alternas As DataTable
        otb_act_alternas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_actividad_alterna
            'Valor que se muestra al usuario
            .DisplayMember = "f0404_act_alterna"
            'Valor interno que almacena el objeto
            .ValueMember = "f0404_id_act_alterna"
            'Origen de Datos del ComboBox
            .DataSource = otb_act_alternas
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        'identifico el tipo de nota
        'otipo_nota = comunes.suministrar_valor_variable_configuracion("TN-RPD-001", vg_id_cia)

        If vf_elemento_nuevo = "N" Then
            tx_id_rp.Text = id_rp
            cargar_info_rp()
            If estado_rp = "C" Or estado_rp = "B" Then
                bloquear_edicion()
            End If
        Else
            bt_grabar.Enabled = True
        End If

    End Sub

    Private Sub cargar_info_rp()
        csql = "select *" _
                    & " FROM " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                    & " where f0402_id_cia = '" & vg_id_cia & "' and f0402_id_rp = '" & id_rp & "'"
        otb_reporte_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_reporte_produccion.Rows
            'id_item = orow("f0402_id_item")
            id_rp = orow("f0402_id_rp")
            id_ipp = orow("f0402_id_ipp")
            id_item = orow("f0402_id_item")
            id_estructura = orow("f0402_id_maquina")
            'tx_estructura.Text = comunes.traer_nombre_estructura(orow("f0402_id_maquina").ToString)
            'lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_rp, vg_id_cia)
            vf_id_notas_archivos = orow("f0402_id_rp")
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
            tx_id_rp.Text = orow("f0402_id_rp")
            dtp_fecha.Value = orow("f0402_fecha_produccion")
            'dtp_fecha_vencimiento.Value = orow("f0402_fecha_vence")
            'tx_lote.Text = orow("f0402_lote")
            estado_rp = orow("f0402_estado")
            'If orow("f0402_estado") = "A" Then
            'tx_estado.Text = "ABIERTO"
            ' Else
            'tx_estado.Text = "CERRADO"
            'End If
            Select Case orow("f0402_estado")
                Case "A"
                    tx_estado.Text = "ABIERTO"
                Case "B"
                    tx_estado.Text = "CERRADO ADMIN"
                Case "C"
                    tx_estado.Text = "CERRADO"
            End Select
            tx_turno.Text = orow("f0402_turno")
            'tx_cant_produccion.Text = orow("f0402_cantidad_producida")
            'tx_tiempo_produccion.Text = orow("f0402_tiempo_produccion")
            tx_horas_hombre.Text = orow("f0402_horas_hombre")
            tx_clasificador.Text = orow("f0402_clasificador")
            'tx_recorte_consumido.Text = orow("f0402_recorte_usado")
            'tx_recorte_generado.Text = orow("f0402_recorte_mt_producido")

            'cargo el personal relacionado
            cargar_funcionarios_rp()

            If orow("f0402_id_bodega_consumo_insumos") <> 0 Then
                cm_bodegas.SelectedValue = orow("f0402_id_bodega_consumo_insumos")
                cm_bodegas.Enabled = False
            End If
            'calculo indicadores productivos
            'calcular_indicadores_productivos()
            cargar_documentos_mov_inventario_relacionados()
        Next
    End Sub
    Private Sub cargar_documentos_mov_inventario_relacionados()
        csql = "select * from " & database.obtener_esquema & ".tb0309_items_movimientos" _
               & " join " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                 & " on f0309_id_documento = f0310_id_documento" _
            & " where f0309_id_cia = '" & vg_id_cia & "'" & " and" _
               & " f0310_id_documento_origen = 'RP-" & id_rp.ToString & "'" _
               & " and f0309_anulado = 'N'"
        'Clipboard.SetDataObject(csql)
        'MsgBox(csql)
        otb_doc_mov_invent_relacionados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        identificar_label_doc_creados()
    End Sub
    Private Function suministrar_documento_mov_invent_relacionado(ByVal tipo As Integer)
        Dim id_documento As String = ""
        Dim orow As DataRow()
        cargar_documentos_mov_inventario_relacionados()
        orow = otb_doc_mov_invent_relacionados.Select("f0310_id_tipo_documento = '" & tipo & "'")
        For Each orow2 As DataRow In orow
            id_documento = orow2("f0310_id_documento")
        Next
        Return id_documento
    End Function
    Private Sub identificar_label_doc_creados()
        lb_cons_irreg.Text = "ND"
        Dim exist As String = "N"
        For Each orow As DataRow In otb_doc_mov_invent_relacionados.Rows
            If orow("f0310_id_tipo_documento") = 7 Then
                lb_cons_irreg.Text = orow("f0310_id_documento")
                exist = "S"
            End If
        Next
        If exist = "N" Then
            cm_bodegas.Enabled = True
        End If
    End Sub
    Private Sub bloquear_edicion()
        bt_cerrar_rp.Enabled = False
        bt_grabar.Enabled = False
        bt_editar.Enabled = False
        'bt_t_improductivo.Enabled = False
        bt_grabar_personal.Enabled = False
        'bt_anular.Enabled = False
    End Sub
    Private Sub validar_turno()
        If tx_turno.Text.Trim = "" Then
            vmensaje_requisitos = "Registre el Turno"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_turno()
        validar_horas_hombre()
        validar_actividad_alterna()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            nuevo_rp()
            If verror = "N" Then
                id_rp = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0402_id_rp", "f0402_usuario_crear", vg_usuario_autoriza, "tb0402_reporte_produccion")
                cargar_info_rp()
                'vf_oform_padre.name_nodo_creado = "RP-" & tx_id_rp.Text
                vf_elemento_nuevo = "N"
                MsgBox("Registro Grabado", MsgBoxStyle.Information, "Info")
            End If
        Else
            editar_rp()
            If verror = "N" Then
                'calculo indicadores productivos
                MsgBox("Registro Grabado", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub
    Private Sub nuevo_rp()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                & " (f0402_id_cia, f0402_fecha_produccion, f0402_turno, f0402_tipo_registro," _
                & " f0402_id_act_alterna, f0402_fecha_vence," _
                & " f0402_clasificador, f0402_id_prog_prod, f0402_id_ipp, f0402_id_item," _
                & " f0402_horas_hombre, f0402_tree_path, f0402_ampliacion," _
                & " f0402_usuario_modificar, f0402_usuario_crear, f0402_fm)" _
                & " VALUES" _
                & " (@f0402_id_cia, @f0402_fecha_produccion, @f0402_turno, @f0402_tipo_registro," _
                & " @f0402_id_act_alterna, @f0402_fecha_vence," _
                & " @f0402_clasificador, @f0402_id_prog_prod, @f0402_id_ipp, @f0402_id_item," _
                & " @f0402_horas_hombre, @f0402_tree_path, @f0402_ampliacion," _
                & " @f0402_usuario_modificar, @f0402_usuario_crear, @f0402_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_tipo_registro", NpgsqlDbType.Integer).Value = 2 '1 = rp, 2= actividad alterna
        ocmd.Parameters.Add("@f0402_id_prog_prod", NpgsqlDbType.Integer).Value = 0
        ocmd.Parameters.Add("@f0402_id_ipp", NpgsqlDbType.Integer).Value = 0
        ocmd.Parameters.Add("@f0402_id_item", NpgsqlDbType.Integer).Value = 0
        ocmd.Parameters.Add("@f0402_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0402_id_act_alterna", NpgsqlDbType.Integer).Value = cm_actividad_alterna.SelectedValue

        ocmd.Parameters.Add("@f0402_ampliacion", NpgsqlDbType.Varchar).Value = tx_ampliacion.Text.Trim
        ocmd.Parameters.Add("@f0402_fecha_vence", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value

        'ocmd.Parameters.Add("@f0402_cantidad_producida", NpgsqlDbType.Numeric).Value = tx_cant_produccion.Text
        'ocmd.Parameters.Add("@f0402_tiempo_produccion", NpgsqlDbType.Numeric).Value = tx_tiempo_produccion.Text
        ocmd.Parameters.Add("@f0402_horas_hombre", NpgsqlDbType.Numeric).Value = tx_horas_hombre.Text
        ocmd.Parameters.Add("@f0402_tree_path", NpgsqlDbType.Varchar).Value = tree_path
        ocmd.Parameters.Add("@f0402_fecha_produccion", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value
        'ocmd.Parameters.Add("@f0402_recorte_usado", NpgsqlDbType.Numeric).Value = tx_recorte_consumido.Text
        'ocmd.Parameters.Add("@f0402_recorte_mt_producido", NpgsqlDbType.Numeric).Value = tx_recorte_generado.Text
        'ocmd.Parameters.Add("@f0402_recorte_me_producido", NpgsqlDbType.Numeric).Value = tx_recorte_me_producido.Text
        ocmd.Parameters.Add("@f0402_turno", NpgsqlDbType.Varchar).Value = tx_turno.Text
        ocmd.Parameters.Add("f0402_clasificador", NpgsqlDbType.Varchar).Value = tx_clasificador.Text.ToString
        'ocmd.Parameters.Add("@f0402_id_maquina", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act

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

    Private Sub editar_rp()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set "
        csql += "f0402_cantidad_producida = @f0402_cantidad_producida,"
        csql += "f0402_tiempo_produccion = @f0402_tiempo_produccion,"
        csql += "f0402_horas_hombre = @f0402_horas_hombre,"
        csql += "f0402_fecha_produccion = @f0402_fecha_produccion,"
        csql += "f0402_fecha_vence = @f0402_fecha_vence,"
        csql += "f0402_lote = @f0402_lote,"
        'csql += "f0402_recorte_usado = @f0402_recorte_usado,"
        'csql += "f0402_recorte_mt_producido = @f0402_recorte_mt_producido,"
        csql += "f0402_turno = @f0402_turno,"
        csql += "f0402_clasificador = @f0402_clasificador,"
        csql += "f0402_id_maquina = @f0402_id_maquina,"
        csql += "f0402_usuario_modificar = @f0402_usuario_modificar,"
        csql += "f0402_fm = @f0402_fm"
        csql += " where f0402_id_rp = @f0402_id_rp"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = tx_id_rp.Text
        'ocmd.Parameters.Add("@f0402_cantidad_producida", NpgsqlDbType.Numeric).Value = tx_cant_produccion.Text
        'ocmd.Parameters.Add("@f0402_tiempo_produccion", NpgsqlDbType.Numeric).Value = tx_tiempo_produccion.Text
        ocmd.Parameters.Add("@f0402_horas_hombre", NpgsqlDbType.Numeric).Value = tx_horas_hombre.Text
        ocmd.Parameters.Add("@f0402_fecha_produccion", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value
        'ocmd.Parameters.Add("@f0402_fecha_vence", NpgsqlDbType.Timestamp).Value = dtp_fecha_vencimiento.Value
        'ocmd.Parameters.Add("@f0402_lote", NpgsqlDbType.Varchar).Value = tx_lote.Text
        'ocmd.Parameters.Add("@f0402_recorte_usado", NpgsqlDbType.Numeric).Value = tx_recorte_consumido.Text
        'ocmd.Parameters.Add("@f0402_recorte_mt_producido", NpgsqlDbType.Numeric).Value = tx_recorte_generado.Text
        'ocmd.Parameters.Add("@f0402_recorte_me_producido", NpgsqlDbType.Numeric).Value = tx_recorte_me_producido.Text
        ocmd.Parameters.Add("@f0402_turno", NpgsqlDbType.Varchar).Value = tx_turno.Text
        ocmd.Parameters.Add("@f0402_clasificador", NpgsqlDbType.Varchar).Value = tx_clasificador.Text.ToString
        ocmd.Parameters.Add("@f0402_id_maquina", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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

    Private Sub actualizar_bodega_consumo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set "
        csql += "f0402_id_bodega_consumo_insumos = @f0402_id_bodega_consumo_insumos,"
        csql += "f0402_usuario_modificar = @f0402_usuario_modificar,"
        csql += "f0402_fm = @f0402_fm"
        csql += " where f0402_id_rp = @f0402_id_rp"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = tx_id_rp.Text
        ocmd.Parameters.Add("@f0402_id_bodega_consumo_insumos", NpgsqlDbType.Numeric).Value = cm_bodegas.SelectedValue
        ocmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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


    Private Sub bt_cerrar_rp_Click(sender As Object, e As EventArgs) Handles bt_cerrar_rp.Click
        If id_rp = 0 Then
            Exit Sub
        End If
        'pregunta si desea cerrar el reporte
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Cerrar Reporte", "Desea CERRAR este Reporte?")
        If respuesta = "N" Then
            Exit Sub
        End If
        verror_requisitos = "N"
        'validar_descargue_insumos()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            If vg_usuario_autoriza = "00000001" Then
                respuesta = comunes.g_mensaje_YesNo("Cerrar Reporte", "Desea CERRAR este Reporte sin cumplir con los requisitos establecidos?")
                If respuesta = "N" Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set "
        csql += "f0402_estado = @f0402_estado,"
        csql += "f0402_usuario_modificar = @f0402_usuario_modificar,"
        csql += "f0402_fm = @f0402_fm"
        csql += " where f0402_id_rp = @f0402_id_rp"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = tx_id_rp.Text
        If vg_usuario_autoriza = "00000001" Then
            'Cuando se va a cerrar un reporte sin importar la informacion que contenga.
            ocmd.Parameters.Add("@f0402_estado", NpgsqlDbType.Varchar).Value = "B"
        Else
            ocmd.Parameters.Add("@f0402_estado", NpgsqlDbType.Varchar).Value = "C"
        End If

        ocmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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

        tx_estado.Text = "CERRADO"
        bloquear_edicion()
    End Sub

    Private Sub anular_rp()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set "
        csql += "f0402_anulado = @f0402_anulado,"
        csql += "f0402_usuario_anular = @f0402_usuario_anular,"
        csql += "f0402_usuario_modificar = @f0402_usuario_modificar,"
        csql += "f0402_fm = @f0402_fm"
        csql += " where f0402_id_rp = @f0402_id_rp"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = tx_id_rp.Text
        ocmd.Parameters.Add("@f0402_anulado", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0402_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        If id_rp = 0 Then
            Exit Sub
        End If
        'Pregunta si realmente desea ANULAR documento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Documento", "Desea ANULAR este documento?")
        If respuesta = "N" Then
            Exit Sub
        End If
        'Verificamos que no existan documentos de movimiento de inventario.
        csql = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
            & " where f0310_id_documento_origen = '" & "RP-" & id_rp.ToString & "' and f0310_anulado = 'N'"
        Dim otb_documentos_inventario As DataTable
        otb_documentos_inventario = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim doc_inventario As String = "N"
        Dim otexto_doc_inventario As String = ""
        For Each orow As DataRow In otb_documentos_inventario.Rows
            doc_inventario = "S"
            otexto_doc_inventario += orow("f0310_id_documento") & vbCrLf
        Next
        If doc_inventario = "S" Then
            MsgBox("Cambio no realizado debido a que el reporte tiene documentos de movimiento de inventario:" _
                   & vbCrLf & otexto_doc_inventario, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'Dim anulado As String = "N"
        'MsgBox("aqui")
        'anulado = cl_utilidades_gestion_compras.anular_documento("CPR-" & id_rp.ToString.PadLeft(8, "0"), vg_usuario_autoriza, vg_id_cia)
        'If anulado = "N" Then
        'Exit Sub
        'End If

        'Anulo el reporte
        anular_rp()
        If verror = "N" Then
            MsgBox("Documento Anulado", MsgBoxStyle.Information, "Info")
            Dispose()
        End If
    End Sub

    Private Sub bt_editar_Click(sender As Object, e As EventArgs) Handles bt_editar.Click
        bt_grabar.Enabled = True
    End Sub

    Private Sub validar_reapertura_por_administrador()
        If estado_rp = "B" Then
            If vg_usuario_autoriza <> "00000001" Then
                vmensaje_requisitos = "Este reporte fue cerrado por el administrador y solo puede reabrirse por el."
                verror_requisitos = "S"
            End If
        End If
    End Sub
    Private Sub bt_abrir_reporte_Click(sender As Object, e As EventArgs) Handles bt_abrir_reporte.Click
        If id_rp = 0 Then
            Exit Sub
        End If
        'pregunta si desea cerrar el reporte
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Abrir Reporte", "Desea REABRIR este Reporte?")
        If respuesta = "N" Then
            Exit Sub
        End If
        verror_requisitos = "N"
        validar_reapertura_por_administrador()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set "
        csql += "f0402_estado = @f0402_estado,"
        csql += "f0402_usuario_modificar = @f0402_usuario_modificar,"
        csql += "f0402_fm = @f0402_fm"
        csql += " where f0402_id_rp = @f0402_id_rp"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = tx_id_rp.Text
        ocmd.Parameters.Add("@f0402_estado", NpgsqlDbType.Varchar).Value = "A"
        ocmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act
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

        tx_estado.Text = "ABIERTO"
    End Sub

    Private Sub cargar_funcionarios_rp()
        dg_personal.Rows.Clear()
        csql = "select * from " & database.obtener_esquema & ".tb0403_personal_rp" _
                        & " where f0403_id_rp = '" & id_rp & "'" _
                        & " and f0403_anulado = 'N'" _
                        & " order by f0403_id_personal_rp"
        otb_personal_rp = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_personal_rp.Rows
            agregar_fila_personal(orow)
        Next
    End Sub
    Private Sub agregar_fila_personal(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1 -- esta oculta
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0403_id_personal_rp").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        ocmb_grid = New DataGridViewComboBoxCell
        ocmb_grid.Value = orow.Item("f0403_id_tercero").ToString
        With ocmb_grid
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_personal_grillas
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        End With
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ocmb_grid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0403_horas").ToString
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0403_nota").ToString
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_personal.Rows.Add(orowgrid)
    End Sub
    Private Sub grabar_personal()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0403_personal_rp" _
                & " (f0403_id_cia, f0403_id_rp, f0403_id_tercero," _
                & " f0403_horas, f0403_nota," _
                & " f0403_usuario_crear, f0403_usuario_modificar, f0403_fm)" _
                & " VALUES" _
                & " (@f0403_id_cia, @f0403_id_rp, @f0403_id_tercero," _
                & " @f0403_horas, @f0403_nota," _
                & " @f0403_usuario_crear, @f0403_usuario_modificar, @f0403_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_personal(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0403_id_rp", NpgsqlDbType.Integer).Value = id_rp
        ocmd.Parameters.Add("@f0403_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0403_id_tercero", NpgsqlDbType.Varchar).Value = dg_row_id_tercero
        ocmd.Parameters.Add("@f0403_horas", NpgsqlDbType.Numeric).Value = dg_row_horas
        ocmd.Parameters.Add("@f0403_nota", NpgsqlDbType.Varchar).Value = dg_row_nota
        ocmd.Parameters.Add("@f0403_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0403_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0403_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando personal! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar personal! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_personal(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0403_id_personal_rp", NpgsqlDbType.Integer).Value = dg_row_id_personal_rp
        ocmd.Parameters.Add("@f0403_id_rp", NpgsqlDbType.Integer).Value = id_rp
        ocmd.Parameters.Add("@f0403_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0403_id_tercero", NpgsqlDbType.Varchar).Value = dg_row_id_tercero
        ocmd.Parameters.Add("@f0403_horas", NpgsqlDbType.Numeric).Value = dg_row_horas
        ocmd.Parameters.Add("@f0403_nota", NpgsqlDbType.Varchar).Value = dg_row_nota
        ocmd.Parameters.Add("@f0403_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0403_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0403_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub grabar_cambios_personal()
        'actualizo los registros existentes que coincidan en la tabla y la grilla
        For Each orow As DataGridViewRow In dg_personal.Rows
            If orow.IsNewRow = False Then
                If orow.Cells("dgocell_id_personal_rp").Value = "" Then
                    dg_row_id_personal_rp = 0
                Else
                    dg_row_id_personal_rp = orow.Cells("dgocell_id_personal_rp").Value
                End If
                dg_row_id_tercero = orow.Cells("dgocell_id_tercero").Value
                dg_row_horas = orow.Cells("dgocell_tiempo_lab").Value
                If IsNothing(orow.Cells("dgocell_nota").Value) = True Then
                    dg_row_nota = ""
                Else
                    dg_row_nota = orow.Cells("dgocell_nota").Value.ToString
                End If
                vexiste = "N"
                For Each orow2 As DataRow In otb_personal_rp.Rows
                    If dg_row_id_personal_rp = orow2("f0403_id_personal_rp").ToString Then
                        vexiste = "S"
                        actualizar_listado_personal()
                        'MsgBox(id_tercero & "--" & orow2("f0607_id_tercero").ToString)
                    End If
                Next
                If vexiste = "N" Then 'el tercero no existe en la tabla entonces en nuevo
                    grabar_personal()
                End If
            End If
        Next
        'anulo los registros que no existan en la grilla
        For Each orow As DataRow In otb_personal_rp.Rows
            dg_row_id_personal_rp = orow("f0403_id_personal_rp").ToString
            vexiste = "N"
            For Each orow2 As DataGridViewRow In dg_personal.Rows
                If orow2.IsNewRow = False Then
                    'MsgBox(id_tercero & "=" & orow2.Cells("dgocell_id_tercero").Value.ToString)
                    If IsNothing(orow2.Cells("dgocell_id_personal_rp").Value) = False Then
                        If dg_row_id_personal_rp = orow2.Cells("dgocell_id_personal_rp").Value.ToString Then
                            vexiste = "S"
                            'MsgBox("Encontrado")
                        End If
                    End If

                End If
            Next
            If vexiste = "N" Then
                'MsgBox("Borrar: " & id_tercero)
                actualizar_listado_personal()
            End If
        Next
        If verror = "N" Then
            MsgBox("Info personal grabada", MsgBoxStyle.Information, "Grabado")
        End If
    End Sub
    Private Sub actualizar_listado_personal()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        If vexiste = "S" Then
            csql = "update " + database.obtener_esquema + ".tb0403_personal_rp set "
            csql += "f0403_horas = @f0403_horas,"
            csql += "f0403_nota = @f0403_nota,"
            csql += "f0403_usuario_modificar = @f0403_usuario_modificar,"
            csql += "f0403_fm = @f0403_fm"
            csql += " where f0403_id_personal_rp = @f0403_id_personal_rp"
        Else
            csql = "update " + database.obtener_esquema + ".tb0403_personal_rp set "
            csql += "f0403_anulado = 'S',"
            csql += "f0403_usuario_anular = @f0403_usuario_modificar,"
            csql += "f0403_fm = @f0403_fm"
            csql += " where f0403_id_rp = @f0403_id_rp and f0403_id_personal_rp = @f0403_id_personal_rp and f0403_anulado = 'N'"
        End If
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_personal(ocmd)
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

    Private Sub bt_grabar_personal_Click(sender As Object, e As EventArgs) Handles bt_grabar_personal.Click
        If tx_id_rp.Text = "" Then
            dg_personal.Rows.Clear()
            MsgBox("Primero debe grabar el reporte de produccion", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If dg_personal.Rows.Count = 1 Then
            Exit Sub
        End If
        'valido que los rows no tengan datos malos
        verror_requisitos = "N"
        For Each orow As DataGridViewRow In dg_personal.Rows
            If orow.IsNewRow = False Then
                If IsNumeric(orow.Cells("dgocell_tiempo_lab").Value) = False Then
                    verror_requisitos = "S"
                End If
                If orow.Cells("dgocell_tiempo_lab").Value = "0" Then
                    verror_requisitos = "S"
                End If
            End If
        Next
        If verror_requisitos = "S" Then
            MsgBox("Un dato de reporte de horas no es numerico o tiene valor 0", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Calculo el total de horas hombre trabajadas
        Dim tot_hh As Decimal = 0
        For Each orow As DataGridViewRow In dg_personal.Rows
            If orow.IsNewRow = False Then
                tot_hh += orow.Cells("dgocell_tiempo_lab").Value
            End If
        Next
        tx_horas_hombre.Text = tot_hh
        grabar_cambios_personal()
        'actualizo el total de personal involucrado en el rp
        actualizar_total_personal()
        'calculo indicadores productivos
        'calcular_indicadores_productivos()
        'actualizo en bd los indicadores productivos en el RP
        'actualizar_total_indicadores()
        'cargo el personal relacionado
        cargar_funcionarios_rp()

    End Sub
    Private Sub actualizar_total_personal()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set"
        csql += " f0402_num_funcionarios = @f0402_num_funcionarios,"
        csql += " f0402_horas_hombre = @f0402_horas_hombre"
        csql += " where f0402_id_rp = @f0402_id_rp and f0402_anulado = 'N'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_personal(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_num_funcionarios", NpgsqlDbType.Integer).Value = dg_personal.Rows.Count - 1
        ocmd.Parameters.Add("@f0402_horas_hombre", NpgsqlDbType.Numeric).Value = tx_horas_hombre.Text
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = id_rp
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

    Private Sub validar_actividad_alterna()
        If cm_actividad_alterna.SelectedIndex = -1 Then
            vmensaje_requisitos = "Seleccione la actividad alterna."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_horas_hombre()
        If CDec(tx_horas_hombre.Text) = 0 Then
            vmensaje_requisitos = "Registre las Horas Hombre"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub tx_horas_hombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_horas_hombre.KeyPress
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

    Private Sub tx_horas_hombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_horas_hombre.Validating
        If tx_horas_hombre.Text.Trim = "" Then
            tx_horas_hombre.Text = 0
        End If
        tx_horas_hombre.Text = CDec(tx_horas_hombre.Text)
    End Sub

End Class
