Imports System
Imports System.IO
Imports System.Collections
Imports System.Globalization
Public Class fm_0800_cargar_rm
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Private otb_remisiones_sin_despacho_asignado As DataTable
    Private otb_tipos_recaudos As DataTable
    Private otb_registros_grabados As DataTable
    Private otb_terceros As DataTable
    Private otb_items As DataTable
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand

    Private ofiscal As String = "1"
    Private numero_rm As String = ""
    Private id_encabezado As Integer
    Private fecha_documento_rm As Date
    Private codigo_cliente As String = ""
    Private digito_verificacion As String = ""
    Private razon_social As String = ""
    Private ciudad_cliente As String = ""
    Private direccion As String = ""
    Private nombre_vendedor As String = ""
    Private codigo_vendedor As String = ""
    Private referencia_1 As String = ""
    Private referencia_2 As String = ""
    Private cantidad_producto As Decimal = 0
    Private descripcion_producto As String = ""
    Private falla_items As String = "N"
    Private txt_falla_item As String = ""
    Private id_bodega As String = ""

    Private id_factura As Integer
    Private num_factura As String = ""
    Private tx_fecha_factura As String = ""
    Private subtotal_factura As Decimal
    Private descuento_factura As Decimal
    Private iva_factura As Decimal
    Private total_factura As Decimal
    Private factura_anulada_cg As String
    Private remision_factura As String

    Private id_item_producto As Integer
    Private subtotal_producto As Decimal
    Private descuento_producto As Decimal
    Private iva_producto As Decimal
    Private total_producto As Decimal

    Public ciudad_equivalente_actualizada As String = "N"
    Public id_ciudad As String
    Public id_tercero As String
    Public direccion_despacho As String
    Public ciudad_despacho As String

    Private Sub fm_0800_cargar_rm_Load(sender As Object, e As EventArgs) Handles Me.Load

        dg_remision_encabezado.AllowUserToAddRows = False
        dg_remision_encabezado.AllowUserToDeleteRows = False
        dg_remision_encabezado.AllowUserToResizeColumns = True
        dg_remision_encabezado.AllowUserToResizeRows = False
        dg_remision_encabezado.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige

        cargar_dg_remisiones_sin_asignar()
    End Sub

    Private Sub bt_cargar_rm_Click(sender As Object, e As EventArgs) Handles bt_cargar_rm.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim path_file As String = ""

        'openFileDialog1.InitialDirectory = "e:\"
        openFileDialog1.Filter = "csv files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*" 'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path_file = openFileDialog1.FileName
            'comunes.mostrar_archivo_texto(path_file, "")
        Else
            Exit Sub
        End If

        Dim lector As New IO.StreamReader(path_file, System.Text.Encoding.UTF7)
        ' Leer el contenido mientras no se llegue al final

        Dim txt_info As String = ""
        Dim contador_exitos As Integer = 0
        Dim contador_fallas As Integer = 0
        Dim bloqueo_actualizacion As String = "N"
        Dim pagina_extra As String = "N"
        Dim conteo_pagina_extra As Integer = 0

        While lector.Peek() <> -1
            Dim linea As String = Replace(lector.ReadLine(), "\'d1", "Ñ")
            ' Si no está vacía, añadirla al control
            ' Si está vacía, continuar el bucle
            If String.IsNullOrEmpty(linea) Then
                Continue While
            End If
            'No fiscal  
            If InStr(linea, "NIT.: 11111111-6") <> 0 Then
                ofiscal = "2"
            End If
            If InStr(linea, "NIT.: 805027332-8") <> 0 Then
                ofiscal = "1"
            End If
            '901183025-7
            If InStr(linea, "NIT.: 901183025-7") <> 0 Then
                ofiscal = "3"
            End If

            'Remision
            If InStr(linea, "Numero:") <> 0 Then
                'txt_info += vbCrLf & vbCrLf & vbCrLf
                'txt_info += "Numero Remision: " & Mid(linea, InStr(linea, "Numero:") + 8, 10).Trim & vbCrLf
                numero_rm = Mid(linea, InStr(linea, "Numero:") + 8, 10).Trim
                'MsgBox(numero_rm)
            End If
            'Fecha
            If InStr(linea, "Fecha :") <> 0 Then
                'txt_info += "Fecha: " & Mid(linea, InStr(linea, "Fecha :") + 7, 13).Trim & vbCrLf
                fecha_documento_rm = formatear_fecha(Mid(linea, InStr(linea, "Fecha :") + 7, 13).Trim)
            End If
            'Pagina:
            If InStr(linea, "Pagina:") <> 0 Then
                'txt_info += "Pagina:" & Mid(linea, InStr(linea, "Pagina:") + 7, 13).Trim & vbCrLf
                If Mid(linea, InStr(linea, "Pagina:") + 7, 13).Trim = "01 de 01" Then
                    pagina_extra = "N"
                    conteo_pagina_extra = 0
                Else
                    pagina_extra = "S"
                    'MsgBox("pagina extra")
                    conteo_pagina_extra += 1
                End If
                If pagina_extra = "N" Then
                    'Controlo que no se cargue dos veces la remision sin anular la anterior primero.
                    bloqueo_actualizacion = verificar_registro_rm(numero_rm, ofiscal)
                End If
            End If
            'Cliente   :
            If InStr(linea, "Cliente   :") <> 0 Then
                'txt_info += "Razon social: " & Mid(linea, InStr(linea, "Cliente   :") + 11, 54).Trim & vbCrLf
                razon_social = Mid(linea, InStr(linea, "Cliente   :") + 11, 54).Trim
            End If
            'Ciudad    :
            'MsgBox("Voy")
            If InStr(linea, "Ciudad    :") <> 0 Then
                'txt_info += "Ciudad: " & Mid(linea, InStr(linea, "Ciudad    :") + 11, 54).Trim & vbCrLf
                ciudad_cliente = Mid(linea, InStr(linea, "Ciudad    :") + 11, 54).Trim
                'MsgBox(ciudad_cliente)
            End If
            'Direccion :
            If InStr(linea, "Direccion :") <> 0 Then
                'txt_info += "Direccion: " & Mid(linea, InStr(linea, "Direccion :") + 11, 54).Trim & vbCrLf
                direccion = Mid(linea, InStr(linea, "Direccion :") + 11, 54).Trim
            End If
            'Vendedor:
            If InStr(linea, "Vendedor:") <> 0 Then
                'txt_info += "Vendedor: " & Mid(linea, InStr(linea, "Vendedor:") + 9, 14).Trim & vbCrLf
                codigo_vendedor = Mid(linea, InStr(linea, "Vendedor:") + 9, 14).Trim
                nombre_vendedor = Mid(linea, InStr(linea, "Vendedor:") + 23, 40).Trim
            End If
            'Fecha :
            If InStr(linea, "Nit o C.C.:") <> 0 Then
                Dim otxt_nit() As String = Split(Mid(linea, InStr(linea, "Nit o C.C.:") + 11, 19).Trim, "-")
                If otxt_nit.Length = 2 Then
                    codigo_cliente = otxt_nit(0).Trim
                    digito_verificacion = otxt_nit(1).Trim
                Else
                    codigo_cliente = otxt_nit(0).Trim
                    digito_verificacion = ""
                End If
                'txt_info += "NIT: " & Mid(linea, InStr(linea, "Nit o C.C.:") + 11, 19).Trim & vbCrLf
            End If
            'Fax       :  indica que ya se leyo todo el encabezado
            If InStr(linea, "Fax       :") <> 0 And conteo_pagina_extra <= 1 Then
                'MsgBox(bloqueo_actualizacion)
                If bloqueo_actualizacion = "N" Then
                    verror = "N"
                    contador_exitos += 1
                    grabar_encabezado_rm()
                    'id_encabezado = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0850_id_rm", "f0850_usuario_crear", vg_usuario_autoriza, "tb0850_remisiones_cguno_encabezado")
                    'MsgBox(id_encabezado)
                Else
                    contador_fallas += 1
                End If
            End If

            'Referencia producto
            Dim otxt_array() As String = Split(Mid(linea, 8, 12).Trim, "-")
            If otxt_array.Length = 2 Then
                'If IsNumeric(otxt_array(0)) = True And IsNumeric(otxt_array(1)) = True Then
                If IsNumeric(otxt_array(1)) = True Then
                    'txt_info += "Referencia: " & Mid(linea, 8, 12).Trim & " Cantidad: " & Mid(linea, 100, 20).Trim _
                    '& " Ref Empaque: " & Mid(linea, 75, 5).Trim & " Descripcion: " & Mid(linea, 29, 41).Trim & vbCrLf

                    referencia_1 = Mid(linea, 8, 12).Trim
                    referencia_2 = Mid(linea, 75, 5).Trim
                    descripcion_producto = Mid(linea, 29, 41).Trim
                    cantidad_producto = Mid(linea, 100, 20).Trim

                    If bloqueo_actualizacion = "N" Then

                        If verror = "N" Then
                            grabar_detalle_rm()
                        End If
                    End If
                End If
            End If
        End While

        ' Cerrar el fichero
        lector.Close()

        'muestro las remisiones sin agignar a un despacho
        cargar_dg_remisiones_sin_asignar()

        Try
            'My.Computer.FileSystem.DeleteFile("C:\dsfc\remisiones.txt")
        Catch ex As Exception

        End Try
        Try
            Dim ruta As String = "C:\dsfc\remisiones.txt"
            'Dim escritor As StreamWriter
            'escritor = File.AppendText(ruta)
            'escritor.Write(txt_info)
            'escritor.Flush()
            'escritor.Close()
            MessageBox.Show("Escritura realizada con éxito." & vbCrLf _
                            & "Total Remisiones cargadas: " & contador_exitos & vbCrLf _
                            & "Total remisiones rechazadas: " & contador_fallas)
        Catch ex As Exception
            MessageBox.Show("Escritura realizada incorrectamente")
        End Try
    End Sub

    Private Sub grabar_encabezado_rm()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)
        'Creamos la remision en la bd
        csql = "insert into " + database.obtener_esquema + ".tb0850_remisiones_cguno_encabezado" _
            & " (" _
            & " f0850_rm, f0850_id_cia, f0850_codigo_tercero, f0850_dig_ver," _
            & " f0850_fecha_documento, f0850_razon_social," _
            & " f0850_ciudad_destino, f0850_direccion_destino," _
            & " f0850_codigo_vendedor, f0850_nombre_vendedor," _
            & " f0850_usuario_crear," _
            & " f0850_usuario_modificar, f0850_ofi" _
            & ") values" _
            & " (" _
            & " @f0850_rm, @f0850_id_cia, @f0850_codigo_tercero, @f0850_dig_ver," _
            & " @f0850_fecha_documento, @f0850_razon_social," _
            & " @f0850_ciudad_destino, @f0850_direccion_destino," _
            & " @f0850_codigo_vendedor, @f0850_nombre_vendedor," _
            & " @f0850_usuario_crear," _
            & " @f0850_usuario_modificar, @f0850_ofi" _
            & ")" _
            & " RETURNING f0850_id_rm"


        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0850_rm", NpgsqlDbType.Varchar).Value = numero_rm
        ocmd.Parameters.Add("f0850_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0850_codigo_tercero", NpgsqlDbType.Varchar).Value = codigo_cliente
        ocmd.Parameters.Add("f0850_dig_ver", NpgsqlDbType.Varchar).Value = digito_verificacion
        ocmd.Parameters.Add("f0850_fecha_documento", NpgsqlDbType.Timestamp).Value = fecha_documento_rm
        ocmd.Parameters.Add("f0850_razon_social", NpgsqlDbType.Varchar).Value = razon_social
        ocmd.Parameters.Add("f0850_ciudad_destino", NpgsqlDbType.Varchar).Value = ciudad_cliente
        ocmd.Parameters.Add("f0850_direccion_destino", NpgsqlDbType.Varchar).Value = direccion
        ocmd.Parameters.Add("f0850_codigo_vendedor", NpgsqlDbType.Varchar).Value = codigo_vendedor
        ocmd.Parameters.Add("f0850_nombre_vendedor", NpgsqlDbType.Varchar).Value = nombre_vendedor
        ocmd.Parameters.Add("f0850_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0850_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0850_ofi", NpgsqlDbType.Varchar).Value = ofiscal

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nueva falla! " + vbCrLf + ex.ToString + vbCrLf + csql)
        End Try
        Try
            id_encabezado = ocmd.ExecuteScalar()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al crear remision ! " + vbCrLf + ex.ToString)
        End Try

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub grabar_detalle_rm()
        'MsgBox("ENTRO")
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "insert into " + database.obtener_esquema + ".tb0851_remisiones_cguno_detalle" _
            & " (" _
            & " f0851_id_rm, f0851_rm, f0851_id_cia, f0851_referencia_1, f0851_referencia_2," _
            & " f0851_descripcion, f0851_cantidad," _
            & " f0851_usuario_crear," _
            & " f0851_usuario_modificar" _
            & ") values" _
            & " (" _
            & " @f0851_id_rm, @f0851_rm, @f0851_id_cia, @f0851_referencia_1, @f0851_referencia_2," _
            & " @f0851_descripcion, @f0851_cantidad," _
            & " @f0851_usuario_crear," _
            & " @f0851_usuario_modificar" _
            & ")"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0851_id_rm", NpgsqlDbType.Integer).Value = id_encabezado
        ocmd.Parameters.Add("f0851_rm", NpgsqlDbType.Varchar).Value = numero_rm
        ocmd.Parameters.Add("f0851_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0851_referencia_1", NpgsqlDbType.Varchar).Value = referencia_1
        ocmd.Parameters.Add("f0851_referencia_2", NpgsqlDbType.Varchar).Value = referencia_2
        ocmd.Parameters.Add("f0851_descripcion", NpgsqlDbType.Varchar).Value = descripcion_producto
        ocmd.Parameters.Add("f0851_cantidad", NpgsqlDbType.Numeric).Value = cantidad_producto
        ocmd.Parameters.Add("f0851_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0851_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! grabando tercero" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error grabando detalle rm" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Function verificar_que_rm_no_este_programada(ByVal id_rm As String)
        Dim rm_programada As String = "N"
        csql = "select * from " & database.obtener_esquema & ".tb0850_remisiones_cguno_encabezado" _
            & " where f0850_id_cia = '" & vg_id_cia & "' and " & "f0850_rm = '" & id_rm & "' and f0850_anulado = 'N'" _
            & " and f0850_id_despacho is not null"
        Dim otb_rm As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_rm.Rows.Count > 0 Then
            rm_programada = "S"
        End If
        Return rm_programada
    End Function

    Private Function verificar_registro_rm(ByVal id_rm As String, ByVal ooficial As String)
        Dim rm_existe As String = "N"
        csql = "select f0850_ofi from " & database.obtener_esquema & ".tb0850_remisiones_cguno_encabezado" _
            & " where f0850_id_cia = '" & vg_id_cia & "' and " & "f0850_rm = '" & id_rm & "' and f0850_anulado = 'N'" _
            & " and f0850_ofi = '" & ooficial & "'"
        Dim otb_rm As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_rm.Rows.Count > 0 Then
            rm_existe = "S"
        End If
        Return rm_existe
    End Function

    Private Sub cargar_dg_remisiones_sin_asignar()
        cargar_otb_remisiones_sin_asignar()

        'Dim ocolum_sel As New DataColumn
        otb_remisiones_sin_despacho_asignado.Columns.Add("sel", Type.GetType("System.Boolean"))

        dg_remision_encabezado.DataSource = otb_remisiones_sin_despacho_asignado
        dg_remision_encabezado.AutoResizeColumns()
        dg_remision_encabezado.Columns("id_rm").ReadOnly = True 'dg_remision_encabezado.Columns("id").ReadOnly = True
        dg_remision_encabezado.Columns("rm").ReadOnly = True 'dg_remision_encabezado.Columns("remision").ReadOnly = True
        dg_remision_encabezado.Columns("digv").ReadOnly = True
        dg_remision_encabezado.Columns("digv").ReadOnly = True
        dg_remision_encabezado.Columns("cliente").ReadOnly = True
        dg_remision_encabezado.Columns("ciudad").ReadOnly = True
        dg_remision_encabezado.Columns("direccion").ReadOnly = True
        dg_remision_encabezado.Columns("fecha").ReadOnly = True
        dg_remision_encabezado.Columns("nit").ReadOnly = True
        dg_remision_encabezado.Columns("cvendedor").ReadOnly = True


        'Dim ocolum As New DataGridViewCheckBoxColumn
        'ocolum.HeaderText = "Despachar"
        'ocolum.Name = "dgocell_crear_despacho"
        'dg_remision_encabezado.Columns.Add(ocolum)

        lb_total_rms.Text = dg_remision_encabezado.Rows.Count & "   Registros."
    End Sub

    Private Sub cargar_otb_remisiones_sin_asignar()
        dg_remision_encabezado.Columns.Clear()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-03", vg_id_cia)
        csql = Replace(csql, "$df001$", database.obtener_esquema)
        csql = Replace(csql, "$001$", vg_id_cia)
        otb_remisiones_sin_despacho_asignado = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub

    Private Function formatear_fecha(ByVal txt As String)
        Dim n_fecha As String = txt
        n_fecha = Replace(n_fecha, "-ENE-", "/01/")
        n_fecha = Replace(n_fecha, "-FEB-", "/02/")
        n_fecha = Replace(n_fecha, "-MAR-", "/03/")
        n_fecha = Replace(n_fecha, "-ABR-", "/04/")
        n_fecha = Replace(n_fecha, "-MAY-", "/05/")
        n_fecha = Replace(n_fecha, "-JUN-", "/06/")
        n_fecha = Replace(n_fecha, "-JUL-", "/07/")
        n_fecha = Replace(n_fecha, "-AGO-", "/08/")
        n_fecha = Replace(n_fecha, "-SEP-", "/09/")
        n_fecha = Replace(n_fecha, "-OCT-", "/10/")
        n_fecha = Replace(n_fecha, "-NOV-", "/11/")
        n_fecha = Replace(n_fecha, "-DIC-", "/12/")
        'MsgBox("Retorna: " & n_fecha)
        Return n_fecha
    End Function

    Private Sub bt_generar_despacho_Click(sender As Object, e As EventArgs) Handles bt_generar_despacho.Click
        Dim fecha_act As Date = comunes.g_fechahora
        'VALIDO SI FECHA DE MOVIMIENTO ESTA HABILITADA
        Dim fechavalidada As String()
        fechavalidada = cl_utilidades_gestion_compras.ValidarFechaMovimiento(fecha_act, vg_id_cia)
        If fechavalidada(1) = "N" Then
            MsgBox(fechavalidada(2), MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Identificamos la bodega de la que saldra el producto terminado

        Dim csql As String
        csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
            & " from " & database.obtener_esquema & ".tb0005_bodegas" _
            & " where f0005_anulado = 'N' AND f0005_uso = 'PT'"
        Dim otb_bodegas As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim ODisplayMember As String = "f0005_descripcion_bodega"
        Dim OValueMember As String = "f0005_id_bodega"
        id_bodega = comunes.formulario_parametro_texto("", "Bodega", False, otb_bodegas, ODisplayMember, OValueMember)
        If id_bodega.Trim = "" Then
            Exit Sub
        End If

        'Cargamos la datatable con todos los items
        otb_items = cl_utilidades_gestion_compras.suministrar_tabla_items(vg_id_cia)

        Dim otb_rm_sel As New DataTable

        ' Create four typed columns in the DataTable.
        otb_rm_sel.Columns.Add("id_rm", GetType(Integer))
        otb_rm_sel.Columns.Add("rm", GetType(String))
        otb_rm_sel.Columns.Add("nit", GetType(String))
        otb_rm_sel.Columns.Add("digv", GetType(String))
        otb_rm_sel.Columns.Add("cliente", GetType(String))
        otb_rm_sel.Columns.Add("ciudad", GetType(String))
        otb_rm_sel.Columns.Add("direccion", GetType(String))
        otb_rm_sel.Columns.Add("cvendedor", GetType(String))

        Dim oselected As String 'para identificar cuales regsitrso fueron selecccionados por el checkbox
        For Each orow As DataGridViewRow In dg_remision_encabezado.Rows
            oselected = orow.Cells("sel").Value.ToString
            If oselected = "True" Then
                otb_rm_sel.Rows.Add(orow.Cells("id_rm").Value,
                                    orow.Cells("rm").Value,
                                    orow.Cells("nit").Value,
                                    orow.Cells("digv").Value,
                                    orow.Cells("cliente").Value,
                                    orow.Cells("ciudad").Value,
                                    orow.Cells("direccion").Value,
                                    orow.Cells("cvendedor").Value)
            End If
        Next

        'validamos que se hallan seleccionado tadas las remisiones del mismo cliente
        Dim remision As String = ""
        Dim id_encabezado As Integer
        Dim cliente As String = ""
        Dim ciudad As String = ""
        Dim direccion As String = ""
        Dim nit As String = ""
        Dim digv As String = ""
        Dim cvendedor As String = ""
        Dim id_tercero_vendedor As String = ""
        Dim cant_sel As Integer
        Dim cant_pend As Integer
        Dim id_ciudad As String = ""
        Dim generar_despacho As String = "S"
        Dim id_despacho As String = ""
        Dim falla_inventario As String = "N"
        Dim otx_inventario_insuficiente As String = "Inventario insuficiente para el producto:" & vbCrLf
        Dim desc_inv As String = "S" 'Para saber si controlar inventarios de PT.
        desc_inv = comunes.suministrar_valor_variable_configuracion("CONFIG-0300-03", vg_id_cia)
        For Each orow As DataRow In otb_rm_sel.Rows
            generar_despacho = "S"
            verror = "N"
            remision = orow("rm")
            id_encabezado = orow("id_rm")
            cliente = orow("cliente")
            nit = orow("nit")
            digv = orow("digv")
            ciudad = orow("ciudad")
            direccion = orow("direccion")
            cvendedor = orow("cvendedor")
            'Verificamos seleccion completa
            cant_sel = buscar_cantidad_registros_mismo_cliente(otb_rm_sel, cliente, ciudad, direccion)
            cant_pend = buscar_cantidad_registros_mismo_cliente(otb_remisiones_sin_despacho_asignado, cliente, ciudad, direccion)
            If cant_sel <> cant_pend Then
                MsgBox("No estan todas las remisiones seleccionadas para:" & vbCrLf _
                       & "Cliente     : " & cliente & vbCrLf _
                       & "Ciudad     : " & ciudad & vbCrLf _
                       & "Direccion : " & direccion & vbCrLf _
                       & cant_sel & " seleccionadas de " & cant_pend & " pendientes." & vbCrLf & vbCrLf _
                       & "NO SE GENERA ORDEN DE CARGUE.", MsgBoxStyle.Exclamation, "Info")
                generar_despacho = "N"
                verror = "S"
            End If
            'verifico que todos los items estan identificados
            falla_items = "N"
            identificar_item_remision(id_encabezado)
            If falla_items = "S" Then
                generar_despacho = "N"
                Dim tx As String = "No se cargo por falla en items la REMISION: " & remision & vbCrLf & vbCrLf
                MsgBox(tx & txt_falla_item, MsgBoxStyle.Information, "Info")
                verror = "S"
            End If
            'Identifico el vendedor
            id_tercero_vendedor = buscar_id_vendedor(cvendedor)
            If id_tercero_vendedor = "ND" Then
                generar_despacho = "N"
                MsgBox("No se cargo la REMISION: " & remision & vbCrLf & vbCrLf & "Vendedor no identificado", MsgBoxStyle.Exclamation, "Info")
                verror = "S"
            End If
            If generar_despacho = "S" Then
                'Dim otb_list_clientes As DataTable = otb_rm_sel.DefaultView.ToTable(True, "cliente")
                'MsgBox(otb_list_clientes.Rows.Count)

                'Verifico que la rm no este programada, dos usuarios con el mismo form abierto....
                Dim rm_programada As String = "N"
                rm_programada = verificar_que_rm_no_este_programada(id_encabezado)
                If rm_programada = "N" Then
                    'Descontamos del inventario los productos remisionados
                    'Verifico si se debe descontar de inventario cuando se remisiona.
                    If desc_inv = "S" Then
                        'verifico inventario para cada producto remisionado.
                        csql = "select * from " & database.obtener_esquema & ".tb0851_remisiones_cguno_detalle" _
                            & " where f0851_id_rm = '" & id_encabezado & "'"
                        Dim otb_productos_rm As DataTable
                        otb_productos_rm = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                        'Primero valido existencias
                        Dim inventario As Decimal = 0
                        Dim cant_desp As Decimal = 0
                        For Each orow_prod As DataRow In otb_productos_rm.Rows
                            inventario = cl_utilidades_gestion_compras.suministrar_inventario_item_bodega(id_bodega, orow_prod("f0851_id_item"))
                            cant_desp = orow_prod("f0851_cantidad")
                            If inventario - cant_desp < 0 Then
                                Dim orow_item As DataRow()
                                orow_item = otb_items.Select("f0300_id_item = '" & orow_prod("f0851_id_item") & "'", "")
                                otx_inventario_insuficiente += orow_prod("f0851_rm") & ": " & "(" _
                                    & orow_prod("f0851_id_item") & ") - " & orow_item(0)("descripcion_larga") _
                                    & " Inv: " & inventario.ToString("F2") & " Req: " & cant_desp.ToString("F2") & vbCrLf
                                falla_inventario = "S"
                            End If
                        Next
                        If falla_inventario = "S" Then
                            MsgBox(otx_inventario_insuficiente, MsgBoxStyle.Exclamation, "Info")
                        Else
                            'Creo el nuevo documento
                            Dim ofecha As DateTime = comunes.g_fechahora
                            Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(5, vg_id_cia)
                            Dim cod_documento As String = "RMS-" & consecutivo.ToString.PadLeft(8, "0")
                            Dim docto_origen As String = "f0850_id_rm-" & id_encabezado
                            cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, id_bodega, 5, ofecha, vg_usuario_autoriza, vg_id_cia,
                                                                                                docto_origen, remision)
                            Dim ocont As Integer = 1
                            For Each orow_prod As DataRow In otb_productos_rm.Rows
                                'descargo los productos de inventario
                                cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario(cod_documento, id_bodega, ocont,
                                                                                                 orow_prod("f0851_id_item"), 0,
                                                                                                 orow_prod("f0851_cantidad"),
                                                                                                 ofecha, vg_usuario_autoriza,
                                                                                                 vg_id_cia)
                                ocont += 1
                            Next
                        End If
                    End If

                    If falla_inventario = "N" Then
                        'Identificamos el tercero
                        gestionar_identificacion_cliente(cliente, nit, digv, ciudad, direccion)
                        'Asignamos un despacho
                        id_despacho = gestionar_despacho_para_remision(id_tercero, id_tercero_vendedor, id_bodega)
                        'Asignamos la Remision al despacho
                        asignar_despacho_y_tercero_a_remision(id_despacho, id_encabezado, id_tercero)
                        'identificamos el total de unidades remisionadas
                        Dim tot_unid_rem As Decimal
                        tot_unid_rem = consultar_total_unidades_remisionadas(id_despacho)
                        'actualizamos en el despacho el total de cajas remisionadas
                        actualizar_tot_unid_remisionadas_despacho(id_despacho, tot_unid_rem)
                    End If
                End If
            End If
        Next
        If verror = "N" Then
            If falla_inventario = "S" Then
                MsgBox("Falla en alguna(s) REMISIONES por inventario insuficiente!!!", MsgBoxStyle.Information, "Info")
            Else
                MsgBox("Remisiones programadas", MsgBoxStyle.Information, "Info")
            End If
            Dispose()
        End If
    End Sub

    Private Function consultar_total_unidades_remisionadas(ByVal id_despacho As Integer)
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-19", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        Dim otb_tot_unid_rem As DataTable
        otb_tot_unid_rem = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim tot_unid_rem As Decimal = 0
        If otb_tot_unid_rem.Rows.Count <> 0 Then
            For Each orow As DataRow In otb_tot_unid_rem.Rows
                tot_unid_rem = orow("ped")
            Next
        End If
        Return tot_unid_rem
    End Function

    Private Sub actualizar_tot_unid_remisionadas_despacho(ByVal id_despacho As Integer, ByVal unid_rem As Decimal)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set" _
                    & " f0800_tot_cajas_aprobadas = @f0800_tot_cajas_aprobadas" _
                    & " where f0800_id_despacho = @f0800_id_despacho"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("f0800_tot_cajas_aprobadas", NpgsqlDbType.Numeric).Value = unid_rem
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! asignar tercero a remision" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al asignar tercero a remision" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        Dim oselected As String 'para identificar cuales regsitrso fueron selecccionados por el checkbox
        Dim id_rm As Integer
        For Each orow As DataGridViewRow In dg_remision_encabezado.Rows
            oselected = orow.Cells("sel").Value.ToString
            If oselected = "True" Then
                id_rm = orow.Cells("id_rm").Value
                'Verifico que la rm no este programada, dos usuarios con el mismo form abierto....
                Dim rm_programada As String = "N"
                rm_programada = verificar_que_rm_no_este_programada(id_encabezado)
                If rm_programada = "N" Then
                    anular_remision(id_rm)
                End If
            End If
        Next
        If verror = "N" Then
            MsgBox("Remisiones Anuladas", MsgBoxStyle.Information, "Info")
            Dispose()
        End If
    End Sub

    Private Sub anular_remision(ByVal id_rm As Integer)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0850_remisiones_cguno_encabezado set" _
                    & " f0850_anulado = 'S'," _
                    & " f0850_usuario_anular = @f0850_usuario_anular," _
                    & " f0850_fm = @f0850_fm" _
                    & " where f0850_id_rm = @f0850_id_rm and f0850_anulado = 'N'"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0850_id_rm", NpgsqlDbType.Integer).Value = id_rm
        ocmd.Parameters.Add("f0850_usuario_anular", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0850_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! asignar tercero a remision" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al asignar tercero a remision" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    'Buscamos en el listado de pendientes despachos al mismo cliente sin identificar
    Private Function buscar_cantidad_registros_mismo_cliente(ByVal otb As DataTable,
                                                             ByVal cliente As String,
                                                             ByVal ciudad As String,
                                                             ByVal direccion As String)
        Dim cantidad As Integer
        Dim apariciones As DataRow()
        apariciones = otb.Select("cliente = '" & cliente & "' and" _
                                & " ciudad = '" & ciudad & "' and" _
                                & " direccion = '" & direccion & "'")
        cantidad = apariciones.Count
        Return cantidad
    End Function

    Private Sub validar_equivalencia_ciudad(ByVal tx_razon_social As String,
                                                 ByVal tx_direccion As String, ByVal tx_ciudad As String)
        csql = "Select f0052_codigo_ciudad from " _
            & database.obtener_esquema & ".tb0052_ciudades" _
            & " Where f0052_ciudad = '" & tx_ciudad & "' or f0052_ciudad_cg = '" & tx_ciudad & "'"
        Dim otb_reg As DataTable
        otb_reg = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Dim resultado As String = ""
        If otb_reg.Rows.Count = 1 Then
            For Each orow As DataRow In otb_reg.Rows
                id_ciudad = orow("f0052_codigo_ciudad")
            Next
        Else
            id_ciudad = "ND"
        End If

        If id_ciudad = "ND" Then
            MsgBox("Cliente: " & tx_razon_social & vbCrLf _
                   & "Direccion: " & tx_direccion & vbCrLf _
                   & "Ciudad sin identificar equivalencia." & vbCrLf _
                   & "Ciudad     : " & tx_ciudad, MsgBoxStyle.Exclamation, "Info")
            'Obligamos a crear equivalencia
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos

            'Aqui obtengo el id_ciudad.
            Dim oform_equivalencia_ciudad As New camocontrol.fm_0052_equivalencias_ciudades_cg
            'oform_grilla_programacion.ods_hijo = ods
            oform_equivalencia_ciudad.vf_oform_padre = Me
            oform_equivalencia_ciudad.vg_id_cia = vg_id_cia
            oform_equivalencia_ciudad.vg_usuario_autoriza = vg_usuario_autoriza
            oform_equivalencia_ciudad.tx_ciudad_cg.Text = tx_ciudad
            oform_equivalencia_ciudad.ShowDialog()
            If id_ciudad = "ND" Then
                MsgBox("No esta la equivalencias de ciudad definida:" & vbCrLf & vbCrLf _
                   & "NO SE GENERA ORDEN DE CARGUE.", MsgBoxStyle.Exclamation, "Info")
                verror = "S"
            End If
        End If
        'MsgBox(id_ciudad)
    End Sub

    Private Function buscar_id_vendedor(ByVal cod_vendedor As String)
        Dim otb_vendedor As DataTable
        Dim id_vendedor As String = "ND"
        csql = "select f0200_id_tercero from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id = '" & cod_vendedor & "' and f0200_id_cia = '" & vg_id_cia & "'"
        otb_vendedor = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_vendedor.Rows
            id_vendedor = orow("f0200_id_tercero")
        Next
        Return id_vendedor
    End Function

    Private Sub gestionar_identificacion_cliente(ByVal razon_social As String, ByVal nit As String,
                                                 ByVal dig_ver As String, ByVal ciudad As String, ByVal direccion As String)

        csql = "select * from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id = '" & nit & "'"
        Dim otb_todas_sucursales As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Primero identifico si hay una sola sucursal
        Dim numero_sucursales As Integer
        numero_sucursales = otb_todas_sucursales.Rows.Count
        Dim identificado As String = "N"
        verror = "N"

        Select Case numero_sucursales
            Case 0
                'El cliente no existe.
                If verror = "N" Then
                    validar_equivalencia_ciudad(razon_social, direccion, ciudad) 'Asigna el id_ciudad
                    crear_nuevo_tercero(nit, dig_ver, razon_social, direccion, id_ciudad)
                    If verror = "N" Then
                        id_tercero = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0200_id_tercero",
                                                                                                   "f0200_usuario_crear",
                                                                                                   vg_usuario_autoriza,
                                                                                                   "tb0200_terceros").ToString.PadLeft(8, "0")
                        actualizar_sucursal_tercero(id_tercero)
                        direccion_despacho = direccion
                        ciudad_despacho = id_ciudad
                        identificado = "S"
                    End If
                End If
            Case Is > 0
                'verificamos si existe la direccion
                Dim orows_sucursales As DataRow()
                'Buscamos igual direccion
                orows_sucursales = otb_todas_sucursales.Select("f0200_direccion_residencia = '" & direccion & "'")
                For Each orow As DataRow In orows_sucursales
                    id_tercero = orow("f0200_id_tercero")
                    direccion_despacho = orow("f0200_direccion_residencia")
                    ciudad_despacho = orow("f0200_ciudad_residencia")
                    If orow("f0200_ciudad_residencia").ToString = "" Then
                        validar_equivalencia_ciudad(razon_social, direccion, ciudad) 'Asigna el id_ciudad
                        'Actualizo el registro tercero
                        actualizar_tercero(id_tercero, direccion, razon_social, id_ciudad)
                    End If
                    identificado = "S"
                Next
                'Buscamos sucursal con direccion basia
                orows_sucursales = otb_todas_sucursales.Select("f0200_direccion_residencia = ''")
                For Each orow As DataRow In orows_sucursales
                    If identificado = "N" Then
                        id_tercero = orow("f0200_id_tercero")
                        direccion_despacho = orow("f0200_direccion_residencia")
                        ciudad_despacho = orow("f0200_ciudad_residencia")
                        validar_equivalencia_ciudad(razon_social, direccion, ciudad) 'Asigna el id_ciudad
                        'Actualizo el registro tercero
                        actualizar_tercero(id_tercero, direccion, razon_social, id_ciudad)
                        identificado = "S"
                    End If
                Next
                'Al no haber ni registro vacio ni direccion se crea un nuevo tercero.
                If identificado = "N" Then
                    validar_equivalencia_ciudad(razon_social, direccion, ciudad) 'Asigna el id_ciudad
                    crear_nuevo_tercero(nit, dig_ver, razon_social, direccion, id_ciudad)
                    If verror = "N" Then
                        id_tercero = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0200_id_tercero",
                                                                                                   "f0200_usuario_crear",
                                                                                                   vg_usuario_autoriza,
                                                                                                   "tb0200_terceros").ToString.PadLeft(8, "0")
                        actualizar_sucursal_tercero(id_tercero)
                        identificado = "S"
                    End If
                End If
        End Select
    End Sub

    Private Sub actualizar_tercero(ByVal id_tercero As String, ByVal direccion As String,
                                   razon_social As String, id_ciudad As String)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0200_terceros set" _
                    & " f0200_nombres = @f0200_nombres," _
                    & " f0200_ciudad_residencia = @f0200_ciudad_residencia," _
                    & " f0200_direccion_residencia = @f0200_direccion_residencia," _
                    & " f0200_fm = @f0200_fm," _
                    & " f0200_usuario_modificar = @f0200_usuario_modificar" _
                    & " where f0200_id_tercero = @f0200_id_tercero"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0200_ciudad_residencia", NpgsqlDbType.Varchar).Value = id_ciudad
        ocmd.Parameters.Add("f0200_direccion_residencia", NpgsqlDbType.Varchar).Value = direccion
        ocmd.Parameters.Add("f0200_nombres", NpgsqlDbType.Varchar).Value = razon_social
        ocmd.Parameters.Add("f0200_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0200_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar tercero" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error actualizando tercero" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub crear_nuevo_tercero(ByVal nit As String, ByVal dig_verific As String,
                                    ByVal razon_soc As String, ByVal direccion As String, ByVal id_ciudad As String)
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "insert into " + database.obtener_esquema + ".tb0200_terceros" _
            & " (" _
            & " f0200_id_cia, f0200_id_tercero, f0200_nombres," _
            & " f0200_ind_cliente, f0200_id, f0200_dig_ver_nit," _
            & " f0200_ciudad_residencia, f0200_direccion_residencia," _
            & " f0200_id_tipo_identificacion, f0200_usuario_crear," _
            & " f0200_usuario_modificar" _
            & ") values" _
            & " (" _
            & " @f0200_id_cia, @f0200_id_tercero, @f0200_nombres," _
            & " @f0200_ind_cliente, @f0200_id, @f0200_dig_ver_nit," _
            & " @f0200_ciudad_residencia, @f0200_direccion_residencia," _
            & " @f0200_id_tipo_identificacion, @f0200_usuario_crear," _
            & " @f0200_usuario_modificar" _
            & ")"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = cl_utilidades_datatables.obtener_nuevo_consecutivo_tablas("f0200_id_tercero", "tb0200_terceros").ToString.PadLeft(8, "0")
        ocmd.Parameters.Add("f0200_id", NpgsqlDbType.Varchar).Value = nit
        ocmd.Parameters.Add("f0200_dig_ver_nit", NpgsqlDbType.Varchar).Value = dig_verific
        ocmd.Parameters.Add("f0200_ciudad_residencia", NpgsqlDbType.Varchar).Value = id_ciudad
        ocmd.Parameters.Add("f0200_direccion_residencia", NpgsqlDbType.Varchar).Value = direccion
        ocmd.Parameters.Add("f0200_id_tipo_identificacion", NpgsqlDbType.Varchar).Value = "NIT"
        ocmd.Parameters.Add("f0200_nombres", NpgsqlDbType.Varchar).Value = razon_soc
        ocmd.Parameters.Add("f0200_ind_cliente", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("f0200_usuario_modificar", NpgsqlDbType.Varchar).Value = "00000001"
        ocmd.Parameters.Add("f0200_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! grabando tercero" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error grabando nuevo tercero" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub actualizar_sucursal_tercero(ByVal id_tercero As String)
        'cuando se crea un nuevo tercero se debe asignar un unico codigo de sucursal debido a al constraint de unicidad

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0200_terceros set" _
                    & " f0200_id_sucursal = @f0200_id_sucursal" _
                    & " where f0200_id_tercero = @f0200_id_tercero"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0200_id_sucursal", NpgsqlDbType.Integer).Value = id_tercero

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar codigo sucursal" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error actualizando codigo sucursal" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub identificar_item_remision(ByVal id_rem As Integer)
        Dim otb_items_rm As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0851_remisiones_cguno_detalle" _
            & " where f0851_id_rm = '" & id_rem & "'"
        otb_items_rm = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim id_item As Integer
        Dim id_rm_det As Integer
        Dim producto As String
        Dim ref1 As String = ""
        Dim ref2 As String = ""
        txt_falla_item = ""
        For Each orow As DataRow In otb_items_rm.Rows
            'Primero identifico el id_item
            id_item = 0
            id_rm_det = orow("f0851_id_rm_det")
            producto = orow("f0851_descripcion")
            ref1 = orow("f0851_referencia_1")
            ref2 = orow("f0851_referencia_2")
            Dim otb_item_identificado() As DataRow
            'MsgBox(otb_items.Rows.Count)
            otb_item_identificado = otb_items.Select("f0300_referencia = '" & ref1 & "' and f0300_referencia_empaque = '" &
                                                     ref2 & "'")
            If otb_item_identificado.Length = 0 Then
                falla_items = "S"
                txt_falla_item = "No hay creado un Item en CAMO para:" & vbCrLf & producto & vbCrLf _
                    & " ( " & ref1 & " ) ( " & ref2 & " ) " & vbCrLf
            Else
                If otb_item_identificado.Length = 1 Then
                    For Each orow2 As DataRow In otb_item_identificado
                        id_item = orow2("f0300_id_item")
                        actualizar_item_de_remision(id_rm_det, id_item)
                    Next
                Else
                    falla_items = "S"
                    txt_falla_item = "Hay multiples items que coinciden con las referencias:" _
                           & vbCrLf & ref1 & vbCrLf & ref2 & vbCrLf
                End If
            End If
        Next
    End Sub

    Private Sub actualizar_item_de_remision(ByVal id_rm_det As String, ByVal id_item As Integer)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0851_remisiones_cguno_detalle set" _
                    & " f0851_id_item = '" & id_item & "'" _
                    & " where f0851_id_rm_det = '" & id_rm_det & "'"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        'ocmd.Parameters.Clear()
        'ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        'ocmd.Parameters.Add("f0200_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar Item" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error actualizando Item" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Function grabar_nuevo_despacho(ByVal id_tercero As String, ByVal id_vendedor As String, ByVal direccion_despacho As String, ByVal ciudad_despacho As String, ByVal id_bodega_despacho As String)
        Dim oid_despacho As Integer = 0
        'los datos de la ciudad de destino ya los obtuve cuando indetifique el tercero en el sub gestionar_identificacion_cliente.

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0800_despachos_comercial" _
                & " (f0800_id_cia," _
                & " f0800_cliente, f0800_vendedor," _
                & " f0800_id_ciudad_destino, f0800_direccion_destino," _
                & " f0800_usuario_modificar, f0800_usuario_crear, f0800_fm, f0800_id_bodega)" _
                & " VALUES" _
                & " (@f0800_id_cia," _
                & " @f0800_cliente, @f0800_vendedor," _
                & " @f0800_id_ciudad_destino, @f0800_direccion_destino," _
                & " @f0800_usuario_modificar, @f0800_usuario_crear, @f0800_fm, @f0800_id_bodega)" _
                & " RETURNING f0800_id_despacho;"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0800_cliente", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("@f0800_vendedor", NpgsqlDbType.Varchar).Value = id_vendedor
        ocmd.Parameters.Add("@f0800_id_ciudad_destino", NpgsqlDbType.Varchar).Value = ciudad_despacho
        ocmd.Parameters.Add("@f0800_direccion_destino", NpgsqlDbType.Varchar).Value = direccion_despacho
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_id_bodega", NpgsqlDbType.Integer).Value = id_bodega_despacho

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nuevo despacho! " + vbCrLf + ex.ToString + vbCrLf + csql)
        End Try
        If verror = "N" Then
            Try
                'Compila el comando en la Base de datos.
                ocmd.Prepare()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Compilar comando nueva falla! " + vbCrLf + ex.ToString + vbCrLf + csql)
            End Try
            Try
                oid_despacho = ocmd.ExecuteScalar()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar nuevo despacho! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        Return oid_despacho
    End Function

    Private Function gestionar_despacho_para_remision(ByVal id_tercero As String, ByVal id_vendedor As String, ByVal id_bodega As String)
        csql = "select * from " & database.obtener_esquema & ".fnc_800_01_gestionar_despacho_pt_desde_rm(" _
        & "'" & id_tercero & "'," & id_bodega & ")"
        Dim otb As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim id_despacho As Integer = otb.Rows.Item(0).Field(Of Integer)(0)

        'MsgBox(id_despacho)
        If id_despacho = 0 Then
            id_despacho = grabar_nuevo_despacho(id_tercero, id_vendedor, direccion_despacho, ciudad_despacho, id_bodega)
        End If
        Return id_despacho
    End Function

    Private Sub asignar_despacho_y_tercero_a_remision(ByVal id_despacho As Integer, ByVal id_rm As Integer,
                                                      ByVal id_tercero As String)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0850_remisiones_cguno_encabezado set" _
                    & " f0850_id_despacho = @f0850_id_despacho," _
                    & " f0850_id_tercero = @f0850_id_tercero," _
                    & " f0850_usuario_asigna_despacho = @f0850_usuario_asigna_despacho," _
                    & " f0850_fecha_asignacion_despacho = @f0850_fecha_asignacion_despacho" _
                    & " where f0850_id_rm = @f0850_id_rm and f0850_anulado = 'N'"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0850_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("f0850_id_rm", NpgsqlDbType.Integer).Value = id_rm
        ocmd.Parameters.Add("f0850_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0850_usuario_asigna_despacho", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0850_fecha_asignacion_despacho", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! asignar tercero a remision" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al asignar tercero a remision" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub bt_exportar_archivo_Click(sender As Object, e As EventArgs) Handles bt_exportar_archivo.Click
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-04", vg_id_cia)
        ocmd.CommandText = csql

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar plano" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error actualizando plano" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        If verror = "N" Then
            MsgBox("Datos exportados", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub tx_scaner_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_scaner.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            lb_cuenta.Text = lb_cuenta.Text + 1
            tx_scaner.Text = ""
        End If
    End Sub

    Private Sub bt_cargar_traslados_Click(sender As Object, e As EventArgs) Handles bt_cargar_traslados.Click
        'MsgBox("En desarrollo.", MsgBoxStyle.Information, "CAMO")
        'Cargamos la datatable con todos los items
        csql = "select * from " & database.obtener_esquema & ".tb0300_items"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        Dim openFileDialog1 As New OpenFileDialog()
        Dim path_file As String = ""

        'openFileDialog1.InitialDirectory = "e:\"
        openFileDialog1.Filter = "csv files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*" 'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path_file = openFileDialog1.FileName
            'comunes.mostrar_archivo_texto(path_file, "")
        Else
            Exit Sub
        End If

        Dim lector As New IO.StreamReader(path_file, System.Text.Encoding.UTF7)
        ' Leer el contenido mientras no se llegue al final

        Dim txt_info As String = ""
        Dim contador_exitos As Integer = 0
        Dim contador_fallas As Integer = 0
        Dim bloqueo_actualizacion As String = "N"
        Dim pagina_extra As String = "N"
        Dim conteo_pagina_extra As Integer = 0

        While lector.Peek() <> -1
            Dim linea As String = Replace(lector.ReadLine(), "\'d1", "Ñ")
            ' Si no está vacía, añadirla al control
            ' Si está vacía, continuar el bucle
            If String.IsNullOrEmpty(linea) Then
                Continue While
            End If
            'No fiscal  
            ofiscal = "1"
            'If InStr(linea, "NIT.: 11111111-6") <> 0 Then
            'ofiscal = "N"
            'End If
            'If InStr(linea, "NIT.: 805027332-8") <> 0 Then
            'ofiscal = "S"
            'End If
            Dim txt As String = ""
            If IsNumeric(Mid(linea, 6, 8)) = True And InStr(linea, "**  ANULADO  **") = 0 Then
                'txt += "Factura:" & Mid(linea, 6, 8) & "|" & vbCrLf
                'txt += "Fecha factura:" & Mid(linea, 25, 11) & "|" & vbCrLf
                'txt += "Subtotal Factura:" & Mid(linea, 71, 15) & "|" & vbCrLf
                'txt += "Descuento:" & Mid(linea, 84, 15) & "|" & vbCrLf
                'txt += "IVA factura:" & Mid(linea, 96, 15) & "|" & vbCrLf
                'txt += "Total Factura:" & Mid(linea, 109, 13) & "|" & vbCrLf
                'MsgBox(txt)
                num_factura = Mid(linea, 6, 8).Trim
                tx_fecha_factura = Mid(linea, 25, 11).Trim
                subtotal_factura = CDec(Mid(linea, 72, 15).Trim)
                descuento_factura = CDec(Mid(linea, 85, 14).Trim)
                iva_factura = CDec(Mid(linea, 97, 14).Trim)
                total_factura = CDec(Mid(linea, 109, 13).Trim)
                factura_anulada_cg = "N"
            End If
            If InStr(linea, "**  ANULADO  **") <> 0 Then
                'txt += "Factura Anulada:" & Mid(linea, 6, 8) & "|" & vbCrLf
                'MsgBox(txt)
                num_factura = Mid(linea, 6, 8).Trim
                remision_factura = ""
                tx_fecha_factura = ""
                subtotal_factura = 0
                descuento_factura = 0
                iva_factura = 0
                total_factura = 0
                factura_anulada_cg = "S"
                grabar_encabezado_factura()
            End If


            'Remision
            If InStr(linea, "RM-") <> 0 Then
                txt += "Remision:" & Mid(linea, 6, 14) & "|" & vbCrLf
                'MsgBox(txt)
                remision_factura = Mid(linea, 6, 14).Trim
                grabar_encabezado_factura()
                id_factura = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0852_id_factura",
                                                                                          "f0852_usuario_crear",
                                                                                          vg_usuario_autoriza,
                                                                                          "tb0852_facturas_cguno_encabezado")
            End If

            'Referencia producto
            Dim otxt_array() As String = Split(Mid(linea, 6, 7).Trim, "-")
            If otxt_array.Length = 2 Then
                If IsNumeric(otxt_array(0)) = True And IsNumeric(otxt_array(1)) = True Then
                    'txt += "Referencia:" & Mid(linea, 6, 7) & "|" & vbCrLf
                    'txt += "Producto:" & Mid(linea, 13, 35) & "|" & vbCrLf
                    'txt += "Cantidad:" & Mid(linea, 57, 9) & "|" & vbCrLf
                    'txt += "U-med:" & Mid(linea, 67, 7) & "|" & vbCrLf
                    'txt += "Subtotal producto:" & Mid(linea, 73, 14) & "|" & vbCrLf
                    'txt += "Descuento producto:" & Mid(linea, 85, 14) & "|" & vbCrLf
                    'txt += "IVA producto:" & Mid(linea, 97, 13) & "|" & vbCrLf
                    'txt += "Total producto:" & Mid(linea, 109, 17) & "|" & vbCrLf
                    'MsgBox(txt)
                    referencia_1 = Mid(linea, 6, 7).Trim
                    referencia_2 = Mid(linea, 67, 7).Trim
                    descripcion_producto = Mid(linea, 13, 35).Trim
                    cantidad_producto = CDec(Mid(linea, 57, 9).Trim)
                    subtotal_producto = CDec(Mid(linea, 73, 14).Trim)
                    descuento_producto = CDec(Mid(linea, 85, 14).Trim)
                    iva_producto = CDec(Mid(linea, 97, 13).Trim)
                    total_producto = CDec(Mid(linea, 110, 13).Trim)


                    'busco el item del producto
                    Dim otb_item_identificado() As DataRow
                    'MsgBox(otb_items.Rows.Count)
                    otb_item_identificado = otb_items.Select("f0300_referencia = '" & referencia_1 & "' and f0300_referencia_empaque = '" &
                                                             referencia_2 & "'")
                    falla_items = "N"
                    If otb_item_identificado.Length = 0 Then
                        falla_items = "S"
                        txt_falla_item = "No hay creado un Item en CAMO para:" & vbCrLf & descripcion_producto & vbCrLf _
                            & " ( " & referencia_1 & " ) ( " & referencia_2 & " ) " & vbCrLf
                    Else
                        If otb_item_identificado.Length = 1 Then
                            For Each orow2 As DataRow In otb_item_identificado
                                id_item_producto = orow2("f0300_id_item")
                            Next
                        Else
                            falla_items = "S"
                            txt_falla_item = "Hay multiples items que coinciden con las referencias:" _
                                   & vbCrLf & referencia_1 & vbCrLf & referencia_2 & vbCrLf
                        End If
                    End If
                    If falla_items = "S" Then
                        'MsgBox(txt_falla_item, MsgBoxStyle.Exclamation, "Info")
                        id_item_producto = 0
                    End If
                    grabar_detalle_factura()
                End If
            End If
        End While
        ' Cerrar el fichero
        lector.Close()
        MsgBox("hola")
    End Sub

    Private Sub grabar_encabezado_factura()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)
        'Creamos la remision en la bd
        csql = "insert into " + database.obtener_esquema + ".tb0852_facturas_cguno_encabezado" _
            & " (" _
            & " f0852_factura, f0852_id_cia, f0852_fecha_documento, f0852_remision, f0852_subtotal_factura," _
            & " f0852_descuento_factura, f0852_iva_factura," _
            & " f0852_total_factura, f0852_ind_fiscal, f0852_anulada_cg," _
            & " f0852_usuario_crear," _
            & " f0852_usuario_modificar" _
            & ") values" _
            & " (" _
            & " @f0852_factura, @f0852_id_cia, @f0852_fecha_documento, @f0852_remision, @f0852_subtotal_factura," _
            & " @f0852_descuento_factura, @f0852_iva_factura," _
            & " @f0852_total_factura, @f0852_ind_fiscal, @f0852_anulada_cg," _
            & " @f0852_usuario_crear," _
            & " @f0852_usuario_modificar" _
            & ")"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0852_factura", NpgsqlDbType.Varchar).Value = num_factura
        ocmd.Parameters.Add("f0852_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0852_fecha_documento", NpgsqlDbType.Varchar).Value = tx_fecha_factura
        ocmd.Parameters.Add("f0852_remision", NpgsqlDbType.Varchar).Value = remision_factura
        ocmd.Parameters.Add("f0852_subtotal_factura", NpgsqlDbType.Numeric).Value = subtotal_factura
        ocmd.Parameters.Add("f0852_descuento_factura", NpgsqlDbType.Numeric).Value = descuento_factura
        ocmd.Parameters.Add("f0852_iva_factura", NpgsqlDbType.Numeric).Value = iva_factura
        ocmd.Parameters.Add("f0852_total_factura", NpgsqlDbType.Numeric).Value = total_factura
        ocmd.Parameters.Add("f0852_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0852_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0852_ind_fiscal", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("f0852_anulada_cg", NpgsqlDbType.Varchar).Value = factura_anulada_cg

        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al crear factura ! " + vbCrLf + ex.ToString)
        End Try

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub grabar_detalle_factura()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "insert into " + database.obtener_esquema + ".tb0853_facturas_cguno_detalle" _
            & " (" _
            & " f0853_id_factura, f0853_id_cia, f0853_referencia_1, f0853_referencia_2, f0853_descripcion," _
            & " f0853_cantidad, f0853_subtotal_producto, f0853_descuento_producto, f0853_iva_producto," _
            & " f0853_total_producto, f0853_id_item, f0853_usuario_crear," _
            & " f0853_usuario_modificar" _
            & ") values" _
            & " (" _
            & " @f0853_id_factura, @f0853_id_cia, @f0853_referencia_1, @f0853_referencia_2, @f0853_descripcion," _
            & " @f0853_cantidad, @f0853_subtotal_producto, @f0853_descuento_producto, @f0853_iva_producto," _
            & " @f0853_total_producto, @f0853_id_item, @f0853_usuario_crear," _
            & " @f0853_usuario_modificar" _
            & ")"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0853_id_factura", NpgsqlDbType.Integer).Value = id_factura
        ocmd.Parameters.Add("f0853_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0853_referencia_1", NpgsqlDbType.Varchar).Value = referencia_1
        ocmd.Parameters.Add("f0853_referencia_2", NpgsqlDbType.Varchar).Value = referencia_2
        ocmd.Parameters.Add("f0853_descripcion", NpgsqlDbType.Varchar).Value = descripcion_producto
        ocmd.Parameters.Add("f0853_cantidad", NpgsqlDbType.Numeric).Value = cantidad_producto
        ocmd.Parameters.Add("f0853_subtotal_producto", NpgsqlDbType.Numeric).Value = subtotal_producto
        ocmd.Parameters.Add("f0853_descuento_producto", NpgsqlDbType.Numeric).Value = descuento_producto
        ocmd.Parameters.Add("f0853_iva_producto", NpgsqlDbType.Numeric).Value = iva_producto
        ocmd.Parameters.Add("f0853_total_producto", NpgsqlDbType.Numeric).Value = total_producto
        ocmd.Parameters.Add("f0853_id_item", NpgsqlDbType.Integer).Value = id_item_producto
        ocmd.Parameters.Add("f0853_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0853_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! grabando detalle factura" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error grabando detalle factura" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

End Class
