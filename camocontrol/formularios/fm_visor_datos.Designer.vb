<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_visor_datos
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
        Me.components = New System.ComponentModel.Container()
        Me.tx_registro_seleccionado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_total_registros = New System.Windows.Forms.Label()
        Me.bt_quitar_filtro = New System.Windows.Forms.Button()
        Me.bt_filtrar = New System.Windows.Forms.Button()
        Me.tx_valor_campo = New System.Windows.Forms.TextBox()
        Me.cm_operadores_filtro = New System.Windows.Forms.ComboBox()
        Me.tx_nombre_campo = New System.Windows.Forms.TextBox()
        Me.dg_datos = New System.Windows.Forms.DataGridView()
        Me.bt_recargar_todo = New System.Windows.Forms.Button()
        Me.bt_nuevo = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.bt_exportar_excel = New System.Windows.Forms.Button()
        Me.bt_exportar_csv = New System.Windows.Forms.Button()
        Me.bt_checkbox = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_fecha
        '
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/02/25"
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(191, 32)
        Me.lb_titulo.Text = "Visor de Datos"
        '
        'bt_salir
        '
        Me.bt_salir.TabIndex = 0
        '
        'tx_registro_seleccionado
        '
        Me.tx_registro_seleccionado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_registro_seleccionado.Location = New System.Drawing.Point(12, 378)
        Me.tx_registro_seleccionado.Name = "tx_registro_seleccionado"
        Me.tx_registro_seleccionado.ReadOnly = True
        Me.tx_registro_seleccionado.Size = New System.Drawing.Size(57, 20)
        Me.tx_registro_seleccionado.TabIndex = 72
        Me.tx_registro_seleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(75, 381)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "de"
        '
        'lb_total_registros
        '
        Me.lb_total_registros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lb_total_registros.AutoSize = True
        Me.lb_total_registros.Location = New System.Drawing.Point(100, 381)
        Me.lb_total_registros.Name = "lb_total_registros"
        Me.lb_total_registros.Size = New System.Drawing.Size(39, 13)
        Me.lb_total_registros.TabIndex = 70
        Me.lb_total_registros.Text = "Label1"
        '
        'bt_quitar_filtro
        '
        Me.bt_quitar_filtro.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargarplano
        Me.bt_quitar_filtro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_quitar_filtro.Location = New System.Drawing.Point(592, 61)
        Me.bt_quitar_filtro.Name = "bt_quitar_filtro"
        Me.bt_quitar_filtro.Size = New System.Drawing.Size(45, 38)
        Me.bt_quitar_filtro.TabIndex = 69
        Me.bt_quitar_filtro.UseVisualStyleBackColor = True
        '
        'bt_filtrar
        '
        Me.bt_filtrar.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_filtrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_filtrar.Location = New System.Drawing.Point(541, 62)
        Me.bt_filtrar.Name = "bt_filtrar"
        Me.bt_filtrar.Size = New System.Drawing.Size(45, 38)
        Me.bt_filtrar.TabIndex = 68
        Me.bt_filtrar.UseVisualStyleBackColor = True
        '
        'tx_valor_campo
        '
        Me.tx_valor_campo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_valor_campo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_valor_campo.Location = New System.Drawing.Point(338, 68)
        Me.tx_valor_campo.Multiline = True
        Me.tx_valor_campo.Name = "tx_valor_campo"
        Me.tx_valor_campo.Size = New System.Drawing.Size(191, 24)
        Me.tx_valor_campo.TabIndex = 67
        '
        'cm_operadores_filtro
        '
        Me.cm_operadores_filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_operadores_filtro.FormattingEnabled = True
        Me.cm_operadores_filtro.Items.AddRange(New Object() {"Contenga", "Igual", "Inicie Con", "Diferente", "Menor", "Menor o Igual", "Mayor", "Mayor o Igual"})
        Me.cm_operadores_filtro.Location = New System.Drawing.Point(212, 68)
        Me.cm_operadores_filtro.Name = "cm_operadores_filtro"
        Me.cm_operadores_filtro.Size = New System.Drawing.Size(121, 24)
        Me.cm_operadores_filtro.TabIndex = 66
        '
        'tx_nombre_campo
        '
        Me.tx_nombre_campo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_nombre_campo.Location = New System.Drawing.Point(14, 70)
        Me.tx_nombre_campo.Multiline = True
        Me.tx_nombre_campo.Name = "tx_nombre_campo"
        Me.tx_nombre_campo.ReadOnly = True
        Me.tx_nombre_campo.Size = New System.Drawing.Size(191, 22)
        Me.tx_nombre_campo.TabIndex = 65
        '
        'dg_datos
        '
        Me.dg_datos.AllowUserToAddRows = False
        Me.dg_datos.AllowUserToDeleteRows = False
        Me.dg_datos.AllowUserToOrderColumns = True
        Me.dg_datos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_datos.Location = New System.Drawing.Point(12, 106)
        Me.dg_datos.Name = "dg_datos"
        Me.dg_datos.ReadOnly = True
        Me.dg_datos.Size = New System.Drawing.Size(718, 266)
        Me.dg_datos.TabIndex = 1
        '
        'bt_recargar_todo
        '
        Me.bt_recargar_todo.BackgroundImage = Global.camocontrol.My.Resources.Resources.actualizar
        Me.bt_recargar_todo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_recargar_todo.Location = New System.Drawing.Point(643, 62)
        Me.bt_recargar_todo.Name = "bt_recargar_todo"
        Me.bt_recargar_todo.Size = New System.Drawing.Size(45, 38)
        Me.bt_recargar_todo.TabIndex = 73
        Me.bt_recargar_todo.UseVisualStyleBackColor = True
        '
        'bt_nuevo
        '
        Me.bt_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_nuevo.Image = Global.camocontrol.My.Resources.Resources.nuevo2
        Me.bt_nuevo.Location = New System.Drawing.Point(386, 408)
        Me.bt_nuevo.Name = "bt_nuevo"
        Me.bt_nuevo.Size = New System.Drawing.Size(49, 38)
        Me.bt_nuevo.TabIndex = 89
        Me.bt_nuevo.UseVisualStyleBackColor = True
        '
        'bt_exportar_excel
        '
        Me.bt_exportar_excel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_exportar_excel.BackgroundImage = Global.camocontrol.My.Resources.Resources.excel2
        Me.bt_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_exportar_excel.Location = New System.Drawing.Point(451, 408)
        Me.bt_exportar_excel.Name = "bt_exportar_excel"
        Me.bt_exportar_excel.Size = New System.Drawing.Size(47, 36)
        Me.bt_exportar_excel.TabIndex = 90
        Me.bt_exportar_excel.UseVisualStyleBackColor = True
        '
        'bt_exportar_csv
        '
        Me.bt_exportar_csv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_exportar_csv.BackgroundImage = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_exportar_csv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_exportar_csv.Image = Global.camocontrol.My.Resources.Resources.formato_csv
        Me.bt_exportar_csv.Location = New System.Drawing.Point(504, 409)
        Me.bt_exportar_csv.Name = "bt_exportar_csv"
        Me.bt_exportar_csv.Size = New System.Drawing.Size(47, 36)
        Me.bt_exportar_csv.TabIndex = 91
        Me.bt_exportar_csv.UseVisualStyleBackColor = True
        '
        'bt_checkbox
        '
        Me.bt_checkbox.Image = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_checkbox.Location = New System.Drawing.Point(694, 62)
        Me.bt_checkbox.Name = "bt_checkbox"
        Me.bt_checkbox.Size = New System.Drawing.Size(45, 38)
        Me.bt_checkbox.TabIndex = 92
        Me.bt_checkbox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(335, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Buscar: Ctrl+B"
        '
        'fm_visor_datos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(742, 458)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bt_checkbox)
        Me.Controls.Add(Me.bt_exportar_csv)
        Me.Controls.Add(Me.bt_exportar_excel)
        Me.Controls.Add(Me.bt_nuevo)
        Me.Controls.Add(Me.bt_recargar_todo)
        Me.Controls.Add(Me.tx_registro_seleccionado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lb_total_registros)
        Me.Controls.Add(Me.bt_quitar_filtro)
        Me.Controls.Add(Me.bt_filtrar)
        Me.Controls.Add(Me.tx_valor_campo)
        Me.Controls.Add(Me.cm_operadores_filtro)
        Me.Controls.Add(Me.tx_nombre_campo)
        Me.Controls.Add(Me.dg_datos)
        Me.KeyPreview = True
        Me.Name = "fm_visor_datos"
        Me.Text = "Visor de Datos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.dg_datos, 0)
        Me.Controls.SetChildIndex(Me.tx_nombre_campo, 0)
        Me.Controls.SetChildIndex(Me.cm_operadores_filtro, 0)
        Me.Controls.SetChildIndex(Me.tx_valor_campo, 0)
        Me.Controls.SetChildIndex(Me.bt_filtrar, 0)
        Me.Controls.SetChildIndex(Me.bt_quitar_filtro, 0)
        Me.Controls.SetChildIndex(Me.lb_total_registros, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tx_registro_seleccionado, 0)
        Me.Controls.SetChildIndex(Me.bt_recargar_todo, 0)
        Me.Controls.SetChildIndex(Me.bt_nuevo, 0)
        Me.Controls.SetChildIndex(Me.bt_exportar_excel, 0)
        Me.Controls.SetChildIndex(Me.bt_exportar_csv, 0)
        Me.Controls.SetChildIndex(Me.bt_checkbox, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tx_registro_seleccionado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lb_total_registros As System.Windows.Forms.Label
    Friend WithEvents bt_quitar_filtro As System.Windows.Forms.Button
    Friend WithEvents bt_filtrar As System.Windows.Forms.Button
    Friend WithEvents tx_valor_campo As System.Windows.Forms.TextBox
    Friend WithEvents cm_operadores_filtro As System.Windows.Forms.ComboBox
    Friend WithEvents tx_nombre_campo As System.Windows.Forms.TextBox
    Friend WithEvents dg_datos As System.Windows.Forms.DataGridView
    Friend WithEvents bt_recargar_todo As System.Windows.Forms.Button
    Protected Friend WithEvents bt_nuevo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents bt_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents bt_exportar_csv As Button
    Friend WithEvents bt_checkbox As Button
    Friend WithEvents Label1 As Label
End Class
