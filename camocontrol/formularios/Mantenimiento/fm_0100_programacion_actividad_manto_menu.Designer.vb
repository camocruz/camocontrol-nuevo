<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0100_programacion_actividad_manto_menu
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
        Me.bt_nueva_recurrente = New System.Windows.Forms.Button()
        Me.bt_nueva_actividad = New System.Windows.Forms.Button()
        Me.bt_actividades_simples_prog = New System.Windows.Forms.Button()
        Me.lb_estructura = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_fallas_reportadas = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bt_actividades_recurrentes = New System.Windows.Forms.Button()
        Me.rb_activas = New System.Windows.Forms.RadioButton()
        Me.rb_todas = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.bt_reporte_actividades = New System.Windows.Forms.Button()
        Me.dtp_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bt_generar_gant = New System.Windows.Forms.Button()
        Me.bt_programacion = New System.Windows.Forms.Button()
        Me.rb_actividades = New System.Windows.Forms.RadioButton()
        Me.rb_todos_seguimientos = New System.Windows.Forms.RadioButton()
        Me.bt_unificado = New System.Windows.Forms.Button()
        Me.bt_admon_path = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2014/03/06"
        '
        'lb_titulo
        '
        Me.lb_titulo.Location = New System.Drawing.Point(254, 14)
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(593, 51)
        Me.lb_titulo.Text = "Actividades de Mantenimiento"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 732)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(496, 674)
        Me.bt_salir.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        '
        'bt_nueva_recurrente
        '
        Me.bt_nueva_recurrente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nueva_recurrente.Image = Global.camocontrol.My.Resources.Resources.cargaremi
        Me.bt_nueva_recurrente.Location = New System.Drawing.Point(1000, 668)
        Me.bt_nueva_recurrente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_nueva_recurrente.Name = "bt_nueva_recurrente"
        Me.bt_nueva_recurrente.Size = New System.Drawing.Size(106, 80)
        Me.bt_nueva_recurrente.TabIndex = 105
        Me.bt_nueva_recurrente.Text = "P"
        Me.bt_nueva_recurrente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_nueva_recurrente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_nueva_recurrente.UseVisualStyleBackColor = True
        '
        'bt_nueva_actividad
        '
        Me.bt_nueva_actividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nueva_actividad.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_nueva_actividad.Location = New System.Drawing.Point(30, 351)
        Me.bt_nueva_actividad.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_nueva_actividad.Name = "bt_nueva_actividad"
        Me.bt_nueva_actividad.Size = New System.Drawing.Size(225, 80)
        Me.bt_nueva_actividad.TabIndex = 106
        Me.bt_nueva_actividad.Text = "Programar Actividad"
        Me.bt_nueva_actividad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_nueva_actividad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_nueva_actividad.UseVisualStyleBackColor = True
        '
        'bt_actividades_simples_prog
        '
        Me.bt_actividades_simples_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_actividades_simples_prog.Image = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_actividades_simples_prog.Location = New System.Drawing.Point(10, 63)
        Me.bt_actividades_simples_prog.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_actividades_simples_prog.Name = "bt_actividades_simples_prog"
        Me.bt_actividades_simples_prog.Size = New System.Drawing.Size(225, 80)
        Me.bt_actividades_simples_prog.TabIndex = 107
        Me.bt_actividades_simples_prog.Text = "Actividades Simples Prog."
        Me.bt_actividades_simples_prog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_actividades_simples_prog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_actividades_simples_prog.UseVisualStyleBackColor = True
        '
        'lb_estructura
        '
        Me.lb_estructura.AutoSize = True
        Me.lb_estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_estructura.Location = New System.Drawing.Point(207, 125)
        Me.lb_estructura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_estructura.Name = "lb_estructura"
        Me.lb_estructura.Size = New System.Drawing.Size(108, 33)
        Me.lb_estructura.TabIndex = 108
        Me.lb_estructura.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 125)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 33)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "Estructura:"
        '
        'bt_fallas_reportadas
        '
        Me.bt_fallas_reportadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_fallas_reportadas.Image = Global.camocontrol.My.Resources.Resources.icono_wifi
        Me.bt_fallas_reportadas.Location = New System.Drawing.Point(10, 145)
        Me.bt_fallas_reportadas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_fallas_reportadas.Name = "bt_fallas_reportadas"
        Me.bt_fallas_reportadas.Size = New System.Drawing.Size(225, 95)
        Me.bt_fallas_reportadas.TabIndex = 110
        Me.bt_fallas_reportadas.Text = "Planes de Accion"
        Me.bt_fallas_reportadas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_fallas_reportadas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_fallas_reportadas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bt_actividades_recurrentes)
        Me.GroupBox1.Controls.Add(Me.rb_activas)
        Me.GroupBox1.Controls.Add(Me.rb_todas)
        Me.GroupBox1.Controls.Add(Me.bt_actividades_simples_prog)
        Me.GroupBox1.Controls.Add(Me.bt_fallas_reportadas)
        Me.GroupBox1.Location = New System.Drawing.Point(278, 186)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(246, 415)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consultar"
        '
        'bt_actividades_recurrentes
        '
        Me.bt_actividades_recurrentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_actividades_recurrentes.Image = Global.camocontrol.My.Resources.Resources.cargaremi
        Me.bt_actividades_recurrentes.Location = New System.Drawing.Point(12, 242)
        Me.bt_actividades_recurrentes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_actividades_recurrentes.Name = "bt_actividades_recurrentes"
        Me.bt_actividades_recurrentes.Size = New System.Drawing.Size(225, 80)
        Me.bt_actividades_recurrentes.TabIndex = 144
        Me.bt_actividades_recurrentes.Text = "Actividades Repetitiv. Prog."
        Me.bt_actividades_recurrentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_actividades_recurrentes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_actividades_recurrentes.UseVisualStyleBackColor = True
        '
        'rb_activas
        '
        Me.rb_activas.AutoSize = True
        Me.rb_activas.Location = New System.Drawing.Point(9, 29)
        Me.rb_activas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rb_activas.Name = "rb_activas"
        Me.rb_activas.Size = New System.Drawing.Size(85, 24)
        Me.rb_activas.TabIndex = 112
        Me.rb_activas.TabStop = True
        Me.rb_activas.Text = "Activas"
        Me.rb_activas.UseVisualStyleBackColor = True
        '
        'rb_todas
        '
        Me.rb_todas.AutoSize = True
        Me.rb_todas.Location = New System.Drawing.Point(108, 29)
        Me.rb_todas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rb_todas.Name = "rb_todas"
        Me.rb_todas.Size = New System.Drawing.Size(78, 24)
        Me.rb_todas.TabIndex = 111
        Me.rb_todas.TabStop = True
        Me.rb_todas.Text = "Todas"
        Me.rb_todas.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.camocontrol.My.Resources.Resources.icono_wifi
        Me.Button2.Location = New System.Drawing.Point(298, 338)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(225, 80)
        Me.Button2.TabIndex = 110
        Me.Button2.Text = "Fallas Reportadas"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.Button3.Location = New System.Drawing.Point(298, 249)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(225, 80)
        Me.Button3.TabIndex = 107
        Me.Button3.Text = "Actividades programadas"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'bt_reporte_actividades
        '
        Me.bt_reporte_actividades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_reporte_actividades.Image = Global.camocontrol.My.Resources.Resources.icono_checklist
        Me.bt_reporte_actividades.Location = New System.Drawing.Point(30, 117)
        Me.bt_reporte_actividades.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_reporte_actividades.Name = "bt_reporte_actividades"
        Me.bt_reporte_actividades.Size = New System.Drawing.Size(225, 80)
        Me.bt_reporte_actividades.TabIndex = 113
        Me.bt_reporte_actividades.Text = "Seguimientos Reportados"
        Me.bt_reporte_actividades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_reporte_actividades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_reporte_actividades.UseVisualStyleBackColor = True
        '
        'dtp_fecha_fin
        '
        Me.dtp_fecha_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_fin.Location = New System.Drawing.Point(188, 74)
        Me.dtp_fecha_fin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_fecha_fin.Name = "dtp_fecha_fin"
        Me.dtp_fecha_fin.Size = New System.Drawing.Size(274, 30)
        Me.dtp_fecha_fin.TabIndex = 142
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(26, 83)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 25)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "Fecha Fin:"
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(188, 31)
        Me.dtp_fecha_inicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(274, 30)
        Me.dtp_fecha_inicio.TabIndex = 140
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 40)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 25)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Fecha Inicio:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_generar_gant)
        Me.GroupBox2.Controls.Add(Me.bt_programacion)
        Me.GroupBox2.Controls.Add(Me.rb_actividades)
        Me.GroupBox2.Controls.Add(Me.rb_todos_seguimientos)
        Me.GroupBox2.Controls.Add(Me.dtp_fecha_fin)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.dtp_fecha_inicio)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.bt_reporte_actividades)
        Me.GroupBox2.Location = New System.Drawing.Point(558, 186)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(525, 332)
        Me.GroupBox2.TabIndex = 143
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reportes y Seguimientos de Actividades de Mantenimiento"
        '
        'bt_generar_gant
        '
        Me.bt_generar_gant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_generar_gant.Image = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_generar_gant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_generar_gant.Location = New System.Drawing.Point(260, 206)
        Me.bt_generar_gant.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_generar_gant.Name = "bt_generar_gant"
        Me.bt_generar_gant.Size = New System.Drawing.Size(225, 80)
        Me.bt_generar_gant.TabIndex = 146
        Me.bt_generar_gant.Text = "Gen. Prog. Manto Gant"
        Me.bt_generar_gant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_generar_gant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_generar_gant.UseVisualStyleBackColor = True
        '
        'bt_programacion
        '
        Me.bt_programacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_programacion.Image = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_programacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_programacion.Location = New System.Drawing.Point(30, 206)
        Me.bt_programacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_programacion.Name = "bt_programacion"
        Me.bt_programacion.Size = New System.Drawing.Size(225, 80)
        Me.bt_programacion.TabIndex = 145
        Me.bt_programacion.Text = "Gen. Prog. Manto"
        Me.bt_programacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_programacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_programacion.UseVisualStyleBackColor = True
        '
        'rb_actividades
        '
        Me.rb_actividades.AutoSize = True
        Me.rb_actividades.Location = New System.Drawing.Point(261, 129)
        Me.rb_actividades.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rb_actividades.Name = "rb_actividades"
        Me.rb_actividades.Size = New System.Drawing.Size(198, 24)
        Me.rb_actividades.TabIndex = 144
        Me.rb_actividades.TabStop = True
        Me.rb_actividades.Text = "Actividades Realizadas"
        Me.rb_actividades.UseVisualStyleBackColor = True
        '
        'rb_todos_seguimientos
        '
        Me.rb_todos_seguimientos.AutoSize = True
        Me.rb_todos_seguimientos.Location = New System.Drawing.Point(261, 158)
        Me.rb_todos_seguimientos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rb_todos_seguimientos.Name = "rb_todos_seguimientos"
        Me.rb_todos_seguimientos.Size = New System.Drawing.Size(78, 24)
        Me.rb_todos_seguimientos.TabIndex = 143
        Me.rb_todos_seguimientos.TabStop = True
        Me.rb_todos_seguimientos.Text = "Todos"
        Me.rb_todos_seguimientos.UseVisualStyleBackColor = True
        '
        'bt_unificado
        '
        Me.bt_unificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_unificado.Image = Global.camocontrol.My.Resources.Resources.icono_agenda_electronica
        Me.bt_unificado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_unificado.Location = New System.Drawing.Point(288, 511)
        Me.bt_unificado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_unificado.Name = "bt_unificado"
        Me.bt_unificado.Size = New System.Drawing.Size(225, 80)
        Me.bt_unificado.TabIndex = 144
        Me.bt_unificado.Text = "Consolidado"
        Me.bt_unificado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_unificado.UseVisualStyleBackColor = True
        '
        'bt_admon_path
        '
        Me.bt_admon_path.Location = New System.Drawing.Point(962, 714)
        Me.bt_admon_path.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_admon_path.Name = "bt_admon_path"
        Me.bt_admon_path.Size = New System.Drawing.Size(30, 34)
        Me.bt_admon_path.TabIndex = 145
        Me.bt_admon_path.Text = "a"
        Me.bt_admon_path.UseVisualStyleBackColor = True
        '
        'fm_0100_programacion_actividad_manto_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1113, 751)
        Me.Controls.Add(Me.bt_admon_path)
        Me.Controls.Add(Me.bt_unificado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lb_estructura)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.bt_nueva_actividad)
        Me.Controls.Add(Me.bt_nueva_recurrente)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "fm_0100_programacion_actividad_manto_menu"
        Me.Text = "Gestion actividades mantenimiento"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.bt_nueva_recurrente, 0)
        Me.Controls.SetChildIndex(Me.bt_nueva_actividad, 0)
        Me.Controls.SetChildIndex(Me.Button2, 0)
        Me.Controls.SetChildIndex(Me.lb_estructura, 0)
        Me.Controls.SetChildIndex(Me.Button3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.bt_unificado, 0)
        Me.Controls.SetChildIndex(Me.bt_admon_path, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_nueva_recurrente As System.Windows.Forms.Button
    Friend WithEvents bt_nueva_actividad As System.Windows.Forms.Button
    Friend WithEvents bt_actividades_simples_prog As System.Windows.Forms.Button
    Friend WithEvents lb_estructura As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bt_fallas_reportadas As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_activas As System.Windows.Forms.RadioButton
    Friend WithEvents rb_todas As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents bt_reporte_actividades As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_actividades As System.Windows.Forms.RadioButton
    Friend WithEvents rb_todos_seguimientos As System.Windows.Forms.RadioButton
    Friend WithEvents bt_actividades_recurrentes As System.Windows.Forms.Button
    Friend WithEvents bt_programacion As System.Windows.Forms.Button
    Friend WithEvents bt_unificado As System.Windows.Forms.Button
    Friend WithEvents bt_generar_gant As Button
    Friend WithEvents bt_admon_path As Button
End Class
