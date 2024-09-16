Public Class cl_importador_planos
    'Estructura creada para almacenar datos de items movimientos de inventario
    Public Structure info_busqueda_campo
        Public criterios_n_linea As String()
        Public valor_encontrado As String
        Public texto_futuro As String
    End Structure


    Public Shared Function importador_planos_a_datasetprueba(ByVal id_file_plano As String,
                                                       ByVal visualizar_datatables As String,
                                                       ByVal vg_id_cia As String,
                                                       ByVal vg_usuario_autoriza As String,
                                                       ByVal path_file As String)
        'visualizar_datatables  "S" or "N"
        Dim ds As DataSet = New DataSet("datos")
        Dim csql As String = ""
        Dim otb_encabezado As DataTable
        Dim otb_detalle As DataTable
        Dim ocolum_referencial As Integer 'Para identificar que campo del encabezado sera usado como referencial en los detalles
        Dim id_linea_leida As Integer
        Dim oencabezado() As String  '= {({"128", "15", "*-[A-Z][A-Z]-*", "128", "15"}), ({"128", "12", "####-[A-Z][A-Z][A-Z]-##", "128", "12"})}
        Dim odetalle() As String
        Dim otb_txt_ref As DataTable
        Dim otb_secciones As DataTable
        Dim criterios_n_linea() As String
        Dim texto_futuro As String = "N"
        Dim resultado_busqueda As info_busqueda_campo = Nothing


        'Agrego las tablas al dataset
        otb_txt_ref = ds.Tables.Add("otb_referenciados")
        otb_encabezado = ds.Tables.Add("otb_encabezado")
        otb_detalle = ds.Tables.Add("otb_detalle")
        'otb_secciones = ds.Tables.Add("otb_secciones")

        'Estructuro las tablas
        'otb_encabezado = Nothing

        'cargo la estructura del encabezado
        csql = "select * FROM " & database.obtener_esquema & ".tb0012_config_read_cg" _
             & " where f0012_archivo ='" & id_file_plano & "'"
        Dim otb_ppal As DataTable
        Dim id_config As Integer
        otb_ppal = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_ppal.Rows
            'separo el texto en las partes que definen cada valor a buscar
            oencabezado = orow("f0012_configuraciones").ToString.Split("┴")
            ocolum_referencial = orow("f0012_col_referencial")
            id_config = orow("f0012_id_config")
            'MsgBox(oencabezado.Length)
        Next
        'otb_encabezado = crear_tabla("otb_encabezado", oencabezado).copy()
        ds = crear_tablas(ds, "otb_encabezado", oencabezado, "N")

        'cargo la estructura de los detalles
        csql = "select * FROM " & database.obtener_esquema & ".tb0013_config_read_cg_detalles" _
             & " where f0013_id_config ='" & id_config & "'"
        otb_secciones = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'creo las datatables en el dataset

        For Each orow As DataRow In otb_secciones.Rows
            ds.Tables.Add(orow("f0013_name_datatable"))
            odetalle = orow("f0013_configuraciones").ToString.Split("┴")
            ds = crear_tablas(ds, orow("f0013_name_datatable").ToString, odetalle, "S")
        Next

        'creo la estructura de la tabla que contendra las coordenadas de los textos a buscar definidos
        'en la lectura de lineas anteriores
        'otb_txt_ref = New DataTable

        otb_txt_ref.Columns.Add("id_linea_leida", GetType(Integer))
        otb_txt_ref.Columns.Add("ini_txt", GetType(Integer))
        otb_txt_ref.Columns.Add("fin_txt", GetType(Integer))
        otb_txt_ref.Columns.Add("otabla", GetType(String))
        otb_txt_ref.Columns.Add("ocampo", GetType(String))
        otb_txt_ref.Columns.Add("valor_referencial", GetType(String))
        otb_txt_ref.Columns.Add("orow", GetType(Integer))

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'seccion para probar que se estructuraron las datatables
        Dim tx As String = ""
        For Each otable As DataTable In ds.Tables
            tx = tx & otable.TableName & " campos: " & otable.Columns.Count & vbCrLf
            For Each ocolum As DataColumn In otable.Columns
                tx = tx & " --- " & ocolum.ColumnName & vbCrLf
            Next
            'MsgBox(otable.TableName)
        Next
        tx = tx & ds.Tables.Count
        'MsgBox(tx)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim lector As New IO.StreamReader(path_file, System.Text.Encoding.UTF7)
        'Dim lector As New IO.StreamReader(path_file)
        ' Leer el contenido mientras no se llegue al final

        Dim txt_info As String = ""
        Dim contador_exitos As Integer = 0
        Dim contador_fallas As Integer = 0
        Dim bloqueo_actualizacion As String = "N"
        Dim pagina_extra As String = "N"
        Dim conteo_pagina_extra As Integer = 0
        Dim txt_testCheck As Boolean = False
        Dim txt_verificador As String = ""
        Dim oconfigpartes() As String
        Dim valor_encontrado As String = ""
        Dim valor_referencial As String = ""
        Dim oconfig_secc() As String
        Dim otabla_name As String = ""

        'defino los objetos que seran anexados como datarow en los datatable
        Dim array_val_encabezado(oencabezado.GetUpperBound(0)) As Object
        Dim array_val_detalle(odetalle.GetUpperBound(0) + 1) As Object

        id_linea_leida = 1

        '128; 12; *-[A-Z][A-Z]-*; 128; 15 | 128; 12; ####-[A-Z][A-Z][A-Z]-##; 128; 12
        While lector.Peek() <> -1
            'Dim linea As String = Replace(lector.ReadLine(), "\'d1", "Ñ")
            Dim linea As String = lector.ReadLine()
            ' Si no está vacía, añadirla al control
            ' Si está vacía, continuar el bucle
            If String.IsNullOrEmpty(linea) Then
                MsgBox("ojo")
                Continue While
            End If
            'MsgBox(linea)

            'busco datos del encabezado
            Dim orows_datable_actual As Integer
            orows_datable_actual = ds.Tables("otb_encabezado").Rows.Count
            For index = 0 To oencabezado.GetUpperBound(0)
                'MsgBox(oencabezado(index).ToString)
                'MsgBox(oencabezado.GetUpperBound(0))
                oconfigpartes = oencabezado(index).ToString.Split(";")
                'MsgBox(linea & vbCrLf & vbCrLf & oencabezado(index).ToString)
                resultado_busqueda = buscar_campo(linea, oconfigpartes)
                valor_encontrado = resultado_busqueda.valor_encontrado
                texto_futuro = resultado_busqueda.texto_futuro
                criterios_n_linea = resultado_busqueda.criterios_n_linea
                If valor_encontrado <> "" Then
                    'MsgBox(valor_encontrado)
                    'MsgBox("Indice actual: " & index & "total de campos. " & oencabezado.GetUpperBound(0))
                    'MsgBox(oconfigpartes(0))
                    'MsgBox(oencabezado(index).ToString & vbCrLf & oconfigpartes(0) & ": " & valor_encontrado)
                    'identifico si es la columna referencial
                    If index = ocolum_referencial Then
                        valor_referencial = valor_encontrado
                        'MsgBox(valor_referencial)
                    End If
                    array_val_encabezado(index) = valor_encontrado
                    If index = oencabezado.GetUpperBound(0) Then
                        'MsgBox("LLegue al ultimo")
                        Try
                            otb_encabezado.Rows.Add(array_val_encabezado)
                            'MsgBox(otb_encabezado.Rows.Count)
                        Catch ex As Exception

                        End Try
                        'MsgBox("se lleno el encabezado #: " & otb_encabezado.Rows.Count)
                    End If
                    'linea y posicion de la que se traera un texto en las siguientes lecturas de linea
                    If texto_futuro = "S" Then
                        'orow = otb_encabezado.Rows.Count
                        Dim otb_orow As DataRow
                        otb_orow = ds.Tables("otb_referenciados").NewRow
                        otb_orow("id_linea_leida") = criterios_n_linea(7) + id_linea_leida
                        otb_orow("ini_txt") = criterios_n_linea(5)
                        otb_orow("fin_txt") = criterios_n_linea(6)
                        otb_orow("otabla") = "otb_encabezado"
                        otb_orow("ocampo") = criterios_n_linea(0)
                        otb_orow("valor_referencial") = valor_referencial
                        otb_orow("orow") = orows_datable_actual + 1
                        ds.Tables("otb_referenciados").Rows.Add(otb_orow)
                        'MsgBox("Total de textos adelante: " & ds.Tables("otb_referenciados").Rows.Count)
                        'MsgBox("anexo: " & criterios_n_linea(0))
                    End If
                End If

            Next

            'Al identificar texto que indica inicio de seccion configuro los valores que controlan la captura
            'recorro el datatable de las secciones para buscar una coincidencia.


