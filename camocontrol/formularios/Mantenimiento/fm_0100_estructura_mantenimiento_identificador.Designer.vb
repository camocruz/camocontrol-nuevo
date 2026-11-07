<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0100_estructura_mantenimiento_identificador
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.components = New System.ComponentModel.Container()
        Me.tw_estructura = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mi_expandir_todo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_colapsartodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mi_expandir_rama = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mi_filtrar_rama = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_quitar_filtro_rama = New System.Windows.Forms.ToolStripMenuItem()
        Me.tx_elemento_seleccionado = New System.Windows.Forms.TextBox()
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.UcSelectorEstructura = New camocontrol.ucSelectorAvanzado()
        Me.rb_codigo = New System.Windows.Forms.RadioButton()
        Me.rb_nombre = New System.Windows.Forms.RadioButton()
        Me.bt_crear_estructura = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(1009, 11)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(1011, 44)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(91, 20)
        Me.lb_fecha.Text = "2014/06/19"
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(889, 7)
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(312, 42)
        Me.lb_titulo.Text = "Estructura Activos"
        '
        'bt_salir
        '
        '
        'tw_estructura
        '
        Me.tw_estructura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tw_estructura.BackColor = System.Drawing.SystemColors.Info
        Me.tw_estructura.Indent = 10
        Me.tw_estructura.ItemHeight = 17
        Me.tw_estructura.Location = New System.Drawing.Point(4, 75)
        Me.tw_estructura.Margin = New System.Windows.Forms.Padding(4)
        Me.tw_estructura.Name = "tw_estructura"
        Me.tw_estructura.Size = New System.Drawing.Size(743, 386)
        Me.tw_estructura.TabIndex = 63
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_expandir_todo, Me.mi_colapsartodo, Me.ToolStripMenuItem2, Me.mi_expandir_rama, Me.ToolStripMenuItem1, Me.mi_filtrar_rama, Me.mi_quitar_filtro_rama})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(179, 136)
        Me.ContextMenuStrip1.Text = "Gestion Elementos"
        '
        'mi_expandir_todo
        '
        Me.mi_expandir_todo.Name = "mi_expandir_todo"
        Me.mi_expandir_todo.Size = New System.Drawing.Size(178, 24)
        Me.mi_expandir_todo.Text = "Expandir Todo"
        '
        'mi_colapsartodo
        '
        Me.mi_colapsartodo.Name = "mi_colapsartodo"
        Me.mi_colapsartodo.Size = New System.Drawing.Size(178, 24)
        Me.mi_colapsartodo.Text = "Colapsar Todo"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(175, 6)
        '
        'mi_expandir_rama
        '
        Me.mi_expandir_rama.Name = "mi_expandir_rama"
        Me.mi_expandir_rama.Size = New System.Drawing.Size(178, 24)
        Me.mi_expandir_rama.Text = "Expandir Rama"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(175, 6)
        '
        'mi_filtrar_rama
        '
        Me.mi_filtrar_rama.Name = "mi_filtrar_rama"
        Me.mi_filtrar_rama.Size = New System.Drawing.Size(178, 24)
        Me.mi_filtrar_rama.Text = "Filtrar Rama"
        '
        'mi_quitar_filtro_rama
        '
        Me.mi_quitar_filtro_rama.Name = "mi_quitar_filtro_rama"
        Me.mi_quitar_filtro_rama.Size = New System.Drawing.Size(178, 24)
        Me.mi_quitar_filtro_rama.Text = "Quitar Filtro"
        '
        'tx_elemento_seleccionado
        '
        Me.tx_elemento_seleccionado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_elemento_seleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_elemento_seleccionado.Location = New System.Drawing.Point(764, 183)
        Me.tx_elemento_seleccionado.Margin = New System.Windows.Forms.Padding(4)
        Me.tx_elemento_seleccionado.Multiline = True
        Me.tx_elemento_seleccionado.Name = "tx_elemento_seleccionado"
        Me.tx_elemento_seleccionado.ReadOnly = True
        Me.tx_elemento_seleccionado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_elemento_seleccionado.Size = New System.Drawing.Size(316, 98)
        Me.tx_elemento_seleccionado.TabIndex = 85
        Me.tx_elemento_seleccionado.Text = "N/D"
        '
        'bt_grabar
        '
        Me.bt_grabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_grabar.Image = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar.Location = New System.Drawing.Point(875, 289)
        Me.bt_grabar.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(75, 60)
        Me.bt_grabar.TabIndex = 86
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.UcSelectorEstructura)
        Me.GroupBox3.Controls.Add(Me.rb_codigo)
        Me.GroupBox3.Controls.Add(Me.rb_nombre)
        Me.GroupBox3.Location = New System.Drawing.Point(756, 75)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(345, 101)
        Me.GroupBox3.TabIndex = 89
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Busqueda Rapida"
        '
        'UcSelectorEstructura
        '
        Me.UcSelectorEstructura.ColumnasVisiblesPopup = Nothing
        Me.UcSelectorEstructura.Location = New System.Drawing.Point(2, 58)
        Me.UcSelectorEstructura.Name = "UcSelectorEstructura"
        Me.UcSelectorEstructura.SelectedExtra = Nothing
        Me.UcSelectorEstructura.SelectedID = Nothing
        Me.UcSelectorEstructura.SelectedText = Nothing
        Me.UcSelectorEstructura.Size = New System.Drawing.Size(341, 26)
        Me.UcSelectorEstructura.SoloLectura = False
        Me.UcSelectorEstructura.TabIndex = 88
        '
        'rb_codigo
        '
        Me.rb_codigo.AutoSize = True
        Me.rb_codigo.Location = New System.Drawing.Point(116, 23)
        Me.rb_codigo.Margin = New System.Windows.Forms.Padding(4)
        Me.rb_codigo.Name = "rb_codigo"
        Me.rb_codigo.Size = New System.Drawing.Size(72, 20)
        Me.rb_codigo.TabIndex = 87
        Me.rb_codigo.Text = "Codigo"
        Me.rb_codigo.UseVisualStyleBackColor = True
        '
        'rb_nombre
        '
        Me.rb_nombre.AutoSize = True
        Me.rb_nombre.Checked = True
        Me.rb_nombre.Location = New System.Drawing.Point(9, 23)
        Me.rb_nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.rb_nombre.Name = "rb_nombre"
        Me.rb_nombre.Size = New System.Drawing.Size(77, 20)
        Me.rb_nombre.TabIndex = 86
        Me.rb_nombre.TabStop = True
        Me.rb_nombre.Text = "Nombre"
        Me.rb_nombre.UseVisualStyleBackColor = True
        '
        'bt_crear_estructura
        '
        Me.bt_crear_estructura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_crear_estructura.Image = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_crear_estructura.Location = New System.Drawing.Point(765, 414)
        Me.bt_crear_estructura.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_crear_estructura.Name = "bt_crear_estructura"
        Me.bt_crear_estructura.Size = New System.Drawing.Size(81, 47)
        Me.bt_crear_estructura.TabIndex = 90
        Me.bt_crear_estructura.UseVisualStyleBackColor = True
        '
        'fm_0100_estructura_mantenimiento_identificador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1115, 564)
        Me.Controls.Add(Me.bt_crear_estructura)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.bt_grabar)
        Me.Controls.Add(Me.tx_elemento_seleccionado)
        Me.Controls.Add(Me.tw_estructura)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "fm_0100_estructura_mantenimiento_identificador"
        Me.Text = "Estructura Activos"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.tw_estructura, 0)
        Me.Controls.SetChildIndex(Me.tx_elemento_seleccionado, 0)
        Me.Controls.SetChildIndex(Me.bt_grabar, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.bt_crear_estructura, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tw_estructura As System.Windows.Forms.TreeView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mi_expandir_todo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_colapsartodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mi_expandir_rama As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mi_filtrar_rama As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_quitar_filtro_rama As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tx_elemento_seleccionado As System.Windows.Forms.TextBox
    Friend WithEvents bt_grabar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_codigo As System.Windows.Forms.RadioButton
    Friend WithEvents rb_nombre As System.Windows.Forms.RadioButton
    Friend WithEvents bt_crear_estructura As Button
    Friend WithEvents UcSelectorEstructura As ucSelectorAvanzado
End Class
