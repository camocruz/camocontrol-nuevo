Imports System.Windows.Forms

Public Class formulario_inicio
    'Objeto para manejar la configuración Regional
    Protected oregioninfo As System.Globalization.RegionInfo

    Private vcerrar As String = "N"
    Private vf_otabla_permisos As DataTable
    Public ocontexto_form As String = ""
    Public autoriza As String = "N"
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public vlogin As String = ""
    Public vpassword As String = ""
    Public vnombreusuario As String = ""
    Public Shared vlogin2 As String = ""
    Public Shared vreporte_desp As String = ""
    Public Shared otb_controles_controlados As DataTable
    Public vg_id_cia As String '= "00000001"
    Public Shared vg_path_carg_aut As String = ""

    Public usuario_validado As String = "$ND$" 'variable usada para identificar un usuario que requiere validacion de indentidad

#Region "Metodos"

    Private Sub formulario_inicio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If vcerrar = "N" Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    'Private Sub formulario_inicio_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
    '    'Para poder desplazarme en el menustrip usando las teclas de flecha.
    '    If e.KeyCode = Keys.Down Then
    '        'MsgBox("HOLA")
    '        Me.MenuStrip.Focus()
    '        mi_salir.Select()
    '    End If
    '    'Combinacion de teclado para cerrar el formulario
    '    If e.Control + e.KeyCode = Keys.I Then
    '        'Debido a fallo en seguridad revalido permiso para uso del menu.
    '        Dim permitir As String = "N"
    '        permitir = verificar_permisos_menu(sender)
    '        If permitir = "N" Then
    '            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
    '            Exit Sub
    '        End If
    '        'Pregunta si realmente desea importar un IP del cguno
    '        Dim respuesta As String = "N"
    '        respuesta = comunes.g_mensaje_YesNo("Importar IP CG-UNO", "Desea importar una IP desde el CG-UNO?")
    '        If respuesta = "N" Then
    '            Exit Sub
    '        End If
    '        cl_importador_planos.cargar_informe_produccion_ip(vg_id_cia, vlogin)
    '    End If
    'End Sub
    'Private Sub formulario_inicio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    'MsgBox("Hola")
    'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.B) Then
    'e.Handled = False
    ' MsgBox("Hola")
    'End If
    'End Sub
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Establece la configuración Regional a "US"
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-us")
        oregioninfo = New System.Globalization.RegionInfo("us")

        'Establece el separador de Decimales para formato moneda
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        'Establece el separador de Decimales para formato numerico
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        'Establece el separador de miles para formato numerico
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        'Establece el número de Decimales para formato numerico
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalDigits = 0


        vlogin2 = vlogin
        Me.Text = My.Application.Info.Title.ToUpper + "  -  BIENVENIDO " + UCase(vnombreusuario)
        'Me.KeyPreview = True 'Para activar capturar metodos abreviados

        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        'Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        otb_controles_controlados = cl_gestion_permisos.todas_opciones_de_control 'Uso en todos los form para permisos usuario
        'cl_utilidades_datatables.visualizar_datos_visor("", "", "", "Controles Controlados", {}, otb_controles_controlados)
        'cl_utilidades_datatables.visualizar_datos_visor("", "", "", "Permisos Usuario", {}, vf_otabla_permisos)

        'informar_actividades()
        'informar_mensajes_sin_gestionar()
        'estadisticas_usuario_acciones()

        'Para controlar la apricion de los diferentes menus...
        'Me.CargarABToolStripMenuItem.Enabled = False
        'Me.mi_cargar_op.Enabled = False
        'Me.mi_cargar_remisiones.Enabled = False
        'Me.ProgramacionDespachosToolStripMenuItem.Enabled = False
        'Me.ProgramacionDespachosToolStripMenuItem.Visible = False
        'Me.mi_programacion.Visible = False
        'Me.mi_catalogos.Enabled = False
        'Me.mi_vehiculos.Visible = False
        'Me.lb_usuario.Text = "USUARIO: " + UCase(vlogin)
    End Sub
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private Function verificar_permisos_menu(ByVal menu_objet As Object)
        'Se identifico fallo de seguridad con usuario sin permisos, pero manejando rapidamente el clic sobre el menu se desbloquea
        'el menu y puede ejecutar las diferentes acciones, con esto se obliga a validar el permiso en el menu.
        Dim permitir As String = "N"
        'Si es el usuario administrador todo esta habilitado.
        If vlogin = "00000001" Then
            permitir = "S"
            Return permitir
            Exit Function
        End If

        Dim name_menu As String = menu_objet.name
        Dim orow_control_controlado As DataRow()
        orow_control_controlado = vf_otabla_permisos.Select("f0020_control='" & name_menu & "'", "")
        If orow_control_controlado.Length = 0 Then
            'Quiere decir que el control no esta definido como controlado.
            permitir = "S"
            Return permitir
            Exit Function
        End If
        Dim permiso As Boolean
        Try
            permiso = orow_control_controlado(0)("f0022_acceso")
        Catch ex As Exception
            permiso = False
        End Try

        If permiso = True Then
            permitir = "S"
            'MsgBox(permitir)
        End If
        Return permitir
    End Function

    Private Sub mi_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_salir.Click
        vcerrar = "S"
        Me.Close()
    End Sub
#End Region

#Region "Menu Catalogos"
    Private Sub mi_gestion_terceros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_gestion_terceros.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_g_terceros As New camocontrol.fm_0200_tercero
        oform_g_terceros.vf_oform_padre = Me
        oform_g_terceros.vg_id_cia = vg_id_cia
        oform_g_terceros.vg_usuario_autoriza = vlogin
        'oform_g_unid.vf_elemento_nuevo = "S"
        oform_g_terceros.Show()
    End Sub
    Private Sub mi_crear_usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_crear_usuarios.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_g_usuarios As New camocontrol.fm_0021_usuarios
        oform_g_usuarios.vf_oform_padre = Me
        oform_g_usuarios.vg_id_cia = vg_id_cia
        oform_g_usuarios.vg_usuario_autoriza = vlogin
        'oform_g_unid.vf_elemento_nuevo = "S"
        oform_g_usuarios.Show()
    End Sub
    Private Sub mi_administrar_permisos_usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_administrar_permisos_usuarios.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_g_permisos As New camocontrol.fm_0022_gestion_permisos_usuarios
        oform_g_permisos.vf_oform_padre = Me
        oform_g_permisos.vg_id_cia = vg_id_cia
        oform_g_permisos.vg_usuario_autoriza = vlogin
        'oform_g_unid.vf_elemento_nuevo = "S"
        oform_g_permisos.Show()
    End Sub
    Private Sub mi_unidad_medicion_basica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_unidad_medicion_basica.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_g_unid As New camocontrol.fm_0002_unidades_medicion
        oform_g_unid.vf_oform_padre = Me
        oform_g_unid.vg_id_cia = vg_id_cia
        oform_g_unid.vg_usuario_autoriza = vlogin
        'oform_g_unid.vf_elemento_nuevo = "S"
        oform_g_unid.Show()

    End Sub
    Private Sub mi_gestion_items_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_gestion_items.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_g_items As New camocontrol.fm_0300_gestion_items
        oform_g_items.vf_oform_padre = Me
        oform_g_items.vg_id_cia = vg_id_cia
        oform_g_items.vg_usuario_autoriza = vlogin
        oform_g_items.vf_elemento_nuevo = "S"
        oform_g_items.Show()
    End Sub
    Private Sub mi_config_transportadoras_Click(sender As Object, e As EventArgs)

    End Sub

#End Region

