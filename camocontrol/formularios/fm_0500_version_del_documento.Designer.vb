<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0500_version_del_documento
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
        Me.tx_id_doc_ed = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.tx_version = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_cambio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_fecha_revision = New System.Windows.Forms.TextBox()
        Me.tx_fecha_aprobacion = New System.Windows.Forms.TextBox()
        Me.cm_aprobadopor = New System.Windows.Forms.ComboBox()
        Me.cm_revisadopor = New System.Windows.Forms.ComboBox()
        Me.bt_fecha_rev = New System.Windows.Forms.Button()
        Me.bt_fecha_aprob = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.bt_fecha_ini_tramites = New System.Windows.Forms.Button()
        Me.bt_fecha_max_vigencia = New System.Windows.Forms.Button()
        Me.tx_fecha_ini_tramites = New System.Windows.Forms.TextBox()
        Me.tx_fecha_max_vigencia = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/02/24"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(298, 32)
        Me.lb_titulo.Text = "Version del Documento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(210, 325)
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 384)
        '
        'tx_id_doc_ed
        '
        Me.tx_id_doc_ed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_doc_ed.Location = New System.Drawing.Point(122, 69)
        Me.tx_id_doc_ed.Name = "tx_id_doc_ed"
        Me.tx_id_doc_ed.ReadOnly = True
        Me.tx_id_doc_ed.Size = New System.Drawing.Size(77, 22)
        Me.tx_id_doc_ed.TabIndex = 246
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(12, 75)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(73, 16)
        Me.Label37.TabIndex = 245
        Me.Label37.Text = "id_edicion:"
        '
        'tx_version
        '
        Me.tx_version.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_version.Location = New System.Drawing.Point(122, 97)
        Me.tx_version.Name = "tx_version"
        Me.tx_version.ReadOnly = True
        Me.tx_version.Size = New System.Drawing.Size(220, 62)
        Me.tx_version.TabIndex = 248
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 247
        Me.Label1.Text = "Version #:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(486, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 251
        Me.Label6.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Revisado por:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(486, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 255
        Me.Label3.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 253
        Me.Label4.Text = "Aprobado por:"
        '
        'tx_cambio
        '
        Me.tx_cambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_cambio.Location = New System.Drawing.Point(122, 226)
        Me.tx_cambio.Multiline = True
        Me.tx_cambio.Name = "tx_cambio"
        Me.tx_cambio.Size = New System.Drawing.Size(565, 88)
        Me.tx_cambio.TabIndex = 259
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 16)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Cambio:"
        '
        'tx_fecha_revision
        '
        Me.tx_fecha_revision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_fecha_revision.Location = New System.Drawing.Point(543, 164)
        Me.tx_fecha_revision.Name = "tx_fecha_revision"
        Me.tx_fecha_revision.ReadOnly = True
        Me.tx_fecha_revision.Size = New System.Drawing.Size(112, 22)
        Me.tx_fecha_revision.TabIndex = 263
        '
        'tx_fecha_aprobacion
        '
        Me.tx_fecha_aprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_fecha_aprobacion.Location = New System.Drawing.Point(543, 193)
        Me.tx_fecha_aprobacion.Name = "tx_fecha_aprobacion"
        Me.tx_fecha_aprobacion.ReadOnly = True
        Me.tx_fecha_aprobacion.Size = New System.Drawing.Size(112, 22)
        Me.tx_fecha_aprobacion.TabIndex = 264
        '
        'cm_aprobadopor
        '
        Me.cm_aprobadopor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_aprobadopor.FormattingEnabled = True
        Me.cm_aprobadopor.Location = New System.Drawing.Point(122, 193)
        Me.cm_aprobadopor.Name = "cm_aprobadopor"
        Me.cm_aprobadopor.Size = New System.Drawing.Size(358, 24)
        Me.cm_aprobadopor.TabIndex = 280
        '
        'cm_revisadopor
        '
        Me.cm_revisadopor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_revisadopor.FormattingEnabled = True
        Me.cm_revisadopor.Location = New System.Drawing.Point(122, 164)
        Me.cm_revisadopor.Name = "cm_revisadopor"
        Me.cm_revisadopor.Size = New System.Drawing.Size(358, 24)
        Me.cm_revisadopor.TabIndex = 279
        '
        'bt_fecha_rev
        '
        Me.bt_fecha_rev.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_rev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_fecha_rev.Location = New System.Drawing.Point(657, 160)
        Me.bt_fecha_rev.Name = "bt_fecha_rev"
        Me.bt_fecha_rev.Size = New System.Drawing.Size(30, 30)
        Me.bt_fecha_rev.TabIndex = 281
        Me.bt_fecha_rev.UseVisualStyleBackColor = True
        '
        'bt_fecha_aprob
        '
        Me.bt_fecha_aprob.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_aprob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_fecha_aprob.Location = New System.Drawing.Point(657, 190)
        Me.bt_fecha_aprob.Name = "bt_fecha_aprob"
        Me.bt_fecha_aprob.Size = New System.Drawing.Size(30, 30)
        Me.bt_fecha_aprob.TabIndex = 282
        Me.bt_fecha_aprob.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(363, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(158, 16)
        Me.Label7.TabIndex = 286
        Me.Label7.Text = "Fecha Inicio de Tramites:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(363, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 16)
        Me.Label8.TabIndex = 285
        Me.Label8.Text = "Fecha Maxima de Vigencia:"
        '
        'bt_fecha_ini_tramites
        '
        Me.bt_fecha_ini_tramites.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_ini_tramites.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_fecha_ini_tramites.Location = New System.Drawing.Point(657, 119)
        Me.bt_fecha_ini_tramites.Name = "bt_fecha_ini_tramites"
        Me.bt_fecha_ini_tramites.Size = New System.Drawing.Size(30, 30)
        Me.bt_fecha_ini_tramites.TabIndex = 290
        Me.bt_fecha_ini_tramites.UseVisualStyleBackColor = True
        '
        'bt_fecha_max_vigencia
        '
        Me.bt_fecha_max_vigencia.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_max_vigencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_fecha_max_vigencia.Location = New System.Drawing.Point(657, 89)
        Me.bt_fecha_max_vigencia.Name = "bt_fecha_max_vigencia"
        Me.bt_fecha_max_vigencia.Size = New System.Drawing.Size(30, 30)
        Me.bt_fecha_max_vigencia.TabIndex = 289
        Me.bt_fecha_max_vigencia.UseVisualStyleBackColor = True
        '
        'tx_fecha_ini_tramites
        '
        Me.tx_fecha_ini_tramites.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_fecha_ini_tramites.Location = New System.Drawing.Point(543, 122)
        Me.tx_fecha_ini_tramites.Name = "tx_fecha_ini_tramites"
        Me.tx_fecha_ini_tramites.ReadOnly = True
        Me.tx_fecha_ini_tramites.Size = New System.Drawing.Size(112, 22)
        Me.tx_fecha_ini_tramites.TabIndex = 288
        '
        'tx_fecha_max_vigencia
        '
        Me.tx_fecha_max_vigencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_fecha_max_vigencia.Location = New System.Drawing.Point(543, 93)
        Me.tx_fecha_max_vigencia.Name = "tx_fecha_max_vigencia"
        Me.tx_fecha_max_vigencia.ReadOnly = True
        Me.tx_fecha_max_vigencia.Size = New System.Drawing.Size(112, 22)
        Me.tx_fecha_max_vigencia.TabIndex = 287
        '
        'fm_0500_version_del_documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 398)
        Me.Controls.Add(Me.bt_fecha_ini_tramites)
        Me.Controls.Add(Me.bt_fecha_max_vigencia)
        Me.Controls.Add(Me.tx_fecha_ini_tramites)
        Me.Controls.Add(Me.tx_fecha_max_vigencia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.bt_fecha_aprob)
        Me.Controls.Add(Me.bt_fecha_rev)
        Me.Controls.Add(Me.cm_aprobadopor)
        Me.Controls.Add(Me.cm_revisadopor)
        Me.Controls.Add(Me.tx_fecha_aprobacion)
        Me.Controls.Add(Me.tx_fecha_revision)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_cambio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_version)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_id_doc_ed)
        Me.Controls.Add(Me.Label37)
        Me.Name = "fm_0500_version_del_documento"
        Me.Text = "Version del Documento"
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.tx_id_doc_ed, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_version, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_cambio, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_fecha_revision, 0)
        Me.Controls.SetChildIndex(Me.tx_fecha_aprobacion, 0)
        Me.Controls.SetChildIndex(Me.cm_revisadopor, 0)
        Me.Controls.SetChildIndex(Me.cm_aprobadopor, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_rev, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_aprob, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_fecha_max_vigencia, 0)
        Me.Controls.SetChildIndex(Me.tx_fecha_ini_tramites, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_max_vigencia, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_ini_tramites, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_id_doc_ed As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents tx_version As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_cambio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_fecha_revision As System.Windows.Forms.TextBox
    Friend WithEvents tx_fecha_aprobacion As System.Windows.Forms.TextBox
    Friend WithEvents cm_aprobadopor As ComboBox
    Friend WithEvents cm_revisadopor As ComboBox
    Friend WithEvents bt_fecha_rev As Button
    Friend WithEvents bt_fecha_aprob As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents bt_fecha_ini_tramites As Button
    Friend WithEvents bt_fecha_max_vigencia As Button
    Friend WithEvents tx_fecha_ini_tramites As TextBox
    Friend WithEvents tx_fecha_max_vigencia As TextBox
End Class
