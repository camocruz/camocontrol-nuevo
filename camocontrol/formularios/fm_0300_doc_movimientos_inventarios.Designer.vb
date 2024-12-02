<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0300_doc_movimientos_inventarios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dg_items = New System.Windows.Forms.DataGridView()
        Me.dgocell_ident_doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_tipo_mov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nombre_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unidad_med = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cant_movimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cant_teorica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_clasificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_info_trazabilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_docto_ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_promedio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lb_cod_documento = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cm_bodegas = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_usuario = New System.Windows.Forms.Label()
        Me.cm_bodega_destino = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tx_registro_seleccionado = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bt_nueva_nota = New System.Windows.Forms.Button()
        Me.bt_consultar_notas = New System.Windows.Forms.Button()
        Me.lb_total_notas = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_docto_contable = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_docto_origen = New System.Windows.Forms.TextBox()
        Me.bt_genmov_apartir_solalm = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cm_recibio = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lb_costo_total = New System.Windows.Forms.Label()
        Me.lb_costo_absoluto = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(779, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(877, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(878, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/04/29"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(345, 32)
        Me.lb_titulo.Text = "Movimiento de Inventarios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(210, 451)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_anular, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_grabar, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_nuevo, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_editar, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_generar_informe, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_g_notas, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.bt_g_archivos, 0)
        Me.GroupBox1.Controls.SetChildIndex(Me.Label10, 0)
        '
        'bt_anular
        '
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 511)
        '
        'bt_editar
        '
        '
        'bt_generar_informe
        '
        '
        'dg_items
        '
        Me.dg_items.AllowUserToAddRows = False
        Me.dg_items.AllowUserToDeleteRows = False
        Me.dg_items.AllowUserToOrderColumns = True
        Me.dg_items.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_ident_doc, Me.dgocell_tipo_mov, Me.dgocell_id_item, Me.dgocell_nombre_item, Me.dgocell_unidad_med, Me.dgocell_cant_movimiento, Me.dgocell_cant_teorica, Me.dgocell_clasificador, Me.dgocell_info_trazabilidad, Me.dgocell_docto_ref, Me.dgocell_costo_promedio})
        Me.dg_items.Location = New System.Drawing.Point(17, 190)
        Me.dg_items.Name = "dg_items"
        Me.dg_items.ReadOnly = True
        Me.dg_items.Size = New System.Drawing.Size(939, 246)
        Me.dg_items.TabIndex = 62
        '
        'dgocell_ident_doc
        '
        Me.dgocell_ident_doc.HeaderText = "id"
        Me.dgocell_ident_doc.Name = "dgocell_ident_doc"
        Me.dgocell_ident_doc.ReadOnly = True
        Me.dgocell_ident_doc.Width = 30
        '
        'dgocell_tipo_mov
        '
        Me.dgocell_tipo_mov.HeaderText = "T"
        Me.dgocell_tipo_mov.Name = "dgocell_tipo_mov"
        Me.dgocell_tipo_mov.ReadOnly = True
        Me.dgocell_tipo_mov.Width = 20
        '
        'dgocell_id_item
        '
        Me.dgocell_id_item.HeaderText = "Id-Item"
        Me.dgocell_id_item.Name = "dgocell_id_item"
        Me.dgocell_id_item.ReadOnly = True
        Me.dgocell_id_item.Width = 50
        '
        'dgocell_nombre_item
        '
        Me.dgocell_nombre_item.HeaderText = "Item"
        Me.dgocell_nombre_item.Name = "dgocell_nombre_item"
        Me.dgocell_nombre_item.ReadOnly = True
        Me.dgocell_nombre_item.Width = 300
        '
        'dgocell_unidad_med
        '
        Me.dgocell_unidad_med.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_unidad_med.HeaderText = "Unidad"
        Me.dgocell_unidad_med.Name = "dgocell_unidad_med"
        Me.dgocell_unidad_med.ReadOnly = True
        Me.dgocell_unidad_med.Width = 66
        '
        'dgocell_cant_movimiento
        '
        Me.dgocell_cant_movimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N4"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.dgocell_cant_movimiento.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgocell_cant_movimiento.HeaderText = "Cantidad"
        Me.dgocell_cant_movimiento.Name = "dgocell_cant_movimiento"
        Me.dgocell_cant_movimiento.ReadOnly = True
        Me.dgocell_cant_movimiento.Width = 74
        '
        'dgocell_cant_teorica
        '
        Me.dgocell_cant_teorica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgocell_cant_teorica.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgocell_cant_teorica.HeaderText = "C. Ref"
        Me.dgocell_cant_teorica.Name = "dgocell_cant_teorica"
        Me.dgocell_cant_teorica.ReadOnly = True
        Me.dgocell_cant_teorica.Width = 5
        '
        'dgocell_clasificador
        '
        Me.dgocell_clasificador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_clasificador.HeaderText = "Clase"
        Me.dgocell_clasificador.Name = "dgocell_clasificador"
        Me.dgocell_clasificador.ReadOnly = True
        Me.dgocell_clasificador.Width = 58
        '
        'dgocell_info_trazabilidad
        '
        Me.dgocell_info_trazabilidad.HeaderText = "Trazabilidad"
        Me.dgocell_info_trazabilidad.Name = "dgocell_info_trazabilidad"
        Me.dgocell_info_trazabilidad.ReadOnly = True
        '
        'dgocell_docto_ref
        '
        Me.dgocell_docto_ref.HeaderText = "Doc Ref"
        Me.dgocell_docto_ref.Name = "dgocell_docto_ref"
        Me.dgocell_docto_ref.ReadOnly = True
        '
        'dgocell_costo_promedio
        '
        Me.dgocell_costo_promedio.HeaderText = "c_prom"
        Me.dgocell_costo_promedio.Name = "dgocell_costo_promedio"
        Me.dgocell_costo_promedio.ReadOnly = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 16)
        Me.Label15.TabIndex = 218
        Me.Label15.Text = "Quien Recibio:"
        '
        'lb_cod_documento
        '
        Me.lb_cod_documento.AutoSize = True
        Me.lb_cod_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_cod_documento.Location = New System.Drawing.Point(116, 66)
        Me.lb_cod_documento.Name = "lb_cod_documento"
        Me.lb_cod_documento.Size = New System.Drawing.Size(104, 16)
        Me.lb_cod_documento.TabIndex = 217
        Me.lb_cod_documento.Text = "XXX-00000000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 219
        Me.Label1.Text = "Documento: "
        '
        'cm_bodegas
        '
        Me.cm_bodegas.FormattingEnabled = True
        Me.cm_bodegas.Location = New System.Drawing.Point(118, 123)
        Me.cm_bodegas.Name = "cm_bodegas"
        Me.cm_bodegas.Size = New System.Drawing.Size(331, 21)
        Me.cm_bodegas.TabIndex = 223
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 16)
        Me.Label14.TabIndex = 222
        Me.Label14.Text = "Bodega:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(261, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Fecha:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(315, 65)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(157, 22)
        Me.dtp_fecha.TabIndex = 225
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(478, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 16)
        Me.Label3.TabIndex = 226
        Me.Label3.Text = "Usuario:"
        '
        'lb_usuario
        '
        Me.lb_usuario.AutoSize = True
        Me.lb_usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_usuario.Location = New System.Drawing.Point(537, 70)
        Me.lb_usuario.Name = "lb_usuario"
        Me.lb_usuario.Size = New System.Drawing.Size(55, 16)
        Me.lb_usuario.TabIndex = 227
        Me.lb_usuario.Text = "Usuario"
        '
        'cm_bodega_destino
        '
        Me.cm_bodega_destino.FormattingEnabled = True
        Me.cm_bodega_destino.Location = New System.Drawing.Point(570, 123)
        Me.cm_bodega_destino.Name = "cm_bodega_destino"
        Me.cm_bodega_destino.Size = New System.Drawing.Size(370, 21)
        Me.cm_bodega_destino.TabIndex = 229
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(455, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 16)
        Me.Label4.TabIndex = 228
        Me.Label4.Text = "Bodega Destino:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(60, 480)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 16)
        Me.Label11.TabIndex = 231
        Me.Label11.Text = "Registro:"
        '
        'tx_registro_seleccionado
        '
        Me.tx_registro_seleccionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_registro_seleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_registro_seleccionado.Location = New System.Drawing.Point(128, 476)
        Me.tx_registro_seleccionado.MaxLength = 30
        Me.tx_registro_seleccionado.Name = "tx_registro_seleccionado"
        Me.tx_registro_seleccionado.ReadOnly = True
        Me.tx_registro_seleccionado.Size = New System.Drawing.Size(44, 22)
        Me.tx_registro_seleccionado.TabIndex = 230
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.bt_nueva_nota)
        Me.GroupBox2.Controls.Add(Me.bt_consultar_notas)
        Me.GroupBox2.Controls.Add(Me.lb_total_notas)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(693, 441)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 76)
        Me.GroupBox2.TabIndex = 232
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seguimientos / Notas:"
        '
        'bt_nueva_nota
        '
        Me.bt_nueva_nota.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nueva_nota.Image = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_nueva_nota.Location = New System.Drawing.Point(6, 19)
        Me.bt_nueva_nota.Name = "bt_nueva_nota"
        Me.bt_nueva_nota.Size = New System.Drawing.Size(50, 51)
        Me.bt_nueva_nota.TabIndex = 170
        Me.bt_nueva_nota.UseVisualStyleBackColor = True
        '
        'bt_consultar_notas
        '
        Me.bt_consultar_notas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_consultar_notas.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_consultar_notas.Location = New System.Drawing.Point(62, 19)
        Me.bt_consultar_notas.Name = "bt_consultar_notas"
        Me.bt_consultar_notas.Size = New System.Drawing.Size(50, 51)
        Me.bt_consultar_notas.TabIndex = 171
        Me.bt_consultar_notas.UseVisualStyleBackColor = True
        '
        'lb_total_notas
        '
        Me.lb_total_notas.AutoSize = True
        Me.lb_total_notas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_notas.Location = New System.Drawing.Point(201, 35)
        Me.lb_total_notas.Name = "lb_total_notas"
        Me.lb_total_notas.Size = New System.Drawing.Size(29, 31)
        Me.lb_total_notas.TabIndex = 172
        Me.lb_total_notas.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(118, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 20)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "Total"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(118, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 20)
        Me.Label17.TabIndex = 174
        Me.Label17.Text = "Registros:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 16)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Documento CG:"
        '
        'tx_docto_contable
        '
        Me.tx_docto_contable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_docto_contable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_docto_contable.Location = New System.Drawing.Point(118, 92)
        Me.tx_docto_contable.MaxLength = 30
        Me.tx_docto_contable.Name = "tx_docto_contable"
        Me.tx_docto_contable.Size = New System.Drawing.Size(138, 22)
        Me.tx_docto_contable.TabIndex = 240
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(260, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 16)
        Me.Label6.TabIndex = 243
        Me.Label6.Text = "Documento Origen:"
        '
        'tx_docto_origen
        '
        Me.tx_docto_origen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_docto_origen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_docto_origen.Location = New System.Drawing.Point(389, 92)
        Me.tx_docto_origen.MaxLength = 30
        Me.tx_docto_origen.Name = "tx_docto_origen"
        Me.tx_docto_origen.ReadOnly = True
        Me.tx_docto_origen.Size = New System.Drawing.Size(138, 22)
        Me.tx_docto_origen.TabIndex = 242
        '
        'bt_genmov_apartir_solalm
        '
        Me.bt_genmov_apartir_solalm.Location = New System.Drawing.Point(569, 91)
        Me.bt_genmov_apartir_solalm.Name = "bt_genmov_apartir_solalm"
        Me.bt_genmov_apartir_solalm.Size = New System.Drawing.Size(138, 29)
        Me.bt_genmov_apartir_solalm.TabIndex = 244
        Me.bt_genmov_apartir_solalm.Text = "Solicitudes Pendientes"
        Me.bt_genmov_apartir_solalm.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 16)
        Me.Label7.TabIndex = 245
        Me.Label7.Text = "Insumos:"
        '
        'cm_recibio
        '
        Me.cm_recibio.FormattingEnabled = True
        Me.cm_recibio.Location = New System.Drawing.Point(118, 148)
        Me.cm_recibio.Name = "cm_recibio"
        Me.cm_recibio.Size = New System.Drawing.Size(331, 21)
        Me.cm_recibio.TabIndex = 246
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(568, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 16)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "Valor Absoluto:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(568, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 249
        Me.Label9.Text = "Valor Total:"
        '
        'lb_costo_total
        '
        Me.lb_costo_total.AutoSize = True
        Me.lb_costo_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_costo_total.Location = New System.Drawing.Point(670, 171)
        Me.lb_costo_total.Name = "lb_costo_total"
        Me.lb_costo_total.Size = New System.Drawing.Size(25, 16)
        Me.lb_costo_total.TabIndex = 251
        Me.lb_costo_total.Text = "$ 0"
        '
        'lb_costo_absoluto
        '
        Me.lb_costo_absoluto.AutoSize = True
        Me.lb_costo_absoluto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_costo_absoluto.Location = New System.Drawing.Point(670, 153)
        Me.lb_costo_absoluto.Name = "lb_costo_absoluto"
        Me.lb_costo_absoluto.Size = New System.Drawing.Size(25, 16)
        Me.lb_costo_absoluto.TabIndex = 250
        Me.lb_costo_absoluto.Text = "$ 0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(69, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Ctrl+A"
        '
        'fm_0300_doc_movimientos_inventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(964, 525)
        Me.Controls.Add(Me.lb_costo_total)
        Me.Controls.Add(Me.lb_costo_absoluto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cm_recibio)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.bt_genmov_apartir_solalm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tx_docto_origen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_docto_contable)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tx_registro_seleccionado)
        Me.Controls.Add(Me.cm_bodega_destino)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lb_usuario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cm_bodegas)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lb_cod_documento)
        Me.Controls.Add(Me.dg_items)
        Me.Name = "fm_0300_doc_movimientos_inventarios"
        Me.Text = "Movimiento de Inventarios"
        Me.Controls.SetChildIndex(Me.dg_items, 0)
        Me.Controls.SetChildIndex(Me.lb_cod_documento, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.cm_bodegas, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lb_usuario, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cm_bodega_destino, 0)
        Me.Controls.SetChildIndex(Me.tx_registro_seleccionado, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.tx_docto_contable, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_docto_origen, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.bt_genmov_apartir_solalm, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cm_recibio, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.lb_costo_absoluto, 0)
        Me.Controls.SetChildIndex(Me.lb_costo_total, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_items As System.Windows.Forms.DataGridView
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lb_cod_documento As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cm_bodegas As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lb_usuario As System.Windows.Forms.Label
    Friend WithEvents cm_bodega_destino As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tx_registro_seleccionado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_nueva_nota As System.Windows.Forms.Button
    Friend WithEvents bt_consultar_notas As System.Windows.Forms.Button
    Friend WithEvents lb_total_notas As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_docto_contable As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tx_docto_origen As TextBox
    Friend WithEvents bt_genmov_apartir_solalm As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cm_recibio As ComboBox
    Friend WithEvents dgocell_ident_doc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_tipo_mov As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nombre_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unidad_med As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cant_movimiento As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cant_teorica As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_clasificador As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_info_trazabilidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_docto_ref As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_promedio As DataGridViewTextBoxColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lb_costo_total As Label
    Friend WithEvents lb_costo_absoluto As Label
    Friend WithEvents Label10 As Label
End Class
