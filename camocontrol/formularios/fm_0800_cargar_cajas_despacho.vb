Public Class fm_0800_cargar_cajas_despacho
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
    Public cargue_bloqueado As String = "N"

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private otb_items_remisiones As DataTable
    Private otb_info_estibas As DataTable
    Private otb_info_una_estiba As DataTable
    Private otb_etiq_busc As DataTable
    Private modo_eliminacion As String = "N"
    Private fila_seleccionada As Integer
    Private oestado_cargue As String = "i" 'i=incompleto, c=completo, p=cargue de mas
    Private id_estiba_actual As Integer = 1



    Private Sub fm_0800_cargar_cajas_despacho_Load(sender As Object, e As EventArgs) Handles Me.Load

        bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_g_archivos.Enabled = False
        bt_g_notas.Enabled = False
        bt_generar_informe.Enabled = False
        bt_grabar.Enabled = False
        bt_nuevo.Enabled = False
        chk_eliminar_cajas.Enabled = False

        dg_items_rms.AllowUserToAddRows = False
        dg_items_rms.AllowUserToDeleteRows = False
        dg_items_rms.AllowUserToResizeColumns = True
        dg_items_rms.AllowUserToResizeRows = False
        dg_items_rms.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_items_rms.DefaultCellStyle.Font = New Font("Tahoma", 20)
        dg_items_rms.RowTemplate.Height = 40

        'tx_id_caja.Focus()
        cargar_dg_items()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cargar_info_estiba(1)
        cargar_info_todas_estibas(id_despacho)
    End Sub
    Private Sub cargar_info_estiba(ByVal id_estiba As Integer)
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-23", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        csql = csql.Replace("$002$", id_estiba)
        otb_info_una_estiba = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim Tot_Cajas As Integer
        Dim Tot_Productos As Integer
        For Each orow As DataRow In otb_info_una_estiba.Rows
            Tot_Cajas = CDec(orow("cantcajas"))
            Tot_Productos = CDec(orow("cantprod"))
        Next
        tx_num_estiba.Text = id_estiba
        tx_num_items_estiba.Text = Tot_Productos
        tx_unid_estiba.Text = Tot_Cajas
    End Sub
    Private Sub cargar_info_todas_estibas(ByVal id_despacho As Integer)
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-22", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        otb_info_estibas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim TotCajasEstiba As Integer
        Dim TotProductosEstiba As Integer
        Dim UltimaEstiba As Integer
        'For Each orow As DataRow In otb_info_estibas.Rows
        'Tot_Cajas = Tot_Cajas + CDec(orow("cant"))
        'Next

        If otb_info_estibas.Rows.Count > 0 Then
            UltimaEstiba = otb_info_estibas.AsEnumerable().Max(Function(oorow) oorow.Field(Of Int32)("f0421_estiba"))
            tx_num_estiba.Text = UltimaEstiba
            TotCajasEstiba = otb_info_estibas.Compute("Sum(cant)", "f0421_estiba = " & UltimaEstiba)
        Else
            MsgBox("No hay pistoleos")
        End If

        Dim aaaa = otb_info_estibas.AsEnumerable().GroupBy(keySelector:=Function(oorow) oorow.Field(Of String)("f0300_referencia"))

        Dim aaa As IEnumerable(Of DataRow) = From oorw In otb_info_estibas
                                             Where oorw("f0421_estiba") = UltimaEstiba And oorw("cant") >= 10
                                             Select oorw


        Dim aa As IEnumerable(Of DataRow) = otb_info_estibas.AsEnumerable.Where(Function(ow) ow("cant") >= 10)

        Dim oaaa As Integer = aaa.Sum(Function(a) a("cant"))

        MsgBox(aa.Count)

                               MsgBox(TotCajasEstiba)
    End Sub
    Private Sub cargar_dg_items()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-05", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        otb_items_remisiones = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_items_rms.DataSource = otb_items_remisiones

        Dim unid_ped As Decimal = 0
        Dim unid_car As Decimal = 0
        Dim odiferencia As Decimal = 0
        Dim oestado As Integer = 0
        For Each orow As DataRow In otb_items_remisiones.Rows
            unid_ped += CDec(orow("ped"))
            unid_car += CDec(orow("car"))
            odiferencia = unid_ped - unid_car
            Select Case odiferencia
                Case < 0
                    oestado = 1
                    'Me.BackColor = Color.HotPink
                Case > 0
                    If oestado <> 1 Then
                        oestado = 2
                    End If
                    'Me.BackColor = Color.Yellow
            End Select
            If CDec(orow("ped")) = 0 Then
                oestado = 1
            End If
        Next
        Select Case oestado
            Case 0
                Me.BackColor = Color.Lime
            Case 1
                Me.BackColor = Color.HotPink
            Case 2
                Me.BackColor = Color.Yellow
        End Select

        tx_unidades_solicitadas.Text = unid_ped
        tx_unidades_despachadas.Text = unid_car
        tx_unidades_pendientes.Text = CDec(unid_ped - unid_car)
        dg_items_rms.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dg_items_rms.Columns("ped").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Alineado a la derecha
        dg_items_rms.Columns("car").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Alineado a la derecha

        tx_id_caja.Focus()
    End Sub

    Private Sub dg_items_rms_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_items_rms.CellFormatting
        ' If the column is the Artist column, check the
        ' value.
        If dg_items_rms.Columns(e.ColumnIndex).Name = "car" Then
            If e.Value IsNot Nothing Then
                Dim cant_ped As Integer = dg_items_rms.Rows.Item(e.RowIndex).Cells("ped").Value
                Dim cant_car As Integer = e.Value
                Dim odif As Integer = cant_ped - cant_car
                Select Case odif
                    Case 0
                        e.CellStyle.BackColor = Color.Green
                    Case Is > 0
                        e.CellStyle.BackColor = Color.Yellow
                    Case Is < 0
                        e.CellStyle.BackColor = Color.Red
                        'Me.BackColor = Color.HotPink
                End Select
            End If
        End If
        tx_id_caja.Focus()
    End Sub

    Private Sub tx_id_caja_KeyDown(sender As Object, e As KeyEventArgs) Handles tx_id_caja.KeyDown
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            'e.Handled = True
            If cargue_bloqueado = "S" Then
                MsgBox("Informacion bloqueada", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If modo_eliminacion = "N" Then
                registrar_caja(tx_id_caja.Text, id_estiba_actual)
                cargar_dg_items()
            Else
                eliminar_una_sola_caja()
                cargar_dg_items()
            End If
            tx_id_caja.Focus()
            tx_id_caja.Text = ""
        End If
    End Sub

    Private Sub registrar_caja(ByVal id_caja As String, ByVal id_estiba As Integer)
        Dim id_prod_etiqueta As String = ""
        Dim vasigna As String = "N"
        Dim otro_prod As String = "S"
        If id_caja.Trim = "" Or IsNumeric(id_caja) = False Then
            Exit Sub
        End If

        'csql = "select *" _
        '    & " from " & database.obtener_esquema & ".fnc_400_07_asignar_etiqueta_pt_despacho4(" _
        '        & id_caja & ", " & id_despacho & ", " & id_estiba & ", '" & vg_usuario_autoriza & "')"
        csql = "select *" _
            & " from " & database.obtener_esquema & ".fnc_400_07_asignar_etiqueta_pt_despacho(" _
                & id_caja & ", " & id_despacho & ", " & id_estiba & ", '" & vg_usuario_autoriza & "')"
        otb_etiq_busc = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'MsgBox(otb_etiq_busc.Columns.Count)
        Dim etiq_busc As String = vbEmpty
        Dim tnedatos As String = "N"
        For Each orow As DataRow In otb_etiq_busc.Rows
            If IsDBNull(orow(0)) = False Then
                etiq_busc = orow(0).trim()
                If etiq_busc = "NE" Then
                    MsgBox("la etiqueta no existe")
                End If
                If Mid(etiq_busc, 1, 2) = "DE" Then
                    'MsgBox("hola")
                    'No sacar mensaje para cajas del mismo despacho.
                    'If "DE-" & id_despacho.ToString.PadLeft(8, "0") <> etiq_busc Then
                    If "DE-" & id_despacho.ToString <> etiq_busc Then
                        MsgBox(id_caja & ": Caja cargada en el despacho: " & etiq_busc)
                    End If
                End If
            Else
                tnedatos = "S"
            End If
        Next
        If tnedatos = "S" Then
            'temporal()
        End If
    End Sub
    Private Sub temporal()
        Dim UltimaEstiba As Integer = otb_etiq_busc.AsEnumerable().Max(Function(oorow) oorow.Field(Of Int32)("id_estib"))

        Dim aaaa = otb_etiq_busc.AsEnumerable().GroupBy(keySelector:=Function(oorow) oorow.Field(Of String)("ref_cg"))

        Dim query = From row In otb_etiq_busc.AsEnumerable()
                    Group row By OrefCg = row.Field(Of String)("ref_cg") Into RefGroup = Group
                    Select New With {
                        Key OrefCg,
                            .pedi = RefGroup.Sum(Function(r) r.Field(Of Int32)("pedi")),
                            .carg = RefGroup.Sum(Function(r) r.Field(Of Int32)("carg"))
                        }

        Dim QuryEstibas = otb_etiq_busc.AsEnumerable().GroupBy(Function(A) New With {
                                                               Key .Estiba = A.Field(Of Int32)("id_estib"),
                                                               Key .ProdEstiba = A.Field(Of String)("ref_cg")})

        QuryEstibas = QuryEstibas.OrderByDescending(Function(B) B.Key.Estiba)

        Dim otb_estibas As New DataTable
        Dim column As DataColumn

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        otb_estibas.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "QtyCajas"
        otb_estibas.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "QtyProd"
        otb_estibas.Columns.Add(column)

        Dim RowEst As DataRow
        For Each x In QuryEstibas
            RowEst = otb_estibas.NewRow()
            RowEst("id") = x.Key.Estiba
            RowEst("QtyCajas") = x.Sum(Function(y) y.Field(Of Int32)("carg"))
            RowEst("QtyProd") = x.Count(Function(y) y.Field(Of Int32)("ref_cg"))
            otb_estibas.Rows.Add(RowEst)
        Next


        Dim query2 = otb_etiq_busc.AsEnumerable().GroupBy(Function(orow) New With {
                                                          Key .Oref = orow.Field(Of String)("ref_cg"),
                                                          Key .Prod = orow.Field(Of String)("producto")})
        query2 = query2.OrderBy(Function(z) z.Key.Prod)


        Dim otb As New DataTable

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "id"
        otb.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "producto"
        otb.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "pedido"
        otb.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "cargado"
        otb.Columns.Add(column)

        Dim ooorow As DataRow
        For Each x In query2
            ooorow = otb.NewRow()
            ooorow("id") = x.Key.Oref
            ooorow("producto") = x.Key.Prod
            ooorow("pedido") = x.Sum(Function(y) y.Field(Of Int32)("pedi"))
            ooorow("cargado") = x.Sum(Function(y) y.Field(Of Int32)("carg"))
            otb.Rows.Add(ooorow)
        Next
        MsgBox(otb.Rows.Count)

        MsgBox(UltimaEstiba)
    End Sub
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmenustrip.Opening
        If dg_items_rms.Rows.Count < 1 Then
            Exit Sub
        End If
        If dg_items_rms.Columns(dg_items_rms.CurrentCell.ColumnIndex).Name = "car" Then
            cmenustrip.Enabled = True
        Else
            cmenustrip.Enabled = False
        End If
    End Sub

    Private Sub cm_mi_limpiar_Click(sender As Object, e As EventArgs) Handles cm_mi_limpiar.Click
        If cargue_bloqueado = "S" Then
            MsgBox("Informacion bloqueada", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If modo_eliminacion = "N" Then
            MsgBox("Para eliminar debe inicializar el modo eliminacion!", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Pregunta si realmente desea limpiar todos los datos
        Dim respuesta As String = "N"
        Dim id_producto As String = dg_items_rms.CurrentRow.Cells(0).Value
        respuesta = comunes.g_mensaje_YesNo("Borrar Datos", "Desea eliminar las unidades registradas?")
        If respuesta = "N" Then
            Exit Sub
        End If
        liberar_cajas_registradas_producto(id_producto)
        modo_eliminacion = "N"
        chk_eliminar_cajas.Enabled = False
        tx_id_caja.BackColor = Color.White
    End Sub

    Private Sub cm_mi_limpiar_todo_Click(sender As Object, e As EventArgs) Handles cm_mi_limpiar_todo.Click
        If cargue_bloqueado = "S" Then
            MsgBox("Informacion bloqueada", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If modo_eliminacion = "N" Then
            MsgBox("Para eliminar debe inicializar el modo eliminacion!", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Pregunta si realmente desea limpiar todos los datos
        Dim respuesta As String = "N"
        Dim id_producto As String = dg_items_rms.CurrentRow.Cells(0).Value
        respuesta = comunes.g_mensaje_YesNo("Borrar Datos", "Desea eliminar TODAS las unidades registradas de TODOS los productos?")
        If respuesta = "N" Then
            Exit Sub
        End If
        liberar_todas_cajas_registradas_todos_productos()
        modo_eliminacion = "N"
        chk_eliminar_cajas.Enabled = False
        tx_id_caja.BackColor = Color.White
    End Sub

    Private Sub cm_mi_ver_datos_Click(sender As Object, e As EventArgs) Handles cm_mi_ver_datos.Click
        Dim id_producto As String = dg_items_rms.CurrentRow.Cells(0).Value
        cl_utilidades_datatables.visualizar_datos_visor("ST-0800-06", vg_id_cia, vg_usuario_autoriza,
                                                            "Unidades Despachadas", {id_despacho, id_producto})
    End Sub

    Private Sub liberar_cajas_registradas_producto(ByVal id_producto As String)
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        csql = csql.Replace("$002$", id_producto)
        cl_utilidades_datatables.ejecutar_csql(csql)
        cargar_dg_items()
        MsgBox("Realizado", MsgBoxStyle.Information, "Info")
    End Sub

    Private Sub liberar_todas_cajas_registradas_todos_productos()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-09", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        cl_utilidades_datatables.ejecutar_csql(csql)
        cargar_dg_items()
        MsgBox("Realizado", MsgBoxStyle.Information, "Info")
    End Sub

    Private Sub bt_eliminar_caja_Click(sender As Object, e As EventArgs) Handles bt_eliminar_caja.Click
        'Pregunta si realmente desea limpiar todos los datos
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Borrar Datos", "Desea eliminar unidades ya registradas?")
        If respuesta = "N" Then
            Exit Sub
        End If
        chk_eliminar_cajas.Enabled = True
    End Sub

    Private Sub eliminar_una_sola_caja()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-08", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        csql = csql.Replace("$002$", tx_id_caja.Text)
        cl_utilidades_datatables.ejecutar_csql(csql)
        cargar_dg_items()
        MsgBox("Realizado", MsgBoxStyle.Information, "Info")
    End Sub

    Private Sub chk_eliminar_cajas_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles chk_eliminar_cajas.Validating
        If chk_eliminar_cajas.Checked = True Then
            MsgBox("Modo de eliminacion inicializado", MsgBoxStyle.Critical, "Info")
            modo_eliminacion = "S"
            bt_eliminar_caja.Enabled = False
            tx_id_caja.BackColor = Color.Red
        Else
            modo_eliminacion = "N"
            chk_eliminar_cajas.Enabled = False
            bt_eliminar_caja.Enabled = True
            tx_id_caja.BackColor = Color.White
        End If
    End Sub

    Private Sub bt_importar_plano_Click(sender As Object, e As EventArgs) Handles bt_importar_plano.Click
        'Identifico la configuracion existentes para importacion del plano
        Dim id_file_plano As String = "INF_TRAZABILIDAD"

        'MsgBox(id_file_plano)
        'Importo las tablas encabezado y detalle generadas de la importacion del plano
        Dim otables() As DataTable = cl_gestion_arch_planos.importar_plano_a_datatable(id_file_plano, vg_id_cia, vg_usuario_autoriza)
        Dim otb_encabezado As DataTable = otables(1)
        Dim otb_detalle As DataTable = otables(2)

        If IsNothing(otb_detalle) = True Then
            MsgBox("Sin datos", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Actualizo la informacion en la base de datos de acuerdo a la informacion del archivo plano.
        For Each orow As DataRow In otb_detalle.Rows
            If cargue_bloqueado = "S" Then
                MsgBox("Informacion bloqueada", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If modo_eliminacion = "N" Then
                registrar_caja(orow("codigo").ToString.PadLeft(8, "0"), id_estiba_actual)
            End If
        Next
        cargar_dg_items()

        'MsgBox("Encabezado: " & otb_encabezado.Rows.Count & " Detalle: " & otb_detalle.Rows.Count)
    End Sub

End Class
