Imports System
Imports System.IO
Imports System.Collections
Imports System.Globalization
Public Class fm_0008_importar_plano_bancos
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Private otb_configuraciones As DataTable
    Private otb_tipos_recaudos As DataTable
    Private otb_registros_grabados As DataTable
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand

    Private matriz_campos As New List(Of String())
    Private rowbanco As DataRow 'datarow con la informacion especifica del banco
    Private orow_dg As DataGridViewRow
    Private req_soporte As String = "S"
    Private txt_texto_evaluacion As String = ""
    Private txt_texto_total_evaluado As String = ""
    Private filas_validas As Integer
    Private filas_ignoradas As Integer
    Private filas_duplicadas As Integer
    Private columnas_archivo As Integer
    Private formato_fecha As String
    Private identificador_columnas As String
    Private longitud_verificacion As Integer 'longitud que debe tener la cadena en la columna de verificacion
    Private ods As New DataSet
    Private otb_datos As New DataTable
    Private otb_datos_rechazados As New DataTable
    Private odatarow As DataRow

    Private Sub fm_0400_importar_plano_bancos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        bt_importar_clipboard.Enabled = False
        bt_importar_plano.Enabled = False
        bt_grabar.Enabled = False

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0008_configuracion_planos_recaudos order by f0008_descripcion_banco"
        otb_configuraciones = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_id_config
            'Valor que se muestra al usuario
            .DisplayMember = "f0008_descripcion_banco"
            'Valor interno que almacena el objeto
            .ValueMember = "f0008_id_config"
            'Origen de Datos del ComboBox
            .DataSource = otb_configuraciones
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        'creo la tabla para almacenar datos
        otb_datos.Columns.Add("fecha", Type.GetType("System.String"))
        otb_datos.Columns.Add("transaccion", Type.GetType("System.String"))
        otb_datos.Columns.Add("oficina", Type.GetType("System.String"))
        otb_datos.Columns.Add("documento", Type.GetType("System.String"))
        otb_datos.Columns.Add("debito", Type.GetType("System.String"))
        otb_datos.Columns.Add("credito", Type.GetType("System.String"))
        otb_datos.Columns.Add("efectivo", Type.GetType("System.String"))
        otb_datos.Columns.Add("cheque", Type.GetType("System.String"))
        otb_datos.Columns.Add("nit", Type.GetType("System.String"))
        otb_datos.Columns.Add("cliente", Type.GetType("System.String"))
        'ods.Tables.Add(otb_datos)

        'crea una copia identica de la estructura de la tabla para los rechazados.
        otb_datos_rechazados = otb_datos.Clone

        'dg_datos_importados.DataSource = otb_datos
    End Sub

    Private Sub bt_importar_plano_Click(sender As System.Object, e As System.EventArgs) Handles bt_importar_plano.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim plano_total As String = ""
        Dim path_file As String = ""

        'cargamos los tipos de movimientos asociados a la configuracion
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0009_bancos_tipos_recaudos" _
            & " where f0009_id_cia = '" & vg_id_cia & "' and f0009_id_config = '" & cm_id_config.SelectedValue & "' and f0009_anulado = 'N'"
        otb_tipos_recaudos = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'Identificamos si el archivo requerira soporte para poder identificarse.
        Dim oconfig As DataRow() = otb_configuraciones.Select("f0008_id_config = '" & cm_id_config.SelectedValue & "'")
        For Each orow As DataRow In oconfig
            req_soporte = orow("f0008_req_soporte")
        Next

        txt_texto_total_evaluado = ""

        dg_datos_importados.DataSource = ""
        dg_rechazados.DataSource = ""

        openFileDialog1.InitialDirectory = "e:\"
        openFileDialog1.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*" 'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path_file = openFileDialog1.FileName
            comunes.mostrar_archivo_texto(path_file, "")
        Else
            Exit Sub
        End If
        'cargamos los registros gravados para este banco con el fin de impedir duplicados
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0010_bancos_recaudos" _
            & " where f0010_id_config = '" & cm_id_config.SelectedValue & "'" _
            & " order by f0010_id_recaudo desc limit 500"
        otb_registros_grabados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        otb_datos.Rows.Clear()
        otb_datos_rechazados.Clear()
        filas_validas = 0
        filas_ignoradas = 0
        filas_duplicadas = 0


        Using MyReader As New Microsoft.VisualBasic.
                      FileIO.TextFieldParser(path_file, System.Text.Encoding.UTF7) 'FileIO.TextFieldParser(path_file)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(identificador_columnas) 'MyReader.SetDelimiters(",")
            Dim currentRow As String()
            Dim conta_fields As Integer
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    Dim arreglo_campos(currentRow.Length + 1) As String
                    currentRow.CopyTo(arreglo_campos, 1)
                    arreglo_campos(0) = "ND"
                    'MsgBox(arreglo_campos.Length)
                    txt_texto_evaluacion = ""
                    conta_fields = 0
                    txt_texto_evaluacion = "LECTURA DEL RENGLON" & vbCrLf
                    For Each currentField In arreglo_campos
                        txt_texto_evaluacion += (conta_fields & ". [ " & currentField & " ]" & vbCrLf)
                        conta_fields += 1
                    Next
                    txt_texto_evaluacion += vbCrLf
                    'Agrego los datos al datatable
                    'agregar_row_otabla(arreglo_campos)

                    'Agrego el arreglo de campos a la coleccion que es un metodo mas flexible.
                    matriz_campos.Add(arreglo_campos)

                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                    Dispose()
                    Exit Sub
                End Try
            End While
        End Using

        'Recorro la coleccion para extraer los campos requeridos
        For Each row_campos As String() In matriz_campos
            'Agrego los datos al datatable
            agregar_row_otabla(row_campos)
        Next

        dg_datos_importados.DataSource = otb_datos
        dg_rechazados.DataSource = otb_datos_rechazados
        If otb_datos.Rows.Count > 0 Then
            bt_grabar.Enabled = True
        End If
        validar_numero_registros() 'validamos que existan registros por guardar.
        MsgBox("Filas validas = " & filas_validas & vbCrLf _
               & "Filas ignoradas = " & filas_ignoradas & vbCrLf _
               & "Filas duplicadas = " & filas_duplicadas, MsgBoxStyle.Information, "Información")
        If chk_paso_a_paso.Checked = True Then
            comunes.mostrar_archivo_texto("", txt_texto_total_evaluado)
        End If
    End Sub
    Private Sub agregar_row_otabla(arreglo_campos() As String)
        txt_texto_evaluacion = vbCrLf & "LECTURA DEL RENGLON:" & vbCrLf & vbCrLf
        'Eliminamos caracter invalido
        Dim c1 As Integer = 0
        Dim i As Integer
        For i = 1 To arreglo_campos.Length
            Try
                arreglo_campos(i) = arreglo_campos(i).ToString.Replace("'", "")
                txt_texto_evaluacion += (c1 & ". [ " & arreglo_campos(i) & " ]" & vbCrLf)
                c1 += 1
            Catch ex As Exception

            End Try
        Next
        txt_texto_evaluacion += "TOTAL COLUMNAS: " & c1
        Dim dr As DataRow
        'Recordar que los arreglos inician en 0, al indice cero le asigne "ND", por esto le sumo 1 al valor de columnas_archivo
        'verificamos si la longitud del campo de verificacion es igual a la longitud esperada. validamos que el banco si sea.
        If arreglo_campos.Length = columnas_archivo Then 'Verificamos que el numero de columnas sea el adecuado
            If Len(arreglo_campos(rowbanco("f0008_col_verificacion")).Trim()) = longitud_verificacion Then 'verificamos longitud de columna
                'MsgBox(Len(arreglo_campos(rowbanco("f0008_col_verificacion")).Trim()) & " - " & longitud_verificacion)
                dr = otb_datos.NewRow
                dr("fecha") = arreglo_campos(rowbanco("f0008_col_fecha")).Trim()
                dr("transaccion") = arreglo_campos(rowbanco("f0008_col_transaccion")).Trim()
                dr("oficina") = arreglo_campos(rowbanco("f0008_col_oficina")).Trim()
                dr("documento") = arreglo_campos(rowbanco("f0008_col_documento")).Trim()
                dr("debito") = arreglo_campos(rowbanco("f0008_col_debito")).Trim()
                dr("credito") = arreglo_campos(rowbanco("f0008_col_credito")).Trim()
                dr("efectivo") = arreglo_campos(rowbanco("f0008_col_efectivo")).Trim()
                dr("cheque") = arreglo_campos(rowbanco("f0008_col_cheque")).Trim()
                dr("nit") = arreglo_campos(rowbanco("f0008_col_nit")).Trim()
                dr("cliente") = arreglo_campos(rowbanco("f0008_col_cliente")).Trim()
                Dim orow_registro_valido As DataRow() = otb_tipos_recaudos.Select("f0009_descripcion_tipo = '" & dr("Transaccion") & "'")
                If orow_registro_valido.Length = 1 Then 'transacciones admitidas de ingreso, las demas se rechazan
                    'verificamos si el registro ya existe
                    Dim orows_registro As DataRow()
                    Try
                        orows_registro = otb_registros_grabados.Select("f0010_id_config = '" & cm_id_config.SelectedValue & "'" _
                                                                                    & " and f0010_col_fecha = '" & arreglo_campos(rowbanco("f0008_col_fecha")).Trim() & "'" _
                                                                                    & " and f0010_col_transaccion = '" & arreglo_campos(rowbanco("f0008_col_transaccion")).Trim() & "'" _
                                                                                    & " and f0010_col_oficina = '" & arreglo_campos(rowbanco("f0008_col_oficina")).Trim() & "'" _
                                                                                    & " and f0010_col_documento = '" & arreglo_campos(rowbanco("f0008_col_documento")).Trim() & "'" _
                                                                                    & " and f0010_col_credito = '" & normalizar_valor(arreglo_campos(rowbanco("f0008_col_credito")).Trim()) & "'" _
                                                                                    & " and f0010_col_efectivo = '" & normalizar_valor(arreglo_campos(rowbanco("f0008_col_efectivo")).Trim()) & "'" _
                                                                                    & " and f0010_col_cheque = '" & normalizar_valor(arreglo_campos(rowbanco("f0008_col_cheque")).Trim()) & "'" _
                                                                                    & " and f0010_col_nit = '" & arreglo_campos(rowbanco("f0008_col_nit")).Trim() & "'" _
                                                                                    & " and f0010_col_cliente = '" & arreglo_campos(rowbanco("f0008_col_cliente")).Trim() & "'" _
                                                                       )
                    Catch ex As Exception
                        txt_texto_evaluacion += "Error de configuracion de Columnas: " & vbCrLf & ex.ToString
                        If chk_paso_a_paso.Checked = True Then
                            MsgBox(txt_texto_evaluacion)
                        End If
                        Exit Sub
                    End Try
                    If orows_registro.Length = 0 Then
                        filas_validas += 1
                        Try
                            otb_datos.Rows.Add(dr)
                        Catch ex As Exception
                            MsgBox("Fallo")
                        End Try
                    Else
                        filas_duplicadas += 1
                        'otb_datos_rechazados.ImportRow(dr)
                        dr = otb_datos_rechazados.NewRow
                        dr("fecha") = arreglo_campos(rowbanco("f0008_col_fecha")).Trim()
                        dr("transaccion") = arreglo_campos(rowbanco("f0008_col_transaccion")).Trim()
                        dr("oficina") = arreglo_campos(rowbanco("f0008_col_oficina")).Trim()
                        dr("documento") = arreglo_campos(rowbanco("f0008_col_documento")).Trim()
                        dr("debito") = arreglo_campos(rowbanco("f0008_col_debito")).Trim()
                        dr("credito") = arreglo_campos(rowbanco("f0008_col_credito")).Trim()
                        dr("efectivo") = arreglo_campos(rowbanco("f0008_col_efectivo")).Trim()
                        dr("cheque") = arreglo_campos(rowbanco("f0008_col_cheque")).Trim()
                        dr("nit") = arreglo_campos(rowbanco("f0008_col_nit")).Trim()
                        dr("cliente") = arreglo_campos(rowbanco("f0008_col_cliente")).Trim()
                        otb_datos_rechazados.Rows.Add(dr)
                        txt_texto_evaluacion += "Rechazo 4: Registro duplicado." & vbCrLf
                    End If
                Else
                    filas_ignoradas += 1
                    txt_texto_evaluacion += "Rechazo 1: Tipo Transaccion: " & dr("Transaccion") & vbCrLf
                End If
            Else
                filas_ignoradas += 1
                txt_texto_evaluacion += "Rechazo 2: Error en validacion de Longitud columna:" & vbCrLf _
                    & "Valor verificado: " & arreglo_campos(rowbanco("f0008_col_verificacion")).Trim() & vbCrLf _
                    & "Longitud: " & Len(arreglo_campos(rowbanco("f0008_col_verificacion")).Trim()) & vbCrLf _
                    & "Longitud esperada: " & longitud_verificacion & vbCrLf
            End If
        Else
            filas_ignoradas += 1
            txt_texto_evaluacion += vbCrLf & "Rechazo 3: Error en configuracion de numero de Columnas: " & vbCrLf _
                & "La configuracion actual es de : " & (columnas_archivo) & " Columnas " & vbCrLf
        End If
        If chk_paso_a_paso.Checked = True Then
            txt_texto_total_evaluado += txt_texto_evaluacion
        End If
    End Sub
    Private Sub bt_importar_clipboard_Click(sender As System.Object, e As System.EventArgs) Handles bt_importar_clipboard.Click
        Dim txt_portapapeles As String = Clipboard.GetText
        comunes.mostrar_archivo_texto("", txt_portapapeles)
        procesar_informacion_clipboard(txt_portapapeles)
    End Sub

    Private Sub procesar_informacion_clipboard(texto_procesar As String)
        texto_procesar = texto_procesar.Replace("""", " ")
        texto_procesar = texto_procesar.Replace(" , ", CChar(vbTab))

        'cargamos los registros gravados para este banco con el fin de impedir duplicados
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0010_bancos_recaudos" _
            & " where f0010_id_config = '" & cm_id_config.SelectedValue & "'" _
            & " order by f0010_id_recaudo desc limit 500"
        otb_registros_grabados = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        otb_datos.Rows.Clear()
        otb_datos_rechazados.Clear()
        Dim arreglo_renglon() As String
        Dim arreglo_campos() As String
        filas_validas = 0
        filas_ignoradas = 0
        filas_duplicadas = 0
        arreglo_renglon = texto_procesar.Split(vbCrLf)  'Clipboard.GetText.Split(vbCrLf)

        For Each txt_renglon As String In arreglo_renglon
            txt_renglon = "ND" & CChar(vbTab) & txt_renglon.Replace("'", "")
            'MsgBox(txt_renglon)
            arreglo_campos = txt_renglon.Split(New [Char]() {CChar(vbTab)})
            agregar_row_otabla(arreglo_campos)
        Next
        'dg_datos_importados.DataSource = ""
        dg_datos_importados.DataSource = otb_datos
        dg_rechazados.DataSource = otb_datos_rechazados
        If otb_datos.Rows.Count > 0 Then
            bt_grabar.Enabled = True
        End If
        validar_numero_registros() 'validamos que existan registros por guardar.
        MsgBox("Filas validas = " & filas_validas & vbCrLf _
               & "Filas ignoradas = " & filas_ignoradas & vbCrLf _
               & "Filas duplicadas = " & filas_duplicadas, MsgBoxStyle.Information, "Información")
    End Sub
    Private Sub cm_bancos_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_id_config.Validating
        If cm_id_config.Text <> "" Then
            bt_importar_clipboard.Enabled = True
            bt_importar_plano.Enabled = True
            MsgBox("La información sera cargada al banco: " & cm_id_config.Text, MsgBoxStyle.Information, "Proceso")
            cargar_informacion_banco()
            otb_datos.Clear()
            otb_datos_rechazados.Clear()
        End If
    End Sub
    Private Sub validar_numero_registros()
        If dg_datos_importados.Rows.Count > 0 Then
            bt_grabar.Enabled = True
        Else
            bt_grabar.Enabled = False
        End If
    End Sub
    Private Sub cargar_informacion_banco()
        Dim orows_banco As DataRow() = otb_configuraciones.Select("f0008_id_config = '" & cm_id_config.SelectedValue & "'")
        For Each orow As DataRow In orows_banco
            rowbanco = orow 'cargo el rowbanco para usar sus campos mas adelante directamente
            columnas_archivo = orow("f0008_columnas_archivo")
            identificador_columnas = orow("f0008_identificador_columnas")
            longitud_verificacion = orow("f0008_long_col_verificacion")
            formato_fecha = orow("f0008_format_fecha")
            Select Case identificador_columnas 'para cuando sea tab hay que asignar valor del sistema para este caracter
                Case "TAB"
                    identificador_columnas = CChar(vbTab)
            End Select
        Next
    End Sub
    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        'recorrer la grilla
        For Each orow As DataGridViewRow In dg_datos_importados.Rows
            orow_dg = orow
            Try
                grabar_nuevo_recaudo()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hay un error en el formato de fecha! " + vbCrLf + ex.ToString)
                Exit Sub
            End Try

            'MsgBox(orow_dg.Cells.Item("fecha").Value)
        Next
        If verror = "N" Then
            MsgBox("Registros grabados", MsgBoxStyle.Information, "Informacion")
        End If
        dg_datos_importados.DataSource = otb_datos_rechazados
        Me.Dispose()
    End Sub
    Private Sub grabar_nuevo_recaudo()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada 
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0010_bancos_recaudos" _
                & " (f0010_id_cia, f0010_id_config, f0010_fecha_transaccion, f0010_req_soporte," _
                & " f0010_col_fecha, f0010_col_transaccion," _
                & " f0010_col_oficina, f0010_col_documento, f0010_col_debito, f0010_col_credito," _
                & " f0010_col_efectivo, f0010_col_cheque, f0010_col_nit, f0010_col_cliente," _
                & " f0010_fm, f0010_usuario_crear, f0010_usuario_modificar)" _
                & " VALUES" _
                & " (@f0010_id_cia, @f0010_id_config, @f0010_fecha_transaccion, @f0010_req_soporte," _
                & " @f0010_col_fecha, @f0010_col_transaccion," _
                & " @f0010_col_oficina, @f0010_col_documento, @f0010_col_debito, @f0010_col_credito," _
                & " @f0010_col_efectivo, @f0010_col_cheque, @f0010_col_nit, @f0010_col_cliente," _
                & " @f0010_fm, @f0010_usuario_crear, @f0010_usuario_modificar)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_recaudo(ocmd)

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
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_recaudo(ByVal ocmd As NpgsqlCommand)
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0010_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0010_id_config", NpgsqlDbType.Integer).Value = CInt(cm_id_config.SelectedValue)
        Dim txt_fecha_armada As String = ""
Dim tx As String = orow_dg.Cells.Item("fecha").Value.ToString
        Select Case formato_fecha
            Case "mm/dd"
                ocmd.Parameters.Add("@f0010_fecha_transaccion", NpgsqlDbType.Timestamp).Value = comunes.convertir_string_to_date(1, Year(Now()) & "/" & orow_dg.Cells.Item("fecha").Value)
            Case "aaaammdd"

                txt_fecha_armada = Mid(tx, 1, 4) & "/"
                txt_fecha_armada += Mid(tx, 5, 2) & "/"
                txt_fecha_armada += Mid(tx, 7, 2)
                ocmd.Parameters.Add("@f0010_fecha_transaccion", NpgsqlDbType.Timestamp).Value = comunes.convertir_string_to_date(1, txt_fecha_armada)
            Case "ddmmaaaa"
                txt_fecha_armada = Mid(orow_dg.Cells.Item("fecha").Value, 1, 2) & "/"
                txt_fecha_armada += Mid(orow_dg.Cells.Item("fecha").Value, 3, 2) & "/"
                txt_fecha_armada += Mid(orow_dg.Cells.Item("fecha").Value, 5, 4)
                ocmd.Parameters.Add("@f0010_fecha_transaccion", NpgsqlDbType.Timestamp).Value = comunes.convertir_string_to_date(2, txt_fecha_armada)
            Case "aaaa/mm/dd"
                txt_fecha_armada = orow_dg.Cells.Item("fecha").Value.ToString
                ocmd.Parameters.Add("@f0010_fecha_transaccion", NpgsqlDbType.Timestamp).Value = comunes.convertir_string_to_date(1, txt_fecha_armada)
            Case "dd/mm/aaaa"
                txt_fecha_armada = orow_dg.Cells.Item("fecha").Value.ToString
                ocmd.Parameters.Add("@f0010_fecha_transaccion", NpgsqlDbType.Timestamp).Value = comunes.convertir_string_to_date(2, txt_fecha_armada)
            Case Else
                ocmd.Parameters.Add("@f0010_fecha_transaccion", NpgsqlDbType.Timestamp).Value = comunes.convertir_string_to_date(2, orow_dg.Cells.Item("fecha").Value) 'Date.ParseExact(orow_dg.Cells.Item("fecha").Value, "dd/mm/yyyy", CultureInfo.InvariantCulture)
        End Select
        ocmd.Parameters.Add("@f0010_req_soporte", NpgsqlDbType.Varchar).Value = req_soporte
        ocmd.Parameters.Add("@f0010_col_fecha", NpgsqlDbType.Varchar).Value = orow_dg.Cells.Item("fecha").Value
        ocmd.Parameters.Add("@f0010_col_transaccion", NpgsqlDbType.Varchar).Value = orow_dg.Cells.Item("transaccion").Value
        ocmd.Parameters.Add("@f0010_col_oficina", NpgsqlDbType.Varchar).Value = orow_dg.Cells.Item("oficina").Value
        ocmd.Parameters.Add("@f0010_col_documento", NpgsqlDbType.Varchar).Value = orow_dg.Cells.Item("documento").Value
        ocmd.Parameters.Add("@f0010_col_debito", NpgsqlDbType.Varchar).Value = normalizar_valor(orow_dg.Cells.Item("debito").Value)
        ocmd.Parameters.Add("@f0010_col_credito", NpgsqlDbType.Varchar).Value = normalizar_valor(orow_dg.Cells.Item("credito").Value)
        ocmd.Parameters.Add("@f0010_col_efectivo", NpgsqlDbType.Varchar).Value = normalizar_valor(orow_dg.Cells.Item("efectivo").Value)
        ocmd.Parameters.Add("@f0010_col_cheque", NpgsqlDbType.Varchar).Value = normalizar_valor(orow_dg.Cells.Item("cheque").Value)
        ocmd.Parameters.Add("@f0010_col_nit", NpgsqlDbType.Varchar).Value = orow_dg.Cells.Item("nit").Value
        ocmd.Parameters.Add("@f0010_col_cliente", NpgsqlDbType.Varchar).Value = orow_dg.Cells.Item("cliente").Value
        ocmd.Parameters.Add("@f0010_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0010_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0010_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub
    Private Function normalizar_valor(tx_valor As String)
        'normaliza los valores de moneda para que los decimales sean con . y los indicadores de mil con ,
        Dim tx_new_valor As String = tx_valor
        If tx_valor <> "ND" Then
            Try
                tx_new_valor = CDec(tx_valor).ToString("C2")
            Catch ex As Exception
                Dim tx_aux As String = tx_valor
                tx_aux = Replace(tx_aux, ",", "#")
                tx_aux = Replace(tx_aux, ".", ",")
                tx_aux = Replace(tx_aux, "#", ".")
                tx_new_valor = CDec(tx_aux).ToString("C2")
            End Try
        End If
        Return tx_new_valor
    End Function

    Private Sub chk_paso_a_paso_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles chk_paso_a_paso.Validating
        If chk_paso_a_paso.Checked = True Then
            MsgBox("Aparecerá un mensaje para cada renglon del archivo!!!!", MsgBoxStyle.Exclamation, "Atencion")
        End If
    End Sub
End Class
