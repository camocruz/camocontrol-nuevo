<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidadorDuplicados
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
        Me.components = New System.ComponentModel.Container()
        Me.txtEntrada = New System.Windows.Forms.TextBox()
        Me.lblRegla = New System.Windows.Forms.Label()
        Me.lstSugerencias = New System.Windows.Forms.ListBox()
        Me.lblDuplicadosInfo = New System.Windows.Forms.Label()
        Me.lstDuplicados = New System.Windows.Forms.ListBox()
        Me.picEstado = New System.Windows.Forms.PictureBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.toolTipPopup = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblInfo = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(675, 11)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(676, 44)
        Me.lb_fecha.Size = New System.Drawing.Size(91, 20)
        Me.lb_fecha.Text = "2026/09/19"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(555, 7)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(321, 42)
        Me.lb_titulo.Text = "Buscador de Textos"
        '
        'txtEntrada
        '
        Me.txtEntrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntrada.Location = New System.Drawing.Point(12, 108)
        Me.txtEntrada.Name = "txtEntrada"
        Me.txtEntrada.Size = New System.Drawing.Size(755, 26)
        Me.txtEntrada.TabIndex = 63
        '
        'lblRegla
        '
        Me.lblRegla.AutoSize = True
        Me.lblRegla.Location = New System.Drawing.Point(12, 80)
        Me.lblRegla.Name = "lblRegla"
        Me.lblRegla.Size = New System.Drawing.Size(48, 16)
        Me.lblRegla.TabIndex = 64
        Me.lblRegla.Text = "Label1"
        '
        'lstSugerencias
        '
        Me.lstSugerencias.FormattingEnabled = True
        Me.lstSugerencias.ItemHeight = 16
        Me.lstSugerencias.Location = New System.Drawing.Point(12, 140)
        Me.lstSugerencias.Name = "lstSugerencias"
        Me.lstSugerencias.Size = New System.Drawing.Size(755, 100)
        Me.lstSugerencias.TabIndex = 65
        '
        'lblDuplicadosInfo
        '
        Me.lblDuplicadosInfo.AutoSize = True
        Me.lblDuplicadosInfo.Location = New System.Drawing.Point(12, 264)
        Me.lblDuplicadosInfo.Name = "lblDuplicadosInfo"
        Me.lblDuplicadosInfo.Size = New System.Drawing.Size(48, 16)
        Me.lblDuplicadosInfo.TabIndex = 66
        Me.lblDuplicadosInfo.Text = "Label1"
        '
        'lstDuplicados
        '
        Me.lstDuplicados.FormattingEnabled = True
        Me.lstDuplicados.ItemHeight = 16
        Me.lstDuplicados.Location = New System.Drawing.Point(12, 293)
        Me.lstDuplicados.Name = "lstDuplicados"
        Me.lstDuplicados.Size = New System.Drawing.Size(755, 100)
        Me.lstDuplicados.TabIndex = 67
        '
        'picEstado
        '
        Me.picEstado.Location = New System.Drawing.Point(12, 411)
        Me.picEstado.Name = "picEstado"
        Me.picEstado.Size = New System.Drawing.Size(32, 32)
        Me.picEstado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picEstado.TabIndex = 68
        Me.picEstado.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(225, 433)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 32)
        Me.btnAceptar.TabIndex = 69
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(326, 433)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 32)
        Me.btnCancelar.TabIndex = 70
        Me.btnCancelar.Tag = ""
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(437, 433)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 32)
        Me.btnLimpiar.TabIndex = 71
        Me.btnLimpiar.Tag = ""
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(144, 411)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(48, 16)
        Me.lblInfo.TabIndex = 72
        Me.lblInfo.Text = "Label1"
        '
        'frmValidadorDuplicados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(780, 564)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.picEstado)
        Me.Controls.Add(Me.lstDuplicados)
        Me.Controls.Add(Me.lblDuplicadosInfo)
        Me.Controls.Add(Me.lstSugerencias)
        Me.Controls.Add(Me.lblRegla)
        Me.Controls.Add(Me.txtEntrada)
        Me.Name = "frmValidadorDuplicados"
        Me.Text = "Buscador de Textos"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.txtEntrada, 0)
        Me.Controls.SetChildIndex(Me.lblRegla, 0)
        Me.Controls.SetChildIndex(Me.lstSugerencias, 0)
        Me.Controls.SetChildIndex(Me.lblDuplicadosInfo, 0)
        Me.Controls.SetChildIndex(Me.lstDuplicados, 0)
        Me.Controls.SetChildIndex(Me.picEstado, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiar, 0)
        Me.Controls.SetChildIndex(Me.lblInfo, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEntrada As TextBox
    Friend WithEvents lblRegla As Label
    Friend WithEvents lstSugerencias As ListBox
    Friend WithEvents lblDuplicadosInfo As Label
    Friend WithEvents lstDuplicados As ListBox
    Friend WithEvents picEstado As PictureBox
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents toolTipPopup As ToolTip
    Friend WithEvents lblInfo As Label
End Class
