<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_recursos_listado
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
        Me.dg_listado = New System.Windows.Forms.DataGridView()
        Me.dg_solicitud = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_solicitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_anotacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_solicitud = New System.Windows.Forms.TextBox()
        Me.bt_items_relacionados = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_solicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/03/07"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(263, 32)
        Me.lb_titulo.Text = "Recursos Necesarios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(175, 409)
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        '
        'bt_generar_informe
        '
        '
        'dg_listado
        '
        Me.dg_listado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_listado.Location = New System.Drawing.Point(12, 230)
        Me.dg_listado.Name = "dg_listado"
        Me.dg_listado.Size = New System.Drawing.Size(721, 170)
        Me.dg_listado.TabIndex = 62
        '
        'dg_solicitud
        '
        Me.dg_solicitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_solicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_solicitud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_solicitud, Me.dgocell_estado, Me.dgocell_accion, Me.dgocell_anotacion})
        Me.dg_solicitud.Location = New System.Drawing.Point(12, 80)
        Me.dg_solicitud.Name = "dg_solicitud"
        Me.dg_solicitud.Size = New System.Drawing.Size(721, 128)
        Me.dg_solicitud.TabIndex = 110
        '
        'dgocell_id_solicitud
        '
        Me.dgocell_id_solicitud.HeaderText = "# S.C."
        Me.dgocell_id_solicitud.Name = "dgocell_id_solicitud"
        Me.dgocell_id_solicitud.ReadOnly = True
        Me.dgocell_id_solicitud.Width = 50
        '
        'dgocell_estado
        '
        Me.dgocell_estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.dgocell_estado.HeaderText = "Estado"
        Me.dgocell_estado.Name = "dgocell_estado"
        Me.dgocell_estado.Width = 21
        '
        'dgocell_accion
        '
        Me.dgocell_accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgocell_accion.HeaderText = "# Accion"
        Me.dgocell_accion.Name = "dgocell_accion"
        Me.dgocell_accion.ReadOnly = True
        Me.dgocell_accion.Width = 75
        '
        'dgocell_anotacion
        '
        Me.dgocell_anotacion.HeaderText = "Anotacion"
        Me.dgocell_anotacion.Name = "dgocell_anotacion"
        Me.dgocell_anotacion.ReadOnly = True
        Me.dgocell_anotacion.Width = 300
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 16)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Historial de solicitudes:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 211)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Items solicitados:"
        '
        'tx_solicitud
        '
        Me.tx_solicitud.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tx_solicitud.Enabled = False
        Me.tx_solicitud.Location = New System.Drawing.Point(643, 409)
        Me.tx_solicitud.Name = "tx_solicitud"
        Me.tx_solicitud.Size = New System.Drawing.Size(88, 20)
        Me.tx_solicitud.TabIndex = 113
        '
        'bt_items_relacionados
        '
        Me.bt_items_relacionados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_items_relacionados.Location = New System.Drawing.Point(12, 406)
        Me.bt_items_relacionados.Name = "bt_items_relacionados"
        Me.bt_items_relacionados.Size = New System.Drawing.Size(123, 60)
        Me.bt_items_relacionados.TabIndex = 114
        Me.bt_items_relacionados.Text = "Ver todos los items relacionados"
        Me.bt_items_relacionados.UseVisualStyleBackColor = True
        '
        'fm_0600_recursos_listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 483)
        Me.Controls.Add(Me.bt_items_relacionados)
        Me.Controls.Add(Me.tx_solicitud)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dg_solicitud)
        Me.Controls.Add(Me.dg_listado)
        Me.Name = "fm_0600_recursos_listado"
        Me.Text = "Gestion de recursos"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.dg_listado, 0)
        Me.Controls.SetChildIndex(Me.dg_solicitud, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_solicitud, 0)
        Me.Controls.SetChildIndex(Me.bt_items_relacionados, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_listado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_solicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_listado As System.Windows.Forms.DataGridView
    Friend WithEvents dg_solicitud As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_solicitud As System.Windows.Forms.TextBox
    Friend WithEvents dgocell_id_solicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_accion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgocell_anotacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_items_relacionados As Button
End Class
