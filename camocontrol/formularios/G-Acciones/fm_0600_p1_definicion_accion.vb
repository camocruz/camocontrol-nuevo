Public Class fm_0600_p1_definicion_accion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_accion As Integer
    '$Public$vf_elemento_nuevo As String = "N"
    Public id_estructura As Integer = 0

    Private new_name_file As String = ""

    Public cambiar_estructura As String = "N"
    Public tx_val_fm_fecha As String 'variable que recibira los valores definidos en el formulario de fechas
    Public retornar_accion As String = "N"

    Private path_accion As String
    Private nivel_cumplimiento As String
    Private usuario_creador As String = ""
    Private usuario_evaluador As String = ""
    Private actividad_cerrada As String = "N" 'Si una actividad fue cerrada queda bloqueada
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private vmensaje_nota As String = ""
    Private csql As String
    Private tipo_nota As String

    Private otxt_evaluador As String
    Private otxt_receptor As String
    Private otxt_modo_falla As String
    Private otxt_titulo As String
    Private otxt_tipo_accion As String
    Private otxt_fuente As String
    Private otxt_tercero_relacionado As String

    Private orow_info_accion As DataRow
    Private otb_info_personal As DataTable
    Private otb_estructura_mantenimiento As DataTable
    Private otb_accion As DataTable
    Private otb_acciones_hijos As DataTable

    Private Sub fm_0600_p1_definicion_accion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        cl_utilidades_gestion_acciones.actualizar_estado_acciones(0, vg_usuario_autoriza, vg_id_cia) 'Actualizamos el estado de todas las acciones
        'cl_utilidades_gestion_acciones.actualizar_estado_acciones(id_accion, vg_usuario_autoriza, vg_id_cia) 'Actualizamos el estado de esta accion

        tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)

        cargar_todos_los_combos_y_formatos()
        If vf_elemento_nuevo = "N" Then
            cargar_informacion_elemento_existente()
        End If
        otxt_evaluador = cm_evaluador.Text
        otxt_receptor = cm_responsable.Text
        otxt_modo_falla = tx_modo_efecto_falla.Text.Trim
        otxt_titulo = tx_titulo.Text.Trim
        otxt_tipo_accion = cm_tipo_accion.Text
        otxt_fuente = cm_fuente_accion.Text
        otxt_tercero_relacionado = cm_razon_social.Text
    End Sub
    Private Sub cargar_informacion_elemento_existente()
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones where f0600_id_accion = " & id_accion
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'tx_cumplimiento.Text = cl_utilidades_gestion_acciones.obtener_nivel_cumplimiento_actual(id_accion, tipo_nota).ToString & "%"
        bt_nuevo_soporte.Enabled = True
        bt_ver_archivos_asociados.Enabled = True
        For Each orow As DataRow In otb_accion.Rows
            orow_info_accion = orow
            tx_id_accion.Text = orow("f0600_id_accion")
            path_accion = orow("f0600_path")
            id_estructura = orow("f0600_id_estructura")
            nivel_cumplimiento = orow("f0600_nivel_cumplimiento")
            tx_cumplimiento.Text = CInt(nivel_cumplimiento).ToString & "%"
            tx_estructura.Text = comunes.traer_nombre_estructura(orow("f0600_id_estructura").ToString)
            cm_estado.SelectedValue = orow("f0600_id_estado_accion")
            tx_documento_origen.Text = orow("f0600_tipo_docto_padre") & "-" & orow("f0600_id_docto_padre")
            tx_tiempo_efectivo_parada.Text = orow("f0600_tiempo_efectivo_parada")
            If orow("f0600_id_estado_accion").ToString = "08" Then '08 es estado cerrado
                actividad_cerrada = "S"
            End If
            If orow("f0600_tercero_relacionado").ToString <> "" Then
                cm_razon_social.SelectedValue = orow("f0600_tercero_relacionado")
            End If
            cm_responsable.SelectedValue = orow("f0600_responsable")
            cm_evaluador.SelectedValue = orow("f0600_evaluador")
            cm_emisor.SelectedValue = orow("f0600_emisor")
            usuario_creador = orow("f0600_emisor")
            If usuario_creador = vg_usuario_autoriza Then
                cm_fuente_accion.Enabled = True
                cm_tipo_accion.Enabled = True
            End If
            usuario_evaluador = orow("f0600_evaluador")
            dtp_fecha_emision.Value = orow("f0600_fecha_emision")
            If orow("f0600_fecha_ocurrencia_evento").ToString <> "" Then
                dtp_fecha_ocurrencia.Value = orow("f0600_fecha_ocurrencia_evento")
                lb_fecha_ocurrencia.Visible = False
            Else
                dtp_fecha_ocurrencia.Visible = False
                lb_fecha_ocurrencia.Visible = True
            End If
            If orow("f0600_fecha_reporte_encargado").ToString <> "" Then
                dtp_fecha_reporte_encargado.Value = orow("f0600_fecha_reporte_encargado")
                lb_fecha_rep_encargado.Visible = False
            Else
                dtp_fecha_reporte_encargado.Visible = False
                lb_fecha_rep_encargado.Visible = True
            End If
            If orow("f0600_fecha_inicio_correctivo").ToString <> "" Then
                dtp_fecha_inicio_correctivo.Value = orow("f0600_fecha_inicio_correctivo")
                lb_fecha_ini_correctivo.Visible = False
            Else
                dtp_fecha_inicio_correctivo.Visible = False
                lb_fecha_ini_correctivo.Visible = True
            End If
            If orow("f0600_fecha_cierre_correctivo").ToString <> "" Then
                dtp_fecha_fin_correctivo.Value = orow("f0600_fecha_cierre_correctivo")
                lb_fecha_fin_correctivo.Visible = False
            Else
                dtp_fecha_fin_correctivo.Visible = False
                lb_fecha_fin_correctivo.Visible = True
            End If
            If orow("f0600_fecha_limite").ToString <> "" Then
                dtp_fecha_limite.Value = orow("f0600_fecha_limite")
                dtp_fecha_limite.Visible = True
                lb_fecha_limite.Visible = False
            Else
                dtp_fecha_limite.Visible = False
                lb_fecha_limite.Visible = True
            End If
            If orow("f0600_fecha_cierre").ToString <> "" Then
                dtp_fecha_cierre.Value = orow("f0600_fecha_cierre")
                dtp_fecha_cierre.Visible = True
                lb_fecha_cierre.Visible = False
            Else
                dtp_fecha_cierre.Visible = False
                lb_fecha_cierre.Visible = True
            End If

            cm_tipo_accion.SelectedValue = orow("f0600_id_tipo_accion")
            cm_fuente_accion.SelectedValue = orow("f0600_id_fuente_accion")
            tx_modo_efecto_falla.Text = orow("f0600_descripcion")
            tx_titulo.Text = orow("f0600_titulo")
        Next
        'verificar_estado_accion()
        'PARA CONTROLAR LA INFORMACION DE LOS DOCUMENTOS ASOCIADOS
        new_name_file = comunes.suministrar_valor_variable_configuracion("CD-ACC-001", vg_id_cia)
        new_name_file += "-" & tx_id_accion.Text.PadLeft(8, "0")
        calcular_archivos_asociados()

    End Sub

    Private Sub cargar_todos_los_combos_y_formatos()
        tx_id_accion.Enabled = False
        tx_estructura.ReadOnly = True
        tx_documento_origen.Enabled = False
        tx_tiempo_efectivo_parada.Enabled = False
        bt_nuevo_soporte.Enabled = False
        bt_ver_archivos_asociados.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_emision.Format = DateTimePickerFormat.Custom
        dtp_fecha_emision.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_emision.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_ocurrencia.Format = DateTimePickerFormat.Custom
        dtp_fecha_ocurrencia.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_ocurrencia.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_reporte_encargado.Format = DateTimePickerFormat.Custom
        dtp_fecha_reporte_encargado.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_reporte_encargado.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_inicio_correctivo.Format = DateTimePickerFormat.Custom
        dtp_fecha_inicio_correctivo.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_inicio_correctivo.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_fin_correctivo.Format = DateTimePickerFormat.Custom
        dtp_fecha_fin_correctivo.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_fin_correctivo.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_limite.Format = DateTimePickerFormat.Custom
        dtp_fecha_limite.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_limite.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_cierre.Format = DateTimePickerFormat.Custom
        dtp_fecha_cierre.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_cierre.Enabled = False

        csql = "SELECT f0603_id_estado_accion, f0603_descriptor_estado" _
            & " FROM " & database.obtener_esquema & ".tb0603_estados_acciones"
        Dim otb_estado_accion As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_estado
            'Valor que se muestra al usuario
            .DisplayMember = "f0603_descriptor_estado"
            'Valor interno que almacena el objeto
            .ValueMember = "f0603_id_estado_accion"
            'Origen de Datos del ComboBox
            .DataSource = otb_estado_accion
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0601_fuentes_acciones"
        Dim otb_fuentes As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_fuente_accion
            'Valor que se muestra al usuario
            .DisplayMember = "f0601_descriptor_fuente"
            'Valor interno que almacena el objeto
            .ValueMember = "f0601_id_fuente"
            'Origen de Datos del ComboBox
            .DataSource = otb_fuentes
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "SELECT f0602_id_tipo_accion, f0602_descriptor_tipo" _
            & " FROM " & database.obtener_esquema & ".tb0602_tipos_acciones"
        Dim otb_tipo_accion As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_tipo_accion
            'Valor que se muestra al usuario
            .DisplayMember = "f0602_descriptor_tipo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0602_id_tipo_accion"
            'Origen de Datos del ComboBox
            .DataSource = otb_tipo_accion
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" & " and f0200_ind_empleado = 'S'" _
            & " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim otb_emisor As DataTable = otb_info_personal.Copy
        Dim otb_responsable As DataTable = otb_info_personal.Copy
        Dim otb_evaluador As DataTable = otb_info_personal.Copy

        With cm_responsable
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_responsable
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        With cm_evaluador
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_evaluador
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        With cm_emisor
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_emisor
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = vg_usuario_autoriza
        End With

        gb_tercero.Enabled = False
        csql = "select f0200_id_tercero, f0200_id," _
            & " trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres || ' - ' || f0200_id) as tercero" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " order by f0200_nombres"  '& " where f0200_ind_cliente = 'S'" _
        Dim otb_tercero As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_nit
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_id"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_tercero
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_razon_social
            'Valor que se muestra al usuario
            .DisplayMember = "tercero"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_tercero
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub bt_criterios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_criterios.Click
        If tx_id_accion.Text = "" Then
            MsgBox("Debe grabar primero el proyecto!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_gestion_criterios As New camocontrol.fm_0600_p2_criterios_eficacia
        oform_gestion_criterios.vf_oform_padre = Me
        oform_gestion_criterios.ShowDialog()
    End Sub

    Private Sub bt_seguimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_seguimientos.Click
        If tx_id_accion.Text = "" Then
            MsgBox("Debe grabar primero el proyecto!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        cl_gestion_anotaciones.consultar_anotaciones_acciones(id_accion, tipo_nota, vg_usuario_autoriza, vg_id_cia, "ST-0606-01", "1")
        cargar_informacion_elemento_existente()
    End Sub

    Private Sub bt_analisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_analisis.Click
        If tx_id_accion.Text = "" Then
            MsgBox("Debe grabar primero el proyecto!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_analisis As New camocontrol.fm_0600_p3_analisis_y_solucion
        'oform_grilla_programacion.ods_hijo = ods
        oform_analisis.vf_oform_padre = Me
        oform_analisis.vg_id_cia = vg_id_cia
        oform_analisis.orow_info_accion = orow_info_accion
        oform_analisis.id_accion = id_accion
        oform_analisis.path_accion_base = path_accion
        oform_analisis.id_estructura = id_estructura
        oform_analisis.nivel_cumplimiento = nivel_cumplimiento
        oform_analisis.vg_usuario_autoriza = vg_usuario_autoriza
        oform_analisis.ShowDialog()

        cl_utilidades_gestion_acciones.actualizar_estado_plan_de_accion(id_accion)
        cargar_informacion_elemento_existente()
    End Sub

    Private Sub bt_recursos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_recursos.Click
        If tx_id_accion.Text.ToString = "" Then
            MsgBox("La actividad debe grabarse primero", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_programar_recurso As New camocontrol.fm_0600_recursos_listado
        'oform_grilla_programacion.ods_hijo = ods
        oform_programar_recurso.vf_oform_padre = Me
        oform_programar_recurso.vg_id_cia = vg_id_cia
        oform_programar_recurso.vg_usuario_autoriza = vg_usuario_autoriza
        oform_programar_recurso.id_accion = tx_id_accion.Text
        oform_programar_recurso.id_estructura = id_estructura
        oform_programar_recurso.ShowDialog()
    End Sub

    Private Sub bt_solicitud_almacen_Click(sender As Object, e As EventArgs) Handles bt_solicitud_almacen.Click
        If tx_id_accion.Text.ToString = "" Then
            MsgBox("La actividad debe grabarse primero", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-38", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", "ACC-" & tx_id_accion.Text)
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        'definimos el contexto para habilitar el boton nuevo
        oform_mostrar_datos.ocontexto_form = "salida de insumos de almacen desde una actividad"
        oform_mostrar_datos.titulo_formulario = "Salidas del almacen de Mantenimiento - Consulta"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.id_accion = tx_id_accion.Text
        oform_mostrar_datos.ShowDialog()


    End Sub

    Private Sub validar_que()
        If tx_modo_efecto_falla.Text.Trim = "" Then
            vmensaje_requisitos = "No hay una descripcion del modo o efecto de falla."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_tipo()
        If cm_tipo_accion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Debe seleccionar el tipo de accion."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_fuente()
        If cm_fuente_accion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Debe seleccionar la fuente del proyecto o plan."
            verror_requisitos = "S"
        End If
    End Sub

    Private Sub validar_cambios_solo_creador()
        Dim p_cambios As String = "N"
        If vf_elemento_nuevo = "N" Then
            If vg_usuario_autoriza <> usuario_creador And vg_usuario_autoriza <> "00000001" Then
                p_cambios = "N"
            Else
                p_cambios = "S"
            End If
            If vg_usuario_autoriza = usuario_evaluador Then
                p_cambios = "S"
            End If
            If p_cambios = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Solo el emisor o el evaluador pueden realizar cambios en este registro!"
            End If
        End If
    End Sub
    Private Sub validar_modificacion_actividad_cerrada()
        If actividad_cerrada = "S" Then
            If vg_usuario_autoriza <> "00000001" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Una actividad cerrada solo puede ser modificada por el Administrador!"
            End If
        End If
    End Sub
    Private Sub grabar()
        'Pregunta si realmente desea reportar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Grabar Accion", "Desea grabar cambios en este registro?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'primer bloque de validaciones que no se relacionan con el usuario
        verror_requisitos = "N"
        validar_que()
        validar_tipo()
        validar_fuente()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        autoriza = "N"
        Dim oform_login As New camocontrol.login
        'oform_grilla_programacion.ods_hijo = ods
        oform_login.vf_oform_padre = Me
        oform_login.paso_autorizacion = "S"
        oform_login.ShowDialog()
        If autoriza = "N" Then
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            Dim id_creado As Integer
            id_creado = grabar_nuevo_plan()
            If verror = "N" Then
                vf_elemento_nuevo = "N"
                id_accion = id_creado  ' cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0600_id_accion", "f0600_usuario_crear", vg_usuario_autoriza, "tb0600_acciones")
                cargar_informacion_elemento_existente()
            End If
        Else
            'segundo bloque de validaciones que se relacionan con el usuario
            verror_requisitos = "N"
            validar_cambios_solo_creador()
            validar_modificacion_actividad_cerrada()
            If verror_requisitos = "S" Then
                MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If
            vmensaje_nota = ""
            Dim cambio As String = "N"
            If otxt_tipo_accion <> cm_tipo_accion.Text Then
                vmensaje_nota += "* Cambio al tipo de accion de: " & otxt_tipo_accion & " a: " & cm_tipo_accion.Text & vbCrLf & vbCrLf
                cambio = "S"
            End If
            If otxt_fuente <> cm_fuente_accion.Text Then
                vmensaje_nota += "* Cambio a la fuente de accion de: " & otxt_fuente & " a: " & cm_fuente_accion.Text & vbCrLf & vbCrLf
                cambio = "S"
            End If
            If otxt_tercero_relacionado <> cm_razon_social.Text Then
                vmensaje_nota += "* Cambio el tercero relacionado de: " & otxt_tercero_relacionado & " a: " _
                    & cm_razon_social.Text & " NIT: " & cm_nit.Text & vbCrLf & vbCrLf
                cambio = "S"
            End If
            If otxt_evaluador <> cm_evaluador.Text Then
                vmensaje_nota += "* Cambio al evaluador de: " & otxt_evaluador & " a: " & cm_evaluador.Text & vbCrLf & vbCrLf
                cambio = "S"
            End If
            If otxt_receptor <> cm_responsable.Text Then
                vmensaje_nota += "* Cambio al responsable de: " & otxt_receptor & " a: " & cm_responsable.Text & vbCrLf & vbCrLf
                cambio = "S"
            End If
            If otxt_modo_falla.Trim <> tx_modo_efecto_falla.Text.Trim Then
                vmensaje_nota += "* Cambio el modo o efecto de falla de: " & otxt_modo_falla & vbCrLf & " a: " & vbCrLf & tx_modo_efecto_falla.Text.Trim
                cambio = "S"
            End If
            If otxt_titulo.Trim <> tx_titulo.Text.Trim Then
                vmensaje_nota += "* Cambio el Titulo de: " & otxt_titulo & vbCrLf & " a: " & vbCrLf & tx_titulo.Text.Trim
                cambio = "S"
            End If
            If cambio = "S" Then
                actualizar_plan()
                Dim txt_nota_cambio As String
                txt_nota_cambio = UCase("El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo el siguiente cambio:") _
                    & vbCrLf & vbCrLf & UCase(vmensaje_nota)
                cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, UCase(txt_nota_cambio), tipo_nota, vg_id_cia)
            Else
                MsgBox("Usted no a realizado ningun cambio en el registro", MsgBoxStyle.Information, "Cambio")
            End If

        End If

        If verror = "N" Then
            MsgBox("Registro grabado", MsgBoxStyle.Information, "Grabar")
            'Dispose()
        End If
    End Sub
    Private Sub actualizar_plan()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += "f0600_descripcion = @f0600_descripcion,"
        csql += "f0600_titulo = @f0600_titulo,"
        csql += "f0600_id_tipo_accion = @f0600_id_tipo_accion,"
        csql += "f0600_id_fuente_accion = @f0600_id_fuente_accion,"
        csql += "f0600_tercero_relacionado = @f0600_tercero_relacionado,"
        csql += "f0600_responsable = @f0600_responsable,"
        csql += "f0600_evaluador = @f0600_evaluador,"
        csql += "f0600_fm = @f0600_fm,"
        csql += "f0600_usuario_modificar = @f0600_usuario_modificar"
        csql += " where f0600_id_accion = @f0600_id_accion"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_actualizar_plan(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_actualizar_plan(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0600_id_accion", NpgsqlDbType.Integer).Value = id_accion
        ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = UCase(tx_modo_efecto_falla.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_titulo", NpgsqlDbType.Varchar).Value = UCase(tx_titulo.Text.ToString.Trim)

        ocmd.Parameters.Add("@f0600_id_tipo_accion", NpgsqlDbType.Varchar).Value = cm_tipo_accion.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = cm_fuente_accion.SelectedValue.ToString
        If cm_razon_social.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0600_tercero_relacionado", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0600_tercero_relacionado", NpgsqlDbType.Varchar).Value = cm_razon_social.SelectedValue
        End If

        ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = cm_responsable.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_evaluador", NpgsqlDbType.Varchar).Value = cm_evaluador.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub bt_cambiar_infraestructura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_cambiar_infraestructura.Click
        verror_requisitos = "N"
        validar_cambios_solo_creador()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
            Exit Sub
        End If
        Dim nueva_estructura As String = id_estructura.ToString
        nueva_estructura = cl_utilidades_gestion_mantenimiento.suministrar_estructura_mantenimiento(vg_id_cia, vg_usuario_autoriza, id_estructura)
        Dim id_estructura_anterior As Integer = id_estructura
        If id_estructura.ToString <> nueva_estructura Then
            id_estructura = nueva_estructura
            cambiar_estructura_seleccionada()
            MsgBox("Estructura definida", MsgBoxStyle.Information, "Estructura")
            If vf_elemento_nuevo = "N" Then
                'Agregar seguimiento informando el cambio realizado
                Dim txt_seguimiento As String
                txt_seguimiento = "CAMBIO DE ESTRUCTURA MANTENIMIENTO: " & vbCrLf _
                & "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo el siguiente cambio:" & vbCrLf _
                & "VALOR INICIAL:" & vbCrLf _
                & "Equipo: " & comunes.traer_nombre_estructura(id_estructura_anterior.ToString) & vbCrLf _
                & "CAMBIA A:" & vbCrLf _
                & "Equipo: " & comunes.traer_nombre_estructura(id_estructura.ToString)
                cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia)
                cargar_informacion_elemento_existente()
                MsgBox("Estructura Cambiada", MsgBoxStyle.Information, "Cambio de Estructura")
            End If
        End If
    End Sub

    Private Sub cambiar_estructura_seleccionada()
        If vf_elemento_nuevo = "S" Then
            tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura.ToString)
        Else
            'Instancia la conexión que estará vigente para todas las operaciones CRUD
            oconn_form = database.obtener_conexion()
            'actualizacion parametrizada
            csql = "update " + database.obtener_esquema + ".tb0600_acciones set " _
                        & " f0600_id_estructura = '" & id_estructura & "'" _
                        & " where f0600_id_accion = '" & id_accion & "'"
            'Crear el comando
            Dim ocmd As New NpgsqlCommand(csql, oconn_form)
            ocmd = database.obtener_comando(oconn_form)
            ocmd.CommandText = csql
            verror = "N"
            Try
                'Compila el comando en la Base de datos.
                'ocmd.Prepare()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
            End Try
            If verror = "N" Then
                Try
                    ocmd.ExecuteNonQuery()
                Catch ex As Exception
                    verror = "S"
                    MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
                End Try
            End If
            ocmd = Nothing
            oconn_form.Close()
        End If
    End Sub

    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        grabar()
    End Sub
    Private Sub calcular_archivos_asociados()
        lb_total_soportes.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-ACC-001", tx_id_accion.Text, vg_id_cia)
    End Sub
    Private Sub bt_nuevo_soporte_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo_soporte.Click
        cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-ACC", tx_id_accion.Text, vg_id_cia, vg_usuario_autoriza, "N")
        calcular_archivos_asociados()
    End Sub
    Private Sub bt_ver_archivos_asociados_Click(sender As System.Object, e As System.EventArgs) Handles bt_ver_archivos_asociados.Click
        csql = "SELECT f0503_id_archivo as id_file, f0503_ed as documento, f0503_descripcion_archivo as descripcion," _
    & " to_char(f0503_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_carga, f0503_nombre_original as origen" _
    & " from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
    & " where f0503_nombre_archivo = '" & new_name_file & "' and f0503_id_cia = '" & vg_id_cia & "'" _
    & " order by f0503_id_archivo desc"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_archivos As New camocontrol.fm_visor_datos
        oform_mostrar_archivos.vf_oform_padre = Me
        oform_mostrar_archivos.csql = csql
        oform_mostrar_archivos.titulo_formulario = "Archivos Asociados"
        oform_mostrar_archivos.vg_id_cia = vg_id_cia
        oform_mostrar_archivos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_archivos.ShowDialog()
    End Sub

    Private Function grabar_nuevo_plan()
        Dim id_creado As Integer
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0600_acciones" _
                & " (f0600_id_cia, f0600_id_estructura, f0600_descripcion, f0600_titulo, f0600_id_fuente_accion, f0600_id_estado_accion," _
                & " f0600_id_tipo_accion, f0600_emisor, f0600_responsable, f0600_evaluador, f0600_fecha_ocurrencia_evento," _
                & " f0600_unidad_duracion, f0600_usuario_modificar, f0600_usuario_crear, f0600_fm, f0600_fecha_cierre_correctivo," _
                & " f0600_fecha_reporte_encargado, f0600_fecha_inicio_correctivo, f0600_tercero_relacionado, f0600_fecha_inicio)" _
                & " VALUES" _
                & " (@f0600_id_cia, @f0600_id_estructura, @f0600_descripcion, @f0600_titulo, @f0600_id_fuente_accion, @f0600_id_estado_accion," _
                & " @f0600_id_tipo_accion, @f0600_emisor, @f0600_responsable, @f0600_evaluador, @f0600_fecha_ocurrencia_evento," _
                & " @f0600_unidad_duracion, @f0600_usuario_modificar, @f0600_usuario_crear, @f0600_fm, @f0600_fecha_cierre_correctivo," _
                & " @f0600_fecha_reporte_encargado, @f0600_fecha_inicio_correctivo, @f0600_tercero_relacionado, @f0600_fecha_inicio)" _
                & " RETURNING f0600_id_accion;"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_nuevo_plan(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nueva falla! " + vbCrLf + ex.ToString + vbCrLf + csql)
        End Try
        If verror = "N" Then
            Try
                id_creado = ocmd.ExecuteScalar()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        Return id_creado
    End Function

    Private Sub crear_parametros_nuevo_plan(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0600_id_estructura", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = UCase(tx_modo_efecto_falla.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_titulo", NpgsqlDbType.Varchar).Value = UCase(tx_titulo.Text.ToString.Trim)

        ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = cm_fuente_accion.SelectedValue
        If cm_razon_social.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0600_tercero_relacionado", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("@f0600_tercero_relacionado", NpgsqlDbType.Varchar).Value = cm_razon_social.SelectedValue
        End If
        ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = "02"
        ocmd.Parameters.Add("@f0600_id_tipo_accion", NpgsqlDbType.Varchar).Value = "01"
        ocmd.Parameters.Add("@f0600_emisor", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = cm_responsable.SelectedValue
        ocmd.Parameters.Add("@f0600_evaluador", NpgsqlDbType.Varchar).Value = cm_evaluador.SelectedValue
        ocmd.Parameters.Add("@f0600_fecha_ocurrencia_evento", NpgsqlDbType.Timestamp).Value = dtp_fecha_ocurrencia.Value
        ocmd.Parameters.Add("@f0600_unidad_duracion", NpgsqlDbType.Varchar).Value = "00000028"
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("@f0600_fecha_cierre_correctivo", NpgsqlDbType.Timestamp).Value = dtp_fecha_fin_correctivo.Value
        ocmd.Parameters.Add("@f0600_fecha_reporte_encargado", NpgsqlDbType.Timestamp).Value = dtp_fecha_reporte_encargado.Value
        ocmd.Parameters.Add("@f0600_fecha_inicio_correctivo", NpgsqlDbType.Timestamp).Value = dtp_fecha_inicio_correctivo.Value
        ocmd.Parameters.Add("@f0600_fecha_inicio", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub

    Private Sub bt_fecha_ocurrencia_Click(sender As System.Object, e As System.EventArgs) Handles bt_fecha_ocurrencia.Click
        cambios_de_fecha(dtp_fecha_ocurrencia, lb_fecha_ocurrencia, "f0600_fecha_ocurrencia_evento", "OCURRENCIA DEL EVENTO")
    End Sub

    Private Sub bt_fecha_fin_correctivo_Click(sender As System.Object, e As System.EventArgs) Handles bt_fecha_fin_correctivo.Click
        cambios_de_fecha(dtp_fecha_fin_correctivo, lb_fecha_fin_correctivo, "f0600_fecha_cierre_correctivo", "FINALIZA CORRECTIVO")
    End Sub

    Private Sub bt_fecha_rep_encargado_Click(sender As Object, e As EventArgs) Handles bt_fecha_rep_encargado.Click
        cambios_de_fecha(dtp_fecha_reporte_encargado, lb_fecha_rep_encargado, "f0600_fecha_reporte_encargado", "REPORTE AL ENCARGADO")
    End Sub

    Private Sub bt_fecha_inicio_correctivo_Click(sender As Object, e As EventArgs) Handles bt_fecha_inicio_correctivo.Click
        cambios_de_fecha(dtp_fecha_inicio_correctivo, lb_fecha_ini_correctivo, "f0600_fecha_inicio_correctivo", "INICIO CORRECTIVO")
    End Sub

    Private Sub cambios_de_fecha(ByVal dtp As Object, ByVal lb_fecha As Object, ByVal campo_fechas As String, ByVal nombre_de_la_fecha As String)
        Dim nueva_fecha_hora As String
        Dim vieja_fecha As Date = dtp.Value
        verror_requisitos = "N"
        validar_cambios_solo_creador()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        nueva_fecha_hora = comunes.formulario_fecha_hora(dtp.Value)
        If nueva_fecha_hora = "ND" Then
            Exit Sub
        End If
        If CDate(nueva_fecha_hora) = vieja_fecha Then
            Exit Sub
        End If
        If CDate(nueva_fecha_hora) > comunes.g_fechahora Then
            MsgBox("Fecha no valida. Es mayor a la fecha actual", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Dim owhere As String
        owhere = "where f0600_id_accion = '" & id_accion & "'"
        If vf_elemento_nuevo = "N" Then
            comunes.actualizar_campo_date_tabla("tb0600_acciones", campo_fechas, CDate(nueva_fecha_hora), owhere)
            dtp.Value = CDate(nueva_fecha_hora)

            'agregar nota registrando el cambio
            Dim txt_seguimiento As String
            If dtp.Visible = True Then
                txt_seguimiento = "CAMBIO FECHA DE " & UCase(nombre_de_la_fecha) & vbCrLf
                txt_seguimiento += "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo el siguiente cambio:" & vbCrLf
                txt_seguimiento += "Cambio de: (" + vieja_fecha.ToString("yyyy/MM/dd  HH:mm") + ") a: (" + CDate(nueva_fecha_hora).ToString("yyyy/MM/dd  HH:mm") + ")"
                cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia)
            Else
                txt_seguimiento = "SE ASIGNO VALOR A FECHA DE " & UCase(nombre_de_la_fecha) & vbCrLf
                txt_seguimiento += "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Asigno como valor de fecha: "
                txt_seguimiento += "(" + CDate(nueva_fecha_hora).ToString("yyyy/MM/dd  HH:mm") + ")"
                cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia)

            End If
            dtp.Visible = True
            lb_fecha.Visible = False
            MsgBox("Fecha actualizada", MsgBoxStyle.Information, "Actualizado")
        Else
            'MsgBox("Hola")
            dtp.Value = CDate(nueva_fecha_hora)
            lb_fecha.visible = False
        End If
    End Sub

    Private Sub bt_activar_tercero_Click(sender As Object, e As EventArgs) Handles bt_activar_tercero.Click
        If gb_tercero.Enabled = False Then
            gb_tercero.Enabled = True
        Else
            gb_tercero.Enabled = False
        End If
    End Sub

    Private Sub cm_nit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_nit.Validating
        If cm_nit.SelectedIndex = -1 Then
            cm_razon_social.SelectedIndex = -1
        End If
    End Sub

    Private Sub cm_razon_social_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_razon_social.Validating
        If cm_razon_social.SelectedIndex = -1 Then
            cm_nit.SelectedIndex = -1
        End If
    End Sub

    Private Sub bt_productos_rel_Click(sender As Object, e As EventArgs) Handles bt_productos_rel.Click
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_relacionar_items As New camocontrol.fm_0600_relacionar_items_accion
        oform_relacionar_items.vf_oform_padre = Me
        oform_relacionar_items.id_accion = id_accion
        oform_relacionar_items.id_tercero = cm_razon_social.SelectedValue
        oform_relacionar_items.NIT = cm_nit.Text
        oform_relacionar_items.emisor_accion = usuario_creador
        oform_relacionar_items.vg_id_cia = vg_id_cia
        oform_relacionar_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_relacionar_items.ShowDialog()
    End Sub

    Private Sub bt_imprimir_Click(sender As Object, e As EventArgs) Handles bt_imprimir.Click
        If tx_id_accion.Text.Trim = "" Then
            MsgBox("Actividad fallida", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        cl_informes_comunes.reporte_plan_accion_proyecto(vg_id_cia, tx_id_accion.Text)
    End Sub

End Class
