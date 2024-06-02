<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0300_formulacion_tree_view
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.tx_cantidad_produccion = New System.Windows.Forms.TextBox()
        Me.bt_recalcular = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_abrir_item = New System.Windows.Forms.Button()
        Me.lb_id_item = New System.Windows.Forms.Label()
        Me.bt_abrir_plantilla_activa = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(871, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(872, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/03/13"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(781, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(353, 32)
        Me.lb_titulo.Text = "Calculadora Formulaciones"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 499)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 463)
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BackColor = System.Drawing.SystemColors.Info
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.HotTracking = True
        Me.TreeView1.Indent = 19
        Me.TreeView1.ItemHeight = 16
        Me.TreeView1.LabelEdit = True
        Me.TreeView1.Location = New System.Drawing.Point(11, 97)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(849, 345)
        Me.TreeView1.TabIndex = 66
        '
        'tx_cantidad_produccion
        '
        Me.tx_cantidad_produccion.Location = New System.Drawing.Point(106, 65)
        Me.tx_cantidad_produccion.Name = "tx_cantidad_produccion"
        Me.tx_cantidad_produccion.Size = New System.Drawing.Size(100, 20)
        Me.tx_cantidad_produccion.TabIndex = 69
        '
        'bt_recalcular
        '
        Me.bt_recalcular.Location = New System.Drawing.Point(223, 63)
        Me.bt_recalcular.Name = "bt_recalcular"
        Me.bt_recalcular.Size = New System.Drawing.Size(75, 23)
        Me.bt_recalcular.TabIndex = 70
        Me.bt_recalcular.Text = "Recalcular"
        Me.bt_recalcular.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Base de Calculo:"
        '
        'bt_abrir_item
        '
        Me.bt_abrir_item.Location = New System.Drawing.Point(867, 211)
        Me.bt_abrir_item.Name = "bt_abrir_item"
        Me.bt_abrir_item.Size = New System.Drawing.Size(75, 23)
        Me.bt_abrir_item.TabIndex = 72
        Me.bt_abrir_item.Text = "Abrir Item"
        Me.bt_abrir_item.UseVisualStyleBackColor = True
        '
        'lb_id_item
        '
        Me.lb_id_item.AutoSize = True
        Me.lb_id_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_id_item.Location = New System.Drawing.Point(867, 192)
        Me.lb_id_item.Name = "lb_id_item"
        Me.lb_id_item.Size = New System.Drawing.Size(15, 16)
        Me.lb_id_item.TabIndex = 73
        Me.lb_id_item.Text = "0"
        '
        'bt_abrir_plantilla_activa
        '
        Me.bt_abrir_plantilla_activa.Location = New System.Drawing.Point(867, 254)
        Me.bt_abrir_plantilla_activa.Name = "bt_abrir_plantilla_activa"
        Me.bt_abrir_plantilla_activa.Size = New System.Drawing.Size(75, 45)
        Me.bt_abrir_plantilla_activa.TabIndex = 74
        Me.bt_abrir_plantilla_activa.Text = "Abrir Plantilla Activa"
        Me.bt_abrir_plantilla_activa.UseVisualStyleBackColor = True
        '
        'fm_0300_formulacion_tree_view
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(950, 513)
        Me.Controls.Add(Me.bt_abrir_plantilla_activa)
        Me.Controls.Add(Me.lb_id_item)
        Me.Controls.Add(Me.bt_abrir_item)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bt_recalcular)
        Me.Controls.Add(Me.tx_cantidad_produccion)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "fm_0300_formulacion_tree_view"
        Me.Text = "Calculadora Formulacion"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad_produccion, 0)
        Me.Controls.SetChildIndex(Me.bt_recalcular, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.bt_abrir_item, 0)
        Me.Controls.SetChildIndex(Me.lb_id_item, 0)
        Me.Controls.SetChildIndex(Me.bt_abrir_plantilla_activa, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents tx_cantidad_produccion As System.Windows.Forms.TextBox
    Friend WithEvents bt_recalcular As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bt_abrir_item As Button
    Friend WithEvents lb_id_item As Label
    Friend WithEvents bt_abrir_plantilla_activa As Button
End Class
