<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0200_tercero
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
        Me.lb_identificacion = New System.Windows.Forms.Label()
        Me.tx_identificacion = New System.Windows.Forms.TextBox()
        Me.tx_nombre = New System.Windows.Forms.TextBox()
        Me.lb_nombre = New System.Windows.Forms.Label()
        Me.tx_1_apellido = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_2_apellido = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_id_tercero = New System.Windows.Forms.TextBox()
        Me.tx_dig_verificacion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cm_tipo_identificacion = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_aspirante = New System.Windows.Forms.CheckBox()
        Me.chk_empleado = New System.Windows.Forms.CheckBox()
        Me.chk_proveedor = New System.Windows.Forms.CheckBox()
        Me.chk_cliente = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cm_identificacion = New System.Windows.Forms.ComboBox()
        Me.dg_sucursales = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_tercero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cod_sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nombre_sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ciudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cm_nombres = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lb_total_sucursales = New System.Windows.Forms.Label()
        Me.bt_nueva_sucursal = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_sucursales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(1292, 9)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(1438, 14)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(1440, 55)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2013/12/17"
        '
        'lb_titulo
        '
        Me.lb_titulo.Location = New System.Drawing.Point(130, 26)
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(337, 51)
        Me.lb_titulo.Text = "Gestion Terceros"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(322, 529)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 8, 6, 8)
        '
        'bt_grabar
        '
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 666)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'lb_identificacion
        '
        Me.lb_identificacion.AutoSize = True
        Me.lb_identificacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_identificacion.Location = New System.Drawing.Point(128, 171)
        Me.lb_identificacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_identificacion.Name = "lb_identificacion"
        Me.lb_identificacion.Size = New System.Drawing.Size(185, 23)
        Me.lb_identificacion.TabIndex = 76
        Me.lb_identificacion.Text = "Identificación / NIT :"
        '
        'tx_identificacion
        '
        Me.tx_identificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_identificacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_identificacion.Location = New System.Drawing.Point(320, 165)
        Me.tx_identificacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_identificacion.MaxLength = 20
        Me.tx_identificacion.Name = "tx_identificacion"
        Me.tx_identificacion.Size = New System.Drawing.Size(296, 30)
        Me.tx_identificacion.TabIndex = 2
        '
        'tx_nombre
        '
        Me.tx_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_nombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nombre.Location = New System.Drawing.Point(320, 371)
        Me.tx_nombre.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_nombre.MaxLength = 100
        Me.tx_nombre.Name = "tx_nombre"
        Me.tx_nombre.Size = New System.Drawing.Size(350, 30)
        Me.tx_nombre.TabIndex = 9
        '
        'lb_nombre
        '
        Me.lb_nombre.AutoSize = True
        Me.lb_nombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_nombre.Location = New System.Drawing.Point(15, 60)
        Me.lb_nombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_nombre.Name = "lb_nombre"
        Me.lb_nombre.Size = New System.Drawing.Size(233, 23)
        Me.lb_nombre.TabIndex = 72
        Me.lb_nombre.Text = "Nombres / Razon Social :"
        '
        'tx_1_apellido
        '
        Me.tx_1_apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_1_apellido.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_1_apellido.Location = New System.Drawing.Point(320, 414)
        Me.tx_1_apellido.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_1_apellido.MaxLength = 100
        Me.tx_1_apellido.Name = "tx_1_apellido"
        Me.tx_1_apellido.Size = New System.Drawing.Size(350, 30)
        Me.tx_1_apellido.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(186, 418)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 23)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "1er Apellido :"
        '
        'tx_2_apellido
        '
        Me.tx_2_apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_2_apellido.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_2_apellido.Location = New System.Drawing.Point(320, 457)
        Me.tx_2_apellido.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_2_apellido.MaxLength = 100
        Me.tx_2_apellido.Name = "tx_2_apellido"
        Me.tx_2_apellido.Size = New System.Drawing.Size(350, 30)
        Me.tx_2_apellido.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(182, 462)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 23)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "2do Apellido :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(278, 131)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 23)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "Id:"
        '
        'tx_id_tercero
        '
        Me.tx_id_tercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_tercero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_tercero.Location = New System.Drawing.Point(320, 122)
        Me.tx_id_tercero.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_id_tercero.MaxLength = 20
        Me.tx_id_tercero.Name = "tx_id_tercero"
        Me.tx_id_tercero.ReadOnly = True
        Me.tx_id_tercero.Size = New System.Drawing.Size(350, 30)
        Me.tx_id_tercero.TabIndex = 90
        '
        'tx_dig_verificacion
        '
        Me.tx_dig_verificacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_dig_verificacion.Location = New System.Drawing.Point(639, 165)
        Me.tx_dig_verificacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_dig_verificacion.MaxLength = 1
        Me.tx_dig_verificacion.Name = "tx_dig_verificacion"
        Me.tx_dig_verificacion.Size = New System.Drawing.Size(31, 30)
        Me.tx_dig_verificacion.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(618, 169)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 29)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(132, 209)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(179, 23)
        Me.Label11.TabIndex = 95
        Me.Label11.Text = "Tipo Identificación :"
        '
        'cm_tipo_identificacion
        '
        Me.cm_tipo_identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_identificacion.FormattingEnabled = True
        Me.cm_tipo_identificacion.Location = New System.Drawing.Point(320, 208)
        Me.cm_tipo_identificacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_tipo_identificacion.Name = "cm_tipo_identificacion"
        Me.cm_tipo_identificacion.Size = New System.Drawing.Size(350, 33)
        Me.cm_tipo_identificacion.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_aspirante)
        Me.GroupBox2.Controls.Add(Me.chk_empleado)
        Me.GroupBox2.Controls.Add(Me.chk_proveedor)
        Me.GroupBox2.Controls.Add(Me.chk_cliente)
        Me.GroupBox2.Location = New System.Drawing.Point(315, 243)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(357, 118)
        Me.GroupBox2.TabIndex = 96
        Me.GroupBox2.TabStop = False
        '
        'chk_aspirante
        '
        Me.chk_aspirante.AutoSize = True
        Me.chk_aspirante.Location = New System.Drawing.Point(231, 65)
        Me.chk_aspirante.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chk_aspirante.Name = "chk_aspirante"
        Me.chk_aspirante.Size = New System.Drawing.Size(103, 24)
        Me.chk_aspirante.TabIndex = 8
        Me.chk_aspirante.Text = "Aspirante"
        Me.chk_aspirante.UseVisualStyleBackColor = True
        '
        'chk_empleado
        '
        Me.chk_empleado.AutoSize = True
        Me.chk_empleado.Location = New System.Drawing.Point(231, 29)
        Me.chk_empleado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chk_empleado.Name = "chk_empleado"
        Me.chk_empleado.Size = New System.Drawing.Size(107, 24)
        Me.chk_empleado.TabIndex = 7
        Me.chk_empleado.Text = "Empleado"
        Me.chk_empleado.UseVisualStyleBackColor = True
        '
        'chk_proveedor
        '
        Me.chk_proveedor.AutoSize = True
        Me.chk_proveedor.Location = New System.Drawing.Point(9, 65)
        Me.chk_proveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chk_proveedor.Name = "chk_proveedor"
        Me.chk_proveedor.Size = New System.Drawing.Size(107, 24)
        Me.chk_proveedor.TabIndex = 6
        Me.chk_proveedor.Text = "Proveedor"
        Me.chk_proveedor.UseVisualStyleBackColor = True
        '
        'chk_cliente
        '
        Me.chk_cliente.AutoSize = True
        Me.chk_cliente.Location = New System.Drawing.Point(9, 29)
        Me.chk_cliente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chk_cliente.Name = "chk_cliente"
        Me.chk_cliente.Size = New System.Drawing.Size(84, 24)
        Me.chk_cliente.TabIndex = 5
        Me.chk_cliente.Text = "Cliente"
        Me.chk_cliente.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(250, 271)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 23)
        Me.Label12.TabIndex = 97
        Me.Label12.Text = "Tipo :"
        '
        'cm_identificacion
        '
        Me.cm_identificacion.FormattingEnabled = True
        Me.cm_identificacion.Location = New System.Drawing.Point(201, 25)
        Me.cm_identificacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_identificacion.Name = "cm_identificacion"
        Me.cm_identificacion.Size = New System.Drawing.Size(349, 28)
        Me.cm_identificacion.TabIndex = 99
        '
        'dg_sucursales
        '
        Me.dg_sucursales.AllowUserToAddRows = False
        Me.dg_sucursales.AllowUserToDeleteRows = False
        Me.dg_sucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_sucursales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_tercero, Me.dgocell_cod_sucursal, Me.dgocell_nombre_sucursal, Me.dgocell_ciudad, Me.dgocell_direccion})
        Me.dg_sucursales.Location = New System.Drawing.Point(20, 129)
        Me.dg_sucursales.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dg_sucursales.Name = "dg_sucursales"
        Me.dg_sucursales.ReadOnly = True
        Me.dg_sucursales.RowHeadersWidth = 62
        Me.dg_sucursales.Size = New System.Drawing.Size(717, 205)
        Me.dg_sucursales.TabIndex = 100
        '
        'dgocell_id_tercero
        '
        Me.dgocell_id_tercero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_id_tercero.HeaderText = "Id"
        Me.dgocell_id_tercero.MinimumWidth = 8
        Me.dgocell_id_tercero.Name = "dgocell_id_tercero"
        Me.dgocell_id_tercero.ReadOnly = True
        Me.dgocell_id_tercero.Width = 59
        '
        'dgocell_cod_sucursal
        '
        Me.dgocell_cod_sucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_cod_sucursal.HeaderText = "codigo"
        Me.dgocell_cod_sucursal.MinimumWidth = 8
        Me.dgocell_cod_sucursal.Name = "dgocell_cod_sucursal"
        Me.dgocell_cod_sucursal.ReadOnly = True
        Me.dgocell_cod_sucursal.Width = 92
        '
        'dgocell_nombre_sucursal
        '
        Me.dgocell_nombre_sucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_nombre_sucursal.HeaderText = "Sucursal"
        Me.dgocell_nombre_sucursal.MinimumWidth = 8
        Me.dgocell_nombre_sucursal.Name = "dgocell_nombre_sucursal"
        Me.dgocell_nombre_sucursal.ReadOnly = True
        Me.dgocell_nombre_sucursal.Width = 107
        '
        'dgocell_ciudad
        '
        Me.dgocell_ciudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_ciudad.HeaderText = "Ciudad"
        Me.dgocell_ciudad.MinimumWidth = 8
        Me.dgocell_ciudad.Name = "dgocell_ciudad"
        Me.dgocell_ciudad.ReadOnly = True
        Me.dgocell_ciudad.Width = 95
        '
        'dgocell_direccion
        '
        Me.dgocell_direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_direccion.HeaderText = "Direccion"
        Me.dgocell_direccion.MinimumWidth = 8
        Me.dgocell_direccion.Name = "dgocell_direccion"
        Me.dgocell_direccion.ReadOnly = True
        Me.dgocell_direccion.Width = 111
        '
        'cm_nombres
        '
        Me.cm_nombres.FormattingEnabled = True
        Me.cm_nombres.Location = New System.Drawing.Point(20, 89)
        Me.cm_nombres.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_nombres.Name = "cm_nombres"
        Me.cm_nombres.Size = New System.Drawing.Size(715, 28)
        Me.cm_nombres.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 23)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Identificación / NIT :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lb_total_sucursales)
        Me.GroupBox3.Controls.Add(Me.bt_nueva_sucursal)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cm_nombres)
        Me.GroupBox3.Controls.Add(Me.dg_sucursales)
        Me.GroupBox3.Controls.Add(Me.cm_identificacion)
        Me.GroupBox3.Controls.Add(Me.lb_nombre)
        Me.GroupBox3.Location = New System.Drawing.Point(704, 122)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(758, 411)
        Me.GroupBox3.TabIndex = 103
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar Tercero"
        '
        'lb_total_sucursales
        '
        Me.lb_total_sucursales.AutoSize = True
        Me.lb_total_sucursales.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_sucursales.Location = New System.Drawing.Point(15, 338)
        Me.lb_total_sucursales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_total_sucursales.Name = "lb_total_sucursales"
        Me.lb_total_sucursales.Size = New System.Drawing.Size(111, 23)
        Me.lb_total_sucursales.TabIndex = 104
        Me.lb_total_sucursales.Text = "0 Registros"
        '
        'bt_nueva_sucursal
        '
        Me.bt_nueva_sucursal.Location = New System.Drawing.Point(308, 343)
        Me.bt_nueva_sucursal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_nueva_sucursal.Name = "bt_nueva_sucursal"
        Me.bt_nueva_sucursal.Size = New System.Drawing.Size(156, 45)
        Me.bt_nueva_sucursal.TabIndex = 103
        Me.bt_nueva_sucursal.Text = "Nueva Sucursal"
        Me.bt_nueva_sucursal.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(75, 371)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(233, 23)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Nombres / Razon Social :"
        '
        'fm_0200_tercero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1569, 685)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cm_tipo_identificacion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tx_dig_verificacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_id_tercero)
        Me.Controls.Add(Me.tx_2_apellido)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_1_apellido)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lb_identificacion)
        Me.Controls.Add(Me.tx_identificacion)
        Me.Controls.Add(Me.tx_nombre)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "fm_0200_tercero"
        Me.Text = "Gestion Terceros"
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.tx_nombre, 0)
        Me.Controls.SetChildIndex(Me.tx_identificacion, 0)
        Me.Controls.SetChildIndex(Me.lb_identificacion, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_1_apellido, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_2_apellido, 0)
        Me.Controls.SetChildIndex(Me.tx_id_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_dig_verificacion, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_identificacion, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dg_sucursales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_identificacion As System.Windows.Forms.Label
    Friend WithEvents tx_identificacion As System.Windows.Forms.TextBox
    Friend WithEvents tx_nombre As System.Windows.Forms.TextBox
    Friend WithEvents lb_nombre As System.Windows.Forms.Label
    Friend WithEvents tx_1_apellido As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_2_apellido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_id_tercero As System.Windows.Forms.TextBox
    Friend WithEvents tx_dig_verificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cm_tipo_identificacion As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_cliente As System.Windows.Forms.CheckBox
    Friend WithEvents chk_empleado As System.Windows.Forms.CheckBox
    Friend WithEvents chk_proveedor As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chk_aspirante As System.Windows.Forms.CheckBox
    Friend WithEvents cm_identificacion As System.Windows.Forms.ComboBox
    Friend WithEvents dg_sucursales As System.Windows.Forms.DataGridView
    Friend WithEvents cm_nombres As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_nueva_sucursal As System.Windows.Forms.Button
    Friend WithEvents lb_total_sucursales As System.Windows.Forms.Label
    Friend WithEvents dgocell_id_tercero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cod_sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nombre_sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ciudad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_direccion As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
