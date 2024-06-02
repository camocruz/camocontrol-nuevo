<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0800_facturacion_pos
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.tx_id_item_sc = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tx_cantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cm_descripcion = New System.Windows.Forms.ComboBox()
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_id_registro = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(821, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(822, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2019/03/30"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(731, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(227, 32)
        Me.lb_titulo.Text = "Facturacion POS"
        '
        'tx_id_item_sc
        '
        Me.tx_id_item_sc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_sc.Location = New System.Drawing.Point(309, 65)
        Me.tx_id_item_sc.Name = "tx_id_item_sc"
        Me.tx_id_item_sc.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item_sc.TabIndex = 212
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(217, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 16)
        Me.Label17.TabIndex = 213
        Me.Label17.Text = "Id_item_SC#:"
        '
        'tx_cantidad
        '
        Me.tx_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad.Location = New System.Drawing.Point(559, 62)
        Me.tx_cantidad.Name = "tx_cantidad"
        Me.tx_cantidad.Size = New System.Drawing.Size(116, 22)
        Me.tx_cantidad.TabIndex = 188
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(448, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "Cantidad:"
        '
        'cm_descripcion
        '
        Me.cm_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_descripcion.FormattingEnabled = True
        Me.cm_descripcion.Location = New System.Drawing.Point(218, 88)
        Me.cm_descripcion.Name = "cm_descripcion"
        Me.cm_descripcion.Size = New System.Drawing.Size(457, 24)
        Me.cm_descripcion.TabIndex = 186
        '
        'tx_id_item
        '
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(133, 90)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item.TabIndex = 195
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 199
        Me.Label5.Text = "Id_item:"
        '
        'tx_id_registro
        '
        Me.tx_id_registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_registro.Location = New System.Drawing.Point(133, 65)
        Me.tx_id_registro.Name = "tx_id_registro"
        Me.tx_id_registro.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_registro.TabIndex = 185
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 16)
        Me.Label8.TabIndex = 198
        Me.Label8.Text = "Id #:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(25, 146)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(863, 256)
        Me.DataGridView1.TabIndex = 214
        '
        'fm_0800_facturacion_pos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(900, 458)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.tx_id_item_sc)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.tx_cantidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cm_descripcion)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_id_registro)
        Me.Controls.Add(Me.Label8)
        Me.Name = "fm_0800_facturacion_pos"
        Me.Text = "Facturacion POS"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_id_registro, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item, 0)
        Me.Controls.SetChildIndex(Me.cm_descripcion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_sc, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_id_item_sc As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents tx_cantidad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cm_descripcion As ComboBox
    Friend WithEvents tx_id_item As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tx_id_registro As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