#Region "Menu Sistema de Gestion"
#Region "Control de Registros"
    Private Sub mi_digitalizar_registro_Click(sender As Object, e As EventArgs) Handles mi_digitalizar_registro.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_digitalizar_docto As New camocontrol.fm_0500_digitalizar_soporte
        'oform_grilla_programacion.ods_hijo = ods
        oform_digitalizar_docto.vf_oform_padre = Me
        oform_digitalizar_docto.vg_id_cia = vg_id_cia
        oform_digitalizar_docto.vg_usuario_autoriza = vlogin
        oform_digitalizar_docto.ShowDialog()
    End Sub

    Private Sub mi_consultar_registros_digitalizados_Click(sender As Object, e As EventArgs) Handles mi_consultar_registros_digitalizados.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0550-01", vg_id_cia, vlogin,
                                                            "Todos los registros", {rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

#End Region
    Private Sub informar_mensajes_sin_gestionar()
        cl_utilidades_datatables.visualizar_datos_visor("ST-0600-02", vg_id_cia, vlogin,
                                                            "Notificacion de Mensajes sin Gestionar", {vlogin})
        Exit Sub
        Dim csql As String
        csql = "SELECT f0607_id_seguimiento_accion as id_sgmnto, f0607_r_lectura as lectura, f0607_r_respuesta as responder" _
            & " FROM " & database.obtener_esquema & ".tb0607_seg_acc_personal" _
            & " where f0607_id_tercero = '" & vlogin & "'" _
            & " and ((f0607_r_lectura = 'S' and f0607_leido = 'N') or (f0607_r_respuesta = 'S' and f0607_respondido = 'N'))"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        'Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        'oform_mostrar_datos.vf_oform_padre = Me
        'oform_mostrar_datos.csql = csql
        'oform_mostrar_datos.titulo_formulario = "Notificacion de Mensajes sin Gestionar"
        'oform_mostrar_datos.vg_id_cia = vg_id_cia
        'oform_mostrar_datos.vg_usuario_autoriza = vlogin
        'oform_mostrar_datos.ShowDialog()
    End Sub
    Private Sub informar_actividades()
        cl_utilidades_datatables.visualizar_datos_visor("ST-0600-01", vg_id_cia, vlogin,
                                                            "Notificacion de Actividades - Consulta", {vlogin})
    End Sub
    Private Sub estadisticas_usuario_acciones()
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_0600_estadisticas_usuario
        oform_mostrar_datos.vf_oform_padre = Me
        'oform_mostrar_datos.csql = csql
        'oform_mostrar_datos.titulo_formulario = "Notificacion de Actividades"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.lb_titulo.Text = "Estadisticas de Usuario: " & vnombreusuario
        oform_mostrar_datos.Text = "Estadisticas de Usuario"
        'oform_mostrar_datos.id_estructura = id_estructura
        oform_mostrar_datos.vg_usuario_autoriza = vlogin
        oform_mostrar_datos.ShowDialog()
    End Sub

    Private Sub mi_estadisticas_usuario_acciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_estadisticas_usuario_acciones.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        estadisticas_usuario_acciones()
    End Sub

    Private Sub mi_traslado_directo_acciones_Click(sender As System.Object, e As System.EventArgs) Handles mi_traslado_directo_acciones.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Pregunta si realmente desea crear un nuevo elemento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Trasladar Ramal", "Desea trasladar un ramal de un lugar a otro?")
        If respuesta = "N" Then
            Exit Sub
        End If
        Dim oform_mover As New camocontrol.fm_0100_trasladar_ramal
        oform_mover.vf_oform_padre = Me
        oform_mover.vg_id_cia = vg_id_cia
        oform_mover.formulario_origen = Me.Name
        oform_mover.Text = "Trasladar Actividad"
        oform_mover.lb_titulo.Text = "Traslado Directo"
        oform_mover.otipo_ramal = 2
        oform_mover.TopMost = False
        oform_mover.ShowDialog()
    End Sub

    Private Sub mi_re_ejecucion_acciones_Click(sender As Object, e As EventArgs) Handles mi_re_ejecucion_acciones.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Pregunta si realmente desea crear un nuevo elemento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Configurar Re-Ejecucion", "Desea configurar una acccion como Re-Ejecucion de otra actividad?")
        If respuesta = "N" Then
            Exit Sub
        End If
        Dim oform_mover As New camocontrol.fm_0100_trasladar_ramal
        oform_mover.vf_oform_padre = Me
        oform_mover.vg_id_cia = vg_id_cia
        oform_mover.formulario_origen = Me.Name
        oform_mover.Text = "Configurar Re-Ejecucion"
        oform_mover.lb_titulo.Text = "Configurar Re-Ejecucion"
        oform_mover.otipo_ramal = 3
        oform_mover.TopMost = False
        oform_mover.ShowDialog()
    End Sub

    Private Sub mi_seguimientos_sin_gestionar_Click(sender As System.Object, e As System.EventArgs) Handles mi_seguimientos_sin_gestionar.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        informar_mensajes_sin_gestionar()
    End Sub

    Private Sub mi_generar_actividad_Click(sender As System.Object, e As System.EventArgs) Handles mi_generar_actividad.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_programar_actividad As New camocontrol.fm_0600_gestion_tareas
        'oform_grilla_programacion.ods_hijo = ods
        oform_programar_actividad.vf_oform_padre = Me
        oform_programar_actividad.vg_id_cia = vg_id_cia
        oform_programar_actividad.vg_usuario_autoriza = vlogin
        oform_programar_actividad.cm_emisor.Enabled = False
        oform_programar_actividad.grb_tipo_tarea.Enabled = False
        oform_programar_actividad.id_estructura = 0
        oform_programar_actividad.vf_elemento_nuevo = "S"
        oform_programar_actividad.ShowDialog()
    End Sub

    Private Sub mi_generar_proyecto_Click(sender As System.Object, e As System.EventArgs) Handles mi_generar_proyecto.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_programar_actividad As New camocontrol.fm_0600_p1_definicion_accion
        'oform_grilla_programacion.ods_hijo = ods
        'oform_programar_actividad.vf_oform_padre = Me
        oform_programar_actividad.vg_usuario_autoriza = vlogin
        oform_programar_actividad.cm_emisor.Enabled = False
        oform_programar_actividad.cm_tipo_accion.Enabled = True
        oform_programar_actividad.dtp_fecha_emision.Enabled = False
        oform_programar_actividad.cm_fuente_accion.Enabled = True
        oform_programar_actividad.vg_id_cia = vg_id_cia
        'oform_programar_actividad.id_accion = id_accion
        oform_programar_actividad.vf_elemento_nuevo = "S"
        oform_programar_actividad.ShowDialog()
    End Sub
    Private Sub mi_gestion_documento_Click(sender As Object, e As EventArgs) Handles mi_gestion_documento.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_gestion_documento As New camocontrol.fm_0500_gestion_documentos
        'oform_grilla_programacion.ods_hijo = ods
        oform_gestion_documento.vf_oform_padre = Me
        oform_gestion_documento.vg_id_cia = vg_id_cia
        oform_gestion_documento.vg_usuario_autoriza = vlogin
        oform_gestion_documento.ShowDialog()
    End Sub
    Private Sub mi_listado_maestro_documentos_Click(sender As Object, e As EventArgs) Handles mi_listado_maestro_documentos.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String = ""
        cl_utilidades_datatables.visualizar_datos_visor("ST-0500-02", vg_id_cia, vlogin,
                                                            "Listado Maestro de Documentos", {""})
    End Sub
    Private Sub mi_catalogo_mef_Click(sender As Object, e As EventArgs) Handles mi_catalogo_mef.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mef As New camocontrol.fm_0600_p3_mef
        'oform_grilla_programacion.ods_hijo = ods
        oform_mef.vf_oform_padre = Nothing
        oform_mef.vg_id_cia = vg_id_cia
        oform_mef.vg_usuario_autoriza = vlogin
        oform_mef.vf_elemento_nuevo = "S"
        oform_mef.ShowDialog()
    End Sub
    Private Sub mi_listado_general_acciones_Click(sender As Object, e As EventArgs) Handles mi_listado_general_acciones.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0600-04", vg_id_cia, vlogin,
                                                            "Listado General Acciones", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub
    Private Sub mi_consultar_accion_especifica_Click(sender As Object, e As EventArgs) Handles mi_consultar_accion_especifica.Click
        'Exit Sub
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
reinicio:
        Dim id_acc As String = ""
        id_acc = comunes.formulario_parametro_texto("", "Accion", False)
        If id_acc = "" Then
            Exit Sub
        End If
        If IsNumeric(id_acc) = False Then
            MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_acciones.abrir_actividad(id_acc, vlogin, vg_id_cia)
        GoTo reinicio
    End Sub

    Private Sub mi_def_directorio_captura_automat_Click(sender As Object, e As EventArgs) Handles mi_def_directorio_captura_automat.Click
        Dim mensaje As String = "Desea definir un directorio del cual se tomen automaticamente los archivos a registrar?"
        Dim respuesta As String = comunes.g_mensaje_YesNo("Definir Path de cargue Automatico", mensaje)

        If respuesta = "S" Then
            Dim dialog As New FolderBrowserDialog()
            dialog.RootFolder = Environment.SpecialFolder.Desktop
            'dialog.SelectedPath = "C:\"
            dialog.Description = "Select Application Configeration Files Path"
            If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                vg_path_carg_aut = dialog.SelectedPath
                MsgBox("Directorio Definido", MsgBoxStyle.Information, "Info")
            End If
            'My.Computer.FileSystem.WriteAllText(path_seleccionado & "path_seleccionado.txt", path_seleccionado, False)
        End If
    End Sub


    Private Sub mi_tabulador_archivos_texto_Click(sender As Object, e As EventArgs) Handles mi_tabulador_archivos_texto.Click
        ''Debido a fallo en seguridad revalido permiso para uso del menu.
        'Dim permitir As String = "N"
        'permitir = verificar_permisos_menu(sender)
        'If permitir = "N" Then
        '    MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        ''Importo las configuraciones existentes para importacion del plano
        'Dim csql As String = "select * from " & database.obtener_esquema & ".tb0012_config_read_cg" _
        '    & " where f0012_anulado = 'N' and" _
        '    & " f0012_id_cia = '" & vg_id_cia & "'"
        'Dim otb_info_config As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Dim id_file_plano As String = comunes.formulario_parametro_texto("", "Configuraciones",, otb_info_config,
        '                                                                 "f0012_archivo", "f0012_archivo")

        'If id_file_plano = "" Then
        '    MsgBox("La configuracion no existe", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        'MsgBox(id_file_plano)
        'Importo las tablas encabezado y detalle generadas de la importacion del plano
        Dim id_file_plano As String = String.Empty
        Dim ds As DataSet = cl_gestion_arch_planos.form_config_importar_plano_a_datatable(vg_id_cia, vlogin, id_file_plano, "S")
        'Dim info_txt As String = ""
        'For Each otabla As DataTable In ds.Tables
        'info_txt += otabla.TableName & ": " & otabla.Rows.Count & vbCrLf
        'Next
        'MsgBox(info_txt, MsgBoxStyle.Information, "Info")
    End Sub


#End Region

#Region "Menu Mantenimiento"
    Private Sub mi_estructura_mantenimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_estructura_mantenimiento.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_g_manto As New camocontrol.fm_0100_estructura_mantenimiento
        oform_g_manto.vf_oform_padre = Me
        oform_g_manto.vg_id_cia = vg_id_cia
        oform_g_manto.vg_usuario_autoriza = vlogin
        'oform_g_unid.vf_elemento_nuevo = "S"
        oform_g_manto.Show()
    End Sub
    Private Sub mi_t_improd_prod_mto_Click(sender As Object, e As EventArgs) Handles mi_t_improd_prod_mto.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        'ggg
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0400-14", vg_id_cia, vlogin,
                                                            "Tiempos Improductivos Produccion", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub
    Private Sub mi_listado_estructura_manto_Click(sender As Object, e As EventArgs) Handles mi_listado_estructura_manto.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0100-07", vg_id_cia, vlogin,
                                                            "Estructura Mantenimiento", {vg_id_cia})
    End Sub

    Private Sub gestionar_seguimiento_acciones_segun_tipo(ByVal otipo_seguimiento As Integer)

