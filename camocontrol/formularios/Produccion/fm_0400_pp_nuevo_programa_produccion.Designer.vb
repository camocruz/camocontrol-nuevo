<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_pp_nuevo_programa_produccion
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_f_fin = New System.Windows.Forms.DateTimePicker()
        Me.dtp_f_ini = New System.Windows.Forms.DateTimePicker()
        Me.tx_nombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(525, 42)
        Me.lb_titulo.Text = "Nuevo Programa De Produccion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(280, 212)
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 292)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(250, 154)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 19)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "al"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 154)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 19)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Lapso:"
        '
        'dtp_f_fin
        '
        Me.dtp_f_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_f_fin.Location = New System.Drawing.Point(282, 149)
        Me.dtp_f_fin.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_f_fin.Name = "dtp_f_fin"
        Me.dtp_f_fin.Size = New System.Drawing.Size(147, 22)
        Me.dtp_f_fin.TabIndex = 105
        '
        'dtp_f_ini
        '
        Me.dtp_f_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_f_ini.Location = New System.Drawing.Point(103, 149)
        Me.dtp_f_ini.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_f_ini.Name = "dtp_f_ini"
        Me.dtp_f_ini.Size = New System.Drawing.Size(137, 22)
        Me.dtp_f_ini.TabIndex = 104
        '
        'tx_nombre
        '
        Me.tx_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_nombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nombre.Location = New System.Drawing.Point(103, 115)
        Me.tx_nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_nombre.MaxLength = 100
        Me.tx_nombre.Name = "tx_nombre"
        Me.tx_nombre.Size = New System.Drawing.Size(325, 26)
        Me.tx_nombre.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 118)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 19)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Nombre:"
        '
        'fm_0400_pp_nuevo_programa_produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(994, 308)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_f_fin)
        Me.Controls.Add(Me.dtp_f_ini)
        Me.Controls.Add(Me.tx_nombre)
        Me.Controls.Add(Me.Label5)
        Me.Name = "fm_0400_pp_nuevo_programa_produccion"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_nombre, 0)
        Me.Controls.SetChildIndex(Me.dtp_f_ini, 0)
        Me.Controls.SetChildIndex(Me.dtp_f_fin, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtp_f_fin As DateTimePicker
    Friend WithEvents dtp_f_ini As DateTimePicker
    Friend WithEvents tx_nombre As TextBox
    Friend WithEvents Label5 As Label
End Class
