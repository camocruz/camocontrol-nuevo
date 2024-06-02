<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_parametro_texto
    Inherits camocontrol.FM_PLANTILLA

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lb_texto = New System.Windows.Forms.Label()
        Me.tx_texto = New System.Windows.Forms.TextBox()
        Me.cm_combo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/10/13"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(173, 32)
        Me.lb_titulo.Text = "Definir Valor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 175)
        '
        'bt_salir
        '
        Me.bt_salir.TabIndex = 1
        '
        'bt_grabar
        '
        Me.bt_grabar.TabIndex = 0
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 235)
        '
        'lb_texto
        '
        Me.lb_texto.AutoSize = True
        Me.lb_texto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_texto.Location = New System.Drawing.Point(12, 71)
        Me.lb_texto.Name = "lb_texto"
        Me.lb_texto.Size = New System.Drawing.Size(101, 20)
        Me.lb_texto.TabIndex = 65
        Me.lb_texto.Text = "Id_Recaudo:"
        '
        'tx_texto
        '
        Me.tx_texto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_texto.Location = New System.Drawing.Point(16, 94)
        Me.tx_texto.MaxLength = 100
        Me.tx_texto.Name = "tx_texto"
        Me.tx_texto.Size = New System.Drawing.Size(715, 26)
        Me.tx_texto.TabIndex = 0
        '
        'cm_combo
        '
        Me.cm_combo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_combo.FormattingEnabled = True
        Me.cm_combo.Location = New System.Drawing.Point(16, 99)
        Me.cm_combo.Name = "cm_combo"
        Me.cm_combo.Size = New System.Drawing.Size(715, 28)
        Me.cm_combo.TabIndex = 1
        '
        'fm_parametro_texto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 249)
        Me.Controls.Add(Me.cm_combo)
        Me.Controls.Add(Me.lb_texto)
        Me.Controls.Add(Me.tx_texto)
        Me.Name = "fm_parametro_texto"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.tx_texto, 0)
        Me.Controls.SetChildIndex(Me.lb_texto, 0)
        Me.Controls.SetChildIndex(Me.cm_combo, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_texto As System.Windows.Forms.Label
    Friend WithEvents tx_texto As System.Windows.Forms.TextBox
    Friend WithEvents cm_combo As System.Windows.Forms.ComboBox
End Class
