Imports System.ComponentModel

Public Class fm_0400_rp_reporte_produccion
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
    Private id_estandar_productivo As Integer = 0
    Private produccion_programada As Decimal = 0
    Private h_h_programada As Decimal = 0
    Private tomar_fecha_sistema As String = "N" 'para definir si la fecha a usar para consumos es la del sistema o la del RP

    Private otb_items As DataTable
    Private otb_reporte_produccion As DataTable
    Private otb_doc_mov_invent_relacionados As DataTable
    Private otb_info_personal As DataTable
    Private otb_personal_grillas As DataTable
    Private otb_personal_rp As DataTable 'es la datatable con los registros actuales relacionados en el rp
    Private otb_indicadores_productivos As DataTable
    Private otb_plantilla_produccion As DataTable



    Private Sub fm_0400_rp_reporte_produccion_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        'Defino con que fecha se realizara el consumo de insumos, si con la fecha del sistema o con la fecha del reporte
        tomar_fecha_sistema = comunes.suministrar_valor_variable_configuracion("CONFIG-0300-07", vg_id_cia)
        'MsgBox(tomar_fecha_sistema & " CARGO")

        dg_ind_productivos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_ind_productivos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

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
        dtp_fecha.CustomFormat = "yyyy/MM/dd hh:mm tt"

        ' Set the Format type and the CustomFormat string.
        dtp_h_ini_programada.Format = DateTimePickerFormat.Custom
        dtp_h_ini_programada.CustomFormat = "hh:mm  tt"

        ' Set the Format type and the CustomFormat string.
        dtp_h_fin_programada.Format = DateTimePickerFormat.Custom
        dtp_h_fin_programada.CustomFormat = "hh:mm  tt"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_vencimiento.Format = DateTimePickerFormat.Custom
        dtp_fecha_vencimiento.CustomFormat = "yyyy/MM/dd"
        dtp_fecha_vencimiento.Value = Now().AddYears(1)

        tx_cantidad_entregada.Text = 0
        tx_cant_produccion.Text = 0
        tx_tiempo_produccion.Text = 0
        tx_horas_hombre.Text = 1000
        tx_horas_hombre.ReadOnly = True
        'tx_recorte_consumido.Text = 0
        'tx_recorte_generado.Text = 0

        csql = "SELECT *, f0300_descripcion_item || ' - REF:(' || f0300_referencia || ') -" _
                    & " P:(' || f0300_contenido_x_empaque || ')' as descripcion_larga" _
                    & " FROM " & database.obtener_esquema & ".tb0300_items" _
                      & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                        & " on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
                    & " where f0300_id_cia = '" & vg_id_cia & "'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0005_bodegas"
        Dim otb_bodega_consumos As DataTable
        otb_bodega_consumos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim otb_bodega_entradas_pt As DataTable = otb_bodega_consumos.Copy
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
        With cm_bodega_entrega_pt
            'Valor que se muestra al usuario
            .DisplayMember = "f0005_descripcion_bodega"
            'Valor interno que almacena el objeto
            .ValueMember = "f0005_id_bodega"
            'Origen de Datos del ComboBox
            .DataSource = otb_bodega_entradas_pt
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        Dim otb_plantas_produccion As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0100_estructura_mantenimiento"
        csql += " where array_length(regexp_split_to_array(f0100_path,'-'),1) = 2 and f0100_id_tipo_estructura = '00000001'"
        csql += " and f0100_id_cia = '" & vg_id_cia & "'"
        csql += " order by f0100_nombre"
        otb_plantas_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_planta_produccion
            'Valor que se muestra al usuario
            .DisplayMember = "f0100_nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0100_id_estructura"
            'Origen de Datos del ComboBox
            .DataSource = otb_plantas_produccion
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "select *, '(' || f0350_id_plantilla || ' {' || f0350_activa || '}) => ' || f0350_descripcion as descrip_larga" _
            & " from " & database.obtener_esquema & ".tb0350_plantillas" _
            & " where f0350_id_cia = '" & vg_id_cia & "' and f0350_id_item = '" & id_item & "'"
        otb_plantilla_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_estandar_productivo
            'Valor que se muestra al usuario
            .DisplayMember = "descrip_larga"
            'Valor interno que almacena el objeto
            .ValueMember = "f0350_id_plantilla"
            'Origen de Datos del ComboBox
            .DataSource = otb_plantilla_produccion
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
        If vg_usuario_autoriza = "00000001" Then
            bt_grabar.Enabled = True
        End If
        Dim orowsintem As DataRow()
        orowsintem = otb_items.Select("f0300_id_item = '" & id_item & "'")
        For Each orow As DataRow In orowsintem
            lb_producto.Text = "Producto: " & orow("descripcion_larga")
            lb_unidad.Text = orow("f0002_unidad_medicion").ToString
            descripcion_producto = orow("descripcion_larga") & " {" & orow("f0002_unidad_medicion") & "}"
        Next

    End Sub

    Private Sub cargar_info_rp()
        csql = "select *" _
                    & " FROM " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                    & " where f0402_id_cia = '" & vg_id_cia & "' and f0402_id_rp = '" & id_rp & "'"
        otb_reporte_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_reporte_produccion.Rows
            'id_item = orow("f0402_id_item")
            id_rp = orow("f0402_id_rp")
            tx_ip_cg.Text = orow("f0402_ip_cg_codigo").ToString
            id_ipp = orow("f0402_id_ipp")
            id_item = orow("f0402_id_item")
            id_estructura = orow("f0402_id_maquina")
            cm_planta_produccion.SelectedValue = orow("f0402_planta_produccion")
            cm_estandar_productivo.SelectedValue = orow("f0402_id_plantilla")
            id_estandar_productivo = orow("f0402_id_plantilla")
            produccion_programada = orow("f0402_produccion_programada")
            h_h_programada = orow("f0402_h_h_programada")
            tx_hh_prog.Text = Math.Round(h_h_programada, 2)
            tx_prod_programada.Text = Math.Round(produccion_programada, 2)
            tx_estructura.Text = comunes.traer_nombre_estructura(orow("f0402_id_maquina").ToString)
            'lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_rp, vg_id_cia)
            vf_id_notas_archivos = orow("f0402_id_rp")
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
            tx_id_rp.Text = orow("f0402_id_rp")
            dtp_fecha.Value = orow("f0402_fecha_produccion")
            dtp_fecha_vencimiento.Value = orow("f0402_fecha_vence")
            If IsDBNull(orow("f0402_fecha_programada_ini_prod")) = False _
                And IsDBNull(orow("f0402_fecha_programada_fin_prod")) = False _
                Then
                'MsgBox(orow("f0402_fecha_programada_ini_prod").ToString)
                dtp_h_ini_programada.Value = orow("f0402_fecha_programada_ini_prod")
                dtp_h_fin_programada.Value = orow("f0402_fecha_programada_fin_prod")
            End If
            tx_lote.Text = orow("f0402_lote")
            estado_rp = orow("f0402_estado")
            'If orow("f0402_estado") = "A" Then
            'tx_estado.Text = "ABIERTO"
            ' Else
            'tx_estado.Text = "CERRADO"
            'End If
            Select Case orow("f0402_estado")
                Case "A"
                    tx_estado.Text = "ABIERTO"
                    bt_cerrar_rp.Enabled = True
                Case "B"
                    tx_estado.Text = "CERRADO ADMIN"
                Case "C"
                    tx_estado.Text = "CERRADO"
            End Select
            tx_turno.Text = orow("f0402_turno")
            'tx_cant_produccion.Text = orow("f0402_cantidad_producida")
            tx_tiempo_produccion.Text = orow("f0402_tiempo_produccion")
            tx_horas_hombre.Text = orow("f0402_horas_hombre")
            tx_clasificador.Text = orow("f0402_clasificador")
            'tx_recorte_consumido.Text = orow("f0402_recorte_usado")
            'tx_recorte_generado.Text = orow("f0402_recorte_mt_producido")

            'cargo el personal relacionado
            cargar_funcionarios_rp()

            If orow("f0402_id_bodega_consumo_insumos") <> 0 Then
                cm_bodegas.SelectedValue = orow("f0402_id_bodega_consumo_insumos")
                cm_bodegas.Enabled = False
                bt_entrar_produccion.Visible = False
            End If
            calcular_info_tiempo_improductivo()
            calcular_info_cant_tot_produccion()
            If orow("f0402_cantidad_producida") <> tot_produccion Or
               orow("f0402_tot_t_improductivo") <> t_improd_total _
               Then
                actualizar_info_recalculo()
            End If
            'calculo indicadores productivos
            calcular_indicadores_productivos()
            cargar_documentos_mov_inventario_relacionados()
        Next
        calcular_h_maquina_programadas()
    End Sub
    Private Sub formatear_segun_origen()

    End Sub
    Private Sub calcular_h_maquina_programadas()
        Dim valor_h As Long = DateDiff(DateInterval.Minute, dtp_h_ini_programada.Value, dtp_h_fin_programada.Value)
        tx_h_maq_prog.Text = Math.Round(valor_h / 60, 2)
    End Sub
    Private Sub calcular_produccion_esperada()
        Dim orow_plantilla As DataRow()
        id_estandar_productivo = cm_estandar_productivo.SelectedValue
        orow_plantilla = otb_plantilla_produccion.Select("f0350_id_plantilla = '" & id_estandar_productivo & "'")
        Dim prod_bache As Decimal = orow_plantilla(0)("f0350_produccion_x_bache")
        Dim tiempo_prod_bache As Decimal = orow_plantilla(0)("f0350_t_prod_bache")
        Dim h_h_prod_bache As Decimal = orow_plantilla(0)("f0350_hh_prod_bache")
        produccion_programada = prod_bache * tx_h_maq_prog.Text / tiempo_prod_bache
        tx_prod_programada.Text = Math.Round(produccion_programada, 2)
        h_h_programada = h_h_prod_bache * tx_h_maq_prog.Text / tiempo_prod_bache
        tx_hh_prog.Text = Math.Round(h_h_programada, 2)
    End Sub
    Private Sub cargar_documentos_mov_inventario_relacionados()
        csql = "select *, coalesce(f0318_info_trazable,'ND') as trazabilidad" _
               & " from " & database.obtener_esquema & ".tb0309_items_movimientos" _
               & " join " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                 & " on f0309_id_documento = f0310_id_documento" _
               & " left join " & database.obtener_esquema & ".tb0318_trazabilidad_movimientos" _
                 & " On f0318_id_mov_item = f0309_id_mov_item and f0318_anulado = 'N'" _
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
        lb_consumo_p.Text = "ND"
        lb_rec_aprov.Text = "ND"
        lb_cons_irreg.Text = "ND"
        lb_rec_gen.Text = "ND"
        Dim exist As String = "N"
        For Each orow As DataRow In otb_doc_mov_invent_relacionados.Rows
            If orow("f0310_id_tipo_documento") = 1 Then
                lb_consumo_p.Text = orow("f0310_id_documento")
                exist = "S"
            End If
            If orow("f0310_id_tipo_documento") = 11 Then
                lb_rec_aprov.Text = orow("f0310_id_documento")
                exist = "S"
            End If
            If orow("f0310_id_tipo_documento") = 7 Then
                lb_cons_irreg.Text = orow("f0310_id_documento")
                exist = "S"
            End If
            If orow("f0310_id_tipo_documento") = 12 Then
                lb_rec_gen.Text = orow("f0310_id_documento")
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

    Private Sub nuevo_rp()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                & " (f0402_id_cia, f0402_id_prog_prod, f0402_id_ipp, f0402_fecha_produccion, f0402_turno, f0402_id_item," _
                & " f0402_lote, f0402_fecha_vence, f0402_id_plantilla,f0402_h_h_programada," _
                & " f0402_fecha_programada_ini_prod, f0402_fecha_programada_fin_prod, f0402_produccion_programada," _
                & " f0402_cantidad_producida, f0402_tiempo_produccion, f0402_clasificador," _
                & " f0402_horas_hombre, f0402_tree_path," _
                & " f0402_id_maquina, f0402_tipo_registro, f0402_planta_produccion," _
                & " f0402_usuario_modificar, f0402_usuario_crear, f0402_fm)" _
                & " VALUES" _
                & " (@f0402_id_cia, @f0402_id_prog_prod, @f0402_id_ipp, @f0402_fecha_produccion, @f0402_turno, @f0402_id_item," _
                & " @f0402_lote, @f0402_fecha_vence, @f0402_id_plantilla,@f0402_h_h_programada," _
                & " @f0402_fecha_programada_ini_prod, @f0402_fecha_programada_fin_prod, @f0402_produccion_programada," _
                & " @f0402_cantidad_producida, @f0402_tiempo_produccion, @f0402_clasificador," _
                & " @f0402_horas_hombre, @f0402_tree_path," _
                & " @f0402_id_maquina, @f0402_tipo_registro, @f0402_planta_produccion," _
                & " @f0402_usuario_modificar, @f0402_usuario_crear, @f0402_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_id_prog_prod", NpgsqlDbType.Integer).Value = id_prog_prod
        ocmd.Parameters.Add("@f0402_id_ipp", NpgsqlDbType.Integer).Value = id_ipp
        ocmd.Parameters.Add("@f0402_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0402_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0402_tipo_registro", NpgsqlDbType.Integer).Value = 1 '1 = rp, 2= actividad alterna
        ocmd.Parameters.Add("@f0402_planta_produccion", NpgsqlDbType.Integer).Value = CInt(cm_planta_produccion.SelectedValue)
        ocmd.Parameters.Add("@f0402_id_plantilla", NpgsqlDbType.Integer).Value = CInt(cm_estandar_productivo.SelectedValue)
        ocmd.Parameters.Add("@f0402_lote", NpgsqlDbType.Varchar).Value = tx_lote.Text.Trim
        ocmd.Parameters.Add("@f0402_fecha_vence", NpgsqlDbType.Timestamp).Value = dtp_fecha_vencimiento.Value
        ocmd.Parameters.Add("@f0402_fecha_programada_ini_prod", NpgsqlDbType.Timestamp).Value = dtp_h_ini_programada.Value
        ocmd.Parameters.Add("@f0402_fecha_programada_fin_prod", NpgsqlDbType.Timestamp).Value = dtp_h_fin_programada.Value
        ocmd.Parameters.Add("@f0402_produccion_programada", NpgsqlDbType.Numeric).Value = produccion_programada
        ocmd.Parameters.Add("@f0402_h_h_programada", NpgsqlDbType.Numeric).Value = h_h_programada
        ocmd.Parameters.Add("@f0402_cantidad_producida", NpgsqlDbType.Numeric).Value = tx_cant_produccion.Text
        ocmd.Parameters.Add("@f0402_tiempo_produccion", NpgsqlDbType.Numeric).Value = tx_tiempo_produccion.Text
        ocmd.Parameters.Add("@f0402_horas_hombre", NpgsqlDbType.Numeric).Value = tx_horas_hombre.Text
        ocmd.Parameters.Add("@f0402_tree_path", NpgsqlDbType.Varchar).Value = tree_path
        ocmd.Parameters.Add("@f0402_fecha_produccion", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value
        'ocmd.Parameters.Add("@f0402_recorte_usado", NpgsqlDbType.Numeric).Value = tx_recorte_consumido.Text
        'ocmd.Parameters.Add("@f0402_recorte_mt_producido", NpgsqlDbType.Numeric).Value = tx_recorte_generado.Text
        'ocmd.Parameters.Add("@f0402_recorte_me_producido", NpgsqlDbType.Numeric).Value = tx_recorte_me_producido.Text
        ocmd.Parameters.Add("@f0402_turno", NpgsqlDbType.Varchar).Value = tx_turno.Text
        ocmd.Parameters.Add("f0402_clasificador", NpgsqlDbType.Varchar).Value = tx_clasificador.Text.ToString
        ocmd.Parameters.Add("@f0402_id_maquina", NpgsqlDbType.Integer).Value = id_estructura
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
        csql += "f0402_fecha_programada_ini_prod = @f0402_fecha_programada_ini_prod,"
        csql += "f0402_fecha_programada_fin_prod = @f0402_fecha_programada_fin_prod,"
        csql += "f0402_lote = @f0402_lote,"
        csql += "f0402_produccion_programada = @f0402_produccion_programada,"
        csql += "f0402_h_h_programada = @f0402_h_h_programada,"
        'csql += "f0402_recorte_usado = @f0402_recorte_usado,"
        'csql += "f0402_recorte_mt_producido = @f0402_recorte_mt_producido,"
        csql += "f0402_turno = @f0402_turno,"
        csql += "f0402_planta_produccion = @f0402_planta_produccion,"
        csql += "f0402_id_plantilla = @f0402_id_plantilla,"
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
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = CInt(tx_id_rp.Text)
        ocmd.Parameters.Add("@f0402_cantidad_producida", NpgsqlDbType.Numeric).Value = tx_cant_produccion.Text
        ocmd.Parameters.Add("@f0402_tiempo_produccion", NpgsqlDbType.Numeric).Value = tx_tiempo_produccion.Text
        ocmd.Parameters.Add("@f0402_horas_hombre", NpgsqlDbType.Numeric).Value = tx_horas_hombre.Text
        ocmd.Parameters.Add("@f0402_fecha_produccion", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value
        ocmd.Parameters.Add("@f0402_fecha_vence", NpgsqlDbType.Timestamp).Value = dtp_fecha_vencimiento.Value
        ocmd.Parameters.Add("@f0402_fecha_programada_ini_prod", NpgsqlDbType.Timestamp).Value = dtp_h_ini_programada.Value
        ocmd.Parameters.Add("@f0402_fecha_programada_fin_prod", NpgsqlDbType.Timestamp).Value = dtp_h_fin_programada.Value
        ocmd.Parameters.Add("@f0402_produccion_programada", NpgsqlDbType.Numeric).Value = produccion_programada
        ocmd.Parameters.Add("@f0402_h_h_programada", NpgsqlDbType.Numeric).Value = h_h_programada
        ocmd.Parameters.Add("@f0402_lote", NpgsqlDbType.Varchar).Value = tx_lote.Text
        If cm_planta_produccion.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0402_planta_produccion", NpgsqlDbType.Integer).Value = 0
        Else
            ocmd.Parameters.Add("@f0402_planta_produccion", NpgsqlDbType.Integer).Value = CInt(cm_planta_produccion.SelectedValue)
        End If
        If cm_estandar_productivo.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0402_id_plantilla", NpgsqlDbType.Integer).Value = 0
        Else
            ocmd.Parameters.Add("@f0402_id_plantilla", NpgsqlDbType.Integer).Value = CInt(cm_estandar_productivo.SelectedValue)
        End If
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
    Private Sub actualizar_info_recalculo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set "
        csql += "f0402_cantidad_producida = @f0402_cantidad_producida,"
        csql += "f0402_tot_t_improductivo = @f0402_tot_t_improductivo"
        csql += " where f0402_id_rp = @f0402_id_rp"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = CInt(tx_id_rp.Text)
        ocmd.Parameters.Add("@f0402_cantidad_producida", NpgsqlDbType.Numeric).Value = tot_produccion
        ocmd.Parameters.Add("@f0402_tot_t_improductivo", NpgsqlDbType.Numeric).Value = t_improd_total
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
    Private Sub validar_turno()
        If tx_turno.Text.Trim = "" Then
            vmensaje_requisitos = "Registre el Turno"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_lote()
        If tx_lote.Text.Trim = "" Then
            vmensaje_requisitos = "Registre el Lote"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_plantilla()
        If cm_estandar_productivo.SelectedIndex = -1 Then
            vmensaje_requisitos = "Registre estandar productivo"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_planta_prod()
        If cm_planta_produccion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Registre la planta de produccion"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_maquina()
        If tx_estructura.Text = "" Then
            vmensaje_requisitos = "Registre la maquina usada para produccion"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_fechas_turno()
        If tx_h_maq_prog.Text <= 0 Then
            vmensaje_requisitos = "Las horas de Inicio y Final de la programacion del turno no son validas"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        procedimiento_de_grabado()
    End Sub
    Private Sub procedimiento_de_grabado()
        verror_requisitos = "N"
        'validar_turno()
        validar_lote()
        'validar_tiempo_produccion()
        validar_horas_hombre()
        'validar_planta_prod()
        'validar_maquina()
        validar_fechas_turno()
        'validar_plantilla()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            nuevo_rp()
            If verror = "N" Then
                id_rp = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0402_id_rp", "f0402_usuario_crear", vg_usuario_autoriza, "tb0402_reporte_produccion")
                cargar_info_rp()
                vf_oform_padre.name_nodo_creado = "RP-" & tx_id_rp.Text
                vf_elemento_nuevo = "N"
                MsgBox("Registro Grabado", MsgBoxStyle.Information, "Info")
            End If
        Else
            If estado_rp = "C" Or estado_rp = "B" Then
                MsgBox("Reporte Cerrado, No puede modificarse", MsgBoxStyle.Information, "Error")
                cargar_info_rp()
                Exit Sub
            End If
            editar_rp()
            If verror = "N" Then
                'calculo indicadores productivos
                calcular_indicadores_productivos()
                'actualizo en bd los indicadores productivos en el RP
                actualizar_total_indicadores()
                id_estandar_productivo = cm_estandar_productivo.SelectedValue
                MsgBox("Registro Grabado", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub
    Private Sub tx_cant_produccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_cant_produccion.KeyPress
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

    Private Sub tx_cant_produccion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_cant_produccion.Validating
        If tx_cant_produccion.Text.Trim = "" Then
            tx_cant_produccion.Text = 0
        End If
        tx_cant_produccion.Text = CDec(tx_cant_produccion.Text)
    End Sub

    Private Sub tx_tiempo_produccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_tiempo_produccion.KeyPress
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

    Private Sub tx_tiempo_produccion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_tiempo_produccion.Validating
        If tx_tiempo_produccion.Text.Trim = "" Then
            tx_tiempo_produccion.Text = 0
        End If
        tx_tiempo_produccion.Text = CDec(tx_tiempo_produccion.Text)
    End Sub

    Private Sub validar_tiempo_produccion()
        If CDec(tx_tiempo_produccion.Text) = 0 Then
            vmensaje_requisitos = "Registre las h/maquina reales"
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

    Private Sub validar_horas_hombre()
        If CDec(tx_horas_hombre.Text) = 0 Then
            vmensaje_requisitos = "Registre las Horas Hombre"
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub bt_consumos_irregulares_Click(sender As Object, e As EventArgs) Handles bt_consumos_irregulares.Click
        If id_rp = 0 Or CDec(tx_cant_produccion.Text) = 0 Then
            Exit Sub
        End If
        If cm_bodegas.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim nuevo_docto As Integer
        Dim registro_recien_creado As String = "N"
        'Identifico si hay creado un documento
        Dim documento As String = suministrar_documento_mov_invent_relacionado(7)
        If documento = "" Then
            If estado_rp = "C" Or estado_rp = "B" Then
                MsgBox("El Reporte ya esta cerrado.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            'Pregunta si realmente desea reportar un consumo irregular
            Dim respuesta As String = "N"
            respuesta = comunes.g_mensaje_YesNo("Reportar Consumo", "Desea registrar un consumo irregular?")
            If respuesta = "N" Then
                Exit Sub
            End If

            registro_recien_creado = "S"
            nuevo_docto = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(7, vg_id_cia)
            Dim ofecha As Date
            If tomar_fecha_sistema = "S" Then
                ofecha = comunes.g_fechahora
            Else
                ofecha = dtp_fecha.Value
            End If
            'MsgBox(nuevo_docto)
            'Creo el nuevo documento de movimiento de inventarios
            'MsgBox("CPR-" & nuevo_docto.ToString.PadLeft(8, "0"))
            cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario("CNP-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                cm_bodegas.SelectedValue,
                                                                                7,
                                                                                ofecha,
                                                                                vg_usuario_autoriza, vg_id_cia,
                                                                                "RP-" & id_rp.ToString)
            'Actualizo la bodega de consumo del reporte
            actualizar_bodega_consumo()
            ' utiliso la variable registro_recien_creado para habilitar o no la modificacion del documento
            cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario("CNP-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                  vg_usuario_autoriza,
                                                                                  vg_id_cia,
                                                                                  registro_recien_creado, "S", "S", "S", "S", "S", "S", "S")
            cargar_documentos_mov_inventario_relacionados()
        Else
            cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(documento,
                                                                                  vg_usuario_autoriza,
                                                                                  vg_id_cia,
                                                                                  registro_recien_creado, "S", "D", "S", "S", "S", "S", "S")
        End If
    End Sub

    Private Sub bt_consumir_recortes_Click(sender As Object, e As EventArgs) Handles bt_consumir_recortes.Click
        If id_rp = 0 Or CDec(tx_cant_produccion.Text) = 0 Then
            Exit Sub
        End If
        If cm_bodegas.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim nuevo_docto As Integer
        Dim registro_recien_creado As String = "N"
        'Identifico si hay creado un aprovechamiento de recorte
        Dim documento As String = suministrar_documento_mov_invent_relacionado(11)
        If documento = "" Then
            If estado_rp = "C" Or estado_rp = "B" Then
                MsgBox("El Reporte ya esta cerrado.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            'identifico si ya hay un consumo realizado.
            Dim doc_consumo As String = suministrar_documento_mov_invent_relacionado(1)
            If doc_consumo <> "" Then
                MsgBox("No puede registrar recorte despues de realizado el consumo de insumos", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            'Pregunta si realmente desea reportar un consumo irregular
            Dim respuesta As String = "N"
            respuesta = comunes.g_mensaje_YesNo("Reportar Consumo Recorte", "Desea registrar un consumo de Recorte?")
            If respuesta = "N" Then
                Exit Sub
            End If

            'Si ya se consumio la materia prima planificada entonces hay que bloquear el consumo de recorte
            csql = "select * from " & database.obtener_esquema & ".tb0309_items_movimientos" _
               & " join " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                 & " on f0309_id_documento = f0310_id_documento" _
            & " where f0309_id_cia = '" & vg_id_cia & "'" & " and f0310_id_tipo_documento = '1' and" _
               & " f0310_id_documento_origen = 'RP-" & id_rp.ToString & "'" _
               & " and f0309_anulado = 'N'"
            'Clipboard.SetDataObject(csql)
            'MsgBox(csql)
            Dim otb_consumos As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            If otb_consumos.Rows.Count = 0 Then
                registro_recien_creado = "S"
                nuevo_docto = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(11, vg_id_cia)
                Dim ofecha As Date
                If tomar_fecha_sistema = "S" Then
                    ofecha = comunes.g_fechahora
                Else
                    ofecha = dtp_fecha.Value
                End If
                'MsgBox(nuevo_docto)
                'Creo el nuevo documento de movimiento de inventarios
                'MsgBox("CPR-" & nuevo_docto.ToString.PadLeft(8, "0"))
                cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario("ARP-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                cm_bodegas.SelectedValue,
                                                                                11,
                                                                                ofecha,
                                                                                vg_usuario_autoriza, vg_id_cia,
                                                                                "RP-" & id_rp.ToString)
                'Actualizo la bodega de consumo del reporte
                actualizar_bodega_consumo()
                ' utiliso la variable registro_recien_creado para habilitar o no la modificacion del documento
                cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario("ARP-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                  vg_usuario_autoriza,
                                                                                  vg_id_cia,
                                                                                  registro_recien_creado, "S", "S", "S", "S", "S", "S", "S")
                cargar_documentos_mov_inventario_relacionados()
            Else
                MsgBox("Ya no se puede reportar consumo de recorte debido a que ya consumio materia prima", MsgBoxStyle.Information, "Info")
            End If
        Else
            cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(documento,
                                                                                  vg_usuario_autoriza,
                                                                                  vg_id_cia,
                                                                                  registro_recien_creado, "S", "D", "S", "S", "S", "S", "S")
        End If
        identificar_total_consumo_recorte()
        actualizar_total_recorte_aprovechado()
        calcular_indicadores_productivos()
    End Sub

    Private Sub bt_transformar_en_recorte_Click(sender As Object, e As EventArgs) Handles bt_transformar_en_recorte.Click
        'OJO El item de recorte solo puede estar definido en kilogramos (6)
        If id_rp = 0 Or CDec(tx_cant_produccion.Text) = 0 Then
            Exit Sub
        End If
        If cm_bodegas.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim nuevo_docto As Integer
        Dim registro_recien_creado As String = "N"
        'Identifico si hay creado un CNP
        Dim documento As String = suministrar_documento_mov_invent_relacionado(12)
        'MsgBox(documento)
        If documento = "" Then 'If otb_cnp.Rows.Count = 0 Then
            If estado_rp = "C" Or estado_rp = "B" Then
                MsgBox("El Reporte ya esta cerrado.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            'identifico si ya hay un consumo realizado.
            Dim doc_consumo As String = suministrar_documento_mov_invent_relacionado(1)
            If doc_consumo <> "" Then
                MsgBox("No puede registrar recorte despues de realizado el consumo de insumos", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            'Pregunta si realmente desea reportar un consumo irregular
            Dim respuesta As String = "N"
            respuesta = comunes.g_mensaje_YesNo("Reportar Recorte Generado", "Desea registrar generacion de recorte?")
            If respuesta = "N" Then
                Exit Sub
            End If
            'Defino la cantidad de producto a transformar en recorte
            Dim cant_transf As String = ""
            MsgBox("Acontinuacion defina la cantidad de recorte que genero: ", MsgBoxStyle.Information, "Info")
            cant_transf = comunes.formulario_parametro_texto("0", "Cantidad de recorte en kilogramos")
            If cant_transf = "" Then
                Exit Sub
            End If
            If IsNumeric(cant_transf) = False Then
                MsgBox("Debe definir un valor numerico", MsgBoxStyle.Exclamation, "Cancelado")
                Exit Sub
            End If
            Dim ofecha As Date
            If tomar_fecha_sistema = "S" Then
                ofecha = comunes.g_fechahora
            Else
                ofecha = dtp_fecha.Value
            End If

            MsgBox("Acontinuacion defina el tipo de recorte generado:  ", MsgBoxStyle.Information, "Info")
            'creo la estructura de la variable que usaremos para realizar el movimiento de inventario de entrada
            Dim info_item_mov_inventario_e As cl_estructuras_variables.info_item_mov_inventario = Nothing
            Dim otb_items_recorte As DataTable
            csql = "SELECT *, f0300_descripcion_item || ' - REF:(' || f0300_referencia || ') -" _
                    & " P:(' || f0300_contenido_x_empaque || ')' as descripcion_larga" _
                    & " FROM " & database.obtener_esquema & ".tb0300_items" _
                      & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                        & " on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
                    & " where f0300_id_cia = '" & vg_id_cia & "' and f0300_id_tipo_item = '29'"
            otb_items_recorte = cl_utilidades_datatables.cargar_informacion_postgres(csql)

            info_item_mov_inventario_e.id_item = comunes.formulario_parametro_texto("", "Recorte Generado:",, otb_items_recorte, "descripcion_larga", "f0300_id_item")
            info_item_mov_inventario_e.cantidad = cant_transf

            If info_item_mov_inventario_e.id_item = 0 Then
                Exit Sub
            End If

            registro_recien_creado = "S"
            nuevo_docto = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(12, vg_id_cia)
            'MsgBox(nuevo_docto)
            'Creo el nuevo documento de movimiento de inventarios
            'MsgBox("CPR-" & nuevo_docto.ToString.PadLeft(8, "0"))
            cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario("RGR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                cm_bodegas.SelectedValue,
                                                                                12,
                                                                                ofecha,
                                                                                vg_usuario_autoriza, vg_id_cia,
                                                                                "RP-" & id_rp.ToString)
            'movimiento de entrada
            cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario("RGR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                             cm_bodegas.SelectedValue,
                                                                             1,
                                                                             info_item_mov_inventario_e.id_item,
                                                                             info_item_mov_inventario_e.cantidad,
                                                                             0, ofecha,
                                                                             vg_usuario_autoriza, vg_id_cia, 0, 1,, "RP-" & id_rp)
            'Actualizo la bodega de consumo del reporte
            actualizar_bodega_consumo()
            ' utiliso la variable registro_recien_creado para habilitar o no la modificacion del documento
            cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario("RGR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                  vg_usuario_autoriza,
                                                                                  vg_id_cia,
                                                                                  "N", "S", "D", "S", "S", "S", "S", "S")
            cargar_documentos_mov_inventario_relacionados()
        Else
            cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(documento,
                                                                                  vg_usuario_autoriza,
                                                                                  vg_id_cia,
                                                                                  registro_recien_creado, "S", "D", "S", "S", "S", "S", "S")
        End If
        identificar_total_consumo_recorte()
        actualizar_total_recorte_aprovechado()
        calcular_indicadores_productivos()
    End Sub
    Private Function entregar_conversion_de_kg_a_unidad_item_rp(ByVal peso_kg As Decimal)
        'identifico las unidades en que estan creados los items para igualarlas, por ejemplo
        'convertir unidades en kilogramos
        Dim unid_item_rp As Integer
        Dim peso_unit_item_rp As Decimal
        Dim cantidad_equivalente As Decimal = 0

        'creo la estructura de la variable que usaremos para realizar el movimiento de inventario de salida
        Dim info_item_mov_inventario_rp As cl_estructuras_variables.info_item_mov_inventario = Nothing
        info_item_mov_inventario_rp.id_item = id_item
        Dim orow_item As DataRow()
        orow_item = otb_items.Select("f0300_id_item = '" & info_item_mov_inventario_rp.id_item & "'")
        unid_item_rp = orow_item(0)("f0300_id_unidad_medicion")
        peso_unit_item_rp = orow_item(0)("f0300_peso_neto")

        'si el item de recorte solo puede estar definido en kilogramos (6)
        If unid_item_rp <> 6 Then
            cantidad_equivalente = peso_kg / peso_unit_item_rp
        Else
            cantidad_equivalente = peso_kg
        End If
        Return cantidad_equivalente
    End Function
    Private Sub identificar_total_consumo_recorte()
        csql = "select coalesce(sum(f0309_salida), 0) as consumo," _
            & " coalesce(sum(f0309_entrada), 0) as generado" _
            & " From " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
              & " join " & database.obtener_esquema & ".tb0309_items_movimientos" _
              & " On f0309_id_documento = f0310_id_documento And f0309_anulado = 'N'" _
            & " where f0310_id_cia = '" & vg_id_cia & "' and" _
            & " (f0310_id_tipo_documento = '11' or f0310_id_tipo_documento = '12') and" _
            & " f0310_id_documento_origen = 'RP-" & id_rp.ToString & "'" _
            & " and f0310_anulado = 'N'"
        Dim otb_recorte_usado As DataTable
        otb_recorte_usado = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        recorte_consumido = 0
        If otb_recorte_usado.Rows.Count > 0 Then
            For Each orow As DataRow In otb_recorte_usado.Rows
                recorte_consumido = orow("consumo")
                recorte_generado = orow("generado")
                'MsgBox("Consumido: " & recorte_consumido & " Generado: " & recorte_generado)
            Next
        End If
    End Sub
    Private Sub actualizar_total_recorte_aprovechado()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set"
        csql += " f0402_recorte_usado = @f0402_recorte_usado,"
        csql += " f0402_recorte_producido = @f0402_recorte_producido"
        csql += " where f0402_id_rp = @f0402_id_rp and f0402_anulado = 'N'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_personal(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_recorte_usado", NpgsqlDbType.Numeric).Value = recorte_consumido
        ocmd.Parameters.Add("@f0402_recorte_producido", NpgsqlDbType.Numeric).Value = recorte_generado
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

    Private Sub bt_consumos_planificados_Click(sender As Object, e As EventArgs) Handles bt_consumos_planificados.Click
        If id_rp = 0 Or CDec(tx_cant_produccion.Text) = 0 Then
            Exit Sub
        End If
        If cm_bodegas.SelectedIndex = -1 Then
            Exit Sub
        End If

        'identifico si hay un documento de consumo de insumos
        Dim documento As String = suministrar_documento_mov_invent_relacionado(1)
        If documento = "" Then
            If estado_rp = "C" Or estado_rp = "B" Then
                MsgBox("El Reporte ya esta cerrado.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim respuesta As String
            respuesta = comunes.g_mensaje_YesNo("Consumo Programado", "Desea generar el consumo de insumos programados?")
            If respuesta = "N" Then
                Exit Sub
            End If
            'MsgBox("voy")
            Dim ofecha As Date
            If tomar_fecha_sistema = "S" Then
                ofecha = comunes.g_fechahora
            Else
                ofecha = dtp_fecha.Value
            End If
            'MsgBox(tomar_fecha_sistema & " " & ofecha)
            'registro_recien_creado = "S"

            'Primero verifico si se puede realizar la salida de todos los items
            'Dim saldo_negativo As String = "N"
            'Dim vmensaje_s_negativo As String = "Saldo negativo para el siguiente Item:" & vbCrLf
            'Dim vmensaje_items As String = ""
            'Dim list_eliminar As New List(Of DataRow) 'Listado auxiliar para luego elimar los  rows que no son consumibles.

            'Protejo cambios de bodega despues de realizado el consumo.
            cm_bodegas.Enabled = False

            Dim nuevo_docto As Integer
            'Identifico si existen aprovechamientos de recorte
            identificar_total_consumo_recorte()

            'Dejo abierta la posibilidad de identificar la plantilla de produccion usando la plantilla activa,
            'Pero como he identificado la plantilla que quiero usar en el proceso entonces uso esta informacion.
            Dim otb_plantillas As DataTable
            Dim otb_items_plantillas As DataTable
            csql = comunes.suministrar_valor_variable_configuracion("ST-0300-06", vg_id_cia)
            csql = csql.Replace("$df001$", database.obtener_esquema)
            csql = csql.Replace("$001$", vg_id_cia)
            'debo cargar tambien las plantillas que no estan activas
            csql = csql.Replace(" and f0350_activa = 'S'", "")
            otb_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

            csql = comunes.suministrar_valor_variable_configuracion("ST-0300-07", vg_id_cia)
            csql = csql.Replace("$df001$", database.obtener_esquema)
            csql = csql.Replace(" and f0350_activa = 'S'", "")
            otb_items_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

            Dim cantidad_producida As Decimal
            Dim cant_rec_aprov As Decimal = entregar_conversion_de_kg_a_unidad_item_rp(recorte_consumido)
            Dim cant_rec_gen As Decimal = entregar_conversion_de_kg_a_unidad_item_rp(recorte_generado)
            cantidad_producida = tx_cant_produccion.Text - cant_rec_aprov + cant_rec_gen
            'MsgBox(cantidad_producida)
            If cantidad_producida < 0 Then
                MsgBox("La cantidad producida no puede ser inferior a la cantidad de recorte usado", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If
            Dim otb_formula As DataTable
            otb_formula = cl_utilidades_gestion_compras.formulacion_entregar_formula_item_directa(id_item, cantidad_producida, "1", otb_plantillas, otb_items_plantillas, id_estandar_productivo)


            '-------------------------------------------
            'Evaluo la viabilidad de realizar todos los consumos sin que se generen invenatarios negativos posteriores.
            Dim viabilidad As String = ""
            Dim otb_items_consumir As New DataTable
            ' Create four typed columns in the DataTable.
            'Estructura del datatable items_cantidades: {id_item, nombre, cantidad}
            otb_items_consumir.Columns.Add("id_item", GetType(Integer))
            otb_items_consumir.Columns.Add("nombre", GetType(String))
            otb_items_consumir.Columns.Add("cantidad", GetType(Decimal))
            'agrego los rows al datatable
            For Each orow As DataRow In otb_formula.Rows
                If orow("consumible") = "S" Then
                    Dim orow_item_consumir As DataRow = otb_items_consumir.NewRow
                    orow_item_consumir("id_item") = orow("id_item")
                    orow_item_consumir("nombre") = orow("nombre")
                    orow_item_consumir("cantidad") = orow("cantidad")
                    otb_items_consumir.Rows.Add(orow_item_consumir)
                End If
            Next

            viabilidad = cl_utilidades_gestion_compras.verificar_viabilidad_varios_consumos_salidas(cm_bodegas.SelectedValue,
                                                                                                ofecha,
                                                                                                otb_items_consumir,
                                                                                                vg_id_cia,
                                                                                                vg_usuario_autoriza)
            If viabilidad <> "" Then
                MsgBox(viabilidad, MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            '------------------------------------------

            'Realizo la salida de insumos si no hay saldos negativos.
            'Identifico el consecutivo de la nueva entrada de producto terminado o semiterminado.
            nuevo_docto = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(1, vg_id_cia)
            'MsgBox(nuevo_docto)
            'Creo el nuevo documento de movimiento de inventarios
            'MsgBox("CPR-" & nuevo_docto.ToString.PadLeft(8, "0"))
            cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario("CPR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                    cm_bodegas.SelectedValue,
                                                                                    1,
                                                                                    ofecha,
                                                                                    vg_usuario_autoriza, vg_id_cia,
                                                                                    "RP-" & id_rp.ToString)
            'Actualizo la bodega de consumo del reporte
            actualizar_bodega_consumo()
            'Consumo los valores de formula del inventario de la bodega
            Dim ocont As Integer = 0
            Dim orows_insumos_validos As DataRow()
            orows_insumos_validos = otb_formula.Select("consumible = 'S'")

            'Ahora consumo los items segun la formula
            For Each orow As DataRow In orows_insumos_validos
                ocont += 1
                'cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario("xxx-" & id_rp.ToString.PadLeft(8, "0"), cm_bodegas.SelectedValue, ocont, orow("id_item"), orow("cantidad"), 0, ofecha, vg_usuario_autoriza, vg_id_cia)

                cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario("CPR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                     cm_bodegas.SelectedValue,
                                                                                     ocont,
                                                                                     orow("id_item"),
                                                                                     0,
                                                                                     orow("cantidad"),
                                                                                     ofecha,
                                                                                     vg_usuario_autoriza,
                                                                                     vg_id_cia,
                                                                                     orow("cantidad"))
            Next
            ' utiliso la variable registro_recien_creado para habilitar o no la modificacion del documento
            cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario("CPR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                      vg_usuario_autoriza,
                                                                                      vg_id_cia,
                                                                                      "N", "S", "D")
            cargar_documentos_mov_inventario_relacionados()
        Else
            'Identificamos si ul usuario tiene acceso total a las formulaciones
            Dim temp_otabla_permiso As DataTable
            temp_otabla_permiso = cl_gestion_permisos.identificar_permisos_usuario(vg_usuario_autoriza, "fm_0300_gestion_items", "")
            usuario_con_acceso_total = cl_gestion_permisos.identificar_permisos_especiales_formularios("ACCESO_RESTRINGIDO",
                                                                                            temp_otabla_permiso,
                                                                                            vg_usuario_autoriza)
            'Muestro el documento
            'Identifico si es un item con informacion restringida
            buscar_info_item()
            Dim mostrar_reporte As String = "S"
            If item_restringido = "S" Then
                If usuario_con_acceso_total = "N" Then
                    mostrar_reporte = "N"
                    MsgBox("No Disponible", MsgBoxStyle.Exclamation, "Acceso Restringido")
                End If
            End If
            If mostrar_reporte = "S" Then
                cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(documento,
                                                                                      vg_usuario_autoriza,
                                                                                      vg_id_cia,
                                                                                      "N", "S", "D")
            End If
        End If
        bt_entrar_produccion.Visible = False
        'cl_utilidades_datatables.visualizar_datos_visor("", "", vg_usuario_autoriza, "Datos de tabla", {}, otb_formula)
    End Sub
    Private Sub buscar_info_item()
        Dim orow As DataRow()
        orow = otb_items.Select("f0300_id_item = '" & id_item & "'")
        For Each orowp As DataRow In orow
            item_restringido = orowp("f0300_ar")
        Next
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
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = CInt(tx_id_rp.Text)
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

    Private Sub validar_descargue_insumos()
        'Para evitar que se cierre un reporte con ningun consumo entonces verifico la existencia de estos
        Dim documento As String = suministrar_documento_mov_invent_relacionado(1)

        If documento = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Registre los insumos consumidos."
        End If
        Dim sin_traz As Integer = 0
        Dim osintraz As DataRow()
        osintraz = otb_doc_mov_invent_relacionados.Select("trazabilidad = 'ND'")
        'MsgBox(osintraz.Length)
        If osintraz.Length > 0 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Registre la trazabilidad de los movimientos: " & osintraz(0)("f0309_id_documento")
        End If
    End Sub
    Private Sub validar_reporte_horas()
        If CDec(tx_horas_hombre.Text) = 1000 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Registre el personal de produccion"
        End If
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
        cargar_info_rp()
        verror_requisitos = "N"
        validar_descargue_insumos()
        validar_tiempo_produccion()
        validar_reporte_horas()

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
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = CInt(tx_id_rp.Text)
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
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = CInt(tx_id_rp.Text)
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


    Private Sub tx_cantidad_entregada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_cantidad_entregada.KeyPress
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

    Private Sub tx_cantidad_entregada_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_cantidad_entregada.Validating
        If tx_cantidad_entregada.Text.Trim = "" Then
            tx_cantidad_entregada.Text = 0
        End If
        tx_cantidad_entregada.Text = CDec(tx_cantidad_entregada.Text)
    End Sub

    Private Sub bt_entrar_produccion_Click(sender As Object, e As EventArgs) Handles bt_entrar_produccion.Click
        If id_rp = 0 Then
            Exit Sub
        End If
        If tx_docto_contable.Text.Trim = "" Then
            MsgBox("Debe registrar el docuemnto contable de entrada.", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        If tx_cantidad_entregada.Text = "0" Then
            MsgBox("Debe registrar una cantidad de entrada.", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        If cm_bodega_entrega_pt.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la bodega de entrada.", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        'Pregunta si realmente desea reportar una produccion.
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Produccion", "Desea una registrar una entrada de produccion?")
        If respuesta = "N" Then
            Exit Sub
        End If
        'Actualizo la informacion del rp por si ha cambiado por otro usuario.
        cargar_info_rp()
        'Identifico el consecutivo de la nueva entrada de producto terminado o semiterminado.
        Dim nuevo_docto As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(4, vg_id_cia)
        Dim fecha_registro As DateTime = dtp_fecha.Value ' comunes.g_fechahora
        'Creo el nuevo documento de movimiento de inventarios
        cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario("EPR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                            cm_bodega_entrega_pt.SelectedValue,
                                                                            4,
                                                                            fecha_registro,
                                                                            vg_usuario_autoriza, vg_id_cia, "RP-" & id_rp,
                                                                            tx_docto_contable.Text.Trim)
        'Ingreso la cantidad que se esta entrando.
        cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario("EPR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                             cm_bodega_entrega_pt.SelectedValue,
                                                                             1,
                                                                             id_item,
                                                                             tx_cantidad_entregada.Text,
                                                                             0,
                                                                             fecha_registro,
                                                                             vg_usuario_autoriza,
                                                                             vg_id_cia,
                                                                             0)
        'identifico el movimiento creado
        Dim id_mov_creado As Integer
        id_mov_creado = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0309_id_mov_item", "f0309_usuario_crear", vg_usuario_autoriza, "tb0309_items_movimientos")
        'Ingreso la informacion de trazabilidad
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0318_trazabilidad_movimientos" _
                                & " (f0318_id_cia, f0318_id_mov_item, f0318_id_mov_docto, f0318_id_item, f0318_id_bodega, f0318_id_documento," _
                                & " f0318_fecha_movimiento, f0318_info_trazable," _
                                & " f0318_usuario_crear, f0318_usuario_modificar)" _
                                & " VALUES" _
                                & " (@f0318_id_cia, @f0318_id_mov_item, @f0318_id_mov_docto, @f0318_id_item, @f0318_id_bodega, @f0318_id_documento," _
                                & " @f0318_fecha_movimiento, @f0318_info_trazable," _
                                & " @f0318_usuario_crear, @f0318_usuario_modificar)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item_prog_prod(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0318_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0318_id_mov_item", NpgsqlDbType.Numeric).Value = id_mov_creado
        ocmd.Parameters.Add("@f0318_id_mov_docto", NpgsqlDbType.Numeric).Value = 1
        ocmd.Parameters.Add("@f0318_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0318_id_bodega", NpgsqlDbType.Integer).Value = CInt(cm_bodega_entrega_pt.SelectedValue)
        ocmd.Parameters.Add("@f0318_id_documento", NpgsqlDbType.Varchar).Value = "EPR-" & nuevo_docto.ToString.PadLeft(8, "0")
        ocmd.Parameters.Add("@f0318_fecha_movimiento", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value
        ocmd.Parameters.Add("@f0318_info_trazable", NpgsqlDbType.Varchar).Value = tx_lote.Text & " (RP-" & id_rp & ")"
        ocmd.Parameters.Add("@f0318_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0318_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza

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

        'calculo el total producido de acuerdo a las entradas de produccion
        calcular_info_cant_tot_produccion()
        'Actualizo la cantidad en la bd
        cl_utilidades_gestion_produccion.actualizar_cantidad_produccion(tx_id_rp.Text, tot_produccion, vg_usuario_autoriza)
        'actualizar_cantidad_produccion(ocantidad)
        tx_cant_produccion.Text = tot_produccion
        MsgBox("Entrada registrada", MsgBoxStyle.Information, "Info")
        tx_cantidad_entregada.Text = 0
        tx_docto_contable.Text = ""
        cm_bodega_entrega_pt.SelectedIndex = -1
        'calculo indicadores productivos
        calcular_indicadores_productivos()
        'actualizo en bd los indicadores productivos en el RP
        actualizar_total_indicadores()
    End Sub

    Private Sub bt_consultar_entradas_Click(sender As Object, e As EventArgs) Handles bt_consultar_entradas.Click
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-12", vg_id_cia, vg_usuario_autoriza, "Entradas de Produccion", {vg_id_cia, "RP-" & id_rp})
        'calculo el total producido de acuerdo a las entradas de produccion
        calcular_info_cant_tot_produccion()
        'Actualizo la cantidad en la bd
        cl_utilidades_gestion_produccion.actualizar_cantidad_produccion(tx_id_rp.Text, tot_produccion, vg_usuario_autoriza)
        'actualizar_cantidad_produccion(ocantidad)
        tx_cant_produccion.Text = tot_produccion
        'calculo indicadores productivos
        calcular_indicadores_productivos()
        'actualizo en bd los indicadores productivos en el RP
        actualizar_total_indicadores()
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
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = CInt(tx_id_rp.Text)
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

        'tx_estado.Text = "ABIERTO"
        'bt_cerrar_rp.Enabled = True
        'estado_rp = "A"
        cargar_info_rp()
    End Sub
    Private Sub calcular_info_cant_tot_produccion()
        'Identifico la cantidad existente antes de realizar el ingreso.
        csql = "select sum(f0309_entrada) as cantidad" _
             & " from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
             & " Join " & database.obtener_esquema & ".tb0309_items_movimientos" _
             & " on f0310_id_documento = f0309_id_documento" _
             & " where f0310_id_documento_origen = 'RP-" & id_rp & "'" _
             & " and f0310_id_tipo_documento = '4' and f0309_anulado = 'N'" _
             & " and f0310_anulado = 'N' and f0310_id_cia = '" & vg_id_cia & "'"
        Dim otb_tot As DataTable
        otb_tot = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_tot.Rows.Count > 0 Then
            Dim orowscantidad As DataRow()
            orowscantidad = otb_tot.Select("", "")
            If IsDBNull(orowscantidad(0)("cantidad")) = False Then
                tot_produccion = orowscantidad(0)("cantidad")
            Else
                tot_produccion = 0
            End If
        End If
        tx_cant_produccion.Text = tot_produccion
    End Sub
    Private Sub calcular_info_tiempo_improductivo()
        If id_rp = 0 Then
            Exit Sub
        End If
        Dim csql As String = ""
        Dim otb_tiempo_improductivo As DataTable

        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-11", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", "RP")
        csql = csql.Replace("$003$", id_rp)
        otb_tiempo_improductivo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_tiempo_improductivo.Rows.Count > 0 Then
            lb_total_rep_t_improd.Text = otb_tiempo_improductivo.Rows.Count
            Dim ototiempo As Object = otb_tiempo_improductivo.Compute("Sum(minutos)", "")
            If IsDBNull(ototiempo) = False Then
                lb_total_min_t_improd.Text = ototiempo & " min"
                t_improd_total = ototiempo
            End If
        Else
            t_improd_total = 0
        End If
    End Sub
    Private Sub bt_t_improductivo_Click(sender As Object, e As EventArgs) Handles bt_t_improductivo.Click
        If id_rp = 0 Then
            Exit Sub
        End If
        Dim csql As String = ""

        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-11", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", "RP")
        csql = csql.Replace("$003$", id_rp)
        'Clipboard.SetText(csql)
        'MsgBox(csql)

        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_archivos As New camocontrol.fm_visor_datos
        oform_mostrar_archivos.vf_oform_padre = Me
        oform_mostrar_archivos.csql = csql
        oform_mostrar_archivos.titulo_formulario = "Tiempos Improductivos Asociados al Registro"
        oform_mostrar_archivos.ocontexto_form = "gestion de tiempos improductivos produccion"
        oform_mostrar_archivos.id_oreg_padre = id_rp
        oform_mostrar_archivos.id_estructura = id_estructura 'para que se cargue la estructura en el reporte de falla
        'oform_mostrar_archivos.ovalue = vf_var_config_archivos
        oform_mostrar_archivos.otipo_nota = "RP"
        oform_mostrar_archivos.vg_id_cia = vg_id_cia
        oform_mostrar_archivos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_archivos.ShowDialog()
        'Recalculamos la cantidad de reportes
        calcular_info_tiempo_improductivo()
        'Actualizo la informacion en la bd
        actualizar_info_recalculo()

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
        ocmd.Parameters.Add("@f0403_id_personal_rp", NpgsqlDbType.Integer).Value = CInt(dg_row_id_personal_rp)
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
        calcular_indicadores_productivos()
        'actualizo en bd los indicadores productivos en el RP
        actualizar_total_indicadores()
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
        ocmd.Parameters.Add("@f0402_num_funcionarios", NpgsqlDbType.Integer).Value = CInt(dg_personal.Rows.Count - 1)
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
    Private Sub actualizar_total_indicadores()
        If tx_cant_produccion.Text = 0 Then
            Exit Sub
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set"
        csql += " f0402_productividad = @f0402_productividad"
        csql += " where f0402_id_rp = @f0402_id_rp and f0402_anulado = 'N'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_personal(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_productividad", NpgsqlDbType.Numeric).Value = ind_productividad
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
    Private Sub calcular_indicadores_productivos()
        'Exit Sub
        If tx_id_rp.Text = "" Then
            Exit Sub
        End If
        If tx_cant_produccion.Text = 0 Then
            Exit Sub
        End If
        If tx_tiempo_produccion.Text = 0 Then
            Exit Sub
        End If
        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-15", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_rp)
        'para que cargue los indices de la plantilla seleccionada no de la activa
        csql = csql.Replace("f0350_activa = 'S'", "f0350_id_plantilla = '" & id_estandar_productivo & "'")
        otb_indicadores_productivos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_indicadores_productivos.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim otb_tabla_indicadores_prod As DataTable = Nothing
        Dim ind_nombre As String = ""
        Dim ind_valor As Decimal = 0
        Dim especificacion As String = ""
        Dim oarray As Decimal() = Nothing
        'limpio el datagrid para poner nuevos valores
        dg_ind_productivos.Rows.Clear()
        For Each ocolum As DataColumn In otb_indicadores_productivos.Columns
            ind_nombre = ocolum.ColumnName
            oarray = otb_indicadores_productivos.Rows(0).Item(ocolum.Ordinal)
            ind_valor = CDec(oarray(0))
            especificacion = oarray(1)
            agregar_fila_indicador_productivo(ind_nombre, ind_valor, especificacion)
            If ind_nombre = "productividad" Then
                ind_productividad = ind_valor
            End If
        Next

    End Sub
    Private Sub agregar_fila_indicador_productivo(ByVal ind_nombre As String, ByVal ind_valor As Decimal,
                                                  ByVal especificacion As String)
        'Crea objeto fila del Datagridview
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1 -- esta oculta
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = ind_nombre
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = ind_valor
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = especificacion
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_ind_productivos.Rows.Add(orowgrid)
    End Sub

    Private Sub bt_inventario_Click(sender As Object, e As EventArgs) Handles bt_inventario.Click
        If cm_bodegas.SelectedIndex = -1 Then
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-11", vg_id_cia, vg_usuario_autoriza,
                                                        cm_bodegas.Text, {vg_id_cia, cm_bodegas.SelectedValue},,
                                                        "Informacion de Inventario Actual")
    End Sub

    Private Sub bt_imprimir_etiquetas_Click(sender As Object, e As EventArgs) Handles bt_imprimir_etiquetas.Click
        If tx_id_rp.Text = "" Then
            Exit Sub
        End If
        cargar_info_rp()
        'If tx_cant_produccion.Text = 0 Then
        'Exit Sub
        'End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_impresion_etiquetas As New camocontrol.fm_0400_impresion_etiquetas
        'oform_grilla_programacion.ods_hijo = ods
        oform_impresion_etiquetas.vf_oform_padre = Me
        oform_impresion_etiquetas.vg_id_cia = vg_id_cia
        oform_impresion_etiquetas.vg_usuario_autoriza = vg_usuario_autoriza
        oform_impresion_etiquetas.generada = "PPROS"
        oform_impresion_etiquetas.id_item = id_item
        oform_impresion_etiquetas.id_ipp = id_ipp
        oform_impresion_etiquetas.id_rp = "RP-" & id_rp
        oform_impresion_etiquetas.fecha_produccion = dtp_fecha.Value
        oform_impresion_etiquetas.fecha_vencimiento = dtp_fecha_vencimiento.Value
        oform_impresion_etiquetas.lote = tx_lote.Text
        oform_impresion_etiquetas.bt_calcular_lote.Enabled = False
        oform_impresion_etiquetas.ShowDialog()
    End Sub
    Private Sub bt_cambiar_infraestructura_Click(sender As Object, e As EventArgs) Handles bt_cambiar_infraestructura.Click
        verror_requisitos = "N"
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
            Exit Sub
        End If
        Dim id_nueva_estructura As String = id_estructura.ToString
        id_nueva_estructura = cl_utilidades_gestion_mantenimiento.suministrar_estructura_mantenimiento(vg_id_cia, vg_usuario_autoriza, id_estructura)
        Dim id_estructura_anterior As Integer = id_estructura
        If id_estructura.ToString <> id_nueva_estructura Then
            id_estructura = id_nueva_estructura
            tx_estructura.Text = comunes.traer_nombre_estructura(id_nueva_estructura)
        End If
    End Sub
    Private Sub bt_calcular_lote_Click(sender As Object, e As EventArgs) Handles bt_calcular_lote.Click
        tx_lote.Text = DatePart(DateInterval.DayOfYear, dtp_fecha.Value) _
            & DatePart(DateInterval.Month, dtp_fecha.Value).ToString.PadLeft(2, "0") _
            & dtp_fecha.Value.ToString("yy")
    End Sub

    Private Sub dtp_h_fin_programada_Validating(sender As Object, e As CancelEventArgs) Handles dtp_h_fin_programada.Validating
        dtp_h_fin_programada.Value = CDate(dtp_h_fin_programada.Value.ToString("yyyy/MM/dd HH:mm"))
        calcular_h_maquina_programadas()
        calcular_produccion_esperada()
    End Sub

    Private Sub dtp_h_ini_programada_Validating(sender As Object, e As CancelEventArgs) Handles dtp_h_ini_programada.Validating
        dtp_h_ini_programada.Value = CDate(dtp_h_ini_programada.Value.ToString("yyyy/MM/dd HH:mm"))
        calcular_h_maquina_programadas()
        calcular_produccion_esperada()
    End Sub

    Private Sub cm_estandar_productivo_Validating(sender As Object, e As CancelEventArgs) Handles cm_estandar_productivo.Validating
        If cm_estandar_productivo.SelectedIndex = -1 Then
            MsgBox("No valido")
            cm_estandar_productivo.SelectedValue = id_estandar_productivo
            Exit Sub
        End If
        calcular_produccion_esperada()
        calcular_indicadores_productivos()
    End Sub

End Class
