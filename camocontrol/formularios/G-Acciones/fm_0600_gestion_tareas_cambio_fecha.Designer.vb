<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_gestion_tareas_cambio_fecha
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
        Me.cm_unidad_duracion = New System.Windows.Forms.ComboBox()
        Me.dtp_fecha_fin_prog = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tx_duracion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_fecha_inicio_prog = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(429, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(527, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(528, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/06/17"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(385, 32)
        Me.lb_titulo.Text = "Cambiar Fechas Programadas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(252, 293)
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 353)
        '
        'cm_unidad_duracion
        '
        Me.cm_unidad_duracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_unidad_duracion.FormattingEnabled = True
        Me.cm_unidad_duracion.Location = New System.Drawing.Point(310, 134)
        Me.cm_unidad_duracion.Name = "cm_unidad_duracion"
        Me.cm_unidad_duracion.Size = New System.Drawing.Size(118, 24)
        Me.cm_unidad_duracion.TabIndex = 147
        '
        'dtp_fecha_fin_prog
        '
        Me.dtp_fecha_fin_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_fin_prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_fin_prog.Location = New System.Drawing.Point(244, 183)
        Me.dtp_fecha_fin_prog.Name = "dtp_fecha_fin_prog"
        Me.dtp_fecha_fin_prog.Size = New System.Drawing.Size(184, 22)
        Me.dtp_fecha_fin_prog.TabIndex = 146
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(136, 189)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 16)
        Me.Label11.TabIndex = 145
        Me.Label11.Text = "Fecha Fin Prog.:"
        '
        'tx_duracion
        '
        Me.tx_duracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_duracion.Location = New System.Drawing.Point(244, 135)
        Me.tx_duracion.Name = "tx_duracion"
        Me.tx_duracion.Size = New System.Drawing.Size(63, 22)
        Me.tx_duracion.TabIndex = 144
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(136, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 16)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "Duracion:"
        '
        'dtp_fecha_inicio_prog
        '
        Me.dtp_fecha_inicio_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio_prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_prog.Location = New System.Drawing.Point(244, 159)
        Me.dtp_fecha_inicio_prog.Name = "dtp_fecha_inicio_prog"
        Me.dtp_fecha_inicio_prog.Size = New System.Drawing.Size(184, 22)
        Me.dtp_fecha_inicio_prog.TabIndex = 142
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(136, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "Fecha Inicio:"
        '
        'fm_0600_gestion_tareas_cambio_fecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(614, 367)
        Me.Controls.Add(Me.cm_unidad_duracion)
        Me.Controls.Add(Me.dtp_fecha_fin_prog)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tx_duracion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtp_fecha_inicio_prog)
        Me.Controls.Add(Me.Label6)
        Me.Name = "fm_0600_gestion_tareas_cambio_fecha"
        Me.Text = "Cambiar Fecha Programada"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_inicio_prog, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_duracion, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_fin_prog, 0)
        Me.Controls.SetChildIndex(Me.cm_unidad_duracion, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_unidad_duracion As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha_fin_prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tx_duracion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio_prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
