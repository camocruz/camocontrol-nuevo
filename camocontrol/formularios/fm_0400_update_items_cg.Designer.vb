<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_update_items_cg
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.cm_linea = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_referencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_planta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_tipo_produccion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_tipo_producto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_actualizar = New System.Windows.Forms.Button()
        Me.lb_descripcion = New System.Windows.Forms.Label()
        Me.tx_peso_unitario = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tx_unidad_medida = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_factor_empaque = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_factor_cobertura = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_tipo_venta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(605, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(606, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2021/09/07"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(515, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(259, 32)
        Me.lb_titulo.Text = "Actualizar Items Cg"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 291)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 255)
        Me.bt_salir.TabIndex = 9
        '
        'cm_linea
        '
        Me.cm_linea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_linea.FormattingEnabled = True
        Me.cm_linea.Location = New System.Drawing.Point(134, 117)
        Me.cm_linea.Name = "cm_linea"
        Me.cm_linea.Size = New System.Drawing.Size(295, 24)
        Me.cm_linea.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Linea Item:"
        '
        'tx_referencia
        '
        Me.tx_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_referencia.Location = New System.Drawing.Point(134, 86)
        Me.tx_referencia.Name = "tx_referencia"
        Me.tx_referencia.Size = New System.Drawing.Size(78, 22)
        Me.tx_referencia.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 16)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "Ref. CGUNO:"
        '
        'tx_planta
        '
        Me.tx_planta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_planta.Location = New System.Drawing.Point(134, 147)
        Me.tx_planta.Name = "tx_planta"
        Me.tx_planta.Size = New System.Drawing.Size(295, 22)
        Me.tx_planta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Planta Produccion:"
        '
        'tx_tipo_produccion
        '
        Me.tx_tipo_produccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tipo_produccion.Location = New System.Drawing.Point(134, 175)
        Me.tx_tipo_produccion.Name = "tx_tipo_produccion"
        Me.tx_tipo_produccion.Size = New System.Drawing.Size(295, 22)
        Me.tx_tipo_produccion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 16)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Tipo Produccion:"
        '
        'tx_tipo_producto
        '
        Me.tx_tipo_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tipo_producto.Location = New System.Drawing.Point(134, 203)
        Me.tx_tipo_producto.Name = "tx_tipo_producto"
        Me.tx_tipo_producto.Size = New System.Drawing.Size(295, 22)
        Me.tx_tipo_producto.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "Tipo Producto:"
        '
        'bt_actualizar
        '
        Me.bt_actualizar.Location = New System.Drawing.Point(580, 239)
        Me.bt_actualizar.Name = "bt_actualizar"
        Me.bt_actualizar.Size = New System.Drawing.Size(86, 58)
        Me.bt_actualizar.TabIndex = 8
        Me.bt_actualizar.Text = "Actualizar"
        Me.bt_actualizar.UseVisualStyleBackColor = True
        '
        'lb_descripcion
        '
        Me.lb_descripcion.AutoSize = True
        Me.lb_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_descripcion.Location = New System.Drawing.Point(227, 92)
        Me.lb_descripcion.Name = "lb_descripcion"
        Me.lb_descripcion.Size = New System.Drawing.Size(28, 16)
        Me.lb_descripcion.TabIndex = 149
        Me.lb_descripcion.Text = "ND"
        '
        'tx_peso_unitario
        '
        Me.tx_peso_unitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_peso_unitario.Location = New System.Drawing.Point(580, 147)
        Me.tx_peso_unitario.Name = "tx_peso_unitario"
        Me.tx_peso_unitario.Size = New System.Drawing.Size(86, 22)
        Me.tx_peso_unitario.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(462, 153)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 16)
        Me.Label13.TabIndex = 161
        Me.Label13.Text = "Peso unit (kg):"
        '
        'tx_unidad_medida
        '
        Me.tx_unidad_medida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidad_medida.Location = New System.Drawing.Point(580, 119)
        Me.tx_unidad_medida.Name = "tx_unidad_medida"
        Me.tx_unidad_medida.Size = New System.Drawing.Size(86, 22)
        Me.tx_unidad_medida.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(462, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "Unidad Medida:"
        '
        'tx_factor_empaque
        '
        Me.tx_factor_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_factor_empaque.Location = New System.Drawing.Point(580, 175)
        Me.tx_factor_empaque.Name = "tx_factor_empaque"
        Me.tx_factor_empaque.Size = New System.Drawing.Size(86, 22)
        Me.tx_factor_empaque.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(462, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 16)
        Me.Label7.TabIndex = 165
        Me.Label7.Text = "Factor Empaque:"
        '
        'tx_factor_cobertura
        '
        Me.tx_factor_cobertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_factor_cobertura.Location = New System.Drawing.Point(580, 203)
        Me.tx_factor_cobertura.Name = "tx_factor_cobertura"
        Me.tx_factor_cobertura.Size = New System.Drawing.Size(86, 22)
        Me.tx_factor_cobertura.TabIndex = 166
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(462, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 16)
        Me.Label8.TabIndex = 167
        Me.Label8.Text = "Factor Cobertura:"
        '
        'tx_tipo_venta
        '
        Me.tx_tipo_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tipo_venta.Location = New System.Drawing.Point(134, 231)
        Me.tx_tipo_venta.MaxLength = 3
        Me.tx_tipo_venta.Name = "tx_tipo_venta"
        Me.tx_tipo_venta.Size = New System.Drawing.Size(78, 22)
        Me.tx_tipo_venta.TabIndex = 168
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 169
        Me.Label9.Text = "Tipo Venta:"
        '
        'fm_0400_update_items_cg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(684, 305)
        Me.Controls.Add(Me.tx_tipo_venta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_factor_cobertura)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tx_factor_empaque)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_unidad_medida)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_peso_unitario)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lb_descripcion)
        Me.Controls.Add(Me.bt_actualizar)
        Me.Controls.Add(Me.tx_tipo_producto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_tipo_produccion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_planta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_referencia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_linea)
        Me.Controls.Add(Me.Label4)
        Me.Name = "fm_0400_update_items_cg"
        Me.Text = "ITEMS CG"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cm_linea, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_referencia, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_planta, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_tipo_produccion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_tipo_producto, 0)
        Me.Controls.SetChildIndex(Me.bt_actualizar, 0)
        Me.Controls.SetChildIndex(Me.lb_descripcion, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_peso_unitario, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_unidad_medida, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_factor_empaque, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_factor_cobertura, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_tipo_venta, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_linea As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tx_referencia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tx_planta As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tx_tipo_produccion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tx_tipo_producto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents bt_actualizar As Button
    Friend WithEvents lb_descripcion As Label
    Friend WithEvents tx_peso_unitario As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tx_unidad_medida As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tx_factor_empaque As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tx_factor_cobertura As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tx_tipo_venta As TextBox
    Friend WithEvents Label9 As Label
End Class
