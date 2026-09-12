<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_rp_reporte_lotes_produccion
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
        Me.tx_ip_cg = New System.Windows.Forms.TextBox()
        Me.bt_calcular_lote = New System.Windows.Forms.Button()
        Me.dtp_fecha_vencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_lote = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.lb_producto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_id_rp = New System.Windows.Forms.TextBox()
        Me.bt_imprimir_etiquetas = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(660, 7)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(790, 11)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(791, 44)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(458, 42)
        Me.lb_titulo.Text = "Reporte Lote de Produccion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(152, 286)
        '
        'bt_grabar
        '
        '
        'bt_anular
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 399)
        '
        'bt_editar
        '
        '
        'tx_ip_cg
        '
        Me.tx_ip_cg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_ip_cg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_ip_cg.Location = New System.Drawing.Point(244, 120)
        Me.tx_ip_cg.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_ip_cg.MaxLength = 30
        Me.tx_ip_cg.Name = "tx_ip_cg"
        Me.tx_ip_cg.ReadOnly = True
        Me.tx_ip_cg.Size = New System.Drawing.Size(149, 26)
        Me.tx_ip_cg.TabIndex = 321
        '
        'bt_calcular_lote
        '
        Me.bt_calcular_lote.Location = New System.Drawing.Point(61, 183)
        Me.bt_calcular_lote.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_calcular_lote.Name = "bt_calcular_lote"
        Me.bt_calcular_lote.Size = New System.Drawing.Size(83, 27)
        Me.bt_calcular_lote.TabIndex = 319
        Me.bt_calcular_lote.Text = "Calcular"
        Me.bt_calcular_lote.UseVisualStyleBackColor = True
        '
        'dtp_fecha_vencimiento
        '
        Me.dtp_fecha_vencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_vencimiento.Location = New System.Drawing.Point(152, 211)
        Me.dtp_fecha_vencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_fecha_vencimiento.Name = "dtp_fecha_vencimiento"
        Me.dtp_fecha_vencimiento.Size = New System.Drawing.Size(241, 26)
        Me.dtp_fecha_vencimiento.TabIndex = 318
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 213)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(125, 20)
        Me.Label18.TabIndex = 317
        Me.Label18.Text = "F. Vencimiento:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 186)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 20)
        Me.Label7.TabIndex = 316
        Me.Label7.Text = "Lote:"
        '
        'tx_lote
        '
        Me.tx_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_lote.Location = New System.Drawing.Point(152, 183)
        Me.tx_lote.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_lote.MaxLength = 30
        Me.tx_lote.Name = "tx_lote"
        Me.tx_lote.Size = New System.Drawing.Size(241, 26)
        Me.tx_lote.TabIndex = 315
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 159)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 20)
        Me.Label8.TabIndex = 314
        Me.Label8.Text = "Fecha:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(152, 154)
        Me.dtp_fecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(241, 23)
        Me.dtp_fecha.TabIndex = 313
        '
        'lb_producto
        '
        Me.lb_producto.AutoSize = True
        Me.lb_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_producto.Location = New System.Drawing.Point(11, 85)
        Me.lb_producto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_producto.Name = "lb_producto"
        Me.lb_producto.Size = New System.Drawing.Size(87, 18)
        Me.lb_producto.TabIndex = 312
        Me.lb_producto.Text = "Producto: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 124)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 311
        Me.Label4.Text = "# Reporte:"
        '
        'tx_id_rp
        '
        Me.tx_id_rp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_rp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_rp.Location = New System.Drawing.Point(152, 120)
        Me.tx_id_rp.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_id_rp.MaxLength = 30
        Me.tx_id_rp.Name = "tx_id_rp"
        Me.tx_id_rp.ReadOnly = True
        Me.tx_id_rp.Size = New System.Drawing.Size(84, 26)
        Me.tx_id_rp.TabIndex = 310
        '
        'bt_imprimir_etiquetas
        '
        Me.bt_imprimir_etiquetas.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_impresion
        Me.bt_imprimir_etiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_imprimir_etiquetas.Location = New System.Drawing.Point(433, 169)
        Me.bt_imprimir_etiquetas.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_imprimir_etiquetas.Name = "bt_imprimir_etiquetas"
        Me.bt_imprimir_etiquetas.Size = New System.Drawing.Size(68, 57)
        Me.bt_imprimir_etiquetas.TabIndex = 320
        Me.bt_imprimir_etiquetas.UseVisualStyleBackColor = True
        '
        'fm_0400_rp_reporte_lotes_produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(907, 415)
        Me.Controls.Add(Me.tx_ip_cg)
        Me.Controls.Add(Me.bt_calcular_lote)
        Me.Controls.Add(Me.dtp_fecha_vencimiento)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_lote)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.lb_producto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_id_rp)
        Me.Controls.Add(Me.bt_imprimir_etiquetas)
        Me.Name = "fm_0400_rp_reporte_lotes_produccion"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_imprimir_etiquetas, 0)
        Me.Controls.SetChildIndex(Me.tx_id_rp, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lb_producto, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_lote, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_vencimiento, 0)
        Me.Controls.SetChildIndex(Me.bt_calcular_lote, 0)
        Me.Controls.SetChildIndex(Me.tx_ip_cg, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tx_ip_cg As TextBox
    Friend WithEvents bt_calcular_lote As Button
    Friend WithEvents dtp_fecha_vencimiento As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tx_lote As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents lb_producto As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tx_id_rp As TextBox
    Friend WithEvents bt_imprimir_etiquetas As Button
End Class
