Public Class cl_utilidades_gestion_acciones
    Public Shared Function suministrar_datatable_info_de_una_accion(ByVal id_accion As Integer, ByVal vg_id_cia As String)
        Dim csql As String
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones"
        csql += " where f0600_id_cia = '" & vg_id_cia & "' and f0600_id_accion = '" & id_accion & "'"
        Dim otb_accion As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Return otb_accion
    End Function
    Public Shared Sub abrir_actividad(id_accion As Integer, vg_usuario_autoriza As String, vg_id_cia As String)
        Dim csql2 As String
        csql2 = "select * from " & database.obtener_esquema & ".tb0600_acciones where f0600_id_accion = " & id_accion
        Dim otb_accion As DataTable
        Dim tipo_registro As String = ""
        Dim id_estructura As Integer
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql2)
        For Each orow As DataRow In otb_accion.Rows
            tipo_registro = orow("f0600_id_tipo_registro")
            id_estructura = orow("f0600_id_estructura")
        Next
        If otb_accion.Rows.Count = 0 Then
            MsgBox("El numero no corresponde a ninguna actividad", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Select Case tipo_registro
            Case "01"
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_programar_actividad As New camocontrol.fm_0600_p1_definicion_accion
                'oform_grilla_programacion.ods_hijo = ods
                'oform_programar_actividad.vf_oform_padre = Me
                oform_programar_actividad.vg_usuario_autoriza = vg_usuario_autoriza
                oform_programar_actividad.cm_emisor.Enabled = False
                oform_programar_actividad.cm_tipo_accion.Enabled = False
                oform_programar_actividad.cm_fuente_accion.Enabled = False
                oform_programar_actividad.vg_id_cia = vg_id_cia
                oform_programar_actividad.id_accion = id_accion
                oform_programar_actividad.vf_elemento_nuevo = "N"
                oform_programar_actividad.ShowDialog()
            Case "03", "04" 'Es una tarea simple o repetitiva
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_programar_actividad As New camocontrol.fm_0600_gestion_tareas
                'oform_grilla_programacion.ods_hijo = ods
                'oform_programar_actividad.vf_oform_padre = Me
                oform_programar_actividad.vg_usuario_autoriza = vg_usuario_autoriza
                oform_programar_actividad.cm_emisor.Enabled = False
                oform_programar_actividad.vg_id_cia = vg_id_cia
                oform_programar_actividad.id_accion = id_accion
                oform_programar_actividad.vf_elemento_nuevo = "N"
                oform_programar_actividad.ShowDialog()
        End Select
    End Sub
    Public Shared Sub actualizar_estado_acciones(ByVal id_accion As Integer, ByVal vg_usuario_autoriza As String, vg_id_cia As String)
        Dim csql As String = ""
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        If id_accion = 0 Then
            'csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
            'csql += "f0600_id_estado_accion = '07'" 'ff
            'csql += " where f0600_fecha_limite < @fecha_actual and f0600_fecha_limite <> '1900-01-01 00:00:00'"
            'csql += " and f0600_id_estado_accion <= '03' and f0600_id_tipo_registro <> '02' and f0600_id_tipo_registro <> '04'"
            csql = "select * from " & database.obtener_esquema & ".fnc_600_01_actualizar_estado_acciones()"
        Else
            'Dim otb_accion As DataTable
            'Dim responsable As String = ""
            'Dim id_estado_accion As String = ""
            'Dim tipo_registro As String = ""
            'csql = "Select * from " & database.obtener_esquema & ".tb0600_acciones where f0600_id_accion = " & id_accion
            'otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            'For Each orow As DataRow In otb_accion.Rows
            '    responsable = orow("f0600_responsable")
            '    id_estado_accion = orow("f0600_id_estado_accion")
            '    tipo_registro = orow("f0600_id_tipo_registro")
            'Next
            ''si quien gestiona es el responsable y no se ha notificado
            'If responsable = vg_usuario_autoriza And id_estado_accion = "01" Then
            '    '01 = sin notificar , 02 = sin gestionar , 03 = implementacion
            '    'Si es un plan de accion
            '    If tipo_registro = "01" Then
            '        csql = "update " + database.obtener_esquema + ".tb0600_acciones Set " _
            '            & "f0600_id_estado_accion = '02'" _
            '            & " where f0600_id_accion = '" & id_accion & "'"
            '    Else
            '        'Es una actividad
            '        csql = "update " + database.obtener_esquema + ".tb0600_acciones set " _
            '            & "f0600_id_estado_accion = '03'" _
            '            & " where f0600_id_accion = '" & id_accion & "'"
            '    End If
            '    Dim txt_seguimiento As String
            '    txt_seguimiento = "ACCION NOTIFICADA: " & vbCrLf _
            '    & "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Leyó la accion en la fecha: " _
            '    & comunes.g_fechahora.ToString("yyyy/MM/dd  HH:mm")
            '    Dim tipo_nota As String = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
            '    cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia)
            'End If

        End If

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'ocmd.Parameters.Clear()
        'ocmd.Parameters.Add("@fecha_actual", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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
    Public Shared Sub cambiar_estado_accion(ByVal id_accion As Integer, ByVal id_estado As String)
        Dim csql As String = ""
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set " _
            & "f0600_id_estado_accion = '" & id_estado & "'" _
            & " where f0600_id_accion = '" & id_accion & "'"
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'ocmd.Parameters.Clear()
        'ocmd.Parameters.Add("@fecha_actual", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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
    Public Shared Function obtener_nivel_cumplimiento_actual(ByVal id_documento As Integer, tipo_nota As String)
        'no la deberia usar para nada
        Dim csql As String
        Dim cumplimiento As Integer
        csql = "select * from " & database.obtener_esquema & ".tb0606_seguimientos_acciones" _
            & " where f0606_id_documento = '" & id_documento & "' and f0606_tipo_nota = '" & tipo_nota & "'" _
            & " order by f0606_id_seguimiento_accion desc limit 1"
        Dim otb_info_ultimo_seguimiento As DataTable
        otb_info_ultimo_seguimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_info_ultimo_seguimiento.Rows.Count = 1 Then
            For Each orow As DataRow In otb_info_ultimo_seguimiento.Rows
                cumplimiento = CInt(orow("f0606_nivel_cumplimiento"))
            Next
        Else
            cumplimiento = 0
        End If
        Return cumplimiento
    End Function

    Public Shared Function obtener_datatable_acciones_hijo(path_completo As String)
        'path incluyendo el id_accion de la actividad de la cual se quieren identificar los hijos y fianlizando con el -
        Dim csql As String
        Dim c_filtrar As String
        Dim otb_Acciones_hijos As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones"
        c_filtrar = " where f0600_anulado = 'N' and" _
        & " substring(f0600_path from 1 for " & Len(path_completo) & ") = '" & path_completo & "'" _
        & " order by f0600_id_tipo_registro desc, f0600_fecha_inicio, f0600_id_accion"
        csql = csql + c_filtrar
        otb_Acciones_hijos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Return otb_Acciones_hijos
    End Function

    Public Shared Sub actualizar_estado_plan_de_accion(id_accion As Integer)
        Dim otb_accion As DataTable
        Dim csql As String
        Dim fecha_emision As Date
        Dim fecha_limite As Date
        Dim fecha_limite_maxima As Date
        Dim path_accion As String = ""
        Dim estado_actual As String = ""
        Dim id_fuente As String = ""
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones where f0600_id_accion = " & id_accion
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_accion.Rows
            If orow("f0600_fecha_limite").ToString <> "" Then
                fecha_limite = orow("f0600_fecha_limite")
            Else
                fecha_limite = CDate("1900-01-01 00:00:00")
            End If
            path_accion = orow("f0600_path")
            estado_actual = orow("f0600_id_estado_accion")
            fecha_emision = orow("f0600_fecha_emision")
            id_fuente = orow("f0600_id_fuente_accion")
        Next
        If estado_actual = "08" Then
            Exit Sub
        End If

        fecha_limite_maxima = cl_utilidades_gestion_acciones.identificar_fecha_maxima_cierre_x_fuente(id_fuente, fecha_emision)
        Dim otb_acciones_hijos As DataTable
        otb_acciones_hijos = cl_utilidades_gestion_acciones.obtener_datatable_acciones_hijo(path_accion & id_accion & "-")
        Dim orows_actividades() As DataRow
        orows_actividades = otb_acciones_hijos.Select("f0600_id_tipo_registro = '03'")
        '1er caso: no hay una fecha limite definida ni actividades =) sin contestar
        If fecha_limite = CDate("1900-01-01 00:00:00") And orows_actividades.Count = 0 Then
            cl_utilidades_gestion_acciones.cambiar_estado_accion(id_accion, "02")
        End If

        '2do caso: no hay una fecha limite definida pero si actividades
        If fecha_limite = CDate("1900-01-01 00:00:00") And orows_actividades.Count > 0 Then
            'Identifico la maxima fecha de las actividades para asignarla como limite sin exceder el limite del sistema
            Dim max_fecha_tareas As Date = otb_acciones_hijos.Compute("max(f0600_fecha_limite)", "")
            If max_fecha_tareas > fecha_limite_maxima Then
                max_fecha_tareas = fecha_limite_maxima
            End If
            cl_utilidades_gestion_acciones.cambiar_estado_accion(id_accion, "02")
            Dim owhere As String = "where f0600_id_accion = '" & id_accion & "'"
            comunes.actualizar_campo_date_tabla("tb0600_acciones", "f0600_fecha_limite", max_fecha_tareas, owhere)
        End If
        '3er caso: hay una fecha limite definida y no se ha vencido
        If fecha_limite <> CDate("1900-01-01 00:00:00") And fecha_limite > Now() Then
            If orows_actividades.Count = 0 Then
                cl_utilidades_gestion_acciones.cambiar_estado_accion(id_accion, "13")
            Else
                cl_utilidades_gestion_acciones.cambiar_estado_accion(id_accion, "03")
            End If
        End If

    End Sub

    'funcion que actualiza los path de un arbol a partir de la rama seleccionada.
    Public Shared Sub actualizar_ramal(ByVal registro_padre As String, ByVal path_padre As String, _
                                                 ByVal otabla As String, ByVal campo_id As String, _
                                                 ByVal campo_path As String, ByVal campo_dependencia As String)
        Dim csql As String
        'identifico los hijos del registro
        csql = "select " & campo_id & "," & campo_dependencia & "," & campo_path _
            & " from " & database.obtener_esquema & "." & otabla _
            & " where " & campo_dependencia & "= '" & registro_padre & "'"
        Dim otb_hijos As DataTable
        otb_hijos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_hijos.Rows.Count > 0 Then
            'MsgBox(otb_hijos.Rows.Count)
            'actualizo los hijos
            cl_utilidades_gestion_acciones.actualizar_path_relacion_arbol(registro_padre, path_padre, otabla, _
                                                                    campo_id, campo_path, campo_dependencia)
            'cargo de nuevo los hijos del registro ya actualizados
            otb_hijos = cl_utilidades_datatables.cargar_informacion_postgres(csql) 'vuelvo a cargar la datatable con datos actualizados
            For Each orow As DataRow In otb_hijos.Rows
                actualizar_ramal(orow(campo_id), orow(campo_path), otabla, campo_id, _
                                 campo_path, campo_dependencia)
            Next
        End If
    End Sub
    Public Shared Sub actualizar_path_relacion_arbol(ByVal registro_padre As String, ByVal path_padre As String, _
                                                     ByVal otabla As String, ByVal campo_id As String, _
                                                     ByVal campo_path As String, ByVal campo_dependencia As String)
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + "." & otabla & " set "
        csql += campo_path & " = '" & path_padre & "' || '" & registro_padre & "' || '-'"
        csql += " where " & campo_dependencia & " = '" & registro_padre & "'"
        'Crear el comando
        'MsgBox("path_padre= " & path_padre & vbCrLf & csql)
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
        End Try
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Public Shared Sub trasladar_ramal(ByVal valor_raiz As String, ByVal id_padre As Integer, ByVal id_hijo As Integer, _
                                      ByVal otabla As String, ByVal campo_id As String, _
                                      ByVal campo_path As String, ByVal campo_dependencia As String, campo_agrupacion_principal As String)
        Dim csql As String = ""
        Dim path_padre As String = "" 'path del elemento + id_padre + "-"
        Dim path_hijo As String = ""
        Dim path_hijo_base As String = "" 'path del hijo sin el id del elemento seleccionado
        Dim path_compara As String = ""
        Dim grupo_principal As String = "" 'Es la accion principal o la maquina padre
        'identifico informacion del registro padre
        csql = "select " & campo_id & "," & campo_dependencia & "," & campo_path & "," & campo_agrupacion_principal _
            & " from " & database.obtener_esquema & "." & otabla _
            & " where " & campo_id & "= '" & id_padre & "'"
        Dim otb_padre As DataTable
        otb_padre = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If id_padre = 0 Then
            path_padre = valor_raiz
        Else
            For Each orow As DataRow In otb_padre.Rows
                path_padre = orow(campo_path) & id_padre & "-"
                If IsDBNull(orow(campo_agrupacion_principal)) = True Then
                    grupo_principal = id_padre
                Else
                    grupo_principal = orow(campo_agrupacion_principal)
                End If
            Next
            'Verifico que exista el padre
            If otb_padre.Rows.Count = 0 Then
                MsgBox("No existe el elemento padre", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
        End If

        'identifico informacion del registro hijo
        csql = "select " & campo_id & "," & campo_dependencia & "," & campo_path _
            & " from " & database.obtener_esquema & "." & otabla _
            & " where " & campo_id & "= '" & id_hijo & "'"
        Dim otb_hijo As DataTable
        otb_hijo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_hijo.Rows
            path_hijo = orow(campo_path) & id_hijo & "-"
            path_hijo_base = orow(campo_path)
        Next
        'Verifico que exista el hijo
        If otb_hijo.Rows.Count = 0 Then
            MsgBox("No existe el elemento hijo", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'verifico que no exista redundancia ciclica

        path_compara = Mid(path_padre, 1, Len(path_hijo))
        'MsgBox("Padre: " & id_padre & " = " & path_padre & vbCrLf & "hijo: " & id_hijo & " = " & path_hijo & vbCrLf _
        '& "Comparacion: " & path_compara & " == " & path_hijo)
        If path_compara = path_hijo And Len(path_padre) > Len(path_hijo) Then
            MsgBox("Dependencia ciclica, no se realiza la operación.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        'MsgBox("hola")
        cl_utilidades_gestion_acciones.realizar_traslado_ramal_bd(id_padre, id_hijo, otabla, campo_id, campo_path, campo_dependencia, _
                                                                   path_padre, path_hijo, path_hijo_base, grupo_principal, campo_agrupacion_principal)
    End Sub
    Public Shared Sub realizar_traslado_ramal_bd(ByVal id_padre As Integer, ByVal id_hijo As Integer, _
                                      ByVal otabla As String, ByVal campo_id As String, _
                                      ByVal campo_path As String, ByVal campo_dependencia As String, _
                                      ByVal path_padre As String, ByVal path_hijo As String, ByVal path_hijo_base As String, _
                                      ByVal grupo_principal As Integer, campo_agrupacion_principal As String)
        'Dim tex As String = ""
        'tex = "id-padre: " & id_padre & vbCrLf
        'tex += "id-hijo: " & id_hijo & vbCrLf
        'tex += "Otabla: " & otabla & vbCrLf
        'tex += "Campo: " & campo_id & vbCrLf
        'MsgBox(tex)

        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + "." + otabla + " set "
        csql += campo_dependencia + " = @campo_dependencia,"
        csql += campo_agrupacion_principal + " = @grupo_principal"
        csql += " where " & campo_id & " = '" & id_hijo & "'"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'crear_parametros_especificaciones(ocmd)
        ocmd.Parameters.Clear()

        ocmd.Parameters.Add("@campo_dependencia", NpgsqlDbType.Integer).Value = id_padre
        ocmd.Parameters.Add("@grupo_principal", NpgsqlDbType.Integer).Value = grupo_principal

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


        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        'oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        'MsgBox("path a Reemplazar: " & path_hijo_base _
        '& vbCrLf & " longitud del path a Reemplazar: " & Len(path_hijo_base) _
        '& vbCrLf & " Con (path padre): " & path_padre)

        csql = "UPDATE " + database.obtener_esquema + "." & otabla _
            & " SET " + campo_path + " = overlay(" + campo_path + " placing '" & path_padre & "' from 1 for " & Len(path_hijo_base) & "), " _
            & campo_agrupacion_principal + " = '" & grupo_principal & "'" _
            & " where substring(" & campo_path & " || " & campo_id & " || '-' from 1 for " & Len(path_hijo) & ") = '" & path_hijo & "'"


        'ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_especificaciones(ocmd)
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

    Public Shared Function identificar_fecha_maxima_cierre_x_fuente(id_fuente As String, fecha_base As Date)
        Dim csql As String
        csql = "select f0601_tiempo_maximo_cierre" _
            & " from " & database.obtener_esquema & ".tb0601_fuentes_acciones" _
            & " where f0601_id_fuente = '" & id_fuente & "'"
        Dim otb_fuente As DataTable
        Dim periodo_maximo As Integer
        otb_fuente = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_fuente.Rows
            periodo_maximo = orow("f0601_tiempo_maximo_cierre")
        Next
        Dim fecha_maxima As Date
        fecha_maxima = fecha_base.AddDays(periodo_maximo)
        Return fecha_maxima
    End Function

    Public Shared Function crear_accion_generica(ByVal id_fuente_accion As String,
                                        ByVal texto_accion As String, ByVal titulo As String,
                                        ByVal responsable As String,
                                        ByVal emisor As String,
                                        ByVal evaluador As String,
                                        ByVal id_cia As String,
                                        ByVal fecha_inicio As Date,
                                        Optional ByVal id_estructura As Integer = 0,
                                        Optional ByVal id_accion_padre As Integer = 0,
                                        Optional ByVal id_tipo_accion As String = "01",
                                        Optional ByVal duracion_horas As Integer = 8,
                                        Optional ByVal unidad_duracion As String = "00000007")
        Dim nueva_accion As Integer = 0

        'busco informacion de la accion padre
        Dim csql As String = ""
        csql = "select f0600_path, f0600_id_accion_principal from " & database.obtener_esquema & ".tb0600_acciones"
        csql += " where f0600_id_accion = '" & id_accion_padre & "'"
        Dim otb_accion_padre As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'valido que la accion padre sea valida
        If id_accion_padre <> 0 Then
            If otb_accion_padre.Rows.Count = 0 Then
                Return nueva_accion
                Exit Function
            End If
        End If

        Dim path_padre As String = otb_accion_padre.Rows(0)("f0600_path")
        Dim id_accion_principal As Integer = 0
        If IsDBNull(otb_accion_padre.Rows(0)("f0600_id_accion_principal")) = True Then
            id_accion_principal = 0
        Else
            id_accion_principal = otb_accion_padre.Rows(0)("f0600_id_accion_principal")
        End If
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0600_acciones" _
                & " (f0600_id_cia, f0600_id_accion_padre, f0600_id_accion_principal," _
                & " f0600_id_estructura, f0600_titulo, f0600_descripcion, f0600_id_estado_accion," _
                & " f0600_id_fuente_accion, f0600_unidad_duracion, f0600_duracion," _
                & " f0600_id_tipo_accion, f0600_responsable, f0600_evaluador, f0600_id_tipo_registro," _
                & " f0600_emisor, f0600_fecha_inicio, f0600_path," _
                & " f0600_usuario_modificar, f0600_usuario_crear, f0600_fm, f0600_fecha_limite)" _
                & " VALUES" _
                & " (@f0600_id_cia, @f0600_id_accion_padre, @f0600_id_accion_principal," _
                & " @f0600_id_estructura, @f0600_titulo, @f0600_descripcion, @f0600_id_estado_accion," _
                & " @f0600_id_fuente_accion, @f0600_unidad_duracion, @f0600_duracion," _
                & " @f0600_id_tipo_accion, @f0600_responsable, @f0600_evaluador, @f0600_id_tipo_registro," _
                & " @f0600_emisor, @f0600_fecha_inicio, @f0600_path," _
                & " @f0600_usuario_modificar, @f0600_usuario_crear, @f0600_fm, @f0600_fecha_limite)" _
                & " RETURNING f0600_id_accion;"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_tarea(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = id_cia
        If id_accion_principal = 0 Then
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = id_accion_principal
        End If
        If id_accion_padre <> 0 Then
            ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = id_accion_padre
            ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = path_padre & id_accion_padre & "-"
        Else
            'MsgBox("si es nulo")
            ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = DBNull.Value
            ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = "-"
        End If
        ocmd.Parameters.Add("@f0600_id_estructura", NpgsqlDbType.Integer).Value = id_estructura
        ocmd.Parameters.Add("@f0600_titulo", NpgsqlDbType.Varchar).Value = UCase(titulo.ToString.Trim)
        ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = UCase(texto_accion.ToString.Trim)
        ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = "03"
        ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = id_fuente_accion '"00000003" '03 = actividad manto
        ocmd.Parameters.Add("@f0600_id_tipo_accion", NpgsqlDbType.Varchar).Value = id_tipo_accion
        ocmd.Parameters.Add("@f0600_unidad_duracion", NpgsqlDbType.Varchar).Value = unidad_duracion
        ocmd.Parameters.Add("@f0600_duracion", NpgsqlDbType.Integer).Value = duracion_horas
        ocmd.Parameters.Add("@f0600_id_tipo_registro", NpgsqlDbType.Varchar).Value = "03" '03=tarea simple
        ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = responsable
        ocmd.Parameters.Add("@f0600_evaluador", NpgsqlDbType.Varchar).Value = evaluador
        ocmd.Parameters.Add("@f0600_emisor", NpgsqlDbType.Varchar).Value = emisor
        ocmd.Parameters.Add("@f0600_fecha_inicio", NpgsqlDbType.Timestamp).Value = fecha_inicio
        ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = emisor
        ocmd.Parameters.Add("@f0600_usuario_crear", NpgsqlDbType.Varchar).Value = emisor
        ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("@f0600_fecha_limite", NpgsqlDbType.Timestamp).Value = DateAdd(DateInterval.Second, 3600 * duracion_horas, fecha_inicio)

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
                nueva_accion = ocmd.ExecuteScalar()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        If verror = "S" Then
            Return nueva_accion
            Exit Function
        End If

        'identifico la accion creada
        'nueva_accion = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0600_id_accion", "f0600_usuario_crear", emisor, "tb0600_acciones")
        Return nueva_accion
    End Function

End Class
