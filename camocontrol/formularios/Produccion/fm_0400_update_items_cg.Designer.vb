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
        Me.tx_corrugado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_descripcion = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(807, 11)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(808, 44)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(91, 20)
        Me.lb_fecha.Text = "2021/09/07"
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(687, 7)
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(329, 42)
        Me.lb_titulo.Text = "Actualizar Items Cg"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 359)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(441, 314)
        Me.bt_salir.Margin = New System.Windows.Forms.Padding(5)
        Me.bt_salir.TabIndex = 9
        '
        'cm_linea
        '
        Me.cm_linea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_linea.FormattingEnabled = True
        Me.cm_linea.Location = New System.Drawing.Point(179, 144)
        Me.cm_linea.Margin = New System.Windows.Forms.Padding(4)
        Me.cm_linea.Name = "cm_linea"
        Me.cm_linea.Size = New System.Drawing.Size(392, 28)
        Me.cm_linea.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 154)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Linea Item:"
        '
        'tx_referencia
        '
        Me.tx_referencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_referencia.Location = New System.Drawing.Point(179, 106)
        Me.tx_referencia.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_referencia.Name = "tx_referencia"
        Me.tx_referencia.Size = New System.Drawing.Size(103, 26)
        Me.tx_referencia.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 113)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 20)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "Ref. CGUNO:"
        '
        'tx_planta
        '
        Me.tx_planta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_planta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_planta.Location = New System.Drawing.Point(179, 181)
        Me.tx_planta.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_planta.Name = "tx_planta"
        Me.tx_planta.Size = New System.Drawing.Size(392, 26)
        Me.tx_planta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 188)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 20)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Planta Produccion:"
        '
        'tx_tipo_produccion
        '
        Me.tx_tipo_produccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_tipo_produccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tipo_produccion.Location = New System.Drawing.Point(179, 215)
        Me.tx_tipo_produccion.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_tipo_produccion.Name = "tx_tipo_produccion"
        Me.tx_tipo_produccion.Size = New System.Drawing.Size(392, 26)
        Me.tx_tipo_produccion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 223)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 20)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Tipo Produccion:"
        '
        'tx_tipo_producto
        '
        Me.tx_tipo_producto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_tipo_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tipo_producto.Location = New System.Drawing.Point(179, 250)
        Me.tx_tipo_producto.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_tipo_producto.Name = "tx_tipo_producto"
        Me.tx_tipo_producto.Size = New System.Drawing.Size(392, 26)
        Me.tx_tipo_producto.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 257)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 20)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "Tipo Producto:"
        '
        'bt_actualizar
        '
        Me.bt_actualizar.Location = New System.Drawing.Point(791, 319)
        Me.bt_actualizar.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_actualizar.Name = "bt_actualizar"
        Me.bt_actualizar.Size = New System.Drawing.Size(97, 46)
        Me.bt_actualizar.TabIndex = 8
        Me.bt_actualizar.Text = "Actualizar"
        Me.bt_actualizar.UseVisualStyleBackColor = True
        '
        'tx_peso_unitario
        '
        Me.tx_peso_unitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_peso_unitario.Location = New System.Drawing.Point(773, 181)
        Me.tx_peso_unitario.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_peso_unitario.Name = "tx_peso_unitario"
        Me.tx_peso_unitario.Size = New System.Drawing.Size(113, 26)
        Me.tx_peso_unitario.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(616, 188)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 20)
        Me.Label13.TabIndex = 161
        Me.Label13.Text = "Peso unit (kg):"
        '
        'tx_unidad_medida
        '
        Me.tx_unidad_medida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_unidad_medida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidad_medida.Location = New System.Drawing.Point(773, 146)
        Me.tx_unidad_medida.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_unidad_medida.Name = "tx_unidad_medida"
        Me.tx_unidad_medida.Size = New System.Drawing.Size(113, 26)
        Me.tx_unidad_medida.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(616, 154)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "Unidad Medida:"
        '
        'tx_factor_empaque
        '
        Me.tx_factor_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_factor_empaque.Location = New System.Drawing.Point(773, 215)
        Me.tx_factor_empaque.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_factor_empaque.Name = "tx_factor_empaque"
        Me.tx_factor_empaque.Size = New System.Drawing.Size(113, 26)
        Me.tx_factor_empaque.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(616, 223)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 20)
        Me.Label7.TabIndex = 165
        Me.Label7.Text = "Factor Empaque:"
        '
        'tx_factor_cobertura
        '
        Me.tx_factor_cobertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_factor_cobertura.Location = New System.Drawing.Point(773, 250)
        Me.tx_factor_cobertura.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_factor_cobertura.Name = "tx_factor_cobertura"
        Me.tx_factor_cobertura.Size = New System.Drawing.Size(113, 26)
        Me.tx_factor_cobertura.TabIndex = 166
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(616, 257)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 20)
        Me.Label8.TabIndex = 167
        Me.Label8.Text = "Factor Cobertura:"
        '
        'tx_tipo_venta
        '
        Me.tx_tipo_venta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_tipo_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tipo_venta.Location = New System.Drawing.Point(179, 284)
        Me.tx_tipo_venta.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_tipo_venta.MaxLength = 3
        Me.tx_tipo_venta.Name = "tx_tipo_venta"
        Me.tx_tipo_venta.Size = New System.Drawing.Size(103, 26)
        Me.tx_tipo_venta.TabIndex = 168
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 292)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 20)
        Me.Label9.TabIndex = 169
        Me.Label9.Text = "Tipo Venta:"
        '
        'tx_corrugado
        '
        Me.tx_corrugado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_corrugado.Location = New System.Drawing.Point(773, 284)
        Me.tx_corrugado.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_corrugado.Name = "tx_corrugado"
        Me.tx_corrugado.Size = New System.Drawing.Size(113, 26)
        Me.tx_corrugado.TabIndex = 170
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(616, 292)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 20)
        Me.Label10.TabIndex = 171
        Me.Label10.Text = "# Corrugado:"
        '
        'tx_descripcion
        '
        Me.tx_descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_descripcion.Location = New System.Drawing.Point(288, 106)
        Me.tx_descripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_descripcion.Name = "tx_descripcion"
        Me.tx_descripcion.Size = New System.Drawing.Size(598, 26)
        Me.tx_descripcion.TabIndex = 172
        '
        'fm_0400_update_items_cg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(912, 375)
        Me.Controls.Add(Me.tx_descripcion)
        Me.Controls.Add(Me.tx_corrugado)
        Me.Controls.Add(Me.Label10)
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
        Me.Margin = New System.Windows.Forms.Padding(5)
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
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.tx_corrugado, 0)
        Me.Controls.SetChildIndex(Me.tx_descripcion, 0)
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
    Friend WithEvents tx_corrugado As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tx_descripcion As TextBox
End Class
