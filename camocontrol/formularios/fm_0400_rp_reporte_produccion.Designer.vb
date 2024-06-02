<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0400_rp_reporte_produccion
    Inherits camocontrol.FM_PLANTILLA

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lb_producto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_id_rp = New System.Windows.Forms.TextBox()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_cant_produccion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_tiempo_produccion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_horas_hombre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tx_turno = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tx_clasificador = New System.Windows.Forms.TextBox()
        Me.bt_consumos_planificados = New System.Windows.Forms.Button()
        Me.cm_bodegas = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lb_rec_gen = New System.Windows.Forms.Label()
        Me.lb_cons_irreg = New System.Windows.Forms.Label()
        Me.lb_rec_aprov = New System.Windows.Forms.Label()
        Me.lb_consumo_p = New System.Windows.Forms.Label()
        Me.bt_transformar_en_recorte = New System.Windows.Forms.Button()
        Me.bt_consumir_recortes = New System.Windows.Forms.Button()
        Me.bt_consumos_irregulares = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_lote = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtp_fecha_vencimiento = New System.Windows.Forms.DateTimePicker()
        Me.bt_cerrar_rp = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tx_estado = New System.Windows.Forms.TextBox()
        Me.dg_ind_productivos = New System.Windows.Forms.DataGridView()
        Me.dgocell_ind_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ind_resultado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_especificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.bt_imprimir_etiquetas = New System.Windows.Forms.Button()
        Me.bt_consultar_entradas = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tx_docto_contable = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cm_bodega_entrega_pt = New System.Windows.Forms.ComboBox()
        Me.tx_cantidad_entregada = New System.Windows.Forms.TextBox()
        Me.bt_entrar_produccion = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lb_unidad = New System.Windows.Forms.Label()
        Me.bt_abrir_reporte = New System.Windows.Forms.Button()
        Me.bt_t_improductivo = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lb_total_min_t_improd = New System.Windows.Forms.Label()
        Me.lb_total_rep_t_improd = New System.Windows.Forms.Label()
        Me.dg_personal = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_personal_rp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_tercero = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgocell_tiempo_lab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_grabar_personal = New System.Windows.Forms.Button()
        Me.bt_inventario = New System.Windows.Forms.Button()
        Me.bt_calcular_lote = New System.Windows.Forms.Button()
        Me.bt_cambiar_infraestructura = New System.Windows.Forms.Button()
        Me.tx_estructura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cm_planta_produccion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_h_ini_programada = New System.Windows.Forms.DateTimePicker()
        Me.dtp_h_fin_programada = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tx_h_maq_prog = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tx_prod_programada = New System.Windows.Forms.TextBox()
        Me.cm_estandar_productivo = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tx_hh_prog = New System.Windows.Forms.TextBox()
        Me.tx_ip_cg = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_ind_productivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(825, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(923, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(924, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/03/31"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(296, 32)
        Me.lb_titulo.Text = "Reporte de Produccion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 557)
        '
        'bt_grabar
        '
        '
        'bt_anular
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 617)
        '
        'bt_editar
        '
        '
        'lb_producto
        '
        Me.lb_producto.AutoSize = True
        Me.lb_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_producto.Location = New System.Drawing.Point(301, 66)
        Me.lb_producto.Name = "lb_producto"
        Me.lb_producto.Size = New System.Drawing.Size(91, 20)
        Me.lb_producto.TabIndex = 194
        Me.lb_producto.Text = "Producto: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 193
        Me.Label4.Text = "# Reporte:"
        '
        'tx_id_rp
        '
        Me.tx_id_rp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_rp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_rp.Location = New System.Drawing.Point(114, 66)
        Me.tx_id_rp.MaxLength = 30
        Me.tx_id_rp.Name = "tx_id_rp"
        Me.tx_id_rp.ReadOnly = True
        Me.tx_id_rp.Size = New System.Drawing.Size(64, 22)
        Me.tx_id_rp.TabIndex = 186
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(114, 235)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(182, 20)
        Me.dtp_fecha.TabIndex = 200
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 239)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 201
        Me.Label8.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 353)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "Produccion:"
        '
        'tx_cant_produccion
        '
        Me.tx_cant_produccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_cant_produccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cant_produccion.Location = New System.Drawing.Point(114, 350)
        Me.tx_cant_produccion.MaxLength = 30
        Me.tx_cant_produccion.Name = "tx_cant_produccion"
        Me.tx_cant_produccion.ReadOnly = True
        Me.tx_cant_produccion.Size = New System.Drawing.Size(182, 22)
        Me.tx_cant_produccion.TabIndex = 202
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 376)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 205
        Me.Label9.Text = "h/maq real:"
        '
        'tx_tiempo_produccion
        '
        Me.tx_tiempo_produccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_tiempo_produccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tiempo_produccion.Location = New System.Drawing.Point(114, 373)
        Me.tx_tiempo_produccion.MaxLength = 30
        Me.tx_tiempo_produccion.Name = "tx_tiempo_produccion"
        Me.tx_tiempo_produccion.Size = New System.Drawing.Size(182, 22)
        Me.tx_tiempo_produccion.TabIndex = 204
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 399)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 16)
        Me.Label10.TabIndex = 207
        Me.Label10.Text = "H. Hombre:"
        '
        'tx_horas_hombre
        '
        Me.tx_horas_hombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_horas_hombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_horas_hombre.Location = New System.Drawing.Point(114, 396)
        Me.tx_horas_hombre.MaxLength = 30
        Me.tx_horas_hombre.Name = "tx_horas_hombre"
        Me.tx_horas_hombre.Size = New System.Drawing.Size(182, 22)
        Me.tx_horas_hombre.TabIndex = 206
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 306)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 16)
        Me.Label11.TabIndex = 209
        Me.Label11.Text = "Turno:"
        '
        'tx_turno
        '
        Me.tx_turno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_turno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_turno.Location = New System.Drawing.Point(114, 304)
        Me.tx_turno.MaxLength = 30
        Me.tx_turno.Name = "tx_turno"
        Me.tx_turno.Size = New System.Drawing.Size(182, 22)
        Me.tx_turno.TabIndex = 208
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
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 330)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 16)
        Me.Label17.TabIndex = 219
        Me.Label17.Text = "Clasificador:"
        '
        'tx_clasificador
        '
        Me.tx_clasificador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_clasificador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_clasificador.Location = New System.Drawing.Point(114, 327)
        Me.tx_clasificador.MaxLength = 30
        Me.tx_clasificador.Name = "tx_clasificador"
        Me.tx_clasificador.Size = New System.Drawing.Size(182, 22)
        Me.tx_clasificador.TabIndex = 218
        '
        'bt_consumos_planificados
        '
        Me.bt_consumos_planificados.Image = Global.camocontrol.My.Resources.Resources.OK
        Me.bt_consumos_planificados.Location = New System.Drawing.Point(5, 58)
        Me.bt_consumos_planificados.Name = "bt_consumos_planificados"
        Me.bt_consumos_planificados.Size = New System.Drawing.Size(112, 48)
        Me.bt_consumos_planificados.TabIndex = 220
        Me.bt_consumos_planificados.Text = "Consumo Insumos Plan"
        Me.bt_consumos_planificados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_consumos_planificados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_consumos_planificados.UseVisualStyleBackColor = True
        '
        'cm_bodegas
        '
        Me.cm_bodegas.FormattingEnabled = True
        Me.cm_bodegas.Location = New System.Drawing.Point(6, 34)
        Me.cm_bodegas.Name = "cm_bodegas"
        Me.cm_bodegas.Size = New System.Drawing.Size(412, 21)
        Me.cm_bodegas.TabIndex = 221
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lb_rec_gen)
        Me.GroupBox2.Controls.Add(Me.lb_cons_irreg)
        Me.GroupBox2.Controls.Add(Me.lb_rec_aprov)
        Me.GroupBox2.Controls.Add(Me.lb_consumo_p)
        Me.GroupBox2.Controls.Add(Me.bt_transformar_en_recorte)
        Me.GroupBox2.Controls.Add(Me.bt_consumir_recortes)
        Me.GroupBox2.Controls.Add(Me.bt_consumos_irregulares)
        Me.GroupBox2.Controls.Add(Me.cm_bodegas)
        Me.GroupBox2.Controls.Add(Me.bt_consumos_planificados)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(575, 304)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 133)
        Me.GroupBox2.TabIndex = 222
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Insumos Consumidos"
        '
        'lb_rec_gen
        '
        Me.lb_rec_gen.AutoSize = True
        Me.lb_rec_gen.Location = New System.Drawing.Point(322, 109)
        Me.lb_rec_gen.Name = "lb_rec_gen"
        Me.lb_rec_gen.Size = New System.Drawing.Size(23, 13)
        Me.lb_rec_gen.TabIndex = 228
        Me.lb_rec_gen.Text = "ND"
        '
        'lb_cons_irreg
        '
        Me.lb_cons_irreg.AutoSize = True
        Me.lb_cons_irreg.Location = New System.Drawing.Point(223, 109)
        Me.lb_cons_irreg.Name = "lb_cons_irreg"
        Me.lb_cons_irreg.Size = New System.Drawing.Size(23, 13)
        Me.lb_cons_irreg.TabIndex = 227
        Me.lb_cons_irreg.Text = "ND"
        '
        'lb_rec_aprov
        '
        Me.lb_rec_aprov.AutoSize = True
        Me.lb_rec_aprov.Location = New System.Drawing.Point(114, 109)
        Me.lb_rec_aprov.Name = "lb_rec_aprov"
        Me.lb_rec_aprov.Size = New System.Drawing.Size(23, 13)
        Me.lb_rec_aprov.TabIndex = 226
        Me.lb_rec_aprov.Text = "ND"
        '
        'lb_consumo_p
        '
        Me.lb_consumo_p.AutoSize = True
        Me.lb_consumo_p.Location = New System.Drawing.Point(3, 109)
        Me.lb_consumo_p.Name = "lb_consumo_p"
        Me.lb_consumo_p.Size = New System.Drawing.Size(23, 13)
        Me.lb_consumo_p.TabIndex = 225
        Me.lb_consumo_p.Text = "ND"
        '
        'bt_transformar_en_recorte
        '
        Me.bt_transformar_en_recorte.Image = Global.camocontrol.My.Resources.Resources.persona_caida
        Me.bt_transformar_en_recorte.Location = New System.Drawing.Point(325, 58)
        Me.bt_transformar_en_recorte.Name = "bt_transformar_en_recorte"
        Me.bt_transformar_en_recorte.Size = New System.Drawing.Size(96, 48)
        Me.bt_transformar_en_recorte.TabIndex = 224
        Me.bt_transformar_en_recorte.Text = "Recorte Generado"
        Me.bt_transformar_en_recorte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_transformar_en_recorte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_transformar_en_recorte.UseVisualStyleBackColor = True
        '
        'bt_consumir_recortes
        '
        Me.bt_consumir_recortes.Image = Global.camocontrol.My.Resources.Resources.grupoproducto
        Me.bt_consumir_recortes.Location = New System.Drawing.Point(117, 58)
        Me.bt_consumir_recortes.Name = "bt_consumir_recortes"
        Me.bt_consumir_recortes.Size = New System.Drawing.Size(110, 48)
        Me.bt_consumir_recortes.TabIndex = 223
        Me.bt_consumir_recortes.Text = "Aprov. de Recortes"
        Me.bt_consumir_recortes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_consumir_recortes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_consumir_recortes.UseVisualStyleBackColor = True
        '
        'bt_consumos_irregulares
        '
        Me.bt_consumos_irregulares.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_consumos_irregulares.Location = New System.Drawing.Point(226, 58)
        Me.bt_consumos_irregulares.Name = "bt_consumos_irregulares"
        Me.bt_consumos_irregulares.Size = New System.Drawing.Size(100, 48)
        Me.bt_consumos_irregulares.TabIndex = 222
        Me.bt_consumos_irregulares.Text = "Consumo Irregular"
        Me.bt_consumos_irregulares.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_consumos_irregulares.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_consumos_irregulares.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 261)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 16)
        Me.Label7.TabIndex = 224
        Me.Label7.Text = "Lote:"
        '
        'tx_lote
        '
        Me.tx_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_lote.Location = New System.Drawing.Point(114, 258)
        Me.tx_lote.MaxLength = 30
        Me.tx_lote.Name = "tx_lote"
        Me.tx_lote.Size = New System.Drawing.Size(182, 22)
        Me.tx_lote.TabIndex = 223
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(9, 283)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 16)
        Me.Label18.TabIndex = 226
        Me.Label18.Text = "F. Vencimiento:"
        '
        'dtp_fecha_vencimiento
        '
        Me.dtp_fecha_vencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_vencimiento.Location = New System.Drawing.Point(114, 281)
        Me.dtp_fecha_vencimiento.Name = "dtp_fecha_vencimiento"
        Me.dtp_fecha_vencimiento.Size = New System.Drawing.Size(182, 22)
        Me.dtp_fecha_vencimiento.TabIndex = 227
        '
        'bt_cerrar_rp
        '
        Me.bt_cerrar_rp.Image = Global.camocontrol.My.Resources.Resources.candado_32
        Me.bt_cerrar_rp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_cerrar_rp.Location = New System.Drawing.Point(306, 374)
        Me.bt_cerrar_rp.Name = "bt_cerrar_rp"
        Me.bt_cerrar_rp.Size = New System.Drawing.Size(87, 44)
        Me.bt_cerrar_rp.TabIndex = 228
        Me.bt_cerrar_rp.Text = "Cerrar Reporte"
        Me.bt_cerrar_rp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_cerrar_rp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_cerrar_rp.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(9, 215)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 16)
        Me.Label19.TabIndex = 230
        Me.Label19.Text = "Estado:"
        '
        'tx_estado
        '
        Me.tx_estado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estado.Location = New System.Drawing.Point(114, 212)
        Me.tx_estado.MaxLength = 30
        Me.tx_estado.Name = "tx_estado"
        Me.tx_estado.ReadOnly = True
        Me.tx_estado.Size = New System.Drawing.Size(182, 22)
        Me.tx_estado.TabIndex = 229
        '
        'dg_ind_productivos
        '
        Me.dg_ind_productivos.AllowUserToAddRows = False
        Me.dg_ind_productivos.AllowUserToDeleteRows = False
        Me.dg_ind_productivos.AllowUserToOrderColumns = True
        Me.dg_ind_productivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_ind_productivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_ind_nombre, Me.dgocell_ind_resultado, Me.dgocell_especificacion})
        Me.dg_ind_productivos.Location = New System.Drawing.Point(302, 210)
        Me.dg_ind_productivos.Name = "dg_ind_productivos"
        Me.dg_ind_productivos.ReadOnly = True
        Me.dg_ind_productivos.Size = New System.Drawing.Size(268, 124)
        Me.dg_ind_productivos.TabIndex = 234
        '
        'dgocell_ind_nombre
        '
        Me.dgocell_ind_nombre.HeaderText = "Indice"
        Me.dgocell_ind_nombre.Name = "dgocell_ind_nombre"
        Me.dgocell_ind_nombre.ReadOnly = True
        Me.dgocell_ind_nombre.Width = 80
        '
        'dgocell_ind_resultado
        '
        Me.dgocell_ind_resultado.HeaderText = "Valor"
        Me.dgocell_ind_resultado.Name = "dgocell_ind_resultado"
        Me.dgocell_ind_resultado.ReadOnly = True
        Me.dgocell_ind_resultado.Width = 50
        '
        'dgocell_especificacion
        '
        Me.dgocell_especificacion.HeaderText = "Especificacion"
        Me.dgocell_especificacion.Name = "dgocell_especificacion"
        Me.dgocell_especificacion.ReadOnly = True
        Me.dgocell_especificacion.Width = 50
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(299, 193)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(144, 16)
        Me.Label22.TabIndex = 235
        Me.Label22.Text = "Indices de Produccion:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.bt_imprimir_etiquetas)
        Me.GroupBox4.Controls.Add(Me.bt_consultar_entradas)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.tx_docto_contable)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.cm_bodega_entrega_pt)
        Me.GroupBox4.Controls.Add(Me.tx_cantidad_entregada)
        Me.GroupBox4.Controls.Add(Me.bt_entrar_produccion)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Location = New System.Drawing.Point(575, 190)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(429, 112)
        Me.GroupBox4.TabIndex = 223
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Entregas Producto Termiando"
        '
        'bt_imprimir_etiquetas
        '
        Me.bt_imprimir_etiquetas.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_impresion
        Me.bt_imprimir_etiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_imprimir_etiquetas.Location = New System.Drawing.Point(367, 17)
        Me.bt_imprimir_etiquetas.Name = "bt_imprimir_etiquetas"
        Me.bt_imprimir_etiquetas.Size = New System.Drawing.Size(51, 46)
        Me.bt_imprimir_etiquetas.TabIndex = 244
        Me.bt_imprimir_etiquetas.UseVisualStyleBackColor = True
        '
        'bt_consultar_entradas
        '
        Me.bt_consultar_entradas.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_consultar_entradas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_consultar_entradas.Location = New System.Drawing.Point(298, 18)
        Me.bt_consultar_entradas.Name = "bt_consultar_entradas"
        Me.bt_consultar_entradas.Size = New System.Drawing.Size(30, 30)
        Me.bt_consultar_entradas.TabIndex = 240
        Me.bt_consultar_entradas.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 16)
        Me.Label15.TabIndex = 239
        Me.Label15.Text = "Documento CG:"
        '
        'tx_docto_contable
        '
        Me.tx_docto_contable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_docto_contable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_docto_contable.Location = New System.Drawing.Point(111, 42)
        Me.tx_docto_contable.MaxLength = 30
        Me.tx_docto_contable.Name = "tx_docto_contable"
        Me.tx_docto_contable.Size = New System.Drawing.Size(138, 22)
        Me.tx_docto_contable.TabIndex = 238
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(6, 20)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 16)
        Me.Label24.TabIndex = 237
        Me.Label24.Text = "Cantidad:"
        '
        'cm_bodega_entrega_pt
        '
        Me.cm_bodega_entrega_pt.FormattingEnabled = True
        Me.cm_bodega_entrega_pt.Location = New System.Drawing.Point(6, 86)
        Me.cm_bodega_entrega_pt.Name = "cm_bodega_entrega_pt"
        Me.cm_bodega_entrega_pt.Size = New System.Drawing.Size(412, 21)
        Me.cm_bodega_entrega_pt.TabIndex = 221
        '
        'tx_cantidad_entregada
        '
        Me.tx_cantidad_entregada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_cantidad_entregada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad_entregada.Location = New System.Drawing.Point(111, 17)
        Me.tx_cantidad_entregada.MaxLength = 30
        Me.tx_cantidad_entregada.Name = "tx_cantidad_entregada"
        Me.tx_cantidad_entregada.Size = New System.Drawing.Size(138, 22)
        Me.tx_cantidad_entregada.TabIndex = 236
        '
        'bt_entrar_produccion
        '
        Me.bt_entrar_produccion.Image = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_entrar_produccion.Location = New System.Drawing.Point(262, 18)
        Me.bt_entrar_produccion.Name = "bt_entrar_produccion"
        Me.bt_entrar_produccion.Size = New System.Drawing.Size(30, 30)
        Me.bt_entrar_produccion.TabIndex = 220
        Me.bt_entrar_produccion.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 68)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(129, 16)
        Me.Label23.TabIndex = 214
        Me.Label23.Text = "Bodega de Entrega:"
        '
        'lb_unidad
        '
        Me.lb_unidad.AutoSize = True
        Me.lb_unidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_unidad.Location = New System.Drawing.Point(302, 354)
        Me.lb_unidad.Name = "lb_unidad"
        Me.lb_unidad.Size = New System.Drawing.Size(52, 16)
        Me.lb_unidad.TabIndex = 236
        Me.lb_unidad.Text = "Unidad"
        '
        'bt_abrir_reporte
        '
        Me.bt_abrir_reporte.Image = Global.camocontrol.My.Resources.Resources.password_32
        Me.bt_abrir_reporte.Location = New System.Drawing.Point(399, 374)
        Me.bt_abrir_reporte.Name = "bt_abrir_reporte"
        Me.bt_abrir_reporte.Size = New System.Drawing.Size(48, 44)
        Me.bt_abrir_reporte.TabIndex = 237
        Me.bt_abrir_reporte.UseVisualStyleBackColor = True
        '
        'bt_t_improductivo
        '
        Me.bt_t_improductivo.Image = Global.camocontrol.My.Resources.Resources.persona_megafono
        Me.bt_t_improductivo.Location = New System.Drawing.Point(6, 19)
        Me.bt_t_improductivo.Name = "bt_t_improductivo"
        Me.bt_t_improductivo.Size = New System.Drawing.Size(50, 51)
        Me.bt_t_improductivo.TabIndex = 238
        Me.bt_t_improductivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_t_improductivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_t_improductivo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lb_total_min_t_improd)
        Me.GroupBox3.Controls.Add(Me.lb_total_rep_t_improd)
        Me.GroupBox3.Controls.Add(Me.bt_t_improductivo)
        Me.GroupBox3.Location = New System.Drawing.Point(462, 341)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(106, 95)
        Me.GroupBox3.TabIndex = 239
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "T. Improductivo"
        '
        'lb_total_min_t_improd
        '
        Me.lb_total_min_t_improd.AutoSize = True
        Me.lb_total_min_t_improd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_min_t_improd.Location = New System.Drawing.Point(6, 69)
        Me.lb_total_min_t_improd.Name = "lb_total_min_t_improd"
        Me.lb_total_min_t_improd.Size = New System.Drawing.Size(66, 24)
        Me.lb_total_min_t_improd.TabIndex = 240
        Me.lb_total_min_t_improd.Text = "00 min"
        '
        'lb_total_rep_t_improd
        '
        Me.lb_total_rep_t_improd.AutoSize = True
        Me.lb_total_rep_t_improd.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_rep_t_improd.Location = New System.Drawing.Point(62, 32)
        Me.lb_total_rep_t_improd.Name = "lb_total_rep_t_improd"
        Me.lb_total_rep_t_improd.Size = New System.Drawing.Size(36, 25)
        Me.lb_total_rep_t_improd.TabIndex = 239
        Me.lb_total_rep_t_improd.Text = "00"
        '
        'dg_personal
        '
        Me.dg_personal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_personal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_personal_rp, Me.dgocell_id_tercero, Me.dgocell_tiempo_lab, Me.dgocell_nota})
        Me.dg_personal.Location = New System.Drawing.Point(114, 443)
        Me.dg_personal.Name = "dg_personal"
        Me.dg_personal.Size = New System.Drawing.Size(659, 115)
        Me.dg_personal.TabIndex = 240
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(111, 424)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 16)
        Me.Label1.TabIndex = 241
        Me.Label1.Text = "Personal Relacionado:"
        '
        'bt_grabar_personal
        '
        Me.bt_grabar_personal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_grabar_personal.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.bt_grabar_personal.Location = New System.Drawing.Point(779, 444)
        Me.bt_grabar_personal.Name = "bt_grabar_personal"
        Me.bt_grabar_personal.Size = New System.Drawing.Size(73, 86)
        Me.bt_grabar_personal.TabIndex = 242
        Me.bt_grabar_personal.Text = "Grabar Personal"
        Me.bt_grabar_personal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bt_grabar_personal.UseVisualStyleBackColor = True
        '
        'bt_inventario
        '
        Me.bt_inventario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_inventario.Location = New System.Drawing.Point(923, 443)
        Me.bt_inventario.Name = "bt_inventario"
        Me.bt_inventario.Size = New System.Drawing.Size(75, 29)
        Me.bt_inventario.TabIndex = 243
        Me.bt_inventario.Text = "Inventario"
        Me.bt_inventario.UseVisualStyleBackColor = True
        '
        'bt_calcular_lote
        '
        Me.bt_calcular_lote.Location = New System.Drawing.Point(46, 258)
        Me.bt_calcular_lote.Name = "bt_calcular_lote"
        Me.bt_calcular_lote.Size = New System.Drawing.Size(62, 22)
        Me.bt_calcular_lote.TabIndex = 244
        Me.bt_calcular_lote.Text = "Calcular"
        Me.bt_calcular_lote.UseVisualStyleBackColor = True
        '
        'bt_cambiar_infraestructura
        '
        Me.bt_cambiar_infraestructura.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargarplano
        Me.bt_cambiar_infraestructura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cambiar_infraestructura.Location = New System.Drawing.Point(734, 121)
        Me.bt_cambiar_infraestructura.Name = "bt_cambiar_infraestructura"
        Me.bt_cambiar_infraestructura.Size = New System.Drawing.Size(21, 22)
        Me.bt_cambiar_infraestructura.TabIndex = 294
        Me.bt_cambiar_infraestructura.UseVisualStyleBackColor = True
        '
        'tx_estructura
        '
        Me.tx_estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estructura.Location = New System.Drawing.Point(114, 118)
        Me.tx_estructura.Name = "tx_estructura"
        Me.tx_estructura.ReadOnly = True
        Me.tx_estructura.Size = New System.Drawing.Size(614, 22)
        Me.tx_estructura.TabIndex = 293
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 292
        Me.Label2.Text = "Maquina:"
        '
        'cm_planta_produccion
        '
        Me.cm_planta_produccion.FormattingEnabled = True
        Me.cm_planta_produccion.Location = New System.Drawing.Point(114, 95)
        Me.cm_planta_produccion.Name = "cm_planta_produccion"
        Me.cm_planta_produccion.Size = New System.Drawing.Size(412, 21)
        Me.cm_planta_produccion.TabIndex = 295
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 296
        Me.Label3.Text = "Planta Produc:"
        '
        'dtp_h_ini_programada
        '
        Me.dtp_h_ini_programada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_h_ini_programada.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_h_ini_programada.Location = New System.Drawing.Point(114, 164)
        Me.dtp_h_ini_programada.Name = "dtp_h_ini_programada"
        Me.dtp_h_ini_programada.Size = New System.Drawing.Size(182, 22)
        Me.dtp_h_ini_programada.TabIndex = 297
        '
        'dtp_h_fin_programada
        '
        Me.dtp_h_fin_programada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_h_fin_programada.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_h_fin_programada.Location = New System.Drawing.Point(114, 188)
        Me.dtp_h_fin_programada.Name = "dtp_h_fin_programada"
        Me.dtp_h_fin_programada.Size = New System.Drawing.Size(182, 22)
        Me.dtp_h_fin_programada.TabIndex = 298
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 16)
        Me.Label12.TabIndex = 301
        Me.Label12.Text = "Turno Programa"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(313, 168)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 16)
        Me.Label13.TabIndex = 303
        Me.Label13.Text = "h/maq prog:"
        '
        'tx_h_maq_prog
        '
        Me.tx_h_maq_prog.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_h_maq_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_h_maq_prog.Location = New System.Drawing.Point(395, 165)
        Me.tx_h_maq_prog.MaxLength = 30
        Me.tx_h_maq_prog.Name = "tx_h_maq_prog"
        Me.tx_h_maq_prog.ReadOnly = True
        Me.tx_h_maq_prog.Size = New System.Drawing.Size(35, 22)
        Me.tx_h_maq_prog.TabIndex = 302
        Me.tx_h_maq_prog.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(555, 168)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 16)
        Me.Label16.TabIndex = 305
        Me.Label16.Text = "Prod Esperada:"
        '
        'tx_prod_programada
        '
        Me.tx_prod_programada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_prod_programada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_prod_programada.Location = New System.Drawing.Point(660, 165)
        Me.tx_prod_programada.MaxLength = 30
        Me.tx_prod_programada.Name = "tx_prod_programada"
        Me.tx_prod_programada.ReadOnly = True
        Me.tx_prod_programada.Size = New System.Drawing.Size(95, 22)
        Me.tx_prod_programada.TabIndex = 304
        '
        'cm_estandar_productivo
        '
        Me.cm_estandar_productivo.FormattingEnabled = True
        Me.cm_estandar_productivo.Location = New System.Drawing.Point(114, 141)
        Me.cm_estandar_productivo.Name = "cm_estandar_productivo"
        Me.cm_estandar_productivo.Size = New System.Drawing.Size(641, 21)
        Me.cm_estandar_productivo.TabIndex = 245
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 146)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(97, 16)
        Me.Label20.TabIndex = 306
        Me.Label20.Text = "Estandar Prod:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(443, 168)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 16)
        Me.Label21.TabIndex = 308
        Me.Label21.Text = "h/h prog:"
        '
        'tx_hh_prog
        '
        Me.tx_hh_prog.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_hh_prog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_hh_prog.Location = New System.Drawing.Point(505, 165)
        Me.tx_hh_prog.MaxLength = 30
        Me.tx_hh_prog.Name = "tx_hh_prog"
        Me.tx_hh_prog.ReadOnly = True
        Me.tx_hh_prog.Size = New System.Drawing.Size(35, 22)
        Me.tx_hh_prog.TabIndex = 307
        Me.tx_hh_prog.Text = "0"
        '
        'tx_ip_cg
        '
        Me.tx_ip_cg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_ip_cg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_ip_cg.Location = New System.Drawing.Point(183, 66)
        Me.tx_ip_cg.MaxLength = 30
        Me.tx_ip_cg.Name = "tx_ip_cg"
        Me.tx_ip_cg.ReadOnly = True
        Me.tx_ip_cg.Size = New System.Drawing.Size(113, 22)
        Me.tx_ip_cg.TabIndex = 309
        '
        'fm_0400_rp_reporte_produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1010, 631)
        Me.Controls.Add(Me.tx_ip_cg)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.tx_hh_prog)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cm_estandar_productivo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tx_prod_programada)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tx_h_maq_prog)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dtp_h_fin_programada)
        Me.Controls.Add(Me.dtp_h_ini_programada)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cm_planta_produccion)
        Me.Controls.Add(Me.bt_cambiar_infraestructura)
        Me.Controls.Add(Me.tx_estructura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bt_calcular_lote)
        Me.Controls.Add(Me.bt_inventario)
        Me.Controls.Add(Me.bt_grabar_personal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_personal)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.bt_abrir_reporte)
        Me.Controls.Add(Me.lb_unidad)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dg_ind_productivos)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.tx_estado)
        Me.Controls.Add(Me.bt_cerrar_rp)
        Me.Controls.Add(Me.dtp_fecha_vencimiento)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_lote)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.tx_clasificador)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tx_turno)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tx_horas_hombre)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_tiempo_produccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_cant_produccion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.lb_producto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_id_rp)
        Me.Name = "fm_0400_rp_reporte_produccion"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.tx_id_rp, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lb_producto, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_cant_produccion, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_tiempo_produccion, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_horas_hombre, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.tx_turno, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_clasificador, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.tx_lote, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_vencimiento, 0)
        Me.Controls.SetChildIndex(Me.bt_cerrar_rp, 0)
        Me.Controls.SetChildIndex(Me.tx_estado, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.dg_ind_productivos, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.lb_unidad, 0)
        Me.Controls.SetChildIndex(Me.bt_abrir_reporte, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.dg_personal, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.bt_grabar_personal, 0)
        Me.Controls.SetChildIndex(Me.bt_inventario, 0)
        Me.Controls.SetChildIndex(Me.bt_calcular_lote, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_estructura, 0)
        Me.Controls.SetChildIndex(Me.bt_cambiar_infraestructura, 0)
        Me.Controls.SetChildIndex(Me.cm_planta_produccion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtp_h_ini_programada, 0)
        Me.Controls.SetChildIndex(Me.dtp_h_fin_programada, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.tx_h_maq_prog, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_prod_programada, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.cm_estandar_productivo, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.tx_hh_prog, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.tx_ip_cg, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dg_ind_productivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_producto As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_id_rp As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_cant_produccion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_tiempo_produccion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tx_horas_hombre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tx_turno As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tx_clasificador As System.Windows.Forms.TextBox
    Friend WithEvents bt_consumos_planificados As System.Windows.Forms.Button
    Friend WithEvents cm_bodegas As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tx_lote As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents bt_cerrar_rp As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tx_estado As System.Windows.Forms.TextBox
    Friend WithEvents dg_ind_productivos As System.Windows.Forms.DataGridView
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cm_bodega_entrega_pt As System.Windows.Forms.ComboBox
    Friend WithEvents tx_cantidad_entregada As System.Windows.Forms.TextBox
    Friend WithEvents bt_entrar_produccion As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tx_docto_contable As System.Windows.Forms.TextBox
    Friend WithEvents bt_consultar_entradas As System.Windows.Forms.Button
    Friend WithEvents bt_consumos_irregulares As Button
    Friend WithEvents lb_unidad As Label
    Friend WithEvents bt_abrir_reporte As Button
    Friend WithEvents bt_t_improductivo As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lb_total_min_t_improd As Label
    Friend WithEvents lb_total_rep_t_improd As Label
    Friend WithEvents dg_personal As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents bt_grabar_personal As Button
    Friend WithEvents dgocell_id_personal_rp As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_tercero As DataGridViewComboBoxColumn
    Friend WithEvents dgocell_tiempo_lab As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nota As DataGridViewTextBoxColumn
    Friend WithEvents bt_consumir_recortes As Button
    Friend WithEvents bt_transformar_en_recorte As Button
    Friend WithEvents lb_rec_gen As Label
    Friend WithEvents lb_cons_irreg As Label
    Friend WithEvents lb_rec_aprov As Label
    Friend WithEvents lb_consumo_p As Label
    Friend WithEvents dgocell_ind_nombre As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ind_resultado As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_especificacion As DataGridViewTextBoxColumn
    Friend WithEvents bt_inventario As Button
    Friend WithEvents bt_imprimir_etiquetas As Button
    Friend WithEvents bt_calcular_lote As Button
    Friend WithEvents bt_cambiar_infraestructura As Button
    Friend WithEvents tx_estructura As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cm_planta_produccion As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtp_h_ini_programada As DateTimePicker
    Friend WithEvents dtp_h_fin_programada As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents tx_h_maq_prog As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents tx_prod_programada As TextBox
    Friend WithEvents cm_estandar_productivo As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents tx_hh_prog As TextBox
    Friend WithEvents tx_ip_cg As TextBox
End Class
