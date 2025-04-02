<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_pp_progamas_produccion
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_id_prog_prod = New System.Windows.Forms.TextBox()
        Me.tx_nombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_f_ini = New System.Windows.Forms.DateTimePicker()
        Me.dtp_f_fin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dg_datos = New System.Windows.Forms.DataGridView()
        Me.bt_clonar_pp = New System.Windows.Forms.Button()
        Me.bt_orden_produccion = New System.Windows.Forms.Button()
        Me.tx_item_prog_prod = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bt_prog_diaria = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/02/12"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(319, 32)
        Me.lb_titulo.Text = "Programa de Produccion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 438)
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
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 498)
        '
        'bt_editar
        '
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 16)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "Id:"
        '
        'tx_id_prog_prod
        '
        Me.tx_id_prog_prod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_prog_prod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_prog_prod.Location = New System.Drawing.Point(73, 22)
        Me.tx_id_prog_prod.MaxLength = 20
        Me.tx_id_prog_prod.Name = "tx_id_prog_prod"
        Me.tx_id_prog_prod.ReadOnly = True
        Me.tx_id_prog_prod.Size = New System.Drawing.Size(245, 22)
        Me.tx_id_prog_prod.TabIndex = 94
        '
        'tx_nombre
        '
        Me.tx_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_nombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nombre.Location = New System.Drawing.Point(73, 50)
        Me.tx_nombre.MaxLength = 100
        Me.tx_nombre.Name = "tx_nombre"
        Me.tx_nombre.Size = New System.Drawing.Size(245, 22)
        Me.tx_nombre.TabIndex = 92
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Nombre:"
        '
        'dtp_f_ini
        '
        Me.dtp_f_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_f_ini.Location = New System.Drawing.Point(408, 52)
        Me.dtp_f_ini.Name = "dtp_f_ini"
        Me.dtp_f_ini.Size = New System.Drawing.Size(104, 20)
        Me.dtp_f_ini.TabIndex = 96
        '
        'dtp_f_fin
        '
        Me.dtp_f_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_f_fin.Location = New System.Drawing.Point(542, 52)
        Me.dtp_f_fin.Name = "dtp_f_fin"
        Me.dtp_f_fin.Size = New System.Drawing.Size(111, 20)
        Me.dtp_f_fin.TabIndex = 97
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(345, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Lapso:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(518, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "al"
        '
        'dg_datos
        '
        Me.dg_datos.AllowUserToAddRows = False
        Me.dg_datos.AllowUserToDeleteRows = False
        Me.dg_datos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_datos.Location = New System.Drawing.Point(12, 162)
        Me.dg_datos.Name = "dg_datos"
        Me.dg_datos.ReadOnly = True
        Me.dg_datos.Size = New System.Drawing.Size(721, 270)
        Me.dg_datos.TabIndex = 100
        '
        'bt_clonar_pp
        '
        Me.bt_clonar_pp.Location = New System.Drawing.Point(352, 22)
        Me.bt_clonar_pp.Name = "bt_clonar_pp"
        Me.bt_clonar_pp.Size = New System.Drawing.Size(75, 23)
        Me.bt_clonar_pp.TabIndex = 101
        Me.bt_clonar_pp.Text = "Clonar"
        Me.bt_clonar_pp.UseVisualStyleBackColor = True
        '
        'bt_orden_produccion
        '
        Me.bt_orden_produccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_orden_produccion.Location = New System.Drawing.Point(12, 438)
        Me.bt_orden_produccion.Name = "bt_orden_produccion"
        Me.bt_orden_produccion.Size = New System.Drawing.Size(76, 42)
        Me.bt_orden_produccion.TabIndex = 102
        Me.bt_orden_produccion.Text = "Ordenes Produccion"
        Me.bt_orden_produccion.UseVisualStyleBackColor = True
        '
        'tx_item_prog_prod
        '
        Me.tx_item_prog_prod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_item_prog_prod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_item_prog_prod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_item_prog_prod.Location = New System.Drawing.Point(93, 448)
        Me.tx_item_prog_prod.MaxLength = 100
        Me.tx_item_prog_prod.Name = "tx_item_prog_prod"
        Me.tx_item_prog_prod.ReadOnly = True
        Me.tx_item_prog_prod.Size = New System.Drawing.Size(82, 22)
        Me.tx_item_prog_prod.TabIndex = 103
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_prog_diaria)
        Me.GroupBox2.Controls.Add(Me.bt_clonar_pp)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtp_f_fin)
        Me.GroupBox2.Controls.Add(Me.dtp_f_ini)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tx_id_prog_prod)
        Me.GroupBox2.Controls.Add(Me.tx_nombre)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(718, 87)
        Me.GroupBox2.TabIndex = 104
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Encabezado del Programa"
        '
        'bt_prog_diaria
        '
        Me.bt_prog_diaria.Location = New System.Drawing.Point(494, 16)
        Me.bt_prog_diaria.Name = "bt_prog_diaria"
        Me.bt_prog_diaria.Size = New System.Drawing.Size(159, 29)
        Me.bt_prog_diaria.TabIndex = 102
        Me.bt_prog_diaria.Text = "Prog. Diaria"
        Me.bt_prog_diaria.UseVisualStyleBackColor = True
        '
        'fm_0400_pp_progamas_produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 512)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.tx_item_prog_prod)
        Me.Controls.Add(Me.bt_orden_produccion)
        Me.Controls.Add(Me.dg_datos)
        Me.Name = "fm_0400_pp_progamas_produccion"
        Me.Text = "Programa de produccion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.dg_datos, 0)
        Me.Controls.SetChildIndex(Me.bt_orden_produccion, 0)
        Me.Controls.SetChildIndex(Me.tx_item_prog_prod, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_id_prog_prod As System.Windows.Forms.TextBox
    Friend WithEvents tx_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_f_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_f_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dg_datos As System.Windows.Forms.DataGridView
    Friend WithEvents bt_clonar_pp As System.Windows.Forms.Button
    Friend WithEvents bt_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents tx_item_prog_prod As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_prog_diaria As Button
End Class
