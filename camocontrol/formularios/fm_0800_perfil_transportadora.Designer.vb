<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0800_perfil_transportadora
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
        Me.bt_listado_fletes = New System.Windows.Forms.Button()
        Me.bt_tarifas = New System.Windows.Forms.Button()
        Me.tx_id_tercero = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cm_transportadora_despacho = New System.Windows.Forms.ComboBox()
        Me.tx_nit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2019/03/10"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(281, 32)
        Me.lb_titulo.Text = "Perfil Transportadora"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 206)
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 270)
        '
        'bt_listado_fletes
        '
        Me.bt_listado_fletes.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_listado_fletes.Image = Global.camocontrol.My.Resources.Resources.pesaje1_peq
        Me.bt_listado_fletes.Location = New System.Drawing.Point(381, 136)
        Me.bt_listado_fletes.Name = "bt_listado_fletes"
        Me.bt_listado_fletes.Size = New System.Drawing.Size(117, 39)
        Me.bt_listado_fletes.TabIndex = 4
        Me.bt_listado_fletes.Text = "Listado"
        Me.bt_listado_fletes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_listado_fletes.UseVisualStyleBackColor = False
        '
        'bt_tarifas
        '
        Me.bt_tarifas.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_tarifas.Image = Global.camocontrol.My.Resources.Resources.dinero01
        Me.bt_tarifas.Location = New System.Drawing.Point(258, 136)
        Me.bt_tarifas.Name = "bt_tarifas"
        Me.bt_tarifas.Size = New System.Drawing.Size(117, 39)
        Me.bt_tarifas.TabIndex = 3
        Me.bt_tarifas.Text = "Definir Fletes"
        Me.bt_tarifas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_tarifas.UseVisualStyleBackColor = False
        '
        'tx_id_tercero
        '
        Me.tx_id_tercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_tercero.Location = New System.Drawing.Point(117, 76)
        Me.tx_id_tercero.Name = "tx_id_tercero"
        Me.tx_id_tercero.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_tercero.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 16)
        Me.Label7.TabIndex = 177
        Me.Label7.Text = "Transportadora:"
        '
        'cm_transportadora_despacho
        '
        Me.cm_transportadora_despacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_transportadora_despacho.FormattingEnabled = True
        Me.cm_transportadora_despacho.Location = New System.Drawing.Point(299, 76)
        Me.cm_transportadora_despacho.Name = "cm_transportadora_despacho"
        Me.cm_transportadora_despacho.Size = New System.Drawing.Size(434, 24)
        Me.cm_transportadora_despacho.TabIndex = 2
        '
        'tx_nit
        '
        Me.tx_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nit.Location = New System.Drawing.Point(199, 76)
        Me.tx_nit.Name = "tx_nit"
        Me.tx_nit.Size = New System.Drawing.Size(96, 22)
        Me.tx_nit.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "NIt:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(298, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "Razon Social:"
        '
        'fm_0800_perfil_transportadora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 284)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_nit)
        Me.Controls.Add(Me.cm_transportadora_despacho)
        Me.Controls.Add(Me.bt_listado_fletes)
        Me.Controls.Add(Me.bt_tarifas)
        Me.Controls.Add(Me.tx_id_tercero)
        Me.Controls.Add(Me.Label7)
        Me.KeyPreview = True
        Me.Name = "fm_0800_perfil_transportadora"
        Me.Text = "Perfil Transportadora"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_id_tercero, 0)
        Me.Controls.SetChildIndex(Me.bt_tarifas, 0)
        Me.Controls.SetChildIndex(Me.bt_listado_fletes, 0)
        Me.Controls.SetChildIndex(Me.cm_transportadora_despacho, 0)
        Me.Controls.SetChildIndex(Me.tx_nit, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_listado_fletes As Button
    Friend WithEvents bt_tarifas As Button
    Friend WithEvents tx_id_tercero As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cm_transportadora_despacho As ComboBox
    Friend WithEvents tx_nit As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
