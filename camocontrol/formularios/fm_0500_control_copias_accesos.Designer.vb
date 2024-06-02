<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0500_control_copias_accesos
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
        Me.dg_personas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dg_cargos = New System.Windows.Forms.DataGridView()
        Me.dgocell_cargo_id_cargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cargo_cm_cargo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgocell_cargo_ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_cargo_chk_c_controlada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_cargo_chk_c_digital = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_cargo_chk_g_registro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_cargo_chk_c_ferenciado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_personas_id_tercero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_personas_cm_nombre_funcionario = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgocell_personas_ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_perosnas_chk_c_controlada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_personas_chk_c_digital = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_perosnas_chk_g_registro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgocell_personas_chk_c_ferenciado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_personas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_cargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(819, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(820, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2018/10/06"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(729, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(357, 32)
        Me.lb_titulo.Text = "Control de Copias y Accesos"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 547)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(401, 494)
        '
        'dg_personas
        '
        Me.dg_personas.AllowUserToDeleteRows = False
        Me.dg_personas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_personas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_personas_id_tercero, Me.dgocell_personas_cm_nombre_funcionario, Me.dgocell_personas_ubicacion, Me.dgocell_perosnas_chk_c_controlada, Me.dgocell_personas_chk_c_digital, Me.dgocell_perosnas_chk_g_registro, Me.dgocell_personas_chk_c_ferenciado})
        Me.dg_personas.Location = New System.Drawing.Point(14, 296)
        Me.dg_personas.Name = "dg_personas"
        Me.dg_personas.Size = New System.Drawing.Size(872, 180)
        Me.dg_personas.TabIndex = 271
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 276)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 263
        Me.Label1.Text = "Personas:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 262
        Me.Label2.Text = "Cargos:"
        '
        'dg_cargos
        '
        Me.dg_cargos.AllowUserToDeleteRows = False
        Me.dg_cargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_cargos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_cargo_id_cargo, Me.dgocell_cargo_cm_cargo, Me.dgocell_cargo_ubicacion, Me.dgocell_cargo_chk_c_controlada, Me.dgocell_cargo_chk_c_digital, Me.dgocell_cargo_chk_g_registro, Me.dgocell_cargo_chk_c_ferenciado})
        Me.dg_cargos.Location = New System.Drawing.Point(14, 85)
        Me.dg_cargos.MultiSelect = False
        Me.dg_cargos.Name = "dg_cargos"
        Me.dg_cargos.Size = New System.Drawing.Size(872, 180)
        Me.dg_cargos.TabIndex = 261
        '
        'dgocell_cargo_id_cargo
        '
        Me.dgocell_cargo_id_cargo.HeaderText = "id_cargo"
        Me.dgocell_cargo_id_cargo.Name = "dgocell_cargo_id_cargo"
        Me.dgocell_cargo_id_cargo.ReadOnly = True
        Me.dgocell_cargo_id_cargo.Width = 50
        '
        'dgocell_cargo_cm_cargo
        '
        Me.dgocell_cargo_cm_cargo.HeaderText = "Cargo"
        Me.dgocell_cargo_cm_cargo.Name = "dgocell_cargo_cm_cargo"
        Me.dgocell_cargo_cm_cargo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_cargo_cm_cargo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_cargo_cm_cargo.Width = 400
        '
        'dgocell_cargo_ubicacion
        '
        Me.dgocell_cargo_ubicacion.HeaderText = "Ubicacion"
        Me.dgocell_cargo_ubicacion.Name = "dgocell_cargo_ubicacion"
        Me.dgocell_cargo_ubicacion.Width = 200
        '
        'dgocell_cargo_chk_c_controlada
        '
        Me.dgocell_cargo_chk_c_controlada.HeaderText = "CC"
        Me.dgocell_cargo_chk_c_controlada.Name = "dgocell_cargo_chk_c_controlada"
        Me.dgocell_cargo_chk_c_controlada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_cargo_chk_c_controlada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_cargo_chk_c_controlada.Width = 30
        '
        'dgocell_cargo_chk_c_digital
        '
        Me.dgocell_cargo_chk_c_digital.HeaderText = "CD"
        Me.dgocell_cargo_chk_c_digital.Name = "dgocell_cargo_chk_c_digital"
        Me.dgocell_cargo_chk_c_digital.Width = 30
        '
        'dgocell_cargo_chk_g_registro
        '
        Me.dgocell_cargo_chk_g_registro.HeaderText = "GR"
        Me.dgocell_cargo_chk_g_registro.Name = "dgocell_cargo_chk_g_registro"
        Me.dgocell_cargo_chk_g_registro.Width = 30
        '
        'dgocell_cargo_chk_c_ferenciado
        '
        Me.dgocell_cargo_chk_c_ferenciado.HeaderText = "RF"
        Me.dgocell_cargo_chk_c_ferenciado.Name = "dgocell_cargo_chk_c_ferenciado"
        Me.dgocell_cargo_chk_c_ferenciado.Width = 30
        '
        'dgocell_personas_id_tercero
        '
        Me.dgocell_personas_id_tercero.HeaderText = "id_Fun"
        Me.dgocell_personas_id_tercero.Name = "dgocell_personas_id_tercero"
        Me.dgocell_personas_id_tercero.Visible = False
        Me.dgocell_personas_id_tercero.Width = 50
        '
        'dgocell_personas_cm_nombre_funcionario
        '
        Me.dgocell_personas_cm_nombre_funcionario.HeaderText = "Funcionario"
        Me.dgocell_personas_cm_nombre_funcionario.Name = "dgocell_personas_cm_nombre_funcionario"
        Me.dgocell_personas_cm_nombre_funcionario.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_personas_cm_nombre_funcionario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgocell_personas_cm_nombre_funcionario.Width = 450
        '
        'dgocell_personas_ubicacion
        '
        Me.dgocell_personas_ubicacion.HeaderText = "Ubicacion"
        Me.dgocell_personas_ubicacion.Name = "dgocell_personas_ubicacion"
        Me.dgocell_personas_ubicacion.Width = 200
        '
        'dgocell_perosnas_chk_c_controlada
        '
        Me.dgocell_perosnas_chk_c_controlada.HeaderText = "CC"
        Me.dgocell_perosnas_chk_c_controlada.Name = "dgocell_perosnas_chk_c_controlada"
        Me.dgocell_perosnas_chk_c_controlada.Width = 30
        '
        'dgocell_personas_chk_c_digital
        '
        Me.dgocell_personas_chk_c_digital.HeaderText = "CD"
        Me.dgocell_personas_chk_c_digital.Name = "dgocell_personas_chk_c_digital"
        Me.dgocell_personas_chk_c_digital.Width = 30
        '
        'dgocell_perosnas_chk_g_registro
        '
        Me.dgocell_perosnas_chk_g_registro.HeaderText = "GR"
        Me.dgocell_perosnas_chk_g_registro.Name = "dgocell_perosnas_chk_g_registro"
        Me.dgocell_perosnas_chk_g_registro.Width = 30
        '
        'dgocell_personas_chk_c_ferenciado
        '
        Me.dgocell_personas_chk_c_ferenciado.HeaderText = "RF"
        Me.dgocell_personas_chk_c_ferenciado.Name = "dgocell_personas_chk_c_ferenciado"
        Me.dgocell_personas_chk_c_ferenciado.Width = 30
        '
        'fm_0500_control_copias_accesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(898, 561)
        Me.Controls.Add(Me.dg_personas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dg_cargos)
        Me.Name = "fm_0500_control_copias_accesos"
        Me.Text = "Control de copias y accesos a documentos"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.dg_cargos, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dg_personas, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_personas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_cargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_personas As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dg_cargos As DataGridView
    Friend WithEvents dgocell_personas_id_tercero As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_personas_cm_nombre_funcionario As DataGridViewComboBoxColumn
    Friend WithEvents dgocell_personas_ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_perosnas_chk_c_controlada As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_personas_chk_c_digital As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_perosnas_chk_g_registro As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_personas_chk_c_ferenciado As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_cargo_id_cargo As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cargo_cm_cargo As DataGridViewComboBoxColumn
    Friend WithEvents dgocell_cargo_ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_cargo_chk_c_controlada As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_cargo_chk_c_digital As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_cargo_chk_g_registro As DataGridViewCheckBoxColumn
    Friend WithEvents dgocell_cargo_chk_c_ferenciado As DataGridViewCheckBoxColumn
End Class
