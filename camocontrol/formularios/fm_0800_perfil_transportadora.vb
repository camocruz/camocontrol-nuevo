Imports System.ComponentModel

Public Class fm_0800_perfil_transportadora
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_tercero As String 'se asigna cuando se llama al formulario desde el fm_padre
    Public id_sc_creada As Integer = 0 'para recoger el numero de la solicitud de compra que creo desde el formulario
    'Private$vf_otabla_permisos$As DataTable

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private otipo_nota As String

    Private otb_terceros As DataTable
    Private otb_listado_fletes As DataTable

    Private Sub fm_0800_perfil_transportadora_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-FCC"
        vf_var_config_notas = "TN-FCP-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)

        csql = "select f0200_id_tercero, f0200_id," _
            & " trim(both ' ' from f0200_nombres || ' ' || f0200_apellido1 || ' ' || f0200_apellido2) as razon_social" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "' and f0200_ind_proveedor = 'S'" _
            & " and f0200_ind_principal = 'S'" _
            & " order by f0200_nombres"
        otb_terceros = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_transportadora_despacho
            'Valor que se muestra al usuario
            .DisplayMember = "razon_social"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_terceros
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        tx_id_tercero.Focus()
        tx_id_tercero.Select()
    End Sub

    Private Sub tx_nit_KeyDown(sender As Object, e As KeyEventArgs) Handles tx_id_tercero.KeyDown
        If (e.KeyCode = Keys.F2) Then
            'ejecutar_modo_busqueda_tercero()
        End If
    End Sub
    Private Sub ejecutar_modo_busqueda_tercero()
        Dim otb_items_selected As DataTable = Nothing
        Dim otb_tablas_array() As DataTable = Nothing
        otb_tablas_array = cl_utilidades_datatables.visualizar_datos_visor("ST-0210-01", vg_id_cia, vg_usuario_autoriza,
                                                        "Listado de proveedores",
                                                        {vg_id_cia},
                                                            , "Proveedores",,, "S", "id_tercero",, "S", "N")

        If IsNothing(otb_tablas_array(2)) = False Then
            otb_items_selected = otb_tablas_array(2)
        Else
            Exit Sub
        End If
        'agrego el tercero seleccionado
        For Each orow As DataRow In otb_items_selected.Rows
            'Actualizo el item
            'MsgBox(orow("id_sc_item"))
            tx_id_tercero.Text = orow("id_tercero")
            id_tercero = orow("id_tercero")
            tx_nit.Text = ""
            cm_transportadora_despacho.SelectedIndex = -1
            cm_transportadora_despacho.Text = ""
            tx_id_tercero.Focus()
        Next
    End Sub
    Private Sub inicializar_campos()
        tx_id_tercero.Text = ""
        tx_nit.Text = ""
        cm_transportadora_despacho.SelectedIndex = -1
        cm_transportadora_despacho.Text = ""
        tx_id_tercero.Focus()
    End Sub
    Private Sub tx_id_tercero_Validating(sender As Object, e As CancelEventArgs) Handles tx_id_tercero.Validating
        If tx_id_tercero.Text.Trim <> "" Then
            tx_id_tercero.Text = tx_id_tercero.Text.Trim.PadLeft(8, "0")
            Dim orow_tercero As DataRow()
            orow_tercero = otb_terceros.Select("f0200_id_tercero = '" & tx_id_tercero.Text & "'")
            If orow_tercero.Length > 0 Then
                cm_transportadora_despacho.SelectedValue = orow_tercero(0)("f0200_id_tercero")
                tx_nit.Text = orow_tercero(0)("f0200_id")
                id_tercero = orow_tercero(0)("f0200_id_tercero")
                bt_tarifas.Focus()
            Else
                MsgBox("No Existe", MsgBoxStyle.Information, "Error")
                inicializar_campos()
            End If
        End If
    End Sub

    Private Sub cm_transportadora_despacho_Validating(sender As Object, e As CancelEventArgs) Handles cm_transportadora_despacho.Validating
        If cm_transportadora_despacho.SelectedIndex <> -1 Then
            Dim orow_tercero As DataRow()
            orow_tercero = otb_terceros.Select("f0200_id_tercero = '" & cm_transportadora_despacho.SelectedValue & "'")
            If orow_tercero.Length > 0 Then
                tx_id_tercero.Text = orow_tercero(0)("f0200_id_tercero")
                tx_nit.Text = orow_tercero(0)("f0200_id")
                id_tercero = orow_tercero(0)("f0200_id_tercero")
                bt_tarifas.Focus()
            End If
        Else
            If cm_transportadora_despacho.Text.Trim <> "" Then
                MsgBox("No Existe", MsgBoxStyle.Information, "Error")
                inicializar_campos()
            End If
            cm_transportadora_despacho.Text = ""
        End If
    End Sub

    Private Sub tx_nit_Validating(sender As Object, e As CancelEventArgs) Handles tx_nit.Validating
        If tx_nit.Text.Trim <> "" Then
            Dim orow_tercero As DataRow()
            orow_tercero = otb_terceros.Select("f0200_id = '" & tx_nit.Text.Trim & "'")
            If orow_tercero.Length > 0 Then
                tx_id_tercero.Text = orow_tercero(0)("f0200_id_tercero")
                cm_transportadora_despacho.SelectedValue = orow_tercero(0)("f0200_id_tercero")
                id_tercero = orow_tercero(0)("f0200_id_tercero")
                bt_tarifas.Focus()
            Else
                MsgBox("No Existe", MsgBoxStyle.Information, "Error")
                inicializar_campos()
            End If
        End If
    End Sub

    Private Sub fm_0800_perfil_transportadora_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F2) Then
            ejecutar_modo_busqueda_tercero()
        End If
    End Sub

    Private Sub bt_tarifas_Click(sender As Object, e As EventArgs) Handles bt_tarifas.Click
        If cm_transportadora_despacho.SelectedIndex = -1 Then
            MsgBox("Seleccione una transportadora", MsgBoxStyle.Information)
            Exit Sub
        End If

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_tarifas As New camocontrol.fm_0800_costo_flete_transportadora
        'oform_grilla_programacion.ods_hijo = ods
        oform_tarifas.vf_oform_padre = Me
        oform_tarifas.lb_titulo.Text = "Actualizar Tarifa Transportadora"
        oform_tarifas.vg_id_cia = vg_id_cia
        oform_tarifas.vg_usuario_autoriza = vg_usuario_autoriza
        oform_tarifas.id_tercero = id_tercero
        oform_tarifas.lb_transportadora.Text = cm_transportadora_despacho.Text
        'oform_tarifas.tx_estructura.Text = "Reclamacion Cliente"
        oform_tarifas.ShowDialog()
    End Sub

    Private Sub bt_listado_fletes_Click(sender As Object, e As EventArgs) Handles bt_listado_fletes.Click
        If cm_transportadora_despacho.SelectedIndex = -1 Then
            MsgBox("Seleccione una transportadora", MsgBoxStyle.Information)
            Exit Sub
        End If
        csql = "Select f0052_ciudad || ' - ' || f0051_departamento as ciudad,"
        csql += " f0802_valor_flete as valor, f0802_recaudo as recaudo"
        csql += " from "
        csql += database.obtener_esquema & ".tb0802_costos_destinos_transportadoras"
        csql += " left join " & database.obtener_esquema & ".tb0052_ciudades"
        csql += " on f0802_id_ciudad_destino = f0052_codigo_ciudad"
        csql += " join " & database.obtener_esquema & ".tb0051_departamentos"
        csql += " on f0051_codigo_departamento = f0052_codigo_departamento"
        csql += " where f0802_id_cia = '" & vg_id_cia & "'"
        csql += " and  f0802_id_tercero = '" & id_tercero & "'"
        csql += " order by f0052_ciudad"
        otb_listado_fletes = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        cl_utilidades_datatables.visualizar_datos_visor("", vg_id_cia, vg_usuario_autoriza, "Listado de Fletes", {vg_id_cia}, otb_listado_fletes)
    End Sub
End Class
