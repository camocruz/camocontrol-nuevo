<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0008_archivos_recibo_consignacion
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
        Me.cm_archivo_recaudo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/09/28"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(404, 32)
        Me.lb_titulo.Text = "Archivos recibos consignaciones"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 212)
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 272)
        '
        'bt_editar
        '
        '
        'cm_archivo_recaudo
        '
        Me.cm_archivo_recaudo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_archivo_recaudo.FormattingEnabled = True
        Me.cm_archivo_recaudo.Location = New System.Drawing.Point(207, 119)
        Me.cm_archivo_recaudo.Name = "cm_archivo_recaudo"
        Me.cm_archivo_recaudo.Size = New System.Drawing.Size(446, 26)
        Me.cm_archivo_recaudo.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 18)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Descripcion archivo:"
        '
        'fm_0008_archivos_recibo_consignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 286)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cm_archivo_recaudo)
        Me.Name = "fm_0008_archivos_recibo_consignacion"
        Me.Text = "Archivos recibos consignaciones"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.cm_archivo_recaudo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_archivo_recaudo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
