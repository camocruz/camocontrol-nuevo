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
        Me.dgocell_ident_doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_tipo_mov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ref_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nombre_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unidad_med = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cant_movimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cant_teorica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_clasificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_info_trazabilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_docto_ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_promedio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(1168, 9)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(1316, 14)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(1317, 55)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2016/04/29"
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(527, 51)
        Me.lb_titulo.Text = "Movimiento de Inventarios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(315, 694)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 8, 6, 8)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 789)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
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
        Me.dg_items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_ident_doc, Me.dgocell_tipo_mov, Me.dgocell_id_item, Me.dgocell_ref_item, Me.dgocell_nombre_item, Me.dgocell_unidad_med, Me.dgocell_cant_movimiento, Me.dgocell_cant_teorica, Me.dgocell_clasificador, Me.dgocell_info_trazabilidad, Me.dgocell_docto_ref, Me.dgocell_costo_promedio})
        Me.dg_items.Location = New System.Drawing.Point(26, 292)
        Me.dg_items.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dg_items.Name = "dg_items"
        Me.dg_items.ReadOnly = True
        Me.dg_items.RowHeadersWidth = 62
        Me.dg_items.Size = New System.Drawing.Size(1408, 378)
        Me.dg_items.TabIndex = 62
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(20, 229)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(140, 25)
        Me.Label15.TabIndex = 218
        Me.Label15.Text = "Quien Recibio:"
        '
        'lb_cod_documento
        '
        Me.lb_cod_documento.AutoSize = True
        Me.lb_cod_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_cod_documento.Location = New System.Drawing.Point(174, 102)
        Me.lb_cod_documento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_cod_documento.Name = "lb_cod_documento"
        Me.lb_cod_documento.Size = New System.Drawing.Size(161, 25)
        Me.lb_cod_documento.TabIndex = 217
        Me.lb_cod_documento.Text = "XXX-00000000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 102)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 25)
        Me.Label1.TabIndex = 219
        Me.Label1.Text = "Documento: "
        '
        'cm_bodegas
        '
        Me.cm_bodegas.FormattingEnabled = True
        Me.cm_bodegas.Location = New System.Drawing.Point(177, 189)
        Me.cm_bodegas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_bodegas.Name = "cm_bodegas"
        Me.cm_bodegas.Size = New System.Drawing.Size(494, 28)
        Me.cm_bodegas.TabIndex = 223
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(20, 197)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 25)
        Me.Label14.TabIndex = 222
        Me.Label14.Text = "Bodega:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(392, 109)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 25)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Fecha:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(472, 100)
        Me.dtp_fecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(234, 30)
        Me.dtp_fecha.TabIndex = 225
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(717, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 25)
        Me.Label3.TabIndex = 226
        Me.Label3.Text = "Usuario:"
        '
        'lb_usuario
        '
        Me.lb_usuario.AutoSize = True
        Me.lb_usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_usuario.Location = New System.Drawing.Point(806, 108)
        Me.lb_usuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_usuario.Name = "lb_usuario"
        Me.lb_usuario.Size = New System.Drawing.Size(79, 25)
        Me.lb_usuario.TabIndex = 227
        Me.lb_usuario.Text = "Usuario"
        '
        'cm_bodega_destino
        '
        Me.cm_bodega_destino.FormattingEnabled = True
        Me.cm_bodega_destino.Location = New System.Drawing.Point(855, 189)
        Me.cm_bodega_destino.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_bodega_destino.Name = "cm_bodega_destino"
        Me.cm_bodega_destino.Size = New System.Drawing.Size(553, 28)
        Me.cm_bodega_destino.TabIndex = 229
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(682, 197)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(157, 25)
        Me.Label4.TabIndex = 228
        Me.Label4.Text = "Bodega Destino:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(90, 738)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 25)
        Me.Label11.TabIndex = 231
        Me.Label11.Text = "Registro:"
        '
        'tx_registro_seleccionado
        '
        Me.tx_registro_seleccionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_registro_seleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_registro_seleccionado.Location = New System.Drawing.Point(192, 732)
        Me.tx_registro_seleccionado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_registro_seleccionado.MaxLength = 30
        Me.tx_registro_seleccionado.Name = "tx_registro_seleccionado"
        Me.tx_registro_seleccionado.ReadOnly = True
        Me.tx_registro_seleccionado.Size = New System.Drawing.Size(64, 30)
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
        Me.GroupBox2.Location = New System.Drawing.Point(1040, 678)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(372, 117)
        Me.GroupBox2.TabIndex = 232
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seguimientos / Notas:"
        '
        'bt_nueva_nota
        '
        Me.bt_nueva_nota.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nueva_nota.Image = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_nueva_nota.Location = New System.Drawing.Point(9, 29)
        Me.bt_nueva_nota.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_nueva_nota.Name = "bt_nueva_nota"
        Me.bt_nueva_nota.Size = New System.Drawing.Size(75, 78)
        Me.bt_nueva_nota.TabIndex = 170
        Me.bt_nueva_nota.UseVisualStyleBackColor = True
        '
        'bt_consultar_notas
        '
        Me.bt_consultar_notas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_consultar_notas.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_consultar_notas.Location = New System.Drawing.Point(93, 29)
        Me.bt_consultar_notas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_consultar_notas.Name = "bt_consultar_notas"
        Me.bt_consultar_notas.Size = New System.Drawing.Size(75, 78)
        Me.bt_consultar_notas.TabIndex = 171
        Me.bt_consultar_notas.UseVisualStyleBackColor = True
        '
        'lb_total_notas
        '
        Me.lb_total_notas.AutoSize = True
        Me.lb_total_notas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_notas.Location = New System.Drawing.Point(302, 54)
        Me.lb_total_notas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_total_notas.Name = "lb_total_notas"
        Me.lb_total_notas.Size = New System.Drawing.Size(43, 47)
        Me.lb_total_notas.TabIndex = 172
        Me.lb_total_notas.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(177, 40)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 29)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "Total"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(177, 71)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 29)
        Me.Label17.TabIndex = 174
        Me.Label17.Text = "Registros:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 146)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 25)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Documento CG:"
        '
        'tx_docto_contable
        '
        Me.tx_docto_contable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_docto_contable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_docto_contable.Location = New System.Drawing.Point(177, 142)
        Me.tx_docto_contable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_docto_contable.MaxLength = 30
        Me.tx_docto_contable.Name = "tx_docto_contable"
        Me.tx_docto_contable.Size = New System.Drawing.Size(205, 30)
        Me.tx_docto_contable.TabIndex = 240
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(390, 146)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(182, 25)
        Me.Label6.TabIndex = 243
        Me.Label6.Text = "Documento Origen:"
        '
        'tx_docto_origen
        '
        Me.tx_docto_origen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_docto_origen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_docto_origen.Location = New System.Drawing.Point(584, 142)
        Me.tx_docto_origen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_docto_origen.MaxLength = 30
        Me.tx_docto_origen.Name = "tx_docto_origen"
        Me.tx_docto_origen.ReadOnly = True
        Me.tx_docto_origen.Size = New System.Drawing.Size(205, 30)
        Me.tx_docto_origen.TabIndex = 242
        '
        'bt_genmov_apartir_solalm
        '
        Me.bt_genmov_apartir_solalm.Location = New System.Drawing.Point(854, 140)
        Me.bt_genmov_apartir_solalm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_genmov_apartir_solalm.Name = "bt_genmov_apartir_solalm"
        Me.bt_genmov_apartir_solalm.Size = New System.Drawing.Size(207, 45)
        Me.bt_genmov_apartir_solalm.TabIndex = 244
        Me.bt_genmov_apartir_solalm.Text = "Solicitudes Pendientes"
        Me.bt_genmov_apartir_solalm.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 263)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 25)
        Me.Label7.TabIndex = 245
        Me.Label7.Text = "Insumos:"
        '
        'cm_recibio
        '
        Me.cm_recibio.FormattingEnabled = True
        Me.cm_recibio.Location = New System.Drawing.Point(177, 228)
        Me.cm_recibio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_recibio.Name = "cm_recibio"
        Me.cm_recibio.Size = New System.Drawing.Size(494, 28)
        Me.cm_recibio.TabIndex = 246
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(852, 235)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 25)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "Valor Absoluto:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(852, 263)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 25)
        Me.Label9.TabIndex = 249
        Me.Label9.Text = "Valor Total:"
        '
        'lb_costo_total
        '
        Me.lb_costo_total.AutoSize = True
        Me.lb_costo_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_costo_total.Location = New System.Drawing.Point(1005, 263)
        Me.lb_costo_total.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_costo_total.Name = "lb_costo_total"
        Me.lb_costo_total.Size = New System.Drawing.Size(39, 25)
        Me.lb_costo_total.TabIndex = 251
        Me.lb_costo_total.Text = "$ 0"
        '
        'lb_costo_absoluto
        '
        Me.lb_costo_absoluto.AutoSize = True
        Me.lb_costo_absoluto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_costo_absoluto.Location = New System.Drawing.Point(1005, 235)
        Me.lb_costo_absoluto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_costo_absoluto.Name = "lb_costo_absoluto"
        Me.lb_costo_absoluto.Size = New System.Drawing.Size(39, 25)
        Me.lb_costo_absoluto.TabIndex = 250
        Me.lb_costo_absoluto.Text = "$ 0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(104, 0)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 20)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Ctrl+A"
        '
        'dgocell_ident_doc
        '
        Me.dgocell_ident_doc.HeaderText = "id"
        Me.dgocell_ident_doc.MinimumWidth = 8
        Me.dgocell_ident_doc.Name = "dgocell_ident_doc"
        Me.dgocell_ident_doc.ReadOnly = True
        Me.dgocell_ident_doc.Width = 30
        '
        'dgocell_tipo_mov
        '
        Me.dgocell_tipo_mov.HeaderText = "T"
        Me.dgocell_tipo_mov.MinimumWidth = 8
        Me.dgocell_tipo_mov.Name = "dgocell_tipo_mov"
        Me.dgocell_tipo_mov.ReadOnly = True
        Me.dgocell_tipo_mov.Width = 20
        '
        'dgocell_id_item
        '
        Me.dgocell_id_item.HeaderText = "Id-Item"
        Me.dgocell_id_item.MinimumWidth = 8
        Me.dgocell_id_item.Name = "dgocell_id_item"
        Me.dgocell_id_item.ReadOnly = True
        Me.dgocell_id_item.Width = 50
        '
        'dgocell_ref_item
        '
        Me.dgocell_ref_item.HeaderText = "Ref"
        Me.dgocell_ref_item.MinimumWidth = 8
        Me.dgocell_ref_item.Name = "dgocell_ref_item"
        Me.dgocell_ref_item.ReadOnly = True
        Me.dgocell_ref_item.Width = 50
        '
        'dgocell_nombre_item
        '
        Me.dgocell_nombre_item.HeaderText = "Item"
        Me.dgocell_nombre_item.MinimumWidth = 8
        Me.dgocell_nombre_item.Name = "dgocell_nombre_item"
        Me.dgocell_nombre_item.ReadOnly = True
        Me.dgocell_nombre_item.Width = 300
        '
        'dgocell_unidad_med
        '
        Me.dgocell_unidad_med.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_unidad_med.HeaderText = "Unidad"
        Me.dgocell_unidad_med.MinimumWidth = 8
        Me.dgocell_unidad_med.Name = "dgocell_unidad_med"
        Me.dgocell_unidad_med.ReadOnly = True
        Me.dgocell_unidad_med.Width = 96
        '
        'dgocell_cant_movimiento
        '
        Me.dgocell_cant_movimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N4"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.dgocell_cant_movimiento.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgocell_cant_movimiento.HeaderText = "Cantidad"
        Me.dgocell_cant_movimiento.MinimumWidth = 8
        Me.dgocell_cant_movimiento.Name = "dgocell_cant_movimiento"
        Me.dgocell_cant_movimiento.ReadOnly = True
        Me.dgocell_cant_movimiento.Width = 109
        '
        'dgocell_cant_teorica
        '
        Me.dgocell_cant_teorica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgocell_cant_teorica.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgocell_cant_teorica.HeaderText = "C. Ref"
        Me.dgocell_cant_teorica.MinimumWidth = 8
        Me.dgocell_cant_teorica.Name = "dgocell_cant_teorica"
        Me.dgocell_cant_teorica.ReadOnly = True
        Me.dgocell_cant_teorica.Width = 8
        '
        'dgocell_clasificador
        '
        Me.dgocell_clasificador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_clasificador.HeaderText = "Clase"
        Me.dgocell_clasificador.MinimumWidth = 8
        Me.dgocell_clasificador.Name = "dgocell_clasificador"
        Me.dgocell_clasificador.ReadOnly = True
        Me.dgocell_clasificador.Width = 85
        '
        'dgocell_info_trazabilidad
        '
        Me.dgocell_info_trazabilidad.HeaderText = "Trazabilidad"
        Me.dgocell_info_trazabilidad.MinimumWidth = 8
        Me.dgocell_info_trazabilidad.Name = "dgocell_info_trazabilidad"
        Me.dgocell_info_trazabilidad.ReadOnly = True
        Me.dgocell_info_trazabilidad.Width = 150
        '
        'dgocell_docto_ref
        '
        Me.dgocell_docto_ref.HeaderText = "Doc Ref"
        Me.dgocell_docto_ref.MinimumWidth = 8
        Me.dgocell_docto_ref.Name = "dgocell_docto_ref"
        Me.dgocell_docto_ref.ReadOnly = True
        Me.dgocell_docto_ref.Width = 150
        '
        'dgocell_costo_promedio
        '
        Me.dgocell_costo_promedio.HeaderText = "c_prom"
        Me.dgocell_costo_promedio.MinimumWidth = 8
        Me.dgocell_costo_promedio.Name = "dgocell_costo_promedio"
        Me.dgocell_costo_promedio.ReadOnly = True
        Me.dgocell_costo_promedio.Width = 150
        '
        'fm_0300_doc_movimientos_inventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1446, 808)
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
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
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
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lb_costo_total As Label
    Friend WithEvents lb_costo_absoluto As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dgocell_ident_doc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_tipo_mov As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ref_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nombre_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unidad_med As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cant_movimiento As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cant_teorica As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_clasificador As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_info_trazabilidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_docto_ref As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_promedio As DataGridViewTextBoxColumn
End Class
