<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0600_p1_definicion_accion
    Inherits camocontrol.FM_PLANTILLA_solo_salir

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cm_responsable = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_id_accion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cm_estado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cm_emisor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cm_evaluador = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_fecha_ocurrencia = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cm_tipo_accion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cm_fuente_accion = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_modo_efecto_falla = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bt_criterios = New System.Windows.Forms.Button()
        Me.bt_analisis = New System.Windows.Forms.Button()
        Me.bt_seguimientos = New System.Windows.Forms.Button()
        Me.bt_normalizacion = New System.Windows.Forms.Button()
        Me.bt_evaluacion = New System.Windows.Forms.Button()
        Me.bt_imprimir = New System.Windows.Forms.Button()
        Me.tx_cumplimiento = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtp_fecha_emision = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_fecha_cierre = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_fecha_fin_correctivo = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tx_estructura = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.bt_cambiar_infraestructura = New System.Windows.Forms.Button()
        Me.bt_fecha_ocurrencia = New System.Windows.Forms.Button()
        Me.bt_fecha_fin_correctivo = New System.Windows.Forms.Button()
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtp_fecha_limite = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lb_total_soportes = New System.Windows.Forms.Label()
        Me.bt_nuevo_soporte = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.bt_ver_archivos_asociados = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.bt_fecha_inicio_correctivo = New System.Windows.Forms.Button()
        Me.dtp_fecha_inicio_correctivo = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.bt_fecha_rep_encargado = New System.Windows.Forms.Button()
        Me.dtp_fecha_reporte_encargado = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lb_fecha_ocurrencia = New System.Windows.Forms.Label()
        Me.lb_fecha_rep_encargado = New System.Windows.Forms.Label()
        Me.lb_fecha_ini_correctivo = New System.Windows.Forms.Label()
        Me.lb_fecha_fin_correctivo = New System.Windows.Forms.Label()
        Me.lb_fecha_limite = New System.Windows.Forms.Label()
        Me.lb_fecha_cierre = New System.Windows.Forms.Label()
        Me.cm_razon_social = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cm_nit = New System.Windows.Forms.ComboBox()
        Me.gb_tercero = New System.Windows.Forms.GroupBox()
        Me.bt_activar_tercero = New System.Windows.Forms.Button()
        Me.bt_productos_rel = New System.Windows.Forms.Button()
        Me.tx_documento_origen = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tx_tiempo_efectivo_parada = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.bt_solicitud_almacen = New System.Windows.Forms.Button()
        Me.bt_recursos = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tx_titulo = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gb_tercero.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(796, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(797, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/03/04"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(706, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(416, 32)
        Me.lb_titulo.Text = "Paso 1: Definición de una Accion"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 577)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(122, 11)
        '
        'cm_responsable
        '
        Me.cm_responsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_responsable.FormattingEnabled = True
        Me.cm_responsable.Location = New System.Drawing.Point(99, 227)
        Me.cm_responsable.Name = "cm_responsable"
        Me.cm_responsable.Size = New System.Drawing.Size(350, 24)
        Me.cm_responsable.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Receptor:"
        '
        'tx_id_accion
        '
        Me.tx_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_accion.Location = New System.Drawing.Point(99, 65)
        Me.tx_id_accion.Name = "tx_id_accion"
        Me.tx_id_accion.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_accion.TabIndex = 83
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "# Accion:"
        '
        'cm_estado
        '
        Me.cm_estado.Enabled = False
        Me.cm_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_estado.FormattingEnabled = True
        Me.cm_estado.Location = New System.Drawing.Point(99, 277)
        Me.cm_estado.Name = "cm_estado"
        Me.cm_estado.Size = New System.Drawing.Size(350, 24)
        Me.cm_estado.TabIndex = 85
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 280)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Estado:"
        '
        'cm_emisor
        '
        Me.cm_emisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_emisor.FormattingEnabled = True
        Me.cm_emisor.Location = New System.Drawing.Point(99, 202)
        Me.cm_emisor.Name = "cm_emisor"
        Me.cm_emisor.Size = New System.Drawing.Size(350, 24)
        Me.cm_emisor.TabIndex = 87
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Emisor:"
        '
        'cm_evaluador
        '
        Me.cm_evaluador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_evaluador.FormattingEnabled = True
        Me.cm_evaluador.Location = New System.Drawing.Point(99, 252)
        Me.cm_evaluador.Name = "cm_evaluador"
        Me.cm_evaluador.Size = New System.Drawing.Size(350, 24)
        Me.cm_evaluador.TabIndex = 89
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 255)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 16)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Evaluador:"
        '
        'dtp_fecha_ocurrencia
        '
        Me.dtp_fecha_ocurrencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_ocurrencia.Location = New System.Drawing.Point(663, 87)
        Me.dtp_fecha_ocurrencia.Name = "dtp_fecha_ocurrencia"
        Me.dtp_fecha_ocurrencia.Size = New System.Drawing.Size(162, 22)
        Me.dtp_fecha_ocurrencia.TabIndex = 91
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(527, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 16)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Fecha Ocurrencia:"
        '
        'cm_tipo_accion
        '
        Me.cm_tipo_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_accion.FormattingEnabled = True
        Me.cm_tipo_accion.Location = New System.Drawing.Point(287, 63)
        Me.cm_tipo_accion.Name = "cm_tipo_accion"
        Me.cm_tipo_accion.Size = New System.Drawing.Size(162, 24)
        Me.cm_tipo_accion.TabIndex = 93
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(201, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 16)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Tipo Accion:"
        '
        'cm_fuente_accion
        '
        Me.cm_fuente_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_fuente_accion.FormattingEnabled = True
        Me.cm_fuente_accion.Location = New System.Drawing.Point(99, 89)
        Me.cm_fuente_accion.Name = "cm_fuente_accion"
        Me.cm_fuente_accion.Size = New System.Drawing.Size(350, 24)
        Me.cm_fuente_accion.TabIndex = 95
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "Fuente:"
        '
        'tx_modo_efecto_falla
        '
        Me.tx_modo_efecto_falla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_modo_efecto_falla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_modo_efecto_falla.Location = New System.Drawing.Point(13, 385)
        Me.tx_modo_efecto_falla.Multiline = True
        Me.tx_modo_efecto_falla.Name = "tx_modo_efecto_falla"
        Me.tx_modo_efecto_falla.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_modo_efecto_falla.Size = New System.Drawing.Size(436, 139)
        Me.tx_modo_efecto_falla.TabIndex = 98
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 368)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(283, 16)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "Modo o Efecto en el que la falla se  manifiesta:"
        '
        'bt_criterios
        '
        Me.bt_criterios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_criterios.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_criterios.Location = New System.Drawing.Point(508, 246)
        Me.bt_criterios.Name = "bt_criterios"
        Me.bt_criterios.Size = New System.Drawing.Size(212, 47)
        Me.bt_criterios.TabIndex = 101
        Me.bt_criterios.Text = "Paso 2: Definicion de criterios de eficacia."
        Me.bt_criterios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_criterios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_criterios.UseVisualStyleBackColor = True
        '
        'bt_analisis
        '
        Me.bt_analisis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_analisis.Image = Global.camocontrol.My.Resources.Resources.espina_pescado
        Me.bt_analisis.Location = New System.Drawing.Point(508, 293)
        Me.bt_analisis.Name = "bt_analisis"
        Me.bt_analisis.Size = New System.Drawing.Size(212, 47)
        Me.bt_analisis.TabIndex = 102
        Me.bt_analisis.Text = "Paso 3: Analisis y solucion del problema."
        Me.bt_analisis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_analisis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_analisis.UseVisualStyleBackColor = True
        '
        'bt_seguimientos
        '
        Me.bt_seguimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_seguimientos.Image = Global.camocontrol.My.Resources.Resources.libreria
        Me.bt_seguimientos.Location = New System.Drawing.Point(508, 340)
        Me.bt_seguimientos.Name = "bt_seguimientos"
        Me.bt_seguimientos.Size = New System.Drawing.Size(212, 47)
        Me.bt_seguimientos.TabIndex = 103
        Me.bt_seguimientos.Text = "Paso 4: Seguimiento y evolucion de la accion."
        Me.bt_seguimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_seguimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_seguimientos.UseVisualStyleBackColor = True
        '
        'bt_normalizacion
        '
        Me.bt_normalizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_normalizacion.Image = Global.camocontrol.My.Resources.Resources.icono_checklist
        Me.bt_normalizacion.Location = New System.Drawing.Point(508, 387)
        Me.bt_normalizacion.Name = "bt_normalizacion"
        Me.bt_normalizacion.Size = New System.Drawing.Size(212, 47)
        Me.bt_normalizacion.TabIndex = 104
        Me.bt_normalizacion.Text = "Paso 5: Normalizacion de los cambios."
        Me.bt_normalizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_normalizacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_normalizacion.UseVisualStyleBackColor = True
        '
        'bt_evaluacion
        '
        Me.bt_evaluacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_evaluacion.Image = Global.camocontrol.My.Resources.Resources.persona_indicadores
        Me.bt_evaluacion.Location = New System.Drawing.Point(508, 434)
        Me.bt_evaluacion.Name = "bt_evaluacion"
        Me.bt_evaluacion.Size = New System.Drawing.Size(212, 47)
        Me.bt_evaluacion.TabIndex = 105
        Me.bt_evaluacion.Text = "Paso 6: Evaluacion de la eficacia y cierre."
        Me.bt_evaluacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_evaluacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_evaluacion.UseVisualStyleBackColor = True
        '
        'bt_imprimir
        '
        Me.bt_imprimir.BackgroundImage = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_imprimir.Location = New System.Drawing.Point(67, 11)
        Me.bt_imprimir.Name = "bt_imprimir"
        Me.bt_imprimir.Size = New System.Drawing.Size(49, 38)
        Me.bt_imprimir.TabIndex = 107
        Me.bt_imprimir.UseVisualStyleBackColor = True
        '
        'tx_cumplimiento
        '
        Me.tx_cumplimiento.Enabled = False
        Me.tx_cumplimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cumplimiento.Location = New System.Drawing.Point(746, 539)
        Me.tx_cumplimiento.Name = "tx_cumplimiento"
        Me.tx_cumplimiento.Size = New System.Drawing.Size(79, 31)
        Me.tx_cumplimiento.TabIndex = 149
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(540, 542)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(188, 25)
        Me.Label13.TabIndex = 148
        Me.Label13.Text = "% Cumplimiento:"
        '
        'dtp_fecha_emision
        '
        Me.dtp_fecha_emision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_emision.Location = New System.Drawing.Point(663, 63)
        Me.dtp_fecha_emision.Name = "dtp_fecha_emision"
        Me.dtp_fecha_emision.Size = New System.Drawing.Size(162, 22)
        Me.dtp_fecha_emision.TabIndex = 151
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(527, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "Fecha Emision:"
        '
        'dtp_fecha_cierre
        '
        Me.dtp_fecha_cierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_cierre.Location = New System.Drawing.Point(663, 214)
        Me.dtp_fecha_cierre.Name = "dtp_fecha_cierre"
        Me.dtp_fecha_cierre.Size = New System.Drawing.Size(162, 22)
        Me.dtp_fecha_cierre.TabIndex = 155
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(527, 220)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 154
        Me.Label11.Text = "Fecha Cierre:"
        '
        'dtp_fecha_fin_correctivo
        '
        Me.dtp_fecha_fin_correctivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_fin_correctivo.Location = New System.Drawing.Point(663, 164)
        Me.dtp_fecha_fin_correctivo.Name = "dtp_fecha_fin_correctivo"
        Me.dtp_fecha_fin_correctivo.Size = New System.Drawing.Size(162, 22)
        Me.dtp_fecha_fin_correctivo.TabIndex = 153
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(527, 170)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 16)
        Me.Label12.TabIndex = 152
        Me.Label12.Text = "Fecha Fin Correctivo:"
        '
        'tx_estructura
        '
        Me.tx_estructura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estructura.Location = New System.Drawing.Point(99, 302)
        Me.tx_estructura.Multiline = True
        Me.tx_estructura.Name = "tx_estructura"
        Me.tx_estructura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_estructura.Size = New System.Drawing.Size(350, 38)
        Me.tx_estructura.TabIndex = 156
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 302)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 16)
        Me.Label14.TabIndex = 157
        Me.Label14.Text = "Equipo:"
        '
        'bt_cambiar_infraestructura
        '
        Me.bt_cambiar_infraestructura.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargarplano
        Me.bt_cambiar_infraestructura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cambiar_infraestructura.Location = New System.Drawing.Point(455, 305)
        Me.bt_cambiar_infraestructura.Name = "bt_cambiar_infraestructura"
        Me.bt_cambiar_infraestructura.Size = New System.Drawing.Size(21, 22)
        Me.bt_cambiar_infraestructura.TabIndex = 158
        Me.bt_cambiar_infraestructura.UseVisualStyleBackColor = True
        '
        'bt_fecha_ocurrencia
        '
        Me.bt_fecha_ocurrencia.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_ocurrencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_fecha_ocurrencia.Location = New System.Drawing.Point(503, 87)
        Me.bt_fecha_ocurrencia.Name = "bt_fecha_ocurrencia"
        Me.bt_fecha_ocurrencia.Size = New System.Drawing.Size(23, 23)
        Me.bt_fecha_ocurrencia.TabIndex = 159
        Me.bt_fecha_ocurrencia.UseVisualStyleBackColor = True
        '
        'bt_fecha_fin_correctivo
        '
        Me.bt_fecha_fin_correctivo.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_fin_correctivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_fecha_fin_correctivo.Location = New System.Drawing.Point(503, 165)
        Me.bt_fecha_fin_correctivo.Name = "bt_fecha_fin_correctivo"
        Me.bt_fecha_fin_correctivo.Size = New System.Drawing.Size(23, 23)
        Me.bt_fecha_fin_correctivo.TabIndex = 160
        Me.bt_fecha_fin_correctivo.UseVisualStyleBackColor = True
        '
        'bt_grabar
        '
        Me.bt_grabar.BackgroundImage = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_grabar.Location = New System.Drawing.Point(12, 11)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(49, 38)
        Me.bt_grabar.TabIndex = 161
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bt_grabar)
        Me.GroupBox1.Controls.Add(Me.bt_imprimir)
        Me.GroupBox1.Controls.Add(Me.bt_salir)
        Me.GroupBox1.Location = New System.Drawing.Point(313, 527)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 53)
        Me.GroupBox1.TabIndex = 162
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_imprimir, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_grabar, 0)
        '
        'dtp_fecha_limite
        '
        Me.dtp_fecha_limite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_limite.Location = New System.Drawing.Point(663, 189)
        Me.dtp_fecha_limite.Name = "dtp_fecha_limite"
        Me.dtp_fecha_limite.Size = New System.Drawing.Size(162, 22)
        Me.dtp_fecha_limite.TabIndex = 166
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(527, 195)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 16)
        Me.Label16.TabIndex = 165
        Me.Label16.Text = "Fecha Limite:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lb_total_soportes)
        Me.GroupBox2.Controls.Add(Me.bt_nuevo_soporte)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.bt_ver_archivos_asociados)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(726, 243)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(99, 228)
        Me.GroupBox2.TabIndex = 167
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Soportes"
        '
        'lb_total_soportes
        '
        Me.lb_total_soportes.AutoSize = True
        Me.lb_total_soportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_soportes.Location = New System.Drawing.Point(6, 184)
        Me.lb_total_soportes.Name = "lb_total_soportes"
        Me.lb_total_soportes.Size = New System.Drawing.Size(29, 31)
        Me.lb_total_soportes.TabIndex = 88
        Me.lb_total_soportes.Text = "0"
        '
        'bt_nuevo_soporte
        '
        Me.bt_nuevo_soporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nuevo_soporte.Image = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_nuevo_soporte.Location = New System.Drawing.Point(23, 28)
        Me.bt_nuevo_soporte.Name = "bt_nuevo_soporte"
        Me.bt_nuevo_soporte.Size = New System.Drawing.Size(50, 51)
        Me.bt_nuevo_soporte.TabIndex = 82
        Me.bt_nuevo_soporte.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 164)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 20)
        Me.Label15.TabIndex = 87
        Me.Label15.Text = "Soportes:"
        '
        'bt_ver_archivos_asociados
        '
        Me.bt_ver_archivos_asociados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ver_archivos_asociados.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_ver_archivos_asociados.Location = New System.Drawing.Point(23, 85)
        Me.bt_ver_archivos_asociados.Name = "bt_ver_archivos_asociados"
        Me.bt_ver_archivos_asociados.Size = New System.Drawing.Size(50, 51)
        Me.bt_ver_archivos_asociados.TabIndex = 84
        Me.bt_ver_archivos_asociados.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 144)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 20)
        Me.Label17.TabIndex = 86
        Me.Label17.Text = "Total"
        '
        'bt_fecha_inicio_correctivo
        '
        Me.bt_fecha_inicio_correctivo.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_inicio_correctivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_fecha_inicio_correctivo.Location = New System.Drawing.Point(503, 138)
        Me.bt_fecha_inicio_correctivo.Name = "bt_fecha_inicio_correctivo"
        Me.bt_fecha_inicio_correctivo.Size = New System.Drawing.Size(23, 23)
        Me.bt_fecha_inicio_correctivo.TabIndex = 170
        Me.bt_fecha_inicio_correctivo.UseVisualStyleBackColor = True
        '
        'dtp_fecha_inicio_correctivo
        '
        Me.dtp_fecha_inicio_correctivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio_correctivo.Location = New System.Drawing.Point(663, 138)
        Me.dtp_fecha_inicio_correctivo.Name = "dtp_fecha_inicio_correctivo"
        Me.dtp_fecha_inicio_correctivo.Size = New System.Drawing.Size(162, 22)
        Me.dtp_fecha_inicio_correctivo.TabIndex = 169
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(527, 144)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(129, 16)
        Me.Label18.TabIndex = 168
        Me.Label18.Text = "Fecha Ini Correctivo:"
        '
        'bt_fecha_rep_encargado
        '
        Me.bt_fecha_rep_encargado.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_rep_encargado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_fecha_rep_encargado.Location = New System.Drawing.Point(503, 112)
        Me.bt_fecha_rep_encargado.Name = "bt_fecha_rep_encargado"
        Me.bt_fecha_rep_encargado.Size = New System.Drawing.Size(23, 23)
        Me.bt_fecha_rep_encargado.TabIndex = 173
        Me.bt_fecha_rep_encargado.UseVisualStyleBackColor = True
        '
        'dtp_fecha_reporte_encargado
        '
        Me.dtp_fecha_reporte_encargado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_reporte_encargado.Location = New System.Drawing.Point(663, 112)
        Me.dtp_fecha_reporte_encargado.Name = "dtp_fecha_reporte_encargado"
        Me.dtp_fecha_reporte_encargado.Size = New System.Drawing.Size(162, 22)
        Me.dtp_fecha_reporte_encargado.TabIndex = 172
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(527, 118)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(127, 16)
        Me.Label19.TabIndex = 171
        Me.Label19.Text = "Fecha Reporte Enc:"
        '
        'lb_fecha_ocurrencia
        '
        Me.lb_fecha_ocurrencia.AutoSize = True
        Me.lb_fecha_ocurrencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_ocurrencia.Location = New System.Drawing.Point(663, 92)
        Me.lb_fecha_ocurrencia.Name = "lb_fecha_ocurrencia"
        Me.lb_fecha_ocurrencia.Size = New System.Drawing.Size(82, 16)
        Me.lb_fecha_ocurrencia.TabIndex = 174
        Me.lb_fecha_ocurrencia.Text = "No Definida."
        '
        'lb_fecha_rep_encargado
        '
        Me.lb_fecha_rep_encargado.AutoSize = True
        Me.lb_fecha_rep_encargado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_rep_encargado.Location = New System.Drawing.Point(663, 118)
        Me.lb_fecha_rep_encargado.Name = "lb_fecha_rep_encargado"
        Me.lb_fecha_rep_encargado.Size = New System.Drawing.Size(82, 16)
        Me.lb_fecha_rep_encargado.TabIndex = 175
        Me.lb_fecha_rep_encargado.Text = "No Definida."
        '
        'lb_fecha_ini_correctivo
        '
        Me.lb_fecha_ini_correctivo.AutoSize = True
        Me.lb_fecha_ini_correctivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_ini_correctivo.Location = New System.Drawing.Point(663, 144)
        Me.lb_fecha_ini_correctivo.Name = "lb_fecha_ini_correctivo"
        Me.lb_fecha_ini_correctivo.Size = New System.Drawing.Size(82, 16)
        Me.lb_fecha_ini_correctivo.TabIndex = 176
        Me.lb_fecha_ini_correctivo.Text = "No Definida."
        '
        'lb_fecha_fin_correctivo
        '
        Me.lb_fecha_fin_correctivo.AutoSize = True
        Me.lb_fecha_fin_correctivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_fin_correctivo.Location = New System.Drawing.Point(663, 170)
        Me.lb_fecha_fin_correctivo.Name = "lb_fecha_fin_correctivo"
        Me.lb_fecha_fin_correctivo.Size = New System.Drawing.Size(82, 16)
        Me.lb_fecha_fin_correctivo.TabIndex = 177
        Me.lb_fecha_fin_correctivo.Text = "No Definida."
        '
        'lb_fecha_limite
        '
        Me.lb_fecha_limite.AutoSize = True
        Me.lb_fecha_limite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_limite.Location = New System.Drawing.Point(663, 196)
        Me.lb_fecha_limite.Name = "lb_fecha_limite"
        Me.lb_fecha_limite.Size = New System.Drawing.Size(82, 16)
        Me.lb_fecha_limite.TabIndex = 178
        Me.lb_fecha_limite.Text = "No Definida."
        '
        'lb_fecha_cierre
        '
        Me.lb_fecha_cierre.AutoSize = True
        Me.lb_fecha_cierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_cierre.Location = New System.Drawing.Point(663, 220)
        Me.lb_fecha_cierre.Name = "lb_fecha_cierre"
        Me.lb_fecha_cierre.Size = New System.Drawing.Size(82, 16)
        Me.lb_fecha_cierre.TabIndex = 179
        Me.lb_fecha_cierre.Text = "No Definida."
        '
        'cm_razon_social
        '
        Me.cm_razon_social.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_razon_social.FormattingEnabled = True
        Me.cm_razon_social.Location = New System.Drawing.Point(83, 35)
        Me.cm_razon_social.Name = "cm_razon_social"
        Me.cm_razon_social.Size = New System.Drawing.Size(350, 24)
        Me.cm_razon_social.TabIndex = 287
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(146, 18)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(124, 16)
        Me.Label32.TabIndex = 288
        Me.Label32.Text = "Identificación / NIT :"
        '
        'cm_nit
        '
        Me.cm_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_nit.FormattingEnabled = True
        Me.cm_nit.Location = New System.Drawing.Point(271, 10)
        Me.cm_nit.Name = "cm_nit"
        Me.cm_nit.Size = New System.Drawing.Size(162, 24)
        Me.cm_nit.TabIndex = 289
        '
        'gb_tercero
        '
        Me.gb_tercero.Controls.Add(Me.cm_nit)
        Me.gb_tercero.Controls.Add(Me.Label32)
        Me.gb_tercero.Controls.Add(Me.cm_razon_social)
        Me.gb_tercero.Location = New System.Drawing.Point(16, 140)
        Me.gb_tercero.Name = "gb_tercero"
        Me.gb_tercero.Size = New System.Drawing.Size(443, 62)
        Me.gb_tercero.TabIndex = 290
        Me.gb_tercero.TabStop = False
        Me.gb_tercero.Text = "Tercero Relacionado"
        '
        'bt_activar_tercero
        '
        Me.bt_activar_tercero.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargarplano
        Me.bt_activar_tercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_activar_tercero.Location = New System.Drawing.Point(463, 152)
        Me.bt_activar_tercero.Name = "bt_activar_tercero"
        Me.bt_activar_tercero.Size = New System.Drawing.Size(21, 22)
        Me.bt_activar_tercero.TabIndex = 291
        Me.bt_activar_tercero.UseVisualStyleBackColor = True
        '
        'bt_productos_rel
        '
        Me.bt_productos_rel.Image = Global.camocontrol.My.Resources.Resources.grupoproducto
        Me.bt_productos_rel.Location = New System.Drawing.Point(508, 486)
        Me.bt_productos_rel.Name = "bt_productos_rel"
        Me.bt_productos_rel.Size = New System.Drawing.Size(61, 51)
        Me.bt_productos_rel.TabIndex = 292
        Me.bt_productos_rel.Text = "Items Rel"
        Me.bt_productos_rel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bt_productos_rel.UseVisualStyleBackColor = True
        '
        'tx_documento_origen
        '
        Me.tx_documento_origen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_documento_origen.Location = New System.Drawing.Point(99, 115)
        Me.tx_documento_origen.Name = "tx_documento_origen"
        Me.tx_documento_origen.Size = New System.Drawing.Size(123, 22)
        Me.tx_documento_origen.TabIndex = 294
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 121)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 16)
        Me.Label20.TabIndex = 293
        Me.Label20.Text = "Doc Origen:"
        '
        'tx_tiempo_efectivo_parada
        '
        Me.tx_tiempo_efectivo_parada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tiempo_efectivo_parada.Location = New System.Drawing.Point(326, 115)
        Me.tx_tiempo_efectivo_parada.Name = "tx_tiempo_efectivo_parada"
        Me.tx_tiempo_efectivo_parada.Size = New System.Drawing.Size(123, 22)
        Me.tx_tiempo_efectivo_parada.TabIndex = 296
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(240, 121)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 16)
        Me.Label21.TabIndex = 295
        Me.Label21.Text = "T. Efec. Par:"
        '
        'bt_solicitud_almacen
        '
        Me.bt_solicitud_almacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_solicitud_almacen.Image = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_solicitud_almacen.Location = New System.Drawing.Point(671, 486)
        Me.bt_solicitud_almacen.Name = "bt_solicitud_almacen"
        Me.bt_solicitud_almacen.Size = New System.Drawing.Size(49, 38)
        Me.bt_solicitud_almacen.TabIndex = 298
        Me.bt_solicitud_almacen.UseVisualStyleBackColor = True
        '
        'bt_recursos
        '
        Me.bt_recursos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_recursos.Image = Global.camocontrol.My.Resources.Resources.icono_herramientas_32x32
        Me.bt_recursos.Location = New System.Drawing.Point(616, 486)
        Me.bt_recursos.Name = "bt_recursos"
        Me.bt_recursos.Size = New System.Drawing.Size(49, 38)
        Me.bt_recursos.TabIndex = 297
        Me.bt_recursos.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 343)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(44, 16)
        Me.Label22.TabIndex = 299
        Me.Label22.Text = "Titulo:"
        '
        'tx_titulo
        '
        Me.tx_titulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_titulo.Location = New System.Drawing.Point(99, 343)
        Me.tx_titulo.MaxLength = 100
        Me.tx_titulo.Name = "tx_titulo"
        Me.tx_titulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_titulo.Size = New System.Drawing.Size(350, 22)
        Me.tx_titulo.TabIndex = 300
        '
        'fm_0600_p1_definicion_accion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(875, 591)
        Me.Controls.Add(Me.tx_titulo)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.bt_solicitud_almacen)
        Me.Controls.Add(Me.bt_recursos)
        Me.Controls.Add(Me.tx_tiempo_efectivo_parada)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.tx_documento_origen)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.bt_productos_rel)
        Me.Controls.Add(Me.bt_activar_tercero)
        Me.Controls.Add(Me.gb_tercero)
        Me.Controls.Add(Me.lb_fecha_cierre)
        Me.Controls.Add(Me.lb_fecha_limite)
        Me.Controls.Add(Me.lb_fecha_fin_correctivo)
        Me.Controls.Add(Me.lb_fecha_ini_correctivo)
        Me.Controls.Add(Me.lb_fecha_rep_encargado)
        Me.Controls.Add(Me.lb_fecha_ocurrencia)
        Me.Controls.Add(Me.bt_fecha_rep_encargado)
        Me.Controls.Add(Me.dtp_fecha_reporte_encargado)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.bt_fecha_inicio_correctivo)
        Me.Controls.Add(Me.dtp_fecha_inicio_correctivo)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtp_fecha_limite)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bt_fecha_fin_correctivo)
        Me.Controls.Add(Me.bt_fecha_ocurrencia)
        Me.Controls.Add(Me.bt_cambiar_infraestructura)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tx_estructura)
        Me.Controls.Add(Me.dtp_fecha_cierre)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtp_fecha_fin_correctivo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dtp_fecha_emision)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_cumplimiento)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.bt_evaluacion)
        Me.Controls.Add(Me.bt_normalizacion)
        Me.Controls.Add(Me.bt_seguimientos)
        Me.Controls.Add(Me.bt_analisis)
        Me.Controls.Add(Me.bt_criterios)
        Me.Controls.Add(Me.tx_modo_efecto_falla)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cm_fuente_accion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cm_tipo_accion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtp_fecha_ocurrencia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_evaluador)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cm_emisor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cm_estado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_id_accion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cm_responsable)
        Me.Controls.Add(Me.Label1)
        Me.Name = "fm_0600_p1_definicion_accion"
        Me.Text = "Definicion de una accion."
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_responsable, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_accion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cm_estado, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cm_emisor, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cm_evaluador, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_ocurrencia, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_accion, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.cm_fuente_accion, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.tx_modo_efecto_falla, 0)
        Me.Controls.SetChildIndex(Me.bt_criterios, 0)
        Me.Controls.SetChildIndex(Me.bt_analisis, 0)
        Me.Controls.SetChildIndex(Me.bt_seguimientos, 0)
        Me.Controls.SetChildIndex(Me.bt_normalizacion, 0)
        Me.Controls.SetChildIndex(Me.bt_evaluacion, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_cumplimiento, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_emision, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_fin_correctivo, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_cierre, 0)
        Me.Controls.SetChildIndex(Me.tx_estructura, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.bt_cambiar_infraestructura, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_ocurrencia, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_fin_correctivo, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_limite, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_inicio_correctivo, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_inicio_correctivo, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_reporte_encargado, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_rep_encargado, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_ocurrencia, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_rep_encargado, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_ini_correctivo, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_fin_correctivo, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_limite, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_cierre, 0)
        Me.Controls.SetChildIndex(Me.gb_tercero, 0)
        Me.Controls.SetChildIndex(Me.bt_activar_tercero, 0)
        Me.Controls.SetChildIndex(Me.bt_productos_rel, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.tx_documento_origen, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.tx_tiempo_efectivo_parada, 0)
        Me.Controls.SetChildIndex(Me.bt_recursos, 0)
        Me.Controls.SetChildIndex(Me.bt_solicitud_almacen, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.tx_titulo, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gb_tercero.ResumeLayout(False)
        Me.gb_tercero.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_responsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_id_accion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cm_estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cm_emisor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cm_evaluador As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_ocurrencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cm_tipo_accion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cm_fuente_accion As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tx_modo_efecto_falla As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents bt_criterios As System.Windows.Forms.Button
    Friend WithEvents bt_analisis As System.Windows.Forms.Button
    Friend WithEvents bt_seguimientos As System.Windows.Forms.Button
    Friend WithEvents bt_normalizacion As System.Windows.Forms.Button
    Friend WithEvents bt_evaluacion As System.Windows.Forms.Button
    Friend WithEvents bt_imprimir As System.Windows.Forms.Button
    Friend WithEvents tx_cumplimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_cierre As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_fin_correctivo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tx_estructura As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents bt_cambiar_infraestructura As System.Windows.Forms.Button
    Friend WithEvents bt_fecha_ocurrencia As System.Windows.Forms.Button
    Friend WithEvents bt_fecha_fin_correctivo As System.Windows.Forms.Button
    Protected Friend WithEvents bt_grabar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_fecha_limite As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lb_total_soportes As System.Windows.Forms.Label
    Friend WithEvents bt_nuevo_soporte As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents bt_ver_archivos_asociados As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents bt_fecha_inicio_correctivo As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_inicio_correctivo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents bt_fecha_rep_encargado As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_reporte_encargado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lb_fecha_ocurrencia As System.Windows.Forms.Label
    Friend WithEvents lb_fecha_rep_encargado As System.Windows.Forms.Label
    Friend WithEvents lb_fecha_ini_correctivo As System.Windows.Forms.Label
    Friend WithEvents lb_fecha_fin_correctivo As System.Windows.Forms.Label
    Friend WithEvents lb_fecha_limite As System.Windows.Forms.Label
    Friend WithEvents lb_fecha_cierre As System.Windows.Forms.Label
    Friend WithEvents cm_razon_social As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cm_nit As System.Windows.Forms.ComboBox
    Friend WithEvents gb_tercero As System.Windows.Forms.GroupBox
    Friend WithEvents bt_activar_tercero As System.Windows.Forms.Button
    Friend WithEvents bt_productos_rel As Button
    Friend WithEvents tx_documento_origen As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents tx_tiempo_efectivo_parada As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents bt_solicitud_almacen As Button
    Friend WithEvents bt_recursos As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents tx_titulo As TextBox
End Class
