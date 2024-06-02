Imports System.ComponentModel

Public Class fm_0300_gestion_items_costos
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    'Public vg_id_cia As String = ""
    'Public vf_elemento_nuevo As String = "S"
    Public id_estructura As Integer
    'Public otipo_nota As String = ""

    'Private$vf_otabla_permisos$As DataTable

    Public id_item As Integer = 0
    Private acceso_restringido As String = "N"
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

    Private otb_items As DataTable
    Private otb_items2 As DataTable
    Private otb_bodegas As DataTable
    Private otb_puntos_control_inventario As DataTable

    Private id_bodega As Integer
    Private criterio_minimo As Decimal
    Private criterio_maximo As Decimal
    Private criterio_consumo_dia As Decimal

    Private Sub fm_0300_gestion_items_costos_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        vf_var_config_archivos = "CD-ITM"
        vf_var_config_notas = "TN-ITM-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        vf_elemento_nuevo = "N"
        cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
                                                               vg_usuario_autoriza, Me,
                                                               vf_id_notas_archivos, vf_otipo_nota,
                                                               vf_var_config_archivos)

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0300_items" _
            & " where f0300_id_cia = '" & vg_id_cia & "' and f0300_id_item = '" & id_item & "'"
        otb_items = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        For Each orow As DataRow In otb_items.Rows
            tx_costo_estandar.Text = CDec(orow("f0300_costo_estandar")).ToString("C4")
            tx_costo_promedio.Text = CDec(orow("f0300_costo_promedio")).ToString("C4")
            tx_ultimo_costo_compra.Text = CDec(orow("f0300_ultimo_costo")).ToString("C4")
        Next

    End Sub

    Private Sub tx_costo_estandar_Validating(sender As Object, e As CancelEventArgs) Handles tx_costo_estandar.Validating
        If tx_costo_estandar.Text.ToString = "" Or IsNumeric(tx_costo_estandar.Text.ToString) = False Then
            tx_costo_estandar.Text = "0"
        End If
        Dim ocosto As Decimal
        ocosto = tx_costo_estandar.Text
        tx_costo_estandar.Text = ocosto.ToString("C4")
    End Sub

    Private Sub tx_ultimo_costo_compra_Validating(sender As Object, e As CancelEventArgs) Handles tx_ultimo_costo_compra.Validating
        If tx_ultimo_costo_compra.Text.ToString = "" Or IsNumeric(tx_ultimo_costo_compra.Text.ToString) = False Then
            tx_ultimo_costo_compra.Text = "0"
        End If
        Dim ocosto As Decimal
        ocosto = tx_ultimo_costo_compra.Text
        tx_ultimo_costo_compra.Text = ocosto.ToString("C4")
    End Sub

    Private Sub tx_costo_promedio_Validating(sender As Object, e As CancelEventArgs) Handles tx_costo_promedio.Validating
        If tx_costo_promedio.Text.ToString = "" Or IsNumeric(tx_costo_promedio.Text.ToString) = False Then
            tx_costo_promedio.Text = "0"
        End If
        Dim ocosto As Decimal
        ocosto = tx_costo_promedio.Text
        tx_costo_promedio.Text = ocosto.ToString("C4")
    End Sub

    Private Sub tx_costo_estandar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_costo_estandar.KeyPress
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

    Private Sub tx_ultimo_costo_compra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_ultimo_costo_compra.KeyPress
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

    Private Sub tx_costo_promedio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_costo_promedio.KeyPress
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

    Private Sub actualizar_costos()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0300_items set "
        csql += "f0300_costo_promedio = @f0300_costo_promedio,"
        csql += "f0300_costo_estandar =  @f0300_costo_estandar,"
        csql += "f0300_fm = @f0300_fm,"
        csql += "f0300_usuario_modificar = @f0300_usuario_modificar"
        csql += " where f0300_id_item = @f0300_id_item"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_facturas(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0300_id_item", NpgsqlDbType.Integer).Value = id_item
        ocmd.Parameters.Add("@f0300_costo_promedio", NpgsqlDbType.Numeric).Value = CDec(tx_costo_promedio.Text)
        ocmd.Parameters.Add("@f0300_costo_estandar", NpgsqlDbType.Numeric).Value = CDec(tx_costo_estandar.Text)
        ocmd.Parameters.Add("@f0300_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0300_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
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

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        actualizar_costos()
        If verror = "N" Then
            MsgBox("Actualizado", MsgBoxStyle.Information, "Actualizar")
            Dispose()
        End If
    End Sub

    Private Sub bt_historico_compras_Click(sender As Object, e As EventArgs) Handles bt_historico_compras.Click
        cl_utilidades_gestion_compras.movimientos_compras_item(id_item, vg_usuario_autoriza, vg_id_cia)
    End Sub
End Class
