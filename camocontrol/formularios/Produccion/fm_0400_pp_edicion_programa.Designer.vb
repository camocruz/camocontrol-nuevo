<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0400_pp_edicion_programa
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
        Me.dg_datos = New System.Windows.Forms.DataGridView()
        Me.dgocell_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_baches = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_fecha_inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_fecha_fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tx_cantidad_original = New System.Windows.Forms.TextBox()
        Me.tx_cantidad = New System.Windows.Forms.TextBox()
        Me.tx_baches = New System.Windows.Forms.TextBox()
        Me.dtp_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cm_planta = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dg_personal = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_seg_personal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_id_tercero = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.bt_nuevo_item_dg = New System.Windows.Forms.Button()
        Me.bt_eliminar_item_dg = New System.Windows.Forms.Button()
        Me.bt_grabar_item_dg = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tx_diferencia_cantidades = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2017/04/15"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(238, 32)
        Me.lb_titulo.Text = "Edicion Programa"
        '
        'bt_grabar
        '
        '
        'dg_datos
        '
        Me.dg_datos.AllowUserToAddRows = False
        Me.dg_datos.AllowUserToDeleteRows = False
        Me.dg_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_cantidad, Me.dgocell_baches, Me.dgocell_fecha_inicio, Me.dgocell_fecha_fin})
        Me.dg_datos.Location = New System.Drawing.Point(12, 111)
        Me.dg_datos.Name = "dg_datos"
        Me.dg_datos.Size = New System.Drawing.Size(719, 129)
        Me.dg_datos.TabIndex = 62
        '
        'dgocell_cantidad
        '
        Me.dgocell_cantidad.HeaderText = "Cantidad"
        Me.dgocell_cantidad.Name = "dgocell_cantidad"
        Me.dgocell_cantidad.ReadOnly = True
        '
        'dgocell_baches
        '
        Me.dgocell_baches.HeaderText = "Baches"
        Me.dgocell_baches.Name = "dgocell_baches"
        Me.dgocell_baches.ReadOnly = True
        '
        'dgocell_fecha_inicio
        '
        Me.dgocell_fecha_inicio.HeaderText = "Fecha_Inicial"
        Me.dgocell_fecha_inicio.Name = "dgocell_fecha_inicio"
        Me.dgocell_fecha_inicio.ReadOnly = True
        '
        'dgocell_fecha_fin
        '
        Me.dgocell_fecha_fin.HeaderText = "Fecha_Final"
        Me.dgocell_fecha_fin.Name = "dgocell_fecha_fin"
        Me.dgocell_fecha_fin.ReadOnly = True
        '
        'tx_cantidad_original
        '
        Me.tx_cantidad_original.Enabled = False
        Me.tx_cantidad_original.Location = New System.Drawing.Point(97, 64)
        Me.tx_cantidad_original.Name = "tx_cantidad_original"
        Me.tx_cantidad_original.Size = New System.Drawing.Size(100, 20)
        Me.tx_cantidad_original.TabIndex = 63
        '
        'tx_cantidad
        '
        Me.tx_cantidad.Location = New System.Drawing.Point(71, 299)
        Me.tx_cantidad.Name = "tx_cantidad"
        Me.tx_cantidad.Size = New System.Drawing.Size(100, 20)
        Me.tx_cantidad.TabIndex = 64
        '
        'tx_baches
        '
        Me.tx_baches.Location = New System.Drawing.Point(71, 321)
        Me.tx_baches.Name = "tx_baches"
        Me.tx_baches.Size = New System.Drawing.Size(100, 20)
        Me.tx_baches.TabIndex = 65
        '
        'dtp_fecha_ini
        '
        Me.dtp_fecha_ini.Location = New System.Drawing.Point(71, 343)
        Me.dtp_fecha_ini.Name = "dtp_fecha_ini"
        Me.dtp_fecha_ini.Size = New System.Drawing.Size(200, 20)
        Me.dtp_fecha_ini.TabIndex = 66
        '
        'dtp_fecha_fin
        '
        Me.dtp_fecha_fin.Location = New System.Drawing.Point(71, 365)
        Me.dtp_fecha_fin.Name = "dtp_fecha_fin"
        Me.dtp_fecha_fin.Size = New System.Drawing.Size(200, 20)
        Me.dtp_fecha_fin.TabIndex = 67
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Cantidad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 324)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "# Baches:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 349)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Fecha Ini:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 371)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Fecha Fin:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Cantidad Base:"
        '
        'cm_planta
        '
        Me.cm_planta.FormattingEnabled = True
        Me.cm_planta.Location = New System.Drawing.Point(269, 64)
        Me.cm_planta.Name = "cm_planta"
        Me.cm_planta.Size = New System.Drawing.Size(200, 21)
        Me.cm_planta.TabIndex = 73
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(221, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Planta:"
        '
        'dg_personal
        '
        Me.dg_personal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_personal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_seg_personal, Me.dgocell_id_tercero})
        Me.dg_personal.Location = New System.Drawing.Point(277, 246)
        Me.dg_personal.Name = "dg_personal"
        Me.dg_personal.Size = New System.Drawing.Size(454, 158)
        Me.dg_personal.TabIndex = 140
        '
        'dgocell_id_seg_personal
        '
        Me.dgocell_id_seg_personal.HeaderText = "Column1"
        Me.dgocell_id_seg_personal.Name = "dgocell_id_seg_personal"
        Me.dgocell_id_seg_personal.ReadOnly = True
        Me.dgocell_id_seg_personal.Visible = False
        '
        'dgocell_id_tercero
        '
        Me.dgocell_id_tercero.HeaderText = "Funcionario"
        Me.dgocell_id_tercero.Name = "dgocell_id_tercero"
        Me.dgocell_id_tercero.Width = 250
        '
        'bt_nuevo_item_dg
        '
        Me.bt_nuevo_item_dg.Image = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_nuevo_item_dg.Location = New System.Drawing.Point(12, 246)
        Me.bt_nuevo_item_dg.Name = "bt_nuevo_item_dg"
        Me.bt_nuevo_item_dg.Size = New System.Drawing.Size(34, 40)
        Me.bt_nuevo_item_dg.TabIndex = 141
        Me.bt_nuevo_item_dg.UseVisualStyleBackColor = True
        '
        'bt_eliminar_item_dg
        '
        Me.bt_eliminar_item_dg.Image = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_eliminar_item_dg.Location = New System.Drawing.Point(50, 246)
        Me.bt_eliminar_item_dg.Name = "bt_eliminar_item_dg"
        Me.bt_eliminar_item_dg.Size = New System.Drawing.Size(34, 40)
        Me.bt_eliminar_item_dg.TabIndex = 142
        Me.bt_eliminar_item_dg.UseVisualStyleBackColor = True
        '
        'bt_grabar_item_dg
        '
        Me.bt_grabar_item_dg.Image = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar_item_dg.Location = New System.Drawing.Point(177, 297)
        Me.bt_grabar_item_dg.Name = "bt_grabar_item_dg"
        Me.bt_grabar_item_dg.Size = New System.Drawing.Size(50, 44)
        Me.bt_grabar_item_dg.TabIndex = 143
        Me.bt_grabar_item_dg.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 145
        Me.Label7.Text = "Diferencia:"
        '
        'tx_diferencia_cantidades
        '
        Me.tx_diferencia_cantidades.Enabled = False
        Me.tx_diferencia_cantidades.Location = New System.Drawing.Point(97, 85)
        Me.tx_diferencia_cantidades.Name = "tx_diferencia_cantidades"
        Me.tx_diferencia_cantidades.Size = New System.Drawing.Size(100, 20)
        Me.tx_diferencia_cantidades.TabIndex = 144
        '
        'fm_0400_pp_edicion_programa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(745, 488)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tx_diferencia_cantidades)
        Me.Controls.Add(Me.bt_grabar_item_dg)
        Me.Controls.Add(Me.bt_eliminar_item_dg)
        Me.Controls.Add(Me.bt_nuevo_item_dg)
        Me.Controls.Add(Me.dg_personal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cm_planta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_fecha_fin)
        Me.Controls.Add(Me.dtp_fecha_ini)
        Me.Controls.Add(Me.tx_baches)
        Me.Controls.Add(Me.tx_cantidad)
        Me.Controls.Add(Me.tx_cantidad_original)
        Me.Controls.Add(Me.dg_datos)
        Me.Name = "fm_0400_pp_edicion_programa"
        Me.Text = "Edicion Programa"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.dg_datos, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad_original, 0)
        Me.Controls.SetChildIndex(Me.tx_cantidad, 0)
        Me.Controls.SetChildIndex(Me.tx_baches, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_ini, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_fin, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cm_planta, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dg_personal, 0)
        Me.Controls.SetChildIndex(Me.bt_nuevo_item_dg, 0)
        Me.Controls.SetChildIndex(Me.bt_eliminar_item_dg, 0)
        Me.Controls.SetChildIndex(Me.bt_grabar_item_dg, 0)
        Me.Controls.SetChildIndex(Me.tx_diferencia_cantidades, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_datos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_personal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dg_datos As DataGridView
    Friend WithEvents tx_cantidad_original As TextBox
    Friend WithEvents tx_cantidad As TextBox
    Friend WithEvents tx_baches As TextBox
    Friend WithEvents dtp_fecha_ini As DateTimePicker
    Friend WithEvents dtp_fecha_fin As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cm_planta As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dg_personal As DataGridView
    Friend WithEvents dgocell_id_seg_personal As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_tercero As DataGridViewComboBoxColumn
    Friend WithEvents bt_nuevo_item_dg As Button
    Friend WithEvents bt_eliminar_item_dg As Button
    Friend WithEvents bt_grabar_item_dg As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents tx_diferencia_cantidades As TextBox
    Friend WithEvents dgocell_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_baches As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_fecha_inicio As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_fecha_fin As DataGridViewTextBoxColumn
End Class
