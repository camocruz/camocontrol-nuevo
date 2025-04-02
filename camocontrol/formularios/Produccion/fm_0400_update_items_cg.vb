Public Class fm_0400_update_items_cg
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"

    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private otb_item As DataTable

    Private Sub fm_0400_update_items_cg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        'Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        csql = "SELECT f0303_id_linea_item," _
               & " CASE WHEN f0303_nivel=1 THEN f0303_descripcion_linea_item" _
                   & " When f0303_nivel=2 Then '      *   ' || f0303_descripcion_linea_item" _
                   & " WHEN f0303_nivel=3 THEN '      *  *     ' || f0303_descripcion_linea_item" _
                   & " WHEN f0303_nivel=4 THEN '         *  *  *       ' || f0303_descripcion_linea_item" _
                   & "                    ELSE '            *  *  *  *=>   ' || f0303_descripcion_linea_item" _
               & " END as linea," _
               & " f0303_path || f0303_id_linea_item || '-' as path," _
               & " f0303_nivel" _
               & " FROM camocontrol.tb0303_lineas_items" _
               & " where f0303_id_cia = '00000001'" _
               & " order by path"
        Dim otb_linea As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_linea
            'Valor que se muestra al usuario
            .DisplayMember = "linea"
            'Valor interno que almacena el objeto
            .ValueMember = "f0303_id_linea_item"
            'Origen de Datos del ComboBox
            .DataSource = otb_linea
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With


    End Sub
    Private Sub traer_info_item_cg(ByVal referencia_cg As String)
        If tx_referencia.Text.ToString.Trim = "" Then
            Exit Sub
        End If
        csql = "select * from " & database.obtener_esquema & ".tb0408_items_cg"
        csql += " where f0408_referencia = '" & referencia_cg & "'"
        otb_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_item.Rows.Count = 0 Then
            MsgBox("La referencia no existe")
            reset_campos()
            Exit Sub
        End If
        tx_planta.Text = otb_item(0)("f0408_planta").ToString
        tx_tipo_produccion.Text = otb_item(0)("f0408_tip_produccion").ToString
        tx_tipo_producto.Text = otb_item(0)("f0408_tip_producto").ToString
        cm_linea.SelectedValue = otb_item(0)("f0408_id_linea").ToString
        lb_descripcion.Text = otb_item(0)("f0408_descripcion").ToString
        tx_peso_unitario.Text = otb_item(0)("f0408_peso").ToString
        tx_unidad_medida.Text = otb_item(0)("f0408_unid_medida").ToString
        tx_factor_empaque.Text = otb_item(0)("f0408_factor_empaque").ToString
        tx_factor_cobertura.Text = otb_item(0)("f0408_factor_cobertura").ToString
        tx_tipo_venta.Text = otb_item(0)("f0408_tip_venta").ToString
        tx_corrugado.Text = otb_item(0)("f0408_id_caja_corrugado").ToString
    End Sub
    Private Sub reset_campos()
        tx_referencia.Text = ""
        tx_planta.Text = ""
        tx_tipo_produccion.Text = ""
        tx_tipo_producto.Text = ""
        cm_linea.SelectedIndex = -1
        lb_descripcion.Text = "ND"
        tx_peso_unitario.Text = ""
        tx_unidad_medida.Text = ""
        tx_factor_empaque.Text = ""
        tx_factor_cobertura.Text = ""
        tx_tipo_venta.Text = ""
        tx_referencia.Select()
        tx_corrugado.Text = ""
    End Sub
    Private Sub actualizar_item()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0408_items_cg set "
        csql += "f0408_planta = @f0408_planta,"
        csql += "f0408_tip_produccion = @f0408_tip_produccion,"
        csql += "f0408_tip_producto = @f0408_tip_producto,"
        csql += "f0408_id_linea = @f0408_id_linea,"
        csql += "f0408_unid_medida = @f0408_unid_medida,"
        csql += "f0408_factor_empaque = @f0408_factor_empaque,"
        csql += "f0408_factor_cobertura = @f0408_factor_cobertura,"
        csql += "f0408_peso = @f0408_peso,"
        csql += "f0408_tip_venta = @f0408_tip_venta,"
        csql += "f0408_id_caja_corrugado = @f0408_id_caja_corrugado"
        csql += " where f0408_referencia = @f0408_referencia"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_item(ocmd)
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
                MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_item(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0408_planta", NpgsqlDbType.Varchar).Value = UCase(tx_planta.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0408_tip_produccion", NpgsqlDbType.Varchar).Value = UCase(tx_tipo_produccion.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0408_tip_producto", NpgsqlDbType.Varchar).Value = UCase(tx_tipo_producto.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0408_id_linea", NpgsqlDbType.Integer).Value = CInt(cm_linea.SelectedValue)
        ocmd.Parameters.Add("@f0408_referencia", NpgsqlDbType.Varchar).Value = UCase(tx_referencia.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0408_peso", NpgsqlDbType.Numeric).Value = tx_peso_unitario.Text
        ocmd.Parameters.Add("@f0408_unid_medida", NpgsqlDbType.Varchar).Value = UCase(tx_unidad_medida.Text.ToString.Trim)
        ocmd.Parameters.Add("@f0408_factor_empaque", NpgsqlDbType.Numeric).Value = tx_factor_empaque.Text
        ocmd.Parameters.Add("@f0408_factor_cobertura", NpgsqlDbType.Numeric).Value = tx_factor_cobertura.Text

        'f0408_tip_venta
        Dim tventa As String = String.Empty
        If tx_tipo_venta.Text.ToString.Trim = "" Then
            tventa = "ND"
        Else
            tventa = UCase(tx_tipo_venta.Text.ToString.Trim)
        End If
        ocmd.Parameters.Add("@f0408_tip_venta", NpgsqlDbType.Varchar).Value = tventa

        Dim caja As Integer
        If tx_corrugado.Text.ToString.Trim = "" Then
            caja = vbNull
        Else
            caja = CInt(tx_corrugado.Text.ToString.Trim)
        End If
        ocmd.Parameters.Add("@f0408_id_caja_corrugado", NpgsqlDbType.Integer).Value = caja
    End Sub

    Private Sub bt_actualizar_Click(sender As Object, e As EventArgs) Handles bt_actualizar.Click
        verror_requisitos = "N"
        If tx_planta.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la planta"
        End If
        If tx_referencia.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Identifique la referencia"
        End If
        If tx_tipo_produccion.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina tipo de produccion"
        End If
        If tx_tipo_producto.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina tipo de producto"
        End If
        If tx_unidad_medida.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina unidad de medida"
        End If
        If cm_linea.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la linea"
        End If
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos)
            Exit Sub
        End If
        actualizar_item()
        Dim otb As DataTable
        'csql = "select * from " & database.obtener_esquema & ".fnc_ip_cguno_exportar_tablas_csv();"
        'otb = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        reset_campos()
    End Sub

    Private Sub tx_referencia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_referencia.Validating
        traer_info_item_cg(tx_referencia.Text.ToString.Trim)
    End Sub
    Private Sub tx_peso_unitario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_peso_unitario.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        End If
    End Sub
    Private Sub tx_peso_unitario_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_peso_unitario.Validating
        If tx_peso_unitario.Text.Trim = "" Then
            tx_peso_unitario.Text = 1
        End If
        tx_peso_unitario.Text = CDec(tx_peso_unitario.Text)
    End Sub
    Private Sub tx_corrugado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_corrugado.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If

    End Sub
    Private Sub tx_factor_empaque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_factor_empaque.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        End If
    End Sub
    Private Sub tx_factor_empaque_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_factor_empaque.Validating
        If tx_factor_empaque.Text.Trim = "" Then
            tx_factor_empaque.Text = 1
        End If
        tx_factor_empaque.Text = CDec(tx_factor_empaque.Text)
    End Sub
    Private Sub tx_factor_cobertura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_factor_cobertura.KeyPress
        'Solo para numeros enteros
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub tx_factor_cobertura_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tx_factor_cobertura.Validating
        If tx_factor_cobertura.Text.Trim = "" Then
            tx_factor_cobertura.Text = 0
        End If
        tx_factor_cobertura.Text = CInt(tx_factor_cobertura.Text)
    End Sub
End Class
