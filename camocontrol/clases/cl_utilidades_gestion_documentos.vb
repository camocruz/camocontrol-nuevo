Imports System.IO
Imports System.IO.Compression
Public Class cl_utilidades_gestion_documentos
    Public Shared Function capturar_archivos_segun_tipo(ByVal tipo_archivo As String,
                                                        ByVal consecutivo_docto As Integer,
                                                        ByVal vg_id_cia As String,
                                                        ByVal vg_usuario_autoriza As String,
                                                        ByVal c_automatico As String,
                                                        Optional path_inicio As String = "",
                                                        Optional CargueDesdePortapapeles As String = "N")
        Dim path_file_complete(2) As String  'Retorna un arreglo con el path completo del archivo creado
        path_file_complete(0) = "" 'id_file, id del registro en la tabla de archivos asociados
        path_file_complete(1) = "" 'Path completo del archivo creado
        path_file_complete(2) = "" ' S o N Indica si el archivo esta comprimido

        Dim csql As String
        Dim otabla_variables_config As DataTable
        Dim tamano_maximo As Integer
        Dim ancho_maximo_imagenes As Integer
        Dim ocomprimido As String = ""
        Dim extensiones_permitidas As String = ""
        Dim odescripcion As String = ""
        Dim new_name_file As String = ""
        Dim new_path_file As String = ""
        Dim omensaje_fin As String = ""
        Dim multiple_seleccion As Boolean = False
        csql = "select * from " & database.obtener_esquema & ".tb0007_varibles_config" _
            & " where f0007_id_cia = '" & vg_id_cia & "' and" _
            & " substring(f0007_id_variable from 1 for " & Len(tipo_archivo) & ") = '" & tipo_archivo & "'" _
            & " order by f0007_id_variable;"
        otabla_variables_config = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otabla_variables_config.Rows
            'MsgBox(Mid(orow("f0007_id_variable"), Len(tipo_archivo) + 2, 3))
            Select Case Mid(orow("f0007_id_variable"), Len(tipo_archivo) + 2, 3)
                Case "001" 'Genera el nombre del docto de acuerdo al tipo.
                    new_name_file = orow("f0007_valor_variable")
                    new_name_file += "-" & consecutivo_docto.ToString.PadLeft(8, "0")
                    'MsgBox(new_name_file)
                Case "002" 'Path donde se gravara el archivo capturado
                    new_path_file = orow("f0007_valor_variable")
                Case "003" 'Indica la descripcion del archivo por defecto
                    If c_automatico = "N" Then
                        odescripcion = comunes.formulario_parametro_texto(orow("f0007_valor_variable"), "Descripcion del Archivo")
                    Else
                        odescripcion = orow("f0007_valor_variable")
                    End If

                    If odescripcion = "" Then
                        Return path_file_complete
                        Exit Function
                        'MsgBox("Se asignara el valor por defecto para la descripcion del documento", MsgBoxStyle.Information, "Informacion")
                        'odescripcion = orow("f0007_valor_variable")
                    End If
                Case "004" 'Tamaño maximo permitido
                    tamano_maximo = CInt(orow("f0007_valor_variable"))
                Case "005" 'Indica si el archivo es comprimido
                    ocomprimido = orow("f0007_valor_variable")
                Case "006" 'Indica la extension de los archivos permitidos
                    extensiones_permitidas = orow("f0007_valor_variable")
                Case "007" 'Indica el ancho maximo de las imagenes
                    ancho_maximo_imagenes = orow("f0007_valor_variable")
                Case "008" 'Indica si se habilita seleccionar multiples archivos
                    If orow("f0007_valor_variable") = "N" Then
                        multiple_seleccion = False
                    Else
                        multiple_seleccion = True
                    End If
            End Select
        Next

        Dim oconsecutivo As String = "" 'corresponde a la edicion del documento o la cuenta de cuantos documentos hay
        csql = "select * from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
            & " where f0503_id_cia = '" & vg_id_cia & "' and" _
            & " f0503_nombre_archivo = '" & new_name_file & "'"
        Dim otb_archivos As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        oconsecutivo = (otb_archivos.Rows.Count + 1).ToString.PadLeft(3, "0")

        Dim path_file As String
        Dim orow_file_names As String() = Nothing
        Dim borrar_archivo As String = "N"

        If c_automatico = "N" Then
            Dim OpenFileDialog1 As New OpenFileDialog
            'OpenFileDialog1.InitialDirectory = "e:\"
            'OpenFileDialog1.Filter = "Imágenes JPG (*.jpg)|*.jpg|" +
            '"Imagenes Fireworks (*.png)|*.png|" +
            '"Mapas de bits (*.bmp)|*.bmp"
            '"Todos Los Archivos|*.*"
            OpenFileDialog1.Filter = extensiones_permitidas
            OpenFileDialog1.FilterIndex = 1
            OpenFileDialog1.RestoreDirectory = True
            OpenFileDialog1.InitialDirectory = path_inicio
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Multiselect = multiple_seleccion

            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                'path_file = OpenFileDialog1.FileName
                'Mostramos o abrimos el archivo
                'cl_utilidades_gestion_documentos.abrir_archivo(path_file, vg_id_cia, vg_usuario_autoriza)
                'Pregunta si realmente desea reportar
                Dim respuesta As String = "N"
                respuesta = comunes.g_mensaje_YesNo("Grabar Soporte", "Desea Registrar los archivos seleccionados?")
                If respuesta = "N" Then
                    Return path_file_complete
                    Exit Function
                End If
                'para borrar los archivos fuente copiados.
                borrar_archivo = comunes.g_mensaje_YesNo("Borrar Archivo", "Desea BORRAR los archivos fuente?")
                orow_file_names = OpenFileDialog1.FileNames
            Else
                Return path_file_complete
                Exit Function
            End If
        Else
            Dim vg_path_carg_aut As String = ""
            'cargo el path de cargue automatico
            vg_path_carg_aut = formulario_inicio.vg_path_carg_aut
            If vg_path_carg_aut = "" Then
                MsgBox("No ha definido el Directorio de Cargue Automatico", MsgBoxStyle.Information, "Info")
                Return path_file_complete
                Exit Function
            End If
            'Verifico que el directorio sea valido
            If Directory.Exists(vg_path_carg_aut) = False Then
                MsgBox("El Directorio de Cargue Automatico no es valido", MsgBoxStyle.Information, "Info")
                Return path_file_complete
                Exit Function
            End If


            'identifico todos los archivos en el directorio
            orow_file_names = Directory.GetFiles(vg_path_carg_aut)
            'para borrar los archivos fuente copiados.
            borrar_archivo = "S"
            'Pregunto si desea cargar todos los archivos
            Dim vmensaje As String = "Desea cargar estos archivos?" & vbCrLf
            Dim ocont As Integer = 0
            For Each path_file In orow_file_names
                vmensaje += path_file & vbCrLf
                ocont = ocont + 1
            Next
            If ocont > 20 Then
                MsgBox("Mas de 20 archivos solo se pueden cargar manualmente", MsgBoxStyle.Information, "Info")
                Return path_file_complete
                Exit Function
            End If
            Dim respuesta As String = comunes.g_mensaje_YesNo("Cargue Automatico", vmensaje)
            If respuesta = "N" Then
                Return path_file_complete
                Exit Function
            End If
        End If
        'proceso los archivos
        For Each path_file In orow_file_names
            Dim infoReader As System.IO.FileInfo
            Dim oextension As String
            Dim old_file_name As String = ""
            infoReader = My.Computer.FileSystem.GetFileInfo(path_file)
            oextension = infoReader.Extension
            old_file_name = infoReader.Name

            'defino el nuevo directorio de captura automatica
            Try
                formulario_inicio.vg_path_carg_aut = infoReader.Directory.ToString
                'MsgBox(formulario_inicio.vg_path_carg_aut)
            Catch ex As Exception

            End Try


            'Identificamos el tipo de archivo
            Dim otipo_archivo As Integer = 0
            otipo_archivo = cl_utilidades_gestion_documentos.identificar_tipo_archivo(path_file)

            Dim otamano_kb As Single = Math.Round((infoReader.Length / 1024), 1)
            Dim nombre_final As String = new_name_file & "-" & oconsecutivo 'Nombre del archivo en el directorio
            If otipo_archivo = 1 Then 'Indica que es una imagen, se ajustara al tamaño definido
                Dim imagen_temporal As String = cl_utilidades_gestion_documentos.imagen_ajustada_a_tamaño_maximo(path_file, ancho_maximo_imagenes)
                'Como se cambio el tamaño de la imagen, entonces su tamaño en kb cambia, hay que identificar el nuevo tamaño
                infoReader = My.Computer.FileSystem.GetFileInfo(imagen_temporal)
                otamano_kb = Math.Round((infoReader.Length / 1024), 1)
                Dim verror As String
                verror = "N"
                'File.Copy(path_file, new_path_file & nombre_final & extension, True)
                verror = cl_utilidades_gestion_documentos.copiar_archivo(imagen_temporal, new_path_file & nombre_final & oextension, ocomprimido)
                If verror = "N" Then
                    cl_utilidades_gestion_documentos.grabar_bd_nuevo_documento_soporte(new_name_file, oconsecutivo, oextension, new_path_file,
                                                                                        odescripcion, ocomprimido, otamano_kb, otipo_archivo, old_file_name,
                                                                                        vg_id_cia, vg_usuario_autoriza)
                    path_file_complete(0) = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0503_id_archivo", "f0503_usuario_crear", vg_usuario_autoriza, "tb0503_archivos_asociados")
                    path_file_complete(1) = new_path_file & new_name_file & "-" & oconsecutivo & oextension
                    path_file_complete(2) = ocomprimido
                    omensaje_fin += old_file_name & " = OK" & vbCrLf
                    'MsgBox("Archivo guardado", MsgBoxStyle.Information, "Guardado")
                End If
            Else
                'Los otros tipos de archivo seran copiados controlando su tamaño
                Dim otamaño As String = ""
                If (infoReader.Length / 1024) > 1024 Then
                    otamaño = Math.Round(((infoReader.Length / 1024) / 1024), 2).ToString() & " Mb"
                Else
                    otamaño = Math.Round((infoReader.Length / 1024), 2).ToString() & " Kb"
                End If
                Dim verror As String
                verror = "N"
                If (infoReader.Length / 1024) < tamano_maximo Then
                    'File.Copy(path_file, new_path_file & nombre_final & extension, True)
                    verror = cl_utilidades_gestion_documentos.copiar_archivo(path_file, new_path_file & nombre_final & oextension, ocomprimido)
                    If verror = "N" Then
                        cl_utilidades_gestion_documentos.grabar_bd_nuevo_documento_soporte(new_name_file, oconsecutivo, oextension, new_path_file,
                                                                                            odescripcion, ocomprimido, otamano_kb, otipo_archivo, old_file_name,
                                                                                            vg_id_cia, vg_usuario_autoriza)
                        'MsgBox("Archivo guardado", MsgBoxStyle.Information, "Guardado")
                        omensaje_fin += old_file_name & " = OK" & vbCrLf
                    End If
                Else
                    'MsgBox("El archivo es muy grande, tamaño maximo: " & tamano_maximo & " Kb, el tamaño actual es: " _
                    '& otamaño & vbCrLf & "Archivo Rechazado!!!", MsgBoxStyle.Critical, "Error")
                    omensaje_fin += old_file_name & " = El archivo es muy grande, tamaño maximo: " & tamano_maximo & " Kb, el tamaño actual es: " _
                               & otamaño & vbCrLf & "Archivo Rechazado!!!" & vbCrLf
                End If
            End If
            oconsecutivo += 1
            oconsecutivo = oconsecutivo.ToString.PadLeft(3, "0")
            'Para borrar los archivos fuente.
            If borrar_archivo = "S" Then
                Try
                    My.Computer.FileSystem.DeleteFile(path_file)
                Catch ex As Exception
                    MsgBox(ex)
                End Try
            End If
        Next path_file
        MsgBox(omensaje_fin, MsgBoxStyle.Information, "Info")

        'MsgBox(path_file_complete(0) & "---" & path_file_complete(1))
        Return path_file_complete
    End Function

    ' Función para determinar si un archivo es una imagen
    Public Shared Function IsImageFile(filePath As String) As Boolean
        Try
            ' Intentar cargar el archivo como una imagen
            Using img As Image = Image.FromFile(filePath)
                Return True
            End Using
        Catch ex As OutOfMemoryException
            ' No es una imagen si ocurre esta excepción
            Return False
        Catch ex As Exception
            ' Otros errores también indican que no es una imagen
            Return False
        End Try
    End Function

    Public Shared Sub copiar_desde_portapapeles()
        ' Verificar si el portapapeles contiene datos de tipo archivo
        If Clipboard.ContainsFileDropList() Then
            ' Obtener la lista de archivos desde el portapapeles
            Dim files = Clipboard.GetFileDropList()

            ' Directorio donde se guardarán los archivos ZIP
            Dim destinationDirectory As String = "C:\Ruta\Destino\"

            ' Asegurarse de que el directorio de destino exista
            If Not Directory.Exists(destinationDirectory) Then
                Directory.CreateDirectory(destinationDirectory)
            End If

            Try
                ' Procesar cada archivo en la lista del portapapeles
                For Each sourceFile As String In files
                    ' Verificar si el archivo es una imagen
                    Dim isImage As Boolean = IsImageFile(sourceFile)
                    ' Obtener el nombre del archivo sin la ruta
                    Dim fileName As String = Path.GetFileNameWithoutExtension(sourceFile)

                    ' Crear el nombre del archivo ZIP de destino
                    Dim zipFilePath As String = Path.Combine(destinationDirectory, fileName & ".zip")

                    ' Crear un archivo ZIP que contiene el archivo original
                    Using zipStream As FileStream = New FileStream(zipFilePath, FileMode.Create)
                        Using zipArchive As ZipArchive = New ZipArchive(zipStream, ZipArchiveMode.Create)
                            ' Agregar el archivo al ZIP
                            Dim zipEntry As ZipArchiveEntry = zipArchive.CreateEntry(Path.GetFileName(sourceFile))
                            Using originalFileStream As FileStream = New FileStream(sourceFile, FileMode.Open, FileAccess.Read)
                                Using zipEntryStream As Stream = zipEntry.Open()
                                    originalFileStream.CopyTo(zipEntryStream)
                                End Using
                            End Using
                        End Using
                    End Using

                    Console.WriteLine("Archivo comprimido exitosamente: " & zipFilePath)
                Next
            Catch ex As Exception
                Console.WriteLine("Ocurrió un error: " & ex.Message)
            End Try
        Else
            Console.WriteLine("El portapapeles no contiene archivos.")
        End If
    End Sub
    Public Shared Sub grabar_bd_nuevo_documento_soporte(codigo_docto As String, consecutivo As String, extension As String, path_file As String,
                                                     descripcion As String, ocomprimido As String, tamano As Single,
                                                     tipo_archivo As Integer, nombre_original As String, vg_id_cia As String, usuario As String)
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0503_archivos_asociados" _
        & " (f0503_id_cia, f0503_nombre_archivo, f0503_extension, f0503_ed, f0503_path, f0503_descripcion_archivo," _
        & " f0503_comprimido, f0503_tamano_kb, f0503_id_tipo_archivo, f0503_nombre_original, f0503_usuario_crear, f0503_usuario_modificar)" _
        & " VALUES" _
        & " (@f0503_id_cia, @f0503_nombre_archivo, @f0503_extension, @f0503_ed, @f0503_path, @f0503_descripcion_archivo," _
        & " @f0503_comprimido, @f0503_tamano_kb, @f0503_id_tipo_archivo, @f0503_nombre_original, @f0503_usuario_crear, @f0503_usuario_modificar)"
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'crear_parametros_seguimiento(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0503_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0503_nombre_archivo", NpgsqlDbType.Varchar).Value = codigo_docto
        ocmd.Parameters.Add("@f0503_extension", NpgsqlDbType.Varchar).Value = extension
        ocmd.Parameters.Add("@f0503_ed", NpgsqlDbType.Varchar).Value = consecutivo
        ocmd.Parameters.Add("@f0503_path", NpgsqlDbType.Varchar).Value = path_file
        ocmd.Parameters.Add("@f0503_descripcion_archivo", NpgsqlDbType.Varchar).Value = descripcion
        ocmd.Parameters.Add("@f0503_comprimido", NpgsqlDbType.Varchar).Value = ocomprimido
        ocmd.Parameters.Add("@f0503_tamano_kb", NpgsqlDbType.Numeric).Value = tamano
        ocmd.Parameters.Add("@f0503_id_tipo_archivo", NpgsqlDbType.Integer).Value = tipo_archivo
        ocmd.Parameters.Add("@f0503_nombre_original", NpgsqlDbType.Varchar).Value = nombre_original
        ocmd.Parameters.Add("@f0503_usuario_crear", NpgsqlDbType.Varchar).Value = usuario
        ocmd.Parameters.Add("@f0503_usuario_modificar", NpgsqlDbType.Varchar).Value = usuario
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
    Public Shared Function copiar_archivo(path_file As String, new_path_file As String, ocomprimido As String)
        Dim verror As String = "N"
        Dim fi As FileInfo = New FileInfo(path_file)
        Select Case ocomprimido
            Case "N" 'Crea una Copia el archivo.
                Try
                    File.Copy(path_file, new_path_file, True)
                Catch ex As Exception
                    verror = "S"
                    MsgBox("El archivo no se pudo procesar!", MsgBoxStyle.Critical, "Error")
                Finally
                End Try
            Case "S" 'Crea una copia comprimida del archivo
                ' Get the stream of the source file.
                Using inFile As FileStream = fi.OpenRead()
                    ' Compressing:
                    ' Prevent compressing hidden and already compressed files.
                    If (File.GetAttributes(fi.FullName) And FileAttributes.Hidden) _
                        <> FileAttributes.Hidden And fi.Extension <> ".zip" Then
                        ' Create the compressed file.
                        Using outFile As FileStream = File.Create(new_path_file + ".zip")
                            Using Compress As GZipStream = _
                             New GZipStream(outFile, CompressionMode.Compress)
                                Try
                                    ' Copy the source file into the compression stream.
                                    inFile.CopyTo(Compress)
                                    verror = "N"
                                Catch ex As Exception
                                    verror = "S"
                                    MsgBox("El archivo no se pudo procesar!", MsgBoxStyle.Critical, "Error")
                                Finally
                                End Try
                                Console.WriteLine("Compressed {0} from {1} to {2} bytes.", _
                                                  fi.Name, fi.Length.ToString(), outFile.Length.ToString())
                            End Using
                        End Using
                    End If
                End Using
        End Select
        Return verror
    End Function
    Public Shared Function suministrar_archivo(path_file As String, new_path_file As String, ocomprimido As String)
        Dim verror As String = "N"
        Dim fi As FileInfo = New FileInfo(path_file & ".zip")
        ' Get the stream of the source file.
        If ocomprimido = "N" Then
            Try
                File.Copy(path_file, new_path_file, True)
            Catch ex As Exception
                verror = "S"
                MsgBox("El archivo no se pudo recuperar!", MsgBoxStyle.Critical, "Error")
            Finally
            End Try
        Else
            Try
                Using inFile As FileStream = fi.OpenRead()
                    ' Get orignial file extension, for example "doc" from report.doc.gz.
                    Dim curFile As String = fi.FullName
                    Dim origName = curFile.Remove(curFile.Length - fi.Extension.Length)

                    ' Create the decompressed file.
                    Using outFile As FileStream = File.Create(new_path_file)
                        Using Decompress As GZipStream = New GZipStream(inFile,
                         CompressionMode.Decompress)
                            Try
                                ' Copy the decompression stream 
                                ' into the output file.
                                Decompress.CopyTo(outFile)
                                verror = "N"
                            Catch ex As Exception
                                verror = "S"
                                MsgBox("El archivo no se pudo recuperar!", MsgBoxStyle.Critical, "Error")
                            Finally
                            End Try
                            Console.WriteLine("Decompressed: {0}", fi.Name)
                        End Using
                    End Using
                End Using
            Catch ex2 As Exception
                verror = "S"
                MsgBox("Hubo un error intentado recuperar archivo! " + vbCrLf + ex2.ToString)
            End Try
        End If
        Return verror
    End Function
    Public Shared Function identificar_tipo_archivo(path_file As String)
        Dim infoReader As System.IO.FileInfo
        Dim oextension As String
        Dim tipo_arch As Integer = 0
        infoReader = My.Computer.FileSystem.GetFileInfo(path_file)
        oextension = LCase(infoReader.Extension)

        'generamos vista previa si es una imagen
        Select Case oextension
            Case ".jpg", ".jpeg", ".png", ".bmp", ".gif" ', ".tif" lo quito porque es multipagina y se dañaria al disminuirlo
                tipo_arch = 1
            Case ".pdf"
                tipo_arch = 2
            Case Else
                tipo_arch = 0
        End Select
        Return tipo_arch
    End Function
    Public Shared Sub abrir_archivo(path_file As String, vg_id_cia As String, vg_usuario_autoriza As String)
        Dim infoReader As System.IO.FileInfo
        Dim oextension As String
        Dim tipo_arch As Integer = 0
        infoReader = My.Computer.FileSystem.GetFileInfo(path_file)
        oextension = infoReader.Extension
        'MsgBox(tipo_arch)
        'generamos vista previa si es una imagen
        Select Case tipo_arch
            Case 1
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_imagen As New camocontrol.fm_visor_imagen
                'oform_grilla_programacion.ods_hijo = ods
                'oform_imagen.vf_oform_padre = Me
                oform_imagen.vg_id_cia = vg_id_cia
                oform_imagen.vg_usuario_autoriza = vg_usuario_autoriza
                oform_imagen.path_file = path_file
                oform_imagen.Text = path_file
                oform_imagen.ShowDialog()
            Case 2
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_imagen As New camocontrol.fm_visor_pdf
                'oform_grilla_programacion.ods_hijo = ods
                'oform_imagen.vf_oform_padre = Me
                oform_imagen.vg_id_cia = vg_id_cia
                oform_imagen.vg_usuario_autoriza = vg_usuario_autoriza
                oform_imagen.path_file = path_file
                oform_imagen.Text = path_file
                oform_imagen.ShowDialog()
            Case Else
                MsgBox("Este archivo no puede ser visualizado con este software.", MsgBoxStyle.Exclamation, "Error")
        End Select

    End Sub
    Public Shared Function calcular_cantidad_archivos_asociados(codigo_config As String, id_documento As String, vg_id_cia As String)
        'Identificamos cuantos archivos estan asociados al documento
        Dim csql As String
        Dim new_name_file As String = ""
        Dim tot_doc As Integer = 0
        new_name_file = comunes.suministrar_valor_variable_configuracion(codigo_config, vg_id_cia)
        new_name_file += "-" & id_documento.Trim.PadLeft(8, "0")
        Dim oconsecutivo As String = ""
        csql = "select * from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
            & " where f0503_anulado = 'N' and f0503_id_cia = '" & vg_id_cia & "' and" _
            & " f0503_nombre_archivo = '" & new_name_file & "'"
        Dim otb_archivos As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        tot_doc = otb_archivos.Rows.Count
        Return tot_doc
    End Function
    Public Shared Function formas_obtener_gestionar_archivo()
        Dim accion_seleccionada As Integer = 0 '1=copia, 2=visualizar
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_seleccionar As New camocontrol.fm_0500_dialog_suministro_documento
        oform_seleccionar.ShowDialog()
        accion_seleccionada = oform_seleccionar.accion_seleccionada
        oform_seleccionar.Dispose()
        Return accion_seleccionada
    End Function
    Public Shared Function mostrar_listado_archivos_asociados(ByVal vf_var_config_archivos As String,
                                                              ByVal vf_id_notas_archivos As String,
                                                              ByVal vf_name_files As String,
                                                              ByVal vg_usuario_autoriza As String,
                                                              ByVal vg_id_cia As String,
                                                              Optional vf_otabla_permisos As DataTable = Nothing)
        'vf_var_config_archivos = "CD-BKC"
        'vf_id_notas_archivos = 28400 entero que identifica el numero del registro id de tabla registro padre
        'vf_name_files = nombre que resibira el archivo creado, eje BCK-00003456

        Dim tot_doc As Integer = 0
        If vf_var_config_archivos = "" Then
            tot_doc = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados(vf_var_config_archivos & "-001",
                                                                                            vf_id_notas_archivos,
                                                                                            vg_id_cia)
            MsgBox("No hay var de configuracion", MsgBoxStyle.Information, "Error")
            Return tot_doc
            Exit Function
        End If
        Dim csql As String = ""
        If vf_id_notas_archivos.Trim <> "" And vf_id_notas_archivos <> "0" Then
            csql = comunes.suministrar_valor_variable_configuracion("ST-0550-02", vg_id_cia)
            csql = csql.Replace("$df001$", database.obtener_esquema)
            csql = csql.Replace("$001$", vg_id_cia)
            csql = csql.Replace("$002$", vf_name_files)
        Else
            tot_doc = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados(vf_var_config_archivos & "-001",
                                                                                            vf_id_notas_archivos,
                                                                                            vg_id_cia)
            MsgBox("No hay id de archivo", MsgBoxStyle.Information, "Error")
            Return tot_doc
            Exit Function
        End If

        'IDENTIFICO LOS PERMISOS QUE TIENE EL USUARIO PARA GESTIONAR LOS ARCHIVOS
        Dim p_add_archivos As String = "N"
        Dim p_consultar_archivos_propios As String = "N"
        Dim P_consultar_todos_archivos As String = "N"
        If IsNothing(vf_otabla_permisos) = False Then
            p_add_archivos = cl_gestion_permisos.identificar_permisos_especiales_formularios("ADD_ARCHIVO", vf_otabla_permisos, vg_usuario_autoriza)
            p_consultar_archivos_propios = cl_gestion_permisos.identificar_permisos_especiales_formularios("CONS_PROP_ARCHIVO", vf_otabla_permisos, vg_usuario_autoriza)
            P_consultar_todos_archivos = cl_gestion_permisos.identificar_permisos_especiales_formularios("CONS_TOT_ARCHIVO", vf_otabla_permisos, vg_usuario_autoriza)
            'determino los datos que podra visualizar el usuario.
            If P_consultar_todos_archivos = "S" Then
                csql = csql.Replace("$003$", "f0503_usuario_crear")
            Else
                csql = csql.Replace("$003$", "'" & vg_usuario_autoriza & "'")
            End If
        Else
            p_add_archivos = "S"
            p_consultar_archivos_propios = "S"
            P_consultar_todos_archivos = "S"
            csql = csql.Replace("$003$", "f0503_usuario_crear")
        End If

        'Clipboard.SetText(csql)
        'MsgBox(csql)
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_archivos As New camocontrol.fm_visor_datos
        If p_add_archivos = "S" Then
            oform_mostrar_archivos.bt_nuevo.Enabled = True
            'MsgBox("SI")
        Else
            oform_mostrar_archivos.bt_nuevo.Enabled = False
        End If
        'oform_mostrar_archivos.vf_oform_padre = Me
        oform_mostrar_archivos.csql = csql
        oform_mostrar_archivos.titulo_formulario = "Archivos Asociados al Registro"
        oform_mostrar_archivos.ocontexto_form = "gestion de archivos asociados al registro"
        oform_mostrar_archivos.id_oreg_padre = vf_name_files
        oform_mostrar_archivos.ovalue = vf_var_config_archivos
        oform_mostrar_archivos.id_oreg_padre = vf_id_notas_archivos
        oform_mostrar_archivos.vg_id_cia = vg_id_cia
        oform_mostrar_archivos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_archivos.ShowDialog()

        'Recalculamos la cantidad de archivos
        tot_doc = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados(vf_var_config_archivos & "-001",
                                                                                        vf_id_notas_archivos,
                                                                                        vg_id_cia)
        Return tot_doc
    End Function
    Public Shared Function imagen_ajustada_a_tamaño_maximo(path_file As String, width_maximo As Integer)
        'esta funcion retorna el path de un archivo temporal de imagen al tamaño ajustado
        'borramos todos los temporales
        Dim dir_temp As String() = Directory.GetFiles(Path.GetTempPath(), "*.tmp")
        For Each f As String In dir_temp
            Try
                File.Delete(f)
            Catch ex As Exception
            End Try
        Next

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(path_file)
        Dim filename As String = path_file
        ' Cree un mapa de bits del contenido del control de fileUpload en la memoria
        Dim originalBMP As Bitmap = New Bitmap(path_file)
        ' Calcule las nuevas dimensiones de imagen
        Dim origWidth As Integer = originalBMP.Width
        Dim origHeight As Integer = originalBMP.Height
        Dim sngRatio As Decimal = width_maximo / origWidth
        Dim newWidth As Integer
        Dim newHeight As Integer

        If origWidth >= origHeight Then
            If origWidth > width_maximo Then
                newWidth = width_maximo
                newHeight = origHeight * sngRatio
            Else
                newWidth = origWidth
                newHeight = origHeight
            End If
        End If
        If origHeight > origWidth Then
            If origHeight > width_maximo Then
                sngRatio = width_maximo / origHeight
                newHeight = width_maximo
                newWidth = origWidth * sngRatio
            Else
                newWidth = origWidth
                newHeight = origHeight
            End If
        End If

        ' Cree un nuevo mapa de bits que sostendrá el mapa de bits anterior redimensionado
        Dim newBMP As New Bitmap(originalBMP, newWidth, newHeight)
        Dim file_temp As String = Path.GetTempFileName()
        newBMP.Save(file_temp, System.Drawing.Imaging.ImageFormat.Jpeg)

        ' Una vez terminado con los objetos de mapa de bits, los desasignamos.
        originalBMP.Dispose()
        newBMP.Dispose()
        'oGraphics.Dispose()

        Return file_temp
    End Function
End Class
