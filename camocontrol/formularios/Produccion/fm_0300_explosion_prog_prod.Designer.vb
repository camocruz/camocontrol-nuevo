<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_explosion_prog_prod
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
        Me.bt_generar_explosion = New System.Windows.Forms.Button()
        Me.bt_relacionar_items = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(557, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(655, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(656, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/01/12"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(305, 32)
        Me.lb_titulo.Text = "Explosion de materiales"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 273)
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 333)
        '
        'bt_generar_explosion
        '
        Me.bt_generar_explosion.Location = New System.Drawing.Point(326, 157)
        Me.bt_generar_explosion.Name = "bt_generar_explosion"
        Me.bt_generar_explosion.Size = New System.Drawing.Size(133, 41)
        Me.bt_generar_explosion.TabIndex = 62
        Me.bt_generar_explosion.Text = "Generar_explosion"
        Me.bt_generar_explosion.UseVisualStyleBackColor = True
        '
        'bt_relacionar_items
        '
        Me.bt_relacionar_items.Image = Global.camocontrol.My.Resources.Resources.persona_hijo
        Me.bt_relacionar_items.Location = New System.Drawing.Point(576, 146)
        Me.bt_relacionar_items.Name = "bt_relacionar_items"
        Me.bt_relacionar_items.Size = New System.Drawing.Size(48, 52)
        Me.bt_relacionar_items.TabIndex = 64
        Me.bt_relacionar_items.UseVisualStyleBackColor = True
        '
        'fm_0300_explosion_prog_prod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(742, 347)
        Me.Controls.Add(Me.bt_relacionar_items)
        Me.Controls.Add(Me.bt_generar_explosion)
        Me.Name = "fm_0300_explosion_prog_prod"
        Me.Text = "Explosion de materiales"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_generar_explosion, 0)
        Me.Controls.SetChildIndex(Me.bt_relacionar_items, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_generar_explosion As System.Windows.Forms.Button
    Friend WithEvents bt_relacionar_items As Button
End Class