reinicio:
        Dim id_acc As String = ""
        id_acc = comunes.formulario_parametro_texto("", "Accion", False)
        If id_acc = "" Then
            Exit Sub
        End If
        If IsNumeric(id_acc) = False Then
            MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'verifico si la accion existe
        Dim csql As String = "select * from " & database.obtener_esquema & ".tb0600_acciones" _
            & " where f0600_id_accion = '" & id_acc & "' and f0600_id_tipo_registro <> '02'"
        Dim otb_info_accion As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_info_accion.Rows.Count = 0 Then
            MsgBox("La actividad no existe", MsgBoxStyle.Information, "Info")
            GoTo reinicio
        End If

        'Abro el formulario para realizar seguimiento.
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_nuevo_seg_accion As New camocontrol.fm_0600_gestion_seguimiento
        'oform_grilla_programacion.ods_hijo = ods
        oform_nuevo_seg_accion.vf_oform_padre = Me
        oform_nuevo_seg_accion.vg_id_cia = vg_id_cia
        oform_nuevo_seg_accion.tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
        oform_nuevo_seg_accion.id_accion = id_acc
        oform_nuevo_seg_accion.ocomportamiento = "1"
        oform_nuevo_seg_accion.vf_elemento_nuevo = "S"
        oform_nuevo_seg_accion.vg_usuario_autoriza = vlogin 'vg_usuario_autoriza
        oform_nuevo_seg_accion.otipo_seguimiento = otipo_seguimiento
        oform_nuevo_seg_accion.linklabel_id_accion.Text = id_acc
        oform_nuevo_seg_accion.ShowDialog()
        GoTo reinicio
    End Sub

    Private Sub mi_rep_seg_estandar_Click(sender As Object, e As EventArgs) Handles mi_rep_seg_estandar.Click
        'Exit Sub
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        gestionar_seguimiento_acciones_segun_tipo(1)
    End Sub

    Private Sub mi_rep_seg_actividad_Click(sender As Object, e As EventArgs) Handles mi_rep_seg_actividad.Click
        'Exit Sub
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        gestionar_seguimiento_acciones_segun_tipo(2)
    End Sub

    Private Sub mi_ActualizarArchivosPlanosManto_Click(sender As Object, e As EventArgs) Handles mi_ActualizarArchivosPlanosManto.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String
        csql = "select *" _
            & " from " & database.obtener_esquema & ".fnc_100_02_exportar_info_acciones_estructura_manto()"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado")
    End Sub


#End Region

#Region "Menu Comercial"

#Region "Cartera"
    Private Sub mi_registrar_consignaciones_Click(sender As System.Object, e As System.EventArgs)
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then

            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_cargar_plano_consignaciones As New camocontrol.fm_0008_importar_plano_bancos
        oform_cargar_plano_consignaciones.vf_oform_padre = Me
        oform_cargar_plano_consignaciones.vg_id_cia = vg_id_cia
        oform_cargar_plano_consignaciones.vg_usuario_autoriza = vlogin
        oform_cargar_plano_consignaciones.ShowDialog()
    End Sub

    Private Sub mi_consignaciones_sin_indentificar_Click(sender As System.Object, e As System.EventArgs)
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0010-01", vg_id_cia, vlogin,
                                                            "Consignaciones Sin Identificar", {vg_id_cia})
    End Sub

    Private Sub mi_recaudos_asignados_Click(sender As System.Object, e As System.EventArgs)
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0010-02", vg_id_cia, vlogin,
                                                            "Consignaciones Recaudos Asignados", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub
    Private Sub mi_config_archivos_consignaciones_Click(sender As System.Object, e As System.EventArgs)
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_configurar_plano_consignaciones As New camocontrol.fm_0008_archivos_recibo_consignacion
        oform_configurar_plano_consignaciones.vf_oform_padre = Me
        oform_configurar_plano_consignaciones.vg_id_cia = vg_id_cia
        oform_configurar_plano_consignaciones.vg_usuario_autoriza = vlogin
        oform_configurar_plano_consignaciones.ShowDialog()
    End Sub

    Private Sub mi_consignaciones_sin_recibo_Click(sender As System.Object, e As System.EventArgs)
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0010-03", vg_id_cia, vlogin,
                                                            "Consignaciones Recaudos Identificados sin Recibo", {vg_id_cia})
    End Sub

    Private Sub mi_todos_los_recaudos_Click(sender As System.Object, e As System.EventArgs)
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0010-04", vg_id_cia, vlogin,
                                                            "Todas Consignaciones Recaudos", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

#End Region

