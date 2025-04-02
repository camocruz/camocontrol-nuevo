<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_gestion_agrupada_consumos_produccion
    Inherits camocontrol.FM_PLANTILLA

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
        Me.dg_doc_pendientes = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_id_doc_inv = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_doc_pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/06/14"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(407, 32)
        Me.lb_titulo.Text = "Gestion Agrupada de Consumos"
        '
        'bt_grabar
        '
        '
        'bt_nuevo
        '
        '
        'dg_doc_pendientes
        '
        Me.dg_doc_pendientes.AllowUserToAddRows = False
        Me.dg_doc_pendientes.AllowUserToDeleteRows = False
        Me.dg_doc_pendientes.AllowUserToOrderColumns = True
        Me.dg_doc_pendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_doc_pendientes.Location = New System.Drawing.Point(12, 81)
        Me.dg_doc_pendientes.Name = "dg_doc_pendientes"
        Me.dg_doc_pendientes.ReadOnly = True
        Me.dg_doc_pendientes.Size = New System.Drawing.Size(720, 150)
        Me.dg_doc_pendientes.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Documentos de agrupacion consumos"
        '
        'tx_id_doc_inv
        '
        Me.tx_id_doc_inv.Location = New System.Drawing.Point(109, 262)
        Me.tx_id_doc_inv.Name = "tx_id_doc_inv"
        Me.tx_id_doc_inv.ReadOnly = True
        Me.tx_id_doc_inv.Size = New System.Drawing.Size(100, 20)
        Me.tx_id_doc_inv.TabIndex = 64
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 265)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Cod. Documento:"
        '
        'fm_0400_gestion_agrupada_consumos_produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 483)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_id_doc_inv)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_doc_pendientes)
        Me.Name = "fm_0400_gestion_agrupada_consumos_produccion"
        Me.Text = "Consumos Producción"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.dg_doc_pendientes, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_id_doc_inv, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_doc_pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dg_doc_pendientes As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents tx_id_doc_inv As TextBox
    Friend WithEvents Label2 As Label
End Class
