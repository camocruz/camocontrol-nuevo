Public Class fm_0100_programacion_actividad_manto_menu
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Public id_estructura As Integer
    Public path_estructura As String = ""

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private csql As String

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String

    Private id_accion As Integer

    Private Sub fm_0100_programacion_actividad_manto_menu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cl_utilidades_gestion_acciones.actualizar_estado_acciones(0, vg_usuario_autoriza, vg_id_cia)
        rb_activas.Checked = True
        rb_actividades.Checked = True

        Dim hora_actual As DateTime = comunes.g_fechahora
        ' Set the Format type and the CustomFormat string.
        dtp_fecha_inicio.Value = hora_actual.AddDays(-15)
        dtp_fecha_inicio.Format = DateTimePickerFormat.Custom
        dtp_fecha_inicio.CustomFormat = "yyyy/MM/dd"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_fin.Value = hora_actual
        dtp_fecha_fin.Format = DateTimePickerFormat.Custom
        dtp_fecha_fin.CustomFormat = "yyyy/MM/dd"
    End Sub
    Private Sub bt_nueva_recurrente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nueva_recurrente.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_programar_actividad As New camocontrol.fm_0600_gestion_tarea_repetitiva
        'oform_grilla_programacion.ods_hijo = ods
        oform_programar_actividad.vf_oform_padre = Me
        oform_programar_actividad.vf_oform_padre = Me
        oform_programar_actividad.vg_id_cia = vg_id_cia
        oform_programar_actividad.vg_usuario_autoriza = vg_usuario_autoriza
        oform_programar_actividad.id_estructura = id_estructura
        oform_programar_actividad.vf_elemento_nuevo = "S"
        oform_programar_actividad.ShowDialog()
    End Sub

    Private Sub bt_nueva_no_recurrente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nueva_actividad.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_programar_actividad As New camocontrol.fm_0600_gestion_tareas
        'oform_grilla_programacion.ods_hijo = ods
        oform_programar_actividad.vf_oform_padre = Me
        oform_programar_actividad.vg_id_cia = vg_id_cia
        oform_programar_actividad.vg_usuario_autoriza = vg_usuario_autoriza
        oform_programar_actividad.cm_emisor.Enabled = False
        oform_programar_actividad.id_estructura = id_estructura
        oform_programar_actividad.vf_elemento_nuevo = "S"
        oform_programar_actividad.ShowDialog()
    End Sub

    Private Sub bt_actividades_prog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_actividades_simples_prog.Click, Button3.Click
        If rb_activas.Checked = True Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-02", vg_id_cia, vg_usuario_autoriza,
                                                            "Actividades de Mantenimiento", {vg_id_cia, "'A'", path_estructura})
        Else
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-02", vg_id_cia, vg_usuario_autoriza,
                                                            "Actividades de Mantenimiento", {vg_id_cia, "f0603_estado", path_estructura})
        End If
    End Sub

    Private Sub bt_fallas_reportadas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_fallas_reportadas.Click
        If rb_activas.Checked = True Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-01", vg_id_cia, vg_usuario_autoriza,
                                                            "Fallas Maquinaria Reportadas", {vg_id_cia, "00000001", "'A'", path_estructura})
        Else
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-01", vg_id_cia, vg_usuario_autoriza,
                                                            "Fallas Maquinaria Reportadas", {vg_id_cia, "00000001", "f0603_estado", path_estructura})
        End If
    End Sub

    Private Sub bt_reporte_actividades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_reporte_actividades.Click
        Dim tipo_nota As String = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
        Dim fecha_ini As String = dtp_fecha_inicio.Value.ToString("yyyy/MM/dd")
        Dim fecha_fin As String = dtp_fecha_fin.Value.AddDays(1).ToString("yyyy/MM/dd")

        If rb_todos_seguimientos.Checked = True Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-03", vg_id_cia, vg_usuario_autoriza,
                                                            "Seguimientos y Reportes a Actividades Mantenimiento",
                                                            {tipo_nota, vg_id_cia, fecha_ini, fecha_fin,
                                                             "f0606_id_tipo_seguimiento", path_estructura})
        Else
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-03", vg_id_cia, vg_usuario_autoriza,
                                                            "Seguimientos y Reportes a Actividades Mantenimiento",
                                                            {tipo_nota, vg_id_cia, fecha_ini, fecha_fin,
                                                             "2", path_estructura})
        End If
    End Sub

    Private Sub bt_actividades_recurrentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_actividades_recurrentes.Click
        If rb_activas.Checked = True Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-04", vg_id_cia, vg_usuario_autoriza,
                                                            "Actividades Repetitivas", {vg_id_cia, "'A'", path_estructura})
        Else
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-04", vg_id_cia, vg_usuario_autoriza,
                                                            "Actividades Repetitivas", {vg_id_cia, "f0603_estado", path_estructura})
        End If
    End Sub

    Private Sub bt_programacion_Click(sender As System.Object, e As System.EventArgs) Handles bt_programacion.Click
        dtp_fecha_inicio.Value = CDate(dtp_fecha_inicio.Value.ToString("yyyy/MM/dd"))
        dtp_fecha_fin.Value = CDate(dtp_fecha_fin.Value.ToString("yyyy/MM/dd"))
        If dtp_fecha_fin.Value < dtp_fecha_inicio.Value Then
            MsgBox("Fecha inicial mayor que Fecha final", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        csql = comunes.suministrar_valor_variable_configuracion("ST-0100-06", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", dtp_fecha_inicio.Value.ToString("yyyy/MM/dd"))
        csql = csql.Replace("$003$", dtp_fecha_fin.Value.AddDays(1).ToString("yyyy/MM/dd"))
        csql = csql.Replace("$004$", path_estructura)

        Dim otb_actividades_programadas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Dim otb_actividades_informe As New DataTable
        Dim fecha_ini As Date
        Dim fecha_fin As Date
        Dim dif_fechas As Integer

        Dim otb_actividades_informe As DataTable = New DataTable
        otb_actividades_informe.Columns.Add("id_acc", GetType(Integer))
        otb_actividades_informe.Columns.Add("elemento_primario", GetType(String))
        otb_actividades_informe.Columns.Add("responsable", GetType(String))
        otb_actividades_informe.Columns.Add("dia", GetType(DateTime))
        otb_actividades_informe.Columns.Add("titulo", GetType(String))
        otb_actividades_informe.Columns.Add("estado", GetType(String))
        otb_actividades_informe.Columns.Add("plan_accion", GetType(String))
        Dim v(7) As Object
        Dim fecha_txt As String = ""
        Dim txt_row As String = ""
        Dim txt_file As String = ""

        '1 = variable que contiene el path para el archivo txt a donde se exportaran datos de programa manto
        Dim file_temp_path As String = comunes.suministrar_valor_variable_configuracion("DIR-I-001", vg_id_cia)
        Dim c1 As Integer = 0
        For Each orow As DataRow In otb_actividades_programadas.Rows
            fecha_ini = orow("f_inicio")
            fecha_fin = orow("f_fin")
            dif_fechas = DateDiff(DateInterval.Day, fecha_ini, fecha_fin)
            'MsgBox(fecha_ini & " - " & fecha_fin & " = " & dif_fechas)
            'orow = otb_actividades_informe.NewRow
            'otb_actividades_informe.Rows.Add(orow)
            v(0) = orow("id_acc")
            'MsgBox(v(0))
            v(1) = orow("elemento_primario")
            v(2) = orow("responsable")
            v(4) = Replace(orow("titulo").ToString, vbCrLf, " -- ")
            v(5) = orow("estado")
            v(6) = orow("plan_accion")
            c1 = 0
            For i = 1 To dif_fechas + 1
                fecha_ini = DateAdd(DateInterval.Day, c1, fecha_ini)
                v(3) = fecha_ini
                fecha_txt = fecha_ini.ToString("d-MM-yyyy")
                'MsgBox(fecha_txt)
                If fecha_ini >= dtp_fecha_inicio.Value And fecha_ini <= dtp_fecha_fin.Value Then
                    'otb_actividades_informe.Rows.Add(v)
                    txt_row = v(0) & "|" & v(1) & "|" & v(2) & "|" & fecha_txt & "|" & v(4) & "|" & v(5) & "|" & v(6) & vbCrLf
                    txt_file += txt_row
                End If
                c1 = 1
            Next

        Next
        Try
            'My.Computer.FileSystem.DeleteFile(file_temp_path)
        Catch ex As Exception

        End Try
        'MsgBox(txt_file)

        'Dim f, fs
        Try
            'My.Computer.FileSystem.WriteAllText(file_temp_path, _
            'txt_file, True)
            'fs = CreateObject("Scripting.FileSystemObject")
            'f = fs.GetFile(file_temp_path)  'f = fs.GetFile("C:\Etiquetas\test.txt")
        Catch ex As Exception
            'MsgBox("Directorio inaccesible", MsgBoxStyle.Exclamation, "Error")
        End Try

        'MsgBox(otb_actividades_programadas.Rows.Count)
        'MsgBox(otb_actividades_informe.Rows.Count)

        'Exporta la informacion de la consulta que se muestra en el visor de datos.
        'Dim file_archivo2 As String = comunes.suministrar_valor_variable_configuracion("DIR-I-002", vg_id_cia)
        'cl_utilidades_datatables.exportar_consulta_plano(csql, file_archivo2, "N", "N")

        'MsgBox("Datos exportados")


        'Exit Sub
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.titulo_formulario = "Actividades de mantenimiento programadas"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.id_estructura = id_estructura
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.ShowDialog()
    End Sub

    Private Sub bt_unificado_Click(sender As System.Object, e As System.EventArgs) Handles bt_unificado.Click
        If rb_activas.Checked = True Then
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-05", vg_id_cia, vg_usuario_autoriza,
                                                            "Unificado Planes de Accion y Actividades", {vg_id_cia, "'A'", path_estructura})
        Else
            cl_utilidades_datatables.visualizar_datos_visor("ST-0100-05", vg_id_cia, vg_usuario_autoriza,
                                                            "Unificado Planes de Accion y Actividades", {vg_id_cia, "f0603_estado", path_estructura})
        End If
    End Sub

    Private Sub bt_generar_gant_Click(sender As Object, e As EventArgs) Handles bt_generar_gant.Click
        dtp_fecha_inicio.Value = CDate(dtp_fecha_inicio.Value.ToString("yyyy/MM/dd"))
        dtp_fecha_fin.Value = CDate(dtp_fecha_fin.Value.ToString("yyyy/MM/dd"))
        If dtp_fecha_fin.Value < dtp_fecha_inicio.Value Then
            MsgBox("Fecha inicial mayor que Fecha final", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        csql = comunes.suministrar_valor_variable_configuracion("ST-0100-08", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", dtp_fecha_inicio.Value.ToString("yyyy/MM/dd"))
        csql = csql.Replace("$003$", dtp_fecha_fin.Value.AddDays(1).ToString("yyyy/MM/dd"))
        csql = csql.Replace("$004$", path_estructura)

        'Agrego las columnas necesarias de acuerdo a los dias que quiero pintar en el grafico
        Dim otb_actividades_programadas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim fecha_col As Date = dtp_fecha_inicio.Value
        While fecha_col <= dtp_fecha_fin.Value
            otb_actividades_programadas.Columns.Add(fecha_col.ToString("yyyy/MM/dd"), GetType(String))
            fecha_col = DateAdd(DateInterval.Day, 1, fecha_col)
        End While

        'De acuerdo a la fecha de inicio y final agrego valores en las columnas de fecha creadas.
        For Each orow As DataRow In otb_actividades_programadas.Rows
            'Identifico y comparo la fecha de inicio con la fecha inicial que solicito para el grafico.
            Dim fecha_llenar_inicial As Date
            If orow("f_inicio") <= dtp_fecha_inicio.Value Then
                fecha_llenar_inicial = dtp_fecha_inicio.Value
            End If
            If orow("f_inicio") > dtp_fecha_inicio.Value Then
                fecha_llenar_inicial = dtp_fecha_inicio.Value
                fecha_llenar_inicial = orow("f_inicio")
            End If
            'Identifico y comparo la fecha final con la fecha final que solicito para el grafico
            Dim fecha_llenar_final As Date
            If orow("f_fin") >= dtp_fecha_fin.Value Then
                fecha_llenar_final = dtp_fecha_fin.Value
            End If
            If orow("f_fin") < dtp_fecha_fin.Value Then
                fecha_llenar_final = orow("f_fin")
            End If
            'lleno los valores en las columnas correspondientes
            While fecha_llenar_inicial <= fecha_llenar_final
                orow(fecha_llenar_inicial.ToString("yyyy/MM/dd")) = CInt(orow("avance"))
                fecha_llenar_inicial = DateAdd(DateInterval.Day, 1, fecha_llenar_inicial)
            End While
        Next

        cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Gantt", {""}, otb_actividades_programadas)
    End Sub

    Private Sub bt_admon_path_Click(sender As Object, e As EventArgs) Handles bt_admon_path.Click
        Dim otb_items_selected As DataTable = Nothing
        Dim otb_tablas_array() As DataTable = Nothing

        dtp_fecha_inicio.Value = CDate(dtp_fecha_inicio.Value.ToString("yyyy/MM/dd"))
        dtp_fecha_fin.Value = CDate(dtp_fecha_fin.Value.ToString("yyyy/MM/dd"))
        If dtp_fecha_fin.Value < dtp_fecha_inicio.Value Then
            MsgBox("Fecha inicial mayor que Fecha final", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        otb_tablas_array = cl_utilidades_datatables.visualizar_datos_visor("ST-0100-08", vg_id_cia, vg_usuario_autoriza,
                                                            "Actividades de Manto Programadas",
                                                            {vg_id_cia,
                                                            dtp_fecha_inicio.Value.ToString("yyyy/MM/dd"),
                                                            dtp_fecha_fin.Value.AddDays(1).ToString("yyyy/MM/dd"),
                                                            path_estructura},
                                                            , "Actividades Programadas",,, "S", "id_acc",, "S")

        If IsNothing(otb_tablas_array(2)) = False Then
            otb_items_selected = otb_tablas_array(2)
        Else
            Exit Sub
        End If

        Dim oform_mover As New camocontrol.fm_0100_trasladar_ramal
        oform_mover.vf_oform_padre = Me
        oform_mover.formulario_origen = Me.Name
        oform_mover.ocontexto_form = "trasladar varias acciones hacia una accion padre"
        oform_mover.otb_listado_elementos_a_trasladar = otb_items_selected
        oform_mover.Text = "Trasladar Actividad"
        oform_mover.lb_titulo.Text = "Traslado Directo"
        oform_mover.otipo_ramal = 2
        oform_mover.TopMost = False
        oform_mover.ShowDialog()

    End Sub
End Class
