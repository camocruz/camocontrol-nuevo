<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0008_importar_plano_bancos
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
        Me.bt_importar_plano = New System.Windows.Forms.Button()
        Me.dg_datos_importados = New System.Windows.Forms.DataGridView()
        Me.bt_importar_clipboard = New System.Windows.Forms.Button()
        Me.cm_id_config = New System.Windows.Forms.ComboBox()
        Me.dg_rechazados = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.chk_paso_a_paso = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_datos_importados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_rechazados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(783, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(784, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/09/04"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(693, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(299, 32)
        Me.lb_titulo.Text = "Cargar Consignaciones"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 495)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 459)
        '
        'bt_importar_plano
        '
        Me.bt_importar_plano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_importar_plano.Image = Global.camocontrol.My.Resources.Resources.carpeta
        Me.bt_importar_plano.Location = New System.Drawing.Point(501, 61)
        Me.bt_importar_plano.Name = "bt_importar_plano"
        Me.bt_importar_plano.Size = New System.Drawing.Size(53, 40)
        Me.bt_importar_plano.TabIndex = 63
        Me.bt_importar_plano.UseVisualStyleBackColor = True
        '
        'dg_datos_importados
        '
        Me.dg_datos_importados.AllowUserToAddRows = False
        Me.dg_datos_importados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_datos_importados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_datos_importados.Location = New System.Drawing.Point(13, 125)
        Me.dg_datos_importados.Name = "dg_datos_importados"
        Me.dg_datos_importados.ReadOnly = True
        Me.dg_datos_importados.Size = New System.Drawing.Size(845, 142)
        Me.dg_datos_importados.TabIndex = 64
        '
        'bt_importar_clipboard
        '
        Me.bt_importar_clipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_importar_clipboard.Image = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_importar_clipboard.Location = New System.Drawing.Point(560, 61)
        Me.bt_importar_clipboard.Name = "bt_importar_clipboard"
        Me.bt_importar_clipboard.Size = New System.Drawing.Size(53, 40)
        Me.bt_importar_clipboard.TabIndex = 65
        Me.bt_importar_clipboard.UseVisualStyleBackColor = True
        Me.bt_importar_clipboard.Visible = False
        '
        'cm_id_config
        '
        Me.cm_id_config.FormattingEnabled = True
        Me.cm_id_config.Location = New System.Drawing.Point(136, 69)
        Me.cm_id_config.Name = "cm_id_config"
        Me.cm_id_config.Size = New System.Drawing.Size(359, 21)
        Me.cm_id_config.TabIndex = 66
        '
        'dg_rechazados
        '
        Me.dg_rechazados.AllowUserToAddRows = False
        Me.dg_rechazados.AllowUserToDeleteRows = False
        Me.dg_rechazados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_rechazados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_rechazados.Location = New System.Drawing.Point(12, 302)
        Me.dg_rechazados.Name = "dg_rechazados"
        Me.dg_rechazados.ReadOnly = True
        Me.dg_rechazados.Size = New System.Drawing.Size(845, 139)
        Me.dg_rechazados.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Duplicados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Validos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 16)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Archivo Plano:"
        '
        'bt_grabar
        '
        Me.bt_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_grabar.Image = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar.Location = New System.Drawing.Point(661, 61)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(53, 40)
        Me.bt_grabar.TabIndex = 144
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'chk_paso_a_paso
        '
        Me.chk_paso_a_paso.AutoSize = True
        Me.chk_paso_a_paso.Location = New System.Drawing.Point(769, 102)
        Me.chk_paso_a_paso.Name = "chk_paso_a_paso"
        Me.chk_paso_a_paso.Size = New System.Drawing.Size(89, 17)
        Me.chk_paso_a_paso.TabIndex = 145
        Me.chk_paso_a_paso.Text = "Paso a Paso:"
        Me.chk_paso_a_paso.UseVisualStyleBackColor = True
        '
        'fm_0008_importar_plano_bancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 509)
        Me.Controls.Add(Me.chk_paso_a_paso)
        Me.Controls.Add(Me.bt_grabar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_rechazados)
        Me.Controls.Add(Me.cm_id_config)
        Me.Controls.Add(Me.bt_importar_clipboard)
        Me.Controls.Add(Me.dg_datos_importados)
        Me.Controls.Add(Me.bt_importar_plano)
        Me.Name = "fm_0008_importar_plano_bancos"
        Me.Text = "Cargar Consignaciones"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.bt_importar_plano, 0)
        Me.Controls.SetChildIndex(Me.dg_datos_importados, 0)
        Me.Controls.SetChildIndex(Me.bt_importar_clipboard, 0)
        Me.Controls.SetChildIndex(Me.cm_id_config, 0)
        Me.Controls.SetChildIndex(Me.dg_rechazados, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.bt_grabar, 0)
        Me.Controls.SetChildIndex(Me.chk_paso_a_paso, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_datos_importados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_rechazados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_importar_plano As System.Windows.Forms.Button
    Friend WithEvents dg_datos_importados As System.Windows.Forms.DataGridView
    Friend WithEvents bt_importar_clipboard As System.Windows.Forms.Button
    Friend WithEvents cm_id_config As System.Windows.Forms.ComboBox
    Friend WithEvents dg_rechazados As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bt_grabar As System.Windows.Forms.Button
    Friend WithEvents chk_paso_a_paso As System.Windows.Forms.CheckBox

End Class
