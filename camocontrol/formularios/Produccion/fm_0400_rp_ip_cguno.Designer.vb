<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_rp_ip_cguno
    Inherits camocontrol.FM_PLANTILLA

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
        Me.bt_calcular_lote = New System.Windows.Forms.Button()
        Me.dtp_fecha_vencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_lote = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_cant_produccion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.lb_producto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_id_rp = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_ip_cg = New System.Windows.Forms.TextBox()
        Me.bt_imprimir_etiquetas = New System.Windows.Forms.Button()
        Me.cm_bodega_entrega_pt = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_horas_hombre = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(651, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(749, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(750, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2019/02/22"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(455, 32)
        Me.lb_titulo.Text = "Reportes de Produccion IP CGUNO"
        '
        'bt_calcular_lote
        '
        Me.bt_calcular_lote.Location = New System.Drawing.Point(46, 152)
        Me.bt_calcular_lote.Name = "bt_calcular_lote"
        Me.bt_calcular_lote.Size = New System.Drawing.Size(62, 22)
        Me.bt_calcular_lote.TabIndex = 325
        Me.bt_calcular_lote.Text = "Calcular"
        Me.bt_calcular_lote.UseVisualStyleBackColor = True
        '
        'dtp_fecha_vencimiento
        '
        Me.dtp_fecha_vencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_vencimiento.Location = New System.Drawing.Point(114, 175)
        Me.dtp_fecha_vencimiento.Name = "dtp_fecha_vencimiento"
        Me.dtp_fecha_vencimiento.Size = New System.Drawing.Size(182, 22)
        Me.dtp_fecha_vencimiento.TabIndex = 321
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(9, 177)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 16)
        Me.Label18.TabIndex = 320
        Me.Label18.Text = "F. Vencimiento:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 16)
        Me.Label7.TabIndex = 319
        Me.Label7.Text = "Lote:"
        '
        'tx_lote
        '
        Me.tx_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_lote.Location = New System.Drawing.Point(114, 152)
        Me.tx_lote.MaxLength = 30
        Me.tx_lote.Name = "tx_lote"
        Me.tx_lote.Size = New System.Drawing.Size(182, 22)
        Me.tx_lote.TabIndex = 318
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 313
        Me.Label5.Text = "Produccion:"
        '
        'tx_cant_produccion
        '
        Me.tx_cant_produccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_cant_produccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cant_produccion.Location = New System.Drawing.Point(114, 203)
        Me.tx_cant_produccion.MaxLength = 30
        Me.tx_cant_produccion.Name = "tx_cant_produccion"
        Me.tx_cant_produccion.ReadOnly = True
        Me.tx_cant_produccion.Size = New System.Drawing.Size(182, 22)
        Me.tx_cant_produccion.TabIndex = 312
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 311
        Me.Label8.Text = "Fecha:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(114, 129)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(182, 20)
        Me.dtp_fecha.TabIndex = 310
        '
        'lb_producto
        '
        Me.lb_producto.AutoSize = True
        Me.lb_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_producto.Location = New System.Drawing.Point(258, 74)
        Me.lb_producto.Name = "lb_producto"
        Me.lb_producto.Size = New System.Drawing.Size(91, 20)
        Me.lb_producto.TabIndex = 309
        Me.lb_producto.Text = "Producto: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 308
        Me.Label4.Text = "# Reporte:"
        '
        'tx_id_rp
        '
        Me.tx_id_rp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_rp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_rp.Location = New System.Drawing.Point(114, 74)
        Me.tx_id_rp.MaxLength = 30
        Me.tx_id_rp.Name = "tx_id_rp"
        Me.tx_id_rp.ReadOnly = True
        Me.tx_id_rp.Size = New System.Drawing.Size(138, 22)
        Me.tx_id_rp.TabIndex = 307
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 327
        Me.Label1.Text = "# IP CG-UNO:"
        '
        'tx_ip_cg
        '
        Me.tx_ip_cg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_ip_cg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_ip_cg.Location = New System.Drawing.Point(114, 102)
        Me.tx_ip_cg.MaxLength = 30
        Me.tx_ip_cg.Name = "tx_ip_cg"
        Me.tx_ip_cg.ReadOnly = True
        Me.tx_ip_cg.Size = New System.Drawing.Size(138, 22)
        Me.tx_ip_cg.TabIndex = 326
        '
        'bt_imprimir_etiquetas
        '
        Me.bt_imprimir_etiquetas.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_impresion
        Me.bt_imprimir_etiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_imprimir_etiquetas.Location = New System.Drawing.Point(302, 129)
        Me.bt_imprimir_etiquetas.Name = "bt_imprimir_etiquetas"
        Me.bt_imprimir_etiquetas.Size = New System.Drawing.Size(51, 46)
        Me.bt_imprimir_etiquetas.TabIndex = 328
        Me.bt_imprimir_etiquetas.UseVisualStyleBackColor = True
        '
        'cm_bodega_entrega_pt
        '
        Me.cm_bodega_entrega_pt.FormattingEnabled = True
        Me.cm_bodega_entrega_pt.Location = New System.Drawing.Point(9, 280)
        Me.cm_bodega_entrega_pt.Name = "cm_bodega_entrega_pt"
        Me.cm_bodega_entrega_pt.Size = New System.Drawing.Size(412, 21)
        Me.cm_bodega_entrega_pt.TabIndex = 330
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(9, 262)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(129, 16)
        Me.Label23.TabIndex = 329
        Me.Label23.Text = "Bodega de Entrega:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 231)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 16)
        Me.Label10.TabIndex = 332
        Me.Label10.Text = "H. Hombre:"
        '
        'tx_horas_hombre
        '
        Me.tx_horas_hombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_horas_hombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_horas_hombre.Location = New System.Drawing.Point(114, 228)
        Me.tx_horas_hombre.MaxLength = 30
        Me.tx_horas_hombre.Name = "tx_horas_hombre"
        Me.tx_horas_hombre.Size = New System.Drawing.Size(182, 22)
        Me.tx_horas_hombre.TabIndex = 331
        '
        'fm_0400_rp_ip_cguno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(836, 488)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tx_horas_hombre)
        Me.Controls.Add(Me.cm_bodega_entrega_pt)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.bt_imprimir_etiquetas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_ip_cg)
        Me.Controls.Add(Me.bt_calcular_lote)
        Me.Controls.Add(Me.dtp_fecha_vencimiento)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_lote)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_cant_produccion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.lb_producto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_id_rp)
        Me.Name = "fm_0400_rp_ip_cguno"
        Me.Text = "IP CG-UNO"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.tx_id_rp, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lb_producto, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_cant_produccion, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_lote, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_vencimiento, 0)
        Me.Controls.SetChildIndex(Me.bt_calcular_lote, 0)
        Me.Controls.SetChildIndex(Me.tx_ip_cg, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.bt_imprimir_etiquetas, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.cm_bodega_entrega_pt, 0)
        Me.Controls.SetChildIndex(Me.tx_horas_hombre, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bt_calcular_lote As Button
    Friend WithEvents dtp_fecha_vencimiento As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tx_lote As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tx_cant_produccion As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents lb_producto As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tx_id_rp As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tx_ip_cg As TextBox
    Friend WithEvents bt_imprimir_etiquetas As Button
    Friend WithEvents cm_bodega_entrega_pt As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tx_horas_hombre As TextBox
End Class
