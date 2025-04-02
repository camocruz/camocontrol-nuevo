<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_asignacion_elemetos_personal_encabezado
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lb_costo_total = New System.Windows.Forms.Label()
        Me.lb_costo_absoluto = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cm_recibio = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lb_usuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cm_bodegas = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lb_cod_documento = New System.Windows.Forms.Label()
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
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(771, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(869, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(870, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2023/05/24"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(463, 32)
        Me.lb_titulo.Text = "Asignacion de Elementos al Personal"
        '
        'lb_costo_total
        '
        Me.lb_costo_total.AutoSize = True
        Me.lb_costo_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_costo_total.Location = New System.Drawing.Point(671, 136)
        Me.lb_costo_total.Name = "lb_costo_total"
        Me.lb_costo_total.Size = New System.Drawing.Size(25, 16)
        Me.lb_costo_total.TabIndex = 274
        Me.lb_costo_total.Text = "$ 0"
        '
        'lb_costo_absoluto
        '
        Me.lb_costo_absoluto.AutoSize = True
        Me.lb_costo_absoluto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_costo_absoluto.Location = New System.Drawing.Point(671, 118)
        Me.lb_costo_absoluto.Name = "lb_costo_absoluto"
        Me.lb_costo_absoluto.Size = New System.Drawing.Size(25, 16)
        Me.lb_costo_absoluto.TabIndex = 273
        Me.lb_costo_absoluto.Text = "$ 0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(569, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 272
        Me.Label9.Text = "Valor Total:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(569, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 16)
        Me.Label8.TabIndex = 271
        Me.Label8.Text = "Valor Absoluto:"
        '
        'cm_recibio
        '
        Me.cm_recibio.FormattingEnabled = True
        Me.cm_recibio.Location = New System.Drawing.Point(119, 113)
        Me.cm_recibio.Name = "cm_recibio"
        Me.cm_recibio.Size = New System.Drawing.Size(331, 21)
        Me.cm_recibio.TabIndex = 270
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 16)
        Me.Label7.TabIndex = 269
        Me.Label7.Text = "Insumos:"
        '
        'lb_usuario
        '
        Me.lb_usuario.AutoSize = True
        Me.lb_usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_usuario.Location = New System.Drawing.Point(539, 65)
        Me.lb_usuario.Name = "lb_usuario"
        Me.lb_usuario.Size = New System.Drawing.Size(55, 16)
        Me.lb_usuario.TabIndex = 261
        Me.lb_usuario.Text = "Usuario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(480, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 16)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Usuario:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(317, 60)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(157, 22)
        Me.dtp_fecha.TabIndex = 259
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(263, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Fecha:"
        '
        'cm_bodegas
        '
        Me.cm_bodegas.FormattingEnabled = True
        Me.cm_bodegas.Location = New System.Drawing.Point(119, 88)
        Me.cm_bodegas.Name = "cm_bodegas"
        Me.cm_bodegas.Size = New System.Drawing.Size(331, 21)
        Me.cm_bodegas.TabIndex = 257
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(14, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 16)
        Me.Label14.TabIndex = 256
        Me.Label14.Text = "Bodega:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Documento: "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 114)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 16)
        Me.Label15.TabIndex = 254
        Me.Label15.Text = "Quien Recibio:"
        '
        'lb_cod_documento
        '
        Me.lb_cod_documento.AutoSize = True
        Me.lb_cod_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_cod_documento.Location = New System.Drawing.Point(118, 61)
        Me.lb_cod_documento.Name = "lb_cod_documento"
        Me.lb_cod_documento.Size = New System.Drawing.Size(104, 16)
        Me.lb_cod_documento.TabIndex = 253
        Me.lb_cod_documento.Text = "XXX-00000000"
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
        Me.dg_items.Location = New System.Drawing.Point(18, 155)
        Me.dg_items.Name = "dg_items"
        Me.dg_items.ReadOnly = True
        Me.dg_items.Size = New System.Drawing.Size(923, 249)
        Me.dg_items.TabIndex = 252
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
        'fm_0300_asignacion_elemetos_personal_encabezado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(956, 488)
        Me.Controls.Add(Me.lb_costo_total)
        Me.Controls.Add(Me.lb_costo_absoluto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cm_recibio)
        Me.Controls.Add(Me.Label7)
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
        Me.Name = "fm_0300_asignacion_elemetos_personal_encabezado"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
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
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cm_recibio, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.lb_costo_absoluto, 0)
        Me.Controls.SetChildIndex(Me.lb_costo_total, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lb_costo_total As Label
    Friend WithEvents lb_costo_absoluto As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cm_recibio As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lb_usuario As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents cm_bodegas As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lb_cod_documento As Label
    Friend WithEvents dg_items As DataGridView
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
End Class
