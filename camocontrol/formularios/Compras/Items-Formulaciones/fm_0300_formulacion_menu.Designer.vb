<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_formulacion_menu
    Inherits camocontrol.FM_PLANTILLA_solo_salir

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bt_listado_plantillas = New System.Windows.Forms.Button()
        Me.bt_formulacion_actual = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/03/13"
        '
        'bt_listado_plantillas
        '
        Me.bt_listado_plantillas.Location = New System.Drawing.Point(312, 110)
        Me.bt_listado_plantillas.Name = "bt_listado_plantillas"
        Me.bt_listado_plantillas.Size = New System.Drawing.Size(128, 57)
        Me.bt_listado_plantillas.TabIndex = 63
        Me.bt_listado_plantillas.Text = "Listado Plantillas"
        Me.bt_listado_plantillas.UseVisualStyleBackColor = True
        '
        'bt_formulacion_actual
        '
        Me.bt_formulacion_actual.Location = New System.Drawing.Point(312, 173)
        Me.bt_formulacion_actual.Name = "bt_formulacion_actual"
        Me.bt_formulacion_actual.Size = New System.Drawing.Size(128, 57)
        Me.bt_formulacion_actual.TabIndex = 64
        Me.bt_formulacion_actual.Text = "Desarrollo Actual"
        Me.bt_formulacion_actual.UseVisualStyleBackColor = True
        '
        'fm_0300_formulacion_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(742, 458)
        Me.Controls.Add(Me.bt_formulacion_actual)
        Me.Controls.Add(Me.bt_listado_plantillas)
        Me.Name = "fm_0300_formulacion_menu"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.bt_listado_plantillas, 0)
        Me.Controls.SetChildIndex(Me.bt_formulacion_actual, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_listado_plantillas As System.Windows.Forms.Button
    Friend WithEvents bt_formulacion_actual As System.Windows.Forms.Button

End Class
