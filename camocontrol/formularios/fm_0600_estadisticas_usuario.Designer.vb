<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0600_estadisticas_usuario
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
        Me.dg_acciones_receptor = New System.Windows.Forms.DataGridView()
        Me.dga_rcptor_ocell_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dga_rcptor_ocell_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dga_rcptor_ocell_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_acciones_emisor = New System.Windows.Forms.DataGridView()
        Me.dga_msor_ocell_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dga_msor_ocell_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dga_msor_ocell_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dg_acciones_evaluador = New System.Windows.Forms.DataGridView()
        Me.dga_vldor_ocell_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dga_vldor_ocell_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dga_vldor_ocell_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_actividad = New System.Windows.Forms.TextBox()
        Me.bt_abrir_actividad = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cm_fuente_accion = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_acciones_receptor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_acciones_emisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_acciones_evaluador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(823, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(824, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/07/07"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(733, 6)
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 536)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 500)
        '
        'dg_acciones_receptor
        '
        Me.dg_acciones_receptor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_acciones_receptor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dga_rcptor_ocell_tipo, Me.dga_rcptor_ocell_estado, Me.dga_rcptor_ocell_cantidad})
        Me.dg_acciones_receptor.Location = New System.Drawing.Point(12, 138)
        Me.dg_acciones_receptor.Name = "dg_acciones_receptor"
        Me.dg_acciones_receptor.Size = New System.Drawing.Size(276, 311)
        Me.dg_acciones_receptor.TabIndex = 63
        '
        'dga_rcptor_ocell_tipo
        '
        Me.dga_rcptor_ocell_tipo.HeaderText = "Tipo"
        Me.dga_rcptor_ocell_tipo.Name = "dga_rcptor_ocell_tipo"
        Me.dga_rcptor_ocell_tipo.ReadOnly = True
        Me.dga_rcptor_ocell_tipo.Width = 60
        '
        'dga_rcptor_ocell_estado
        '
        Me.dga_rcptor_ocell_estado.HeaderText = "Estado"
        Me.dga_rcptor_ocell_estado.Name = "dga_rcptor_ocell_estado"
        Me.dga_rcptor_ocell_estado.ReadOnly = True
        '
        'dga_rcptor_ocell_cantidad
        '
        Me.dga_rcptor_ocell_cantidad.HeaderText = "Cant."
        Me.dga_rcptor_ocell_cantidad.Name = "dga_rcptor_ocell_cantidad"
        Me.dga_rcptor_ocell_cantidad.ReadOnly = True
        Me.dga_rcptor_ocell_cantidad.Width = 50
        '
        'dg_acciones_emisor
        '
        Me.dg_acciones_emisor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_acciones_emisor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dga_msor_ocell_tipo, Me.dga_msor_ocell_estado, Me.dga_msor_ocell_cantidad})
        Me.dg_acciones_emisor.Location = New System.Drawing.Point(610, 138)
        Me.dg_acciones_emisor.Name = "dg_acciones_emisor"
        Me.dg_acciones_emisor.Size = New System.Drawing.Size(276, 311)
        Me.dg_acciones_emisor.TabIndex = 65
        '
        'dga_msor_ocell_tipo
        '
        Me.dga_msor_ocell_tipo.HeaderText = "Tipo"
        Me.dga_msor_ocell_tipo.Name = "dga_msor_ocell_tipo"
        Me.dga_msor_ocell_tipo.ReadOnly = True
        Me.dga_msor_ocell_tipo.Width = 60
        '
        'dga_msor_ocell_estado
        '
        Me.dga_msor_ocell_estado.HeaderText = "Estado"
        Me.dga_msor_ocell_estado.Name = "dga_msor_ocell_estado"
        Me.dga_msor_ocell_estado.ReadOnly = True
        '
        'dga_msor_ocell_cantidad
        '
        Me.dga_msor_ocell_cantidad.HeaderText = "Cant."
        Me.dga_msor_ocell_cantidad.Name = "dga_msor_ocell_cantidad"
        Me.dga_msor_ocell_cantidad.ReadOnly = True
        Me.dga_msor_ocell_cantidad.Width = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 22)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "COMO RECEPTOR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 15)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Estado De Acciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(607, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 15)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Estado De Acciones"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(606, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 22)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "COMO EMISOR"
        '
        'dg_acciones_evaluador
        '
        Me.dg_acciones_evaluador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_acciones_evaluador.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dga_vldor_ocell_tipo, Me.dga_vldor_ocell_estado, Me.dga_vldor_ocell_cantidad})
        Me.dg_acciones_evaluador.Location = New System.Drawing.Point(311, 138)
        Me.dg_acciones_evaluador.Name = "dg_acciones_evaluador"
        Me.dg_acciones_evaluador.Size = New System.Drawing.Size(276, 311)
        Me.dg_acciones_evaluador.TabIndex = 64
        '
        'dga_vldor_ocell_tipo
        '
        Me.dga_vldor_ocell_tipo.HeaderText = "Tipo"
        Me.dga_vldor_ocell_tipo.Name = "dga_vldor_ocell_tipo"
        Me.dga_vldor_ocell_tipo.ReadOnly = True
        Me.dga_vldor_ocell_tipo.Width = 60
        '
        'dga_vldor_ocell_estado
        '
        Me.dga_vldor_ocell_estado.HeaderText = "Estado"
        Me.dga_vldor_ocell_estado.Name = "dga_vldor_ocell_estado"
        Me.dga_vldor_ocell_estado.ReadOnly = True
        '
        'dga_vldor_ocell_cantidad
        '
        Me.dga_vldor_ocell_cantidad.HeaderText = "Cant."
        Me.dga_vldor_ocell_cantidad.Name = "dga_vldor_ocell_cantidad"
        Me.dga_vldor_ocell_cantidad.ReadOnly = True
        Me.dga_vldor_ocell_cantidad.Width = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(306, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 22)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "COMO EVALUADOR"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(307, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 15)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Estado De Acciones"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(607, 452)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 15)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Estado De Acciones"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(307, 452)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 15)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Estado De Acciones"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 452)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 15)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Estado De Acciones"
        '
        'tx_actividad
        '
        Me.tx_actividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_actividad.Location = New System.Drawing.Point(13, 23)
        Me.tx_actividad.Name = "tx_actividad"
        Me.tx_actividad.Size = New System.Drawing.Size(75, 22)
        Me.tx_actividad.TabIndex = 77
        '
        'bt_abrir_actividad
        '
        Me.bt_abrir_actividad.BackgroundImage = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_abrir_actividad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_abrir_actividad.Location = New System.Drawing.Point(94, 18)
        Me.bt_abrir_actividad.Name = "bt_abrir_actividad"
        Me.bt_abrir_actividad.Size = New System.Drawing.Size(44, 33)
        Me.bt_abrir_actividad.TabIndex = 78
        Me.bt_abrir_actividad.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bt_abrir_actividad)
        Me.GroupBox1.Controls.Add(Me.tx_actividad)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(736, 470)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 58)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consultar Actividad"
        '
        'cm_fuente_accion
        '
        Me.cm_fuente_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_fuente_accion.FormattingEnabled = True
        Me.cm_fuente_accion.Location = New System.Drawing.Point(67, 62)
        Me.cm_fuente_accion.Name = "cm_fuente_accion"
        Me.cm_fuente_accion.Size = New System.Drawing.Size(382, 24)
        Me.cm_fuente_accion.TabIndex = 179
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 65)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 16)
        Me.Label20.TabIndex = 178
        Me.Label20.Text = "Fuente:"
        '
        'fm_0600_estadisticas_usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(902, 550)
        Me.Controls.Add(Me.cm_fuente_accion)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_acciones_emisor)
        Me.Controls.Add(Me.dg_acciones_evaluador)
        Me.Controls.Add(Me.dg_acciones_receptor)
        Me.Name = "fm_0600_estadisticas_usuario"
        Me.Controls.SetChildIndex(Me.dg_acciones_receptor, 0)
        Me.Controls.SetChildIndex(Me.dg_acciones_evaluador, 0)
        Me.Controls.SetChildIndex(Me.dg_acciones_emisor, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.cm_fuente_accion, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_acciones_receptor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_acciones_emisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_acciones_evaluador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_acciones_receptor As System.Windows.Forms.DataGridView
    Friend WithEvents dg_acciones_emisor As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dg_acciones_evaluador As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dga_rcptor_ocell_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dga_rcptor_ocell_estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dga_rcptor_ocell_cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dga_msor_ocell_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dga_msor_ocell_estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dga_msor_ocell_cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dga_vldor_ocell_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dga_vldor_ocell_estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dga_vldor_ocell_cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_actividad As System.Windows.Forms.TextBox
    Friend WithEvents bt_abrir_actividad As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cm_fuente_accion As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label

End Class
