Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading
Imports App.ApiClient.CS.Services

Public Class FM_PLANTILLA
    Public Property vg_id_cia As String = ""
    Public Property vg_usuario_nn As String = ""
    Public Property vg_usuario_autoriza As String = ""
    Public Property vf_elemento_nuevo As String = "S"
    Public Property vcerrar As String = "N"

    Private _vf_id_notas_archivos As String = ""
    Public Property vf_id_notas_archivos As String
        Get
            Return _vf_id_notas_archivos
        End Get
        Set(value As String)
            If Not IsNumeric(value) AndAlso value <> "" Then
                Throw New ArgumentException("El ID de notas debe ser numérico.")
            End If
            _vf_id_notas_archivos = value
        End Set
    End Property

    Private _vf_var_config_notas As String = ""
    Private _vf_otipo_nota As String = ""

    Public Property vf_var_config_notas As String
        Get
            Return _vf_var_config_notas
        End Get
        Set(value As String)

            If _vf_var_config_notas = value Then Exit Property

            _vf_var_config_notas = value

            If String.IsNullOrWhiteSpace(value) Then
                _vf_otipo_nota = ""
                Exit Property
            End If

            If String.IsNullOrWhiteSpace(vg_id_cia) Then Exit Property

            _vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(value, vg_id_cia)

        End Set
    End Property

    Public Property vf_otipo_nota As String
        Get
            Return _vf_otipo_nota
        End Get
        Set(value As String)
            _vf_otipo_nota = value
        End Set
    End Property

    'Public vg_id_cia As String = ""
    'Public vg_usuario_nn As String = ""
    'Public vg_usuario_autoriza As String = ""
    Public vg_path_carg_aut As String = ""
    Public vf_oform_padre As Object = Nothing
    'Public vf_var_config_notas As String
    Public vf_var_config_archivos As String
    Public vf_name_files As String
    Public vf_var_config_sql_notas As String = "ST-0606-02"
    ' vf_otipo_nota As String = ""
    'Public vf_id_notas_archivos As String = ""
    Public vf_tot_notas As Integer
    'Public vf_elemento_nuevo As String = "S"
    Public vf_otabla_permisos As DataTable
    Public vf_t_string As String = "" 'variable que se usara para almacenar datos de intercambio entre formularios
    'Public vcerrar As String = "N"
    'Objeto para manejar la configuración Regional
    Protected oregioninfo As System.Globalization.RegionInfo



    Private Function IsInDesignMode() As Boolean
        Return LicenseManager.UsageMode = LicenseUsageMode.Designtime
    End Function
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsInDesignMode() Then
            Exit Sub
        End If


        ConfigurarCultura()
        InicializarFecha()
        InicializarTooltips()
        InicializarNotas()
        InicializarArchivos()

    End Sub

    Private Sub ConfigurarCultura()
        Dim c = New CultureInfo("en-US")

        c.NumberFormat.CurrencyDecimalSeparator = "."
        c.NumberFormat.NumberDecimalSeparator = "."
        c.NumberFormat.NumberGroupSeparator = ","
        c.NumberFormat.NumberDecimalDigits = 0

        Thread.CurrentThread.CurrentCulture = c
        oregioninfo = New RegionInfo("US")
    End Sub

    Private Sub InicializarFecha()
        Me.lb_fecha.Text = DateTime.Now.ToString("yyyy/MM/dd")
    End Sub

    Private Sub InicializarTooltips()
        fm_plantilla_ToolTip1.SetToolTip(bt_nuevo, "Nuevo Registro")
        fm_plantilla_ToolTip1.SetToolTip(bt_grabar, "Grabar Registro")
        fm_plantilla_ToolTip1.SetToolTip(bt_anular, "Eliminar Registro")
        fm_plantilla_ToolTip1.SetToolTip(bt_salir, "Salir")
        fm_plantilla_ToolTip1.SetToolTip(bt_editar, "Editar")
        fm_plantilla_ToolTip1.SetToolTip(bt_generar_informe, "Imprimir")
        fm_plantilla_ToolTip1.SetToolTip(bt_g_notas, "Anotaciones")
    End Sub

    Private Sub InicializarNotas()
        If String.IsNullOrWhiteSpace(vf_var_config_notas) Then Exit Sub

        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(
                        vf_var_config_notas,
                        vg_id_cia)
    End Sub

    Private Sub InicializarArchivos()
        If String.IsNullOrWhiteSpace(vf_var_config_archivos) Then Exit Sub

        ' Aquí irá la lógica real cuando la quieras activar de nuevo
        ' vf_name_files = comunes.suministrar_valor_variable_configuracion(vf_var_config_archivos, vg_id_cia)
        ' vf_name_files += "-" & vf_id_notas_archivos.ToString().PadLeft(8, "0"c)
    End Sub

    Private Sub FM_PLANTILLA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If vcerrar = "N" Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    'Subrutina para manejar el evento KeyPress del Formulario.
    'Antes de ésto, se debió asignar el valor true a la propiedad KeyPreview del Formulario en Modo Ddiseño.
    Private Sub FM_PLANTILLA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = vbCr Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub bt_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bt_salir.Click
        'Manejador del Evento click del botón [SALIR]
        vcerrar = "S"
        Dispose()
        'Me.Close()
    End Sub

    Private Sub bt_g_notas_Click(sender As Object, e As EventArgs) Handles bt_g_notas.Click
        GestionarNotas()
    End Sub
    Private Sub GestionarNotas()
        If vf_elemento_nuevo = "S" Then
            MsgBox("No se pueden crear notas sin un dato asociativo")
            Exit Sub
        End If

        If vf_id_notas_archivos.Trim <> "" AndAlso vf_id_notas_archivos <> "0" Then
            cl_gestion_anotaciones.consultar_anotaciones_acciones(
            vf_id_notas_archivos,
            vf_otipo_nota,
            vg_usuario_autoriza,
            vg_id_cia,
            vf_var_config_sql_notas,
            "2",
            vf_otabla_permisos
        )

            bt_g_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(
            vf_otipo_nota,
            vf_id_notas_archivos,
            vg_id_cia
        )
        Else
            MsgBox("No ha definido un Item", MsgBoxStyle.Information, "Info")
        End If
    End Sub
    Private Sub bt_g_archivos_Click(sender As Object, e As EventArgs) Handles bt_g_archivos.Click
        GestionarArchivos()
    End Sub
    Private Sub GestionarArchivos()
        If vf_var_config_archivos = "" Then Exit Sub

        bt_g_archivos.Text = cl_utilidades_gestion_documentos.mostrar_listado_archivos_asociados(
        vf_var_config_archivos,
        vf_id_notas_archivos,
        vf_name_files,
        vg_usuario_autoriza,
        vg_id_cia,
        vf_otabla_permisos
    )
    End Sub
    Private Sub bt_g_archivos_MouseDown(sender As Object, e As MouseEventArgs) Handles bt_g_archivos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim p_add_archivos As String = "N"
            If IsNothing(vf_otabla_permisos) = False Then
                p_add_archivos = cl_gestion_permisos.identificar_permisos_especiales_formularios("ADD_ARCHIVO", vf_otabla_permisos, vg_usuario_autoriza)
            End If
            If p_add_archivos = "N" Then
                MsgBox("No tiene permisos para adicionar archivos", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            'procesamos los documentos
            cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo(vf_var_config_archivos, vf_id_notas_archivos, vg_id_cia, vg_usuario_autoriza, "S")
            'Recalculamos la cantidad de archivos
            bt_g_archivos.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados(vf_var_config_archivos & "-001",
                                                                                                       vf_id_notas_archivos, vg_id_cia)
        End If
    End Sub
    Private Sub bt_editar_Click(sender As Object, e As EventArgs) Handles bt_editar.Click
        If vf_elemento_nuevo = "S" Then
            MsgBox("Este registro esta en estado nuevo", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vf_id_notas_archivos.Trim <> "" And vf_id_notas_archivos <> "0" Then
            'MsgBox("Hola1")
            'IDENTIFICO LOS PERMISOS QUE TIENE EL USUARIO PARA GESTIONAR LOS ARCHIVOS
            If IsNothing(vf_otabla_permisos) = False Then
                'MsgBox("Hola2")
                Dim p_editar As String = "N"
                p_editar = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_editar", vf_otabla_permisos, vg_usuario_autoriza)
                If p_editar = "S" Then
                    Dim respuesta As String = "N"
                    respuesta = comunes.g_mensaje_YesNo("Editar Informacion", "Desea editar la informacion de este formulario?")
                    If respuesta = "S" Then
                        bt_grabar.Enabled = True
                    End If
                    'MsgBox("SI")
                Else
                    MsgBox("No tiene permiso para editar esta informacion!", MsgBoxStyle.Exclamation, "Info")
                End If
            Else
                'MsgBox("Hola3")
            End If
        Else
            MsgBox("No hay ningun registro activo", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub FM_PLANTILLA_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        'Combinacion de teclado para cerrar el formulario
        If e.Alt + e.KeyCode = Keys.Q Then
            'Dispose()
        End If
    End Sub
End Class
