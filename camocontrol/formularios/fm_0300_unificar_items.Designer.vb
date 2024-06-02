<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_unificar_items
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cm_descripcion_queda = New System.Windows.Forms.ComboBox()
        Me.tx_id_item_queda = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_procesar = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(590, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(591, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2018/04/14"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(500, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(191, 32)
        Me.lb_titulo.Text = "Unificar Items"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 390)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 354)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(45, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 24)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Id_item:"
        '
        'cm_descripcion_queda
        '
        Me.cm_descripcion_queda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_descripcion_queda.FormattingEnabled = True
        Me.cm_descripcion_queda.Location = New System.Drawing.Point(189, 236)
        Me.cm_descripcion_queda.Name = "cm_descripcion_queda"
        Me.cm_descripcion_queda.Size = New System.Drawing.Size(411, 24)
        Me.cm_descripcion_queda.TabIndex = 139
        '
        'tx_id_item_queda
        '
        Me.tx_id_item_queda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_item_queda.Location = New System.Drawing.Point(104, 238)
        Me.tx_id_item_queda.Name = "tx_id_item_queda"
        Me.tx_id_item_queda.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_item_queda.TabIndex = 138
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 241)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Id_item:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 16)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Item que DESAPARECERA:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 217)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 16)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "Item que QUEDARA:"
        '
        'bt_procesar
        '
        Me.bt_procesar.BackgroundImage = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_procesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_procesar.Location = New System.Drawing.Point(307, 266)
        Me.bt_procesar.Name = "bt_procesar"
        Me.bt_procesar.Size = New System.Drawing.Size(93, 70)
        Me.bt_procesar.TabIndex = 142
        Me.bt_procesar.Text = "Procesar"
        Me.bt_procesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_procesar.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.camocontrol.My.Resources.Resources.flecha_abajo
        Me.PictureBox2.Location = New System.Drawing.Point(307, 132)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(93, 84)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 143
        Me.PictureBox2.TabStop = False
        '
        'fm_0300_unificar_items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(669, 404)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.bt_procesar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cm_descripcion_queda)
        Me.Controls.Add(Me.tx_id_item_queda)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Name = "fm_0300_unificar_items"
        Me.Text = "Unificador de Items"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_id_item_queda, 0)
        Me.Controls.SetChildIndex(Me.cm_descripcion_queda, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.bt_procesar, 0)
        Me.Controls.SetChildIndex(Me.PictureBox2, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As Label
    Friend WithEvents cm_descripcion_queda As ComboBox
    Friend WithEvents tx_id_item_queda As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents bt_procesar As Button
    Friend WithEvents PictureBox2 As PictureBox
End Class
