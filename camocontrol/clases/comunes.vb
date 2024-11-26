Imports System.Globalization
Public Class comunes
    Public Shared vuser_email As String = ""
    Public Shared vpassword_email As String = ""
    Public Shared vserver_email As String = ""
    Public Shared vport_email As Integer = 0
    Public Shared vfrom_email As String = ""
    Public Shared vssl_email As Boolean = True
    Public Shared vdestinatario_principal As String = ""
    Public Shared vcopia_a As String = ""
    Public Shared vrespuesta_correo As String = ""
    Public Shared csql As String = ""
    Public Shared odr As NpgsqlDataReader

    Public Shared Function suministrar_valor_variable_configuracion(variable As String, vg_id_cia As String)
        Dim otb_info_variables_configuracion As DataTable
        Dim csql As String
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0007_varibles_config" _
            & " where f0007_id_cia = '" & vg_id_cia & "' and f0007_id_variable = '" & variable & "'"
        otb_info_variables_configuracion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim valor_variable As String = ""
        For Each orow As DataRow In otb_info_variables_configuracion.Rows
            valor_variable = orow("f0007_valor_variable")
        Next
        Return valor_variable
    End Function
    Public Shared Function cargar_informacion_companias()
        Dim otb_info_compañias As DataTable
        Dim csql As String
        csql = "SELECT *, f0001_nit || ' - ' || f0001_razon_social as compania" _
            & " FROM " & database.obtener_esquema & ".tb0001_compania" _
            & " order by f0001_razon_social"
        otb_info_compañias = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Return otb_info_compañias
    End Function
    Public Shared Sub mostrar_archivo_texto(path_txt As String, txt_texto As String)
        Dim oform_visor_texto As New camocontrol.fm_visor_archivos_texto
        oform_visor_texto.path_txt = path_txt
        oform_visor_texto.txt_texto = txt_texto
        oform_visor_texto.ShowDialog()
        oform_visor_texto.Dispose()
    End Sub
    Public Shared Function Buscador_item(vg_id_cia As String, vg_usuario_autoriza As String, Optional filtro As String = "")
        Dim otb_items_selected As DataTable = Nothing
        Dim otb_tablas_array() As DataTable = Nothing
        Dim id_item As Integer = 0
        otb_tablas_array = cl_utilidades_datatables.visualizar_datos_visor("ST-0300-34", vg_id_cia, vg_usuario_autoriza,
                                                        "Listado de Items",
                                                        {vg_id_cia},
                                                            , "Items",,, "S", "id_item",, "S", "N", filtro)

        If IsNothing(otb_tablas_array(2)) = False Then
            otb_items_selected = otb_tablas_array(2)
        Else
            Return id_item
            Exit Function
        End If
        'agrego el tercero seleccionado
        For Each orow As DataRow In otb_items_selected.Rows
            'Actualizo el item
            'MsgBox(orow("id_sc_item"))
            id_item = orow("id_item")
        Next
        Return id_item
    End Function


    Public Shared Function formulario_fecha_hora(ByVal fecha_ini As Date, Optional show_hora As String = "S")
        Dim a As String
        Dim oform_fecha As New camocontrol.fm_gestion_fechas
        oform_fecha.fecha_ini = fecha_ini
        If show_hora = "N" Then
            oform_fecha.GroupBox1.Visible = False
        End If
        oform_fecha.ShowDialog()
        a = oform_fecha.ofecha_tx
        oform_fecha.Dispose()
        Return a
    End Function
    Public Shared Function formulario_fecha_rango()
        'retorna un arreglo de textos con fecha inicial y final
        Dim rango_fechas() As String
        Dim oform_fecha As New camocontrol.fm_gestion_fechas_rango
        oform_fecha.ShowDialog()
        rango_fechas = oform_fecha.rango_fechas
        oform_fecha.Dispose()
        Return rango_fechas
    End Function
    Public Shared Function formulario_parametro_texto(valor_defecto As String, descripcion_variable As String,
                                                      Optional multilinea As Boolean = False,
                                                      Optional otb_combobox As DataTable = Nothing,
                                                      Optional ODisplayMember As String = "",
                                                      Optional OValueMember As String = "",
                                                      Optional Oselectedvalue As String = "",
                                                      Optional Oselectedtext As String = "",
                                                      Optional ImagenPortapapeles As String = "N")
        'Retorna una valor de texto definido por el usuario
        Dim ocancelar As String = "S" 'Si se preciona el boton salir, significa que se cancela toda la operacion.
        Dim otexto As String = ""
        Dim oform_texto As New camocontrol.fm_parametro_texto

        If ImagenPortapapeles = "S" Then
            'verifico que el portapapeles si tenga una imagen
            If My.Computer.Clipboard.ContainsImage() Then
                'MsgBox("Clipboard contains an image.")
                oform_texto.PictureBox2.Image = My.Computer.Clipboard.GetImage
            End If
        End If

        If multilinea = True Then
            oform_texto.tx_texto.Multiline = True
            oform_texto.tx_texto.MaxLength = 1000
            oform_texto.tx_texto.Height = 80
            oform_texto.tx_texto.ScrollBars = ScrollBars.Vertical
        End If
        oform_texto.lb_texto.Text = descripcion_variable
        oform_texto.tx_texto.Text = valor_defecto
        If IsNothing(otb_combobox) = False Then
            oform_texto.ocombobox = "S"
            oform_texto.otb_combobox = otb_combobox
            oform_texto.ODisplayMember = ODisplayMember
            oform_texto.OValueMember = OValueMember
            oform_texto.Oselectedvalue = Oselectedvalue
            oform_texto.OselectedText = Oselectedtext
            If ODisplayMember.Trim = "" Or OValueMember.Trim = "" Then
                MsgBox("Defina los parametros para el combo (comunes.formulario_parametro_texto)")
                Return otexto
                Exit Function
            End If
        End If
        oform_texto.ShowDialog()
        otexto = oform_texto.otexto_descripcion
        ocancelar = oform_texto.ocancelar
        oform_texto.Dispose()
        If ocancelar = "S" Then
            otexto = ""
        End If
        Return otexto
    End Function

    Public Shared Function obtener_impresora_defecto() As String
        Dim vdefault_printer As String
        'Obtiene la Impresora por Defecto actual 
        Dim PD As New System.Drawing.Printing.PrintDocument
        vdefault_printer = PD.DefaultPageSettings.PrinterSettings.PrinterName
        Return vdefault_printer
    End Function
    Public Shared Function suministrar_otb_info_personal(ByVal vg_id_cia As String, ByVal mostrar_inactivos As String)
        Dim otb_info_personal As DataTable
        Dim csql As String
        csql = "select f0200_id_tercero, trim(both ' ' from f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres) as nombre"
        csql += " from " & database.obtener_esquema & ".tb0200_terceros"
        csql += " where f0200_id_cia = '" & vg_id_cia & "'" & " and f0200_ind_empleado = 'S'"
        If mostrar_inactivos = "N" Then
            csql += " and f0200_estado = 'A'"
        End If
        csql += " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Return otb_info_personal
    End Function
    Public Shared Function suministrar_otb_info_cargos(ByVal vg_id_cia As String, ByVal mostrar_anulados As String)
        Dim csql As String
        Dim otb_cargos As DataTable
        csql = "select f0240_id_cargo, f0240_cargo"
        csql += " from " & database.obtener_esquema & ".tb0240_cargos_compania"
        csql += " where f0240_id_cia = '" & vg_id_cia & "'"
        If mostrar_anulados = "N" Then
            csql += " and  f0240_anulado = 'N'"
        End If
        csql += " order by f0240_cargo"
        otb_cargos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Return otb_cargos
    End Function
    Public Shared Function traer_nombre_usuario(ByVal id_tercero As String)
        Dim csql As String
        Dim otb_usuario As DataTable
        Dim nombre As String = ""
        csql = "select f0200_id_tercero, f0200_id, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_tercero = '" & id_tercero & "'" _
            & " order by nombre"
        otb_usuario = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_usuario.Rows
            nombre = orow("nombre")
        Next
        Return nombre
    End Function
    Public Shared Function traer_nit_nombre_usuario(ByVal id_tercero As String)
        Dim csql As String
        Dim otb_usuario As DataTable
        Dim tinfo(1) As String
        csql = "select f0200_id_tercero, f0200_id, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_tercero = '" & id_tercero & "'" _
            & " order by nombre"
        otb_usuario = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_usuario.Rows
            tinfo(0) = orow("f0200_id") 'cedula o nit
            tinfo(1) = orow("nombre")
        Next
        Return tinfo
    End Function
    Public Shared Function traer_nombre_estructura(ByVal id_estructura As Integer)
        Dim csql As String
        Dim otb_estructura_mantenimiento As DataTable
        Dim nombre As String = ""
        Dim id_elemento_primario As String = ""
        Dim a As String = ""
        csql = "SELECT otb_estructura.*, otb_estructura.f0100_nombre || ' -- { ' || otb_estructura.f0100_codigo || ' }' as descripcion_nombre," _
            & " otb_estructura.f0100_codigo || ' -- { ' || otb_estructura.f0100_nombre || ' }' || '( ' || otb_estructura.f0100_id_estructura || ' )' as descripcion_codigo," _
            & " otb_primario.f0100_nombre || ' -- { ' || otb_primario.f0100_codigo || ' }' as descripcion_elemento_primario," _
            & " otb_estructura.f0100_id_maquina_padre as id_primario, otb_estructura.f0100_id_estructura as id_estructura" _
            & " FROM " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as otb_estructura" _
                & " join " & database.obtener_esquema & ".tb0107_tipos_estructura" _
                    & " on otb_estructura.f0100_id_tipo_estructura = f0107_id_tipo_estructura" _
                & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as otb_primario" _
                    & " on otb_primario.f0100_id_estructura = otb_estructura.f0100_id_maquina_padre" _
            & " where otb_estructura.f0100_id_estructura = '" & id_estructura & "'"
        otb_estructura_mantenimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_estructura_mantenimiento.Rows
            nombre = orow("descripcion_codigo")
            If orow("descripcion_elemento_primario").ToString.Trim <> "" And
                orow("id_primario").ToString <> orow("id_estructura").ToString Then
                nombre = nombre & " >> " & orow("descripcion_elemento_primario").ToString.Trim & " {" & orow("f0100_id_item") & "}"
            End If
        Next
        Return nombre
    End Function
    Public Shared Sub actualizar_campo_date_tabla(otabla As String, ocampo As String, ovalor As Date, owhere As String)
        Dim csql As String = ""
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + "." + otabla + " set "
        csql += ocampo & " = @ovalor"
        csql += " " & owhere
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@ovalor", NpgsqlDbType.Timestamp).Value = ovalor

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
    Public Shared Function SetDefaultPrinter(ByVal strPrinterName As String) As Boolean
        Dim strOldPrinter As String
        Dim WshNetwork As Object = Nothing
        Dim pd As New System.Drawing.Printing.PrintDocument

        strOldPrinter = pd.PrinterSettings.PrinterName 'Impresora por Defecto actual

        'Establece nueva Impresora por Defecto
        Try
            WshNetwork = Microsoft.VisualBasic.CreateObject("WScript.Network")
            WshNetwork.SetDefaultPrinter(strPrinterName)
            pd.PrinterSettings.PrinterName = strPrinterName 'Especifica la Impresora a utilizar
            If pd.PrinterSettings.IsValid Then 'Verifica que la Impresora exista
                Return True
            Else
                'Si la Impresora seleccionada es inválida, deja la Impresora por defecto anterior
                WshNetwork.SetDefaultPrinter(strOldPrinter)
                Return False
            End If
        Catch exptd As Exception
            WshNetwork.SetDefaultPrinter(strOldPrinter)
            Return False
        Finally
            WshNetwork = Nothing
            pd = Nothing
        End Try
    End Function
    Public Shared Function convertir_string_to_date(formato As Integer, tx_date As String)
        Dim odate As Date
        Try
            Select Case formato
                Case 1
                    'formato yyyy/mm/dd
                    odate = CDate(tx_date)
                Case 2
                    'formato dd/mm/yyyy
                    odate = Date.ParseExact(tx_date, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            End Select
        Catch ex As Exception
            MsgBox("Hay un error en el formato de fecha! (comunes.convertir_string_to_date) " + vbCrLf + ex.ToString)
        End Try
        Return odate
    End Function
    Public Shared Function fechahora() As DateTime
        Dim odr As NpgsqlDataReader
        Dim csql As String = ""
        Dim vfecha As DateTime
        csql = "SELECT CURRENT_TIMESTAMP as fechahora"
        odr = database.get_data_reader(csql)
        odr.Read()
        vfecha = odr(0)
        odr.Close()
        Return vfecha
    End Function
    Public Shared Function g_fechahora() As DateTime
        Dim odr As NpgsqlDataReader
        Dim csql As String = ""
        Dim vfecha As DateTime
        csql = "SELECT CURRENT_TIMESTAMP as fechahora"
        odr = database.get_data_reader(csql)
        odr.Read()
        vfecha = odr(0)
        odr.Close()
        Return vfecha
    End Function
    Public Shared Function devolver_nombre_dia_semana(ByVal fecha As Date)
        Dim dia_sem As String = ""
        Select Case Weekday(fecha)
            Case 1
                dia_sem = "Domingo"
            Case 2
                dia_sem = "Lunes"
            Case 3
                dia_sem = "Martes"
            Case 4
                dia_sem = "Miercoles"
            Case 5
                dia_sem = "Jueves"
            Case 6
                dia_sem = "Viernes"
            Case 7
                dia_sem = "Sabado"
        End Select
        Return dia_sem
    End Function
    Public Shared Function devolver_nombre_mes_ano(ByVal fecha As Date)
        Dim mes_ano As String = ""
        Select Case Month(fecha)
            Case 1
                mes_ano = "Enero"
            Case 2
                mes_ano = "Febrero"
            Case 3
                mes_ano = "Marzo"
            Case 4
                mes_ano = "Abril"
            Case 5
                mes_ano = "Mayo"
            Case 6
                mes_ano = "Junio"
            Case 7
                mes_ano = "Julio"
            Case 8
                mes_ano = "Agosto"
            Case 9
                mes_ano = "Septiembre"
            Case 10
                mes_ano = "Octubre"
            Case 11
                mes_ano = "Noviembre"
            Case 12
                mes_ano = "Diciembre"
        End Select
        Return mes_ano
    End Function
    Public Shared Function g_mensaje_YesNo(ByVal titulo As String, ByVal mensaje As String)
        Dim respuesta As MsgBoxResult
        Dim estilo As MsgBoxStyle
        Dim resultado As String = "N"
        estilo = MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation Or MsgBoxStyle.DefaultButton2
        respuesta = MsgBox(mensaje, estilo, titulo)
        If respuesta = MsgBoxResult.Yes Then
            resultado = "S"
        End If
        Return resultado
    End Function
    Public Shared Function cambio_valor(valor As String, valor_buscado As String, cambiar_por As String)
        If valor = valor_buscado Then
            valor = cambiar_por
        End If
        Return valor
    End Function
    Public Shared Function g_mensajes(ByVal vtip As String, ByVal vmen As String) As String
        Dim vmensaje As String
        Dim vtipo As String
        vmensaje = vmen
        vtipo = vtip

        If vtipo = "1" Then  ' tipo ERROR
            MessageBox.Show(vmensaje, "Error", MessageBoxButtons.OK, _
            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If

        If vtipo = "2" Then  ' Exito en el proceso
            MessageBox.Show(vmensaje, "Proceso OK", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

        If vtipo = "3" Then  ' Advertencia en el proceso
            MessageBox.Show(vmensaje, "Advertencia", MessageBoxButtons.OK, _
            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
        Return True
    End Function
    '--------------------------------
    'Función que comprueba si una diección de email es válida
    '*********************************************************************************
    Public Shared Function Validar_Email(ByVal Email As String) As Boolean

        Dim i As Integer, iLen As Integer, caracter As String
        Dim bp As Boolean, iPos As Integer, iPos2 As Integer
        Validar_Email = False

        Email = Trim$(Email)

        If Email = vbNullString Then
            Exit Function
        End If

        Email = LCase$(Email)
        iLen = Len(Email)


        For i = 1 To iLen
            caracter = Mid(Email, i, 1)
            If (Not (caracter Like "[a-z]")) And (Not (caracter Like "[0-9]")) Then
                If InStr(1, "_-" & "." & "@", caracter) > 0 Then
                    If bp = True Then
                        Exit Function
                    Else
                        bp = True
                        If i = 1 Or i = iLen Then
                            Exit Function
                        End If
                        If caracter = "@" Then
                            If iPos = 0 Then
                                iPos = i
                            Else
                                Exit Function
                            End If
                        End If
                        If caracter = "." Then
                            iPos2 = i
                        End If
                    End If
                Else
                    Exit Function
                End If
            Else
                bp = False
            End If
        Next i
        If iPos = 0 Or iPos2 = 0 Then
            Exit Function
        End If
        If iPos2 < iPos Then
            Exit Function
        End If
        Validar_Email = True
    End Function
    Public Shared Function g_solofecha() As Date
        Dim odr As NpgsqlDataReader
        Dim csql As String = ""
        Dim vfecha As Date

        csql = "SELECT CURRENT_date as fecha"
        odr = database.get_data_reader(csql)
        odr.Read()
        vfecha = odr(0)
        odr.Close()
        Return vfecha
    End Function

    Public Shared Sub enviar_email(ByVal cod_mensaje As String, ByVal asunto As String, ByVal cuerpo As String, ByVal archivo As String)
        obtener_parametros_correo(cod_mensaje)
        Try
            Dim SmtpServer As New System.Net.Mail.SmtpClient()
            Dim mail As New System.Net.Mail.MailMessage()
            vrespuesta_correo = ""
            If vuser_email <> "" And vserver_email <> "" And vfrom_email <> "" And vdestinatario_principal <> "" Then
                SmtpServer.Credentials = New Net.NetworkCredential(vuser_email, vpassword_email)
                SmtpServer.EnableSsl = vssl_email
                SmtpServer.Port = vport_email
                SmtpServer.Host = vserver_email
                mail = New System.Net.Mail.MailMessage()
                mail.From = New System.Net.Mail.MailAddress(vfrom_email)
                mail.To.Add(vdestinatario_principal)
                If vcopia_a <> "" Then
                    mail.CC.Add(vcopia_a)
                End If
                mail.Subject = Trim(asunto)
                If System.IO.File.Exists(archivo) Then
                    mail.Attachments.Add(New System.Net.Mail.Attachment(archivo))
                End If
                mail.Body = Trim(cuerpo)
                SmtpServer.Send(mail)
                vrespuesta_correo = "Correo enviado Exitosamente !"
            Else
                vrespuesta_correo = "Error : No se pudo Obtener algún parámetro para enviar Correo"
            End If
        Catch ex As Exception
            vrespuesta_correo = "Error : " + ex.ToString.Replace(vbCrLf, "")
        End Try
    End Sub

    Public Shared Sub enviar_email_cliente(ByVal destinatario As String, ByVal asunto As String, ByVal cuerpo As String, ByVal archivo As String)
        obtener_parametros_correo("01")
        Try
            Dim SmtpServer As New System.Net.Mail.SmtpClient()
            Dim mail As New System.Net.Mail.MailMessage()
            vrespuesta_correo = ""
            vdestinatario_principal = destinatario
            If vuser_email <> "" And vserver_email <> "" And vfrom_email <> "" And vdestinatario_principal <> "" Then
                SmtpServer.Credentials = New Net.NetworkCredential(vuser_email, vpassword_email)
                SmtpServer.EnableSsl = vssl_email
                SmtpServer.Port = vport_email
                SmtpServer.Host = vserver_email
                mail = New Net.Mail.MailMessage()
                mail.From = New Net.Mail.MailAddress(vfrom_email)
                mail.To.Add(vdestinatario_principal)
                If vcopia_a <> "" Then
                    mail.CC.Add(vcopia_a)
                End If
                mail.Subject = Trim(asunto)
                If System.IO.File.Exists(archivo) Then
                    mail.Attachments.Add(New System.Net.Mail.Attachment(archivo))
                End If
                mail.Body = Trim(cuerpo)
                SmtpServer.Send(mail)
                vrespuesta_correo = "Correo enviado Exitosamente !"
            Else
                vrespuesta_correo = "Error : No se pudo Obtener algún parámetro para enviar Correo"
            End If
        Catch ex As Exception
            vrespuesta_correo = "Error : " + ex.ToString.Replace(vbCrLf, "")
        End Try
    End Sub

    Public Shared Sub obtener_parametros_correo(ByVal cod_mensaje As String)
        csql = "select * from " + database.obtener_esquema + ".parametros "
        odr = database.get_data_reader(csql)
        While odr.Read
            vuser_email = Trim(odr.Item("user_email"))
            vpassword_email = Trim(odr.Item("password_email"))
            vserver_email = Trim(odr.Item("server_email"))
            vport_email = Trim(odr.Item("port_email"))
            vfrom_email = Trim(odr.Item("from_email"))
            If odr.Item("ssl_email") = "S" Then
                vssl_email = True
            Else
                vssl_email = False
            End If
        End While
        odr.Close()
        'Obtiene los destinatarios del mensaje
        csql = "select a.*, coalesce(b.copia_a,' ') copia_a from " + database.obtener_esquema + ".tb_mensajes_email a " _
        + " left join " + database.obtener_esquema + ".tb_mensajes_email_copias b " _
        + "  on a.codigo = b.codigo_mensaje " _
        + " where a.codigo = '" + Trim(cod_mensaje) + "' "
        odr = database.get_data_reader(csql)
        vdestinatario_principal = ""
        vcopia_a = ""
        While odr.Read
            vdestinatario_principal = Trim(odr.Item("destinatario_principal"))
            If Trim(odr.Item("copia_a")) <> "" Then
                vcopia_a += Trim(odr.Item("copia_a")) + ","
            End If
        End While
        odr.Close()
    End Sub


End Class
