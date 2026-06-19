<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_gestion_tareas
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
        Me.bt_informe = New System.Windows.Forms.Button()
        Me.cm_tipo_accion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtp_fecha_inicio_prog = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cm_estado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cm_responsable = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_id_tarea = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_duracion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_fecha_fin_prog = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cm_emisor = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cm_evaluador = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_fecha_cierre_real = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_texto_tarea = New System.Windows.Forms.TextBox()
        Me.cm_unidad_duracion = New System.Windows.Forms.ComboBox()
        Me.bt_recursos = New System.Windows.Forms.Button()
        Me.bt_seguimientos = New System.Windows.Forms.Button()
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_titulo = New System.Windows.Forms.TextBox()
        Me.tx_cumplimiento = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.bt_cambiar_infraestructura = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tx_estructura = New System.Windows.Forms.TextBox()
        Me.tx_periodo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chk_permanente = New System.Windows.Forms.CheckBox()
        Me.tx_repeticiones = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grb_tipo_tarea = New System.Windows.Forms.GroupBox()
        Me.rb_repetitiva = New System.Windows.Forms.RadioButton()
        Me.rb_simple = New System.Windows.Forms.RadioButton()
        Me.bt_actividades_hijo = New System.Windows.Forms.Button()
        Me.bt_nuevo_soporte = New System.Windows.Forms.Button()
        Me.bt_ver_archivos_asociados = New System.Windows.Forms.Button()
        Me.lb_total_soportes = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cm_fuente_accion = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lb_fecha_cierre = New System.Windows.Forms.Label()
        Me.cm_path = New System.Windows.Forms.ComboBox()
        Me.bt_anular = New System.Windows.Forms.Button()
        Me.bt_cierre_rrapido = New System.Windows.Forms.Button()
        Me.bt_solicitud_almacen = New System.Windows.Forms.Button()
        Me.bt_sol_almacen = New System.Windows.Forms.Button()
        Me.bt_seg_reporte_act = New System.Windows.Forms.Button()
        Me.bt_seg_estandar = New System.Windows.Forms.Button()
        Me.bt_CargarImagenClipboard = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_tipo_tarea.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(1112, 11)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(1113, 44)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(91, 20)
        Me.lb_fecha.Text = "2014/03/06"
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(992, 7)
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(451, 42)
        Me.lb_titulo.Text = "Definicion de una actividad"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 617)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(558, 571)
        Me.bt_salir.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        '
        'bt_informe
        '
        Me.bt_informe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_informe.Image = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_informe.Location = New System.Drawing.Point(524, 518)
        Me.bt_informe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_informe.Name = "bt_informe"
        Me.bt_informe.Size = New System.Drawing.Size(66, 46)
        Me.bt_informe.TabIndex = 124
        Me.bt_informe.UseVisualStyleBackColor = True
        '
        'cm_tipo_accion
        '
        Me.cm_tipo_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_accion.FormattingEnabled = True
        Me.cm_tipo_accion.Location = New System.Drawing.Point(800, 169)
        Me.cm_tipo_accion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cm_tipo_accion.Name = "cm_tipo_accion"
        Me.cm_tipo_accion.Size = New System.Drawing.Size(244, 28)
        Me.cm_tipo_accion.TabIndex = 121
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(656, 172)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 20)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "Tipo Accion:"
        '
        'dtp_fecha_inicio_prog
        '
        Me.dtp_fecha_inicio_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio_prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_prog.Location = New System.Drawing.Point(800, 230)
        Me.dtp_fecha_inicio_prog.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtp_fecha_inicio_prog.Name = "dtp_fecha_inicio_prog"
        Me.dtp_fecha_inicio_prog.Size = New System.Drawing.Size(244, 26)
        Me.dtp_fecha_inicio_prog.TabIndex = 119
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(656, 238)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "Fecha Inicio:"
        '
        'cm_estado
        '
        Me.cm_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_estado.FormattingEnabled = True
        Me.cm_estado.Location = New System.Drawing.Point(800, 137)
        Me.cm_estado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cm_estado.Name = "cm_estado"
        Me.cm_estado.Size = New System.Drawing.Size(244, 28)
        Me.cm_estado.TabIndex = 113
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(656, 140)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Estado:"
        '
        'cm_responsable
        '
        Me.cm_responsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_responsable.FormattingEnabled = True
        Me.cm_responsable.Location = New System.Drawing.Point(800, 354)
        Me.cm_responsable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cm_responsable.Name = "cm_responsable"
        Me.cm_responsable.Size = New System.Drawing.Size(407, 28)
        Me.cm_responsable.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(656, 357)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 20)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Quien:"
        '
        'tx_id_tarea
        '
        Me.tx_id_tarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_tarea.Location = New System.Drawing.Point(121, 139)
        Me.tx_id_tarea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tx_id_tarea.Name = "tx_id_tarea"
        Me.tx_id_tarea.Size = New System.Drawing.Size(72, 26)
        Me.tx_id_tarea.TabIndex = 128
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 142)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 20)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "Actividad #:"
        '
        'tx_duracion
        '
        Me.tx_duracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_duracion.Location = New System.Drawing.Point(800, 201)
        Me.tx_duracion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tx_duracion.Name = "tx_duracion"
        Me.tx_duracion.Size = New System.Drawing.Size(82, 26)
        Me.tx_duracion.TabIndex = 130
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(656, 204)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 20)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Duracion:"
        '
        'dtp_fecha_fin_prog
        '
        Me.dtp_fecha_fin_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_fin_prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_fin_prog.Location = New System.Drawing.Point(800, 260)
        Me.dtp_fecha_fin_prog.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtp_fecha_fin_prog.Name = "dtp_fecha_fin_prog"
        Me.dtp_fecha_fin_prog.Size = New System.Drawing.Size(244, 26)
        Me.dtp_fecha_fin_prog.TabIndex = 132
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(656, 267)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 131
        Me.Label11.Text = "Fecha Fin Prog.:"
        '
        'cm_emisor
        '
        Me.cm_emisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_emisor.FormattingEnabled = True
        Me.cm_emisor.Location = New System.Drawing.Point(800, 418)
        Me.cm_emisor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cm_emisor.Name = "cm_emisor"
        Me.cm_emisor.Size = New System.Drawing.Size(407, 28)
        Me.cm_emisor.TabIndex = 134
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(656, 421)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 20)
        Me.Label12.TabIndex = 133
        Me.Label12.Text = "Emisor:"
        '
        'cm_evaluador
        '
        Me.cm_evaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_evaluador.FormattingEnabled = True
        Me.cm_evaluador.Location = New System.Drawing.Point(800, 386)
        Me.cm_evaluador.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cm_evaluador.Name = "cm_evaluador"
        Me.cm_evaluador.Size = New System.Drawing.Size(407, 28)
        Me.cm_evaluador.TabIndex = 136
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(656, 389)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Evaluador:"
        '
        'dtp_fecha_cierre_real
        '
        Me.dtp_fecha_cierre_real.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_cierre_real.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_cierre_real.Location = New System.Drawing.Point(800, 450)
        Me.dtp_fecha_cierre_real.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtp_fecha_cierre_real.Name = "dtp_fecha_cierre_real"
        Me.dtp_fecha_cierre_real.Size = New System.Drawing.Size(244, 26)
        Me.dtp_fecha_cierre_real.TabIndex = 138
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(656, 458)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 20)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "Fecha Cierre:"
        '
        'tx_texto_tarea
        '
        Me.tx_texto_tarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_texto_tarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_texto_tarea.Location = New System.Drawing.Point(20, 318)
        Me.tx_texto_tarea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tx_texto_tarea.Multiline = True
        Me.tx_texto_tarea.Name = "tx_texto_tarea"
        Me.tx_texto_tarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_texto_tarea.Size = New System.Drawing.Size(573, 178)
        Me.tx_texto_tarea.TabIndex = 139
        '
        'cm_unidad_duracion
        '
        Me.cm_unidad_duracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_unidad_duracion.FormattingEnabled = True
        Me.cm_unidad_duracion.Location = New System.Drawing.Point(888, 199)
        Me.cm_unidad_duracion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cm_unidad_duracion.Name = "cm_unidad_duracion"
        Me.cm_unidad_duracion.Size = New System.Drawing.Size(156, 28)
        Me.cm_unidad_duracion.TabIndex = 140
        '
        'bt_recursos
        '
        Me.bt_recursos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_recursos.Image = Global.camocontrol.My.Resources.Resources.icono_herramientas_32x32
        Me.bt_recursos.Location = New System.Drawing.Point(597, 518)
        Me.bt_recursos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_recursos.Name = "bt_recursos"
        Me.bt_recursos.Size = New System.Drawing.Size(66, 46)
        Me.bt_recursos.TabIndex = 141
        Me.bt_recursos.UseVisualStyleBackColor = True
        '
        'bt_seguimientos
        '
        Me.bt_seguimientos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_seguimientos.Image = Global.camocontrol.My.Resources.Resources.libreria
        Me.bt_seguimientos.Location = New System.Drawing.Point(744, 518)
        Me.bt_seguimientos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_seguimientos.Name = "bt_seguimientos"
        Me.bt_seguimientos.Size = New System.Drawing.Size(66, 46)
        Me.bt_seguimientos.TabIndex = 142
        Me.bt_seguimientos.UseVisualStyleBackColor = True
        '
        'bt_grabar
        '
        Me.bt_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_grabar.Image = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar.Location = New System.Drawing.Point(632, 571)
        Me.bt_grabar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(66, 46)
        Me.bt_grabar.TabIndex = 143
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 260)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 20)
        Me.Label10.TabIndex = 144
        Me.Label10.Text = "Titulo:"
        '
        'tx_titulo
        '
        Me.tx_titulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_titulo.Location = New System.Drawing.Point(85, 260)
        Me.tx_titulo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tx_titulo.Multiline = True
        Me.tx_titulo.Name = "tx_titulo"
        Me.tx_titulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_titulo.Size = New System.Drawing.Size(508, 50)
        Me.tx_titulo.TabIndex = 145
        '
        'tx_cumplimiento
        '
        Me.tx_cumplimiento.Enabled = False
        Me.tx_cumplimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cumplimiento.Location = New System.Drawing.Point(940, 75)
        Me.tx_cumplimiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tx_cumplimiento.Name = "tx_cumplimiento"
        Me.tx_cumplimiento.Size = New System.Drawing.Size(104, 37)
        Me.tx_cumplimiento.TabIndex = 147
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(681, 78)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(233, 31)
        Me.Label13.TabIndex = 146
        Me.Label13.Text = "% Cumplimiento:"
        '
        'bt_cambiar_infraestructura
        '
        Me.bt_cambiar_infraestructura.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargarplano
        Me.bt_cambiar_infraestructura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cambiar_infraestructura.Location = New System.Drawing.Point(603, 170)
        Me.bt_cambiar_infraestructura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_cambiar_infraestructura.Name = "bt_cambiar_infraestructura"
        Me.bt_cambiar_infraestructura.Size = New System.Drawing.Size(28, 27)
        Me.bt_cambiar_infraestructura.TabIndex = 159
        Me.bt_cambiar_infraestructura.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 170)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 20)
        Me.Label15.TabIndex = 161
        Me.Label15.Text = "Equipo:"
        '
        'tx_estructura
        '
        Me.tx_estructura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estructura.Location = New System.Drawing.Point(85, 170)
        Me.tx_estructura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tx_estructura.Multiline = True
        Me.tx_estructura.Name = "tx_estructura"
        Me.tx_estructura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_estructura.Size = New System.Drawing.Size(508, 50)
        Me.tx_estructura.TabIndex = 160
        '
        'tx_periodo
        '
        Me.tx_periodo.Location = New System.Drawing.Point(800, 320)
        Me.tx_periodo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tx_periodo.Name = "tx_periodo"
        Me.tx_periodo.Size = New System.Drawing.Size(89, 22)
        Me.tx_periodo.TabIndex = 166
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(656, 322)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 20)
        Me.Label16.TabIndex = 165
        Me.Label16.Text = "Periodo (Dias)"
        '
        'chk_permanente
        '
        Me.chk_permanente.AutoSize = True
        Me.chk_permanente.Location = New System.Drawing.Point(900, 295)
        Me.chk_permanente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_permanente.Name = "chk_permanente"
        Me.chk_permanente.Size = New System.Drawing.Size(102, 20)
        Me.chk_permanente.TabIndex = 164
        Me.chk_permanente.Text = "Permanente"
        Me.chk_permanente.UseVisualStyleBackColor = True
        '
        'tx_repeticiones
        '
        Me.tx_repeticiones.Location = New System.Drawing.Point(800, 292)
        Me.tx_repeticiones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tx_repeticiones.Name = "tx_repeticiones"
        Me.tx_repeticiones.Size = New System.Drawing.Size(89, 22)
        Me.tx_repeticiones.TabIndex = 163
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(656, 294)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 20)
        Me.Label17.TabIndex = 162
        Me.Label17.Text = "Repeticiones:"
        '
        'grb_tipo_tarea
        '
        Me.grb_tipo_tarea.Controls.Add(Me.rb_repetitiva)
        Me.grb_tipo_tarea.Controls.Add(Me.rb_simple)
        Me.grb_tipo_tarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grb_tipo_tarea.Location = New System.Drawing.Point(18, 71)
        Me.grb_tipo_tarea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grb_tipo_tarea.Name = "grb_tipo_tarea"
        Me.grb_tipo_tarea.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grb_tipo_tarea.Size = New System.Drawing.Size(311, 55)
        Me.grb_tipo_tarea.TabIndex = 168
        Me.grb_tipo_tarea.TabStop = False
        Me.grb_tipo_tarea.Text = "Tipo Actividad"
        '
        'rb_repetitiva
        '
        Me.rb_repetitiva.AutoSize = True
        Me.rb_repetitiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_repetitiva.Location = New System.Drawing.Point(168, 21)
        Me.rb_repetitiva.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rb_repetitiva.Name = "rb_repetitiva"
        Me.rb_repetitiva.Size = New System.Drawing.Size(104, 24)
        Me.rb_repetitiva.TabIndex = 1
        Me.rb_repetitiva.Text = "Repetitiva"
        Me.rb_repetitiva.UseVisualStyleBackColor = True
        '
        'rb_simple
        '
        Me.rb_simple.AutoSize = True
        Me.rb_simple.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_simple.Location = New System.Drawing.Point(9, 21)
        Me.rb_simple.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rb_simple.Name = "rb_simple"
        Me.rb_simple.Size = New System.Drawing.Size(81, 24)
        Me.rb_simple.TabIndex = 0
        Me.rb_simple.Text = "Simple"
        Me.rb_simple.UseVisualStyleBackColor = True
        '
        'bt_actividades_hijo
        '
        Me.bt_actividades_hijo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_actividades_hijo.Image = Global.camocontrol.My.Resources.Resources.espina_pescado
        Me.bt_actividades_hijo.Location = New System.Drawing.Point(818, 518)
        Me.bt_actividades_hijo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_actividades_hijo.Name = "bt_actividades_hijo"
        Me.bt_actividades_hijo.Size = New System.Drawing.Size(66, 46)
        Me.bt_actividades_hijo.TabIndex = 169
        Me.bt_actividades_hijo.UseVisualStyleBackColor = True
        '
        'bt_nuevo_soporte
        '
        Me.bt_nuevo_soporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nuevo_soporte.Image = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_nuevo_soporte.Location = New System.Drawing.Point(8, 23)
        Me.bt_nuevo_soporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_nuevo_soporte.Name = "bt_nuevo_soporte"
        Me.bt_nuevo_soporte.Size = New System.Drawing.Size(67, 62)
        Me.bt_nuevo_soporte.TabIndex = 170
        Me.bt_nuevo_soporte.UseVisualStyleBackColor = True
        '
        'bt_ver_archivos_asociados
        '
        Me.bt_ver_archivos_asociados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ver_archivos_asociados.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_ver_archivos_asociados.Location = New System.Drawing.Point(83, 23)
        Me.bt_ver_archivos_asociados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_ver_archivos_asociados.Name = "bt_ver_archivos_asociados"
        Me.bt_ver_archivos_asociados.Size = New System.Drawing.Size(67, 62)
        Me.bt_ver_archivos_asociados.TabIndex = 171
        Me.bt_ver_archivos_asociados.UseVisualStyleBackColor = True
        '
        'lb_total_soportes
        '
        Me.lb_total_soportes.AutoSize = True
        Me.lb_total_soportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_soportes.Location = New System.Drawing.Point(268, 43)
        Me.lb_total_soportes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_total_soportes.Name = "lb_total_soportes"
        Me.lb_total_soportes.Size = New System.Drawing.Size(36, 39)
        Me.lb_total_soportes.TabIndex = 172
        Me.lb_total_soportes.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(157, 57)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 25)
        Me.Label18.TabIndex = 174
        Me.Label18.Text = "Soportes:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(157, 32)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 25)
        Me.Label19.TabIndex = 173
        Me.Label19.Text = "Total"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bt_nuevo_soporte)
        Me.GroupBox1.Controls.Add(Me.bt_ver_archivos_asociados)
        Me.GroupBox1.Controls.Add(Me.lb_total_soportes)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 503)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(331, 94)
        Me.GroupBox1.TabIndex = 175
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Archivos Soporte:"
        '
        'cm_fuente_accion
        '
        Me.cm_fuente_accion.Enabled = False
        Me.cm_fuente_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_fuente_accion.FormattingEnabled = True
        Me.cm_fuente_accion.Location = New System.Drawing.Point(85, 226)
        Me.cm_fuente_accion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cm_fuente_accion.Name = "cm_fuente_accion"
        Me.cm_fuente_accion.Size = New System.Drawing.Size(508, 28)
        Me.cm_fuente_accion.TabIndex = 177
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 229)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 20)
        Me.Label20.TabIndex = 176
        Me.Label20.Text = "Fuente:"
        '
        'lb_fecha_cierre
        '
        Me.lb_fecha_cierre.AutoSize = True
        Me.lb_fecha_cierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_cierre.Location = New System.Drawing.Point(796, 458)
        Me.lb_fecha_cierre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_fecha_cierre.Name = "lb_fecha_cierre"
        Me.lb_fecha_cierre.Size = New System.Drawing.Size(101, 20)
        Me.lb_fecha_cierre.TabIndex = 178
        Me.lb_fecha_cierre.Text = "No Definida."
        '
        'cm_path
        '
        Me.cm_path.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_path.FormattingEnabled = True
        Me.cm_path.Location = New System.Drawing.Point(203, 139)
        Me.cm_path.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cm_path.Name = "cm_path"
        Me.cm_path.Size = New System.Drawing.Size(391, 28)
        Me.cm_path.TabIndex = 181
        '
        'bt_anular
        '
        Me.bt_anular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_anular.Image = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_anular.Location = New System.Drawing.Point(359, 508)
        Me.bt_anular.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_anular.Name = "bt_anular"
        Me.bt_anular.Size = New System.Drawing.Size(64, 66)
        Me.bt_anular.TabIndex = 182
        Me.bt_anular.UseVisualStyleBackColor = True
        '
        'bt_cierre_rrapido
        '
        Me.bt_cierre_rrapido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cierre_rrapido.Image = Global.camocontrol.My.Resources.Resources.OK
        Me.bt_cierre_rrapido.Location = New System.Drawing.Point(926, 485)
        Me.bt_cierre_rrapido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_cierre_rrapido.Name = "bt_cierre_rrapido"
        Me.bt_cierre_rrapido.Size = New System.Drawing.Size(119, 46)
        Me.bt_cierre_rrapido.TabIndex = 183
        Me.bt_cierre_rrapido.Text = "Cierre Rapido"
        Me.bt_cierre_rrapido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_cierre_rrapido.UseVisualStyleBackColor = True
        '
        'bt_solicitud_almacen
        '
        Me.bt_solicitud_almacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_solicitud_almacen.Image = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_solicitud_almacen.Location = New System.Drawing.Point(670, 518)
        Me.bt_solicitud_almacen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_solicitud_almacen.Name = "bt_solicitud_almacen"
        Me.bt_solicitud_almacen.Size = New System.Drawing.Size(66, 46)
        Me.bt_solicitud_almacen.TabIndex = 184
        Me.bt_solicitud_almacen.UseVisualStyleBackColor = True
        '
        'bt_sol_almacen
        '
        Me.bt_sol_almacen.Image = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_sol_almacen.Location = New System.Drawing.Point(451, 518)
        Me.bt_sol_almacen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_sol_almacen.Name = "bt_sol_almacen"
        Me.bt_sol_almacen.Size = New System.Drawing.Size(66, 46)
        Me.bt_sol_almacen.TabIndex = 185
        Me.bt_sol_almacen.UseVisualStyleBackColor = True
        '
        'bt_seg_reporte_act
        '
        Me.bt_seg_reporte_act.Image = Global.camocontrol.My.Resources.Resources.conductor
        Me.bt_seg_reporte_act.Location = New System.Drawing.Point(744, 571)
        Me.bt_seg_reporte_act.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_seg_reporte_act.Name = "bt_seg_reporte_act"
        Me.bt_seg_reporte_act.Size = New System.Drawing.Size(66, 46)
        Me.bt_seg_reporte_act.TabIndex = 186
        Me.bt_seg_reporte_act.UseVisualStyleBackColor = True
        '
        'bt_seg_estandar
        '
        Me.bt_seg_estandar.Image = Global.camocontrol.My.Resources.Resources.icono_agenda_electronica
        Me.bt_seg_estandar.Location = New System.Drawing.Point(819, 572)
        Me.bt_seg_estandar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_seg_estandar.Name = "bt_seg_estandar"
        Me.bt_seg_estandar.Size = New System.Drawing.Size(66, 46)
        Me.bt_seg_estandar.TabIndex = 187
        Me.bt_seg_estandar.UseVisualStyleBackColor = True
        '
        'bt_CargarImagenClipboard
        '
        Me.bt_CargarImagenClipboard.Location = New System.Drawing.Point(951, 558)
        Me.bt_CargarImagenClipboard.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bt_CargarImagenClipboard.Name = "bt_CargarImagenClipboard"
        Me.bt_CargarImagenClipboard.Size = New System.Drawing.Size(94, 58)
        Me.bt_CargarImagenClipboard.TabIndex = 188
        Me.bt_CargarImagenClipboard.Text = "Pegar Imagen"
        Me.bt_CargarImagenClipboard.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(1053, 450)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(155, 166)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 189
        Me.PictureBox2.TabStop = False
        '
        'fm_0600_gestion_tareas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1218, 633)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.bt_CargarImagenClipboard)
        Me.Controls.Add(Me.bt_seg_estandar)
        Me.Controls.Add(Me.bt_seg_reporte_act)
        Me.Controls.Add(Me.bt_sol_almacen)
        Me.Controls.Add(Me.bt_solicitud_almacen)
        Me.Controls.Add(Me.bt_cierre_rrapido)
        Me.Controls.Add(Me.bt_anular)
        Me.Controls.Add(Me.cm_path)
        Me.Controls.Add(Me.lb_fecha_cierre)
        Me.Controls.Add(Me.cm_fuente_accion)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bt_actividades_hijo)
        Me.Controls.Add(Me.grb_tipo_tarea)
        Me.Controls.Add(Me.tx_periodo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.chk_permanente)
        Me.Controls.Add(Me.tx_repeticiones)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tx_estructura)
        Me.Controls.Add(Me.bt_cambiar_infraestructura)
        Me.Controls.Add(Me.tx_cumplimiento)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tx_titulo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.bt_grabar)
        Me.Controls.Add(Me.bt_seguimientos)
        Me.Controls.Add(Me.bt_recursos)
        Me.Controls.Add(Me.cm_unidad_duracion)
        Me.Controls.Add(Me.tx_texto_tarea)
        Me.Controls.Add(Me.dtp_fecha_cierre_real)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cm_evaluador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cm_emisor)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dtp_fecha_fin_prog)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tx_duracion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_id_tarea)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.bt_informe)
        Me.Controls.Add(Me.cm_tipo_accion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtp_fecha_inicio_prog)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_estado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cm_responsable)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "fm_0600_gestion_tareas"
        Me.Text = "Definicion de una Accion"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_responsable, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cm_estado, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_inicio_prog, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_accion, 0)
        Me.Controls.SetChildIndex(Me.bt_informe, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_id_tarea, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_duracion, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_fin_prog, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.cm_emisor, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cm_evaluador, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_cierre_real, 0)
        Me.Controls.SetChildIndex(Me.tx_texto_tarea, 0)
        Me.Controls.SetChildIndex(Me.cm_unidad_duracion, 0)
        Me.Controls.SetChildIndex(Me.bt_recursos, 0)
        Me.Controls.SetChildIndex(Me.bt_seguimientos, 0)
        Me.Controls.SetChildIndex(Me.bt_grabar, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.tx_titulo, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_cumplimiento, 0)
        Me.Controls.SetChildIndex(Me.bt_cambiar_infraestructura, 0)
        Me.Controls.SetChildIndex(Me.tx_estructura, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.tx_repeticiones, 0)
        Me.Controls.SetChildIndex(Me.chk_permanente, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.tx_periodo, 0)
        Me.Controls.SetChildIndex(Me.grb_tipo_tarea, 0)
        Me.Controls.SetChildIndex(Me.bt_actividades_hijo, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.cm_fuente_accion, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_cierre, 0)
        Me.Controls.SetChildIndex(Me.cm_path, 0)
        Me.Controls.SetChildIndex(Me.bt_anular, 0)
        Me.Controls.SetChildIndex(Me.bt_cierre_rrapido, 0)
        Me.Controls.SetChildIndex(Me.bt_solicitud_almacen, 0)
        Me.Controls.SetChildIndex(Me.bt_sol_almacen, 0)
        Me.Controls.SetChildIndex(Me.bt_seg_reporte_act, 0)
        Me.Controls.SetChildIndex(Me.bt_seg_estandar, 0)
        Me.Controls.SetChildIndex(Me.bt_CargarImagenClipboard, 0)
        Me.Controls.SetChildIndex(Me.PictureBox2, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_tipo_tarea.ResumeLayout(False)
        Me.grb_tipo_tarea.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_informe As System.Windows.Forms.Button
    Friend WithEvents cm_tipo_accion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio_prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cm_estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cm_responsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_id_tarea As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tx_duracion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_fin_prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cm_emisor As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cm_evaluador As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_cierre_real As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_texto_tarea As System.Windows.Forms.TextBox
    Friend WithEvents cm_unidad_duracion As System.Windows.Forms.ComboBox
    Friend WithEvents bt_recursos As System.Windows.Forms.Button
    Friend WithEvents bt_seguimientos As System.Windows.Forms.Button
    Friend WithEvents bt_grabar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tx_titulo As System.Windows.Forms.TextBox
    Friend WithEvents tx_cumplimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents bt_cambiar_infraestructura As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tx_estructura As System.Windows.Forms.TextBox
    Friend WithEvents tx_periodo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chk_permanente As System.Windows.Forms.CheckBox
    Friend WithEvents tx_repeticiones As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grb_tipo_tarea As System.Windows.Forms.GroupBox
    Friend WithEvents rb_repetitiva As System.Windows.Forms.RadioButton
    Friend WithEvents rb_simple As System.Windows.Forms.RadioButton
    Friend WithEvents bt_actividades_hijo As System.Windows.Forms.Button
    Friend WithEvents bt_nuevo_soporte As System.Windows.Forms.Button
    Friend WithEvents bt_ver_archivos_asociados As System.Windows.Forms.Button
    Friend WithEvents lb_total_soportes As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cm_fuente_accion As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lb_fecha_cierre As System.Windows.Forms.Label
    Friend WithEvents cm_path As System.Windows.Forms.ComboBox
    Friend WithEvents bt_anular As Button
    Friend WithEvents bt_cierre_rrapido As Button
    Friend WithEvents bt_solicitud_almacen As Button
    Friend WithEvents bt_sol_almacen As Button
    Friend WithEvents bt_seg_reporte_act As Button
    Friend WithEvents bt_seg_estandar As Button
    Friend WithEvents bt_CargarImagenClipboard As Button
    Friend WithEvents PictureBox2 As PictureBox
End Class
