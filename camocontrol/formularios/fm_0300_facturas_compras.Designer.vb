<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_facturas_compras
    Inherits camocontrol.FM_PLANTILLA

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chk_cmena = New System.Windows.Forms.CheckBox()
        Me.bt_contabilizacion = New System.Windows.Forms.Button()
        Me.tx_contabilizacion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.bt_listado_oc = New System.Windows.Forms.Button()
        Me.tx_id_oc = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.bt_listado_items_pend = New System.Windows.Forms.Button()
        Me.bt_nueva_sc = New System.Windows.Forms.Button()
        Me.bt_actualizar_grilla = New System.Windows.Forms.Button()
        Me.bt_cargar_items_sc = New System.Windows.Forms.Button()
        Me.lb_valor_subtotal = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.bt_docto_inv = New System.Windows.Forms.Button()
        Me.bt_aprobar_recepcion_sin_ea = New System.Windows.Forms.Button()
        Me.lb_doc_entrada = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tx_docto_contable = New System.Windows.Forms.TextBox()
        Me.cm_bodega = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.bt_aprobar_recepcion = New System.Windows.Forms.Button()
        Me.tx_remision_proveedor = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtp_vencimiento_factura = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_factura = New System.Windows.Forms.DateTimePicker()
        Me.bt_solicitud_compra = New System.Windows.Forms.Button()
        Me.tx_sol_compra = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.bt_gestionar_tercero = New System.Windows.Forms.Button()
        Me.bt_catalago_items = New System.Windows.Forms.Button()
        Me.lb_valor_factura = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_cuadre_caja = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_aprobar = New System.Windows.Forms.Button()
        Me.tx_estado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_id_factura = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_oc_uno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bt_eliminar_item = New System.Windows.Forms.Button()
        Me.bt_add_item = New System.Windows.Forms.Button()
        Me.tx_id_item_sc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_factura_proveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dg_listado = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_sc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_chk_item_aprobado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_id_sc_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_oc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_chk_oc_aprobada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_DocEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_complementaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cantidad_solicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_chk_inventario = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_inventario_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.bt_historico_compras = New System.Windows.Forms.Button()
        Me.tx_id_item_cons_mov = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_fecha_aprob = New System.Windows.Forms.Label()
        Me.Tx_Nombre_Tercero = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tx_id_tercero = New System.Windows.Forms.TextBox()
        Me.Tx_Nit = New System.Windows.Forms.TextBox()
        Me.lb_identificacion = New System.Windows.Forms.Label()
        Me.lb_IncumpleRequisitos = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(756, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(854, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(855, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2024/11/27"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(256, 32)
        Me.lb_titulo.Text = "Factura de Compra"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 510)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 574)
        '
        'chk_cmena
        '
        Me.chk_cmena.AutoSize = True
        Me.chk_cmena.Location = New System.Drawing.Point(676, 290)
        Me.chk_cmena.Name = "chk_cmena"
        Me.chk_cmena.Size = New System.Drawing.Size(57, 17)
        Me.chk_cmena.TabIndex = 350
        Me.chk_cmena.Text = "CMNA"
        Me.chk_cmena.UseVisualStyleBackColor = True
        '
        'bt_contabilizacion
        '
        Me.bt_contabilizacion.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_contabilizacion.Location = New System.Drawing.Point(746, 257)
        Me.bt_contabilizacion.Name = "bt_contabilizacion"
        Me.bt_contabilizacion.Size = New System.Drawing.Size(48, 46)
        Me.bt_contabilizacion.TabIndex = 349
        Me.bt_contabilizacion.UseVisualStyleBackColor = True
        '
        'tx_contabilizacion
        '
        Me.tx_contabilizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_contabilizacion.Location = New System.Drawing.Point(676, 266)
        Me.tx_contabilizacion.Name = "tx_contabilizacion"
        Me.tx_contabilizacion.Size = New System.Drawing.Size(64, 22)
        Me.tx_contabilizacion.TabIndex = 348
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(673, 249)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 16)
        Me.Label12.TabIndex = 347
        Me.Label12.Text = "Cont. #:"
        '
        'bt_listado_oc
        '
        Me.bt_listado_oc.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_listado_oc.Location = New System.Drawing.Point(170, 275)
        Me.bt_listado_oc.Name = "bt_listado_oc"
        Me.bt_listado_oc.Size = New System.Drawing.Size(32, 34)
        Me.bt_listado_oc.TabIndex = 346
        Me.bt_listado_oc.Text = "Ad"
        Me.bt_listado_oc.UseVisualStyleBackColor = True
        '
        'tx_id_oc
        '
        Me.tx_id_oc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_oc.Location = New System.Drawing.Point(98, 279)
        Me.tx_id_oc.Name = "tx_id_oc"
        Me.tx_id_oc.Size = New System.Drawing.Size(69, 22)
        Me.tx_id_oc.TabIndex = 345
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(49, 282)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 16)
        Me.Label20.TabIndex = 344
        Me.Label20.Text = "Id_OC:"
        '
        'bt_listado_items_pend
        '
        Me.bt_listado_items_pend.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_listado_items_pend.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_listado_items_pend.Location = New System.Drawing.Point(204, 241)
        Me.bt_listado_items_pend.Name = "bt_listado_items_pend"
        Me.bt_listado_items_pend.Size = New System.Drawing.Size(32, 34)
        Me.bt_listado_items_pend.TabIndex = 343
        Me.bt_listado_items_pend.UseVisualStyleBackColor = True
        '
        'bt_nueva_sc
        '
        Me.bt_nueva_sc.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_nueva_sc.Enabled = False
        Me.bt_nueva_sc.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_nueva_sc.Location = New System.Drawing.Point(204, 209)
        Me.bt_nueva_sc.Name = "bt_nueva_sc"
        Me.bt_nueva_sc.Size = New System.Drawing.Size(32, 34)
        Me.bt_nueva_sc.TabIndex = 342
        Me.bt_nueva_sc.UseVisualStyleBackColor = True
        '
        'bt_actualizar_grilla
        '
        Me.bt_actualizar_grilla.Image = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_actualizar_grilla.Location = New System.Drawing.Point(287, 208)
        Me.bt_actualizar_grilla.Name = "bt_actualizar_grilla"
        Me.bt_actualizar_grilla.Size = New System.Drawing.Size(51, 45)
        Me.bt_actualizar_grilla.TabIndex = 341
        Me.bt_actualizar_grilla.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.bt_actualizar_grilla.UseVisualStyleBackColor = True
        '
        'bt_cargar_items_sc
        '
        Me.bt_cargar_items_sc.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_cargar_items_sc.Location = New System.Drawing.Point(238, 208)
        Me.bt_cargar_items_sc.Name = "bt_cargar_items_sc"
        Me.bt_cargar_items_sc.Size = New System.Drawing.Size(32, 34)
        Me.bt_cargar_items_sc.TabIndex = 340
        Me.bt_cargar_items_sc.UseVisualStyleBackColor = True
        '
        'lb_valor_subtotal
        '
        Me.lb_valor_subtotal.AutoSize = True
        Me.lb_valor_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_subtotal.Location = New System.Drawing.Point(365, 263)
        Me.lb_valor_subtotal.Name = "lb_valor_subtotal"
        Me.lb_valor_subtotal.Size = New System.Drawing.Size(18, 20)
        Me.lb_valor_subtotal.TabIndex = 339
        Me.lb_valor_subtotal.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(286, 263)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 20)
        Me.Label19.TabIndex = 338
        Me.Label19.Text = "Subtotal:"
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
        Me.GroupBox2.Location = New System.Drawing.Point(502, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 151)
        Me.GroupBox2.TabIndex = 337
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gestionar Recepcion y Entrada"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(220, 11)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(157, 22)
        Me.dtp_fecha.TabIndex = 251
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(166, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 16)
        Me.Label18.TabIndex = 250
        Me.Label18.Text = "Fecha:"
        '
        'bt_docto_inv
        '
        Me.bt_docto_inv.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_docto_inv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_docto_inv.Location = New System.Drawing.Point(136, 122)
        Me.bt_docto_inv.Name = "bt_docto_inv"
        Me.bt_docto_inv.Size = New System.Drawing.Size(32, 22)
        Me.bt_docto_inv.TabIndex = 246
        Me.bt_docto_inv.UseVisualStyleBackColor = True
        '
        'bt_aprobar_recepcion_sin_ea
        '
        Me.bt_aprobar_recepcion_sin_ea.Image = Global.camocontrol.My.Resources.Resources.icono_checklist
        Me.bt_aprobar_recepcion_sin_ea.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_aprobar_recepcion_sin_ea.Location = New System.Drawing.Point(298, 36)
        Me.bt_aprobar_recepcion_sin_ea.Name = "bt_aprobar_recepcion_sin_ea"
        Me.bt_aprobar_recepcion_sin_ea.Size = New System.Drawing.Size(125, 55)
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
        Me.lb_doc_entrada.Location = New System.Drawing.Point(170, 125)
        Me.lb_doc_entrada.Name = "lb_doc_entrada"
        Me.lb_doc_entrada.Size = New System.Drawing.Size(28, 16)
        Me.lb_doc_entrada.TabIndex = 245
        Me.lb_doc_entrada.Text = "ND"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 125)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(130, 16)
        Me.Label17.TabIndex = 244
        Me.Label17.Text = "Documento Entrada:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(102, 16)
        Me.Label16.TabIndex = 243
        Me.Label16.Text = "Documento CG:"
        '
        'tx_docto_contable
        '
        Me.tx_docto_contable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_docto_contable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_docto_contable.Location = New System.Drawing.Point(9, 55)
        Me.tx_docto_contable.MaxLength = 30
        Me.tx_docto_contable.Name = "tx_docto_contable"
        Me.tx_docto_contable.Size = New System.Drawing.Size(127, 22)
        Me.tx_docto_contable.TabIndex = 242
        '
        'cm_bodega
        '
        Me.cm_bodega.FormattingEnabled = True
        Me.cm_bodega.Location = New System.Drawing.Point(9, 98)
        Me.cm_bodega.Name = "cm_bodega"
        Me.cm_bodega.Size = New System.Drawing.Size(412, 21)
        Me.cm_bodega.TabIndex = 241
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(9, 80)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(129, 16)
        Me.Label23.TabIndex = 240
        Me.Label23.Text = "Bodega de Entrada:"
        '
        'bt_aprobar_recepcion
        '
        Me.bt_aprobar_recepcion.Image = Global.camocontrol.My.Resources.Resources.icono_checklist
        Me.bt_aprobar_recepcion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_aprobar_recepcion.Location = New System.Drawing.Point(167, 36)
        Me.bt_aprobar_recepcion.Name = "bt_aprobar_recepcion"
        Me.bt_aprobar_recepcion.Size = New System.Drawing.Size(125, 55)
        Me.bt_aprobar_recepcion.TabIndex = 193
        Me.bt_aprobar_recepcion.Text = "Registrar Recepcion con EA"
        Me.bt_aprobar_recepcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_aprobar_recepcion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_aprobar_recepcion.UseVisualStyleBackColor = True
        '
        'tx_remision_proveedor
        '
        Me.tx_remision_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_remision_proveedor.Location = New System.Drawing.Point(693, 70)
        Me.tx_remision_proveedor.Name = "tx_remision_proveedor"
        Me.tx_remision_proveedor.Size = New System.Drawing.Size(64, 22)
        Me.tx_remision_proveedor.TabIndex = 336
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(602, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 16)
        Me.Label15.TabIndex = 335
        Me.Label15.Text = "REMISION #:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(279, 126)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 16)
        Me.Label14.TabIndex = 334
        Me.Label14.Text = "Vencimiento:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(279, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 16)
        Me.Label13.TabIndex = 333
        Me.Label13.Text = "Fecha:"
        '
        'dtp_vencimiento_factura
        '
        Me.dtp_vencimiento_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento_factura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_vencimiento_factura.Location = New System.Drawing.Point(370, 123)
        Me.dtp_vencimiento_factura.Name = "dtp_vencimiento_factura"
        Me.dtp_vencimiento_factura.Size = New System.Drawing.Size(123, 22)
        Me.dtp_vencimiento_factura.TabIndex = 332
        '
        'dtp_fecha_factura
        '
        Me.dtp_fecha_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_factura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_factura.Location = New System.Drawing.Point(370, 96)
        Me.dtp_fecha_factura.Name = "dtp_fecha_factura"
        Me.dtp_fecha_factura.Size = New System.Drawing.Size(123, 22)
        Me.dtp_fecha_factura.TabIndex = 331
        '
        'bt_solicitud_compra
        '
        Me.bt_solicitud_compra.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_solicitud_compra.Location = New System.Drawing.Point(171, 209)
        Me.bt_solicitud_compra.Name = "bt_solicitud_compra"
        Me.bt_solicitud_compra.Size = New System.Drawing.Size(32, 34)
        Me.bt_solicitud_compra.TabIndex = 330
        Me.bt_solicitud_compra.UseVisualStyleBackColor = True
        '
        'tx_sol_compra
        '
        Me.tx_sol_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_sol_compra.Location = New System.Drawing.Point(98, 217)
        Me.tx_sol_compra.Name = "tx_sol_compra"
        Me.tx_sol_compra.Size = New System.Drawing.Size(69, 22)
        Me.tx_sol_compra.TabIndex = 329
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(49, 220)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 16)
        Me.Label11.TabIndex = 328
        Me.Label11.Text = "Id_SC:"
        '
        'bt_gestionar_tercero
        '
        Me.bt_gestionar_tercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_gestionar_tercero.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.bt_gestionar_tercero.Location = New System.Drawing.Point(376, 179)
        Me.bt_gestionar_tercero.Name = "bt_gestionar_tercero"
        Me.bt_gestionar_tercero.Size = New System.Drawing.Size(117, 39)
        Me.bt_gestionar_tercero.TabIndex = 327
        Me.bt_gestionar_tercero.Text = "Gestion Terceros"
        Me.bt_gestionar_tercero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_gestionar_tercero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_gestionar_tercero.UseVisualStyleBackColor = True
        '
        'bt_catalago_items
        '
        Me.bt_catalago_items.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_catalago_items.Image = Global.camocontrol.My.Resources.Resources.icono_herramientas
        Me.bt_catalago_items.Location = New System.Drawing.Point(376, 220)
        Me.bt_catalago_items.Name = "bt_catalago_items"
        Me.bt_catalago_items.Size = New System.Drawing.Size(117, 39)
        Me.bt_catalago_items.TabIndex = 326
        Me.bt_catalago_items.Text = "Gestion Items"
        Me.bt_catalago_items.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_catalago_items.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_catalago_items.UseVisualStyleBackColor = True
        '
        'lb_valor_factura
        '
        Me.lb_valor_factura.AutoSize = True
        Me.lb_valor_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_factura.Location = New System.Drawing.Point(365, 283)
        Me.lb_valor_factura.Name = "lb_valor_factura"
        Me.lb_valor_factura.Size = New System.Drawing.Size(18, 20)
        Me.lb_valor_factura.TabIndex = 325
        Me.lb_valor_factura.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(286, 283)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 20)
        Me.Label10.TabIndex = 324
        Me.Label10.Text = "Total:"
        '
        'tx_cuadre_caja
        '
        Me.tx_cuadre_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cuadre_caja.Location = New System.Drawing.Point(842, 70)
        Me.tx_cuadre_caja.Name = "tx_cuadre_caja"
        Me.tx_cuadre_caja.Size = New System.Drawing.Size(64, 22)
        Me.tx_cuadre_caja.TabIndex = 323
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(771, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 322
        Me.Label2.Text = "C_Menor:"
        '
        'bt_aprobar
        '
        Me.bt_aprobar.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_aprobar.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_aprobar.Location = New System.Drawing.Point(509, 249)
        Me.bt_aprobar.Name = "bt_aprobar"
        Me.bt_aprobar.Size = New System.Drawing.Size(117, 39)
        Me.bt_aprobar.TabIndex = 321
        Me.bt_aprobar.Text = "Aprobar Factura"
        Me.bt_aprobar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_aprobar.UseVisualStyleBackColor = False
        '
        'tx_estado
        '
        Me.tx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estado.Location = New System.Drawing.Point(248, 70)
        Me.tx_estado.Name = "tx_estado"
        Me.tx_estado.Size = New System.Drawing.Size(165, 22)
        Me.tx_estado.TabIndex = 320
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(188, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 319
        Me.Label7.Text = "Estado:"
        '
        'tx_id_factura
        '
        Me.tx_id_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_factura.Location = New System.Drawing.Point(98, 70)
        Me.tx_id_factura.Name = "tx_id_factura"
        Me.tx_id_factura.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_factura.TabIndex = 318
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 16)
        Me.Label9.TabIndex = 317
        Me.Label9.Text = "id_fct_prov:"
        '
        'tx_oc_uno
        '
        Me.tx_oc_uno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_oc_uno.Location = New System.Drawing.Point(518, 70)
        Me.tx_oc_uno.Name = "tx_oc_uno"
        Me.tx_oc_uno.Size = New System.Drawing.Size(64, 22)
        Me.tx_oc_uno.TabIndex = 316
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(427, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 16)
        Me.Label6.TabIndex = 315
        Me.Label6.Text = "OC UNO #:"
        '
        'bt_eliminar_item
        '
        Me.bt_eliminar_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_eliminar_item.Location = New System.Drawing.Point(238, 242)
        Me.bt_eliminar_item.Name = "bt_eliminar_item"
        Me.bt_eliminar_item.Size = New System.Drawing.Size(32, 34)
        Me.bt_eliminar_item.TabIndex = 313
        Me.bt_eliminar_item.UseVisualStyleBackColor = True
        '
        'bt_add_item
        '
        Me.bt_add_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_add_item.Location = New System.Drawing.Point(170, 242)
        Me.bt_add_item.Name = "bt_add_item"
        Me.bt_add_item.Size = New System.Drawing.Size(32, 34)
        Me.bt_add_item.TabIndex = 312
        Me.bt_add_item.Text = "Ad"
        Me.bt_add_item.UseVisualStyleBackColor = True
        '
        'tx_id_item_sc
        '
        Me.tx_id_item_sc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_sc.Location = New System.Drawing.Point(98, 249)
        Me.tx_id_item_sc.Name = "tx_id_item_sc"
        Me.tx_id_item_sc.Size = New System.Drawing.Size(69, 22)
        Me.tx_id_item_sc.TabIndex = 311
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 252)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 310
        Me.Label1.Text = "Id_item_SC:"
        '
        'tx_factura_proveedor
        '
        Me.tx_factura_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_factura_proveedor.Location = New System.Drawing.Point(98, 105)
        Me.tx_factura_proveedor.Name = "tx_factura_proveedor"
        Me.tx_factura_proveedor.Size = New System.Drawing.Size(168, 29)
        Me.tx_factura_proveedor.TabIndex = 306
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 16)
        Me.Label8.TabIndex = 305
        Me.Label8.Text = "FACTURA #:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 352
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
        Me.dg_listado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_sc, Me.dgocell_chk_item_aprobado, Me.dgocell_id_sc_item, Me.dgocell_id_oc, Me.dgocell_chk_oc_aprobada, Me.dgocell_item, Me.dgocell_DocEntrada, Me.dgocell_descripcion_item, Me.dgocell_descripcion_complementaria, Me.dgocell_cantidad_solicitada, Me.dgocell_chk_inventario, Me.dgocell_inventario_total, Me.dgocell_unidad, Me.dgocell_var_costo, Me.dgocell_costo_unitario, Me.dgocell_descuento, Me.dgocell_costo_total, Me.dgocell_iva, Me.dgocell_costo_unit_iva, Me.dgocell_costo_total_iva, Me.dgocell_descripcion_estructura, Me.dgocell_id_accion, Me.dgocell_id_accion_raiz, Me.dgocell_nota, Me.dgocell_planta})
        Me.dg_listado.Location = New System.Drawing.Point(10, 331)
        Me.dg_listado.Name = "dg_listado"
        Me.dg_listado.RowHeadersWidth = 62
        Me.dg_listado.Size = New System.Drawing.Size(921, 162)
        Me.dg_listado.TabIndex = 351
        '
        'dgocell_id_sc
        '
        Me.dgocell_id_sc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgocell_id_sc.HeaderText = "Id_SC"
        Me.dgocell_id_sc.MinimumWidth = 40
        Me.dgocell_id_sc.Name = "dgocell_id_sc"
        Me.dgocell_id_sc.ReadOnly = True
        '
        'dgocell_chk_item_aprobado
        '
        Me.dgocell_chk_item_aprobado.HeaderText = "Ap"
        Me.dgocell_chk_item_aprobado.MinimumWidth = 8
        Me.dgocell_chk_item_aprobado.Name = "dgocell_chk_item_aprobado"
        Me.dgocell_chk_item_aprobado.ReadOnly = True
        Me.dgocell_chk_item_aprobado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_chk_item_aprobado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_chk_item_aprobado.Width = 30
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
        'dgocell_chk_oc_aprobada
        '
        Me.dgocell_chk_oc_aprobada.HeaderText = "Ap"
        Me.dgocell_chk_oc_aprobada.Name = "dgocell_chk_oc_aprobada"
        Me.dgocell_chk_oc_aprobada.Width = 30
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
        Me.dgocell_nota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_nota.HeaderText = "Nota"
        Me.dgocell_nota.MinimumWidth = 8
        Me.dgocell_nota.Name = "dgocell_nota"
        Me.dgocell_nota.ReadOnly = True
        Me.dgocell_nota.Width = 8
        '
        'dgocell_planta
        '
        Me.dgocell_planta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_planta.HeaderText = "Planta"
        Me.dgocell_planta.MinimumWidth = 8
        Me.dgocell_planta.Name = "dgocell_planta"
        Me.dgocell_planta.ReadOnly = True
        Me.dgocell_planta.Width = 8
        '
        'bt_historico_compras
        '
        Me.bt_historico_compras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_historico_compras.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_historico_compras.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_historico_compras.Location = New System.Drawing.Point(852, 526)
        Me.bt_historico_compras.Name = "bt_historico_compras"
        Me.bt_historico_compras.Size = New System.Drawing.Size(32, 34)
        Me.bt_historico_compras.TabIndex = 355
        Me.bt_historico_compras.UseVisualStyleBackColor = True
        '
        'tx_id_item_cons_mov
        '
        Me.tx_id_item_cons_mov.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_id_item_cons_mov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_cons_mov.Location = New System.Drawing.Point(852, 503)
        Me.tx_id_item_cons_mov.Name = "tx_id_item_cons_mov"
        Me.tx_id_item_cons_mov.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item_cons_mov.TabIndex = 354
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(794, 506)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 353
        Me.Label3.Text = "Id_item:"
        '
        'lb_fecha_aprob
        '
        Me.lb_fecha_aprob.AutoSize = True
        Me.lb_fecha_aprob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_aprob.Location = New System.Drawing.Point(511, 289)
        Me.lb_fecha_aprob.Name = "lb_fecha_aprob"
        Me.lb_fecha_aprob.Size = New System.Drawing.Size(17, 16)
        Me.lb_fecha_aprob.TabIndex = 356
        Me.lb_fecha_aprob.Text = "..."
        '
        'Tx_Nombre_Tercero
        '
        Me.Tx_Nombre_Tercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Nombre_Tercero.Location = New System.Drawing.Point(99, 153)
        Me.Tx_Nombre_Tercero.Name = "Tx_Nombre_Tercero"
        Me.Tx_Nombre_Tercero.Size = New System.Drawing.Size(397, 22)
        Me.Tx_Nombre_Tercero.TabIndex = 357
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 358
        Me.Label5.Text = "Proveedor:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(97, 203)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 12)
        Me.Label21.TabIndex = 363
        Me.Label21.Text = "Ctrl+B"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(241, 186)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(25, 16)
        Me.Label22.TabIndex = 362
        Me.Label22.Text = "Id :"
        '
        'tx_id_tercero
        '
        Me.tx_id_tercero.Enabled = False
        Me.tx_id_tercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_tercero.Location = New System.Drawing.Point(267, 180)
        Me.tx_id_tercero.Name = "tx_id_tercero"
        Me.tx_id_tercero.Size = New System.Drawing.Size(103, 22)
        Me.tx_id_tercero.TabIndex = 361
        '
        'Tx_Nit
        '
        Me.Tx_Nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Nit.Location = New System.Drawing.Point(99, 180)
        Me.Tx_Nit.Name = "Tx_Nit"
        Me.Tx_Nit.Size = New System.Drawing.Size(137, 22)
        Me.Tx_Nit.TabIndex = 359
        '
        'lb_identificacion
        '
        Me.lb_identificacion.AutoSize = True
        Me.lb_identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_identificacion.Location = New System.Drawing.Point(8, 183)
        Me.lb_identificacion.Name = "lb_identificacion"
        Me.lb_identificacion.Size = New System.Drawing.Size(36, 16)
        Me.lb_identificacion.TabIndex = 360
        Me.lb_identificacion.Text = "NIT :"
        '
        'lb_IncumpleRequisitos
        '
        Me.lb_IncumpleRequisitos.AutoSize = True
        Me.lb_IncumpleRequisitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_IncumpleRequisitos.Location = New System.Drawing.Point(286, 309)
        Me.lb_IncumpleRequisitos.Name = "lb_IncumpleRequisitos"
        Me.lb_IncumpleRequisitos.Size = New System.Drawing.Size(21, 20)
        Me.lb_IncumpleRequisitos.TabIndex = 364
        Me.lb_IncumpleRequisitos.Text = "..."
        '
        'fm_0300_facturas_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(941, 588)
        Me.Controls.Add(Me.lb_IncumpleRequisitos)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.tx_id_tercero)
        Me.Controls.Add(Me.Tx_Nit)
        Me.Controls.Add(Me.lb_identificacion)
        Me.Controls.Add(Me.Tx_Nombre_Tercero)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lb_fecha_aprob)
        Me.Controls.Add(Me.bt_historico_compras)
        Me.Controls.Add(Me.tx_id_item_cons_mov)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dg_listado)
        Me.Controls.Add(Me.chk_cmena)
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
        Me.Controls.Add(Me.bt_eliminar_item)
        Me.Controls.Add(Me.bt_add_item)
        Me.Controls.Add(Me.tx_id_item_sc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_factura_proveedor)
        Me.Controls.Add(Me.Label8)
        Me.Name = "fm_0300_facturas_compras"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_factura_proveedor, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_add_item, 0)
        Me.Controls.SetChildIndex(Me.bt_eliminar_item, 0)
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
        Me.Controls.SetChildIndex(Me.chk_cmena, 0)
        Me.Controls.SetChildIndex(Me.dg_listado, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_cons_mov, 0)
        Me.Controls.SetChildIndex(Me.bt_historico_compras, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_aprob, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Tx_Nombre_Tercero, 0)
        Me.Controls.SetChildIndex(Me.lb_identificacion, 0)
        Me.Controls.SetChildIndex(Me.Tx_Nit, 0)
        Me.Controls.SetChildIndex(Me.tx_id_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.lb_IncumpleRequisitos, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chk_cmena As CheckBox
    Friend WithEvents bt_contabilizacion As Button
    Friend WithEvents tx_contabilizacion As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents bt_listado_oc As Button
    Friend WithEvents tx_id_oc As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents bt_listado_items_pend As Button
    Friend WithEvents bt_nueva_sc As Button
    Friend WithEvents bt_actualizar_grilla As Button
    Friend WithEvents bt_cargar_items_sc As Button
    Friend WithEvents lb_valor_subtotal As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents bt_docto_inv As Button
    Friend WithEvents bt_aprobar_recepcion_sin_ea As Button
    Friend WithEvents lb_doc_entrada As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents tx_docto_contable As TextBox
    Friend WithEvents cm_bodega As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents bt_aprobar_recepcion As Button
    Friend WithEvents tx_remision_proveedor As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dtp_vencimiento_factura As DateTimePicker
    Friend WithEvents dtp_fecha_factura As DateTimePicker
    Friend WithEvents bt_solicitud_compra As Button
    Friend WithEvents tx_sol_compra As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents bt_gestionar_tercero As Button
    Friend WithEvents bt_catalago_items As Button
    Friend WithEvents lb_valor_factura As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tx_cuadre_caja As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents bt_aprobar As Button
    Friend WithEvents tx_estado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tx_id_factura As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tx_oc_uno As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents bt_eliminar_item As Button
    Friend WithEvents bt_add_item As Button
    Friend WithEvents tx_id_item_sc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tx_factura_proveedor As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dg_listado As DataGridView
    Friend WithEvents bt_historico_compras As Button
    Friend WithEvents tx_id_item_cons_mov As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lb_fecha_aprob As Label
    Friend WithEvents dgocell_id_sc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_chk_item_aprobado As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_id_sc_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_oc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_chk_oc_aprobada As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_DocEntrada As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_complementaria As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cantidad_solicitada As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_chk_inventario As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_inventario_total As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unidad As DataGridViewTextBoxColumn
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
    Friend WithEvents Tx_Nombre_Tercero As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents tx_id_tercero As TextBox
    Friend WithEvents Tx_Nit As TextBox
    Friend WithEvents lb_identificacion As Label
    Friend WithEvents lb_IncumpleRequisitos As Label
End Class
