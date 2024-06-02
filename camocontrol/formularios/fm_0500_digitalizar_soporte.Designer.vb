<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0500_digitalizar_soporte
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
        Me.bt_cargue_manual = New System.Windows.Forms.Button()
        Me.tx_path_dir = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_tipo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_cargue_automatico = New System.Windows.Forms.Button()
        Me.bt_definir_directorio = New System.Windows.Forms.Button()
        Me.tx_consecutivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_existencia = New System.Windows.Forms.Label()
        Me.cm_tipo_doc = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2018/12/07"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(292, 32)
        Me.lb_titulo.Text = "Digitalizar Documento"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 272)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 236)
        Me.bt_salir.TabIndex = 4
        '
        'bt_cargue_manual
        '
        Me.bt_cargue_manual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cargue_manual.Image = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_cargue_manual.Location = New System.Drawing.Point(273, 128)
        Me.bt_cargue_manual.Name = "bt_cargue_manual"
        Me.bt_cargue_manual.Size = New System.Drawing.Size(49, 53)
        Me.bt_cargue_manual.TabIndex = 2
        Me.bt_cargue_manual.UseVisualStyleBackColor = True
        '
        'tx_path_dir
        '
        Me.tx_path_dir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_path_dir.Location = New System.Drawing.Point(15, 86)
        Me.tx_path_dir.Name = "tx_path_dir"
        Me.tx_path_dir.ReadOnly = True
        Me.tx_path_dir.Size = New System.Drawing.Size(643, 22)
        Me.tx_path_dir.TabIndex = 187
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 16)
        Me.Label8.TabIndex = 186
        Me.Label8.Text = "Directorio de Captura:"
        '
        'tx_tipo
        '
        Me.tx_tipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_tipo.Location = New System.Drawing.Point(15, 140)
        Me.tx_tipo.Name = "tx_tipo"
        Me.tx_tipo.Size = New System.Drawing.Size(61, 26)
        Me.tx_tipo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 188
        Me.Label1.Text = "Tipo:"
        '
        'bt_cargue_automatico
        '
        Me.bt_cargue_automatico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cargue_automatico.Image = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_cargue_automatico.Location = New System.Drawing.Point(216, 128)
        Me.bt_cargue_automatico.Name = "bt_cargue_automatico"
        Me.bt_cargue_automatico.Size = New System.Drawing.Size(49, 53)
        Me.bt_cargue_automatico.TabIndex = 3
        Me.bt_cargue_automatico.UseVisualStyleBackColor = True
        '
        'bt_definir_directorio
        '
        Me.bt_definir_directorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_definir_directorio.Image = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_definir_directorio.Location = New System.Drawing.Point(664, 78)
        Me.bt_definir_directorio.Name = "bt_definir_directorio"
        Me.bt_definir_directorio.Size = New System.Drawing.Size(49, 38)
        Me.bt_definir_directorio.TabIndex = 191
        Me.bt_definir_directorio.UseVisualStyleBackColor = True
        '
        'tx_consecutivo
        '
        Me.tx_consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_consecutivo.Location = New System.Drawing.Point(82, 140)
        Me.tx_consecutivo.Name = "tx_consecutivo"
        Me.tx_consecutivo.Size = New System.Drawing.Size(118, 26)
        Me.tx_consecutivo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(79, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 192
        Me.Label2.Text = "Consecutivo:"
        '
        'lb_existencia
        '
        Me.lb_existencia.AutoSize = True
        Me.lb_existencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_existencia.Location = New System.Drawing.Point(10, 169)
        Me.lb_existencia.Name = "lb_existencia"
        Me.lb_existencia.Size = New System.Drawing.Size(83, 25)
        Me.lb_existencia.TabIndex = 193
        Me.lb_existencia.Text = "Label3"
        '
        'cm_tipo_doc
        '
        Me.cm_tipo_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_doc.FormattingEnabled = True
        Me.cm_tipo_doc.Location = New System.Drawing.Point(428, 153)
        Me.cm_tipo_doc.Name = "cm_tipo_doc"
        Me.cm_tipo_doc.Size = New System.Drawing.Size(118, 28)
        Me.cm_tipo_doc.TabIndex = 194
        '
        'fm_0500_digitalizar_soporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(742, 286)
        Me.Controls.Add(Me.cm_tipo_doc)
        Me.Controls.Add(Me.lb_existencia)
        Me.Controls.Add(Me.tx_consecutivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bt_definir_directorio)
        Me.Controls.Add(Me.bt_cargue_automatico)
        Me.Controls.Add(Me.tx_tipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_path_dir)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.bt_cargue_manual)
        Me.Name = "fm_0500_digitalizar_soporte"
        Me.Text = "Digitalizar Documento"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.bt_cargue_manual, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_path_dir, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_tipo, 0)
        Me.Controls.SetChildIndex(Me.bt_cargue_automatico, 0)
        Me.Controls.SetChildIndex(Me.bt_definir_directorio, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_consecutivo, 0)
        Me.Controls.SetChildIndex(Me.lb_existencia, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_doc, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bt_cargue_manual As Button
    Friend WithEvents tx_path_dir As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tx_tipo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bt_cargue_automatico As Button
    Friend WithEvents bt_definir_directorio As Button
    Friend WithEvents tx_consecutivo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lb_existencia As Label
    Friend WithEvents cm_tipo_doc As ComboBox
End Class
