<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_update_lotes_ip_cguno
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
        Me.bt_actualizar = New System.Windows.Forms.Button()
        Me.txt_ip_num = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dg_items = New System.Windows.Forms.DataGridView()
        Me.txt_lote = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2021/09/08"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(469, 32)
        Me.lb_titulo.Text = "Actualizacion de Lotes de IP-Cg-Uno"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 244)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 208)
        '
        'bt_actualizar
        '
        Me.bt_actualizar.Location = New System.Drawing.Point(103, 134)
        Me.bt_actualizar.Name = "bt_actualizar"
        Me.bt_actualizar.Size = New System.Drawing.Size(86, 58)
        Me.bt_actualizar.TabIndex = 2
        Me.bt_actualizar.Text = "Actualizar"
        Me.bt_actualizar.UseVisualStyleBackColor = True
        '
        'txt_ip_num
        '
        Me.txt_ip_num.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ip_num.Location = New System.Drawing.Point(63, 72)
        Me.txt_ip_num.Name = "txt_ip_num"
        Me.txt_ip_num.Size = New System.Drawing.Size(126, 22)
        Me.txt_ip_num.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "IP-Num:"
        '
        'dg_items
        '
        Me.dg_items.AllowUserToAddRows = False
        Me.dg_items.AllowUserToDeleteRows = False
        Me.dg_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_items.Location = New System.Drawing.Point(195, 72)
        Me.dg_items.Name = "dg_items"
        Me.dg_items.Size = New System.Drawing.Size(535, 120)
        Me.dg_items.TabIndex = 156
        '
        'txt_lote
        '
        Me.txt_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lote.Location = New System.Drawing.Point(63, 100)
        Me.txt_lote.Name = "txt_lote"
        Me.txt_lote.Size = New System.Drawing.Size(126, 22)
        Me.txt_lote.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 158
        Me.Label2.Text = "Lote:"
        '
        'fm_0400_update_lotes_ip_cguno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(742, 258)
        Me.Controls.Add(Me.txt_lote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dg_items)
        Me.Controls.Add(Me.txt_ip_num)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bt_actualizar)
        Me.Name = "fm_0400_update_lotes_ip_cguno"
        Me.Text = "Lotes IP"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.bt_actualizar, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txt_ip_num, 0)
        Me.Controls.SetChildIndex(Me.dg_items, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txt_lote, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bt_actualizar As Button
    Friend WithEvents txt_ip_num As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dg_items As DataGridView
    Friend WithEvents txt_lote As TextBox
    Friend WithEvents Label2 As Label
End Class
