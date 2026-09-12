Public Class fm_0400_rp_reporte_lotes_produccion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_prog_prod As Integer
    Public id_rp As Integer
    Public id_ipp As Integer
    Public id_item As Integer
    Public tree_path As String = ""

    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private estado_rp As String = "C" 'A = abierto  C = cerrado  B = cerrado por administrador sin cumplir requisitos
    Private descripcion_producto As String = ""
    Private verror As String = "S"
    Private vexiste As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private otb_items As DataTable
    Private otb_reporte_produccion As DataTable

    Private Sub fm_0400_rp_reporte_lotes_produccion_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        ' Set the Format type and the CustomFormat string.
        dtp_fecha.Format = DateTimePickerFormat.Custom
        dtp_fecha.CustomFormat = "yyyy/MM/dd hh:mm tt"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_vencimiento.Format = DateTimePickerFormat.Custom
        dtp_fecha_vencimiento.CustomFormat = "yyyy/MM/dd"
        dtp_fecha_vencimiento.Value = Now().AddYears(1)

        csql = "SELECT *, f0300_descripcion_item || ' - REF:(' || f0300_referencia || ') -" _
                    & " P:(' || f0300_contenido_x_empaque || ')' as descripcion_larga" _
                    & " FROM " & database.obtener_esquema & ".tb0300_items" _
                      & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                        & " on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
                    & " where f0300_id_cia = '" & vg_id_cia & "'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        If vf_elemento_nuevo = "N" Then
            tx_id_rp.Text = id_rp
            cargar_info_rp()
            If estado_rp = "C" Or estado_rp = "B" Then
                bloquear_edicion()
            End If
        Else
            bt_grabar.Enabled = True
        End If
        If vg_usuario_autoriza = "00000001" Then
            bt_grabar.Enabled = True
        End If
        Dim orowsintem As DataRow()
        orowsintem = otb_items.Select("f0300_id_item = '" & id_item & "'")
        For Each orow As DataRow In orowsintem
            lb_producto.Text = "Producto: " & orow("descripcion_larga")
            descripcion_producto = orow("descripcion_larga") & " {" & orow("f0002_unidad_medicion") & "}"
        Next



    End Sub

    Private Sub cargar_info_rp()
        csql = "select *" _
                    & " FROM " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                    & " where f0402_id_cia = '" & vg_id_cia & "' and f0402_id_rp = '" & id_rp & "'"
        otb_reporte_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_reporte_produccion.Rows
            'id_item = orow("f0402_id_item")
            id_rp = orow("f0402_id_rp")
            tx_ip_cg.Text = orow("f0402_ip_cg_codigo").ToString
            id_ipp = orow("f0402_id_ipp")
            id_item = orow("f0402_id_item")
            'lb_total_notas.Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(otipo_nota, id_rp, vg_id_cia)
            vf_id_notas_archivos = orow("f0402_id_rp")
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)
            tx_id_rp.Text = orow("f0402_id_rp")
            dtp_fecha.Value = orow("f0402_fecha_produccion")
            dtp_fecha_vencimiento.Value = orow("f0402_fecha_vence")
            tx_lote.Text = orow("f0402_lote")
            estado_rp = orow("f0402_estado")
        Next
    End Sub

    Private Sub bloquear_edicion()
        bt_grabar.Enabled = False
        bt_editar.Enabled = False
    End Sub


    Private Function nuevo_rp() As Integer
        'RETURNING Permite obtener el ID sin hacer otra consulta.
        'Se puede usar asi:
        'Dim idNuevo As Integer = nuevo_rp()
        Dim fechaAct As Date = comunes.g_fechahora

        Dim sql As String =
    $"INSERT INTO " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                & " (f0402_id_cia, f0402_id_prog_prod, f0402_id_ipp, f0402_fecha_produccion, f0402_id_item," _
                & " f0402_lote, f0402_fecha_vence," _
                & " f0402_tree_path," _
                & " f0402_tipo_registro," _
                & " f0402_usuario_modificar, f0402_usuario_crear, f0402_fm)" _
                & " VALUES" _
                & " (@f0402_id_cia, @f0402_id_prog_prod, @f0402_id_ipp, @f0402_fecha_produccion, @f0402_id_item," _
                & " @f0402_lote, @f0402_fecha_vence," _
                & " @f0402_tree_path," _
                & " @f0402_tipo_registro," _
                & " @f0402_usuario_modificar, @f0402_usuario_crear, @f0402_fm) 
                    RETURNING f0402_id_rp;"

        Try
            Using conn As NpgsqlConnection = database.obtener_conexion(),
              cmd As New NpgsqlCommand(sql, conn)

                Dim fecha_act As Date = comunes.g_fechahora
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@f0402_id_prog_prod", NpgsqlDbType.Integer).Value = id_prog_prod
                cmd.Parameters.Add("@f0402_id_ipp", NpgsqlDbType.Integer).Value = id_ipp
                cmd.Parameters.Add("@f0402_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
                cmd.Parameters.Add("@f0402_id_item", NpgsqlDbType.Integer).Value = id_item
                cmd.Parameters.Add("@f0402_tipo_registro", NpgsqlDbType.Integer).Value = 1 '1 = rp, 2= actividad alterna
                cmd.Parameters.Add("@f0402_lote", NpgsqlDbType.Varchar).Value = tx_lote.Text.Trim
                cmd.Parameters.Add("@f0402_fecha_vence", NpgsqlDbType.Timestamp).Value = dtp_fecha_vencimiento.Value
                cmd.Parameters.Add("@f0402_tree_path", NpgsqlDbType.Varchar).Value = tree_path
                cmd.Parameters.Add("@f0402_fecha_produccion", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value
                cmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
                cmd.Parameters.Add("@f0402_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
                cmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act

                cmd.Prepare()

                ' Ejecuta y obtiene el ID insertado
                Dim nuevoId As Integer = CInt(cmd.ExecuteScalar())
                Return nuevoId

            End Using

        Catch ex As Exception
            verror = "S"
            MsgBox("Error al insertar encabezado del programa de producción:" & vbCrLf &
               ex.Message & vbCrLf &
               "SQL: " & sql)
            Return -1
        End Try

    End Function


    Private Sub editar_rp()

        Dim fechaAct As Date = comunes.g_fechahora

        Dim sql As String =
        $"UPDATE {database.obtener_esquema}.tb0402_reporte_produccion SET
            f0402_fecha_produccion = @fecha_produccion,
            f0402_fecha_vence = @fecha_vence,
            f0402_lote = @lote,
            f0402_usuario_modificar = @usuario_modificar,
            f0402_fm = @fm
          WHERE f0402_id_rp = @id_rp;"

        Try
            Using conn As NpgsqlConnection = database.obtener_conexion(),
              cmd As New NpgsqlCommand(sql, conn)

                cmd.Parameters.Add("@id_rp", NpgsqlDbType.Integer).Value = CInt(tx_id_rp.Text)
                cmd.Parameters.Add("@fecha_produccion", NpgsqlDbType.Timestamp).Value = dtp_fecha.Value
                cmd.Parameters.Add("@fecha_vence", NpgsqlDbType.Timestamp).Value = dtp_fecha_vencimiento.Value
                cmd.Parameters.Add("@lote", NpgsqlDbType.Varchar).Value = tx_lote.Text
                cmd.Parameters.Add("@usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
                cmd.Parameters.Add("@fm", NpgsqlDbType.Timestamp).Value = fechaAct

                cmd.Prepare()
                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            verror = "S"
            MsgBox("Error al actualizar el reporte de producción:" & vbCrLf &
               ex.Message & vbCrLf &
               "SQL: " & sql)
        End Try

    End Sub


    Private Sub anular_rp()

        Dim fechaAct As Date = comunes.g_fechahora

        Dim sql As String =
            $"UPDATE {database.obtener_esquema}.tb0402_reporte_produccion SET
            f0402_anulado = @anulado,
            f0402_usuario_anular = @usuario_anular,
            f0402_usuario_modificar = @usuario_modificar,
            f0402_fm = @fm
          WHERE f0402_id_rp = @id_rp;"

        Try
            Using conn As NpgsqlConnection = database.obtener_conexion(),
                  cmd As New NpgsqlCommand(sql, conn)

                cmd.Parameters.Add("@id_rp", NpgsqlDbType.Integer).Value = CInt(tx_id_rp.Text)
                cmd.Parameters.Add("@anulado", NpgsqlDbType.Varchar).Value = "S"
                cmd.Parameters.Add("@usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
                cmd.Parameters.Add("@usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
                cmd.Parameters.Add("@fm", NpgsqlDbType.Timestamp).Value = fechaAct

                cmd.Prepare()
                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            verror = "S"
            MsgBox("Error al anular el reporte de producción:" & vbCrLf &
                   ex.Message & vbCrLf &
                   "SQL: " & sql)
        End Try

    End Sub

    Private Sub validar_lote()
        If tx_lote.Text.Trim = "" Then
            vmensaje_requisitos = "Registre el Lote"
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        procedimiento_de_grabado()
    End Sub
    Private Sub procedimiento_de_grabado()
        verror_requisitos = "N"
        validar_lote()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If vf_elemento_nuevo = "S" Then
            id_rp = nuevo_rp()
            cargar_info_rp()
            vf_oform_padre.name_nodo_creado = "RP-" & tx_id_rp.Text
            vf_elemento_nuevo = "N"
            MsgBox("Registro Grabado", MsgBoxStyle.Information, "Info")
        Else
            editar_rp()
            If verror = "N" Then
                MsgBox("Registro Grabado", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        If id_rp = 0 Then
            Exit Sub
        End If
        'Pregunta si realmente desea ANULAR documento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Anular Documento", "Desea ANULAR este documento?")
        If respuesta = "N" Then
            Exit Sub
        End If
        'Verificamos que no existan impresiones del reporte
        csql = "SELECT coalesce(sum(f0420_cantidad),0) as cantidad
                    FROM camocontrol.tb0420_orden_imp_etiquetas
                    where f0420_op_alterna = '" & "RP-" & id_rp.ToString & "' and f0310_anulado = 'N'"

        Dim otb_ordenes_impresion As DataTable
        otb_ordenes_impresion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_ordenes_impresion.Rows.Count > 0 Then
            Dim cantidad As Integer = CInt(otb_ordenes_impresion.Rows(0)("cantidad"))
            If cantidad > 0 Then
                MsgBox("Cambio no realizado debido a que el reporte tiene ordenes de impresión de etiquetas:" _
                       & vbCrLf & "Cantidad de etiquetas impresas: " & cantidad.ToString, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If

        'Anulo el reporte
        anular_rp()
        If verror = "N" Then
            MsgBox("Documento Anulado", MsgBoxStyle.Information, "Info")
            Dispose()
        End If
    End Sub

    Private Sub bt_imprimir_etiquetas_Click(sender As Object, e As EventArgs) Handles bt_imprimir_etiquetas.Click
        If tx_id_rp.Text = "" Then
            Exit Sub
        End If
        cargar_info_rp()
        'If tx_cant_produccion.Text = 0 Then
        'Exit Sub
        'End If
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_impresion_etiquetas As New camocontrol.fm_0400_impresion_etiquetas
        'oform_grilla_programacion.ods_hijo = ods
        oform_impresion_etiquetas.vf_oform_padre = Me
        oform_impresion_etiquetas.vg_id_cia = vg_id_cia
        oform_impresion_etiquetas.vg_usuario_autoriza = vg_usuario_autoriza
        'oform_impresion_etiquetas.generada = "PPROS"
        'oform_impresion_etiquetas.id_item = id_item
        'oform_impresion_etiquetas.id_ipp = id_ipp
        oform_impresion_etiquetas.descripcion_item = lb_producto.Text
        oform_impresion_etiquetas.id_rp = id_rp
        oform_impresion_etiquetas.id_rp_documento = "RP-" & id_rp
        'oform_impresion_etiquetas.fecha_produccion = dtp_fecha.Value
        'oform_impresion_etiquetas.fecha_vencimiento = dtp_fecha_vencimiento.Value
        'oform_impresion_etiquetas.lote = tx_lote.Text
        oform_impresion_etiquetas.ShowDialog()
    End Sub
    Private Sub bt_calcular_lote_Click(sender As Object, e As EventArgs) Handles bt_calcular_lote.Click
        tx_lote.Text = DatePart(DateInterval.DayOfYear, dtp_fecha.Value) _
            & DatePart(DateInterval.Month, dtp_fecha.Value).ToString.PadLeft(2, "0") _
            & dtp_fecha.Value.ToString("yy")
    End Sub
    Private Sub bt_editar_Click(sender As Object, e As EventArgs) Handles bt_editar.Click
        bt_grabar.Enabled = True
    End Sub

End Class
