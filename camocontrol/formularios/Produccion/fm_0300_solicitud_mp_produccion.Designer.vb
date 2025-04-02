<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0300_solicitud_mp_produccion
    Inherits camocontrol.FM_PLANTILLA

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cm_descripcion = New System.Windows.Forms.ComboBox()
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dg_items_solicitud = New System.Windows.Forms.DataGridView()
        Me.dgocell_ppal_id_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_nombre_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_tamano_bache = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_baches_requeridos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_id_bodega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_bodega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_inventario_propio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_inv_disponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_cant_solicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_fecha_entrega_requerida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ppal_chk_aprobado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tx_cantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_solicitar = New System.Windows.Forms.Button()
        Me.tx_produccion_x_bache = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_numero_baches = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_unidad_medicion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cm_bodega_solicitante = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tx_inventario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dg_prog_produccion = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_pprod_fecha_programada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtp_f_requerida_entrega = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_items_solicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_prog_produccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(835, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(933, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(934, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2017/01/10"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(619, 32)
        Me.lb_titulo.Text = "Solicitud de M. Prima y M. Empaque Produccion"
        '
        'bt_grabar
        '
        '
        'cm_descripcion
        '
        Me.cm_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_descripcion.FormattingEnabled = True
        Me.cm_descripcion.Location = New System.Drawing.Point(186, 59)
        Me.cm_descripcion.Name = "cm_descripcion"
        Me.cm_descripcion.Size = New System.Drawing.Size(411, 24)
        Me.cm_descripcion.TabIndex = 136
        '
        'tx_id_item
        '
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(105, 61)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item.TabIndex = 135
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Id_item:"
        '
        'dg_items_solicitud
        '
        Me.dg_items_solicitud.AllowUserToAddRows = False
        Me.dg_items_solicitud.AllowUserToDeleteRows = False
        Me.dg_items_solicitud.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_items_solicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_items_solicitud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_ppal_id_item, Me.dgocell_ppal_nombre_item, Me.dgocell_ppal_cantidad, Me.dgocell_ppal_unidad, Me.dgocell_tamano_bache, Me.dgocell_ppal_baches_requeridos, Me.dgocell_ppal_id_bodega, Me.dgocell_ppal_bodega, Me.dgocell_ppal_inventario_propio, Me.dgocell_ppal_inv_disponible, Me.dgocell_ppal_cant_solicitada, Me.dgocell_ppal_fecha_entrega_requerida, Me.dgocell_ppal_chk_aprobado})
        Me.dg_items_solicitud.Location = New System.Drawing.Point(37, 343)
        Me.dg_items_solicitud.Name = "dg_items_solicitud"
        Me.dg_items_solicitud.Size = New System.Drawing.Size(971, 63)
        Me.dg_items_solicitud.TabIndex = 137
        '
        'dgocell_ppal_id_item
        '
        Me.dgocell_ppal_id_item.HeaderText = "id_item"
        Me.dgocell_ppal_id_item.Name = "dgocell_ppal_id_item"
        Me.dgocell_ppal_id_item.Width = 40
        '
        'dgocell_ppal_nombre_item
        '
        Me.dgocell_ppal_nombre_item.HeaderText = "Item"
        Me.dgocell_ppal_nombre_item.Name = "dgocell_ppal_nombre_item"
        '
        'dgocell_ppal_cantidad
        '
        Me.dgocell_ppal_cantidad.HeaderText = "Cantidad"
        Me.dgocell_ppal_cantidad.Name = "dgocell_ppal_cantidad"
        Me.dgocell_ppal_cantidad.Width = 70
        '
        'dgocell_ppal_unidad
        '
        Me.dgocell_ppal_unidad.HeaderText = "Unidad"
        Me.dgocell_ppal_unidad.Name = "dgocell_ppal_unidad"
        Me.dgocell_ppal_unidad.Width = 70
        '
        'dgocell_tamano_bache
        '
        Me.dgocell_tamano_bache.HeaderText = "Tamaño Bache"
        Me.dgocell_tamano_bache.Name = "dgocell_tamano_bache"
        '
        'dgocell_ppal_baches_requeridos
        '
        Me.dgocell_ppal_baches_requeridos.HeaderText = "# Baches"
        Me.dgocell_ppal_baches_requeridos.Name = "dgocell_ppal_baches_requeridos"
        '
        'dgocell_ppal_id_bodega
        '
        Me.dgocell_ppal_id_bodega.HeaderText = "id_bod"
        Me.dgocell_ppal_id_bodega.Name = "dgocell_ppal_id_bodega"
        Me.dgocell_ppal_id_bodega.Width = 30
        '
        'dgocell_ppal_bodega
        '
        Me.dgocell_ppal_bodega.HeaderText = "Bodega"
        Me.dgocell_ppal_bodega.MinimumWidth = 20
        Me.dgocell_ppal_bodega.Name = "dgocell_ppal_bodega"
        '
        'dgocell_ppal_inventario_propio
        '
        Me.dgocell_ppal_inventario_propio.HeaderText = "Inventario Propio"
        Me.dgocell_ppal_inventario_propio.Name = "dgocell_ppal_inventario_propio"
        '
        'dgocell_ppal_inv_disponible
        '
        Me.dgocell_ppal_inv_disponible.HeaderText = "Inventario Disponible"
        Me.dgocell_ppal_inv_disponible.Name = "dgocell_ppal_inv_disponible"
        '
        'dgocell_ppal_cant_solicitada
        '
        Me.dgocell_ppal_cant_solicitada.HeaderText = "Cantidad Solicitada"
        Me.dgocell_ppal_cant_solicitada.Name = "dgocell_ppal_cant_solicitada"
        '
        'dgocell_ppal_fecha_entrega_requerida
        '
        Me.dgocell_ppal_fecha_entrega_requerida.HeaderText = "Fecha Requerida"
        Me.dgocell_ppal_fecha_entrega_requerida.Name = "dgocell_ppal_fecha_entrega_requerida"
        '
        'dgocell_ppal_chk_aprobado
        '
        Me.dgocell_ppal_chk_aprobado.HeaderText = "Ap"
        Me.dgocell_ppal_chk_aprobado.Name = "dgocell_ppal_chk_aprobado"
        Me.dgocell_ppal_chk_aprobado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_ppal_chk_aprobado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_ppal_chk_aprobado.Width = 30
        '
        'tx_cantidad
        '
        Me.tx_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad.Location = New System.Drawing.Point(105, 86)
        Me.tx_cantidad.Name = "tx_cantidad"
        Me.tx_cantidad.Size = New System.Drawing.Size(79, 22)
        Me.tx_cantidad.TabIndex = 139
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Cantidad:"
        '
        'bt_solicitar
        '
        Me.bt_solicitar.Image = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_solicitar.Location = New System.Drawing.Point(611, 59)
        Me.bt_solicitar.Name = "bt_solicitar"
        Me.bt_solicitar.Size = New System.Drawing.Size(67, 50)
        Me.bt_solicitar.TabIndex = 140
        Me.bt_solicitar.Text = "Procesar"
        Me.bt_solicitar.UseVisualStyleBackColor = True
        '
        'tx_produccion_x_bache
        '
        Me.tx_produccion_x_bache.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_produccion_x_bache.Location = New System.Drawing.Point(105, 111)
        Me.tx_produccion_x_bache.Name = "tx_produccion_x_bache"
        Me.tx_produccion_x_bache.ReadOnly = True
        Me.tx_produccion_x_bache.Size = New System.Drawing.Size(79, 22)
        Me.tx_produccion_x_bache.TabIndex = 142
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "P. Bache:"
        '
        'tx_numero_baches
        '
        Me.tx_numero_baches.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_numero_baches.Location = New System.Drawing.Point(105, 136)
        Me.tx_numero_baches.Name = "tx_numero_baches"
        Me.tx_numero_baches.Size = New System.Drawing.Size(79, 22)
        Me.tx_numero_baches.TabIndex = 144
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "# Baches:"
        '
        'lb_unidad_medicion
        '
        Me.lb_unidad_medicion.AutoSize = True
        Me.lb_unidad_medicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_unidad_medicion.Location = New System.Drawing.Point(190, 102)
        Me.lb_unidad_medicion.Name = "lb_unidad_medicion"
        Me.lb_unidad_medicion.Size = New System.Drawing.Size(52, 16)
        Me.lb_unidad_medicion.TabIndex = 145
        Me.lb_unidad_medicion.Text = "Unidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(34, 324)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 16)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "Items Solicitados:"
        '
        'cm_bodega_solicitante
        '
        Me.cm_bodega_solicitante.FormattingEnabled = True
        Me.cm_bodega_solicitante.Location = New System.Drawing.Point(319, 112)
        Me.cm_bodega_solicitante.Name = "cm_bodega_solicitante"
        Me.cm_bodega_solicitante.Size = New System.Drawing.Size(359, 21)
        Me.cm_bodega_solicitante.TabIndex = 223
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(319, 94)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(133, 16)
        Me.Label23.TabIndex = 222
        Me.Label23.Text = "Bodega que Solicita:"
        '
        'tx_inventario
        '
        Me.tx_inventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_inventario.Location = New System.Drawing.Point(755, 111)
        Me.tx_inventario.Name = "tx_inventario"
        Me.tx_inventario.ReadOnly = True
        Me.tx_inventario.Size = New System.Drawing.Size(123, 22)
        Me.tx_inventario.TabIndex = 225
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(684, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 224
        Me.Label4.Text = "Inventario:"
        '
        'dg_prog_produccion
        '
        Me.dg_prog_produccion.AllowUserToAddRows = False
        Me.dg_prog_produccion.AllowUserToDeleteRows = False
        Me.dg_prog_produccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_prog_produccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_prog_produccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.dgocell_pprod_fecha_programada})
        Me.dg_prog_produccion.Location = New System.Drawing.Point(37, 180)
        Me.dg_prog_produccion.Name = "dg_prog_produccion"
        Me.dg_prog_produccion.Size = New System.Drawing.Size(971, 141)
        Me.dg_prog_produccion.TabIndex = 226
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "id_item"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 40
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Item"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Unidad"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Tamaño Bache"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "# Baches"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'dgocell_pprod_fecha_programada
        '
        Me.dgocell_pprod_fecha_programada.HeaderText = "Fecha Programada"
        Me.dgocell_pprod_fecha_programada.Name = "dgocell_pprod_fecha_programada"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 16)
        Me.Label7.TabIndex = 227
        Me.Label7.Text = "Programa de Produccion:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(316, 139)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 16)
        Me.Label14.TabIndex = 229
        Me.Label14.Text = "Entregar el:"
        '
        'dtp_f_requerida_entrega
        '
        Me.dtp_f_requerida_entrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_f_requerida_entrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_f_requerida_entrega.Location = New System.Drawing.Point(407, 136)
        Me.dtp_f_requerida_entrega.Name = "dtp_f_requerida_entrega"
        Me.dtp_f_requerida_entrega.Size = New System.Drawing.Size(123, 22)
        Me.dtp_f_requerida_entrega.TabIndex = 228
        '
        'fm_0300_solicitud_mp_produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1020, 488)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dtp_f_requerida_entrega)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dg_prog_produccion)
        Me.Controls.Add(Me.tx_inventario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cm_bodega_solicitante)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lb_unidad_medicion)
        Me.Controls.Add(Me.tx_numero_baches)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_produccion_x_bache)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bt_solicitar)
        Me.Controls.Add(Me.tx_cantidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_items_solicitud)
        Me.Controls.Add(Me.cm_descripcion)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label5)
        Me.Name = "fm_0300_solicitud_mp_produccion"
        Me.Text = "Solicitud de Almacen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item, 0)
        Me.Controls.SetChildIndex(Me.cm_descripcion, 0)
        Me.Controls.SetChildIndex(Me.dg_items_solicitud, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad, 0)
        Me.Controls.SetChildIndex(Me.bt_solicitar, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_produccion_x_bache, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_numero_baches, 0)
        Me.Controls.SetChildIndex(Me.lb_unidad_medicion, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.cm_bodega_solicitante, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tx_inventario, 0)
        Me.Controls.SetChildIndex(Me.dg_prog_produccion, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dtp_f_requerida_entrega, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_items_solicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_prog_produccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cm_descripcion As ComboBox
    Friend WithEvents tx_id_item As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dg_items_solicitud As DataGridView
    Friend WithEvents tx_cantidad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bt_solicitar As Button
    Friend WithEvents tx_produccion_x_bache As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tx_numero_baches As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lb_unidad_medicion As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cm_bodega_solicitante As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents tx_inventario As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dg_prog_produccion As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dtp_f_requerida_entrega As DateTimePicker
    Friend WithEvents dgocell_ppal_id_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_nombre_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_unidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_tamano_bache As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_baches_requeridos As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_id_bodega As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_bodega As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_inventario_propio As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_inv_disponible As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_cant_solicitada As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_fecha_entrega_requerida As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ppal_chk_aprobado As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_pprod_fecha_programada As DataGridViewTextBoxColumn
End Class
