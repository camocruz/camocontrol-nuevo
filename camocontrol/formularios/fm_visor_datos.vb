Imports System.ComponentModel
Public Class fm_visor_datos
    'Objetos publicos que reciben valores desde el Formulario padre

    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"

    'Private$vf_otabla_permisos$As DataTable

    Public csql As String = ""
    Public titulo_formulario As String = ""
    Public formulariodeseleccion As String = "N"
    Public seleccionmultiple As String = "S"

    '$Public$vg_id_cia As String = ""
    Public P_exportar As String = "S"
    Public id_tercero As String
    Public id_estructura As Integer
    Public id_accion As Integer
    Public id_oreg_padre As String 'para usarlo genericamente almacenando un valor
    Public ovalue As String 'para usarlo genericamente almacenando un valor
    Public otipo_nota As String = ""
    Public otb_datos_pasar As DataTable 'Para almacenar una datatable que sera pasada al formulario que abra.
    Public oarray_var As String() 'variable usar almacenando un arreglo de string
    Public otb_datos_checbox_selec As DataTable
    Public agregar_checkboxcolumn As String = "N"
    Public name_colum_id As String = ""

    Private nombre_columna_desecadenadora As String 'El nombre de la columna en que hago doble click
    Private DD As String = "N" 'indica que un indice o dato ya fue desplegado
    Private fila_actual As Integer 'fila actualmente activa en el datagrid

    Public otb_datos As DataTable 'Los datos que mostrara el formulario
    Private dw_datos As DataView
    Public dv_filter As String = ""
    Private filtro_inicial As String = "N"
    Private conta_filtros As Integer = 0
    Private txt_operador As String = ""
    Private otb_datos_desplegados As New DataTable

    Private Sub fm_visor_datos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        'vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        'Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        'cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_nuevo, ocontexto_form)

        ToolTip1.SetToolTip(bt_nuevo, "Nuevo Registro")
        ToolTip1.SetToolTip(bt_filtrar, "Aplicar Filtro")
        ToolTip1.SetToolTip(bt_quitar_filtro, "Quitar Filtro")
        ToolTip1.SetToolTip(bt_recargar_todo, "Recargar Todo")

        dg_datos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        If P_exportar = "S" Or vg_usuario_autoriza = "00000001" Then
            dg_datos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Else
            dg_datos.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable
            bt_exportar_csv.Enabled = False
            bt_exportar_excel.Enabled = False
        End If



        If csql <> "" Then
            otb_datos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        End If
        ' Para cuando los datos que se cargaran ya tienen un filtro inicial
        If dv_filter <> "" Then
            filtro_inicial = "S"
            filtrar_datos()
            'Para que la columna salga mas ancha
            Dim ColAncha As String = Split(dv_filter, " ")(0)
            'MsgBox(ColAncha)
            dg_datos.Columns.Item(ColAncha).Width = 400
        Else
            dg_datos.DataSource = otb_datos
        End If



        dg_datos.Focus()
        lb_titulo.Text = titulo_formulario
        cm_operadores_filtro.SelectedIndex = 0
        lb_total_registros.Text = dg_datos.Rows.Count

        Dim workCol As DataColumn = otb_datos_desplegados.Columns.Add(
            "id_desplegado", Type.GetType("System.Int32"))
        workCol.AllowDBNull = False
        workCol.Unique = True

        'Para habilitar la columna checkboxcolumn
        bt_checkbox.Enabled = False
        If agregar_checkboxcolumn = "S" Then
            'activo el boton que prosesa la informacion checbox
            bt_checkbox.Enabled = True
            'Activo la columna que habilita el checkbox
            'dg_datos.Columns.Clear()
            Dim Obj As New DataGridViewColumn
            Dim Col As New DataGridViewCheckBoxColumn
            Obj = Col
            Obj.HeaderText = "Check" ' el texto que ira en la cabecera
            Obj.Name = "dgocell_checkbox" ' Nombre de la Columna de la Grilla
            Obj.Width = 50
            dg_datos.Columns.Add(Obj)
            dg_datos.Columns(dg_datos.Columns.Count - 1).DisplayIndex = 0 ' Es para que la columna sea la primera en la grilla

            dg_datos.ReadOnly = False ' Esto para que toda la grilla sea editable
            'dg_datos.DataSource = Nothing ' al inicio no va ningun enlaze de datos

            ' Este for es para que solo sea editable el checkbox de la grilla es decir poder hacerle click
            For ocol As Integer = 0 To dg_datos.Columns.Count - 1
                If dg_datos.Columns(ocol).Name = "dgocell_checkbox" Then
                    dg_datos.Columns(ocol).ReadOnly = False
                Else
                    dg_datos.Columns(ocol).ReadOnly = True
                End If
            Next
        End If
    End Sub
    Public Sub recargar_datos()
        Dim oldColumn As DataGridViewColumn = dg_datos.SortedColumn
        Dim index_oldColumn As Integer
        Dim direction As ListSortDirection
        If oldColumn IsNot Nothing Then
            index_oldColumn = dg_datos.SortedColumn.Index
            If dg_datos.SortOrder = SortOrder.Ascending Then
                direction = ListSortDirection.Ascending
            Else
                direction = ListSortDirection.Descending
            End If
        End If
        otb_datos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If dv_filter <> "" Then
            Dim dv_datos As New DataView(otb_datos)
            Try
                dv_datos.RowFilter = dv_filter
            Catch ex As Exception
                MsgBox("El filtro no se puede procesar" + vbCrLf + ex.ToString, MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try
            'dv_datos.RowFilter = tx_nombre_campo.Text & " LIKE '00%'"
            dg_datos.DataSource = dv_datos
            tx_nombre_campo.Text = ""
            tx_valor_campo.Text = ""
            cm_operadores_filtro.SelectedIndex = 0
            lb_total_registros.Text = dv_datos.Count
            tx_registro_seleccionado.Text = ""
        Else
            dg_datos.DataSource = otb_datos
        End If
        lb_total_registros.Text = dg_datos.Rows.Count
        Try
            vf_oform_padre.vf_tot_notas = dg_datos.Rows.Count
        Catch ex As Exception

        End Try

        If oldColumn IsNot Nothing And nombre_columna_desecadenadora <> "" Then
            dg_datos.Sort(dg_datos.Columns(index_oldColumn), direction)
            If direction = ListSortDirection.Ascending Then
                dg_datos.Columns(index_oldColumn).HeaderCell.SortGlyphDirection = SortOrder.Ascending
            Else
                dg_datos.Columns(index_oldColumn).HeaderCell.SortGlyphDirection = SortOrder.Descending
            End If
        End If
        If dg_datos.Rows.Count > 0 Then
            'Para dejar seleccionado el mismo elemento que se abrio
            dg_datos.FirstDisplayedScrollingRowIndex = fila_actual
            dg_datos.CurrentCell = dg_datos.Rows.Item(fila_actual).Cells(0)
        End If
    End Sub
    Private Sub bt_checkbox_Click(sender As Object, e As EventArgs) Handles bt_checkbox.Click
        entregar_datos_seleccionados()
    End Sub
    Private Sub entregar_datos_seleccionados()
        otb_datos_checbox_selec = New DataTable
        ' Create typed columns in the DataTable.
        otb_datos_checbox_selec.Columns.Add(name_colum_id, GetType(String))
        'Lleno el datatable con los datos seleccionados
        For Each orow As DataGridViewRow In dg_datos.Rows
            If orow.Cells("dgocell_checkbox").Value = True Then
                otb_datos_checbox_selec.Rows.Add(orow.Cells(name_colum_id).Value)
                'actualizar_tercero_orden_compra(orow.Cells(name_colum_id).Value, id_tercero)
            End If
        Next

        Me.Hide()
    End Sub
    Private Sub dg_datos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_datos.CellClick
        If dg_datos.Rows.Count = 0 Then
            Exit Sub
        End If
        'MsgBox("hola")
        ' el problema consiste en que si no pongo este codigo al hacer click en un checkbox de la grilla este no cambiara a true hasta que otro checkbox sea clickeado o se haga click en la celda de la grilla
        If dg_datos.Columns(dg_datos.CurrentCell.ColumnIndex).Name = "dgocell_checkbox" Then
            'MsgBox("holalll" & seleccionmultiple)

            'If e.RowIndex < 0 Or Not e.ColumnIndex = 0 Then Exit Sub
            'If Convert.ToBoolean(dg_datos.Rows(e.RowIndex).Cells(0).Value) = False Then
            'MsgBox(Convert.ToBoolean(dg_datos.CurrentCell.Value).ToString)
            'If Convert.ToBoolean(dg_datos.Rows(e.RowIndex).Cells(0).Value) = False Then
            If Convert.ToBoolean(dg_datos.CurrentCell.Value) = True Then
                'dg_datos.Rows(e.RowIndex).Cells(0).Value = False
                dg_datos.CurrentCell.Value = False
                'MsgBox("coloca falso")
            Else
                'dg_datos.Rows(e.RowIndex).Cells(0).Value = True
                dg_datos.CurrentCell.Value = True
                'MsgBox("coloca verdadero")
            End If
            If seleccionmultiple = "N" Then
                'para cuando voy a usar el formulario solo para seleccionar un unico dato
                entregar_datos_seleccionados()
            End If
            'si es la columna checkbox no puedo realizar las acciones siguientes
            Exit Sub
        End If
        tx_valor_campo.Text = dg_datos.CurrentCell.Value.ToString.Trim
        tx_nombre_campo.Text = dg_datos.Columns(dg_datos.CurrentCell.ColumnIndex).Name
        tx_registro_seleccionado.Text = dg_datos.CurrentRow.Index + 1
    End Sub
    Private Sub dg_datos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_datos.CellDoubleClick
        ejecutar_accion()
    End Sub
    Private Sub dg_datos_MouseClick(sender As Object, e As MouseEventArgs) Handles dg_datos.MouseClick

        'Para realizar acciones dependiendo del contecto del formulario..
        Select Case ocontexto_form
            Case "salida de insumos de almacen desde una actividad"
                Dim nombre_columna As String = dg_datos.Columns(dg_datos.CurrentCell.ColumnIndex).Name
                Select Case nombre_columna
                    Case "id_doc_inv"
                        If e.Button = MouseButtons.Right Then
                            Dim menu = New System.Windows.Forms.ContextMenuStrip()
                            Dim posrow = dg_datos.HitTest(e.X, e.Y).RowIndex
                            Dim poscol = dg_datos.HitTest(e.X, e.Y).ColumnIndex

                            If posrow > -1 Then
                                menu.Items.Add("Modificar").Name = "Modificar" & posrow
                                menu.Items.Add("Mostrar").Name = "Mostrar" & posrow
                            End If
                            menu.Show(dg_datos, e.X, e.Y)
                            'dg_datos.Rows.Item(posicion).Selected = True
                            'dg_datos.Rows.Item(posrow).Cells.Item(poscol).Selected = True
                            'MsgBox(poscol)


                            AddHandler menu.ItemClicked, AddressOf menuClic
                        End If
                    Case Else
                        ' Coloca algo
                End Select
        End Select
    End Sub

    Private Sub menuClic(sender As Object, e As ToolStripItemClickedEventArgs)
        Dim nombre = e.ClickedItem.Name.ToString
        Dim documento = dg_datos.CurrentCell.Value.ToString.Trim
        'Verifico si el documento existe
        Dim otb_docto As DataTable
        Dim csql As String = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                             & " where f0310_anulado = 'N' and f0310_id_documento = '" & documento & "'"
        otb_docto = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_docto.Rows.Count = 0 Then
            Exit Sub
        End If
        If nombre.Contains("Mostrar") Then
            ejecutar_accion()
        End If
        If nombre.Contains("Modificar") Then

            Dim permiso As String
            permiso = cl_gestion_permisos.identificar_un_permiso_especial_usuario("MOD-SAL-ALM-MTO", vg_usuario_autoriza)

            If permiso = "S" Then
                cl_utilidades_gestion_compras.habilitar_documento(documento, vg_usuario_autoriza)

                cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(documento,
                                                                                  vg_usuario_autoriza,
                                                                                  vg_id_cia,
                                                                                  "N", "S", "D")
            Else
                MsgBox("No cuenta con los permisos para modificar una salida de almacen",, "Denegado")
            End If


        End If
    End Sub

    Private Sub dg_datos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dg_datos.CellEnter
        If dg_datos.Columns(dg_datos.CurrentCell.ColumnIndex).Name = "dgocell_checkbox" Then
            Exit Sub
        End If
        Try
            tx_valor_campo.Text = dg_datos.CurrentCell.Value.ToString.Trim
        Catch ex As Exception

        End Try

        tx_nombre_campo.Text = dg_datos.Columns(dg_datos.CurrentCell.ColumnIndex).Name
        tx_registro_seleccionado.Text = dg_datos.CurrentRow.Index + 1

    End Sub

    Private Sub dg_datos_KeyDown(sender As Object, e As KeyEventArgs) Handles dg_datos.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            ejecutar_accion()
        End If
        If (e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control) Then
            'PARA USAR CUANDO EL FORMULARIO ES PARA SELECCIONAR UN DATO
            'MsgBox(dg_datos.CurrentRow.Cells("id_sc").Value)
        End If
        If e.KeyCode = Keys.Tab Then
            'No uso este porque al usar la tecla enter tambien se interpreta como tab ????
            'MsgBox("Tab")
        End If
        If (e.KeyCode = Keys.B AndAlso e.Modifiers = Keys.Control) Then
            'PARA USAR CUANDO EL FORMULARIO ES PARA SELECCIONAR UN DATO
            'MsgBox(dg_datos.CurrentRow.Cells("id_sc").Value)
            cm_operadores_filtro.Select()
        End If
        If (e.KeyCode = Keys.F10) Then
            Dispose()
        End If

    End Sub
    Private Sub dg_datos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dg_datos.KeyPress
        'ESTOY USANDO MEJOR EL EVENTO KEYDOWN PARA SABER QUE TECLA PRESIONE. EL EVENTO KEYPRESS EMPIEZA  A SER OBSOLETO
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
        'ejecutar_accion()
        'MsgBox("Tecla enter" & " " & dg_datos.Columns(dg_datos.CurrentCell.ColumnIndex).Name)
        'End If
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

    Private Sub ejecutar_accion()
        Dim nombre_columna As String = dg_datos.Columns(dg_datos.CurrentCell.ColumnIndex).Name
        If nombre_columna = "dgocell_checkbox" Then
            'no debe hacer nada porque es la columna checkbox
            Exit Sub
        End If
        If dg_datos.Rows.Count = 0 Or dg_datos.CurrentCell.Value.ToString = "" Then
            Exit Sub
        End If
        Select Case nombre_columna
            Case "id_struc"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_estructura As New camocontrol.fm_0100_elemento_estructura_mantenimiento
                oform_estructura.vf_oform_padre = Me
                oform_estructura.vg_id_cia = vg_id_cia
                oform_estructura.id_estructura = dg_datos.CurrentCell.Value
                oform_estructura.vg_usuario_autoriza = vg_usuario_autoriza
                oform_estructura.vf_elemento_nuevo = "N"
                oform_estructura.ShowDialog()
                recargar_datos()
            Case "id_ausnt"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_ausentismo As New camocontrol.fm_0023_01_ausentismo
                oform_ausentismo.vf_oform_padre = Me
                oform_ausentismo.vg_id_cia = vg_id_cia
                oform_ausentismo.id_ausnt = dg_datos.CurrentCell.Value
                oform_ausentismo.vg_usuario_autoriza = vg_usuario_autoriza
                oform_ausentismo.vf_elemento_nuevo = "N"
                oform_ausentismo.ShowDialog()
                recargar_datos()
            Case "id_prog_prod"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_prog_prod As New camocontrol.fm_0400_pp_progamas_produccion
                oform_prog_prod.vf_oform_padre = Me
                oform_prog_prod.vg_id_cia = vg_id_cia
                oform_prog_prod.id_prog_prod = dg_datos.CurrentCell.Value
                oform_prog_prod.vg_usuario_autoriza = vg_usuario_autoriza
                oform_prog_prod.vf_elemento_nuevo = "N"
                oform_prog_prod.ShowDialog()
                recargar_datos()
            Case "id_rp"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'cl_utilidades_gestion_produccion.desplegar_item_prog_prod(vg_id_cia, vg_usuario_autoriza, "RP-" & dg_datos.CurrentCell.Value)
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_reporte_produccion As New camocontrol.fm_0400_rp_reporte_produccion
                oform_reporte_produccion.vf_oform_padre = Me
                '''''oform_reporte_produccion.vf_var_config_notas = "TN-RPD-001"
                ''''oform_reporte_produccion.vf_var_config_archivos = "CD-RPD"
                oform_reporte_produccion.vf_id_notas_archivos = dg_datos.CurrentCell.Value
                oform_reporte_produccion.vg_id_cia = vg_id_cia
                oform_reporte_produccion.vg_usuario_autoriza = vg_usuario_autoriza
                oform_reporte_produccion.id_rp = dg_datos.CurrentCell.Value
                oform_reporte_produccion.vf_elemento_nuevo = "N"
                oform_reporte_produccion.ShowDialog()
                recargar_datos()
            Case "id_item"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_item As New camocontrol.fm_0300_gestion_items
                oform_item.vf_oform_padre = Me
                oform_item.vg_id_cia = vg_id_cia
                oform_item.cerrar_al_actualizar = "S"
                oform_item.id_item = dg_datos.CurrentCell.Value
                oform_item.vg_usuario_autoriza = vg_usuario_autoriza
                oform_item.vf_elemento_nuevo = "N"
                oform_item.ShowDialog()
                recargar_datos()
            Case "id_salm"
                'Esta opcion abre directamente el reporte de solicitud de almacen.
                Dim id_doc As String()
                id_doc = dg_datos.CurrentCell.Value.ToString.Split("-")
                cl_informes_comunes.reporte_solicitud_almacen(vg_id_cia, id_doc(1), 1)
            Case "id_soalcc"
                'Esta opcion abre directamente el reporte de solicitud de almacen.
                cl_informes_comunes.reporte_solicitud_almacen(vg_id_cia, dg_datos.CurrentCell.Value, 2)
            Case "id_itsalm"
                'esta opcion para manejar los eventos con los items de las solicitudes de almacen.
                If ocontexto_form = "exportar_datagridviewrow" Then
                    'oculto el formulario para que la funcion cl_utilidades_datatables.suministrar_datagridviewrow_visor 
                    'tome el datagridviewrow activo.
                    Me.Hide()
                End If
            Case "id_fcc"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_factura_compra As New camocontrol.fm_0300_facturas_compras
                oform_factura_compra.vf_oform_padre = Me
                oform_factura_compra.vg_id_cia = vg_id_cia
                'oform_factura_compra.vf_var_config_notas = "TN-FCP-001"
                'oform_factura_compra.vf_var_config_archivos = "CD-FCC"
                oform_factura_compra.vf_id_notas_archivos = dg_datos.CurrentCell.Value
                oform_factura_compra.id_factura_compras = dg_datos.CurrentCell.Value
                oform_factura_compra.vg_usuario_autoriza = vg_usuario_autoriza
                oform_factura_compra.vf_elemento_nuevo = "N"
                oform_factura_compra.Show() 'Para que no sea un formulario modal
                recargar_datos()
            Case "docto_origen"
                If Microsoft.VisualBasic.Left(dg_datos.CurrentCell.Value, 4) = "FCP-" Then
                    'agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                    'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                    'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                    Dim oform_factura_compra As New camocontrol.fm_0300_facturas_compras
                    oform_factura_compra.vf_oform_padre = Me
                    oform_factura_compra.vg_id_cia = vg_id_cia
                    'oform_factura_compra.vf_var_config_notas = "TN-FCP-001"
                    'oform_factura_compra.vf_var_config_archivos = "CD-FCC"
                    oform_factura_compra.vf_id_notas_archivos = Microsoft.VisualBasic.Mid(dg_datos.CurrentCell.Value, 5)
                    oform_factura_compra.id_factura_compras = Microsoft.VisualBasic.Mid(dg_datos.CurrentCell.Value, 5)
                    oform_factura_compra.vg_usuario_autoriza = vg_usuario_autoriza
                    oform_factura_compra.vf_elemento_nuevo = "N"
                    oform_factura_compra.Show() 'Para que no sea un formulario modal
                    'recargar_datos()
                End If

            Case "id_rgtro"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                id_accion = dg_datos.CurrentCell.Value
                Dim vf_name_files As String = "BKC-" & id_accion.ToString.PadLeft(8, "0")
                If id_accion.ToString <> "" And id_accion <> "0" Then
                    cl_utilidades_gestion_documentos.mostrar_listado_archivos_asociados("CD-BKC", id_accion,
                                                                                        vf_name_files,
                                                                                        vg_usuario_autoriza,
                                                                                        vg_id_cia)
                    recargar_datos()
                Else
                    MsgBox("No ha definido un Item", MsgBoxStyle.Information, "Info")
                End If

            Case "id_accion", "id_acc"
                If dg_datos.CurrentCell.Value.ToString <> "0" Then
                    agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                    id_accion = dg_datos.CurrentCell.Value
                    'ajecutamos clase que abre el formulario adecuado segun el tipo de actividad
                    cl_utilidades_gestion_acciones.abrir_actividad(id_accion, vg_usuario_autoriza, vg_id_cia)
                    recargar_datos()
                End If
            Case "id_rpf"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                id_accion = dg_datos.CurrentCell.Value
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_programar_actividad As New camocontrol.fm_0600_p1_definicion_accion
                'oform_grilla_programacion.ods_hijo = ods
                oform_programar_actividad.vf_oform_padre = Me
                oform_programar_actividad.vg_usuario_autoriza = vg_usuario_autoriza
                oform_programar_actividad.cm_emisor.Enabled = False
                oform_programar_actividad.cm_tipo_accion.Enabled = False
                oform_programar_actividad.dtp_fecha_emision.Enabled = False
                oform_programar_actividad.cm_fuente_accion.Enabled = False
                oform_programar_actividad.vg_id_cia = vg_id_cia
                oform_programar_actividad.id_accion = id_accion
                oform_programar_actividad.vf_elemento_nuevo = "N"
                oform_programar_actividad.ShowDialog()
                recargar_datos()
            Case "id_sc" 'solicitudes de compra
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_agregar_solicitud As New camocontrol.fm_0300_sc_solicitud
                oform_agregar_solicitud.vf_oform_padre = Me
                oform_agregar_solicitud.vg_id_cia = vg_id_cia
                oform_agregar_solicitud.id_solicitud_compra = dg_datos.CurrentCell.Value
                oform_agregar_solicitud.vg_usuario_autoriza = vg_usuario_autoriza
                oform_agregar_solicitud.vf_elemento_nuevo = "N"
                oform_agregar_solicitud.ShowDialog()
                recargar_datos()
            Case "id_sc_item"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_item_sol_compra As New camocontrol.fm_0300_sc_items
                oform_item_sol_compra.vf_oform_padre = Me
                'oform_item_sol_compra.id_solicitud_compra = dg_datos.CurrentCell.Value
                oform_item_sol_compra.vg_usuario_autoriza = vg_usuario_autoriza
                oform_item_sol_compra.vg_id_cia = vg_id_cia
                'oform_item_sol_compra.id_estructura = id_estructura
                'oform_item_sol_compra.id_accion = id_accion
                oform_item_sol_compra.id_item_solicitud = dg_datos.CurrentCell.Value
                oform_item_sol_compra.vf_elemento_nuevo = "N"
                oform_item_sol_compra.ShowDialog()
                recargar_datos()
            Case "id_oc" 'solicitudes de compra
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos

                'PARA NO ABRIR OC ANULADAS
                Dim csql As String = "select f0319_id_oc from " & database.obtener_esquema & ".tb0319_ordenes_compra"
                csql += " where f0319_id_oc = '" & dg_datos.CurrentCell.Value & "' and f0319_anulado = 'N'"
                Dim otb_fc As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                If otb_fc.Rows.Count = 0 Then
                    MsgBox("OC ANULADA!", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim oform_agregar_solicitud As New camocontrol.fm_0300_orden_compra
                oform_agregar_solicitud.vf_oform_padre = Me
                oform_agregar_solicitud.vg_id_cia = vg_id_cia
                oform_agregar_solicitud.id_orden_compra = dg_datos.CurrentCell.Value
                oform_agregar_solicitud.vg_usuario_autoriza = vg_usuario_autoriza
                oform_agregar_solicitud.vf_elemento_nuevo = "N"
                oform_agregar_solicitud.ShowDialog()
                recargar_datos()
            Case "id_exmtp"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_exp_materiales As New camocontrol.fm_0300_formulacion
                oform_exp_materiales.vf_oform_padre = Me
                oform_exp_materiales.vg_usuario_autoriza = vg_usuario_autoriza
                oform_exp_materiales.vg_id_cia = vg_id_cia
                oform_exp_materiales.id_plantilla = dg_datos.CurrentCell.Value
                oform_exp_materiales.id_item_padre = id_oreg_padre
                oform_exp_materiales.vf_elemento_nuevo = "N"
                oform_exp_materiales.ShowDialog()
                recargar_datos()
            Case "inv_item"
                'agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim id_bodega As String = oarray_var(1)
                Dim id_item As String = dg_datos.CurrentRow.Cells("id_item").Value
                Dim item As String = dg_datos.CurrentRow.Cells("Item").Value
                cl_utilidades_datatables.visualizar_datos_visor("ST-0300-13", vg_id_cia, vg_usuario_autoriza, item, {vg_id_cia, id_item, id_bodega})
                recargar_datos()
            Case "inf_lote"
                If IsNothing(vf_oform_padre) = False Then
                    vf_oform_padre.vf_t_string = dg_datos.CurrentCell.Value
                End If
                Dispose()
            Case "id_sgmnto"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_seguimientos As New camocontrol.fm_0600_gestion_seguimiento
                'oform_grilla_programacion.ods_hijo = ods
                oform_seguimientos.vf_oform_padre = Me
                oform_seguimientos.vg_id_cia = vg_id_cia
                'oform_seguimientos.id_accion = id_accion
                oform_seguimientos.id_seguimiento_accion = dg_datos.CurrentCell.Value
                oform_seguimientos.vf_elemento_nuevo = "N"
                oform_seguimientos.vg_usuario_autoriza = vg_usuario_autoriza
                oform_seguimientos.ocomportamiento = ovalue
                oform_seguimientos.ShowDialog()
                recargar_datos()
            Case "id_recaudo"
                Dim id_recaudo As Integer = dg_datos.CurrentCell.Value
                agregar_dato_desplegado(nombre_columna)
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_recaudos_consignaciones As New camocontrol.fm_0008_asignar_recibo_consignacion
                'oform_grilla_programacion.ods_hijo = ods
                oform_recaudos_consignaciones.vf_oform_padre = Me
                oform_recaudos_consignaciones.vg_id_cia = vg_id_cia
                oform_recaudos_consignaciones.vf_id_notas_archivos = id_recaudo
                oform_recaudos_consignaciones.id_recaudo = id_recaudo
                oform_recaudos_consignaciones.vf_elemento_nuevo = "N"
                oform_recaudos_consignaciones.vg_usuario_autoriza = vg_usuario_autoriza
                oform_recaudos_consignaciones.ShowDialog()
                recargar_datos()
            Case "id_pdd" 'Todo el proceso de aprobaciones de un pedido hasta facturacion.
                Dim id_pedido As Integer = dg_datos.CurrentCell.Value
                If id_pedido <= 1500 Then
                    MsgBox("Este pedido no esta soportado, registro informativo de reclamacion", MsgBoxStyle.Exclamation, "Pedido fuera de Registros")
                    Exit Sub
                End If
                agregar_dato_desplegado(nombre_columna)
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_pedidos_programados As New camocontrol.fm_0800_programacion_despacho
                'oform_grilla_programacion.ods_hijo = ods
                oform_pedidos_programados.vf_oform_padre = Me
                oform_pedidos_programados.vg_id_cia = vg_id_cia
                oform_pedidos_programados.id_despacho = id_pedido
                oform_pedidos_programados.vf_elemento_nuevo = "N"
                oform_pedidos_programados.mostrar_solo_despacho = "N"
                oform_pedidos_programados.vg_usuario_autoriza = vg_usuario_autoriza
                oform_pedidos_programados.ShowDialog()
                recargar_datos()
            Case "id_dsp" 'Todo el proceso de despachos hasta el servicio postventa.
                Dim id_despacho As Integer = dg_datos.CurrentCell.Value
                agregar_dato_desplegado(nombre_columna)
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_despachos_programados As New camocontrol.fm_0800_programacion_despacho
                'oform_grilla_programacion.ods_hijo = ods
                oform_despachos_programados.vf_oform_padre = Me
                oform_despachos_programados.vg_id_cia = vg_id_cia
                oform_despachos_programados.id_despacho = id_despacho
                oform_despachos_programados.vf_elemento_nuevo = "N"
                oform_despachos_programados.mostrar_solo_despacho = "S"
                oform_despachos_programados.vg_usuario_autoriza = vg_usuario_autoriza
                oform_despachos_programados.ShowDialog()
                recargar_datos()
            Case "id_doc_inv"
                Dim documento As String = dg_datos.CurrentCell.Value
                Dim traslado As String = "N"
                If Strings.Left(documento, 3) = "TRI" Then
                    traslado = "S"
                End If
                'Verifico que el documento exista
                Dim otb_docto As DataTable
                Dim csql As String = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                                     & " where f0310_id_documento = '" & documento & "'"
                otb_docto = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                If otb_docto.Rows.Count = 0 Then
                    MsgBox("El documento no existe", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(documento,
                                                                                      vg_usuario_autoriza,
                                                                                      vg_id_cia,
                                                                                      "N", "S", "D")

            Case "id_file"
                Dim id_file As Integer = dg_datos.CurrentCell.Value
                Dim otabla_file As DataTable
                Dim ofile As String = ""
                Dim oextension As String = ""
                Dim ocomprimido As String = ""
                Dim tipo_archivo As Integer
                Dim visualizar_archivo As String = "N"
                Dim copia_archivo As String = "N"
                agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.

                'Pregunta las formas_obtener_gestionar_archivo() '1=copia, 2=visualizar
                Dim respuesta As Integer = cl_utilidades_gestion_documentos.formas_obtener_gestionar_archivo
                Select Case respuesta
                    Case 0
                        Exit Sub
                    Case 1
                        copia_archivo = "S"
                    Case 2
                        visualizar_archivo = "S"
                End Select

                csql = "SELECT f0503_path || f0503_nombre_archivo || '-' || f0503_ed || f0503_extension as ofile," _
                    & " f0503_comprimido, f0503_extension, f0503_id_tipo_archivo" _
                    & " from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
                    & " where f0503_id_archivo = '" & id_file & "'"
                otabla_file = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                For Each orow As DataRow In otabla_file.Rows
                    ofile = orow("ofile")
                    oextension = orow("f0503_extension")
                    ocomprimido = orow("f0503_comprimido")
                    tipo_archivo = orow("f0503_id_tipo_archivo")
                Next
                Dim verror As String = "N" 'la funcion suministrar archivo retorna "N" si no hay problemas
                If visualizar_archivo = "S" Then
                    'borramos todos los temporales
                    Dim dir_temp As String() = Directory.GetFiles(Path.GetTempPath(), "*.tmp")
                    For Each f As String In dir_temp
                        Try
                            File.Delete(f)
                        Catch ex As Exception
                        End Try
                    Next
                    Dim file_temp As String = Path.GetTempFileName()
                    Select Case tipo_archivo

                        Case 1 'Archivo de imagen

                            verror = cl_utilidades_gestion_documentos.suministrar_archivo(ofile, file_temp, ocomprimido)
                            If verror = "N" Then
                                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                                Dim oform_imagen As New camocontrol.fm_visor_imagen
                                'oform_grilla_programacion.ods_hijo = ods
                                'oform_imagen.vf_oform_padre = Me
                                oform_imagen.vg_id_cia = vg_id_cia
                                oform_imagen.vg_usuario_autoriza = vg_usuario_autoriza
                                oform_imagen.path_file = file_temp
                                oform_imagen.Text = "Soporte"
                                oform_imagen.Show()
                            End If
                        Case 2 'Archivo pdf

                            verror = cl_utilidades_gestion_documentos.suministrar_archivo(ofile, file_temp, ocomprimido)
                            If verror = "N" Then
                                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                                Dim oform_imagen As New camocontrol.fm_visor_pdf
                                'oform_grilla_programacion.ods_hijo = ods
                                'oform_imagen.vf_oform_padre = Me
                                oform_imagen.vg_id_cia = vg_id_cia
                                oform_imagen.vg_usuario_autoriza = vg_usuario_autoriza
                                oform_imagen.path_file = file_temp
                                oform_imagen.Text = ""
                                oform_imagen.Show()
                            End If
                        Case Else
                            'Para ejecutar el programa prederminado
                            'System.Diagnostics.Process.Start(file_temp)
                            MsgBox("El archivo no puede ser Visualizado en el programa", MsgBoxStyle.Exclamation, "Error")
                    End Select
                End If

                If copia_archivo = "S" Then
                    Dim saveFileDialog1 As New SaveFileDialog
                    saveFileDialog1.FileName = "arch_camo"
                    saveFileDialog1.Filter = "files (*" & oextension & ")|*" & oextension
                    saveFileDialog1.FilterIndex = 1
                    saveFileDialog1.RestoreDirectory = True
                    Dim myStream As Stream
                    If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                        myStream = saveFileDialog1.OpenFile()
                        'MsgBox(saveFileDialog1.FileName)
                        If (myStream IsNot Nothing) Then
                            ' Code to write the stream goes here.
                            myStream.Close()
                            verror = cl_utilidades_gestion_documentos.suministrar_archivo(ofile, saveFileDialog1.FileName, ocomprimido)
                            MsgBox("Archivo Suministrado", MsgBoxStyle.Information, "Info")
                        End If
                    Else
                        verror = "S"
                    End If
                End If

            Case "cod_doc"
                'Dim id_file As Integer = dg_datos.CurrentCell.Value
                Dim codigo_documento As String = dg_datos.CurrentCell.Value
                Dim csql As String = comunes.suministrar_valor_variable_configuracion("ST-0550-03", vg_id_cia)
                Dim otabla_file As DataTable
                Dim ofile As String = ""
                Dim oextension As String = ""
                Dim ocomprimido As String = ""
                Dim tipo_archivo As Integer
                Dim visualizar_archivo As String = "N"
                Dim copia_archivo As String = "N"
                Dim verror As String = "N" 'la funcion suministrar archivo retorna "N" si no hay problemas
                'agregar_dato_desplegado(nombre_columna) 'Agrega el datos a otabla para que sea desplegado.


                csql = csql.Replace("$df001$", database.obtener_esquema)
                csql = csql.Replace("$001$", vg_id_cia)
                csql = csql.Replace("$002$", codigo_documento)
                csql = csql.Replace("$003$", 2)

                'Clipboard.SetText(csql)
                'MsgBox("hola")

                otabla_file = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                If otabla_file.Rows.Count = 0 Then
                    MsgBox("El documento no tiene archivos asociados para consultar.", MsgBoxStyle.Information, "Sin datos")
                    Exit Sub
                End If

                'If otabla_file.Rows.Count = 1 Then
                'otabla_file = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                For Each orow As DataRow In otabla_file.Rows
                    ofile = orow("ofile")
                    oextension = orow("f0503_extension")
                    ocomprimido = orow("f0503_comprimido")
                    tipo_archivo = orow("f0503_id_tipo_archivo")

                    'generamos el archivo temporal
                    'borramos todos los temporales
                    Dim dir_temp As String() = Directory.GetFiles(Path.GetTempPath(), "*.tmp")
                    For Each f As String In dir_temp
                        Try
                            File.Delete(f)
                        Catch ex As Exception
                        End Try
                    Next
                    Dim file_temp As String = Path.GetTempFileName()

                    verror = cl_utilidades_gestion_documentos.suministrar_archivo(ofile, file_temp, ocomprimido)
                    If verror = "N" Then
                        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                        Dim oform_imagen As New camocontrol.fm_visor_pdf
                        'oform_grilla_programacion.ods_hijo = ods
                        'oform_imagen.vf_oform_padre = Me
                        oform_imagen.vg_id_cia = vg_id_cia
                        oform_imagen.vg_usuario_autoriza = vg_usuario_autoriza
                        oform_imagen.path_file = file_temp
                        oform_imagen.Text = ""
                        oform_imagen.Show()
                    End If
                Next
                'cl_utilidades_gestion_documentos.abrir_archivo(ofile, vg_id_cia, vg_usuario_autoriza)
                'Else

                'End If
        End Select
    End Sub
    Private Sub bt_filtrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt_filtrar.Click
        filtrar_datos()
    End Sub
    Private Sub filtrar_datos()
        Dim dv_datos As New DataView(otb_datos)
        If filtro_inicial = "S" Then
            filtro_inicial = "N"
            GoTo filtro_ini
        End If
        If tx_valor_campo.Text = "" And cm_operadores_filtro.Text <> "Valor = Nulo" Then
            MsgBox("Fallo")
            Exit Sub
        End If
        Select Case cm_operadores_filtro.Text
            Case "Igual"
                txt_operador = "="
            Case "Diferente"
                txt_operador = "<>"
            Case "Menor"
                txt_operador = "<"
            Case "Menor o Igual"
                txt_operador = "<="
            Case "Mayor"
                txt_operador = ">"
            Case "Mayor o Igual"
                txt_operador = ">="
            Case "Inicie Con"
                txt_operador = "LIKE"
            Case "Contenga"
                txt_operador = "TOP1"
            Case "Valor = Nulo"
                txt_operador = "NULO"
            Case Else
                txt_operador = "="
                cm_operadores_filtro.SelectedIndex = 0
        End Select

        Dim dv_filter_antiguo As String = dv_filter

        Select Case txt_operador
            Case "TOP1"
                If conta_filtros = 0 Then
                    dv_filter = comunes.generador_filtro_like(tx_nombre_campo.Text, tx_valor_campo.Text)
                    'dv_filter = tx_nombre_campo.Text & " " & "LIKE" & " '%" & tx_valor_campo.Text & "%'"
                    'MsgBox(dv_filter)
                Else
                    'dv_filter += " and " & tx_nombre_campo.Text & " " & "LIKE" & " '%" & tx_valor_campo.Text & "%'"
                    dv_filter += " and " & comunes.generador_filtro_like(tx_nombre_campo.Text, tx_valor_campo.Text)
                End If
            Case "LIKE"
                If conta_filtros = 0 Then
                    dv_filter = comunes.generador_filtro_like(tx_nombre_campo.Text, tx_valor_campo.Text)
                    'dv_filter = tx_nombre_campo.Text & " " & txt_operador & " '" & tx_valor_campo.Text & "%'"
                    'MsgBox(dv_filter)
                Else
                    'dv_filter += " and " & tx_nombre_campo.Text & " " & txt_operador & " '" & tx_valor_campo.Text & "%'"
                    dv_filter += " and " & comunes.generador_filtro_like(tx_nombre_campo.Text, tx_valor_campo.Text)
                End If
            Case "NULO" 'este filtro hay que probarlo en columnas tipo numeric, texto y date.
                If conta_filtros = 0 Then
                    dv_filter = tx_nombre_campo.Text & " IS NULL or " & tx_nombre_campo.Text & " = ''" ' & "%'"  "A IS NOT NULL AND A <> ''"
                    'MsgBox(dv_filter)
                Else
                    dv_filter += " and " & tx_nombre_campo.Text & " IS NULL or " & tx_nombre_campo.Text & " = ''" '& "%'"
                End If
            Case Else
                If conta_filtros = 0 Then
                    dv_filter = tx_nombre_campo.Text & " " & txt_operador & " '" & tx_valor_campo.Text & "'"
                Else
                    dv_filter += " and " & tx_nombre_campo.Text & " " & txt_operador & " '" & tx_valor_campo.Text & "'"
                End If
        End Select
filtro_ini:
        conta_filtros += 1
        'MsgBox(UCase(dv_filter), MsgBoxStyle.Information, "Filtro")
        Try
            dv_datos.RowFilter = dv_filter
        Catch ex As Exception
            MsgBox("El filtro no se puede procesar" + vbCrLf + ex.ToString, MsgBoxStyle.Critical, "Error")
            dv_filter = dv_filter_antiguo
            Exit Sub
        End Try
        'dv_datos.RowFilter = tx_nombre_campo.Text & " LIKE '00%'"
        dg_datos.DataSource = dv_datos
        'tx_nombre_campo.Text = ""
        'tx_valor_campo.Text = ""
        'cm_operadores_filtro.SelectedIndex = 0
        lb_total_registros.Text = dv_datos.Count
        'tx_registro_seleccionado.Text = ""
        If dg_datos.Rows.Count > 0 Then
            dg_datos.Focus()
            dg_datos.Rows(0).Cells(0).Selected = True
        End If
    End Sub

    Private Sub bt_quitar_filtro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt_quitar_filtro.Click
        dg_datos.DataSource = otb_datos
        dv_filter = ""
        conta_filtros = 0
        tx_registro_seleccionado.Text = ""
        lb_total_registros.Text = dg_datos.Rows.Count
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

    Private Sub bt_recargar_todo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_recargar_todo.Click
        nombre_columna_desecadenadora = ""
        otb_datos_desplegados.Rows.Clear()
        fila_actual = 0
        recargar_datos()
    End Sub

    Private Sub bt_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo.Click
        Select Case ocontexto_form
            Case "gestion de anotaciones asociadas al registro"
                If otipo_nota <> "" Then
                    'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                    'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                    Dim oform_nuevo_seg_accion As New camocontrol.fm_0600_gestion_seguimiento
                    'oform_grilla_programacion.ods_hijo = ods
                    oform_nuevo_seg_accion.vf_oform_padre = Me
                    oform_nuevo_seg_accion.vg_id_cia = vg_id_cia
                    oform_nuevo_seg_accion.tipo_nota = otipo_nota
                    oform_nuevo_seg_accion.id_accion = id_oreg_padre
                    oform_nuevo_seg_accion.ocomportamiento = ovalue
                    oform_nuevo_seg_accion.vf_elemento_nuevo = "S"
                    oform_nuevo_seg_accion.vg_usuario_autoriza = vg_usuario_autoriza
                    oform_nuevo_seg_accion.ShowDialog()
                    recargar_datos()
                End If
            Case "gestion de archivos asociados al registro"
                'Dim tipo_archivo As String = comunes.suministrar_valor_variable_configuracion(ovalue, vg_id_cia)
                'MsgBox(ovalue & "-" & id_oreg_padre)

                cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo(ovalue, id_oreg_padre, vg_id_cia, vg_usuario_autoriza, "N")
                recargar_datos()
            Case "historial de ausentismo"
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_ausentismo As New camocontrol.fm_0023_01_ausentismo
                oform_ausentismo.vf_oform_padre = Me
                oform_ausentismo.vg_id_cia = vg_id_cia
                oform_ausentismo.id_ausnt = 0
                oform_ausentismo.id_tercero = oarray_var(0)
                oform_ausentismo.id_cargo = oarray_var(1)
                oform_ausentismo.fecha_nacimiento = oarray_var(2)
                oform_ausentismo.fecha_ini_1er_contrato = oarray_var(3)
                oform_ausentismo.fecha_ini_act_contrato = oarray_var(4)
                oform_ausentismo.vg_usuario_autoriza = vg_usuario_autoriza
                oform_ausentismo.vf_elemento_nuevo = "S"
                oform_ausentismo.lb_titulo.Text = oform_ausentismo.lb_titulo.Text & " - (NUEVO)"
                oform_ausentismo.ShowDialog()
                recargar_datos()
            Case "solicitudes de almacen origen acciones"
                'verificamos si tiene permisos para crear una salida
                'Dim permiso As String = "N"
                'permiso = cl_gestion_permisos.identificar_un_permiso_especial_usuario("SAL-ALM-ACC", vg_usuario_autoriza)
                'If permiso = "N" Then
                'MsgBox("No tiene autorizacion para realizar salidas de inventario", MsgBoxStyle.Information, "Info")
                'Exit Sub
                'End If
                'creamos el nuevo documento
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_solicitud_almacen As New camocontrol.fm_0300_solicitud_mp_produccion
                'oform_grilla_programacion.ods_hijo = ods
                oform_solicitud_almacen.vf_oform_padre = Me
                oform_solicitud_almacen.vg_id_cia = vg_id_cia
                oform_solicitud_almacen.id_accion = id_accion
                oform_solicitud_almacen.vg_usuario_autoriza = vg_usuario_autoriza
                oform_solicitud_almacen.ShowDialog()
                recargar_datos()
            Case "salida de insumos de almacen desde una actividad"
                'verificamos si tiene permisos para crear una salida
                Dim permiso As String = "N"
                permiso = cl_gestion_permisos.identificar_un_permiso_especial_usuario("SAL-ALM-ACC", vg_usuario_autoriza)
                If permiso = "N" Then
                    MsgBox("No tiene autorizacion para realizar salidas de inventario", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                'creamos el nuevo documento
                Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(14, vg_id_cia)
                Dim cod_documento As String = "CIM-" & consecutivo.ToString.PadLeft(8, "0")
                cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, 10, 14, comunes.g_fechahora, vg_usuario_autoriza, vg_id_cia, "ACC-" & id_accion)
                cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(cod_documento, vg_usuario_autoriza, vg_id_cia, "S", "N", "S", "N", "S", "S", "S", "N", "S")
                recargar_datos()
            Case "seguimientos al personaltttt"
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_nuevo_seg_accion As New camocontrol.fm_0600_gestion_seguimiento
                'oform_grilla_programacion.ods_hijo = ods
                oform_nuevo_seg_accion.vf_oform_padre = Me
                oform_nuevo_seg_accion.vg_id_cia = vg_id_cia
                oform_nuevo_seg_accion.tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-RHU-001", vg_id_cia)
                oform_nuevo_seg_accion.id_accion = id_oreg_padre
                oform_nuevo_seg_accion.vf_elemento_nuevo = "S"
                oform_nuevo_seg_accion.vg_usuario_autoriza = vg_usuario_autoriza
                oform_nuevo_seg_accion.ShowDialog()
                recargar_datos()
            Case "nueva explosion de materiales"
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_exp_materiales As New camocontrol.fm_0300_formulacion
                oform_exp_materiales.vf_oform_padre = Me
                oform_exp_materiales.vg_usuario_autoriza = vg_usuario_autoriza
                oform_exp_materiales.vg_id_cia = vg_id_cia
                oform_exp_materiales.vf_elemento_nuevo = "S"
                oform_exp_materiales.id_item_padre = id_oreg_padre
                oform_exp_materiales.ShowDialog()
                recargar_datos()
            Case "gestion de tiempos improductivos produccion"
                'Pregunta si realmente desea reportar
                Dim respuesta As String = "N"
                respuesta = comunes.g_mensaje_YesNo("Reportar Tiempo Improductivo", "Desea reportar tiempo improductivo?")
                If respuesta = "N" Then
                    Exit Sub
                End If

                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_reportar_falla As New camocontrol.fm_0100_reportar_falla_maquina
                'oform_grilla_programacion.ods_hijo = ods
                oform_reportar_falla.vf_oform_padre = Me
                oform_reportar_falla.vg_id_cia = vg_id_cia
                oform_reportar_falla.Text = "Tiempo Improductivo"
                oform_reportar_falla.lb_titulo.Text = "Registro de tiempo Improductivo"
                oform_reportar_falla.id_estructura = id_estructura
                oform_reportar_falla.id_fuente_falla = "00000002"
                oform_reportar_falla.otipo_docto_padre = otipo_nota
                oform_reportar_falla.id_docto_padre = id_oreg_padre
                oform_reportar_falla.cm_fuente_accion.Enabled = False
                oform_reportar_falla.cm_nit.Enabled = False
                oform_reportar_falla.cm_razon_social.Enabled = False
                oform_reportar_falla.vg_usuario_autoriza = vg_usuario_autoriza
                'oform_reportar_falla.tx_estructura.Text = tx_elemento_seleccionado.Text.Trim
                oform_reportar_falla.ShowDialog()
                recargar_datos()
        End Select
    End Sub

    Private Sub bt_exportar_excel_Click(sender As Object, e As EventArgs) Handles bt_exportar_excel.Click
        Dim verror As String = "N"
        Try
            cl_utilidades_datatables.exportar_datatable_excel(otb_datos)
        Catch ex As Exception
            'Try
            'verror = cl_utilidades_datatables.exportar_consulta_plano(csql, "", "S", "S")
            'Catch ex2 As Exception
            'MsgBox("Error" + vbCrLf + ex2.ToString, MsgBoxStyle.Critical, "Error")
            'Exit Sub
            'End Try
            verror = "S"
            MsgBox("Error excel no disponible", MsgBoxStyle.Critical, "Error")
        End Try
        If verror = "N" Then
            MsgBox("Texto exportado", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub crear_excel()
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Iniciar un nuevo libro en Excel
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add
        'Agregar datos a las celdas de la primera hoja en el libro nuevo
        oSheet = oBook.Worksheets(1)
        'oSheet.cells.WrapText = False
        ' Agregamos el nombre de las columnas
        Dim ncol As Integer = 1
        For Each ocolum As DataColumn In otb_datos.Columns
            oSheet.cells(1, ncol).value = ocolum.ColumnName.ToString
            ncol += 1
        Next
        ' Agregamos Los datos que queremos agregar
        Dim ocolumnas As Integer = otb_datos.Columns.Count
        Dim nrow As Long = 1
        For Each orow As DataRow In otb_datos.Rows
            For i = 1 To ocolumnas
                oSheet.cells(nrow + 1, i).value = orow(i - 1).ToString
            Next
            nrow = nrow + 1
        Next
        'oSheet.cells(1, 1).Value = "Hola Mundo"

        ' hacemos visible el documento
        oExcel.Visible = True
        oExcel.UserControl = True
        'Guardaremos el documento en el escritorio con el nombre prueba
        'oBook.SaveAs(Environ("UserProfile") & "\desktop\Prueba.xls")

    End Sub

    Private Sub bt_exportar_csv_Click(sender As Object, e As EventArgs) Handles bt_exportar_csv.Click
        Dim verror As String = "N"
        Try
            cl_utilidades_datatables.datatable_to_csv_filesavedialog(otb_datos, True, vg_id_cia)
        Catch ex As Exception
            verror = "S"
            MsgBox("Error CSV no disponible" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        If verror = "N" Then
            MsgBox("Texto exportado", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub actualizar_tercero_orden_compra(ByVal id_item_solicitud As Integer, ByVal id_tercero_oc As String)
        'MsgBox(id_item_solicitud & " - " & id_tercero_oc)
        Dim oconn_form As NpgsqlConnection
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0305_items_solicitados set "
        csql += "f0305_tercero_sol = @f0305_tercero_sol"
        csql += " where f0305_id_item_solicitud = @f0305_id_item_solicitud"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_item(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0305_id_item_solicitud", NpgsqlDbType.Integer).Value = id_item_solicitud
        ocmd.Parameters.Add("@f0305_tercero_sol", NpgsqlDbType.Varchar).Value = id_tercero_oc

        Dim verror As String = "N"
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

    Private Sub tx_valor_campo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_valor_campo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            filtrar_datos()
        End If
    End Sub

    Private Sub cm_operadores_filtro_GotFocus(sender As Object, e As EventArgs) Handles cm_operadores_filtro.GotFocus
        cm_operadores_filtro.DroppedDown = True
    End Sub

End Class
