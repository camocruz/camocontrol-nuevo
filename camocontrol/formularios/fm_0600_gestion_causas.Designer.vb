<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0600_gestion_causas
    Inherits camocontrol.FM_PLANTILLA

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
        Me.cm_emisor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_id_accion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_texto_tarea = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tx_estructura = New System.Windows.Forms.TextBox()
        Me.bt_cambiar_infraestructura = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rb_grupo = New System.Windows.Forms.RadioButton()
        Me.rb_causa = New System.Windows.Forms.RadioButton()
        Me.bt_actividades_hijo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/05/04"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(239, 32)
        Me.lb_titulo.Text = "Gestion de Causas"
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        '
        'cm_emisor
        '
        Me.cm_emisor.Enabled = False
        Me.cm_emisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_emisor.FormattingEnabled = True
        Me.cm_emisor.Location = New System.Drawing.Point(306, 61)
        Me.cm_emisor.Name = "cm_emisor"
        Me.cm_emisor.Size = New System.Drawing.Size(427, 24)
        Me.cm_emisor.TabIndex = 91
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(253, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Emisor:"
        '
        'tx_id_accion
        '
        Me.tx_id_accion.Enabled = False
        Me.tx_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_accion.Location = New System.Drawing.Point(38, 61)
        Me.tx_id_accion.Name = "tx_id_accion"
        Me.tx_id_accion.Size = New System.Drawing.Size(79, 22)
        Me.tx_id_accion.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 16)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Id:"
        '
        'tx_texto_tarea
        '
        Me.tx_texto_tarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_texto_tarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_texto_tarea.Location = New System.Drawing.Point(13, 185)
        Me.tx_texto_tarea.Multiline = True
        Me.tx_texto_tarea.Name = "tx_texto_tarea"
        Me.tx_texto_tarea.Size = New System.Drawing.Size(720, 219)
        Me.tx_texto_tarea.TabIndex = 140
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 16)
        Me.Label15.TabIndex = 164
        Me.Label15.Text = "Equipo:"
        '
        'tx_estructura
        '
        Me.tx_estructura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estructura.Location = New System.Drawing.Point(72, 125)
        Me.tx_estructura.Multiline = True
        Me.tx_estructura.Name = "tx_estructura"
        Me.tx_estructura.Size = New System.Drawing.Size(634, 55)
        Me.tx_estructura.TabIndex = 163
        '
        'bt_cambiar_infraestructura
        '
        Me.bt_cambiar_infraestructura.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargarplano
        Me.bt_cambiar_infraestructura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cambiar_infraestructura.Location = New System.Drawing.Point(712, 125)
        Me.bt_cambiar_infraestructura.Name = "bt_cambiar_infraestructura"
        Me.bt_cambiar_infraestructura.Size = New System.Drawing.Size(21, 22)
        Me.bt_cambiar_infraestructura.TabIndex = 162
        Me.bt_cambiar_infraestructura.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rb_grupo)
        Me.GroupBox2.Controls.Add(Me.rb_causa)
        Me.GroupBox2.Location = New System.Drawing.Point(139, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(83, 57)
        Me.GroupBox2.TabIndex = 165
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo"
        '
        'rb_grupo
        '
        Me.rb_grupo.AutoSize = True
        Me.rb_grupo.Location = New System.Drawing.Point(7, 33)
        Me.rb_grupo.Name = "rb_grupo"
        Me.rb_grupo.Size = New System.Drawing.Size(54, 17)
        Me.rb_grupo.TabIndex = 166
        Me.rb_grupo.TabStop = True
        Me.rb_grupo.Text = "Grupo"
        Me.rb_grupo.UseVisualStyleBackColor = True
        '
        'rb_causa
        '
        Me.rb_causa.AutoSize = True
        Me.rb_causa.Location = New System.Drawing.Point(7, 15)
        Me.rb_causa.Name = "rb_causa"
        Me.rb_causa.Size = New System.Drawing.Size(55, 17)
        Me.rb_causa.TabIndex = 0
        Me.rb_causa.TabStop = True
        Me.rb_causa.Text = "Causa"
        Me.rb_causa.UseVisualStyleBackColor = True
        '
        'bt_actividades_hijo
        '
        Me.bt_actividades_hijo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_actividades_hijo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_actividades_hijo.Image = Global.camocontrol.My.Resources.Resources.espina_pescado
        Me.bt_actividades_hijo.Location = New System.Drawing.Point(669, 427)
        Me.bt_actividades_hijo.Name = "bt_actividades_hijo"
        Me.bt_actividades_hijo.Size = New System.Drawing.Size(49, 38)
        Me.bt_actividades_hijo.TabIndex = 170
        Me.bt_actividades_hijo.UseVisualStyleBackColor = True
        '
        'fm_0600_gestion_causas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 483)
        Me.Controls.Add(Me.bt_actividades_hijo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tx_estructura)
        Me.Controls.Add(Me.bt_cambiar_infraestructura)
        Me.Controls.Add(Me.tx_texto_tarea)
        Me.Controls.Add(Me.cm_emisor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_id_accion)
        Me.Controls.Add(Me.Label5)
        Me.Name = "fm_0600_gestion_causas"
        Me.Text = "Gestion de Causas"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_id_accion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cm_emisor, 0)
        Me.Controls.SetChildIndex(Me.tx_texto_tarea, 0)
        Me.Controls.SetChildIndex(Me.bt_cambiar_infraestructura, 0)
        Me.Controls.SetChildIndex(Me.tx_estructura, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.bt_actividades_hijo, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cm_emisor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tx_id_accion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_texto_tarea As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tx_estructura As System.Windows.Forms.TextBox
    Friend WithEvents bt_cambiar_infraestructura As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rb_grupo As RadioButton
    Friend WithEvents rb_causa As RadioButton
    Friend WithEvents bt_actividades_hijo As Button
End Class
