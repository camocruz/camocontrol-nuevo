Imports System.ComponentModel

Public Class fm_0600_gestion_tareas
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_estructura As Integer = 0
    Public id_accion As Integer
    Public id_accion_principal As Integer
    Public id_accion_padre As Integer
    Public path_padre As String = "-"
    Public fuente_padre As String = ""

    Private new_name_file As String = ""

    Public cambiar_estructura As String = "N"

    Private id_tipo_Accion As String = String.Empty

    Private path_accion As String
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
    Private cambio_fecha As String = "N"
    Private fecha_fin_antigua As Date
    Private cambio_descripcion As String = "N"
    Private descripcion_antigua As String = ""
    Private txt_seguimiento As String = ""
    Private nivel_cumplimiento As String = "000"
    Private csql As String
    Private fecha_limite As DateTime
    Private repeticiones As Integer = 1
    Private tipo_registro_acciones As String = "03" 'Tarea simple, 04 = tarea repetitiva
    Private tipo_nota As String
    Private actividad_anulada As String = "N"
    Private admin_act_manto As String = "N" 'tiene permisos de administrador de activiades de mantenimiento.

    Private orow_info_accion As DataRow 'contiene informacion de la accion actual
    Private otb_unidad_tiempo As DataTable

    'informaciones para programar nuevas tareas hijo de tareas repetitivas
    Private tarea_repetitiva As String = "N"
    Private repeticion_programada As String = "N"
    Private periodo_nueva_repeticion As Integer = 0
    Private repeticiones_programadas As Integer
    Private repeticiones_ejecutadas As Integer = 0
    Private duracion As TimeSpan
    Private nueva_fecha_inicio As Date
    Private nueva_fecha_limite As Date

    Private otb_info_personal As DataTable
    Private otb_info_accion_padre As DataTable
    Private otb_estructura_mantenimiento As DataTable
    Private otb_accion As DataTable
    Private otb_acciones_arbol As DataTable 'todas las acciones involucradas en el arbol al que pertenece la accion actual

    Private Sub fm_0600_gestion_tareas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        cl_utilidades_gestion_acciones.actualizar_estado_acciones(0, vg_usuario_autoriza, vg_id_cia) 'Actualizamos el estado de todas las acciones
        'cl_utilidades_gestion_acciones.actualizar_estado_acciones(id_accion, vg_usuario_autoriza, vg_id_cia) 'Actualizamos el estado de esta accion

        admin_act_manto = cl_gestion_permisos.identificar_permisos_especiales_formularios("ADMIN_ACT_MANTO", vf_otabla_permisos, vg_usuario_autoriza)

        tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
        bt_cierre_rrapido.Enabled = False
        If vg_usuario_autoriza = "00000001" Or vg_usuario_autoriza = "00000004" Then
            bt_anular.Enabled = True
        Else
            bt_anular.Enabled = False
        End If
        cargar_todos_los_combos_y_formatos()

        If vf_elemento_nuevo = "S" Then
            formato_tarea_simple()
            tx_duracion.Text = 1
            dtp_fecha_inicio_prog.Value = comunes.g_fechahora
            dtp_fecha_fin_prog.Value = comunes.g_fechahora
            dtp_fecha_cierre_real.Visible = False
            lb_fecha_cierre.Visible = True
            If fuente_padre <> "" Then
                cm_fuente_accion.SelectedValue = fuente_padre
            End If
            cm_estado.SelectedIndex = 1
            cm_tipo_accion.SelectedIndex = -1
            cm_unidad_duracion.SelectedIndex = 1
            cm_responsable.SelectedIndex = -1
            cm_evaluador.SelectedIndex = -1
            cm_emisor.SelectedIndex = -1
            tx_periodo.Enabled = False
            tx_repeticiones.Enabled = False
            chk_permanente.Enabled = False
            If IsDBNull(id_estructura) = False Then
                tx_estructura.Text = comunes.traer_nombre_estructura(id_estructura)
            End If
        End If
        If vf_elemento_nuevo = "N" Then
            grb_tipo_tarea.Enabled = False
            traer_informacion_accion()
        End If
        'tx_id_accion.Text = "N/A"
        'tx_texto_accion.Text = "N/A"
        calcular_fecha_finalizacion_tarea_simple()
    End Sub
    Private Sub desplegar_path()
        Dim actividades() As String = Split(path_accion & id_accion & "-", "-")
        cm_path.Items.Add(path_accion & id_accion & "-")
        If actividades.Length = 3 Then
            cm_path.SelectedIndex = 0
            Exit Sub
        End If
        Dim i As Integer = 1
        'MsgBox(actividades.Length)
        Dim tx As String = "    "
        Dim tx2 As String = ""
        For Each orow As String In actividades
            If orow.ToString <> "" Then
                cm_path.Items.Add(tx2 & orow)
                tx2 += tx
                If i = 1 Then
                    otb_acciones_arbol = cl_utilidades_gestion_acciones.obtener_datatable_acciones_hijo("-" & orow & "-")
                    'MsgBox(otb_acciones_arbol.Rows.Count)
                    i = 2
                End If
            End If
        Next
        cm_path.SelectedIndex = 0
    End Sub
    Private Sub traer_informacion_accion()
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones where f0600_id_accion = " & id_accion
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'tx_cumplimiento.Text = cl_utilidades_gestion_acciones.obtener_nivel_cumplimiento_actual(id_accion, tipo_nota).ToString & "%"
        For Each orow As DataRow In otb_accion.Rows
            'habilitamos el registro de soportes y elemntos relacionados
            bt_nuevo_soporte.Enabled = True
            bt_ver_archivos_asociados.Enabled = True
            bt_actividades_hijo.Enabled = True
            bt_seguimientos.Enabled = True
            bt_recursos.Enabled = True
            bt_informe.Enabled = True
            'bt_cambiar_fechas.Enabled = True

            'si es una actividad anulada
            If orow("f0600_anulado") = "S" Then
                actividad_anulada = "S"
            End If

            orow_info_accion = orow
            path_accion = orow("f0600_path")
            'tx_path.Text = path_accion & id_accion & "-"

            'tx_id_accion_principal.Text = orow("f0600_id_accion_principal").ToString
            'tx_id_accion_padre.Text = orow("f0600_id_accion_padre").ToString
            tx_id_tarea.Text = orow("f0600_id_accion")
            nivel_cumplimiento = orow("f0600_nivel_cumplimiento")
            tx_cumplimiento.Text = CInt(nivel_cumplimiento).ToString & "%"
            id_estructura = orow("f0600_id_estructura")
            tx_estructura.Text = comunes.traer_nombre_estructura(orow("f0600_id_estructura").ToString)
            tx_texto_tarea.Text = orow("f0600_descripcion")
            descripcion_antigua = orow("f0600_descripcion")
            tx_titulo.Text = orow("f0600_titulo")
            cm_estado.SelectedValue = orow("f0600_id_estado_accion")
            cm_fuente_accion.SelectedValue = orow("f0600_id_fuente_accion")
            If orow("f0600_id_estado_accion").ToString = "08" Then '08 es estado cerrado
                actividad_cerrada = "S"
                'Protejo la actividad de cambios.
                BloquearCambios("S")
            Else
                BloquearCambios("N")
            End If
            If orow("f0600_id_tipo_registro").ToString = "04" Then
                lb_titulo.Text = "Definicion de una actividad Repetitiva"
                formato_tarea_repetitiva()
            Else
                lb_titulo.Text = "Definicion de una actividad Simple"
                formato_tarea_simple()
            End If
            If actividad_anulada = "S" Then
                lb_titulo.Text = "¡¡¡ACTIVIDAD ANULADA!!!"
            End If
            cm_tipo_accion.SelectedValue = orow("f0600_id_tipo_accion")
            id_tipo_Accion = orow("f0600_id_tipo_accion")
            tx_duracion.Text = orow("f0600_duracion")
            cm_unidad_duracion.SelectedValue = orow("f0600_unidad_duracion")
            dtp_fecha_inicio_prog.Value = orow("f0600_fecha_inicio")
            dtp_fecha_fin_prog.Value = orow("f0600_fecha_limite")
            fecha_fin_antigua = orow("f0600_fecha_limite")
            cm_responsable.SelectedValue = orow("f0600_responsable")
            cm_evaluador.SelectedValue = orow("f0600_evaluador")
            If orow("f0600_evaluador") = vg_usuario_autoriza Or admin_act_manto = "S" Or vg_usuario_autoriza = "00000001" Then
                bt_cierre_rrapido.Enabled = True
            Else
                bt_cierre_rrapido.Enabled = False
            End If
            cm_emisor.SelectedValue = orow("f0600_emisor")
            usuario_creador = orow("f0600_emisor")
            usuario_evaluador = orow("f0600_evaluador")
            If orow("f0600_fecha_cierre").ToString = "" Then
                dtp_fecha_cierre_real.Visible = False
                lb_fecha_cierre.Visible = True
            Else
                dtp_fecha_cierre_real.Value = orow("f0600_fecha_cierre")
                lb_fecha_cierre.Visible = False
            End If

            desplegar_path()

            If orow("f0600_id_fuente_accion") = "00000003" And IsDBNull(orow("f0600_id_estructura")) = False Then 'indica que es actividad programa mantenimiento
                csql = "SELECT *, f0100_nombre || ' -- { ' || f0100_codigo || ' }' as descripcion_nombre," _
                        & " f0100_codigo || ' -- { ' || f0100_nombre || ' }' as descripcion_codigo" _
                        & " FROM " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
                        & " where f0100_id_estructura = " & orow("f0600_id_estructura") _
                        & " order by f0100_estructura_padre;"
                'otb_estructura_mantenimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                'For Each orow2 As DataRow In otb_estructura_mantenimiento.Rows
                'tx_texto_accion.Text = "Actividad mantenimiento para equipo o estructura: " & vbCrLf _
                '& orow2("descripcion_codigo")
                'Next
            End If
            tipo_registro_acciones = orow("f0600_id_tipo_registro")
            If tipo_registro_acciones = "03" Then
                formato_tarea_simple()
                'MsgBox("simple")
            Else
                formato_tarea_repetitiva()
                'MsgBox("repetitivo")
                tx_periodo.Text = orow("f0600_periodo_repeticion")
                If orow("f0600_repeticiones_indefinidas").ToString = "S" Then
                    chk_permanente.Checked = True
                    tx_repeticiones.Text = "N/A"
                Else
                    chk_permanente.Checked = False
                    tx_repeticiones.Text = orow("f0600_repeticiones_programadas")
                End If
            End If

            'Informacion requerida para programar nueva tarea hijo de tarea repetitiva
            repeticion_programada = orow("f0600_repeticion_programada")
            'evaluador_accion = orow("f0600_evaluador").ToString
            tarea_repetitiva = orow("f0600_repetitiva")

            If IsDBNull(orow("f0600_id_accion_padre")) = False Then
                id_accion_padre = orow("f0600_id_accion_padre")
            Else
                id_accion_padre = 0
            End If
            If IsDBNull(orow("f0600_id_accion_principal")) = False Then
                id_accion_principal = orow("f0600_id_accion_principal")
            Else
                id_accion_principal = 0
            End If

            'Try
            '    id_accion_padre = orow("f0600_id_accion_padre")
            'Catch ex As Exception
            '    id_accion_padre = 0
            'End Try
            'Try
            '    id_accion_principal = orow("f0600_id_accion_principal")
            'Catch ex As Exception
            '    id_accion_principal = 0
            'End Try
        Next

        'PARA CONTROLAR LA INFORMACION DE LOS DOCUMENTOS ASOCIADOS
        new_name_file = comunes.suministrar_valor_variable_configuracion("CD-ACC-001", vg_id_cia)
        new_name_file += "-" & tx_id_tarea.Text.PadLeft(8, "0")
        calcular_archivos_asociados()
    End Sub

    Private Sub BloquearCambios(bloquear As String)

        If bloquear = "S" Then
            bt_cambiar_infraestructura.Enabled = False
            cm_fuente_accion.Enabled = False
            tx_titulo.ReadOnly = True
            tx_texto_tarea.ReadOnly = True
            cm_tipo_accion.Enabled = False
            tx_duracion.ReadOnly = True
            cm_unidad_duracion.Enabled = False
            dtp_fecha_inicio_prog.Enabled = False
            cm_responsable.Enabled = False
            cm_evaluador.Enabled = False
        Else
            bt_cambiar_infraestructura.Enabled = True
            cm_fuente_accion.Enabled = True
            tx_titulo.ReadOnly = False
            tx_texto_tarea.ReadOnly = False
            cm_tipo_accion.Enabled = True
            tx_duracion.ReadOnly = False
            dtp_fecha_inicio_prog.Enabled = True
            cm_responsable.Enabled = True
            cm_evaluador.Enabled = True
        End If

    End Sub
    Private Sub formato_tarea_repetitiva()
        'lb_titulo.Text = "Definicion de una Actividad Repetitiva"
        rb_repetitiva.Checked = True
        tipo_registro_acciones = "04"
        tx_periodo.Enabled = True
        tx_repeticiones.Enabled = True
        chk_permanente.Enabled = True
        tx_periodo.Text = 1
        tx_repeticiones.Text = 2

        If id_tipo_Accion <> "02" And actividad_cerrada = "N" Then
            cm_tipo_accion.Enabled = True
        Else
            cm_tipo_accion.Enabled = False
        End If
        If vf_elemento_nuevo = "S" Then
            cm_estado.SelectedValue = "15"
            cm_tipo_accion.SelectedValue = "02"
        End If

    End Sub
    Private Sub formato_tarea_simple()
        rb_simple.Checked = True
        'cm_tipo_accion.Enabled = True
        'lb_titulo.Text = "Definicion de una Actividad Simple"
        tipo_registro_acciones = "03"
        tx_periodo.Enabled = False
        tx_repeticiones.Enabled = False
        chk_permanente.Enabled = False
        tx_periodo.Text = "N/A"
        tx_repeticiones.Text = "N/A"
    End Sub
    Private Sub cargar_todos_los_combos_y_formatos()
        bt_nuevo_soporte.Enabled = False
        bt_ver_archivos_asociados.Enabled = False
        bt_actividades_hijo.Enabled = False
        bt_seguimientos.Enabled = False
        bt_recursos.Enabled = False
        bt_informe.Enabled = False
        'bt_cambiar_fechas.Enabled = False

        'tx_id_accion_principal.Enabled = False
        'tx_id_accion_padre.Enabled = False
        'tx_texto_accion.Enabled = False
        tx_id_tarea.Enabled = False
        cm_estado.Enabled = False
        tx_estructura.ReadOnly = True
        tx_repeticiones.Text = "2"
        tx_periodo.Text = "1"
        rb_simple.Checked = True
        ' Set the Format type and the CustomFormat string.
        dtp_fecha_inicio_prog.Format = DateTimePickerFormat.Custom
        dtp_fecha_inicio_prog.CustomFormat = "yyyy/MM/dd   hh:mm  tt"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_fin_prog.Format = DateTimePickerFormat.Custom
        dtp_fecha_fin_prog.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_fin_prog.Enabled = False

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_cierre_real.Format = DateTimePickerFormat.Custom
        dtp_fecha_cierre_real.CustomFormat = "yyyy/MM/dd   hh:mm  tt"
        dtp_fecha_cierre_real.Enabled = False

        With cm_path
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0601_fuentes_acciones"
        Dim otb_fuentes As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_fuente_accion
            If fuente_padre = "" And vf_elemento_nuevo = "S" Then
                .Enabled = True
            End If
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

        csql = " select *" _
            & " FROM " & database.obtener_esquema & ".tb0002_unidades_medicion" _
            & " where f0002_id_tipo_unidad = '00000005'"
        otb_unidad_tiempo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_unidad_duracion
            'Valor que se muestra al usuario
            .DisplayMember = "f0002_unidad_medicion"
            'Valor interno que almacena el objeto
            .ValueMember = "f0002_id_unidad_medicion"
            'Origen de Datos del ComboBox
            .DataSource = otb_unidad_tiempo
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
        End With

    End Sub
    Private Sub validar_que()
        If tx_texto_tarea.Text.Trim = "" Then
            vmensaje_requisitos = "No hay una descripcion (Que) de la actividad a realizar."
            verror_requisitos = "S"
        End If
        If descripcion_antigua <> tx_texto_tarea.Text And vf_elemento_nuevo = "N" Then
            cambio_descripcion = "S"
        End If
    End Sub
    Private Sub validar_estado()
        If cm_estado.SelectedIndex = -1 Then
            vmensaje_requisitos = "Debe seleccionar un estado para la accion."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_tipo()
        If cm_tipo_accion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Debe seleccionar el tipo de accion."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_receptor()
        If cm_responsable.SelectedIndex = -1 Then
            vmensaje_requisitos = "Debe seleccionar Quien realizara la Actividad."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_evaluador()
        If cm_evaluador.SelectedIndex = -1 Then
            vmensaje_requisitos = "Debe seleccionar Evaluador para la Actividad."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub validar_fuente()
        If cm_fuente_accion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Debe seleccionar una Fuente para esta actividad."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub ajustar_estado_accion_cambio_fechas()
        If actividad_cerrada = "S" Then
            Exit Sub
        End If
        If fecha_fin_antigua <> dtp_fecha_fin_prog.Value And vf_elemento_nuevo = "N" Then
            cambio_fecha = "S"
        End If
        If dtp_fecha_fin_prog.Value > comunes.g_fechahora Then
            If dtp_fecha_inicio_prog.Value > comunes.g_fechahora Then
                cm_estado.SelectedValue = "01"
            Else
                cm_estado.SelectedValue = "03"
            End If
        Else
            cm_estado.SelectedValue = "07"
        End If
        If rb_repetitiva.Checked Then
            cm_estado.SelectedValue = "15"
        End If
    End Sub
    Private Sub cm_unidad_duracion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_unidad_duracion.Validating
        If chk_permanente.Checked = False Then
            calcular_fecha_finalizacion_tarea_simple()
            ajustar_estado_accion_cambio_fechas()
        End If
    End Sub
    Private Sub validar_fechas_inicio_fin()
        If dtp_fecha_fin_prog.Value <= dtp_fecha_inicio_prog.Value Then
            vmensaje_requisitos = "La fecha de finalizacion no pude ser menor que la fecha de inicial"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub tx_duracion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_duracion.Validating
        If tx_duracion.Text.Trim = "" Or CInt(tx_duracion.Text.Trim) = 0 Then
            tx_duracion.Text = 1
        End If
        If chk_permanente.Checked = False Then
            calcular_fecha_finalizacion_tarea_simple()
            ajustar_estado_accion_cambio_fechas()
        End If
    End Sub
    Private Sub tx_duracion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_duracion.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub validar_duracion()
        If tx_duracion.Text.Trim = "" Or IsNumeric(tx_duracion.Text.Trim) = False Or cm_unidad_duracion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Defina una duracion valida."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub dtp_fecha_inicio_prog_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtp_fecha_inicio_prog.Validating
        calcular_fecha_finalizacion_tarea_simple()
        ajustar_estado_accion_cambio_fechas()
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
            'para habilitar cambios si tiene administraccion de programacion de estructuras o maquinas.
            If tx_estructura.Text.ToString.Trim <> "" And admin_act_manto = "S" Then
                p_cambios = "S"
            End If
            If p_cambios = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Solo el emisor o el evaluador pueden realizar cambios en este registro!"
            End If
        End If
    End Sub
    Private Sub validar_cierre_rechazo_solo_evaluador()
        Dim p_cambios As String = "N"
        If vf_elemento_nuevo = "N" Then
            If cm_estado.SelectedValue.ToString = "08" Or cm_estado.SelectedValue.ToString = "04" Then '08 es estado cerrado
                If vg_usuario_autoriza = usuario_evaluador Then
                    p_cambios = "S"
                End If
                If vg_usuario_autoriza = "00000001" Then
                    p_cambios = "S"
                End If
                If p_cambios = "N" Then
                    verror_requisitos = "S"
                    vmensaje_requisitos = "Solo el evaluador puede cerrar o rechazar una accion!"
                End If
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
    Private Sub bt_recursos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_recursos.Click
        If tx_id_tarea.Text.ToString = "" Then
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
        oform_programar_recurso.id_accion = tx_id_tarea.Text
        oform_programar_recurso.id_estructura = id_estructura
        oform_programar_recurso.ShowDialog()
    End Sub

    Private Sub bt_seguimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_seguimientos.Click
        'MsgBox(id_accion & "--" & tipo_nota & "--" & vg_usuario_autoriza)

        cl_gestion_anotaciones.consultar_anotaciones_acciones(id_accion, tipo_nota, vg_usuario_autoriza, vg_id_cia, "ST-0606-01", "1")
        'tx_cumplimiento.Text = cl_utilidades_gestion_acciones.obtener_nivel_cumplimiento_actual(id_accion, tipo_nota).ToString & "%"
        traer_informacion_accion()
    End Sub

    Private Sub registrar_cambios()
        'agregar nota registrando el cambio
        If cambio_fecha = "S" Then
            If txt_seguimiento <> "" Then
                txt_seguimiento = txt_seguimiento & vbCrLf & vbCrLf
            End If
            txt_seguimiento += "CAMBIO FECHA DE FINALIZACION" & vbCrLf
            txt_seguimiento += "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo el siguiente cambio:" & vbCrLf
            txt_seguimiento += "Cambio la fecha de finalizacion del: (" + fecha_fin_antigua.ToString("yyyy/MM/dd  HH:mm") + ") al: (" + CDate(dtp_fecha_fin_prog.Value).ToString("yyyy/MM/dd  HH:mm") + ")"
        End If

        If cambio_descripcion = "S" Then
            If txt_seguimiento <> "" Then
                txt_seguimiento = txt_seguimiento & vbCrLf & vbCrLf
            End If
            txt_seguimiento += "CAMBIO TEXTO ACCION" & vbCrLf
            txt_seguimiento += "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo el siguiente cambio:" & vbCrLf
            txt_seguimiento += "Cambio el texto descriptivo de:" & vbCrLf & descripcion_antigua & vbCrLf & vbCrLf _
                & "A:" & vbCrLf & vbCrLf & tx_texto_tarea.Text
        End If
        If txt_seguimiento = "" Then
            txt_seguimiento = "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo cambios en la definicion de la actividad:"
        End If
        cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia, nivel_cumplimiento)
        cambio_fecha = "N"
        cambio_descripcion = "N"
        txt_seguimiento = ""
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
        validar_estado()
        validar_tipo()
        validar_fechas_inicio_fin()
        validar_duracion()
        validar_repeticiones()
        validar_evaluador()
        validar_receptor()
        validar_fuente()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        'autoriza = "N"
        'Dim oform_login As New camocontrol.login
        'oform_grilla_programacion.ods_hijo = ods
        'oform_login.vf_oform_padre = Me
        'oform_login.paso_autorizacion = "S"
        'oform_login.ShowDialog()
        'If autoriza = "N" Then
        'Exit Sub
        'End If

        'segundo bloque de validaciones que se relacionan con el usuario
        verror_requisitos = "N"
        validar_cambios_solo_creador()
        validar_cierre_rechazo_solo_evaluador()
        validar_modificacion_actividad_cerrada()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            id_accion = grabar_nueva_tarea()
            'tx_id_tarea.Text = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0600_id_accion", "f0600_usuario_crear", vg_usuario_autoriza, "tb0600_acciones")
            tx_id_tarea.Text = id_accion
            traer_informacion_accion()
            'funcion que actualiza los path de un arbol a partir de la rama seleccionada.
            'cl_utilidades_gestion_acciones.actualizar_ramal(id_accion_padre, path_padre, "tb0600_acciones", "f0600_id_accion", _
            '"f0600_path", "f0600_id_accion_padre")
            If tipo_registro_acciones = "04" Then
                'creamos la primer tarea del programa de manto.
                tipo_registro_acciones = "03" '03=tarea
                id_accion_padre = tx_id_tarea.Text
                id_accion_principal = tx_id_tarea.Text ' tx_id_accion_principal.Text
                path_padre = "-" 'lo reiniciamos para que dependa solamente de la periodica.
                calcular_fecha_finalizacion_tarea_simple()
                grabar_nueva_tarea()
            End If
        Else
            actualizar_tarea()
            registrar_cambios()
        End If
        If verror = "N" Then
            MsgBox("La actividad fue grabada", MsgBoxStyle.Information, "Grabar")
            vf_elemento_nuevo = "N"
            'Dispose()
        End If
    End Sub
    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        grabar()
    End Sub
    Private Function grabar_nueva_tarea()
        Dim id_nueva_Acion As Integer = 0
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0600_acciones" _
                & " (f0600_id_cia, f0600_id_accion_padre, f0600_id_accion_principal," _
                & " f0600_id_estructura, f0600_titulo, f0600_descripcion, f0600_id_estado_accion," _
                & " f0600_id_fuente_accion, f0600_unidad_duracion, f0600_duracion," _
                & " f0600_periodo_repeticion, f0600_repeticiones_programadas," _
                & " f0600_repeticiones_indefinidas, f0600_repetitiva, f0600_repeticiones_ejecutadas," _
                & " f0600_id_tipo_accion, f0600_responsable, f0600_evaluador, f0600_id_tipo_registro," _
                & " f0600_emisor, f0600_fecha_inicio, f0600_path," _
                & " f0600_usuario_modificar, f0600_usuario_crear, f0600_fm, f0600_fecha_limite)" _
                & " VALUES" _
                & " (@f0600_id_cia, @f0600_id_accion_padre, @f0600_id_accion_principal," _
                & " @f0600_id_estructura, @f0600_titulo, @f0600_descripcion, @f0600_id_estado_accion," _
                & " @f0600_id_fuente_accion, @f0600_unidad_duracion, @f0600_duracion," _
                & " @f0600_periodo_repeticion, @f0600_repeticiones_programadas," _
                & " @f0600_repeticiones_indefinidas, @f0600_repetitiva, @f0600_repeticiones_ejecutadas," _
                & " @f0600_id_tipo_accion, @f0600_responsable, @f0600_evaluador, @f0600_id_tipo_registro," _
                & " @f0600_emisor, @f0600_fecha_inicio, @f0600_path," _
                & " @f0600_usuario_modificar, @f0600_usuario_crear, @f0600_fm, @f0600_fecha_limite)" _
                & " RETURNING f0600_id_accion;"


        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        If tarea_repetitiva = "N" Then
            crear_parametros_tarea(ocmd)
        Else
            crear_parametros_nueva_tarea_hijo_repetitiva(ocmd)
        End If

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
                id_nueva_Acion = ocmd.ExecuteScalar()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        'para que se gestione obligatoriamente la tarea repetitiva creada.
        If tarea_repetitiva = "S" And verror = "N" Then
            Dispose()
        End If
        Return id_nueva_Acion
    End Function

    Private Sub actualizar_tarea()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += "f0600_titulo = @f0600_titulo,"
        csql += "f0600_descripcion = @f0600_descripcion,"
        csql += "f0600_id_estado_accion = @f0600_id_estado_accion,"
        csql += "f0600_unidad_duracion = @f0600_unidad_duracion, "
        csql += "f0600_duracion = @f0600_duracion,"
        csql += "f0600_id_tipo_accion = @f0600_id_tipo_accion,"

        csql += "f0600_periodo_repeticion = @f0600_periodo_repeticion,"
        csql += "f0600_repeticiones_programadas = @f0600_repeticiones_programadas,"
        csql += "f0600_repeticiones_indefinidas = @f0600_repeticiones_indefinidas,"
        csql += "f0600_repetitiva = @f0600_repetitiva,"
        csql += "f0600_repeticiones_ejecutadas = @f0600_repeticiones_ejecutadas,"

        csql += "f0600_responsable = @f0600_responsable,"
        csql += "f0600_evaluador = @f0600_evaluador,"
        csql += "f0600_fecha_inicio = @f0600_fecha_inicio,"
        csql += "f0600_fecha_limite = @f0600_fecha_limite,"
        csql += "f0600_fm = @f0600_fm,"
        csql += "f0600_usuario_modificar = @f0600_usuario_modificar"
        csql += " where f0600_id_accion = @f0600_id_accion"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_tarea(ocmd)
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
    Private Sub crear_parametros_tarea(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("f0600_id_accion", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(id_accion)
        End If
        ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        If id_accion_principal = 0 Then
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(id_accion_principal)
        End If
        If id_accion_padre <> 0 Then
            ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(id_accion_padre)
            ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = path_padre & id_accion_padre & "-"
        Else
            ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = DBNull.Value
            ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = "-"
        End If
        ocmd.Parameters.Add("@f0600_id_estructura", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(id_estructura)
        ocmd.Parameters.Add("@f0600_titulo", NpgsqlDbType.Varchar).Value = UCase(tx_titulo.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = UCase(tx_texto_tarea.Text.ToString.Trim)

        ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(cm_fuente_accion.SelectedValue)
        ocmd.Parameters.Add("@f0600_id_tipo_accion", NpgsqlDbType.Varchar).Value = cm_tipo_accion.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_unidad_duracion", NpgsqlDbType.Varchar).Value = cm_unidad_duracion.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_duracion", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(tx_duracion.Text.ToString.Trim)
        If tipo_registro_acciones = "03" Then
            ocmd.Parameters.Add("@f0600_id_tipo_registro", NpgsqlDbType.Varchar).Value = "03" '03=tarea simple
            ocmd.Parameters.Add("@f0600_periodo_repeticion", NpgsqlDbType.Integer).Value = 0
            ocmd.Parameters.Add("@f0600_repeticiones_programadas", NpgsqlDbType.Integer).Value = 0
            ocmd.Parameters.Add("@f0600_repeticiones_indefinidas", NpgsqlDbType.Varchar).Value = "N"
            ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = cm_estado.SelectedValue.ToString
            If rb_repetitiva.Checked = True Then
                ocmd.Parameters.Add("@f0600_repetitiva", NpgsqlDbType.Varchar).Value = "S"
            Else
                ocmd.Parameters.Add("@f0600_repetitiva", NpgsqlDbType.Varchar).Value = "N"
            End If
            ocmd.Parameters.Add("@f0600_repeticiones_ejecutadas", NpgsqlDbType.Integer).Value = 0
        Else 'entonces es 04 = tarea repetitiva
            ocmd.Parameters.Add("@f0600_id_tipo_registro", NpgsqlDbType.Varchar).Value = "04" '03=tarea simple
            ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = cm_estado.SelectedValue.ToString '"15"
            ocmd.Parameters.Add("@f0600_periodo_repeticion", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(tx_periodo.Text.ToString.Trim)
            ocmd.Parameters.Add("@f0600_repeticiones_programadas", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(repeticiones)
            If chk_permanente.Checked = True Then
                ocmd.Parameters.Add("@f0600_repeticiones_indefinidas", NpgsqlDbType.Varchar).Value = "S"
            Else
                ocmd.Parameters.Add("@f0600_repeticiones_indefinidas", NpgsqlDbType.Varchar).Value = "N"
            End If
            ocmd.Parameters.Add("@f0600_repetitiva", NpgsqlDbType.Varchar).Value = "S"
            ocmd.Parameters.Add("@f0600_repeticiones_ejecutadas", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(1)
        End If
        ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = cm_responsable.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_evaluador", NpgsqlDbType.Varchar).Value = cm_evaluador.SelectedValue.ToString
        ocmd.Parameters.Add("@f0600_emisor", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fecha_inicio", NpgsqlDbType.Timestamp).Value = dtp_fecha_inicio_prog.Value
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("@f0600_fecha_limite", NpgsqlDbType.Timestamp).Value = fecha_limite
    End Sub

    Private Sub crear_parametros_nueva_tarea_hijo_repetitiva(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0002_unidades_medicion" _
            & " where f0002_id_tipo_unidad = '00000005'"
        otb_unidad_tiempo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Donde cargo la info de accion padre
        If id_accion_padre = 0 Then
            id_accion_padre = id_accion
        End If
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones" _
                & " where f0600_id_accion = '" & id_accion_padre & "'"
        otb_info_accion_padre = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_accion_padre.Rows
            ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = orow("f0600_id_cia")
            If IsDBNull(orow("f0600_id_accion_principal")) = True Then
                ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(orow("f0600_id_accion"))
            Else
                ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(orow("f0600_id_accion_principal"))
            End If
            ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(orow("f0600_id_accion"))
            ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = orow("f0600_path") & id_accion_padre & "-"
            ocmd.Parameters.Add("@f0600_id_estructura", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(orow("f0600_id_estructura"))
            ocmd.Parameters.Add("@f0600_titulo", NpgsqlDbType.Varchar).Value = orow("f0600_titulo")
            ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = orow("f0600_descripcion")
            ocmd.Parameters.Add("@f0600_id_tipo_registro", NpgsqlDbType.Varchar).Value = "03" 'es una tarea normal
            ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(orow("f0600_id_fuente_accion"))
            ocmd.Parameters.Add("@f0600_id_tipo_accion", NpgsqlDbType.Varchar).Value = orow("f0600_id_tipo_accion")
            ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = "01" '01 = Programada
            ocmd.Parameters.Add("@f0600_unidad_duracion", NpgsqlDbType.Varchar).Value = orow("f0600_unidad_duracion")
            ocmd.Parameters.Add("@f0600_duracion", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(orow("f0600_duracion"))
            ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = orow("f0600_responsable")
            ocmd.Parameters.Add("@f0600_evaluador", NpgsqlDbType.Varchar).Value = orow("f0600_evaluador")
            ocmd.Parameters.Add("@f0600_emisor", NpgsqlDbType.Varchar).Value = orow("f0600_emisor")
            'calcular nueva fecha de inicio
            Dim fecha_ini As Date = Now()
            'MsgBox(orow("f0600_periodo_repeticion"))
            nueva_fecha_inicio = DateAdd(DateInterval.Day, CInt(orow("f0600_periodo_repeticion")), CDate(fecha_ini.ToString("yyyy/MM/dd") & " " & CDate(orow("f0600_fecha_inicio")).ToString("HH:mm")))
            ocmd.Parameters.Add("@f0600_fecha_inicio", NpgsqlDbType.Timestamp).Value = nueva_fecha_inicio
            ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
            ocmd.Parameters.Add("@f0600_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
            ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
            'calcular nueva fecha de finalizacion
            Dim odatarow() As DataRow = otb_unidad_tiempo.Select("f0002_id_unidad_medicion = '" & orow("f0600_unidad_duracion") & "'")
            For Each orow2 As DataRow In odatarow
                nueva_fecha_limite = DateAdd(DateInterval.Second, (orow2("f0002_factor_conversion") * orow("f0600_duracion")), nueva_fecha_inicio)
            Next
            ocmd.Parameters.Add("@f0600_periodo_repeticion", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(0)
            ocmd.Parameters.Add("@f0600_repeticiones_indefinidas", NpgsqlDbType.Varchar).Value = "N"
            ocmd.Parameters.Add("@f0600_fecha_limite", NpgsqlDbType.Timestamp).Value = nueva_fecha_limite
            ocmd.Parameters.Add("@f0600_repetitiva", NpgsqlDbType.Varchar).Value = "S"
            ocmd.Parameters.Add("@f0600_repeticiones_ejecutadas", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(repeticiones_ejecutadas + 1)
            ocmd.Parameters.Add("@f0600_repeticiones_programadas", NpgsqlDbType.Integer).Value = cl_db_helpers.SafeIntZero(repeticiones_programadas)
        Next
    End Sub
    Private Sub bt_cambiar_infraestructura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_cambiar_infraestructura.Click
        verror_requisitos = "N"
        validar_cambios_solo_creador()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
            Exit Sub
        End If
        cambiar_estructura = "N"
        verror_requisitos = "N"

        Dim id_estructura_anterior As Integer = id_estructura
        Dim id_nueva_estructura As String = id_estructura.ToString
        id_nueva_estructura = cl_utilidades_gestion_mantenimiento.suministrar_estructura_mantenimiento(vg_id_cia, vg_usuario_autoriza, id_estructura)
        If id_estructura.ToString <> id_nueva_estructura Then
            If vf_elemento_nuevo = "S" Then
                id_estructura = id_nueva_estructura
                tx_estructura.Text = comunes.traer_nombre_estructura(id_nueva_estructura)
            Else
                If id_estructura_anterior <> id_nueva_estructura Then
                    'MsgBox(id_estructura_anterior & " <> " & id_nueva_estructura)
                    validar_cambios_solo_creador()
                    If verror_requisitos = "S" Then
                        MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
                        Exit Sub
                    End If
                    'MsgBox("Hola")
                    id_estructura = id_nueva_estructura
                    cambiar_estructura_seleccionada()
                    'Agregar seguimiento informando el cambio realizado
                    Dim txt_seguimiento As String
                    txt_seguimiento = "CAMBIO DE ESTRUCTURA MANTENIMIENTO: " & vbCrLf _
                    & "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo el siguiente cambio:" & vbCrLf _
                    & "VALOR INICIAL:" & vbCrLf _
                    & "Equipo: " & comunes.traer_nombre_estructura(id_estructura_anterior.ToString) & vbCrLf _
                    & "CAMBIA A:" & vbCrLf _
                    & "Equipo: " & comunes.traer_nombre_estructura(id_estructura.ToString)
                    cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia, nivel_cumplimiento)
                    traer_informacion_accion()
                    MsgBox("Estructura Cambiada", MsgBoxStyle.Information, "Cambio de Estructura")
                End If
            End If
        End If
    End Sub
    Private Sub cambiar_estructura_seleccionada()
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
    End Sub

    Private Sub chk_permanente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles chk_permanente.Validating
        If chk_permanente.Checked = True Then
            tx_repeticiones.Text = "N/A"
            tx_repeticiones.ReadOnly = True
        Else
            tx_repeticiones.Text = "1"
            tx_repeticiones.ReadOnly = False
        End If
        calcular_fecha_finalizacion_tarea_repetitiva()
    End Sub

    Private Sub tx_repeticiones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_repeticiones.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_repeticiones_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_repeticiones.Validating
        validar_repeticiones()
        calcular_fecha_finalizacion_tarea_repetitiva()
    End Sub
    Private Sub validar_repeticiones()
        If tx_repeticiones.Text = "N/A" Then
            repeticiones = 1000000
            Exit Sub
        End If
        If tx_repeticiones.Text = "" Then
            tx_repeticiones.Text = "2"
        End If
        If CInt(tx_repeticiones.Text) < 2 Then
            tx_repeticiones.Text = "2"
        End If
        repeticiones = tx_repeticiones.Text
    End Sub
    Private Sub validar_periodo()
        If tx_periodo.Text = "" Then
            tx_periodo.Text = "1"
        End If
        If CInt(tx_periodo.Text) = 0 Then
            tx_periodo.Text = "1"
        End If
    End Sub

    Private Sub tx_periodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_periodo.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_periodo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_periodo.Validating
        validar_periodo()
        calcular_fecha_finalizacion_tarea_repetitiva()
    End Sub
    Private Sub calcular_fecha_finalizacion_tarea_simple()
        Dim odatarow() As DataRow = otb_unidad_tiempo.Select("f0002_id_unidad_medicion = '" & cm_unidad_duracion.SelectedValue & "'")
        ' Loop and display.
        For Each orow As DataRow In odatarow
            fecha_limite = DateAdd(DateInterval.Second, orow("f0002_factor_conversion") * CInt(tx_duracion.Text), dtp_fecha_inicio_prog.Value)
            dtp_fecha_fin_prog.Value = fecha_limite
        Next
    End Sub
    Private Sub calcular_fecha_finalizacion_tarea_repetitiva()
        'If tx_repeticiones.Text = "N/A" Then
        'fecha_limite = "2200/01/01"
        'Else
        'fecha_limite = DateAdd(DateInterval.Day, CInt(tx_periodo.Text) * CInt(tx_repeticiones.Text) - 1, dtp_fecha_inicio_prog.Value)
        'End If
        calcular_fecha_finalizacion_tarea_simple()
    End Sub
    Private Sub rb_repetitiva_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_repetitiva.CheckedChanged

    End Sub
    Private Sub rb_repetitiva_Validating(sender As Object, e As CancelEventArgs) Handles rb_repetitiva.Validating
        chk_permanente.Checked = False
        If rb_simple.Checked = True Then
            formato_tarea_simple()
            calcular_fecha_finalizacion_tarea_simple()
        Else
            formato_tarea_repetitiva()
            calcular_fecha_finalizacion_tarea_repetitiva()
        End If
    End Sub
    Private Sub bt_actividades_hijo_Click(sender As System.Object, e As System.EventArgs) Handles bt_actividades_hijo.Click
        If tx_id_tarea.Text = "" Then
            MsgBox("La actividad padre no existe!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_analisis As New camocontrol.fm_0600_p3_analisis_y_solucion
        'oform_grilla_programacion.ods_hijo = ods
        oform_analisis.vf_oform_padre = Me
        oform_analisis.Text = "Actividades hijo"
        oform_analisis.lb_titulo.Text = "Actividades hijo"
        oform_analisis.bt_mef.Visible = False
        oform_analisis.cm_mef.Visible = False
        oform_analisis.tx_MEF.Visible = False
        oform_analisis.cm_subfuente.Visible = False
        oform_analisis.tx_subfuente.Visible = False
        oform_analisis.vg_id_cia = vg_id_cia
        oform_analisis.orow_info_accion = orow_info_accion
        oform_analisis.id_accion = id_accion
        oform_analisis.path_accion_base = path_accion
        oform_analisis.id_estructura = id_estructura
        oform_analisis.nivel_cumplimiento = nivel_cumplimiento
        oform_analisis.vg_usuario_autoriza = vg_usuario_autoriza
        oform_analisis.ShowDialog()

    End Sub
    Private Sub calcular_archivos_asociados()
        lb_total_soportes.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-ACC-001", tx_id_tarea.Text, vg_id_cia)
    End Sub
    Private Sub bt_nuevo_soporte_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo_soporte.Click
        cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-ACC", tx_id_tarea.Text, vg_id_cia, vg_usuario_autoriza, "N")
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

    Private Sub cm_path_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cm_path.SelectedIndexChanged
        If cm_path.SelectedIndex = -1 Or cm_path.SelectedIndex = 0 Then
            cm_path.SelectedIndex = 0
            Exit Sub
        End If
        If cm_path.Text.Trim = id_accion Then
            cm_path.SelectedIndex = 0
            Exit Sub
        End If
        Dim otipo_actividad As String = ""
        Dim oinfo_actividad() As DataRow
        oinfo_actividad = otb_acciones_arbol.Select("f0600_id_accion = '" & CInt(cm_path.Text.Trim) & "'")
        For Each orow As DataRow In oinfo_actividad
            otipo_actividad = orow("f0600_id_tipo_registro")
        Next
        If otipo_actividad = "02" Then
            MsgBox("El item seleccionado es una causa y no se abrira", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        cl_utilidades_gestion_acciones.abrir_actividad(CInt(cm_path.Text), vg_usuario_autoriza, vg_id_cia)
        cm_path.SelectedIndex = 0
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        'Pregunta si realmente desea ANULAR
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("ANULAR Accion", "Desea ANULAR este registro?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += " f0600_anulado = 'S',"
        csql += " f0600_usuario_anular = @f0600_usuario_anular,"
        csql += " f0600_fm = @f0600_fm"
        csql += " where f0600_id_accion = '" & id_accion & "'"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_tarea(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0600_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
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
        If verror = "N" Then
            'Agregar seguimiento informando el cambio realizado
            Dim txt_seguimiento As String
            txt_seguimiento = "ANULACION DE ACTIVIDAD: " & vbCrLf _
            & "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " ANULO LA ACTIVIDAD"
            cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia, nivel_cumplimiento)
            'traer_informacion_accion()
            MsgBox("Actividad Anulada", MsgBoxStyle.Information, "ANULADA!")
            Dispose()
        End If
    End Sub

    Private Sub bt_cierre_rrapido_Click(sender As Object, e As EventArgs) Handles bt_cierre_rrapido.Click
        If cm_estado.SelectedValue = "08" Then
            Me.Dispose()
            Exit Sub
        End If
        'Pregunta si realmente desea cerrar
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("CERRAR Accion", "Desea dar por CERRADA esta actividad?")
        If respuesta = "N" Then
            Exit Sub
        End If

        'creo la actividad hijo antes de actualizar y cerrar la actividad.

        traer_informacion_accion()

        'identifico si es una accion hijo de una tarea repetitiva
        '-------------
        'Cargo la informacion de la actividad padre.
        Dim tipo_accion_padre As String = ""
        Dim estado_accion_padre As String = ""
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones" _
                & " where f0600_id_accion = '" & id_accion_padre & "'"
        otb_info_accion_padre = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_accion_padre.Rows
            repeticiones_programadas = orow("f0600_repeticiones_programadas")
            repeticiones_ejecutadas = orow("f0600_repeticiones_ejecutadas")
            tipo_accion_padre = orow("f0600_id_tipo_registro")
            estado_accion_padre = orow("f0600_id_estado_accion")

        Next
        Dim mensaje_cierre As String = "Actividad Cerrada"
        If tipo_accion_padre = "04" Then
            'programar tarea repetitiva
            tarea_repetitiva = "S"
            If repeticiones_ejecutadas < repeticiones_programadas And estado_accion_padre <> "08" Then
                'MsgBox("Hola")
                If repeticion_programada = "N" Then
                    grabar_nueva_tarea()
                End If
                actualizar_accion_principal()
                mensaje_cierre += vbCrLf & "Esta actividad se debera repetir el dia: "
                mensaje_cierre += nueva_fecha_inicio.ToString("yyyy/MM/dd")
            End If
        End If

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += " f0600_nivel_cumplimiento = '100',"
        csql += " f0600_id_estado_accion = '08',"
        csql += " f0600_fecha_cierre = @fecha_actual,"
        If tarea_repetitiva = "S" Then
            csql += " f0600_repeticion_programada = 'S',"
        End If
        csql += " f0600_usuario_modificar = @f0600_usuario_modificar,"
        csql += " f0600_fm = @fecha_actual"
        csql += " where f0600_id_accion = '" & id_accion & "'"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_tarea(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        'ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("@fecha_actual", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
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
        If verror = "N" Then
            'Agregar seguimiento informando el cambio realizado
            Dim txt_seguimiento As String
            txt_seguimiento = "CIERRE DE LA ACCION: " & vbCrLf _
            & "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " DA FE DE QUE LA ACTIVIDAD SE CUMPLIO ADECUADAMENTE, LOGRANDO LOS OBJETIVOS PROPUESTOS Y AUTORIZA SU CIERRE."
            cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia, "100")
            'traer_informacion_accion()

            'MsgBox(mensaje_cierre, MsgBoxStyle.Information, "CERRADA!")
        End If
        Dispose()
    End Sub
    Private Sub actualizar_accion_principal()
        Dim estado_ppal As String
        If repeticiones_programadas = repeticiones_ejecutadas + 1 Then
            estado_ppal = "06"
        Else
            estado_ppal = "03"
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set " _
                    & " f0600_repeticiones_ejecutadas = '" & repeticiones_ejecutadas + 1 & "'," _
                    & " f0600_id_estado_accion = '" & estado_ppal & "'" _
                    & " where f0600_id_accion = '" & id_accion_padre & "'"
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
    End Sub
    Private Sub bt_informe_Click(sender As Object, e As EventArgs) Handles bt_informe.Click
        If tx_id_tarea.Text.Trim = "" Then
            MsgBox("Actividad fallida", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        cl_informes_comunes.reporte_actividad_sgc(vg_id_cia, tx_id_tarea.Text)
    End Sub

    Private Sub bt_solicitud_almacen_Click(sender As Object, e As EventArgs) Handles bt_solicitud_almacen.Click
        If tx_id_tarea.Text.ToString = "" Then
            MsgBox("La actividad debe grabarse primero", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-38", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", "ACC-" & tx_id_tarea.Text)
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.titulo_formulario = "Salidas del almacen de Mantenimiento - Consulta"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.id_accion = tx_id_tarea.Text
        oform_mostrar_datos.ocontexto_form = "salida de insumos de almacen desde una actividad"
        oform_mostrar_datos.ShowDialog()


    End Sub

    Private Sub bt_sol_almacen_Click(sender As Object, e As EventArgs) Handles bt_sol_almacen.Click
        If tx_id_tarea.Text.ToString = "" Then
            MsgBox("La actividad debe grabarse primero", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0600-08", vg_id_cia, vg_usuario_autoriza, "Solicitudes de Almacen", {vg_id_cia, id_accion})
        csql = comunes.suministrar_valor_variable_configuracion("ST-0600-08", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_accion)
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_solicitudes_almacen As New camocontrol.fm_visor_datos
        'oform_grilla_programacion.ods_hijo = ods
        oform_solicitudes_almacen.vf_oform_padre = Me
        oform_solicitudes_almacen.vg_id_cia = vg_id_cia
        oform_solicitudes_almacen.titulo_formulario = "Solicitudes de Almacen"
        oform_solicitudes_almacen.id_accion = id_accion
        oform_solicitudes_almacen.csql = csql
        oform_solicitudes_almacen.ocontexto_form = "solicitudes de almacen origen acciones"
        oform_solicitudes_almacen.vg_usuario_autoriza = vg_usuario_autoriza
        oform_solicitudes_almacen.ShowDialog()
    End Sub

    Private Sub gestionar_seguimiento_acciones_segun_tipo(ByVal otipo_seguimiento As Integer)

        If id_accion = 0 Or IsDBNull(id_accion) = True Then
            MsgBox("Primero debe guardar la accion!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'Abro el formulario para realizar seguimiento.
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_nuevo_seg_accion As New camocontrol.fm_0600_gestion_seguimiento
        'oform_grilla_programacion.ods_hijo = ods
        oform_nuevo_seg_accion.vf_oform_padre = Me
        oform_nuevo_seg_accion.vg_id_cia = vg_id_cia
        oform_nuevo_seg_accion.tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
        oform_nuevo_seg_accion.id_accion = id_accion
        oform_nuevo_seg_accion.ocomportamiento = "1"
        oform_nuevo_seg_accion.vf_elemento_nuevo = "S"
        oform_nuevo_seg_accion.vg_usuario_autoriza = vg_usuario_autoriza 'vg_usuario_autoriza
        oform_nuevo_seg_accion.otipo_seguimiento = otipo_seguimiento
        oform_nuevo_seg_accion.linklabel_id_accion.Text = id_accion
        oform_nuevo_seg_accion.ShowDialog()
        traer_informacion_accion()
    End Sub

    Private Sub bt_seg_reporte_act_Click(sender As Object, e As EventArgs) Handles bt_seg_reporte_act.Click
        gestionar_seguimiento_acciones_segun_tipo(2)
    End Sub

    Private Sub bt_seg_estandar_Click(sender As Object, e As EventArgs) Handles bt_seg_estandar.Click
        gestionar_seguimiento_acciones_segun_tipo(1)
    End Sub

    Private Sub bt_CargarImagenClipboard_Click(sender As Object, e As EventArgs) Handles bt_CargarImagenClipboard.Click
        If My.Computer.Clipboard.ContainsImage() Then
            'MsgBox("Clipboard contains an image.")
            PictureBox2.Image = My.Computer.Clipboard.GetImage

            Dim archivocopi(2) As String
            archivocopi = cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-ACC", tx_id_tarea.Text, vg_id_cia, vg_usuario_autoriza, "N", "", "S")
            'Cuando archivocopi esta vacio entonces no debe haber nada en el picturebox
            If archivocopi(1) = "" Then
                PictureBox2.Image = Nothing
            End If

            calcular_archivos_asociados()
            My.Computer.Clipboard.Clear()
        Else
            MsgBox("Clipboard no contiene una imagen.")
        End If
    End Sub
End Class
