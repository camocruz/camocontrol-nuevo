<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0800_costo_flete_transportadora
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.cm_destino = New System.Windows.Forms.ComboBox()
        Me.tx_valor = New System.Windows.Forms.TextBox()
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rb_sin_recaudo = New System.Windows.Forms.RadioButton()
        Me.gb_recaudo = New System.Windows.Forms.GroupBox()
        Me.rb_con_recaudo = New System.Windows.Forms.RadioButton()
        Me.lb_transportadora = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_recaudo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2021/08/12"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(217, 32)
        Me.lb_titulo.Text = "Flete Transporte"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 283)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 247)
        '
        'cm_destino
        '
        Me.cm_destino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_destino.FormattingEnabled = True
        Me.cm_destino.Location = New System.Drawing.Point(88, 85)
        Me.cm_destino.Name = "cm_destino"
        Me.cm_destino.Size = New System.Drawing.Size(570, 24)
        Me.cm_destino.TabIndex = 63
        '
        'tx_valor
        '
        Me.tx_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_valor.Location = New System.Drawing.Point(88, 128)
        Me.tx_valor.Name = "tx_valor"
        Me.tx_valor.Size = New System.Drawing.Size(129, 22)
        Me.tx_valor.TabIndex = 64
        '
        'bt_grabar
        '
        Me.bt_grabar.Image = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar.Location = New System.Drawing.Point(317, 128)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(76, 60)
        Me.bt_grabar.TabIndex = 65
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 18)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Destino"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 18)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Valor"
        '
        'rb_sin_recaudo
        '
        Me.rb_sin_recaudo.AutoSize = True
        Me.rb_sin_recaudo.Checked = True
        Me.rb_sin_recaudo.Location = New System.Drawing.Point(6, 19)
        Me.rb_sin_recaudo.Name = "rb_sin_recaudo"
        Me.rb_sin_recaudo.Size = New System.Drawing.Size(87, 17)
        Me.rb_sin_recaudo.TabIndex = 68
        Me.rb_sin_recaudo.TabStop = True
        Me.rb_sin_recaudo.Text = "Sin Recaudo"
        Me.rb_sin_recaudo.UseVisualStyleBackColor = True
        '
        'gb_recaudo
        '
        Me.gb_recaudo.Controls.Add(Me.rb_con_recaudo)
        Me.gb_recaudo.Controls.Add(Me.rb_sin_recaudo)
        Me.gb_recaudo.Location = New System.Drawing.Point(88, 154)
        Me.gb_recaudo.Name = "gb_recaudo"
        Me.gb_recaudo.Size = New System.Drawing.Size(129, 75)
        Me.gb_recaudo.TabIndex = 69
        Me.gb_recaudo.TabStop = False
        Me.gb_recaudo.Text = "Recaudo"
        '
        'rb_con_recaudo
        '
        Me.rb_con_recaudo.AutoSize = True
        Me.rb_con_recaudo.Location = New System.Drawing.Point(6, 42)
        Me.rb_con_recaudo.Name = "rb_con_recaudo"
        Me.rb_con_recaudo.Size = New System.Drawing.Size(91, 17)
        Me.rb_con_recaudo.TabIndex = 69
        Me.rb_con_recaudo.Text = "Con Recaudo"
        Me.rb_con_recaudo.UseVisualStyleBackColor = True
        '
        'lb_transportadora
        '
        Me.lb_transportadora.AutoSize = True
        Me.lb_transportadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_transportadora.Location = New System.Drawing.Point(85, 63)
        Me.lb_transportadora.Name = "lb_transportadora"
        Me.lb_transportadora.Size = New System.Drawing.Size(132, 20)
        Me.lb_transportadora.TabIndex = 70
        Me.lb_transportadora.Text = "Transportadora"
        '
        'fm_0800_costo_flete_transportadora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(742, 297)
        Me.Controls.Add(Me.lb_transportadora)
        Me.Controls.Add(Me.gb_recaudo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bt_grabar)
        Me.Controls.Add(Me.tx_valor)
        Me.Controls.Add(Me.cm_destino)
        Me.Name = "fm_0800_costo_flete_transportadora"
        Me.Text = "Flete Transporte"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.cm_destino, 0)
        Me.Controls.SetChildIndex(Me.tx_valor, 0)
        Me.Controls.SetChildIndex(Me.bt_grabar, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.gb_recaudo, 0)
        Me.Controls.SetChildIndex(Me.lb_transportadora, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_recaudo.ResumeLayout(False)
        Me.gb_recaudo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cm_destino As ComboBox
    Friend WithEvents tx_valor As TextBox
    Friend WithEvents bt_grabar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents rb_sin_recaudo As RadioButton
    Friend WithEvents gb_recaudo As GroupBox
    Friend WithEvents rb_con_recaudo As RadioButton
    Friend WithEvents lb_transportadora As Label
End Class
