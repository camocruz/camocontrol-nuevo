<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0200_tercero_sucursal
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tx_direccion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_nombre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cm_ciudad = New System.Windows.Forms.ComboBox()
        Me.tx_telefono_fijo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_celular = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tx_email = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tx_notas_varias = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_id_tercero = New System.Windows.Forms.TextBox()
        Me.dg_puntos_entrega = New System.Windows.Forms.DataGridView()
        Me.dgocell_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_ciudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_imgcell_editar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tx_nombre_contacto = New System.Windows.Forms.TextBox()
        Me.bt_nuevo_punto_entrega = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_puntos_entrega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(760, 6)
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(858, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(859, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2016/02/06"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(279, 32)
        Me.lb_titulo.Text = "Informacion Sucursal"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(225, 409)
        '
        'bt_grabar
        '
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 469)
        '
        'bt_editar
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Nombre Sucursal:"
        '
        'tx_direccion
        '
        Me.tx_direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_direccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_direccion.Location = New System.Drawing.Point(127, 128)
        Me.tx_direccion.MaxLength = 100
        Me.tx_direccion.Name = "tx_direccion"
        Me.tx_direccion.Size = New System.Drawing.Size(319, 22)
        Me.tx_direccion.TabIndex = 105
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 16)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Direccion Factura:"
        '
        'tx_nombre
        '
        Me.tx_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_nombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nombre.Location = New System.Drawing.Point(127, 100)
        Me.tx_nombre.MaxLength = 100
        Me.tx_nombre.Name = "tx_nombre"
        Me.tx_nombre.Size = New System.Drawing.Size(319, 22)
        Me.tx_nombre.TabIndex = 104
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 157)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 16)
        Me.Label11.TabIndex = 109
        Me.Label11.Text = "Ciudad Factura:"
        '
        'cm_ciudad
        '
        Me.cm_ciudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_ciudad.FormattingEnabled = True
        Me.cm_ciudad.Location = New System.Drawing.Point(127, 156)
        Me.cm_ciudad.Name = "cm_ciudad"
        Me.cm_ciudad.Size = New System.Drawing.Size(319, 24)
        Me.cm_ciudad.TabIndex = 108
        '
        'tx_telefono_fijo
        '
        Me.tx_telefono_fijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_telefono_fijo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_telefono_fijo.Location = New System.Drawing.Point(127, 214)
        Me.tx_telefono_fijo.MaxLength = 100
        Me.tx_telefono_fijo.Name = "tx_telefono_fijo"
        Me.tx_telefono_fijo.Size = New System.Drawing.Size(319, 22)
        Me.tx_telefono_fijo.TabIndex = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 217)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Telefono :"
        '
        'tx_celular
        '
        Me.tx_celular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_celular.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_celular.Location = New System.Drawing.Point(127, 242)
        Me.tx_celular.MaxLength = 100
        Me.tx_celular.Name = "tx_celular"
        Me.tx_celular.Size = New System.Drawing.Size(319, 22)
        Me.tx_celular.TabIndex = 112
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Celular :"
        '
        'tx_email
        '
        Me.tx_email.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_email.Location = New System.Drawing.Point(127, 270)
        Me.tx_email.MaxLength = 100
        Me.tx_email.Name = "tx_email"
        Me.tx_email.Size = New System.Drawing.Size(319, 22)
        Me.tx_email.TabIndex = 114
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 273)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Correo :"
        '
        'tx_notas_varias
        '
        Me.tx_notas_varias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_notas_varias.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_notas_varias.Location = New System.Drawing.Point(452, 122)
        Me.tx_notas_varias.MaxLength = 100
        Me.tx_notas_varias.Multiline = True
        Me.tx_notas_varias.Name = "tx_notas_varias"
        Me.tx_notas_varias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tx_notas_varias.Size = New System.Drawing.Size(393, 170)
        Me.tx_notas_varias.TabIndex = 116
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(449, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 16)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Anotacion :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 16)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Id:"
        '
        'tx_id_tercero
        '
        Me.tx_id_tercero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_id_tercero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_tercero.Location = New System.Drawing.Point(127, 72)
        Me.tx_id_tercero.MaxLength = 20
        Me.tx_id_tercero.Name = "tx_id_tercero"
        Me.tx_id_tercero.ReadOnly = True
        Me.tx_id_tercero.Size = New System.Drawing.Size(126, 22)
        Me.tx_id_tercero.TabIndex = 118
        '
        'dg_puntos_entrega
        '
        Me.dg_puntos_entrega.AllowUserToAddRows = False
        Me.dg_puntos_entrega.AllowUserToDeleteRows = False
        Me.dg_puntos_entrega.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_puntos_entrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_puntos_entrega.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id, Me.dgocell_ciudad, Me.dgocell_direccion, Me.dg_imgcell_editar})
        Me.dg_puntos_entrega.Location = New System.Drawing.Point(127, 299)
        Me.dg_puntos_entrega.Name = "dg_puntos_entrega"
        Me.dg_puntos_entrega.Size = New System.Drawing.Size(791, 104)
        Me.dg_puntos_entrega.TabIndex = 120
        '
        'dgocell_id
        '
        Me.dgocell_id.HeaderText = "Id"
        Me.dgocell_id.Name = "dgocell_id"
        Me.dgocell_id.ReadOnly = True
        Me.dgocell_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_id.Width = 50
        '
        'dgocell_ciudad
        '
        Me.dgocell_ciudad.HeaderText = "Ciudad"
        Me.dgocell_ciudad.Name = "dgocell_ciudad"
        Me.dgocell_ciudad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_ciudad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgocell_ciudad.Width = 200
        '
        'dgocell_direccion
        '
        Me.dgocell_direccion.HeaderText = "Direccion"
        Me.dgocell_direccion.Name = "dgocell_direccion"
        Me.dgocell_direccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgocell_direccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgocell_direccion.Width = 400
        '
        'dg_imgcell_editar
        '
        Me.dg_imgcell_editar.HeaderText = ""
        Me.dg_imgcell_editar.Image = Global.camocontrol.My.Resources.Resources.design
        Me.dg_imgcell_editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.dg_imgcell_editar.Name = "dg_imgcell_editar"
        Me.dg_imgcell_editar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_imgcell_editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dg_imgcell_editar.Width = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 299)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 16)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "Puntos Entrega :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 16)
        Me.Label8.TabIndex = 123
        Me.Label8.Text = "Nombre Contacto:"
        '
        'tx_nombre_contacto
        '
        Me.tx_nombre_contacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_nombre_contacto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nombre_contacto.Location = New System.Drawing.Point(127, 186)
        Me.tx_nombre_contacto.MaxLength = 100
        Me.tx_nombre_contacto.Name = "tx_nombre_contacto"
        Me.tx_nombre_contacto.Size = New System.Drawing.Size(319, 22)
        Me.tx_nombre_contacto.TabIndex = 122
        '
        'bt_nuevo_punto_entrega
        '
        Me.bt_nuevo_punto_entrega.Location = New System.Drawing.Point(12, 318)
        Me.bt_nuevo_punto_entrega.Name = "bt_nuevo_punto_entrega"
        Me.bt_nuevo_punto_entrega.Size = New System.Drawing.Size(72, 47)
        Me.bt_nuevo_punto_entrega.TabIndex = 124
        Me.bt_nuevo_punto_entrega.Text = "Nuevo Punto"
        Me.bt_nuevo_punto_entrega.UseVisualStyleBackColor = True
        '
        'fm_0200_tercero_sucursal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(945, 483)
        Me.Controls.Add(Me.bt_nuevo_punto_entrega)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tx_nombre_contacto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dg_puntos_entrega)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tx_id_tercero)
        Me.Controls.Add(Me.tx_notas_varias)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tx_email)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tx_celular)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tx_telefono_fijo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cm_ciudad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_direccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_nombre)
        Me.Name = "fm_0200_tercero_sucursal"
        Me.Text = "Sucursal Tercero"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.tx_nombre, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_direccion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cm_ciudad, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tx_telefono_fijo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.tx_celular, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tx_email, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_notas_varias, 0)
        Me.Controls.SetChildIndex(Me.tx_id_tercero, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.dg_puntos_entrega, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tx_nombre_contacto, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.bt_nuevo_punto_entrega, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_puntos_entrega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tx_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cm_ciudad As System.Windows.Forms.ComboBox
    Friend WithEvents tx_telefono_fijo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_celular As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tx_email As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tx_notas_varias As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tx_id_tercero As System.Windows.Forms.TextBox
    Friend WithEvents dg_puntos_entrega As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tx_nombre_contacto As TextBox
    Friend WithEvents bt_nuevo_punto_entrega As Button
    Friend WithEvents dgocell_id As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_ciudad As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_direccion As DataGridViewTextBoxColumn
    Friend WithEvents dg_imgcell_editar As DataGridViewImageColumn
End Class
