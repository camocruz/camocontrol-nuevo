<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcValidadorDuplicados
    Inherits System.Windows.Forms.UserControl

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.picEstado = New System.Windows.Forms.PictureBox()
        Me.btnValidador = New System.Windows.Forms.Button()
        Me.toolTipEstado = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.picEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtValor
        '
        Me.txtValor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValor.Location = New System.Drawing.Point(3, 3)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(180, 22)
        Me.txtValor.TabIndex = 0
        '
        'picEstado
        '
        Me.picEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picEstado.Location = New System.Drawing.Point(189, 3)
        Me.picEstado.Name = "picEstado"
        Me.picEstado.Size = New System.Drawing.Size(20, 20)
        Me.picEstado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picEstado.TabIndex = 1
        Me.picEstado.TabStop = False
        '
        'btnValidador
        '
        Me.btnValidador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValidador.Location = New System.Drawing.Point(215, 3)
        Me.btnValidador.Name = "btnValidador"
        Me.btnValidador.Size = New System.Drawing.Size(25, 20)
        Me.btnValidador.TabIndex = 2
        Me.btnValidador.Text = "..."
        '
        'UcValidadorDuplicados
        '
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.picEstado)
        Me.Controls.Add(Me.btnValidador)
        Me.Name = "UcValidadorDuplicados"
        Me.Size = New System.Drawing.Size(245, 26)
        CType(Me.picEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtValor As TextBox
    Friend WithEvents picEstado As PictureBox
    Friend WithEvents btnValidador As Button
    Friend WithEvents toolTipEstado As ToolTip

End Class

