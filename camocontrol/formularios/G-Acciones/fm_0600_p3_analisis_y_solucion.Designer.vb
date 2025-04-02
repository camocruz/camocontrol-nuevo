<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_p3_analisis_y_solucion
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
        Me.tx_id_accion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_id_seleccionado = New System.Windows.Forms.TextBox()
        Me.bt_nuevo = New System.Windows.Forms.Button()
        Me.rb_tarea = New System.Windows.Forms.RadioButton()
        Me.rb_porque = New System.Windows.Forms.RadioButton()
        Me.dg_analisis = New System.Windows.Forms.DataGridView()
        Me.dgocell_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nivel_cumplimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_fecha_inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_fecha_fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_estructura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tx_cumplimiento = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.bt_trasladar_ramal = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_mef = New System.Windows.Forms.Button()
        Me.cm_mef = New System.Windows.Forms.ComboBox()
        Me.dtp_limite = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bt_fecha_limite = New System.Windows.Forms.Button()
        Me.bt_seguimientos = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_MEF = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_buscar = New System.Windows.Forms.TextBox()
        Me.tx_subfuente = New System.Windows.Forms.TextBox()
        Me.cm_subfuente = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg_analisis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(936, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(937, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/05/04"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(846, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(406, 32)
        Me.lb_titulo.Text = "Analisis y solucion del problema"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 512)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 476)
        '
        'tx_id_accion
        '
        Me.tx_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_accion.Location = New System.Drawing.Point(588, 13)
        Me.tx_id_accion.Name = "tx_id_accion"
        Me.tx_id_accion.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_accion.TabIndex = 85
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(520, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "# Accion:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tx_id_seleccionado)
        Me.GroupBox1.Controls.Add(Me.bt_nuevo)
        Me.GroupBox1.Controls.Add(Me.rb_tarea)
        Me.GroupBox1.Controls.Add(Me.rb_porque)
        Me.GroupBox1.Location = New System.Drawing.Point(167, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 81)
        Me.GroupBox1.TabIndex = 86
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nuevo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Hijo de:"
        '
        'tx_id_seleccionado
        '
        Me.tx_id_seleccionado.Enabled = False
        Me.tx_id_seleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_seleccionado.Location = New System.Drawing.Point(100, 13)
        Me.tx_id_seleccionado.Name = "tx_id_seleccionado"
        Me.tx_id_seleccionado.Size = New System.Drawing.Size(49, 21)
        Me.tx_id_seleccionado.TabIndex = 89
        '
        'bt_nuevo
        '
        Me.bt_nuevo.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_nuevo.Location = New System.Drawing.Point(100, 38)
        Me.bt_nuevo.Name = "bt_nuevo"
        Me.bt_nuevo.Size = New System.Drawing.Size(49, 38)
        Me.bt_nuevo.TabIndex = 88
        Me.bt_nuevo.UseVisualStyleBackColor = True
        '
        'rb_tarea
        '
        Me.rb_tarea.AutoSize = True
        Me.rb_tarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_tarea.Location = New System.Drawing.Point(18, 56)
        Me.rb_tarea.Name = "rb_tarea"
        Me.rb_tarea.Size = New System.Drawing.Size(82, 20)
        Me.rb_tarea.TabIndex = 1
        Me.rb_tarea.TabStop = True
        Me.rb_tarea.Text = "Actividad"
        Me.rb_tarea.UseVisualStyleBackColor = True
        '
        'rb_porque
        '
        Me.rb_porque.AutoSize = True
        Me.rb_porque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_porque.Location = New System.Drawing.Point(18, 33)
        Me.rb_porque.Name = "rb_porque"
        Me.rb_porque.Size = New System.Drawing.Size(70, 20)
        Me.rb_porque.TabIndex = 0
        Me.rb_porque.TabStop = True
        Me.rb_porque.Text = "Porque"
        Me.rb_porque.UseVisualStyleBackColor = True
        '
        'dg_analisis
        '
        Me.dg_analisis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_analisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_analisis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id, Me.dgocell_responsable, Me.dgocell_estado, Me.dgocell_nivel_cumplimiento, Me.dgocell_fecha_inicio, Me.dgocell_fecha_fin, Me.dgocell_descripcion, Me.dgocell_estructura})
        Me.dg_analisis.Location = New System.Drawing.Point(14, 210)
        Me.dg_analisis.Name = "dg_analisis"
        Me.dg_analisis.Size = New System.Drawing.Size(989, 260)
        Me.dg_analisis.TabIndex = 89
        '
        'dgocell_id
        '
        Me.dgocell_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_id.HeaderText = "id"
        Me.dgocell_id.Name = "dgocell_id"
        Me.dgocell_id.ReadOnly = True
        Me.dgocell_id.Width = 21
        '
        'dgocell_responsable
        '
        Me.dgocell_responsable.HeaderText = "Responsable"
        Me.dgocell_responsable.Name = "dgocell_responsable"
        Me.dgocell_responsable.ReadOnly = True
        '
        'dgocell_estado
        '
        Me.dgocell_estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_estado.HeaderText = "Estado"
        Me.dgocell_estado.Name = "dgocell_estado"
        Me.dgocell_estado.ReadOnly = True
        Me.dgocell_estado.Width = 21
        '
        'dgocell_nivel_cumplimiento
        '
        Me.dgocell_nivel_cumplimiento.HeaderText = "% Cump."
        Me.dgocell_nivel_cumplimiento.Name = "dgocell_nivel_cumplimiento"
        Me.dgocell_nivel_cumplimiento.ReadOnly = True
        Me.dgocell_nivel_cumplimiento.Width = 50
        '
        'dgocell_fecha_inicio
        '
        Me.dgocell_fecha_inicio.HeaderText = "Inicia"
        Me.dgocell_fecha_inicio.Name = "dgocell_fecha_inicio"
        Me.dgocell_fecha_inicio.ReadOnly = True
        Me.dgocell_fecha_inicio.Width = 75
        '
        'dgocell_fecha_fin
        '
        Me.dgocell_fecha_fin.HeaderText = "Fin"
        Me.dgocell_fecha_fin.Name = "dgocell_fecha_fin"
        Me.dgocell_fecha_fin.ReadOnly = True
        Me.dgocell_fecha_fin.Width = 75
        '
        'dgocell_descripcion
        '
        Me.dgocell_descripcion.HeaderText = "Descripcion"
        Me.dgocell_descripcion.Name = "dgocell_descripcion"
        Me.dgocell_descripcion.ReadOnly = True
        Me.dgocell_descripcion.Width = 500
        '
        'dgocell_estructura
        '
        Me.dgocell_estructura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_estructura.HeaderText = "Estructura"
        Me.dgocell_estructura.Name = "dgocell_estructura"
        Me.dgocell_estructura.Width = 80
        '
        'tx_cumplimiento
        '
        Me.tx_cumplimiento.Enabled = False
        Me.tx_cumplimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cumplimiento.Location = New System.Drawing.Point(887, 133)
        Me.tx_cumplimiento.Name = "tx_cumplimiento"
        Me.tx_cumplimiento.Size = New System.Drawing.Size(79, 31)
        Me.tx_cumplimiento.TabIndex = 149
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(698, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(188, 25)
        Me.Label13.TabIndex = 148
        Me.Label13.Text = "% Cumplimiento:"
        '
        'bt_trasladar_ramal
        '
        Me.bt_trasladar_ramal.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_cortar_2
        Me.bt_trasladar_ramal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_trasladar_ramal.Location = New System.Drawing.Point(331, 130)
        Me.bt_trasladar_ramal.Name = "bt_trasladar_ramal"
        Me.bt_trasladar_ramal.Size = New System.Drawing.Size(45, 34)
        Me.bt_trasladar_ramal.TabIndex = 150
        Me.bt_trasladar_ramal.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 16)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Modo o Efecto de Falla:"
        '
        'bt_mef
        '
        Me.bt_mef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_mef.Location = New System.Drawing.Point(940, 70)
        Me.bt_mef.Name = "bt_mef"
        Me.bt_mef.Size = New System.Drawing.Size(63, 48)
        Me.bt_mef.TabIndex = 154
        Me.bt_mef.Text = "CAT. MEF"
        Me.bt_mef.UseVisualStyleBackColor = True
        '
        'cm_mef
        '
        Me.cm_mef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_mef.FormattingEnabled = True
        Me.cm_mef.Location = New System.Drawing.Point(223, 99)
        Me.cm_mef.Name = "cm_mef"
        Me.cm_mef.Size = New System.Drawing.Size(711, 24)
        Me.cm_mef.TabIndex = 155
        '
        'dtp_limite
        '
        Me.dtp_limite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_limite.Location = New System.Drawing.Point(800, 176)
        Me.dtp_limite.Name = "dtp_limite"
        Me.dtp_limite.Size = New System.Drawing.Size(178, 22)
        Me.dtp_limite.TabIndex = 157
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(707, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Fecha Limite:"
        '
        'bt_fecha_limite
        '
        Me.bt_fecha_limite.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_limite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_fecha_limite.Location = New System.Drawing.Point(981, 176)
        Me.bt_fecha_limite.Name = "bt_fecha_limite"
        Me.bt_fecha_limite.Size = New System.Drawing.Size(23, 23)
        Me.bt_fecha_limite.TabIndex = 161
        Me.bt_fecha_limite.UseVisualStyleBackColor = True
        '
        'bt_seguimientos
        '
        Me.bt_seguimientos.BackgroundImage = Global.camocontrol.My.Resources.Resources.libreria
        Me.bt_seguimientos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_seguimientos.Location = New System.Drawing.Point(969, 133)
        Me.bt_seguimientos.Name = "bt_seguimientos"
        Me.bt_seguimientos.Size = New System.Drawing.Size(34, 31)
        Me.bt_seguimientos.TabIndex = 162
        Me.bt_seguimientos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 163
        Me.Label1.Text = "Origen de Falla:"
        '
        'tx_MEF
        '
        Me.tx_MEF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_MEF.Location = New System.Drawing.Point(167, 100)
        Me.tx_MEF.Name = "tx_MEF"
        Me.tx_MEF.Size = New System.Drawing.Size(50, 22)
        Me.tx_MEF.TabIndex = 167
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(435, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 16)
        Me.Label6.TabIndex = 165
        Me.Label6.Text = "Buscar # Accion:"
        '
        'tx_buscar
        '
        Me.tx_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_buscar.Location = New System.Drawing.Point(438, 161)
        Me.tx_buscar.Name = "tx_buscar"
        Me.tx_buscar.Size = New System.Drawing.Size(79, 22)
        Me.tx_buscar.TabIndex = 166
        '
        'tx_subfuente
        '
        Me.tx_subfuente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_subfuente.Location = New System.Drawing.Point(167, 73)
        Me.tx_subfuente.Name = "tx_subfuente"
        Me.tx_subfuente.Size = New System.Drawing.Size(50, 22)
        Me.tx_subfuente.TabIndex = 171
        '
        'cm_subfuente
        '
        Me.cm_subfuente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_subfuente.FormattingEnabled = True
        Me.cm_subfuente.Location = New System.Drawing.Point(223, 72)
        Me.cm_subfuente.Name = "cm_subfuente"
        Me.cm_subfuente.Size = New System.Drawing.Size(711, 24)
        Me.cm_subfuente.TabIndex = 170
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Sub Fuente:"
        '
        'fm_0600_p3_analisis_y_solucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1015, 526)
        Me.Controls.Add(Me.tx_subfuente)
        Me.Controls.Add(Me.cm_subfuente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_MEF)
        Me.Controls.Add(Me.tx_buscar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bt_seguimientos)
        Me.Controls.Add(Me.bt_fecha_limite)
        Me.Controls.Add(Me.dtp_limite)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cm_mef)
        Me.Controls.Add(Me.bt_mef)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.bt_trasladar_ramal)
        Me.Controls.Add(Me.tx_cumplimiento)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dg_analisis)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tx_id_accion)
        Me.Controls.Add(Me.Label5)
        Me.Name = "fm_0600_p3_analisis_y_solucion"
        Me.Text = "Analisis y Solucion del Problema"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_accion, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.dg_analisis, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_cumplimiento, 0)
        Me.Controls.SetChildIndex(Me.bt_trasladar_ramal, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.bt_mef, 0)
        Me.Controls.SetChildIndex(Me.cm_mef, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtp_limite, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_limite, 0)
        Me.Controls.SetChildIndex(Me.bt_seguimientos, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_buscar, 0)
        Me.Controls.SetChildIndex(Me.tx_MEF, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cm_subfuente, 0)
        Me.Controls.SetChildIndex(Me.tx_subfuente, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg_analisis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_id_accion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_tarea As System.Windows.Forms.RadioButton
    Friend WithEvents rb_porque As System.Windows.Forms.RadioButton
    Protected Friend WithEvents bt_nuevo As System.Windows.Forms.Button
    Friend WithEvents dg_analisis As System.Windows.Forms.DataGridView
    Friend WithEvents tx_cumplimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_id_seleccionado As System.Windows.Forms.TextBox
    Friend WithEvents bt_trasladar_ramal As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bt_mef As System.Windows.Forms.Button
    Friend WithEvents cm_mef As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_limite As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bt_fecha_limite As System.Windows.Forms.Button
    Friend WithEvents bt_seguimientos As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgocell_id As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_responsable As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_estado As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nivel_cumplimiento As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_fecha_inicio As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_fecha_fin As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_estructura As DataGridViewTextBoxColumn
    Friend WithEvents tx_MEF As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tx_buscar As TextBox
    Friend WithEvents tx_subfuente As TextBox
    Friend WithEvents cm_subfuente As ComboBox
    Friend WithEvents Label7 As Label
End Class
