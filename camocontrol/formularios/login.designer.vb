<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.tx_clave = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cm_empleados = New System.Windows.Forms.ComboBox()
        Me.bt_cancelar = New System.Windows.Forms.Button()
        Me.tx_usuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_compania = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tx_clave
        '
        Me.tx_clave.Location = New System.Drawing.Point(190, 100)
        Me.tx_clave.MaxLength = 20
        Me.tx_clave.Name = "tx_clave"
        Me.tx_clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tx_clave.Size = New System.Drawing.Size(144, 20)
        Me.tx_clave.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(161, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 30)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(130, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(130, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Clave"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(27, 50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(88, 117)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'cm_empleados
        '
        Me.cm_empleados.FormattingEnabled = True
        Me.cm_empleados.Location = New System.Drawing.Point(205, 181)
        Me.cm_empleados.Name = "cm_empleados"
        Me.cm_empleados.Size = New System.Drawing.Size(144, 21)
        Me.cm_empleados.TabIndex = 0
        Me.cm_empleados.Visible = False
        '
        'bt_cancelar
        '
        Me.bt_cancelar.Location = New System.Drawing.Point(244, 138)
        Me.bt_cancelar.Name = "bt_cancelar"
        Me.bt_cancelar.Size = New System.Drawing.Size(76, 29)
        Me.bt_cancelar.TabIndex = 5
        Me.bt_cancelar.Text = "Cancelar"
        Me.bt_cancelar.UseVisualStyleBackColor = True
        '
        'tx_usuario
        '
        Me.tx_usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_usuario.Location = New System.Drawing.Point(190, 75)
        Me.tx_usuario.Name = "tx_usuario"
        Me.tx_usuario.Size = New System.Drawing.Size(144, 20)
        Me.tx_usuario.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Diseño: Ing. Carlos Andres Mosquera."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(263, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 28)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "CAMO"
        '
        'tx_compania
        '
        Me.tx_compania.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_compania.Location = New System.Drawing.Point(190, 49)
        Me.tx_compania.Name = "tx_compania"
        Me.tx_compania.Size = New System.Drawing.Size(144, 20)
        Me.tx_compania.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(130, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Compañia"
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 214)
        Me.Controls.Add(Me.tx_compania)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_usuario)
        Me.Controls.Add(Me.bt_cancelar)
        Me.Controls.Add(Me.cm_empleados)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tx_clave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.Text = "CAMO SECURITY"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_clave As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cm_empleados As System.Windows.Forms.ComboBox
    Friend WithEvents bt_cancelar As System.Windows.Forms.Button
    Friend WithEvents tx_usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_compania As TextBox
    Friend WithEvents Label5 As Label
End Class