aaa:
            'Actualizo los valores para los registros referenciados anteriormente
            'buscar_texto_referenciado(id_linea_leida, linea)
            Dim oview As New DataView(otb_txt_ref, "id_linea_leida = '" & id_linea_leida & "'",
                                  "", DataViewRowState.CurrentRows)
            If oview.Count > 0 Then
                For Each orow As DataRowView In oview
                    Try
                        ds.Tables(orow("otabla").ToString)(CInt(orow("orow")) - 1)(orow("ocampo").ToString) =
                                         Mid(linea, CInt(orow("ini_txt")), CInt(orow("fin_txt"))).Trim
                        'cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "otb_txt_ref", {}, otb_txt_ref,,,,,,, "N")
                        'MsgBox("hola")
                    Catch ex As Exception

                    End Try

                    'MsgBox(orow("otabla"))
                Next
                'cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Encabezado", {}, otb_encabezado,,,,,,, "N")
                'MsgBox("Actualizado")
            End If


            'Incremento el contador de lineas leidas
            id_linea_leida += 1
        End While


        'MsgBox("Encabezado: " & otb_encabezado.Rows.Count)
        ' Cerrar el fichero
        lector.Close()
        MsgBox(id_linea_leida)
        'MsgBox("secciones ds: " & ds.Tables("otb_secciones").Rows.Count)
        'MsgBox("secciones datatable: " & otb_secciones.Rows.Count)
        ds.Tables.Add("otb_secciones")
        ds.Tables("otb_secciones").Merge(otb_secciones)

        If visualizar_datatables = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Encabezado", {}, otb_encabezado,,,,,,, "N")
            ''''cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Detalle", {}, otb_detalle,,,,,,, "N")
            ''''cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "busquedas", {}, otb_txt_ref,,,,,,, "N")
            For Each orow As DataRow In otb_secciones.Rows
                cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, orow("f0013_name_datatable").ToString, {}, ds.Tables(orow("f0013_name_datatable").ToString),,,,,,, "N")
            Next
            ''''Else
            ''''Me.Dispose()
        End If
        'MsgBox("hola")
        Return ds.Copy()
    End Function


    Public Shared Function importador_planos_a_dataset(ByVal file_plano As String,
                                                       ByVal visualizar_datatables As String,
                                                       ByVal vg_id_cia As String,
                                                       ByVal vg_usuario_autoriza As String,
                                                       ByVal path_file As String)

        'Es necesario que el primer valor dentro de la cadena de configuracion de los campos f0012_configuraciones
        'se el campo que indica el pk o valor referencial

        'visualizar_datatables  "S" or "N"
        Dim ds As DataSet = New DataSet("datos")
        Dim csql As String = ""
        Dim otb_encabezado As DataTable
        Dim seccion_continua As String = "N"
        Dim tipo_seccion As Integer
        Dim linea_inicio_seccion_continua As Integer = 0
        Dim orow_definicion_secc_continua As DataRow = Nothing

        'No uso ocolum_referencial ya que he desidido que el primer valor a encontrar es el pk o valor referencial
        'Entonces simpre sera la posicion 0
        Dim id_linea_leida As Integer
        Dim oencabezado() As String
        Dim odetalle() As String
        Dim oPkadicionalesDetalle As String ' columnas que seran anexadas a la tabla detalles y registraran los valores actuales en la tabla de encabezado
        Dim otb_txt_ref As DataTable
        Dim otb_secciones As DataTable
        Dim criterios_n_linea() As String
        Dim texto_futuro As String = "N"
        Dim resultado_busqueda As info_busqueda_campo = Nothing

        'Agrego las tablas al dataset
        otb_txt_ref = ds.Tables.Add("otb_referenciados") 'Contiene los parametros que definen y encuentran los textos futuros
        otb_encabezado = ds.Tables.Add("otb_encabezado")

        'Estructuro las tablas
        'cargo la estructura del encabezado
        csql = "select * FROM " & database.obtener_esquema & ".tb0012_config_read_cg" _
             & " where f0012_archivo ='" & file_plano & "'"
        Dim otb_ppal As DataTable
        Dim id_config As Integer
        otb_ppal = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_ppal.Rows
            'separo el texto en las partes que definen cada valor a buscar
            oencabezado = orow("f0012_configuraciones").ToString.Split("┴")
            id_config = orow("f0012_id_config")
        Next
        ds = crear_tablas(ds, "otb_encabezado", oencabezado, "N")

        'cargo la estructura de los detalles
        csql = "select * FROM " & database.obtener_esquema & ".tb0013_config_read_cg_detalles" _
             & " where f0013_id_config ='" & id_config & "'"
        otb_secciones = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_secciones.Rows
            ds.Tables.Add(orow("f0013_name_datatable"))
            odetalle = orow("f0013_configuraciones").ToString.Split("┴")
            oPkadicionalesDetalle = orow("f0013_pk_multiple").ToString
            ds = crear_tablas(ds, orow("f0013_name_datatable").ToString, odetalle, "S", oPkadicionalesDetalle, otb_encabezado)
        Next



        'creo la estructura de la tabla que contendra las coordenadas de los textos futuros definidos
        'en la lectura de lineas anteriores
        otb_txt_ref.Columns.Add("id_linea_leida", GetType(Integer))
        otb_txt_ref.Columns.Add("ini_txt", GetType(Integer))
        otb_txt_ref.Columns.Add("fin_txt", GetType(Integer))
        otb_txt_ref.Columns.Add("otabla", GetType(String))
        otb_txt_ref.Columns.Add("ocampo", GetType(String))
        otb_txt_ref.Columns.Add("valor_referencial", GetType(String))
        otb_txt_ref.Columns.Add("orow", GetType(Integer))


        'Inicio el proceso de lectura del archivo
        Dim lector As New IO.StreamReader(path_file, System.Text.Encoding.UTF8)
        Dim txt_info As String = ""
        Dim contador_exitos As Integer = 0
        Dim contador_fallas As Integer = 0
        Dim bloqueo_actualizacion As String = "N"
        Dim pagina_extra As String = "N"
        Dim conteo_pagina_extra As Integer = 0
        Dim txt_testCheck As Boolean = False
        Dim txt_verificador As String = ""
        Dim oconfigpartes() As String
        Dim valor_encontrado As String = ""
        Dim valor_referencial As String = ""
        Dim oconfig_secc() As String
        Dim otabla_name As String = ""
        Dim ContRowsDtActual As Integer
        'defino los objetos que seran anexados como datarow en los datatable
        Dim array_val_encabezado(oencabezado.GetUpperBound(0) + 1) As Object
        Dim array_val_detalle(odetalle.GetUpperBound(0) + 1) As Object
        'inicio la lectura del archivo
        id_linea_leida = 1
        While lector.Peek() <> -1
            Dim linea As String = Replace(lector.ReadLine(), "\'d1", "Ñ")
            If String.IsNullOrEmpty(linea) Then
                MsgBox("ojo")
                'Console.WriteLine(linea)
                Continue While
            End If
            If (Mid(linea.ToString, 1, 12).Trim) = "\page \u9792" Then
                'Console.WriteLine(linea)
                Continue While
            End If

            'seccion que registrara los datos de una seccion continua, no buscara valores de encabezado u otras secciones
            'hasta cuando se llegue a el indicador de que la seccion a terminado, se usara para capturar datos que se
            'encuentran en formato tabular.
