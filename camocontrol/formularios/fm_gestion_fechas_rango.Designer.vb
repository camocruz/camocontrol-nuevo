<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_gestion_fechas_rango
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
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.bt_salir = New System.Windows.Forms.Button()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.dtp_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'bt_grabar
        '
        Me.bt_grabar.BackgroundImage = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_grabar.Location = New System.Drawing.Point(70, 264)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(49, 38)
        Me.bt_grabar.TabIndex = 2
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'bt_salir
        '
        Me.bt_salir.BackgroundImage = Global.camocontrol.My.Resources.Resources.salida2
        Me.bt_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_salir.Location = New System.Drawing.Point(139, 264)
        Me.bt_salir.Name = "bt_salir"
        Me.bt_salir.Size = New System.Drawing.Size(49, 38)
        Me.bt_salir.TabIndex = 3
        Me.bt_salir.UseVisualStyleBackColor = True
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthCalendar1.Location = New System.Drawing.Point(18, 18)
        Me.MonthCalendar1.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MonthCalendar1.MaxSelectionCount = 10000
        Me.MonthCalendar1.MinDate = New Date(2013, 1, 1, 0, 0, 0, 0)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 61
        '
        'dtp_fecha_ini
        '
        Me.dtp_fecha_ini.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_ini.Location = New System.Drawing.Point(118, 191)
        Me.dtp_fecha_ini.MinDate = New Date(2013, 1, 1, 0, 0, 0, 0)
        Me.dtp_fecha_ini.Name = "dtp_fecha_ini"
        Me.dtp_fecha_ini.Size = New System.Drawing.Size(127, 26)
        Me.dtp_fecha_ini.TabIndex = 0
        '
        'dtp_fecha_fin
        '
        Me.dtp_fecha_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_fin.Location = New System.Drawing.Point(118, 217)
        Me.dtp_fecha_fin.MinDate = New Date(2013, 1, 1, 0, 0, 0, 0)
        Me.dtp_fecha_fin.Name = "dtp_fecha_fin"
        Me.dtp_fecha_fin.Size = New System.Drawing.Size(127, 26)
        Me.dtp_fecha_fin.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Fecha Inicial:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Fecha Final:"
        '
        'fm_gestion_fechas_rango
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(266, 322)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_fecha_fin)
        Me.Controls.Add(Me.dtp_fecha_ini)
        Me.Controls.Add(Me.bt_grabar)
        Me.Controls.Add(Me.bt_salir)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fm_gestion_fechas_rango"
        Me.Text = "Rango de Fechas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents bt_grabar As System.Windows.Forms.Button
    Protected Friend WithEvents bt_salir As System.Windows.Forms.Button
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents dtp_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
