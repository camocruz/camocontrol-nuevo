Imports System.ComponentModel

Public Class fm_importador_datos_txt_plano
    Public ocontexto_form As String = ""
    Public id_file_plano As String = "UCCO1099"
    Public visualizar_datatables As String = "S"
    Public ds As DataSet
    Private csql As String = ""
    Public otb_encabezado As DataTable
    Public otb_detalle As DataTable
    Private ocolum_referencial As Integer 'Para identificar que campo del encabezado sera usado como referencial en los detalles
    Private id_linea_leida As Integer
    Private oencabezado() As String  '= {({"128", "15", "*-[A-Z][A-Z]-*", "128", "15"}), ({"128", "12", "####-[A-Z][A-Z][A-Z]-##", "128", "12"})}
    Private odetalle() As String
    Private otb_txt_ref As DataTable
    Private otb_secciones As DataTable
    Private criterios_n_linea() As String
    Private texto_futuro As String = "N"
    Private path_file As String = ""
    Private otb_configuraciones As DataTable


    Private Sub fm_importador_datos_txt_plano_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        csql = "select * from " & database.obtener_esquema & ".tb0012_config_read_cg"
        csql += " where f0012_anulado = 'N' and f0012_id_cia = '" & vg_id_cia & "'"
        otb_configuraciones = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_configuracion
            'Valor que se muestra al usuario
            .DisplayMember = "f0012_archivo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0012_archivo"
            'Origen de Datos del ComboBox
            .DataSource = otb_configuraciones
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub cm_configuracion_Validating(sender As Object, e As CancelEventArgs) Handles cm_configuracion.Validating
        'fffdgfdgd

    End Sub
    Private Sub definir_archivo()
        'llamo el filedialog para buscar el archivo
        Dim openFileDialog1 As New OpenFileDialog()
        If tx_archivo.Text = String.Empty Then
            'openFileDialog1.InitialDirectory = "e:\"
            openFileDialog1.Filter = "csv files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*" 'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 1
            openFileDialog1.RestoreDirectory = True
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path_file = openFileDialog1.FileName
                tx_archivo.Text = openFileDialog1.FileName.ToString
                'comunes.mostrar_archivo_texto(path_file, "")
            Else
                Exit Sub
            End If
        Else
            path_file = tx_archivo.Text
        End If
    End Sub

    Private Sub bt_buscar_Click(sender As Object, e As EventArgs) Handles bt_buscar.Click
        If cm_configuracion.SelectedIndex = -1 Then
            MsgBox("Seleccione un archivo de configuracion")
            Exit Sub
        End If
        If path_file = "" Then
            definir_archivo()
        End If

        dgw_encontrados.Rows.Clear()

        'inicio proceso de prueba de criterio definido
        Dim oconfigpartes As String()
        oconfigpartes = Split(tx_definicion.Text.Trim, ";")
        Dim lector As New IO.StreamReader(path_file, System.Text.Encoding.UTF8)

        '128; 12; *-[A-Z][A-Z]-*; 128; 15 | 128; 12; ####-[A-Z][A-Z][A-Z]-##; 128; 12
        ' Leer el contenido mientras no se llegue al final
        Dim contador As Integer = 0
        Dim txt_testCheck As Boolean = False
        id_linea_leida = 1
        While lector.Peek() <> -1
            Dim linea As String = Replace(lector.ReadLine(), "\'d1", "Ñ")
            ' Si está vacía, continuar el bucle
            If String.IsNullOrEmpty(linea) Then
                Continue While
            End If
            'busco los valores que encuentro y muestro para evaluacion
            txt_testCheck = linea Like "*" & tx_buscador.Text & "*"
            If txt_testCheck = True And contador < 20 Then
                'MsgBox("Coincidencia en la linea: " & id_linea_leida)
                contador += 1
                tx_ubicacion.Text = InStr(linea, tx_buscador.Text) & ";" & Len(tx_buscador.Text)
                tx_formato.Text = "*" & tx_buscador.Text.Trim & "*"
                dgw_encontrados.Rows.Add(id_linea_leida, tx_ubicacion.Text)
            End If
            id_linea_leida += 1
        End While
        ' Cerrar el fichero
        lector.Close()
        MsgBox("Ejecutado")
    End Sub

    Private Sub bt_probar_Click(sender As Object, e As EventArgs) Handles bt_probar.Click
        If tx_definicion.Text = "" Then
            MsgBox("Genere cadena de prueba", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim info_busqueda As cl_importador_planos.info_busqueda_campo
        dgw_encontrados.Rows.Clear()
        definir_archivo()
        'MsgBox(tx_definicion.Text.Trim)
        'inicio proceso de prueba de criterio definido
        Dim oconfigpartes As String()
        Dim txconfiguracion As String = Replace(tx_definicion.Text.Trim, "┴", "")
        oconfigpartes = Split(txconfiguracion, ";")
        Dim lector As New IO.StreamReader(path_file, System.Text.Encoding.Default)
        Dim valor_encontrado As String = ""
        'MsgBox("Estoy aqui")
        '128; 12; *-[A-Z][A-Z]-*; 128; 15 | 128; 12; ####-[A-Z][A-Z][A-Z]-##; 128; 12
        ' Leer el contenido mientras no se llegue al final
        Dim contador As Integer = 0
        Dim txt_mostrar As String = ""
        id_linea_leida = 1
        While lector.Peek() <> -1
            Dim linea As String = Replace(lector.ReadLine(), "\'d1", "Ñ")
            ' Si está vacía, continuar el bucle
            If String.IsNullOrEmpty(linea) Then
                Continue While
            End If
            'busco los valores que encuentro y muestro para evaluacion
            info_busqueda = cl_importador_planos.buscar_campo(linea, oconfigpartes)
            valor_encontrado = info_busqueda.valor_encontrado
            'MsgBox(valor_encontrado)
            If valor_encontrado <> "" And contador <= 5 Then
                txt_mostrar += valor_encontrado & vbCrLf
                dgw_encontrados.Rows.Add(id_linea_leida, valor_encontrado)
                contador += 1
                'MsgBox(txt_mostrar)
            End If
            id_linea_leida += 1
        End While
        ' Cerrar el fichero
        lector.Close()
    End Sub

    Private Sub bt_salir_Click(sender As Object, e As EventArgs) Handles bt_salir.Click
        Me.Hide()
    End Sub

    Private Sub bt_importar_Click(sender As Object, e As EventArgs) Handles bt_importar.Click
        If cm_configuracion.SelectedIndex = -1 Then
            MsgBox("Seleccione un archivo de configuracion")
            Exit Sub
        End If
        If path_file = "" Then
            definir_archivo()
        End If
        Dim file_plano As String = cm_configuracion.SelectedValue
        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "e: \"
        openFileDialog1.Filter = "csv files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*" 'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.Title = "Buscar Archivo " & file_plano
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path_file = openFileDialog1.FileName
            'comunes.mostrar_archivo_texto(path_file, "")
        Else
            Exit Sub
        End If

        'BackgroundWorker1.RunWorkerAsync()

        'Importo las tablas encabezado y detalle generadas de la importacion del plano

        Dim ds As DataSet = cl_importador_planos.importador_planos_a_dataset(file_plano, "S", vg_id_cia, vg_usuario_autoriza, path_file).copy()
        For Each otable As DataTable In ds.Tables
            MsgBox(otable.TableName & " cantidad " & otable.Rows.Count)
        Next
    End Sub

    Private Sub bt_armar_arreglo_Click(sender As Object, e As EventArgs) Handles bt_armar_arreglo.Click
        Dim txt_arreglo As String
        txt_arreglo = tx_nombre_campo.Text.Trim & ";"
        txt_arreglo += cm_tipo_datos.Text & ";"
        txt_arreglo += tx_ubicacion.Text & ";"
        txt_arreglo += tx_formato.Text & ";"
        txt_arreglo += tx_ini_long_val_traer.Text & ";"
        txt_arreglo += tx_lineas_futuras.Text & "┴"
        tx_definicion.Text = txt_arreglo
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim file_Plano As String = "UCIN3056"
        Dim path_file As String = "\\192.168.0.90\pub_macdulces\camo\3056\UCIN3056-P1.rtf"
        Dim otb1 As DataTable
        Dim otb2 As DataTable
        Dim ds As DataSet = cl_importador_planos.importador_planos_a_dataset(file_Plano, "N", vg_id_cia, vg_usuario_autoriza, path_file).copy()
        otb1 = ds.Tables.Item("INFO_INVENTARIO").Copy()
        ds.Clear()
        path_file = "\\192.168.0.90\pub_macdulces\camo\3056\UCIN3056-P2.rtf"
        ds = cl_importador_planos.importador_planos_a_dataset(file_Plano, "N", vg_id_cia, vg_usuario_autoriza, path_file).copy()
        otb2 = ds.Tables.Item("INFO_INVENTARIO").Copy()
        'MsgBox(otb1.Rows.Count)
        'MsgBox(otb2.Rows.Count)
        otb1.Merge(otb2, True)
        'MsgBox(otb1.Rows.Count)
        cl_utilidades_datatables.datatable_to_csv_filesavedialog(otb1, False, vg_id_cia)
    End Sub
End Class
