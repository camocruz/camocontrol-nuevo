<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0500_gestion_documentos
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
        Me.tx_id_documento = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cm_tipo_documento = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cm_codigo_documento = New System.Windows.Forms.ComboBox()
        Me.cm_nombre_documento = New System.Windows.Forms.ComboBox()
        Me.dg_ediciones = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_nuevo_documento = New System.Windows.Forms.Button()
        Me.bt_editar_documento = New System.Windows.Forms.Button()
        Me.bt_nueva_version = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bt_referenciado = New System.Windows.Forms.Button()
        Me.bt_acceso = New System.Windows.Forms.Button()
        Me.bt_informe_control = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_ediciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(686, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(784, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(785, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/02/22"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(304, 32)
        Me.lb_titulo.Text = "Gestion de Documentos"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        '
        'tx_id_documento
        '
        Me.tx_id_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_documento.Location = New System.Drawing.Point(121, 20)
        Me.tx_id_documento.Name = "tx_id_documento"
        Me.tx_id_documento.ReadOnly = True
        Me.tx_id_documento.Size = New System.Drawing.Size(119, 22)
        Me.tx_id_documento.TabIndex = 242
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 73)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(39, 16)
        Me.Label31.TabIndex = 239
        Me.Label31.Text = "Tipo:"
        '
        'cm_tipo_documento
        '
        Me.cm_tipo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_tipo_documento.FormattingEnabled = True
        Me.cm_tipo_documento.Location = New System.Drawing.Point(122, 65)
        Me.cm_tipo_documento.Name = "cm_tipo_documento"
        Me.cm_tipo_documento.Size = New System.Drawing.Size(377, 24)
        Me.cm_tipo_documento.TabIndex = 240
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(11, 26)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 16)
        Me.Label37.TabIndex = 241
        Me.Label37.Text = "id_documento:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 243
        Me.Label1.Text = "Documento:"
        '
        'cm_codigo_documento
        '
        Me.cm_codigo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_codigo_documento.FormattingEnabled = True
        Me.cm_codigo_documento.Location = New System.Drawing.Point(121, 48)
        Me.cm_codigo_documento.Name = "cm_codigo_documento"
        Me.cm_codigo_documento.Size = New System.Drawing.Size(119, 24)
        Me.cm_codigo_documento.TabIndex = 244
        '
        'cm_nombre_documento
        '
        Me.cm_nombre_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_nombre_documento.FormattingEnabled = True
        Me.cm_nombre_documento.Location = New System.Drawing.Point(246, 48)
        Me.cm_nombre_documento.Name = "cm_nombre_documento"
        Me.cm_nombre_documento.Size = New System.Drawing.Size(415, 24)
        Me.cm_nombre_documento.TabIndex = 246
        '
        'dg_ediciones
        '
        Me.dg_ediciones.AllowUserToAddRows = False
        Me.dg_ediciones.AllowUserToDeleteRows = False
        Me.dg_ediciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_ediciones.Location = New System.Drawing.Point(15, 262)
        Me.dg_ediciones.Name = "dg_ediciones"
        Me.dg_ediciones.ReadOnly = True
        Me.dg_ediciones.Size = New System.Drawing.Size(842, 142)
        Me.dg_ediciones.TabIndex = 247
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 242)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 248
        Me.Label2.Text = "Ediciones:"
        '
        'bt_nuevo_documento
        '
        Me.bt_nuevo_documento.Image = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_nuevo_documento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_nuevo_documento.Location = New System.Drawing.Point(667, 18)
        Me.bt_nuevo_documento.Name = "bt_nuevo_documento"
        Me.bt_nuevo_documento.Size = New System.Drawing.Size(52, 57)
        Me.bt_nuevo_documento.TabIndex = 249
        Me.bt_nuevo_documento.Text = "Nuevo"
        Me.bt_nuevo_documento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_nuevo_documento.UseVisualStyleBackColor = True
        '
        'bt_editar_documento
        '
        Me.bt_editar_documento.Image = Global.camocontrol.My.Resources.Resources.design
        Me.bt_editar_documento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_editar_documento.Location = New System.Drawing.Point(15, 182)
        Me.bt_editar_documento.Name = "bt_editar_documento"
        Me.bt_editar_documento.Size = New System.Drawing.Size(52, 57)
        Me.bt_editar_documento.TabIndex = 250
        Me.bt_editar_documento.Text = "Editar"
        Me.bt_editar_documento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_editar_documento.UseVisualStyleBackColor = True
        '
        'bt_nueva_version
        '
        Me.bt_nueva_version.Image = Global.camocontrol.My.Resources.Resources.icono_checklist
        Me.bt_nueva_version.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_nueva_version.Location = New System.Drawing.Point(70, 182)
        Me.bt_nueva_version.Name = "bt_nueva_version"
        Me.bt_nueva_version.Size = New System.Drawing.Size(52, 57)
        Me.bt_nueva_version.TabIndex = 251
        Me.bt_nueva_version.Text = "Nueva ED"
        Me.bt_nueva_version.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_nueva_version.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_nuevo_documento)
        Me.GroupBox2.Controls.Add(Me.cm_nombre_documento)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cm_codigo_documento)
        Me.GroupBox2.Controls.Add(Me.tx_id_documento)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(842, 85)
        Me.GroupBox2.TabIndex = 252
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccion del Documento"
        '
        'bt_referenciado
        '
        Me.bt_referenciado.Image = Global.camocontrol.My.Resources.Resources.cargaremi
        Me.bt_referenciado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_referenciado.Location = New System.Drawing.Point(125, 182)
        Me.bt_referenciado.Name = "bt_referenciado"
        Me.bt_referenciado.Size = New System.Drawing.Size(52, 57)
        Me.bt_referenciado.TabIndex = 258
        Me.bt_referenciado.Text = "Relac"
        Me.bt_referenciado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_referenciado.UseVisualStyleBackColor = True
        '
        'bt_acceso
        '
        Me.bt_acceso.Image = Global.camocontrol.My.Resources.Resources.terceros
        Me.bt_acceso.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_acceso.Location = New System.Drawing.Point(180, 182)
        Me.bt_acceso.Name = "bt_acceso"
        Me.bt_acceso.Size = New System.Drawing.Size(52, 57)
        Me.bt_acceso.TabIndex = 259
        Me.bt_acceso.Text = "Acceso"
        Me.bt_acceso.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_acceso.UseVisualStyleBackColor = True
        '
        'bt_informe_control
        '
        Me.bt_informe_control.Image = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_informe_control.Location = New System.Drawing.Point(270, 182)
        Me.bt_informe_control.Name = "bt_informe_control"
        Me.bt_informe_control.Size = New System.Drawing.Size(52, 57)
        Me.bt_informe_control.TabIndex = 260
        Me.bt_informe_control.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_informe_control.UseVisualStyleBackColor = True
        '
        'fm_0500_gestion_documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(871, 483)
        Me.Controls.Add(Me.bt_informe_control)
        Me.Controls.Add(Me.bt_acceso)
        Me.Controls.Add(Me.bt_editar_documento)
        Me.Controls.Add(Me.bt_referenciado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.bt_nueva_version)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dg_ediciones)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.cm_tipo_documento)
        Me.Name = "fm_0500_gestion_documentos"
        Me.Text = "Gestion de Documentos"
        Me.Controls.SetChildIndex(Me.cm_tipo_documento, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.dg_ediciones, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.bt_nueva_version, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.bt_referenciado, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_editar_documento, 0)
        Me.Controls.SetChildIndex(Me.bt_acceso, 0)
        Me.Controls.SetChildIndex(Me.bt_informe_control, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_ediciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_id_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cm_tipo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cm_codigo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents cm_nombre_documento As System.Windows.Forms.ComboBox
    Friend WithEvents dg_ediciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_nuevo_documento As System.Windows.Forms.Button
    Friend WithEvents bt_editar_documento As System.Windows.Forms.Button
    Friend WithEvents bt_nueva_version As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_referenciado As Button
    Friend WithEvents bt_acceso As Button
    Friend WithEvents bt_informe_control As Button
End Class
