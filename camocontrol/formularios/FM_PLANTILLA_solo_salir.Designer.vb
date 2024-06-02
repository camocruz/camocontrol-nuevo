<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FM_PLANTILLA_solo_salir
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lb_mi_marca = New System.Windows.Forms.Label()
        Me.lb_fecha = New System.Windows.Forms.Label()
        Me.ll_linea1 = New System.Windows.Forms.LinkLabel()
        Me.lb_titulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lb_diseñador_programa = New System.Windows.Forms.Label()
        Me.bt_salir = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_mi_marca.AutoSize = True
        Me.lb_mi_marca.BackColor = System.Drawing.Color.AliceBlue
        Me.lb_mi_marca.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_mi_marca.ForeColor = System.Drawing.Color.Red
        Me.lb_mi_marca.Location = New System.Drawing.Point(663, 9)
        Me.lb_mi_marca.Name = "lb_mi_marca"
        Me.lb_mi_marca.Size = New System.Drawing.Size(75, 24)
        Me.lb_mi_marca.TabIndex = 60
        Me.lb_mi_marca.Text = "CAMO"
        '
        'lb_fecha
        '
        Me.lb_fecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_fecha.AutoSize = True
        Me.lb_fecha.BackColor = System.Drawing.Color.Thistle
        Me.lb_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha.ForeColor = System.Drawing.Color.Red
        Me.lb_fecha.Location = New System.Drawing.Point(664, 36)
        Me.lb_fecha.Name = "lb_fecha"
        Me.lb_fecha.Size = New System.Drawing.Size(41, 16)
        Me.lb_fecha.TabIndex = 59
        Me.lb_fecha.Text = "fecha"
        '
        'll_linea1
        '
        Me.ll_linea1.ActiveLinkColor = System.Drawing.Color.Black
        Me.ll_linea1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ll_linea1.BackColor = System.Drawing.Color.Black
        Me.ll_linea1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ll_linea1.LinkColor = System.Drawing.Color.Black
        Me.ll_linea1.Location = New System.Drawing.Point(85, 52)
        Me.ll_linea1.Name = "ll_linea1"
        Me.ll_linea1.Size = New System.Drawing.Size(573, 6)
        Me.ll_linea1.TabIndex = 58
        Me.ll_linea1.TabStop = True
        Me.ll_linea1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lb_titulo
        '
        Me.lb_titulo.AutoSize = True
        Me.lb_titulo.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_titulo.ForeColor = System.Drawing.Color.Red
        Me.lb_titulo.Location = New System.Drawing.Point(82, 9)
        Me.lb_titulo.Name = "lb_titulo"
        Me.lb_titulo.Size = New System.Drawing.Size(234, 32)
        Me.lb_titulo.TabIndex = 57
        Me.lb_titulo.Text = "Titulo de la forma"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.camocontrol.My.Resources.Resources.macdulces2
        Me.PictureBox1.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 61
        Me.PictureBox1.TabStop = False
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.AutoSize = True
        Me.lb_diseñador_programa.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lb_diseñador_programa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_diseñador_programa.ForeColor = System.Drawing.Color.Black
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 444)
        Me.lb_diseñador_programa.Name = "lb_diseñador_programa"
        Me.lb_diseñador_programa.Size = New System.Drawing.Size(189, 14)
        Me.lb_diseñador_programa.TabIndex = 62
        Me.lb_diseñador_programa.Text = "Diseño: Ing. Carlos Andres Mosquera."
        '
        'bt_salir
        '
        Me.bt_salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_salir.BackgroundImage = Global.camocontrol.My.Resources.Resources.salida2
        Me.bt_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_salir.Location = New System.Drawing.Point(331, 408)
        Me.bt_salir.Name = "bt_salir"
        Me.bt_salir.Size = New System.Drawing.Size(49, 38)
        Me.bt_salir.TabIndex = 57
        Me.bt_salir.UseVisualStyleBackColor = True
        '
        'FM_PLANTILLA_solo_salir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.ClientSize = New System.Drawing.Size(742, 458)
        Me.Controls.Add(Me.bt_salir)
        Me.Controls.Add(Me.lb_diseñador_programa)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lb_mi_marca)
        Me.Controls.Add(Me.lb_fecha)
        Me.Controls.Add(Me.ll_linea1)
        Me.Controls.Add(Me.lb_titulo)
        Me.Name = "FM_PLANTILLA_solo_salir"
        Me.Text = "FM_PLANTILLA_SIN_CONTROLES"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Protected Friend WithEvents lb_mi_marca As System.Windows.Forms.Label
    Protected Friend WithEvents lb_fecha As System.Windows.Forms.Label
    Protected Friend WithEvents ll_linea1 As System.Windows.Forms.LinkLabel
    Protected Friend WithEvents lb_titulo As System.Windows.Forms.Label
    Protected Friend WithEvents lb_diseñador_programa As System.Windows.Forms.Label
    Protected Friend WithEvents bt_salir As System.Windows.Forms.Button
End Class
