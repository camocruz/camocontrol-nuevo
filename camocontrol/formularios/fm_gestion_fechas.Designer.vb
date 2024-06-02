<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_gestion_fechas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.nud_hora = New System.Windows.Forms.NumericUpDown()
        Me.nud_minuto = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.bt_salir = New System.Windows.Forms.Button()
        CType(Me.nud_hora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_minuto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(18, 18)
        Me.MonthCalendar1.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MonthCalendar1.MaxSelectionCount = 1
        Me.MonthCalendar1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        '
        'nud_hora
        '
        Me.nud_hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nud_hora.Location = New System.Drawing.Point(14, 26)
        Me.nud_hora.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.nud_hora.Name = "nud_hora"
        Me.nud_hora.Size = New System.Drawing.Size(61, 44)
        Me.nud_hora.TabIndex = 1
        '
        'nud_minuto
        '
        Me.nud_minuto.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nud_minuto.Location = New System.Drawing.Point(95, 26)
        Me.nud_minuto.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nud_minuto.Name = "nud_minuto"
        Me.nud_minuto.Size = New System.Drawing.Size(61, 44)
        Me.nud_minuto.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 39)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = ":"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nud_minuto)
        Me.GroupBox1.Controls.Add(Me.nud_hora)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(44, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(172, 82)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hora"
        '
        'bt_grabar
        '
        Me.bt_grabar.BackgroundImage = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_grabar.Location = New System.Drawing.Point(70, 286)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(49, 38)
        Me.bt_grabar.TabIndex = 60
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'bt_salir
        '
        Me.bt_salir.BackgroundImage = Global.camocontrol.My.Resources.Resources.salida2
        Me.bt_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_salir.Location = New System.Drawing.Point(139, 286)
        Me.bt_salir.Name = "bt_salir"
        Me.bt_salir.Size = New System.Drawing.Size(49, 38)
        Me.bt_salir.TabIndex = 59
        Me.bt_salir.UseVisualStyleBackColor = True
        '
        'fm_gestion_fechas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 340)
        Me.Controls.Add(Me.bt_grabar)
        Me.Controls.Add(Me.bt_salir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fm_gestion_fechas"
        Me.Text = "Gestion Fecha"
        CType(Me.nud_hora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_minuto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents nud_hora As System.Windows.Forms.NumericUpDown
    Friend WithEvents nud_minuto As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected Friend WithEvents bt_grabar As System.Windows.Forms.Button
    Protected Friend WithEvents bt_salir As System.Windows.Forms.Button
End Class
