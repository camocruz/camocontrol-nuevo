<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0500_digitalizar_registro
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_id_registro = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cm_codigo_documento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_turno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_anotacion = New System.Windows.Forms.TextBox()
        Me.cm_titulo_documento = New System.Windows.Forms.ComboBox()
        Me.dtp_fecha_registro = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.bt_nuevo_soporte = New System.Windows.Forms.Button()
        Me.bt_ver_archivos_asociados = New System.Windows.Forms.Button()
        Me.lb_total_soportes = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dg_items = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_elemento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unid_medida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_personal = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_seg_personal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_tercero = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgocell_restar_tiempo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fecha_fin_prog = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_fecha_inicio_prog = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(801, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(899, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(900, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/02/10"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(254, 32)
        Me.lb_titulo.Text = "Digitalizar Registro"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 452)
        '
        'bt_grabar
        '
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 512)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 16)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "Id:"
        '
        'tx_id_registro
        '
        Me.tx_id_registro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_registro.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_registro.Location = New System.Drawing.Point(93, 65)
        Me.tx_id_registro.MaxLength = 20
        Me.tx_id_registro.Name = "tx_id_registro"
        Me.tx_id_registro.ReadOnly = True
        Me.tx_id_registro.Size = New System.Drawing.Size(126, 22)
        Me.tx_id_registro.TabIndex = 126
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 16)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Registro:"
        '
        'cm_codigo_documento
        '
        Me.cm_codigo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_codigo_documento.FormattingEnabled = True
        Me.cm_codigo_documento.Location = New System.Drawing.Point(93, 91)
        Me.cm_codigo_documento.Name = "cm_codigo_documento"
        Me.cm_codigo_documento.Size = New System.Drawing.Size(126, 24)
        Me.cm_codigo_documento.TabIndex = 124
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 376)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Nota:"
        '
        'tx_turno
        '
        Me.tx_turno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_turno.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_turno.Location = New System.Drawing.Point(347, 120)
        Me.tx_turno.MaxLength = 100
        Me.tx_turno.Name = "tx_turno"
        Me.tx_turno.Size = New System.Drawing.Size(181, 22)
        Me.tx_turno.TabIndex = 121
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(295, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Turno :"
        '
        'tx_anotacion
        '
        Me.tx_anotacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_anotacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_anotacion.Location = New System.Drawing.Point(93, 376)
        Me.tx_anotacion.MaxLength = 100
        Me.tx_anotacion.Multiline = True
        Me.tx_anotacion.Name = "tx_anotacion"
        Me.tx_anotacion.Size = New System.Drawing.Size(606, 73)
        Me.tx_anotacion.TabIndex = 120
        '
        'cm_titulo_documento
        '
        Me.cm_titulo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_titulo_documento.FormattingEnabled = True
        Me.cm_titulo_documento.Location = New System.Drawing.Point(225, 92)
        Me.cm_titulo_documento.Name = "cm_titulo_documento"
        Me.cm_titulo_documento.Size = New System.Drawing.Size(474, 24)
        Me.cm_titulo_documento.TabIndex = 128
        '
        'dtp_fecha_registro
        '
        Me.dtp_fecha_registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_registro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_registro.Location = New System.Drawing.Point(790, 173)
        Me.dtp_fecha_registro.Name = "dtp_fecha_registro"
        Me.dtp_fecha_registro.Size = New System.Drawing.Size(184, 22)
        Me.dtp_fecha_registro.TabIndex = 131
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(709, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "Fecha:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.bt_nuevo_soporte)
        Me.GroupBox3.Controls.Add(Me.bt_ver_archivos_asociados)
        Me.GroupBox3.Controls.Add(Me.lb_total_soportes)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Location = New System.Drawing.Point(714, 376)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 76)
        Me.GroupBox3.TabIndex = 177
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Archivos Soporte:"
        '
        'bt_nuevo_soporte
        '
        Me.bt_nuevo_soporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nuevo_soporte.Image = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_nuevo_soporte.Location = New System.Drawing.Point(6, 19)
        Me.bt_nuevo_soporte.Name = "bt_nuevo_soporte"
        Me.bt_nuevo_soporte.Size = New System.Drawing.Size(50, 51)
        Me.bt_nuevo_soporte.TabIndex = 170
        Me.bt_nuevo_soporte.UseVisualStyleBackColor = True
        '
        'bt_ver_archivos_asociados
        '
        Me.bt_ver_archivos_asociados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ver_archivos_asociados.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_ver_archivos_asociados.Location = New System.Drawing.Point(62, 19)
        Me.bt_ver_archivos_asociados.Name = "bt_ver_archivos_asociados"
        Me.bt_ver_archivos_asociados.Size = New System.Drawing.Size(50, 51)
        Me.bt_ver_archivos_asociados.TabIndex = 171
        Me.bt_ver_archivos_asociados.UseVisualStyleBackColor = True
        '
        'lb_total_soportes
        '
        Me.lb_total_soportes.AutoSize = True
        Me.lb_total_soportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_soportes.Location = New System.Drawing.Point(201, 35)
        Me.lb_total_soportes.Name = "lb_total_soportes"
        Me.lb_total_soportes.Size = New System.Drawing.Size(29, 31)
        Me.lb_total_soportes.TabIndex = 172
        Me.lb_total_soportes.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(118, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 20)
        Me.Label19.TabIndex = 173
        Me.Label19.Text = "Total"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(118, 46)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 20)
        Me.Label18.TabIndex = 174
        Me.Label18.Text = "Soportes:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "Producto:"
        '
        'dg_items
        '
        Me.dg_items.AllowUserToAddRows = False
        Me.dg_items.AllowUserToDeleteRows = False
        Me.dg_items.AllowUserToOrderColumns = True
        Me.dg_items.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_elemento, Me.dgocell_id_item, Me.dgocell_descripcion_item, Me.dgocell_unid_medida, Me.dgocell_cantidad})
        Me.dg_items.Location = New System.Drawing.Point(93, 173)
        Me.dg_items.Name = "dg_items"
        Me.dg_items.ReadOnly = True
        Me.dg_items.Size = New System.Drawing.Size(606, 93)
        Me.dg_items.TabIndex = 182
        '
        'dgocell_id_elemento
        '
        Me.dgocell_id_elemento.HeaderText = "id_lmto"
        Me.dgocell_id_elemento.Name = "dgocell_id_elemento"
        Me.dgocell_id_elemento.ReadOnly = True
        '
        'dgocell_id_item
        '
        Me.dgocell_id_item.HeaderText = "id_item"
        Me.dgocell_id_item.Name = "dgocell_id_item"
        Me.dgocell_id_item.ReadOnly = True
        '
        'dgocell_descripcion_item
        '
        Me.dgocell_descripcion_item.HeaderText = "Item"
        Me.dgocell_descripcion_item.Name = "dgocell_descripcion_item"
        Me.dgocell_descripcion_item.ReadOnly = True
        '
        'dgocell_unid_medida
        '
        Me.dgocell_unid_medida.HeaderText = "Unid"
        Me.dgocell_unid_medida.Name = "dgocell_unid_medida"
        Me.dgocell_unid_medida.ReadOnly = True
        '
        'dgocell_cantidad
        '
        Me.dgocell_cantidad.HeaderText = "Cantidad"
        Me.dgocell_cantidad.Name = "dgocell_cantidad"
        Me.dgocell_cantidad.ReadOnly = True
        '
        'dg_personal
        '
        Me.dg_personal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_personal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_seg_personal, Me.dgocell_id_tercero, Me.dgocell_restar_tiempo})
        Me.dg_personal.Location = New System.Drawing.Point(93, 272)
        Me.dg_personal.Name = "dg_personal"
        Me.dg_personal.Size = New System.Drawing.Size(606, 98)
        Me.dg_personal.TabIndex = 183
        '
        'dgocell_id_seg_personal
        '
        Me.dgocell_id_seg_personal.HeaderText = "Column1"
        Me.dgocell_id_seg_personal.Name = "dgocell_id_seg_personal"
        Me.dgocell_id_seg_personal.ReadOnly = True
        Me.dgocell_id_seg_personal.Visible = False
        '
        'dgocell_id_tercero
        '
        Me.dgocell_id_tercero.HeaderText = "Funcionario"
        Me.dgocell_id_tercero.Name = "dgocell_id_tercero"
        Me.dgocell_id_tercero.Width = 250
        '
        'dgocell_restar_tiempo
        '
        Me.dgocell_restar_tiempo.HeaderText = "Restar (min)"
        Me.dgocell_restar_tiempo.Name = "dgocell_restar_tiempo"
        Me.dgocell_restar_tiempo.Width = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Empleado:"
        '
        'dtp_fecha_fin_prog
        '
        Me.dtp_fecha_fin_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_fin_prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_fin_prog.Location = New System.Drawing.Point(93, 145)
        Me.dtp_fecha_fin_prog.Name = "dtp_fecha_fin_prog"
        Me.dtp_fecha_fin_prog.Size = New System.Drawing.Size(184, 22)
        Me.dtp_fecha_fin_prog.TabIndex = 188
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 187
        Me.Label4.Text = "F. Fin:"
        '
        'dtp_fecha_inicio_prog
        '
        Me.dtp_fecha_inicio_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio_prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_prog.Location = New System.Drawing.Point(93, 119)
        Me.dtp_fecha_inicio_prog.Name = "dtp_fecha_inicio_prog"
        Me.dtp_fecha_inicio_prog.Size = New System.Drawing.Size(184, 22)
        Me.dtp_fecha_inicio_prog.TabIndex = 186
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 185
        Me.Label7.Text = "F. Inicio:"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(836, 132)
        Me.TextBox1.MaxLength = 100
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(101, 22)
        Me.TextBox1.TabIndex = 189
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(733, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 16)
        Me.Label8.TabIndex = 190
        Me.Label8.Text = "O. Producción :"
        '
        'fm_0500_digitalizar_registro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(986, 526)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtp_fecha_fin_prog)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtp_fecha_inicio_prog)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_personal)
        Me.Controls.Add(Me.dg_items)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dtp_fecha_registro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_titulo_documento)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_id_registro)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cm_codigo_documento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_turno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_anotacion)
        Me.Name = "fm_0500_digitalizar_registro"
        Me.Text = "Digitalizar Registro"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.tx_anotacion, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_turno, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cm_codigo_documento, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_id_registro, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.cm_titulo_documento, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_registro, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dg_items, 0)
        Me.Controls.SetChildIndex(Me.dg_personal, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_inicio_prog, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_fin_prog, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_id_registro As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cm_codigo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_turno As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_anotacion As System.Windows.Forms.TextBox
    Friend WithEvents cm_titulo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha_registro As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_nuevo_soporte As System.Windows.Forms.Button
    Friend WithEvents bt_ver_archivos_asociados As System.Windows.Forms.Button
    Friend WithEvents lb_total_soportes As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dg_items As System.Windows.Forms.DataGridView
    Friend WithEvents dgocell_id_elemento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unid_medida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg_personal As System.Windows.Forms.DataGridView
    Friend WithEvents dgocell_id_seg_personal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_tercero As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgocell_restar_tiempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_fin_prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio_prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
