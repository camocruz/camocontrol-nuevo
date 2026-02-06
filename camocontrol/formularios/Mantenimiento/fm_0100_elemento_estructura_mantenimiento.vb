Public Class fm_0100_elemento_estructura_mantenimiento
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"

    Public usuario_creador As String
    '$Public$vg_id_cia As String
    Public id_estructura As Integer
    Public id_estructura_padre As Integer
    Public path_estructura_padre As String = ""
    Public id_codigo As String
    '$Public$vf_elemento_nuevo As String = "N"
    Private otb_estructura_mantenimiento As DataTable 'Informacion que se carga desde el formulario padre

    Private new_name_file As String = ""
    Private id_estructura_raiz As Integer 'la estructura origen de todo el arbol. es la compañia.

    Private id_especificacion As Integer
    Private valor_nuevo As Decimal
    Private valor_actual As Decimal

    Private verror As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String

    Private csql As String
    Private caracteres_consecutivo_hijos As Integer = 3
    Private consecutivo_hermanos As Integer 'Numero de elementos hijos del mismo padre actualmente
    Private otb_elementos_padre As DataTable
    Private otb_tipo_estructura As DataTable
    Private otb_especificaciones As DataTable
    Private otb_items As DataTable

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet


    Private Sub fm_0100_elemento_estructura_mantenimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        cm_subtipo.Enabled = False

        cargar_otabla_estructura()
        cargar_combos_estructura()
        cargar_combos_estructura_padre()
        cargar_combo_items()
        tx_cantidad_item.Text = "1"
        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0107_tipos_estructura order by f0107_orden"
        otb_tipo_estructura = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        cargar_combo_tipo_estructura()
        If vf_elemento_nuevo = "S" Then
            cm_nombre_e_padre.Enabled = False
            id_codigo = generar_codigo_estructura(id_estructura_padre)
            cm_codigo.Text = id_codigo
            tx_valor_actual.Text = "0"
            tx_valor_nuevo.Text = "0"
            'Deshabilitar los controles y las tabpage que necesitan un id_estructura para ejecutar su codigo
            'TabControl1.TabPages("tabpage_especificaciones").Parent = Nothing
            TabControl1.TabPages("tabpage_documentacion").Parent = Nothing
            bt_imagen.Visible = False
        Else
            llenar_informacion_elemento()
        End If
        'pb_imagen_elemento.Image = My.Resources.Logo_Mac_Dulces_01
        'Genera el codigo de los elementos hijo.
        generar_codigo_hijos()
    End Sub
    Private Sub cargar_otabla_estructura()
        csql = "SELECT estructura.*, tb0107_tipos_estructura.*," _
                    & " estructura.f0100_nombre || ' -- { ' || estructura.f0100_codigo || ' } ' || ' -- ' || coalesce(maquina.f0100_nombre,'ND') as descripcion_nombre," _
                    & " estructura.f0100_codigo || ' -- { ' || estructura.f0100_nombre || ' } ' || ' -- ' || coalesce(maquina.f0100_nombre,'ND') as descripcion_codigo" _
                    & " FROM " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as estructura" _
                        & " join " & database.obtener_esquema & ".tb0107_tipos_estructura" _
                            & " on f0100_id_tipo_estructura = f0107_id_tipo_estructura" _
                        & " left join " & database.obtener_esquema & ".tb0100_estructura_mantenimiento as maquina" _
                          & " on maquina.f0100_id_estructura = estructura.f0100_id_maquina_padre" _
                    & " where estructura.f0100_id_cia = '" & vg_id_cia & "' and estructura.f0100_anulado = 'N'" _
                    & " order by estructura.f0100_estructura_padre;"
        otb_estructura_mantenimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim orow As DataRow()
        orow = otb_estructura_mantenimiento.Select("f0100_path = ''")
        id_estructura_raiz = orow(0)("f0100_id_estructura")
    End Sub
    Private Sub calcular_archivos_asociados()
        lb_total_archivos.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-MTO-001", tx_id_estructura.Text, "00000001")
    End Sub
    Private Sub cargar_combos_estructura()
        With cm_codigo
            'Valor que se muestra al usuario
            .DisplayMember = "f0100_codigo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0100_id_estructura"
            'Origen de Datos del ComboBox
            .DataSource = otb_estructura_mantenimiento
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_nombre_elemento
            'Valor que se muestra al usuario
            .DisplayMember = "f0100_nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0100_id_estructura"
            'Origen de Datos del ComboBox
            'If vf_elemento_nuevo = "S" Then
            Dim dv As New DataView(otb_estructura_mantenimiento, "", "", DataViewRowState.CurrentRows)
            .DataSource = dv
            'Else
            '.DataSource = otb_estructura_mantenimiento
            'End If
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub cargar_combos_estructura_padre()
        Dim dv As New DataView(otb_estructura_mantenimiento, "", "", DataViewRowState.CurrentRows)
        With cm_nombre_e_padre
            'Valor que se muestra al usuario
            .DisplayMember = "f0100_nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0100_id_estructura"
            'Origen de Datos del ComboBox
            .DataSource = dv
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            If vf_elemento_nuevo = "S" Then
                .SelectedValue = id_estructura_padre
            Else
                .SelectedIndex = -1
            End If
        End With
    End Sub
    Private Sub cargar_combo_tipo_estructura()
        With cm_tipo_estructura
            'Valor que se muestra al usuario
            .DisplayMember = "f0107_tipo_estructura"
            'Valor interno que almacena el objeto
            .ValueMember = "f0107_id_tipo_estructura"
            'Origen de Datos del ComboBox
            .DataSource = otb_tipo_estructura
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.SelectedValue = id_estructura
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub cargar_combo_items()
        csql = "SELECT *, f0300_descripcion_item || ' ' || f0300_referencia as descripcion_larga" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_id_cia = '" & vg_id_cia & "' and f0300_anulado = 'N'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_item
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion_larga"
            'Valor interno que almacena el objeto
            .ValueMember = "f0300_id_item"
            'Origen de Datos del ComboBox
            .DataSource = otb_items
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = 1
            '.SelectedIndex = -1
        End With
        tx_id_item.Text = 1
    End Sub
    Private Sub llenar_informacion_elemento()
        Dim rowelemento As DataRow() = otb_estructura_mantenimiento.Select("f0100_id_estructura = '" & id_estructura & "'")
        For Each orow As DataRow In rowelemento
            tx_id_estructura.Text = CInt(orow("f0100_id_estructura").ToString)
            path_estructura_padre = orow("f0100_path")
            cm_codigo.SelectedValue = orow("f0100_id_estructura")
            cm_nombre_elemento.SelectedValue = orow("f0100_id_estructura")
            If CInt(orow("f0100_estructura_padre")) = 0 Then
                cm_nombre_e_padre.Text = "RAIZ"
            Else
                cm_nombre_e_padre.SelectedValue = orow("f0100_estructura_padre")
            End If
            tx_descripcion.Text = orow("f0100_descripcion")
            tx_id_item.Text = orow("f0100_id_item")
            cm_item.SelectedValue = orow("f0100_id_item")
            tx_cantidad_item.Text = orow("f0100_cantidad_item")
            tx_texto_elementos_hijo.Text = orow("f0100_texto_codigo_hijos")
            tx_consecutivo_actual_hijos.Text = orow("f0100_consecutivo_hijos")
            tx_caracteres_consecutivo_hijos.Text = orow("f0100_consecutivo_h_caracteres")
            caracteres_consecutivo_hijos = CInt(orow("f0100_consecutivo_h_caracteres"))
            If orow("f0100_consecutivo_h_habilitado") = "S" Then
                chk_consecutivo.Checked = True
            Else
                chk_consecutivo.Checked = False
            End If
            If orow("f0100_anexar_codigo_padre") = "S" Then
                chk_codigo_padre.Checked = True
            Else
                chk_codigo_padre.Checked = False
            End If
            cm_tipo_estructura.SelectedValue = orow("f0100_id_tipo_estructura")
            llenar_descripcion_tipo()
            tx_ubicacion.Text = orow("f0100_ubicacion")
            tx_ano_fabricacion.Text = orow("f0100_ano_fabricacion")
            dtp_fecha_inicio_operacion.Value = orow("f0100_fecha_entrada_operacion")
            tx_fabricante.Text = orow("f0100_fabricante")
            tx_marca.Text = orow("f0100_marca")
            tx_modelo.Text = orow("f0100_modelo")
            tx_serial.Text = orow("f0100_serial")
            valor_nuevo = orow("f0100_valor_nuevo")
            tx_valor_nuevo.Text = valor_nuevo.ToString("C2")
            valor_actual = orow("f0100_valor_actual")
            tx_valor_actual.Text = valor_actual.ToString("C2")
            dtp_fecha_valor_actual.Value = orow("f0100_fecha_valor_actual")
            dtp_fecha_salida_linea.Value = orow("f0100_fecha_salida_linea")
            tx_funcion_requerida.Text = orow("f0100_funcion_requerida")
            If orow("f0100_path_file_imagen") <> "" Then
                Try
                    pb_imagen_elemento.Image = Image.FromFile(orow("f0100_path_file_imagen"))
                Catch SecEx As SecurityException
                    ' The user lacks appropriate permissions to read files, discover paths, etc.
                    MessageBox.Show("Security error. Please contact your administrator for details.\n\n" &
                        "Error message: " & SecEx.Message & "\n\n" &
                        "Details (send to Support):\n\n" & SecEx.StackTrace)
                Catch ex As Exception
                    ' Could not load the image - probably permissions-related.
                    MessageBox.Show(("Cannot display the image: " &
                    ". You may not have permission to read the file, or " + "it may be corrupt." _
                    & ControlChars.Lf & ControlChars.Lf & "Reported error: Imagen no disponible"))
                End Try
            End If
        Next
        id_codigo = cm_codigo.Text
        id_estructura_padre = cm_nombre_e_padre.SelectedValue
        'PARA CONTROLAR LA INFORMACION DE LOS DOCUMENTOS ASOCIADOS
        new_name_file = comunes.suministrar_valor_variable_configuracion("CD-MTO-001", vg_id_cia)
        new_name_file += "-" & tx_id_estructura.Text.PadLeft(8, "0")
        calcular_archivos_asociados()
    End Sub

    Private Sub llenar_descripcion_tipo()
        Dim rowtipoelemento As DataRow() = otb_tipo_estructura.Select("f0107_id_tipo_estructura = '" & cm_tipo_estructura.SelectedValue & "'")
        For Each orow2 As DataRow In rowtipoelemento
            tx_descripcion_tipo.Text = orow2("f0107_descripcion")
        Next
    End Sub
    Private Sub cm_tipo_estructura_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_tipo_estructura.Validating
        llenar_descripcion_tipo()
    End Sub

    Private Function generar_codigo_estructura(ByVal oid_estructura_padre As Integer, ByVal Optional oconsecutivo As Integer = Nothing)
        'El codigo que se propone para el nuevo elemnto que se esta creando
        Dim dv As New DataView(otb_estructura_mantenimiento, "f0100_id_estructura = " & oid_estructura_padre, "", DataViewRowState.CurrentRows)
        Dim caracteres_consecutivo As Integer = 1
        Dim consecutivo_actual As Integer = 0
        Dim codigo_nuevo_elemento As String = ""
        For Each orow As DataRowView In dv
            If orow("f0100_anexar_codigo_padre").ToString.Trim = "S" Then
                codigo_nuevo_elemento = orow("f0100_codigo").ToString.Trim
            End If
            codigo_nuevo_elemento += orow("f0100_texto_codigo_hijos").ToString.Trim
            If orow("f0100_consecutivo_h_habilitado").ToString.Trim = "S" Then
                caracteres_consecutivo = CInt(orow("f0100_consecutivo_h_caracteres"))
                'If IsNothing(oconsecutivo) = True Then
                consecutivo_actual = CInt(orow("f0100_consecutivo_hijos"))
                'Else
                'consecutivo_actual = oconsecutivo + 1
                'End If

                codigo_nuevo_elemento += (CInt(consecutivo_actual) + 1).ToString.PadLeft(caracteres_consecutivo, "0")
            End If
        Next
        Return codigo_nuevo_elemento
    End Function
    Private Sub generar_codigo_hijos()
        tx_ejemplo_codigo_hijos.Text = ""
        Dim cons_ini As Integer = 1
        If chk_codigo_padre.Checked = True Then
            tx_ejemplo_codigo_hijos.Text += cm_codigo.Text
        End If
        tx_ejemplo_codigo_hijos.Text += tx_texto_elementos_hijo.Text
        If chk_consecutivo.Checked = True Then
            tx_ejemplo_codigo_hijos.Text += cons_ini.ToString.PadLeft(caracteres_consecutivo_hijos, "0")
        End If
    End Sub

    Private Sub chk_codigo_padre_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_codigo_padre.CheckedChanged
        generar_codigo_hijos()
    End Sub

    Private Sub chk_consecutivo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_consecutivo.CheckedChanged
        'generar_codigo_hijos()
    End Sub
    Private Sub tx_texto_elementos_hijo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tx_texto_elementos_hijo.TextChanged
        generar_codigo_hijos()
    End Sub
    Private Sub tx_caracteres_consecutivo_hijos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_caracteres_consecutivo_hijos.Validating
        If tx_caracteres_consecutivo_hijos.Text = "" Then
            tx_caracteres_consecutivo_hijos.Text = 3
            caracteres_consecutivo_hijos = 3
        End If
        If IsNumeric(tx_caracteres_consecutivo_hijos.Text) = False Then
            MsgBox("El valor de caracteres debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_caracteres_consecutivo_hijos.Text = 3
            caracteres_consecutivo_hijos = 3
        End If
        If CInt(tx_caracteres_consecutivo_hijos.Text) > 8 Then
            tx_caracteres_consecutivo_hijos.Text = 8
            caracteres_consecutivo_hijos = 8
        End If
        caracteres_consecutivo_hijos = CInt(tx_caracteres_consecutivo_hijos.Text)
        generar_codigo_hijos()
    End Sub

    Private Function grabar_nuevo_elemento_mantenimiento()
        Dim id_creado As Integer
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
                & " (f0100_id_cia, f0100_nombre, f0100_descripcion," _
                & " f0100_codigo, f0100_estructura_padre," _
                & " f0100_texto_codigo_hijos, f0100_consecutivo_hijos, f0100_consecutivo_h_caracteres," _
                & " f0100_consecutivo_h_habilitado, f0100_anexar_codigo_padre, f0100_id_tipo_estructura," _
                & " f0100_ubicacion, f0100_ano_fabricacion, f0100_fecha_entrada_operacion," _
                & " f0100_codigo_proyecto, f0100_fabricante, f0100_marca, f0100_modelo," _
                & " f0100_serial, f0100_path, f0100_id_item, f0100_cantidad_item," _
                & " f0100_valor_nuevo, f0100_valor_actual, f0100_fecha_valor_actual, f0100_fecha_salida_linea," _
                & " f0100_funcion_requerida, f0100_usuario_crear, f0100_usuario_modificar, f0100_fm)" _
                & " VALUES" _
                & " (@f0100_id_cia, @f0100_nombre, @f0100_descripcion," _
                & " @f0100_codigo, @f0100_estructura_padre," _
                & " @f0100_texto_codigo_hijos, @f0100_consecutivo_hijos, @f0100_consecutivo_h_caracteres," _
                & " @f0100_consecutivo_h_habilitado, @f0100_anexar_codigo_padre, @f0100_id_tipo_estructura," _
                & " @f0100_ubicacion, @f0100_ano_fabricacion, @f0100_fecha_entrada_operacion," _
                & " @f0100_codigo_proyecto, @f0100_fabricante, @f0100_marca, @f0100_modelo," _
                & " @f0100_serial, @f0100_path, @f0100_id_item, @f0100_cantidad_item," _
                & " @f0100_valor_nuevo, @f0100_valor_actual, @f0100_fecha_valor_actual, @f0100_fecha_salida_linea," _
                & " @f0100_funcion_requerida, @f0100_usuario_crear, @f0100_usuario_modificar, @f0100_fm)" _
                & " RETURNING f0100_id_estructura;"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_grabar_elemento_mantenimiento(ocmd)

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
                id_creado = ocmd.ExecuteScalar()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try

            'Cuando es un elemento nuevo hay que aumentar el conecutivo de los elementos en el elemento padre
            If cm_nombre_e_padre.Text <> "RAIZ" And verror = "N" Then
                csql = "update " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
                    & " set f0100_consecutivo_hijos = @f0100_consecutivo_hijos" _
                    & " where f0100_id_estructura = '" & id_estructura_padre & "'"

                ocmd.CommandText = csql

                ocmd.Parameters.Clear()
                ocmd.Parameters.Add("@f0100_consecutivo_hijos", NpgsqlDbType.Varchar).Value = consecutivo_hermanos.ToString()

                Try
                    ocmd.ExecuteNonQuery()
                Catch ex As Exception
                    verror = "S"
                    MsgBox("Hubo un error al actualizar consecutivo hermanos! " + vbCrLf + ex.ToString)
                End Try
            End If
        End If

        ocmd = Nothing
        oconn_form.Close()
        Return id_creado
    End Function
    Private Sub actualizar_elemento_mantenimiento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0100_estructura_mantenimiento set "
        csql += "f0100_nombre = @f0100_nombre,"
        csql += "f0100_descripcion = @f0100_descripcion,"
        csql += "f0100_codigo = @f0100_codigo,"
        csql += "f0100_estructura_padre = @f0100_estructura_padre,"
        csql += "f0100_texto_codigo_hijos = @f0100_texto_codigo_hijos,"
        csql += "f0100_consecutivo_hijos = @f0100_consecutivo_hijos,"
        csql += "f0100_consecutivo_h_caracteres = @f0100_consecutivo_h_caracteres,"
        csql += "f0100_consecutivo_h_habilitado = @f0100_consecutivo_h_habilitado,"
        csql += "f0100_anexar_codigo_padre = @f0100_anexar_codigo_padre,"
        csql += "f0100_id_tipo_estructura = @f0100_id_tipo_estructura,"
        csql += "f0100_ubicacion = @f0100_ubicacion,"
        csql += "f0100_ano_fabricacion = @f0100_ano_fabricacion,"
        csql += "f0100_fecha_entrada_operacion = @f0100_fecha_entrada_operacion,"
        csql += "f0100_fabricante = @f0100_fabricante,"
        csql += "f0100_marca = @f0100_marca,"
        csql += "f0100_modelo = @f0100_modelo,"
        csql += "f0100_serial = @f0100_serial,"
        csql += "f0100_path = @f0100_path,"
        csql += "f0100_id_item = @f0100_id_item,"
        csql += "f0100_cantidad_item = @f0100_cantidad_item,"
        csql += "f0100_valor_nuevo = @f0100_valor_nuevo,"
        csql += "f0100_valor_actual = @f0100_valor_actual,"
        csql += "f0100_fecha_valor_actual = @f0100_fecha_valor_actual,"
        csql += "f0100_fecha_salida_linea = @f0100_fecha_salida_linea,"
        csql += "f0100_funcion_requerida = @f0100_funcion_requerida,"
        csql += "f0100_usuario_modificar = @f0100_usuario_modificar,"
        csql += "f0100_fm = @f0100_fm"
        csql += " where f0100_id_estructura = " & id_estructura

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_grabar_elemento_mantenimiento(ocmd)
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
    Private Sub crear_parametros_grabar_elemento_mantenimiento(ByVal ocmd As NpgsqlCommand)
        Dim _f0100_estructura_padre As Integer = 0
        If cm_nombre_e_padre.Text = "RAIZ" Then
            _f0100_estructura_padre = 0
        Else
            _f0100_estructura_padre = CInt(cm_nombre_e_padre.SelectedValue.ToString)
        End If
        Dim _f0100_id_item As Integer = CInt(cm_item.SelectedValue.ToString)
        Dim _f0100_cantidad_item As Integer = CInt(tx_cantidad_item.Text.ToString.Trim)

        ocmd.Parameters.Clear()
        '& " , , f0100_id_file," _
        ocmd.Parameters.Add("@f0100_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia.ToString.Trim.PadLeft(8, "0")
        ocmd.Parameters.Add("@f0100_nombre", NpgsqlDbType.Varchar).Value = UCase(cm_nombre_elemento.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0100_descripcion", NpgsqlDbType.Varchar).Value = tx_descripcion.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_codigo", NpgsqlDbType.Varchar).Value = id_codigo.ToString.Trim
        ocmd.Parameters.Add("@f0100_estructura_padre", NpgsqlDbType.Integer).Value = _f0100_estructura_padre

        ocmd.Parameters.Add("@f0100_texto_codigo_hijos", NpgsqlDbType.Varchar).Value = tx_texto_elementos_hijo.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_consecutivo_hijos", NpgsqlDbType.Varchar).Value = tx_consecutivo_actual_hijos.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_consecutivo_h_caracteres", NpgsqlDbType.Varchar).Value = tx_caracteres_consecutivo_hijos.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_consecutivo_h_habilitado", NpgsqlDbType.Char).Value = If(chk_consecutivo.Checked, "S", "N")
        ocmd.Parameters.Add("@f0100_anexar_codigo_padre", NpgsqlDbType.Char).Value = If(chk_codigo_padre.Checked, "S", "N")
        ocmd.Parameters.Add("@f0100_id_tipo_estructura", NpgsqlDbType.Varchar).Value = cm_tipo_estructura.SelectedValue.ToString
        ocmd.Parameters.Add("@f0100_ubicacion", NpgsqlDbType.Varchar).Value = tx_ubicacion.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_ano_fabricacion", NpgsqlDbType.Char).Value = If(tx_ano_fabricacion.Text.Trim = "", "1800", tx_ano_fabricacion.Text.Trim)

        ocmd.Parameters.Add("@f0100_fecha_entrada_operacion", NpgsqlDbType.Timestamp).Value = dtp_fecha_inicio_operacion.Value
        If cm_proyectos.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0100_codigo_proyecto", NpgsqlDbType.Varchar).Value = "00000000"
        Else
            ocmd.Parameters.Add("@f0100_codigo_proyecto", NpgsqlDbType.Varchar).Value = cm_proyectos.SelectedValue.ToString.Trim
        End If
        ocmd.Parameters.Add("@f0100_fabricante", NpgsqlDbType.Varchar).Value = tx_fabricante.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_marca", NpgsqlDbType.Varchar).Value = tx_marca.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_modelo", NpgsqlDbType.Varchar).Value = tx_modelo.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_serial", NpgsqlDbType.Varchar).Value = tx_serial.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_path", NpgsqlDbType.Varchar).Value = path_estructura_padre '& "-" & id_estructura_padre 'sumarle el id de la estructura nueva para completar la direccion
        ocmd.Parameters.Add("@f0100_id_item", NpgsqlDbType.Integer).Value = _f0100_id_item
        ocmd.Parameters.Add("@f0100_cantidad_item", NpgsqlDbType.Integer).Value = _f0100_cantidad_item
        ocmd.Parameters.Add("@f0100_valor_nuevo", NpgsqlDbType.Numeric).Value = CDec(tx_valor_nuevo.Text)
        ocmd.Parameters.Add("@f0100_valor_actual", NpgsqlDbType.Numeric).Value = CDec(tx_valor_actual.Text)
        ocmd.Parameters.Add("@f0100_fecha_valor_actual", NpgsqlDbType.Timestamp).Value = dtp_fecha_valor_actual.Value
        ocmd.Parameters.Add("@f0100_fecha_salida_linea", NpgsqlDbType.Timestamp).Value = dtp_fecha_salida_linea.Value
        ocmd.Parameters.Add("@f0100_funcion_requerida", NpgsqlDbType.Varchar).Value = tx_funcion_requerida.Text.ToString.Trim
        ocmd.Parameters.Add("@f0100_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza.ToString.Trim
        ocmd.Parameters.Add("@f0100_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza.ToString.Trim
        ocmd.Parameters.Add("@f0100_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora.ToLocalTime()

    End Sub
    Private Sub validar_tipo_estructura()
        If cm_tipo_estructura.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el tipo de estructura."
        End If
    End Sub
    Private Sub validar_nombre_elemento()
        If cm_nombre_elemento.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el nombre del elemento."
        End If
    End Sub
    Private Sub validar_codigo()
        If cm_codigo.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el codigo del elemento."
        End If
        cm_codigo.Text = UCase(cm_codigo.Text.Trim)
        id_codigo = UCase(cm_codigo.Text.Trim)
        If vf_elemento_nuevo = "S" Then
            If cm_codigo.SelectedIndex <> -1 Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Codigo del elemento ya existe."
            End If
        End If
    End Sub

    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_codigo()
        validar_tipo_estructura()
        validar_nombre_elemento()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        'Pregunta si realmente desea grabar cambios
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Grabar Cambios", "Desea grabar cambios en este registro?")
        If respuesta = "N" Then
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            csql = "Select max(f0100_consecutivo_hijos) As hermanos" _
                & " from " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
                & " where f0100_id_estructura = '" & id_estructura_padre & "'"
            Dim otb_hermanos As DataTable
            otb_hermanos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            For Each orow As DataRow In otb_hermanos.Rows
                consecutivo_hermanos = CInt(orow("hermanos")) + 1
            Next
            'grabar_nuevo_elemento_mantenimiento()
            'id_estructura = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0100_id_estructura", "f0100_usuario_modificar", vg_usuario_autoriza, "tb0100_estructura_mantenimiento")

            id_estructura = grabar_nuevo_elemento_mantenimiento()

            vf_elemento_nuevo = "N"
            tx_id_estructura.Text = id_estructura
            vf_oform_padre.nodo_padre_tag = id_estructura
        Else
            actualizar_elemento_mantenimiento()
        End If
        If verror = "N" Then
            MsgBox("Elemento grabado exitosamente", MsgBoxStyle.Information, "Grabar")
            'Cuando es un elemento nuevo hay que aumentar el conecutivo de los elementos en el elemento padre
            fm_0100_estructura_mantenimiento.nodo_padre_tag = id_estructura
            'funcion que recalculara las estructuras padre de la estructura de mantenimiento.
            cl_utilidades_gestion_mantenimiento.actualizar_estructura_padre(vg_id_cia)
            cl_utilidades_gestion_mantenimiento.actualizar_hijos_de_maquinas(vg_id_cia)
        End If

        'Exporto el listado de la estrucrura
        csql = "select * from " & database.obtener_esquema & ".fnc_100_01_exportar_listados_extructura()"
        cl_utilidades_datatables.ejecutar_csql(csql)

    End Sub

    Private Sub cm_codigo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_codigo.Validating
        'validamos que el codigo que estamos digitando no ha sido usado por otro componente.
        If cm_codigo.SelectedIndex = -1 Then
            id_codigo = cm_codigo.Text
        Else
            MsgBox("Este codigo ya esta en uso", MsgBoxStyle.Exclamation, "Error")
            cm_codigo.Text = id_codigo
        End If
        generar_codigo_hijos()
    End Sub


    Private Sub bt_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_anular.Click

    End Sub

    Private Sub tx_id_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_id_item.Validating
        If IsNumeric(tx_id_item.Text) = False Or tx_id_item.Text.Trim = "" Then
            MsgBox("El valor debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_id_item.Text = ""
            Exit Sub
        End If
        cm_item.Focus()
        cm_item.SelectedValue = CInt(tx_id_item.Text)
    End Sub

    Private Sub cm_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_item.Validating
        If cm_item.SelectedIndex = -1 Then
            If cm_item.Text.ToString.Trim <> "" Then
                MsgBox("El Item no existe", MsgBoxStyle.Information, "Error")
            End If
            cm_item.Text = ""
            tx_id_item.Text = ""
        Else
            tx_id_item.Text = CInt(cm_item.SelectedValue)
        End If
    End Sub

    Private Sub tx_cantidad_item_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_cantidad_item.Validating
        If tx_cantidad_item.Text.Trim = "" Then
            MsgBox("defina una cantidad", MsgBoxStyle.Critical, "Error")
            tx_cantidad_item.Text = "1"
            tx_cantidad_item.Focus()
        End If
        If IsNumeric(tx_cantidad_item.Text.Trim) = False Then
            MsgBox("El valor de caracteres debe ser numerico", MsgBoxStyle.Critical, "Error")
            tx_cantidad_item.Text = "1"
            tx_cantidad_item.Focus()
        Else
            If CInt(tx_cantidad_item.Text.Trim) <= 0 Then
                MsgBox("El valor de caracteres debe ser mayor a 0", MsgBoxStyle.Critical, "Error")
                tx_cantidad_item.Text = "1"
                tx_cantidad_item.Focus()
            End If
        End If
    End Sub
    Private Sub tx_valor_nuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_valor_nuevo.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub tx_valor_nuevo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_valor_nuevo.Validating
        If tx_valor_nuevo.Text.Trim = "" Then
            tx_valor_nuevo.Text = 0
        End If
        Dim ovalor As Decimal = tx_valor_nuevo.Text
        tx_valor_nuevo.Text = ovalor.ToString("C2")
    End Sub
    Private Sub tx_valor_actual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_valor_actual.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub tx_valor_actual_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_valor_actual.Validating
        If tx_valor_actual.Text.Trim = "" Then
            tx_valor_actual.Text = 0
        End If
        Dim ovalor As Decimal = tx_valor_actual.Text
        tx_valor_actual.Text = ovalor.ToString("C2")
    End Sub

    Private Sub bt_nuevo_documento_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo_documento.Click
        cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-MTO", tx_id_estructura.Text, vg_id_cia, vg_usuario_autoriza, "N")
        calcular_archivos_asociados()
    End Sub

    Private Sub bt_ver_archivos_asociados_Click(sender As System.Object, e As System.EventArgs) Handles bt_ver_archivos_asociados.Click
        csql = "SELECT f0503_id_archivo as id_file, f0503_ed as documento, f0503_descripcion_archivo as descripcion," _
    & " to_char(f0503_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_carga, f0503_nombre_original as origen" _
    & " from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
    & " where f0503_nombre_archivo = '" & new_name_file & "' and f0503_id_cia = '" & vg_id_cia & "'" _
    & " order by f0503_id_archivo desc"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_archivos As New camocontrol.fm_visor_datos
        oform_mostrar_archivos.vf_oform_padre = Me
        oform_mostrar_archivos.csql = csql
        oform_mostrar_archivos.titulo_formulario = "Archivos Asociados"
        oform_mostrar_archivos.vg_id_cia = vg_id_cia
        oform_mostrar_archivos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_archivos.ShowDialog()
    End Sub

    Private Sub bt_imagen_Click_1(sender As System.Object, e As System.EventArgs) Handles bt_imagen.Click
        Dim oreturn() As String
        oreturn = cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("IMGMTO", id_estructura, vg_id_cia, vg_usuario_autoriza, "N")
        If oreturn(0) = "" Then
            Exit Sub 'no se hizo ningun cambio
        End If

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0100_estructura_mantenimiento set "
        csql += "f0100_id_file_imagen = @f0100_id_file_imagen,"
        csql += "f0100_path_file_imagen = @f0100_path_file_imagen,"
        csql += "f0100_usuario_modificar = @f0100_usuario_modificar,"
        csql += "f0100_fm = @f0100_fm"
        csql += " where f0100_id_estructura = " & id_estructura

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_grabar_elemento_mantenimiento(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0100_id_file_imagen", NpgsqlDbType.Integer).Value = CInt(oreturn(0))
        ocmd.Parameters.Add("@f0100_path_file_imagen", NpgsqlDbType.Varchar).Value = oreturn(1)
        ocmd.Parameters.Add("@f0100_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza.ToString.Trim
        ocmd.Parameters.Add("@f0100_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
        End Try
        ocmd = Nothing
        oconn_form.Close()
        pb_imagen_elemento.Image = Image.FromFile(oreturn(1))
        MsgBox("Imagen Actualizada", MsgBoxStyle.Information, "Ok")
    End Sub

    Private Sub bt_cambiar_codigo_ramal_Click(sender As Object, e As EventArgs) Handles bt_cambiar_codigo_ramal.Click
        cargar_otabla_estructura()
        llenar_informacion_elemento()

        'esto se debe aplicar solo para maquinas

        Dim path_raiz_arbol As String = path_estructura_padre & id_estructura & "-"
        'MsgBox(path_raiz_arbol)
        'modifico el elemento raiz
        'MsgBox(id_estructura)
        'modifico los hijos
        cambiar_codigos(path_raiz_arbol)
    End Sub
    Private Sub cambiar_codigos(ByVal path_raiz_arbol As String)

        Dim orow_padre As DataRow() = otb_estructura_mantenimiento.Select("f0100_path = '" & path_raiz_arbol & "'")
        Dim ocontador As Integer = 1
        Dim nuevo_codigo As String = ""
        For Each orow_hijos As DataRow In orow_padre
            'MsgBox(orow_hijos("f0100_id_estructura"))
            'buscar la estructura padre
            nuevo_codigo = generar_codigo_estructura(orow_hijos("f0100_estructura_padre"), ocontador)
            'actualizo el codigo de la estructura
            'TENGO QUE ACTUALIZAR EL DATATABLE
            orow_hijos("f0100_codigo") = nuevo_codigo
            MsgBox(nuevo_codigo & " - " & orow_hijos("f0100_estructura_padre"))
            'genero la iteracion para actualizar los hijos
            cambiar_codigos(orow_hijos("f0100_path") & orow_hijos("f0100_id_estructura") & "-")
            ocontador += 1
        Next
        'Actualizo el consecutivo actual de la estructura
    End Sub

    Private Sub bt_listado_general_items_Click(sender As Object, e As EventArgs) Handles bt_listado_general_items.Click
        cl_utilidades_datatables.visualizar_datos_visor("ST-0300-34", vg_id_cia, vg_usuario_autoriza,
                                                    "Listado General de Items", {vg_id_cia})
    End Sub

    Private Sub bt_catalago_items_Click(sender As Object, e As EventArgs) Handles bt_catalago_items.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0300_gestion_items
        oform_catalogo_items.vf_oform_padre = Me
        oform_catalogo_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_catalogo_items.vg_id_cia = vg_id_cia
        'oform_catalogo_items.vf_elemento_nuevo = "N"
        oform_catalogo_items.ShowDialog()
        cargar_combo_items()
    End Sub
End Class
