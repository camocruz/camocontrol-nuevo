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
        Me.btnProbarValidacionArchivo = New System.Windows.Forms.Button()
        Me.btnPrepararSoporte = New System.Windows.Forms.Button()
        Me.btnGuardarSoporteResult = New System.Windows.Forms.Button()
        Me.btnProbarEncryptFile = New System.Windows.Forms.Button()
        Me.btnProbarDecryptFile = New System.Windows.Forms.Button()
        Me.btnProbarSoporteDigitalAccesoDto = New System.Windows.Forms.Button()
        Me.btnProbarSoporteAuditService = New System.Windows.Forms.Button()
        Me.btnTemporaryFileCleanupService = New System.Windows.Forms.Button()
        Me.btnSoporteDigitalService = New System.Windows.Forms.Button()
        Me.btnGuardarSoporte = New System.Windows.Forms.Button()
        Me.btnSoporteDigitalRepository = New System.Windows.Forms.Button()
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
        Me.btnProbarAES.Location = New System.Drawing.Point(377, 12)
        Me.btnProbarAES.Name = "btnProbarAES"
        Me.btnProbarAES.Size = New System.Drawing.Size(230, 35)
        Me.btnProbarAES.TabIndex = 2
        Me.btnProbarAES.Text = "Probar AES"
        Me.btnProbarAES.UseVisualStyleBackColor = True
        '
        'btnProbarArchivo
        '
        Me.btnProbarArchivo.Location = New System.Drawing.Point(377, 46)
        Me.btnProbarArchivo.Name = "btnProbarArchivo"
        Me.btnProbarArchivo.Size = New System.Drawing.Size(230, 35)
        Me.btnProbarArchivo.TabIndex = 3
        Me.btnProbarArchivo.Text = "Probar Archivo"
        Me.btnProbarArchivo.UseVisualStyleBackColor = True
        '
        'btnVerificarClaves
        '
        Me.btnVerificarClaves.Location = New System.Drawing.Point(377, 82)
        Me.btnVerificarClaves.Name = "btnVerificarClaves"
        Me.btnVerificarClaves.Size = New System.Drawing.Size(230, 35)
        Me.btnVerificarClaves.TabIndex = 4
        Me.btnVerificarClaves.Text = "Verificar Claves"
        Me.btnVerificarClaves.UseVisualStyleBackColor = True
        '
        'btnGenerarNombre
        '
        Me.btnGenerarNombre.Location = New System.Drawing.Point(377, 117)
        Me.btnGenerarNombre.Name = "btnGenerarNombre"
        Me.btnGenerarNombre.Size = New System.Drawing.Size(230, 35)
        Me.btnGenerarNombre.TabIndex = 5
        Me.btnGenerarNombre.Text = "Generar Nombre"
        Me.btnGenerarNombre.UseVisualStyleBackColor = True
        '
        'btnGenerarRutaArchivo
        '
        Me.btnGenerarRutaArchivo.Location = New System.Drawing.Point(377, 153)
        Me.btnGenerarRutaArchivo.Name = "btnGenerarRutaArchivo"
        Me.btnGenerarRutaArchivo.Size = New System.Drawing.Size(230, 35)
        Me.btnGenerarRutaArchivo.TabIndex = 6
        Me.btnGenerarRutaArchivo.Text = "Generar Ruta Archivo"
        Me.btnGenerarRutaArchivo.UseVisualStyleBackColor = True
        '
        'btnProbarConfiguracion
        '
        Me.btnProbarConfiguracion.Location = New System.Drawing.Point(377, 188)
        Me.btnProbarConfiguracion.Name = "btnProbarConfiguracion"
        Me.btnProbarConfiguracion.Size = New System.Drawing.Size(230, 35)
        Me.btnProbarConfiguracion.TabIndex = 7
        Me.btnProbarConfiguracion.Text = "Probar Configuracion"
        Me.btnProbarConfiguracion.UseVisualStyleBackColor = True
        '
        'btnProbarValidacionArchivo
        '
        Me.btnProbarValidacionArchivo.Location = New System.Drawing.Point(377, 222)
        Me.btnProbarValidacionArchivo.Name = "btnProbarValidacionArchivo"
        Me.btnProbarValidacionArchivo.Size = New System.Drawing.Size(230, 35)
        Me.btnProbarValidacionArchivo.TabIndex = 8
        Me.btnProbarValidacionArchivo.Text = "Probar Validacion de Archivo"
        Me.btnProbarValidacionArchivo.UseVisualStyleBackColor = True
        '
        'btnPrepararSoporte
        '
        Me.btnPrepararSoporte.Location = New System.Drawing.Point(377, 256)
        Me.btnPrepararSoporte.Name = "btnPrepararSoporte"
        Me.btnPrepararSoporte.Size = New System.Drawing.Size(230, 35)
        Me.btnPrepararSoporte.TabIndex = 9
        Me.btnPrepararSoporte.Text = "Probar Preparar Soporte"
        Me.btnPrepararSoporte.UseVisualStyleBackColor = True
        '
        'btnGuardarSoporteResult
        '
        Me.btnGuardarSoporteResult.Location = New System.Drawing.Point(377, 290)
        Me.btnGuardarSoporteResult.Name = "btnGuardarSoporteResult"
        Me.btnGuardarSoporteResult.Size = New System.Drawing.Size(230, 35)
        Me.btnGuardarSoporteResult.TabIndex = 10
        Me.btnGuardarSoporteResult.Text = "Probar guardar soporte result"
        Me.btnGuardarSoporteResult.UseVisualStyleBackColor = True
        '
        'btnProbarEncryptFile
        '
        Me.btnProbarEncryptFile.Location = New System.Drawing.Point(377, 325)
        Me.btnProbarEncryptFile.Name = "btnProbarEncryptFile"
        Me.btnProbarEncryptFile.Size = New System.Drawing.Size(230, 35)
        Me.btnProbarEncryptFile.TabIndex = 11
        Me.btnProbarEncryptFile.Text = "Probar encrypter file"
        Me.btnProbarEncryptFile.UseVisualStyleBackColor = True
        '
        'btnProbarDecryptFile
        '
        Me.btnProbarDecryptFile.Location = New System.Drawing.Point(377, 360)
        Me.btnProbarDecryptFile.Name = "btnProbarDecryptFile"
        Me.btnProbarDecryptFile.Size = New System.Drawing.Size(230, 35)
        Me.btnProbarDecryptFile.TabIndex = 12
        Me.btnProbarDecryptFile.Text = "Probar decrypter file"
        Me.btnProbarDecryptFile.UseVisualStyleBackColor = True
        '
        'btnProbarSoporteDigitalAccesoDto
        '
        Me.btnProbarSoporteDigitalAccesoDto.Location = New System.Drawing.Point(377, 395)
        Me.btnProbarSoporteDigitalAccesoDto.Name = "btnProbarSoporteDigitalAccesoDto"
        Me.btnProbarSoporteDigitalAccesoDto.Size = New System.Drawing.Size(230, 35)
        Me.btnProbarSoporteDigitalAccesoDto.TabIndex = 13
        Me.btnProbarSoporteDigitalAccesoDto.Text = "Probar SoporteDigitalAccesoDto"
        Me.btnProbarSoporteDigitalAccesoDto.UseVisualStyleBackColor = True
        '
        'btnProbarSoporteAuditService
        '
        Me.btnProbarSoporteAuditService.Location = New System.Drawing.Point(613, 12)
        Me.btnProbarSoporteAuditService.Name = "btnProbarSoporteAuditService"
        Me.btnProbarSoporteAuditService.Size = New System.Drawing.Size(230, 35)
        Me.btnProbarSoporteAuditService.TabIndex = 14
        Me.btnProbarSoporteAuditService.Text = "Probar SoporteAuditService"
        Me.btnProbarSoporteAuditService.UseVisualStyleBackColor = True
        '
        'btnTemporaryFileCleanupService
        '
        Me.btnTemporaryFileCleanupService.Location = New System.Drawing.Point(613, 46)
        Me.btnTemporaryFileCleanupService.Name = "btnTemporaryFileCleanupService"
        Me.btnTemporaryFileCleanupService.Size = New System.Drawing.Size(230, 35)
        Me.btnTemporaryFileCleanupService.TabIndex = 15
        Me.btnTemporaryFileCleanupService.Text = "TemporaryFileCleanupService"
        Me.btnTemporaryFileCleanupService.UseVisualStyleBackColor = True
        '
        'btnSoporteDigitalService
        '
        Me.btnSoporteDigitalService.Location = New System.Drawing.Point(613, 82)
        Me.btnSoporteDigitalService.Name = "btnSoporteDigitalService"
        Me.btnSoporteDigitalService.Size = New System.Drawing.Size(230, 35)
        Me.btnSoporteDigitalService.TabIndex = 16
        Me.btnSoporteDigitalService.Text = "SoporteDigitalService"
        Me.btnSoporteDigitalService.UseVisualStyleBackColor = True
        '
        'btnGuardarSoporte
        '
        Me.btnGuardarSoporte.Location = New System.Drawing.Point(613, 117)
        Me.btnGuardarSoporte.Name = "btnGuardarSoporte"
        Me.btnGuardarSoporte.Size = New System.Drawing.Size(230, 35)
        Me.btnGuardarSoporte.TabIndex = 17
        Me.btnGuardarSoporte.Text = "GuardarSoporte"
        Me.btnGuardarSoporte.UseVisualStyleBackColor = True
        '
        'btnSoporteDigitalRepository
        '
        Me.btnSoporteDigitalRepository.Location = New System.Drawing.Point(613, 153)
        Me.btnSoporteDigitalRepository.Name = "btnSoporteDigitalRepository"
        Me.btnSoporteDigitalRepository.Size = New System.Drawing.Size(230, 35)
        Me.btnSoporteDigitalRepository.TabIndex = 18
        Me.btnSoporteDigitalRepository.Text = "SoporteDigitalRepository"
        Me.btnSoporteDigitalRepository.UseVisualStyleBackColor = True
        '
        'fm_laboratorioPruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 450)
        Me.Controls.Add(Me.btnSoporteDigitalRepository)
        Me.Controls.Add(Me.btnGuardarSoporte)
        Me.Controls.Add(Me.btnSoporteDigitalService)
        Me.Controls.Add(Me.btnTemporaryFileCleanupService)
        Me.Controls.Add(Me.btnProbarSoporteAuditService)
        Me.Controls.Add(Me.btnProbarSoporteDigitalAccesoDto)
        Me.Controls.Add(Me.btnProbarDecryptFile)
        Me.Controls.Add(Me.btnProbarEncryptFile)
        Me.Controls.Add(Me.btnGuardarSoporteResult)
        Me.Controls.Add(Me.btnPrepararSoporte)
        Me.Controls.Add(Me.btnProbarValidacionArchivo)
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
    Friend WithEvents btnProbarValidacionArchivo As Button
    Friend WithEvents btnPrepararSoporte As Button
    Friend WithEvents btnGuardarSoporteResult As Button
    Friend WithEvents btnProbarEncryptFile As Button
    Friend WithEvents btnProbarDecryptFile As Button
    Friend WithEvents btnProbarSoporteDigitalAccesoDto As Button
    Friend WithEvents btnProbarSoporteAuditService As Button
    Friend WithEvents btnTemporaryFileCleanupService As Button
    Friend WithEvents btnSoporteDigitalService As Button
    Friend WithEvents btnGuardarSoporte As Button
    Friend WithEvents btnSoporteDigitalRepository As Button
End Class
