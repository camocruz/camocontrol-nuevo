Public Class cl_utilidades_gestion_produccion

    Public Shared Function suministrar_orow_info_ipp(ByVal id_ipp As Integer)
        Dim csql As String = "select *," _
            & " f0300_descripcion_item || ' (' || f0300_referencia || ') (' || f0300_contenido_x_empaque || ')' as descripcion_larga" _
            & " from " & database.obtener_esquema & ".tb0401_items_prog_prod" _
                             & " join " & database.obtener_esquema & ".tb0300_items" _
                               & "  on f0401_id_item = f0300_id_item" _
                             & " join " & database.obtener_esquema & ".tb0002_unidades_medicion" _
                               & "  on f0300_id_unidad_medicion = f0002_id_unidad_medicion" _
            & " where f0401_id_ipp = '" & id_ipp & "'"
        Dim otb_ipp As DataTable
        otb_ipp = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim orow As DataRow = Nothing
        For Each orow2 As DataRow In otb_ipp.Rows
            orow = orow2
        Next
        Return orow
    End Function

    Public Shared Function suministrar_orow_info_rp(ByVal id_rp As Integer)
        Dim csql As String = "select * from " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                                             & " where f0402_id_rp = '" & id_rp & "'"
        Dim otb_rp As DataTable
        otb_rp = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim orow As DataRow = Nothing
        For Each orow2 As DataRow In otb_rp.Rows
            orow = orow2
        Next
        Return orow
    End Function

    Public Shared Sub desplegar_item_prog_prod(ByVal vg_id_cia As String, ByVal vg_usuario_autoriza As String, Optional cod_documento As String = "")
        Dim documento As String
        If cod_documento <> "" Then
            documento = cod_documento
        Else
            documento = comunes.formulario_parametro_texto("", "Numero del Documento", False)
        End If
        If documento.Trim = "" Then
            Exit Sub
        End If
        Dim doc_valido As String = "N"
        If Strings.Left(documento, 3) = "RP-" Then
            'MsgBox("Busco en tablas de RP")
            doc_valido = "S"
        End If
        If Strings.Left(documento, 4) = "IPP-" Then
            'MsgBox("Busco en tablas de IPP")
            doc_valido = "S"
        End If
        If doc_valido = "N" Then
            MsgBox("Documento no valido", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        'Verifico que el documento exista

        Dim info_ipp As String() = Split(documento, "-")
        Dim tipo_docto As String = info_ipp(0)
        Dim orow_ipp As DataRow = Nothing
        Dim orow_rp As DataRow = Nothing
        Dim descripcion_producto As String = ""
        Dim path_ipp As String = ""
        Dim id_item As Integer
        Dim id_prog_prod As Integer
        Dim id_item_pp As Integer

        Select Case tipo_docto
            Case "IPP"
                orow_ipp = cl_utilidades_gestion_produccion.suministrar_orow_info_ipp(info_ipp(1))
                If IsNothing(orow_ipp) = True Then
                    MsgBox("El " & documento & " NO EXISTE!", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                Else
                    If orow_ipp("f0401_anulado") = "S" Then
                        MsgBox("El " & documento & " ESTA ANULADO!", MsgBoxStyle.Exclamation, "Error")
                        Exit Sub
                    End If
                End If
                path_ipp = orow_ipp("f0401_tree_path")
                'MsgBox(orow_ipp("f0401_id_ipp"))
                'MsgBox(orow_ipp("f0401_tree_path"))
                'Busco la informacion de la cabeza del arbol ipp_ppal
                Dim orow_path As String() = Split(path_ipp, "-")
                'Identifico si el ipp es el programa mes, o un item del programa del mes.
                'MsgBox(orow_path.Length)
                Select Case orow_path.Length
                    Case 2
                        MsgBox("El IPP es el programa de produccion de un mes")
                        Exit Sub
                    Case 3
                        MsgBox("El IPP es un item de un programa")
                        Exit Sub
                End Select
                id_prog_prod = orow_path(1)
                Dim id_ipp_ppal As Integer = orow_path(2)
                'MsgBox(id_ipp_ppal & " HOLA")

                Dim orow_ipp_ppal As DataRow = cl_utilidades_gestion_produccion.suministrar_orow_info_ipp(id_ipp_ppal)
                descripcion_producto = orow_ipp_ppal("descripcion_larga")
                id_item = orow_ipp_ppal("f0401_id_item")
                path_ipp = orow_ipp_ppal("f0401_tree_path") & id_ipp_ppal & "-"
                id_item_pp = id_ipp_ppal
            Case "RP"
                orow_rp = cl_utilidades_gestion_produccion.suministrar_orow_info_rp(info_ipp(1))
                If IsNothing(orow_rp) = True Then
                    MsgBox("El " & documento & " NO EXISTE!", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                Else
                    If orow_rp("f0402_anulado") = "S" Then
                        MsgBox("El " & documento & " ESTA ANULADO!", MsgBoxStyle.Exclamation, "Error")
                        Exit Sub
                    End If
                End If
                Dim id_ipp_rp As String = "IPP-" & orow_rp("f0402_id_ipp")
                cl_utilidades_gestion_produccion.desplegar_item_prog_prod(vg_id_cia, vg_usuario_autoriza, id_ipp_rp)
                Exit Sub
        End Select

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0400_pp_ordenes_produccion_arbol
        'oform_catalogo_items.vf_oform_padre = Me
        oform_catalogo_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_catalogo_items.vg_id_cia = vg_id_cia
        oform_catalogo_items.lb_producto.Text = "PRODUCTO: " & descripcion_producto
        oform_catalogo_items.id_prog_prod = id_prog_prod
        oform_catalogo_items.id_item_clonar = id_item
        oform_catalogo_items.id_item_pp = id_item_pp
        oform_catalogo_items.tree_path_base = path_ipp
        oform_catalogo_items.vf_elemento_nuevo = "N"
        oform_catalogo_items.nodo_buscar = documento
        oform_catalogo_items.ShowDialog()
    End Sub
    Public Shared Sub actualizar_cantidad_produccion(ByVal id_rp As Integer, ByVal nueva_cantidad As Decimal,
                                                     ByVal vg_usuario_autoriza As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        Dim oconn_form As NpgsqlConnection
        oconn_form = database.obtener_conexion()
        Dim csql As String
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0402_reporte_produccion set "
        csql += "f0402_cantidad_producida = @f0402_cantidad_producida,"
        csql += "f0402_usuario_modificar = @f0402_usuario_modificar,"
        csql += "f0402_fm = @f0402_fm"
        csql += " where f0402_id_rp = @f0402_id_rp"

        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0402_id_rp", NpgsqlDbType.Integer).Value = id_rp
        ocmd.Parameters.Add("@f0402_cantidad_producida", NpgsqlDbType.Numeric).Value = nueva_cantidad
        ocmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act

        Dim verror As String
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
    End Sub
End Class
