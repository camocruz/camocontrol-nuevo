<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0002_unidades_medicion
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
        Me.dg_unidades_medicion = New System.Windows.Forms.DataGridView()
        Me.ocell_dgunid_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ocell_dgunid_sigla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ocell_sigla_CGUNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ocell_dgunid_unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ocell_dgunid_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ocell_btver = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_unidades_medicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/02/02"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(289, 32)
        Me.lb_titulo.Text = "Unidades de Medición"
        '
        'bt_nuevo
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        '
        'dg_unidades_medicion
        '
        Me.dg_unidades_medicion.AllowUserToAddRows = False
        Me.dg_unidades_medicion.AllowUserToDeleteRows = False
        Me.dg_unidades_medicion.AllowUserToOrderColumns = True
        Me.dg_unidades_medicion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_unidades_medicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_unidades_medicion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ocell_dgunid_id, Me.ocell_dgunid_sigla, Me.ocell_sigla_CGUNO, Me.ocell_dgunid_unidad, Me.ocell_dgunid_tipo, Me.ocell_btver})
        Me.dg_unidades_medicion.Location = New System.Drawing.Point(13, 61)
        Me.dg_unidades_medicion.Name = "dg_unidades_medicion"
        Me.dg_unidades_medicion.ReadOnly = True
        Me.dg_unidades_medicion.Size = New System.Drawing.Size(720, 342)
        Me.dg_unidades_medicion.TabIndex = 62
        '
        'ocell_dgunid_id
        '
        Me.ocell_dgunid_id.HeaderText = "id"
        Me.ocell_dgunid_id.Name = "ocell_dgunid_id"
        Me.ocell_dgunid_id.ReadOnly = True
        Me.ocell_dgunid_id.Visible = False
        '
        'ocell_dgunid_sigla
        '
        Me.ocell_dgunid_sigla.HeaderText = "Sigla"
        Me.ocell_dgunid_sigla.Name = "ocell_dgunid_sigla"
        Me.ocell_dgunid_sigla.ReadOnly = True
        '
        'ocell_sigla_CGUNO
        '
        Me.ocell_sigla_CGUNO.HeaderText = "Sigla CG-UNO"
        Me.ocell_sigla_CGUNO.Name = "ocell_sigla_CGUNO"
        Me.ocell_sigla_CGUNO.ReadOnly = True
        '
        'ocell_dgunid_unidad
        '
        Me.ocell_dgunid_unidad.HeaderText = "Unidad"
        Me.ocell_dgunid_unidad.Name = "ocell_dgunid_unidad"
        Me.ocell_dgunid_unidad.ReadOnly = True
        Me.ocell_dgunid_unidad.Width = 200
        '
        'ocell_dgunid_tipo
        '
        Me.ocell_dgunid_tipo.HeaderText = "Tipo"
        Me.ocell_dgunid_tipo.Name = "ocell_dgunid_tipo"
        Me.ocell_dgunid_tipo.ReadOnly = True
        Me.ocell_dgunid_tipo.Width = 200
        '
        'ocell_btver
        '
        Me.ocell_btver.HeaderText = "Ver"
        Me.ocell_btver.Name = "ocell_btver"
        Me.ocell_btver.ReadOnly = True
        Me.ocell_btver.Width = 40
        '
        'fm_0002_unidades_medicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 483)
        Me.Controls.Add(Me.dg_unidades_medicion)
        Me.Name = "fm_0002_unidades_medicion"
        Me.Text = "Unidades de Medición"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.dg_unidades_medicion, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_unidades_medicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_unidades_medicion As System.Windows.Forms.DataGridView
    Friend WithEvents ocell_dgunid_id As DataGridViewTextBoxColumn
    Friend WithEvents ocell_dgunid_sigla As DataGridViewTextBoxColumn
    Friend WithEvents ocell_sigla_CGUNO As DataGridViewTextBoxColumn
    Friend WithEvents ocell_dgunid_unidad As DataGridViewTextBoxColumn
    Friend WithEvents ocell_dgunid_tipo As DataGridViewTextBoxColumn
    Friend WithEvents ocell_btver As DataGridViewButtonColumn
End Class
