<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_visor_imagen
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.nud_escala_imagen = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_rotar_imagen_derecha = New System.Windows.Forms.Button()
        Me.bt_rotar_imagen_izquierda = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_escala_imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(692, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(693, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/10/05"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(602, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(237, 32)
        Me.lb_titulo.Text = "Visor de Imagenes"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 497)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 461)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Location = New System.Drawing.Point(4, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(683, 394)
        Me.Panel1.TabIndex = 63
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(430, 388)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'nud_escala_imagen
        '
        Me.nud_escala_imagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nud_escala_imagen.Location = New System.Drawing.Point(696, 132)
        Me.nud_escala_imagen.Name = "nud_escala_imagen"
        Me.nud_escala_imagen.Size = New System.Drawing.Size(69, 20)
        Me.nud_escala_imagen.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(696, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Zoom"
        '
        'bt_rotar_imagen_derecha
        '
        Me.bt_rotar_imagen_derecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_rotar_imagen_derecha.Image = Global.camocontrol.My.Resources.Resources.cac_girar_icono_derecha
        Me.bt_rotar_imagen_derecha.Location = New System.Drawing.Point(706, 189)
        Me.bt_rotar_imagen_derecha.Name = "bt_rotar_imagen_derecha"
        Me.bt_rotar_imagen_derecha.Size = New System.Drawing.Size(46, 44)
        Me.bt_rotar_imagen_derecha.TabIndex = 66
        Me.bt_rotar_imagen_derecha.UseVisualStyleBackColor = True
        '
        'bt_rotar_imagen_izquierda
        '
        Me.bt_rotar_imagen_izquierda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_rotar_imagen_izquierda.Image = Global.camocontrol.My.Resources.Resources.cac_girar_icono_izquierda
        Me.bt_rotar_imagen_izquierda.Location = New System.Drawing.Point(706, 239)
        Me.bt_rotar_imagen_izquierda.Name = "bt_rotar_imagen_izquierda"
        Me.bt_rotar_imagen_izquierda.Size = New System.Drawing.Size(46, 44)
        Me.bt_rotar_imagen_izquierda.TabIndex = 67
        Me.bt_rotar_imagen_izquierda.UseVisualStyleBackColor = True
        '
        'fm_visor_imagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(771, 511)
        Me.Controls.Add(Me.bt_rotar_imagen_izquierda)
        Me.Controls.Add(Me.bt_rotar_imagen_derecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nud_escala_imagen)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fm_visor_imagen"
        Me.Text = "Visor de Imagenes"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.nud_escala_imagen, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.bt_rotar_imagen_derecha, 0)
        Me.Controls.SetChildIndex(Me.bt_rotar_imagen_izquierda, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_escala_imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents nud_escala_imagen As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bt_rotar_imagen_derecha As System.Windows.Forms.Button
    Friend WithEvents bt_rotar_imagen_izquierda As System.Windows.Forms.Button

End Class
