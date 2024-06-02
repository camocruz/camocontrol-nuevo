<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0500_dialog_suministro_documento
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
        Me.rb_copia = New System.Windows.Forms.RadioButton()
        Me.rb_visualizar = New System.Windows.Forms.RadioButton()
        Me.bt_aceptar = New System.Windows.Forms.Button()
        Me.bt_cancelar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(358, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(359, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/11/23"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(268, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(156, 32)
        Me.lb_titulo.Text = "Documento"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 275)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(12, 225)
        Me.bt_salir.Visible = False
        '
        'rb_copia
        '
        Me.rb_copia.AutoSize = True
        Me.rb_copia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_copia.Location = New System.Drawing.Point(158, 96)
        Me.rb_copia.Name = "rb_copia"
        Me.rb_copia.Size = New System.Drawing.Size(150, 22)
        Me.rb_copia.TabIndex = 63
        Me.rb_copia.TabStop = True
        Me.rb_copia.Text = "Obtener una Copia"
        Me.rb_copia.UseVisualStyleBackColor = True
        '
        'rb_visualizar
        '
        Me.rb_visualizar.AutoSize = True
        Me.rb_visualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_visualizar.Location = New System.Drawing.Point(158, 132)
        Me.rb_visualizar.Name = "rb_visualizar"
        Me.rb_visualizar.Size = New System.Drawing.Size(89, 22)
        Me.rb_visualizar.TabIndex = 64
        Me.rb_visualizar.TabStop = True
        Me.rb_visualizar.Text = "Visualizar"
        Me.rb_visualizar.UseVisualStyleBackColor = True
        '
        'bt_aceptar
        '
        Me.bt_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_aceptar.Location = New System.Drawing.Point(146, 195)
        Me.bt_aceptar.Name = "bt_aceptar"
        Me.bt_aceptar.Size = New System.Drawing.Size(75, 35)
        Me.bt_aceptar.TabIndex = 65
        Me.bt_aceptar.Text = "Aceptar"
        Me.bt_aceptar.UseVisualStyleBackColor = True
        '
        'bt_cancelar
        '
        Me.bt_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cancelar.Location = New System.Drawing.Point(252, 195)
        Me.bt_cancelar.Name = "bt_cancelar"
        Me.bt_cancelar.Size = New System.Drawing.Size(75, 35)
        Me.bt_cancelar.TabIndex = 66
        Me.bt_cancelar.Text = "Cancelar"
        Me.bt_cancelar.UseVisualStyleBackColor = True
        '
        'fm_0500_dialog_suministro_documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(437, 289)
        Me.Controls.Add(Me.bt_cancelar)
        Me.Controls.Add(Me.bt_aceptar)
        Me.Controls.Add(Me.rb_visualizar)
        Me.Controls.Add(Me.rb_copia)
        Me.Name = "fm_0500_dialog_suministro_documento"
        Me.Text = "Interaccion con Documento"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.rb_copia, 0)
        Me.Controls.SetChildIndex(Me.rb_visualizar, 0)
        Me.Controls.SetChildIndex(Me.bt_aceptar, 0)
        Me.Controls.SetChildIndex(Me.bt_cancelar, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rb_copia As System.Windows.Forms.RadioButton
    Friend WithEvents rb_visualizar As System.Windows.Forms.RadioButton
    Friend WithEvents bt_aceptar As System.Windows.Forms.Button
    Friend WithEvents bt_cancelar As System.Windows.Forms.Button

End Class
