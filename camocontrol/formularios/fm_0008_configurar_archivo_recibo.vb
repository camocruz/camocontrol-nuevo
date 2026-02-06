Public Class fm_0008_configurar_archivo_recibo
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_config As Integer

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand

    Private otb_archivo As DataTable
    Private otb_tipos_movimientos As DataTable

    Private nueva_descripcion As String

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private Sub fm_0008_configurar_archivo_recibo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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
        tx_id_config.ReadOnly = True
        bt_anular.Enabled = False
        bt_editar.Enabled = False
        bt_generar_informe.Enabled = False
        bt_nuevo.Enabled = False
        cm_format_fecha.SelectedIndex = 1
        formatear_grilla()

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0011_bancos"
        Dim otb_bancos As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_banco
            'Valor que se muestra al usuario
            .DisplayMember = "f0011_razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0011_id_banco"
            'Origen de Datos del ComboBox
            .DataSource = otb_bancos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        If vf_elemento_nuevo = "N" Then
            cargar_informacion()
        Else
            tx_descripcion.Text = ""
            tx_columnas_archivo.Text = 0
            tx_identificador.Text = ","
            tx_col_verificacion.Text = 0
            tx_long_verificacion.Text = 0
            tx_col_fecha.Text = 0
            tx_col_transaccion.Text = 0
            tx_col_oficina.Text = 0
            tx_col_documento.Text = 0
            tx_col_credito.Text = 0
            tx_col_efectivo.Text = 0
            tx_col_cheque.Text = 0
            tx_col_nit.Text = 0
            tx_col_cliente.Text = 0
        End If

    End Sub
    Private Sub cargar_tipos_recaudos()
        dg_tipos_transacciones.Rows.Clear()
        csql = "Select f0009_id_tipo, f0009_descripcion_tipo" _
            & " FROM " & database.obtener_esquema & ".tb0009_bancos_tipos_recaudos" _
            & " where f0009_id_config = '" & tx_id_config.Text & "' and f0009_id_cia = '" & vg_id_cia & "' and f0009_anulado = 'N'"
        otb_tipos_movimientos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_tipos_movimientos.Rows
            agregar_fila_especificaciones(orow)
        Next
    End Sub
    Private Sub cargar_informacion()
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0008_configuracion_planos_recaudos where f0008_id_config = '" & id_config & "'"
        otb_archivo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_archivo.Rows
            tx_id_config.Text = id_config
            cm_banco.SelectedValue = orow("f0008_id_banco")
            cm_format_fecha.Text = orow("f0008_format_fecha")
            tx_descripcion.Text = orow("f0008_descripcion_banco")
            tx_columnas_archivo.Text = orow("f0008_columnas_archivo")
            tx_identificador.Text = orow("f0008_identificador_columnas")
            tx_col_verificacion.Text = orow("f0008_col_verificacion")
            tx_long_verificacion.Text = orow("f0008_long_col_verificacion")
            tx_col_fecha.Text = orow("f0008_col_fecha")
            tx_col_transaccion.Text = orow("f0008_col_transaccion")
            tx_col_oficina.Text = orow("f0008_col_oficina")
            tx_col_documento.Text = orow("f0008_col_documento")
            tx_col_credito.Text = orow("f0008_col_credito")
            tx_col_efectivo.Text = orow("f0008_col_efectivo")
            tx_col_cheque.Text = orow("f0008_col_cheque")
            tx_col_nit.Text = orow("f0008_col_nit")
            tx_col_cliente.Text = orow("f0008_col_cliente")
            If orow("f0008_req_soporte") = "S" Then
                chk_convenio.Checked = False
            Else
                chk_convenio.Checked = True
            End If
        Next
        cargar_tipos_recaudos()
    End Sub
    Private Sub formatear_grilla()
        dg_tipos_transacciones.AllowUserToAddRows = False
        dg_tipos_transacciones.AllowUserToDeleteRows = False
        dg_tipos_transacciones.AllowUserToResizeColumns = True
        dg_tipos_transacciones.AllowUserToResizeRows = False
        dg_tipos_transacciones.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
    End Sub
    Private Sub agregar_fila_especificaciones(ByVal orow As DataRow)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0009_id_tipo"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0009_descripcion_tipo").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_tipos_transacciones.Rows.Add(orowgrid)
    End Sub
    Private Sub validar_formato_fecha()
        If cm_format_fecha.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Seleccione el formato de fecha!"
        End If
    End Sub
    Private Sub validar_banco()
        If cm_banco.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Seleccione el banco al que pertenece el archivo!"
        End If
    End Sub
    Private Sub validar_descripcion()
        If tx_descripcion.Text.ToString = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la descripcion!"
        End If
    End Sub
    Private Sub validar_columnas_archivo()
        If IsNumeric(tx_columnas_archivo.Text) = False Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El valor de Columnas Archivo debe ser numerico!"
            Exit Sub
        End If
        If CInt(tx_columnas_archivo.Text) < 0 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El valor de Columnas Archivo debe >= 0!"
        End If
    End Sub
    Private Sub tx_identificador_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_identificador.Validating
        validar_identificador()
    End Sub
    Private Sub validar_identificador()
        If tx_identificador.Text.ToString = "" Then
            tx_identificador.Text = ","
        End If
    End Sub
    Private Sub validar_configuracion_columnas(n_control As TextBox, nombre_col As String)
        If IsNumeric(n_control.Text) = False Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El valor de " & nombre_col & " debe ser numerico!"
            Exit Sub
        End If
        If CInt(n_control.Text) < 0 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El valor de " & nombre_col & " debe >= 0!"
        End If
        If CInt(n_control.Text) > CInt(tx_columnas_archivo.Text) Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Valor de " & nombre_col & " sobrepasa a el numero de Columnas Archivo!"
        End If
    End Sub
    Private Sub validar_longitud_de_verificacion()
        If IsNumeric(tx_long_verificacion.Text) = False Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El valor de Longitud Verificacion debe ser numerico!"
            Exit Sub
        End If
        If CInt(tx_long_verificacion.Text) < 0 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El valor Longitud Verificacion debe >= 0!"
        End If
    End Sub

    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_banco()
        validar_descripcion()
        validar_columnas_archivo()
        validar_formato_fecha()
        validar_configuracion_columnas(tx_col_verificacion, "Columna Verificacion")
        validar_longitud_de_verificacion()
        validar_configuracion_columnas(tx_col_fecha, "Columna Fecha")
        validar_configuracion_columnas(tx_col_transaccion, "Columna Transaccion")
        validar_configuracion_columnas(tx_col_oficina, "Columna Oficina")
        validar_configuracion_columnas(tx_col_documento, "Columna Documento")
        validar_configuracion_columnas(tx_col_credito, "Columna Credito")
        validar_configuracion_columnas(tx_col_efectivo, "Columna Efectivo")
        validar_configuracion_columnas(tx_col_cheque, "Columna Cheque")
        validar_configuracion_columnas(tx_col_nit, "Columna NIT")
        validar_configuracion_columnas(tx_col_cliente, "Columna Cliente")
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            grabar_nueva_configuracion()
        Else
            actualizar_configuracion()
        End If
        If verror = "N" Then
            MsgBox("Archivo guardado")
            Dispose()
        End If
    End Sub
    Private Sub grabar_nueva_configuracion()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0008_configuracion_planos_recaudos" _
                & " (f0008_id_cia, f0008_id_banco, f0008_descripcion_banco, f0008_columnas_archivo," _
                & " f0008_identificador_columnas, f0008_col_verificacion, f0008_long_col_verificacion," _
                & " f0008_format_fecha, f0008_col_fecha, f0008_col_transaccion, f0008_col_oficina, f0008_col_documento," _
                & " f0008_col_credito, f0008_col_efectivo, f0008_col_cheque, f0008_req_soporte," _
                & " f0008_col_nit, f0008_col_cliente, f0008_fm, f0008_fr, f0008_usuario_crear, f0008_usuario_modificar)" _
                & " VALUES" _
                & " (@f0008_id_cia, @f0008_id_banco, @f0008_descripcion_banco, @f0008_columnas_archivo," _
                & " @f0008_identificador_columnas, @f0008_col_verificacion, @f0008_long_col_verificacion," _
                & " @f0008_format_fecha, @f0008_col_fecha, @f0008_col_transaccion, @f0008_col_oficina, @f0008_col_documento," _
                & " @f0008_col_credito, @f0008_col_efectivo, @f0008_col_cheque, @f0008_req_soporte," _
                & " @f0008_col_nit, @f0008_col_cliente, @f0008_fm, @f0008_fr, @f0008_usuario_crear, @f0008_usuario_modificar)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Try
            crear_parametros_config(ocmd)
        Catch ex As Exception
            MsgBox("Hubo un error creando parametros! " + vbCrLf + ex.ToString)
        End Try
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
    Private Sub actualizar_configuracion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0008_configuracion_planos_recaudos set "
        csql += "f0008_id_banco = @f0008_id_banco,"
        csql += "f0008_descripcion_banco = @f0008_descripcion_banco,"
        csql += "f0008_columnas_archivo = @f0008_columnas_archivo,"
        csql += "f0008_identificador_columnas = @f0008_identificador_columnas,"
        csql += "f0008_col_verificacion = @f0008_col_verificacion, "
        csql += "f0008_long_col_verificacion = @f0008_long_col_verificacion,"
        csql += "f0008_format_fecha = @f0008_format_fecha,"
        csql += "f0008_col_fecha = @f0008_col_fecha,"
        csql += "f0008_col_transaccion = @f0008_col_transaccion,"
        csql += "f0008_col_oficina = @f0008_col_oficina,"
        csql += "f0008_col_documento = @f0008_col_documento,"
        csql += "f0008_col_credito = @f0008_col_credito,"
        csql += "f0008_col_efectivo = @f0008_col_efectivo,"
        csql += "f0008_col_cheque = @f0008_col_cheque,"
        csql += "f0008_req_soporte = @f0008_req_soporte,"
        csql += "f0008_col_nit = @f0008_col_nit,"
        csql += "f0008_col_cliente = @f0008_col_cliente,"
        csql += "f0008_fm = @f0008_fm,"
        csql += "f0008_fr = @f0008_fr,"
        csql += "f0008_usuario_crear = @f0008_usuario_crear,"
        csql += "f0008_usuario_modificar = @f0008_usuario_modificar"
        csql += " where f0008_id_config = @f0008_id_config"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_config(ocmd)
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
    Private Sub crear_parametros_config(ByVal ocmd As NpgsqlCommand)
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0008_id_config", NpgsqlDbType.Integer).Value = id_config
        End If
        ocmd.Parameters.Add("@f0008_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0008_id_banco", NpgsqlDbType.Integer).Value = CInt(cm_banco.SelectedValue)
        ocmd.Parameters.Add("@f0008_descripcion_banco", NpgsqlDbType.Varchar).Value = UCase(tx_descripcion.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0008_columnas_archivo", NpgsqlDbType.Integer).Value = CInt(tx_columnas_archivo.Text)
        ocmd.Parameters.Add("@f0008_identificador_columnas", NpgsqlDbType.Varchar).Value = tx_identificador.Text.Trim()
        ocmd.Parameters.Add("@f0008_col_verificacion", NpgsqlDbType.Integer).Value = CInt(tx_col_verificacion.Text)
        ocmd.Parameters.Add("@f0008_long_col_verificacion", NpgsqlDbType.Integer).Value = CInt(tx_long_verificacion.Text)
        ocmd.Parameters.Add("@f0008_format_fecha", NpgsqlDbType.Varchar).Value = cm_format_fecha.Text
        ocmd.Parameters.Add("@f0008_col_fecha", NpgsqlDbType.Integer).Value = CInt(tx_col_fecha.Text)
        ocmd.Parameters.Add("@f0008_col_transaccion", NpgsqlDbType.Integer).Value = CInt(tx_col_transaccion.Text)
        ocmd.Parameters.Add("@f0008_col_oficina", NpgsqlDbType.Integer).Value = CInt(tx_col_oficina.Text)
        ocmd.Parameters.Add("@f0008_col_documento", NpgsqlDbType.Integer).Value = CInt(tx_col_documento.Text)
        ocmd.Parameters.Add("@f0008_col_credito", NpgsqlDbType.Integer).Value = CInt(tx_col_credito.Text)
        ocmd.Parameters.Add("@f0008_col_efectivo", NpgsqlDbType.Integer).Value = CInt(tx_col_efectivo.Text)
        ocmd.Parameters.Add("@f0008_col_cheque", NpgsqlDbType.Integer).Value = CInt(tx_col_cheque.Text)
        If chk_convenio.Checked = True Then
            ocmd.Parameters.Add("@f0008_req_soporte", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0008_req_soporte", NpgsqlDbType.Varchar).Value = "S"
        End If
        ocmd.Parameters.Add("@f0008_col_nit", NpgsqlDbType.Integer).Value = CInt(tx_col_nit.Text)
        ocmd.Parameters.Add("@f0008_col_cliente", NpgsqlDbType.Integer).Value = CInt(tx_col_cliente.Text)

        ocmd.Parameters.Add("@f0008_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0008_fr", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0008_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0008_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub

    Private Sub bt_leer_archivo_Click(sender As System.Object, e As System.EventArgs) Handles bt_leer_archivo.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim plano_total As String = ""
        Dim path_file As String = ""
        Dim txt_texto_renglon As String = ""
        Dim txt_texto_evaluacion As String = ""
        Dim txt_texto_total As String = ""
        RichTextBox1.Text = ""

        openFileDialog1.InitialDirectory = "e:\"
        openFileDialog1.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*" 'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        path_file = openFileDialog1.FileName

        Using MyReader As New Microsoft.VisualBasic.
              FileIO.TextFieldParser(path_file, System.Text.Encoding.UTF7) 'FileIO.TextFieldParser(path_file)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(tx_identificador.Text) 'MyReader.SetDelimiters(",")
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
                    txt_texto_evaluacion += "CONFIGURE: " & conta_fields & " COLUMNAS." & vbCrLf & vbCrLf
                    txt_texto_total += txt_texto_evaluacion
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                    Dispose()
                    Exit Sub
                End Try
            End While
        End Using
        RichTextBox1.Text = txt_texto_total
        'comunes.mostrar_archivo_texto("", txt_texto_total)

    End Sub
    Private Sub validar_id_config()
        If tx_id_config.Text.ToString = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Solo se pueden grabar tipos de recaudos en configuraciones grabadas!"
        End If
    End Sub
    Private Sub bt_nuevo_tipo_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo_tipo.Click
        verror_requisitos = "N"
        validar_banco()
        validar_id_config()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        nueva_descripcion = comunes.formulario_parametro_texto("", "Tipo de Movimiento")
        If nueva_descripcion <> "" Then
            grabar_nuevo_tipo()
            If verror = "N" Then
                cargar_tipos_recaudos()
                MsgBox("Nuevo tipo grabado", MsgBoxStyle.Information, "Grabar")
            End If
        End If
    End Sub
    Private Sub grabar_nuevo_tipo()

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0009_bancos_tipos_recaudos" _
                & " (f0009_id_banco, f0009_id_cia, f0009_descripcion_tipo, f0009_id_config," _
                & " f0009_fm, f0009_usuario_crear, f0009_usuario_modificar)" _
                & " VALUES" _
                & " (@f0009_id_banco, @f0009_id_cia, @f0009_descripcion_tipo, @f0009_id_config," _
                & " @f0009_fm, @f0009_usuario_crear, @f0009_usuario_modificar)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Try
            crear_parametros_tipos(ocmd)
        Catch ex As Exception
            MsgBox("Hubo un error creando parametros! " + vbCrLf + ex.ToString)
        End Try
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
    Private Sub crear_parametros_tipos(ByVal ocmd As NpgsqlCommand)
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0009_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0009_id_banco", NpgsqlDbType.Integer).Value = CInt(cm_banco.SelectedValue)
        ocmd.Parameters.Add("@f0009_descripcion_tipo", NpgsqlDbType.Varchar).Value = nueva_descripcion.Trim
        ocmd.Parameters.Add("@f0009_id_config", NpgsqlDbType.Integer).Value = id_config
        ocmd.Parameters.Add("@f0009_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0009_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0009_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub

    Private Sub chk_convenio_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles chk_convenio.Validating
        If chk_convenio.Checked = True Then
            MsgBox("No requerira soporte para asignar la consignacion!", MsgBoxStyle.Exclamation, "Cuidado")
        End If
    End Sub
End Class
