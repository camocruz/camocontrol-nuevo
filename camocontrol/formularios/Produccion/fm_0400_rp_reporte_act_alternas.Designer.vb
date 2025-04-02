<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_rp_reporte_act_alternas
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
        Me.bt_grabar_personal = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dg_personal = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_personal_rp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_tercero = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgocell_tiempo_lab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lb_cons_irreg = New System.Windows.Forms.Label()
        Me.bt_consumos_irregulares = New System.Windows.Forms.Button()
        Me.cm_bodegas = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.bt_abrir_reporte = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tx_estado = New System.Windows.Forms.TextBox()
        Me.bt_cerrar_rp = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_horas_hombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_id_rp = New System.Windows.Forms.TextBox()
        Me.cm_actividad_alterna = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_ampliacion = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tx_clasificador = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tx_turno = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.lb_fecha.Text = "2017/09/17"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(407, 32)
        Me.lb_titulo.Text = "Reporte de Actividades Alternas"
        '
        'bt_grabar
        '
        '
        'bt_anular
        '
        '
        'bt_editar
        '
        '
        'bt_grabar_personal
        '
        Me.bt_grabar_personal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_grabar_personal.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.bt_grabar_personal.Location = New System.Drawing.Point(677, 290)
        Me.bt_grabar_personal.Name = "bt_grabar_personal"
        Me.bt_grabar_personal.Size = New System.Drawing.Size(73, 86)
        Me.bt_grabar_personal.TabIndex = 246
        Me.bt_grabar_personal.Text = "Grabar Personal"
        Me.bt_grabar_personal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bt_grabar_personal.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 16)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Personal Relacionado:"
        '
        'dg_personal
        '
        Me.dg_personal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_personal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_personal_rp, Me.dgocell_id_tercero, Me.dgocell_tiempo_lab, Me.dgocell_nota})
        Me.dg_personal.Location = New System.Drawing.Point(12, 291)
        Me.dg_personal.Name = "dg_personal"
        Me.dg_personal.Size = New System.Drawing.Size(659, 115)
        Me.dg_personal.TabIndex = 244
        '
        'dgocell_id_personal_rp
        '
        Me.dgocell_id_personal_rp.HeaderText = "Column1"
        Me.dgocell_id_personal_rp.Name = "dgocell_id_personal_rp"
        Me.dgocell_id_personal_rp.ReadOnly = True
        Me.dgocell_id_personal_rp.Visible = False
        '
        'dgocell_id_tercero
        '
        Me.dgocell_id_tercero.HeaderText = "Funcionario"
        Me.dgocell_id_tercero.Name = "dgocell_id_tercero"
        Me.dgocell_id_tercero.Width = 250
        '
        'dgocell_tiempo_lab
        '
        Me.dgocell_tiempo_lab.HeaderText = "Horas"
        Me.dgocell_tiempo_lab.Name = "dgocell_tiempo_lab"
        '
        'dgocell_nota
        '
        Me.dgocell_nota.HeaderText = "Nota"
        Me.dgocell_nota.Name = "dgocell_nota"
        Me.dgocell_nota.Width = 250
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lb_cons_irreg)
        Me.GroupBox2.Controls.Add(Me.bt_consumos_irregulares)
        Me.GroupBox2.Controls.Add(Me.cm_bodegas)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(417, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(524, 83)
        Me.GroupBox2.TabIndex = 243
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Insumos Consumidos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 228
        Me.Label5.Text = "Documento:"
        '
        'lb_cons_irreg
        '
        Me.lb_cons_irreg.AutoSize = True
        Me.lb_cons_irreg.Location = New System.Drawing.Point(71, 58)
        Me.lb_cons_irreg.Name = "lb_cons_irreg"
        Me.lb_cons_irreg.Size = New System.Drawing.Size(23, 13)
        Me.lb_cons_irreg.TabIndex = 227
        Me.lb_cons_irreg.Text = "ND"
        '
        'bt_consumos_irregulares
        '
        Me.bt_consumos_irregulares.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_consumos_irregulares.Location = New System.Drawing.Point(418, 19)
        Me.bt_consumos_irregulares.Name = "bt_consumos_irregulares"
        Me.bt_consumos_irregulares.Size = New System.Drawing.Size(100, 48)
        Me.bt_consumos_irregulares.TabIndex = 222
        Me.bt_consumos_irregulares.Text = "Consumo Irregular"
        Me.bt_consumos_irregulares.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_consumos_irregulares.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_consumos_irregulares.UseVisualStyleBackColor = True
        '
        'cm_bodegas
        '
        Me.cm_bodegas.FormattingEnabled = True
        Me.cm_bodegas.Location = New System.Drawing.Point(6, 34)
        Me.cm_bodegas.Name = "cm_bodegas"
        Me.cm_bodegas.Size = New System.Drawing.Size(412, 21)
        Me.cm_bodegas.TabIndex = 221
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 214
        Me.Label14.Text = "Bodega Consumo:"
        '
        'bt_abrir_reporte
        '
        Me.bt_abrir_reporte.Image = Global.camocontrol.My.Resources.Resources.password_32
        Me.bt_abrir_reporte.Location = New System.Drawing.Point(207, 217)
        Me.bt_abrir_reporte.Name = "bt_abrir_reporte"
        Me.bt_abrir_reporte.Size = New System.Drawing.Size(48, 44)
        Me.bt_abrir_reporte.TabIndex = 256
        Me.bt_abrir_reporte.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(9, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 16)
        Me.Label19.TabIndex = 255
        Me.Label19.Text = "Estado:"
        '
        'tx_estado
        '
        Me.tx_estado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estado.Location = New System.Drawing.Point(114, 92)
        Me.tx_estado.MaxLength = 30
        Me.tx_estado.Name = "tx_estado"
        Me.tx_estado.ReadOnly = True
        Me.tx_estado.Size = New System.Drawing.Size(138, 22)
        Me.tx_estado.TabIndex = 254
        '
        'bt_cerrar_rp
        '
        Me.bt_cerrar_rp.Image = Global.camocontrol.My.Resources.Resources.candado_32
        Me.bt_cerrar_rp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_cerrar_rp.Location = New System.Drawing.Point(114, 217)
        Me.bt_cerrar_rp.Name = "bt_cerrar_rp"
        Me.bt_cerrar_rp.Size = New System.Drawing.Size(87, 44)
        Me.bt_cerrar_rp.TabIndex = 253
        Me.bt_cerrar_rp.Text = "Cerrar Reporte"
        Me.bt_cerrar_rp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_cerrar_rp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_cerrar_rp.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 16)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "H. Hombre:"
        '
        'tx_horas_hombre
        '
        Me.tx_horas_hombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_horas_hombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_horas_hombre.Location = New System.Drawing.Point(114, 139)
        Me.tx_horas_hombre.MaxLength = 30
        Me.tx_horas_hombre.Name = "tx_horas_hombre"
        Me.tx_horas_hombre.Size = New System.Drawing.Size(138, 22)
        Me.tx_horas_hombre.TabIndex = 251
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "Fecha:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(114, 115)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(138, 22)
        Me.dtp_fecha.TabIndex = 249
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 248
        Me.Label4.Text = "# Reporte:"
        '
        'tx_id_rp
        '
        Me.tx_id_rp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_rp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_rp.Location = New System.Drawing.Point(114, 68)
        Me.tx_id_rp.MaxLength = 30
        Me.tx_id_rp.Name = "tx_id_rp"
        Me.tx_id_rp.ReadOnly = True
        Me.tx_id_rp.Size = New System.Drawing.Size(138, 22)
        Me.tx_id_rp.TabIndex = 247
        '
        'cm_actividad_alterna
        '
        Me.cm_actividad_alterna.FormattingEnabled = True
        Me.cm_actividad_alterna.Location = New System.Drawing.Point(417, 68)
        Me.cm_actividad_alterna.Name = "cm_actividad_alterna"
        Me.cm_actividad_alterna.Size = New System.Drawing.Size(524, 21)
        Me.cm_actividad_alterna.TabIndex = 258
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(291, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 257
        Me.Label2.Text = "Actividad Alterna:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(291, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 16)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Observacion Ampl.:"
        '
        'tx_ampliacion
        '
        Me.tx_ampliacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_ampliacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_ampliacion.Location = New System.Drawing.Point(417, 91)
        Me.tx_ampliacion.MaxLength = 30
        Me.tx_ampliacion.Multiline = True
        Me.tx_ampliacion.Name = "tx_ampliacion"
        Me.tx_ampliacion.Size = New System.Drawing.Size(526, 103)
        Me.tx_ampliacion.TabIndex = 259
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 189)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 16)
        Me.Label17.TabIndex = 264
        Me.Label17.Text = "Clasificador:"
        '
        'tx_clasificador
        '
        Me.tx_clasificador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_clasificador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_clasificador.Location = New System.Drawing.Point(114, 186)
        Me.tx_clasificador.MaxLength = 30
        Me.tx_clasificador.Name = "tx_clasificador"
        Me.tx_clasificador.Size = New System.Drawing.Size(138, 22)
        Me.tx_clasificador.TabIndex = 263
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 165)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 16)
        Me.Label11.TabIndex = 262
        Me.Label11.Text = "Turno:"
        '
        'tx_turno
        '
        Me.tx_turno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_turno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_turno.Location = New System.Drawing.Point(114, 163)
        Me.tx_turno.MaxLength = 30
        Me.tx_turno.Name = "tx_turno"
        Me.tx_turno.Size = New System.Drawing.Size(138, 22)
        Me.tx_turno.TabIndex = 261
        '
        'fm_0400_rp_reporte_act_alternas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(986, 488)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.tx_clasificador)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tx_turno)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_ampliacion)
        Me.Controls.Add(Me.cm_actividad_alterna)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bt_abrir_reporte)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.tx_estado)
        Me.Controls.Add(Me.bt_cerrar_rp)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tx_horas_hombre)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_id_rp)
        Me.Controls.Add(Me.bt_grabar_personal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_personal)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "fm_0400_rp_reporte_act_alternas"
        Me.Text = "Actividades Alternas"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.dg_personal, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.bt_grabar_personal, 0)
        Me.Controls.SetChildIndex(Me.tx_id_rp, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_horas_hombre, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.bt_cerrar_rp, 0)
        Me.Controls.SetChildIndex(Me.tx_estado, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.bt_abrir_reporte, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cm_actividad_alterna, 0)
        Me.Controls.SetChildIndex(Me.tx_ampliacion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_turno, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_clasificador, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bt_grabar_personal As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dg_personal As DataGridView
    Friend WithEvents dgocell_id_personal_rp As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_tercero As DataGridViewComboBoxColumn
    Friend WithEvents dgocell_tiempo_lab As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nota As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lb_cons_irreg As Label
    Friend WithEvents bt_consumos_irregulares As Button
    Friend WithEvents cm_bodegas As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents bt_abrir_reporte As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents tx_estado As TextBox
    Friend WithEvents bt_cerrar_rp As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents tx_horas_hombre As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents tx_id_rp As TextBox
    Friend WithEvents cm_actividad_alterna As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tx_ampliacion As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents tx_clasificador As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tx_turno As TextBox
End Class