#Region "Despachos"

    Private Sub mi_despachos_pendintes_guia_Click(sender As Object, e As EventArgs) Handles mi_despachos_pendintes_guia.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0800-11", vg_id_cia, vlogin,
                                                            "Despachos sin asignar guia transportadora", {""})
    End Sub

    Private Sub mi_consultar_todos_despachos_Click(sender As Object, e As EventArgs) Handles mi_consultar_despachos_x_fecha_guia.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0800-01", vg_id_cia, vlogin,
                                                            "Todos los despachos", {rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_remisiones_despachadas_Click(sender As Object, e As EventArgs) Handles mi_remisiones_despachadas.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0800-18", vg_id_cia, vlogin,
                                                            "Todas las Remisiones", {rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub


    Private Sub mi_rastrear_caja_Click(sender As Object, e As EventArgs) Handles mi_rastrear_caja.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim etiqueta As String = comunes.formulario_parametro_texto("", "Numero de Etiqueta", False)
        If IsNumeric(etiqueta) = True Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0800-17", vg_id_cia, vlogin,
                                                            "informacion de una Etiqueta", {etiqueta})
        Else
            MsgBox("Solo se admiten valores numericos", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub mi_trazabilidad_lotes_despachos_Click(sender As Object, e As EventArgs) Handles mi_trazabilidad_lotes_despachos.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0800-20", vg_id_cia, vlogin,
                                                            "Trazabilidad Lotes Despachados", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_consultar_un_despacho_Click(sender As Object, e As EventArgs) Handles mi_consultar_un_despacho.Click

        'Exit Sub
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
reinicio:
        Dim id_pedido As String = ""
        id_pedido = comunes.formulario_parametro_texto("", "Numero de Pedido/Despacho", False)
        If id_pedido = "" Then
            'MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If IsNumeric(id_pedido) = False Then
            MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String = "select f0800_id_despacho from " & database.obtener_esquema & ".tb0800_despachos_comercial"
        csql += " where f0800_id_despacho = '" & id_pedido & "' and f0800_anulado = 'N'"
        Dim otb_fc As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_fc.Rows.Count = 0 Then
            MsgBox("Este Pedido/Despacho no existe!", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If id_pedido <= 1500 Then
            MsgBox("Este pedido no esta soportado, registro informativo de reclamacion", MsgBoxStyle.Exclamation, "Pedido fuera de Registros")
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_pedidos_programados As New camocontrol.fm_0800_programacion_despacho
        'oform_grilla_programacion.ods_hijo = ods
        oform_pedidos_programados.vf_oform_padre = Me
        oform_pedidos_programados.vg_id_cia = vg_id_cia
        oform_pedidos_programados.id_despacho = id_pedido
        oform_pedidos_programados.vf_elemento_nuevo = "N"
        oform_pedidos_programados.mostrar_solo_despacho = "N"
        oform_pedidos_programados.vg_usuario_autoriza = vlogin
        oform_pedidos_programados.ShowDialog()
        GoTo reinicio
    End Sub

    Private Sub mi_reportar_reclamacion_cliente_Click(sender As Object, e As EventArgs) Handles mi_reportar_reclamacion_cliente_sin_pedido.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Reclamo Cliente", "Desea reportar una Reclamo de Cliente?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_reportar_falla As New camocontrol.fm_0100_reportar_falla_maquina
        'oform_grilla_programacion.ods_hijo = ods
        oform_reportar_falla.vf_oform_padre = Me
        oform_reportar_falla.ocontexto_form = "emision de PQR"
        oform_reportar_falla.lb_titulo.Text = "Reporte de Reclamación de Cliente"
        oform_reportar_falla.vg_id_cia = vg_id_cia
        oform_reportar_falla.id_estructura = 0
        oform_reportar_falla.id_fuente_falla = 4
        oform_reportar_falla.cm_fuente_accion.Enabled = False
        oform_reportar_falla.vg_usuario_autoriza = vlogin
        'oform_reportar_falla.tx_estructura.Text = "Reclamacion Cliente"
        oform_reportar_falla.ShowDialog()

    End Sub

    Private Sub mi_consultar_reclamaciones_Click(sender As Object, e As EventArgs) Handles mi_consultar_reclamaciones.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0600-03", vg_id_cia, vlogin,
                                                            "Reclamaciones de los clientes", {""})
    End Sub

#End Region

#Region "cguno"
    Private Sub mi_CargarCotizaciones_Click(sender As Object, e As EventArgs) Handles mi_CargarCotizaciones.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Exporto los datos en los .CSV para analsis de los interesados
        Dim csql As String
        csql = "select * from " & database.obtener_esquema & ".fnc_840_01_importar_cotizaciones_cv()"
        cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado", MsgBoxStyle.Information)

    End Sub
    Private Sub mi_AsignarFaltantesCotizaciones_Click(sender As Object, e As EventArgs) Handles mi_AsignarFaltantesCotizaciones.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_cargar_cotizaciones_cguno As New camocontrol.fm_0800_cargar_faltantes_cotizaciones
            'oform_grilla_programacion.ods_hijo = ods
            oform_cargar_cotizaciones_cguno.vf_oform_padre = Me
            oform_cargar_cotizaciones_cguno.vg_id_cia = vg_id_cia
            oform_cargar_cotizaciones_cguno.vg_usuario_autoriza = vlogin
            oform_cargar_cotizaciones_cguno.f_inicio = rango_fechas(1)
            oform_cargar_cotizaciones_cguno.f_fin = rango_fechas(2)
            oform_cargar_cotizaciones_cguno.ShowDialog()
        Else
            Exit Sub
        End If
    End Sub
    Private Sub mi_cargar_remisiones_cguno_Click(sender As Object, e As EventArgs) Handles mi_cargar_remisiones_cguno.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_cargar_remisiones_cguno As New camocontrol.fm_0800_cargar_rm
        'oform_grilla_programacion.ods_hijo = ods
        oform_cargar_remisiones_cguno.vf_oform_padre = Me
        oform_cargar_remisiones_cguno.vg_id_cia = vg_id_cia
        oform_cargar_remisiones_cguno.vg_usuario_autoriza = vlogin
        oform_cargar_remisiones_cguno.ShowDialog()
    End Sub
    'mi_ActualizarEstadisticas
    Private Sub mi_ActualizarEstadisticas_Click(sender As Object, e As EventArgs) Handles mi_ActualizarEstadisticas.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String
        csql = "select *" _
            & " from " & database.obtener_esquema & ".fnc_850_01_exportar_tablas_ventas_csv()"
        Dim otb As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado")
    End Sub
#End Region

#Region "Gestion Logistica"

    Private Sub mi_tarifas_transportadoras_Click(sender As Object, e As EventArgs) Handles mi_tarifas_transportadoras.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Pregunta si realmente desea reportar
        'Dim respuesta As String = "N"
        'respuesta = comunes.g_mensaje_YesNo("Definir tarifa transportadora", "Desea actualizar tarifas de transporte?")
        'If respuesta = "N" Then
        '    Exit Sub
        'End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_config_transportadoras As New camocontrol.fm_0800_perfil_transportadora
        'oform_grilla_programacion.ods_hijo = ods
        oform_config_transportadoras.vf_oform_padre = Me
        oform_config_transportadoras.vg_id_cia = vg_id_cia
        oform_config_transportadoras.vg_usuario_autoriza = vlogin
        oform_config_transportadoras.vf_elemento_nuevo = "S"
        oform_config_transportadoras.ShowDialog()

    End Sub

    Private Sub mi_CargarInventarioDiario_Click(sender As Object, e As EventArgs) Handles mi_CargarInventarioDiario.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Exporto los datos en los .CSV para analsis de los interesados
        Dim csql As String
        csql = "select * from " & database.obtener_esquema & ".fnc_850_02_cargar_inventarios_diarios()"
        cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado", MsgBoxStyle.Information)
    End Sub

#End Region

#End Region

#Region "Menu Recursos Humanos"
    Private Sub mi_info_personal_Click(sender As System.Object, e As System.EventArgs) Handles mi_info_personal.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_info_personal As New camocontrol.fm_0023_informacion_personal
        oform_info_personal.vf_oform_padre = Me
        oform_info_personal.vg_id_cia = vg_id_cia
        oform_info_personal.vg_usuario_autoriza = vlogin
        oform_info_personal.ShowDialog()
    End Sub


    Private Sub mi_rh_listado_personal_Click(sender As Object, e As EventArgs) Handles mi_rh_listado_personal.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0200-01", vg_id_cia, vlogin,
                                                            "Listado de empleados", {vg_id_cia})
    End Sub

    Private Sub mi_listado_ausentismo_Click(sender As Object, e As EventArgs) Handles mi_listado_ausentismo.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0200-04", vg_id_cia, vlogin,
                                                            "Listado de Ausentismo", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_listado_de_cargos_Click(sender As Object, e As EventArgs) Handles mi_listado_de_cargos.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0250-01", vg_id_cia, vlogin,
                                                            "Listado de Cargos", {vg_id_cia})
    End Sub


    Private Sub mi_listado_horas_lab_rep_prod_Click(sender As Object, e As EventArgs) Handles mi_listado_horas_lab_rep_prod.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0400-17", vg_id_cia, vlogin,
                                                            "Listado Reporte Produccion", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_cargar_datos_reloj_Click(sender As Object, e As EventArgs) Handles mi_cargar_datos_reloj.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Exporto los datos en los .CSV para analsis de los interesados
        Dim csql As String
        csql = "select * from " & database.obtener_esquema & ".fnc_200_01_cargar_exportar_horas_aceptadas_personal()"
        cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado", MsgBoxStyle.Information)
    End Sub

#End Region

