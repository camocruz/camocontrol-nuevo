<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_laboratorioPruebas
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
        Me.btnGenerarClave = New System.Windows.Forms.Button()
        Me.txtResultado = New System.Windows.Forms.TextBox()
        Me.btnProbarAES = New System.Windows.Forms.Button()
        Me.btnProbarArchivo = New System.Windows.Forms.Button()
        Me.btnVerificarClaves = New System.Windows.Forms.Button()
        Me.btnGenerarNombre = New System.Windows.Forms.Button()
        Me.btnGenerarRutaArchivo = New System.Windows.Forms.Button()
        Me.btnProbarConfiguracion = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGenerarClave
        '
        Me.btnGenerarClave.Location = New System.Drawing.Point(7, 9)
        Me.btnGenerarClave.Name = "btnGenerarClave"
        Me.btnGenerarClave.Size = New System.Drawing.Size(194, 81)
        Me.btnGenerarClave.TabIndex = 0
        Me.btnGenerarClave.Text = "Generar AES"
        Me.btnGenerarClave.UseVisualStyleBackColor = True
        '
        'txtResultado
        '
        Me.txtResultado.Location = New System.Drawing.Point(7, 96)
        Me.txtResultado.Multiline = True
        Me.txtResultado.Name = "txtResultado"
        Me.txtResultado.Size = New System.Drawing.Size(361, 168)
        Me.txtResultado.TabIndex = 1
        '
        'btnProbarAES
        '
        Me.btnProbarAES.Location = New System.Drawing.Point(438, 12)
        Me.btnProbarAES.Name = "btnProbarAES"
        Me.btnProbarAES.Size = New System.Drawing.Size(194, 35)
        Me.btnProbarAES.TabIndex = 2
        Me.btnProbarAES.Text = "Probar AES"
        Me.btnProbarAES.UseVisualStyleBackColor = True
        '
        'btnProbarArchivo
        '
        Me.btnProbarArchivo.Location = New System.Drawing.Point(438, 51)
        Me.btnProbarArchivo.Name = "btnProbarArchivo"
        Me.btnProbarArchivo.Size = New System.Drawing.Size(194, 35)
        Me.btnProbarArchivo.TabIndex = 3
        Me.btnProbarArchivo.Text = "Probar Archivo"
        Me.btnProbarArchivo.UseVisualStyleBackColor = True
        '
        'btnVerificarClaves
        '
        Me.btnVerificarClaves.Location = New System.Drawing.Point(438, 92)
        Me.btnVerificarClaves.Name = "btnVerificarClaves"
        Me.btnVerificarClaves.Size = New System.Drawing.Size(194, 35)
        Me.btnVerificarClaves.TabIndex = 4
        Me.btnVerificarClaves.Text = "Verificar Claves"
        Me.btnVerificarClaves.UseVisualStyleBackColor = True
        '
        'btnGenerarNombre
        '
        Me.btnGenerarNombre.Location = New System.Drawing.Point(438, 133)
        Me.btnGenerarNombre.Name = "btnGenerarNombre"
        Me.btnGenerarNombre.Size = New System.Drawing.Size(194, 35)
        Me.btnGenerarNombre.TabIndex = 5
        Me.btnGenerarNombre.Text = "Generar Nombre"
        Me.btnGenerarNombre.UseVisualStyleBackColor = True
        '
        'btnGenerarRutaArchivo
        '
        Me.btnGenerarRutaArchivo.Location = New System.Drawing.Point(438, 174)
        Me.btnGenerarRutaArchivo.Name = "btnGenerarRutaArchivo"
        Me.btnGenerarRutaArchivo.Size = New System.Drawing.Size(194, 35)
        Me.btnGenerarRutaArchivo.TabIndex = 6
        Me.btnGenerarRutaArchivo.Text = "Generar Ruta Archivo"
        Me.btnGenerarRutaArchivo.UseVisualStyleBackColor = True
        '
        'btnProbarConfiguracion
        '
        Me.btnProbarConfiguracion.Location = New System.Drawing.Point(438, 215)
        Me.btnProbarConfiguracion.Name = "btnProbarConfiguracion"
        Me.btnProbarConfiguracion.Size = New System.Drawing.Size(194, 35)
        Me.btnProbarConfiguracion.TabIndex = 7
        Me.btnProbarConfiguracion.Text = "Probar Configuracion"
        Me.btnProbarConfiguracion.UseVisualStyleBackColor = True
        '
        'fm_laboratorioPruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnProbarConfiguracion)
        Me.Controls.Add(Me.btnGenerarRutaArchivo)
        Me.Controls.Add(Me.btnGenerarNombre)
        Me.Controls.Add(Me.btnVerificarClaves)
        Me.Controls.Add(Me.btnProbarArchivo)
        Me.Controls.Add(Me.btnProbarAES)
        Me.Controls.Add(Me.txtResultado)
        Me.Controls.Add(Me.btnGenerarClave)
        Me.Name = "fm_laboratorioPruebas"
        Me.Text = "fm_laboratorioPruebas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGenerarClave As Button
    Friend WithEvents txtResultado As TextBox
    Friend WithEvents btnProbarAES As Button
    Friend WithEvents btnProbarArchivo As Button
    Friend WithEvents btnVerificarClaves As Button
    Friend WithEvents btnGenerarNombre As Button
    Friend WithEvents btnGenerarRutaArchivo As Button
    Friend WithEvents btnProbarConfiguracion As Button
End Class
