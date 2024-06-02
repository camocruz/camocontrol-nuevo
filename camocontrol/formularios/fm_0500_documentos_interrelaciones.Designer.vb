<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0500_documentos_interrelaciones
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
        Me.dg_referenciados = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_documento_referenciado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_documento_referenciado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cm_codigo_documento = New System.Windows.Forms.ComboBox()
        Me.tx_id_documento_relacion = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.bt_eliminar_relacion = New System.Windows.Forms.Button()
        Me.bt_referenciado = New System.Windows.Forms.Button()
        Me.bt_referenciador = New System.Windows.Forms.Button()
        Me.dg_referenciador = New System.Windows.Forms.DataGridView()
        Me.dgocell_id_documento_referenciador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgocell_documento_referenciador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tx_titulo_documento = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_referenciados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_referenciador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2018/09/22"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(389, 32)
        Me.lb_titulo.Text = "Interrelaciones del Documento"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 462)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(331, 426)
        '
        'dg_referenciados
        '
        Me.dg_referenciados.AllowUserToAddRows = False
        Me.dg_referenciados.AllowUserToDeleteRows = False
        Me.dg_referenciados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_referenciados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_documento_referenciado, Me.dgocell_documento_referenciado})
        Me.dg_referenciados.Location = New System.Drawing.Point(13, 83)
        Me.dg_referenciados.Name = "dg_referenciados"
        Me.dg_referenciados.ReadOnly = True
        Me.dg_referenciados.Size = New System.Drawing.Size(350, 223)
        Me.dg_referenciados.TabIndex = 63
        '
        'dgocell_id_documento_referenciado
        '
        Me.dgocell_id_documento_referenciado.HeaderText = "id_docum"
        Me.dgocell_id_documento_referenciado.Name = "dgocell_id_documento_referenciado"
        Me.dgocell_id_documento_referenciado.ReadOnly = True
        Me.dgocell_id_documento_referenciado.Visible = False
        '
        'dgocell_documento_referenciado
        '
        Me.dgocell_documento_referenciado.HeaderText = "Documento"
        Me.dgocell_documento_referenciado.Name = "dgocell_documento_referenciado"
        Me.dgocell_documento_referenciado.ReadOnly = True
        Me.dgocell_documento_referenciado.Width = 300
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Referenciados:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(379, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 251
        Me.Label1.Text = "Referenciadores:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 351)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 254
        Me.Label3.Text = "Documento:"
        '
        'cm_codigo_documento
        '
        Me.cm_codigo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_codigo_documento.FormattingEnabled = True
        Me.cm_codigo_documento.Location = New System.Drawing.Point(123, 343)
        Me.cm_codigo_documento.Name = "cm_codigo_documento"
        Me.cm_codigo_documento.Size = New System.Drawing.Size(549, 24)
        Me.cm_codigo_documento.TabIndex = 255
        '
        'tx_id_documento_relacion
        '
        Me.tx_id_documento_relacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_documento_relacion.Location = New System.Drawing.Point(123, 315)
        Me.tx_id_documento_relacion.Name = "tx_id_documento_relacion"
        Me.tx_id_documento_relacion.ReadOnly = True
        Me.tx_id_documento_relacion.Size = New System.Drawing.Size(48, 22)
        Me.tx_id_documento_relacion.TabIndex = 253
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(13, 321)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 16)
        Me.Label37.TabIndex = 252
        Me.Label37.Text = "id_documento:"
        '
        'bt_eliminar_relacion
        '
        Me.bt_eliminar_relacion.Image = Global.camocontrol.My.Resources.Resources.eliminar
        Me.bt_eliminar_relacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_eliminar_relacion.Location = New System.Drawing.Point(678, 314)
        Me.bt_eliminar_relacion.Name = "bt_eliminar_relacion"
        Me.bt_eliminar_relacion.Size = New System.Drawing.Size(52, 57)
        Me.bt_eliminar_relacion.TabIndex = 256
        Me.bt_eliminar_relacion.Text = "Borrar"
        Me.bt_eliminar_relacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_eliminar_relacion.UseVisualStyleBackColor = True
        '
        'bt_referenciado
        '
        Me.bt_referenciado.Image = Global.camocontrol.My.Resources.Resources.cargaremi
        Me.bt_referenciado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_referenciado.Location = New System.Drawing.Point(123, 369)
        Me.bt_referenciado.Name = "bt_referenciado"
        Me.bt_referenciado.Size = New System.Drawing.Size(97, 57)
        Me.bt_referenciado.TabIndex = 257
        Me.bt_referenciado.Text = "Referenciado"
        Me.bt_referenciado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_referenciado.UseVisualStyleBackColor = True
        '
        'bt_referenciador
        '
        Me.bt_referenciador.Image = Global.camocontrol.My.Resources.Resources.espina_pescado
        Me.bt_referenciador.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_referenciador.Location = New System.Drawing.Point(223, 368)
        Me.bt_referenciador.Name = "bt_referenciador"
        Me.bt_referenciador.Size = New System.Drawing.Size(97, 57)
        Me.bt_referenciador.TabIndex = 258
        Me.bt_referenciador.Text = "Referenciador"
        Me.bt_referenciador.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_referenciador.UseVisualStyleBackColor = True
        '
        'dg_referenciador
        '
        Me.dg_referenciador.AllowUserToAddRows = False
        Me.dg_referenciador.AllowUserToDeleteRows = False
        Me.dg_referenciador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_referenciador.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgocell_id_documento_referenciador, Me.dgocell_documento_referenciador})
        Me.dg_referenciador.Location = New System.Drawing.Point(380, 84)
        Me.dg_referenciador.Name = "dg_referenciador"
        Me.dg_referenciador.ReadOnly = True
        Me.dg_referenciador.Size = New System.Drawing.Size(350, 223)
        Me.dg_referenciador.TabIndex = 259
        '
        'dgocell_id_documento_referenciador
        '
        Me.dgocell_id_documento_referenciador.HeaderText = "id_docum"
        Me.dgocell_id_documento_referenciador.Name = "dgocell_id_documento_referenciador"
        Me.dgocell_id_documento_referenciador.ReadOnly = True
        Me.dgocell_id_documento_referenciador.Visible = False
        '
        'dgocell_documento_referenciador
        '
        Me.dgocell_documento_referenciador.HeaderText = "Documento"
        Me.dgocell_documento_referenciador.Name = "dgocell_documento_referenciador"
        Me.dgocell_documento_referenciador.ReadOnly = True
        Me.dgocell_documento_referenciador.Width = 300
        '
        'tx_titulo_documento
        '
        Me.tx_titulo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_titulo_documento.Location = New System.Drawing.Point(177, 315)
        Me.tx_titulo_documento.Name = "tx_titulo_documento"
        Me.tx_titulo_documento.ReadOnly = True
        Me.tx_titulo_documento.Size = New System.Drawing.Size(495, 22)
        Me.tx_titulo_documento.TabIndex = 260
        '
        'fm_0500_documentos_interrelaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(742, 476)
        Me.Controls.Add(Me.tx_titulo_documento)
        Me.Controls.Add(Me.dg_referenciador)
        Me.Controls.Add(Me.bt_referenciador)
        Me.Controls.Add(Me.bt_referenciado)
        Me.Controls.Add(Me.bt_eliminar_relacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cm_codigo_documento)
        Me.Controls.Add(Me.tx_id_documento_relacion)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dg_referenciados)
        Me.Name = "fm_0500_documentos_interrelaciones"
        Me.Text = "Interrelaciones"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.dg_referenciados, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.tx_id_documento_relacion, 0)
        Me.Controls.SetChildIndex(Me.cm_codigo_documento, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.bt_eliminar_relacion, 0)
        Me.Controls.SetChildIndex(Me.bt_referenciado, 0)
        Me.Controls.SetChildIndex(Me.bt_referenciador, 0)
        Me.Controls.SetChildIndex(Me.dg_referenciador, 0)
        Me.Controls.SetChildIndex(Me.tx_titulo_documento, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_referenciados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_referenciador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dg_referenciados As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cm_codigo_documento As ComboBox
    Friend WithEvents tx_id_documento_relacion As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents bt_eliminar_relacion As Button
    Friend WithEvents bt_referenciado As Button
    Friend WithEvents bt_referenciador As Button
    Friend WithEvents dg_referenciador As DataGridView
    Friend WithEvents dgocell_id_documento_referenciador As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_documento_referenciador As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_id_documento_referenciado As DataGridViewTextBoxColumn
    Friend WithEvents dgocell_documento_referenciado As DataGridViewTextBoxColumn
    Friend WithEvents tx_titulo_documento As TextBox
End Class