#Region "Menu Compras"

    Private Sub mi_nueva_sol_compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi_nueva_sol_compra.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_sc As New camocontrol.fm_0300_sc_solicitud
        oform_sc.vf_oform_padre = Me
        oform_sc.vg_id_cia = vg_id_cia
        oform_sc.vg_usuario_autoriza = vlogin
        oform_sc.ShowDialog()
    End Sub

    Private Sub mi_lista_facturas_x_aprobar_Click(sender As System.Object, e As System.EventArgs) Handles mi_lista_facturas_x_aprobar.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-09", vg_id_cia, vlogin,
                                                            "Recepciones Pendientes por Aprobar", {vg_id_cia})
    End Sub

    Private Sub mi_facturas_Aprob_por_fechas_Click(sender As System.Object, e As System.EventArgs) Handles mi_facturas_Aprob_por_fechas.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-01", vg_id_cia, vlogin,
                                                            "Facturas Aprobadas", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_listado_general_facturas_compras_Click(sender As Object, e As EventArgs) Handles mi_listado_general_facturas_compras.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-42", vg_id_cia, vlogin,
                                                            "Facturas Compras", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_recepcion_Click(sender As System.Object, e As System.EventArgs) Handles mi_recepcion.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_recepciones As New camocontrol.fm_0300_facturas_compras
        oform_recepciones.vf_oform_padre = Me
        oform_recepciones.vg_id_cia = vg_id_cia
        oform_recepciones.vg_usuario_autoriza = vlogin
        oform_recepciones.Text = "Recepción de Items y Facturas"
        oform_recepciones.lb_titulo.Text = "Recepción de Items y Factura"
        oform_recepciones.Show()
    End Sub

    Private Sub mi_sc_pend_aprob_recepcion_Click(sender As System.Object, e As System.EventArgs) Handles mi_sc_pend_aprob_recepcion.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-02", vg_id_cia, vlogin,
                                                            "Recepciones Pendientes por Aprobar", {vg_id_cia})
    End Sub

    Private Sub mi_listado_general_items_sin_recibir_Click(sender As System.Object, e As System.EventArgs) Handles mi_ListadoDeItemsSinRecibir.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-44", vg_id_cia, vlogin,
                                                            "Items Solicitados para Comprar Sin Recibir",
                                                            {vg_id_cia, rango_fechas(1), rango_fechas(2)},, "Items Solicitados",,,,,, "N")
        End If
    End Sub

    Private Sub mi_listado_general_items_solicitados_compras_Click(sender As System.Object, e As System.EventArgs) Handles mi_listado_general_items_solicitados_compras.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-31", vg_id_cia, vlogin,
                                                            "Items Solicitados para Compra", {vg_id_cia, rango_fechas(1), rango_fechas(2)},, "Items Solicitados",,,,,, "N")
        End If
    End Sub
    Private Sub mi_listado_items_solicitados_compras_usuario_Click(sender As System.Object, e As System.EventArgs) Handles mi_listado_items_solicitados_compras_usuario.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            'carga informacion de los items en las solictudes
            csql = "select f0305_id_solicitud_compra as id_sc, to_char(f0305_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_solicitud," _
                & " f0305_id_item_solicitud as id_sc_item, f0300_id_item as item," _
                & " f0300_descripcion_item || ' ' || f0300_referencia || ' ' || f0300_contenido_x_empaque as descripcion," _
                & " f0305_ampliacion_item as descripcion_comp," _
                & " f0305_cantidad as cantidad_sol,f0002_sigla_unidad_medicion as unid," _
                & " to_char(f0305_costo_total_planificado,'LFM999,999,999.00') as costo," _
                & " f0305_anotacion_item as observacion" _
                & " from " & database.obtener_esquema & ".tb0305_items_solicitados" _
                & " join " & database.obtener_esquema & ".tb0300_items" _
                    & " on f0305_id_item = f0300_id_item" _
                & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                    & " on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
                & " Where f0305_anulado = 'N' and f0305_usuario_crear = '" & vlogin & "'" _
                & " and f0305_fr BETWEEN '" & rango_fechas(1) & "' and '" & rango_fechas(2) & "' order by f0300_descripcion_item, f0305_id_solicitud_compra"
            'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
            oform_mostrar_datos.vf_oform_padre = Me
            oform_mostrar_datos.csql = csql
            oform_mostrar_datos.titulo_formulario = "Items Solicitados"
            oform_mostrar_datos.vg_id_cia = vg_id_cia
            oform_mostrar_datos.vg_usuario_autoriza = vlogin
            oform_mostrar_datos.Show()
        Else
            Exit Sub
        End If
    End Sub
    Private Sub mi_listado_general_sc_Click(sender As System.Object, e As System.EventArgs) Handles mi_listado_general_sc.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            csql = "select f0304_id_solicitud as id_sc, f0306_estado_compras as estado," _
                & " trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as solicitante," _
                & " f0304_fr as Fecha, to_char(f0304_costo_total_planificado,'LFM999,999,999.00') as costo_tot_iva," _
                & " f0304_id_accion as id_acc, substring(coalesce(f0600_descripcion, '') from 1 for 200)" _
                & " || chr(13) || chr(10) || chr(13) || chr(10) || 'Nota Solicitud: ' || coalesce(f0304_anotacion,'') as nota_solicitud," _
                & " f0100_codigo as cod_estructura, f0100_nombre as nombre_estructura" _
                & " from " & database.obtener_esquema & ".tb0304_solicitud_compra" _
                & " join " & database.obtener_esquema & ".tb0306_estados_compras" _
                    & " on f0304_id_estado = f0306_id_estado_compras" _
                & " join " & database.obtener_esquema & ".tb0200_terceros" _
                    & " on f0304_usuario_crear = f0200_id_tercero" _
                & " left join " & database.obtener_esquema & ".tb0600_acciones" _
                    & " on f0304_id_accion = f0600_id_accion" _
                & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
                    & " on f0304_id_estructura = f0100_id_estructura" _
                & " where f0304_anulado = 'N'" _
                & " and f0304_fr BETWEEN '" & rango_fechas(1) & "' and '" & rango_fechas(2) & "' order by f0304_id_solicitud desc"
            'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
            oform_mostrar_datos.vf_oform_padre = Me
            oform_mostrar_datos.csql = csql
            oform_mostrar_datos.titulo_formulario = "Solicitudes de compra - Consulta"
            oform_mostrar_datos.vg_id_cia = vg_id_cia
            oform_mostrar_datos.vg_usuario_autoriza = vlogin
            oform_mostrar_datos.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_listado_sc_usuario_Click(sender As System.Object, e As System.EventArgs) Handles mi_listado_sc_usuario.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            csql = "select f0304_id_solicitud as id_sc, f0306_estado_compras as estado," _
                & " trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as solicitante," _
                & " f0304_fr as Fecha, to_char(f0304_costo_total_planificado,'LFM999,999,999.00') as costo_tot_iva," _
                & " f0304_id_accion as id_acc, substring(coalesce(f0600_descripcion, '') from 1 for 200)" _
                & " || chr(13) || chr(10) || chr(13) || chr(10) || 'Nota Solicitud: ' || coalesce(f0304_anotacion,'') as nota_solicitud," _
                & " f0100_codigo as cod_estructura, f0100_nombre as nombre_estructura" _
                & " from " & database.obtener_esquema & ".tb0304_solicitud_compra" _
                & " join " & database.obtener_esquema & ".tb0306_estados_compras" _
                    & " on f0304_id_estado = f0306_id_estado_compras" _
                & " join " & database.obtener_esquema & ".tb0200_terceros" _
                    & " on f0304_usuario_crear = f0200_id_tercero" _
                & " left join " & database.obtener_esquema & ".tb0600_acciones" _
                    & " on f0304_id_accion = f0600_id_accion" _
                & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
                    & " on f0304_id_estructura = f0100_id_estructura" _
                & " where f0304_anulado = 'N' and f0304_usuario_crear = '" & vlogin & "'" _
                & " and f0304_fr BETWEEN '" & rango_fechas(1) & "' and '" & rango_fechas(2) & "' order by f0304_id_solicitud desc"
            'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
            oform_mostrar_datos.vf_oform_padre = Me
            oform_mostrar_datos.csql = csql
            oform_mostrar_datos.titulo_formulario = "Solicitudes de compra - Consulta"
            oform_mostrar_datos.vg_id_cia = vg_id_cia
            oform_mostrar_datos.vg_usuario_autoriza = vlogin
            oform_mostrar_datos.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_sc_pendientes_aprobacion_solicitud_Click(sender As System.Object, e As System.EventArgs) Handles mi_sc_pendientes_aprobacion_solicitud.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String = ""
        csql = "select f0304_id_solicitud as id_sc, f0306_estado_compras as estado," _
                & " trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as solicitante," _
                & " f0304_fr as Fecha, to_char(f0304_costo_total_planificado,'LFM999,999,999.00') as costo_tot_iva," _
                & " f0304_id_accion as id_acc, substring(coalesce(f0600_descripcion, '') from 1 for 200)" _
                & " || chr(13) || chr(10) || chr(13) || chr(10) || 'Nota Solicitud: ' || coalesce(f0304_anotacion,'') as nota_solicitud," _
                & " f0100_codigo as cod_estructura, f0100_nombre as nombre_estructura" _
                & " from " & database.obtener_esquema & ".tb0304_solicitud_compra" _
                & " join " & database.obtener_esquema & ".tb0306_estados_compras" _
                    & " on f0304_id_estado = f0306_id_estado_compras" _
                & " join " & database.obtener_esquema & ".tb0200_terceros" _
                    & " on f0304_usuario_crear = f0200_id_tercero" _
                & " left join " & database.obtener_esquema & ".tb0600_acciones" _
                    & " on f0304_id_accion = f0600_id_accion" _
                & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
                    & " on f0304_id_estructura = f0100_id_estructura" _
                & " where f0304_anulado = 'N'" _
                & " and f0304_id_estado <= '2' order by f0304_id_solicitud desc"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.titulo_formulario = "Solicitudes de compra - Consulta"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vlogin
        oform_mostrar_datos.ShowDialog()
    End Sub

    Private Sub mi_historico_compras_item_Click(sender As Object, e As EventArgs) Handles mi_historico_compras_item.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        fm_0300_historico_compras_item.MdiParent = Me
        fm_0300_historico_compras_item.vg_id_cia = vg_id_cia
        fm_0300_historico_compras_item.vg_usuario_autoriza = vlogin
        'fm_0300_historico_compras_item.Text = "Recepción de Items y Facturas"
        'fm_0300_historico_compras_item.lb_titulo.Text = "Recepción de Items y Factura"
        fm_0300_historico_compras_item.Show()
    End Sub
    Private Sub mi_listado_compras_consolidado_Click(sender As Object, e As EventArgs) Handles mi_listado_compras_consolidado.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-08", vg_id_cia, vlogin,
                                                            "Todos los items comprados", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_trazabilidad_lotes_compras_Click(sender As Object, e As EventArgs) Handles mi_trazabilidad_lotes_compras.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-43", vg_id_cia, vlogin,
                                                            "Todos los items comprados", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub
    Private Sub mi_entrada_directa_almacen_Click(sender As Object, e As EventArgs) Handles mi_entrada_directa_almacen.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(9, vg_id_cia)
        Dim cod_documento As String = "EAD-" & consecutivo.ToString.PadLeft(8, "0")
        cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, 1, 9, comunes.g_fechahora, vlogin, vg_id_cia)
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(cod_documento, vlogin, vg_id_cia, "S", "N", "E", "N", "S", "S", "S", "S")
    End Sub
    Private Sub mi_salida_directa_almacen_Click(sender As Object, e As EventArgs) Handles mi_salida_directa_almacen.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(10, vg_id_cia)
        Dim cod_documento As String = "SAD-" & consecutivo.ToString.PadLeft(8, "0")
        cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, 1, 10, comunes.g_fechahora, vlogin, vg_id_cia)
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(cod_documento, vlogin, vg_id_cia, "S", "N", "S", "N", "S", "S", "S", "S")
    End Sub
    Private Sub mi_traslado_inventarios_Click(sender As Object, e As EventArgs) Handles mi_traslado_inventarios.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(2, vg_id_cia)
        Dim cod_documento As String = "TRI-" & consecutivo.ToString.PadLeft(8, "0")
        cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, 1, 2, comunes.g_fechahora, vlogin, vg_id_cia)
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(cod_documento, vlogin, vg_id_cia, "S", "N")
    End Sub

    Private Sub mi_ajuste_inventario_Click(sender As Object, e As EventArgs) Handles mi_ajuste_inventario.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(3, vg_id_cia)
        Dim cod_documento As String = "AJU-" & consecutivo.ToString.PadLeft(8, "0")
        cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, 1, 3, comunes.g_fechahora, vlogin, vg_id_cia)
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(cod_documento, vlogin, vg_id_cia, "S", "N", "D", "S", "S", "S", "S", "N")
    End Sub

    Private Sub mi_consultar_docto_mov_inventario_Click(sender As Object, e As EventArgs) Handles mi_consultar_docto_mov_inventario.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim documento As String = comunes.formulario_parametro_texto("", "Numero del Documento", False)
        Dim traslado As String = "N"
        If Strings.Left(documento, 3) = "TRI" Then
            traslado = "S"
        End If
        'Verifico que el documento exista
        Dim otb_docto As DataTable
        Dim csql As String = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                             & " where f0310_id_documento = '" & documento & "'"
        otb_docto = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_docto.Rows.Count = 0 Then
            MsgBox("El documento no existe", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(documento,
                                                                              vlogin,
                                                                              vg_id_cia,
                                                                              "N", "S", "D")
    End Sub

    Private Sub mi_habilitar_documento_invent_Click(sender As Object, e As EventArgs) Handles mi_habilitar_documento_invent.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Pregunta si realmente desea habilitar documento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Habilitar Documento", "Desea habilitar un documento para edición?")
        If respuesta = "N" Then
            Exit Sub
        End If

        Dim documento As String = comunes.formulario_parametro_texto("", "Numero del Documento", False)
        Dim otb_docto As DataTable

        If documento.Trim = "" Then
            Exit Sub
        End If

        Dim csql As String = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                             & " where f0310_anulado = 'N' and f0310_id_documento = '" & documento & "'"
        otb_docto = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_docto.Rows.Count = 1 Then
            cl_utilidades_gestion_compras.habilitar_documento(documento, vlogin)
            MsgBox("Documento Habilitado", MsgBoxStyle.Information, "Info")
        Else
            MsgBox("El documento no existe", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub mi_anular_docto_invent_Click(sender As Object, e As EventArgs) Handles mi_anular_docto_invent.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Pregunta si realmente desea ANULAR documento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Documento", "Desea ANULAR un documento?")
        If respuesta = "N" Then
            Exit Sub
        End If

        Dim documento As String = comunes.formulario_parametro_texto("", "Numero del Documento", False)
        If documento.Trim = "" Then
            Exit Sub
        End If
        'Verifico que el documento exista
        Dim otb_docto As DataTable
        Dim csql As String = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
                             & " where f0310_anulado = 'N' and f0310_id_documento = '" & documento & "'"
        otb_docto = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_docto.Rows.Count = 0 Then
            MsgBox("El documento no existe", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim anulado As String = "N"
        anulado = cl_utilidades_gestion_compras.anular_documento(documento, vlogin, vg_id_cia)
        If anulado = "S" Then
            MsgBox("Documento Anulado", MsgBoxStyle.Information, "Info")
        Else
            MsgBox("Accion no realizada", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub mi_inventario_bodega_Click(sender As Object, e As EventArgs) Handles mi_inventario_bodega.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim id_bodega As String = ""
        Dim csql As String
        csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
            & " from " & database.obtener_esquema & ".tb0005_bodegas" _
            & " where f0005_anulado = 'N'"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim ODisplayMember As String = "f0005_descripcion_bodega"
        Dim OValueMember As String = "f0005_id_bodega"
        id_bodega = comunes.formulario_parametro_texto("", "Bodega", False, otb_bodegas, ODisplayMember, OValueMember)
        If id_bodega.Trim = "" Then
            Exit Sub
        End If
        Dim orow_inf_bodega As DataRow()
        orow_inf_bodega = otb_bodegas.Select("f0005_id_bodega = '" & id_bodega & "'")
        Dim nombre_bodega As String = orow_inf_bodega(0)("f0005_descripcion_bodega")
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-11", vg_id_cia, vlogin,
                                                        nombre_bodega, {vg_id_cia, id_bodega},,
                                                        "Informacion de Inventario Actual")
    End Sub

    Private Sub mi_movimientos_item_Click(sender As Object, e As EventArgs) Handles mi_movimientos_item.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim id_bodega As String = ""
        Dim csql As String
        csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
            & " from " & database.obtener_esquema & ".tb0005_bodegas" _
            & " where f0005_anulado = 'N'"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim ODisplayMember As String = "f0005_descripcion_bodega"
        Dim OValueMember As String = "f0005_id_bodega"
        id_bodega = comunes.formulario_parametro_texto("", "Bodega", False, otb_bodegas, ODisplayMember, OValueMember)
        If id_bodega.Trim = "" Then
            Exit Sub
        End If
        Dim id_item As String = ""
        csql = "select f0300_id_item, f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as item" _
            & " from " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_anulado = 'N'"
        Dim otb_items As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        ODisplayMember = "item"
        OValueMember = "f0300_id_item"
        id_item = comunes.formulario_parametro_texto("", "Item", False, otb_items, ODisplayMember, OValueMember)
        If id_item.Trim = "" Then
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-13", vg_id_cia, vlogin, "Bodega", {vg_id_cia, id_item, id_bodega})
    End Sub

    Private Sub mi_listado_doc_mov_inventarios_Click(sender As Object, e As EventArgs) Handles mi_listado_doc_mov_inventarios.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-16", vg_id_cia, vlogin,
                                                            "Documentos Movimientos Inventario", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_inventario_bodega_fcorte_Click(sender As Object, e As EventArgs) Handles mi_inventario_bodega_fcorte.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim id_bodega As String = ""
        Dim csql As String
        csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
            & " from " & database.obtener_esquema & ".tb0005_bodegas" _
            & " where f0005_anulado = 'N'"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim ODisplayMember As String = "f0005_descripcion_bodega"
        Dim OValueMember As String = "f0005_id_bodega"
        id_bodega = comunes.formulario_parametro_texto("", "Bodega", False, otb_bodegas, ODisplayMember, OValueMember)
        If id_bodega.Trim = "" Then
            Exit Sub
        End If
        Dim orow_inf_bodega As DataRow()
        orow_inf_bodega = otb_bodegas.Select("f0005_id_bodega = '" & id_bodega & "'")
        Dim nombre_bodega As String = orow_inf_bodega(0)("f0005_descripcion_bodega")
        Dim rango_fechas() As String
        rango_fechas = comunes.formulario_fecha_rango()
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-17", vg_id_cia, vlogin,
                                                            "Inventario fecha corte antes del : " & rango_fechas(2),
                                                            {vg_id_cia, id_bodega, rango_fechas(2)},,
                                                            "Inventario a corte de la bodega: " & nombre_bodega)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_inventario_todas_bodegas_Click(sender As Object, e As EventArgs) Handles mi_inventario_todas_bodegas.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Dim rango_fechas() As String
        'rango_fechas = comunes.formulario_fecha_rango()
        Dim fecha_select As String = comunes.formulario_fecha_hora(Now(), "N")
        If fecha_select = "ND" Then
            Exit Sub
        End If
        Dim fecha_final As String = CDate(fecha_select).ToString("yyyy/MM/dd")
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-23", vg_id_cia, vlogin,
                                                        "Inventario fecha corte antes del : " & fecha_final,
                                                        {vg_id_cia, fecha_final},,
                                                        "Informacion de Inventario Actual")
    End Sub
    Private Sub mi_inv_todas_bodegas_costeado_Click(sender As Object, e As EventArgs) Handles mi_inv_todas_bodegas_costeado.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim fecha_select As String = comunes.formulario_fecha_hora(Now(), "N")
        If fecha_select = "ND" Then
            Exit Sub
        End If
        Dim fecha_final As String = CDate(fecha_select).ToString("yyyy/MM/dd")
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-33", vg_id_cia, vlogin,
                                                            "Inventario fecha corte antes del : " & fecha_final,
                                                            {vg_id_cia, fecha_final},,
                                                            "Inventario a corte de todas las bodegas")
    End Sub

    Private Sub mi_exportar_info_compras_Click(sender As Object, e As EventArgs) Handles mi_exportar_info_compras.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim csql As String = ""
        Dim verror As String = "N"
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-22", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)

        verror = cl_utilidades_datatables.exportar_consulta_plano(csql, "", "S", "S")

        If verror = "N" Then
            MsgBox("Información exportada", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub mi_imprimir_etiquetas_ident_mp_Click(sender As Object, e As EventArgs) Handles mi_imprimir_etiquetas_ident_mp.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_impresion_etiquetas As New camocontrol.fm_0400_impresion_etiquetas
        'oform_grilla_programacion.ods_hijo = ods
        oform_impresion_etiquetas.vf_oform_padre = Me
        oform_impresion_etiquetas.vg_id_cia = vg_id_cia
        oform_impresion_etiquetas.vg_usuario_autoriza = vlogin
        oform_impresion_etiquetas.generada = "MATPRIM"
        oform_impresion_etiquetas.lb_titulo.Text = "Impresión de etiquetas MP - ME"
        oform_impresion_etiquetas.ShowDialog()
    End Sub

    Private Sub mi_consultar_solicitud_compra_Click(sender As Object, e As EventArgs) Handles mi_consultar_solicitud_compra.Click
        'Exit Sub
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
reinicio:
        Dim id_sc As String = ""
        id_sc = comunes.formulario_parametro_texto("", "Solicitud de Compra", False)
        If id_sc = "" Then
            Exit Sub
        End If
        If IsNumeric(id_sc) = False Then
            MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String = "select f0304_id_solicitud from " & database.obtener_esquema & ".tb0304_solicitud_compra"
        csql += " where f0304_id_solicitud = '" & id_sc & "' and f0304_anulado = 'N'"
        Dim otb_sc As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_sc.Rows.Count = 0 Then
            MsgBox("La solicitud no existe!", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim oform_agregar_solicitud As New camocontrol.fm_0300_sc_solicitud
        oform_agregar_solicitud.vf_oform_padre = Me
        oform_agregar_solicitud.vg_id_cia = vg_id_cia
        oform_agregar_solicitud.id_solicitud_compra = id_sc
        oform_agregar_solicitud.vg_usuario_autoriza = vlogin
        oform_agregar_solicitud.vf_elemento_nuevo = "N"
        oform_agregar_solicitud.ShowDialog()
        GoTo reinicio
    End Sub

    Private Sub mi_consultar_factura_Click(sender As Object, e As EventArgs) Handles mi_consultar_factura.Click
        'Exit Sub
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
reinicio:
        Dim id_fc As String = ""
        id_fc = comunes.formulario_parametro_texto("", "Factura de Compra", False)
        If id_fc = "" Then
            'MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If IsNumeric(id_fc) = False Then
            MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String = "select f0307_id_factura_compras from " & database.obtener_esquema & ".tb0307_facturas_compras"
        csql += " where f0307_id_factura_compras = '" & id_fc & "' and f0307_anulado = 'N'"
        Dim otb_fc As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_fc.Rows.Count = 0 Then
            MsgBox("La factura no existe!", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim oform_factura_compra As New camocontrol.fm_0300_facturas_compras
        oform_factura_compra.vf_oform_padre = Me
        oform_factura_compra.vg_id_cia = vg_id_cia
        'oform_factura_compra.vf_var_config_notas = "TN-FCP-001"
        'oform_factura_compra.vf_var_config_archivos = "CD-FCC"
        oform_factura_compra.vf_id_notas_archivos = id_fc
        oform_factura_compra.id_factura_compras = id_fc
        oform_factura_compra.vg_usuario_autoriza = vlogin
        oform_factura_compra.vf_elemento_nuevo = "N"
        oform_factura_compra.ShowDialog()
        GoTo reinicio
    End Sub

    Private Sub mi_listado_general_items_Click(sender As Object, e As EventArgs) Handles mi_listado_general_items.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-34", vg_id_cia, vlogin,
                                                            "Listado General de Items", {vg_id_cia})
    End Sub

    Private Sub mi_generar_OC_Click(sender As Object, e As EventArgs) Handles mi_generar_OC.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_oc As New camocontrol.fm_0300_orden_compra
        oform_oc.vf_oform_padre = Me
        oform_oc.vg_id_cia = vg_id_cia
        oform_oc.vg_usuario_autoriza = vlogin
        oform_oc.Text = "Orden de Compra"
        'oform_recepciones.lb_titulo.Text = "Recepción de Items y Factura"
        oform_oc.Show()
    End Sub

    Private Sub mi_listado_items_sin_OC_Click(sender As Object, e As EventArgs) Handles mi_listado_items_sin_OC.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-39", vg_id_cia, vlogin,
                                                            "Items Solicitados para Comprar sin OC",
                                                            {vg_id_cia, rango_fechas(1), rango_fechas(2)},
                                                            , "Items Solicitados",,,,,, "N")
        End If
    End Sub

    Private Sub mi_listado_ocs_Click(sender As Object, e As EventArgs) Handles mi_listado_ocs.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-41", vg_id_cia, vlogin,
                                                            "Listado General de OC",
                                                            {vg_id_cia, rango_fechas(1), rango_fechas(2)},
                                                            , "Ordenes de Compra",,,,,, "N")
        End If
    End Sub

    Private Sub mi_consultar_OC_Click(sender As Object, e As EventArgs) Handles mi_consultar_OC.Click
        'Exit Sub
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
reinicio:
        Dim id_oc As String = ""
        id_oc = comunes.formulario_parametro_texto("", "Orden de Compra", False)
        If id_oc = "" Then
            'MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If IsNumeric(id_oc) = False Then
            MsgBox("Invalido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String = "select f0319_id_oc from " & database.obtener_esquema & ".tb0319_ordenes_compra"
        csql += " where f0319_id_oc = '" & id_oc & "' and f0319_anulado = 'N'"
        Dim otb_fc As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_fc.Rows.Count = 0 Then
            MsgBox("La orden de compra no existe!", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim oform_orden_compra As New camocontrol.fm_0300_orden_compra
        oform_orden_compra.vf_oform_padre = Me
        oform_orden_compra.vg_id_cia = vg_id_cia
        'oform_orden_compra.vf_var_config_notas = "TN-FCP-001"
        'oform_orden_compra.vf_var_config_archivos = "CD-FCC"
        oform_orden_compra.vf_id_notas_archivos = id_oc
        oform_orden_compra.id_orden_compra = id_oc
        oform_orden_compra.vg_usuario_autoriza = vlogin
        oform_orden_compra.vf_elemento_nuevo = "N"
        oform_orden_compra.ShowDialog()
        GoTo reinicio
    End Sub
    Private Sub mi_recepcion_mp_me_desde_cguno_Click(sender As Object, e As EventArgs) Handles mi_recepcion_mp_me_desde_cguno.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Importo las tablas encabezado y detalle generadas de la importacion del plano
        Dim otables() As DataTable = cl_gestion_arch_planos.importar_plano_a_datatable("UCCO1099", vg_id_cia, vlogin, "", "S")
        Dim otb_encabezado As DataTable = otables(1)
        Dim otb_detalle As DataTable = otables(2)
        MsgBox("Encabezado: " & otb_encabezado.Rows.Count & " Detalle: " & otb_detalle.Rows.Count)
    End Sub

#Region "Asignacion Elementos a Personal"

    Private Sub mi_generar_asignacion_insumos_Click(sender As Object, e As EventArgs) Handles mi_generar_asignacion_insumos.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_asignacion_elementos_al_persoanl As New camocontrol.fm_0300_asignacion_elemetos_personal_encabezado
        'oform_grilla_programacion.ods_hijo = ods
        oform_asignacion_elementos_al_persoanl.vf_oform_padre = Me
        oform_asignacion_elementos_al_persoanl.vg_id_cia = vg_id_cia
        oform_asignacion_elementos_al_persoanl.vg_usuario_autoriza = vlogin
        'oform_asignacion_elementos_al_persoanl.generada = "MATPRIM"
        'oform_asignacion_elementos_al_persoanl.lb_titulo.Text = "Impresión de etiquetas MP - ME"
        oform_asignacion_elementos_al_persoanl.ShowDialog()

        'Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(3, vg_id_cia)
        'Dim cod_documento As String = "AJU-" & consecutivo.ToString.PadLeft(8, "0")
        'cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, 1, 3, comunes.g_fechahora, vlogin, vg_id_cia)
        'cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(cod_documento, vlogin, vg_id_cia, "S", "N", "D", "S", "S", "S", "S", "N")
    End Sub
#End Region


#End Region

#Region "Menu Produccion"
    Private Sub mi_imprimir_etiquetas_Click(sender As Object, e As EventArgs) Handles mi_imprimir_etiquetas.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_impresion_etiquetas As New camocontrol.fm_0400_impresion_etiquetas
        'oform_grilla_programacion.ods_hijo = ods
        oform_impresion_etiquetas.vf_oform_padre = Me
        oform_impresion_etiquetas.vg_id_cia = vg_id_cia
        oform_impresion_etiquetas.vg_usuario_autoriza = vlogin
        oform_impresion_etiquetas.ShowDialog()
    End Sub
    Private Sub mi_explosionar_prog_prod_Click(sender As Object, e As EventArgs) Handles mi_explosionar_prog_prod.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_explosionar_prog_prod As New camocontrol.fm_0300_explosion_prog_prod
        'oform_grilla_programacion.ods_hijo = ods
        oform_explosionar_prog_prod.vf_oform_padre = Me
        oform_explosionar_prog_prod.vg_id_cia = vg_id_cia
        oform_explosionar_prog_prod.vg_usuario_autoriza = vlogin
        oform_explosionar_prog_prod.ShowDialog()
    End Sub
    Private Sub mi_programas_produccion_Click(sender As Object, e As EventArgs) Handles mi_programas_produccion.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0400-01", vg_id_cia, vlogin,
                                                            "Todos los Programas", {vg_id_cia, "N"})
    End Sub
    Private Sub mi_buscar_elemento_produccion_Click(sender As Object, e As EventArgs) Handles mi_buscar_elemento_produccion.Click
        cl_utilidades_gestion_produccion.desplegar_item_prog_prod(vg_id_cia, vlogin)

    End Sub
    Private Sub mi_gestion_consumos_insumos_Click(sender As Object, e As EventArgs) Handles mi_gestion_consumos_insumos.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_gestion_documento As New camocontrol.fm_0400_gestion_agrupada_consumos_produccion
        'oform_grilla_programacion.ods_hijo = ods
        oform_gestion_documento.vf_oform_padre = Me
        oform_gestion_documento.vg_id_cia = vg_id_cia
        oform_gestion_documento.vg_usuario_autoriza = vlogin
        oform_gestion_documento.ShowDialog()
    End Sub
    Private Sub mi_nueva_solictud_produccion_Click(sender As Object, e As EventArgs) Handles mi_nueva_solictud_produccion.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_solicitud_almacen As New camocontrol.fm_0300_solicitud_mp_produccion
        'oform_grilla_programacion.ods_hijo = ods
        oform_solicitud_almacen.vf_oform_padre = Me
        oform_solicitud_almacen.vg_id_cia = vg_id_cia
        oform_solicitud_almacen.vg_usuario_autoriza = vlogin
        oform_solicitud_almacen.ShowDialog()
    End Sub
    Private Sub mi_listado_solicitudes_almacen_Click(sender As Object, e As EventArgs) Handles mi_listado_solicitudes_almacen.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0300-27", vg_id_cia, vlogin,
                                                            "Listado Solicitudes a Almacenes", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_items_sin_entregar_Click(sender As Object, e As EventArgs) Handles mi_items_sin_entregar.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim id_bodega As String = ""
        Dim csql As String
        csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
            & " from " & database.obtener_esquema & ".tb0005_bodegas" _
            & " where f0005_anulado = 'N'"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim ODisplayMember As String = "f0005_descripcion_bodega"
        Dim OValueMember As String = "f0005_id_bodega"
        id_bodega = comunes.formulario_parametro_texto("", "Bodega", False, otb_bodegas, ODisplayMember, OValueMember)
        If id_bodega.Trim = "" Then
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-29", vg_id_cia, vlogin,
                                                            "Items pendientes por entregar", {vg_id_cia, id_bodega})
    End Sub

    Private Sub mi_ReporteDeParadaDeProduccion_Click(sender As Object, e As EventArgs) Handles mi_ReporteDeParadaDeProduccion.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_reportar_falla As New camocontrol.fm_0100_reportar_falla_maquina
        'oform_grilla_programacion.ods_hijo = ods
        oform_reportar_falla.vf_oform_padre = Me
        oform_reportar_falla.vg_id_cia = vg_id_cia
        oform_reportar_falla.Text = "Reporte de Parada de Produccion"
        oform_reportar_falla.lb_titulo.Text = "Reporte de Parada de Produccion"
        oform_reportar_falla.id_fuente_falla = "00000002"
        oform_reportar_falla.otipo_docto_padre = "RP"
        oform_reportar_falla.id_docto_padre = 0
        oform_reportar_falla.cm_fuente_accion.Enabled = False
        oform_reportar_falla.cm_nit.Enabled = False
        oform_reportar_falla.cm_razon_social.Enabled = False
        oform_reportar_falla.vg_usuario_autoriza = vlogin
        'oform_reportar_falla.tx_estructura.Text = tx_elemento_seleccionado.Text.Trim
        oform_reportar_falla.ShowDialog()
    End Sub
    Private Sub mi_tiempos_improductivos_produccion_Click(sender As Object, e As EventArgs) Handles mi_tiempos_improductivos_produccion.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        'ggg
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0400-14", vg_id_cia, vlogin,
                                                            "Tiempos Improductivos Produccion", {vg_id_cia, rango_fechas(1), rango_fechas(2)})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_listado_informe_produccion_Click(sender As Object, e As EventArgs) Handles mi_listado_informe_produccion.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0400-16", vg_id_cia, vlogin,
                                                            "Listado Reporte Produccion", {vg_id_cia, rango_fechas(1), rango_fechas(2), "N"})
        Else
            Exit Sub
        End If
    End Sub
    Private Sub mi_reportar_act_alt_produccion_Click(sender As Object, e As EventArgs) Handles mi_reportar_act_alt_produccion.Click
        'Exit Sub
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_act_alt_produccion As New camocontrol.fm_0400_rp_reporte_act_alternas
        'oform_grilla_programacion.ods_hijo = ods
        oform_act_alt_produccion.vf_oform_padre = Nothing
        oform_act_alt_produccion.vg_id_cia = vg_id_cia
        oform_act_alt_produccion.vg_usuario_autoriza = vlogin
        oform_act_alt_produccion.vf_elemento_nuevo = "S"
        oform_act_alt_produccion.ShowDialog()
    End Sub

    Private Sub mi_gestion_dosificaciones_Click(sender As Object, e As EventArgs) Handles mi_gestion_dosificaciones.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_datatables.visualizar_datos_visor("ST-0400-01", vg_id_cia, vlogin,
                                                            "Programas Dosificacion", {vg_id_cia, "S"})
    End Sub

    Private Sub mi_listado_informe_mat_nuc_Click(sender As Object, e As EventArgs) Handles mi_listado_informe_mat_nuc.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0400-16", vg_id_cia, vlogin,
                                                            "Listado Reporte Produccion", {vg_id_cia, rango_fechas(1), rango_fechas(2), "S"})
        Else
            Exit Sub
        End If
    End Sub

    Private Sub mi_cargar_ip_cguno_Click(sender As Object, e As EventArgs) Handles mi_cargar_ip_cguno.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_gestion_documento As New camocontrol.fm_0400_cargar_ip_cguno
        'oform_grilla_programacion.ods_hijo = ods
        oform_gestion_documento.vf_oform_padre = Me
        oform_gestion_documento.vg_id_cia = vg_id_cia
        oform_gestion_documento.vg_usuario_autoriza = vlogin
        oform_gestion_documento.ShowDialog()
    End Sub

    Private Sub mi_listado_ips_Click(sender As Object, e As EventArgs) Handles mi_listado_ips.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim rango_fechas() As String
        Dim csql As String = ""
        rango_fechas = comunes.formulario_fecha_rango
        If rango_fechas(0) = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0400-18", vg_id_cia, vlogin,
                                                            "Listado de IP's Cargados CG-UNO",
                                                            {vg_id_cia, rango_fechas(1), rango_fechas(2)},
                                                            , "IP",,,,,, "N")
        End If
    End Sub
    Private Sub mi_actualizar_item_cguno_Click(sender As Object, e As EventArgs) Handles mi_actualizar_item_cguno.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_gestion_documento As New camocontrol.fm_0400_update_items_cg
        'oform_grilla_programacion.ods_hijo = ods
        oform_gestion_documento.vf_oform_padre = Me
        oform_gestion_documento.vg_id_cia = vg_id_cia
        oform_gestion_documento.vg_usuario_autoriza = vlogin
        oform_gestion_documento.ShowDialog()
    End Sub
    Private Sub mi_actualizar_lotes_ip_cguno_Click(sender As Object, e As EventArgs) Handles mi_actualizar_lotes_ip_cguno.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_gestion_documento As New camocontrol.fm_0400_update_lotes_ip_cguno
        'oform_grilla_programacion.ods_hijo = ods
        oform_gestion_documento.vf_oform_padre = Me
        oform_gestion_documento.vg_id_cia = vg_id_cia
        oform_gestion_documento.vg_usuario_autoriza = vlogin
        oform_gestion_documento.ShowDialog()
    End Sub

    Private Sub mi_ActProgProdP1_Click(sender As Object, e As EventArgs) Handles mi_ActProgProdP1.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String
        csql = "select *" _
            & " from " & database.obtener_esquema & ".fnc_400_02_cargar_programa_produccion('P1')"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado")
    End Sub

    Private Sub mi_ActProgProdP2_Click(sender As Object, e As EventArgs) Handles mi_ActProgProdP2.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String
        csql = "select *" _
            & " from " & database.obtener_esquema & ".fnc_400_02_cargar_programa_produccion('P2')"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado")
    End Sub

    Private Sub mi_cargar_horas_personal_p1_Click(sender As Object, e As EventArgs) Handles mi_cargar_horas_personal_p1.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String
        csql = "select *" _
            & " from " & database.obtener_esquema & ".fnc_200_01_cargar_exportar_horas_aceptadas_personal('P1')"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado")
    End Sub

    Private Sub mi_cargar_horas_personal_p2_Click(sender As Object, e As EventArgs) Handles mi_cargar_horas_personal_p2.Click
        'Debido a fallo en seguridad revalido permiso para uso del menu.
        Dim permitir As String = "N"
        permitir = verificar_permisos_menu(sender)
        If permitir = "N" Then
            MsgBox("Fallo en permisos de uso menu", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim csql As String
        csql = "select *" _
            & " from " & database.obtener_esquema & ".fnc_200_01_cargar_exportar_horas_aceptadas_personal('P2')"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        MsgBox("Actualizado")
    End Sub











#End Region


End Class
