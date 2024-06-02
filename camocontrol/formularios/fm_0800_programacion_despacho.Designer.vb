<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0800_programacion_despacho
    Inherits camocontrol.FM_PLANTILLA

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fm_0800_programacion_despacho))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpg_pedido = New System.Windows.Forms.TabPage()
        Me.Btn_CambiarDireccion = New System.Windows.Forms.Button()
        Me.pnl_DireccionDespacho = New System.Windows.Forms.GroupBox()
        Me.bt_GrabarNuevaDireccion = New System.Windows.Forms.Button()
        Me.tx_direccion = New System.Windows.Forms.TextBox()
        Me.cm_ciudad_destino = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.pnl_reg_pedido = New System.Windows.Forms.Panel()
        Me.tx_funcionario_registra_pedido = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cm_razon_social = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cm_nit = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cm_asesor = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtp_fecha_registro = New System.Windows.Forms.DateTimePicker()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.tbpg_despacho = New System.Windows.Forms.TabPage()
        Me.bt_anular_guia = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_registrar_caja = New System.Windows.Forms.Button()
        Me.pnl_reg_guia = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_unidades_guia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_unidades_solicitadas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_unidades_despachadas = New System.Windows.Forms.TextBox()
        Me.tx_funcionario_registra_guia_transp = New System.Windows.Forms.TextBox()
        Me.bt_guia = New System.Windows.Forms.Button()
        Me.dtp_fecha_registro_guia = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_guia_transportadora = New System.Windows.Forms.TextBox()
        Me.cm_transportadora_despacho = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dg_items_rms = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dg_remisiones = New System.Windows.Forms.DataGridView()
        Me.dgocell_rms_id_rem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_rms_remision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_rms_factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_rms_bonificado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tbpg_seguimiento = New System.Windows.Forms.TabPage()
        Me.pnl_cumplido_transportadora = New System.Windows.Forms.Panel()
        Me.tx_funcionario_registra_cumplido_transp = New System.Windows.Forms.TextBox()
        Me.bt_recepcion_cumplido = New System.Windows.Forms.Button()
        Me.dtp_fecha_cumplido = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tx_id_cumplido_transportadora = New System.Windows.Forms.TextBox()
        Me.gb_soportes_cumplido = New System.Windows.Forms.GroupBox()
        Me.bt_nuevo_soporte = New System.Windows.Forms.Button()
        Me.bt_ver_archivos_asociados = New System.Windows.Forms.Button()
        Me.lb_total_soportes_cumplido = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.pnl_verif_cliente = New System.Windows.Forms.Panel()
        Me.tx_funcionario_verifica_recibo = New System.Windows.Forms.TextBox()
        Me.bt_verificacion_recepcion = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tx_info_cliente_recibo = New System.Windows.Forms.TextBox()
        Me.dtp_fecha_verificacion_recibo = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbpg_reclamacion = New System.Windows.Forms.TabPage()
        Me.pnl_cierre_despacho = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_funcionario_cierra_pedido = New System.Windows.Forms.TextBox()
        Me.bt_cerrar_pedido = New System.Windows.Forms.Button()
        Me.dtp_fecha_cierre_pedido = New System.Windows.Forms.DateTimePicker()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pnl_reclamacion = New System.Windows.Forms.Panel()
        Me.tx_texto_reclamo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnl_devolucion = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tx_docto_devolucion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tx_funcionario_registra_devolucion = New System.Windows.Forms.TextBox()
        Me.dtp_fecha_registro_devolucion = New System.Windows.Forms.DateTimePicker()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.bt_devolucion = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tx_informacion_devolucion = New System.Windows.Forms.TextBox()
        Me.dtp_fecha_recibo_devolucion = New System.Windows.Forms.DateTimePicker()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cm_funcionario_recibe_devolucion = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tx_id_accion = New System.Windows.Forms.TextBox()
        Me.bt_reclamacion = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tx_id_despacho = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tbpg_pedido.SuspendLayout()
        Me.pnl_DireccionDespacho.SuspendLayout()
        Me.pnl_reg_pedido.SuspendLayout()
        Me.tbpg_despacho.SuspendLayout()
        Me.pnl_reg_guia.SuspendLayout()
        CType(Me.dg_items_rms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_remisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpg_seguimiento.SuspendLayout()
        Me.pnl_cumplido_transportadora.SuspendLayout()
        Me.gb_soportes_cumplido.SuspendLayout()
        Me.pnl_verif_cliente.SuspendLayout()
        Me.tbpg_reclamacion.SuspendLayout()
        Me.pnl_cierre_despacho.SuspendLayout()
        Me.pnl_reclamacion.SuspendLayout()
        Me.pnl_devolucion.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(842, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(940, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(941, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2015/09/28"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(335, 32)
        Me.lb_titulo.Text = "Informacion del Despacho"
        '
        'bt_grabar
        '
        '
        'bt_anular
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpg_pedido)
        Me.TabControl1.Controls.Add(Me.tbpg_despacho)
        Me.TabControl1.Controls.Add(Me.tbpg_seguimiento)
        Me.TabControl1.Controls.Add(Me.tbpg_reclamacion)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 89)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(954, 321)
        Me.TabControl1.TabIndex = 273
        '
        'tbpg_pedido
        '
        Me.tbpg_pedido.BackColor = System.Drawing.Color.Thistle
        Me.tbpg_pedido.Controls.Add(Me.Btn_CambiarDireccion)
        Me.tbpg_pedido.Controls.Add(Me.pnl_DireccionDespacho)
        Me.tbpg_pedido.Controls.Add(Me.pnl_reg_pedido)
        Me.tbpg_pedido.Location = New System.Drawing.Point(4, 25)
        Me.tbpg_pedido.Name = "tbpg_pedido"
        Me.tbpg_pedido.Size = New System.Drawing.Size(946, 292)
        Me.tbpg_pedido.TabIndex = 3
        Me.tbpg_pedido.Text = "Pedido"
        '
        'Btn_CambiarDireccion
        '
        Me.Btn_CambiarDireccion.Location = New System.Drawing.Point(573, 181)
        Me.Btn_CambiarDireccion.Name = "Btn_CambiarDireccion"
        Me.Btn_CambiarDireccion.Size = New System.Drawing.Size(105, 62)
        Me.Btn_CambiarDireccion.TabIndex = 241
        Me.Btn_CambiarDireccion.Text = "Cambiar Direccion Despacho"
        Me.Btn_CambiarDireccion.UseVisualStyleBackColor = True
        '
        'pnl_DireccionDespacho
        '
        Me.pnl_DireccionDespacho.Controls.Add(Me.bt_GrabarNuevaDireccion)
        Me.pnl_DireccionDespacho.Controls.Add(Me.tx_direccion)
        Me.pnl_DireccionDespacho.Controls.Add(Me.cm_ciudad_destino)
        Me.pnl_DireccionDespacho.Controls.Add(Me.Label6)
        Me.pnl_DireccionDespacho.Controls.Add(Me.Label38)
        Me.pnl_DireccionDespacho.Location = New System.Drawing.Point(2, 163)
        Me.pnl_DireccionDespacho.Name = "pnl_DireccionDespacho"
        Me.pnl_DireccionDespacho.Size = New System.Drawing.Size(562, 88)
        Me.pnl_DireccionDespacho.TabIndex = 260
        Me.pnl_DireccionDespacho.TabStop = False
        Me.pnl_DireccionDespacho.Text = "Direccion De Despacho"
        '
        'bt_GrabarNuevaDireccion
        '
        Me.bt_GrabarNuevaDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_GrabarNuevaDireccion.Image = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_GrabarNuevaDireccion.Location = New System.Drawing.Point(504, 24)
        Me.bt_GrabarNuevaDireccion.Name = "bt_GrabarNuevaDireccion"
        Me.bt_GrabarNuevaDireccion.Size = New System.Drawing.Size(50, 51)
        Me.bt_GrabarNuevaDireccion.TabIndex = 241
        Me.bt_GrabarNuevaDireccion.UseVisualStyleBackColor = True
        '
        'tx_direccion
        '
        Me.tx_direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_direccion.Location = New System.Drawing.Point(121, 53)
        Me.tx_direccion.Name = "tx_direccion"
        Me.tx_direccion.Size = New System.Drawing.Size(377, 22)
        Me.tx_direccion.TabIndex = 240
        '
        'cm_ciudad_destino
        '
        Me.cm_ciudad_destino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_ciudad_destino.FormattingEnabled = True
        Me.cm_ciudad_destino.Location = New System.Drawing.Point(121, 23)
        Me.cm_ciudad_destino.Name = "cm_ciudad_destino"
        Me.cm_ciudad_destino.Size = New System.Drawing.Size(377, 24)
        Me.cm_ciudad_destino.TabIndex = 222
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 239
        Me.Label6.Text = "Direccion:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(10, 31)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(103, 16)
        Me.Label38.TabIndex = 221
        Me.Label38.Text = "Ciudad Destino:"
        '
        'pnl_reg_pedido
        '
        Me.pnl_reg_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_reg_pedido.Controls.Add(Me.tx_funcionario_registra_pedido)
        Me.pnl_reg_pedido.Controls.Add(Me.Label31)
        Me.pnl_reg_pedido.Controls.Add(Me.cm_razon_social)
        Me.pnl_reg_pedido.Controls.Add(Me.Label32)
        Me.pnl_reg_pedido.Controls.Add(Me.cm_nit)
        Me.pnl_reg_pedido.Controls.Add(Me.Label36)
        Me.pnl_reg_pedido.Controls.Add(Me.cm_asesor)
        Me.pnl_reg_pedido.Controls.Add(Me.Label37)
        Me.pnl_reg_pedido.Controls.Add(Me.dtp_fecha_registro)
        Me.pnl_reg_pedido.Controls.Add(Me.Label39)
        Me.pnl_reg_pedido.Location = New System.Drawing.Point(2, 6)
        Me.pnl_reg_pedido.Name = "pnl_reg_pedido"
        Me.pnl_reg_pedido.Size = New System.Drawing.Size(942, 136)
        Me.pnl_reg_pedido.TabIndex = 259
        '
        'tx_funcionario_registra_pedido
        '
        Me.tx_funcionario_registra_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_funcionario_registra_pedido.Location = New System.Drawing.Point(120, 21)
        Me.tx_funcionario_registra_pedido.Name = "tx_funcionario_registra_pedido"
        Me.tx_funcionario_registra_pedido.Size = New System.Drawing.Size(377, 22)
        Me.tx_funcionario_registra_pedido.TabIndex = 238
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(10, 54)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(52, 16)
        Me.Label31.TabIndex = 198
        Me.Label31.Text = "Cliente:"
        '
        'cm_razon_social
        '
        Me.cm_razon_social.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_razon_social.FormattingEnabled = True
        Me.cm_razon_social.Location = New System.Drawing.Point(120, 46)
        Me.cm_razon_social.Name = "cm_razon_social"
        Me.cm_razon_social.Size = New System.Drawing.Size(377, 24)
        Me.cm_razon_social.TabIndex = 199
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(505, 54)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(124, 16)
        Me.Label32.TabIndex = 200
        Me.Label32.Text = "Identificación / NIT :"
        '
        'cm_nit
        '
        Me.cm_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_nit.FormattingEnabled = True
        Me.cm_nit.Location = New System.Drawing.Point(637, 46)
        Me.cm_nit.Name = "cm_nit"
        Me.cm_nit.Size = New System.Drawing.Size(155, 24)
        Me.cm_nit.TabIndex = 201
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(10, 81)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(66, 16)
        Me.Label36.TabIndex = 217
        Me.Label36.Text = "Asesor C:"
        '
        'cm_asesor
        '
        Me.cm_asesor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_asesor.FormattingEnabled = True
        Me.cm_asesor.Location = New System.Drawing.Point(120, 73)
        Me.cm_asesor.Name = "cm_asesor"
        Me.cm_asesor.Size = New System.Drawing.Size(377, 24)
        Me.cm_asesor.TabIndex = 218
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(10, 27)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(101, 16)
        Me.Label37.TabIndex = 219
        Me.Label37.Text = "Registrado por:"
        '
        'dtp_fecha_registro
        '
        Me.dtp_fecha_registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_registro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_registro.Location = New System.Drawing.Point(637, 21)
        Me.dtp_fecha_registro.Name = "dtp_fecha_registro"
        Me.dtp_fecha_registro.Size = New System.Drawing.Size(155, 22)
        Me.dtp_fecha_registro.TabIndex = 223
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(505, 27)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(103, 16)
        Me.Label39.TabIndex = 224
        Me.Label39.Text = "Fecha Registro:"
        '
        'tbpg_despacho
        '
        Me.tbpg_despacho.BackColor = System.Drawing.Color.Thistle
        Me.tbpg_despacho.Controls.Add(Me.bt_anular_guia)
        Me.tbpg_despacho.Controls.Add(Me.Label3)
        Me.tbpg_despacho.Controls.Add(Me.bt_registrar_caja)
        Me.tbpg_despacho.Controls.Add(Me.pnl_reg_guia)
        Me.tbpg_despacho.Controls.Add(Me.dg_items_rms)
        Me.tbpg_despacho.Controls.Add(Me.Label2)
        Me.tbpg_despacho.Controls.Add(Me.dg_remisiones)
        Me.tbpg_despacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpg_despacho.Location = New System.Drawing.Point(4, 25)
        Me.tbpg_despacho.Name = "tbpg_despacho"
        Me.tbpg_despacho.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpg_despacho.Size = New System.Drawing.Size(946, 292)
        Me.tbpg_despacho.TabIndex = 0
        Me.tbpg_despacho.Text = "Despacho"
        '
        'bt_anular_guia
        '
        Me.bt_anular_guia.Image = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_anular_guia.Location = New System.Drawing.Point(842, 123)
        Me.bt_anular_guia.Name = "bt_anular_guia"
        Me.bt_anular_guia.Size = New System.Drawing.Size(93, 47)
        Me.bt_anular_guia.TabIndex = 288
        Me.bt_anular_guia.Text = "Anular Guia"
        Me.bt_anular_guia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_anular_guia.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(353, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 16)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "Productos a despachar"
        '
        'bt_registrar_caja
        '
        Me.bt_registrar_caja.Location = New System.Drawing.Point(842, 22)
        Me.bt_registrar_caja.Name = "bt_registrar_caja"
        Me.bt_registrar_caja.Size = New System.Drawing.Size(93, 95)
        Me.bt_registrar_caja.TabIndex = 283
        Me.bt_registrar_caja.Text = "Registrar Cajas"
        Me.bt_registrar_caja.UseVisualStyleBackColor = True
        '
        'pnl_reg_guia
        '
        Me.pnl_reg_guia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_reg_guia.Controls.Add(Me.Label7)
        Me.pnl_reg_guia.Controls.Add(Me.tx_unidades_guia)
        Me.pnl_reg_guia.Controls.Add(Me.Label5)
        Me.pnl_reg_guia.Controls.Add(Me.tx_unidades_solicitadas)
        Me.pnl_reg_guia.Controls.Add(Me.Label4)
        Me.pnl_reg_guia.Controls.Add(Me.tx_unidades_despachadas)
        Me.pnl_reg_guia.Controls.Add(Me.tx_funcionario_registra_guia_transp)
        Me.pnl_reg_guia.Controls.Add(Me.bt_guia)
        Me.pnl_reg_guia.Controls.Add(Me.dtp_fecha_registro_guia)
        Me.pnl_reg_guia.Controls.Add(Me.Label1)
        Me.pnl_reg_guia.Controls.Add(Me.Label12)
        Me.pnl_reg_guia.Controls.Add(Me.Label8)
        Me.pnl_reg_guia.Controls.Add(Me.tx_guia_transportadora)
        Me.pnl_reg_guia.Controls.Add(Me.cm_transportadora_despacho)
        Me.pnl_reg_guia.Controls.Add(Me.Label11)
        Me.pnl_reg_guia.Location = New System.Drawing.Point(6, 183)
        Me.pnl_reg_guia.Name = "pnl_reg_guia"
        Me.pnl_reg_guia.Size = New System.Drawing.Size(934, 92)
        Me.pnl_reg_guia.TabIndex = 282
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(334, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 16)
        Me.Label7.TabIndex = 287
        Me.Label7.Text = "Unid. Guia:"
        '
        'tx_unidades_guia
        '
        Me.tx_unidades_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidades_guia.Location = New System.Drawing.Point(413, 34)
        Me.tx_unidades_guia.Name = "tx_unidades_guia"
        Me.tx_unidades_guia.Size = New System.Drawing.Size(84, 22)
        Me.tx_unidades_guia.TabIndex = 286
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(539, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 16)
        Me.Label5.TabIndex = 285
        Me.Label5.Text = "Unidades Pedido:"
        '
        'tx_unidades_solicitadas
        '
        Me.tx_unidades_solicitadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidades_solicitadas.Location = New System.Drawing.Point(680, 33)
        Me.tx_unidades_solicitadas.Name = "tx_unidades_solicitadas"
        Me.tx_unidades_solicitadas.ReadOnly = True
        Me.tx_unidades_solicitadas.Size = New System.Drawing.Size(127, 22)
        Me.tx_unidades_solicitadas.TabIndex = 284
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(539, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 16)
        Me.Label4.TabIndex = 283
        Me.Label4.Text = "Unidades Cargadas:"
        '
        'tx_unidades_despachadas
        '
        Me.tx_unidades_despachadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidades_despachadas.Location = New System.Drawing.Point(680, 61)
        Me.tx_unidades_despachadas.Name = "tx_unidades_despachadas"
        Me.tx_unidades_despachadas.ReadOnly = True
        Me.tx_unidades_despachadas.Size = New System.Drawing.Size(127, 22)
        Me.tx_unidades_despachadas.TabIndex = 282
        '
        'tx_funcionario_registra_guia_transp
        '
        Me.tx_funcionario_registra_guia_transp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_funcionario_registra_guia_transp.Location = New System.Drawing.Point(447, 7)
        Me.tx_funcionario_registra_guia_transp.Name = "tx_funcionario_registra_guia_transp"
        Me.tx_funcionario_registra_guia_transp.Size = New System.Drawing.Size(360, 22)
        Me.tx_funcionario_registra_guia_transp.TabIndex = 280
        '
        'bt_guia
        '
        Me.bt_guia.BackColor = System.Drawing.Color.Thistle
        Me.bt_guia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_guia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bt_guia.Image = CType(resources.GetObject("bt_guia.Image"), System.Drawing.Image)
        Me.bt_guia.Location = New System.Drawing.Point(835, 45)
        Me.bt_guia.Name = "bt_guia"
        Me.bt_guia.Size = New System.Drawing.Size(93, 40)
        Me.bt_guia.TabIndex = 279
        Me.bt_guia.Text = "Reg"
        Me.bt_guia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_guia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_guia.UseVisualStyleBackColor = False
        '
        'dtp_fecha_registro_guia
        '
        Me.dtp_fecha_registro_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_registro_guia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_registro_guia.Location = New System.Drawing.Point(120, 7)
        Me.dtp_fecha_registro_guia.Name = "dtp_fecha_registro_guia"
        Me.dtp_fecha_registro_guia.Size = New System.Drawing.Size(171, 22)
        Me.dtp_fecha_registro_guia.TabIndex = 268
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 269
        Me.Label1.Text = "Fecha Guia:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 16)
        Me.Label12.TabIndex = 275
        Me.Label12.Text = "Guia #:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(341, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 16)
        Me.Label8.TabIndex = 271
        Me.Label8.Text = "Registrado por:"
        '
        'tx_guia_transportadora
        '
        Me.tx_guia_transportadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_guia_transportadora.Location = New System.Drawing.Point(120, 33)
        Me.tx_guia_transportadora.Name = "tx_guia_transportadora"
        Me.tx_guia_transportadora.Size = New System.Drawing.Size(171, 22)
        Me.tx_guia_transportadora.TabIndex = 276
        '
        'cm_transportadora_despacho
        '
        Me.cm_transportadora_despacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_transportadora_despacho.FormattingEnabled = True
        Me.cm_transportadora_despacho.Location = New System.Drawing.Point(120, 59)
        Me.cm_transportadora_despacho.Name = "cm_transportadora_despacho"
        Me.cm_transportadora_despacho.Size = New System.Drawing.Size(377, 24)
        Me.cm_transportadora_despacho.TabIndex = 274
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 16)
        Me.Label11.TabIndex = 273
        Me.Label11.Text = "Transportadora:"
        '
        'dg_items_rms
        '
        Me.dg_items_rms.AllowUserToAddRows = False
        Me.dg_items_rms.AllowUserToDeleteRows = False
        Me.dg_items_rms.AllowUserToOrderColumns = True
        Me.dg_items_rms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_items_rms.Location = New System.Drawing.Point(354, 22)
        Me.dg_items_rms.Name = "dg_items_rms"
        Me.dg_items_rms.ReadOnly = True
        Me.dg_items_rms.Size = New System.Drawing.Size(482, 155)
        Me.dg_items_rms.TabIndex = 206
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 16)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "Remisiones a despachar"
        '
        'dg_remisiones
        '
        Me.dg_remisiones.AllowUserToAddRows = False
        Me.dg_remisiones.AllowUserToDeleteRows = False
        Me.dg_remisiones.AllowUserToOrderColumns = True
        Me.dg_remisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_remisiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_rms_id_rem, Me.dgocell_rms_remision, Me.dgocell_rms_factura, Me.dgocell_rms_bonificado})
        Me.dg_remisiones.Location = New System.Drawing.Point(7, 22)
        Me.dg_remisiones.Name = "dg_remisiones"
        Me.dg_remisiones.Size = New System.Drawing.Size(341, 155)
        Me.dg_remisiones.TabIndex = 0
        '
        'dgocell_rms_id_rem
        '
        Me.dgocell_rms_id_rem.HeaderText = "Id"
        Me.dgocell_rms_id_rem.Name = "dgocell_rms_id_rem"
        Me.dgocell_rms_id_rem.ReadOnly = True
        Me.dgocell_rms_id_rem.Width = 60
        '
        'dgocell_rms_remision
        '
        Me.dgocell_rms_remision.HeaderText = "Remision"
        Me.dgocell_rms_remision.Name = "dgocell_rms_remision"
        Me.dgocell_rms_remision.ReadOnly = True
        '
        'dgocell_rms_factura
        '
        Me.dgocell_rms_factura.HeaderText = "Factura"
        Me.dgocell_rms_factura.MaxInputLength = 10
        Me.dgocell_rms_factura.Name = "dgocell_rms_factura"
        '
        'dgocell_rms_bonificado
        '
        Me.dgocell_rms_bonificado.HeaderText = "Bn"
        Me.dgocell_rms_bonificado.Name = "dgocell_rms_bonificado"
        Me.dgocell_rms_bonificado.Width = 30
        '
        'tbpg_seguimiento
        '
        Me.tbpg_seguimiento.BackColor = System.Drawing.Color.Thistle
        Me.tbpg_seguimiento.Controls.Add(Me.pnl_cumplido_transportadora)
        Me.tbpg_seguimiento.Controls.Add(Me.gb_soportes_cumplido)
        Me.tbpg_seguimiento.Controls.Add(Me.pnl_verif_cliente)
        Me.tbpg_seguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpg_seguimiento.Location = New System.Drawing.Point(4, 25)
        Me.tbpg_seguimiento.Name = "tbpg_seguimiento"
        Me.tbpg_seguimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpg_seguimiento.Size = New System.Drawing.Size(946, 292)
        Me.tbpg_seguimiento.TabIndex = 1
        Me.tbpg_seguimiento.Text = "Seguimiento"
        '
        'pnl_cumplido_transportadora
        '
        Me.pnl_cumplido_transportadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_cumplido_transportadora.Controls.Add(Me.tx_funcionario_registra_cumplido_transp)
        Me.pnl_cumplido_transportadora.Controls.Add(Me.bt_recepcion_cumplido)
        Me.pnl_cumplido_transportadora.Controls.Add(Me.dtp_fecha_cumplido)
        Me.pnl_cumplido_transportadora.Controls.Add(Me.Label20)
        Me.pnl_cumplido_transportadora.Controls.Add(Me.Label21)
        Me.pnl_cumplido_transportadora.Controls.Add(Me.Label22)
        Me.pnl_cumplido_transportadora.Controls.Add(Me.tx_id_cumplido_transportadora)
        Me.pnl_cumplido_transportadora.Location = New System.Drawing.Point(6, 146)
        Me.pnl_cumplido_transportadora.Name = "pnl_cumplido_transportadora"
        Me.pnl_cumplido_transportadora.Size = New System.Drawing.Size(934, 63)
        Me.pnl_cumplido_transportadora.TabIndex = 285
        '
        'tx_funcionario_registra_cumplido_transp
        '
        Me.tx_funcionario_registra_cumplido_transp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_funcionario_registra_cumplido_transp.Location = New System.Drawing.Point(120, 6)
        Me.tx_funcionario_registra_cumplido_transp.Name = "tx_funcionario_registra_cumplido_transp"
        Me.tx_funcionario_registra_cumplido_transp.Size = New System.Drawing.Size(377, 22)
        Me.tx_funcionario_registra_cumplido_transp.TabIndex = 282
        '
        'bt_recepcion_cumplido
        '
        Me.bt_recepcion_cumplido.BackColor = System.Drawing.Color.Thistle
        Me.bt_recepcion_cumplido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_recepcion_cumplido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_recepcion_cumplido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bt_recepcion_cumplido.Image = CType(resources.GetObject("bt_recepcion_cumplido.Image"), System.Drawing.Image)
        Me.bt_recepcion_cumplido.Location = New System.Drawing.Point(840, 7)
        Me.bt_recepcion_cumplido.Name = "bt_recepcion_cumplido"
        Me.bt_recepcion_cumplido.Size = New System.Drawing.Size(80, 40)
        Me.bt_recepcion_cumplido.TabIndex = 280
        Me.bt_recepcion_cumplido.Text = "Reg"
        Me.bt_recepcion_cumplido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_recepcion_cumplido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_recepcion_cumplido.UseVisualStyleBackColor = False
        '
        'dtp_fecha_cumplido
        '
        Me.dtp_fecha_cumplido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_cumplido.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_cumplido.Location = New System.Drawing.Point(656, 6)
        Me.dtp_fecha_cumplido.Name = "dtp_fecha_cumplido"
        Me.dtp_fecha_cumplido.Size = New System.Drawing.Size(171, 22)
        Me.dtp_fecha_cumplido.TabIndex = 268
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(513, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(109, 16)
        Me.Label20.TabIndex = 269
        Me.Label20.Text = "Fecha Cumplido:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(10, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 16)
        Me.Label21.TabIndex = 275
        Me.Label21.Text = "Cumplido #:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(10, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(101, 16)
        Me.Label22.TabIndex = 271
        Me.Label22.Text = "Registrado por:"
        '
        'tx_id_cumplido_transportadora
        '
        Me.tx_id_cumplido_transportadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_cumplido_transportadora.Location = New System.Drawing.Point(120, 31)
        Me.tx_id_cumplido_transportadora.Name = "tx_id_cumplido_transportadora"
        Me.tx_id_cumplido_transportadora.Size = New System.Drawing.Size(171, 22)
        Me.tx_id_cumplido_transportadora.TabIndex = 276
        '
        'gb_soportes_cumplido
        '
        Me.gb_soportes_cumplido.Controls.Add(Me.bt_nuevo_soporte)
        Me.gb_soportes_cumplido.Controls.Add(Me.bt_ver_archivos_asociados)
        Me.gb_soportes_cumplido.Controls.Add(Me.lb_total_soportes_cumplido)
        Me.gb_soportes_cumplido.Controls.Add(Me.Label19)
        Me.gb_soportes_cumplido.Controls.Add(Me.Label24)
        Me.gb_soportes_cumplido.Location = New System.Drawing.Point(360, 211)
        Me.gb_soportes_cumplido.Name = "gb_soportes_cumplido"
        Me.gb_soportes_cumplido.Size = New System.Drawing.Size(248, 76)
        Me.gb_soportes_cumplido.TabIndex = 277
        Me.gb_soportes_cumplido.TabStop = False
        Me.gb_soportes_cumplido.Text = "Archivos Soporte Cumplido:"
        '
        'bt_nuevo_soporte
        '
        Me.bt_nuevo_soporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nuevo_soporte.Image = CType(resources.GetObject("bt_nuevo_soporte.Image"), System.Drawing.Image)
        Me.bt_nuevo_soporte.Location = New System.Drawing.Point(6, 19)
        Me.bt_nuevo_soporte.Name = "bt_nuevo_soporte"
        Me.bt_nuevo_soporte.Size = New System.Drawing.Size(50, 51)
        Me.bt_nuevo_soporte.TabIndex = 170
        Me.bt_nuevo_soporte.UseVisualStyleBackColor = True
        '
        'bt_ver_archivos_asociados
        '
        Me.bt_ver_archivos_asociados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ver_archivos_asociados.Image = CType(resources.GetObject("bt_ver_archivos_asociados.Image"), System.Drawing.Image)
        Me.bt_ver_archivos_asociados.Location = New System.Drawing.Point(62, 19)
        Me.bt_ver_archivos_asociados.Name = "bt_ver_archivos_asociados"
        Me.bt_ver_archivos_asociados.Size = New System.Drawing.Size(50, 51)
        Me.bt_ver_archivos_asociados.TabIndex = 171
        Me.bt_ver_archivos_asociados.UseVisualStyleBackColor = True
        '
        'lb_total_soportes_cumplido
        '
        Me.lb_total_soportes_cumplido.AutoSize = True
        Me.lb_total_soportes_cumplido.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_soportes_cumplido.Location = New System.Drawing.Point(201, 35)
        Me.lb_total_soportes_cumplido.Name = "lb_total_soportes_cumplido"
        Me.lb_total_soportes_cumplido.Size = New System.Drawing.Size(29, 31)
        Me.lb_total_soportes_cumplido.TabIndex = 172
        Me.lb_total_soportes_cumplido.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(118, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 20)
        Me.Label19.TabIndex = 173
        Me.Label19.Text = "Total"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(118, 46)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(78, 20)
        Me.Label24.TabIndex = 174
        Me.Label24.Text = "Soportes:"
        '
        'pnl_verif_cliente
        '
        Me.pnl_verif_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_verif_cliente.Controls.Add(Me.tx_funcionario_verifica_recibo)
        Me.pnl_verif_cliente.Controls.Add(Me.bt_verificacion_recepcion)
        Me.pnl_verif_cliente.Controls.Add(Me.Label18)
        Me.pnl_verif_cliente.Controls.Add(Me.tx_info_cliente_recibo)
        Me.pnl_verif_cliente.Controls.Add(Me.dtp_fecha_verificacion_recibo)
        Me.pnl_verif_cliente.Controls.Add(Me.Label15)
        Me.pnl_verif_cliente.Controls.Add(Me.Label16)
        Me.pnl_verif_cliente.Location = New System.Drawing.Point(6, 6)
        Me.pnl_verif_cliente.Name = "pnl_verif_cliente"
        Me.pnl_verif_cliente.Size = New System.Drawing.Size(934, 134)
        Me.pnl_verif_cliente.TabIndex = 284
        '
        'tx_funcionario_verifica_recibo
        '
        Me.tx_funcionario_verifica_recibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_funcionario_verifica_recibo.Location = New System.Drawing.Point(119, 5)
        Me.tx_funcionario_verifica_recibo.Name = "tx_funcionario_verifica_recibo"
        Me.tx_funcionario_verifica_recibo.Size = New System.Drawing.Size(377, 22)
        Me.tx_funcionario_verifica_recibo.TabIndex = 281
        '
        'bt_verificacion_recepcion
        '
        Me.bt_verificacion_recepcion.BackColor = System.Drawing.Color.Thistle
        Me.bt_verificacion_recepcion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_verificacion_recepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_verificacion_recepcion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bt_verificacion_recepcion.Image = CType(resources.GetObject("bt_verificacion_recepcion.Image"), System.Drawing.Image)
        Me.bt_verificacion_recepcion.Location = New System.Drawing.Point(840, 35)
        Me.bt_verificacion_recepcion.Name = "bt_verificacion_recepcion"
        Me.bt_verificacion_recepcion.Size = New System.Drawing.Size(80, 40)
        Me.bt_verificacion_recepcion.TabIndex = 280
        Me.bt_verificacion_recepcion.Text = "Reg"
        Me.bt_verificacion_recepcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_verificacion_recepcion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_verificacion_recepcion.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 16)
        Me.Label18.TabIndex = 278
        Me.Label18.Text = "Info. Cliente:"
        '
        'tx_info_cliente_recibo
        '
        Me.tx_info_cliente_recibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_info_cliente_recibo.Location = New System.Drawing.Point(119, 55)
        Me.tx_info_cliente_recibo.Multiline = True
        Me.tx_info_cliente_recibo.Name = "tx_info_cliente_recibo"
        Me.tx_info_cliente_recibo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_info_cliente_recibo.Size = New System.Drawing.Size(709, 73)
        Me.tx_info_cliente_recibo.TabIndex = 277
        '
        'dtp_fecha_verificacion_recibo
        '
        Me.dtp_fecha_verificacion_recibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_verificacion_recibo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_verificacion_recibo.Location = New System.Drawing.Point(656, 5)
        Me.dtp_fecha_verificacion_recibo.Name = "dtp_fecha_verificacion_recibo"
        Me.dtp_fecha_verificacion_recibo.Size = New System.Drawing.Size(171, 22)
        Me.dtp_fecha_verificacion_recibo.TabIndex = 273
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(513, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(122, 16)
        Me.Label15.TabIndex = 274
        Me.Label15.Text = "Fecha Verificacion:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 16)
        Me.Label16.TabIndex = 275
        Me.Label16.Text = "Verificado por:"
        '
        'tbpg_reclamacion
        '
        Me.tbpg_reclamacion.BackColor = System.Drawing.Color.Thistle
        Me.tbpg_reclamacion.Controls.Add(Me.pnl_cierre_despacho)
        Me.tbpg_reclamacion.Controls.Add(Me.pnl_reclamacion)
        Me.tbpg_reclamacion.Location = New System.Drawing.Point(4, 25)
        Me.tbpg_reclamacion.Name = "tbpg_reclamacion"
        Me.tbpg_reclamacion.Size = New System.Drawing.Size(946, 292)
        Me.tbpg_reclamacion.TabIndex = 2
        Me.tbpg_reclamacion.Text = "Reclamacion"
        '
        'pnl_cierre_despacho
        '
        Me.pnl_cierre_despacho.BackColor = System.Drawing.Color.PaleGreen
        Me.pnl_cierre_despacho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_cierre_despacho.Controls.Add(Me.Label9)
        Me.pnl_cierre_despacho.Controls.Add(Me.tx_funcionario_cierra_pedido)
        Me.pnl_cierre_despacho.Controls.Add(Me.bt_cerrar_pedido)
        Me.pnl_cierre_despacho.Controls.Add(Me.dtp_fecha_cierre_pedido)
        Me.pnl_cierre_despacho.Controls.Add(Me.Label33)
        Me.pnl_cierre_despacho.Controls.Add(Me.Label35)
        Me.pnl_cierre_despacho.Location = New System.Drawing.Point(3, 213)
        Me.pnl_cierre_despacho.Name = "pnl_cierre_despacho"
        Me.pnl_cierre_despacho.Size = New System.Drawing.Size(939, 74)
        Me.pnl_cierre_despacho.TabIndex = 297
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 20)
        Me.Label9.TabIndex = 312
        Me.Label9.Text = "Cierre del Despacho"
        '
        'tx_funcionario_cierra_pedido
        '
        Me.tx_funcionario_cierra_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_funcionario_cierra_pedido.Location = New System.Drawing.Point(131, 48)
        Me.tx_funcionario_cierra_pedido.Name = "tx_funcionario_cierra_pedido"
        Me.tx_funcionario_cierra_pedido.Size = New System.Drawing.Size(377, 22)
        Me.tx_funcionario_cierra_pedido.TabIndex = 311
        '
        'bt_cerrar_pedido
        '
        Me.bt_cerrar_pedido.BackColor = System.Drawing.Color.Thistle
        Me.bt_cerrar_pedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cerrar_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cerrar_pedido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bt_cerrar_pedido.Image = CType(resources.GetObject("bt_cerrar_pedido.Image"), System.Drawing.Image)
        Me.bt_cerrar_pedido.Location = New System.Drawing.Point(542, 16)
        Me.bt_cerrar_pedido.Name = "bt_cerrar_pedido"
        Me.bt_cerrar_pedido.Size = New System.Drawing.Size(80, 40)
        Me.bt_cerrar_pedido.TabIndex = 300
        Me.bt_cerrar_pedido.Text = "Reg"
        Me.bt_cerrar_pedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_cerrar_pedido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_cerrar_pedido.UseVisualStyleBackColor = False
        '
        'dtp_fecha_cierre_pedido
        '
        Me.dtp_fecha_cierre_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_cierre_pedido.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_cierre_pedido.Location = New System.Drawing.Point(131, 24)
        Me.dtp_fecha_cierre_pedido.Name = "dtp_fecha_cierre_pedido"
        Me.dtp_fecha_cierre_pedido.Size = New System.Drawing.Size(171, 22)
        Me.dtp_fecha_cierre_pedido.TabIndex = 296
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(6, 30)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 16)
        Me.Label33.TabIndex = 297
        Me.Label33.Text = "Fecha Cierre:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(6, 54)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(83, 16)
        Me.Label35.TabIndex = 298
        Me.Label35.Text = "Cerrado por:"
        '
        'pnl_reclamacion
        '
        Me.pnl_reclamacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_reclamacion.Controls.Add(Me.tx_texto_reclamo)
        Me.pnl_reclamacion.Controls.Add(Me.Label13)
        Me.pnl_reclamacion.Controls.Add(Me.pnl_devolucion)
        Me.pnl_reclamacion.Controls.Add(Me.tx_id_accion)
        Me.pnl_reclamacion.Controls.Add(Me.bt_reclamacion)
        Me.pnl_reclamacion.Location = New System.Drawing.Point(3, 3)
        Me.pnl_reclamacion.Name = "pnl_reclamacion"
        Me.pnl_reclamacion.Size = New System.Drawing.Size(939, 207)
        Me.pnl_reclamacion.TabIndex = 296
        '
        'tx_texto_reclamo
        '
        Me.tx_texto_reclamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_texto_reclamo.Location = New System.Drawing.Point(216, 3)
        Me.tx_texto_reclamo.Multiline = True
        Me.tx_texto_reclamo.Name = "tx_texto_reclamo"
        Me.tx_texto_reclamo.ReadOnly = True
        Me.tx_texto_reclamo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_texto_reclamo.Size = New System.Drawing.Size(718, 57)
        Me.tx_texto_reclamo.TabIndex = 315
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 20)
        Me.Label13.TabIndex = 314
        Me.Label13.Text = "Reclamo del Cliente"
        '
        'pnl_devolucion
        '
        Me.pnl_devolucion.BackColor = System.Drawing.Color.LightCoral
        Me.pnl_devolucion.Controls.Add(Me.Label14)
        Me.pnl_devolucion.Controls.Add(Me.tx_docto_devolucion)
        Me.pnl_devolucion.Controls.Add(Me.Label10)
        Me.pnl_devolucion.Controls.Add(Me.tx_funcionario_registra_devolucion)
        Me.pnl_devolucion.Controls.Add(Me.dtp_fecha_registro_devolucion)
        Me.pnl_devolucion.Controls.Add(Me.Label59)
        Me.pnl_devolucion.Controls.Add(Me.Label60)
        Me.pnl_devolucion.Controls.Add(Me.bt_devolucion)
        Me.pnl_devolucion.Controls.Add(Me.Label26)
        Me.pnl_devolucion.Controls.Add(Me.tx_informacion_devolucion)
        Me.pnl_devolucion.Controls.Add(Me.dtp_fecha_recibo_devolucion)
        Me.pnl_devolucion.Controls.Add(Me.Label25)
        Me.pnl_devolucion.Controls.Add(Me.cm_funcionario_recibe_devolucion)
        Me.pnl_devolucion.Controls.Add(Me.Label29)
        Me.pnl_devolucion.Location = New System.Drawing.Point(3, 62)
        Me.pnl_devolucion.Name = "pnl_devolucion"
        Me.pnl_devolucion.Size = New System.Drawing.Size(931, 139)
        Me.pnl_devolucion.TabIndex = 293
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(565, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 20)
        Me.Label14.TabIndex = 315
        Me.Label14.Text = "Documento:"
        '
        'tx_docto_devolucion
        '
        Me.tx_docto_devolucion.Location = New System.Drawing.Point(666, 4)
        Me.tx_docto_devolucion.Name = "tx_docto_devolucion"
        Me.tx_docto_devolucion.ReadOnly = True
        Me.tx_docto_devolucion.Size = New System.Drawing.Size(169, 22)
        Me.tx_docto_devolucion.TabIndex = 314
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(271, 20)
        Me.Label10.TabIndex = 313
        Me.Label10.Text = "Recepcion de Devolucion en Bodega"
        '
        'tx_funcionario_registra_devolucion
        '
        Me.tx_funcionario_registra_devolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_funcionario_registra_devolucion.Location = New System.Drawing.Point(128, 28)
        Me.tx_funcionario_registra_devolucion.Name = "tx_funcionario_registra_devolucion"
        Me.tx_funcionario_registra_devolucion.Size = New System.Drawing.Size(377, 22)
        Me.tx_funcionario_registra_devolucion.TabIndex = 310
        '
        'dtp_fecha_registro_devolucion
        '
        Me.dtp_fecha_registro_devolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_registro_devolucion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_registro_devolucion.Location = New System.Drawing.Point(666, 28)
        Me.dtp_fecha_registro_devolucion.Name = "dtp_fecha_registro_devolucion"
        Me.dtp_fecha_registro_devolucion.Size = New System.Drawing.Size(171, 22)
        Me.dtp_fecha_registro_devolucion.TabIndex = 307
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(540, 34)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(103, 16)
        Me.Label59.TabIndex = 308
        Me.Label59.Text = "Fecha Registro:"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(5, 34)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(101, 16)
        Me.Label60.TabIndex = 309
        Me.Label60.Text = "Registrado por:"
        '
        'bt_devolucion
        '
        Me.bt_devolucion.BackColor = System.Drawing.Color.Thistle
        Me.bt_devolucion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_devolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_devolucion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bt_devolucion.Image = CType(resources.GetObject("bt_devolucion.Image"), System.Drawing.Image)
        Me.bt_devolucion.Location = New System.Drawing.Point(842, 64)
        Me.bt_devolucion.Name = "bt_devolucion"
        Me.bt_devolucion.Size = New System.Drawing.Size(80, 40)
        Me.bt_devolucion.TabIndex = 306
        Me.bt_devolucion.Text = "Reg"
        Me.bt_devolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_devolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_devolucion.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(5, 76)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(106, 16)
        Me.Label26.TabIndex = 305
        Me.Label26.Text = "Info. Devolucion:"
        '
        'tx_informacion_devolucion
        '
        Me.tx_informacion_devolucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_informacion_devolucion.Location = New System.Drawing.Point(128, 76)
        Me.tx_informacion_devolucion.Multiline = True
        Me.tx_informacion_devolucion.Name = "tx_informacion_devolucion"
        Me.tx_informacion_devolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_informacion_devolucion.Size = New System.Drawing.Size(709, 57)
        Me.tx_informacion_devolucion.TabIndex = 304
        '
        'dtp_fecha_recibo_devolucion
        '
        Me.dtp_fecha_recibo_devolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_recibo_devolucion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_recibo_devolucion.Location = New System.Drawing.Point(666, 53)
        Me.dtp_fecha_recibo_devolucion.Name = "dtp_fecha_recibo_devolucion"
        Me.dtp_fecha_recibo_devolucion.Size = New System.Drawing.Size(171, 22)
        Me.dtp_fecha_recibo_devolucion.TabIndex = 300
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(540, 59)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(120, 16)
        Me.Label25.TabIndex = 301
        Me.Label25.Text = "Fecha Devolucion:"
        '
        'cm_funcionario_recibe_devolucion
        '
        Me.cm_funcionario_recibe_devolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_funcionario_recibe_devolucion.FormattingEnabled = True
        Me.cm_funcionario_recibe_devolucion.Location = New System.Drawing.Point(128, 51)
        Me.cm_funcionario_recibe_devolucion.Name = "cm_funcionario_recibe_devolucion"
        Me.cm_funcionario_recibe_devolucion.Size = New System.Drawing.Size(377, 24)
        Me.cm_funcionario_recibe_devolucion.TabIndex = 303
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(5, 59)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(89, 16)
        Me.Label29.TabIndex = 302
        Me.Label29.Text = "Recibido por:"
        '
        'tx_id_accion
        '
        Me.tx_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_accion.Location = New System.Drawing.Point(131, 29)
        Me.tx_id_accion.Name = "tx_id_accion"
        Me.tx_id_accion.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_accion.TabIndex = 292
        '
        'bt_reclamacion
        '
        Me.bt_reclamacion.BackColor = System.Drawing.Color.Crimson
        Me.bt_reclamacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_reclamacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_reclamacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bt_reclamacion.Image = CType(resources.GetObject("bt_reclamacion.Image"), System.Drawing.Image)
        Me.bt_reclamacion.Location = New System.Drawing.Point(9, 20)
        Me.bt_reclamacion.Name = "bt_reclamacion"
        Me.bt_reclamacion.Size = New System.Drawing.Size(116, 40)
        Me.bt_reclamacion.TabIndex = 291
        Me.bt_reclamacion.Text = "Reclamo"
        Me.bt_reclamacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_reclamacion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_reclamacion.UseVisualStyleBackColor = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(13, 67)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(72, 16)
        Me.Label30.TabIndex = 204
        Me.Label30.Text = "Id_pedido:"
        '
        'tx_id_despacho
        '
        Me.tx_id_despacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_despacho.Location = New System.Drawing.Point(93, 61)
        Me.tx_id_despacho.Name = "tx_id_despacho"
        Me.tx_id_despacho.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_despacho.TabIndex = 205
        '
        'fm_0800_programacion_despacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1027, 483)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.tx_id_despacho)
        Me.Name = "fm_0800_programacion_despacho"
        Me.Text = "Gestion Despacho"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.tx_id_despacho, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpg_pedido.ResumeLayout(False)
        Me.pnl_DireccionDespacho.ResumeLayout(False)
        Me.pnl_DireccionDespacho.PerformLayout()
        Me.pnl_reg_pedido.ResumeLayout(False)
        Me.pnl_reg_pedido.PerformLayout()
        Me.tbpg_despacho.ResumeLayout(False)
        Me.tbpg_despacho.PerformLayout()
        Me.pnl_reg_guia.ResumeLayout(False)
        Me.pnl_reg_guia.PerformLayout()
        CType(Me.dg_items_rms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_remisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpg_seguimiento.ResumeLayout(False)
        Me.pnl_cumplido_transportadora.ResumeLayout(False)
        Me.pnl_cumplido_transportadora.PerformLayout()
        Me.gb_soportes_cumplido.ResumeLayout(False)
        Me.gb_soportes_cumplido.PerformLayout()
        Me.pnl_verif_cliente.ResumeLayout(False)
        Me.pnl_verif_cliente.PerformLayout()
        Me.tbpg_reclamacion.ResumeLayout(False)
        Me.pnl_cierre_despacho.ResumeLayout(False)
        Me.pnl_cierre_despacho.PerformLayout()
        Me.pnl_reclamacion.ResumeLayout(False)
        Me.pnl_reclamacion.PerformLayout()
        Me.pnl_devolucion.ResumeLayout(False)
        Me.pnl_devolucion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbpg_pedido As System.Windows.Forms.TabPage
    Friend WithEvents pnl_reg_pedido As System.Windows.Forms.Panel
    Friend WithEvents tx_funcionario_registra_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cm_razon_social As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cm_nit As System.Windows.Forms.ComboBox
    Friend WithEvents tx_id_despacho As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cm_asesor As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cm_ciudad_destino As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha_registro As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents tbpg_despacho As System.Windows.Forms.TabPage
    Friend WithEvents pnl_reg_guia As System.Windows.Forms.Panel
    Friend WithEvents tx_funcionario_registra_guia_transp As System.Windows.Forms.TextBox
    Friend WithEvents bt_guia As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_registro_guia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tx_guia_transportadora As System.Windows.Forms.TextBox
    Friend WithEvents cm_transportadora_despacho As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbpg_seguimiento As System.Windows.Forms.TabPage
    Friend WithEvents pnl_cumplido_transportadora As System.Windows.Forms.Panel
    Friend WithEvents tx_funcionario_registra_cumplido_transp As System.Windows.Forms.TextBox
    Friend WithEvents bt_recepcion_cumplido As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_cumplido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tx_id_cumplido_transportadora As System.Windows.Forms.TextBox
    Friend WithEvents gb_soportes_cumplido As System.Windows.Forms.GroupBox
    Friend WithEvents bt_nuevo_soporte As System.Windows.Forms.Button
    Friend WithEvents bt_ver_archivos_asociados As System.Windows.Forms.Button
    Friend WithEvents lb_total_soportes_cumplido As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents pnl_verif_cliente As System.Windows.Forms.Panel
    Friend WithEvents tx_funcionario_verifica_recibo As System.Windows.Forms.TextBox
    Friend WithEvents bt_verificacion_recepcion As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tx_info_cliente_recibo As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha_verificacion_recibo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbpg_reclamacion As System.Windows.Forms.TabPage
    Friend WithEvents pnl_cierre_despacho As System.Windows.Forms.Panel
    Friend WithEvents tx_funcionario_cierra_pedido As System.Windows.Forms.TextBox
    Friend WithEvents bt_cerrar_pedido As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_cierre_pedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pnl_reclamacion As System.Windows.Forms.Panel
    Friend WithEvents pnl_devolucion As System.Windows.Forms.Panel
    Friend WithEvents tx_funcionario_registra_devolucion As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha_registro_devolucion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents bt_devolucion As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents tx_informacion_devolucion As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha_recibo_devolucion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cm_funcionario_recibe_devolucion As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tx_id_accion As System.Windows.Forms.TextBox
    Friend WithEvents bt_reclamacion As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dg_items_rms As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dg_remisiones As System.Windows.Forms.DataGridView
    Friend WithEvents bt_registrar_caja As System.Windows.Forms.Button
    Friend WithEvents tx_unidades_despachadas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_unidades_solicitadas As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tx_unidades_guia As System.Windows.Forms.TextBox
    Friend WithEvents bt_anular_guia As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tx_texto_reclamo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents tx_docto_devolucion As TextBox
    Friend WithEvents dgocell_rms_id_rem As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_rms_remision As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_rms_factura As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_rms_bonificado As DataGridViewCheckBoxColumn
    Friend WithEvents Btn_CambiarDireccion As Button
    Friend WithEvents pnl_DireccionDespacho As GroupBox
    Friend WithEvents bt_GrabarNuevaDireccion As Button
End Class
