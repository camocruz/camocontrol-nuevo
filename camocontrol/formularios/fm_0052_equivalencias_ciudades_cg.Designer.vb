<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0052_equivalencias_ciudades_cg
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
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cm_ciudad_camo = New System.Windows.Forms.ComboBox()
        Me.tx_ciudad_cg = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2015/09/30"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(314, 32)
        Me.lb_titulo.Text = "Equivalencia ciudad CG"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 169)
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 229)
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(60, 86)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(96, 16)
        Me.Label38.TabIndex = 224
        Me.Label38.Text = "Ciudad CAMO:"
        '
        'cm_ciudad_camo
        '
        Me.cm_ciudad_camo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_ciudad_camo.FormattingEnabled = True
        Me.cm_ciudad_camo.Location = New System.Drawing.Point(63, 105)
        Me.cm_ciudad_camo.Name = "cm_ciudad_camo"
        Me.cm_ciudad_camo.Size = New System.Drawing.Size(291, 24)
        Me.cm_ciudad_camo.TabIndex = 225
        '
        'tx_ciudad_cg
        '
        Me.tx_ciudad_cg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_ciudad_cg.Location = New System.Drawing.Point(382, 107)
        Me.tx_ciudad_cg.Name = "tx_ciudad_cg"
        Me.tx_ciudad_cg.ReadOnly = True
        Me.tx_ciudad_cg.Size = New System.Drawing.Size(291, 22)
        Me.tx_ciudad_cg.TabIndex = 223
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(360, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 16)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "="
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(379, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "Ciudad CG:"
        '
        'fm_0052_equivalencias_ciudades_cg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 243)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.cm_ciudad_camo)
        Me.Controls.Add(Me.tx_ciudad_cg)
        Me.Name = "fm_0052_equivalencias_ciudades_cg"
        Me.Text = "Equivalencias Ciudades CG"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.tx_ciudad_cg, 0)
        Me.Controls.SetChildIndex(Me.cm_ciudad_camo, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cm_ciudad_camo As System.Windows.Forms.ComboBox
    Friend WithEvents tx_ciudad_cg As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
