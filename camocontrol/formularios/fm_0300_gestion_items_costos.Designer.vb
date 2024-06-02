<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_gestion_items_costos
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
        Me.tx_ultimo_costo_compra = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tx_costo_promedio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tx_costo_estandar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_historico_compras = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2017/11/26"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(419, 32)
        Me.lb_titulo.Text = "Informacion Costos e Inventarios"
        '
        'bt_grabar
        '
        '
        'tx_ultimo_costo_compra
        '
        Me.tx_ultimo_costo_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_ultimo_costo_compra.Location = New System.Drawing.Point(194, 122)
        Me.tx_ultimo_costo_compra.Name = "tx_ultimo_costo_compra"
        Me.tx_ultimo_costo_compra.ReadOnly = True
        Me.tx_ultimo_costo_compra.Size = New System.Drawing.Size(150, 22)
        Me.tx_ultimo_costo_compra.TabIndex = 166
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(27, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(157, 16)
        Me.Label13.TabIndex = 165
        Me.Label13.Text = "Ultimo Costo de Compra:"
        '
        'tx_costo_promedio
        '
        Me.tx_costo_promedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_costo_promedio.Location = New System.Drawing.Point(194, 145)
        Me.tx_costo_promedio.Name = "tx_costo_promedio"
        Me.tx_costo_promedio.Size = New System.Drawing.Size(150, 22)
        Me.tx_costo_promedio.TabIndex = 164
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(27, 148)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(148, 16)
        Me.Label12.TabIndex = 163
        Me.Label12.Text = "Costo Promedio Actual:"
        '
        'tx_costo_estandar
        '
        Me.tx_costo_estandar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_costo_estandar.Location = New System.Drawing.Point(194, 168)
        Me.tx_costo_estandar.Name = "tx_costo_estandar"
        Me.tx_costo_estandar.Size = New System.Drawing.Size(150, 22)
        Me.tx_costo_estandar.TabIndex = 168
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Costo Estandar:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 20)
        Me.Label2.TabIndex = 169
        Me.Label2.Text = "Informacion Costos Unitarios"
        '
        'bt_historico_compras
        '
        Me.bt_historico_compras.BackgroundImage = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_historico_compras.Image = Global.camocontrol.My.Resources.Resources.icono_estadisticas
        Me.bt_historico_compras.Location = New System.Drawing.Point(350, 110)
        Me.bt_historico_compras.Name = "bt_historico_compras"
        Me.bt_historico_compras.Size = New System.Drawing.Size(32, 34)
        Me.bt_historico_compras.TabIndex = 201
        Me.bt_historico_compras.UseVisualStyleBackColor = True
        '
        'fm_0300_gestion_items_costos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 488)
        Me.Controls.Add(Me.bt_historico_compras)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_costo_estandar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_ultimo_costo_compra)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tx_costo_promedio)
        Me.Controls.Add(Me.Label12)
        Me.Name = "fm_0300_gestion_items_costos"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.tx_costo_promedio, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tx_ultimo_costo_compra, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_costo_estandar, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.bt_historico_compras, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tx_ultimo_costo_compra As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tx_costo_promedio As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tx_costo_estandar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents bt_historico_compras As Button
End Class
