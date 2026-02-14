Public Class fm_0200_tercero
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public oform_actual As Object = Me

    'Private$vf_otabla_permisos$As DataTable
    Private P_grabar As String = "N"
    Private P_editar As String = "N"
    Private P_nuevos_r As String = "N"

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private entrado As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private verror_grabar As String = ""
    Private vexiste As String = "N"
    Private verror As String = "N"
    Private vactivo As String = "N"
    Private vdato As String = ""
    Private local As String = ""
    Private MensajeError As String
    Private vemail_ok As Boolean
    Private vestado As String
    Private vgrabar As String

    Private otb_terceros As DataTable
    Private orow_sucursales As DataRow()
    Private dv_tereceros_principales As DataView

    Private total_sucursales As Integer = 0
    Private nit_antiguo As String
    Private f0200_id_cia As String
    Private f0200_id_tercero As String
    Private f0200_id As String
    Private f0200_dig_ver_nit As String
    Private f0200_id_tipo_identificacion As String
    Private f0200_apellido1 As String
    Private f0200_apellido2 As String
    Private f0200_nombres As String
    Private f0200_ind_cliente As String
    Private f0200_ind_proveedor As String
    Private f0200_ind_empleado As String
    Private f0200_ind_aspirante As String
    Private f0200_accionista As String
    Private f0200_fr As String
    Private f0200_codigo_empleado As String
    Private f0200_fm As DateTime
    Private f0200_usuario_modifica As String

    Private Sub fm_0200_tercero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        ''Identifico permisos basicos de gestion de registros
        'P_editar = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_editar", vf_otabla_permisos, vg_usuario_autoriza)
        'P_grabar = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_grabar", vf_otabla_permisos, vg_usuario_autoriza)
        'P_nuevos_r = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_nuevo", vf_otabla_permisos, vg_usuario_autoriza)

        'bt_anular.Enabled = False
        'bt_grabar.Enabled = False
        'bt_nuevo.Enabled = False
        'bt_editar.Enabled = False

        'gestiono_permisos_basicos
        'cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo, vg_usuario_autoriza, Me)

        llenar_tabla_terceros()

        csql = "select * from " & database.obtener_esquema & ".tb0201_tipos_identificacion_terceros"
        With cm_tipo_identificacion
            'Valor que se muestra al usuario
            .DisplayMember = "f0201_descripcion"
            'Valor interno que almacena el objeto
            .ValueMember = "f0201_id_tipo_identificacion"
            'Origen de Datos del ComboBox
            .DataSource = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
    End Sub


    Private Sub llenar_tabla_terceros()
        csql = "select tb0200_terceros.*, trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2 || ' - ' || f0200_id) as razon_social," _
            & " f0052_ciudad || ' - ' || f0051_departamento as ciudad" _
            & " FROM " & database.obtener_esquema & ".tb0200_terceros" _
            & " left Join " & database.obtener_esquema & ".tb0052_ciudades" _
              & " on f0200_ciudad_residencia = f0052_codigo_ciudad" _
            & " left join " & database.obtener_esquema & ".tb0051_departamentos" _
            & "   on f0051_codigo_departamento = f0052_codigo_departamento" _
            & " where f0200_id_cia ='" & vg_id_cia & "'"
        otb_terceros = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        dv_tereceros_principales = New DataView(otb_terceros, "f0200_ind_principal = 'S'", "", DataViewRowState.CurrentRows)

        With cm_identificacion
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_id"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id"
            'Origen de Datos del ComboBox
            .DataSource = dv_tereceros_principales
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_nombres
            'Valor que se muestra al usuario
            .DisplayMember = "razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id"
            'Origen de Datos del ComboBox
            .DataSource = dv_tereceros_principales
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        'MsgBox(vf_elemento_nuevo)
        verror_requisitos = "N"
        validar_identificacion()
        validar_tipo_identificacion()
        validar_nombre()
        validar_tipo()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Crear las variables con los valores del campo.
        f0200_id_cia = vg_id_cia
        f0200_id_tercero = tx_id_tercero.Text
        f0200_id = tx_identificacion.Text.Trim
        f0200_dig_ver_nit = tx_dig_verificacion.Text.Trim
        f0200_id_tipo_identificacion = cm_tipo_identificacion.SelectedValue
        f0200_apellido1 = tx_1_apellido.Text.Trim.ToUpper
        f0200_apellido2 = tx_2_apellido.Text.Trim.ToUpper
        f0200_nombres = tx_nombre.Text.Trim.ToUpper
        If chk_cliente.Checked = True Then
            f0200_ind_cliente = "S"
        Else
            f0200_ind_cliente = "N"
        End If
        If chk_proveedor.Checked = True Then
            f0200_ind_proveedor = "S"
        Else
            f0200_ind_proveedor = "N"
        End If
        If chk_empleado.Checked = True Then
            f0200_ind_empleado = "S"
        Else
            f0200_ind_empleado = "N"
        End If
        If chk_aspirante.Checked = True Then
            f0200_ind_aspirante = "S"
        Else
            f0200_ind_aspirante = "N"
        End If
        f0200_fm = comunes.g_fechahora()
        f0200_usuario_modifica = vg_usuario_autoriza.PadLeft(8, "0")

        If vf_elemento_nuevo = "S" Then
            f0200_id_tercero = cl_utilidades_datatables.obtener_nuevo_consecutivo_tablas("f0200_id_tercero", "tb0200_terceros").ToString.PadLeft(8, "0")
            tx_id_tercero.Text = f0200_id_tercero
            grabar_tercero()
            llenar_tabla_terceros()
        Else
            actualizar_tercero()
            llenar_tabla_terceros()
            cm_identificacion.SelectedIndex = -1
            cm_nombres.SelectedIndex = -1
            dg_sucursales.Rows.Clear()
        End If

        If verror = "N" Then
            MsgBox("Actualización Terminada", MsgBoxStyle.Information, "Proceso terminado")
            Me.Limpiar()
        End If

        tx_identificacion.Focus()

    End Sub

    Private Sub grabar_tercero()

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "insert into " + database.obtener_esquema + ".tb0200_terceros" _
            & " (" _
            & " f0200_id_cia, f0200_id_tercero, f0200_apellido1, f0200_apellido2, f0200_nombres," _
            & " f0200_ind_cliente, f0200_ind_proveedor, f0200_ind_empleado, f0200_ind_aspirante, f0200_id, f0200_dig_ver_nit," _
            & " f0200_id_tipo_identificacion, f0200_id_sucursal, f0200_ind_principal," _
            & " f0200_fm, f0200_usuario_crear," _
            & " f0200_usuario_modificar" _
            & ") values" _
            & " (" _
            & " @f0200_id_cia, @f0200_id_tercero, @f0200_apellido1, @f0200_apellido2, @f0200_nombres," _
            & " @f0200_ind_cliente, @f0200_ind_proveedor, @f0200_ind_empleado, @f0200_ind_aspirante, @f0200_id, @f0200_dig_ver_nit," _
            & " @f0200_id_tipo_identificacion, @f0200_id_sucursal, @f0200_ind_principal," _
            & " @f0200_fm, @f0200_usuario_crear," _
            & " @f0200_usuario_modificar" _
            & ")"

        ocmd.CommandText = csql

        'Inserción parametrizada
        crear_parametros_tb_terceros(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! grabando tercero" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error grabando tercero" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub actualizar_tercero()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0200_terceros set" _
            & " f0200_id_cia = @f0200_id_cia," _
            & " f0200_apellido1 = @f0200_apellido1," _
            & " f0200_apellido2 = @f0200_apellido2," _
            & " f0200_nombres = @f0200_nombres," _
            & " f0200_ind_cliente = @f0200_ind_cliente," _
            & " f0200_ind_proveedor = @f0200_ind_proveedor," _
            & " f0200_ind_empleado = @f0200_ind_empleado," _
            & " f0200_ind_aspirante = @f0200_ind_aspirante," _
            & " f0200_id = @f0200_id," _
            & " f0200_dig_ver_nit = @f0200_dig_ver_nit," _
            & " f0200_id_tipo_identificacion = @f0200_id_tipo_identificacion," _
            & " f0200_fm = @f0200_fm," _
            & " f0200_usuario_modificar = @f0200_usuario_modificar" _
            & " where f0200_id = '" & nit_antiguo & "'"

        ocmd.CommandText = csql

        'Inserción parametrizada
        crear_parametros_tb_terceros(ocmd)
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar Tercero ! " + vbCrLf + ex.ToString)
            Limpiar()
        End Try
    End Sub
    Private Sub crear_parametros_tb_terceros(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_id_cia", NpgsqlDbType.Varchar).Value = f0200_id_cia
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = f0200_id_tercero
        ocmd.Parameters.Add("f0200_id", NpgsqlDbType.Varchar).Value = f0200_id
        ocmd.Parameters.Add("f0200_dig_ver_nit", NpgsqlDbType.Varchar).Value = f0200_dig_ver_nit
        ocmd.Parameters.Add("f0200_id_tipo_identificacion", NpgsqlDbType.Varchar).Value = f0200_id_tipo_identificacion
        ocmd.Parameters.Add("f0200_apellido1", NpgsqlDbType.Varchar).Value = f0200_apellido1
        ocmd.Parameters.Add("f0200_apellido2", NpgsqlDbType.Varchar).Value = f0200_apellido2
        ocmd.Parameters.Add("f0200_nombres", NpgsqlDbType.Varchar).Value = f0200_nombres
        ocmd.Parameters.Add("f0200_ind_cliente", NpgsqlDbType.Varchar).Value = f0200_ind_cliente
        ocmd.Parameters.Add("f0200_ind_proveedor", NpgsqlDbType.Varchar).Value = f0200_ind_proveedor
        ocmd.Parameters.Add("f0200_ind_empleado", NpgsqlDbType.Varchar).Value = f0200_ind_empleado
        ocmd.Parameters.Add("f0200_ind_aspirante", NpgsqlDbType.Varchar).Value = f0200_ind_aspirante
        ocmd.Parameters.Add("f0200_id_sucursal", NpgsqlDbType.Integer).Value = CInt(f0200_id_tercero)
        If total_sucursales >= 1 Then
            ocmd.Parameters.Add("f0200_ind_principal", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("f0200_ind_principal", NpgsqlDbType.Varchar).Value = "S"
        End If
        ocmd.Parameters.Add("f0200_fm", NpgsqlDbType.Timestamp).Value = f0200_fm
        ocmd.Parameters.Add("f0200_usuario_modificar", NpgsqlDbType.Varchar).Value = f0200_usuario_modifica
        ocmd.Parameters.Add("f0200_usuario_crear", NpgsqlDbType.Varchar).Value = f0200_usuario_modifica
    End Sub

    Private Sub tx_identificacion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_identificacion.Validating
        verror_requisitos = "N"
        validar_identificacion()
        'tx_dig_verificacion.Focus()
        If verror_requisitos = "N" Then
            If vf_elemento_nuevo = "S" Then
                buscar_identificacion(tx_identificacion.Text)
            End If
        End If
    End Sub
    Private Sub validar_identificacion()
        If tx_identificacion.Text.ToString.Trim = "" Then 'Is DBNull.Value Then
            vmensaje_requisitos = "Defina la identificacion"
            verror_requisitos = "S"
            Exit Sub
        End If
        If IsNumeric(tx_identificacion.Text.ToString) = False Then
            vmensaje_requisitos = "La identificacion debe ser numerica"
            verror_requisitos = "S"
            Exit Sub
        End If
    End Sub

    Private Sub buscar_identificacion(ByVal f0200_id As String)
        bt_grabar.Enabled = False
        Dim orow_tercero_ppal As DataRow()
        orow_tercero_ppal = otb_terceros.Select("f0200_ind_principal = 'S' and f0200_id = '" & f0200_id & "'")
        'MsgBox("hola1")
        If orow_tercero_ppal.Length = 0 Then
            vf_elemento_nuevo = "S"
            total_sucursales = 0
            'gestiono_permisos_basicos
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo, vg_usuario_autoriza, Me)
            Exit Sub
        Else
            ' MsgBox("hola3")
            vf_elemento_nuevo = "N"
            cargar_sucursales(f0200_id)
            total_sucursales = orow_sucursales.Length
        End If
        Limpiar()
        For Each orow As DataRow In orow_tercero_ppal
            vf_id_notas_archivos = orow("f0200_id_tercero")
            vf_elemento_nuevo = "N"
            tx_identificacion.Text = orow("f0200_id")
            nit_antiguo = orow("f0200_id")
            tx_id_tercero.Text = orow("f0200_id_tercero")
            tx_dig_verificacion.Text = orow("f0200_dig_ver_nit")
            cm_tipo_identificacion.SelectedValue = orow("f0200_id_tipo_identificacion")
            tx_1_apellido.Text = orow("f0200_apellido1")
            tx_2_apellido.Text = orow("f0200_apellido2")
            tx_nombre.Text = orow("f0200_nombres")

            If orow("f0200_ind_cliente") = "S" Then
                chk_cliente.Checked = True
            Else
                chk_cliente.Checked = False
            End If
            If orow("f0200_ind_proveedor") = "S" Then
                chk_proveedor.Checked = True
            Else
                chk_proveedor.Checked = False
            End If
            If orow("f0200_ind_empleado") = "S" Then
                chk_empleado.Checked = True
            Else
                chk_empleado.Checked = False
            End If
            If orow("f0200_ind_aspirante") = "S" Then
                chk_aspirante.Checked = True
            Else
                chk_aspirante.Checked = False
            End If
        Next
    End Sub
    Private Sub validar_nombre()
        If tx_nombre.Text.ToString.Trim = "" Then 'Is DBNull.Value Then
            vmensaje_requisitos = "Defina el nombre"
            verror_requisitos = "S"
            Exit Sub
        End If
    End Sub
    Private Sub validar_tipo()
        If chk_cliente.Checked = False And chk_empleado.Checked = False And chk_proveedor.Checked = False And chk_aspirante.Checked = False Then
            vmensaje_requisitos = "Defina el tipo de Tercero."
            verror_requisitos = "S"
            Exit Sub
        End If
    End Sub
    Private Sub validar_tipo_identificacion()
        If cm_tipo_identificacion.SelectedIndex = -1 Then
            vmensaje_requisitos = "Defina un tipo de identificacion."
            verror_requisitos = "S"
            Exit Sub
        End If
    End Sub
    Private Sub cm_tipo_identificacion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_tipo_identificacion.Validating
        If cm_tipo_identificacion.SelectedIndex = -1 And cm_tipo_identificacion.Text <> "" Then
            MsgBox("Debe seleccionar un tipo de identificacion de la lista o crear un nuevo tipo primero!", MsgBoxStyle.Exclamation, "Error")
            cm_tipo_identificacion.Text = ""
        End If
    End Sub

    Private Sub Limpiar()
        'entrado = "N"
        vf_elemento_nuevo = "S"
        cm_tipo_identificacion.SelectedIndex = -1
        tx_id_tercero.Text = ""
        tx_identificacion.Text = ""
        tx_dig_verificacion.Text = ""
        tx_1_apellido.Text = ""
        tx_2_apellido.Text = ""
        tx_nombre.Text = ""
        chk_cliente.Checked = False
        chk_empleado.Checked = False
        chk_proveedor.Checked = False
        chk_aspirante.Checked = False
    End Sub
    Private Sub bt_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nuevo.Click
        vf_elemento_nuevo = "S"
        cm_identificacion.SelectedIndex = -1
        cm_nombres.SelectedIndex = -1
        dg_sucursales.Rows.Clear()
        Limpiar()
        bt_grabar.Enabled = True
    End Sub

    Private Sub cm_identificacion_Click(sender As Object, e As EventArgs) Handles cm_identificacion.Click
        entrado = "S"
    End Sub

    Private Sub cm_identificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cm_identificacion.SelectedIndexChanged
        If entrado = "S" Then
            buscar_identificacion(cm_identificacion.Text)
        End If
    End Sub

    Private Sub cm_nombres_Click(sender As Object, e As EventArgs) Handles cm_nombres.Click
        entrado = "S"
    End Sub

    Private Sub cargar_sucursales(ByVal f0200_id As String)
        dg_sucursales.Rows.Clear()

        orow_sucursales = otb_terceros.Select("f0200_id = '" & f0200_id & "'")
        For Each orow As DataRow In orow_sucursales
            agregar_fila_sucursales(orow)
        Next
        lb_total_sucursales.Text = orow_sucursales.Length & " Registros"
    End Sub

    Private Sub agregar_fila_sucursales(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0200_id_tercero").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0200_id_sucursal").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0200_nombres").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("ciudad").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0200_direccion_residencia").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)


        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_sucursales.Rows.Add(orowgrid)
    End Sub

    Private Sub bt_nueva_sucursal_Click(sender As Object, e As EventArgs) Handles bt_nueva_sucursal.Click
        If tx_id_tercero.Text.Trim = "" Then
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_sucursal As New camocontrol.fm_0200_tercero_sucursal
        oform_sucursal.vf_oform_padre = Me
        oform_sucursal.vg_id_cia = vg_id_cia
        oform_sucursal.vg_usuario_autoriza = vg_usuario_autoriza
        oform_sucursal.vf_elemento_nuevo = "S"
        oform_sucursal.id_tercero = tx_id_tercero.Text
        oform_sucursal.ShowDialog()
    End Sub

    Private Sub dg_sucursales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_sucursales.CellDoubleClick
        If dg_sucursales.Rows.Count = 0 Then
            Exit Sub
        End If
        If tx_id_tercero.Text.Trim = "" Then
            Exit Sub
        End If
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_sucursal As New camocontrol.fm_0200_tercero_sucursal
        oform_sucursal.vf_oform_padre = Me
        oform_sucursal.vg_id_cia = vg_id_cia
        oform_sucursal.vf_elemento_nuevo = "N"
        oform_sucursal.vg_usuario_autoriza = vg_usuario_autoriza
        oform_sucursal.id_tercero = dg_sucursales.CurrentRow.Cells("dgocell_id_tercero").Value
        oform_sucursal.vf_id_notas_archivos = dg_sucursales.CurrentRow.Cells("dgocell_id_tercero").Value
        oform_sucursal.ShowDialog()
        Dim oactivo As String = tx_identificacion.Text
        llenar_tabla_terceros()
        buscar_identificacion(oactivo)
    End Sub

End Class
