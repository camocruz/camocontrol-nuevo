Public Class cl_informes_comunes
    Public Shared Sub informe_solicitud_compra(ByVal id_solicitud As Integer, ByVal id_cia As String)
        Dim csql As String
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-32", id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_solicitud)
        'Lleno el dataset tipado con la datable que entrega la funcion clase

        Dim oconn_form As NpgsqlConnection
        Dim oda As NpgsqlDataAdapter
        Dim ds_solicitud_compra As New DataSet
        oconn_form = database.obtener_conexion
        oda = New NpgsqlDataAdapter(csql, oconn_form)
        'Si ya existe el Data Table creado, lo borra
        If ds_solicitud_compra.Tables.Contains("dt_items") Then
            ds_solicitud_compra.Tables("dt_items").Clear()
        End If
        'Llenamos el dataAdapter con el query definido arriba, y le damos nombre a la tabla que se creará en memoria

        'carga todos los metadatos sobre una tabla, como nombres de columnas, claves y contsrains
        'oda.FillSchema(ods, SchemaType.Source, "info_sidlog")

        'carga los datos propiamente dichos.
        oda.Fill(ds_solicitud_compra, "dt_items")

        'Dim otb_info_sidlog As DataTable
        ' otb_info_sidlog = ods.Tables("info_sidlog")
        'cerrar coneccion
        oconn_form.Close()



        'Dim ds_solicitud_compra As New DataSet

        'Si ya existe el Data Table creado, lo borra
        'If ds_solicitud_compra.Tables.Contains("dt_items") Then
        'ds_solicitud_compra.Tables("dt_items").Clear()
        'End If
        'Esta seccion llena totalmente el reporte discriminado. y el encabezado del reporte agrupado
        'ds_solicitud_compra.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        'ds_solicitud_compra.Tables(0).TableName = "dt_items"

        Dim cr_0300_solicitud_compra As New cr_0300_solicitud_compra
        cr_0300_solicitud_compra.SetDataSource(ds_solicitud_compra)
        Dim fi_visor_cr As New FI_VISOR_CR
        fi_visor_cr.cr_visor.ReportSource = cr_0300_solicitud_compra
        'para mostrar preliminar del reporte
        fi_visor_cr.Text = "Orden de Cargue Agrupado"
        fi_visor_cr.ShowDialog()
        ds_solicitud_compra.Dispose()
    End Sub

    Public Shared Sub informe_orden_compra(ByVal id_oc As Integer, ByVal id_cia As String)
        Dim csql As String
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-40", id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_cia)
        csql = csql.Replace("$002$", id_oc)
        'Lleno el dataset tipado con la datable que entrega la funcion clase
        Dim ds_solicitud_compra As New DataSet
        'Clipboard.SetText(csql)
        'MsgBox("Hola")

        'Si ya existe el Data Table creado, lo borra
        If ds_solicitud_compra.Tables.Contains("dt_orden_compra") Then
            ds_solicitud_compra.Tables("dt_orden_compra").Clear()
        End If
        'Esta seccion llena totalmente el reporte discriminado. y el encabezado del reporte agrupado
        ds_solicitud_compra.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_solicitud_compra.Tables(0).TableName = "dt_orden_compra"

        Dim cr_0300_orden_compra As New cr_0300_orden_compra
        cr_0300_orden_compra.SetDataSource(ds_solicitud_compra)
        Dim fi_visor_cr As New FI_VISOR_CR
        fi_visor_cr.cr_visor.ReportSource = cr_0300_orden_compra
        'para mostrar preliminar del reporte
        fi_visor_cr.Text = "Orden de Compra"
        fi_visor_cr.ShowDialog()
        ds_solicitud_compra.Dispose()
    End Sub

    Public Shared Sub reporte_doc_mov_inventario(ByVal vg_id_cia As String, ByVal id_doc_inv As String)
        Dim csql As String

        'Lleno el dataset tipado con la datable que entrega la funcion clase
        Dim ds_solicitud_compra As New DataSet


        'Si ya existe el Data Table creado, lo borra
        If ds_solicitud_compra.Tables.Contains("dt_inf_doc_inventario") Then
            ds_solicitud_compra.Tables("dt_inf_doc_inventario").Clear()
        End If
        If ds_solicitud_compra.Tables.Contains("dt_anotaciones_doc_inventario") Then
            ds_solicitud_compra.Tables("dt_anotaciones_doc_inventario").Clear()
        End If

        Dim var_config As String

        If Strings.Left(id_doc_inv, 3) = "DAC" Then
            var_config = "ST-0400-08"
        Else
            var_config = "ST-0300-20"
        End If

        csql = comunes.suministrar_valor_variable_configuracion(var_config, vg_id_cia)
        'csql = comunes.suministrar_valor_variable_configuracion("ST-0400-08", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_doc_inv)
        ds_solicitud_compra.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_solicitud_compra.Tables(0).TableName = "dt_inf_doc_inventario"

        'busco la informacion de trazabilidad
        Dim otb_info_trazabilidad_items As DataTable
        csql = "SELECT *" _
                 & " FROM " & database.obtener_esquema & ".tb0318_trazabilidad_movimientos" _
                 & " where f0318_id_documento = '" & id_doc_inv & "'"
        otb_info_trazabilidad_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In ds_solicitud_compra.Tables(0).Rows
            'complemento la descripcion del item con la info de trazabilidad
            Dim info_trazabilidad As String = ""
            Dim orows_trazabilidad As DataRow()
            orows_trazabilidad = otb_info_trazabilidad_items.Select("f0318_id_mov_item = '" & orow("id_mov_item") & "'")
            For Each orow2 As DataRow In orows_trazabilidad
                info_trazabilidad += orow2("f0318_info_trazable") & ", "
            Next
            If info_trazabilidad <> "" Then
                orow("item") = orow("item") & " { Lote: " & info_trazabilidad & " }"
            End If
        Next

        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-21", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_doc_inv)
        ds_solicitud_compra.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_solicitud_compra.Tables(1).TableName = "dt_anotaciones_doc_inventario"

        'Clipboard.SetDataObject(csql)
        'MsgBox("hola")
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0300-20", vg_id_cia, "00000001", "hola", {vg_id_cia, id_doc_inv})
        'Esta seccion llena totalmente el reporte discriminado. y el encabezado del reporte agrupado

        Dim cr_0300_solicitud_compra As New cr_0300_reporte_doc_mov_inventario
        cr_0300_solicitud_compra.SetDataSource(ds_solicitud_compra)
        Dim fi_visor_cr As New FI_VISOR_CR
        fi_visor_cr.cr_visor.ReportSource = cr_0300_solicitud_compra
        'para mostrar preliminar del reporte
        fi_visor_cr.Text = "Documento Mov Inventario"
        fi_visor_cr.ShowDialog()
        ds_solicitud_compra.Dispose()
    End Sub

    Public Shared Sub reporte_solicitud_almacen(ByVal vg_id_cia As String, ByVal id_sol_alm As String, ByVal tipo As Integer)
        Dim csql As String

        'Lleno el dataset tipado con la datable que entrega la funcion clase
        Dim ds_solicitud_almacen As New DataSet

        'Si ya existe el Data Table creado, lo borra
        If ds_solicitud_almacen.Tables.Contains("otb_encabezado") Then
            ds_solicitud_almacen.Tables("otb_encabezado").Clear()
        End If
        If ds_solicitud_almacen.Tables.Contains("otb_detalle") Then
            ds_solicitud_almacen.Tables("otb_detalle").Clear()
        End If

        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-25", vg_id_cia)
        'csql = comunes.suministrar_valor_variable_configuracion("ST-0400-08", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_sol_alm)
        ds_solicitud_almacen.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_solicitud_almacen.Tables(0).TableName = "otb_encabezado"

        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-26", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_sol_alm)
        ds_solicitud_almacen.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_solicitud_almacen.Tables(1).TableName = "otb_detalle"

        'Clipboard.SetDataObject(csql)
        'MsgBox("hola")
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0300-20", vg_id_cia, "00000001", "hola", {vg_id_cia, id_doc_inv})
        'Esta seccion llena totalmente el reporte discriminado. y el encabezado del reporte agrupado
        Dim cr_0300_solicitud_almacen As Object
        cr_0300_solicitud_almacen = Nothing
        Select Case tipo
            Case 1
                'Solicitud de almacen usada por produccion 
                cr_0300_solicitud_almacen = New cr_0300_sol_almacen
            Case 2
                'Solicitud de almacen usada por mantenimiento
                cr_0300_solicitud_almacen = New cr_0600_sol_almacen_acc
        End Select

        cr_0300_solicitud_almacen.SetDataSource(ds_solicitud_almacen)
        Dim fi_visor_cr As New FI_VISOR_CR
        fi_visor_cr.cr_visor.ReportSource = cr_0300_solicitud_almacen
        'para mostrar preliminar del reporte
        fi_visor_cr.Text = "Solicitud de Almacen"
        fi_visor_cr.ShowDialog()
        ds_solicitud_almacen.Dispose()
    End Sub

    Public Shared Sub reporte_actividad_sgc(ByVal vg_id_cia As String, ByVal id_actividad As String)
        Dim csql As String

        'Lleno el dataset tipado con la datable que entrega la funcion clase
        Dim ds_acciones_sgc As New DataSet

        'Si ya existe el Data Table creado, lo borra
        If ds_acciones_sgc.Tables.Contains("dt_inf_actividad") Then
            ds_acciones_sgc.Tables("dt_inf_actividad").Clear()
        End If

        Dim var_config As String = "ST-0600-05"

        csql = comunes.suministrar_valor_variable_configuracion(var_config, vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_actividad)

        Dim otb As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        ds_acciones_sgc.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_acciones_sgc.Tables(0).TableName = "dt_inf_actividad"

        'Clipboard.SetDataObject(csql)
        'MsgBox("hola")
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0300-20", vg_id_cia, "00000001", "hola", {vg_id_cia, id_doc_inv})
        'Esta seccion llena totalmente el reporte discriminado. y el encabezado del reporte agrupado

        Dim cr_0600_act_simple As New cr_0600_rep_actividad_simple
        cr_0600_act_simple.SetDataSource(ds_acciones_sgc)
        Dim fi_visor_cr As New FI_VISOR_CR
        fi_visor_cr.cr_visor.ReportSource = cr_0600_act_simple
        'para mostrar preliminar del reporte
        fi_visor_cr.Text = "Orden de Trabajo"
        fi_visor_cr.ShowDialog()
        ds_acciones_sgc.Dispose()
    End Sub
    Public Shared Sub reporte_plan_accion_proyecto(ByVal vg_id_cia As String, ByVal id_actividad As String)
        Dim csql As String

        'Lleno el dataset tipado con la datable que entrega la funcion clase
        Dim ds_acciones_sgc As New DataSet

        'Si ya existe el Data Table creado, lo borra
        If ds_acciones_sgc.Tables.Contains("dt_inf_actividad") Then
            ds_acciones_sgc.Tables("dt_inf_actividad").Clear()
        End If

        Dim var_config As String = "ST-0600-06"

        csql = comunes.suministrar_valor_variable_configuracion(var_config, vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_actividad)

        Dim otb As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        ds_acciones_sgc.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_acciones_sgc.Tables(0).TableName = "dt_inf_plan_accion"

        'Clipboard.SetDataObject(csql)
        'MsgBox("hola")
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0300-20", vg_id_cia, "00000001", "hola", {vg_id_cia, id_doc_inv})
        'Esta seccion llena totalmente el reporte discriminado. y el encabezado del reporte agrupado

        Dim cr_0600_plan_accion As New cr_0600_plan_de_accion
        cr_0600_plan_accion.SetDataSource(ds_acciones_sgc)
        Dim fi_visor_cr As New FI_VISOR_CR
        fi_visor_cr.cr_visor.ReportSource = cr_0600_plan_accion
        'para mostrar preliminar del reporte
        fi_visor_cr.Text = "Reporte PLAN DE ACCION Y/O PROYECTO"
        fi_visor_cr.ShowDialog()
        ds_acciones_sgc.Dispose()
    End Sub

    Public Shared Sub reporte_seguimiento_anotacion(ByVal vg_id_cia As String, ByVal id_seguimiento As String)
        Dim csql As String

        'Lleno el dataset tipado con la datable que entrega la funcion clase
        Dim ds_acciones_sgc As New DataSet

        'Si ya existe el Data Table creado, lo borra
        If ds_acciones_sgc.Tables.Contains("dt_inf_seguimientos") Then
            ds_acciones_sgc.Tables("dt_inf_seguimientos").Clear()
        End If


        csql = comunes.suministrar_valor_variable_configuracion("ST-0607-01", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_seguimiento)

        Dim otb As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        ds_acciones_sgc.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_acciones_sgc.Tables(0).TableName = "dt_inf_seguimientos"



        'Clipboard.SetDataObject(csql)
        'MsgBox("hola")
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0300-20", vg_id_cia, "00000001", "hola", {vg_id_cia, id_doc_inv})
        'Esta seccion llena totalmente el reporte discriminado. y el encabezado del reporte agrupado

        Dim cr_0607_seguimiento As New cr_0607_info_anotacion_seguimiento
        cr_0607_seguimiento.SetDataSource(ds_acciones_sgc)
        Dim fi_visor_cr As New FI_VISOR_CR
        fi_visor_cr.cr_visor.ReportSource = cr_0607_seguimiento
        'para mostrar preliminar del reporte
        fi_visor_cr.Text = "Reporte SEGUIMIENTO O ANOTACION"
        fi_visor_cr.ShowDialog()
        ds_acciones_sgc.Dispose()
    End Sub

    Public Shared Sub reporte_control_documento(ByVal vg_id_cia As String, ByVal id_documento As String)
        Dim csql As String

        'Lleno el dataset tipado con la datable que entrega la funcion clase
        Dim ds_control_documentos As New DataSet

        'Si ya existe el Data Table creado, lo borra
        If ds_control_documentos.Tables.Contains("otb_enc_info_documento") Then
            ds_control_documentos.Tables("otb_enc_info_documento").Clear()
        End If
        If ds_control_documentos.Tables.Contains("otb_control_cambios") Then
            ds_control_documentos.Tables("otb_control_cambios").Clear()
        End If
        If ds_control_documentos.Tables.Contains("otb_accesos") Then
            ds_control_documentos.Tables("otb_accesos").Clear()
        End If

        csql = comunes.suministrar_valor_variable_configuracion("ST-0500-03", vg_id_cia)
        'csql = comunes.suministrar_valor_variable_configuracion("ST-0400-08", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_documento)
        ds_control_documentos.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_control_documentos.Tables(0).TableName = "otb_enc_info_documento"

        csql = comunes.suministrar_valor_variable_configuracion("ST-0500-04", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_documento)
        ds_control_documentos.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_control_documentos.Tables(1).TableName = "otb_control_cambios"

        csql = comunes.suministrar_valor_variable_configuracion("ST-0500-05", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_documento)
        ds_control_documentos.Tables.Add(cl_utilidades_datatables.cargar_informacion_postgres(csql).Copy())
        ds_control_documentos.Tables(2).TableName = "otb_accesos"

        'Clipboard.SetDataObject(csql)
        'MsgBox("hola")
        'cl_utilidades_datatables.visualizar_datos_visor("ST-0300-20", vg_id_cia, "00000001", "hola", {vg_id_cia, id_doc_inv})
        'Esta seccion llena totalmente el reporte discriminado. y el encabezado del reporte agrupado

        Dim cr_0500_info_del_documento As New cr_0500_info_del_documento
        cr_0500_info_del_documento.SetDataSource(ds_control_documentos)
        Dim fi_visor_cr As New FI_VISOR_CR
        fi_visor_cr.cr_visor.ReportSource = cr_0500_info_del_documento
        'para mostrar preliminar del reporte
        fi_visor_cr.Text = "Control del Documento"
        fi_visor_cr.ShowDialog()
        ds_control_documentos.Dispose()
    End Sub
End Class
