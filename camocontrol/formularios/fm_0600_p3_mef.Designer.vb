<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_p3_mef
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
        Me.tx_mef = New System.Windows.Forms.TextBox()
        Me.cm_mef = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_id_mef = New System.Windows.Forms.TextBox()
        Me.lb_accion = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/05/22"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(299, 32)
        Me.lb_titulo.Text = "Modo o Efecto de Falla"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 232)
        '
        'bt_grabar
        '
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 291)
        '
        'tx_mef
        '
        Me.tx_mef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_mef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_mef.Location = New System.Drawing.Point(96, 149)
        Me.tx_mef.Multiline = True
        Me.tx_mef.Name = "tx_mef"
        Me.tx_mef.Size = New System.Drawing.Size(480, 56)
        Me.tx_mef.TabIndex = 130
        '
        'cm_mef
        '
        Me.cm_mef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_mef.FormattingEnabled = True
        Me.cm_mef.Location = New System.Drawing.Point(157, 119)
        Me.cm_mef.Name = "cm_mef"
        Me.cm_mef.Size = New System.Drawing.Size(419, 24)
        Me.cm_mef.TabIndex = 129
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "MEF:"
        '
        'tx_id_mef
        '
        Me.tx_id_mef.Location = New System.Drawing.Point(96, 123)
        Me.tx_id_mef.Name = "tx_id_mef"
        Me.tx_id_mef.ReadOnly = True
        Me.tx_id_mef.Size = New System.Drawing.Size(55, 20)
        Me.tx_id_mef.TabIndex = 131
        '
        'lb_accion
        '
        Me.lb_accion.AutoSize = True
        Me.lb_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_accion.Location = New System.Drawing.Point(91, 82)
        Me.lb_accion.Name = "lb_accion"
        Me.lb_accion.Size = New System.Drawing.Size(68, 25)
        Me.lb_accion.TabIndex = 132
        Me.lb_accion.Text = "Editar"
        '
        'fm_0600_p3_mef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 305)
        Me.Controls.Add(Me.lb_accion)
        Me.Controls.Add(Me.tx_id_mef)
        Me.Controls.Add(Me.tx_mef)
        Me.Controls.Add(Me.cm_mef)
        Me.Controls.Add(Me.Label2)
        Me.Name = "fm_0600_p3_mef"
        Me.Text = "Modo o Efecto de Falla"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cm_mef, 0)
        Me.Controls.SetChildIndex(Me.tx_mef, 0)
        Me.Controls.SetChildIndex(Me.tx_id_mef, 0)
        Me.Controls.SetChildIndex(Me.lb_accion, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_mef As System.Windows.Forms.TextBox
    Friend WithEvents cm_mef As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_id_mef As TextBox
    Friend WithEvents lb_accion As Label
End Class
