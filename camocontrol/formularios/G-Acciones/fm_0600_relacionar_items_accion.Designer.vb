<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_relacionar_items_accion
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
        Me.dg_productos_rel = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_it_ac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_mef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_mef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cm_descripcion = New System.Windows.Forms.ComboBox()
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cm_mef = New System.Windows.Forms.ComboBox()
        Me.tx_id_accion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_lote = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dg_lotes = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_cantidad_texto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_id_it_ac = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_productos_rel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_lotes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lb_fecha.Text = "2017/04/20"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(384, 32)
        Me.lb_titulo.Text = "Relacion de Items o Productos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 416)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 480)
        '
        'dg_productos_rel
        '
        Me.dg_productos_rel.AllowUserToAddRows = False
        Me.dg_productos_rel.AllowUserToDeleteRows = False
        Me.dg_productos_rel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_productos_rel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_it_ac, Me.dgocell_id_item, Me.dgocell_item, Me.dgocell_cantidad, Me.dgocell_id_mef, Me.dgocell_mef, Me.dgocell_lote})
        Me.dg_productos_rel.Location = New System.Drawing.Point(12, 103)
        Me.dg_productos_rel.Name = "dg_productos_rel"
        Me.dg_productos_rel.ReadOnly = True
        Me.dg_productos_rel.Size = New System.Drawing.Size(995, 135)
        Me.dg_productos_rel.TabIndex = 62
        '
        'dgocell_id_it_ac
        '
        Me.dgocell_id_it_ac.HeaderText = "Id"
        Me.dgocell_id_it_ac.Name = "dgocell_id_it_ac"
        Me.dgocell_id_it_ac.ReadOnly = True
        Me.dgocell_id_it_ac.Width = 40
        '
        'dgocell_id_item
        '
        Me.dgocell_id_item.HeaderText = "id_item"
        Me.dgocell_id_item.Name = "dgocell_id_item"
        Me.dgocell_id_item.ReadOnly = True
        Me.dgocell_id_item.Width = 50
        '
        'dgocell_item
        '
        Me.dgocell_item.HeaderText = "Item"
        Me.dgocell_item.Name = "dgocell_item"
        Me.dgocell_item.ReadOnly = True
        Me.dgocell_item.Width = 300
        '
        'dgocell_cantidad
        '
        Me.dgocell_cantidad.HeaderText = "Cantidad"
        Me.dgocell_cantidad.Name = "dgocell_cantidad"
        Me.dgocell_cantidad.ReadOnly = True
        Me.dgocell_cantidad.Width = 200
        '
        'dgocell_id_mef
        '
        Me.dgocell_id_mef.HeaderText = "id_MEF"
        Me.dgocell_id_mef.Name = "dgocell_id_mef"
        Me.dgocell_id_mef.ReadOnly = True
        Me.dgocell_id_mef.Width = 50
        '
        'dgocell_mef
        '
        Me.dgocell_mef.HeaderText = "MEF Modo o Efecto de Falla"
        Me.dgocell_mef.Name = "dgocell_mef"
        Me.dgocell_mef.ReadOnly = True
        Me.dgocell_mef.Width = 300
        '
        'dgocell_lote
        '
        Me.dgocell_lote.HeaderText = "Lote"
        Me.dgocell_lote.Name = "dgocell_lote"
        Me.dgocell_lote.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Productos o Items"
        '
        'cm_descripcion
        '
        Me.cm_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_descripcion.FormattingEnabled = True
        Me.cm_descripcion.Location = New System.Drawing.Point(153, 269)
        Me.cm_descripcion.Name = "cm_descripcion"
        Me.cm_descripcion.Size = New System.Drawing.Size(442, 24)
        Me.cm_descripcion.TabIndex = 135
        '
        'tx_id_item
        '
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(68, 271)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item.TabIndex = 136
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 274)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Id_item:"
        '
        'cm_mef
        '
        Me.cm_mef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_mef.FormattingEnabled = True
        Me.cm_mef.Location = New System.Drawing.Point(68, 295)
        Me.cm_mef.Name = "cm_mef"
        Me.cm_mef.Size = New System.Drawing.Size(527, 24)
        Me.cm_mef.TabIndex = 158
        '
        'tx_id_accion
        '
        Me.tx_id_accion.Enabled = False
        Me.tx_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_accion.Location = New System.Drawing.Point(83, 61)
        Me.tx_id_accion.Name = "tx_id_accion"
        Me.tx_id_accion.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_accion.TabIndex = 157
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "# Accion:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 298)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "MEF:"
        '
        'tx_lote
        '
        Me.tx_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_lote.Location = New System.Drawing.Point(68, 345)
        Me.tx_lote.Name = "tx_lote"
        Me.tx_lote.Size = New System.Drawing.Size(136, 22)
        Me.tx_lote.TabIndex = 160
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 348)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "Lote:"
        '
        'dg_lotes
        '
        Me.dg_lotes.AllowUserToAddRows = False
        Me.dg_lotes.AllowUserToDeleteRows = False
        Me.dg_lotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_lotes.Location = New System.Drawing.Point(601, 257)
        Me.dg_lotes.Name = "dg_lotes"
        Me.dg_lotes.ReadOnly = True
        Me.dg_lotes.Size = New System.Drawing.Size(406, 156)
        Me.dg_lotes.TabIndex = 164
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(598, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 165
        Me.Label6.Text = "Lotes despachados:"
        '
        'tx_cantidad_texto
        '
        Me.tx_cantidad_texto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad_texto.Location = New System.Drawing.Point(68, 321)
        Me.tx_cantidad_texto.Name = "tx_cantidad_texto"
        Me.tx_cantidad_texto.Size = New System.Drawing.Size(252, 22)
        Me.tx_cantidad_texto.TabIndex = 169
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 324)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "Tx Cant.:"
        '
        'tx_id_it_ac
        '
        Me.tx_id_it_ac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_it_ac.Location = New System.Drawing.Point(68, 247)
        Me.tx_id_it_ac.Name = "tx_id_it_ac"
        Me.tx_id_it_ac.ReadOnly = True
        Me.tx_id_it_ac.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_it_ac.TabIndex = 171
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 16)
        Me.Label8.TabIndex = 172
        Me.Label8.Text = "Id:"
        '
        'fm_0600_relacionar_items_accion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1021, 494)
        Me.Controls.Add(Me.tx_id_it_ac)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tx_cantidad_texto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dg_lotes)
        Me.Controls.Add(Me.tx_lote)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cm_mef)
        Me.Controls.Add(Me.tx_id_accion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cm_descripcion)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_productos_rel)
        Me.Name = "fm_0600_relacionar_items_accion"
        Me.Text = "Relacion de Items o Productos"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.dg_productos_rel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item, 0)
        Me.Controls.SetChildIndex(Me.cm_descripcion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_id_accion, 0)
        Me.Controls.SetChildIndex(Me.cm_mef, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tx_lote, 0)
        Me.Controls.SetChildIndex(Me.dg_lotes, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad_texto, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_id_it_ac, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_productos_rel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_lotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dg_productos_rel As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents cm_descripcion As ComboBox
    Friend WithEvents tx_id_item As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cm_mef As ComboBox
    Friend WithEvents tx_id_accion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tx_lote As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dg_lotes As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents tx_cantidad_texto As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tx_id_it_ac As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dgocell_id_it_ac As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_mef As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_mef As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_lote As DataGridViewTextBoxColumn
End Class
