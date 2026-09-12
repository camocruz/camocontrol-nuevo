<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_pp_ordenes_produccion_arbol
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.components = New System.ComponentModel.Container()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mi_imprimir_etiqueta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_personal_asociado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_registros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_reporte_produccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_reporte_produccion_nuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_reporte_produccion_consultar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_ajustar_cantidad_bache = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_cerrar_item_programado = New System.Windows.Forms.ToolStripMenuItem()
        Me.bt_nueva_orden_de_produccion = New System.Windows.Forms.Button()
        Me.tx_id_registro = New System.Windows.Forms.TextBox()
        Me.lb_tipo_registro = New System.Windows.Forms.Label()
        Me.bt_editar_op = New System.Windows.Forms.Button()
        Me.tx_cantidad_ordenada = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_cantidad_programada = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_cantidad_producida = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_producto = New System.Windows.Forms.Label()
        Me.bt_anular_op = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(1155, 11)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(1156, 44)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(91, 20)
        Me.lb_fecha.Text = "2016/03/02"
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(1035, 7)
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(385, 42)
        Me.lb_titulo.Text = "Ordenes de Produccion"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 588)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(441, 543)
        Me.bt_salir.Margin = New System.Windows.Forms.Padding(5)
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.SystemColors.Info
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeView1.HotTracking = True
        Me.TreeView1.Indent = 19
        Me.TreeView1.ItemHeight = 17
        Me.TreeView1.Location = New System.Drawing.Point(16, 137)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(4)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(1131, 394)
        Me.TreeView1.TabIndex = 63
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_imprimir_etiqueta, Me.mi_personal_asociado, Me.mi_registros, Me.mi_reporte_produccion, Me.mi_ajustar_cantidad_bache, Me.mi_cerrar_item_programado})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(255, 148)
        '
        'mi_imprimir_etiqueta
        '
        Me.mi_imprimir_etiqueta.Name = "mi_imprimir_etiqueta"
        Me.mi_imprimir_etiqueta.Size = New System.Drawing.Size(254, 24)
        Me.mi_imprimir_etiqueta.Text = "Etiquetas de Identificacion"
        '
        'mi_personal_asociado
        '
        Me.mi_personal_asociado.Name = "mi_personal_asociado"
        Me.mi_personal_asociado.Size = New System.Drawing.Size(254, 24)
        Me.mi_personal_asociado.Text = "Personal Asociado"
        '
        'mi_registros
        '
        Me.mi_registros.Name = "mi_registros"
        Me.mi_registros.Size = New System.Drawing.Size(254, 24)
        Me.mi_registros.Text = "Registros Asociados"
        '
        'mi_reporte_produccion
        '
        Me.mi_reporte_produccion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_reporte_produccion_nuevo, Me.mi_reporte_produccion_consultar})
        Me.mi_reporte_produccion.Name = "mi_reporte_produccion"
        Me.mi_reporte_produccion.Size = New System.Drawing.Size(254, 24)
        Me.mi_reporte_produccion.Text = "Reporte de Produccion"
        '
        'mi_reporte_produccion_nuevo
        '
        Me.mi_reporte_produccion_nuevo.Name = "mi_reporte_produccion_nuevo"
        Me.mi_reporte_produccion_nuevo.Size = New System.Drawing.Size(207, 26)
        Me.mi_reporte_produccion_nuevo.Text = "Nuevo"
        '
        'mi_reporte_produccion_consultar
        '
        Me.mi_reporte_produccion_consultar.Name = "mi_reporte_produccion_consultar"
        Me.mi_reporte_produccion_consultar.Size = New System.Drawing.Size(207, 26)
        Me.mi_reporte_produccion_consultar.Text = "Consultar / Editar"
        '
        'mi_ajustar_cantidad_bache
        '
        Me.mi_ajustar_cantidad_bache.Name = "mi_ajustar_cantidad_bache"
        Me.mi_ajustar_cantidad_bache.Size = New System.Drawing.Size(254, 24)
        Me.mi_ajustar_cantidad_bache.Text = "Ajustar Cantidad Bache"
        '
        'mi_cerrar_item_programado
        '
        Me.mi_cerrar_item_programado.Name = "mi_cerrar_item_programado"
        Me.mi_cerrar_item_programado.Size = New System.Drawing.Size(254, 24)
        Me.mi_cerrar_item_programado.Text = "Cerrar Item Programado"
        '
        'bt_nueva_orden_de_produccion
        '
        Me.bt_nueva_orden_de_produccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_nueva_orden_de_produccion.Image = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_nueva_orden_de_produccion.Location = New System.Drawing.Point(1160, 126)
        Me.bt_nueva_orden_de_produccion.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_nueva_orden_de_produccion.Name = "bt_nueva_orden_de_produccion"
        Me.bt_nueva_orden_de_produccion.Size = New System.Drawing.Size(92, 85)
        Me.bt_nueva_orden_de_produccion.TabIndex = 64
        Me.bt_nueva_orden_de_produccion.Text = "Nueva OP"
        Me.bt_nueva_orden_de_produccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bt_nueva_orden_de_produccion.UseVisualStyleBackColor = True
        '
        'tx_id_registro
        '
        Me.tx_id_registro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_id_registro.Location = New System.Drawing.Point(1160, 251)
        Me.tx_id_registro.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_id_registro.Name = "tx_id_registro"
        Me.tx_id_registro.ReadOnly = True
        Me.tx_id_registro.Size = New System.Drawing.Size(91, 22)
        Me.tx_id_registro.TabIndex = 65
        '
        'lb_tipo_registro
        '
        Me.lb_tipo_registro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_tipo_registro.AutoSize = True
        Me.lb_tipo_registro.Location = New System.Drawing.Point(1160, 228)
        Me.lb_tipo_registro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_tipo_registro.Name = "lb_tipo_registro"
        Me.lb_tipo_registro.Size = New System.Drawing.Size(41, 16)
        Me.lb_tipo_registro.TabIndex = 66
        Me.lb_tipo_registro.Text = "IPP #:"
        '
        'bt_editar_op
        '
        Me.bt_editar_op.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_editar_op.Image = Global.camocontrol.My.Resources.Resources.design
        Me.bt_editar_op.Location = New System.Drawing.Point(1160, 298)
        Me.bt_editar_op.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_editar_op.Name = "bt_editar_op"
        Me.bt_editar_op.Size = New System.Drawing.Size(92, 85)
        Me.bt_editar_op.TabIndex = 67
        Me.bt_editar_op.Text = "Editar OP"
        Me.bt_editar_op.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bt_editar_op.UseVisualStyleBackColor = True
        '
        'tx_cantidad_ordenada
        '
        Me.tx_cantidad_ordenada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_cantidad_ordenada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad_ordenada.Location = New System.Drawing.Point(199, 105)
        Me.tx_cantidad_ordenada.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_cantidad_ordenada.MaxLength = 30
        Me.tx_cantidad_ordenada.Name = "tx_cantidad_ordenada"
        Me.tx_cantidad_ordenada.ReadOnly = True
        Me.tx_cantidad_ordenada.Size = New System.Drawing.Size(113, 26)
        Me.tx_cantidad_ordenada.TabIndex = 166
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 108)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 20)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Cantidad Ordenada:"
        '
        'tx_cantidad_programada
        '
        Me.tx_cantidad_programada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_cantidad_programada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad_programada.Location = New System.Drawing.Point(541, 105)
        Me.tx_cantidad_programada.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_cantidad_programada.MaxLength = 30
        Me.tx_cantidad_programada.Name = "tx_cantidad_programada"
        Me.tx_cantidad_programada.ReadOnly = True
        Me.tx_cantidad_programada.Size = New System.Drawing.Size(113, 26)
        Me.tx_cantidad_programada.TabIndex = 168
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(341, 108)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 20)
        Me.Label2.TabIndex = 167
        Me.Label2.Text = "Cantidad Programada:"
        '
        'tx_cantidad_producida
        '
        Me.tx_cantidad_producida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_cantidad_producida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad_producida.Location = New System.Drawing.Point(868, 105)
        Me.tx_cantidad_producida.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_cantidad_producida.MaxLength = 30
        Me.tx_cantidad_producida.Name = "tx_cantidad_producida"
        Me.tx_cantidad_producida.ReadOnly = True
        Me.tx_cantidad_producida.Size = New System.Drawing.Size(113, 26)
        Me.tx_cantidad_producida.TabIndex = 170
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(687, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 20)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Cantidad Producida:"
        '
        'lb_producto
        '
        Me.lb_producto.AutoSize = True
        Me.lb_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_producto.Location = New System.Drawing.Point(19, 76)
        Me.lb_producto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_producto.Name = "lb_producto"
        Me.lb_producto.Size = New System.Drawing.Size(106, 24)
        Me.lb_producto.TabIndex = 171
        Me.lb_producto.Text = "Producto: "
        '
        'bt_anular_op
        '
        Me.bt_anular_op.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_anular_op.Image = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_anular_op.Location = New System.Drawing.Point(1160, 390)
        Me.bt_anular_op.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_anular_op.Name = "bt_anular_op"
        Me.bt_anular_op.Size = New System.Drawing.Size(92, 85)
        Me.bt_anular_op.TabIndex = 172
        Me.bt_anular_op.Text = "Anular OP"
        Me.bt_anular_op.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bt_anular_op.UseVisualStyleBackColor = True
        '
        'fm_0400_pp_ordenes_produccion_arbol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1260, 604)
        Me.Controls.Add(Me.bt_anular_op)
        Me.Controls.Add(Me.lb_producto)
        Me.Controls.Add(Me.tx_cantidad_producida)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_cantidad_programada)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_cantidad_ordenada)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bt_editar_op)
        Me.Controls.Add(Me.lb_tipo_registro)
        Me.Controls.Add(Me.tx_id_registro)
        Me.Controls.Add(Me.bt_nueva_orden_de_produccion)
        Me.Controls.Add(Me.TreeView1)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "fm_0400_pp_ordenes_produccion_arbol"
        Me.Text = "Ordenes de Produccion"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.Controls.SetChildIndex(Me.bt_nueva_orden_de_produccion, 0)
        Me.Controls.SetChildIndex(Me.tx_id_registro, 0)
        Me.Controls.SetChildIndex(Me.lb_tipo_registro, 0)
        Me.Controls.SetChildIndex(Me.bt_editar_op, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad_ordenada, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad_programada, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad_producida, 0)
        Me.Controls.SetChildIndex(Me.lb_producto, 0)
        Me.Controls.SetChildIndex(Me.bt_anular_op, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents bt_nueva_orden_de_produccion As System.Windows.Forms.Button
    Friend WithEvents tx_id_registro As System.Windows.Forms.TextBox
    Friend WithEvents lb_tipo_registro As System.Windows.Forms.Label
    Friend WithEvents bt_editar_op As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mi_imprimir_etiqueta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_personal_asociado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_registros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_reporte_produccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_ajustar_cantidad_bache As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tx_cantidad_ordenada As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_cantidad_programada As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_cantidad_producida As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lb_producto As System.Windows.Forms.Label
    Friend WithEvents bt_anular_op As System.Windows.Forms.Button
    Friend WithEvents mi_reporte_produccion_nuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_reporte_produccion_consultar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_cerrar_item_programado As System.Windows.Forms.ToolStripMenuItem

End Class
