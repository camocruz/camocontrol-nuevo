<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_formulacion_items
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
        Me.cm_descripcion = New System.Windows.Forms.ComboBox()
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_cantidad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lb_unidad_medicion = New System.Windows.Forms.Label()
        Me.tx_id_lmto = New System.Windows.Forms.TextBox()
        Me.lb_elemento = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2015/08/23"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(272, 32)
        Me.lb_titulo.Text = "Item de Formulacion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 174)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 234)
        '
        'bt_g_notas
        '
        '
        'cm_descripcion
        '
        Me.cm_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_descripcion.FormattingEnabled = True
        Me.cm_descripcion.Location = New System.Drawing.Point(178, 96)
        Me.cm_descripcion.Name = "cm_descripcion"
        Me.cm_descripcion.Size = New System.Drawing.Size(411, 24)
        Me.cm_descripcion.TabIndex = 136
        '
        'tx_id_item
        '
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(93, 98)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item.TabIndex = 135
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Id_item:"
        '
        'tx_cantidad
        '
        Me.tx_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad.Location = New System.Drawing.Point(93, 130)
        Me.tx_cantidad.Name = "tx_cantidad"
        Me.tx_cantidad.Size = New System.Drawing.Size(118, 22)
        Me.tx_cantidad.TabIndex = 142
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 16)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "Cantidad:"
        '
        'lb_unidad_medicion
        '
        Me.lb_unidad_medicion.AutoSize = True
        Me.lb_unidad_medicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_unidad_medicion.Location = New System.Drawing.Point(220, 136)
        Me.lb_unidad_medicion.Name = "lb_unidad_medicion"
        Me.lb_unidad_medicion.Size = New System.Drawing.Size(94, 16)
        Me.lb_unidad_medicion.TabIndex = 143
        Me.lb_unidad_medicion.Text = "Unid Medicion"
        '
        'tx_id_lmto
        '
        Me.tx_id_lmto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_lmto.Location = New System.Drawing.Point(93, 70)
        Me.tx_id_lmto.Name = "tx_id_lmto"
        Me.tx_id_lmto.ReadOnly = True
        Me.tx_id_lmto.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_lmto.TabIndex = 145
        '
        'lb_elemento
        '
        Me.lb_elemento.AutoSize = True
        Me.lb_elemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_elemento.Location = New System.Drawing.Point(16, 73)
        Me.lb_elemento.Name = "lb_elemento"
        Me.lb_elemento.Size = New System.Drawing.Size(51, 16)
        Me.lb_elemento.TabIndex = 144
        Me.lb_elemento.Text = "Id_lmto"
        '
        'fm_0300_formulacion_items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 248)
        Me.Controls.Add(Me.tx_id_lmto)
        Me.Controls.Add(Me.lb_elemento)
        Me.Controls.Add(Me.lb_unidad_medicion)
        Me.Controls.Add(Me.tx_cantidad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_descripcion)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label5)
        Me.Name = "fm_0300_formulacion_items"
        Me.Text = "Item de Formulación"
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
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad, 0)
        Me.Controls.SetChildIndex(Me.lb_unidad_medicion, 0)
        Me.Controls.SetChildIndex(Me.lb_elemento, 0)
        Me.Controls.SetChildIndex(Me.tx_id_lmto, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_descripcion As System.Windows.Forms.ComboBox
    Friend WithEvents tx_id_item As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lb_unidad_medicion As System.Windows.Forms.Label
    Friend WithEvents tx_id_lmto As System.Windows.Forms.TextBox
    Friend WithEvents lb_elemento As System.Windows.Forms.Label

End Class
