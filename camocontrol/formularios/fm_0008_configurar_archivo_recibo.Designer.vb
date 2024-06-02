<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0008_configurar_archivo_recibo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_descripcion = New System.Windows.Forms.TextBox()
        Me.tx_columnas_archivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_identificador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_col_verificacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_long_verificacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_col_fecha = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_col_transaccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_col_oficina = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_col_documento = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_col_credito = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tx_col_efectivo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tx_col_cheque = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tx_col_nit = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tx_col_cliente = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tx_id_config = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cm_banco = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.bt_leer_archivo = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.cm_format_fecha = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dg_tipos_transacciones = New System.Windows.Forms.DataGridView()
        Me.dgocell_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.bt_nuevo_tipo = New System.Windows.Forms.Button()
        Me.chk_convenio = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_tipos_transacciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(654, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(752, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(753, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/09/28"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(293, 32)
        Me.lb_titulo.Text = "Configuracion Archivo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(252, 450)
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 519)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 18)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Descripción:"
        '
        'tx_descripcion
        '
        Me.tx_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_descripcion.Location = New System.Drawing.Point(183, 61)
        Me.tx_descripcion.Name = "tx_descripcion"
        Me.tx_descripcion.Size = New System.Drawing.Size(476, 24)
        Me.tx_descripcion.TabIndex = 63
        '
        'tx_columnas_archivo
        '
        Me.tx_columnas_archivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_columnas_archivo.Location = New System.Drawing.Point(183, 115)
        Me.tx_columnas_archivo.Name = "tx_columnas_archivo"
        Me.tx_columnas_archivo.Size = New System.Drawing.Size(53, 24)
        Me.tx_columnas_archivo.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 18)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Columnas Archivo:"
        '
        'tx_identificador
        '
        Me.tx_identificador.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_identificador.Location = New System.Drawing.Point(183, 141)
        Me.tx_identificador.Name = "tx_identificador"
        Me.tx_identificador.Size = New System.Drawing.Size(53, 24)
        Me.tx_identificador.TabIndex = 67
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 18)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Identificador Columnas:"
        '
        'tx_col_verificacion
        '
        Me.tx_col_verificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_verificacion.Location = New System.Drawing.Point(183, 167)
        Me.tx_col_verificacion.Name = "tx_col_verificacion"
        Me.tx_col_verificacion.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_verificacion.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 18)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Columna Verificacion:"
        '
        'tx_long_verificacion
        '
        Me.tx_long_verificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_long_verificacion.Location = New System.Drawing.Point(183, 193)
        Me.tx_long_verificacion.Name = "tx_long_verificacion"
        Me.tx_long_verificacion.Size = New System.Drawing.Size(53, 24)
        Me.tx_long_verificacion.TabIndex = 71
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 18)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Longitud Verificacion:"
        '
        'tx_col_fecha
        '
        Me.tx_col_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_fecha.Location = New System.Drawing.Point(183, 218)
        Me.tx_col_fecha.Name = "tx_col_fecha"
        Me.tx_col_fecha.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_fecha.TabIndex = 73
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 221)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 18)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "Columna Fecha:"
        '
        'tx_col_transaccion
        '
        Me.tx_col_transaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_transaccion.Location = New System.Drawing.Point(183, 267)
        Me.tx_col_transaccion.Name = "tx_col_transaccion"
        Me.tx_col_transaccion.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_transaccion.TabIndex = 75
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(158, 18)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Columna Transaccion:"
        '
        'tx_col_oficina
        '
        Me.tx_col_oficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_oficina.Location = New System.Drawing.Point(392, 115)
        Me.tx_col_oficina.Name = "tx_col_oficina"
        Me.tx_col_oficina.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_oficina.TabIndex = 77
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(258, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 18)
        Me.Label8.TabIndex = 76
        Me.Label8.Text = "Columna Oficina:"
        '
        'tx_col_documento
        '
        Me.tx_col_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_documento.Location = New System.Drawing.Point(183, 293)
        Me.tx_col_documento.Name = "tx_col_documento"
        Me.tx_col_documento.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_documento.TabIndex = 81
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 296)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 18)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Columna Documento:"
        '
        'tx_col_credito
        '
        Me.tx_col_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_credito.Location = New System.Drawing.Point(392, 141)
        Me.tx_col_credito.Name = "tx_col_credito"
        Me.tx_col_credito.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_credito.TabIndex = 83
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(259, 144)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 18)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "Columna Credito:"
        '
        'tx_col_efectivo
        '
        Me.tx_col_efectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_efectivo.Location = New System.Drawing.Point(392, 167)
        Me.tx_col_efectivo.Name = "tx_col_efectivo"
        Me.tx_col_efectivo.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_efectivo.TabIndex = 85
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(259, 170)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 18)
        Me.Label12.TabIndex = 84
        Me.Label12.Text = "Columna Efectivo:"
        '
        'tx_col_cheque
        '
        Me.tx_col_cheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_cheque.Location = New System.Drawing.Point(392, 193)
        Me.tx_col_cheque.Name = "tx_col_cheque"
        Me.tx_col_cheque.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_cheque.TabIndex = 87
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(259, 196)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 18)
        Me.Label13.TabIndex = 86
        Me.Label13.Text = "Columna Cheque:"
        '
        'tx_col_nit
        '
        Me.tx_col_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_nit.Location = New System.Drawing.Point(392, 218)
        Me.tx_col_nit.Name = "tx_col_nit"
        Me.tx_col_nit.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_nit.TabIndex = 89
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(259, 221)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 18)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Columna NIT:"
        '
        'tx_col_cliente
        '
        Me.tx_col_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_col_cliente.Location = New System.Drawing.Point(392, 244)
        Me.tx_col_cliente.Name = "tx_col_cliente"
        Me.tx_col_cliente.Size = New System.Drawing.Size(53, 24)
        Me.tx_col_cliente.TabIndex = 91
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(259, 247)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 18)
        Me.Label15.TabIndex = 90
        Me.Label15.Text = "Columna Cliente:"
        '
        'tx_id_config
        '
        Me.tx_id_config.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_config.Location = New System.Drawing.Point(774, 61)
        Me.tx_id_config.Name = "tx_id_config"
        Me.tx_id_config.Size = New System.Drawing.Size(53, 24)
        Me.tx_id_config.TabIndex = 93
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(692, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 18)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Id Archivo:"
        '
        'cm_banco
        '
        Me.cm_banco.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_banco.FormattingEnabled = True
        Me.cm_banco.Location = New System.Drawing.Point(183, 87)
        Me.cm_banco.Name = "cm_banco"
        Me.cm_banco.Size = New System.Drawing.Size(550, 26)
        Me.cm_banco.TabIndex = 94
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 18)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Banco:"
        '
        'bt_leer_archivo
        '
        Me.bt_leer_archivo.Location = New System.Drawing.Point(750, 90)
        Me.bt_leer_archivo.Name = "bt_leer_archivo"
        Me.bt_leer_archivo.Size = New System.Drawing.Size(75, 23)
        Me.bt_leer_archivo.TabIndex = 96
        Me.bt_leer_archivo.Text = "Archivo"
        Me.bt_leer_archivo.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(451, 115)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(376, 202)
        Me.RichTextBox1.TabIndex = 97
        Me.RichTextBox1.Text = ""
        '
        'cm_format_fecha
        '
        Me.cm_format_fecha.FormattingEnabled = True
        Me.cm_format_fecha.Items.AddRange(New Object() {"mm/dd", "dd/mm/aaaa", "aaaa/mm/dd", "aaaammdd", "ddmmaaaa"})
        Me.cm_format_fecha.Location = New System.Drawing.Point(147, 244)
        Me.cm_format_fecha.Name = "cm_format_fecha"
        Me.cm_format_fecha.Size = New System.Drawing.Size(89, 21)
        Me.cm_format_fecha.TabIndex = 98
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(14, 244)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 18)
        Me.Label17.TabIndex = 99
        Me.Label17.Text = "Formato Fecha:"
        '
        'dg_tipos_transacciones
        '
        Me.dg_tipos_transacciones.AllowUserToAddRows = False
        Me.dg_tipos_transacciones.AllowUserToDeleteRows = False
        Me.dg_tipos_transacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_tipos_transacciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id, Me.dgocell_tipo})
        Me.dg_tipos_transacciones.Location = New System.Drawing.Point(183, 323)
        Me.dg_tipos_transacciones.Name = "dg_tipos_transacciones"
        Me.dg_tipos_transacciones.ReadOnly = True
        Me.dg_tipos_transacciones.Size = New System.Drawing.Size(642, 121)
        Me.dg_tipos_transacciones.TabIndex = 100
        '
        'dgocell_id
        '
        Me.dgocell_id.HeaderText = "Id"
        Me.dgocell_id.Name = "dgocell_id"
        Me.dgocell_id.ReadOnly = True
        Me.dgocell_id.Width = 50
        '
        'dgocell_tipo
        '
        Me.dgocell_tipo.HeaderText = "Tipo"
        Me.dgocell_tipo.Name = "dgocell_tipo"
        Me.dgocell_tipo.ReadOnly = True
        Me.dgocell_tipo.Width = 300
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(14, 323)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(151, 18)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "Tipos Transacciones:"
        '
        'bt_nuevo_tipo
        '
        Me.bt_nuevo_tipo.Location = New System.Drawing.Point(29, 374)
        Me.bt_nuevo_tipo.Name = "bt_nuevo_tipo"
        Me.bt_nuevo_tipo.Size = New System.Drawing.Size(118, 45)
        Me.bt_nuevo_tipo.TabIndex = 102
        Me.bt_nuevo_tipo.Text = "Agregar tipo"
        Me.bt_nuevo_tipo.UseVisualStyleBackColor = True
        '
        'chk_convenio
        '
        Me.chk_convenio.AutoSize = True
        Me.chk_convenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_convenio.Location = New System.Drawing.Point(262, 274)
        Me.chk_convenio.Name = "chk_convenio"
        Me.chk_convenio.Size = New System.Drawing.Size(189, 37)
        Me.chk_convenio.TabIndex = 103
        Me.chk_convenio.Text = "CONVENIO"
        Me.chk_convenio.UseVisualStyleBackColor = True
        '
        'fm_0008_configurar_archivo_recibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(839, 533)
        Me.Controls.Add(Me.chk_convenio)
        Me.Controls.Add(Me.bt_nuevo_tipo)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dg_tipos_transacciones)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cm_format_fecha)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.bt_leer_archivo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cm_banco)
        Me.Controls.Add(Me.tx_id_config)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_col_cliente)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tx_col_nit)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tx_col_cheque)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tx_col_efectivo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tx_col_credito)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tx_col_documento)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tx_col_oficina)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tx_col_transaccion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_col_fecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tx_long_verificacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_col_verificacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_identificador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_columnas_archivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_descripcion)
        Me.Controls.Add(Me.Label1)
        Me.Name = "fm_0008_configurar_archivo_recibo"
        Me.Text = "Configuracion de archivo recibo consignacion"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_descripcion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_columnas_archivo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_identificador, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tx_col_verificacion, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_long_verificacion, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_col_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_col_transaccion, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_col_oficina, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.tx_col_documento, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_col_credito, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.tx_col_efectivo, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_col_cheque, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.tx_col_nit, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.tx_col_cliente, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_id_config, 0)
        Me.Controls.SetChildIndex(Me.cm_banco, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.bt_leer_archivo, 0)
        Me.Controls.SetChildIndex(Me.RichTextBox1, 0)
        Me.Controls.SetChildIndex(Me.cm_format_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.dg_tipos_transacciones, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.bt_nuevo_tipo, 0)
        Me.Controls.SetChildIndex(Me.chk_convenio, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_tipos_transacciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents tx_columnas_archivo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_identificador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tx_col_verificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_long_verificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_col_fecha As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tx_col_transaccion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tx_col_oficina As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tx_col_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tx_col_credito As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tx_col_efectivo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tx_col_cheque As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tx_col_nit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tx_col_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tx_id_config As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cm_banco As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents bt_leer_archivo As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents cm_format_fecha As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dg_tipos_transacciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dgocell_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_nuevo_tipo As System.Windows.Forms.Button
    Friend WithEvents chk_convenio As System.Windows.Forms.CheckBox

End Class
