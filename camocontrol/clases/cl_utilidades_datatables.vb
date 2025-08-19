Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Linq
Public Class cl_utilidades_datatables
    Public Shared Function copiar_ramal(ocampos As String(,), otabla As String, id_rama As String, campo_rama As String, campo_id As String)

        Dim csql1 As String = ""
        Dim csql_campos_insertar As String = ""
        Dim i As Integer = 0
        ' Loop over the array.
        For index0 = 0 To ocampos.GetUpperBound(0)
            'MsgBox(ocampos(index0, 0) & " ---- " & ocampos(index0, 1))
            csql1 += ocampos(index0, 0) & ","
            csql_campos_insertar += ocampos(index0, 0)
            If i < ocampos.GetUpperBound(0) Then
                csql_campos_insertar += ","
            End If
            i += 1
        Next
        MsgBox(csql1)
        MsgBox(ocampos.GetUpperBound(0))
        Dim csql_padre As String = ""
        csql_padre = "select " & csql1 & " from " & database.obtener_esquema & "." & otabla _
            & " where " & campo_id & " = '" & id_rama & "'"
        Dim otabla_padre As DataTable
        otabla_padre = cl_utilidades_datatables.cargar_informacion_postgres(csql_padre)
        Dim csql_valores As String = ""
        Dim ocont As Integer = 0
        For Each orow As DataRow In otabla_padre.Rows
            ' Loop over the array.
            For index0 = 0 To ocampos.GetUpperBound(0)
                If IsDBNull(orow(ocampos(index0, 0))) = True Then
                    csql_valores += "null"
                Else
                    If orow(ocampos(index0, 0)) = "" Then
                        csql_valores += "''"
                    Else
                        csql_valores += orow(ocampos(index0, 0))
                    End If
                End If
                If ocont < ocampos.GetUpperBound(0) Then
                    csql_valores += ","
                End If
                ocont += 1
            Next

            'copio la cabeza de la rama
            Dim csql_insertar As String = "INSERT INTO " & database.obtener_esquema & "." & otabla _
                            & " " & csql_campos_insertar _
                            & " VALUES" _
                            & " (" & csql_valores & ")"
            'cl_utilidades_datatables.ejecutar_csql(csql_insertar)
            MsgBox("Creo una copia del ramal." & orow(campo_id) & " con csql: " & csql_insertar)
            'Identifico el nuevo id

            'Identifico los hijos de la rama
            Dim csql_hijos As String = ""
            csql_hijos = "select " & csql1 & " from " & database.obtener_esquema & "." & otabla _
                & " where " & campo_rama & " = '" & id_rama & "'"
            Dim otabla_hijos As DataTable
            otabla_hijos = cl_utilidades_datatables.cargar_informacion_postgres(csql_hijos)
            MsgBox("La rama tiene tantos hijos: " & otabla_hijos.Rows.Count)
            For Each orow_hijos As DataRow In otabla_hijos.Rows
                'MsgBox(orow("f0100_id_estructura"))
                'Crear copia del hijo
                cl_utilidades_datatables.copiar_ramal(ocampos, otabla, orow_hijos(campo_id), campo_rama, campo_id)
            Next

        Next

        Return csql1
    End Function
    Public Shared Function ejecutar_csql(csql As String)
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'Crear el comando
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
        Return verror
    End Function
    Public Shared Function obtener_nuevo_consecutivo_reporte_programacion()
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim odr As NpgsqlDataReader
        Dim n_codigo As Integer = 1
        'Obtiene el código de Item más alto grabado en la tabla
        csql = "select tb100_solicitudes_programacion_despacho.id_solicitud" _
                & " from " + database.obtener_esquema + ".tb100_solicitudes_programacion_despacho" _
                & " order by tb100_solicitudes_programacion_despacho.id_solicitud DESC LIMIT 1"
        oconn_form = database.obtener_conexion()
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        'Crear el datareder
        'Dim odr As OleDbDataReader
        odr = ocmd.ExecuteReader 'Optener datareader
        'Recorrer los datos si el dia no tiene turnos no hay nada que leer, entonces el consecutivo es 1 por defecto
        While odr.Read
            If odr.Item("id_solicitud") Is DBNull.Value Then
                n_codigo = 1
            Else
                n_codigo = CInt(odr.Item("id_solicitud")) + 1
            End If
        End While
        'MsgBox("el valor es" & nconsecutivo)
        odr.Close()
        oconn_form.Close()
        'MsgBox(n_codigo)
        Return n_codigo
    End Function
    Public Shared Function consultar_consecutivo_creado_tablas(ByVal campo As String, ByVal campo_usuario As String, ByVal usuario As String, ByVal tabla As String)
        'Obtiene el código de Item más alto grabado en la tabla
        Dim csql As String
        Dim consecutivo As Integer
        csql = "select max(" & campo & ") as ultimo from " & database.obtener_esquema & "." & tabla _
            & " where " & campo_usuario & " = '" & usuario & "'"

        Dim otb_ultimo As DataTable
        otb_ultimo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_ultimo.Rows
            If orow("ultimo") Is DBNull.Value Then
                consecutivo = 1
            Else
                consecutivo = CInt(orow("ultimo"))
            End If
        Next
        Return consecutivo
    End Function
    Public Shared Function obtener_nuevo_consecutivo_tablas(ByVal campo As String, ByVal tabla As String)
        'Obtiene el código de Item más alto grabado en la tabla
        Dim csql As String
        Dim consecutivo As Integer
        csql = "select max(" & campo & ") as ultimo from " & database.obtener_esquema & "." & tabla & ";"

        Dim otb_ultimo As DataTable
        otb_ultimo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_ultimo.Rows
            If orow("ultimo") Is DBNull.Value Then
                consecutivo = 1
            Else
                consecutivo = CInt(orow("ultimo")) + 1
            End If
        Next
        Return consecutivo
    End Function

    Public Shared Function traer_datos_reporte_programacion(ByVal tx_filtro As String)
        'tipo_tercero 1 = Cliente; 
        Dim oconn_form As NpgsqlConnection
        Dim info_reporte As DataTable
        Dim csql As String
        Dim flt As String = "" 'diferentes posibilidades de la calusula where
        Dim oda As NpgsqlDataAdapter
        Dim ods As New DataSet
        csql = "SELECT tb100_solicitudes_programacion_despacho.id_solicitud," _
                        & " tb100_solicitudes_programacion_despacho.n_documento," _
                        & " tb100_solicitudes_programacion_despacho.f_rowid," _
                        & " tb100_solicitudes_programacion_despacho.td," _
                        & " tb100_solicitudes_programacion_despacho.cumplido," _
                        & " tb100_solicitudes_programacion_despacho.fecha_registro," _
                        & " tb100_solicitudes_programacion_despacho.identificacion_usuario," _
                        & " tb100_solicitudes_programacion_despacho.nombre_usuario" _
            & " FROM " + database.obtener_esquema + ".tb100_solicitudes_programacion_despacho" _
            & tx_filtro

        oconn_form = database.obtener_conexion()
        oda = New NpgsqlDataAdapter(csql, oconn_form)
        'Si ya existe el Data Table creado, lo borra
        If ods.Tables.Contains("info_reporte") Then
            ods.Tables("info_reporte").Clear()
        End If
        'Llenamos el dataAdapter con el query definido arriba, y le damos nombre a la tabla que se creará en memoria
        oda.Fill(ods, "info_reporte")
        info_reporte = ods.Tables("info_reporte")
        'cerrar coneccion
        oconn_form.Close()
        Return info_reporte
    End Function
    Public Shared Function cargar_informacion_unoee(ByVal csql As String)
        Dim oconn_sql_form As SqlConnection
        Dim ods As New DataSet
        Dim oda = New SqlDataAdapter
        oconn_sql_form = database.obtener_conexion_sql
        oda = New SqlDataAdapter(csql, oconn_sql_form)
        'Si ya existe el Data Table creado, lo borra
        If ods.Tables.Contains("info_unoee") Then
            ods.Tables("info_unoee").Clear()
        End If
        'Llenamos el dataAdapter con el query definido arriba, y le damos nombre a la tabla que se creará en memoria
        oda.Fill(ods, "info_unoee")
        Dim otb_info_unoee As DataTable
        otb_info_unoee = ods.Tables("info_unoee")
        'cerrar coneccion de la coneccion sql
        oconn_sql_form.Close()
        Return otb_info_unoee
    End Function

    Public Shared Function visualizar_datos_visor(ByVal id_sql As String, ByVal vg_id_cia As String, ByVal id_usuario As String,
                                             ByVal titulo_form As String, ByVal val_replace As String(),
                                             Optional otb As DataTable = Nothing,
                                             Optional nombre_formulario As String = "Visor de datos",
                                             Optional permitir_exportar As String = "S",
                                             Optional oform_padre As Object = Nothing,
                                             Optional agregar_checkboxcolumn As String = "N",
                                             Optional name_colum_id As String = "",
                                             Optional id_tercero As String = "",
                                             Optional formulario_modal As String = "S",
                                             Optional seleccion_multiple As String = "S",
                                             Optional dv_filter As String = "")
        '
        'arreglo de tablas (1)= tabla total de datos mostrados, (2) tabla datos seleccionados con el chk
        Dim otb_tablas_array(2) As DataTable
        Dim csql As String = ""
        If otb Is Nothing = True Then
            csql = comunes.suministrar_valor_variable_configuracion(id_sql, vg_id_cia)
            csql = csql.Replace("$VERDADERO$", "")
            csql = csql.Replace("$df001$", database.obtener_esquema)
            Dim i As Integer = 1
            Dim ovariable As String = ""
            For Each oval As String In val_replace
                ovariable = "$" & i.ToString.PadLeft(3, "0") & "$"
                csql = csql.Replace(ovariable, oval)
                i += 1
            Next
        End If

        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = oform_padre
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.P_exportar = permitir_exportar
        oform_mostrar_datos.otb_datos = otb
        oform_mostrar_datos.titulo_formulario = titulo_form
        oform_mostrar_datos.Text = nombre_formulario
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = id_usuario
        oform_mostrar_datos.oarray_var = val_replace
        oform_mostrar_datos.agregar_checkboxcolumn = agregar_checkboxcolumn
        oform_mostrar_datos.seleccionmultiple = seleccion_multiple
        oform_mostrar_datos.name_colum_id = name_colum_id
        oform_mostrar_datos.id_tercero = id_tercero
        oform_mostrar_datos.dv_filter = dv_filter
        If formulario_modal = "S" Then
            oform_mostrar_datos.ShowDialog()
        Else
            oform_mostrar_datos.Show()
        End If

        If agregar_checkboxcolumn = "S" Then
            otb_tablas_array(1) = oform_mostrar_datos.otb_datos
            otb_tablas_array(2) = oform_mostrar_datos.otb_datos_checbox_selec
            oform_mostrar_datos.Dispose()
        End If
        Return otb_tablas_array
    End Function

    Public Shared Function suministrar_datagridviewrows_visor(ByVal csql As String, ByVal vg_id_cia As String,
                                                             ByVal id_usuario As String,
                                                             ByVal titulo_formulario As String,
                                                             ByVal texto_formulario As String)
        Dim nombre_columna As String = ""
        Dim valor_filtro As String = ""
        Dim vcerrar As String = "S"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        'oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.ocontexto_form = "exportar_datagridviewrow"
        oform_mostrar_datos.titulo_formulario = titulo_formulario
        oform_mostrar_datos.Text = texto_formulario
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = id_usuario
        oform_mostrar_datos.ShowDialog()
        'Copio la informacion del datarow de la tabla segun el criterio doble click
        Dim orow As DataRow() = Nothing
        If oform_mostrar_datos.IsDisposed = False Then
            nombre_columna = oform_mostrar_datos.dg_datos.Columns(oform_mostrar_datos.dg_datos.CurrentCell.ColumnIndex).Name
            valor_filtro = oform_mostrar_datos.dg_datos.CurrentCell.Value
            orow = oform_mostrar_datos.otb_datos.Select(nombre_columna & " = '" & valor_filtro & "'")
        End If
        oform_mostrar_datos.Close()
        Return orow
    End Function

    Public Shared Function cargar_informacion_postgres(ByVal csql As String)
        Dim oconn_form As NpgsqlConnection
        Dim oda As NpgsqlDataAdapter
        Dim ods As New DataSet
        oconn_form = database.obtener_conexion
        oda = New NpgsqlDataAdapter(csql, oconn_form)
        'Si ya existe el Data Table creado, lo borra
        If ods.Tables.Contains("info_sidlog") Then
            ods.Tables("info_sidlog").Clear()
        End If
        'Llenamos el dataAdapter con el query definido arriba, y le damos nombre a la tabla que se creará en memoria

        'carga todos los metadatos sobre una tabla, como nombres de columnas, claves y contsrains
        'oda.FillSchema(ods, SchemaType.Source, "info_sidlog")

        'carga los datos propiamente dichos.
        oda.Fill(ods, "info_sidlog")
        Dim otb_info_sidlog As DataTable
        otb_info_sidlog = ods.Tables("info_sidlog")
        'cerrar coneccion
        oconn_form.Close()
        Return otb_info_sidlog
    End Function

    Public Shared Function cargar_informacion_access_despachos(ByVal csql As String)
        'datable de los despachos programados
        Dim ods As New DataSet
        'Dim csql As String
        Dim info_ppal_despachos As DataTable

        Dim oconn_access_form As OleDbConnection
        Dim oda2 As OleDbDataAdapter

        'csql = es la instruccion sql que usaremos.

        Dim dtb As String = database.inf_despachos '"E:\bases_sidoc\Despachos\BASCULA.mdb"
        Dim dtmdw As String = database.inf_despachos_seg '"E:\Backups\Temp\icdp_sgrdd.mdw"
        Dim usr As String = database.inf_despachos_user '"sidoc"
        Dim psuser As String = database.inf_despachos_clave '"963"
        oconn_access_form = database.obtener_conexion_access(dtb, dtmdw, usr, psuser)
        oda2 = New OleDbDataAdapter(csql, oconn_access_form)

        'Si ya existe el Data Table creado, lo borra
        If ods.Tables.Contains("info_access_despachos") Then
            ods.Tables("info_access_despachos").Clear()
        End If

        'Llenamos el dataAdapter con el query definido arriba, y le damos nombre a la tabla que se creará en memoria
        oda2.Fill(ods, "info_access_despachos")
        oconn_access_form.Close()
        info_ppal_despachos = ods.Tables("info_access_despachos")
        Return info_ppal_despachos
    End Function

    Public Shared Function filtrar_datatable(ByVal dt As DataTable, ByVal filter As String, ByVal sort As String) As DataTable
        Dim rows As DataRow()
        Dim dtNew As DataTable
        ' copy table structure
        dtNew = dt.Clone()
        ' sort and filter data
        rows = dt.Select(filter, sort)
        ' fill dtNew with selected rows
        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next
        ' return filtered dt
        Return dtNew
    End Function

    Public Shared Function exportar_consulta_plano(csql As String, path_txt As String, form_file As String, header As String)
        'csql es la instruccion csql
        'path_txt es el archivo donde se grabara el texto exportado
        'form_file indicara si se usara el form file para definir el nombre del archivo donde se exportara. "S o N"
        'header indica si se inluira el nombre de las columnas en el texto a exportar. "S . N"

        Dim verror As String = "N"
        Dim tbl As New DataTable
        Dim strFilePath As String = ""
        Dim stm As StreamWriter
        Dim i As Integer

        tbl = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If tbl.Rows.Count > 0 Then
            Dim path_file As String = ""
        Else
            MsgBox("No hay datos que exportar", MsgBoxStyle.Information, "Info")
            verror = "S"
            Return verror
            Exit Function
        End If
        If form_file = "S" Then
            'Identifico en que archivo quiero guardar los datos.
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            saveFileDialog1.FilterIndex = 1
            saveFileDialog1.RestoreDirectory = True
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                strFilePath = saveFileDialog1.FileName
            Else
                verror = "S"
                Return verror
                Exit Function
            End If
        Else
            strFilePath = path_txt
        End If
        Try
            stm = New StreamWriter(strFilePath, False)
            If header = "S" Then  'si queremos exportar el nombre de las columnas
                'strFilePath = "c:\tblProducts.txt"

                For i = 0 To tbl.Columns.Count - 2
                    stm.Write(tbl.Columns(i).ColumnName + ControlChars.Tab)
                    'stm.Write(tbl.Columns(i).ColumnName + "|")
                Next i
                stm.Write(tbl.Columns(i).ColumnName)
                stm.WriteLine()
            End If
            Dim txtvalue As String = ""
            For Each row As DataRow In tbl.Rows
                For i = 0 To tbl.Columns.Count - 1
                    txtvalue = row(i).ToString.Replace(ControlChars.CrLf, " -- ")
                    stm.Write(txtvalue + ControlChars.Tab)
                    'stm.Write(txtvalue + "|")
                Next
                stm.WriteLine()
            Next row
            stm.Close()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Exportar ! " + vbCrLf + ex.ToString)
        End Try
        Return verror
    End Function
    Public Shared Sub exportar_datatable_excel(ByVal otb As DataTable)
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        If otb.Rows.Count = 0 Then
            Exit Sub
        End If

        'Iniciar un nuevo libro en Excel
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add
        'Agregar datos a las celdas de la primera hoja en el libro nuevo
        oSheet = oBook.Worksheets(1)

        ' Agregamos el nombre de las columnas
        Dim ncol As Integer = 1
        For Each ocolum As DataColumn In otb.Columns
            oSheet.cells(1, ncol).value = ocolum.ColumnName.ToString
            ncol += 1
        Next
        ' Agregamos Los datos que queremos agregar
        Dim ocolumnas As Integer = otb.Columns.Count
        Dim nrow As Long = 1
        For Each orow As DataRow In otb.Rows
            For i = 1 To ocolumnas
                oSheet.cells(nrow + 1, i).value = orow(i - 1).ToString
            Next
            nrow = nrow + 1
        Next
        'oSheet.cells(1, 1).Value = "Hola Mundo"

        ' hacemos visible el documento
        oExcel.Visible = True
        oExcel.UserControl = True
        'Guardaremos el documento en el escritorio con el nombre prueba
        'oBook.SaveAs(Environ("UserProfile") & "\desktop\Prueba.xls")

    End Sub

    Public Shared Sub datatable_to_csv_filesavedialog(ByVal sourceTable As DataTable,
                                     ByVal includeHeaders As Boolean, ByVal id_cia As String)
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        saveFileDialog1.AddExtension = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Using writer As StreamWriter = New StreamWriter(saveFileDialog1.FileName)
                cl_utilidades_datatables.datatable_to_csv_path(sourceTable, writer, includeHeaders, "S", id_cia)
            End Using
        End If
    End Sub

    Public Shared Sub datatable_to_csv_path(ByVal sourceTable As DataTable,
                                     ByVal writer As TextWriter,
                                     ByVal includeHeaders As Boolean,
                                     ByVal ajust_numeros As String,
                                     ByVal id_cia As String)
        'writer es el path del aechivo que se va a crear.
        If (includeHeaders) Then
            If (includeHeaders) Then
                Dim headerValues As IEnumerable(Of String) = sourceTable.Columns.OfType(Of DataColumn).Select(Function(column) QuoteValue(column.ColumnName))
                writer.WriteLine(String.Join(vbTab, headerValues))
            End If
        End If

        Dim items As IEnumerable(Of String) = Nothing
        Dim items2 As IEnumerable(Of String) = Nothing
        'Dim ajust_numeros As String = comunes.suministrar_valor_variable_configuracion("CONFIG-GEN001", id_cia)
        Dim txt_item As String = ""

        If ajust_numeros = "S" Then
            For Each row As DataRow In sourceTable.Rows
                items = row.ItemArray.Select(Function(obj) QuoteValue(obj.ToString()))
                items2 = items.Select(Function(x) x.Replace(",", "!1!")).ToList()
                items2 = items.Select(Function(x) x.Replace(".", ",")).ToList()
                items2 = items.Select(Function(x) x.Replace("!1!", ",")).ToList()
                items2 = items2.Select(Function(x) x.Replace(vbCrLf, " -- ")).ToList()
                items2 = items2.Select(Function(x) x.Replace(vbTab, "    ")).ToList()
                items2 = items2.Select(Function(x) x.Replace("\uDC23", "")).ToList()
                txt_item = ""

                'MsgBox(row(0).ToString & txt_item)
                Try
                    writer.WriteLine(String.Join(vbTab, items2))
                Catch ex As Exception
                    'For Each item As Object In row.ItemArray
                    'txt_item += " - " & item.ToString
                    'Next
                    'MsgBox(ex.Message & vbCrLf & txt_item)
                End Try
            Next
        Else
            For Each row As DataRow In sourceTable.Rows
                items = row.ItemArray.Select(Function(obj) QuoteValue(obj.ToString()))
                items = items.Select(Function(x) x.Replace(vbCrLf, " -- ")).ToList()
                items = items.Select(Function(x) x.Replace(vbTab, "    ")).ToList()
                items = items.Select(Function(x) x.Replace("\uDC23", "")).ToList()

                Try
                    writer.WriteLine(String.Join(vbTab, items))
                Catch ex As Exception
                    'For Each item As Object In row.ItemArray
                    'txt_item += " - " & item.ToString
                    'Next
                    'MsgBox(ex.Message & vbCrLf & txt_item)
                End Try
            Next
        End If
        writer.Flush()
    End Sub
    Private Shared Function QuoteValue(ByVal value As String) As String
        Return String.Concat("""", value.Replace("""", """"""), """")
    End Function

    Public Shared Sub datatable_to_csv_path_sin_comillas(ByVal sourceTable As DataTable,
                                     ByVal rutaArchivo As String,
                                     ByVal includeHeaders As Boolean,
                                     ByVal ajust_numeros As String)



        Using sw As New StreamWriter(rutaArchivo, False, Encoding.UTF8)
            ' Escribir cabeceras
            If includeHeaders Then
                Dim columnas As String() = sourceTable.Columns.Cast(Of DataColumn)().
                                            Select(Function(c) c.ColumnName).ToArray()
                sw.WriteLine(String.Join(vbTab, columnas))
            End If

            ' Escribir filas
            For Each row As DataRow In sourceTable.Rows
                Dim valores As New List(Of String)
                For Each col As DataColumn In sourceTable.Columns
                    Dim valor As String = If(row(col) IsNot Nothing, row(col).ToString(), "")
                    ' Sin comillas, solo limpiar comas para no romper el CSV
                    'valor = valor.Replace(vbTab, " ") ' <- evita que una coma en el dato rompa el CSV
                    valor = valor.Replace(vbCrLf, " -- ")
                    valor = valor.Replace(vbTab, "    ")
                    valor = valor.Replace("\uDC23", "")

                    If ajust_numeros = "S" Then 'cambiar "," por "." y viceversa
                        Dim vf As String = valor.Replace(",", vbEmpty)
                        vf = vf.Replace(".", vbEmpty)
                        If IsNumeric(vf) Then
                            valor = valor.Replace(",", vbEmpty)
                            'valor = valor.Replace(".", ",") 'En realidad solo debo eliminar las "," el punto es el decimal
                        End If
                    End If
                    valores.Add(valor)
                Next
                sw.WriteLine(String.Join(vbTab, valores))
            Next
        End Using
    End Sub



End Class
