<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0008_asignar_recibo_consignacion
    Inherits camocontrol.FM_PLANTILLA

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
        Me.tx_id_recaudo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_valor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_numero_recibo = New System.Windows.Forms.TextBox()
        Me.tx_nota_recibo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_nota_identificacion = New System.Windows.Forms.TextBox()
        Me.tx_fecha_identificado = New System.Windows.Forms.TextBox()
        Me.tx_funcionario_identifica = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_funcionario_reporta = New System.Windows.Forms.TextBox()
        Me.tx_fecha_reportado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cm_nit = New System.Windows.Forms.ComboBox()
        Me.cm_razon_social = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cm_tipo_recibo = New System.Windows.Forms.ComboBox()
        Me.lb_convenio = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(596, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(694, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(695, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/09/12"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(395, 32)
        Me.lb_titulo.Text = "Registrar Recibo Consignacion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(252, 425)
        '
        'bt_grabar
        '
        '
        'bt_anular
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 485)
        '
        'bt_editar
        '
        '
        'tx_id_recaudo
        '
        Me.tx_id_recaudo.Enabled = False
        Me.tx_id_recaudo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_recaudo.Location = New System.Drawing.Point(119, 67)
        Me.tx_id_recaudo.Name = "tx_id_recaudo"
        Me.tx_id_recaudo.Size = New System.Drawing.Size(147, 26)
        Me.tx_id_recaudo.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 20)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Id_Recaudo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(291, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 20)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Valor:"
        '
        'tx_valor
        '
        Me.tx_valor.Enabled = False
        Me.tx_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_valor.Location = New System.Drawing.Point(347, 67)
        Me.tx_valor.Name = "tx_valor"
        Me.tx_valor.Size = New System.Drawing.Size(163, 26)
        Me.tx_valor.TabIndex = 64
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 20)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Recibo CG:"
        '
        'tx_numero_recibo
        '
        Me.tx_numero_recibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_numero_recibo.Location = New System.Drawing.Point(185, 287)
        Me.tx_numero_recibo.Name = "tx_numero_recibo"
        Me.tx_numero_recibo.Size = New System.Drawing.Size(104, 26)
        Me.tx_numero_recibo.TabIndex = 66
        '
        'tx_nota_recibo
        '
        Me.tx_nota_recibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_nota_recibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nota_recibo.Location = New System.Drawing.Point(119, 319)
        Me.tx_nota_recibo.Multiline = True
        Me.tx_nota_recibo.Name = "tx_nota_recibo"
        Me.tx_nota_recibo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_nota_recibo.Size = New System.Drawing.Size(646, 97)
        Me.tx_nota_recibo.TabIndex = 68
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 322)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 20)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Nota:"
        '
        'txt_nota_identificacion
        '
        Me.txt_nota_identificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nota_identificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_identificacion.Location = New System.Drawing.Point(119, 163)
        Me.txt_nota_identificacion.Multiline = True
        Me.txt_nota_identificacion.Name = "txt_nota_identificacion"
        Me.txt_nota_identificacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_nota_identificacion.Size = New System.Drawing.Size(646, 85)
        Me.txt_nota_identificacion.TabIndex = 70
        '
        'tx_fecha_identificado
        '
        Me.tx_fecha_identificado.Enabled = False
        Me.tx_fecha_identificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_fecha_identificado.Location = New System.Drawing.Point(119, 99)
        Me.tx_fecha_identificado.Name = "tx_fecha_identificado"
        Me.tx_fecha_identificado.Size = New System.Drawing.Size(170, 26)
        Me.tx_fecha_identificado.TabIndex = 71
        '
        'tx_funcionario_identifica
        '
        Me.tx_funcionario_identifica.Enabled = False
        Me.tx_funcionario_identifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_funcionario_identifica.Location = New System.Drawing.Point(295, 99)
        Me.tx_funcionario_identifica.Name = "tx_funcionario_identifica"
        Me.tx_funcionario_identifica.Size = New System.Drawing.Size(472, 26)
        Me.tx_funcionario_identifica.TabIndex = 72
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 20)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "Identificado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(71, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 20)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Nit:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 257)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 20)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Recaudado:"
        '
        'tx_funcionario_reporta
        '
        Me.tx_funcionario_reporta.Enabled = False
        Me.tx_funcionario_reporta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_funcionario_reporta.Location = New System.Drawing.Point(295, 254)
        Me.tx_funcionario_reporta.Name = "tx_funcionario_reporta"
        Me.tx_funcionario_reporta.Size = New System.Drawing.Size(472, 26)
        Me.tx_funcionario_reporta.TabIndex = 78
        '
        'tx_fecha_reportado
        '
        Me.tx_fecha_reportado.Enabled = False
        Me.tx_fecha_reportado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_fecha_reportado.Location = New System.Drawing.Point(119, 254)
        Me.tx_fecha_reportado.Name = "tx_fecha_reportado"
        Me.tx_fecha_reportado.Size = New System.Drawing.Size(170, 26)
        Me.tx_fecha_reportado.TabIndex = 77
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(516, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Valor:"
        '
        'cm_nit
        '
        Me.cm_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_nit.FormattingEnabled = True
        Me.cm_nit.Location = New System.Drawing.Point(119, 129)
        Me.cm_nit.Name = "cm_nit"
        Me.cm_nit.Size = New System.Drawing.Size(170, 28)
        Me.cm_nit.TabIndex = 86
        '
        'cm_razon_social
        '
        Me.cm_razon_social.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_razon_social.FormattingEnabled = True
        Me.cm_razon_social.Location = New System.Drawing.Point(295, 129)
        Me.cm_razon_social.Name = "cm_razon_social"
        Me.cm_razon_social.Size = New System.Drawing.Size(472, 28)
        Me.cm_razon_social.TabIndex = 87
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 20)
        Me.Label11.TabIndex = 88
        Me.Label11.Text = "Nota:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 183)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 20)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "Proceso"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 20)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Identificacion:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 362)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 20)
        Me.Label14.TabIndex = 92
        Me.Label14.Text = "Recaudo:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 342)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 20)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "Proceso"
        '
        'cm_tipo_recibo
        '
        Me.cm_tipo_recibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_recibo.FormattingEnabled = True
        Me.cm_tipo_recibo.Location = New System.Drawing.Point(119, 286)
        Me.cm_tipo_recibo.Name = "cm_tipo_recibo"
        Me.cm_tipo_recibo.Size = New System.Drawing.Size(60, 28)
        Me.cm_tipo_recibo.TabIndex = 93
        '
        'lb_convenio
        '
        Me.lb_convenio.AutoSize = True
        Me.lb_convenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_convenio.Location = New System.Drawing.Point(295, 287)
        Me.lb_convenio.Name = "lb_convenio"
        Me.lb_convenio.Size = New System.Drawing.Size(236, 24)
        Me.lb_convenio.TabIndex = 94
        Me.lb_convenio.Text = "SOPORTE REQUERIDO"
        '
        'fm_0008_asignar_recibo_consignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(781, 499)
        Me.Controls.Add(Me.lb_convenio)
        Me.Controls.Add(Me.cm_tipo_recibo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cm_razon_social)
        Me.Controls.Add(Me.cm_nit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_funcionario_reporta)
        Me.Controls.Add(Me.tx_fecha_reportado)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_funcionario_identifica)
        Me.Controls.Add(Me.tx_fecha_identificado)
        Me.Controls.Add(Me.txt_nota_identificacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_nota_recibo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_numero_recibo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_valor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_id_recaudo)
        Me.Name = "fm_0008_asignar_recibo_consignacion"
        Me.Text = "Registrar Recibo"
        Me.Controls.SetChildIndex(Me.tx_id_recaudo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_valor, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_numero_recibo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_nota_recibo, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_nota_identificacion, 0)
        Me.Controls.SetChildIndex(Me.tx_fecha_identificado, 0)
        Me.Controls.SetChildIndex(Me.tx_funcionario_identifica, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_fecha_reportado, 0)
        Me.Controls.SetChildIndex(Me.tx_funcionario_reporta, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.cm_nit, 0)
        Me.Controls.SetChildIndex(Me.cm_razon_social, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_recibo, 0)
        Me.Controls.SetChildIndex(Me.lb_convenio, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_id_recaudo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_valor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tx_numero_recibo As System.Windows.Forms.TextBox
    Friend WithEvents tx_nota_recibo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_nota_identificacion As System.Windows.Forms.TextBox
    Friend WithEvents tx_fecha_identificado As System.Windows.Forms.TextBox
    Friend WithEvents tx_funcionario_identifica As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tx_funcionario_reporta As System.Windows.Forms.TextBox
    Friend WithEvents tx_fecha_reportado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cm_nit As System.Windows.Forms.ComboBox
    Friend WithEvents cm_razon_social As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cm_tipo_recibo As System.Windows.Forms.ComboBox
    Friend WithEvents lb_convenio As Label
End Class
