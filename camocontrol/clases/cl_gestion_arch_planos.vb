Public Class cl_gestion_arch_planos

    Public Shared Function form_config_importar_plano_a_datatable(ByVal id_cia As String, ByVal id_usuario As String,
                                                      ByVal id_file_plano As String,
                                                      Optional ByVal visualizar_datos As String = "S")
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_importador_datos_txt_plano
        'oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.Text = "Texto Plano"
        oform_mostrar_datos.id_file_plano = id_file_plano
        oform_mostrar_datos.vg_id_cia = id_cia
        oform_mostrar_datos.vg_usuario_autoriza = id_usuario
        oform_mostrar_datos.visualizar_datatables = visualizar_datos
        oform_mostrar_datos.ShowDialog()
        Dim ds As DataSet
        ds = oform_mostrar_datos.ds
        oform_mostrar_datos.Hide()
        Return ds
    End Function

    Public Shared Function importar_plano_a_datatable(ByVal id_config_file_plano As String, ByVal id_cia As String,
                                                      ByVal usuario As String,
                                                      Optional ByVal path_file As String = "",
                                                      Optional ByVal visualizar_datatables As String = "N")

        'Dim visualizar_datatables As String = "S"

        Dim csql As String = ""
        Dim otb_encabezado As DataTable
        Dim otb_detalle As DataTable
        Dim otables(2) As DataTable

        Dim ocolum_referencial As Integer 'Para identificar que campo del encabezado sera usado como referencial en los detalles

        Dim oencabezado() As String = {} '= {({"128", "15", "*-[A-Z][A-Z]-*", "128", "15"}), ({"128", "12", "####-[A-Z][A-Z][A-Z]-##", "128", "12"})}
        Dim odetalle() As String = {}

        'estructuro las tablas de acuerdo a la configuracion
        otb_encabezado = Nothing
        otb_detalle = Nothing
        'cargo la estructura del encabezado y el detalle
        csql = "select * FROM camocontrol.tb0012_config_imp_cg where f0012_id_variable ='" & id_config_file_plano & "'"
        Dim otb As DataTable
        otb = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb.Rows
            'separo el texto en las partes que definen cada valor a buscar
            oencabezado = orow("f0012_encabezado").ToString.Split("┴")
            odetalle = orow("f0012_detalle").ToString.Split("┴")
            ocolum_referencial = orow("f0012_col_referencial")
            'MsgBox(oencabezado.Length)
        Next
        otb_encabezado = crear_tablas(oencabezado)
        otb_detalle = crear_tablas(odetalle, "S")
        'si no hay un archivo definido entonces lo debo buscar
        If path_file = "" Then
            Dim openFileDialog1 As New OpenFileDialog()
            'openFileDialog1.InitialDirectory = "e:\"
            openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*" 'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 1
            openFileDialog1.RestoreDirectory = True
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path_file = openFileDialog1.FileName
                'comunes.mostrar_archivo_texto(path_file, "")
            Else
                Return otables
                Exit Function
            End If
        End If

        Dim lector As New IO.StreamReader(path_file, System.Text.Encoding.UTF7)
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
        Dim contador_linea As Integer = 0

        'defino los objetos que seran anexados como datarow en los datatable
        Dim array_val_encabezado(oencabezado.GetUpperBound(0)) As Object
        Dim array_val_detalle(odetalle.GetUpperBound(0) + 1) As Object

        '128; 12; *-[A-Z][A-Z]-*; 128; 15 | 128; 12; ####-[A-Z][A-Z][A-Z]-##; 128; 12
        While lector.Peek() <> -1
            Dim linea As String = Replace(lector.ReadLine(), "\'d1", "Ñ")
            ' Si no está vacía, añadirla al control
            ' Si está vacía, continuar el bucle
            If String.IsNullOrEmpty(linea) Then
                Continue While
            End If

            'busco datos del encabezado
            For contador_linea = 0 To oencabezado.GetUpperBound(0)
                oconfigpartes = oencabezado(contador_linea).ToString.Split(";")
                valor_encontrado = buscar_campo(linea, oconfigpartes)
                If valor_encontrado <> "" Then
                    'MsgBox(oconfigpartes(0))
                    'MsgBox(oconfigpartes(0) & ": " & valor_encontrado)
                    'identifico si es la columna referencial
                    If contador_linea = ocolum_referencial Then
                        valor_referencial = valor_encontrado
                    End If
                    array_val_encabezado(contador_linea) = valor_encontrado
                    If contador_linea = oencabezado.GetUpperBound(0) Then
                        Try
                            otb_encabezado.Rows.Add(array_val_encabezado)
                        Catch ex As Exception

                        End Try
                        'MsgBox("se lleno el encabezado #: " & otb_encabezado.Rows.Count)
                    End If
                End If
            Next
            'busco datos del detalle
            For contador_linea = 0 To odetalle.GetUpperBound(0)
                oconfigpartes = odetalle(contador_linea).ToString.Split(";")
                valor_encontrado = buscar_campo(linea, oconfigpartes)
                If valor_encontrado <> "" Then
                    'MsgBox(oconfigpartes(0))
                    'MsgBox(oconfigpartes(0) & ": " & valor_encontrado)
                    array_val_detalle(0) = valor_referencial
                    array_val_detalle(contador_linea + 1) = valor_encontrado
                    If contador_linea = odetalle.GetUpperBound(0) Then
                        Try
                            otb_detalle.Rows.Add(array_val_detalle)
                        Catch ex As Exception

                        End Try
                        'MsgBox("se lleno el encabezado #: " & otb_encabezado.Rows.Count)
                    End If
                End If
            Next
        End While

        ' Cerrar el fichero
        lector.Close()
        If visualizar_datatables = "S" Then
            cl_utilidades_datatables.visualizar_datos_visor("", id_cia, usuario, "Encabezado", {}, otb_encabezado,,,,,,, "N")
            cl_utilidades_datatables.visualizar_datos_visor("", id_cia, usuario, "Detalle", {}, otb_detalle,,,,,,, "N")
        End If
        'asigno el valor de las tablas
        otables(1) = otb_encabezado
        otables(2) = otb_detalle
        Return otables
    End Function

    Public Shared Function crear_tablas(ByVal oarray() As String, Optional ByVal col_vinculante As String = "N")
        Dim odatatable = New DataTable
        Dim contador_linea As Integer = 0
        'Creo la estructura que tendran las tablas que almacenaran los datos
        Dim oconfigpartes As String()
        'creo estructura tabla encabezado
        'otb_encabezado = New DataTable
        If col_vinculante = "S" Then
            odatatable.Columns.Add("id_referencial", GetType(String))
        End If
        For contador_linea = 0 To oarray.GetUpperBound(0)
            oconfigpartes = oarray(contador_linea).ToString.Split(";")
            'MsgBox(oconfigpartes(1))
            Select Case oconfigpartes(1)
                Case "text"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(String))
                    'MsgBox(oconfigpartes(0))
                Case "numeric"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(Decimal))
                    'MsgBox(2)
                Case "date"
                    odatatable.Columns.Add(oconfigpartes(0).ToString, GetType(DateTime))
                    'MsgBox(3)
            End Select
        Next
        'MsgBox(odatatable.Columns.Count)
        Return odatatable
    End Function
    Public Shared Function buscar_campo(ByVal l_texto As String, ByVal criterios As String())
        Dim txt_testCheck As Boolean = False
        Dim txt_verificador As String = ""
        Dim valor_encontrado As String = ""
        'busco informacion que corresponda al encabezado
        'busco un formato en una posicion definida
        '{"128", "15", "*-[A-Z][A-Z]-*", "128", "15"}
        txt_verificador = Mid(l_texto, criterios(2).Trim, criterios(3).Trim).Trim
        'MsgBox(txt_verificador)
        'MsgBox(criterios(3))
        '001-EA-003100  2017-NOV-23
        'MsgBox(InStr(linea, "2017-NOV-23"))
        Select Case criterios(4).Trim
            Case "$t-numeric$"
                'referencia_cg; 8; 8; $t-numeric$; 8; 8
                'MsgBox("Entro")
                If IsNumeric(txt_verificador.Trim) = True Then
                    valor_encontrado = txt_verificador
                    'MsgBox("si es: " & valor_encontrado)
                End If
            Case "$t-text$"
                If IsNumeric(txt_verificador) = False Then
                    valor_encontrado = txt_verificador
                End If
            Case Else
                txt_testCheck = txt_verificador Like criterios(4).Trim
                If txt_testCheck = True Then
                    'MsgBox(Mid(l_texto, criterios(3).Trim(), criterios(4).Trim()).Trim)
                    valor_encontrado = Mid(l_texto, criterios(5).Trim(), criterios(6).Trim()).Trim
                    'MsgBox("lo hizo")
                End If
        End Select
        If criterios(1) = "date" Then
            valor_encontrado = formatear_fecha(valor_encontrado)
        End If
        Return valor_encontrado
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
End Class
