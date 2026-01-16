<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0300_Oc_ListadoSiesaApi
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
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.dgvEncabezado = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(112, 25)
        Me.lb_fecha.Text = "2026/01/12"
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(900, 628)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(98, 36)
        Me.btnCargar.TabIndex = 63
        Me.btnCargar.Text = "Button1"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'dgvEncabezado
        '
        Me.dgvEncabezado.AllowUserToAddRows = False
        Me.dgvEncabezado.AllowUserToDeleteRows = False
        Me.dgvEncabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEncabezado.Location = New System.Drawing.Point(6, 116)
        Me.dgvEncabezado.Name = "dgvEncabezado"
        Me.dgvEncabezado.ReadOnly = True
        Me.dgvEncabezado.RowHeadersWidth = 62
        Me.dgvEncabezado.RowTemplate.Height = 28
        Me.dgvEncabezado.Size = New System.Drawing.Size(1095, 237)
        Me.dgvEncabezado.TabIndex = 64
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(11, 656)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 20)
        Me.lblTotal.TabIndex = 65
        Me.lblTotal.Text = "Label1"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(6, 372)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersWidth = 62
        Me.dgvDetalle.RowTemplate.Height = 28
        Me.dgvDetalle.Size = New System.Drawing.Size(1095, 237)
        Me.dgvDetalle.TabIndex = 66
        '
        'fm_0300_Oc_ListadoSiesaApi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1113, 705)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.dgvEncabezado)
        Me.Controls.Add(Me.btnCargar)
        Me.Name = "fm_0300_Oc_ListadoSiesaApi"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.btnCargar, 0)
        Me.Controls.SetChildIndex(Me.dgvEncabezado, 0)
        Me.Controls.SetChildIndex(Me.lblTotal, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCargar As Button
    Friend WithEvents dgvEncabezado As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvDetalle As DataGridView
End Class
