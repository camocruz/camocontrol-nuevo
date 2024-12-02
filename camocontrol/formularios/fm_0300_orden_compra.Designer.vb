<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_orden_compra
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
        Me.bt_nueva_sc = New System.Windows.Forms.Button()
        Me.bt_actualizar_grilla = New System.Windows.Forms.Button()
        Me.bt_cargar_items_sc = New System.Windows.Forms.Button()
        Me.lb_valor_subtotal = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.bt_historico_compras = New System.Windows.Forms.Button()
        Me.tx_id_item_cons_mov = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.bt_solicitud_compra = New System.Windows.Forms.Button()
        Me.tx_sol_compra = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lb_valor_aprobado = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.bt_gestionar_tercero = New System.Windows.Forms.Button()
        Me.bt_catalago_items = New System.Windows.Forms.Button()
        Me.lb_valor_factura = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bt_aprobar = New System.Windows.Forms.Button()
        Me.tx_estado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_oc_uno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bt_eliminar_item = New System.Windows.Forms.Button()
        Me.bt_add_item = New System.Windows.Forms.Button()
        Me.tx_id_item_sc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dg_listado = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_sc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_sc_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cod_uno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_complementaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cantidad_solicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_inventario_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_chk_item_aprobado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcocell_chk_item_recepcionado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        Me.dgocell_id_fcc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_doc_inv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lb_identificacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_id_orden_compra = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.bt_listado_items_pend = New System.Windows.Forms.Button()
        Me.bt_desaprobar_oc = New System.Windows.Forms.Button()
        Me.Tx_Nombre_Tercero = New System.Windows.Forms.TextBox()
        Me.Tx_Nit = New System.Windows.Forms.TextBox()
        Me.tx_id_tercero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(798, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(896, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(897, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2018/03/11"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(239, 32)
        Me.lb_titulo.Text = "Orden de Compra"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 452)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 516)
        '
        'bt_generar_informe
        '
        '
        'bt_nueva_sc
        '
        Me.bt_nueva_sc.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_nueva_sc.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_nueva_sc.Location = New System.Drawing.Point(194, 210)
        Me.bt_nueva_sc.Name = "bt_nueva_sc"
        Me.bt_nueva_sc.Size = New System.Drawing.Size(32, 34)
        Me.bt_nueva_sc.TabIndex = 294
        Me.bt_nueva_sc.UseVisualStyleBackColor = True
        '
        'bt_actualizar_grilla
        '
        Me.bt_actualizar_grilla.Image = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_actualizar_grilla.Location = New System.Drawing.Point(51, 139)
        Me.bt_actualizar_grilla.Name = "bt_actualizar_grilla"
        Me.bt_actualizar_grilla.Size = New System.Drawing.Size(51, 53)
        Me.bt_actualizar_grilla.TabIndex = 293
        Me.bt_actualizar_grilla.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.bt_actualizar_grilla.UseVisualStyleBackColor = True
        '
        'bt_cargar_items_sc
        '
        Me.bt_cargar_items_sc.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_cargar_items_sc.Location = New System.Drawing.Point(227, 209)
        Me.bt_cargar_items_sc.Name = "bt_cargar_items_sc"
        Me.bt_cargar_items_sc.Size = New System.Drawing.Size(32, 34)
        Me.bt_cargar_items_sc.TabIndex = 292
        Me.bt_cargar_items_sc.UseVisualStyleBackColor = True
        '
        'lb_valor_subtotal
        '
        Me.lb_valor_subtotal.AutoSize = True
        Me.lb_valor_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_subtotal.Location = New System.Drawing.Point(298, 151)
        Me.lb_valor_subtotal.Name = "lb_valor_subtotal"
        Me.lb_valor_subtotal.Size = New System.Drawing.Size(26, 29)
        Me.lb_valor_subtotal.TabIndex = 291
        Me.lb_valor_subtotal.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(111, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(169, 29)
        Me.Label19.TabIndex = 290
        Me.Label19.Text = "Valor Subtotal:"
        '
        'bt_historico_compras
        '
        Me.bt_historico_compras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_historico_compras.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_historico_compras.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_historico_compras.Location = New System.Drawing.Point(878, 434)
        Me.bt_historico_compras.Name = "bt_historico_compras"
        Me.bt_historico_compras.Size = New System.Drawing.Size(32, 34)
        Me.bt_historico_compras.TabIndex = 288
        Me.bt_historico_compras.UseVisualStyleBackColor = True
        '
        'tx_id_item_cons_mov
        '
        Me.tx_id_item_cons_mov.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_id_item_cons_mov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_cons_mov.Location = New System.Drawing.Point(878, 411)
        Me.tx_id_item_cons_mov.Name = "tx_id_item_cons_mov"
        Me.tx_id_item_cons_mov.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item_cons_mov.TabIndex = 287
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(820, 414)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 286
        Me.Label3.Text = "Id_item:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(757, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 16)
        Me.Label13.TabIndex = 282
        Me.Label13.Text = "Fecha:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(809, 62)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(148, 22)
        Me.dtp_fecha.TabIndex = 280
        '
        'bt_solicitud_compra
        '
        Me.bt_solicitud_compra.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_solicitud_compra.Location = New System.Drawing.Point(162, 210)
        Me.bt_solicitud_compra.Name = "bt_solicitud_compra"
        Me.bt_solicitud_compra.Size = New System.Drawing.Size(32, 34)
        Me.bt_solicitud_compra.TabIndex = 279
        Me.bt_solicitud_compra.UseVisualStyleBackColor = True
        '
        'tx_sol_compra
        '
        Me.tx_sol_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_sol_compra.Location = New System.Drawing.Point(77, 211)
        Me.tx_sol_compra.Name = "tx_sol_compra"
        Me.tx_sol_compra.Size = New System.Drawing.Size(79, 22)
        Me.tx_sol_compra.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 214)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 16)
        Me.Label11.TabIndex = 277
        Me.Label11.Text = "Id_SC:"
        '
        'lb_valor_aprobado
        '
        Me.lb_valor_aprobado.AutoSize = True
        Me.lb_valor_aprobado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_aprobado.Location = New System.Drawing.Point(298, 124)
        Me.lb_valor_aprobado.Name = "lb_valor_aprobado"
        Me.lb_valor_aprobado.Size = New System.Drawing.Size(26, 29)
        Me.lb_valor_aprobado.TabIndex = 276
        Me.lb_valor_aprobado.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(111, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(187, 29)
        Me.Label12.TabIndex = 275
        Me.Label12.Text = "Valor Aprobado:"
        '
        'bt_gestionar_tercero
        '
        Me.bt_gestionar_tercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_gestionar_tercero.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.bt_gestionar_tercero.Location = New System.Drawing.Point(686, 153)
        Me.bt_gestionar_tercero.Name = "bt_gestionar_tercero"
        Me.bt_gestionar_tercero.Size = New System.Drawing.Size(117, 39)
        Me.bt_gestionar_tercero.TabIndex = 274
        Me.bt_gestionar_tercero.Text = "Gestion Terceros"
        Me.bt_gestionar_tercero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_gestionar_tercero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_gestionar_tercero.UseVisualStyleBackColor = True
        '
        'bt_catalago_items
        '
        Me.bt_catalago_items.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_catalago_items.Image = Global.camocontrol.My.Resources.Resources.icono_herramientas
        Me.bt_catalago_items.Location = New System.Drawing.Point(809, 153)
        Me.bt_catalago_items.Name = "bt_catalago_items"
        Me.bt_catalago_items.Size = New System.Drawing.Size(117, 39)
        Me.bt_catalago_items.TabIndex = 273
        Me.bt_catalago_items.Text = "Gestion Items"
        Me.bt_catalago_items.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_catalago_items.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_catalago_items.UseVisualStyleBackColor = True
        '
        'lb_valor_factura
        '
        Me.lb_valor_factura.AutoSize = True
        Me.lb_valor_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_factura.Location = New System.Drawing.Point(298, 177)
        Me.lb_valor_factura.Name = "lb_valor_factura"
        Me.lb_valor_factura.Size = New System.Drawing.Size(26, 29)
        Me.lb_valor_factura.TabIndex = 272
        Me.lb_valor_factura.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(111, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(161, 29)
        Me.Label10.TabIndex = 271
        Me.Label10.Text = "Valor Factura:"
        '
        'bt_aprobar
        '
        Me.bt_aprobar.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_aprobar.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_aprobar.Location = New System.Drawing.Point(563, 153)
        Me.bt_aprobar.Name = "bt_aprobar"
        Me.bt_aprobar.Size = New System.Drawing.Size(117, 39)
        Me.bt_aprobar.TabIndex = 268
        Me.bt_aprobar.Text = "Aprobar OC"
        Me.bt_aprobar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_aprobar.UseVisualStyleBackColor = False
        '
        'tx_estado
        '
        Me.tx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estado.Location = New System.Drawing.Point(388, 61)
        Me.tx_estado.Name = "tx_estado"
        Me.tx_estado.Size = New System.Drawing.Size(165, 22)
        Me.tx_estado.TabIndex = 267
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(328, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 266
        Me.Label7.Text = "Estado:"
        '
        'tx_oc_uno
        '
        Me.tx_oc_uno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_oc_uno.Location = New System.Drawing.Point(658, 61)
        Me.tx_oc_uno.Name = "tx_oc_uno"
        Me.tx_oc_uno.Size = New System.Drawing.Size(64, 22)
        Me.tx_oc_uno.TabIndex = 263
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(567, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 16)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "OC UNO #:"
        '
        'bt_eliminar_item
        '
        Me.bt_eliminar_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_eliminar_item.Location = New System.Drawing.Point(481, 211)
        Me.bt_eliminar_item.Name = "bt_eliminar_item"
        Me.bt_eliminar_item.Size = New System.Drawing.Size(32, 34)
        Me.bt_eliminar_item.TabIndex = 260
        Me.bt_eliminar_item.UseVisualStyleBackColor = True
        '
        'bt_add_item
        '
        Me.bt_add_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_add_item.Location = New System.Drawing.Point(443, 211)
        Me.bt_add_item.Name = "bt_add_item"
        Me.bt_add_item.Size = New System.Drawing.Size(32, 34)
        Me.bt_add_item.TabIndex = 259
        Me.bt_add_item.Text = "Ad"
        Me.bt_add_item.UseVisualStyleBackColor = True
        '
        'tx_id_item_sc
        '
        Me.tx_id_item_sc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_sc.Location = New System.Drawing.Point(358, 211)
        Me.tx_id_item_sc.Name = "tx_id_item_sc"
        Me.tx_id_item_sc.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item_sc.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(278, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Id_item_SC:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 256
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
        Me.dg_listado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_sc, Me.dgocell_id_sc_item, Me.dgocell_item, Me.dgocell_cod_uno, Me.dgocell_descripcion_item, Me.dgocell_descripcion_complementaria, Me.dgocell_cantidad_solicitada, Me.dgocell_inventario_total, Me.dgocell_unidad, Me.dgocell_chk_item_aprobado, Me.dgcocell_chk_item_recepcionado, Me.dgocell_var_costo, Me.dgocell_costo_unitario, Me.dgocell_descuento, Me.dgocell_costo_total, Me.dgocell_iva, Me.dgocell_costo_unit_iva, Me.dgocell_costo_total_iva, Me.dgocell_descripcion_estructura, Me.dgocell_id_accion, Me.dgocell_id_accion_raiz, Me.dgocell_nota, Me.dgocell_id_fcc, Me.dgocell_id_doc_inv})
        Me.dg_listado.Location = New System.Drawing.Point(28, 261)
        Me.dg_listado.Name = "dg_listado"
        Me.dg_listado.Size = New System.Drawing.Size(929, 144)
        Me.dg_listado.TabIndex = 255
        '
        'dgocell_id_sc
        '
        Me.dgocell_id_sc.HeaderText = "Id_SC"
        Me.dgocell_id_sc.Name = "dgocell_id_sc"
        Me.dgocell_id_sc.ReadOnly = True
        Me.dgocell_id_sc.Width = 50
        '
        'dgocell_id_sc_item
        '
        Me.dgocell_id_sc_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_id_sc_item.HeaderText = "Id_sc_item"
        Me.dgocell_id_sc_item.Name = "dgocell_id_sc_item"
        Me.dgocell_id_sc_item.ReadOnly = True
        Me.dgocell_id_sc_item.Width = 5
        '
        'dgocell_item
        '
        Me.dgocell_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_item.HeaderText = "Cod_Item"
        Me.dgocell_item.Name = "dgocell_item"
        Me.dgocell_item.ReadOnly = True
        Me.dgocell_item.Width = 5
        '
        'dgocell_cod_uno
        '
        Me.dgocell_cod_uno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_cod_uno.HeaderText = "Cod_Uno"
        Me.dgocell_cod_uno.Name = "dgocell_cod_uno"
        Me.dgocell_cod_uno.ReadOnly = True
        Me.dgocell_cod_uno.Width = 5
        '
        'dgocell_descripcion_item
        '
        Me.dgocell_descripcion_item.HeaderText = "Item"
        Me.dgocell_descripcion_item.Name = "dgocell_descripcion_item"
        Me.dgocell_descripcion_item.ReadOnly = True
        Me.dgocell_descripcion_item.Width = 200
        '
        'dgocell_descripcion_complementaria
        '
        Me.dgocell_descripcion_complementaria.HeaderText = "Descripcion Complementaria"
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
        'dgocell_inventario_total
        '
        Me.dgocell_inventario_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_inventario_total.HeaderText = "Inventarario"
        Me.dgocell_inventario_total.Name = "dgocell_inventario_total"
        Me.dgocell_inventario_total.Width = 88
        '
        'dgocell_unidad
        '
        Me.dgocell_unidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_unidad.HeaderText = "Unidad"
        Me.dgocell_unidad.Name = "dgocell_unidad"
        Me.dgocell_unidad.ReadOnly = True
        Me.dgocell_unidad.Width = 5
        '
        'dgocell_chk_item_aprobado
        '
        Me.dgocell_chk_item_aprobado.HeaderText = "Apb"
        Me.dgocell_chk_item_aprobado.Name = "dgocell_chk_item_aprobado"
        Me.dgocell_chk_item_aprobado.ReadOnly = True
        Me.dgocell_chk_item_aprobado.Width = 30
        '
        'dgcocell_chk_item_recepcionado
        '
        Me.dgcocell_chk_item_recepcionado.HeaderText = "Rcd"
        Me.dgcocell_chk_item_recepcionado.Name = "dgcocell_chk_item_recepcionado"
        Me.dgcocell_chk_item_recepcionado.ReadOnly = True
        Me.dgcocell_chk_item_recepcionado.Width = 30
        '
        'dgocell_var_costo
        '
        Me.dgocell_var_costo.HeaderText = "%V"
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
        Me.dgocell_descripcion_estructura.Name = "dgocell_descripcion_estructura"
        Me.dgocell_descripcion_estructura.ReadOnly = True
        Me.dgocell_descripcion_estructura.Width = 5
        '
        'dgocell_id_accion
        '
        Me.dgocell_id_accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgocell_id_accion.HeaderText = "id_acc"
        Me.dgocell_id_accion.Name = "dgocell_id_accion"
        Me.dgocell_id_accion.ReadOnly = True
        Me.dgocell_id_accion.Width = 45
        '
        'dgocell_id_accion_raiz
        '
        Me.dgocell_id_accion_raiz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_id_accion_raiz.HeaderText = "Raiz"
        Me.dgocell_id_accion_raiz.Name = "dgocell_id_accion_raiz"
        Me.dgocell_id_accion_raiz.Width = 5
        '
        'dgocell_nota
        '
        Me.dgocell_nota.HeaderText = "Nota"
        Me.dgocell_nota.Name = "dgocell_nota"
        Me.dgocell_nota.ReadOnly = True
        Me.dgocell_nota.Width = 200
        '
        'dgocell_id_fcc
        '
        Me.dgocell_id_fcc.HeaderText = "id_fcc"
        Me.dgocell_id_fcc.Name = "dgocell_id_fcc"
        Me.dgocell_id_fcc.ReadOnly = True
        Me.dgocell_id_fcc.Width = 50
        '
        'dgocell_id_doc_inv
        '
        Me.dgocell_id_doc_inv.HeaderText = "id_doc_inv"
        Me.dgocell_id_doc_inv.Name = "dgocell_id_doc_inv"
        Me.dgocell_id_doc_inv.ReadOnly = True
        '
        'lb_identificacion
        '
        Me.lb_identificacion.AutoSize = True
        Me.lb_identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_identificacion.Location = New System.Drawing.Point(517, 100)
        Me.lb_identificacion.Name = "lb_identificacion"
        Me.lb_identificacion.Size = New System.Drawing.Size(124, 16)
        Me.lb_identificacion.TabIndex = 254
        Me.lb_identificacion.Text = "Identificación / NIT :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 252
        Me.Label5.Text = "Proveedor:"
        '
        'tx_id_orden_compra
        '
        Me.tx_id_orden_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_orden_compra.Location = New System.Drawing.Point(116, 62)
        Me.tx_id_orden_compra.Name = "tx_id_orden_compra"
        Me.tx_id_orden_compra.Size = New System.Drawing.Size(201, 29)
        Me.tx_id_orden_compra.TabIndex = 251
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(25, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "OC #:"
        '
        'bt_listado_items_pend
        '
        Me.bt_listado_items_pend.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_listado_items_pend.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_listado_items_pend.Location = New System.Drawing.Point(519, 211)
        Me.bt_listado_items_pend.Name = "bt_listado_items_pend"
        Me.bt_listado_items_pend.Size = New System.Drawing.Size(32, 34)
        Me.bt_listado_items_pend.TabIndex = 295
        Me.bt_listado_items_pend.UseVisualStyleBackColor = True
        '
        'bt_desaprobar_oc
        '
        Me.bt_desaprobar_oc.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_desaprobar_oc.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_desaprobar_oc.Location = New System.Drawing.Point(686, 199)
        Me.bt_desaprobar_oc.Name = "bt_desaprobar_oc"
        Me.bt_desaprobar_oc.Size = New System.Drawing.Size(117, 39)
        Me.bt_desaprobar_oc.TabIndex = 296
        Me.bt_desaprobar_oc.Text = "Desaprobar OC"
        Me.bt_desaprobar_oc.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_desaprobar_oc.UseVisualStyleBackColor = False
        '
        'Tx_Nombre_Tercero
        '
        Me.Tx_Nombre_Tercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Nombre_Tercero.Location = New System.Drawing.Point(116, 94)
        Me.Tx_Nombre_Tercero.Name = "Tx_Nombre_Tercero"
        Me.Tx_Nombre_Tercero.Size = New System.Drawing.Size(397, 22)
        Me.Tx_Nombre_Tercero.TabIndex = 0
        '
        'Tx_Nit
        '
        Me.Tx_Nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Nit.Location = New System.Drawing.Point(658, 94)
        Me.Tx_Nit.Name = "Tx_Nit"
        Me.Tx_Nit.Size = New System.Drawing.Size(156, 22)
        Me.Tx_Nit.TabIndex = 1
        '
        'tx_id_tercero
        '
        Me.tx_id_tercero.Enabled = False
        Me.tx_id_tercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_tercero.Location = New System.Drawing.Point(846, 94)
        Me.tx_id_tercero.Name = "tx_id_tercero"
        Me.tx_id_tercero.Size = New System.Drawing.Size(111, 22)
        Me.tx_id_tercero.TabIndex = 299
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(820, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 16)
        Me.Label2.TabIndex = 300
        Me.Label2.Text = "Id :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(114, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 12)
        Me.Label9.TabIndex = 301
        Me.Label9.Text = "Ctrl+B"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(656, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 12)
        Me.Label14.TabIndex = 302
        Me.Label14.Text = "Ctrl+B"
        '
        'fm_0300_orden_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(983, 530)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_id_tercero)
        Me.Controls.Add(Me.Tx_Nit)
        Me.Controls.Add(Me.Tx_Nombre_Tercero)
        Me.Controls.Add(Me.bt_desaprobar_oc)
        Me.Controls.Add(Me.bt_listado_items_pend)
        Me.Controls.Add(Me.bt_nueva_sc)
        Me.Controls.Add(Me.bt_actualizar_grilla)
        Me.Controls.Add(Me.bt_cargar_items_sc)
        Me.Controls.Add(Me.lb_valor_subtotal)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.bt_historico_compras)
        Me.Controls.Add(Me.tx_id_item_cons_mov)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.bt_solicitud_compra)
        Me.Controls.Add(Me.tx_sol_compra)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lb_valor_aprobado)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.bt_gestionar_tercero)
        Me.Controls.Add(Me.bt_catalago_items)
        Me.Controls.Add(Me.lb_valor_factura)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.bt_aprobar)
        Me.Controls.Add(Me.tx_estado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_oc_uno)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.bt_eliminar_item)
        Me.Controls.Add(Me.bt_add_item)
        Me.Controls.Add(Me.tx_id_item_sc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dg_listado)
        Me.Controls.Add(Me.lb_identificacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_id_orden_compra)
        Me.Controls.Add(Me.Label8)
        Me.Name = "fm_0300_orden_compra"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_id_orden_compra, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lb_identificacion, 0)
        Me.Controls.SetChildIndex(Me.dg_listado, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_add_item, 0)
        Me.Controls.SetChildIndex(Me.bt_eliminar_item, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_oc_uno, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_estado, 0)
        Me.Controls.SetChildIndex(Me.bt_aprobar, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_factura, 0)
        Me.Controls.SetChildIndex(Me.bt_catalago_items, 0)
        Me.Controls.SetChildIndex(Me.bt_gestionar_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_aprobado, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_sol_compra, 0)
        Me.Controls.SetChildIndex(Me.bt_solicitud_compra, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_cons_mov, 0)
        Me.Controls.SetChildIndex(Me.bt_historico_compras, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_subtotal, 0)
        Me.Controls.SetChildIndex(Me.bt_cargar_items_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_actualizar_grilla, 0)
        Me.Controls.SetChildIndex(Me.bt_nueva_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_listado_items_pend, 0)
        Me.Controls.SetChildIndex(Me.bt_desaprobar_oc, 0)
        Me.Controls.SetChildIndex(Me.Tx_Nombre_Tercero, 0)
        Me.Controls.SetChildIndex(Me.Tx_Nit, 0)
        Me.Controls.SetChildIndex(Me.tx_id_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bt_nueva_sc As Button
    Friend WithEvents bt_actualizar_grilla As Button
    Friend WithEvents bt_cargar_items_sc As Button
    Friend WithEvents lb_valor_subtotal As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents bt_historico_compras As Button
    Friend WithEvents tx_id_item_cons_mov As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents bt_solicitud_compra As Button
    Friend WithEvents tx_sol_compra As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lb_valor_aprobado As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents bt_gestionar_tercero As Button
    Friend WithEvents bt_catalago_items As Button
    Friend WithEvents lb_valor_factura As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents bt_aprobar As Button
    Friend WithEvents tx_estado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tx_oc_uno As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents bt_eliminar_item As Button
    Friend WithEvents bt_add_item As Button
    Friend WithEvents tx_id_item_sc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dg_listado As DataGridView
    Friend WithEvents lb_identificacion As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tx_id_orden_compra As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents bt_listado_items_pend As Button
    Friend WithEvents bt_desaprobar_oc As Button
    Friend WithEvents dgocell_id_sc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_sc_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cod_uno As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_complementaria As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cantidad_solicitada As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_inventario_total As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_chk_item_aprobado As DataGridViewTextBoxColumn
    Friend WithEvents dgcocell_chk_item_recepcionado As DataGridViewCheckBoxColumn
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
    Friend WithEvents dgocell_id_fcc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_doc_inv As DataGridViewTextBoxColumn
    Friend WithEvents Tx_Nombre_Tercero As TextBox
    Friend WithEvents Tx_Nit As TextBox
    Friend WithEvents tx_id_tercero As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
End Class
