<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0100_gestion_especificaciones
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
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tx_observacion = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tx_maximo = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tx_minimo = New System.Windows.Forms.TextBox()
        Me.cm_tipo_especificacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_especificacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_nombre_especificacion = New System.Windows.Forms.TextBox()
        Me.chk_estandar = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cm_unidad = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2013/12/11"
        '
        'lb_titulo
        '
        Me.lb_titulo.Location = New System.Drawing.Point(206, 9)
        Me.lb_titulo.Size = New System.Drawing.Size(352, 32)
        Me.lb_titulo.Text = "Gestion de Especificaciones"
        '
        'bt_grabar
        '
        '
        'bt_anular
        '
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(18, 201)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(88, 16)
        Me.Label29.TabIndex = 123
        Me.Label29.Text = "Observacion:"
        '
        'tx_observacion
        '
        Me.tx_observacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_observacion.Location = New System.Drawing.Point(112, 201)
        Me.tx_observacion.Multiline = True
        Me.tx_observacion.Name = "tx_observacion"
        Me.tx_observacion.Size = New System.Drawing.Size(574, 179)
        Me.tx_observacion.TabIndex = 122
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(561, 125)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(24, 25)
        Me.Label28.TabIndex = 121
        Me.Label28.Text = "+"
        '
        'tx_maximo
        '
        Me.tx_maximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_maximo.Location = New System.Drawing.Point(580, 129)
        Me.tx_maximo.Name = "tx_maximo"
        Me.tx_maximo.Size = New System.Drawing.Size(104, 22)
        Me.tx_maximo.TabIndex = 120
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(563, 154)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(19, 25)
        Me.Label26.TabIndex = 119
        Me.Label26.Text = "-"
        '
        'tx_minimo
        '
        Me.tx_minimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_minimo.Location = New System.Drawing.Point(580, 161)
        Me.tx_minimo.Name = "tx_minimo"
        Me.tx_minimo.Size = New System.Drawing.Size(104, 22)
        Me.tx_minimo.TabIndex = 118
        '
        'cm_tipo_especificacion
        '
        Me.cm_tipo_especificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_especificacion.FormattingEnabled = True
        Me.cm_tipo_especificacion.Location = New System.Drawing.Point(234, 64)
        Me.cm_tipo_especificacion.Name = "cm_tipo_especificacion"
        Me.cm_tipo_especificacion.Size = New System.Drawing.Size(452, 24)
        Me.cm_tipo_especificacion.TabIndex = 117
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(350, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 16)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Especificación:"
        '
        'tx_especificacion
        '
        Me.tx_especificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_especificacion.Location = New System.Drawing.Point(454, 144)
        Me.tx_especificacion.Name = "tx_especificacion"
        Me.tx_especificacion.Size = New System.Drawing.Size(104, 22)
        Me.tx_especificacion.TabIndex = 126
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Especificación:"
        '
        'tx_nombre_especificacion
        '
        Me.tx_nombre_especificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nombre_especificacion.Location = New System.Drawing.Point(114, 94)
        Me.tx_nombre_especificacion.Name = "tx_nombre_especificacion"
        Me.tx_nombre_especificacion.Size = New System.Drawing.Size(572, 22)
        Me.tx_nombre_especificacion.TabIndex = 128
        '
        'chk_estandar
        '
        Me.chk_estandar.AutoSize = True
        Me.chk_estandar.Checked = True
        Me.chk_estandar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_estandar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_estandar.Location = New System.Drawing.Point(114, 66)
        Me.chk_estandar.Name = "chk_estandar"
        Me.chk_estandar.Size = New System.Drawing.Size(114, 20)
        Me.chk_estandar.TabIndex = 130
        Me.chk_estandar.Text = "Estandarizada"
        Me.chk_estandar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(108, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Unidad Medida:"
        '
        'cm_unidad
        '
        Me.cm_unidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_unidad.FormattingEnabled = True
        Me.cm_unidad.Location = New System.Drawing.Point(217, 144)
        Me.cm_unidad.Name = "cm_unidad"
        Me.cm_unidad.Size = New System.Drawing.Size(114, 24)
        Me.cm_unidad.TabIndex = 133
        '
        'fm_0100_gestion_especificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 483)
        Me.Controls.Add(Me.cm_unidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chk_estandar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_nombre_especificacion)
        Me.Controls.Add(Me.tx_maximo)
        Me.Controls.Add(Me.tx_minimo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_especificacion)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.tx_observacion)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cm_tipo_especificacion)
        Me.Name = "fm_0100_gestion_especificaciones"
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_especificacion, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.tx_observacion, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.tx_especificacion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_minimo, 0)
        Me.Controls.SetChildIndex(Me.tx_maximo, 0)
        Me.Controls.SetChildIndex(Me.tx_nombre_especificacion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.chk_estandar, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cm_unidad, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tx_observacion As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents tx_maximo As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents tx_minimo As System.Windows.Forms.TextBox
    Friend WithEvents cm_tipo_especificacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tx_especificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_nombre_especificacion As System.Windows.Forms.TextBox
    Friend WithEvents chk_estandar As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cm_unidad As System.Windows.Forms.ComboBox

End Class