#Region "Seccion de datos continuos tabulares"
            If id_linea_leida >= linea_inicio_seccion_continua And seccion_continua = "S" Then
                'Console.WriteLine(linea)
                oconfig_secc = orow_definicion_secc_continua("f0013_txt_ind_fin_seccion").ToString.Split(";")
                otabla_name = orow_definicion_secc_continua("f0013_name_datatable").ToString
                odetalle = orow_definicion_secc_continua("f0013_configuraciones").ToString.Split("┴")
                resultado_busqueda = buscar_campo(linea, oconfig_secc)
                valor_encontrado = resultado_busqueda.valor_encontrado
                If valor_encontrado <> "" Then
                    seccion_continua = "N"
                    id_linea_leida += 1
                    'Continue While
                End If
                'Aqui extraigo de cada linea los datos tabulares
                For index = 0 To odetalle.GetUpperBound(0)
                    oconfigpartes = odetalle(index).ToString.Split(";")
                    resultado_busqueda = buscar_campo(linea, oconfigpartes)
                    valor_encontrado = resultado_busqueda.valor_encontrado
                    If valor_encontrado <> "" And otabla_name <> "" Then
                        Console.WriteLine(linea)
                        'si el valor encontrado corresponde al index 0 es porque inicia nuevo registro
                        'identifico si es la columna referencial trabaja con el PK del registro
                        If index = 0 Then
                            'Agrego el nuevo datorow en la otb
                            ds.Tables(otabla_name).Rows.Add()
                            'registro valor pk y referencial
                            ContRowsDtActual = ds.Tables(otabla_name).Rows.Count
                            ds.Tables(otabla_name).Rows(ContRowsDtActual - 1)(0) = ContRowsDtActual
                            ds.Tables(otabla_name).Rows(ContRowsDtActual - 1)(1) = valor_referencial
                        End If
                        ds.Tables(otabla_name).Rows(ContRowsDtActual - 1)(index + 2) = valor_encontrado
                    End If
                Next
                'Reinicia el bucle hasta que encuentre el final de la seccion tabular
                'Continue While
            End If
