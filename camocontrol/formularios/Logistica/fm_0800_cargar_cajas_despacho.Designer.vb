<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0800_cargar_cajas_despacho
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
        Me.components = New System.ComponentModel.Container()
        Me.dg_items_rms = New System.Windows.Forms.DataGridView()
        Me.cmenustrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cm_mi_limpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cm_mi_ver_datos = New System.Windows.Forms.ToolStripMenuItem()
        Me.cm_mi_limpiar_todo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tx_id_caja = New System.Windows.Forms.TextBox()
        Me.bt_eliminar_caja = New System.Windows.Forms.Button()
        Me.chk_eliminar_cajas = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_unidades_solicitadas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_unidades_despachadas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_unidades_pendientes = New System.Windows.Forms.TextBox()
        Me.bt_importar_plano = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_num_estiba = New System.Windows.Forms.TextBox()
        Me.tx_unid_estiba = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_num_items_estiba = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_items_rms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenustrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(728, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(826, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(827, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2015/10/13"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(404, 32)
        Me.lb_titulo.Text = "Cargue de Productos Despacho."
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 459)
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 519)
        '
        'dg_items_rms
        '
        Me.dg_items_rms.AllowUserToAddRows = False
        Me.dg_items_rms.AllowUserToDeleteRows = False
        Me.dg_items_rms.AllowUserToOrderColumns = True
        Me.dg_items_rms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_items_rms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_items_rms.ContextMenuStrip = Me.cmenustrip
        Me.dg_items_rms.Location = New System.Drawing.Point(12, 111)
        Me.dg_items_rms.Name = "dg_items_rms"
        Me.dg_items_rms.ReadOnly = True
        Me.dg_items_rms.Size = New System.Drawing.Size(693, 342)
        Me.dg_items_rms.TabIndex = 62
        '
        'cmenustrip
        '
        Me.cmenustrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cm_mi_limpiar, Me.cm_mi_ver_datos, Me.cm_mi_limpiar_todo})
        Me.cmenustrip.Name = "ContextMenuStrip1"
        Me.cmenustrip.Size = New System.Drawing.Size(230, 70)
        '
        'cm_mi_limpiar
        '
        Me.cm_mi_limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cm_mi_limpiar.Image = Global.camocontrol.My.Resources.Resources.eliminar
        Me.cm_mi_limpiar.Name = "cm_mi_limpiar"
        Me.cm_mi_limpiar.Size = New System.Drawing.Size(229, 22)
        Me.cm_mi_limpiar.Text = "Limpiar solo producto"
        '
        'cm_mi_ver_datos
        '
        Me.cm_mi_ver_datos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cm_mi_ver_datos.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.cm_mi_ver_datos.Name = "cm_mi_ver_datos"
        Me.cm_mi_ver_datos.Size = New System.Drawing.Size(229, 22)
        Me.cm_mi_ver_datos.Text = "Ver datos"
        '
        'cm_mi_limpiar_todo
        '
        Me.cm_mi_limpiar_todo.Image = Global.camocontrol.My.Resources.Resources.eliminar
        Me.cm_mi_limpiar_todo.Name = "cm_mi_limpiar_todo"
        Me.cm_mi_limpiar_todo.Size = New System.Drawing.Size(229, 22)
        Me.cm_mi_limpiar_todo.Text = "Limpiar TODOS los productos"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(12, 76)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(57, 16)
        Me.Label30.TabIndex = 206
        Me.Label30.Text = "Id_Caja:"
        '
        'tx_id_caja
        '
        Me.tx_id_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_caja.Location = New System.Drawing.Point(75, 70)
        Me.tx_id_caja.Name = "tx_id_caja"
        Me.tx_id_caja.Size = New System.Drawing.Size(123, 22)
        Me.tx_id_caja.TabIndex = 207
        '
        'bt_eliminar_caja
        '
        Me.bt_eliminar_caja.Image = Global.camocontrol.My.Resources.Resources.EQUIS
        Me.bt_eliminar_caja.Location = New System.Drawing.Point(204, 61)
        Me.bt_eliminar_caja.Name = "bt_eliminar_caja"
        Me.bt_eliminar_caja.Size = New System.Drawing.Size(45, 38)
        Me.bt_eliminar_caja.TabIndex = 208
        Me.bt_eliminar_caja.UseVisualStyleBackColor = True
        '
        'chk_eliminar_cajas
        '
        Me.chk_eliminar_cajas.AutoSize = True
        Me.chk_eliminar_cajas.Location = New System.Drawing.Point(256, 73)
        Me.chk_eliminar_cajas.Name = "chk_eliminar_cajas"
        Me.chk_eliminar_cajas.Size = New System.Drawing.Size(62, 17)
        Me.chk_eliminar_cajas.TabIndex = 209
        Me.chk_eliminar_cajas.Text = "Eliminar"
        Me.chk_eliminar_cajas.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(315, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 25)
        Me.Label5.TabIndex = 289
        Me.Label5.Text = "Unid Ped:"
        '
        'tx_unidades_solicitadas
        '
        Me.tx_unidades_solicitadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidades_solicitadas.Location = New System.Drawing.Point(424, 65)
        Me.tx_unidades_solicitadas.Name = "tx_unidades_solicitadas"
        Me.tx_unidades_solicitadas.ReadOnly = True
        Me.tx_unidades_solicitadas.Size = New System.Drawing.Size(85, 38)
        Me.tx_unidades_solicitadas.TabIndex = 288
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(511, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 25)
        Me.Label4.TabIndex = 287
        Me.Label4.Text = "Unid Car:"
        '
        'tx_unidades_despachadas
        '
        Me.tx_unidades_despachadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidades_despachadas.Location = New System.Drawing.Point(620, 65)
        Me.tx_unidades_despachadas.Name = "tx_unidades_despachadas"
        Me.tx_unidades_despachadas.ReadOnly = True
        Me.tx_unidades_despachadas.Size = New System.Drawing.Size(85, 38)
        Me.tx_unidades_despachadas.TabIndex = 286
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(707, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 25)
        Me.Label1.TabIndex = 291
        Me.Label1.Text = "Unid Pen:"
        '
        'tx_unidades_pendientes
        '
        Me.tx_unidades_pendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unidades_pendientes.Location = New System.Drawing.Point(816, 65)
        Me.tx_unidades_pendientes.Name = "tx_unidades_pendientes"
        Me.tx_unidades_pendientes.ReadOnly = True
        Me.tx_unidades_pendientes.Size = New System.Drawing.Size(85, 38)
        Me.tx_unidades_pendientes.TabIndex = 290
        '
        'bt_importar_plano
        '
        Me.bt_importar_plano.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_importar_plano.Location = New System.Drawing.Point(12, 459)
        Me.bt_importar_plano.Name = "bt_importar_plano"
        Me.bt_importar_plano.Size = New System.Drawing.Size(94, 53)
        Me.bt_importar_plano.TabIndex = 292
        Me.bt_importar_plano.Text = "Importar Registros"
        Me.bt_importar_plano.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(711, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 25)
        Me.Label2.TabIndex = 294
        Me.Label2.Text = "# Estiba:"
        '
        'tx_num_estiba
        '
        Me.tx_num_estiba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_num_estiba.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_num_estiba.Location = New System.Drawing.Point(716, 137)
        Me.tx_num_estiba.Name = "tx_num_estiba"
        Me.tx_num_estiba.ReadOnly = True
        Me.tx_num_estiba.Size = New System.Drawing.Size(85, 38)
        Me.tx_num_estiba.TabIndex = 293
        '
        'tx_unid_estiba
        '
        Me.tx_unid_estiba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_unid_estiba.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_unid_estiba.Location = New System.Drawing.Point(716, 181)
        Me.tx_unid_estiba.Name = "tx_unid_estiba"
        Me.tx_unid_estiba.ReadOnly = True
        Me.tx_unid_estiba.Size = New System.Drawing.Size(185, 116)
        Me.tx_unid_estiba.TabIndex = 295
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(811, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 25)
        Me.Label3.TabIndex = 297
        Me.Label3.Text = "# Items:"
        '
        'tx_num_items_estiba
        '
        Me.tx_num_items_estiba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_num_items_estiba.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_num_items_estiba.Location = New System.Drawing.Point(816, 137)
        Me.tx_num_items_estiba.Name = "tx_num_items_estiba"
        Me.tx_num_items_estiba.ReadOnly = True
        Me.tx_num_items_estiba.Size = New System.Drawing.Size(85, 38)
        Me.tx_num_items_estiba.TabIndex = 296
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(764, 303)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 28)
        Me.Button1.TabIndex = 298
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'fm_0800_cargar_cajas_despacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.Thistle
        Me.ClientSize = New System.Drawing.Size(913, 533)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_num_items_estiba)
        Me.Controls.Add(Me.tx_unid_estiba)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_num_estiba)
        Me.Controls.Add(Me.bt_importar_plano)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_unidades_pendientes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_unidades_solicitadas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_unidades_despachadas)
        Me.Controls.Add(Me.chk_eliminar_cajas)
        Me.Controls.Add(Me.bt_eliminar_caja)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.tx_id_caja)
        Me.Controls.Add(Me.dg_items_rms)
        Me.Name = "fm_0800_cargar_cajas_despacho"
        Me.Text = "Cargue de productos despacho"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.dg_items_rms, 0)
        Me.Controls.SetChildIndex(Me.tx_id_caja, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.bt_eliminar_caja, 0)
        Me.Controls.SetChildIndex(Me.chk_eliminar_cajas, 0)
        Me.Controls.SetChildIndex(Me.tx_unidades_despachadas, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tx_unidades_solicitadas, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_unidades_pendientes, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.bt_importar_plano, 0)
        Me.Controls.SetChildIndex(Me.tx_num_estiba, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_unid_estiba, 0)
        Me.Controls.SetChildIndex(Me.tx_num_items_estiba, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_items_rms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenustrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_items_rms As System.Windows.Forms.DataGridView
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tx_id_caja As System.Windows.Forms.TextBox
    Friend WithEvents cmenustrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cm_mi_limpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cm_mi_ver_datos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bt_eliminar_caja As System.Windows.Forms.Button
    Friend WithEvents chk_eliminar_cajas As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_unidades_solicitadas As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_unidades_despachadas As System.Windows.Forms.TextBox
    Friend WithEvents cm_mi_limpiar_todo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents tx_unidades_pendientes As TextBox
    Friend WithEvents bt_importar_plano As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents tx_num_estiba As TextBox
    Friend WithEvents tx_unid_estiba As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tx_num_items_estiba As TextBox
    Friend WithEvents Button1 As Button
End Class
