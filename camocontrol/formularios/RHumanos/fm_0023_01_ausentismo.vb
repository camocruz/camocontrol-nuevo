Imports System.ComponentModel

Public Class fm_0023_01_ausentismo
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

    Public id_ausnt As Integer = 0
    Public id_tercero As String = ""
    Public id_cargo As Integer = 0
    Public fecha_nacimiento As Date
    Public fecha_ini_1er_contrato As Date
    Public fecha_ini_act_contrato As Date

    Private otercero As Integer

    'Private$vf_otabla_permisos$As DataTable

    Private otb_info_ausentismo As DataTable
    Private otb_causas As DataTable
    Private otb_cargos As DataTable

    Private id_estructura As Integer = 0
    Private edad_redondeada_anos As Integer
    Private edad_redondeada_meses As Integer
    Private editando_registro As String = "N"
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand

    Private Sub fm_0023_01_ausentismo_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        vf_var_config_archivos = "CD-AUS"
        vf_var_config_notas = "TN-AUS-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        vf_id_notas_archivos = id_ausnt
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)

        tx_id_ausentismo.ReadOnly = True
        tx_edad_evento.ReadOnly = True

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_inicio_tnl.Format = DateTimePickerFormat.Custom
        dtp_fecha_inicio_tnl.CustomFormat = "{dddd}  yyyy/MM/dd  HH:mm"

        Dim otb_tipo_ausentismo As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0217_tipos_ausentismo" _
            & " where f0217_anulado = 'N' and f0217_id_cia = '" & vg_id_cia & "'"
        otb_tipo_ausentismo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_tipo
            'Valor que se muestra al usuario
            .DisplayMember = "f0217_tipo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0217_id_tipo"
            'Origen de Datos del ComboBox
            .DataSource = otb_tipo_ausentismo
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        Dim otb_plantas_produccion As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0100_estructura_mantenimiento"
        csql += " where array_length(regexp_split_to_array(f0100_path,'-'),1) = 2 and f0100_id_tipo_estructura = '00000001'"
        csql += " and f0100_id_cia = '" & vg_id_cia & "'"
        csql += " order by f0100_nombre"
        otb_plantas_produccion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_planta_produccion
            'Valor que se muestra al usuario
            .DisplayMember = "f0100_nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0100_id_estructura"
            'Origen de Datos del ComboBox
            .DataSource = otb_plantas_produccion
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        csql = "select *, f0215_codigo || ' - ' || f0215_causa as descri" _
            & " from " & database.obtener_esquema & ".tb0215_causas_ausentismo" _
              & " Join " & database.obtener_esquema & ".tb0214_grupos_ausentismo" _
                & " on f0214_id_grupo = f0215_id_grupo" _
            & " where f0215_anulado = 'N' and f0215_id_cia = '" & vg_id_cia & "'"
        otb_causas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = "select * from " & database.obtener_esquema & ".tb0240_cargos_compania" _
            & " where f0240_anulado = 'N' and f0240_id_cia = '" & vg_id_cia & "'"
        otb_cargos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_causa
            'Valor que se muestra al usuario
            .DisplayMember = "f0215_causa"
            'Valor interno que almacena el objeto
            .ValueMember = "f0215_id_causa"
            'Origen de Datos del ComboBox
            .DataSource = otb_causas
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With
        With cm_cod_causa
            'Valor que se muestra al usuario
            .DisplayMember = "descri"
            'Valor interno que almacena el objeto
            .ValueMember = "f0215_id_causa"
            'Origen de Datos del ComboBox
            .DataSource = otb_causas
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With


        If vf_elemento_nuevo = "N" Then
            cargar_info_ausentismo()
        Else
            Dim f_actual As Date = comunes.g_fechahora

            'identificamos la informacion del cargo
            Dim orow As DataRow() = otb_cargos.Select("f0240_id_cargo = '" & id_cargo & "'")
            tx_cargo.Text = orow(0)("f0240_cargo")
            'calculo la edad actual
            calcular_edad(fecha_nacimiento, f_actual)
            tx_edad_evento.Text = edad_redondeada_anos
            'calulo la antiguedad de acuerdo al contrato inicial
            calcular_edad(fecha_ini_1er_contrato, f_actual)
            tx_antiguedad_total.Text = edad_redondeada_meses
            'calulo la antiguedad de acuerdo al contrato actual
            calcular_edad(fecha_ini_act_contrato, f_actual)
            tx_antiguedad_actual.Text = edad_redondeada_meses
            tx_cant_prorrogas.Text = 0
            tx_dias_prorroga.Text = 0
            tx_tnl.Text = 0
            tx_incapacidad_ini.Text = 0

            cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_grabar, "")
        End If

    End Sub
    Private Sub calcular_edad(ByVal f_nacimiento As Date, ByVal f_calculo As Date)
        Dim cumplidos As Boolean
        Dim anoactual As Integer = f_calculo.Year
        ' SE COMPRUEBA CUANDO FUE EL ULTIMOS CUMPLEAÑOS
        ' FORMULA:
        '   Años cumplidos = (Año del ultimo cumpleaños - Año de nacimiento)
        If (f_nacimiento.Month <= f_calculo.Month) Then
            If (f_nacimiento.Day <= f_calculo.Day) Then
                If (f_nacimiento.Day = f_calculo.Day And f_nacimiento.Month = f_calculo.Month) Then
                    'MsgBox("Feliz Cumpleaños!")
                End If
                ' MsgBox("Ya cumplio")
                cumplidos = True
            End If
        End If
        If (cumplidos = False) Then
            anoactual = (f_calculo.Year - 1)
            'MsgBox("Ultimo cumpleaños: " & anoactual)
        End If
        ' Se realiza la resta de años para definir los años cumplidos
        Dim edadanos As Integer = (anoactual - f_nacimiento.Year)
        'MsgBox(edadanos)
        ' DEFINICION DE LOS MESES LUEGO DEL ULTIMO CUMPLEAÑOS
        Dim EdadMes As Integer
        If Not (anoactual = f_calculo.Year) Then
            EdadMes = (12 - f_nacimiento.Month)
            EdadMes = EdadMes + f_calculo.Month
        Else
            EdadMes = Math.Abs(f_calculo.Month - f_nacimiento.Month)
        End If
        'SACAMOS LA CANTIDAD DE DIAS EXACTOS
        'Dim EdadDia As Integer = (DiaActual - DiaNacimiento)

        edad_redondeada_anos = Math.Round(edadanos + (EdadMes / 12), 0)
        edad_redondeada_meses = (edadanos * 12) + EdadMes

        'RETORNAMOS LOS VALORES EN UNA CADENA STRING
        'lb_edad.Text = edadanos & " años , " & EdadMes & " meses"
        'Return ("Ud. tiene exactamente " & EdadAños & " años , " & EdadMes & " meses y " & EdadDia & " dias")
    End Sub
    Private Sub cargar_otb_ausentismo()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0200-03", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_ausnt)
        otb_info_ausentismo = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'MsgBox(otb_info_ausentismo.Rows.Count & " -- " & id_ausnt)
    End Sub

    Private Sub cm_cod_causa_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_cod_causa.Validating
        If cm_cod_causa.SelectedIndex = -1 Then
            cm_cod_causa.Text = ""
            Exit Sub
        End If
        cm_causa.SelectedValue = cm_cod_causa.SelectedValue
        tx_grupo_causa.Text = grupo_causa(cm_causa.SelectedValue)
    End Sub

    Private Sub cm_causa_Validating(sender As Object, e As CancelEventArgs) Handles cm_causa.Validating
        If cm_causa.SelectedIndex = -1 Then
            cm_causa.Text = ""
            Exit Sub
        End If
        cm_cod_causa.SelectedValue = cm_causa.SelectedValue
        tx_grupo_causa.Text = grupo_causa(cm_cod_causa.SelectedValue)
    End Sub

    Private Function grupo_causa(ByVal id_causa As Integer)
        Dim orow As DataRow()
        orow = otb_causas.Select("f0215_id_causa = '" & id_causa & "'")
        Dim ogrupo As String = orow(0)("f0214_descripcion_grupo")
        Return ogrupo
    End Function

    Private Sub cargar_info_ausentismo()
        If id_ausnt = 0 Then
            Exit Sub
        End If
        cargar_otb_ausentismo()

        vf_id_notas_archivos = id_ausnt
        vf_elemento_nuevo = "N"

        For Each orow As DataRow In otb_info_ausentismo.Rows
            tx_id_ausentismo.Text = id_ausnt

            If IsDBNull(orow("f_final_tnl")) = True Then
                tx_estado.Text = "Abierto"
            Else
                tx_estado.Text = "Cerrado"
                tx_fecha_fin_tnl.Text = CDate(orow("f_final_tnl")).ToString("yyyy-MM-dd HH:mm:ss")
            End If
            cm_tipo.SelectedValue = orow("f0216_id_tipo")
            cm_planta_produccion.SelectedValue = orow("f0216_planta")
            tx_estructura.Text = comunes.traer_nombre_estructura(orow("f0216_maquina"))

            id_tercero = orow("f0200_id_tercero")
            dtp_fecha_inicio_tnl.Value = orow("f_inicial_tnl")
            tx_cargo.Text = orow("cargo")
            tx_lugar_ocurrencia.Text = orow("f0216_lugar_ocurrencia")
            tx_antiguedad_actual.Text = orow("ant_act")
            tx_antiguedad_total.Text = orow("ant_tot")
            tx_edad_evento.Text = orow("edad")
            tx_incapacidad_ini.Text = orow("d_inc_ini")
            tx_cant_prorrogas.Text = orow("f0216_cant_prorrogas")
            tx_dias_prorroga.Text = orow("d_prorroga")
            tx_tnl.Text = orow("horas_tnl")

            cm_cod_causa.SelectedValue = orow("f0215_id_causa")
            cm_causa.SelectedValue = orow("f0215_id_causa")
            tx_grupo_causa.Text = orow("grupo")
            tx_observacion.Text = orow("observacion")
            'calculo los dias calendario de ausencia
            If tx_fecha_fin_tnl.Text <> "" Then
                tx_dias_calendario.Text = DateDiff(DateInterval.Day, dtp_fecha_inicio_tnl.Value, CDate(tx_fecha_fin_tnl.Text))
            End If
        Next
    End Sub

    Private Sub dtp_fecha_inicio_tnl_Validating(sender As Object, e As CancelEventArgs) Handles dtp_fecha_inicio_tnl.Validating
        Dim fecha_act As Date = comunes.g_fechahora
        If fecha_nacimiento > dtp_fecha_inicio_tnl.Value Or dtp_fecha_inicio_tnl.Value > fecha_act Then
            dtp_fecha_inicio_tnl.Value = fecha_act
            MsgBox("Fecha no valida", MsgBoxStyle.Information, "Error")
        End If
        'calculo la edad segun la fecha del evento
        calcular_edad(fecha_nacimiento, dtp_fecha_inicio_tnl.Value)
        tx_edad_evento.Text = edad_redondeada_anos
        'calculo los dias calendario de ausencia
        If tx_fecha_fin_tnl.Text <> "" Then
            tx_dias_calendario.Text = DateDiff(DateInterval.Day, dtp_fecha_inicio_tnl.Value, CDate(tx_fecha_fin_tnl.Text))
        End If
    End Sub

    Private Sub grabar_nuevo_ausentismo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0216_ausentismo" _
                & " (f0216_id_cia, f0216_id_tercero, f0216_id_causa, f0216_observacion," _
                & " f0216_id_tipo, f0216_maquina, f0216_planta," _
                & " f0216_edad, f0216_id_cargo, f0216_antiguedad_ini," _
                & " f0216_antiguedad_act, f0216_fecha_inicio_tnl, f0216_fecha_fin_tnl," _
                & " f0216_nombre_dia_ini_tnl, f0216_nombre_mes_ini_tnl," _
                & " f0216_dias_incap_inicial, f0216_dias_prorroga," _
                & " f0216_horas_tnl, f0216_lugar_ocurrencia, f0216_cant_prorrogas," _
                & " f0216_usuario_modificar, f0216_usuario_crear, f0216_fm)" _
                & " VALUES" _
                & " (@f0216_id_cia, @f0216_id_tercero, @f0216_id_causa, @f0216_observacion," _
                & " @f0216_id_tipo, @f0216_maquina, @f0216_planta," _
                & " @f0216_edad, @f0216_id_cargo, @f0216_antiguedad_ini," _
                & " @f0216_antiguedad_act, @f0216_fecha_inicio_tnl, @f0216_fecha_fin_tnl," _
                & " @f0216_nombre_dia_ini_tnl, @f0216_nombre_mes_ini_tnl," _
                & " @f0216_dias_incap_inicial, @f0216_dias_prorroga," _
                & " @f0216_horas_tnl, @f0216_lugar_ocurrencia, @f0216_cant_prorrogas," _
                & " @f0216_usuario_modificar, @f0216_usuario_crear, @f0216_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_ausentismo(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + vbCrLf + ex.ToString + vbCrLf + csql)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                If ex.ToString.Trim <> "" And InStr(ex.ToString.ToUpper, "23505".ToUpper) <> 0 Then
                    'MsgBox("Esta factura ya ha sido registrada!")
                Else
                    'MsgBox("Hubo un error al Grabar! ") ' + vbCrLf + ex.ToString)
                End If
                MsgBox("Hubo un error al Grabar!" + vbCrLf + ex.ToString)
                verror = "S"
            End Try
        End If
        If verror = "N" Then
            vf_elemento_nuevo = "N"
            cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota, vf_var_config_archivos)
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_ausentismo(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0216_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0216_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("@f0216_id_causa", NpgsqlDbType.Integer).Value = cm_causa.SelectedValue
        ocmd.Parameters.Add("@f0216_observacion", NpgsqlDbType.Varchar).Value = tx_observacion.Text.ToString.Trim.ToUpper
        ocmd.Parameters.Add("@f0216_edad", NpgsqlDbType.Numeric).Value = tx_edad_evento.Text
        ocmd.Parameters.Add("@f0216_id_cargo", NpgsqlDbType.Integer).Value = id_cargo
        ocmd.Parameters.Add("@f0216_antiguedad_ini", NpgsqlDbType.Numeric).Value = tx_antiguedad_total.Text
        ocmd.Parameters.Add("@f0216_antiguedad_act", NpgsqlDbType.Numeric).Value = tx_antiguedad_total.Text
        ocmd.Parameters.Add("@f0216_fecha_inicio_tnl", NpgsqlDbType.Timestamp).Value = dtp_fecha_inicio_tnl.Value
        ocmd.Parameters.Add("@f0216_id_tipo", NpgsqlDbType.Integer).Value = cm_tipo.SelectedValue

        If cm_planta_produccion.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0216_planta", NpgsqlDbType.Integer).Value = 0
        Else
            ocmd.Parameters.Add("@f0216_planta", NpgsqlDbType.Integer).Value = cm_planta_produccion.SelectedValue
        End If
        ocmd.Parameters.Add("@f0216_maquina", NpgsqlDbType.Integer).Value = id_estructura

        If tx_fecha_fin_tnl.Text = "" Then
            ocmd.Parameters.Add("@f0216_fecha_fin_tnl", NpgsqlDbType.Timestamp).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0216_fecha_fin_tnl", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_fin_tnl.Text)
        End If
        ocmd.Parameters.Add("@f0216_nombre_dia_ini_tnl", NpgsqlDbType.Varchar).Value = comunes.devolver_nombre_dia_semana(dtp_fecha_inicio_tnl.Value)
        ocmd.Parameters.Add("@f0216_nombre_mes_ini_tnl", NpgsqlDbType.Varchar).Value = comunes.devolver_nombre_mes_ano(dtp_fecha_inicio_tnl.Value)
        ocmd.Parameters.Add("@f0216_dias_incap_inicial", NpgsqlDbType.Integer).Value = tx_incapacidad_ini.Text
        ocmd.Parameters.Add("@f0216_dias_prorroga", NpgsqlDbType.Integer).Value = tx_dias_prorroga.Text
        ocmd.Parameters.Add("@f0216_horas_tnl", NpgsqlDbType.Integer).Value = CInt(tx_tnl.Text)
        ocmd.Parameters.Add("@f0216_lugar_ocurrencia", NpgsqlDbType.Varchar).Value = tx_lugar_ocurrencia.Text
        ocmd.Parameters.Add("@f0216_cant_prorrogas", NpgsqlDbType.Integer).Value = tx_cant_prorrogas.Text
        ocmd.Parameters.Add("@f0216_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0216_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0216_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub actualizar_ausentismo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0216_ausentismo set "
        csql += "f0216_id_causa = @f0216_id_causa,"
        csql += "f0216_observacion = @f0216_observacion,"
        csql += "f0216_edad = @f0216_edad,"
        csql += "f0216_maquina = @f0216_maquina,"
        csql += "f0216_id_tipo = @f0216_id_tipo,"
        csql += "f0216_planta = @f0216_planta,"
        csql += "f0216_dias_incap_inicial = @f0216_dias_incap_inicial,"
        csql += "f0216_antiguedad_act = @f0216_antiguedad_act,"
        csql += "f0216_fecha_inicio_tnl = @f0216_fecha_inicio_tnl,"
        csql += "f0216_fecha_fin_tnl = @f0216_fecha_fin_tnl,"
        csql += "f0216_nombre_dia_ini_tnl = @f0216_nombre_dia_ini_tnl,"
        csql += "f0216_nombre_mes_ini_tnl = @f0216_nombre_mes_ini_tnl,"
        csql += "f0216_dias_prorroga = @f0216_dias_prorroga,"
        csql += "f0216_horas_tnl = @f0216_horas_tnl,"
        csql += "f0216_lugar_ocurrencia = @f0216_lugar_ocurrencia,"
        csql += "f0216_cant_prorrogas = @f0216_cant_prorrogas,"
        csql += "f0216_fm = @f0216_fm,"
        csql += "f0216_usuario_modificar = @f0216_usuario_modificar"
        csql += " where f0216_id_ausentismo = @f0216_id_ausentismo"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_actualiazar_ausentismo(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! ") ' + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! ") ' + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_actualiazar_ausentismo(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0216_id_ausentismo", NpgsqlDbType.Integer).Value = id_ausnt
        ocmd.Parameters.Add("@f0216_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0216_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("@f0216_id_causa", NpgsqlDbType.Integer).Value = cm_causa.SelectedValue
        ocmd.Parameters.Add("@f0216_observacion", NpgsqlDbType.Varchar).Value = tx_observacion.Text.ToString.Trim.ToUpper
        ocmd.Parameters.Add("@f0216_edad", NpgsqlDbType.Numeric).Value = tx_edad_evento.Text
        ocmd.Parameters.Add("@f0216_id_cargo", NpgsqlDbType.Integer).Value = id_cargo
        ocmd.Parameters.Add("@f0216_antiguedad_ini", NpgsqlDbType.Numeric).Value = tx_antiguedad_total.Text
        ocmd.Parameters.Add("@f0216_antiguedad_act", NpgsqlDbType.Numeric).Value = tx_antiguedad_total.Text
        ocmd.Parameters.Add("@f0216_fecha_inicio_tnl", NpgsqlDbType.Timestamp).Value = dtp_fecha_inicio_tnl.Value
        ocmd.Parameters.Add("@f0216_id_tipo", NpgsqlDbType.Integer).Value = cm_tipo.SelectedValue

        If cm_planta_produccion.SelectedIndex = -1 Then
            ocmd.Parameters.Add("@f0216_planta", NpgsqlDbType.Integer).Value = 0
        Else
            ocmd.Parameters.Add("@f0216_planta", NpgsqlDbType.Integer).Value = cm_planta_produccion.SelectedValue
        End If
        ocmd.Parameters.Add("@f0216_maquina", NpgsqlDbType.Integer).Value = id_estructura

        If tx_fecha_fin_tnl.Text = "" Then
            ocmd.Parameters.Add("@f0216_fecha_fin_tnl", NpgsqlDbType.Timestamp).Value = DBNull.Value
        Else
            ocmd.Parameters.Add("@f0216_fecha_fin_tnl", NpgsqlDbType.Timestamp).Value = CDate(tx_fecha_fin_tnl.Text)
        End If
        ocmd.Parameters.Add("@f0216_nombre_dia_ini_tnl", NpgsqlDbType.Varchar).Value = comunes.devolver_nombre_dia_semana(dtp_fecha_inicio_tnl.Value)
        ocmd.Parameters.Add("@f0216_nombre_mes_ini_tnl", NpgsqlDbType.Varchar).Value = comunes.devolver_nombre_mes_ano(dtp_fecha_inicio_tnl.Value)
        ocmd.Parameters.Add("@f0216_dias_incap_inicial", NpgsqlDbType.Integer).Value = tx_incapacidad_ini.Text
        ocmd.Parameters.Add("@f0216_dias_prorroga", NpgsqlDbType.Integer).Value = tx_dias_prorroga.Text
        ocmd.Parameters.Add("@f0216_horas_tnl", NpgsqlDbType.Integer).Value = CInt(tx_tnl.Text)
        ocmd.Parameters.Add("@f0216_lugar_ocurrencia", NpgsqlDbType.Varchar).Value = tx_lugar_ocurrencia.Text
        ocmd.Parameters.Add("@f0216_cant_prorrogas", NpgsqlDbType.Integer).Value = tx_cant_prorrogas.Text
        ocmd.Parameters.Add("@f0216_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0216_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0216_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub tx_fecha_fin_tnl_DoubleClick(sender As Object, e As EventArgs) Handles tx_fecha_fin_tnl.DoubleClick
        Dim respuesta As String = comunes.g_mensaje_YesNo("Actualizar fecha", "Desea actualizar la fecha?")
        If respuesta = "S" Then
            tx_fecha_fin_tnl.Text = comunes.formulario_fecha_hora(Now())
        End If
    End Sub
    Private Sub validar_tipo()
        If cm_tipo.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el tipo de ausentismo."
        End If
    End Sub
    Private Sub validar_fechas()
        If tx_fecha_fin_tnl.Text <> "" Then
            If dtp_fecha_inicio_tnl.Value >= CDate(tx_fecha_fin_tnl.Text) Then
                verror_requisitos = "S"
                vmensaje_requisitos = "La fecha final no puede ser menor o igual a la fecha de inicio."
            End If
        End If
    End Sub
    Private Sub validar_causa()
        If cm_causa.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la causa del ausentismo."
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        Dim respuesta As String = comunes.g_mensaje_YesNo("Grabar", "Desea grabar los cambios?")
        If respuesta = "N" Then
            Exit Sub
        End If
        verror_requisitos = "N"
        validar_fechas()
        validar_causa()
        validar_tipo()

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            grabar_nuevo_ausentismo()
        Else
            actualizar_ausentismo()
        End If
        If verror = "N" Then
            MsgBox("Grabado", MsgBoxStyle.Information, "Info")
            Dispose()
        End If
    End Sub

    Private Sub tx_fecha_fin_tnl_Validating(sender As Object, e As CancelEventArgs) Handles tx_fecha_fin_tnl.Validating
        If tx_fecha_fin_tnl.Text <> "" Then
            tx_dias_calendario.Text = DateDiff(DateInterval.Day, dtp_fecha_inicio_tnl.Value, CDate(tx_fecha_fin_tnl.Text))
        End If
    End Sub

    Private Sub bt_cambiar_infraestructura_Click(sender As Object, e As EventArgs) Handles bt_cambiar_infraestructura.Click
        verror_requisitos = "N"
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Cambio denegado")
            Exit Sub
        End If
        Dim id_nueva_estructura As String = id_estructura.ToString
        id_nueva_estructura = cl_utilidades_gestion_mantenimiento.suministrar_estructura_mantenimiento(vg_id_cia, vg_usuario_autoriza, id_estructura)
        Dim id_estructura_anterior As Integer = id_estructura
        If id_estructura.ToString <> id_nueva_estructura Then
            id_estructura = id_nueva_estructura
            tx_estructura.Text = comunes.traer_nombre_estructura(id_nueva_estructura)
        End If
    End Sub
End Class
