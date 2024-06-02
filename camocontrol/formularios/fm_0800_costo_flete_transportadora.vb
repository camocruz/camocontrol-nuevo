Imports System.ComponentModel
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class fm_0800_costo_flete_transportadora
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Public id_tercero As String = String.Empty
    Public id_ciudad As String = String.Empty

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private csql As String

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String

    Private otb_listado_fletes As DataTable
    Private FleteActual As Decimal

    Private Sub fm_0800_costo_flete_transportadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Dim otb_ciudades As DataTable
        csql = "select f0052_codigo_ciudad, f0052_ciudad || ' - ' || f0051_departamento as ciudad" _
            & " from " & database.obtener_esquema & ".tb0052_ciudades" _
            & " join " & database.obtener_esquema & ".tb0051_departamentos" _
            & " on f0051_codigo_departamento = f0052_codigo_departamento"
        otb_ciudades = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        With cm_destino
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
        cargar_listado_fletes()
        cm_destino.Focus()
        cm_destino.Select

    End Sub
    Private Sub cargar_listado_fletes()
        csql = "Select tb0802_costos_destinos_transportadoras.*, f0052_ciudad  from "
        csql += database.obtener_esquema & ".tb0802_costos_destinos_transportadoras"
        csql += " left join " & database.obtener_esquema & ".tb0052_ciudades"
        csql += " on f0802_id_ciudad_destino = f0052_codigo_ciudad"
        csql += " where f0802_id_cia = '" & vg_id_cia & "'"
        csql += " and  f0802_id_tercero = '" & id_tercero & "'"
        csql += " order by f0052_ciudad"
        otb_listado_fletes = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Console.WriteLine("Cargado")
    End Sub

    Private Sub grabar_nuevo_flete()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0802_costos_destinos_transportadoras" _
                & " (f0802_id_cia, f0802_id_tercero, f0802_id_ciudad_destino, f0802_valor_flete, f0802_recaudo," _
                & " f0802_usuario_modificar, f0802_usuario_crear, f0802_fm)" _
                & " VALUES" _
                & " (@f0802_id_cia, @f0802_id_tercero, @f0802_id_ciudad_destino, @f0802_valor_flete, @f0802_recaudo," _
                & " @f0802_usuario_modificar, @f0802_usuario_crear, @f0802_fm)" _
        & " ON CONFLICT ON CONSTRAINT pk_tb0802 DO UPDATE SET f0802_valor_flete = @f0802_valor_flete," _
        & " f0802_usuario_modificar = @f0802_usuario_modificar," _
        & " f0802_fm = @f0802_fm;"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_flete(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nuevo pedido! " + vbCrLf + ex.ToString + vbCrLf + csql)
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
    Private Sub crear_parametros_flete(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        If vf_elemento_nuevo = "N" Then
            'ocmd.Parameters.Add("@f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        End If
        ocmd.Parameters.Add("@f0802_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0802_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("@f0802_valor_flete", NpgsqlDbType.Numeric).Value = tx_valor.Text
        If rb_sin_recaudo.Checked = True Then
            ocmd.Parameters.Add("@f0802_recaudo", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0802_recaudo", NpgsqlDbType.Varchar).Value = "S"
        End If
        ocmd.Parameters.Add("@f0802_id_ciudad_destino", NpgsqlDbType.Varchar).Value = cm_destino.SelectedValue
        ocmd.Parameters.Add("@f0802_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0802_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0802_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
    End Sub
    Private Sub identificar_valor_flete()
        If cm_destino.SelectedIndex <> -1 Then
            Dim orow_destino As DataRow()
            Dim ofiltro As String = String.Empty
            ofiltro = "f0802_id_ciudad_destino = '" & cm_destino.SelectedValue & "'"
            If rb_sin_recaudo.Checked Then
                ofiltro += " and f0802_recaudo = 'N'"
            Else
                ofiltro += " and f0802_recaudo = 'S'"
            End If
            orow_destino = otb_listado_fletes.Select(ofiltro)
            If orow_destino.Length > 0 Then
                tx_valor.Text = FormatCurrency(orow_destino(0)("f0802_valor_flete"), 2)
                FleteActual = orow_destino(0)("f0802_valor_flete")
            End If

        End If
    End Sub
    Private Sub validar_valor_flete()
        If tx_valor.Text.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina el valor del flete"
        End If
        If IsNumeric(tx_valor.Text) = False Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El valor del flete debe ser numerico"
        End If
    End Sub
    Private Sub validar_ciudad_destino()
        If cm_destino.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina la ciudad de Destino"
        End If
    End Sub
    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_ciudad_destino()
        validar_valor_flete()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If FleteActual <> CDec(tx_valor.Text) Then
            grabar_nuevo_flete()
        End If

        cm_destino.SelectedIndex = -1
        tx_valor.Text = ""
        cargar_listado_fletes()
        cm_destino.Focus()
    End Sub

    Private Sub cm_destino_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cm_destino.Validating
        If cm_destino.SelectedIndex <> -1 Then
            identificar_valor_flete()
        End If
    End Sub

    Private Sub rb_sin_recaudo_CheckedChanged(sender As Object, e As EventArgs) Handles rb_sin_recaudo.CheckedChanged
        identificar_valor_flete()
    End Sub

    Private Sub tx_valor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_valor.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

End Class
