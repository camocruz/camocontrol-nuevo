<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0300_orden_compra
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
        Me.bt_nueva_sc = New System.Windows.Forms.Button()
        Me.bt_actualizar_grilla = New System.Windows.Forms.Button()
        Me.bt_cargar_items_sc = New System.Windows.Forms.Button()
        Me.lb_valor_subtotal = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.bt_historico_compras = New System.Windows.Forms.Button()
        Me.tx_id_item_cons_mov = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.bt_solicitud_compra = New System.Windows.Forms.Button()
        Me.tx_sol_compra = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lb_valor_aprobado = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.bt_gestionar_tercero = New System.Windows.Forms.Button()
        Me.bt_catalago_items = New System.Windows.Forms.Button()
        Me.lb_valor_factura = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bt_aprobar = New System.Windows.Forms.Button()
        Me.tx_estado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bt_eliminar_item = New System.Windows.Forms.Button()
        Me.bt_add_item = New System.Windows.Forms.Button()
        Me.tx_id_item_sc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dg_listado = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_sc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_sc_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cod_uno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_complementaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cantidad_solicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_inventario_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_chk_item_aprobado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgcocell_chk_item_recepcionado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_var_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_unitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_unit_iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_costo_total_iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_descripcion_estructura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_accion_raiz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_nota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_fcc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_doc_inv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lb_identificacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_id_orden_compra = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.bt_listado_items_pend = New System.Windows.Forms.Button()
        Me.bt_desaprobar_oc = New System.Windows.Forms.Button()
        Me.Tx_Nombre_Tercero = New System.Windows.Forms.TextBox()
        Me.Tx_Nit = New System.Windows.Forms.TextBox()
        Me.tx_id_tercero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lb_fecha_aprob = New System.Windows.Forms.Label()
        Me.lb_IncumpleRequisitos = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.bt_gen_plano_oc_uno = New System.Windows.Forms.Button()
        Me.bt_actualizar_info_oc_siesa = New System.Windows.Forms.Button()
        Me.tx_oc_uno = New System.Windows.Forms.TextBox()
        Me.btn_consultarOcUnoEE = New System.Windows.Forms.Button()
        Me.btn_ItemsUnoEE = New System.Windows.Forms.Button()
        Me.btn_listado_items = New System.Windows.Forms.Button()
        Me.btn_proveedoresSiesa = New System.Windows.Forms.Button()
        Me.Tx_SucursalUnoEE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(1064, 7)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(1195, 11)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(1196, 44)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(91, 20)
        Me.lb_fecha.Text = "2018/03/11"
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(306, 42)
        Me.lb_titulo.Text = "Orden de Compra"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(280, 556)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 6, 5, 6)
        '
        'bt_grabar
        '
        '
        'bt_anular
        '
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 636)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'bt_generar_informe
        '
        '
        'bt_nueva_sc
        '
        Me.bt_nueva_sc.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_nueva_sc.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_nueva_sc.Location = New System.Drawing.Point(259, 258)
        Me.bt_nueva_sc.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_nueva_sc.Name = "bt_nueva_sc"
        Me.bt_nueva_sc.Size = New System.Drawing.Size(43, 42)
        Me.bt_nueva_sc.TabIndex = 294
        Me.bt_nueva_sc.UseVisualStyleBackColor = True
        '
        'bt_actualizar_grilla
        '
        Me.bt_actualizar_grilla.Image = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_actualizar_grilla.Location = New System.Drawing.Point(68, 171)
        Me.bt_actualizar_grilla.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_actualizar_grilla.Name = "bt_actualizar_grilla"
        Me.bt_actualizar_grilla.Size = New System.Drawing.Size(68, 66)
        Me.bt_actualizar_grilla.TabIndex = 293
        Me.bt_actualizar_grilla.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.bt_actualizar_grilla.UseVisualStyleBackColor = True
        '
        'bt_cargar_items_sc
        '
        Me.bt_cargar_items_sc.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_cargar_items_sc.Location = New System.Drawing.Point(302, 258)
        Me.bt_cargar_items_sc.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_cargar_items_sc.Name = "bt_cargar_items_sc"
        Me.bt_cargar_items_sc.Size = New System.Drawing.Size(43, 42)
        Me.bt_cargar_items_sc.TabIndex = 292
        Me.bt_cargar_items_sc.UseVisualStyleBackColor = True
        '
        'lb_valor_subtotal
        '
        Me.lb_valor_subtotal.AutoSize = True
        Me.lb_valor_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_subtotal.Location = New System.Drawing.Point(397, 186)
        Me.lb_valor_subtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_valor_subtotal.Name = "lb_valor_subtotal"
        Me.lb_valor_subtotal.Size = New System.Drawing.Size(32, 36)
        Me.lb_valor_subtotal.TabIndex = 291
        Me.lb_valor_subtotal.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(148, 186)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(212, 36)
        Me.Label19.TabIndex = 290
        Me.Label19.Text = "Valor Subtotal:"
        '
        'bt_historico_compras
        '
        Me.bt_historico_compras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_historico_compras.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_historico_compras.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_historico_compras.Location = New System.Drawing.Point(1171, 534)
        Me.bt_historico_compras.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_historico_compras.Name = "bt_historico_compras"
        Me.bt_historico_compras.Size = New System.Drawing.Size(43, 42)
        Me.bt_historico_compras.TabIndex = 288
        Me.bt_historico_compras.UseVisualStyleBackColor = True
        '
        'tx_id_item_cons_mov
        '
        Me.tx_id_item_cons_mov.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_id_item_cons_mov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_cons_mov.Location = New System.Drawing.Point(1171, 506)
        Me.tx_id_item_cons_mov.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_id_item_cons_mov.Name = "tx_id_item_cons_mov"
        Me.tx_id_item_cons_mov.Size = New System.Drawing.Size(104, 26)
        Me.tx_id_item_cons_mov.TabIndex = 287
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1093, 510)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 286
        Me.Label3.Text = "Id_item:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1010, 82)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 20)
        Me.Label13.TabIndex = 282
        Me.Label13.Text = "Fecha:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(1079, 76)
        Me.dtp_fecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(196, 26)
        Me.dtp_fecha.TabIndex = 280
        '
        'bt_solicitud_compra
        '
        Me.bt_solicitud_compra.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_solicitud_compra.Location = New System.Drawing.Point(216, 258)
        Me.bt_solicitud_compra.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_solicitud_compra.Name = "bt_solicitud_compra"
        Me.bt_solicitud_compra.Size = New System.Drawing.Size(43, 42)
        Me.bt_solicitud_compra.TabIndex = 279
        Me.bt_solicitud_compra.UseVisualStyleBackColor = True
        '
        'tx_sol_compra
        '
        Me.tx_sol_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_sol_compra.Location = New System.Drawing.Point(103, 260)
        Me.tx_sol_compra.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_sol_compra.Name = "tx_sol_compra"
        Me.tx_sol_compra.Size = New System.Drawing.Size(104, 26)
        Me.tx_sol_compra.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 263)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 20)
        Me.Label11.TabIndex = 277
        Me.Label11.Text = "Id_SC:"
        '
        'lb_valor_aprobado
        '
        Me.lb_valor_aprobado.AutoSize = True
        Me.lb_valor_aprobado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_aprobado.Location = New System.Drawing.Point(397, 153)
        Me.lb_valor_aprobado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_valor_aprobado.Name = "lb_valor_aprobado"
        Me.lb_valor_aprobado.Size = New System.Drawing.Size(32, 36)
        Me.lb_valor_aprobado.TabIndex = 276
        Me.lb_valor_aprobado.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(148, 153)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(234, 36)
        Me.Label12.TabIndex = 275
        Me.Label12.Text = "Valor Aprobado:"
        '
        'bt_gestionar_tercero
        '
        Me.bt_gestionar_tercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_gestionar_tercero.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.bt_gestionar_tercero.Location = New System.Drawing.Point(905, 211)
        Me.bt_gestionar_tercero.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_gestionar_tercero.Name = "bt_gestionar_tercero"
        Me.bt_gestionar_tercero.Size = New System.Drawing.Size(100, 48)
        Me.bt_gestionar_tercero.TabIndex = 274
        Me.bt_gestionar_tercero.Text = "Gestion Terceros"
        Me.bt_gestionar_tercero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_gestionar_tercero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_gestionar_tercero.UseVisualStyleBackColor = True
        '
        'bt_catalago_items
        '
        Me.bt_catalago_items.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_catalago_items.Image = Global.camocontrol.My.Resources.Resources.icono_herramientas
        Me.bt_catalago_items.Location = New System.Drawing.Point(1069, 211)
        Me.bt_catalago_items.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_catalago_items.Name = "bt_catalago_items"
        Me.bt_catalago_items.Size = New System.Drawing.Size(156, 48)
        Me.bt_catalago_items.TabIndex = 273
        Me.bt_catalago_items.Text = "Gestion Items"
        Me.bt_catalago_items.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_catalago_items.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_catalago_items.UseVisualStyleBackColor = True
        '
        'lb_valor_factura
        '
        Me.lb_valor_factura.AutoSize = True
        Me.lb_valor_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_valor_factura.Location = New System.Drawing.Point(397, 218)
        Me.lb_valor_factura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_valor_factura.Name = "lb_valor_factura"
        Me.lb_valor_factura.Size = New System.Drawing.Size(32, 36)
        Me.lb_valor_factura.TabIndex = 272
        Me.lb_valor_factura.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(148, 218)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(202, 36)
        Me.Label10.TabIndex = 271
        Me.Label10.Text = "Valor Factura:"
        '
        'bt_aprobar
        '
        Me.bt_aprobar.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_aprobar.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_aprobar.Location = New System.Drawing.Point(702, 159)
        Me.bt_aprobar.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_aprobar.Name = "bt_aprobar"
        Me.bt_aprobar.Size = New System.Drawing.Size(156, 48)
        Me.bt_aprobar.TabIndex = 268
        Me.bt_aprobar.Text = "Aprobar OC"
        Me.bt_aprobar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_aprobar.UseVisualStyleBackColor = False
        '
        'tx_estado
        '
        Me.tx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estado.Location = New System.Drawing.Point(517, 75)
        Me.tx_estado.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_estado.Name = "tx_estado"
        Me.tx_estado.Size = New System.Drawing.Size(219, 26)
        Me.tx_estado.TabIndex = 267
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(437, 78)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 266
        Me.Label7.Text = "Estado:"
        '
        'bt_eliminar_item
        '
        Me.bt_eliminar_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_eliminar_item.Location = New System.Drawing.Point(642, 260)
        Me.bt_eliminar_item.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_eliminar_item.Name = "bt_eliminar_item"
        Me.bt_eliminar_item.Size = New System.Drawing.Size(43, 42)
        Me.bt_eliminar_item.TabIndex = 260
        Me.bt_eliminar_item.UseVisualStyleBackColor = True
        '
        'bt_add_item
        '
        Me.bt_add_item.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_add_item.Location = New System.Drawing.Point(590, 260)
        Me.bt_add_item.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_add_item.Name = "bt_add_item"
        Me.bt_add_item.Size = New System.Drawing.Size(43, 42)
        Me.bt_add_item.TabIndex = 259
        Me.bt_add_item.Text = "Ad"
        Me.bt_add_item.UseVisualStyleBackColor = True
        '
        'tx_id_item_sc
        '
        Me.tx_id_item_sc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_sc.Location = New System.Drawing.Point(477, 260)
        Me.tx_id_item_sc.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_id_item_sc.Name = "tx_id_item_sc"
        Me.tx_id_item_sc.Size = New System.Drawing.Size(104, 26)
        Me.tx_id_item_sc.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(371, 263)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Id_item_SC:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(35, 298)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 20)
        Me.Label4.TabIndex = 256
        Me.Label4.Text = "Items solicitados:"
        '
        'dg_listado
        '
        Me.dg_listado.AllowUserToAddRows = False
        Me.dg_listado.AllowUserToDeleteRows = False
        Me.dg_listado.AllowUserToOrderColumns = True
        Me.dg_listado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_listado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_sc, Me.dgocell_id_sc_item, Me.dgocell_item, Me.dgocell_cod_uno, Me.dgocell_descripcion_item, Me.dgocell_descripcion_complementaria, Me.dgocell_cantidad_solicitada, Me.dgocell_inventario_total, Me.dgocell_unidad, Me.dgocell_chk_item_aprobado, Me.dgcocell_chk_item_recepcionado, Me.dgocell_var_costo, Me.dgocell_costo_unitario, Me.dgocell_descuento, Me.dgocell_costo_total, Me.dgocell_iva, Me.dgocell_costo_unit_iva, Me.dgocell_costo_total_iva, Me.dgocell_descripcion_estructura, Me.dgocell_id_accion, Me.dgocell_id_accion_raiz, Me.dgocell_nota, Me.dgocell_id_fcc, Me.dgocell_id_doc_inv})
        Me.dg_listado.Location = New System.Drawing.Point(37, 322)
        Me.dg_listado.Margin = New System.Windows.Forms.Padding(4)
        Me.dg_listado.Name = "dg_listado"
        Me.dg_listado.RowHeadersWidth = 62
        Me.dg_listado.Size = New System.Drawing.Size(1239, 178)
        Me.dg_listado.TabIndex = 255
        '
        'dgocell_id_sc
        '
        Me.dgocell_id_sc.HeaderText = "Id_SC"
        Me.dgocell_id_sc.MinimumWidth = 8
        Me.dgocell_id_sc.Name = "dgocell_id_sc"
        Me.dgocell_id_sc.ReadOnly = True
        Me.dgocell_id_sc.Width = 50
        '
        'dgocell_id_sc_item
        '
        Me.dgocell_id_sc_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_id_sc_item.HeaderText = "Id_sc_item"
        Me.dgocell_id_sc_item.MinimumWidth = 8
        Me.dgocell_id_sc_item.Name = "dgocell_id_sc_item"
        Me.dgocell_id_sc_item.ReadOnly = True
        Me.dgocell_id_sc_item.Width = 8
        '
        'dgocell_item
        '
        Me.dgocell_item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_item.HeaderText = "Cod_Item"
        Me.dgocell_item.MinimumWidth = 8
        Me.dgocell_item.Name = "dgocell_item"
        Me.dgocell_item.ReadOnly = True
        Me.dgocell_item.Width = 8
        '
        'dgocell_cod_uno
        '
        Me.dgocell_cod_uno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_cod_uno.HeaderText = "Cod_Uno"
        Me.dgocell_cod_uno.MinimumWidth = 8
        Me.dgocell_cod_uno.Name = "dgocell_cod_uno"
        Me.dgocell_cod_uno.ReadOnly = True
        Me.dgocell_cod_uno.Width = 8
        '
        'dgocell_descripcion_item
        '
        Me.dgocell_descripcion_item.HeaderText = "Item"
        Me.dgocell_descripcion_item.MinimumWidth = 8
        Me.dgocell_descripcion_item.Name = "dgocell_descripcion_item"
        Me.dgocell_descripcion_item.ReadOnly = True
        Me.dgocell_descripcion_item.Width = 200
        '
        'dgocell_descripcion_complementaria
        '
        Me.dgocell_descripcion_complementaria.HeaderText = "Descripcion Complementaria"
        Me.dgocell_descripcion_complementaria.MinimumWidth = 8
        Me.dgocell_descripcion_complementaria.Name = "dgocell_descripcion_complementaria"
        Me.dgocell_descripcion_complementaria.ReadOnly = True
        Me.dgocell_descripcion_complementaria.Width = 200
        '
        'dgocell_cantidad_solicitada
        '
        Me.dgocell_cantidad_solicitada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_cantidad_solicitada.HeaderText = "Cant. Sol."
        Me.dgocell_cantidad_solicitada.MinimumWidth = 40
        Me.dgocell_cantidad_solicitada.Name = "dgocell_cantidad_solicitada"
        Me.dgocell_cantidad_solicitada.ReadOnly = True
        Me.dgocell_cantidad_solicitada.Width = 40
        '
        'dgocell_inventario_total
        '
        Me.dgocell_inventario_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_inventario_total.HeaderText = "Inventarario"
        Me.dgocell_inventario_total.MinimumWidth = 8
        Me.dgocell_inventario_total.Name = "dgocell_inventario_total"
        Me.dgocell_inventario_total.Width = 106
        '
        'dgocell_unidad
        '
        Me.dgocell_unidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_unidad.HeaderText = "Unidad"
        Me.dgocell_unidad.MinimumWidth = 8
        Me.dgocell_unidad.Name = "dgocell_unidad"
        Me.dgocell_unidad.ReadOnly = True
        Me.dgocell_unidad.Width = 8
        '
        'dgocell_chk_item_aprobado
        '
        Me.dgocell_chk_item_aprobado.HeaderText = "Apb"
        Me.dgocell_chk_item_aprobado.MinimumWidth = 8
        Me.dgocell_chk_item_aprobado.Name = "dgocell_chk_item_aprobado"
        Me.dgocell_chk_item_aprobado.ReadOnly = True
        Me.dgocell_chk_item_aprobado.Width = 30
        '
        'dgcocell_chk_item_recepcionado
        '
        Me.dgcocell_chk_item_recepcionado.HeaderText = "Rcd"
        Me.dgcocell_chk_item_recepcionado.MinimumWidth = 8
        Me.dgcocell_chk_item_recepcionado.Name = "dgcocell_chk_item_recepcionado"
        Me.dgcocell_chk_item_recepcionado.ReadOnly = True
        Me.dgcocell_chk_item_recepcionado.Width = 30
        '
        'dgocell_var_costo
        '
        Me.dgocell_var_costo.HeaderText = "%V"
        Me.dgocell_var_costo.MinimumWidth = 8
        Me.dgocell_var_costo.Name = "dgocell_var_costo"
        Me.dgocell_var_costo.ReadOnly = True
        Me.dgocell_var_costo.Width = 40
        '
        'dgocell_costo_unitario
        '
        Me.dgocell_costo_unitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_costo_unitario.HeaderText = "$_Unit"
        Me.dgocell_costo_unitario.MinimumWidth = 60
        Me.dgocell_costo_unitario.Name = "dgocell_costo_unitario"
        Me.dgocell_costo_unitario.ReadOnly = True
        Me.dgocell_costo_unitario.Width = 60
        '
        'dgocell_descuento
        '
        Me.dgocell_descuento.HeaderText = "%_Desc"
        Me.dgocell_descuento.MinimumWidth = 40
        Me.dgocell_descuento.Name = "dgocell_descuento"
        Me.dgocell_descuento.ReadOnly = True
        Me.dgocell_descuento.Width = 40
        '
        'dgocell_costo_total
        '
        Me.dgocell_costo_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_costo_total.HeaderText = "$_Sub_T"
        Me.dgocell_costo_total.MinimumWidth = 60
        Me.dgocell_costo_total.Name = "dgocell_costo_total"
        Me.dgocell_costo_total.ReadOnly = True
        Me.dgocell_costo_total.Width = 60
        '
        'dgocell_iva
        '
        Me.dgocell_iva.HeaderText = "IVA"
        Me.dgocell_iva.MinimumWidth = 40
        Me.dgocell_iva.Name = "dgocell_iva"
        Me.dgocell_iva.ReadOnly = True
        Me.dgocell_iva.Width = 40
        '
        'dgocell_costo_unit_iva
        '
        Me.dgocell_costo_unit_iva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_costo_unit_iva.HeaderText = "$_unit_IVA"
        Me.dgocell_costo_unit_iva.MinimumWidth = 60
        Me.dgocell_costo_unit_iva.Name = "dgocell_costo_unit_iva"
        Me.dgocell_costo_unit_iva.Width = 60
        '
        'dgocell_costo_total_iva
        '
        Me.dgocell_costo_total_iva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_costo_total_iva.HeaderText = "$_Tot_IVA"
        Me.dgocell_costo_total_iva.MinimumWidth = 60
        Me.dgocell_costo_total_iva.Name = "dgocell_costo_total_iva"
        Me.dgocell_costo_total_iva.ReadOnly = True
        Me.dgocell_costo_total_iva.Width = 60
        '
        'dgocell_descripcion_estructura
        '
        Me.dgocell_descripcion_estructura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgocell_descripcion_estructura.HeaderText = "Estructura"
        Me.dgocell_descripcion_estructura.MinimumWidth = 8
        Me.dgocell_descripcion_estructura.Name = "dgocell_descripcion_estructura"
        Me.dgocell_descripcion_estructura.ReadOnly = True
        Me.dgocell_descripcion_estructura.Width = 8
        '
        'dgocell_id_accion
        '
        Me.dgocell_id_accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgocell_id_accion.HeaderText = "id_acc"
        Me.dgocell_id_accion.MinimumWidth = 8
        Me.dgocell_id_accion.Name = "dgocell_id_accion"
        Me.dgocell_id_accion.ReadOnly = True
        Me.dgocell_id_accion.Width = 45
        '
        'dgocell_id_accion_raiz
        '
        Me.dgocell_id_accion_raiz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_id_accion_raiz.HeaderText = "Raiz"
        Me.dgocell_id_accion_raiz.MinimumWidth = 8
        Me.dgocell_id_accion_raiz.Name = "dgocell_id_accion_raiz"
        Me.dgocell_id_accion_raiz.Width = 8
        '
        'dgocell_nota
        '
        Me.dgocell_nota.HeaderText = "Nota"
        Me.dgocell_nota.MinimumWidth = 8
        Me.dgocell_nota.Name = "dgocell_nota"
        Me.dgocell_nota.ReadOnly = True
        Me.dgocell_nota.Width = 200
        '
        'dgocell_id_fcc
        '
        Me.dgocell_id_fcc.HeaderText = "id_fcc"
        Me.dgocell_id_fcc.MinimumWidth = 8
        Me.dgocell_id_fcc.Name = "dgocell_id_fcc"
        Me.dgocell_id_fcc.ReadOnly = True
        Me.dgocell_id_fcc.Width = 50
        '
        'dgocell_id_doc_inv
        '
        Me.dgocell_id_doc_inv.HeaderText = "id_doc_inv"
        Me.dgocell_id_doc_inv.MinimumWidth = 8
        Me.dgocell_id_doc_inv.Name = "dgocell_id_doc_inv"
        Me.dgocell_id_doc_inv.ReadOnly = True
        Me.dgocell_id_doc_inv.Width = 150
        '
        'lb_identificacion
        '
        Me.lb_identificacion.AutoSize = True
        Me.lb_identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_identificacion.Location = New System.Drawing.Point(690, 123)
        Me.lb_identificacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_identificacion.Name = "lb_identificacion"
        Me.lb_identificacion.Size = New System.Drawing.Size(158, 20)
        Me.lb_identificacion.TabIndex = 254
        Me.lb_identificacion.Text = "Identificación / NIT :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 119)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 20)
        Me.Label5.TabIndex = 252
        Me.Label5.Text = "Proveedor:"
        '
        'tx_id_orden_compra
        '
        Me.tx_id_orden_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_orden_compra.Location = New System.Drawing.Point(155, 76)
        Me.tx_id_orden_compra.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_id_orden_compra.Name = "tx_id_orden_compra"
        Me.tx_id_orden_compra.Size = New System.Drawing.Size(267, 34)
        Me.tx_id_orden_compra.TabIndex = 251
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(34, 80)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 20)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "OC #:"
        '
        'bt_listado_items_pend
        '
        Me.bt_listado_items_pend.BackgroundImage = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_32
        Me.bt_listado_items_pend.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_listado_items_pend.Location = New System.Drawing.Point(692, 260)
        Me.bt_listado_items_pend.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_listado_items_pend.Name = "bt_listado_items_pend"
        Me.bt_listado_items_pend.Size = New System.Drawing.Size(43, 42)
        Me.bt_listado_items_pend.TabIndex = 295
        Me.bt_listado_items_pend.UseVisualStyleBackColor = True
        '
        'bt_desaprobar_oc
        '
        Me.bt_desaprobar_oc.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_desaprobar_oc.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_desaprobar_oc.Location = New System.Drawing.Point(901, 162)
        Me.bt_desaprobar_oc.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_desaprobar_oc.Name = "bt_desaprobar_oc"
        Me.bt_desaprobar_oc.Size = New System.Drawing.Size(156, 48)
        Me.bt_desaprobar_oc.TabIndex = 296
        Me.bt_desaprobar_oc.Text = "Desaprobar OC"
        Me.bt_desaprobar_oc.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_desaprobar_oc.UseVisualStyleBackColor = False
        '
        'Tx_Nombre_Tercero
        '
        Me.Tx_Nombre_Tercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Nombre_Tercero.Location = New System.Drawing.Point(155, 116)
        Me.Tx_Nombre_Tercero.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_Nombre_Tercero.Name = "Tx_Nombre_Tercero"
        Me.Tx_Nombre_Tercero.Size = New System.Drawing.Size(528, 26)
        Me.Tx_Nombre_Tercero.TabIndex = 0
        '
        'Tx_Nit
        '
        Me.Tx_Nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_Nit.Location = New System.Drawing.Point(877, 116)
        Me.Tx_Nit.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_Nit.Name = "Tx_Nit"
        Me.Tx_Nit.Size = New System.Drawing.Size(207, 26)
        Me.Tx_Nit.TabIndex = 1
        '
        'tx_id_tercero
        '
        Me.tx_id_tercero.Enabled = False
        Me.tx_id_tercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_tercero.Location = New System.Drawing.Point(1128, 116)
        Me.tx_id_tercero.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_id_tercero.Name = "tx_id_tercero"
        Me.tx_id_tercero.Size = New System.Drawing.Size(146, 26)
        Me.tx_id_tercero.TabIndex = 299
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1093, 123)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 20)
        Me.Label2.TabIndex = 300
        Me.Label2.Text = "Id :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(152, 142)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 15)
        Me.Label9.TabIndex = 301
        Me.Label9.Text = "Ctrl+B"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(875, 144)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 15)
        Me.Label14.TabIndex = 302
        Me.Label14.Text = "Ctrl+B"
        '
        'lb_fecha_aprob
        '
        Me.lb_fecha_aprob.AutoSize = True
        Me.lb_fecha_aprob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha_aprob.Location = New System.Drawing.Point(707, 212)
        Me.lb_fecha_aprob.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_fecha_aprob.Name = "lb_fecha_aprob"
        Me.lb_fecha_aprob.Size = New System.Drawing.Size(21, 20)
        Me.lb_fecha_aprob.TabIndex = 357
        Me.lb_fecha_aprob.Text = "..."
        '
        'lb_IncumpleRequisitos
        '
        Me.lb_IncumpleRequisitos.AutoSize = True
        Me.lb_IncumpleRequisitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_IncumpleRequisitos.Location = New System.Drawing.Point(745, 293)
        Me.lb_IncumpleRequisitos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_IncumpleRequisitos.Name = "lb_IncumpleRequisitos"
        Me.lb_IncumpleRequisitos.Size = New System.Drawing.Size(27, 25)
        Me.lb_IncumpleRequisitos.TabIndex = 365
        Me.lb_IncumpleRequisitos.Text = "..."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1095, 158)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 367
        Me.Label15.Text = "OC-SIESA :"
        '
        'bt_gen_plano_oc_uno
        '
        Me.bt_gen_plano_oc_uno.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_gen_plano_oc_uno.Location = New System.Drawing.Point(859, 162)
        Me.bt_gen_plano_oc_uno.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_gen_plano_oc_uno.Name = "bt_gen_plano_oc_uno"
        Me.bt_gen_plano_oc_uno.Size = New System.Drawing.Size(43, 42)
        Me.bt_gen_plano_oc_uno.TabIndex = 368
        Me.bt_gen_plano_oc_uno.UseVisualStyleBackColor = True
        '
        'bt_actualizar_info_oc_siesa
        '
        Me.bt_actualizar_info_oc_siesa.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_actualizar_info_oc_siesa.Location = New System.Drawing.Point(1181, 166)
        Me.bt_actualizar_info_oc_siesa.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_actualizar_info_oc_siesa.Name = "bt_actualizar_info_oc_siesa"
        Me.bt_actualizar_info_oc_siesa.Size = New System.Drawing.Size(43, 42)
        Me.bt_actualizar_info_oc_siesa.TabIndex = 369
        Me.bt_actualizar_info_oc_siesa.UseVisualStyleBackColor = True
        '
        'tx_oc_uno
        '
        Me.tx_oc_uno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_oc_uno.Location = New System.Drawing.Point(1083, 176)
        Me.tx_oc_uno.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tx_oc_uno.Name = "tx_oc_uno"
        Me.tx_oc_uno.Size = New System.Drawing.Size(93, 22)
        Me.tx_oc_uno.TabIndex = 371
        '
        'btn_consultarOcUnoEE
        '
        Me.btn_consultarOcUnoEE.Location = New System.Drawing.Point(905, 260)
        Me.btn_consultarOcUnoEE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_consultarOcUnoEE.Name = "btn_consultarOcUnoEE"
        Me.btn_consultarOcUnoEE.Size = New System.Drawing.Size(156, 35)
        Me.btn_consultarOcUnoEE.TabIndex = 372
        Me.btn_consultarOcUnoEE.Text = "OC UnoEE"
        Me.btn_consultarOcUnoEE.UseVisualStyleBackColor = True
        '
        'btn_ItemsUnoEE
        '
        Me.btn_ItemsUnoEE.Location = New System.Drawing.Point(1069, 260)
        Me.btn_ItemsUnoEE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_ItemsUnoEE.Name = "btn_ItemsUnoEE"
        Me.btn_ItemsUnoEE.Size = New System.Drawing.Size(156, 35)
        Me.btn_ItemsUnoEE.TabIndex = 373
        Me.btn_ItemsUnoEE.Text = "Items UnoEE"
        Me.btn_ItemsUnoEE.UseVisualStyleBackColor = True
        '
        'btn_listado_items
        '
        Me.btn_listado_items.Location = New System.Drawing.Point(508, 289)
        Me.btn_listado_items.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_listado_items.Name = "btn_listado_items"
        Me.btn_listado_items.Size = New System.Drawing.Size(34, 27)
        Me.btn_listado_items.TabIndex = 374
        Me.btn_listado_items.Text = "IT"
        Me.btn_listado_items.UseVisualStyleBackColor = True
        '
        'btn_proveedoresSiesa
        '
        Me.btn_proveedoresSiesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_proveedoresSiesa.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.btn_proveedoresSiesa.Location = New System.Drawing.Point(1007, 211)
        Me.btn_proveedoresSiesa.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_proveedoresSiesa.Name = "btn_proveedoresSiesa"
        Me.btn_proveedoresSiesa.Size = New System.Drawing.Size(55, 48)
        Me.btn_proveedoresSiesa.TabIndex = 375
        Me.btn_proveedoresSiesa.Text = "TS"
        Me.btn_proveedoresSiesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_proveedoresSiesa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_proveedoresSiesa.UseVisualStyleBackColor = True
        '
        'Tx_SucursalUnoEE
        '
        Me.Tx_SucursalUnoEE.Enabled = False
        Me.Tx_SucursalUnoEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tx_SucursalUnoEE.Location = New System.Drawing.Point(877, 82)
        Me.Tx_SucursalUnoEE.Margin = New System.Windows.Forms.Padding(4)
        Me.Tx_SucursalUnoEE.Name = "Tx_SucursalUnoEE"
        Me.Tx_SucursalUnoEE.Size = New System.Drawing.Size(126, 26)
        Me.Tx_SucursalUnoEE.TabIndex = 376
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(788, 86)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 20)
        Me.Label6.TabIndex = 377
        Me.Label6.Text = "SucEE:"
        '
        'fm_0300_orden_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1310, 652)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Tx_SucursalUnoEE)
        Me.Controls.Add(Me.btn_proveedoresSiesa)
        Me.Controls.Add(Me.btn_listado_items)
        Me.Controls.Add(Me.btn_ItemsUnoEE)
        Me.Controls.Add(Me.btn_consultarOcUnoEE)
        Me.Controls.Add(Me.tx_oc_uno)
        Me.Controls.Add(Me.bt_actualizar_info_oc_siesa)
        Me.Controls.Add(Me.bt_gen_plano_oc_uno)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lb_IncumpleRequisitos)
        Me.Controls.Add(Me.lb_fecha_aprob)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_id_tercero)
        Me.Controls.Add(Me.Tx_Nit)
        Me.Controls.Add(Me.Tx_Nombre_Tercero)
        Me.Controls.Add(Me.bt_desaprobar_oc)
        Me.Controls.Add(Me.bt_listado_items_pend)
        Me.Controls.Add(Me.bt_nueva_sc)
        Me.Controls.Add(Me.bt_actualizar_grilla)
        Me.Controls.Add(Me.bt_cargar_items_sc)
        Me.Controls.Add(Me.lb_valor_subtotal)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.bt_historico_compras)
        Me.Controls.Add(Me.tx_id_item_cons_mov)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.bt_solicitud_compra)
        Me.Controls.Add(Me.tx_sol_compra)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lb_valor_aprobado)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.bt_gestionar_tercero)
        Me.Controls.Add(Me.bt_catalago_items)
        Me.Controls.Add(Me.lb_valor_factura)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.bt_aprobar)
        Me.Controls.Add(Me.tx_estado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.bt_eliminar_item)
        Me.Controls.Add(Me.bt_add_item)
        Me.Controls.Add(Me.tx_id_item_sc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dg_listado)
        Me.Controls.Add(Me.lb_identificacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_id_orden_compra)
        Me.Controls.Add(Me.Label8)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "fm_0300_orden_compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_id_orden_compra, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lb_identificacion, 0)
        Me.Controls.SetChildIndex(Me.dg_listado, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_add_item, 0)
        Me.Controls.SetChildIndex(Me.bt_eliminar_item, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_estado, 0)
        Me.Controls.SetChildIndex(Me.bt_aprobar, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_factura, 0)
        Me.Controls.SetChildIndex(Me.bt_catalago_items, 0)
        Me.Controls.SetChildIndex(Me.bt_gestionar_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_aprobado, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tx_sol_compra, 0)
        Me.Controls.SetChildIndex(Me.bt_solicitud_compra, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_cons_mov, 0)
        Me.Controls.SetChildIndex(Me.bt_historico_compras, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.lb_valor_subtotal, 0)
        Me.Controls.SetChildIndex(Me.bt_cargar_items_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_actualizar_grilla, 0)
        Me.Controls.SetChildIndex(Me.bt_nueva_sc, 0)
        Me.Controls.SetChildIndex(Me.bt_listado_items_pend, 0)
        Me.Controls.SetChildIndex(Me.bt_desaprobar_oc, 0)
        Me.Controls.SetChildIndex(Me.Tx_Nombre_Tercero, 0)
        Me.Controls.SetChildIndex(Me.Tx_Nit, 0)
        Me.Controls.SetChildIndex(Me.tx_id_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha_aprob, 0)
        Me.Controls.SetChildIndex(Me.lb_IncumpleRequisitos, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.bt_gen_plano_oc_uno, 0)
        Me.Controls.SetChildIndex(Me.bt_actualizar_info_oc_siesa, 0)
        Me.Controls.SetChildIndex(Me.tx_oc_uno, 0)
        Me.Controls.SetChildIndex(Me.btn_consultarOcUnoEE, 0)
        Me.Controls.SetChildIndex(Me.btn_ItemsUnoEE, 0)
        Me.Controls.SetChildIndex(Me.btn_listado_items, 0)
        Me.Controls.SetChildIndex(Me.btn_proveedoresSiesa, 0)
        Me.Controls.SetChildIndex(Me.Tx_SucursalUnoEE, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bt_nueva_sc As Button
    Friend WithEvents bt_actualizar_grilla As Button
    Friend WithEvents bt_cargar_items_sc As Button
    Friend WithEvents lb_valor_subtotal As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents bt_historico_compras As Button
    Friend WithEvents tx_id_item_cons_mov As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents bt_solicitud_compra As Button
    Friend WithEvents tx_sol_compra As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lb_valor_aprobado As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents bt_gestionar_tercero As Button
    Friend WithEvents bt_catalago_items As Button
    Friend WithEvents lb_valor_factura As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents bt_aprobar As Button
    Friend WithEvents tx_estado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents bt_eliminar_item As Button
    Friend WithEvents bt_add_item As Button
    Friend WithEvents tx_id_item_sc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dg_listado As DataGridView
    Friend WithEvents lb_identificacion As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tx_id_orden_compra As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents bt_listado_items_pend As Button
    Friend WithEvents bt_desaprobar_oc As Button
    Friend WithEvents dgocell_id_sc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_sc_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cod_uno As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_item As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_complementaria As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cantidad_solicitada As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_inventario_total As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_unidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_chk_item_aprobado As DataGridViewTextBoxColumn
    Friend WithEvents dgcocell_chk_item_recepcionado As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_var_costo As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_unitario As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descuento As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_total As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_iva As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_unit_iva As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_costo_total_iva As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_descripcion_estructura As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_accion As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_accion_raiz As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_nota As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_fcc As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_doc_inv As DataGridViewTextBoxColumn
    Friend WithEvents Tx_Nombre_Tercero As TextBox
    Friend WithEvents Tx_Nit As TextBox
    Friend WithEvents tx_id_tercero As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lb_fecha_aprob As Label
    Friend WithEvents lb_IncumpleRequisitos As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents bt_gen_plano_oc_uno As Button
    Friend WithEvents bt_actualizar_info_oc_siesa As Button
    Friend WithEvents tx_oc_uno As TextBox
    Friend WithEvents btn_consultarOcUnoEE As Button
    Friend WithEvents btn_ItemsUnoEE As Button
    Friend WithEvents btn_listado_items As Button
    Friend WithEvents btn_proveedoresSiesa As Button
    Friend WithEvents Tx_SucursalUnoEE As TextBox
    Friend WithEvents Label6 As Label
End Class
