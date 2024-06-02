<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FM_PLANTILLA
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lb_titulo = New System.Windows.Forms.Label()
        Me.ll_linea1 = New System.Windows.Forms.LinkLabel()
        Me.lb_mi_marca = New System.Windows.Forms.Label()
        Me.lb_fecha = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bt_g_archivos = New System.Windows.Forms.Button()
        Me.bt_g_notas = New System.Windows.Forms.Button()
        Me.bt_generar_informe = New System.Windows.Forms.Button()
        Me.bt_editar = New System.Windows.Forms.Button()
        Me.bt_nuevo = New System.Windows.Forms.Button()
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.bt_salir = New System.Windows.Forms.Button()
        Me.bt_anular = New System.Windows.Forms.Button()
        Me.fm_plantilla_ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lb_diseñador_programa = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_titulo
        '
        Me.lb_titulo.AutoSize = True
        Me.lb_titulo.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_titulo.ForeColor = System.Drawing.Color.Red
        Me.lb_titulo.Location = New System.Drawing.Point(90, 9)
        Me.lb_titulo.Name = "lb_titulo"
        Me.lb_titulo.Size = New System.Drawing.Size(234, 32)
        Me.lb_titulo.TabIndex = 0
        Me.lb_titulo.Text = "Titulo de la forma"
        '
        'll_linea1
        '
        Me.ll_linea1.ActiveLinkColor = System.Drawing.Color.Black
        Me.ll_linea1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ll_linea1.BackColor = System.Drawing.Color.Black
        Me.ll_linea1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ll_linea1.LinkColor = System.Drawing.Color.Black
        Me.ll_linea1.Location = New System.Drawing.Point(93, 52)
        Me.ll_linea1.Name = "ll_linea1"
        Me.ll_linea1.Size = New System.Drawing.Size(560, 6)
        Me.ll_linea1.TabIndex = 4
        Me.ll_linea1.TabStop = True
        Me.ll_linea1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_mi_marca.AutoSize = True
        Me.lb_mi_marca.BackColor = System.Drawing.Color.AliceBlue
        Me.lb_mi_marca.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_mi_marca.ForeColor = System.Drawing.Color.Red
        Me.lb_mi_marca.Location = New System.Drawing.Point(658, 9)
        Me.lb_mi_marca.Name = "lb_mi_marca"
        Me.lb_mi_marca.Size = New System.Drawing.Size(75, 24)
        Me.lb_mi_marca.TabIndex = 55
        Me.lb_mi_marca.Text = "CAMO"
        '
        'lb_fecha
        '
        Me.lb_fecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_fecha.AutoSize = True
        Me.lb_fecha.BackColor = System.Drawing.Color.Thistle
        Me.lb_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha.ForeColor = System.Drawing.Color.Red
        Me.lb_fecha.Location = New System.Drawing.Point(659, 36)
        Me.lb_fecha.Name = "lb_fecha"
        Me.lb_fecha.Size = New System.Drawing.Size(41, 16)
        Me.lb_fecha.TabIndex = 54
        Me.lb_fecha.Text = "fecha"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.bt_g_archivos)
        Me.GroupBox1.Controls.Add(Me.bt_g_notas)
        Me.GroupBox1.Controls.Add(Me.bt_generar_informe)
        Me.GroupBox1.Controls.Add(Me.bt_editar)
        Me.GroupBox1.Controls.Add(Me.bt_nuevo)
        Me.GroupBox1.Controls.Add(Me.bt_grabar)
        Me.GroupBox1.Controls.Add(Me.bt_salir)
        Me.GroupBox1.Controls.Add(Me.bt_anular)
        Me.GroupBox1.Location = New System.Drawing.Point(210, 410)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 66)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'bt_g_archivos
        '
        Me.bt_g_archivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_g_archivos.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_g_archivos.ForeColor = System.Drawing.Color.Black
        Me.bt_g_archivos.Image = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_g_archivos.Location = New System.Drawing.Point(391, 11)
        Me.bt_g_archivos.Name = "bt_g_archivos"
        Me.bt_g_archivos.Size = New System.Drawing.Size(49, 51)
        Me.bt_g_archivos.TabIndex = 65
        Me.bt_g_archivos.Text = "0"
        Me.bt_g_archivos.UseVisualStyleBackColor = True
        '
        'bt_g_notas
        '
        Me.bt_g_notas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_g_notas.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_g_notas.ForeColor = System.Drawing.Color.Black
        Me.bt_g_notas.Image = Global.camocontrol.My.Resources.Resources.libreria
        Me.bt_g_notas.Location = New System.Drawing.Point(336, 11)
        Me.bt_g_notas.Name = "bt_g_notas"
        Me.bt_g_notas.Size = New System.Drawing.Size(49, 51)
        Me.bt_g_notas.TabIndex = 64
        Me.bt_g_notas.Text = "0"
        Me.bt_g_notas.UseVisualStyleBackColor = True
        '
        'bt_generar_informe
        '
        Me.bt_generar_informe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_generar_informe.Image = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_generar_informe.Location = New System.Drawing.Point(281, 10)
        Me.bt_generar_informe.Name = "bt_generar_informe"
        Me.bt_generar_informe.Size = New System.Drawing.Size(49, 51)
        Me.bt_generar_informe.TabIndex = 63
        Me.bt_generar_informe.UseVisualStyleBackColor = True
        '
        'bt_editar
        '
        Me.bt_editar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_editar.Image = Global.camocontrol.My.Resources.Resources.design
        Me.bt_editar.Location = New System.Drawing.Point(9, 10)
        Me.bt_editar.Name = "bt_editar"
        Me.bt_editar.Size = New System.Drawing.Size(49, 51)
        Me.bt_editar.TabIndex = 62
        Me.bt_editar.UseVisualStyleBackColor = True
        '
        'bt_nuevo
        '
        Me.bt_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_nuevo.Image = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_nuevo.Location = New System.Drawing.Point(61, 11)
        Me.bt_nuevo.Name = "bt_nuevo"
        Me.bt_nuevo.Size = New System.Drawing.Size(49, 51)
        Me.bt_nuevo.TabIndex = 61
        Me.bt_nuevo.UseVisualStyleBackColor = True
        '
        'bt_grabar
        '
        Me.bt_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_grabar.Image = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar.Location = New System.Drawing.Point(116, 11)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(49, 51)
        Me.bt_grabar.TabIndex = 58
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'bt_salir
        '
        Me.bt_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_salir.Image = Global.camocontrol.My.Resources.Resources.salida2
        Me.bt_salir.Location = New System.Drawing.Point(226, 11)
        Me.bt_salir.Name = "bt_salir"
        Me.bt_salir.Size = New System.Drawing.Size(49, 51)
        Me.bt_salir.TabIndex = 57
        Me.bt_salir.UseVisualStyleBackColor = True
        '
        'bt_anular
        '
        Me.bt_anular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_anular.Image = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_anular.Location = New System.Drawing.Point(171, 11)
        Me.bt_anular.Name = "bt_anular"
        Me.bt_anular.Size = New System.Drawing.Size(49, 51)
        Me.bt_anular.TabIndex = 59
        Me.bt_anular.UseVisualStyleBackColor = True
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.AutoSize = True
        Me.lb_diseñador_programa.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lb_diseñador_programa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_diseñador_programa.ForeColor = System.Drawing.Color.Black
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 474)
        Me.lb_diseñador_programa.Name = "lb_diseñador_programa"
        Me.lb_diseñador_programa.Size = New System.Drawing.Size(189, 14)
        Me.lb_diseñador_programa.TabIndex = 61
        Me.lb_diseñador_programa.Text = "Diseño: Ing. Carlos Andres Mosquera."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.camocontrol.My.Resources.Resources.macdulces2
        Me.PictureBox1.Location = New System.Drawing.Point(12, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 56
        Me.PictureBox1.TabStop = False
        '
        'FM_PLANTILLA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.ClientSize = New System.Drawing.Size(745, 488)
        Me.Controls.Add(Me.lb_diseñador_programa)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lb_mi_marca)
        Me.Controls.Add(Me.lb_fecha)
        Me.Controls.Add(Me.ll_linea1)
        Me.Controls.Add(Me.lb_titulo)
        Me.Name = "FM_PLANTILLA"
        Me.Text = "plantilla"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents ll_linea1 As System.Windows.Forms.LinkLabel
    Protected Friend WithEvents lb_mi_marca As System.Windows.Forms.Label
    Protected Friend WithEvents lb_fecha As System.Windows.Forms.Label
    Friend WithEvents fm_plantilla_ToolTip1 As System.Windows.Forms.ToolTip
    Protected Friend WithEvents lb_titulo As System.Windows.Forms.Label
    Protected Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Protected Friend WithEvents bt_salir As System.Windows.Forms.Button
    Protected Friend WithEvents bt_grabar As System.Windows.Forms.Button
    Protected Friend WithEvents bt_anular As System.Windows.Forms.Button
    Protected Friend WithEvents bt_nuevo As System.Windows.Forms.Button
    Protected Friend WithEvents lb_diseñador_programa As System.Windows.Forms.Label
    Protected Friend WithEvents bt_editar As System.Windows.Forms.Button
    Protected Friend WithEvents bt_generar_informe As System.Windows.Forms.Button
    Protected Friend WithEvents bt_g_notas As System.Windows.Forms.Button
    Protected Friend WithEvents bt_g_archivos As System.Windows.Forms.Button

End Class
