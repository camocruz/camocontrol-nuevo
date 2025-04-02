Public Class fm_0400_gestion_agrupada_consumos_produccion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_prog_prod As Integer
    Public id_rp As Integer
    Public id_ipp As Integer
    Public id_item As Integer
    Public otb_items_programa_produccion As DataTable

    Private otipo_nota As String

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private estado_rp As String = "C" 'A = abierto  C = cerrado
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private otb_bodegas As DataTable
    Private otb_reporte_produccion As DataTable
    Private id_doc_inv As String

    Private Sub fm_0400_gestion_agrupada_consumos_produccion_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        csql = "select f0005_id_bodega, f0005_descripcion_bodega" _
            & " from " & database.obtener_esquema & ".tb0005_bodegas" _
            & " where f0005_anulado = 'N'"
        otb_bodegas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        cargar_doctos_pendientes()
    End Sub

    Private Sub cargar_doctos_pendientes()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)

        Dim otb_doctos_pend As DataTable
        otb_doctos_pend = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'dg_doc_pendientes.Rows.Clear()
        dg_doc_pendientes.DataSource = otb_doctos_pend

    End Sub

    Private Sub bt_nuevo_Click(sender As Object, e As EventArgs) Handles bt_nuevo.Click
        'Pregunta si realmente desea reportar una produccion.
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Reportar Consumos Produccion CG-UNO", "Desea un nuevo reporte agrupado de consumos?")
        If respuesta = "N" Then
            Exit Sub
        End If
        'Identifico la bodega
        Dim ODisplayMember As String = "f0005_descripcion_bodega"
        Dim OValueMember As String = "f0005_id_bodega"
        Dim id_bodega As String = comunes.formulario_parametro_texto("", "Bodega", False, otb_bodegas, ODisplayMember, OValueMember)
        If id_bodega.Trim = "" Then
            Exit Sub
        End If
        'Identifico si hay consumos sin registrar en cg-uno
        csql = "select * from " & database.obtener_esquema & ".tb0310_documentos_movimientos_inventarios" _
            & " where f0310_id_tipo_documento = 1 And f0310_anulado = 'N' and f0310_id_documento_ref01 = ''" _
            & " and f0310_id_bodega = '" & id_bodega & "'"
        Dim otb_consumos_disp As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_consumos_disp.Rows.Count = 0 Then
            MsgBox("No hay consumos que agrupar", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'Identifico el consecutivo de la nueva entrada de producto terminado o semiterminado.
        Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(6, vg_id_cia)
        Dim cod_documento As String = "DAC-" & consecutivo.ToString.PadLeft(8, "0")
        cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, id_bodega, 6, comunes.g_fechahora,
                                                                            vg_usuario_autoriza, vg_id_cia)
        'Actualizo cada consumo con el documento de referencia.
        For Each orow As DataRow In otb_consumos_disp.Rows
            asignar_documento_referencia(orow("f0310_id_documento"), cod_documento)
        Next
        cargar_doctos_pendientes()
        MsgBox("Realizado")
    End Sub
    Private Sub asignar_documento_referencia(ByVal id_docto_consumo As String, ByVal docto_referencia As String)
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0310_documentos_movimientos_inventarios set "
        csql += "f0310_id_documento_ref01 = @f0310_id_documento_ref01"
        csql += " where f0310_id_documento = @f0310_id_documento"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_solicitud(ocmd)
        Dim fecha_act As Date = comunes.g_fechahora
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0310_id_documento", NpgsqlDbType.Varchar).Value = id_docto_consumo
        ocmd.Parameters.Add("@f0310_id_documento_ref01", NpgsqlDbType.Varchar).Value = docto_referencia
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

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click

    End Sub

    Private Sub dg_doc_pendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_doc_pendientes.CellClick
        If dg_doc_pendientes.Rows.Count = 0 Then
            Exit Sub
        End If
        id_doc_inv = dg_doc_pendientes.CurrentRow.Cells("id_doc_inv").Value
        tx_id_doc_inv.Text = id_doc_inv
    End Sub

    Private Sub dg_doc_pendientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_doc_pendientes.CellDoubleClick
        Dim nombre_columna As String = dg_doc_pendientes.Columns(dg_doc_pendientes.CurrentCell.ColumnIndex).Name

        If dg_doc_pendientes.Rows.Count = 0 Then
            Exit Sub
        End If
        cl_utilidades_gestion_compras.mostrar_documento_movimiento_inventario(id_doc_inv,
                                                                                      vg_usuario_autoriza,
                                                                                      vg_id_cia,
                                                                                      "N", "S", "D")
    End Sub
End Class
