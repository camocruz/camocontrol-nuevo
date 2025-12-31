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
        Me.tx_scaner = New System.Windows.Forms.TextBox()
        Me.lb_cuenta = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.lblPaginas = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_remision_encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2015/09/18"
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(556, 51)
        Me.lb_titulo.Text = "Cargar Remisiones CGUNO"
        '
        'bt_anular
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 724)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'bt_cargar_rm
        '
        Me.bt_cargar_rm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_cargar_rm.Location = New System.Drawing.Point(326, 525)
        Me.bt_cargar_rm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_cargar_rm.Name = "bt_cargar_rm"
        Me.bt_cargar_rm.Size = New System.Drawing.Size(122, 95)
        Me.bt_cargar_rm.TabIndex = 62
        Me.bt_cargar_rm.Text = "Cargar Rem"
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
        Me.dg_remision_encabezado.Location = New System.Drawing.Point(18, 94)
        Me.dg_remision_encabezado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dg_remision_encabezado.Name = "dg_remision_encabezado"
        Me.dg_remision_encabezado.RowHeadersWidth = 62
        Me.dg_remision_encabezado.Size = New System.Drawing.Size(1078, 421)
        Me.dg_remision_encabezado.TabIndex = 63
        '
        'lb_total_rms
        '
        Me.lb_total_rms.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lb_total_rms.AutoSize = True
        Me.lb_total_rms.Location = New System.Drawing.Point(18, 519)
        Me.lb_total_rms.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_total_rms.Name = "lb_total_rms"
        Me.lb_total_rms.Size = New System.Drawing.Size(18, 20)
        Me.lb_total_rms.TabIndex = 64
        Me.lb_total_rms.Text = "0"
        '
        'bt_generar_despacho
        '
        Me.bt_generar_despacho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_generar_despacho.Location = New System.Drawing.Point(873, 525)
        Me.bt_generar_despacho.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bt_generar_despacho.Name = "bt_generar_despacho"
        Me.bt_generar_despacho.Size = New System.Drawing.Size(122, 95)
        Me.bt_generar_despacho.TabIndex = 65
        Me.bt_generar_despacho.Text = "Generar Despacho"
        Me.bt_generar_despacho.UseVisualStyleBackColor = True
        '
        'tx_scaner
        '
        Me.tx_scaner.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_scaner.Location = New System.Drawing.Point(22, 594)
        Me.tx_scaner.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tx_scaner.Name = "tx_scaner"
        Me.tx_scaner.Size = New System.Drawing.Size(130, 26)
        Me.tx_scaner.TabIndex = 67
        '
        'lb_cuenta
        '
        Me.lb_cuenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lb_cuenta.AutoSize = True
        Me.lb_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_cuenta.Location = New System.Drawing.Point(22, 629)
        Me.lb_cuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_cuenta.Name = "lb_cuenta"
        Me.lb_cuenta.Size = New System.Drawing.Size(51, 55)
        Me.lb_cuenta.TabIndex = 68
        Me.lb_cuenta.Text = "0"
        '
        'btnCargar
        '
        Me.btnCargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCargar.Location = New System.Drawing.Point(505, 525)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(124, 95)
        Me.btnCargar.TabIndex = 73
        Me.btnCargar.Text = "Cargar Facturas UnoEE"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'lblRegistros
        '
        Me.lblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Location = New System.Drawing.Point(631, 608)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(57, 20)
        Me.lblRegistros.TabIndex = 76
        Me.lblRegistros.Text = "Label1"
        '
        'lblPaginas
        '
        Me.lblPaginas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPaginas.AutoSize = True
        Me.lblPaginas.Location = New System.Drawing.Point(631, 579)
        Me.lblPaginas.Name = "lblPaginas"
        Me.lblPaginas.Size = New System.Drawing.Size(57, 20)
        Me.lblPaginas.TabIndex = 75
        Me.lblPaginas.Text = "Label1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(635, 525)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(192, 45)
        Me.ProgressBar1.TabIndex = 74
        '
        'fm_0800_cargar_rm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1118, 743)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.lblPaginas)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.lb_cuenta)
        Me.Controls.Add(Me.tx_scaner)
        Me.Controls.Add(Me.bt_generar_despacho)
        Me.Controls.Add(Me.lb_total_rms)
        Me.Controls.Add(Me.dg_remision_encabezado)
        Me.Controls.Add(Me.bt_cargar_rm)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
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
        Me.Controls.SetChildIndex(Me.tx_scaner, 0)
        Me.Controls.SetChildIndex(Me.lb_cuenta, 0)
        Me.Controls.SetChildIndex(Me.btnCargar, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.lblPaginas, 0)
        Me.Controls.SetChildIndex(Me.lblRegistros, 0)
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
    Friend WithEvents tx_scaner As System.Windows.Forms.TextBox
    Friend WithEvents lb_cuenta As System.Windows.Forms.Label
    Friend WithEvents btnCargar As Button
    Friend WithEvents lblRegistros As Label
    Friend WithEvents lblPaginas As Label
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
