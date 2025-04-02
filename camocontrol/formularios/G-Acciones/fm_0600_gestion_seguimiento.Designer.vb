<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_gestion_seguimiento
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
        Me.cm_responsable = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_anotacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_id_seguimiento = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_cumplimiento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dg_personal = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_seg_personal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_tercero = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgocell_restar_tiempo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_minutos_extras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_ochk_dominical = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgochk_r_lectura = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_fecha_lectura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgochk_r_respuesta = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_id_respuesta = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cm_tipo_seguimiento = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bt_actividades_prog = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.bt_nuevo_soporte = New System.Windows.Forms.Button()
        Me.bt_ver_archivos_asociados = New System.Windows.Forms.Button()
        Me.lb_total_soportes = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.linklabel_id_accion = New System.Windows.Forms.LinkLabel()
        Me.cm_cualificador_seguimiento = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bt_forzar_cierre = New System.Windows.Forms.Button()
        Me.tx_duracion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lb_duracion = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(808, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(906, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(907, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/04/20"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(168, 32)
        Me.lb_titulo.Text = "Seguimiento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(252, 431)
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 491)
        '
        'bt_editar
        '
        '
        'bt_generar_informe
        '
        '
        'cm_responsable
        '
        Me.cm_responsable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cm_responsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_responsable.FormattingEnabled = True
        Me.cm_responsable.Location = New System.Drawing.Point(127, 400)
        Me.cm_responsable.Name = "cm_responsable"
        Me.cm_responsable.Size = New System.Drawing.Size(312, 24)
        Me.cm_responsable.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 403)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Emisor del Seg.:"
        '
        'tx_anotacion
        '
        Me.tx_anotacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_anotacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_anotacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_anotacion.Location = New System.Drawing.Point(17, 278)
        Me.tx_anotacion.Multiline = True
        Me.tx_anotacion.Name = "tx_anotacion"
        Me.tx_anotacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_anotacion.Size = New System.Drawing.Size(962, 116)
        Me.tx_anotacion.TabIndex = 81
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 259)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 16)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Seguimiento:"
        '
        'tx_id_seguimiento
        '
        Me.tx_id_seguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_seguimiento.Location = New System.Drawing.Point(486, 70)
        Me.tx_id_seguimiento.Name = "tx_id_seguimiento"
        Me.tx_id_seguimiento.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_seguimiento.TabIndex = 132
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(434, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "id_seg:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(580, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 129
        Me.Label5.Text = "# Accion:"
        '
        'tx_cumplimiento
        '
        Me.tx_cumplimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cumplimiento.Location = New System.Drawing.Point(122, 203)
        Me.tx_cumplimiento.Name = "tx_cumplimiento"
        Me.tx_cumplimiento.Size = New System.Drawing.Size(116, 62)
        Me.tx_cumplimiento.TabIndex = 134
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 16)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "% Cumplimiento:"
        '
        'dtp_fecha_fin
        '
        Me.dtp_fecha_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_fin.Location = New System.Drawing.Point(122, 168)
        Me.dtp_fecha_fin.Name = "dtp_fecha_fin"
        Me.dtp_fecha_fin.Size = New System.Drawing.Size(184, 22)
        Me.dtp_fecha_fin.TabIndex = 138
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 174)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 16)
        Me.Label11.TabIndex = 137
        Me.Label11.Text = "Fecha Fin:"
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(122, 100)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(184, 22)
        Me.dtp_fecha_inicio.TabIndex = 136
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Fecha Inicio:"
        '
        'dg_personal
        '
        Me.dg_personal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_personal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_seg_personal, Me.dgocell_id_tercero, Me.dgocell_restar_tiempo, Me.dgocell_minutos_extras, Me.dg_ochk_dominical, Me.dgochk_r_lectura, Me.dgocell_fecha_lectura, Me.dgochk_r_respuesta, Me.dgocell_id_respuesta})
        Me.dg_personal.Location = New System.Drawing.Point(7, 16)
        Me.dg_personal.Name = "dg_personal"
        Me.dg_personal.Size = New System.Drawing.Size(649, 120)
        Me.dg_personal.TabIndex = 139
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
        'dgocell_minutos_extras
        '
        Me.dgocell_minutos_extras.HeaderText = "T. Extra (min)"
        Me.dgocell_minutos_extras.Name = "dgocell_minutos_extras"
        Me.dgocell_minutos_extras.Width = 50
        '
        'dg_ochk_dominical
        '
        Me.dg_ochk_dominical.FalseValue = ""
        Me.dg_ochk_dominical.HeaderText = "Extra Dom."
        Me.dg_ochk_dominical.Name = "dg_ochk_dominical"
        Me.dg_ochk_dominical.Width = 50
        '
        'dgochk_r_lectura
        '
        Me.dgochk_r_lectura.HeaderText = "R. Lect."
        Me.dgochk_r_lectura.Name = "dgochk_r_lectura"
        Me.dgochk_r_lectura.Width = 50
        '
        'dgocell_fecha_lectura
        '
        Me.dgocell_fecha_lectura.HeaderText = "F. Lectura"
        Me.dgocell_fecha_lectura.Name = "dgocell_fecha_lectura"
        Me.dgocell_fecha_lectura.ReadOnly = True
        '
        'dgochk_r_respuesta
        '
        Me.dgochk_r_respuesta.HeaderText = "R. Resp."
        Me.dgochk_r_respuesta.Name = "dgochk_r_respuesta"
        Me.dgochk_r_respuesta.Width = 50
        '
        'dgocell_id_respuesta
        '
        Me.dgocell_id_respuesta.HeaderText = "Seg. Respuesta"
        Me.dgocell_id_respuesta.Name = "dgocell_id_respuesta"
        Me.dgocell_id_respuesta.ReadOnly = True
        Me.dgocell_id_respuesta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_id_respuesta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_id_respuesta.Width = 70
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Duracion:"
        '
        'cm_tipo_seguimiento
        '
        Me.cm_tipo_seguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_seguimiento.FormattingEnabled = True
        Me.cm_tipo_seguimiento.Location = New System.Drawing.Point(122, 70)
        Me.cm_tipo_seguimiento.Name = "cm_tipo_seguimiento"
        Me.cm_tipo_seguimiento.Size = New System.Drawing.Size(306, 24)
        Me.cm_tipo_seguimiento.TabIndex = 144
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "Tipo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dg_personal)
        Me.GroupBox2.Location = New System.Drawing.Point(317, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(662, 142)
        Me.GroupBox2.TabIndex = 145
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Funcionario(s)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(237, 207)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 55)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "%"
        '
        'bt_actividades_prog
        '
        Me.bt_actividades_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_actividades_prog.Image = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_actividades_prog.Location = New System.Drawing.Point(154, 435)
        Me.bt_actividades_prog.Name = "bt_actividades_prog"
        Me.bt_actividades_prog.Size = New System.Drawing.Size(92, 52)
        Me.bt_actividades_prog.TabIndex = 148
        Me.bt_actividades_prog.Text = "Prog. Act."
        Me.bt_actividades_prog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_actividades_prog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_actividades_prog.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.bt_nuevo_soporte)
        Me.GroupBox3.Controls.Add(Me.bt_ver_archivos_asociados)
        Me.GroupBox3.Controls.Add(Me.lb_total_soportes)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Location = New System.Drawing.Point(733, 417)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 76)
        Me.GroupBox3.TabIndex = 176
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
        'linklabel_id_accion
        '
        Me.linklabel_id_accion.AutoSize = True
        Me.linklabel_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linklabel_id_accion.Location = New System.Drawing.Point(648, 71)
        Me.linklabel_id_accion.Name = "linklabel_id_accion"
        Me.linklabel_id_accion.Size = New System.Drawing.Size(71, 18)
        Me.linklabel_id_accion.TabIndex = 177
        Me.linklabel_id_accion.TabStop = True
        Me.linklabel_id_accion.Text = "id_accion"
        '
        'cm_cualificador_seguimiento
        '
        Me.cm_cualificador_seguimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cm_cualificador_seguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_cualificador_seguimiento.FormattingEnabled = True
        Me.cm_cualificador_seguimiento.Location = New System.Drawing.Point(412, 248)
        Me.cm_cualificador_seguimiento.Name = "cm_cualificador_seguimiento"
        Me.cm_cualificador_seguimiento.Size = New System.Drawing.Size(567, 24)
        Me.cm_cualificador_seguimiento.TabIndex = 179
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(324, 251)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 16)
        Me.Label10.TabIndex = 178
        Me.Label10.Text = "Cualificador:"
        '
        'bt_forzar_cierre
        '
        Me.bt_forzar_cierre.Image = Global.camocontrol.My.Resources.Resources.persona_caida
        Me.bt_forzar_cierre.Location = New System.Drawing.Point(17, 428)
        Me.bt_forzar_cierre.Name = "bt_forzar_cierre"
        Me.bt_forzar_cierre.Size = New System.Drawing.Size(103, 52)
        Me.bt_forzar_cierre.TabIndex = 180
        Me.bt_forzar_cierre.Text = "Forzar Cierre"
        Me.bt_forzar_cierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_forzar_cierre.UseVisualStyleBackColor = True
        '
        'tx_duracion
        '
        Me.tx_duracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_duracion.Location = New System.Drawing.Point(122, 127)
        Me.tx_duracion.Name = "tx_duracion"
        Me.tx_duracion.Size = New System.Drawing.Size(63, 22)
        Me.tx_duracion.TabIndex = 182
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(191, 130)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 16)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "Minutos:"
        '
        'lb_duracion
        '
        Me.lb_duracion.AutoSize = True
        Me.lb_duracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_duracion.Location = New System.Drawing.Point(119, 152)
        Me.lb_duracion.Name = "lb_duracion"
        Me.lb_duracion.Size = New System.Drawing.Size(47, 13)
        Me.lb_duracion.TabIndex = 184
        Me.lb_duracion.Text = "Minutos:"
        '
        'fm_0600_gestion_seguimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(993, 505)
        Me.Controls.Add(Me.lb_duracion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tx_duracion)
        Me.Controls.Add(Me.bt_forzar_cierre)
        Me.Controls.Add(Me.cm_cualificador_seguimiento)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.linklabel_id_accion)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.bt_actividades_prog)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cm_tipo_seguimiento)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtp_fecha_fin)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtp_fecha_inicio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_cumplimiento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_id_seguimiento)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cm_responsable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_anotacion)
        Me.Controls.Add(Me.Label6)
        Me.Name = "fm_0600_gestion_seguimiento"
        Me.Text = "Gestion Seguimientos"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_anotacion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_responsable, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_id_seguimiento, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_cumplimiento, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_inicio, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_fin, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_seguimiento, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.bt_actividades_prog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.linklabel_id_accion, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cm_cualificador_seguimiento, 0)
        Me.Controls.SetChildIndex(Me.bt_forzar_cierre, 0)
        Me.Controls.SetChildIndex(Me.tx_duracion, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.lb_duracion, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_responsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_anotacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tx_id_seguimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_cumplimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dg_personal As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cm_tipo_seguimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bt_actividades_prog As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_nuevo_soporte As System.Windows.Forms.Button
    Friend WithEvents bt_ver_archivos_asociados As System.Windows.Forms.Button
    Friend WithEvents lb_total_soportes As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents linklabel_id_accion As System.Windows.Forms.LinkLabel
    Friend WithEvents cm_cualificador_seguimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents bt_forzar_cierre As Button
    Friend WithEvents tx_duracion As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lb_duracion As Label
    Friend WithEvents dgocell_id_seg_personal As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_tercero As DataGridViewComboBoxColumn
    Friend WithEvents dgocell_restar_tiempo As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_minutos_extras As DataGridViewTextBoxColumn
    Friend WithEvents dg_ochk_dominical As DataGridViewCheckBoxColumn
    Friend WithEvents dgochk_r_lectura As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_fecha_lectura As DataGridViewTextBoxColumn
    Friend WithEvents dgochk_r_respuesta As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_id_respuesta As DataGridViewLinkColumn
End Class
