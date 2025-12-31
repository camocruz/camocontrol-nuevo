<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0800_cargar_pedidos_unoee
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblPaginas = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2025/12/13"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 108)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(1082, 255)
        Me.DataGridView1.TabIndex = 63
        '
        'btnCargar
        '
        Me.btnCargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCargar.Location = New System.Drawing.Point(476, 515)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(146, 71)
        Me.btnCargar.TabIndex = 64
        Me.btnCargar.Text = "Button1"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(716, 486)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(384, 45)
        Me.ProgressBar1.TabIndex = 65
        '
        'lblPaginas
        '
        Me.lblPaginas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPaginas.AutoSize = True
        Me.lblPaginas.Location = New System.Drawing.Point(712, 540)
        Me.lblPaginas.Name = "lblPaginas"
        Me.lblPaginas.Size = New System.Drawing.Size(57, 20)
        Me.lblPaginas.TabIndex = 66
        Me.lblPaginas.Text = "Label1"
        '
        'lblRegistros
        '
        Me.lblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Location = New System.Drawing.Point(712, 569)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(57, 20)
        Me.lblRegistros.TabIndex = 68
        Me.lblRegistros.Text = "Label1"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Location = New System.Drawing.Point(170, 505)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(94, 45)
        Me.btnLimpiar.TabIndex = 69
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(12, 381)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 62
        Me.DataGridView2.RowTemplate.Height = 28
        Me.DataGridView2.Size = New System.Drawing.Size(1082, 67)
        Me.DataGridView2.TabIndex = 70
        '
        'fm_0800_cargar_pedidos_unoee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1113, 705)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.lblPaginas)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(3)
        Me.Name = "fm_0800_cargar_pedidos_unoee"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.btnCargar, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.lblPaginas, 0)
        Me.Controls.SetChildIndex(Me.lblRegistros, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiar, 0)
        Me.Controls.SetChildIndex(Me.DataGridView2, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnCargar As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblPaginas As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents DataGridView2 As DataGridView
End Class
