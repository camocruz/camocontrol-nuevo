<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_historico_compras_item
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
        Me.cm_descripcion = New System.Windows.Forms.ComboBox()
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bt_consultar_movimientos = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2015/04/13"
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(656, 51)
        Me.lb_titulo.Text = "Consulta Historico Compras Item"
        '
        'cm_descripcion
        '
        Me.cm_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_descripcion.FormattingEnabled = True
        Me.cm_descripcion.Location = New System.Drawing.Point(339, 146)
        Me.cm_descripcion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_descripcion.Name = "cm_descripcion"
        Me.cm_descripcion.Size = New System.Drawing.Size(684, 33)
        Me.cm_descripcion.TabIndex = 135
        '
        'tx_id_item
        '
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(212, 149)
        Me.tx_id_item.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(116, 30)
        Me.tx_id_item.TabIndex = 136
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(45, 154)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 25)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Id_item:"
        '
        'bt_consultar_movimientos
        '
        Me.bt_consultar_movimientos.Location = New System.Drawing.Point(212, 202)
        Me.bt_consultar_movimientos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_consultar_movimientos.Name = "bt_consultar_movimientos"
        Me.bt_consultar_movimientos.Size = New System.Drawing.Size(150, 69)
        Me.bt_consultar_movimientos.TabIndex = 138
        Me.bt_consultar_movimientos.Text = "Consultar"
        Me.bt_consultar_movimientos.UseVisualStyleBackColor = True
        '
        'fm_0300_historico_compras_item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1113, 705)
        Me.Controls.Add(Me.bt_consultar_movimientos)
        Me.Controls.Add(Me.cm_descripcion)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label5)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "fm_0300_historico_compras_item"
        Me.Text = "Movimientos Compras Item"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item, 0)
        Me.Controls.SetChildIndex(Me.cm_descripcion, 0)
        Me.Controls.SetChildIndex(Me.bt_consultar_movimientos, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_descripcion As System.Windows.Forms.ComboBox
    Friend WithEvents tx_id_item As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents bt_consultar_movimientos As System.Windows.Forms.Button

End Class
