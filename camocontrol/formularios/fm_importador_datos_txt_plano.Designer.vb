<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fm_importador_datos_txt_plano
    Inherits camocontrol.FM_PLANTILLA_solo_salir

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bt_importar = New System.Windows.Forms.Button()
        Me.tx_buscador = New System.Windows.Forms.TextBox()
        Me.tx_ubicacion = New System.Windows.Forms.TextBox()
        Me.tx_formato = New System.Windows.Forms.TextBox()
        Me.tx_definicion = New System.Windows.Forms.TextBox()
        Me.bt_buscar = New System.Windows.Forms.Button()
        Me.bt_probar = New System.Windows.Forms.Button()
        Me.tx_nombre_campo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.dgw_encontrados = New System.Windows.Forms.DataGridView()
        Me.dgw_linea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgw_ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tx_archivo = New System.Windows.Forms.TextBox()
        Me.cm_tipo_datos = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_ini_long_val_traer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_lineas_futuras = New System.Windows.Forms.TextBox()
        Me.bt_armar_arreglo = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cm_configuracion = New System.Windows.Forms.ComboBox()
        Me.tx_descripcion_archivo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgw_encontrados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(746, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(747, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2018/02/17"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(656, 6)
        '
        'bt_salir
        '
        '
        'bt_importar
        '
        Me.bt_importar.Location = New System.Drawing.Point(273, 343)
        Me.bt_importar.Name = "bt_importar"
        Me.bt_importar.Size = New System.Drawing.Size(133, 56)
        Me.bt_importar.TabIndex = 63
        Me.bt_importar.Text = "Importar"
        Me.bt_importar.UseVisualStyleBackColor = True
        '
        'tx_buscador
        '
        Me.tx_buscador.Location = New System.Drawing.Point(183, 144)
        Me.tx_buscador.Name = "tx_buscador"
        Me.tx_buscador.Size = New System.Drawing.Size(100, 20)
        Me.tx_buscador.TabIndex = 64
        '
        'tx_ubicacion
        '
        Me.tx_ubicacion.Location = New System.Drawing.Point(289, 144)
        Me.tx_ubicacion.Name = "tx_ubicacion"
        Me.tx_ubicacion.Size = New System.Drawing.Size(106, 20)
        Me.tx_ubicacion.TabIndex = 65
        '
        'tx_formato
        '
        Me.tx_formato.Location = New System.Drawing.Point(401, 144)
        Me.tx_formato.Name = "tx_formato"
        Me.tx_formato.Size = New System.Drawing.Size(106, 20)
        Me.tx_formato.TabIndex = 66
        '
        'tx_definicion
        '
        Me.tx_definicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_definicion.Location = New System.Drawing.Point(77, 283)
        Me.tx_definicion.Name = "tx_definicion"
        Me.tx_definicion.Size = New System.Drawing.Size(430, 26)
        Me.tx_definicion.TabIndex = 67
        '
        'bt_buscar
        '
        Me.bt_buscar.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_buscar.Location = New System.Drawing.Point(513, 128)
        Me.bt_buscar.Name = "bt_buscar"
        Me.bt_buscar.Size = New System.Drawing.Size(65, 52)
        Me.bt_buscar.TabIndex = 68
        Me.bt_buscar.UseVisualStyleBackColor = True
        '
        'bt_probar
        '
        Me.bt_probar.Image = Global.camocontrol.My.Resources.Resources.chatarra2
        Me.bt_probar.Location = New System.Drawing.Point(676, 222)
        Me.bt_probar.Name = "bt_probar"
        Me.bt_probar.Size = New System.Drawing.Size(65, 52)
        Me.bt_probar.TabIndex = 69
        Me.bt_probar.UseVisualStyleBackColor = True
        '
        'tx_nombre_campo
        '
        Me.tx_nombre_campo.Location = New System.Drawing.Point(183, 170)
        Me.tx_nombre_campo.Name = "tx_nombre_campo"
        Me.tx_nombre_campo.Size = New System.Drawing.Size(100, 20)
        Me.tx_nombre_campo.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Nombre Campo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Val. Buscado:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(286, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Inicio; Longitud:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(398, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Formato:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(77, 317)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(430, 23)
        Me.ProgressBar1.TabIndex = 79
        '
        'dgw_encontrados
        '
        Me.dgw_encontrados.AllowUserToAddRows = False
        Me.dgw_encontrados.AllowUserToDeleteRows = False
        Me.dgw_encontrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_encontrados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgw_linea, Me.dgw_ubicacion})
        Me.dgw_encontrados.Location = New System.Drawing.Point(600, 67)
        Me.dgw_encontrados.Name = "dgw_encontrados"
        Me.dgw_encontrados.ReadOnly = True
        Me.dgw_encontrados.Size = New System.Drawing.Size(213, 149)
        Me.dgw_encontrados.TabIndex = 81
        '
        'dgw_linea
        '
        Me.dgw_linea.HeaderText = "Linea"
        Me.dgw_linea.Name = "dgw_linea"
        Me.dgw_linea.ReadOnly = True
        Me.dgw_linea.Width = 40
        '
        'dgw_ubicacion
        '
        Me.dgw_ubicacion.HeaderText = "Ubicacion"
        Me.dgw_ubicacion.Name = "dgw_ubicacion"
        Me.dgw_ubicacion.ReadOnly = True
        '
        'tx_archivo
        '
        Me.tx_archivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_archivo.Location = New System.Drawing.Point(77, 99)
        Me.tx_archivo.Name = "tx_archivo"
        Me.tx_archivo.ReadOnly = True
        Me.tx_archivo.Size = New System.Drawing.Size(430, 26)
        Me.tx_archivo.TabIndex = 82
        '
        'cm_tipo_datos
        '
        Me.cm_tipo_datos.FormattingEnabled = True
        Me.cm_tipo_datos.Items.AddRange(New Object() {"Text", "$t-numeric$", "$t-text$", "date", "SepDec0", "SepDec1"})
        Me.cm_tipo_datos.Location = New System.Drawing.Point(183, 195)
        Me.cm_tipo_datos.Name = "cm_tipo_datos"
        Me.cm_tipo_datos.Size = New System.Drawing.Size(121, 21)
        Me.cm_tipo_datos.TabIndex = 83
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(74, 198)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Formato:"
        '
        'tx_ini_long_val_traer
        '
        Me.tx_ini_long_val_traer.Location = New System.Drawing.Point(183, 222)
        Me.tx_ini_long_val_traer.Name = "tx_ini_long_val_traer"
        Me.tx_ini_long_val_traer.Size = New System.Drawing.Size(106, 20)
        Me.tx_ini_long_val_traer.TabIndex = 85
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(74, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "IniLongValorTraer"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(74, 251)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Lineas Futuras"
        '
        'tx_lineas_futuras
        '
        Me.tx_lineas_futuras.Location = New System.Drawing.Point(183, 248)
        Me.tx_lineas_futuras.Name = "tx_lineas_futuras"
        Me.tx_lineas_futuras.Size = New System.Drawing.Size(106, 20)
        Me.tx_lineas_futuras.TabIndex = 87
        Me.tx_lineas_futuras.Text = "0"
        '
        'bt_armar_arreglo
        '
        Me.bt_armar_arreglo.Image = Global.camocontrol.My.Resources.Resources.design
        Me.bt_armar_arreglo.Location = New System.Drawing.Point(513, 283)
        Me.bt_armar_arreglo.Name = "bt_armar_arreglo"
        Me.bt_armar_arreglo.Size = New System.Drawing.Size(44, 40)
        Me.bt_armar_arreglo.TabIndex = 89
        Me.bt_armar_arreglo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(398, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "# = Numero"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(398, 183)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "[A-Z] = Letras"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(398, 196)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "* = Comodin"
        '
        'cm_configuracion
        '
        Me.cm_configuracion.FormattingEnabled = True
        Me.cm_configuracion.Items.AddRange(New Object() {"Text", "$t-numeric$", "$t-text$", "date", "SepDec0", "SepDec1"})
        Me.cm_configuracion.Location = New System.Drawing.Point(183, 72)
        Me.cm_configuracion.Name = "cm_configuracion"
        Me.cm_configuracion.Size = New System.Drawing.Size(121, 21)
        Me.cm_configuracion.TabIndex = 93
        '
        'tx_descripcion_archivo
        '
        Me.tx_descripcion_archivo.Location = New System.Drawing.Point(306, 73)
        Me.tx_descripcion_archivo.Name = "tx_descripcion_archivo"
        Me.tx_descripcion_archivo.Size = New System.Drawing.Size(272, 20)
        Me.tx_descripcion_archivo.TabIndex = 94
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(77, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 95
        Me.Label11.Text = "Configuracion:"
        '
        'fm_importador_datos_txt_plano
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(825, 458)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tx_descripcion_archivo)
        Me.Controls.Add(Me.cm_configuracion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.bt_armar_arreglo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tx_lineas_futuras)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tx_ini_long_val_traer)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cm_tipo_datos)
        Me.Controls.Add(Me.tx_archivo)
        Me.Controls.Add(Me.dgw_encontrados)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tx_nombre_campo)
        Me.Controls.Add(Me.bt_probar)
        Me.Controls.Add(Me.bt_buscar)
        Me.Controls.Add(Me.tx_definicion)
        Me.Controls.Add(Me.tx_formato)
        Me.Controls.Add(Me.tx_ubicacion)
        Me.Controls.Add(Me.tx_buscador)
        Me.Controls.Add(Me.bt_importar)
        Me.Name = "fm_importador_datos_txt_plano"
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.bt_importar, 0)
        Me.Controls.SetChildIndex(Me.tx_buscador, 0)
        Me.Controls.SetChildIndex(Me.tx_ubicacion, 0)
        Me.Controls.SetChildIndex(Me.tx_formato, 0)
        Me.Controls.SetChildIndex(Me.tx_definicion, 0)
        Me.Controls.SetChildIndex(Me.bt_buscar, 0)
        Me.Controls.SetChildIndex(Me.bt_probar, 0)
        Me.Controls.SetChildIndex(Me.tx_nombre_campo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.dgw_encontrados, 0)
        Me.Controls.SetChildIndex(Me.tx_archivo, 0)
        Me.Controls.SetChildIndex(Me.cm_tipo_datos, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.tx_ini_long_val_traer, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.tx_lineas_futuras, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.bt_armar_arreglo, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cm_configuracion, 0)
        Me.Controls.SetChildIndex(Me.tx_descripcion_archivo, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgw_encontrados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bt_importar As Button
    Friend WithEvents tx_buscador As TextBox
    Friend WithEvents tx_ubicacion As TextBox
    Friend WithEvents tx_formato As TextBox
    Friend WithEvents tx_definicion As TextBox
    Friend WithEvents bt_buscar As Button
    Friend WithEvents bt_probar As Button
    Friend WithEvents tx_nombre_campo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents dgw_encontrados As DataGridView
    Friend WithEvents dgw_linea As DataGridViewTextBoxColumn
    Friend WithEvents dgw_ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents tx_archivo As TextBox
    Friend WithEvents cm_tipo_datos As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tx_ini_long_val_traer As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tx_lineas_futuras As TextBox
    Friend WithEvents bt_armar_arreglo As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cm_configuracion As ComboBox
    Friend WithEvents tx_descripcion_archivo As TextBox
    Friend WithEvents Label11 As Label
End Class
