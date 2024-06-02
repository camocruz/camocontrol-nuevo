<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0500_info_documento
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
        Me.tx_id_documento = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.tx_titulo_documento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cm_codigo_documento = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cm_proceso = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_conservacion = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/02/23"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(257, 32)
        Me.lb_titulo.Text = "Info del Documento"
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        '
        'tx_id_documento
        '
        Me.tx_id_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_documento.Location = New System.Drawing.Point(122, 69)
        Me.tx_id_documento.Name = "tx_id_documento"
        Me.tx_id_documento.ReadOnly = True
        Me.tx_id_documento.Size = New System.Drawing.Size(119, 22)
        Me.tx_id_documento.TabIndex = 244
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(12, 75)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 16)
        Me.Label37.TabIndex = 243
        Me.Label37.Text = "id_documento:"
        '
        'tx_titulo_documento
        '
        Me.tx_titulo_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_titulo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_titulo_documento.Location = New System.Drawing.Point(247, 99)
        Me.tx_titulo_documento.Name = "tx_titulo_documento"
        Me.tx_titulo_documento.Size = New System.Drawing.Size(486, 22)
        Me.tx_titulo_documento.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "Documento:"
        '
        'cm_codigo_documento
        '
        Me.cm_codigo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_codigo_documento.FormattingEnabled = True
        Me.cm_codigo_documento.Location = New System.Drawing.Point(122, 97)
        Me.cm_codigo_documento.Name = "cm_codigo_documento"
        Me.cm_codigo_documento.Size = New System.Drawing.Size(119, 24)
        Me.cm_codigo_documento.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "Proceso:"
        '
        'cm_proceso
        '
        Me.cm_proceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_proceso.FormattingEnabled = True
        Me.cm_proceso.Location = New System.Drawing.Point(122, 127)
        Me.cm_proceso.Name = "cm_proceso"
        Me.cm_proceso.Size = New System.Drawing.Size(611, 24)
        Me.cm_proceso.TabIndex = 248
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 251
        Me.Label3.Text = "Conservacion:"
        '
        'tx_conservacion
        '
        Me.tx_conservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_conservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_conservacion.Location = New System.Drawing.Point(122, 157)
        Me.tx_conservacion.Name = "tx_conservacion"
        Me.tx_conservacion.Size = New System.Drawing.Size(186, 22)
        Me.tx_conservacion.TabIndex = 250
        '
        'fm_0500_info_documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 483)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_conservacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cm_proceso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cm_codigo_documento)
        Me.Controls.Add(Me.tx_titulo_documento)
        Me.Controls.Add(Me.tx_id_documento)
        Me.Controls.Add(Me.Label37)
        Me.Name = "fm_0500_info_documento"
        Me.Text = "Info del Documento"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.tx_id_documento, 0)
        Me.Controls.SetChildIndex(Me.tx_titulo_documento, 0)
        Me.Controls.SetChildIndex(Me.cm_codigo_documento, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cm_proceso, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_conservacion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_id_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents tx_titulo_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cm_codigo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cm_proceso As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tx_conservacion As TextBox
End Class
