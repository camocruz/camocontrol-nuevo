<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_facturas_compras_recepcion
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
        Me.cm_proveedor = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_factura_proveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lb_identificacion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dg_listado = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_sc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_sc_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cod_uno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_complementaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cantidad_solicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_chk_item_aprobado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_unitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_total_iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_estructura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tx_id_item_sc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_add_item = New System.Windows.Forms.Button()
        Me.bt_eliminar_item = New System.Windows.Forms.Button()
        Me.cm_nit = New System.Windows.Forms.ComboBox()
        Me.tx_id_recepcion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_estado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bt_gestionar_tercero = New System.Windows.Forms.Button()
        Me.bt_solicitud_compra = New System.Windows.Forms.Button()
        Me.tx_sol_compra = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_fecha_factura = New System.Windows.Forms.DateTimePicker()
        Me.dtp_vencimiento_factura = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.bt_aprobar_recepcion = New System.Windows.Forms.Button()
        Me.bt_historico_compras = New System.Windows.Forms.Button()
        Me.tx_id_item_cons_mov = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cm_responsable = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.bt_inspeccion_ensayo = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tx_valor_factura = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtp_fecha_creacion = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(647, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(745, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(746, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2015/01/02"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(291, 32)
        Me.lb_titulo.Text = "Recepcion de Almacen"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 451)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 511)
        '
        'cm_proveedor
        '
        Me.cm_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_proveedor.FormattingEnabled = True
        Me.cm_proveedor.Location = New System.Drawing.Point(90, 86)
        Me.cm_proveedor.Name = "cm_proveedor"
        Me.cm_proveedor.Size = New System.Drawing.Size(405, 24)
        Me.cm_proveedor.TabIndex = 149
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 148
        Me.Label5.Text = "Proveedor:"
        '
        'tx_factura_proveedor
        '
        Me.tx_factura_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_factura_proveedor.Location = New System.Drawing.Point(97, 12)
        Me.tx_factura_proveedor.Name = "tx_factura_proveedor"
        Me.tx_factura_proveedor.Size = New System.Drawing.Size(123, 22)
        Me.tx_factura_proveedor.TabIndex = 147
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 16)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "FACTURA #:"
        '
        'lb_identificacion
        '
        Me.lb_identificacion.AutoSize = True
        Me.lb_identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_identificacion.Location = New System.Drawing.Point(501, 92)
        Me.lb_identificacion.Name = "lb_identificacion"
        Me.lb_identificacion.Size = New System.Drawing.Size(124, 16)
        Me.lb_identificacion.TabIndex = 151
        Me.lb_identificacion.Text = "Identificación / NIT :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 321)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
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
        Me.dg_listado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_sc, Me.dgocell_id_sc_item, Me.dgocell_item, Me.dgocell_cod_uno, Me.dgocell_descripcion_item, Me.dgocell_descripcion_complementaria, Me.dgocell_cantidad_solicitada, Me.dgocell_unidad, Me.dgocell_chk_item_aprobado, Me.dgocell_costo_unitario, Me.dgocell_costo_total, Me.dgocell_descuento, Me.dgocell_iva, Me.dgocell_costo_total_iva, Me.dgocell_descripcion_estructura, Me.dgocell_id_accion, Me.dgocell_nota})
        Me.dg_listado.Location = New System.Drawing.Point(12, 338)
        Me.dg_listado.Name = "dg_listado"
        Me.dg_listado.ReadOnly = True
        Me.dg_listado.Size = New System.Drawing.Size(806, 109)
        Me.dg_listado.TabIndex = 154
        '
        'dgocell_id_sc
        '
        Me.dgocell_id_sc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_id_sc.HeaderText = "Id_SC"
        Me.dgocell_id_sc.Name = "dgocell_id_sc"
        Me.dgocell_id_sc.ReadOnly = True
        Me.dgocell_id_sc.Width = 5
        '
        'dgocell_id_sc_item
        '
        Me.dgocell_id_sc_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
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
        Me.dgocell_cod_uno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
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
        Me.dgocell_cantidad_solicitada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_cantidad_solicitada.HeaderText = "Cant. Sol."
        Me.dgocell_cantidad_solicitada.Name = "dgocell_cantidad_solicitada"
        Me.dgocell_cantidad_solicitada.ReadOnly = True
        Me.dgocell_cantidad_solicitada.Width = 5
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
        'dgocell_costo_unitario
        '
        Me.dgocell_costo_unitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_costo_unitario.HeaderText = "$_Unit"
        Me.dgocell_costo_unitario.Name = "dgocell_costo_unitario"
        Me.dgocell_costo_unitario.ReadOnly = True
        Me.dgocell_costo_unitario.Width = 5
        '
        'dgocell_costo_total
        '
        Me.dgocell_costo_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_costo_total.HeaderText = "$_Sub_T"
        Me.dgocell_costo_total.Name = "dgocell_costo_total"
        Me.dgocell_costo_total.ReadOnly = True
        Me.dgocell_costo_total.Width = 5
        '
        'dgocell_descuento
        '
        Me.dgocell_descuento.HeaderText = "%_Desc"
        Me.dgocell_descuento.Name = "dgocell_descuento"
        Me.dgocell_descuento.ReadOnly = True
        Me.dgocell_descuento.Width = 50
        '
        'dgocell_iva
        '
        Me.dgocell_iva.HeaderText = "IVA"
        Me.dgocell_iva.Name = "dgocell_iva"
        Me.dgocell_iva.ReadOnly = True
        Me.dgocell_iva.Width = 40
        '
        'dgocell_costo_total_iva
        '
        Me.dgocell_costo_total_iva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_costo_total_iva.HeaderText = "$_Tot"
        Me.dgocell_costo_total_iva.Name = "dgocell_costo_total_iva"
        Me.dgocell_costo_total_iva.ReadOnly = True
        Me.dgocell_costo_total_iva.Width = 5
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
        'dgocell_nota
        '
        Me.dgocell_nota.HeaderText = "Nota"
        Me.dgocell_nota.Name = "dgocell_nota"
        Me.dgocell_nota.ReadOnly = True
        Me.dgocell_nota.Width = 200
        '
        'tx_id_item_sc
        '
        Me.tx_id_item_sc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_sc.Location = New System.Drawing.Point(82, 43)
        Me.tx_id_item_sc.Name = "tx_id_item_sc"
        Me.tx_id_item_sc.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item_sc.TabIndex = 157
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Id_item_SC:"
        '
        'bt_add_item
        '
        Me.bt_add_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_add_item.Location = New System.Drawing.Point(82, 67)
        Me.bt_add_item.Name = "bt_add_item"
        Me.bt_add_item.Size = New System.Drawing.Size(32, 34)
        Me.bt_add_item.TabIndex = 158
        Me.bt_add_item.Text = "Ad"
        Me.bt_add_item.UseVisualStyleBackColor = True
        '
        'bt_eliminar_item
        '
        Me.bt_eliminar_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_eliminar_item.Location = New System.Drawing.Point(119, 67)
        Me.bt_eliminar_item.Name = "bt_eliminar_item"
        Me.bt_eliminar_item.Size = New System.Drawing.Size(32, 34)
        Me.bt_eliminar_item.TabIndex = 159
        Me.bt_eliminar_item.UseVisualStyleBackColor = True
        '
        'cm_nit
        '
        Me.cm_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_nit.FormattingEnabled = True
        Me.cm_nit.Location = New System.Drawing.Point(631, 86)
        Me.cm_nit.Name = "cm_nit"
        Me.cm_nit.Size = New System.Drawing.Size(187, 24)
        Me.cm_nit.TabIndex = 160
        '
        'tx_id_recepcion
        '
        Me.tx_id_recepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_recepcion.Location = New System.Drawing.Point(90, 61)
        Me.tx_id_recepcion.Name = "tx_id_recepcion"
        Me.tx_id_recepcion.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_recepcion.TabIndex = 168
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 16)
        Me.Label9.TabIndex = 167
        Me.Label9.Text = "id_recep.:"
        '
        'tx_estado
        '
        Me.tx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estado.Location = New System.Drawing.Point(190, 25)
        Me.tx_estado.Name = "tx_estado"
        Me.tx_estado.Size = New System.Drawing.Size(165, 22)
        Me.tx_estado.TabIndex = 170
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(130, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Estado:"
        '
        'bt_gestionar_tercero
        '
        Me.bt_gestionar_tercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_gestionar_tercero.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.bt_gestionar_tercero.Location = New System.Drawing.Point(701, 167)
        Me.bt_gestionar_tercero.Name = "bt_gestionar_tercero"
        Me.bt_gestionar_tercero.Size = New System.Drawing.Size(117, 39)
        Me.bt_gestionar_tercero.TabIndex = 183
        Me.bt_gestionar_tercero.Text = "Gestion Terceros"
        Me.bt_gestionar_tercero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_gestionar_tercero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_gestionar_tercero.UseVisualStyleBackColor = True
        '
        'bt_solicitud_compra
        '
        Me.bt_solicitud_compra.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_solicitud_compra.Location = New System.Drawing.Point(166, 16)
        Me.bt_solicitud_compra.Name = "bt_solicitud_compra"
        Me.bt_solicitud_compra.Size = New System.Drawing.Size(32, 34)
        Me.bt_solicitud_compra.TabIndex = 188
        Me.bt_solicitud_compra.UseVisualStyleBackColor = True
        '
        'tx_sol_compra
        '
        Me.tx_sol_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_sol_compra.Location = New System.Drawing.Point(82, 18)
        Me.tx_sol_compra.Name = "tx_sol_compra"
        Me.tx_sol_compra.Size = New System.Drawing.Size(79, 22)
        Me.tx_sol_compra.TabIndex = 187
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 16)
        Me.Label11.TabIndex = 186
        Me.Label11.Text = "Id_SC:"
        '
        'dtp_fecha_factura
        '
        Me.dtp_fecha_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_factura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_factura.Location = New System.Drawing.Point(97, 58)
        Me.dtp_fecha_factura.Name = "dtp_fecha_factura"
        Me.dtp_fecha_factura.Size = New System.Drawing.Size(123, 22)
        Me.dtp_fecha_factura.TabIndex = 189
        '
        'dtp_vencimiento_factura
        '
        Me.dtp_vencimiento_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento_factura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_vencimiento_factura.Location = New System.Drawing.Point(97, 35)
        Me.dtp_vencimiento_factura.Name = "dtp_vencimiento_factura"
        Me.dtp_vencimiento_factura.Size = New System.Drawing.Size(123, 22)
        Me.dtp_vencimiento_factura.TabIndex = 190
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 16)
        Me.Label13.TabIndex = 191
        Me.Label13.Text = "Fecha Fact:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 16)
        Me.Label14.TabIndex = 192
        Me.Label14.Text = "Vencimiento:"
        '
        'bt_aprobar_recepcion
        '
        Me.bt_aprobar_recepcion.Image = Global.camocontrol.My.Resources.Resources.OK
        Me.bt_aprobar_recepcion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_aprobar_recepcion.Location = New System.Drawing.Point(701, 212)
        Me.bt_aprobar_recepcion.Name = "bt_aprobar_recepcion"
        Me.bt_aprobar_recepcion.Size = New System.Drawing.Size(117, 39)
        Me.bt_aprobar_recepcion.TabIndex = 193
        Me.bt_aprobar_recepcion.Text = "Aprobar Recepcion"
        Me.bt_aprobar_recepcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_aprobar_recepcion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_aprobar_recepcion.UseVisualStyleBackColor = True
        '
        'bt_historico_compras
        '
        Me.bt_historico_compras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_historico_compras.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_historico_compras.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_historico_compras.Location = New System.Drawing.Point(395, 137)
        Me.bt_historico_compras.Name = "bt_historico_compras"
        Me.bt_historico_compras.Size = New System.Drawing.Size(32, 34)
        Me.bt_historico_compras.TabIndex = 199
        Me.bt_historico_compras.UseVisualStyleBackColor = True
        '
        'tx_id_item_cons_mov
        '
        Me.tx_id_item_cons_mov.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_id_item_cons_mov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_cons_mov.Location = New System.Drawing.Point(377, 114)
        Me.tx_id_item_cons_mov.Name = "tx_id_item_cons_mov"
        Me.tx_id_item_cons_mov.Size = New System.Drawing.Size(70, 22)
        Me.tx_id_item_cons_mov.TabIndex = 198
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(377, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 197
        Me.Label3.Text = "Id_item:"
        '
        'cm_responsable
        '
        Me.cm_responsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_responsable.FormattingEnabled = True
        Me.cm_responsable.Location = New System.Drawing.Point(90, 112)
        Me.cm_responsable.Name = "cm_responsable"
        Me.cm_responsable.Size = New System.Drawing.Size(405, 24)
        Me.cm_responsable.TabIndex = 201
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 16)
        Me.Label16.TabIndex = 202
        Me.Label16.Text = "Receptor:"
        '
        'bt_inspeccion_ensayo
        '
        Me.bt_inspeccion_ensayo.Image = Global.camocontrol.My.Resources.Resources.icono_checklist
        Me.bt_inspeccion_ensayo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_inspeccion_ensayo.Location = New System.Drawing.Point(8, 17)
        Me.bt_inspeccion_ensayo.Name = "bt_inspeccion_ensayo"
        Me.bt_inspeccion_ensayo.Size = New System.Drawing.Size(117, 39)
        Me.bt_inspeccion_ensayo.TabIndex = 203
        Me.bt_inspeccion_ensayo.Text = "Inspeccion y Ensayo"
        Me.bt_inspeccion_ensayo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_inspeccion_ensayo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_inspeccion_ensayo.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(207, 29)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(240, 65)
        Me.DataGridView1.TabIndex = 204
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(204, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(144, 16)
        Me.Label17.TabIndex = 205
        Me.Label17.Text = "Lotes Recepcionados:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tx_valor_factura)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.tx_factura_proveedor)
        Me.GroupBox2.Controls.Add(Me.dtp_vencimiento_factura)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.dtp_fecha_factura)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 141)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 110)
        Me.GroupBox2.TabIndex = 206
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Con Factura"
        '
        'tx_valor_factura
        '
        Me.tx_valor_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_valor_factura.Location = New System.Drawing.Point(97, 81)
        Me.tx_valor_factura.Name = "tx_valor_factura"
        Me.tx_valor_factura.ReadOnly = True
        Me.tx_valor_factura.Size = New System.Drawing.Size(123, 22)
        Me.tx_valor_factura.TabIndex = 208
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 16)
        Me.Label12.TabIndex = 207
        Me.Label12.Text = "Valor Factura:"
        '
        'dtp_fecha_creacion
        '
        Me.dtp_fecha_creacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_creacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_creacion.Location = New System.Drawing.Point(313, 61)
        Me.dtp_fecha_creacion.Name = "dtp_fecha_creacion"
        Me.dtp_fecha_creacion.Size = New System.Drawing.Size(182, 22)
        Me.dtp_fecha_creacion.TabIndex = 193
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(258, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 16)
        Me.Label10.TabIndex = 194
        Me.Label10.Text = "Fecha:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.bt_eliminar_item)
        Me.GroupBox3.Controls.Add(Me.bt_add_item)
        Me.GroupBox3.Controls.Add(Me.bt_solicitud_compra)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.bt_historico_compras)
        Me.GroupBox3.Controls.Add(Me.tx_sol_compra)
        Me.GroupBox3.Controls.Add(Me.tx_id_item_cons_mov)
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.tx_id_item_sc)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(244, 141)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(453, 177)
        Me.GroupBox3.TabIndex = 207
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Recepción del Producto Comprado:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.bt_inspeccion_ensayo)
        Me.GroupBox4.Controls.Add(Me.tx_estado)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 106)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(366, 60)
        Me.GroupBox4.TabIndex = 206
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Inspeccion y Ensayo del Producto Comprado:"
        '
        'fm_0300_facturas_compras_recepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(832, 525)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dtp_fecha_creacion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cm_responsable)
        Me.Controls.Add(Me.bt_aprobar_recepcion)
        Me.Controls.Add(Me.bt_gestionar_tercero)
        Me.Controls.Add(Me.tx_id_recepcion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cm_nit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dg_listado)
        Me.Controls.Add(Me.lb_identificacion)
        Me.Controls.Add(Me.cm_proveedor)
        Me.Controls.Add(Me.Label5)
        Me.Name = "fm_0300_facturas_compras_recepcion"
        Me.Text = "Recepcion de Almacen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cm_proveedor, 0)
        Me.Controls.SetChildIndex(Me.lb_identificacion, 0)
        Me.Controls.SetChildIndex(Me.dg_listado, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cm_nit, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_id_recepcion, 0)
        Me.Controls.SetChildIndex(Me.bt_gestionar_tercero, 0)
        Me.Controls.SetChildIndex(Me.bt_aprobar_recepcion, 0)
        Me.Controls.SetChildIndex(Me.cm_responsable, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_creacion, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents tx_id_recepcion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_estado As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bt_gestionar_tercero As System.Windows.Forms.Button
    Friend WithEvents bt_solicitud_compra As System.Windows.Forms.Button
    Friend WithEvents tx_sol_compra As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_factura As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_vencimiento_factura As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents bt_aprobar_recepcion As System.Windows.Forms.Button
    Friend WithEvents dgocell_id_sc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_sc_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cod_uno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_complementaria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cantidad_solicitada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_chk_item_aprobado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_unitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_total_iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_estructura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_accion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_historico_compras As System.Windows.Forms.Button
    Friend WithEvents tx_id_item_cons_mov As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cm_responsable As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents bt_inspeccion_ensayo As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtp_fecha_creacion As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents tx_valor_factura As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
End Class
