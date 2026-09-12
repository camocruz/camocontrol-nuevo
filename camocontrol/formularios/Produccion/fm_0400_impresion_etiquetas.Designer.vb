<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_impresion_etiquetas
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
        Me.dtp_fecha_vence = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_lote = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cm_formato_etiqueta = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nud_cantidad = New System.Windows.Forms.NumericUpDown()
        Me.bt_imprimir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_op_alterna = New System.Windows.Forms.TextBox()
        Me.tx_op_ppal = New System.Windows.Forms.TextBox()
        Me.nud_cant_englobada = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chk_englobe = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_fvence_aaaa_mm = New System.Windows.Forms.CheckBox()
        Me.dtp_fecha_produccion = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.tx_f_vence_digitada = New System.Windows.Forms.TextBox()
        Me.chk_f_vence_manual = New System.Windows.Forms.CheckBox()
        Me.Lb_DescripcionItem = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_cant_englobada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(91, 20)
        Me.lb_fecha.Text = "2015/07/18"
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(667, 42)
        Me.lb_titulo.Text = "Impresión Etiquetas Producto Terminado"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(280, 448)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 523)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'dtp_fecha_vence
        '
        Me.dtp_fecha_vence.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_vence.Location = New System.Drawing.Point(157, 298)
        Me.dtp_fecha_vence.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_fecha_vence.Name = "dtp_fecha_vence"
        Me.dtp_fecha_vence.Size = New System.Drawing.Size(381, 26)
        Me.dtp_fecha_vence.TabIndex = 151
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 302)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "Fecha Vence:"
        '
        'tx_lote
        '
        Me.tx_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_lote.Location = New System.Drawing.Point(157, 258)
        Me.tx_lote.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_lote.MaxLength = 30
        Me.tx_lote.Name = "tx_lote"
        Me.tx_lote.Size = New System.Drawing.Size(381, 26)
        Me.tx_lote.TabIndex = 149
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 261)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 20)
        Me.Label8.TabIndex = 148
        Me.Label8.Text = "Lote #:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 155)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 152
        Me.Label5.Text = "Orden Prod:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 94)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 20)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "Id_Item:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 363)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Cantidad Imp:"
        '
        'cm_formato_etiqueta
        '
        Me.cm_formato_etiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_formato_etiqueta.FormattingEnabled = True
        Me.cm_formato_etiqueta.Location = New System.Drawing.Point(157, 394)
        Me.cm_formato_etiqueta.Margin = New System.Windows.Forms.Padding(4)
        Me.cm_formato_etiqueta.Name = "cm_formato_etiqueta"
        Me.cm_formato_etiqueta.Size = New System.Drawing.Size(381, 28)
        Me.cm_formato_etiqueta.TabIndex = 159
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 398)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 158
        Me.Label3.Text = "Formato:"
        '
        'nud_cantidad
        '
        Me.nud_cantidad.Location = New System.Drawing.Point(157, 363)
        Me.nud_cantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.nud_cantidad.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.nud_cantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nud_cantidad.Name = "nud_cantidad"
        Me.nud_cantidad.Size = New System.Drawing.Size(92, 22)
        Me.nud_cantidad.TabIndex = 160
        Me.nud_cantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'bt_imprimir
        '
        Me.bt_imprimir.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_impresion
        Me.bt_imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_imprimir.Location = New System.Drawing.Point(668, 227)
        Me.bt_imprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_imprimir.Name = "bt_imprimir"
        Me.bt_imprimir.Size = New System.Drawing.Size(91, 60)
        Me.bt_imprimir.TabIndex = 161
        Me.bt_imprimir.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 192)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "Orden Prod Alt:"
        '
        'tx_op_alterna
        '
        Me.tx_op_alterna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_op_alterna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_op_alterna.Location = New System.Drawing.Point(157, 189)
        Me.tx_op_alterna.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_op_alterna.MaxLength = 30
        Me.tx_op_alterna.Name = "tx_op_alterna"
        Me.tx_op_alterna.Size = New System.Drawing.Size(381, 26)
        Me.tx_op_alterna.TabIndex = 163
        '
        'tx_op_ppal
        '
        Me.tx_op_ppal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_op_ppal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_op_ppal.Location = New System.Drawing.Point(157, 152)
        Me.tx_op_ppal.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_op_ppal.MaxLength = 30
        Me.tx_op_ppal.Name = "tx_op_ppal"
        Me.tx_op_ppal.Size = New System.Drawing.Size(381, 26)
        Me.tx_op_ppal.TabIndex = 164
        '
        'nud_cant_englobada
        '
        Me.nud_cant_englobada.Location = New System.Drawing.Point(73, 52)
        Me.nud_cant_englobada.Margin = New System.Windows.Forms.Padding(4)
        Me.nud_cant_englobada.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nud_cant_englobada.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nud_cant_englobada.Name = "nud_cant_englobada"
        Me.nud_cant_englobada.Size = New System.Drawing.Size(92, 26)
        Me.nud_cant_englobada.TabIndex = 166
        Me.nud_cant_englobada.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 50)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 20)
        Me.Label7.TabIndex = 165
        Me.Label7.Text = "Cant:"
        '
        'chk_englobe
        '
        Me.chk_englobe.AutoSize = True
        Me.chk_englobe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_englobe.Location = New System.Drawing.Point(16, 26)
        Me.chk_englobe.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_englobe.Name = "chk_englobe"
        Me.chk_englobe.Size = New System.Drawing.Size(91, 24)
        Me.chk_englobe.TabIndex = 167
        Me.chk_englobe.Text = "Englobe"
        Me.chk_englobe.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_englobe)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.nud_cant_englobada)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(783, 202)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(189, 97)
        Me.GroupBox2.TabIndex = 168
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Englobe"
        '
        'chk_fvence_aaaa_mm
        '
        Me.chk_fvence_aaaa_mm.AutoSize = True
        Me.chk_fvence_aaaa_mm.Location = New System.Drawing.Point(548, 303)
        Me.chk_fvence_aaaa_mm.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_fvence_aaaa_mm.Name = "chk_fvence_aaaa_mm"
        Me.chk_fvence_aaaa_mm.Size = New System.Drawing.Size(91, 20)
        Me.chk_fvence_aaaa_mm.TabIndex = 169
        Me.chk_fvence_aaaa_mm.Text = "AAAA/MM"
        Me.chk_fvence_aaaa_mm.UseVisualStyleBackColor = True
        '
        'dtp_fecha_produccion
        '
        Me.dtp_fecha_produccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_produccion.Location = New System.Drawing.Point(157, 223)
        Me.dtp_fecha_produccion.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_fecha_produccion.Name = "dtp_fecha_produccion"
        Me.dtp_fecha_produccion.Size = New System.Drawing.Size(381, 26)
        Me.dtp_fecha_produccion.TabIndex = 171
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 228)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 20)
        Me.Label9.TabIndex = 173
        Me.Label9.Text = "Fecha Produc:"
        '
        'tx_id_item
        '
        Me.tx_id_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(157, 92)
        Me.tx_id_item.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_id_item.MaxLength = 30
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(93, 26)
        Me.tx_id_item.TabIndex = 174
        '
        'tx_f_vence_digitada
        '
        Me.tx_f_vence_digitada.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tx_f_vence_digitada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_f_vence_digitada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_f_vence_digitada.Location = New System.Drawing.Point(157, 328)
        Me.tx_f_vence_digitada.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_f_vence_digitada.MaxLength = 30
        Me.tx_f_vence_digitada.Name = "tx_f_vence_digitada"
        Me.tx_f_vence_digitada.Size = New System.Drawing.Size(381, 26)
        Me.tx_f_vence_digitada.TabIndex = 175
        '
        'chk_f_vence_manual
        '
        Me.chk_f_vence_manual.AutoSize = True
        Me.chk_f_vence_manual.Location = New System.Drawing.Point(548, 333)
        Me.chk_f_vence_manual.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_f_vence_manual.Name = "chk_f_vence_manual"
        Me.chk_f_vence_manual.Size = New System.Drawing.Size(85, 20)
        Me.chk_f_vence_manual.TabIndex = 176
        Me.chk_f_vence_manual.Text = "MANUAL"
        Me.chk_f_vence_manual.UseVisualStyleBackColor = True
        '
        'Lb_DescripcionItem
        '
        Me.Lb_DescripcionItem.AutoSize = True
        Me.Lb_DescripcionItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_DescripcionItem.Location = New System.Drawing.Point(153, 122)
        Me.Lb_DescripcionItem.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb_DescripcionItem.Name = "Lb_DescripcionItem"
        Me.Lb_DescripcionItem.Size = New System.Drawing.Size(81, 20)
        Me.Lb_DescripcionItem.TabIndex = 177
        Me.Lb_DescripcionItem.Text = "Producto:"
        '
        'fm_0400_impresion_etiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(993, 539)
        Me.Controls.Add(Me.Lb_DescripcionItem)
        Me.Controls.Add(Me.chk_f_vence_manual)
        Me.Controls.Add(Me.tx_f_vence_digitada)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtp_fecha_produccion)
        Me.Controls.Add(Me.chk_fvence_aaaa_mm)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.tx_op_ppal)
        Me.Controls.Add(Me.tx_op_alterna)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bt_imprimir)
        Me.Controls.Add(Me.nud_cantidad)
        Me.Controls.Add(Me.cm_formato_etiqueta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtp_fecha_vence)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tx_lote)
        Me.Controls.Add(Me.Label8)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "fm_0400_impresion_etiquetas"
        Me.Text = "Impresión Etiquetas PT"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_lote, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_vence, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cm_formato_etiqueta, 0)
        Me.Controls.SetChildIndex(Me.nud_cantidad, 0)
        Me.Controls.SetChildIndex(Me.bt_imprimir, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tx_op_alterna, 0)
        Me.Controls.SetChildIndex(Me.tx_op_ppal, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.chk_fvence_aaaa_mm, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_produccion, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item, 0)
        Me.Controls.SetChildIndex(Me.tx_f_vence_digitada, 0)
        Me.Controls.SetChildIndex(Me.chk_f_vence_manual, 0)
        Me.Controls.SetChildIndex(Me.Lb_DescripcionItem, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_cant_englobada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp_fecha_vence As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tx_lote As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cm_formato_etiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nud_cantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents bt_imprimir As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_op_alterna As System.Windows.Forms.TextBox
    Friend WithEvents tx_op_ppal As System.Windows.Forms.TextBox
    Friend WithEvents nud_cant_englobada As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chk_englobe As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_fvence_aaaa_mm As System.Windows.Forms.CheckBox
    Friend WithEvents dtp_fecha_produccion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_id_item As TextBox
    Friend WithEvents tx_f_vence_digitada As TextBox
    Friend WithEvents chk_f_vence_manual As CheckBox
    Friend WithEvents Lb_DescripcionItem As Label
End Class
