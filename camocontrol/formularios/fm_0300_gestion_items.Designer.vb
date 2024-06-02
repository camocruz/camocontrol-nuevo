<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0300_gestion_items
    Inherits camocontrol.FM_PLANTILLA

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
        Me.tx_id_item = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cm_unidad_medicion = New System.Windows.Forms.ComboBox()
        Me.cm_tipo_item = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cm_linea = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_referencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_observacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_cguno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chk_descripcion_manual = New System.Windows.Forms.CheckBox()
        Me.tx_cont_empaque = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chk_venta = New System.Windows.Forms.CheckBox()
        Me.bt_explosion_materiales = New System.Windows.Forms.Button()
        Me.tx_referencia_empaque = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chk_pp_programable = New System.Windows.Forms.CheckBox()
        Me.tx_peso_unitario = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.bt_acceso_restringido = New System.Windows.Forms.Button()
        Me.chk_acceso_restringido = New System.Windows.Forms.CheckBox()
        Me.dg_def_inventarios = New System.Windows.Forms.DataGridView()
        Me.tx_id_criterio = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.bt_editar_criterio = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bt_movimientos_item = New System.Windows.Forms.Button()
        Me.bt_ajuste_inventario = New System.Windows.Forms.Button()
        Me.bt_costos = New System.Windows.Forms.Button()
        Me.tx_peso_neto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tx_peso_bruto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.bt_unificar = New System.Windows.Forms.Button()
        Me.tx_id_item_unificado = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tx_codigo_barras = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tx_ref_emp_alt = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tx_factor_conv_ref_emp_alt = New System.Windows.Forms.TextBox()
        Me.cm_oper_fact_conv_alt_ppal = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tx_descripcion = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_def_inventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(766, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(864, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(865, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/03/17"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(220, 32)
        Me.lb_titulo.Text = "Gestion de Items"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(252, 537)
        '
        'bt_grabar
        '
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 597)
        '
        'tx_id_item
        '
        Me.tx_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item.Location = New System.Drawing.Point(134, 99)
        Me.tx_id_item.Name = "tx_id_item"
        Me.tx_id_item.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Id_item:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Unidad Medicion:"
        '
        'cm_unidad_medicion
        '
        Me.cm_unidad_medicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_unidad_medicion.FormattingEnabled = True
        Me.cm_unidad_medicion.Location = New System.Drawing.Point(134, 217)
        Me.cm_unidad_medicion.Name = "cm_unidad_medicion"
        Me.cm_unidad_medicion.Size = New System.Drawing.Size(295, 24)
        Me.cm_unidad_medicion.TabIndex = 6
        '
        'cm_tipo_item
        '
        Me.cm_tipo_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_item.FormattingEnabled = True
        Me.cm_tipo_item.Location = New System.Drawing.Point(134, 242)
        Me.cm_tipo_item.Name = "cm_tipo_item"
        Me.cm_tipo_item.Size = New System.Drawing.Size(295, 24)
        Me.cm_tipo_item.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Tipo Item:"
        '
        'cm_linea
        '
        Me.cm_linea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_linea.FormattingEnabled = True
        Me.cm_linea.Location = New System.Drawing.Point(134, 315)
        Me.cm_linea.Name = "cm_linea"
        Me.cm_linea.Size = New System.Drawing.Size(295, 24)
        Me.cm_linea.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 318)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "Linea Item:"
        '
        'tx_referencia
        '
        Me.tx_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_referencia.Location = New System.Drawing.Point(134, 148)
        Me.tx_referencia.Name = "tx_referencia"
        Me.tx_referencia.Size = New System.Drawing.Size(295, 22)
        Me.tx_referencia.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 16)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "Ref. CGUNO:"
        '
        'tx_observacion
        '
        Me.tx_observacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_observacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_observacion.Location = New System.Drawing.Point(16, 470)
        Me.tx_observacion.Multiline = True
        Me.tx_observacion.Name = "tx_observacion"
        Me.tx_observacion.Size = New System.Drawing.Size(413, 56)
        Me.tx_observacion.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 453)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 141
        Me.Label7.Text = "Observacion:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 143
        Me.Label8.Text = "Codigo CGUNO"
        '
        'tx_cguno
        '
        Me.tx_cguno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cguno.Location = New System.Drawing.Point(134, 171)
        Me.tx_cguno.Name = "tx_cguno"
        Me.tx_cguno.Size = New System.Drawing.Size(295, 22)
        Me.tx_cguno.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Descripcion:"
        '
        'chk_descripcion_manual
        '
        Me.chk_descripcion_manual.AutoSize = True
        Me.chk_descripcion_manual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_descripcion_manual.Location = New System.Drawing.Point(467, 125)
        Me.chk_descripcion_manual.Name = "chk_descripcion_manual"
        Me.chk_descripcion_manual.Size = New System.Drawing.Size(193, 20)
        Me.chk_descripcion_manual.TabIndex = 149
        Me.chk_descripcion_manual.Text = "Habilita descripcion manual"
        Me.chk_descripcion_manual.UseVisualStyleBackColor = True
        '
        'tx_cont_empaque
        '
        Me.tx_cont_empaque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_cont_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cont_empaque.Location = New System.Drawing.Point(134, 292)
        Me.tx_cont_empaque.MaxLength = 30
        Me.tx_cont_empaque.Name = "tx_cont_empaque"
        Me.tx_cont_empaque.Size = New System.Drawing.Size(295, 22)
        Me.tx_cont_empaque.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 16)
        Me.Label10.TabIndex = 150
        Me.Label10.Text = "Cont. Empaque:"
        '
        'chk_venta
        '
        Me.chk_venta.AutoSize = True
        Me.chk_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_venta.Location = New System.Drawing.Point(467, 151)
        Me.chk_venta.Name = "chk_venta"
        Me.chk_venta.Size = New System.Drawing.Size(138, 20)
        Me.chk_venta.TabIndex = 152
        Me.chk_venta.Text = "Producto de Venta"
        Me.chk_venta.UseVisualStyleBackColor = True
        '
        'bt_explosion_materiales
        '
        Me.bt_explosion_materiales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_explosion_materiales.Image = Global.camocontrol.My.Resources.Resources.espina_pescado
        Me.bt_explosion_materiales.Location = New System.Drawing.Point(470, 494)
        Me.bt_explosion_materiales.Name = "bt_explosion_materiales"
        Me.bt_explosion_materiales.Size = New System.Drawing.Size(57, 43)
        Me.bt_explosion_materiales.TabIndex = 155
        Me.bt_explosion_materiales.UseVisualStyleBackColor = True
        '
        'tx_referencia_empaque
        '
        Me.tx_referencia_empaque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_referencia_empaque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_referencia_empaque.Location = New System.Drawing.Point(134, 409)
        Me.tx_referencia_empaque.Name = "tx_referencia_empaque"
        Me.tx_referencia_empaque.Size = New System.Drawing.Size(150, 22)
        Me.tx_referencia_empaque.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 412)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 16)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "Ref_empaq:"
        '
        'chk_pp_programable
        '
        Me.chk_pp_programable.AutoSize = True
        Me.chk_pp_programable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_pp_programable.Location = New System.Drawing.Point(710, 125)
        Me.chk_pp_programable.Name = "chk_pp_programable"
        Me.chk_pp_programable.Size = New System.Drawing.Size(127, 20)
        Me.chk_pp_programable.TabIndex = 158
        Me.chk_pp_programable.Text = "PP Programable"
        Me.chk_pp_programable.UseVisualStyleBackColor = True
        '
        'tx_peso_unitario
        '
        Me.tx_peso_unitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_peso_unitario.Location = New System.Drawing.Point(134, 340)
        Me.tx_peso_unitario.Name = "tx_peso_unitario"
        Me.tx_peso_unitario.Size = New System.Drawing.Size(150, 22)
        Me.tx_peso_unitario.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 343)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 16)
        Me.Label13.TabIndex = 159
        Me.Label13.Text = "Peso unit (kg):"
        '
        'bt_acceso_restringido
        '
        Me.bt_acceso_restringido.Image = Global.camocontrol.My.Resources.Resources.icono_wifi
        Me.bt_acceso_restringido.Location = New System.Drawing.Point(875, 130)
        Me.bt_acceso_restringido.Name = "bt_acceso_restringido"
        Me.bt_acceso_restringido.Size = New System.Drawing.Size(48, 41)
        Me.bt_acceso_restringido.TabIndex = 161
        Me.bt_acceso_restringido.UseVisualStyleBackColor = True
        '
        'chk_acceso_restringido
        '
        Me.chk_acceso_restringido.AutoSize = True
        Me.chk_acceso_restringido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_acceso_restringido.Location = New System.Drawing.Point(710, 150)
        Me.chk_acceso_restringido.Name = "chk_acceso_restringido"
        Me.chk_acceso_restringido.Size = New System.Drawing.Size(160, 20)
        Me.chk_acceso_restringido.TabIndex = 162
        Me.chk_acceso_restringido.Text = "Acceso Dosificadores"
        Me.chk_acceso_restringido.UseVisualStyleBackColor = True
        '
        'dg_def_inventarios
        '
        Me.dg_def_inventarios.AllowUserToAddRows = False
        Me.dg_def_inventarios.AllowUserToDeleteRows = False
        Me.dg_def_inventarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_def_inventarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_def_inventarios.Location = New System.Drawing.Point(17, 19)
        Me.dg_def_inventarios.Name = "dg_def_inventarios"
        Me.dg_def_inventarios.ReadOnly = True
        Me.dg_def_inventarios.Size = New System.Drawing.Size(439, 250)
        Me.dg_def_inventarios.TabIndex = 163
        '
        'tx_id_criterio
        '
        Me.tx_id_criterio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_id_criterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_criterio.Location = New System.Drawing.Point(91, 279)
        Me.tx_id_criterio.Name = "tx_id_criterio"
        Me.tx_id_criterio.ReadOnly = True
        Me.tx_id_criterio.Size = New System.Drawing.Size(75, 22)
        Me.tx_id_criterio.TabIndex = 166
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 282)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 16)
        Me.Label14.TabIndex = 165
        Me.Label14.Text = "id_criterio:"
        '
        'bt_editar_criterio
        '
        Me.bt_editar_criterio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_editar_criterio.BackgroundImage = Global.camocontrol.My.Resources.Resources.design
        Me.bt_editar_criterio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_editar_criterio.Location = New System.Drawing.Point(172, 276)
        Me.bt_editar_criterio.Name = "bt_editar_criterio"
        Me.bt_editar_criterio.Size = New System.Drawing.Size(29, 29)
        Me.bt_editar_criterio.TabIndex = 167
        Me.bt_editar_criterio.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.bt_movimientos_item)
        Me.GroupBox2.Controls.Add(Me.bt_ajuste_inventario)
        Me.GroupBox2.Controls.Add(Me.bt_editar_criterio)
        Me.GroupBox2.Controls.Add(Me.tx_id_criterio)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.dg_def_inventarios)
        Me.GroupBox2.Location = New System.Drawing.Point(467, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(474, 314)
        Me.GroupBox2.TabIndex = 170
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Criterios de Control de Inventarios"
        '
        'bt_movimientos_item
        '
        Me.bt_movimientos_item.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_movimientos_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_movimientos_item.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_movimientos_item.Location = New System.Drawing.Point(278, 278)
        Me.bt_movimientos_item.Name = "bt_movimientos_item"
        Me.bt_movimientos_item.Size = New System.Drawing.Size(24, 24)
        Me.bt_movimientos_item.TabIndex = 169
        Me.bt_movimientos_item.UseVisualStyleBackColor = True
        '
        'bt_ajuste_inventario
        '
        Me.bt_ajuste_inventario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_ajuste_inventario.BackgroundImage = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_ajuste_inventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_ajuste_inventario.Location = New System.Drawing.Point(243, 275)
        Me.bt_ajuste_inventario.Name = "bt_ajuste_inventario"
        Me.bt_ajuste_inventario.Size = New System.Drawing.Size(29, 29)
        Me.bt_ajuste_inventario.TabIndex = 168
        Me.bt_ajuste_inventario.UseVisualStyleBackColor = True
        '
        'bt_costos
        '
        Me.bt_costos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_costos.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_costos.Location = New System.Drawing.Point(533, 494)
        Me.bt_costos.Name = "bt_costos"
        Me.bt_costos.Size = New System.Drawing.Size(57, 43)
        Me.bt_costos.TabIndex = 171
        Me.bt_costos.UseVisualStyleBackColor = True
        '
        'tx_peso_neto
        '
        Me.tx_peso_neto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_peso_neto.Location = New System.Drawing.Point(134, 363)
        Me.tx_peso_neto.Name = "tx_peso_neto"
        Me.tx_peso_neto.Size = New System.Drawing.Size(150, 22)
        Me.tx_peso_neto.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 366)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 16)
        Me.Label11.TabIndex = 172
        Me.Label11.Text = "Peso neto (kg):"
        '
        'tx_peso_bruto
        '
        Me.tx_peso_bruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_peso_bruto.Location = New System.Drawing.Point(134, 386)
        Me.tx_peso_bruto.Name = "tx_peso_bruto"
        Me.tx_peso_bruto.Size = New System.Drawing.Size(150, 22)
        Me.tx_peso_bruto.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 389)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 16)
        Me.Label15.TabIndex = 174
        Me.Label15.Text = "Peso bruto (kg):"
        '
        'bt_unificar
        '
        Me.bt_unificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_unificar.Image = Global.camocontrol.My.Resources.Resources.grupoproducto
        Me.bt_unificar.Location = New System.Drawing.Point(596, 494)
        Me.bt_unificar.Name = "bt_unificar"
        Me.bt_unificar.Size = New System.Drawing.Size(57, 43)
        Me.bt_unificar.TabIndex = 176
        Me.bt_unificar.UseVisualStyleBackColor = True
        '
        'tx_id_item_unificado
        '
        Me.tx_id_item_unificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_unificado.Location = New System.Drawing.Point(844, 76)
        Me.tx_id_item_unificado.Name = "tx_id_item_unificado"
        Me.tx_id_item_unificado.ReadOnly = True
        Me.tx_id_item_unificado.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item_unificado.TabIndex = 178
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(725, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 16)
        Me.Label16.TabIndex = 177
        Me.Label16.Text = "Id_item_unificado:"
        '
        'tx_codigo_barras
        '
        Me.tx_codigo_barras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_codigo_barras.Location = New System.Drawing.Point(134, 194)
        Me.tx_codigo_barras.Name = "tx_codigo_barras"
        Me.tx_codigo_barras.Size = New System.Drawing.Size(295, 22)
        Me.tx_codigo_barras.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 197)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 16)
        Me.Label17.TabIndex = 179
        Me.Label17.Text = "Codigo Barras:"
        '
        'tx_ref_emp_alt
        '
        Me.tx_ref_emp_alt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_ref_emp_alt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_ref_emp_alt.Location = New System.Drawing.Point(134, 432)
        Me.tx_ref_emp_alt.Name = "tx_ref_emp_alt"
        Me.tx_ref_emp_alt.Size = New System.Drawing.Size(150, 22)
        Me.tx_ref_emp_alt.TabIndex = 14
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 435)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 16)
        Me.Label18.TabIndex = 181
        Me.Label18.Text = "Ref_empaq alt:"
        '
        'tx_factor_conv_ref_emp_alt
        '
        Me.tx_factor_conv_ref_emp_alt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_factor_conv_ref_emp_alt.Location = New System.Drawing.Point(348, 433)
        Me.tx_factor_conv_ref_emp_alt.Name = "tx_factor_conv_ref_emp_alt"
        Me.tx_factor_conv_ref_emp_alt.Size = New System.Drawing.Size(81, 22)
        Me.tx_factor_conv_ref_emp_alt.TabIndex = 16
        '
        'cm_oper_fact_conv_alt_ppal
        '
        Me.cm_oper_fact_conv_alt_ppal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_oper_fact_conv_alt_ppal.FormattingEnabled = True
        Me.cm_oper_fact_conv_alt_ppal.Items.AddRange(New Object() {"*", "/"})
        Me.cm_oper_fact_conv_alt_ppal.Location = New System.Drawing.Point(290, 432)
        Me.cm_oper_fact_conv_alt_ppal.Name = "cm_oper_fact_conv_alt_ppal"
        Me.cm_oper_fact_conv_alt_ppal.Size = New System.Drawing.Size(52, 24)
        Me.cm_oper_fact_conv_alt_ppal.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(131, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 16)
        Me.Label19.TabIndex = 182
        Me.Label19.Text = "F2 Busqueda"
        '
        'tx_descripcion
        '
        Me.tx_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_descripcion.Location = New System.Drawing.Point(134, 123)
        Me.tx_descripcion.Name = "tx_descripcion"
        Me.tx_descripcion.Size = New System.Drawing.Size(295, 22)
        Me.tx_descripcion.TabIndex = 183
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(134, 267)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(295, 24)
        Me.ComboBox1.TabIndex = 184
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 270)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 16)
        Me.Label9.TabIndex = 185
        Me.Label9.Text = "Sub Tipo Item:"
        '
        'fm_0300_gestion_items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(951, 611)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_descripcion)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cm_oper_fact_conv_alt_ppal)
        Me.Controls.Add(Me.tx_factor_conv_ref_emp_alt)
        Me.Controls.Add(Me.tx_ref_emp_alt)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.tx_codigo_barras)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.tx_id_item_unificado)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.bt_unificar)
        Me.Controls.Add(Me.tx_peso_bruto)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tx_peso_neto)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.bt_costos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chk_acceso_restringido)
        Me.Controls.Add(Me.bt_acceso_restringido)
        Me.Controls.Add(Me.tx_peso_unitario)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chk_pp_programable)
        Me.Controls.Add(Me.tx_referencia_empaque)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.bt_explosion_materiales)
        Me.Controls.Add(Me.chk_venta)
        Me.Controls.Add(Me.tx_cont_empaque)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.chk_descripcion_manual)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_cguno)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tx_observacion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_referencia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_linea)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cm_tipo_item)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cm_unidad_medicion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_id_item)
        Me.Controls.Add(Me.Label5)
        Me.KeyPreview = True
        Me.Name = "fm_0300_gestion_items"
        Me.Text = "1"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_unidad_medicion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_item, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cm_linea, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_referencia, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_observacion, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_cguno, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.chk_descripcion_manual, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.tx_cont_empaque, 0)
        Me.Controls.SetChildIndex(Me.chk_venta, 0)
        Me.Controls.SetChildIndex(Me.bt_explosion_materiales, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.tx_referencia_empaque, 0)
        Me.Controls.SetChildIndex(Me.chk_pp_programable, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_peso_unitario, 0)
        Me.Controls.SetChildIndex(Me.bt_acceso_restringido, 0)
        Me.Controls.SetChildIndex(Me.chk_acceso_restringido, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.bt_costos, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_peso_neto, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.tx_peso_bruto, 0)
        Me.Controls.SetChildIndex(Me.bt_unificar, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_unificado, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.tx_codigo_barras, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.tx_ref_emp_alt, 0)
        Me.Controls.SetChildIndex(Me.tx_factor_conv_ref_emp_alt, 0)
        Me.Controls.SetChildIndex(Me.cm_oper_fact_conv_alt_ppal, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.tx_descripcion, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_def_inventarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_id_item As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cm_unidad_medicion As System.Windows.Forms.ComboBox
    Friend WithEvents cm_tipo_item As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cm_linea As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_referencia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tx_observacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tx_cguno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chk_descripcion_manual As System.Windows.Forms.CheckBox
    Friend WithEvents tx_cont_empaque As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chk_venta As System.Windows.Forms.CheckBox
    Friend WithEvents bt_explosion_materiales As System.Windows.Forms.Button
    Friend WithEvents tx_referencia_empaque As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chk_pp_programable As System.Windows.Forms.CheckBox
    Friend WithEvents tx_peso_unitario As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents bt_acceso_restringido As Button
    Friend WithEvents chk_acceso_restringido As CheckBox
    Friend WithEvents dg_def_inventarios As DataGridView
    Friend WithEvents tx_id_criterio As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents bt_editar_criterio As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents bt_costos As Button
    Friend WithEvents tx_peso_neto As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tx_peso_bruto As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents bt_unificar As Button
    Friend WithEvents bt_ajuste_inventario As Button
    Friend WithEvents bt_movimientos_item As Button
    Friend WithEvents tx_id_item_unificado As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents tx_codigo_barras As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents tx_ref_emp_alt As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents tx_factor_conv_ref_emp_alt As TextBox
    Friend WithEvents cm_oper_fact_conv_alt_ppal As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents tx_descripcion As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label9 As Label
End Class
