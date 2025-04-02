<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_gestion_tarea_repetitiva
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtp_fecha_fin_prog = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cm_evaluador = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cm_unidad_duracion = New System.Windows.Forms.ComboBox()
        Me.tx_duracion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_titulo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_texto_tarea = New System.Windows.Forms.TextBox()
        Me.tx_id_accion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_periodo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chk_permanente = New System.Windows.Forms.CheckBox()
        Me.tx_repeticiones = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fecha_inicio_prog = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dg_procedimientos = New System.Windows.Forms.DataGridView()
        Me.dgocell_codigo_documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.dgocell_minimo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_maximos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_actividad_verificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_orden_verificar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_actividad_verificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_responsable_verificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_registro_verificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_frecuencia_verificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_muestreo_verificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DataGridView10 = New System.Windows.Forms.DataGridView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DataGridView9 = New System.Windows.Forms.DataGridView()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DataGridView7 = New System.Windows.Forms.DataGridView()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DataGridView8 = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DataGridView6 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dg_procedimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(774, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(872, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(873, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2013/12/08"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(367, 32)
        Me.lb_titulo.Text = "Actividad de Mantenimiento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(377, 409)
        '
        'bt_grabar
        '
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(13, 72)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(934, 331)
        Me.TabControl1.TabIndex = 61
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Thistle
        Me.TabPage1.Controls.Add(Me.dtp_fecha_fin_prog)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.cm_evaluador)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cm_unidad_duracion)
        Me.TabPage1.Controls.Add(Me.tx_duracion)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.tx_titulo)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.tx_texto_tarea)
        Me.TabPage1.Controls.Add(Me.tx_id_accion)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.tx_periodo)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.chk_permanente)
        Me.TabPage1.Controls.Add(Me.tx_repeticiones)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dtp_fecha_inicio_prog)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.dg_procedimientos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(926, 305)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        '
        'dtp_fecha_fin_prog
        '
        Me.dtp_fecha_fin_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_fin_prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_fin_prog.Location = New System.Drawing.Point(813, 3)
        Me.dtp_fecha_fin_prog.Name = "dtp_fecha_fin_prog"
        Me.dtp_fecha_fin_prog.Size = New System.Drawing.Size(102, 22)
        Me.dtp_fecha_fin_prog.TabIndex = 174
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(743, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 16)
        Me.Label13.TabIndex = 173
        Me.Label13.Text = "Fin Prog.:"
        '
        'cm_evaluador
        '
        Me.cm_evaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_evaluador.FormattingEnabled = True
        Me.cm_evaluador.Location = New System.Drawing.Point(611, 110)
        Me.cm_evaluador.Name = "cm_evaluador"
        Me.cm_evaluador.Size = New System.Drawing.Size(306, 24)
        Me.cm_evaluador.TabIndex = 172
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(532, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 16)
        Me.Label12.TabIndex = 171
        Me.Label12.Text = "Evaluador:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(540, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 16)
        Me.Label9.TabIndex = 170
        Me.Label9.Text = "Duracion:"
        '
        'cm_unidad_duracion
        '
        Me.cm_unidad_duracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_unidad_duracion.FormattingEnabled = True
        Me.cm_unidad_duracion.Location = New System.Drawing.Point(799, 81)
        Me.cm_unidad_duracion.Name = "cm_unidad_duracion"
        Me.cm_unidad_duracion.Size = New System.Drawing.Size(118, 24)
        Me.cm_unidad_duracion.TabIndex = 169
        '
        'tx_duracion
        '
        Me.tx_duracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_duracion.Location = New System.Drawing.Point(611, 82)
        Me.tx_duracion.Name = "tx_duracion"
        Me.tx_duracion.Size = New System.Drawing.Size(184, 22)
        Me.tx_duracion.TabIndex = 168
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "Descripcion:"
        '
        'tx_titulo
        '
        Me.tx_titulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_titulo.Location = New System.Drawing.Point(106, 33)
        Me.tx_titulo.Multiline = True
        Me.tx_titulo.Name = "tx_titulo"
        Me.tx_titulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_titulo.Size = New System.Drawing.Size(369, 41)
        Me.tx_titulo.TabIndex = 166
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 165
        Me.Label3.Text = "Titulo:"
        '
        'tx_texto_tarea
        '
        Me.tx_texto_tarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_texto_tarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_texto_tarea.Location = New System.Drawing.Point(106, 80)
        Me.tx_texto_tarea.Multiline = True
        Me.tx_texto_tarea.Name = "tx_texto_tarea"
        Me.tx_texto_tarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_texto_tarea.Size = New System.Drawing.Size(369, 219)
        Me.tx_texto_tarea.TabIndex = 164
        '
        'tx_id_accion
        '
        Me.tx_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_accion.Location = New System.Drawing.Point(106, 8)
        Me.tx_id_accion.Name = "tx_id_accion"
        Me.tx_id_accion.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_accion.TabIndex = 163
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Accion #:"
        '
        'tx_periodo
        '
        Me.tx_periodo.Location = New System.Drawing.Point(611, 57)
        Me.tx_periodo.Name = "tx_periodo"
        Me.tx_periodo.Size = New System.Drawing.Size(68, 20)
        Me.tx_periodo.TabIndex = 161
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(510, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 160
        Me.Label4.Text = "Periodo (Dias)"
        '
        'chk_permanente
        '
        Me.chk_permanente.AutoSize = True
        Me.chk_permanente.Location = New System.Drawing.Point(686, 34)
        Me.chk_permanente.Name = "chk_permanente"
        Me.chk_permanente.Size = New System.Drawing.Size(83, 17)
        Me.chk_permanente.TabIndex = 159
        Me.chk_permanente.Text = "Permanente"
        Me.chk_permanente.UseVisualStyleBackColor = True
        '
        'tx_repeticiones
        '
        Me.tx_repeticiones.Location = New System.Drawing.Point(611, 31)
        Me.tx_repeticiones.Name = "tx_repeticiones"
        Me.tx_repeticiones.Size = New System.Drawing.Size(68, 20)
        Me.tx_repeticiones.TabIndex = 158
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(514, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 157
        Me.Label2.Text = "Repeticiones:"
        '
        'dtp_fecha_inicio_prog
        '
        Me.dtp_fecha_inicio_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio_prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_prog.Location = New System.Drawing.Point(611, 3)
        Me.dtp_fecha_inicio_prog.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.dtp_fecha_inicio_prog.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtp_fecha_inicio_prog.Name = "dtp_fecha_inicio_prog"
        Me.dtp_fecha_inicio_prog.Size = New System.Drawing.Size(102, 22)
        Me.dtp_fecha_inicio_prog.TabIndex = 156
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(497, 6)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(108, 16)
        Me.Label21.TabIndex = 155
        Me.Label21.Text = "Inicio Operacion:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(500, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 16)
        Me.Label10.TabIndex = 149
        Me.Label10.Text = "Procedimientos:"
        '
        'dg_procedimientos
        '
        Me.dg_procedimientos.AllowUserToOrderColumns = True
        Me.dg_procedimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_procedimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_codigo_documento})
        Me.dg_procedimientos.Location = New System.Drawing.Point(611, 140)
        Me.dg_procedimientos.Name = "dg_procedimientos"
        Me.dg_procedimientos.Size = New System.Drawing.Size(304, 159)
        Me.dg_procedimientos.TabIndex = 148
        '
        'dgocell_codigo_documento
        '
        Me.dgocell_codigo_documento.HeaderText = "Codigo"
        Me.dgocell_codigo_documento.Name = "dgocell_codigo_documento"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.Thistle
        Me.TabPage5.Controls.Add(Me.TextBox4)
        Me.TabPage5.Controls.Add(Me.Label20)
        Me.TabPage5.Controls.Add(Me.Label8)
        Me.TabPage5.Controls.Add(Me.DataGridView2)
        Me.TabPage5.Controls.Add(Me.Label7)
        Me.TabPage5.Controls.Add(Me.Label5)
        Me.TabPage5.Controls.Add(Me.TextBox3)
        Me.TabPage5.Controls.Add(Me.DataGridView1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(926, 305)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "L. Chequeo"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(3, 30)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(219, 85)
        Me.TextBox4.TabIndex = 143
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(225, 11)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 16)
        Me.Label20.TabIndex = 142
        Me.Label20.Text = "Descripcion:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(670, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 16)
        Me.Label8.TabIndex = 140
        Me.Label8.Text = "Especificaciones:"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_minimo, Me.dgocell_maximos, Me.dgocell_unidad})
        Me.DataGridView2.Location = New System.Drawing.Point(674, 30)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(249, 85)
        Me.DataGridView2.TabIndex = 139
        '
        'dgocell_minimo
        '
        Me.dgocell_minimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.dgocell_minimo.HeaderText = "Minimo"
        Me.dgocell_minimo.Name = "dgocell_minimo"
        Me.dgocell_minimo.Width = 65
        '
        'dgocell_maximos
        '
        Me.dgocell_maximos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.dgocell_maximos.HeaderText = "Maximo"
        Me.dgocell_maximos.Name = "dgocell_maximos"
        Me.dgocell_maximos.Width = 68
        '
        'dgocell_unidad
        '
        Me.dgocell_unidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.dgocell_unidad.HeaderText = "Unidad"
        Me.dgocell_unidad.Name = "dgocell_unidad"
        Me.dgocell_unidad.Width = 66
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 16)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "Actividad de Verificacion:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(348, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 16)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Seleccione la actividad a consultar"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(228, 30)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(440, 85)
        Me.TextBox3.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_actividad_verificacion, Me.dgocell_orden_verificar, Me.dgocell_actividad_verificacion, Me.dgocell_responsable_verificacion, Me.dgocell_registro_verificacion, Me.dgocell_frecuencia_verificacion, Me.dgocell_muestreo_verificacion})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 143)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(920, 159)
        Me.DataGridView1.TabIndex = 0
        '
        'dgocell_id_actividad_verificacion
        '
        Me.dgocell_id_actividad_verificacion.HeaderText = "Id"
        Me.dgocell_id_actividad_verificacion.Name = "dgocell_id_actividad_verificacion"
        '
        'dgocell_orden_verificar
        '
        Me.dgocell_orden_verificar.HeaderText = "Orden"
        Me.dgocell_orden_verificar.Name = "dgocell_orden_verificar"
        '
        'dgocell_actividad_verificacion
        '
        Me.dgocell_actividad_verificacion.HeaderText = "Actividad"
        Me.dgocell_actividad_verificacion.Name = "dgocell_actividad_verificacion"
        '
        'dgocell_responsable_verificacion
        '
        Me.dgocell_responsable_verificacion.HeaderText = "Responsable"
        Me.dgocell_responsable_verificacion.Name = "dgocell_responsable_verificacion"
        '
        'dgocell_registro_verificacion
        '
        Me.dgocell_registro_verificacion.HeaderText = "Registro"
        Me.dgocell_registro_verificacion.Name = "dgocell_registro_verificacion"
        '
        'dgocell_frecuencia_verificacion
        '
        Me.dgocell_frecuencia_verificacion.HeaderText = "Frecuencia"
        Me.dgocell_frecuencia_verificacion.Name = "dgocell_frecuencia_verificacion"
        '
        'dgocell_muestreo_verificacion
        '
        Me.dgocell_muestreo_verificacion.HeaderText = "Muestreo"
        Me.dgocell_muestreo_verificacion.Name = "dgocell_muestreo_verificacion"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Thistle
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(926, 305)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Calendario"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Thistle
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.DataGridView10)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.DataGridView9)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.DataGridView7)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.DataGridView8)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(926, 305)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "R. Humanos"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 11)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 16)
        Me.Label19.TabIndex = 152
        Me.Label19.Text = "Roles:"
        '
        'DataGridView10
        '
        Me.DataGridView10.AllowUserToOrderColumns = True
        Me.DataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView10.Location = New System.Drawing.Point(11, 30)
        Me.DataGridView10.Name = "DataGridView10"
        Me.DataGridView10.Size = New System.Drawing.Size(293, 101)
        Me.DataGridView10.TabIndex = 151
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(308, 182)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 16)
        Me.Label18.TabIndex = 150
        Me.Label18.Text = "Personal Asignado:"
        '
        'DataGridView9
        '
        Me.DataGridView9.AllowUserToOrderColumns = True
        Me.DataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView9.Location = New System.Drawing.Point(311, 201)
        Me.DataGridView9.Name = "DataGridView9"
        Me.DataGridView9.Size = New System.Drawing.Size(293, 101)
        Me.DataGridView9.TabIndex = 149
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(608, 182)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(141, 16)
        Me.Label16.TabIndex = 148
        Me.Label16.Text = "Personal Competente:"
        '
        'DataGridView7
        '
        Me.DataGridView7.AllowUserToOrderColumns = True
        Me.DataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView7.Location = New System.Drawing.Point(611, 201)
        Me.DataGridView7.Name = "DataGridView7"
        Me.DataGridView7.Size = New System.Drawing.Size(293, 101)
        Me.DataGridView7.TabIndex = 147
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 182)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(172, 16)
        Me.Label17.TabIndex = 146
        Me.Label17.Text = "Competencias Requeridas:"
        '
        'DataGridView8
        '
        Me.DataGridView8.AllowUserToOrderColumns = True
        Me.DataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView8.Location = New System.Drawing.Point(11, 201)
        Me.DataGridView8.Name = "DataGridView8"
        Me.DataGridView8.Size = New System.Drawing.Size(293, 101)
        Me.DataGridView8.TabIndex = 145
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Thistle
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.DataGridView5)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.DataGridView4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(926, 305)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Insumos / Herramientas"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(466, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 16)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "Herramientas:"
        '
        'DataGridView5
        '
        Me.DataGridView5.AllowUserToOrderColumns = True
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(469, 39)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.Size = New System.Drawing.Size(437, 263)
        Me.DataGridView5.TabIndex = 143
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 16)
        Me.Label11.TabIndex = 142
        Me.Label11.Text = "Insumos:"
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToOrderColumns = True
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(14, 39)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(437, 263)
        Me.DataGridView4.TabIndex = 141
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.Thistle
        Me.TabPage6.Controls.Add(Me.Label15)
        Me.TabPage6.Controls.Add(Me.DataGridView6)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(926, 305)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Riesgo"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(243, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 16)
        Me.Label15.TabIndex = 144
        Me.Label15.Text = "Insumos:"
        '
        'DataGridView6
        '
        Me.DataGridView6.AllowUserToOrderColumns = True
        Me.DataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView6.Location = New System.Drawing.Point(246, 30)
        Me.DataGridView6.Name = "DataGridView6"
        Me.DataGridView6.Size = New System.Drawing.Size(437, 263)
        Me.DataGridView6.TabIndex = 143
        '
        'fm_0600_gestion_tarea_repetitiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(959, 483)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "fm_0600_gestion_tarea_repetitiva"
        Me.Text = "Programar Actividad"
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dg_procedimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DataGridView10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DataGridView5 As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DataGridView6 As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DataGridView10 As System.Windows.Forms.DataGridView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DataGridView9 As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DataGridView7 As System.Windows.Forms.DataGridView
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DataGridView8 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dgocell_minimo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_maximos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_actividad_verificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_orden_verificar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_actividad_verificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_responsable_verificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_registro_verificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_frecuencia_verificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_muestreo_verificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tx_id_accion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_periodo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chk_permanente As System.Windows.Forms.CheckBox
    Friend WithEvents tx_repeticiones As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio_prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dg_procedimientos As System.Windows.Forms.DataGridView
    Friend WithEvents dgocell_codigo_documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tx_titulo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tx_texto_tarea As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cm_unidad_duracion As System.Windows.Forms.ComboBox
    Friend WithEvents tx_duracion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cm_evaluador As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_fin_prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label

End Class
