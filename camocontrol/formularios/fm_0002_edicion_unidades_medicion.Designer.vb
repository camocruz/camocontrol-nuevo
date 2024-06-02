<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0002_edicion_unidades_medicion
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
        Me.tx_sigla = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tx_unidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cm_tipo_unidad = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_sigla_cguno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/02/02"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(265, 32)
        Me.lb_titulo.Text = "Unidad de Medicion"
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        '
        'tx_sigla
        '
        Me.tx_sigla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_sigla.Location = New System.Drawing.Point(229, 151)
        Me.tx_sigla.Name = "tx_sigla"
        Me.tx_sigla.Size = New System.Drawing.Size(344, 22)
        Me.tx_sigla.TabIndex = 108
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(137, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 16)
        Me.Label15.TabIndex = 109
        Me.Label15.Text = "Sigla:"
        '
        'tx_unidad
        '
        Me.tx_unidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidad.Location = New System.Drawing.Point(229, 207)
        Me.tx_unidad.Name = "tx_unidad"
        Me.tx_unidad.Size = New System.Drawing.Size(344, 22)
        Me.tx_unidad.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(137, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Unidad:"
        '
        'cm_tipo_unidad
        '
        Me.cm_tipo_unidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_unidad.FormattingEnabled = True
        Me.cm_tipo_unidad.Location = New System.Drawing.Point(229, 235)
        Me.cm_tipo_unidad.Name = "cm_tipo_unidad"
        Me.cm_tipo_unidad.Size = New System.Drawing.Size(344, 24)
        Me.cm_tipo_unidad.TabIndex = 138
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(137, 238)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Tipo Unidad:"
        '
        'tx_sigla_cguno
        '
        Me.tx_sigla_cguno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_sigla_cguno.Location = New System.Drawing.Point(229, 179)
        Me.tx_sigla_cguno.Name = "tx_sigla_cguno"
        Me.tx_sigla_cguno.Size = New System.Drawing.Size(344, 22)
        Me.tx_sigla_cguno.TabIndex = 139
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(137, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Sigla CGUNO:"
        '
        'fm_0002_edicion_unidades_medicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 483)
        Me.Controls.Add(Me.tx_sigla_cguno)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cm_tipo_unidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_unidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_sigla)
        Me.Controls.Add(Me.Label15)
        Me.Name = "fm_0002_edicion_unidades_medicion"
        Me.Text = "Unidad de Medicion"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.tx_sigla, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_unidad, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_unidad, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_sigla_cguno, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_sigla As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tx_unidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cm_tipo_unidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_sigla_cguno As TextBox
    Friend WithEvents Label3 As Label
End Class
