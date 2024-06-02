<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0021_usuarios
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rb_inactivo = New System.Windows.Forms.RadioButton()
        Me.rb_activo = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_id_tercero = New System.Windows.Forms.TextBox()
        Me.tx_usuario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_codigo = New System.Windows.Forms.TextBox()
        Me.lb_identificacion = New System.Windows.Forms.Label()
        Me.tx_identificacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_codigo_v = New System.Windows.Forms.TextBox()
        Me.tx_nombre_tercero = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_fecha_caducidad = New System.Windows.Forms.DateTimePicker()
        Me.chk_usuario_no_caduca = New System.Windows.Forms.CheckBox()
        Me.chk_clave_periodica = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(405, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(503, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(504, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/01/05"
        '
        'lb_titulo
        '
        Me.lb_titulo.Location = New System.Drawing.Point(163, 9)
        Me.lb_titulo.Size = New System.Drawing.Size(259, 32)
        Me.lb_titulo.Text = "Gestion de Usuarios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(174, 409)
        '
        'bt_grabar
        '
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(137, 365)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 16)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Estado :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rb_inactivo)
        Me.GroupBox2.Controls.Add(Me.rb_activo)
        Me.GroupBox2.Location = New System.Drawing.Point(201, 347)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(144, 49)
        Me.GroupBox2.TabIndex = 106
        Me.GroupBox2.TabStop = False
        '
        'rb_inactivo
        '
        Me.rb_inactivo.AutoSize = True
        Me.rb_inactivo.Location = New System.Drawing.Point(79, 19)
        Me.rb_inactivo.Name = "rb_inactivo"
        Me.rb_inactivo.Size = New System.Drawing.Size(63, 17)
        Me.rb_inactivo.TabIndex = 1
        Me.rb_inactivo.TabStop = True
        Me.rb_inactivo.Text = "Inactivo"
        Me.rb_inactivo.UseVisualStyleBackColor = True
        '
        'rb_activo
        '
        Me.rb_activo.AutoSize = True
        Me.rb_activo.Location = New System.Drawing.Point(6, 18)
        Me.rb_activo.Name = "rb_activo"
        Me.rb_activo.Size = New System.Drawing.Size(55, 17)
        Me.rb_activo.TabIndex = 0
        Me.rb_activo.TabStop = True
        Me.rb_activo.Text = "Activo"
        Me.rb_activo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(172, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 16)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "Id:"
        '
        'tx_id_tercero
        '
        Me.tx_id_tercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_tercero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_tercero.Location = New System.Drawing.Point(200, 69)
        Me.tx_id_tercero.MaxLength = 20
        Me.tx_id_tercero.Name = "tx_id_tercero"
        Me.tx_id_tercero.ReadOnly = True
        Me.tx_id_tercero.Size = New System.Drawing.Size(263, 22)
        Me.tx_id_tercero.TabIndex = 104
        '
        'tx_usuario
        '
        Me.tx_usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_usuario.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_usuario.Location = New System.Drawing.Point(200, 184)
        Me.tx_usuario.MaxLength = 100
        Me.tx_usuario.Name = "tx_usuario"
        Me.tx_usuario.Size = New System.Drawing.Size(263, 22)
        Me.tx_usuario.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(134, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Usuario :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(146, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 16)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Clave :"
        '
        'tx_codigo
        '
        Me.tx_codigo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_codigo.Location = New System.Drawing.Point(200, 212)
        Me.tx_codigo.MaxLength = 20
        Me.tx_codigo.Name = "tx_codigo"
        Me.tx_codigo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(120)
        Me.tx_codigo.Size = New System.Drawing.Size(263, 22)
        Me.tx_codigo.TabIndex = 99
        Me.tx_codigo.UseSystemPasswordChar = True
        '
        'lb_identificacion
        '
        Me.lb_identificacion.AutoSize = True
        Me.lb_identificacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_identificacion.Location = New System.Drawing.Point(72, 101)
        Me.lb_identificacion.Name = "lb_identificacion"
        Me.lb_identificacion.Size = New System.Drawing.Size(122, 16)
        Me.lb_identificacion.TabIndex = 101
        Me.lb_identificacion.Text = "Identificación / NIT :"
        '
        'tx_identificacion
        '
        Me.tx_identificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_identificacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_identificacion.Location = New System.Drawing.Point(200, 97)
        Me.tx_identificacion.MaxLength = 20
        Me.tx_identificacion.Name = "tx_identificacion"
        Me.tx_identificacion.Size = New System.Drawing.Size(263, 22)
        Me.tx_identificacion.TabIndex = 98
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(77, 315)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 16)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Fecha Caducidad :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(146, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "Clave :"
        '
        'tx_codigo_v
        '
        Me.tx_codigo_v.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_codigo_v.Location = New System.Drawing.Point(200, 240)
        Me.tx_codigo_v.MaxLength = 20
        Me.tx_codigo_v.Name = "tx_codigo_v"
        Me.tx_codigo_v.PasswordChar = Global.Microsoft.VisualBasic.ChrW(120)
        Me.tx_codigo_v.Size = New System.Drawing.Size(263, 22)
        Me.tx_codigo_v.TabIndex = 112
        Me.tx_codigo_v.UseSystemPasswordChar = True
        '
        'tx_nombre_tercero
        '
        Me.tx_nombre_tercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_nombre_tercero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nombre_tercero.Location = New System.Drawing.Point(200, 125)
        Me.tx_nombre_tercero.MaxLength = 100
        Me.tx_nombre_tercero.Multiline = True
        Me.tx_nombre_tercero.Name = "tx_nombre_tercero"
        Me.tx_nombre_tercero.ReadOnly = True
        Me.tx_nombre_tercero.Size = New System.Drawing.Size(263, 53)
        Me.tx_nombre_tercero.TabIndex = 115
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(137, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 16)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Nombre:"
        '
        'dtp_fecha_caducidad
        '
        Me.dtp_fecha_caducidad.Location = New System.Drawing.Point(200, 313)
        Me.dtp_fecha_caducidad.Name = "dtp_fecha_caducidad"
        Me.dtp_fecha_caducidad.Size = New System.Drawing.Size(263, 20)
        Me.dtp_fecha_caducidad.TabIndex = 117
        '
        'chk_usuario_no_caduca
        '
        Me.chk_usuario_no_caduca.AutoSize = True
        Me.chk_usuario_no_caduca.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_usuario_no_caduca.Location = New System.Drawing.Point(200, 293)
        Me.chk_usuario_no_caduca.Name = "chk_usuario_no_caduca"
        Me.chk_usuario_no_caduca.Size = New System.Drawing.Size(160, 20)
        Me.chk_usuario_no_caduca.TabIndex = 118
        Me.chk_usuario_no_caduca.Text = "Usuario Nunca Caduca"
        Me.chk_usuario_no_caduca.UseVisualStyleBackColor = True
        '
        'chk_clave_periodica
        '
        Me.chk_clave_periodica.AutoSize = True
        Me.chk_clave_periodica.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_clave_periodica.Location = New System.Drawing.Point(200, 268)
        Me.chk_clave_periodica.Name = "chk_clave_periodica"
        Me.chk_clave_periodica.Size = New System.Drawing.Size(263, 20)
        Me.chk_clave_periodica.TabIndex = 119
        Me.chk_clave_periodica.Text = "Obligar Cambio de Clave Periodicamente"
        Me.chk_clave_periodica.UseVisualStyleBackColor = True
        '
        'fm_0021_usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(590, 483)
        Me.Controls.Add(Me.chk_clave_periodica)
        Me.Controls.Add(Me.chk_usuario_no_caduca)
        Me.Controls.Add(Me.dtp_fecha_caducidad)
        Me.Controls.Add(Me.tx_nombre_tercero)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_codigo_v)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_id_tercero)
        Me.Controls.Add(Me.tx_usuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_codigo)
        Me.Controls.Add(Me.lb_identificacion)
        Me.Controls.Add(Me.tx_identificacion)
        Me.Name = "fm_0021_usuarios"
        Me.Text = "Gestion de Usuarios"
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.tx_identificacion, 0)
        Me.Controls.SetChildIndex(Me.lb_identificacion, 0)
        Me.Controls.SetChildIndex(Me.tx_codigo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_usuario, 0)
        Me.Controls.SetChildIndex(Me.tx_id_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_codigo_v, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_nombre_tercero, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_caducidad, 0)
        Me.Controls.SetChildIndex(Me.chk_usuario_no_caduca, 0)
        Me.Controls.SetChildIndex(Me.chk_clave_periodica, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_id_tercero As System.Windows.Forms.TextBox
    Friend WithEvents tx_usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tx_codigo As System.Windows.Forms.TextBox
    Friend WithEvents lb_identificacion As System.Windows.Forms.Label
    Friend WithEvents tx_identificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_codigo_v As System.Windows.Forms.TextBox
    Friend WithEvents tx_nombre_tercero As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rb_inactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rb_activo As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_fecha_caducidad As System.Windows.Forms.DateTimePicker
    Friend WithEvents chk_usuario_no_caduca As System.Windows.Forms.CheckBox
    Friend WithEvents chk_clave_periodica As System.Windows.Forms.CheckBox

End Class
