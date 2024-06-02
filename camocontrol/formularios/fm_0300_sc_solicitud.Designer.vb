<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_sc_solicitud
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
        Me.tx_solicitud = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cm_estado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cm_centro_costo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_anotacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cm_usuario = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_fecha_solicitud = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_id_accion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bt_catalago_items = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tx_estructura = New System.Windows.Forms.TextBox()
        Me.bt_cambiar_infraestructura = New System.Windows.Forms.Button()
        Me.bt_cambiar_estado = New System.Windows.Forms.Button()
        Me.bt_agregar_item = New System.Windows.Forms.Button()
        Me.bt_historico_compras = New System.Windows.Forms.Button()
        Me.tx_id_item_cons_mov = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.bt_generar_recepcion = New System.Windows.Forms.Button()
        Me.lb_valor_subtotal = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lb_valor_factura = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dg_listado = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_sc_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cod_uno = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.dgocell_nota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_fcc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_doc_inv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(637, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(735, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(736, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/04/01"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(268, 32)
        Me.lb_titulo.Text = "Solicitud de Compra"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 458)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 518)
        '
        'bt_generar_informe
        '
        '
        'tx_solicitud
        '
        Me.tx_solicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_solicitud.Location = New System.Drawing.Point(122, 61)
        Me.tx_solicitud.Name = "tx_solicitud"
        Me.tx_solicitud.Size = New System.Drawing.Size(79, 22)
        Me.tx_solicitud.TabIndex = 130
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Solicitud #:"
        '
        'cm_estado
        '
        Me.cm_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_estado.FormattingEnabled = True
        Me.cm_estado.Location = New System.Drawing.Point(446, 61)
        Me.cm_estado.Name = "cm_estado"
        Me.cm_estado.Size = New System.Drawing.Size(164, 24)
        Me.cm_estado.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(338, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Estado:"
        '
        'cm_centro_costo
        '
        Me.cm_centro_costo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_centro_costo.FormattingEnabled = True
        Me.cm_centro_costo.Location = New System.Drawing.Point(122, 119)
        Me.cm_centro_costo.Name = "cm_centro_costo"
        Me.cm_centro_costo.Size = New System.Drawing.Size(209, 24)
        Me.cm_centro_costo.TabIndex = 134
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Centro de Costo:"
        '
        'tx_anotacion
        '
        Me.tx_anotacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_anotacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_anotacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_anotacion.Location = New System.Drawing.Point(17, 207)
        Me.tx_anotacion.Multiline = True
        Me.tx_anotacion.Name = "tx_anotacion"
        Me.tx_anotacion.Size = New System.Drawing.Size(710, 58)
        Me.tx_anotacion.TabIndex = 141
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Anotacion:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 287)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 143
        Me.Label4.Text = "Items solicitados:"
        '
        'cm_usuario
        '
        Me.cm_usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_usuario.FormattingEnabled = True
        Me.cm_usuario.Location = New System.Drawing.Point(446, 89)
        Me.cm_usuario.Name = "cm_usuario"
        Me.cm_usuario.Size = New System.Drawing.Size(287, 24)
        Me.cm_usuario.TabIndex = 145
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(337, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 16)
        Me.Label5.TabIndex = 144
        Me.Label5.Text = "Solicitado Por:"
        '
        'dtp_fecha_solicitud
        '
        Me.dtp_fecha_solicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_solicitud.Location = New System.Drawing.Point(446, 119)
        Me.dtp_fecha_solicitud.Name = "dtp_fecha_solicitud"
        Me.dtp_fecha_solicitud.Size = New System.Drawing.Size(287, 22)
        Me.dtp_fecha_solicitud.TabIndex = 147
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(337, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 16)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "Fecha Solicitud:"
        '
        'tx_id_accion
        '
        Me.tx_id_accion.Enabled = False
        Me.tx_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_accion.Location = New System.Drawing.Point(122, 89)
        Me.tx_id_accion.Name = "tx_id_accion"
        Me.tx_id_accion.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_accion.TabIndex = 150
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Actividad #:"
        '
        'bt_catalago_items
        '
        Me.bt_catalago_items.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_catalago_items.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_catalago_items.Image = Global.camocontrol.My.Resources.Resources.CANCELAR
        Me.bt_catalago_items.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_catalago_items.Location = New System.Drawing.Point(17, 458)
        Me.bt_catalago_items.Name = "bt_catalago_items"
        Me.bt_catalago_items.Size = New System.Drawing.Size(117, 39)
        Me.bt_catalago_items.TabIndex = 151
        Me.bt_catalago_items.Text = "Agregar Item a Catalogo"
        Me.bt_catalago_items.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_catalago_items.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_catalago_items.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 152)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 16)
        Me.Label15.TabIndex = 164
        Me.Label15.Text = "Equipo/Estruct:"
        '
        'tx_estructura
        '
        Me.tx_estructura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estructura.Location = New System.Drawing.Point(122, 149)
        Me.tx_estructura.Multiline = True
        Me.tx_estructura.Name = "tx_estructura"
        Me.tx_estructura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_estructura.Size = New System.Drawing.Size(508, 52)
        Me.tx_estructura.TabIndex = 163
        '
        'bt_cambiar_infraestructura
        '
        Me.bt_cambiar_infraestructura.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargarplano
        Me.bt_cambiar_infraestructura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cambiar_infraestructura.Location = New System.Drawing.Point(636, 149)
        Me.bt_cambiar_infraestructura.Name = "bt_cambiar_infraestructura"
        Me.bt_cambiar_infraestructura.Size = New System.Drawing.Size(21, 22)
        Me.bt_cambiar_infraestructura.TabIndex = 162
        Me.bt_cambiar_infraestructura.UseVisualStyleBackColor = True
        '
        'bt_cambiar_estado
        '
        Me.bt_cambiar_estado.Location = New System.Drawing.Point(616, 62)
        Me.bt_cambiar_estado.Name = "bt_cambiar_estado"
        Me.bt_cambiar_estado.Size = New System.Drawing.Size(115, 23)
        Me.bt_cambiar_estado.TabIndex = 165
        Me.bt_cambiar_estado.Text = "Cambiar Estado"
        Me.bt_cambiar_estado.UseVisualStyleBackColor = True
        '
        'bt_agregar_item
        '
        Me.bt_agregar_item.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_agregar_item.Image = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_agregar_item.Location = New System.Drawing.Point(741, 205)
        Me.bt_agregar_item.Name = "bt_agregar_item"
        Me.bt_agregar_item.Size = New System.Drawing.Size(73, 60)
        Me.bt_agregar_item.TabIndex = 166
        Me.bt_agregar_item.Text = "Add"
        Me.bt_agregar_item.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bt_agregar_item.UseVisualStyleBackColor = True
        '
        'bt_historico_compras
        '
        Me.bt_historico_compras.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_historico_compras.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_historico_compras.Location = New System.Drawing.Point(726, 155)
        Me.bt_historico_compras.Name = "bt_historico_compras"
        Me.bt_historico_compras.Size = New System.Drawing.Size(32, 34)
        Me.bt_historico_compras.TabIndex = 202
        Me.bt_historico_compras.UseVisualStyleBackColor = True
        '
        'tx_id_item_cons_mov
        '
        Me.tx_id_item_cons_mov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_cons_mov.Location = New System.Drawing.Point(667, 166)
        Me.tx_id_item_cons_mov.Name = "tx_id_item_cons_mov"
        Me.tx_id_item_cons_mov.ReadOnly = True
        Me.tx_id_item_cons_mov.Size = New System.Drawing.Size(57, 22)
        Me.tx_id_item_cons_mov.TabIndex = 201
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(664, 147)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 16)
        Me.Label9.TabIndex = 200
        Me.Label9.Text = "Id_item:"
        '
        'bt_generar_recepcion
        '
        Me.bt_generar_recepcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_generar_recepcion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_generar_recepcion.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_generar_recepcion.Location = New System.Drawing.Point(754, 89)
        Me.bt_generar_recepcion.Name = "bt_generar_recepcion"
        Me.bt_generar_recepcion.Size = New System.Drawing.Size(56, 52)
        Me.bt_generar_recepcion.TabIndex = 203
        Me.bt_generar_recepcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_generar_recepcion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_generar_recepcion.UseVisualStyleBackColor = True
        '
        'lb_valor_subtotal
        '
        Me.lb_valor_subtotal.AutoSize = True
        Me.lb_valor_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_subtotal.Location = New System.Drawing.Point(315, 268)
        Me.lb_valor_subtotal.Name = "lb_valor_subtotal"
        Me.lb_valor_subtotal.Size = New System.Drawing.Size(16, 18)
        Me.lb_valor_subtotal.TabIndex = 250
        Me.lb_valor_subtotal.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(214, 268)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 18)
        Me.Label19.TabIndex = 249
        Me.Label19.Text = "Valor Subtotal:"
        '
        'lb_valor_factura
        '
        Me.lb_valor_factura.AutoSize = True
        Me.lb_valor_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_factura.Location = New System.Drawing.Point(315, 283)
        Me.lb_valor_factura.Name = "lb_valor_factura"
        Me.lb_valor_factura.Size = New System.Drawing.Size(16, 18)
        Me.lb_valor_factura.TabIndex = 248
        Me.lb_valor_factura.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(214, 283)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 18)
        Me.Label10.TabIndex = 247
        Me.Label10.Text = "Valor Factura:"
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
        Me.dg_listado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_sc_item, Me.dgocell_item, Me.dgocell_cod_uno, Me.dgocell_descripcion_item, Me.dgocell_descripcion_complementaria, Me.dgocell_cantidad_solicitada, Me.dgocell_chk_inventario, Me.dgocell_inventario_total, Me.dgocell_unidad, Me.dgocell_var_costo, Me.dgocell_costo_unitario, Me.dgocell_descuento, Me.dgocell_costo_total, Me.dgocell_iva, Me.dgocell_costo_unit_iva, Me.dgocell_costo_total_iva, Me.dgocell_descripcion_estructura, Me.dgocell_id_accion, Me.dgocell_nota, Me.dgocell_id_fcc, Me.dgocell_doc_inv})
        Me.dg_listado.Location = New System.Drawing.Point(17, 304)
        Me.dg_listado.Name = "dg_listado"
        Me.dg_listado.Size = New System.Drawing.Size(797, 148)
        Me.dg_listado.TabIndex = 251
        '
        'dgocell_id_sc_item
        '
        Me.dgocell_id_sc_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.dgocell_id_sc_item.HeaderText = "Id_sc_item"
        Me.dgocell_id_sc_item.Name = "dgocell_id_sc_item"
        Me.dgocell_id_sc_item.ReadOnly = True
        Me.dgocell_id_sc_item.Width = 83
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
        Me.dgocell_descripcion_complementaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgocell_descripcion_complementaria.HeaderText = "Descripcion Complementaria"
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
        Me.dgocell_chk_inventario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_chk_inventario.HeaderText = "Invt"
        Me.dgocell_chk_inventario.Name = "dgocell_chk_inventario"
        Me.dgocell_chk_inventario.ReadOnly = True
        Me.dgocell_chk_inventario.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_chk_inventario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_chk_inventario.Width = 50
        '
        'dgocell_inventario_total
        '
        Me.dgocell_inventario_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_inventario_total.HeaderText = "Inventario"
        Me.dgocell_inventario_total.Name = "dgocell_inventario_total"
        Me.dgocell_inventario_total.Width = 79
        '
        'dgocell_unidad
        '
        Me.dgocell_unidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_unidad.HeaderText = "Unidad"
        Me.dgocell_unidad.Name = "dgocell_unidad"
        Me.dgocell_unidad.ReadOnly = True
        Me.dgocell_unidad.Width = 5
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
        'dgocell_nota
        '
        Me.dgocell_nota.HeaderText = "Nota"
        Me.dgocell_nota.Name = "dgocell_nota"
        Me.dgocell_nota.ReadOnly = True
        Me.dgocell_nota.Width = 150
        '
        'dgocell_id_fcc
        '
        Me.dgocell_id_fcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_id_fcc.HeaderText = "id_fcc"
        Me.dgocell_id_fcc.Name = "dgocell_id_fcc"
        Me.dgocell_id_fcc.Width = 5
        '
        'dgocell_doc_inv
        '
        Me.dgocell_doc_inv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_doc_inv.HeaderText = "Doc_inv"
        Me.dgocell_doc_inv.Name = "dgocell_doc_inv"
        Me.dgocell_doc_inv.Width = 5
        '
        'fm_0300_sc_solicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(822, 532)
        Me.Controls.Add(Me.dg_listado)
        Me.Controls.Add(Me.lb_valor_subtotal)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lb_valor_factura)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.bt_generar_recepcion)
        Me.Controls.Add(Me.bt_historico_compras)
        Me.Controls.Add(Me.tx_id_item_cons_mov)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.bt_agregar_item)
        Me.Controls.Add(Me.bt_cambiar_estado)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tx_estructura)
        Me.Controls.Add(Me.bt_cambiar_infraestructura)
        Me.Controls.Add(Me.bt_catalago_items)
        Me.Controls.Add(Me.tx_id_accion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtp_fecha_solicitud)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_usuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_anotacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cm_centro_costo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cm_estado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_solicitud)
        Me.Controls.Add(Me.Label8)
        Me.Name = "fm_0300_sc_solicitud"
        Me.Text = "Solicitud de Compra"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_solicitud, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cm_estado, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_centro_costo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_anotacion, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cm_usuario, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_solicitud, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_id_accion, 0)
        Me.Controls.SetChildIndex(Me.bt_catalago_items, 0)
        Me.Controls.SetChildIndex(Me.bt_cambiar_infraestructura, 0)
        Me.Controls.SetChildIndex(Me.tx_estructura, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.bt_cambiar_estado, 0)
        Me.Controls.SetChildIndex(Me.bt_agregar_item, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_cons_mov, 0)
        Me.Controls.SetChildIndex(Me.bt_historico_compras, 0)
        Me.Controls.SetChildIndex(Me.bt_generar_recepcion, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_factura, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_subtotal, 0)
        Me.Controls.SetChildIndex(Me.dg_listado, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_solicitud As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cm_estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cm_centro_costo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_anotacion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cm_usuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_solicitud As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tx_id_accion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bt_catalago_items As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tx_estructura As System.Windows.Forms.TextBox
    Friend WithEvents bt_cambiar_infraestructura As System.Windows.Forms.Button
    Friend WithEvents bt_cambiar_estado As System.Windows.Forms.Button
    Friend WithEvents bt_agregar_item As Button
    Friend WithEvents bt_historico_compras As Button
    Friend WithEvents tx_id_item_cons_mov As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents bt_generar_recepcion As Button
    Friend WithEvents lb_valor_subtotal As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lb_valor_factura As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dg_listado As DataGridView
    Friend WithEvents dgocell_id_sc_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cod_uno As DataGridViewTextBoxColumn
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
    Friend WithEvents dgocell_nota As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_fcc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_doc_inv As DataGridViewTextBoxColumn
End Class
