<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_0100_trasladar_ramal
    Inherits camocontrol.FM_PLANTILLA_solo_salir

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
        Me.lb_padre = New System.Windows.Forms.Label()
        Me.bt_cerrar = New System.Windows.Forms.Button()
        Me.lb_hijo = New System.Windows.Forms.Label()
        Me.rb_hijo = New System.Windows.Forms.RadioButton()
        Me.rb_padre = New System.Windows.Forms.RadioButton()
        Me.chk_raiz = New System.Windows.Forms.CheckBox()
        Me.bt_trasladar = New System.Windows.Forms.Button()
        Me.txt_id_padre = New System.Windows.Forms.TextBox()
        Me.txt_id_hijo = New System.Windows.Forms.TextBox()
        Me.cm_responsable = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(534, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(535, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/02/06"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(444, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Location = New System.Drawing.Point(93, 9)
        Me.lb_titulo.Size = New System.Drawing.Size(359, 32)
        Me.lb_titulo.Text = "Trasladar Ramal Estructura"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 222)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(472, 198)
        Me.bt_salir.Visible = False
        '
        'lb_padre
        '
        Me.lb_padre.AutoSize = True
        Me.lb_padre.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_padre.Location = New System.Drawing.Point(95, 127)
        Me.lb_padre.Name = "lb_padre"
        Me.lb_padre.Size = New System.Drawing.Size(27, 20)
        Me.lb_padre.TabIndex = 63
        Me.lb_padre.Text = "ND"
        '
        'bt_cerrar
        '
        Me.bt_cerrar.AccessibleDescription = "e.Node.Text.Trim"
        Me.bt_cerrar.BackgroundImage = Global.camocontrol.My.Resources.Resources.salida2
        Me.bt_cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cerrar.Location = New System.Drawing.Point(221, 175)
        Me.bt_cerrar.Name = "bt_cerrar"
        Me.bt_cerrar.Size = New System.Drawing.Size(42, 38)
        Me.bt_cerrar.TabIndex = 64
        Me.bt_cerrar.UseVisualStyleBackColor = True
        '
        'lb_hijo
        '
        Me.lb_hijo.AutoSize = True
        Me.lb_hijo.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_hijo.Location = New System.Drawing.Point(99, 154)
        Me.lb_hijo.Name = "lb_hijo"
        Me.lb_hijo.Size = New System.Drawing.Size(27, 20)
        Me.lb_hijo.TabIndex = 65
        Me.lb_hijo.Text = "ND"
        '
        'rb_hijo
        '
        Me.rb_hijo.AutoSize = True
        Me.rb_hijo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_hijo.Location = New System.Drawing.Point(30, 154)
        Me.rb_hijo.Name = "rb_hijo"
        Me.rb_hijo.Size = New System.Drawing.Size(63, 23)
        Me.rb_hijo.TabIndex = 67
        Me.rb_hijo.TabStop = True
        Me.rb_hijo.Text = "Hijo:"
        Me.rb_hijo.UseVisualStyleBackColor = True
        '
        'rb_padre
        '
        Me.rb_padre.AutoSize = True
        Me.rb_padre.Checked = True
        Me.rb_padre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_padre.Location = New System.Drawing.Point(11, 127)
        Me.rb_padre.Name = "rb_padre"
        Me.rb_padre.Size = New System.Drawing.Size(78, 23)
        Me.rb_padre.TabIndex = 68
        Me.rb_padre.TabStop = True
        Me.rb_padre.Text = "Padre:"
        Me.rb_padre.UseVisualStyleBackColor = True
        '
        'chk_raiz
        '
        Me.chk_raiz.AutoSize = True
        Me.chk_raiz.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_raiz.Location = New System.Drawing.Point(10, 71)
        Me.chk_raiz.Name = "chk_raiz"
        Me.chk_raiz.Size = New System.Drawing.Size(172, 28)
        Me.chk_raiz.TabIndex = 69
        Me.chk_raiz.Text = "Convertir en Raiz"
        Me.chk_raiz.UseVisualStyleBackColor = True
        '
        'bt_trasladar
        '
        Me.bt_trasladar.AccessibleDescription = "e.Node.Text.Trim"
        Me.bt_trasladar.BackgroundImage = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_trasladar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_trasladar.Location = New System.Drawing.Point(279, 175)
        Me.bt_trasladar.Name = "bt_trasladar"
        Me.bt_trasladar.Size = New System.Drawing.Size(42, 38)
        Me.bt_trasladar.TabIndex = 70
        Me.bt_trasladar.UseVisualStyleBackColor = True
        '
        'txt_id_padre
        '
        Me.txt_id_padre.Location = New System.Drawing.Point(128, 127)
        Me.txt_id_padre.Name = "txt_id_padre"
        Me.txt_id_padre.Size = New System.Drawing.Size(91, 20)
        Me.txt_id_padre.TabIndex = 71
        '
        'txt_id_hijo
        '
        Me.txt_id_hijo.Location = New System.Drawing.Point(128, 154)
        Me.txt_id_hijo.Name = "txt_id_hijo"
        Me.txt_id_hijo.Size = New System.Drawing.Size(91, 20)
        Me.txt_id_hijo.TabIndex = 72
        '
        'cm_responsable
        '
        Me.cm_responsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_responsable.FormattingEnabled = True
        Me.cm_responsable.Location = New System.Drawing.Point(128, 97)
        Me.cm_responsable.Name = "cm_responsable"
        Me.cm_responsable.Size = New System.Drawing.Size(350, 24)
        Me.cm_responsable.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 18)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Responsable:"
        '
        'fm_0100_trasladar_ramal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(613, 236)
        Me.Controls.Add(Me.cm_responsable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_id_hijo)
        Me.Controls.Add(Me.txt_id_padre)
        Me.Controls.Add(Me.bt_trasladar)
        Me.Controls.Add(Me.chk_raiz)
        Me.Controls.Add(Me.rb_padre)
        Me.Controls.Add(Me.rb_hijo)
        Me.Controls.Add(Me.lb_hijo)
        Me.Controls.Add(Me.bt_cerrar)
        Me.Controls.Add(Me.lb_padre)
        Me.Name = "fm_0100_trasladar_ramal"
        Me.Text = "Trasladar Ramal"
        Me.TopMost = True
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.lb_padre, 0)
        Me.Controls.SetChildIndex(Me.bt_cerrar, 0)
        Me.Controls.SetChildIndex(Me.lb_hijo, 0)
        Me.Controls.SetChildIndex(Me.rb_hijo, 0)
        Me.Controls.SetChildIndex(Me.rb_padre, 0)
        Me.Controls.SetChildIndex(Me.chk_raiz, 0)
        Me.Controls.SetChildIndex(Me.bt_trasladar, 0)
        Me.Controls.SetChildIndex(Me.txt_id_padre, 0)
        Me.Controls.SetChildIndex(Me.txt_id_hijo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_responsable, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_padre As System.Windows.Forms.Label
    Friend WithEvents bt_cerrar As System.Windows.Forms.Button
    Friend WithEvents lb_hijo As System.Windows.Forms.Label
    Friend WithEvents rb_hijo As System.Windows.Forms.RadioButton
    Friend WithEvents rb_padre As System.Windows.Forms.RadioButton
    Friend WithEvents chk_raiz As System.Windows.Forms.CheckBox
    Friend WithEvents bt_trasladar As System.Windows.Forms.Button
    Friend WithEvents txt_id_padre As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_hijo As System.Windows.Forms.TextBox
    Friend WithEvents cm_responsable As ComboBox
    Friend WithEvents Label1 As Label
End Class