#End Region
            'busco datos del encabezado
            Dim ContRowsDtEncabezado As Integer

            For index = 0 To oencabezado.GetUpperBound(0)
                oconfigpartes = oencabezado(index).ToString.Split(";")
                resultado_busqueda = buscar_campo(linea, oconfigpartes)
                valor_encontrado = resultado_busqueda.valor_encontrado
                texto_futuro = resultado_busqueda.texto_futuro
                criterios_n_linea = resultado_busqueda.criterios_n_linea
                If valor_encontrado <> "" Then
                    'si el valor encontrado corresponde al index 0 es porque inicia nuevo registro
                    'identifico si es la columna referencial trabaja con el PK del registro
                    If index = 0 Then 'If index = ocolum_referencial Then
                        Console.WriteLine(valor_encontrado)
                        valor_referencial = valor_encontrado
                        'Agrego el nuevo datorow en la otb
                        otb_encabezado.Rows.Add()
                        'registro valor pk y referencial
                        ContRowsDtEncabezado = ds.Tables("otb_encabezado").Rows.Count
                        otb_encabezado.Rows(ContRowsDtEncabezado - 1)(0) = ContRowsDtEncabezado
                        otb_encabezado.Rows(ContRowsDtEncabezado - 1)(1) = valor_referencial
                    End If
                    otb_encabezado.Rows(ContRowsDtEncabezado - 1)(index + 1) = valor_encontrado

                    'linea y posicion de la que se traera un texto en las siguientes lecturas de linea
                    If texto_futuro = "S" Then
                        Dim otb_orow As DataRow
                        otb_orow = ds.Tables("otb_referenciados").NewRow
                        otb_orow("id_linea_leida") = criterios_n_linea(7) + id_linea_leida
                        otb_orow("ini_txt") = criterios_n_linea(5)
                        otb_orow("fin_txt") = criterios_n_linea(6)
                        otb_orow("otabla") = "otb_encabezado"
                        otb_orow("ocampo") = criterios_n_linea(0)
                        otb_orow("valor_referencial") = valor_referencial
                        otb_orow("orow") = ContRowsDtEncabezado
                        ds.Tables("otb_referenciados").Rows.Add(otb_orow)
                    End If
                End If
            Next

            'Al identificar texto que indica inicio de seccion configuro los valores que controlan la captura
            'recorro el datatable de las secciones para buscar una coincidencia.
            For Each orow As DataRow In otb_secciones.Rows
                oconfig_secc = orow("f0013_txt_ind_ini_seccion").ToString.Split(";")
                resultado_busqueda = buscar_campo(linea, oconfig_secc)
                valor_encontrado = resultado_busqueda.valor_encontrado
                texto_futuro = resultado_busqueda.texto_futuro
                criterios_n_linea = resultado_busqueda.criterios_n_linea
                If valor_encontrado <> "" Then
                    odetalle = orow("f0013_configuraciones").ToString.Split("┴")
                    otabla_name = orow("f0013_name_datatable").ToString
                    tipo_seccion = orow("f0013_tipo_seccion")
                    'inicializamos la lectura de secciones continuas en formato tabular
                    If orow("f0013_tipo_seccion") = 2 Then
                        seccion_continua = "S"
                        linea_inicio_seccion_continua = id_linea_leida + oconfig_secc(7)
                        orow_definicion_secc_continua = orow
                        Console.Write(linea)
                    End If
                    Exit For
                End If
            Next

            'Si la seccion que esta activa es continua entonces no debo hacer nada mas y seguir leyendo el archivo
            'hasta que se identifiquen los textos futuros pendientes o se inicialice una nueva seccion
            'recuerde que las secciones no pueden estar traslapadas
            If seccion_continua = "N" Then
                'busco datos del detalle
                Dim ini_registro As String = "N"
                For index = 0 To odetalle.GetUpperBound(0)
                    oconfigpartes = odetalle(index).ToString.Split(";")
                    resultado_busqueda = buscar_campo(linea, oconfigpartes)
                    valor_encontrado = resultado_busqueda.valor_encontrado
                    texto_futuro = resultado_busqueda.texto_futuro
                    criterios_n_linea = resultado_busqueda.criterios_n_linea
                    If valor_encontrado <> "" And otabla_name <> "" And tipo_seccion <> 2 Then
                        'Console.WriteLine(linea)
                        'si el valor encontrado corresponde al index 0 es porque inicia nuevo registro
                        'identifico si es la columna referencial trabaja con el PK del registro
                        If index = 0 Then 'If index = ocolum_referencial Then
                            'valor_referencial = valor_encontrado
                            'Agrego el nuevo datorow en la otb
                            ds.Tables(otabla_name).Rows.Add()
                            'registro valor pk y referencial
                            ContRowsDtActual = ds.Tables(otabla_name).Rows.Count
                            ds.Tables(otabla_name).Rows(ContRowsDtActual - 1)(0) = ContRowsDtActual
                            ds.Tables(otabla_name).Rows(ContRowsDtActual - 1)(1) = valor_referencial
                        End If
                        ds.Tables(otabla_name).Rows(ContRowsDtActual - 1)(index + 2) = valor_encontrado
                        '' voy a buscar los valores del ultimo regsitro de la tabla encabezado para llenar
                        '' los valores de los campos pk varios
                        Dim orow_ultimo_encabezado As DataRow
                        orow_ultimo_encabezado = otb_encabezado.Rows.Item(otb_encabezado.Rows.Count - 1)
                        Dim NombreCampoOtbEncabezado As String
                        Dim IndiceTablaDetalle As Integer
                        Dim ValorCampoTablaEncabezado As String

                        'SECCION PARA LLENAR EN TABLA DETALLES VALORES DESDE LA TABLA ENCABEZADO
                        'Cuando requiero que aparezcen en la tabla detalles algunos valores tomados desde el ultimo datarow
                        'de la tabla enbezado, esto es cuando el indentificador requiere que sean varios campos y no solo la columna 
                        'referencial
                        If oPkadicionalesDetalle <> "" Then
                            Dim ocoladicionales() As String
                            ocoladicionales = oPkadicionalesDetalle.ToString.Split(";")
                            For index2 = 0 To ocoladicionales.GetUpperBound(0)
                                NombreCampoOtbEncabezado = otb_encabezado.Columns.Item(CInt(ocoladicionales(index2)) - 1).ColumnName
                                ValorCampoTablaEncabezado = orow_ultimo_encabezado(NombreCampoOtbEncabezado).ToString
                                IndiceTablaDetalle = ds.Tables(otabla_name).Columns.Item(NombreCampoOtbEncabezado).Ordinal
                                ds.Tables(otabla_name).Rows(ContRowsDtActual - 1)(IndiceTablaDetalle) = ValorCampoTablaEncabezado
                                'MsgBox(NombreCampoOtbEncabezado)
                                'MsgBox(otb_encabezado.Columns.Item(CInt(oPkadicionalesDetalle(index)) - 1).ColumnName)
                                'MsgBox(otb_encabezado.Columns.Item(CInt(oPkadicionalesDetalle(index)) - 1).GetType.ToString)
                            Next
                        End If

                        'Busco los textos futuros
                        If texto_futuro = "S" Then
                            'orow = otb_encabezado.Rows.Count
                            Dim otb_orow As DataRow
                            otb_orow = ds.Tables("otb_referenciados").NewRow
                            otb_orow("id_linea_leida") = criterios_n_linea(7) + id_linea_leida
                            otb_orow("ini_txt") = criterios_n_linea(5)
                            otb_orow("fin_txt") = criterios_n_linea(6)
                            otb_orow("otabla") = otabla_name
                            otb_orow("ocampo") = criterios_n_linea(0)
                            otb_orow("valor_referencial") = valor_referencial
                            otb_orow("orow") = ds.Tables(otabla_name).Rows.Count
                            ds.Tables("otb_referenciados").Rows.Add(otb_orow)
                            'MsgBox("Total de textos adelante: " & ds.Tables("otb_referenciados").Rows.Count)
                            'MsgBox("anexo: " & criterios_n_linea(0))
                        End If
                    End If
                Next

            End If


            'Actualizo los valores para los registros referenciados anteriormente como textos futuros y que coinciden
            'con la linea que se esta leyendo actualemnte
            Dim oview As New DataView(otb_txt_ref, "id_linea_leida = '" & id_linea_leida & "'",
                                       "", DataViewRowState.CurrentRows)
            If oview.Count > 0 Then
                For Each orow As DataRowView In oview
                    Dim a As Integer = ds.Tables(orow("otabla")).Columns(orow("ocampo")).Ordinal
                    ds.Tables(orow("otabla")).Rows(orow("orow") - 1)(a) = Mid(linea, CInt(orow("ini_txt")), CInt(orow("fin_txt"))).Trim
                Next

                Dim expression As String
                expression = " id_linea_leida = '" & id_linea_leida & "'"
                Dim foundRows() As DataRow

                ' Use the Select method to find all rows matching the filter.
                foundRows = otb_txt_ref.Select(expression)

                Dim i As Integer
                ' Print column 0 of each returned row.
                For i = 0 To foundRows.GetUpperBound(0)
                    'Console.WriteLine(foundRows(i)(0))
                    foundRows(i).Delete()
                Next i


            End If

            'Incremento el contador de lineas leidas
            id_linea_leida += 1
        End While

        ' Cerrar el fichero
        lector.Close()

        'MsgBox("secciones ds: " & ds.Tables("otb_secciones").Rows.Count)
        'MsgBox("secciones datatable: " & otb_secciones.Rows.Count)
        ds.Tables.Add("otb_secciones")
        ds.Tables("otb_secciones").Merge(otb_secciones)


        'visualizar_datatables = "N"

        If visualizar_datatables = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Encabezado", {}, otb_encabezado,,,,,,, "N")
            ''''cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Detalle", {}, otb_detalle,,,,,,, "N")
            ''''cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "busquedas", {}, otb_txt_ref,,,,,,, "N")
            For Each orow As DataRow In otb_secciones.Rows
                cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, orow("f0013_name_datatable").ToString, {}, ds.Tables(orow("f0013_name_datatable").ToString),,,,,,, "N")
            Next
            ''''Else
            ''''Me.Dispose()
        End If

        MsgBox("Se cargaron: " & id_linea_leida & " Lineas, Inicia actualizacion de datos")
        Return ds.Copy()
    End Function
    Public Shared Sub CopiarDatatableToPostgresql(dtable As DataTable, dtableDestino As String, csql As String,
                                                  Optional elimcol As String = "S", Optional OnConflict As String = "")
        'La datatable que se va a insertar debe tener la misma estructura que se optiene con la instruccion select
        'La instruccion select es solamente para configurar la estructura asi que debe generar un dt vacio sin datos

        Dim oconn_form As NpgsqlConnection
        Dim oadapter As NpgsqlDataAdapter
        Dim ds As DataSet = New DataSet()

        oconn_form = database.obtener_conexion
        oadapter = New NpgsqlDataAdapter(csql, oconn_form)

        'creo una datatable con el select para identificar las columnas
        Dim dtestructura As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        Dim p1 As String = String.Empty
        Dim p2 As String = String.Empty
        For Each ocolumna As DataColumn In dtestructura.Columns
            p1 += ocolumna.ColumnName
            p2 += ":" & ocolumna.ColumnName
            If ocolumna.Ordinal < dtestructura.Columns.Count - 1 Then
                p1 += ","
                p2 += ","
            End If
        Next
        csql = "INSERT INTO " & database.obtener_esquema & "." & dtableDestino & "("
        csql += p1 & ") VALUES ("
        csql += p2 & ")"

        If OnConflict <> "" Then
            csql += OnConflict
        End If

        Console.Write(csql)

        'If OnConflict = "S" Then
        '    csql += " ON CONFLICT (" & dtestructura.Columns(0).ColumnName & ") DO UPDATE " & database.obtener_esquema & "." & dtableDestino & " AS tbupdate SET "
        '    For Each ocolumna As DataColumn In dtestructura.Columns
        '        If ocolumna.Ordinal > 1 Then
        '            p1 = "tbupdate." & ocolumna.ColumnName & " = " & ":" & ocolumna.ColumnName
        '            csql += p1
        '            If ocolumna.Ordinal < dtestructura.Columns.Count - 1 Then
        '                csql += ","
        '            End If
        '        End If

        '    Next
        '    csql += " Where tbupdate." & dtestructura.Columns(0).ColumnName & " = :" & dtestructura.Columns(0).ColumnName

        'End If
        'Console.WriteLine("Tengo las columnas")

        'csql = "INSERT INTO camocontrol.tb0405_det_prod_ip_cg_umpr4015_9(" _
        '    & " f0405_ip_num, f0405_referencia, f0405_descripcion, f0405_localizacion," _
        '    & " f0405_unidad, f0405_cant_prod, f0405_costo_prod, f0405_lote)" _
        '    & " VALUES (:ip, :ref, :desc, :loc, :und, :cant, :cost, :lot)"
        oadapter.InsertCommand = New NpgsqlCommand(csql, oconn_form)
        Dim npgtype As NpgsqlDbType
        For Each ocolumna As DataColumn In dtestructura.Columns
            Console.WriteLine(ocolumna.DataType.Name.ToString)
            Select Case ocolumna.DataType.Name.ToString
                Case "String"
                    npgtype = NpgsqlDbType.Varchar
                Case "Decimal"
                    npgtype = NpgsqlDbType.Numeric
                Case "DateTime"
                    npgtype = NpgsqlDbType.Timestamp
                Case Else
                    MsgBox("npgtype no definido")
            End Select
            oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter(ocolumna.ColumnName, npgtype))
        Next
        'oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter("ip", NpgsqlDbType.Varchar))
        'oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter("ref", NpgsqlDbType.Varchar))
        'oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter("desc", NpgsqlDbType.Varchar))
        'oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter("loc", NpgsqlDbType.Varchar))
        'oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter("und", NpgsqlDbType.Varchar))
        'oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter("cant", NpgsqlDbType.Numeric))
        'oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter("cost", NpgsqlDbType.Numeric))
        'oadapter.InsertCommand.Parameters.Add(New NpgsqlParameter("lot", NpgsqlDbType.Varchar))

        For i = 0 To dtestructura.Columns.Count - 1
            oadapter.InsertCommand.Parameters(i).Direction = ParameterDirection.Input
        Next
        'oadapter.InsertCommand.Parameters(0).Direction = ParameterDirection.Input
        'oadapter.InsertCommand.Parameters(1).Direction = ParameterDirection.Input
        'oadapter.InsertCommand.Parameters(2).Direction = ParameterDirection.Input
        'oadapter.InsertCommand.Parameters(3).Direction = ParameterDirection.Input
        'oadapter.InsertCommand.Parameters(4).Direction = ParameterDirection.Input
        'oadapter.InsertCommand.Parameters(5).Direction = ParameterDirection.Input
        'oadapter.InsertCommand.Parameters(6).Direction = ParameterDirection.Input
        'oadapter.InsertCommand.Parameters(7).Direction = ParameterDirection.Input

        For i = 0 To dtestructura.Columns.Count - 1
            oadapter.InsertCommand.Parameters(i).SourceColumn = dtestructura.Columns(i).ColumnName
        Next
        'oadapter.InsertCommand.Parameters(0).SourceColumn = "f0405_ip_num"
        'oadapter.InsertCommand.Parameters(1).SourceColumn = "f0405_referencia"
        'oadapter.InsertCommand.Parameters(2).SourceColumn = "f0405_descripcion"
        'oadapter.InsertCommand.Parameters(3).SourceColumn = "f0405_localizacion"
        'oadapter.InsertCommand.Parameters(4).SourceColumn = "f0405_unidad"
        'oadapter.InsertCommand.Parameters(5).SourceColumn = "f0405_cant_prod"
        'oadapter.InsertCommand.Parameters(6).SourceColumn = "f0405_costo_prod"
        'oadapter.InsertCommand.Parameters(7).SourceColumn = "f0405_lote"

        oadapter.Fill(ds)

        Dim newdt As DataTable = ds.Tables(0)

        If elimcol = "S" Then
            'cambio la estructura de la datable para que coincida con la estructura del dataset
            dtable.Columns.Remove(dtable.Columns.Item(0).ColumnName)
            'Console.WriteLine("columna quitada")
        End If
        'Para que las dt se puedan copiar deben tener la misma estrcutura
        For i = 0 To dtable.Columns.Count - 1
            dtable.Columns.Item(i).ColumnName = ds.Tables(0).Columns.Item(i).ColumnName
        Next
        'Console.Write("Columnas renombradas")

        'Copio la datatable en el dt del dataset para proceder a actualizar los datos
        ds.Tables.Add(dtable.Copy())
        ds.Tables(0).Merge(ds.Tables(1))
        Console.Write("Datos copiados")

        'orow(1) = "a"
        'newdt.Rows.Add(orow)
        'orow = newdt.NewRow()
        'orow(1) = "b"
        'newdt.Rows.Add(orow)

        'Actualizo el dataset
        Dim ds2 As DataSet = ds.GetChanges()

        oadapter.Update(ds2)
        ds.Merge(ds2)
        ds.AcceptChanges()

        oconn_form.Close()

    End Sub
    Public Shared Function crear_tablas(ByVal ds As DataSet, ByVal otabla As String, ByVal oarray() As String,
                                        Optional ByVal col_vinculante As String = "N",
                                        Optional ByVal pkAdicionales As String = "",
                                        Optional ByVal otb_encabezado As DataTable = Nothing)
        Dim odatatable = ds.Tables(otabla)
        'Dim odatatable As New DataTable
        'Creo la estructura que tendran las tablas que almacenaran los datos
        Dim oconfigpartes As String()
        'creo estructura tabla encabezado
        'otb_encabezado = New DataTable
        odatatable.Columns.Add("pk", GetType(Integer))
        If col_vinculante = "S" Then
            odatatable.Columns.Add("id_referencial", GetType(String))
        End If
        For index = 0 To oarray.GetUpperBound(0)
            oconfigpartes = oarray(index).ToString.Split(";")
            Select Case oconfigpartes(1)
                Case "text"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(String))
                Case "numeric"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(Decimal))
                Case "SepDec0"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(Decimal))
                Case "SepDec1"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(Decimal))
                Case "SepDec2"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(Decimal))
                Case "date"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(Date))
                Case Else
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(String))
            End Select
        Next

        If pkAdicionales <> "" Then
            'MsgBox(otb_encabezado.Rows.Count)
            'Anexo las columnas pk de la tabla encabezado que seran usadas para relacionar tablas
            Dim oPkadicionalesDetalle() As String
            oPkadicionalesDetalle = pkAdicionales.ToString.Split(";")
            For index = 0 To oPkadicionalesDetalle.GetUpperBound(0)
                odatatable.Columns.Add(otb_encabezado.Columns.Item(CInt(oPkadicionalesDetalle(index)) - 1).ColumnName,
                                       GetType(String))
                'MsgBox(otb_encabezado.Columns.Item(CInt(oPkadicionalesDetalle(index)) - 1).ColumnName)
                'MsgBox(otb_encabezado.Columns.Item(CInt(oPkadicionalesDetalle(index)) - 1).GetType.ToString)
            Next
        End If

        'MsgBox("columnas. " & odatatable.Columns.Count)
        Return ds
        'Return odatatable
    End Function
    Public Shared Function buscar_campo(ByVal l_texto As String, ByVal criterios As String())
        Dim txt_testCheck As Boolean = False
        Dim txt_verificador As String = String.Empty
        Dim valor_encontrado As String = String.Empty
        Dim info_busqueda As info_busqueda_campo = Nothing

        txt_verificador = Mid(l_texto, criterios(2).Trim, criterios(3).Trim).Trim
        'Esta primera parte valida que corresponda con el formato definido
        Select Case criterios(4).Trim
            Case "$t-numeric$"
                If IsNumeric(txt_verificador.Trim) = True Then
                    valor_encontrado = txt_verificador
                End If
            Case "$t-text$"
                If IsNumeric(txt_verificador) = False Then
                    valor_encontrado = txt_verificador
                End If
            Case Else
                txt_testCheck = txt_verificador Like criterios(4).Trim
                If txt_testCheck = True Then
                    valor_encontrado = Mid(l_texto, criterios(5).Trim(), criterios(6).Trim()).Trim
                    If CInt(criterios(7) > 0) Then
                        valor_encontrado = "-1"
                    End If
                End If
        End Select
        'Esta seccion formatea el valor encontrado de acuerdo a la necesidad
        info_busqueda.valor_encontrado = valor_encontrado
        If valor_encontrado <> "" Then
            Select Case criterios(1)
                Case "date"
                    info_busqueda.valor_encontrado = formatear_fecha(valor_encontrado)
                Case "SepDec0"
                    'valor_encontrado = Replace(valor_encontrado, ",", "")
                    ''valor_encontrado = Replace(valor_encontrado, ".", ",")
                    info_busqueda.valor_encontrado = valor_encontrado
                Case "SepDec1"
                    valor_encontrado = Replace(valor_encontrado, ",", "")
                    info_busqueda.valor_encontrado = valor_encontrado
                Case "SepDec2"
                    valor_encontrado = Replace(valor_encontrado, ".", "")
                    info_busqueda.valor_encontrado = valor_encontrado
            End Select
        End If
        'Esta seccion indica que es un texto futuro
        If CInt(criterios(7) > 0) Then
            info_busqueda.texto_futuro = "S"
            info_busqueda.criterios_n_linea = criterios
        Else
            info_busqueda.texto_futuro = "N"
        End If
        Return info_busqueda
    End Function
    Public Shared Function formatear_fecha(ByVal txt As String)
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

    Public Shared Sub cargar_informe_produccion_ip(ByVal vg_id_cia As String, ByVal vg_usuario_autoriza As String)
        Dim id_file_plano As String = "UMPR4015"

        'Importo las tablas encabezado y detalle generadas de la importacion del plano

        Dim openFileDialog1 As New OpenFileDialog()
        Dim path_file As String = ""

        'openFileDialog1.InitialDirectory = "e: \"
        openFileDialog1.Filter = "csv files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*" 'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.Title = "Buscar Archivo " & id_file_plano
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path_file = openFileDialog1.FileName
            'comunes.mostrar_archivo_texto(path_file, "")
        Else
            Exit Sub
        End If

        Dim ds As DataSet = cl_importador_planos.importador_planos_a_dataset(id_file_plano, "N", vg_id_cia, vg_usuario_autoriza, path_file)

        If IsNothing(ds) = True Then
            Exit Sub
        End If

        Dim csql As String

        csql = "SELECT f0405_ip_num, f0405_fecha, f0405_operacion, f0405_cproductivo,"
        csql += "f0405_descr_operacion, f0405_unidad, f0405_hh, f0405_cost_mo,"
        csql += "f0405_costos_variables, f0405_costo_subcontrat, f0405_costo_tot_transf,"
        csql += "f0405_costo_mpme, f0405_costo_total"
        csql += " From " & database.obtener_esquema & ".tb0405_encabezado_ip_cg_umpr4015_9;"



        'nO ESTA HACIENDO NADA EL csqlOnConflict
        Dim csqlOnConflict As String = String.Empty
        csqlOnConflict = " ON CONFLICT (f0405_ip_num) DO UPDATE"
        csqlOnConflict = "SET dname = EXCLUDED.dname || ' (formerly ' || d.dname || ')'"
        csqlOnConflict = "WHERE d.zipcode <> '21201'"
        CopiarDatatableToPostgresql(ds.Tables("otb_encabezado"), "tb0405_encabezado_ip_cg_umpr4015_9", csql)

        csql = "SELECT f0406_ip_num, f0406_referencia, f0406_descripcion, f0406_localizacion,"
        csql += " f0406_unidad, f0406_cant_prod, f0406_costo_prod, f0406_lote"
        csql += " From " & database.obtener_esquema & ".tb0406_det_prod_ip_cg_umpr4015_9"
        csql += " where f0406_id = -1"
        CopiarDatatableToPostgresql(ds.Tables("produccion"), "tb0406_det_prod_ip_cg_umpr4015_9", csql)

        csql = "SELECT f0407_ip_num, f0407_referencia, f0407_descripcion,"
        csql += "f0407_unidad, f0407_cant_cons, f0407_costo_unit, f0407_costo_tot,"
        csql += "f0407_lote"
        csql += " From " & database.obtener_esquema & ".tb0407_det_cons_ip_cg_umpr4015_9"
        csql += " where f0407_id = -1"
        CopiarDatatableToPostgresql(ds.Tables("consumos"), "tb0407_det_cons_ip_cg_umpr4015_9", csql)


        'Pulo los lotes y calculo valores unitarios y costos con esta funcion
        Dim otb2 As DataTable
        csql = "select * from " & database.obtener_esquema & ".fnc_ip_cguno_407_calcular_costos_y_pulir_lotes()"
        otb2 = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        'Exporto los datos en los .CSV para analsis de los interesados

        csql = "select * from " & database.obtener_esquema & ".fnc_ip_cguno_exportar_tablas_csv()"
        cl_utilidades_datatables.cargar_informacion_postgres(csql)

        MsgBox("Datos Cargados.")



        ''TODO LO SIGUIENTE NO LO USO. PERO HAY QUE VER COMO LO USAMOS.

        Exit Sub

        'Valido si las fechas de los reportes no estan cerradas en el sistema
        Dim ofecha(1) As Date
        ofecha(0) = ds.Tables("otb_encabezado").Compute("MIN(fecha)", "")
        ofecha(1) = ds.Tables("otb_encabezado").Compute("MAX(fecha)", "")

        For Each odate As Date In ofecha
            'VALIDO SI FECHA DE MOVIMIENTO ESTA HABILITADA
            Dim fechavalidada As String()
            fechavalidada = cl_utilidades_gestion_compras.ValidarFechaMovimiento(odate, vg_id_cia)
            If fechavalidada(1) = "N" Then
                MsgBox(fechavalidada(2), MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
        Next

        'Dim csql As String = ""
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        Dim ocmd As New NpgsqlCommand

        csql = "select * from " & database.obtener_esquema & ".tb0300_items"
        csql += " where f0300_id_cia = '" & vg_id_cia & "' and f0300_anulado = 'N'"
        Dim otb_items As DataTable
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim item_camo As Integer = 0

        csql = "select * from " & database.obtener_esquema & ".tb0005_bodegas"
        csql += " where f0005_id_cia = '" & vg_id_cia & "' and f0005_anulado = 'N'"
        Dim otb_bodegas As DataTable
        otb_bodegas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim id_bodega As Integer = 0


        For Each orow As DataRow In ds.Tables("produccion").Rows
            'MsgBox(orow("id_referencial"))
            'Identifico los valores que requiero para crear el rp
            Dim oitem As DataRow() = otb_items.Select("f0300_referencia = '" & orow("Referencia") & "'")
            If oitem.Length > 0 Then
                item_camo = oitem(0)("f0300_id_item")
            Else
                MsgBox("El item " & orow("Referencia") & " No se encuentra registrado en el CAMO")
                Exit Sub
            End If
            'identifico la bodega que corresponde al sistema camo
            Dim obodega As DataRow() = otb_bodegas.Select("f0005_cod_bodega = '" & orow("bodega") & "'")
            If obodega.Length > 0 Then
                id_bodega = obodega(0)("f0005_id_bodega")
            Else
                MsgBox("La bodega " & orow("bodega") & " No se encuentra registrado en el CAMO")
                Exit Sub
            End If
            Dim bodega_cg As String = orow("bodega")

            Dim ref_emp_ppal As String = oitem(0)("f0300_referencia_empaque")
            Dim ref_emp_sec As String = oitem(0)("f0300_referencia_empaque_alterna")
            Dim factor_conversion As Decimal = oitem(0)("f0300_facto_conv_ref_emp_alterna")
            Dim operador_conversion As String = oitem(0)("f0300_oper_conversion")
            Dim ref_emp_informe As String = orow("und")

            Dim planta As Integer = 0
            If orow("bodega") = "001-01" Then
                planta = 1
            Else
                planta = 30
            End If

            Dim oencabezado As DataRow() = ds.Tables("otb_encabezado").Select("ip_num = '" & orow("id_referencial") & "'")
            Dim ip_cg_codigo As String = oencabezado(0)("ip_num")
            Dim oarray_ip As String() = oencabezado(0)("ip_num").ToString.Split("-")
            Dim co_cg As String = oarray_ip(0)
            Dim id_ip As Integer = oarray_ip(2)
            Dim fecha_reporte As Date = oencabezado(0)("fecha")
            Dim fecha_vencimiento As Date = fecha_reporte.AddYears(1)
            Dim produccion As Decimal = 0
            If ref_emp_informe <> ref_emp_ppal Then
                If ref_emp_sec = ref_emp_informe Then
                    If operador_conversion = "*" Then
                        produccion = orow("cantidad_prod") * factor_conversion
                    Else
                        produccion = orow("cantidad_prod") / factor_conversion
                    End If
                Else
                    MsgBox("El item: " & item_camo & " Tiene las unidades de empaque mal definidas", MsgBoxStyle.Critical, "Error")
                End If
            Else
                produccion = orow("cantidad_prod")
            End If

            Dim lote As String = orow("lote").ToString.Trim
            Dim unidad_cg As String = orow("und").ToString.Trim


            'Instancia la conexión que estará vigente para todas las operaciones CRUD
            oconn_form = database.obtener_conexion()

            'Inserción parametrizada
            csql = "INSERT INTO " & database.obtener_esquema & ".tb0402_reporte_produccion" _
                    & " (f0402_id_cia, f0402_id_prog_prod, f0402_id_ipp, f0402_fecha_produccion, f0402_turno, f0402_id_item," _
                    & " f0402_lote, f0402_lote_ip, f0402_fecha_vence, f0402_id_plantilla,f0402_h_h_programada," _
                    & " f0402_fecha_programada_ini_prod, f0402_fecha_programada_fin_prod, f0402_produccion_programada," _
                    & " f0402_cantidad_producida, f0402_tiempo_produccion, f0402_clasificador," _
                    & " f0402_horas_hombre, f0402_tree_path," _
                    & " f0402_id_maquina, f0402_tipo_registro, f0402_planta_produccion," _
                    & " f0402_co_cguno, f0402_ip_cguno, f0402_ip_cg_codigo," _
                    & " f0402_usuario_modificar, f0402_usuario_crear, f0402_fm)" _
                    & " VALUES" _
                    & " (@f0402_id_cia, @f0402_id_prog_prod, @f0402_id_ipp, @f0402_fecha_produccion, @f0402_turno, @f0402_id_item," _
                    & " @f0402_lote, @f0402_lote_ip, @f0402_fecha_vence, @f0402_id_plantilla,@f0402_h_h_programada," _
                    & " @f0402_fecha_programada_ini_prod, @f0402_fecha_programada_fin_prod, @f0402_produccion_programada," _
                    & " @f0402_cantidad_producida, @f0402_tiempo_produccion, @f0402_clasificador," _
                    & " @f0402_horas_hombre, @f0402_tree_path," _
                    & " @f0402_id_maquina, @f0402_tipo_registro, @f0402_planta_produccion," _
                    & " @f0402_co_cguno, @f0402_ip_cguno, @f0402_ip_cg_codigo," _
                    & " @f0402_usuario_modificar, @f0402_usuario_crear, @f0402_fm)" _
                    & " ON CONFLICT (f0402_ip_cg_codigo) DO UPDATE SET" _
                    & " f0402_usuario_modificar = @f0402_usuario_modificar," _
                    & " f0402_fm = @f0402_fm"


            ocmd = database.obtener_comando(oconn_form)
            ocmd.CommandText = csql
            'crear_parametros_item_prog_prod(ocmd)
            Dim fecha_act As Date = comunes.g_fechahora
            ocmd.Parameters.Clear()
            ocmd.Parameters.Add("@f0402_id_prog_prod", NpgsqlDbType.Integer).Value = 0
            ocmd.Parameters.Add("@f0402_id_ipp", NpgsqlDbType.Integer).Value = 0
            ocmd.Parameters.Add("@f0402_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
            ocmd.Parameters.Add("@f0402_id_item", NpgsqlDbType.Integer).Value = item_camo
            ocmd.Parameters.Add("@f0402_tipo_registro", NpgsqlDbType.Integer).Value = 1 '1 = rp, 2= actividad alterna
            ocmd.Parameters.Add("@f0402_planta_produccion", NpgsqlDbType.Integer).Value = planta
            ocmd.Parameters.Add("@f0402_ip_cg_codigo", NpgsqlDbType.Varchar).Value = ip_cg_codigo
            ocmd.Parameters.Add("@f0402_co_cguno", NpgsqlDbType.Varchar).Value = co_cg
            ocmd.Parameters.Add("@f0402_ip_cguno", NpgsqlDbType.Integer).Value = id_ip
            ocmd.Parameters.Add("@f0402_id_plantilla", NpgsqlDbType.Integer).Value = 0
            ocmd.Parameters.Add("@f0402_lote", NpgsqlDbType.Varchar).Value = lote
            ocmd.Parameters.Add("@f0402_lote_ip", NpgsqlDbType.Varchar).Value = lote
            ocmd.Parameters.Add("@f0402_fecha_vence", NpgsqlDbType.Timestamp).Value = fecha_vencimiento
            ocmd.Parameters.Add("@f0402_fecha_programada_ini_prod", NpgsqlDbType.Timestamp).Value = fecha_reporte
            ocmd.Parameters.Add("@f0402_fecha_programada_fin_prod", NpgsqlDbType.Timestamp).Value = fecha_reporte.AddDays(1)
            ocmd.Parameters.Add("@f0402_produccion_programada", NpgsqlDbType.Numeric).Value = produccion
            ocmd.Parameters.Add("@f0402_h_h_programada", NpgsqlDbType.Numeric).Value = 1
            ocmd.Parameters.Add("@f0402_cantidad_producida", NpgsqlDbType.Numeric).Value = produccion
            ocmd.Parameters.Add("@f0402_tiempo_produccion", NpgsqlDbType.Numeric).Value = 1
            ocmd.Parameters.Add("@f0402_horas_hombre", NpgsqlDbType.Numeric).Value = 1
            ocmd.Parameters.Add("@f0402_tree_path", NpgsqlDbType.Varchar).Value = ""
            ocmd.Parameters.Add("@f0402_fecha_produccion", NpgsqlDbType.Timestamp).Value = fecha_reporte
            'ocmd.Parameters.Add("@f0402_recorte_usado", NpgsqlDbType.Numeric).Value = tx_recorte_consumido.Text
            'ocmd.Parameters.Add("@f0402_recorte_mt_producido", NpgsqlDbType.Numeric).Value = tx_recorte_generado.Text
            'ocmd.Parameters.Add("@f0402_recorte_me_producido", NpgsqlDbType.Numeric).Value = tx_recorte_me_producido.Text
            ocmd.Parameters.Add("@f0402_turno", NpgsqlDbType.Varchar).Value = "ND"
            ocmd.Parameters.Add("f0402_clasificador", NpgsqlDbType.Varchar).Value = "ND"
            ocmd.Parameters.Add("@f0402_id_maquina", NpgsqlDbType.Integer).Value = 0
            ocmd.Parameters.Add("@f0402_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza 'vg_usuario_autoriza
            ocmd.Parameters.Add("@f0402_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
            ocmd.Parameters.Add("@f0402_fm", NpgsqlDbType.Timestamp).Value = fecha_act

            verror = "N"
            Try
                'Compila el comando en la Base de datos.
                ocmd.Prepare()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString + vbCrLf + csql)
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
            'MsgBox("HOLA")

            'Reportar la produccion

            'Identifico el rp creado
            csql = "select f0402_id_rp from " & database.obtener_esquema & ".tb0402_reporte_produccion"
            csql += " where f0402_ip_cg_codigo = '" & ip_cg_codigo & "'"
            Dim otb_rp_new As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            Dim id_rp As Integer = otb_rp_new(0)("f0402_id_rp")

            'Para identificar si el reporte de produccion ya tiene items reportados, entonces no reporto nuevamente
            csql = "select f0309_id_item"
            csql += " From " & database.obtener_esquema & ".tb0309_items_movimientos"
            csql += " join " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios"
            csql += " On f0310_id_documento = f0309_id_documento"
            csql += " where f0309_id_item = '" & item_camo & "'"
            csql += " And f0310_id_documento_origen = '" & "RP-" & id_rp & "'"
            csql += " And f0310_anulado = 'N' and f0309_anulado = 'N'"
            Dim otb_repo As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            If otb_repo.Rows.Count > 0 Then
                GoTo a1
            End If

            'Identifico el consecutivo de la nueva entrada de producto terminado o semiterminado.
            Dim nuevo_docto As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(4, vg_id_cia)
            Dim fecha_registro As DateTime = fecha_reporte ' comunes.g_fechahora
            'Creo el nuevo documento de movimiento de inventarios
            cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario("EPR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                id_bodega,
                                                                                4,
                                                                                fecha_registro,
                                                                                vg_usuario_autoriza, vg_id_cia, "RP-" & id_rp,
                                                                                ip_cg_codigo)
            'Ingreso la cantidad que se esta entrando.
            cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario("EPR-" & nuevo_docto.ToString.PadLeft(8, "0"),
                                                                                 id_bodega,
                                                                                 1,
                                                                                 item_camo,
                                                                                 produccion,
                                                                                 0,
                                                                                 fecha_registro,
                                                                                 vg_usuario_autoriza,
                                                                                 vg_id_cia,
                                                                                 0)
            'identifico el movimiento creado
            Dim id_mov_creado As Integer
            id_mov_creado = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0309_id_mov_item", "f0309_usuario_crear", vg_usuario_autoriza, "tb0309_items_movimientos")
            'Ingreso la informacion de trazabilidad
            'Instancia la conexión que estará vigente para todas las operaciones CRUD
            oconn_form = database.obtener_conexion()

            'Inserción parametrizada
            csql = "INSERT INTO " & database.obtener_esquema & ".tb0318_trazabilidad_movimientos" _
                                    & " (f0318_id_cia, f0318_id_mov_item, f0318_id_mov_docto, f0318_id_item, f0318_id_bodega, f0318_id_documento," _
                                    & " f0318_fecha_movimiento, f0318_info_trazable," _
                                    & " f0318_usuario_crear, f0318_usuario_modificar)" _
                                    & " VALUES" _
                                    & " (@f0318_id_cia, @f0318_id_mov_item, @f0318_id_mov_docto, @f0318_id_item, @f0318_id_bodega, @f0318_id_documento," _
                                    & " @f0318_fecha_movimiento, @f0318_info_trazable," _
                                    & " @f0318_usuario_crear, @f0318_usuario_modificar)"

            ocmd = database.obtener_comando(oconn_form)
            ocmd.CommandText = csql
            'crear_parametros_item_prog_prod(ocmd)
            ocmd.Parameters.Clear()
            ocmd.Parameters.Add("@f0318_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
            ocmd.Parameters.Add("@f0318_id_mov_item", NpgsqlDbType.Numeric).Value = id_mov_creado
            ocmd.Parameters.Add("@f0318_id_mov_docto", NpgsqlDbType.Numeric).Value = 1
            ocmd.Parameters.Add("@f0318_id_item", NpgsqlDbType.Integer).Value = item_camo
            ocmd.Parameters.Add("@f0318_id_bodega", NpgsqlDbType.Integer).Value = id_bodega
            ocmd.Parameters.Add("@f0318_id_documento", NpgsqlDbType.Varchar).Value = "EPR-" & nuevo_docto.ToString.PadLeft(8, "0")
            ocmd.Parameters.Add("@f0318_fecha_movimiento", NpgsqlDbType.Timestamp).Value = fecha_registro
            ocmd.Parameters.Add("@f0318_info_trazable", NpgsqlDbType.Varchar).Value = lote & " - (RP-" & id_rp & ")"
            ocmd.Parameters.Add("@f0318_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
            ocmd.Parameters.Add("@f0318_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza

            verror = "N"
            Try
                'Compila el comando en la Base de datos.
                ocmd.Prepare()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Compilar comando! " + vbCrLf + ex.ToString + vbCrLf + csql)
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

a1:

        Next
        MsgBox("FINALIZADO")
    End Sub
End Class
