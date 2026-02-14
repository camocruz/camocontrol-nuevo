<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0100_estructura_mantenimiento
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
        Me.components = New System.ComponentModel.Container()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mi_expandir_todo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_colapsartodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mi_expandir_rama = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mi_filtrar_rama = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_quitar_filtro_rama = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi_ruta_estructura = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NumericTxAbrirAccion = New camocontrol.NumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_nueva_actividad = New System.Windows.Forms.Button()
        Me.bt_comprar = New System.Windows.Forms.Button()
        Me.bt_trasladar = New System.Windows.Forms.Button()
        Me.bt_reportar_falla = New System.Windows.Forms.Button()
        Me.tx_elemento_seleccionado = New System.Windows.Forms.TextBox()
        Me.bt_info_elemento = New System.Windows.Forms.Button()
        Me.bt_recalcular_path = New System.Windows.Forms.Button()
        Me.bt_crear_elemento = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bt_imagen = New System.Windows.Forms.Button()
        Me.bt_mantenimientos = New System.Windows.Forms.Button()
        Me.cm_compania = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tx_BuscadorEstructura = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(987, 9)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(1134, 14)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(1136, 55)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2013/10/16"
        '
        'lb_titulo
        '
        Me.lb_titulo.Location = New System.Drawing.Point(318, 14)
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(522, 51)
        Me.lb_titulo.Text = "Estructura Mantenimiento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(452, 666)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 8, 6, 8)
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 761)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.SystemColors.Info
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeView1.Indent = 10
        Me.TreeView1.ItemHeight = 17
        Me.TreeView1.Location = New System.Drawing.Point(416, 137)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(835, 518)
        Me.TreeView1.TabIndex = 61
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_expandir_todo, Me.mi_colapsartodo, Me.ToolStripMenuItem2, Me.mi_expandir_rama, Me.ToolStripMenuItem1, Me.mi_filtrar_rama, Me.mi_quitar_filtro_rama, Me.mi_ruta_estructura})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(204, 208)
        Me.ContextMenuStrip1.Text = "Gestion Elementos"
        '
        'mi_expandir_todo
        '
        Me.mi_expandir_todo.Name = "mi_expandir_todo"
        Me.mi_expandir_todo.Size = New System.Drawing.Size(203, 32)
        Me.mi_expandir_todo.Text = "Expandir Todo"
        '
        'mi_colapsartodo
        '
        Me.mi_colapsartodo.Name = "mi_colapsartodo"
        Me.mi_colapsartodo.Size = New System.Drawing.Size(203, 32)
        Me.mi_colapsartodo.Text = "Colapsar Todo"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(200, 6)
        '
        'mi_expandir_rama
        '
        Me.mi_expandir_rama.Name = "mi_expandir_rama"
        Me.mi_expandir_rama.Size = New System.Drawing.Size(203, 32)
        Me.mi_expandir_rama.Text = "Expandir Rama"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(200, 6)
        '
        'mi_filtrar_rama
        '
        Me.mi_filtrar_rama.Name = "mi_filtrar_rama"
        Me.mi_filtrar_rama.Size = New System.Drawing.Size(203, 32)
        Me.mi_filtrar_rama.Text = "Filtrar Rama"
        '
        'mi_quitar_filtro_rama
        '
        Me.mi_quitar_filtro_rama.Name = "mi_quitar_filtro_rama"
        Me.mi_quitar_filtro_rama.Size = New System.Drawing.Size(203, 32)
        Me.mi_quitar_filtro_rama.Text = "Quitar Filtro"
        '
        'mi_ruta_estructura
        '
        Me.mi_ruta_estructura.Name = "mi_ruta_estructura"
        Me.mi_ruta_estructura.Size = New System.Drawing.Size(203, 32)
        Me.mi_ruta_estructura.Text = "Ruta Estructura"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NumericTxAbrirAccion)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.bt_nueva_actividad)
        Me.GroupBox2.Controls.Add(Me.bt_comprar)
        Me.GroupBox2.Controls.Add(Me.bt_trasladar)
        Me.GroupBox2.Controls.Add(Me.bt_reportar_falla)
        Me.GroupBox2.Controls.Add(Me.tx_elemento_seleccionado)
        Me.GroupBox2.Controls.Add(Me.bt_info_elemento)
        Me.GroupBox2.Controls.Add(Me.bt_recalcular_path)
        Me.GroupBox2.Controls.Add(Me.bt_crear_elemento)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.bt_imagen)
        Me.GroupBox2.Controls.Add(Me.bt_mantenimientos)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 216)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(388, 429)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Acciones"
        '
        'NumericTxAbrirAccion
        '
        Me.NumericTxAbrirAccion.Location = New System.Drawing.Point(272, 383)
        Me.NumericTxAbrirAccion.Name = "NumericTxAbrirAccion"
        Me.NumericTxAbrirAccion.Size = New System.Drawing.Size(92, 26)
        Me.NumericTxAbrirAccion.TabIndex = 91
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(158, 386)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 20)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Consultar OT:"
        '
        'bt_nueva_actividad
        '
        Me.bt_nueva_actividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nueva_actividad.Image = Global.camocontrol.My.Resources.Resources.nuevo
        Me.bt_nueva_actividad.Location = New System.Drawing.Point(194, 308)
        Me.bt_nueva_actividad.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_nueva_actividad.Name = "bt_nueva_actividad"
        Me.bt_nueva_actividad.Size = New System.Drawing.Size(173, 70)
        Me.bt_nueva_actividad.TabIndex = 107
        Me.bt_nueva_actividad.Text = "Programar Actividad"
        Me.bt_nueva_actividad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_nueva_actividad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_nueva_actividad.UseVisualStyleBackColor = True
        '
        'bt_comprar
        '
        Me.bt_comprar.Image = Global.camocontrol.My.Resources.Resources.Full_shopping_cart_Icon_48
        Me.bt_comprar.Location = New System.Drawing.Point(10, 312)
        Me.bt_comprar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_comprar.Name = "bt_comprar"
        Me.bt_comprar.Size = New System.Drawing.Size(82, 66)
        Me.bt_comprar.TabIndex = 87
        Me.bt_comprar.Tag = ""
        Me.ToolTip1.SetToolTip(Me.bt_comprar, "Comprar Repuestos")
        Me.bt_comprar.UseVisualStyleBackColor = True
        '
        'bt_trasladar
        '
        Me.bt_trasladar.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_cortar_2
        Me.bt_trasladar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_trasladar.Location = New System.Drawing.Point(285, 162)
        Me.bt_trasladar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_trasladar.Name = "bt_trasladar"
        Me.bt_trasladar.Size = New System.Drawing.Size(82, 66)
        Me.bt_trasladar.TabIndex = 86
        Me.ToolTip1.SetToolTip(Me.bt_trasladar, "Trasladar Ramal")
        Me.bt_trasladar.UseVisualStyleBackColor = True
        '
        'bt_reportar_falla
        '
        Me.bt_reportar_falla.BackgroundImage = Global.camocontrol.My.Resources.Resources.persona_megafono2
        Me.bt_reportar_falla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_reportar_falla.Location = New System.Drawing.Point(194, 162)
        Me.bt_reportar_falla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_reportar_falla.Name = "bt_reportar_falla"
        Me.bt_reportar_falla.Size = New System.Drawing.Size(82, 66)
        Me.bt_reportar_falla.TabIndex = 85
        Me.ToolTip1.SetToolTip(Me.bt_reportar_falla, "Reportar Falla")
        Me.bt_reportar_falla.UseVisualStyleBackColor = True
        '
        'tx_elemento_seleccionado
        '
        Me.tx_elemento_seleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_elemento_seleccionado.Location = New System.Drawing.Point(9, 29)
        Me.tx_elemento_seleccionado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_elemento_seleccionado.Multiline = True
        Me.tx_elemento_seleccionado.Name = "tx_elemento_seleccionado"
        Me.tx_elemento_seleccionado.ReadOnly = True
        Me.tx_elemento_seleccionado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_elemento_seleccionado.Size = New System.Drawing.Size(355, 121)
        Me.tx_elemento_seleccionado.TabIndex = 84
        Me.tx_elemento_seleccionado.Text = "N/D"
        '
        'bt_info_elemento
        '
        Me.bt_info_elemento.Image = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_info_elemento.Location = New System.Drawing.Point(10, 162)
        Me.bt_info_elemento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_info_elemento.Name = "bt_info_elemento"
        Me.bt_info_elemento.Size = New System.Drawing.Size(82, 66)
        Me.bt_info_elemento.TabIndex = 83
        Me.ToolTip1.SetToolTip(Me.bt_info_elemento, "Info Elemento")
        Me.bt_info_elemento.UseVisualStyleBackColor = True
        '
        'bt_recalcular_path
        '
        Me.bt_recalcular_path.Image = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_recalcular_path.Location = New System.Drawing.Point(285, 237)
        Me.bt_recalcular_path.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_recalcular_path.Name = "bt_recalcular_path"
        Me.bt_recalcular_path.Size = New System.Drawing.Size(82, 66)
        Me.bt_recalcular_path.TabIndex = 82
        Me.bt_recalcular_path.Tag = ""
        Me.ToolTip1.SetToolTip(Me.bt_recalcular_path, "Recalcular Path")
        Me.bt_recalcular_path.UseVisualStyleBackColor = True
        '
        'bt_crear_elemento
        '
        Me.bt_crear_elemento.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargaremi
        Me.bt_crear_elemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_crear_elemento.Location = New System.Drawing.Point(102, 162)
        Me.bt_crear_elemento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_crear_elemento.Name = "bt_crear_elemento"
        Me.bt_crear_elemento.Size = New System.Drawing.Size(82, 66)
        Me.bt_crear_elemento.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.bt_crear_elemento, "Nuevo Elemento Hijo")
        Me.bt_crear_elemento.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.camocontrol.My.Resources.Resources.libreria
        Me.Button1.Location = New System.Drawing.Point(194, 237)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 66)
        Me.Button1.TabIndex = 81
        Me.Button1.Tag = ""
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bt_imagen
        '
        Me.bt_imagen.Image = Global.camocontrol.My.Resources.Resources.icono_foto_cam
        Me.bt_imagen.Location = New System.Drawing.Point(10, 237)
        Me.bt_imagen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_imagen.Name = "bt_imagen"
        Me.bt_imagen.Size = New System.Drawing.Size(82, 66)
        Me.bt_imagen.TabIndex = 79
        Me.bt_imagen.Tag = ""
        Me.bt_imagen.UseVisualStyleBackColor = True
        '
        'bt_mantenimientos
        '
        Me.bt_mantenimientos.Image = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_mantenimientos.Location = New System.Drawing.Point(102, 237)
        Me.bt_mantenimientos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_mantenimientos.Name = "bt_mantenimientos"
        Me.bt_mantenimientos.Size = New System.Drawing.Size(82, 66)
        Me.bt_mantenimientos.TabIndex = 80
        Me.bt_mantenimientos.Tag = ""
        Me.bt_mantenimientos.UseVisualStyleBackColor = True
        '
        'cm_compania
        '
        Me.cm_compania.Enabled = False
        Me.cm_compania.FormattingEnabled = True
        Me.cm_compania.Location = New System.Drawing.Point(154, 95)
        Me.cm_compania.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cm_compania.Name = "cm_compania"
        Me.cm_compania.Size = New System.Drawing.Size(546, 28)
        Me.cm_compania.TabIndex = 63
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 97)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 29)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Compañia:"
        '
        'tx_BuscadorEstructura
        '
        Me.tx_BuscadorEstructura.Location = New System.Drawing.Point(27, 173)
        Me.tx_BuscadorEstructura.Name = "tx_BuscadorEstructura"
        Me.tx_BuscadorEstructura.Size = New System.Drawing.Size(370, 26)
        Me.tx_BuscadorEstructura.TabIndex = 89
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 141)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 29)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Estructura:"
        '
        'fm_0100_estructura_mantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 780)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_BuscadorEstructura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cm_compania)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TreeView1)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "fm_0100_estructura_mantenimiento"
        Me.Text = "Estructura del Mantenimiento"
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.cm_compania, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_BuscadorEstructura, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_crear_elemento As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mi_expandir_todo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cm_compania As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_recalcular_path As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents bt_imagen As System.Windows.Forms.Button
    Friend WithEvents bt_mantenimientos As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents bt_info_elemento As System.Windows.Forms.Button
    Friend WithEvents tx_elemento_seleccionado As System.Windows.Forms.TextBox
    Friend WithEvents mi_colapsartodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi_expandir_rama As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bt_reportar_falla As System.Windows.Forms.Button
    Friend WithEvents bt_trasladar As System.Windows.Forms.Button
    Friend WithEvents mi_filtrar_rama As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mi_quitar_filtro_rama As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bt_comprar As System.Windows.Forms.Button
    Friend WithEvents mi_ruta_estructura As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tx_BuscadorEstructura As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bt_nueva_actividad As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericTxAbrirAccion As NumericTextBox
End Class
