<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0300_facturas_compras
    Inherits camocontrol.FM_PLANTILLA

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cm_proveedor = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_factura_proveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lb_identificacion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dg_listado = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_sc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_sc_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_oc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_DocEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_complementaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cantidad_solicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_chk_inventario = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_inventario_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_chk_item_aprobado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_var_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_unitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_unit_iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_total_iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_estructura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_accion_raiz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_planta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tx_id_item_sc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_add_item = New System.Windows.Forms.Button()
        Me.bt_eliminar_item = New System.Windows.Forms.Button()
        Me.cm_nit = New System.Windows.Forms.ComboBox()
        Me.tx_oc_uno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_id_factura = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_estado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bt_aprobar = New System.Windows.Forms.Button()
        Me.tx_cuadre_caja = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lb_valor_factura = New System.Windows.Forms.Label()
        Me.bt_catalago_items = New System.Windows.Forms.Button()
        Me.bt_gestionar_tercero = New System.Windows.Forms.Button()
        Me.bt_solicitud_compra = New System.Windows.Forms.Button()
        Me.tx_sol_compra = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_fecha_factura = New System.Windows.Forms.DateTimePicker()
        Me.dtp_vencimiento_factura = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.bt_aprobar_recepcion = New System.Windows.Forms.Button()
        Me.tx_remision_proveedor = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.bt_historico_compras = New System.Windows.Forms.Button()
        Me.tx_id_item_cons_mov = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tx_docto_contable = New System.Windows.Forms.TextBox()
        Me.cm_bodega = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.bt_docto_inv = New System.Windows.Forms.Button()
        Me.bt_aprobar_recepcion_sin_ea = New System.Windows.Forms.Button()
        Me.lb_doc_entrada = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lb_valor_subtotal = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.bt_cargar_items_sc = New System.Windows.Forms.Button()
        Me.bt_actualizar_grilla = New System.Windows.Forms.Button()
        Me.bt_nueva_sc = New System.Windows.Forms.Button()
        Me.bt_listado_items_pend = New System.Windows.Forms.Button()
        Me.bt_listado_oc = New System.Windows.Forms.Button()
        Me.tx_id_oc = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tx_contabilizacion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.bt_contabilizacion = New System.Windows.Forms.Button()
        Me.lb_fecha_aprob = New System.Windows.Forms.Label()
        Me.chk_cmena = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(1155, 9)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(1302, 14)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(1304, 55)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2015/01/02"
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(392, 51)
        Me.lb_titulo.Text = "Factura de Compra"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(315, 763)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 8, 6, 8)
        '
        'bt_grabar
        '
        '
        'bt_anular
        '
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 858)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'cm_proveedor
        '
        Me.cm_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_proveedor.FormattingEnabled = True
        Me.cm_proveedor.Location = New System.Drawing.Point(150, 215)
        Me.cm_proveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_proveedor.Name = "cm_proveedor"
        Me.cm_proveedor.Size = New System.Drawing.Size(590, 33)
        Me.cm_proveedor.TabIndex = 149
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 220)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 25)
        Me.Label5.TabIndex = 148
        Me.Label5.Text = "Proveedor:"
        '
        'tx_factura_proveedor
        '
        Me.tx_factura_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_factura_proveedor.Location = New System.Drawing.Point(150, 148)
        Me.tx_factura_proveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_factura_proveedor.Name = "tx_factura_proveedor"
        Me.tx_factura_proveedor.Size = New System.Drawing.Size(250, 40)
        Me.tx_factura_proveedor.TabIndex = 147
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 152)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 25)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "FACTURA #:"
        '
        'lb_identificacion
        '
        Me.lb_identificacion.AutoSize = True
        Me.lb_identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_identificacion.Location = New System.Drawing.Point(93, 266)
        Me.lb_identificacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_identificacion.Name = "lb_identificacion"
        Me.lb_identificacion.Size = New System.Drawing.Size(55, 25)
        Me.lb_identificacion.TabIndex = 151
        Me.lb_identificacion.Text = "NIT :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 469)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 25)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Items solicitados:"
        '
        'dg_listado
        '
        Me.dg_listado.AllowUserToAddRows = False
        Me.dg_listado.AllowUserToDeleteRows = False
        Me.dg_listado.AllowUserToOrderColumns = True
        Me.dg_listado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_listado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_sc, Me.dgocell_id_sc_item, Me.dgocell_id_oc, Me.dgocell_item, Me.dgocell_DocEntrada, Me.dgocell_descripcion_item, Me.dgocell_descripcion_complementaria, Me.dgocell_cantidad_solicitada, Me.dgocell_chk_inventario, Me.dgocell_inventario_total, Me.dgocell_unidad, Me.dgocell_chk_item_aprobado, Me.dgocell_var_costo, Me.dgocell_costo_unitario, Me.dgocell_descuento, Me.dgocell_costo_total, Me.dgocell_iva, Me.dgocell_costo_unit_iva, Me.dgocell_costo_total_iva, Me.dgocell_descripcion_estructura, Me.dgocell_id_accion, Me.dgocell_id_accion_raiz, Me.dgocell_nota, Me.dgocell_planta})
        Me.dg_listado.Location = New System.Drawing.Point(18, 498)
        Me.dg_listado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dg_listado.Name = "dg_listado"
        Me.dg_listado.RowHeadersWidth = 62
        Me.dg_listado.Size = New System.Drawing.Size(1394, 255)
        Me.dg_listado.TabIndex = 154
        '
        'dgocell_id_sc
        '
        Me.dgocell_id_sc.HeaderText = "Id_SC"
        Me.dgocell_id_sc.MinimumWidth = 40
        Me.dgocell_id_sc.Name = "dgocell_id_sc"
        Me.dgocell_id_sc.ReadOnly = True
        Me.dgocell_id_sc.Width = 50
        '
        'dgocell_id_sc_item
        '
        Me.dgocell_id_sc_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_id_sc_item.HeaderText = "Id_sc_item"
        Me.dgocell_id_sc_item.MinimumWidth = 40
        Me.dgocell_id_sc_item.Name = "dgocell_id_sc_item"
        Me.dgocell_id_sc_item.ReadOnly = True
        Me.dgocell_id_sc_item.Width = 40
        '
        'dgocell_id_oc
        '
        Me.dgocell_id_oc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_id_oc.HeaderText = "id_OC"
        Me.dgocell_id_oc.MinimumWidth = 40
        Me.dgocell_id_oc.Name = "dgocell_id_oc"
        Me.dgocell_id_oc.ReadOnly = True
        Me.dgocell_id_oc.Width = 40
        '
        'dgocell_item
        '
        Me.dgocell_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_item.HeaderText = "Cod_Item"
        Me.dgocell_item.MinimumWidth = 40
        Me.dgocell_item.Name = "dgocell_item"
        Me.dgocell_item.ReadOnly = True
        Me.dgocell_item.Width = 40
        '
        'dgocell_DocEntrada
        '
        Me.dgocell_DocEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_DocEntrada.HeaderText = "Entrada"
        Me.dgocell_DocEntrada.MinimumWidth = 8
        Me.dgocell_DocEntrada.Name = "dgocell_DocEntrada"
        Me.dgocell_DocEntrada.ReadOnly = True
        Me.dgocell_DocEntrada.Width = 8
        '
        'dgocell_descripcion_item
        '
        Me.dgocell_descripcion_item.HeaderText = "Item"
        Me.dgocell_descripcion_item.MinimumWidth = 8
        Me.dgocell_descripcion_item.Name = "dgocell_descripcion_item"
        Me.dgocell_descripcion_item.ReadOnly = True
        Me.dgocell_descripcion_item.Width = 200
        '
        'dgocell_descripcion_complementaria
        '
        Me.dgocell_descripcion_complementaria.HeaderText = "Descripcion Complementaria"
        Me.dgocell_descripcion_complementaria.MinimumWidth = 8
        Me.dgocell_descripcion_complementaria.Name = "dgocell_descripcion_complementaria"
        Me.dgocell_descripcion_complementaria.ReadOnly = True
        Me.dgocell_descripcion_complementaria.Width = 200
        '
        'dgocell_cantidad_solicitada
        '
        Me.dgocell_cantidad_solicitada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_cantidad_solicitada.HeaderText = "Cant. Sol."
        Me.dgocell_cantidad_solicitada.MinimumWidth = 40
        Me.dgocell_cantidad_solicitada.Name = "dgocell_cantidad_solicitada"
        Me.dgocell_cantidad_solicitada.ReadOnly = True
        Me.dgocell_cantidad_solicitada.Width = 40
        '
        'dgocell_chk_inventario
        '
        Me.dgocell_chk_inventario.HeaderText = "Invt"
        Me.dgocell_chk_inventario.MinimumWidth = 8
        Me.dgocell_chk_inventario.Name = "dgocell_chk_inventario"
        Me.dgocell_chk_inventario.ReadOnly = True
        Me.dgocell_chk_inventario.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_chk_inventario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_chk_inventario.Width = 40
        '
        'dgocell_inventario_total
        '
        Me.dgocell_inventario_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_inventario_total.HeaderText = "Inventario"
        Me.dgocell_inventario_total.MinimumWidth = 8
        Me.dgocell_inventario_total.Name = "dgocell_inventario_total"
        Me.dgocell_inventario_total.Width = 8
        '
        'dgocell_unidad
        '
        Me.dgocell_unidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_unidad.HeaderText = "Unidad"
        Me.dgocell_unidad.MinimumWidth = 8
        Me.dgocell_unidad.Name = "dgocell_unidad"
        Me.dgocell_unidad.ReadOnly = True
        Me.dgocell_unidad.Width = 8
        '
        'dgocell_chk_item_aprobado
        '
        Me.dgocell_chk_item_aprobado.HeaderText = "Apb"
        Me.dgocell_chk_item_aprobado.MinimumWidth = 8
        Me.dgocell_chk_item_aprobado.Name = "dgocell_chk_item_aprobado"
        Me.dgocell_chk_item_aprobado.ReadOnly = True
        Me.dgocell_chk_item_aprobado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_chk_item_aprobado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_chk_item_aprobado.Width = 30
        '
        'dgocell_var_costo
        '
        Me.dgocell_var_costo.HeaderText = "%V"
        Me.dgocell_var_costo.MinimumWidth = 8
        Me.dgocell_var_costo.Name = "dgocell_var_costo"
        Me.dgocell_var_costo.ReadOnly = True
        Me.dgocell_var_costo.Width = 40
        '
        'dgocell_costo_unitario
        '
        Me.dgocell_costo_unitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_costo_unitario.HeaderText = "$_Unit"
        Me.dgocell_costo_unitario.MinimumWidth = 60
        Me.dgocell_costo_unitario.Name = "dgocell_costo_unitario"
        Me.dgocell_costo_unitario.ReadOnly = True
        Me.dgocell_costo_unitario.Width = 60
        '
        'dgocell_descuento
        '
        Me.dgocell_descuento.HeaderText = "%_Desc"
        Me.dgocell_descuento.MinimumWidth = 40
        Me.dgocell_descuento.Name = "dgocell_descuento"
        Me.dgocell_descuento.ReadOnly = True
        Me.dgocell_descuento.Width = 40
        '
        'dgocell_costo_total
        '
        Me.dgocell_costo_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_costo_total.HeaderText = "$_Sub_T"
        Me.dgocell_costo_total.MinimumWidth = 60
        Me.dgocell_costo_total.Name = "dgocell_costo_total"
        Me.dgocell_costo_total.ReadOnly = True
        Me.dgocell_costo_total.Width = 60
        '
        'dgocell_iva
        '
        Me.dgocell_iva.HeaderText = "IVA"
        Me.dgocell_iva.MinimumWidth = 40
        Me.dgocell_iva.Name = "dgocell_iva"
        Me.dgocell_iva.ReadOnly = True
        Me.dgocell_iva.Width = 40
        '
        'dgocell_costo_unit_iva
        '
        Me.dgocell_costo_unit_iva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_costo_unit_iva.HeaderText = "$_unit_IVA"
        Me.dgocell_costo_unit_iva.MinimumWidth = 60
        Me.dgocell_costo_unit_iva.Name = "dgocell_costo_unit_iva"
        Me.dgocell_costo_unit_iva.Width = 60
        '
        'dgocell_costo_total_iva
        '
        Me.dgocell_costo_total_iva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_costo_total_iva.HeaderText = "$_Tot_IVA"
        Me.dgocell_costo_total_iva.MinimumWidth = 60
        Me.dgocell_costo_total_iva.Name = "dgocell_costo_total_iva"
        Me.dgocell_costo_total_iva.ReadOnly = True
        Me.dgocell_costo_total_iva.Width = 60
        '
        'dgocell_descripcion_estructura
        '
        Me.dgocell_descripcion_estructura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_descripcion_estructura.HeaderText = "Estructura"
        Me.dgocell_descripcion_estructura.MinimumWidth = 8
        Me.dgocell_descripcion_estructura.Name = "dgocell_descripcion_estructura"
        Me.dgocell_descripcion_estructura.ReadOnly = True
        Me.dgocell_descripcion_estructura.Width = 8
        '
        'dgocell_id_accion
        '
        Me.dgocell_id_accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgocell_id_accion.HeaderText = "id_acc"
        Me.dgocell_id_accion.MinimumWidth = 8
        Me.dgocell_id_accion.Name = "dgocell_id_accion"
        Me.dgocell_id_accion.ReadOnly = True
        Me.dgocell_id_accion.Width = 45
        '
        'dgocell_id_accion_raiz
        '
        Me.dgocell_id_accion_raiz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgocell_id_accion_raiz.HeaderText = "Raiz"
        Me.dgocell_id_accion_raiz.MinimumWidth = 8
        Me.dgocell_id_accion_raiz.Name = "dgocell_id_accion_raiz"
        Me.dgocell_id_accion_raiz.Width = 45
        '
        'dgocell_nota
        '
        Me.dgocell_nota.HeaderText = "Nota"
        Me.dgocell_nota.MinimumWidth = 8
        Me.dgocell_nota.Name = "dgocell_nota"
        Me.dgocell_nota.ReadOnly = True
        Me.dgocell_nota.Width = 200
        '
        'dgocell_planta
        '
        Me.dgocell_planta.HeaderText = "Planta"
        Me.dgocell_planta.MinimumWidth = 8
        Me.dgocell_planta.Name = "dgocell_planta"
        Me.dgocell_planta.ReadOnly = True
        Me.dgocell_planta.Width = 150
        '
        'tx_id_item_sc
        '
        Me.tx_id_item_sc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_sc.Location = New System.Drawing.Point(150, 369)
        Me.tx_id_item_sc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_id_item_sc.Name = "tx_id_item_sc"
        Me.tx_id_item_sc.Size = New System.Drawing.Size(102, 30)
        Me.tx_id_item_sc.TabIndex = 157
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 374)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 25)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Id_item_SC:"
        '
        'bt_add_item
        '
        Me.bt_add_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_add_item.Location = New System.Drawing.Point(258, 358)
        Me.bt_add_item.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_add_item.Name = "bt_add_item"
        Me.bt_add_item.Size = New System.Drawing.Size(48, 52)
        Me.bt_add_item.TabIndex = 158
        Me.bt_add_item.Text = "Ad"
        Me.bt_add_item.UseVisualStyleBackColor = True
        '
        'bt_eliminar_item
        '
        Me.bt_eliminar_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_eliminar_item.Location = New System.Drawing.Point(360, 358)
        Me.bt_eliminar_item.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_eliminar_item.Name = "bt_eliminar_item"
        Me.bt_eliminar_item.Size = New System.Drawing.Size(48, 52)
        Me.bt_eliminar_item.TabIndex = 159
        Me.bt_eliminar_item.UseVisualStyleBackColor = True
        '
        'cm_nit
        '
        Me.cm_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_nit.FormattingEnabled = True
        Me.cm_nit.Location = New System.Drawing.Point(150, 262)
        Me.cm_nit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_nit.Name = "cm_nit"
        Me.cm_nit.Size = New System.Drawing.Size(250, 33)
        Me.cm_nit.TabIndex = 160
        '
        'tx_oc_uno
        '
        Me.tx_oc_uno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_oc_uno.Location = New System.Drawing.Point(780, 94)
        Me.tx_oc_uno.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_oc_uno.Name = "tx_oc_uno"
        Me.tx_oc_uno.Size = New System.Drawing.Size(94, 30)
        Me.tx_oc_uno.TabIndex = 164
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(644, 98)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 25)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "OC UNO #:"
        '
        'tx_id_factura
        '
        Me.tx_id_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_factura.Location = New System.Drawing.Point(150, 94)
        Me.tx_id_factura.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_id_factura.Name = "tx_id_factura"
        Me.tx_id_factura.Size = New System.Drawing.Size(116, 30)
        Me.tx_id_factura.TabIndex = 168
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 98)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 25)
        Me.Label9.TabIndex = 167
        Me.Label9.Text = "id_fct_prov:"
        '
        'tx_estado
        '
        Me.tx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estado.Location = New System.Drawing.Point(375, 94)
        Me.tx_estado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_estado.Name = "tx_estado"
        Me.tx_estado.Size = New System.Drawing.Size(246, 30)
        Me.tx_estado.TabIndex = 170
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(285, 98)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 25)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Estado:"
        '
        'bt_aprobar
        '
        Me.bt_aprobar.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_aprobar.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_aprobar.Location = New System.Drawing.Point(766, 397)
        Me.bt_aprobar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_aprobar.Name = "bt_aprobar"
        Me.bt_aprobar.Size = New System.Drawing.Size(176, 60)
        Me.bt_aprobar.TabIndex = 171
        Me.bt_aprobar.Text = "Aprobar Factura"
        Me.bt_aprobar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_aprobar.UseVisualStyleBackColor = False
        '
        'tx_cuadre_caja
        '
        Me.tx_cuadre_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cuadre_caja.Location = New System.Drawing.Point(1266, 94)
        Me.tx_cuadre_caja.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_cuadre_caja.Name = "tx_cuadre_caja"
        Me.tx_cuadre_caja.Size = New System.Drawing.Size(94, 30)
        Me.tx_cuadre_caja.TabIndex = 179
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1160, 98)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 25)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = "C_Menor:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(432, 437)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 29)
        Me.Label10.TabIndex = 180
        Me.Label10.Text = "Total:"
        '
        'lb_valor_factura
        '
        Me.lb_valor_factura.AutoSize = True
        Me.lb_valor_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_factura.Location = New System.Drawing.Point(550, 437)
        Me.lb_valor_factura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_valor_factura.Name = "lb_valor_factura"
        Me.lb_valor_factura.Size = New System.Drawing.Size(26, 29)
        Me.lb_valor_factura.TabIndex = 181
        Me.lb_valor_factura.Text = "0"
        '
        'bt_catalago_items
        '
        Me.bt_catalago_items.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_catalago_items.Image = Global.camocontrol.My.Resources.Resources.icono_herramientas
        Me.bt_catalago_items.Location = New System.Drawing.Point(567, 325)
        Me.bt_catalago_items.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_catalago_items.Name = "bt_catalago_items"
        Me.bt_catalago_items.Size = New System.Drawing.Size(176, 60)
        Me.bt_catalago_items.TabIndex = 182
        Me.bt_catalago_items.Text = "Gestion Items"
        Me.bt_catalago_items.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_catalago_items.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_catalago_items.UseVisualStyleBackColor = True
        '
        'bt_gestionar_tercero
        '
        Me.bt_gestionar_tercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_gestionar_tercero.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.bt_gestionar_tercero.Location = New System.Drawing.Point(567, 262)
        Me.bt_gestionar_tercero.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_gestionar_tercero.Name = "bt_gestionar_tercero"
        Me.bt_gestionar_tercero.Size = New System.Drawing.Size(176, 60)
        Me.bt_gestionar_tercero.TabIndex = 183
        Me.bt_gestionar_tercero.Text = "Gestion Terceros"
        Me.bt_gestionar_tercero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_gestionar_tercero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_gestionar_tercero.UseVisualStyleBackColor = True
        '
        'bt_solicitud_compra
        '
        Me.bt_solicitud_compra.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_solicitud_compra.Location = New System.Drawing.Point(260, 308)
        Me.bt_solicitud_compra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_solicitud_compra.Name = "bt_solicitud_compra"
        Me.bt_solicitud_compra.Size = New System.Drawing.Size(48, 52)
        Me.bt_solicitud_compra.TabIndex = 188
        Me.bt_solicitud_compra.UseVisualStyleBackColor = True
        '
        'tx_sol_compra
        '
        Me.tx_sol_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_sol_compra.Location = New System.Drawing.Point(150, 320)
        Me.tx_sol_compra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_sol_compra.Name = "tx_sol_compra"
        Me.tx_sol_compra.Size = New System.Drawing.Size(102, 30)
        Me.tx_sol_compra.TabIndex = 187
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(76, 325)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 25)
        Me.Label11.TabIndex = 186
        Me.Label11.Text = "Id_SC:"
        '
        'dtp_fecha_factura
        '
        Me.dtp_fecha_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_factura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_factura.Location = New System.Drawing.Point(558, 134)
        Me.dtp_fecha_factura.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_fecha_factura.Name = "dtp_fecha_factura"
        Me.dtp_fecha_factura.Size = New System.Drawing.Size(182, 30)
        Me.dtp_fecha_factura.TabIndex = 189
        '
        'dtp_vencimiento_factura
        '
        Me.dtp_vencimiento_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento_factura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_vencimiento_factura.Location = New System.Drawing.Point(558, 175)
        Me.dtp_vencimiento_factura.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_vencimiento_factura.Name = "dtp_vencimiento_factura"
        Me.dtp_vencimiento_factura.Size = New System.Drawing.Size(182, 30)
        Me.dtp_vencimiento_factura.TabIndex = 190
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(422, 142)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 25)
        Me.Label13.TabIndex = 191
        Me.Label13.Text = "Fecha:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(422, 180)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(126, 25)
        Me.Label14.TabIndex = 192
        Me.Label14.Text = "Vencimiento:"
        '
        'bt_aprobar_recepcion
        '
        Me.bt_aprobar_recepcion.Image = Global.camocontrol.My.Resources.Resources.icono_checklist
        Me.bt_aprobar_recepcion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_aprobar_recepcion.Location = New System.Drawing.Point(250, 55)
        Me.bt_aprobar_recepcion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_aprobar_recepcion.Name = "bt_aprobar_recepcion"
        Me.bt_aprobar_recepcion.Size = New System.Drawing.Size(188, 85)
        Me.bt_aprobar_recepcion.TabIndex = 193
        Me.bt_aprobar_recepcion.Text = "Registrar Recepcion con EA"
        Me.bt_aprobar_recepcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_aprobar_recepcion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_aprobar_recepcion.UseVisualStyleBackColor = True
        '
        'tx_remision_proveedor
        '
        Me.tx_remision_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_remision_proveedor.Location = New System.Drawing.Point(1042, 94)
        Me.tx_remision_proveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_remision_proveedor.Name = "tx_remision_proveedor"
        Me.tx_remision_proveedor.Size = New System.Drawing.Size(94, 30)
        Me.tx_remision_proveedor.TabIndex = 195
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(906, 98)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(131, 25)
        Me.Label15.TabIndex = 194
        Me.Label15.Text = "REMISION #:"
        '
        'bt_historico_compras
        '
        Me.bt_historico_compras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_historico_compras.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_historico_compras.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_historico_compras.Location = New System.Drawing.Point(1293, 798)
        Me.bt_historico_compras.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_historico_compras.Name = "bt_historico_compras"
        Me.bt_historico_compras.Size = New System.Drawing.Size(48, 52)
        Me.bt_historico_compras.TabIndex = 199
        Me.bt_historico_compras.UseVisualStyleBackColor = True
        '
        'tx_id_item_cons_mov
        '
        Me.tx_id_item_cons_mov.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_id_item_cons_mov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_cons_mov.Location = New System.Drawing.Point(1293, 763)
        Me.tx_id_item_cons_mov.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_id_item_cons_mov.Name = "tx_id_item_cons_mov"
        Me.tx_id_item_cons_mov.Size = New System.Drawing.Size(116, 30)
        Me.tx_id_item_cons_mov.TabIndex = 198
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1206, 768)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 25)
        Me.Label3.TabIndex = 197
        Me.Label3.Text = "Id_item:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 55)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(153, 25)
        Me.Label16.TabIndex = 243
        Me.Label16.Text = "Documento CG:"
        '
        'tx_docto_contable
        '
        Me.tx_docto_contable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_docto_contable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_docto_contable.Location = New System.Drawing.Point(14, 85)
        Me.tx_docto_contable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_docto_contable.MaxLength = 30
        Me.tx_docto_contable.Name = "tx_docto_contable"
        Me.tx_docto_contable.Size = New System.Drawing.Size(188, 30)
        Me.tx_docto_contable.TabIndex = 242
        '
        'cm_bodega
        '
        Me.cm_bodega.FormattingEnabled = True
        Me.cm_bodega.Location = New System.Drawing.Point(14, 151)
        Me.cm_bodega.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_bodega.Name = "cm_bodega"
        Me.cm_bodega.Size = New System.Drawing.Size(616, 28)
        Me.cm_bodega.TabIndex = 241
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(14, 123)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(186, 25)
        Me.Label23.TabIndex = 240
        Me.Label23.Text = "Bodega de Entrada:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtp_fecha)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.bt_docto_inv)
        Me.GroupBox2.Controls.Add(Me.bt_aprobar_recepcion_sin_ea)
        Me.GroupBox2.Controls.Add(Me.lb_doc_entrada)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.tx_docto_contable)
        Me.GroupBox2.Controls.Add(Me.cm_bodega)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.bt_aprobar_recepcion)
        Me.GroupBox2.Location = New System.Drawing.Point(756, 137)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(644, 232)
        Me.GroupBox2.TabIndex = 244
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gestionar Recepcion y Entrada"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(330, 17)
        Me.dtp_fecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(234, 30)
        Me.dtp_fecha.TabIndex = 251
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(249, 26)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 25)
        Me.Label18.TabIndex = 250
        Me.Label18.Text = "Fecha:"
        '
        'bt_docto_inv
        '
        Me.bt_docto_inv.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_docto_inv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_docto_inv.Location = New System.Drawing.Point(204, 188)
        Me.bt_docto_inv.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_docto_inv.Name = "bt_docto_inv"
        Me.bt_docto_inv.Size = New System.Drawing.Size(48, 34)
        Me.bt_docto_inv.TabIndex = 246
        Me.bt_docto_inv.UseVisualStyleBackColor = True
        '
        'bt_aprobar_recepcion_sin_ea
        '
        Me.bt_aprobar_recepcion_sin_ea.Image = Global.camocontrol.My.Resources.Resources.icono_checklist
        Me.bt_aprobar_recepcion_sin_ea.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_aprobar_recepcion_sin_ea.Location = New System.Drawing.Point(447, 55)
        Me.bt_aprobar_recepcion_sin_ea.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_aprobar_recepcion_sin_ea.Name = "bt_aprobar_recepcion_sin_ea"
        Me.bt_aprobar_recepcion_sin_ea.Size = New System.Drawing.Size(188, 85)
        Me.bt_aprobar_recepcion_sin_ea.TabIndex = 245
        Me.bt_aprobar_recepcion_sin_ea.Text = "Aprobar Recepcion sin EA"
        Me.bt_aprobar_recepcion_sin_ea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_aprobar_recepcion_sin_ea.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_aprobar_recepcion_sin_ea.UseVisualStyleBackColor = True
        '
        'lb_doc_entrada
        '
        Me.lb_doc_entrada.AutoSize = True
        Me.lb_doc_entrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_doc_entrada.Location = New System.Drawing.Point(255, 192)
        Me.lb_doc_entrada.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_doc_entrada.Name = "lb_doc_entrada"
        Me.lb_doc_entrada.Size = New System.Drawing.Size(40, 25)
        Me.lb_doc_entrada.TabIndex = 245
        Me.lb_doc_entrada.Text = "ND"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 192)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(191, 25)
        Me.Label17.TabIndex = 244
        Me.Label17.Text = "Documento Entrada:"
        '
        'lb_valor_subtotal
        '
        Me.lb_valor_subtotal.AutoSize = True
        Me.lb_valor_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_subtotal.Location = New System.Drawing.Point(550, 406)
        Me.lb_valor_subtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_valor_subtotal.Name = "lb_valor_subtotal"
        Me.lb_valor_subtotal.Size = New System.Drawing.Size(26, 29)
        Me.lb_valor_subtotal.TabIndex = 246
        Me.lb_valor_subtotal.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(432, 406)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(107, 29)
        Me.Label19.TabIndex = 245
        Me.Label19.Text = "Subtotal:"
        '
        'bt_cargar_items_sc
        '
        Me.bt_cargar_items_sc.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_cargar_items_sc.Location = New System.Drawing.Point(360, 306)
        Me.bt_cargar_items_sc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_cargar_items_sc.Name = "bt_cargar_items_sc"
        Me.bt_cargar_items_sc.Size = New System.Drawing.Size(48, 52)
        Me.bt_cargar_items_sc.TabIndex = 247
        Me.bt_cargar_items_sc.UseVisualStyleBackColor = True
        '
        'bt_actualizar_grilla
        '
        Me.bt_actualizar_grilla.Image = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_actualizar_grilla.Location = New System.Drawing.Point(434, 306)
        Me.bt_actualizar_grilla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_actualizar_grilla.Name = "bt_actualizar_grilla"
        Me.bt_actualizar_grilla.Size = New System.Drawing.Size(76, 69)
        Me.bt_actualizar_grilla.TabIndex = 248
        Me.bt_actualizar_grilla.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.bt_actualizar_grilla.UseVisualStyleBackColor = True
        '
        'bt_nueva_sc
        '
        Me.bt_nueva_sc.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_nueva_sc.Enabled = False
        Me.bt_nueva_sc.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_nueva_sc.Location = New System.Drawing.Point(309, 308)
        Me.bt_nueva_sc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_nueva_sc.Name = "bt_nueva_sc"
        Me.bt_nueva_sc.Size = New System.Drawing.Size(48, 52)
        Me.bt_nueva_sc.TabIndex = 249
        Me.bt_nueva_sc.UseVisualStyleBackColor = True
        '
        'bt_listado_items_pend
        '
        Me.bt_listado_items_pend.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_listado_items_pend.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_listado_items_pend.Location = New System.Drawing.Point(309, 357)
        Me.bt_listado_items_pend.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_listado_items_pend.Name = "bt_listado_items_pend"
        Me.bt_listado_items_pend.Size = New System.Drawing.Size(48, 52)
        Me.bt_listado_items_pend.TabIndex = 296
        Me.bt_listado_items_pend.UseVisualStyleBackColor = True
        '
        'bt_listado_oc
        '
        Me.bt_listado_oc.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_listado_oc.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_listado_oc.Location = New System.Drawing.Point(258, 409)
        Me.bt_listado_oc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_listado_oc.Name = "bt_listado_oc"
        Me.bt_listado_oc.Size = New System.Drawing.Size(48, 52)
        Me.bt_listado_oc.TabIndex = 299
        Me.bt_listado_oc.UseVisualStyleBackColor = True
        '
        'tx_id_oc
        '
        Me.tx_id_oc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_oc.Location = New System.Drawing.Point(150, 415)
        Me.tx_id_oc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_id_oc.Name = "tx_id_oc"
        Me.tx_id_oc.Size = New System.Drawing.Size(102, 30)
        Me.tx_id_oc.TabIndex = 298
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(76, 420)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 25)
        Me.Label20.TabIndex = 297
        Me.Label20.Text = "Id_OC:"
        '
        'tx_contabilizacion
        '
        Me.tx_contabilizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_contabilizacion.Location = New System.Drawing.Point(1017, 423)
        Me.tx_contabilizacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_contabilizacion.Name = "tx_contabilizacion"
        Me.tx_contabilizacion.Size = New System.Drawing.Size(94, 30)
        Me.tx_contabilizacion.TabIndex = 301
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1012, 397)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 25)
        Me.Label12.TabIndex = 300
        Me.Label12.Text = "Cont. #:"
        '
        'bt_contabilizacion
        '
        Me.bt_contabilizacion.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_contabilizacion.Location = New System.Drawing.Point(1122, 409)
        Me.bt_contabilizacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_contabilizacion.Name = "bt_contabilizacion"
        Me.bt_contabilizacion.Size = New System.Drawing.Size(72, 71)
        Me.bt_contabilizacion.TabIndex = 302
        Me.bt_contabilizacion.UseVisualStyleBackColor = True
        '
        'lb_fecha_aprob
        '
        Me.lb_fecha_aprob.AutoSize = True
        Me.lb_fecha_aprob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_aprob.Location = New System.Drawing.Point(768, 462)
        Me.lb_fecha_aprob.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_fecha_aprob.Name = "lb_fecha_aprob"
        Me.lb_fecha_aprob.Size = New System.Drawing.Size(27, 25)
        Me.lb_fecha_aprob.TabIndex = 303
        Me.lb_fecha_aprob.Text = "..."
        '
        'chk_cmena
        '
        Me.chk_cmena.AutoSize = True
        Me.chk_cmena.Location = New System.Drawing.Point(1017, 460)
        Me.chk_cmena.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chk_cmena.Name = "chk_cmena"
        Me.chk_cmena.Size = New System.Drawing.Size(81, 24)
        Me.chk_cmena.TabIndex = 304
        Me.chk_cmena.Text = "CMNA"
        Me.chk_cmena.UseVisualStyleBackColor = True
        '
        'fm_0300_facturas_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1432, 877)
        Me.Controls.Add(Me.chk_cmena)
        Me.Controls.Add(Me.lb_fecha_aprob)
        Me.Controls.Add(Me.bt_contabilizacion)
        Me.Controls.Add(Me.tx_contabilizacion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.bt_listado_oc)
        Me.Controls.Add(Me.tx_id_oc)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.bt_listado_items_pend)
        Me.Controls.Add(Me.bt_nueva_sc)
        Me.Controls.Add(Me.bt_actualizar_grilla)
        Me.Controls.Add(Me.bt_cargar_items_sc)
        Me.Controls.Add(Me.lb_valor_subtotal)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.bt_historico_compras)
        Me.Controls.Add(Me.tx_id_item_cons_mov)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_remision_proveedor)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dtp_vencimiento_factura)
        Me.Controls.Add(Me.dtp_fecha_factura)
        Me.Controls.Add(Me.bt_solicitud_compra)
        Me.Controls.Add(Me.tx_sol_compra)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.bt_gestionar_tercero)
        Me.Controls.Add(Me.bt_catalago_items)
        Me.Controls.Add(Me.lb_valor_factura)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tx_cuadre_caja)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bt_aprobar)
        Me.Controls.Add(Me.tx_estado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_id_factura)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_oc_uno)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_nit)
        Me.Controls.Add(Me.bt_eliminar_item)
        Me.Controls.Add(Me.bt_add_item)
        Me.Controls.Add(Me.tx_id_item_sc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dg_listado)
        Me.Controls.Add(Me.lb_identificacion)
        Me.Controls.Add(Me.cm_proveedor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_factura_proveedor)
        Me.Controls.Add(Me.Label8)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "fm_0300_facturas_compras"
        Me.Text = "Factura de Compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_factura_proveedor, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cm_proveedor, 0)
        Me.Controls.SetChildIndex(Me.lb_identificacion, 0)
        Me.Controls.SetChildIndex(Me.dg_listado, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_add_item, 0)
        Me.Controls.SetChildIndex(Me.bt_eliminar_item, 0)
        Me.Controls.SetChildIndex(Me.cm_nit, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_oc_uno, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_id_factura, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_estado, 0)
        Me.Controls.SetChildIndex(Me.bt_aprobar, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_cuadre_caja, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_factura, 0)
        Me.Controls.SetChildIndex(Me.bt_catalago_items, 0)
        Me.Controls.SetChildIndex(Me.bt_gestionar_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_sol_compra, 0)
        Me.Controls.SetChildIndex(Me.bt_solicitud_compra, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_factura, 0)
        Me.Controls.SetChildIndex(Me.dtp_vencimiento_factura, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.tx_remision_proveedor, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_cons_mov, 0)
        Me.Controls.SetChildIndex(Me.bt_historico_compras, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_subtotal, 0)
        Me.Controls.SetChildIndex(Me.bt_cargar_items_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_actualizar_grilla, 0)
        Me.Controls.SetChildIndex(Me.bt_nueva_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_listado_items_pend, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.tx_id_oc, 0)
        Me.Controls.SetChildIndex(Me.bt_listado_oc, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.tx_contabilizacion, 0)
        Me.Controls.SetChildIndex(Me.bt_contabilizacion, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_aprob, 0)
        Me.Controls.SetChildIndex(Me.chk_cmena, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_factura_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lb_identificacion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dg_listado As System.Windows.Forms.DataGridView
    Friend WithEvents tx_id_item_sc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bt_add_item As System.Windows.Forms.Button
    Friend WithEvents bt_eliminar_item As System.Windows.Forms.Button
    Friend WithEvents cm_nit As System.Windows.Forms.ComboBox
    Friend WithEvents tx_oc_uno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tx_id_factura As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_estado As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bt_aprobar As System.Windows.Forms.Button
    Friend WithEvents tx_cuadre_caja As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lb_valor_factura As System.Windows.Forms.Label
    Friend WithEvents bt_catalago_items As System.Windows.Forms.Button
    Friend WithEvents bt_gestionar_tercero As System.Windows.Forms.Button
    Friend WithEvents bt_solicitud_compra As System.Windows.Forms.Button
    Friend WithEvents tx_sol_compra As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_factura As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_vencimiento_factura As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents bt_aprobar_recepcion As System.Windows.Forms.Button
    Friend WithEvents tx_remision_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents bt_historico_compras As System.Windows.Forms.Button
    Friend WithEvents tx_id_item_cons_mov As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As Label
    Friend WithEvents tx_docto_contable As TextBox
    Friend WithEvents cm_bodega As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lb_doc_entrada As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents bt_aprobar_recepcion_sin_ea As Button
    Friend WithEvents bt_docto_inv As Button
    Friend WithEvents lb_valor_subtotal As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents bt_cargar_items_sc As Button
    Friend WithEvents bt_actualizar_grilla As Button
    Friend WithEvents bt_nueva_sc As Button
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents bt_listado_items_pend As Button
    Friend WithEvents bt_listado_oc As Button
    Friend WithEvents tx_id_oc As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents tx_contabilizacion As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents bt_contabilizacion As Button
    Friend WithEvents dgocell_id_sc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_sc_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_oc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_DocEntrada As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_complementaria As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cantidad_solicitada As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_chk_inventario As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_inventario_total As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_chk_item_aprobado As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_var_costo As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_unitario As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descuento As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_total As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_iva As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_unit_iva As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_total_iva As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_estructura As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_accion As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_accion_raiz As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nota As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_planta As DataGridViewTextBoxColumn
    Friend WithEvents lb_fecha_aprob As Label
    Friend WithEvents chk_cmena As CheckBox
End Class
