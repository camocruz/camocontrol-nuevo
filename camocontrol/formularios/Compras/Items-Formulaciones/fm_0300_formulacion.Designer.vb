<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_formulacion
    Inherits camocontrol.FM_PLANTILLA

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dg_items = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_elemento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmi_dg_items = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mi_nuevo_item_alterno = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgocell_descripcion_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unid_medida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cost_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cost_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_descripcion = New System.Windows.Forms.TextBox()
        Me.tx_cantidad_x_bache = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_id_exmtp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lb_unidad_medicion = New System.Windows.Forms.Label()
        Me.tx_id_lmnto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_costo_unitario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lb_unid_cost_unit = New System.Windows.Forms.Label()
        Me.tx_costo_bache = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bt_calcular_costo = New System.Windows.Forms.Button()
        Me.tx_h_operario = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_h_operario_lider = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_h_supervisor = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_costo_unitario_iva = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tx_costo_bache_iva = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.bt_historico_compras = New System.Windows.Forms.Button()
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dg_var_costos = New System.Windows.Forms.DataGridView()
        Me.dgocell_varcost_id_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_varcost_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_varcost_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.bt_exportar_formula = New System.Windows.Forms.Button()
        Me.bt_calculadora_costos = New System.Windows.Forms.Button()
        Me.bt_recargar_costos_personal = New System.Windows.Forms.Button()
        Me.bt_activar_plantilla = New System.Windows.Forms.Button()
        Me.tx_h_prod_x_bache = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tx_hh_bache = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dg_items_opcionales = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_dgopcional_id_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cms_dg_items_opcionales = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mi_eliminar_item_opcional = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmi_dg_items.SuspendLayout()
        CType(Me.dg_var_costos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_items_opcionales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_dg_items_opcionales.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(836, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(934, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(935, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2015/08/20"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(301, 32)
        Me.lb_titulo.Text = "Plantilla de Produccion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 512)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 572)
        '
        'bt_g_notas
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Descripcion:"
        '
        'dg_items
        '
        Me.dg_items.AllowUserToAddRows = False
        Me.dg_items.AllowUserToDeleteRows = False
        Me.dg_items.AllowUserToOrderColumns = True
        Me.dg_items.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_elemento, Me.dgocell_id_item, Me.dgocell_descripcion_item, Me.dgocell_unid_medida, Me.dgocell_cantidad, Me.dgocell_cost_total, Me.dgocell_cost_unit})
        Me.dg_items.Location = New System.Drawing.Point(12, 229)
        Me.dg_items.Name = "dg_items"
        Me.dg_items.ReadOnly = True
        Me.dg_items.Size = New System.Drawing.Size(644, 156)
        Me.dg_items.TabIndex = 158
        '
        'dgocell_id_elemento
        '
        Me.dgocell_id_elemento.HeaderText = "id_lmto"
        Me.dgocell_id_elemento.Name = "dgocell_id_elemento"
        Me.dgocell_id_elemento.ReadOnly = True
        '
        'dgocell_id_item
        '
        Me.dgocell_id_item.ContextMenuStrip = Me.cmi_dg_items
        Me.dgocell_id_item.HeaderText = "id_item"
        Me.dgocell_id_item.Name = "dgocell_id_item"
        Me.dgocell_id_item.ReadOnly = True
        '
        'cmi_dg_items
        '
        Me.cmi_dg_items.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_nuevo_item_alterno})
        Me.cmi_dg_items.Name = "cmi_dg_items"
        Me.cmi_dg_items.Size = New System.Drawing.Size(195, 26)
        '
        'mi_nuevo_item_alterno
        '
        Me.mi_nuevo_item_alterno.Name = "mi_nuevo_item_alterno"
        Me.mi_nuevo_item_alterno.Size = New System.Drawing.Size(194, 22)
        Me.mi_nuevo_item_alterno.Text = "Agregar Item Opcional"
        '
        'dgocell_descripcion_item
        '
        Me.dgocell_descripcion_item.HeaderText = "Item"
        Me.dgocell_descripcion_item.Name = "dgocell_descripcion_item"
        Me.dgocell_descripcion_item.ReadOnly = True
        '
        'dgocell_unid_medida
        '
        Me.dgocell_unid_medida.HeaderText = "Unid"
        Me.dgocell_unid_medida.Name = "dgocell_unid_medida"
        Me.dgocell_unid_medida.ReadOnly = True
        '
        'dgocell_cantidad
        '
        Me.dgocell_cantidad.HeaderText = "Cantidad"
        Me.dgocell_cantidad.Name = "dgocell_cantidad"
        Me.dgocell_cantidad.ReadOnly = True
        '
        'dgocell_cost_total
        '
        Me.dgocell_cost_total.HeaderText = "cost_total"
        Me.dgocell_cost_total.Name = "dgocell_cost_total"
        Me.dgocell_cost_total.ReadOnly = True
        '
        'dgocell_cost_unit
        '
        Me.dgocell_cost_unit.HeaderText = "Cost_Unit"
        Me.dgocell_cost_unit.Name = "dgocell_cost_unit"
        Me.dgocell_cost_unit.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Items:"
        '
        'tx_descripcion
        '
        Me.tx_descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_descripcion.Location = New System.Drawing.Point(107, 134)
        Me.tx_descripcion.Name = "tx_descripcion"
        Me.tx_descripcion.Size = New System.Drawing.Size(598, 22)
        Me.tx_descripcion.TabIndex = 160
        '
        'tx_cantidad_x_bache
        '
        Me.tx_cantidad_x_bache.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad_x_bache.Location = New System.Drawing.Point(107, 86)
        Me.tx_cantidad_x_bache.Name = "tx_cantidad_x_bache"
        Me.tx_cantidad_x_bache.Size = New System.Drawing.Size(106, 22)
        Me.tx_cantidad_x_bache.TabIndex = 162
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 16)
        Me.Label3.TabIndex = 161
        Me.Label3.Text = "Cant x Bache:"
        '
        'tx_id_exmtp
        '
        Me.tx_id_exmtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_exmtp.Location = New System.Drawing.Point(107, 61)
        Me.tx_id_exmtp.Name = "tx_id_exmtp"
        Me.tx_id_exmtp.ReadOnly = True
        Me.tx_id_exmtp.Size = New System.Drawing.Size(106, 22)
        Me.tx_id_exmtp.TabIndex = 164
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "id_exmtp:"
        '
        'lb_unidad_medicion
        '
        Me.lb_unidad_medicion.AutoSize = True
        Me.lb_unidad_medicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_unidad_medicion.Location = New System.Drawing.Point(216, 92)
        Me.lb_unidad_medicion.Name = "lb_unidad_medicion"
        Me.lb_unidad_medicion.Size = New System.Drawing.Size(85, 16)
        Me.lb_unidad_medicion.TabIndex = 165
        Me.lb_unidad_medicion.Text = "Unid Medida"
        '
        'tx_id_lmnto
        '
        Me.tx_id_lmnto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_id_lmnto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_lmnto.Location = New System.Drawing.Point(771, 466)
        Me.tx_id_lmnto.Name = "tx_id_lmnto"
        Me.tx_id_lmnto.ReadOnly = True
        Me.tx_id_lmnto.Size = New System.Drawing.Size(89, 22)
        Me.tx_id_lmnto.TabIndex = 168
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(711, 469)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 167
        Me.Label5.Text = "Id_lmto:"
        '
        'tx_costo_unitario
        '
        Me.tx_costo_unitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_costo_unitario.Location = New System.Drawing.Point(107, 158)
        Me.tx_costo_unitario.Name = "tx_costo_unitario"
        Me.tx_costo_unitario.ReadOnly = True
        Me.tx_costo_unitario.Size = New System.Drawing.Size(106, 22)
        Me.tx_costo_unitario.TabIndex = 170
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 16)
        Me.Label6.TabIndex = 169
        Me.Label6.Text = "Costo Unitario:"
        '
        'lb_unid_cost_unit
        '
        Me.lb_unid_cost_unit.AutoSize = True
        Me.lb_unid_cost_unit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_unid_cost_unit.Location = New System.Drawing.Point(219, 161)
        Me.lb_unid_cost_unit.Name = "lb_unid_cost_unit"
        Me.lb_unid_cost_unit.Size = New System.Drawing.Size(85, 16)
        Me.lb_unid_cost_unit.TabIndex = 171
        Me.lb_unid_cost_unit.Text = "Unid Medida"
        '
        'tx_costo_bache
        '
        Me.tx_costo_bache.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_costo_bache.Location = New System.Drawing.Point(584, 158)
        Me.tx_costo_bache.Name = "tx_costo_bache"
        Me.tx_costo_bache.ReadOnly = True
        Me.tx_costo_bache.Size = New System.Drawing.Size(120, 22)
        Me.tx_costo_bache.TabIndex = 173
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(489, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 172
        Me.Label7.Text = "Costo Bache:"
        '
        'bt_calcular_costo
        '
        Me.bt_calcular_costo.Location = New System.Drawing.Point(310, 184)
        Me.bt_calcular_costo.Name = "bt_calcular_costo"
        Me.bt_calcular_costo.Size = New System.Drawing.Size(120, 23)
        Me.bt_calcular_costo.TabIndex = 174
        Me.bt_calcular_costo.Text = "Calc. Costo"
        Me.bt_calcular_costo.UseVisualStyleBackColor = True
        '
        'tx_h_operario
        '
        Me.tx_h_operario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_h_operario.Location = New System.Drawing.Point(887, 85)
        Me.tx_h_operario.Name = "tx_h_operario"
        Me.tx_h_operario.Size = New System.Drawing.Size(80, 22)
        Me.tx_h_operario.TabIndex = 176
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(792, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 16)
        Me.Label8.TabIndex = 175
        Me.Label8.Text = "$h Operario:"
        '
        'tx_h_operario_lider
        '
        Me.tx_h_operario_lider.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_h_operario_lider.Location = New System.Drawing.Point(887, 113)
        Me.tx_h_operario_lider.Name = "tx_h_operario_lider"
        Me.tx_h_operario_lider.Size = New System.Drawing.Size(80, 22)
        Me.tx_h_operario_lider.TabIndex = 178
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(792, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 177
        Me.Label9.Text = "$h Operario L:"
        '
        'tx_h_supervisor
        '
        Me.tx_h_supervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_h_supervisor.Location = New System.Drawing.Point(887, 141)
        Me.tx_h_supervisor.Name = "tx_h_supervisor"
        Me.tx_h_supervisor.Size = New System.Drawing.Size(80, 22)
        Me.tx_h_supervisor.TabIndex = 180
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(792, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 16)
        Me.Label10.TabIndex = 179
        Me.Label10.Text = "$h Supervisor:"
        '
        'tx_costo_unitario_iva
        '
        Me.tx_costo_unitario_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_costo_unitario_iva.Location = New System.Drawing.Point(107, 181)
        Me.tx_costo_unitario_iva.Name = "tx_costo_unitario_iva"
        Me.tx_costo_unitario_iva.ReadOnly = True
        Me.tx_costo_unitario_iva.Size = New System.Drawing.Size(106, 22)
        Me.tx_costo_unitario_iva.TabIndex = 182
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(59, 184)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 16)
        Me.Label11.TabIndex = 181
        Me.Label11.Text = "+ IVA:"
        '
        'tx_costo_bache_iva
        '
        Me.tx_costo_bache_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_costo_bache_iva.Location = New System.Drawing.Point(584, 181)
        Me.tx_costo_bache_iva.Name = "tx_costo_bache_iva"
        Me.tx_costo_bache_iva.ReadOnly = True
        Me.tx_costo_bache_iva.Size = New System.Drawing.Size(120, 22)
        Me.tx_costo_bache_iva.TabIndex = 184
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(536, 184)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 16)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "+ IVA:"
        '
        'bt_historico_compras
        '
        Me.bt_historico_compras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_historico_compras.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_historico_compras.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_historico_compras.Location = New System.Drawing.Point(866, 483)
        Me.bt_historico_compras.Name = "bt_historico_compras"
        Me.bt_historico_compras.Size = New System.Drawing.Size(32, 34)
        Me.bt_historico_compras.TabIndex = 200
        Me.bt_historico_compras.UseVisualStyleBackColor = True
        '
        'tx_id_item
        '
        Me.tx_id_item.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(771, 490)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.ReadOnly = True
        Me.tx_id_item.Size = New System.Drawing.Size(89, 22)
        Me.tx_id_item.TabIndex = 202
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(711, 493)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 16)
        Me.Label13.TabIndex = 201
        Me.Label13.Text = "Id_ltem:"
        '
        'dg_var_costos
        '
        Me.dg_var_costos.AllowUserToAddRows = False
        Me.dg_var_costos.AllowUserToOrderColumns = True
        Me.dg_var_costos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_var_costos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_var_costos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_varcost_id_item, Me.dgocell_varcost_costo, Me.dgocell_varcost_item})
        Me.dg_var_costos.Location = New System.Drawing.Point(662, 229)
        Me.dg_var_costos.Name = "dg_var_costos"
        Me.dg_var_costos.Size = New System.Drawing.Size(354, 228)
        Me.dg_var_costos.TabIndex = 203
        '
        'dgocell_varcost_id_item
        '
        Me.dgocell_varcost_id_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_varcost_id_item.HeaderText = "id_item"
        Me.dgocell_varcost_id_item.Name = "dgocell_varcost_id_item"
        Me.dgocell_varcost_id_item.ReadOnly = True
        Me.dgocell_varcost_id_item.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_varcost_id_item.Width = 65
        '
        'dgocell_varcost_costo
        '
        Me.dgocell_varcost_costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_varcost_costo.HeaderText = "Costo($)"
        Me.dgocell_varcost_costo.Name = "dgocell_varcost_costo"
        Me.dgocell_varcost_costo.Width = 71
        '
        'dgocell_varcost_item
        '
        Me.dgocell_varcost_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_varcost_item.HeaderText = "Item"
        Me.dgocell_varcost_item.Name = "dgocell_varcost_item"
        Me.dgocell_varcost_item.ReadOnly = True
        Me.dgocell_varcost_item.Width = 52
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(662, 210)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(180, 16)
        Me.Label14.TabIndex = 204
        Me.Label14.Text = "Variacion de costos insumos"
        '
        'bt_exportar_formula
        '
        Me.bt_exportar_formula.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_exportar_formula.Image = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_exportar_formula.Location = New System.Drawing.Point(904, 472)
        Me.bt_exportar_formula.Name = "bt_exportar_formula"
        Me.bt_exportar_formula.Size = New System.Drawing.Size(45, 45)
        Me.bt_exportar_formula.TabIndex = 205
        Me.bt_exportar_formula.UseVisualStyleBackColor = True
        '
        'bt_calculadora_costos
        '
        Me.bt_calculadora_costos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_calculadora_costos.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_calculadora_costos.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_calculadora_costos.Location = New System.Drawing.Point(984, 187)
        Me.bt_calculadora_costos.Name = "bt_calculadora_costos"
        Me.bt_calculadora_costos.Size = New System.Drawing.Size(32, 34)
        Me.bt_calculadora_costos.TabIndex = 206
        Me.bt_calculadora_costos.UseVisualStyleBackColor = True
        '
        'bt_recargar_costos_personal
        '
        Me.bt_recargar_costos_personal.BackgroundImage = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_recargar_costos_personal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_recargar_costos_personal.Location = New System.Drawing.Point(749, 107)
        Me.bt_recargar_costos_personal.Name = "bt_recargar_costos_personal"
        Me.bt_recargar_costos_personal.Size = New System.Drawing.Size(37, 34)
        Me.bt_recargar_costos_personal.TabIndex = 208
        Me.bt_recargar_costos_personal.UseVisualStyleBackColor = True
        '
        'bt_activar_plantilla
        '
        Me.bt_activar_plantilla.Location = New System.Drawing.Point(222, 61)
        Me.bt_activar_plantilla.Name = "bt_activar_plantilla"
        Me.bt_activar_plantilla.Size = New System.Drawing.Size(108, 22)
        Me.bt_activar_plantilla.TabIndex = 209
        Me.bt_activar_plantilla.Text = "Activar Plantilla"
        Me.bt_activar_plantilla.UseVisualStyleBackColor = True
        '
        'tx_h_prod_x_bache
        '
        Me.tx_h_prod_x_bache.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_h_prod_x_bache.Location = New System.Drawing.Point(345, 110)
        Me.tx_h_prod_x_bache.Name = "tx_h_prod_x_bache"
        Me.tx_h_prod_x_bache.Size = New System.Drawing.Size(106, 22)
        Me.tx_h_prod_x_bache.TabIndex = 211
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(219, 113)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(115, 16)
        Me.Label15.TabIndex = 210
        Me.Label15.Text = "H. maquina (H/M):"
        '
        'tx_hh_bache
        '
        Me.tx_hh_bache.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_hh_bache.Location = New System.Drawing.Point(107, 110)
        Me.tx_hh_bache.Name = "tx_hh_bache"
        Me.tx_hh_bache.Size = New System.Drawing.Size(106, 22)
        Me.tx_hh_bache.TabIndex = 213
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 113)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 16)
        Me.Label16.TabIndex = 212
        Me.Label16.Text = "H/H bache:"
        '
        'dg_items_opcionales
        '
        Me.dg_items_opcionales.AllowUserToAddRows = False
        Me.dg_items_opcionales.AllowUserToDeleteRows = False
        Me.dg_items_opcionales.AllowUserToOrderColumns = True
        Me.dg_items_opcionales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_items_opcionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_items_opcionales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.dgocell_dgopcional_id_item, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dg_items_opcionales.Location = New System.Drawing.Point(12, 407)
        Me.dg_items_opcionales.Name = "dg_items_opcionales"
        Me.dg_items_opcionales.ReadOnly = True
        Me.dg_items_opcionales.Size = New System.Drawing.Size(644, 105)
        Me.dg_items_opcionales.TabIndex = 214
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "id_lmto"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'dgocell_dgopcional_id_item
        '
        Me.dgocell_dgopcional_id_item.ContextMenuStrip = Me.cms_dg_items_opcionales
        Me.dgocell_dgopcional_id_item.HeaderText = "id_item"
        Me.dgocell_dgopcional_id_item.Name = "dgocell_dgopcional_id_item"
        Me.dgocell_dgopcional_id_item.ReadOnly = True
        '
        'cms_dg_items_opcionales
        '
        Me.cms_dg_items_opcionales.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_eliminar_item_opcional})
        Me.cms_dg_items_opcionales.Name = "cms_dg_items_opcionales"
        Me.cms_dg_items_opcionales.Size = New System.Drawing.Size(196, 26)
        '
        'mi_eliminar_item_opcional
        '
        Me.mi_eliminar_item_opcional.Name = "mi_eliminar_item_opcional"
        Me.mi_eliminar_item_opcional.Size = New System.Drawing.Size(195, 22)
        Me.mi_eliminar_item_opcional.Text = "Eliminar Item Opcional"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Item"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Unid"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "cost_total"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cost_Unit"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 388)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(203, 16)
        Me.Label17.TabIndex = 215
        Me.Label17.Text = "Items Opcionales / Equivalentes:"
        '
        'fm_0300_formulacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1021, 586)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.dg_items_opcionales)
        Me.Controls.Add(Me.tx_hh_bache)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tx_h_prod_x_bache)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.bt_activar_plantilla)
        Me.Controls.Add(Me.bt_recargar_costos_personal)
        Me.Controls.Add(Me.bt_calculadora_costos)
        Me.Controls.Add(Me.bt_exportar_formula)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dg_var_costos)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.bt_historico_compras)
        Me.Controls.Add(Me.tx_costo_bache_iva)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tx_costo_unitario_iva)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tx_h_supervisor)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tx_h_operario_lider)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_h_operario)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.bt_calcular_costo)
        Me.Controls.Add(Me.tx_costo_bache)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lb_unid_cost_unit)
        Me.Controls.Add(Me.tx_costo_unitario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tx_id_lmnto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lb_unidad_medicion)
        Me.Controls.Add(Me.tx_id_exmtp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_cantidad_x_bache)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_descripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dg_items)
        Me.Controls.Add(Me.Label1)
        Me.Name = "fm_0300_formulacion"
        Me.Text = "Plantilla de Produccion"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dg_items, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_descripcion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad_x_bache, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tx_id_exmtp, 0)
        Me.Controls.SetChildIndex(Me.lb_unidad_medicion, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_lmnto, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_costo_unitario, 0)
        Me.Controls.SetChildIndex(Me.lb_unid_cost_unit, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_costo_bache, 0)
        Me.Controls.SetChildIndex(Me.bt_calcular_costo, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_h_operario, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_h_operario_lider, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.tx_h_supervisor, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_costo_unitario_iva, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.tx_costo_bache_iva, 0)
        Me.Controls.SetChildIndex(Me.bt_historico_compras, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item, 0)
        Me.Controls.SetChildIndex(Me.dg_var_costos, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.bt_exportar_formula, 0)
        Me.Controls.SetChildIndex(Me.bt_calculadora_costos, 0)
        Me.Controls.SetChildIndex(Me.bt_recargar_costos_personal, 0)
        Me.Controls.SetChildIndex(Me.bt_activar_plantilla, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.tx_h_prod_x_bache, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.tx_hh_bache, 0)
        Me.Controls.SetChildIndex(Me.dg_items_opcionales, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmi_dg_items.ResumeLayout(False)
        CType(Me.dg_var_costos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_items_opcionales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_dg_items_opcionales.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dg_items As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents tx_cantidad_x_bache As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tx_id_exmtp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lb_unidad_medicion As System.Windows.Forms.Label
    Friend WithEvents tx_id_lmnto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_costo_unitario As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lb_unid_cost_unit As System.Windows.Forms.Label
    Friend WithEvents tx_costo_bache As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bt_calcular_costo As System.Windows.Forms.Button
    Friend WithEvents tx_h_operario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tx_h_operario_lider As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_h_supervisor As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tx_costo_unitario_iva As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tx_costo_bache_iva As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents bt_historico_compras As System.Windows.Forms.Button
    Friend WithEvents tx_id_item As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dg_var_costos As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents bt_exportar_formula As System.Windows.Forms.Button
    Friend WithEvents bt_calculadora_costos As System.Windows.Forms.Button
    Friend WithEvents dgocell_varcost_id_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_varcost_costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_varcost_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_recargar_costos_personal As System.Windows.Forms.Button
    Friend WithEvents bt_activar_plantilla As System.Windows.Forms.Button
    Friend WithEvents tx_h_prod_x_bache As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tx_hh_bache As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dg_items_opcionales As System.Windows.Forms.DataGridView
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmi_dg_items As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mi_nuevo_item_alterno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgocell_id_elemento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unid_medida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cost_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cost_unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cms_dg_items_opcionales As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mi_eliminar_item_opcional As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_dgopcional_id_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
