Public Class cl_gestion_anotaciones
    Public Shared Function calcular_cantidad_notas_asociadas(tipo_nota As String, id_documento As String, vg_id_cia As String)
        'Identificamos cuantos archivos estan asociados al documento
        Dim csql As String
        Dim tot_doc As Integer = 0
        Dim oconsecutivo As String = ""
        'Dim tipo_nota As String = comunes.suministrar_valor_variable_configuracion(codigo_config, vg_id_cia)
        csql = "select * from " & database.obtener_esquema & ".tb0606_seguimientos_acciones" _
            & " where f0606_anulado = 'N' and f0606_id_cia = '" & vg_id_cia & "' and" _
            & " f0606_id_documento = '" & id_documento & "' and f0606_tipo_nota = '" & tipo_nota & "'"
        'Clipboard.SetText(csql)
        'MsgBox("Copiado")
        Dim otb_archivos As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        tot_doc = otb_archivos.Rows.Count
        Return tot_doc
    End Function
    Public Shared Sub consultar_anotaciones_acciones(id_reg_padre As Integer, tipo_nota As String, vg_usuario_autoriza As String,
                                                     vg_id_cia As String, id_var_config_sql As String,
                                                     oformato As String,
                                                     Optional vf_otabla_permisos As DataTable = Nothing)

        Dim csql As String
        csql = comunes.suministrar_valor_variable_configuracion(id_var_config_sql, vg_id_cia)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_reg_padre)
        csql = csql.Replace("$003$", tipo_nota)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        'IDENTIFICO LOS PERMISOS QUE TIENE EL USUARIO PARA GESTIONAR ESTAS NOTAS
        If IsNothing(vf_otabla_permisos) = False Then
            Dim p_add_notas As String = "N"
            Dim p_consultar_notas_propias As String = "N"
            Dim P_consultar_todas_notas As String = "N"
            p_add_notas = cl_gestion_permisos.identificar_permisos_especiales_formularios("ADD_NOTAS", vf_otabla_permisos, vg_usuario_autoriza)
            p_consultar_notas_propias = cl_gestion_permisos.identificar_permisos_especiales_formularios("CONS_PROP_NOTAS", vf_otabla_permisos, vg_usuario_autoriza)
            P_consultar_todas_notas = cl_gestion_permisos.identificar_permisos_especiales_formularios("CONS_TOT_NOTAS", vf_otabla_permisos, vg_usuario_autoriza)
            'MsgBox(p_add_notas)
            'determino los datos que podra visualizar el usuario.
            If P_consultar_todas_notas = "S" Then
                csql = csql.Replace("$004$", "f0606_usuario_crear")
            Else
                csql = csql.Replace("$004$", "'" & vg_usuario_autoriza & "'")
            End If
            If p_add_notas = "S" Then
                oform_mostrar_datos.bt_nuevo.Enabled = True
                'MsgBox("SI")
            Else
                oform_mostrar_datos.bt_nuevo.Enabled = False
            End If
        End If
        'MsgBox(csql)
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.titulo_formulario = "Listado de Seguimientos"
        oform_mostrar_datos.ocontexto_form = "gestion de anotaciones asociadas al registro"
        oform_mostrar_datos.id_oreg_padre = id_reg_padre
        oform_mostrar_datos.otipo_nota = tipo_nota
        oform_mostrar_datos.ovalue = oformato
        oform_mostrar_datos.ShowDialog()
        'vf_oform_padre.vf_tot_notas = 1
    End Sub
    Public Shared Sub grabar_nuevo_seguimiento(ByVal id_reg_padre As Integer, ByVal txt_seguimiento As String,
                                               tipo_nota As String, vg_id_cia As String, Optional ByRef nivel_cumplimiento As String = "")
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0606_seguimientos_acciones" _
        & " (f0606_id_documento, f0606_id_cia, f0606_seguimiento_accion, f0606_nivel_cumplimiento," _
        & " f0606_fecha_inicio, f0606_fecha_fin, f0606_id_tipo_seguimiento, f0606_tipo_nota," _
        & " f0606_usuario_crear, f0606_usuario_modificar, f0606_fm)" _
        & " VALUES" _
        & " (@f0606_id_documento, @f0606_id_cia, @f0606_seguimiento_accion, @f0606_nivel_cumplimiento," _
        & " @f0606_fecha_inicio, @f0606_fecha_fin, @f0606_id_tipo_seguimiento, @f0606_tipo_nota," _
        & " @f0606_usuario_crear, @f0606_usuario_modificar, @f0606_fm)"
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'crear_parametros_seguimiento(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0606_id_documento", NpgsqlDbType.Integer).Value = id_reg_padre
        ocmd.Parameters.Add("@f0606_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0606_seguimiento_accion", NpgsqlDbType.Varchar).Value = txt_seguimiento

        If nivel_cumplimiento = "" Then
            'ocmd.Parameters.Add("@f0606_nivel_cumplimiento", NpgsqlDbType.Varchar).Value = cl_utilidades_gestion_acciones.obtener_nivel_cumplimiento_actual(id_reg_padre, tipo_nota).ToString.PadLeft(3, "0")
            ocmd.Parameters.Add("@f0606_nivel_cumplimiento", NpgsqlDbType.Varchar).Value = "000"
        Else
            ocmd.Parameters.Add("@f0606_nivel_cumplimiento", NpgsqlDbType.Varchar).Value = nivel_cumplimiento.ToString.PadLeft(3, "0")
        End If
        Dim fecha_actual As Date
            fecha_actual = comunes.g_fechahora
        ocmd.Parameters.Add("@f0606_fecha_inicio", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0606_fecha_fin", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0606_id_tipo_seguimiento", NpgsqlDbType.Integer).Value = 1 'seguimiento estandar
        ocmd.Parameters.Add("@f0606_tipo_nota", NpgsqlDbType.Varchar).Value = tipo_nota
        ocmd.Parameters.Add("@f0606_usuario_crear", NpgsqlDbType.Varchar).Value = "00000001"
        ocmd.Parameters.Add("@f0606_usuario_modificar", NpgsqlDbType.Varchar).Value = "00000001"
        ocmd.Parameters.Add("@f0606_fm", NpgsqlDbType.Timestamp).Value = fecha_actual

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
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Public Shared Function obligar_anotacion(ByVal encabezado_nota As String, lb_texto As String,
                                             ByVal vg_usuario_autoriza As String, ByVal id_reg_padre As Integer,
                                             tipo_nota As String, vg_id_cia As String,
                                             Optional info_anexa As String = "",
                                             Optional identif_emisor As String = "S")
        'Valido la identidad del usuario
        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim ovalidado As String = "N"
        Dim ojustificacion As String = ""
        Dim oform_login As New camocontrol.login
        'oform_grilla_programacion.ods_hijo = ods
        oform_login.ocontexto_form = "2"
        formulario_inicio.usuario_validado = "$ND$"
        oform_login.ShowDialog()
        If formulario_inicio.usuario_validado = "$ND$" Then
            'MsgBox("evento 1")
            Return ovalidado = "N"
            Exit Function
        Else
            'MsgBox(vg_usuario_autoriza & " = " & formulario_inicio.usuario_validado)
            If vg_usuario_autoriza = formulario_inicio.usuario_validado Then
                formulario_inicio.usuario_validado = "$ND$"
                ojustificacion = comunes.formulario_parametro_texto("", lb_texto, True)
                If ojustificacion.Trim <> "" Then
                    If identif_emisor = "S" Then
                        Dim emisor As String
                        emisor = comunes.traer_nombre_usuario(vg_usuario_autoriza)
                        encabezado_nota = "Notificacion generada por la accion del usuario: " _
                            & emisor & vbCrLf & vbCrLf & encabezado_nota
                    End If
                    ojustificacion = UCase(encabezado_nota & vbCrLf & ojustificacion)
                    If info_anexa <> "" Then
                        ojustificacion = ojustificacion & vbCrLf & vbCrLf & info_anexa
                    End If
                    grabar_nuevo_seguimiento(id_reg_padre, ojustificacion, tipo_nota, vg_id_cia)
                    ovalidado = "S"
                    'MsgBox("evento 2")
                Else
                    ovalidado = "N"
                    'MsgBox("evento 3")
                End If
            Else
                MsgBox("Usuario que autoriza diferente de usuario de sistema! No se Ejecuta.", MsgBoxStyle.Exclamation, "Info")
                ovalidado = "N"
            End If
        End If
        'MsgBox("sale")
        Return ovalidado
    End Function

End Class
