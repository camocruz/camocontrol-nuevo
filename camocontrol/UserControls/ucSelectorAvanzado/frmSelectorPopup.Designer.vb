<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectorPopup
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
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(91, 20)
        Me.lb_fecha.Text = "2026/09/12"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(129, 42)
        Me.lb_titulo.Text = "Buscar"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 410)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(441, 364)
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(70, 95)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(335, 22)
        Me.txtBuscar.TabIndex = 0
        '
        'dgDatos
        '
        Me.dgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatos.Location = New System.Drawing.Point(12, 134)
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.RowHeadersWidth = 51
        Me.dgDatos.RowTemplate.Height = 24
        Me.dgDatos.Size = New System.Drawing.Size(965, 220)
        Me.dgDatos.TabIndex = 1
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.BackgroundImage = Global.camocontrol.My.Resources.Resources.EQUIS
        Me.btnLimpiarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(411, 89)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(34, 34)
        Me.btnLimpiarFiltro.TabIndex = 65
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Buscar:"
        '
        'lblCantidad
        '
        Me.lblCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(12, 364)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(75, 16)
        Me.lblCantidad.TabIndex = 67
        Me.lblCantidad.Text = "lblCantidad"
        '
        'frmSelectorPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(989, 426)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.dgDatos)
        Me.Controls.Add(Me.txtBuscar)
        Me.Name = "frmSelectorPopup"
        Me.Text = "Buscador"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.Controls.SetChildIndex(Me.dgDatos, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiarFiltro, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblCantidad, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgDatos As DataGridView
    Friend WithEvents btnLimpiarFiltro As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCantidad As Label
End Class
