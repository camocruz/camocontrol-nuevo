Imports System.ComponentModel

Public Class fm_0023_informacion_personal
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public otipo_nota As String = ""

    Private new_name_file As String = ""

    Private carga_inicial As String = "S"

    Public id_tercero As String = ""
    Private otercero As Integer
    Private id_cargo As Integer = 0
    Private edad_anos As Integer = 0

    'Private$vf_otabla_permisos$As DataTable

    Private otb_info_personal As DataTable
    Private otb_cargos As DataTable
    Private otb_ciudades As DataTable
    Private otb_eps As DataTable
    Private otb_arl As DataTable
    Private otb_f_cesantias As DataTable
    Private otb_f_pensiones As DataTable
    Private otb_empleador As DataTable

    Public id_recaudo As Integer
    Private editando_registro As String = "N"
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand

    Private Sub fm_0023_informacion_personal_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-IRH"
        vf_var_config_notas = "TN-RHU-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        vf_id_notas_archivos = id_tercero
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)


        'bt_nuevo.Enabled = False
        'bt_anular.Enabled = False
        'bt_editar.Enabled = False
        'bt_generar_informe.Enabled = False
        'bt_grabar.Enabled = False
        bt_imagen.Enabled = False

        'Activar grabar si tiene permisos para esto
        'cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_grabar, ocontexto_form)
        cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, Me.bt_imagen, ocontexto_form)

        cargar_otabla_personal()

        With cm_nombre
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_personal
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_cedula
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_id"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_personal
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_codigo
            'Valor que se muestra al usuario
            .DisplayMember = "f0200_codigo_empleado"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_personal
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        csql = "select * from " & database.obtener_esquema & ".tb0240_cargos_compania" _
            & " where f0240_anulado = 'N' and f0240_id_cia = '" & vg_id_cia & "'"
        otb_cargos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_cargo
            'Valor que se muestra al usuario
            .DisplayMember = "f0240_cargo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0240_id_cargo"
            'Origen de Datos del ComboBox
            .DataSource = otb_cargos
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "select f0052_codigo_ciudad, f0052_ciudad || ' - ' || f0051_departamento as ciudad" _
            & " from " & database.obtener_esquema & ".tb0052_ciudades" _
            & " join " & database.obtener_esquema & ".tb0051_departamentos" _
            & " on f0051_codigo_departamento = f0052_codigo_departamento"
        otb_ciudades = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim otb_info_ciudad_resi As DataTable = otb_ciudades.Copy
        With cm_ciudad_nacimiento
            'Valor que se muestra al usuario
            .DisplayMember = "ciudad"
            'Valor interno que almacena el objeto
            .ValueMember = "f0052_codigo_ciudad"
            'Origen de Datos del ComboBox
            .DataSource = otb_ciudades
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_ciudad_residencia
            'Valor que se muestra al usuario
            .DisplayMember = "ciudad"
            'Valor interno que almacena el objeto
            .ValueMember = "f0052_codigo_ciudad"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_ciudad_resi
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        csql = "select *, trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2 || ' - ' || f0200_id) as razon_social" _
            & " FROM " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_ind_principal = 'S'"
        '& " and f0200_id_cia ='" & vg_id_cia & "'"
        otb_eps = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        otb_arl = otb_eps.Copy()
        otb_f_cesantias = otb_eps.Copy()
        otb_f_pensiones = otb_eps.Copy()
        otb_empleador = otb_eps.Copy()
        With cm_eps
            'Valor que se muestra al usuario
            .DisplayMember = "razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_eps
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
            '.Text = ""
        End With
        With cm_arl
            'Valor que se muestra al usuario
            .DisplayMember = "razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_arl
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
            '.Text = ""
        End With
        With cm_f_cesantias
            'Valor que se muestra al usuario
            .DisplayMember = "razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_f_cesantias
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
            '.Text = ""
        End With
        With cm_f_pensiones
            'Valor que se muestra al usuario
            .DisplayMember = "razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_f_pensiones
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
            '.Text = ""
        End With
        With cm_empleador
            'Valor que se muestra al usuario
            .DisplayMember = "razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_empleador
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
            '.Text = ""
        End With
        carga_inicial = "N"
    End Sub

    Private Sub cargar_otabla_personal()
        csql = "select *, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" & " and (f0200_ind_empleado = 'S' or f0200_ind_aspirante = 'S')" _
            & " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub cargar_info_funcionario()
        If carga_inicial = "S" Then
            Exit Sub
        End If
        If cm_nombre.SelectedIndex = -1 Then
            Exit Sub
        End If
        cm_eps.SelectedIndex = -1
        cm_arl.SelectedIndex = -1
        cm_f_cesantias.SelectedIndex = -1
        cm_empleador.SelectedIndex = -1
        cm_f_pensiones.SelectedIndex = -1


        Dim dv_datos As New DataView(otb_info_personal)
        Dim dv_filter As String
        dv_filter = "f0200_id_tercero = '" & cm_nombre.SelectedValue & "'"
        dv_datos.RowFilter = dv_filter
        otercero = CInt(cm_nombre.SelectedValue)
        vf_id_notas_archivos = otercero
        vf_elemento_nuevo = "N"
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                                   vg_usuario_autoriza, Me,
                                                                   vf_id_notas_archivos, vf_otipo_nota,
                                                                   vf_var_config_archivos)
        For Each orow As DataRowView In dv_datos
            tx_codigo.Text = orow("f0200_codigo_empleado").ToString
            If orow("f0200_estado") = "A" Then
                cm_estado.Text = "Activo"
            Else
                cm_estado.Text = "Inactivo"
            End If
            id_tercero = orow("f0200_id_tercero")
            id_cargo = orow("f0200_id_cargo")
            cm_cargo.SelectedValue = id_cargo
            cm_ciudad_nacimiento.SelectedValue = orow("f0200_ciudad_nacimiento")
            dtp_fecha_nacimiento.Value = orow("f0200_fecha_nacimiento")
            'calculo la edad
            calcular_edad(dtp_fecha_nacimiento.Value)
            cm_ciudad_residencia.SelectedValue = orow("f0200_ciudad_residencia")
            cm_eps.SelectedValue = orow("f0200_id_eps")
            cm_arl.SelectedValue = orow("f0200_id_arl")
            cm_f_cesantias.SelectedValue = orow("f0200_f_cesantias")
            cm_empleador.SelectedValue = orow("f0200_empleador")
            cm_f_pensiones.SelectedValue = orow("f0200_f_pensiones")

            tx_direccion_residencia.Text = orow("f0200_direccion_residencia")
            tx_tel_fijo.Text = orow("f0200_telefono_fijo")
            tx_tel_celular.Text = orow("f0200_telefono_celular")
            tx_correo_electronico.Text = orow("f0200_correo_electronico")

            If IsDBNull(orow("f0200_f_ini_1er_contrato")) = False Then
                tx_f_1er_contrato.Text = CDate(orow("f0200_f_ini_1er_contrato")).ToString("yyyy-MM-dd HH:mm:ss")
            Else
                tx_f_1er_contrato.Text = ""
            End If
            If IsDBNull(orow("f0200_f_ini_act_contrato")) = False Then
                tx_f_act_contrato.Text = CDate(orow("f0200_f_ini_act_contrato")).ToString("yyyy-MM-dd HH:mm:ss")
            Else
                tx_f_act_contrato.Text = ""
            End If

            If orow("f0200_path_file_imagen") <> "" Then
                Try
                    pb_imagen_elemento.Image = Image.FromFile(orow("f0200_path_file_imagen"))
                Catch ex As Exception

                End Try
            Else
                pb_imagen_elemento.Image = My.Resources.conductor
            End If
        Next
    End Sub
    Private Sub calcular_edad(ByVal f_nacimiento As Date)
        Dim cumplidos As Boolean
        Dim anoactual As Integer = Now.Year
        ' SE COMPRUEBA CUANDO FUE EL ULTIMOS CUMPLEAÑOS
        ' FORMULA:
        '   Años cumplidos = (Año del ultimo cumpleaños - Año de nacimiento)
        If (f_nacimiento.Month <= Now.Month) Then
            If (f_nacimiento.Day <= Now.Day) Then
                If (f_nacimiento.Day = Now.Day And f_nacimiento.Month = Now.Month) Then
                    'MsgBox("Feliz Cumpleaños!")
                End If
                ' MsgBox("Ya cumplio")
                cumplidos = True
            End If
        End If
        If (cumplidos = False) Then
            anoactual = (Now.Year - 1)
            'MsgBox("Ultimo cumpleaños: " & anoactual)
        End If
        ' Se realiza la resta de años para definir los años cumplidos
        Dim edadanos As Integer = (anoactual - f_nacimiento.Year)
        'MsgBox(edadanos)
        ' DEFINICION DE LOS MESES LUEGO DEL ULTIMO CUMPLEAÑOS
        Dim EdadMes As Integer
        If Not (anoactual = Now.Year) Then
            EdadMes = (12 - f_nacimiento.Month)
            EdadMes = EdadMes + Now.Month
        Else
            EdadMes = Math.Abs(Now.Month - f_nacimiento.Month)
        End If
        'SACAMOS LA CANTIDAD DE DIAS EXACTOS
        'Dim EdadDia As Integer = (DiaActual - DiaNacimiento)

        edad_anos = Math.Round(edadanos + (EdadMes / 12), 0)

        'RETORNAMOS LOS VALORES EN UNA CADENA STRING
        lb_edad.Text = edadanos & " años , " & EdadMes & " meses"
        'Return ("Ud. tiene exactamente " & EdadAños & " años , " & EdadMes & " meses y " & EdadDia & " dias")
    End Sub
    Private Sub actualizar_personal()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0200_terceros set" _
            & " f0200_codigo_empleado = @f0200_codigo_empleado," _
            & " f0200_id_cargo = @f0200_id_cargo," _
            & " f0200_estado = @f0200_estado," _
            & " f0200_ciudad_residencia = @f0200_ciudad_residencia," _
            & " f0200_ciudad_nacimiento = @f0200_ciudad_nacimiento," _
            & " f0200_fecha_nacimiento = @f0200_fecha_nacimiento," _
            & " f0200_direccion_residencia = @f0200_direccion_residencia," _
            & " f0200_telefono_fijo = @f0200_telefono_fijo," _
            & " f0200_telefono_celular = @f0200_telefono_celular," _
            & " f0200_correo_electronico = @f0200_correo_electronico," _
            & " f0200_fm = @f0200_fm," _
            & " f0200_usuario_modificar = @f0200_usuario_modificar," _
            & " f0200_f_ini_1er_contrato = @f0200_f_ini_1er_contrato," _
            & " f0200_f_ini_act_contrato = @f0200_f_ini_act_contrato," _
            & " f0200_id_arl = @f0200_id_arl," _
            & " f0200_f_cesantias = @f0200_f_cesantias," _
            & " f0200_empleador = @f0200_empleador," _
            & " f0200_f_pensiones = @f0200_f_pensiones," _
            & " f0200_id_eps = @f0200_id_eps" _
            & " where f0200_id_tercero = @f0200_id_tercero"

        ocmd.CommandText = csql

        'Inserción parametrizada
        crear_parametros_actualizar_personal(ocmd)
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar Personal! " + vbCrLf + ex.ToString)
        End Try
    End Sub
    Private Sub crear_parametros_actualizar_personal(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = cm_nombre.SelectedValue
        If cm_estado.Text = "Activo" Then
            ocmd.Parameters.Add("f0200_estado", NpgsqlDbType.Varchar).Value = "A"
        Else
            ocmd.Parameters.Add("f0200_estado", NpgsqlDbType.Varchar).Value = "I"
        End If
        ocmd.Parameters.Add("f0200_id_cargo", NpgsqlDbType.Integer).Value = CInt(cm_cargo.SelectedValue)
        ocmd.Parameters.Add("f0200_codigo_empleado", NpgsqlDbType.Varchar).Value = tx_codigo.Text
        ocmd.Parameters.Add("f0200_ciudad_residencia", NpgsqlDbType.Varchar).Value = cm_ciudad_residencia.SelectedValue
        ocmd.Parameters.Add("f0200_ciudad_nacimiento", NpgsqlDbType.Varchar).Value = cm_ciudad_nacimiento.SelectedValue
        ocmd.Parameters.Add("f0200_fecha_nacimiento", NpgsqlDbType.Timestamp).Value = dtp_fecha_nacimiento.Value
        ocmd.Parameters.Add("f0200_direccion_residencia", NpgsqlDbType.Varchar).Value = tx_direccion_residencia.Text
        ocmd.Parameters.Add("f0200_telefono_fijo", NpgsqlDbType.Varchar).Value = tx_tel_fijo.Text
        ocmd.Parameters.Add("f0200_telefono_celular", NpgsqlDbType.Varchar).Value = tx_tel_celular.Text
        ocmd.Parameters.Add("f0200_correo_electronico", NpgsqlDbType.Varchar).Value = tx_correo_electronico.Text
        ocmd.Parameters.Add("f0200_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("f0200_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0200_f_ini_1er_contrato", NpgsqlDbType.Timestamp).Value = CDate(tx_f_1er_contrato.Text)
        ocmd.Parameters.Add("f0200_f_ini_act_contrato", NpgsqlDbType.Timestamp).Value = CDate(tx_f_act_contrato.Text)
        If cm_arl.SelectedIndex = -1 Then
            ocmd.Parameters.Add("f0200_id_arl", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("f0200_id_arl", NpgsqlDbType.Varchar).Value = cm_arl.SelectedValue
        End If
        If cm_eps.SelectedIndex = -1 Then
            ocmd.Parameters.Add("f0200_id_eps", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("f0200_id_eps", NpgsqlDbType.Varchar).Value = cm_eps.SelectedValue
        End If
        If cm_f_cesantias.SelectedIndex = -1 Then
            ocmd.Parameters.Add("f0200_f_cesantias", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("f0200_f_cesantias", NpgsqlDbType.Varchar).Value = cm_f_cesantias.SelectedValue
        End If
        If cm_empleador.SelectedIndex = -1 Then
            ocmd.Parameters.Add("f0200_empleador", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("f0200_empleador", NpgsqlDbType.Varchar).Value = cm_empleador.SelectedValue
        End If
        If cm_f_pensiones.SelectedIndex = -1 Then
            ocmd.Parameters.Add("f0200_f_pensiones", NpgsqlDbType.Varchar).Value = ""
        Else
            ocmd.Parameters.Add("f0200_f_pensiones", NpgsqlDbType.Varchar).Value = cm_f_pensiones.SelectedValue
        End If
    End Sub
    Private Sub validaciones()
        validar_codigo()
        validar_funcionario()
        validar_ciudad_nacimiento()
        validar_ciudad_recidencia()
        validar_cargo()
        validar_fecha_ini_1er_contrato()
        validar_fecha_ini_contrato_actual()
    End Sub
    Private Sub bt_grabar_Click(sender As System.Object, e As System.EventArgs) Handles bt_grabar.Click
        If cm_nombre.SelectedIndex = -1 Then
            Exit Sub
        End If
        verror_requisitos = "N"
        'corro las validaciones
        validaciones()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        actualizar_personal()
        If verror = "N" Then
            cargar_otabla_personal()
            MsgBox("Info Actualizada", MsgBoxStyle.Information, "Actualizado")
        End If
        'Elimino los permisos de usuarios inactivos
        csql = comunes.suministrar_valor_variable_configuracion("ST-0020-01", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        cl_utilidades_datatables.ejecutar_csql(csql)
    End Sub
    Private Sub validar_codigo()
        If tx_codigo.Text = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe definir un codigo para el empleado."
            Exit Sub
        End If
        If cm_codigo.Text <> tx_codigo.Text Then
            csql = "select f0200_codigo_empleado from " & database.obtener_esquema & ".tb0200_terceros" _
                & " where f0200_codigo_empleado = '" & tx_codigo.Text.Trim & "'"
            Dim otb_codigo As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            If otb_codigo.Rows.Count <> 0 Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Codigo de empleado ya usado, defina uno nuevo."
            End If
        End If
    End Sub
    Private Sub validar_funcionario()
        If cm_nombre.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe seleccionar un funcionario"
        End If
    End Sub
    Private Sub validar_cargo()
        If cm_cargo.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe definir el Cargo"
        End If
    End Sub
    Private Sub validar_ciudad_nacimiento()
        If cm_ciudad_nacimiento.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe seleccionar la ciudad de nacimiento"
        End If
    End Sub
    Private Sub validar_ciudad_recidencia()
        If cm_ciudad_residencia.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe seleccionar la ciudad de residencia"
        End If
    End Sub
    Private Sub validar_fecha_ini_1er_contrato()
        If tx_f_1er_contrato.Text = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe definir la fecha inicial del primer contrato"
        End If
    End Sub
    Private Sub validar_fecha_ini_contrato_actual()
        If tx_f_act_contrato.Text = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Debe definir la fecha inicial del contrato actual"
        End If
    End Sub

    Private Sub cm_nombre_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cm_nombre.SelectedIndexChanged
        cargar_info_funcionario()
    End Sub

    Private Sub recetear_todo()
        tx_codigo.Text = ""
        cm_nombre.Text = ""
        cm_cedula.Text = ""
        cm_codigo.Text = ""
        cm_ciudad_nacimiento.Text = ""
        dtp_fecha_nacimiento.Value = Now()
        cm_ciudad_residencia.Text = ""
        tx_direccion_residencia.Text = ""
        tx_tel_fijo.Text = ""
        tx_tel_celular.Text = ""
        tx_correo_electronico.Text = ""
        bt_grabar.Enabled = False
    End Sub
    Private Sub cm_nombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_nombre.Validating
        If cm_nombre.SelectedIndex = -1 Then
            recetear_todo()
        End If
    End Sub
    Private Sub cm_codigo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_codigo.Validating
        If cm_codigo.SelectedIndex = -1 Then
            recetear_todo()
        End If
    End Sub
    Private Sub cm_cedula_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_cedula.Validating
        If cm_cedula.SelectedIndex = -1 Then
            recetear_todo()
        End If
    End Sub

    Private Sub bt_imagen_Click(sender As System.Object, e As System.EventArgs) Handles bt_imagen.Click
        If cm_nombre.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un funcionario", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Dim oreturn() As String
        Dim otercero As Integer = CInt(cm_nombre.SelectedValue)
        oreturn = cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("IMGRHU", otercero, vg_id_cia, vg_usuario_autoriza, "N")
        If oreturn(0) = "" Then
            Exit Sub 'no se hizo ningun cambio
        End If

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0200_terceros set "
        csql += "f0200_id_file_imagen = @f0200_id_file_imagen,"
        csql += "f0200_path_file_imagen = @f0200_path_file_imagen,"
        csql += "f0200_usuario_modificar = @f0200_usuario_modificar,"
        csql += "f0200_fm = @f0200_fm"
        csql += " where f0200_id_tercero = '" & cm_nombre.SelectedValue & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_grabar_elemento_mantenimiento(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0200_id_file_imagen", NpgsqlDbType.Integer).Value = CInt(oreturn(0))
        ocmd.Parameters.Add("@f0200_path_file_imagen", NpgsqlDbType.Varchar).Value = oreturn(1)
        ocmd.Parameters.Add("@f0200_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza.ToString.Trim
        ocmd.Parameters.Add("@f0200_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

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

    Private Sub dtp_fecha_nacimiento_Validating(sender As Object, e As CancelEventArgs) Handles dtp_fecha_nacimiento.Validating
        calcular_edad(dtp_fecha_nacimiento.Value)
    End Sub

    Private Sub bt_ausentismo_Click(sender As Object, e As EventArgs) Handles bt_ausentismo.Click
        verror_requisitos = "N"
        'corro las validaciones
        validaciones()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'recuerda llamo al visor de datos de esta manera para dejar activado el boton de nuevo para nuevas plantillas.
        Dim csql As String = comunes.suministrar_valor_variable_configuracion("ST-0200-02", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_tercero)

        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        'definimos el contexto para habilitar el boton nuevo
        oform_mostrar_datos.ocontexto_form = "historial de ausentismo"
        oform_mostrar_datos.titulo_formulario = "Historial de Ausentismo - Consulta"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.oarray_var = {id_tercero, id_cargo, dtp_fecha_nacimiento.Value, tx_f_1er_contrato.Text, tx_f_act_contrato.Text}
        oform_mostrar_datos.ShowDialog()
    End Sub


    Private Sub tx_f_1er_contrato_DoubleClick(sender As Object, e As EventArgs) Handles tx_f_1er_contrato.DoubleClick
        Dim respuesta As String = comunes.g_mensaje_YesNo("Actualizar fecha", "Desea actualizar la fecha?")
        If respuesta = "S" Then
            tx_f_1er_contrato.Text = comunes.formulario_fecha_hora(Now())
        End If
    End Sub

    Private Sub tx_f_act_contrato_DoubleClick(sender As Object, e As EventArgs) Handles tx_f_act_contrato.DoubleClick
        Dim respuesta As String = comunes.g_mensaje_YesNo("Actualizar fecha", "Desea actualizar la fecha?")
        If respuesta = "S" Then
            tx_f_act_contrato.Text = comunes.formulario_fecha_hora(Now())
        End If
    End Sub

    Private Sub cm_estado_Validating(sender As Object, e As CancelEventArgs) Handles cm_estado.Validating
        If cm_estado.Text <> "Activo" Then
            MsgBox("Si inactiva el usuario se eliminaran todos los permisos del software asociados a este.", MsgBoxStyle.Critical, "Cuidado")
        End If
    End Sub

    Private Sub cm_cargo_Validating(sender As Object, e As CancelEventArgs) Handles cm_cargo.Validating
        id_cargo = cm_cargo.SelectedValue
    End Sub
End Class
