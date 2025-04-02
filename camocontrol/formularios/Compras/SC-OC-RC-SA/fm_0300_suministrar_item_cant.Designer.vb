<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0300_suministrar_item_cant
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
        Me.lb_unidad_medicion = New System.Windows.Forms.Label()
        Me.tx_cantidad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cm_clasificador = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_inventario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gb_tipo_movimiento = New System.Windows.Forms.GroupBox()
        Me.rb_salida = New System.Windows.Forms.RadioButton()
        Me.rb_entrada = New System.Windows.Forms.RadioButton()
        Me.dg_trazabilidad = New System.Windows.Forms.DataGridView()
        Me.dgocell_info_trazabilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_buscar_trazabilidad = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bt_listado_general_items = New System.Windows.Forms.Button()
        Me.tx_item_descripcion = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_tipo_movimiento.SuspendLayout()
        CType(Me.dg_trazabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(595, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(693, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(694, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/04/15"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(230, 32)
        Me.lb_titulo.Text = "Cantidad de Item"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 272)
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 332)
        '
        'lb_unidad_medicion
        '
        Me.lb_unidad_medicion.AutoSize = True
        Me.lb_unidad_medicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_unidad_medicion.Location = New System.Drawing.Point(226, 121)
        Me.lb_unidad_medicion.Name = "lb_unidad_medicion"
        Me.lb_unidad_medicion.Size = New System.Drawing.Size(94, 16)
        Me.lb_unidad_medicion.TabIndex = 151
        Me.lb_unidad_medicion.Text = "Unid Medicion"
        '
        'tx_cantidad
        '
        Me.tx_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad.Location = New System.Drawing.Point(96, 131)
        Me.tx_cantidad.Name = "tx_cantidad"
        Me.tx_cantidad.Size = New System.Drawing.Size(118, 22)
        Me.tx_cantidad.TabIndex = 150
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 16)
        Me.Label6.TabIndex = 149
        Me.Label6.Text = "Cantidad:"
        '
        'tx_id_item
        '
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(95, 75)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item.TabIndex = 147
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Id_item:"
        '
        'cm_clasificador
        '
        Me.cm_clasificador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_clasificador.FormattingEnabled = True
        Me.cm_clasificador.Location = New System.Drawing.Point(96, 220)
        Me.cm_clasificador.Name = "cm_clasificador"
        Me.cm_clasificador.Size = New System.Drawing.Size(392, 24)
        Me.cm_clasificador.TabIndex = 153
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Clasificador:"
        '
        'tx_inventario
        '
        Me.tx_inventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_inventario.Location = New System.Drawing.Point(95, 103)
        Me.tx_inventario.Name = "tx_inventario"
        Me.tx_inventario.ReadOnly = True
        Me.tx_inventario.Size = New System.Drawing.Size(118, 22)
        Me.tx_inventario.TabIndex = 155
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "Inventario:"
        '
        'gb_tipo_movimiento
        '
        Me.gb_tipo_movimiento.Controls.Add(Me.rb_salida)
        Me.gb_tipo_movimiento.Controls.Add(Me.rb_entrada)
        Me.gb_tipo_movimiento.Location = New System.Drawing.Point(96, 159)
        Me.gb_tipo_movimiento.Name = "gb_tipo_movimiento"
        Me.gb_tipo_movimiento.Size = New System.Drawing.Size(101, 55)
        Me.gb_tipo_movimiento.TabIndex = 156
        Me.gb_tipo_movimiento.TabStop = False
        Me.gb_tipo_movimiento.Text = "T. Movimiento"
        '
        'rb_salida
        '
        Me.rb_salida.AutoSize = True
        Me.rb_salida.Location = New System.Drawing.Point(7, 33)
        Me.rb_salida.Name = "rb_salida"
        Me.rb_salida.Size = New System.Drawing.Size(54, 17)
        Me.rb_salida.TabIndex = 1
        Me.rb_salida.TabStop = True
        Me.rb_salida.Text = "Salida"
        Me.rb_salida.UseVisualStyleBackColor = True
        '
        'rb_entrada
        '
        Me.rb_entrada.AutoSize = True
        Me.rb_entrada.Location = New System.Drawing.Point(7, 14)
        Me.rb_entrada.Name = "rb_entrada"
        Me.rb_entrada.Size = New System.Drawing.Size(62, 17)
        Me.rb_entrada.TabIndex = 0
        Me.rb_entrada.TabStop = True
        Me.rb_entrada.Text = "Entrada"
        Me.rb_entrada.UseVisualStyleBackColor = True
        '
        'dg_trazabilidad
        '
        Me.dg_trazabilidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_trazabilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_trazabilidad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_info_trazabilidad})
        Me.dg_trazabilidad.Location = New System.Drawing.Point(529, 129)
        Me.dg_trazabilidad.Name = "dg_trazabilidad"
        Me.dg_trazabilidad.Size = New System.Drawing.Size(238, 114)
        Me.dg_trazabilidad.TabIndex = 157
        '
        'dgocell_info_trazabilidad
        '
        Me.dgocell_info_trazabilidad.HeaderText = "Identificador"
        Me.dgocell_info_trazabilidad.Name = "dgocell_info_trazabilidad"
        Me.dgocell_info_trazabilidad.Width = 150
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(491, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 16)
        Me.Label3.TabIndex = 158
        Me.Label3.Text = "Info Trazabilidad"
        '
        'bt_buscar_trazabilidad
        '
        Me.bt_buscar_trazabilidad.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_buscar_trazabilidad.Location = New System.Drawing.Point(436, 129)
        Me.bt_buscar_trazabilidad.Name = "bt_buscar_trazabilidad"
        Me.bt_buscar_trazabilidad.Size = New System.Drawing.Size(52, 73)
        Me.bt_buscar_trazabilidad.TabIndex = 159
        Me.bt_buscar_trazabilidad.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(735, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "Ctrl+B"
        '
        'bt_listado_general_items
        '
        Me.bt_listado_general_items.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_listado_general_items.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_listado_general_items.Location = New System.Drawing.Point(731, 63)
        Me.bt_listado_general_items.Name = "bt_listado_general_items"
        Me.bt_listado_general_items.Size = New System.Drawing.Size(38, 36)
        Me.bt_listado_general_items.TabIndex = 211
        Me.bt_listado_general_items.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_listado_general_items.UseVisualStyleBackColor = True
        '
        'tx_item_descripcion
        '
        Me.tx_item_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_item_descripcion.Location = New System.Drawing.Point(180, 75)
        Me.tx_item_descripcion.Name = "tx_item_descripcion"
        Me.tx_item_descripcion.Size = New System.Drawing.Size(545, 22)
        Me.tx_item_descripcion.TabIndex = 1
        '
        'fm_0300_suministrar_item_cant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(780, 346)
        Me.Controls.Add(Me.tx_item_descripcion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bt_listado_general_items)
        Me.Controls.Add(Me.bt_buscar_trazabilidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dg_trazabilidad)
        Me.Controls.Add(Me.gb_tipo_movimiento)
        Me.Controls.Add(Me.tx_inventario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cm_clasificador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lb_unidad_medicion)
        Me.Controls.Add(Me.tx_cantidad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label5)
        Me.Name = "fm_0300_suministrar_item_cant"
        Me.Text = "Gestion Cantidades"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad, 0)
        Me.Controls.SetChildIndex(Me.lb_unidad_medicion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_clasificador, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_inventario, 0)
        Me.Controls.SetChildIndex(Me.gb_tipo_movimiento, 0)
        Me.Controls.SetChildIndex(Me.dg_trazabilidad, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.bt_buscar_trazabilidad, 0)
        Me.Controls.SetChildIndex(Me.bt_listado_general_items, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tx_item_descripcion, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_tipo_movimiento.ResumeLayout(False)
        Me.gb_tipo_movimiento.PerformLayout()
        CType(Me.dg_trazabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_unidad_medicion As System.Windows.Forms.Label
    Friend WithEvents tx_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tx_id_item As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cm_clasificador As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_inventario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gb_tipo_movimiento As System.Windows.Forms.GroupBox
    Friend WithEvents rb_salida As System.Windows.Forms.RadioButton
    Friend WithEvents rb_entrada As System.Windows.Forms.RadioButton
    Friend WithEvents dg_trazabilidad As DataGridView
    Friend WithEvents dgocell_info_trazabilidad As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents bt_buscar_trazabilidad As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents bt_listado_general_items As Button
    Friend WithEvents tx_item_descripcion As TextBox
End Class
