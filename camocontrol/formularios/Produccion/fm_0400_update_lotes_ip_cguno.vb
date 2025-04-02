Public Class fm_0400_update_lotes_ip_cguno
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

    End Sub
    Private Sub traer_info_ip_cg()
        If txt_ip_num.Text.ToString.Trim = "" Then
            Exit Sub
        End If
        csql = "select f0406_id,f0406_referencia,f0406_descripcion,f0406_lote from " & database.obtener_esquema & ".tb0406_det_prod_ip_cg_umpr4015_9"
        csql += " where f0406_ip_num = '" & txt_ip_num.Text.ToString.Trim & "'"
        otb_item = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_item.Rows.Count = 0 Then
            MsgBox("La referencia no existe")
            reset_campos()
            Exit Sub
        End If
        txt_lote.Text = ""
        dg_items.DataSource = otb_item
    End Sub
    Private Sub reset_campos()
        txt_ip_num.Text = ""
        txt_lote.Text = ""
        otb_item = Nothing
        dg_items.DataSource = Nothing
        dg_items.Rows.Clear()
        txt_ip_num.Select()
    End Sub
    Private Sub actualizar_item()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0406_det_prod_ip_cg_umpr4015_9 set "
        csql += "f0406_lote = @f0406_lote"
        csql += " where f0406_ip_num = '" & txt_ip_num.Text.ToString.Trim & "'"

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
        ocmd.Parameters.Add("@f0406_lote", NpgsqlDbType.Varchar).Value = "Lote: " & UCase(txt_lote.Text.ToString.Trim)
    End Sub

    Private Sub bt_actualizar_Click(sender As Object, e As EventArgs) Handles bt_actualizar.Click
        verror_requisitos = "N"
        If dg_items.Rows.Count = 0 Or txt_lote.Text.ToString.Trim = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "No hay datos que actualizar"
        End If
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos)
            Exit Sub
        End If
        actualizar_item()
        reset_campos()
        Dim otb As DataTable
        csql = "select * from " & database.obtener_esquema & ".fnc_ip_cguno_exportar_tablas_csv();"
        otb = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub txt_ip_num_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_ip_num.Validating
        traer_info_ip_cg()
    End Sub
End Class
