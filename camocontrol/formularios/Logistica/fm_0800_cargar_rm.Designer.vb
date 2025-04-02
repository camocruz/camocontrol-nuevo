<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0800_cargar_rm
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
        Me.bt_cargar_rm = New System.Windows.Forms.Button()
        Me.dg_remision_encabezado = New System.Windows.Forms.DataGridView()
        Me.lb_total_rms = New System.Windows.Forms.Label()
        Me.bt_generar_despacho = New System.Windows.Forms.Button()
        Me.bt_exportar_archivo = New System.Windows.Forms.Button()
        Me.tx_scaner = New System.Windows.Forms.TextBox()
        Me.lb_cuenta = New System.Windows.Forms.Label()
        Me.bt_cargar_traslados = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_remision_encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2015/09/18"
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(363, 32)
        Me.lb_titulo.Text = "Cargar Remisiones CGUNO"
        '
        'bt_anular
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'bt_cargar_rm
        '
        Me.bt_cargar_rm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_cargar_rm.Location = New System.Drawing.Point(217, 341)
        Me.bt_cargar_rm.Name = "bt_cargar_rm"
        Me.bt_cargar_rm.Size = New System.Drawing.Size(81, 62)
        Me.bt_cargar_rm.TabIndex = 62
        Me.bt_cargar_rm.Text = "Cargar Remisiones"
        Me.bt_cargar_rm.UseVisualStyleBackColor = True
        '
        'dg_remision_encabezado
        '
        Me.dg_remision_encabezado.AllowUserToAddRows = False
        Me.dg_remision_encabezado.AllowUserToDeleteRows = False
        Me.dg_remision_encabezado.AllowUserToOrderColumns = True
        Me.dg_remision_encabezado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_remision_encabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_remision_encabezado.Location = New System.Drawing.Point(12, 61)
        Me.dg_remision_encabezado.Name = "dg_remision_encabezado"
        Me.dg_remision_encabezado.RowHeadersWidth = 62
        Me.dg_remision_encabezado.Size = New System.Drawing.Size(719, 263)
        Me.dg_remision_encabezado.TabIndex = 63
        '
        'lb_total_rms
        '
        Me.lb_total_rms.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lb_total_rms.AutoSize = True
        Me.lb_total_rms.Location = New System.Drawing.Point(12, 327)
        Me.lb_total_rms.Name = "lb_total_rms"
        Me.lb_total_rms.Size = New System.Drawing.Size(13, 13)
        Me.lb_total_rms.TabIndex = 64
        Me.lb_total_rms.Text = "0"
        '
        'bt_generar_despacho
        '
        Me.bt_generar_despacho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_generar_despacho.Location = New System.Drawing.Point(437, 341)
        Me.bt_generar_despacho.Name = "bt_generar_despacho"
        Me.bt_generar_despacho.Size = New System.Drawing.Size(81, 62)
        Me.bt_generar_despacho.TabIndex = 65
        Me.bt_generar_despacho.Text = "Generar Despacho"
        Me.bt_generar_despacho.UseVisualStyleBackColor = True
        '
        'bt_exportar_archivo
        '
        Me.bt_exportar_archivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_exportar_archivo.Location = New System.Drawing.Point(523, 341)
        Me.bt_exportar_archivo.Name = "bt_exportar_archivo"
        Me.bt_exportar_archivo.Size = New System.Drawing.Size(81, 62)
        Me.bt_exportar_archivo.TabIndex = 66
        Me.bt_exportar_archivo.Text = "Actualizar Estadisticas"
        Me.bt_exportar_archivo.UseVisualStyleBackColor = True
        '
        'tx_scaner
        '
        Me.tx_scaner.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_scaner.Location = New System.Drawing.Point(15, 386)
        Me.tx_scaner.Name = "tx_scaner"
        Me.tx_scaner.Size = New System.Drawing.Size(88, 20)
        Me.tx_scaner.TabIndex = 67
        '
        'lb_cuenta
        '
        Me.lb_cuenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lb_cuenta.AutoSize = True
        Me.lb_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_cuenta.Location = New System.Drawing.Point(15, 409)
        Me.lb_cuenta.Name = "lb_cuenta"
        Me.lb_cuenta.Size = New System.Drawing.Size(35, 37)
        Me.lb_cuenta.TabIndex = 68
        Me.lb_cuenta.Text = "0"
        '
        'bt_cargar_traslados
        '
        Me.bt_cargar_traslados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_cargar_traslados.Location = New System.Drawing.Point(131, 341)
        Me.bt_cargar_traslados.Name = "bt_cargar_traslados"
        Me.bt_cargar_traslados.Size = New System.Drawing.Size(81, 62)
        Me.bt_cargar_traslados.TabIndex = 69
        Me.bt_cargar_traslados.Text = "Cargar Traslados"
        Me.bt_cargar_traslados.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"001-03", "005-03"})
        Me.ComboBox1.Location = New System.Drawing.Point(315, 366)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(95, 21)
        Me.ComboBox1.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(313, 346)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Bodega"
        '
        'fm_0800_cargar_rm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 483)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.bt_cargar_traslados)
        Me.Controls.Add(Me.lb_cuenta)
        Me.Controls.Add(Me.tx_scaner)
        Me.Controls.Add(Me.bt_exportar_archivo)
        Me.Controls.Add(Me.bt_generar_despacho)
        Me.Controls.Add(Me.lb_total_rms)
        Me.Controls.Add(Me.dg_remision_encabezado)
        Me.Controls.Add(Me.bt_cargar_rm)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "fm_0800_cargar_rm"
        Me.Text = "Cargar Remisiones CGUNO"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_cargar_rm, 0)
        Me.Controls.SetChildIndex(Me.dg_remision_encabezado, 0)
        Me.Controls.SetChildIndex(Me.lb_total_rms, 0)
        Me.Controls.SetChildIndex(Me.bt_generar_despacho, 0)
        Me.Controls.SetChildIndex(Me.bt_exportar_archivo, 0)
        Me.Controls.SetChildIndex(Me.tx_scaner, 0)
        Me.Controls.SetChildIndex(Me.lb_cuenta, 0)
        Me.Controls.SetChildIndex(Me.bt_cargar_traslados, 0)
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_remision_encabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_cargar_rm As System.Windows.Forms.Button
    Friend WithEvents dg_remision_encabezado As System.Windows.Forms.DataGridView
    Friend WithEvents lb_total_rms As System.Windows.Forms.Label
    Friend WithEvents bt_generar_despacho As System.Windows.Forms.Button
    Friend WithEvents bt_exportar_archivo As System.Windows.Forms.Button
    Friend WithEvents tx_scaner As System.Windows.Forms.TextBox
    Friend WithEvents lb_cuenta As System.Windows.Forms.Label
    Friend WithEvents bt_cargar_traslados As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
End Class
