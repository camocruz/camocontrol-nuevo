<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_cargar_ip_cguno
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_cargar = New System.Windows.Forms.Button()
        Me.dg_maximos = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_maximos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(605, 9)
        Me.lb_mi_marca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(606, 36)
        Me.lb_fecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2021/07/21"
        '
        'll_linea1
        '
        Me.ll_linea1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ll_linea1.Size = New System.Drawing.Size(515, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_titulo.Size = New System.Drawing.Size(357, 32)
        Me.lb_titulo.Text = "Cargar IP CgUno Reporte 9"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 282)
        Me.lb_diseñador_programa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 246)
        Me.bt_salir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 25)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Consecutivos Actuales"
        '
        'btn_cargar
        '
        Me.btn_cargar.BackgroundImage = Global.camocontrol.My.Resources.Resources.actualizar
        Me.btn_cargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_cargar.Location = New System.Drawing.Point(349, 128)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(60, 53)
        Me.btn_cargar.TabIndex = 66
        Me.btn_cargar.Text = "Cargar"
        Me.btn_cargar.UseVisualStyleBackColor = True
        '
        'dg_maximos
        '
        Me.dg_maximos.AllowUserToAddRows = False
        Me.dg_maximos.AllowUserToDeleteRows = False
        Me.dg_maximos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dg_maximos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dg_maximos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_maximos.Location = New System.Drawing.Point(88, 94)
        Me.dg_maximos.Name = "dg_maximos"
        Me.dg_maximos.ReadOnly = True
        Me.dg_maximos.Size = New System.Drawing.Size(243, 126)
        Me.dg_maximos.TabIndex = 67
        '
        'fm_0400_cargar_ip_cguno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(684, 296)
        Me.Controls.Add(Me.dg_maximos)
        Me.Controls.Add(Me.btn_cargar)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "fm_0400_cargar_ip_cguno"
        Me.Text = "Cargar IP CgUno"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btn_cargar, 0)
        Me.Controls.SetChildIndex(Me.dg_maximos, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_maximos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btn_cargar As Button
    Friend WithEvents dg_maximos As DataGridView
End Class
