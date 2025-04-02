<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_0100_reportar_falla_maquina
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tx_estructura = New System.Windows.Forms.TextBox()
        Me.tx_modo_efecto_falla = New System.Windows.Forms.TextBox()
        Me.bt_grabar = New System.Windows.Forms.Button()
        Me.dtp_fecha_ocurrencia = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cm_responsable = New System.Windows.Forms.ComboBox()
        Me.dtp_fecha_cierre_correccion = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tx_anotacion = New System.Windows.Forms.TextBox()
        Me.tx_id_accion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gb_soportes_falla = New System.Windows.Forms.GroupBox()
        Me.bt_nuevo_soporte = New System.Windows.Forms.Button()
        Me.bt_ver_archivos_asociados = New System.Windows.Forms.Button()
        Me.lb_total_soportes = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.bt_fecha_ocurrencia = New System.Windows.Forms.Button()
        Me.bt_f_cierre_correccion = New System.Windows.Forms.Button()
        Me.lb_f_inicio = New System.Windows.Forms.Label()
        Me.lb_f_correccion = New System.Windows.Forms.Label()
        Me.bt_gestionar = New System.Windows.Forms.Button()
        Me.cm_fuente_accion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bt_cambiar_infraestructura = New System.Windows.Forms.Button()
        Me.bt_informe = New System.Windows.Forms.Button()
        Me.cm_mef = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tx_MEF = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cm_razon_social = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cm_nit = New System.Windows.Forms.ComboBox()
        Me.bt_rel_items = New System.Windows.Forms.Button()
        Me.cm_subfuente_accion = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_soportes_falla.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_mi_marca
        '
        Me.lb_mi_marca.Location = New System.Drawing.Point(706, 9)
        '
        'lb_fecha
        '
        Me.lb_fecha.Location = New System.Drawing.Point(707, 36)
        Me.lb_fecha.Size = New System.Drawing.Size(72, 16)
        Me.lb_fecha.Text = "2014/02/22"
        '
        'll_linea1
        '
        Me.ll_linea1.Size = New System.Drawing.Size(616, 6)
        '
        'lb_titulo
        '
        Me.lb_titulo.Size = New System.Drawing.Size(572, 32)
        Me.lb_titulo.Text = "Registro de Falla en Infraestructura o Equipo"
        '
        'lb_diseñador_programa
        '
        Me.lb_diseñador_programa.Location = New System.Drawing.Point(0, 537)
        '
        'bt_salir
        '
        Me.bt_salir.Location = New System.Drawing.Point(323, 487)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(283, 16)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Modo o Efecto en el que la falla se  manifiesta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 404)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 16)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Fecha y Hora Inicio Falla:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 16)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Equipo o Infraestructura:"
        '
        'tx_estructura
        '
        Me.tx_estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_estructura.Location = New System.Drawing.Point(196, 193)
        Me.tx_estructura.Name = "tx_estructura"
        Me.tx_estructura.Size = New System.Drawing.Size(561, 22)
        Me.tx_estructura.TabIndex = 0
        '
        'tx_modo_efecto_falla
        '
        Me.tx_modo_efecto_falla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_modo_efecto_falla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_modo_efecto_falla.Location = New System.Drawing.Point(15, 240)
        Me.tx_modo_efecto_falla.Multiline = True
        Me.tx_modo_efecto_falla.Name = "tx_modo_efecto_falla"
        Me.tx_modo_efecto_falla.Size = New System.Drawing.Size(742, 69)
        Me.tx_modo_efecto_falla.TabIndex = 5
        '
        'bt_grabar
        '
        Me.bt_grabar.BackgroundImage = Global.camocontrol.My.Resources.Resources.GRABAR2
        Me.bt_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_grabar.Location = New System.Drawing.Point(378, 487)
        Me.bt_grabar.Name = "bt_grabar"
        Me.bt_grabar.Size = New System.Drawing.Size(49, 38)
        Me.bt_grabar.TabIndex = 74
        Me.bt_grabar.UseVisualStyleBackColor = True
        '
        'dtp_fecha_ocurrencia
        '
        Me.dtp_fecha_ocurrencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_ocurrencia.Location = New System.Drawing.Point(45, 423)
        Me.dtp_fecha_ocurrencia.Name = "dtp_fecha_ocurrencia"
        Me.dtp_fecha_ocurrencia.Size = New System.Drawing.Size(226, 22)
        Me.dtp_fecha_ocurrencia.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 451)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Receptor:"
        '
        'cm_responsable
        '
        Me.cm_responsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_responsable.FormattingEnabled = True
        Me.cm_responsable.Location = New System.Drawing.Point(88, 448)
        Me.cm_responsable.Name = "cm_responsable"
        Me.cm_responsable.Size = New System.Drawing.Size(350, 24)
        Me.cm_responsable.TabIndex = 79
        '
        'dtp_fecha_cierre_correccion
        '
        Me.dtp_fecha_cierre_correccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_cierre_correccion.Location = New System.Drawing.Point(326, 423)
        Me.dtp_fecha_cierre_correccion.Name = "dtp_fecha_cierre_correccion"
        Me.dtp_fecha_cierre_correccion.Size = New System.Drawing.Size(226, 22)
        Me.dtp_fecha_cierre_correccion.TabIndex = 81
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(294, 404)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(193, 16)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Fecha y Hora Correccion Falla:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 312)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Anotacion:"
        '
        'tx_anotacion
        '
        Me.tx_anotacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tx_anotacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_anotacion.Location = New System.Drawing.Point(15, 331)
        Me.tx_anotacion.Multiline = True
        Me.tx_anotacion.Name = "tx_anotacion"
        Me.tx_anotacion.Size = New System.Drawing.Size(742, 69)
        Me.tx_anotacion.TabIndex = 6
        '
        'tx_id_accion
        '
        Me.tx_id_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_id_accion.Location = New System.Drawing.Point(91, 62)
        Me.tx_id_accion.Name = "tx_id_accion"
        Me.tx_id_accion.Size = New System.Drawing.Size(72, 22)
        Me.tx_id_accion.TabIndex = 130
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 16)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Falla #:"
        '
        'gb_soportes_falla
        '
        Me.gb_soportes_falla.Controls.Add(Me.bt_nuevo_soporte)
        Me.gb_soportes_falla.Controls.Add(Me.bt_ver_archivos_asociados)
        Me.gb_soportes_falla.Controls.Add(Me.lb_total_soportes)
        Me.gb_soportes_falla.Controls.Add(Me.Label19)
        Me.gb_soportes_falla.Controls.Add(Me.Label24)
        Me.gb_soportes_falla.Location = New System.Drawing.Point(509, 449)
        Me.gb_soportes_falla.Name = "gb_soportes_falla"
        Me.gb_soportes_falla.Size = New System.Drawing.Size(248, 76)
        Me.gb_soportes_falla.TabIndex = 278
        Me.gb_soportes_falla.TabStop = False
        Me.gb_soportes_falla.Text = "Archivos Soporte Falla:"
        '
        'bt_nuevo_soporte
        '
        Me.bt_nuevo_soporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_nuevo_soporte.Image = Global.camocontrol.My.Resources.Resources.carpeta2
        Me.bt_nuevo_soporte.Location = New System.Drawing.Point(6, 19)
        Me.bt_nuevo_soporte.Name = "bt_nuevo_soporte"
        Me.bt_nuevo_soporte.Size = New System.Drawing.Size(50, 51)
        Me.bt_nuevo_soporte.TabIndex = 170
        Me.bt_nuevo_soporte.UseVisualStyleBackColor = True
        '
        'bt_ver_archivos_asociados
        '
        Me.bt_ver_archivos_asociados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ver_archivos_asociados.Image = Global.camocontrol.My.Resources.Resources.icono_lupa
        Me.bt_ver_archivos_asociados.Location = New System.Drawing.Point(62, 19)
        Me.bt_ver_archivos_asociados.Name = "bt_ver_archivos_asociados"
        Me.bt_ver_archivos_asociados.Size = New System.Drawing.Size(50, 51)
        Me.bt_ver_archivos_asociados.TabIndex = 171
        Me.bt_ver_archivos_asociados.UseVisualStyleBackColor = True
        '
        'lb_total_soportes
        '
        Me.lb_total_soportes.AutoSize = True
        Me.lb_total_soportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_soportes.Location = New System.Drawing.Point(201, 35)
        Me.lb_total_soportes.Name = "lb_total_soportes"
        Me.lb_total_soportes.Size = New System.Drawing.Size(29, 31)
        Me.lb_total_soportes.TabIndex = 172
        Me.lb_total_soportes.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(118, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 20)
        Me.Label19.TabIndex = 173
        Me.Label19.Text = "Total"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(118, 46)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(78, 20)
        Me.Label24.TabIndex = 174
        Me.Label24.Text = "Soportes:"
        '
        'bt_fecha_ocurrencia
        '
        Me.bt_fecha_ocurrencia.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_fecha_ocurrencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_fecha_ocurrencia.Location = New System.Drawing.Point(16, 422)
        Me.bt_fecha_ocurrencia.Name = "bt_fecha_ocurrencia"
        Me.bt_fecha_ocurrencia.Size = New System.Drawing.Size(23, 23)
        Me.bt_fecha_ocurrencia.TabIndex = 279
        Me.bt_fecha_ocurrencia.UseVisualStyleBackColor = True
        '
        'bt_f_cierre_correccion
        '
        Me.bt_f_cierre_correccion.BackgroundImage = Global.camocontrol.My.Resources.Resources.icono_calendario
        Me.bt_f_cierre_correccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_f_cierre_correccion.Location = New System.Drawing.Point(297, 422)
        Me.bt_f_cierre_correccion.Name = "bt_f_cierre_correccion"
        Me.bt_f_cierre_correccion.Size = New System.Drawing.Size(23, 23)
        Me.bt_f_cierre_correccion.TabIndex = 280
        Me.bt_f_cierre_correccion.UseVisualStyleBackColor = True
        '
        'lb_f_inicio
        '
        Me.lb_f_inicio.AutoSize = True
        Me.lb_f_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_f_inicio.Location = New System.Drawing.Point(45, 428)
        Me.lb_f_inicio.Name = "lb_f_inicio"
        Me.lb_f_inicio.Size = New System.Drawing.Size(82, 16)
        Me.lb_f_inicio.TabIndex = 281
        Me.lb_f_inicio.Text = "No Definida."
        '
        'lb_f_correccion
        '
        Me.lb_f_correccion.AutoSize = True
        Me.lb_f_correccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_f_correccion.Location = New System.Drawing.Point(326, 429)
        Me.lb_f_correccion.Name = "lb_f_correccion"
        Me.lb_f_correccion.Size = New System.Drawing.Size(82, 16)
        Me.lb_f_correccion.TabIndex = 282
        Me.lb_f_correccion.Text = "No Definida."
        '
        'bt_gestionar
        '
        Me.bt_gestionar.Location = New System.Drawing.Point(169, 62)
        Me.bt_gestionar.Name = "bt_gestionar"
        Me.bt_gestionar.Size = New System.Drawing.Size(75, 23)
        Me.bt_gestionar.TabIndex = 283
        Me.bt_gestionar.Text = "Gestionar"
        Me.bt_gestionar.UseVisualStyleBackColor = True
        '
        'cm_fuente_accion
        '
        Me.cm_fuente_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_fuente_accion.FormattingEnabled = True
        Me.cm_fuente_accion.Location = New System.Drawing.Point(169, 113)
        Me.cm_fuente_accion.Name = "cm_fuente_accion"
        Me.cm_fuente_accion.Size = New System.Drawing.Size(588, 24)
        Me.cm_fuente_accion.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 16)
        Me.Label7.TabIndex = 288
        Me.Label7.Text = "Fuente:"
        '
        'bt_cambiar_infraestructura
        '
        Me.bt_cambiar_infraestructura.BackgroundImage = Global.camocontrol.My.Resources.Resources.cargarplano
        Me.bt_cambiar_infraestructura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cambiar_infraestructura.Location = New System.Drawing.Point(169, 194)
        Me.bt_cambiar_infraestructura.Name = "bt_cambiar_infraestructura"
        Me.bt_cambiar_infraestructura.Size = New System.Drawing.Size(21, 22)
        Me.bt_cambiar_infraestructura.TabIndex = 1
        Me.bt_cambiar_infraestructura.UseVisualStyleBackColor = True
        '
        'bt_informe
        '
        Me.bt_informe.Image = Global.camocontrol.My.Resources.Resources.articles
        Me.bt_informe.Location = New System.Drawing.Point(268, 489)
        Me.bt_informe.Name = "bt_informe"
        Me.bt_informe.Size = New System.Drawing.Size(49, 38)
        Me.bt_informe.TabIndex = 292
        Me.bt_informe.UseVisualStyleBackColor = True
        '
        'cm_mef
        '
        Me.cm_mef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_mef.FormattingEnabled = True
        Me.cm_mef.Location = New System.Drawing.Point(225, 166)
        Me.cm_mef.Name = "cm_mef"
        Me.cm_mef.Size = New System.Drawing.Size(532, 24)
        Me.cm_mef.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 16)
        Me.Label9.TabIndex = 293
        Me.Label9.Text = "Modo o Efecto de Falla:"
        '
        'tx_MEF
        '
        Me.tx_MEF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_MEF.Location = New System.Drawing.Point(169, 166)
        Me.tx_MEF.Name = "tx_MEF"
        Me.tx_MEF.Size = New System.Drawing.Size(50, 22)
        Me.tx_MEF.TabIndex = 3
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(13, 90)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(140, 16)
        Me.Label31.TabIndex = 296
        Me.Label31.Text = "Tercero Relacionado:"
        '
        'cm_razon_social
        '
        Me.cm_razon_social.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_razon_social.FormattingEnabled = True
        Me.cm_razon_social.Location = New System.Drawing.Point(169, 87)
        Me.cm_razon_social.Name = "cm_razon_social"
        Me.cm_razon_social.Size = New System.Drawing.Size(350, 24)
        Me.cm_razon_social.TabIndex = 297
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(534, 90)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(70, 16)
        Me.Label32.TabIndex = 298
        Me.Label32.Text = "C.C. / NIT :"
        '
        'cm_nit
        '
        Me.cm_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_nit.FormattingEnabled = True
        Me.cm_nit.Location = New System.Drawing.Point(606, 87)
        Me.cm_nit.Name = "cm_nit"
        Me.cm_nit.Size = New System.Drawing.Size(151, 24)
        Me.cm_nit.TabIndex = 299
        '
        'bt_rel_items
        '
        Me.bt_rel_items.Location = New System.Drawing.Point(631, 403)
        Me.bt_rel_items.Name = "bt_rel_items"
        Me.bt_rel_items.Size = New System.Drawing.Size(126, 41)
        Me.bt_rel_items.TabIndex = 300
        Me.bt_rel_items.Text = "Relacionar Items / Productos"
        Me.bt_rel_items.UseVisualStyleBackColor = True
        '
        'cm_subfuente_accion
        '
        Me.cm_subfuente_accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm_subfuente_accion.FormattingEnabled = True
        Me.cm_subfuente_accion.Location = New System.Drawing.Point(169, 139)
        Me.cm_subfuente_accion.Name = "cm_subfuente_accion"
        Me.cm_subfuente_accion.Size = New System.Drawing.Size(588, 24)
        Me.cm_subfuente_accion.TabIndex = 301
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 16)
        Me.Label10.TabIndex = 302
        Me.Label10.Text = "Sub Fuente:"
        '
        'fm_0100_reportar_falla_maquina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(785, 551)
        Me.Controls.Add(Me.cm_subfuente_accion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.bt_rel_items)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.cm_razon_social)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.cm_nit)
        Me.Controls.Add(Me.tx_MEF)
        Me.Controls.Add(Me.cm_mef)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.bt_informe)
        Me.Controls.Add(Me.bt_cambiar_infraestructura)
        Me.Controls.Add(Me.cm_fuente_accion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.bt_gestionar)
        Me.Controls.Add(Me.lb_f_correccion)
        Me.Controls.Add(Me.lb_f_inicio)
        Me.Controls.Add(Me.bt_f_cierre_correccion)
        Me.Controls.Add(Me.bt_fecha_ocurrencia)
        Me.Controls.Add(Me.gb_soportes_falla)
        Me.Controls.Add(Me.tx_id_accion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtp_fecha_cierre_correccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cm_responsable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_fecha_ocurrencia)
        Me.Controls.Add(Me.bt_grabar)
        Me.Controls.Add(Me.tx_anotacion)
        Me.Controls.Add(Me.tx_modo_efecto_falla)
        Me.Controls.Add(Me.tx_estructura)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "fm_0100_reportar_falla_maquina"
        Me.Tag = "|"
        Me.Text = "Reporte de Falla"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.tx_estructura, 0)
        Me.Controls.SetChildIndex(Me.tx_modo_efecto_falla, 0)
        Me.Controls.SetChildIndex(Me.tx_anotacion, 0)
        Me.Controls.SetChildIndex(Me.bt_grabar, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_ocurrencia, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cm_responsable, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtp_fecha_cierre_correccion, 0)
        Me.Controls.SetChildIndex(Me.lb_titulo, 0)
        Me.Controls.SetChildIndex(Me.ll_linea1, 0)
        Me.Controls.SetChildIndex(Me.lb_fecha, 0)
        Me.Controls.SetChildIndex(Me.lb_mi_marca, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.lb_diseñador_programa, 0)
        Me.Controls.SetChildIndex(Me.bt_salir, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.tx_id_accion, 0)
        Me.Controls.SetChildIndex(Me.gb_soportes_falla, 0)
        Me.Controls.SetChildIndex(Me.bt_fecha_ocurrencia, 0)
        Me.Controls.SetChildIndex(Me.bt_f_cierre_correccion, 0)
        Me.Controls.SetChildIndex(Me.lb_f_inicio, 0)
        Me.Controls.SetChildIndex(Me.lb_f_correccion, 0)
        Me.Controls.SetChildIndex(Me.bt_gestionar, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cm_fuente_accion, 0)
        Me.Controls.SetChildIndex(Me.bt_cambiar_infraestructura, 0)
        Me.Controls.SetChildIndex(Me.bt_informe, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.cm_mef, 0)
        Me.Controls.SetChildIndex(Me.tx_MEF, 0)
        Me.Controls.SetChildIndex(Me.cm_nit, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.cm_razon_social, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.bt_rel_items, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cm_subfuente_accion, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_soportes_falla.ResumeLayout(False)
        Me.gb_soportes_falla.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tx_estructura As System.Windows.Forms.TextBox
    Friend WithEvents tx_modo_efecto_falla As System.Windows.Forms.TextBox
    Friend WithEvents bt_grabar As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_ocurrencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cm_responsable As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha_cierre_correccion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tx_anotacion As System.Windows.Forms.TextBox
    Friend WithEvents tx_id_accion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gb_soportes_falla As System.Windows.Forms.GroupBox
    Friend WithEvents bt_nuevo_soporte As System.Windows.Forms.Button
    Friend WithEvents bt_ver_archivos_asociados As System.Windows.Forms.Button
    Friend WithEvents lb_total_soportes As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents bt_fecha_ocurrencia As System.Windows.Forms.Button
    Friend WithEvents bt_f_cierre_correccion As System.Windows.Forms.Button
    Friend WithEvents lb_f_inicio As System.Windows.Forms.Label
    Friend WithEvents lb_f_correccion As System.Windows.Forms.Label
    Friend WithEvents bt_gestionar As System.Windows.Forms.Button
    Friend WithEvents cm_fuente_accion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bt_cambiar_infraestructura As Button
    Friend WithEvents bt_informe As Button
    Friend WithEvents cm_mef As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tx_MEF As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents cm_razon_social As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents cm_nit As ComboBox
    Friend WithEvents bt_rel_items As Button
    Friend WithEvents cm_subfuente_accion As ComboBox
    Friend WithEvents Label10 As Label
End Class
