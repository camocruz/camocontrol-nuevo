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
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bt_consultar_movimientos = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_item_descripcion = New System.Windows.Forms.TextBox()
        Me.bt_listado_general_items = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2015/04/13"
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(428, 32)
        Me.lb_titulo.Text = "Consulta Historico Compras Item"
        '
        'tx_id_item
        '
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(141, 97)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item.TabIndex = 136
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Id_item:"
        '
        'bt_consultar_movimientos
        '
        Me.bt_consultar_movimientos.Location = New System.Drawing.Point(141, 131)
        Me.bt_consultar_movimientos.Name = "bt_consultar_movimientos"
        Me.bt_consultar_movimientos.Size = New System.Drawing.Size(100, 45)
        Me.bt_consultar_movimientos.TabIndex = 138
        Me.bt_consultar_movimientos.Text = "Consultar"
        Me.bt_consultar_movimientos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(692, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "Ctrl+B"
        '
        'tx_item_descripcion
        '
        Me.tx_item_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_item_descripcion.Location = New System.Drawing.Point(226, 97)
        Me.tx_item_descripcion.Name = "tx_item_descripcion"
        Me.tx_item_descripcion.Size = New System.Drawing.Size(457, 22)
        Me.tx_item_descripcion.TabIndex = 211
        '
        'bt_listado_general_items
        '
        Me.bt_listado_general_items.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_listado_general_items.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_listado_general_items.Location = New System.Drawing.Point(689, 83)
        Me.bt_listado_general_items.Name = "bt_listado_general_items"
        Me.bt_listado_general_items.Size = New System.Drawing.Size(38, 36)
        Me.bt_listado_general_items.TabIndex = 213
        Me.bt_listado_general_items.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_listado_general_items.UseVisualStyleBackColor = True
        '
        'fm_0300_historico_compras_item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(742, 458)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_item_descripcion)
        Me.Controls.Add(Me.bt_listado_general_items)
        Me.Controls.Add(Me.bt_consultar_movimientos)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label5)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
        Me.Controls.SetChildIndex(Me.bt_consultar_movimientos, 0)
        Me.Controls.SetChildIndex(Me.bt_listado_general_items, 0)
        Me.Controls.SetChildIndex(Me.tx_item_descripcion, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_id_item As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents bt_consultar_movimientos As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents tx_item_descripcion As TextBox
    Friend WithEvents bt_listado_general_items As Button
End Class
