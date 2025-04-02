Public Class fm_0800_cargar_faltantes_cotizaciones
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public f_inicio As String
    Public f_fin As String

    Private otb_cv_encabezado As DataTable
    Private otb_cv_detalle As DataTable
    Private otb_motivos As DataTable
    Private otb_terceros As DataTable
    Private otb_items As DataTable
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private Sub fm_0800_cargar_faltantes_cotizaciones_Load(sender As Object, e As EventArgs) Handles Me.Load
        dg_cv_encabezado.AllowUserToAddRows = False
        dg_cv_encabezado.AllowUserToDeleteRows = False
        dg_cv_encabezado.AllowUserToResizeColumns = True
        dg_cv_encabezado.AllowUserToResizeRows = False
        dg_cv_encabezado.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige

        dg_cv_detalle.AllowUserToAddRows = False
        dg_cv_detalle.AllowUserToDeleteRows = False
        dg_cv_detalle.AllowUserToResizeColumns = True
        dg_cv_detalle.AllowUserToResizeRows = False
        dg_cv_detalle.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige

        cargar_otb_cv_datos()
    End Sub

    Private Sub cargar_otb_cv_datos()
        dg_cv_encabezado.DataSource = ""
        dg_cv_detalle.DataSource = ""

        'csql = comunes.suministrar_valor_variable_configuracion("ST-0800-03", vg_id_cia)
        'csql = Replace(csql, "$df001$", database.obtener_esquema)
        'csql = Replace(csql, "$001$", vg_id_cia)
        'Dim f_ini As Date = dtp_fecha_inicio_prog.Value
        'Dim f_fin As Date = dtp_fecha_fin_prog.Value
        'MsgBox(f_inicio.ToString("yyyy/MM/dd"))


        csql = "SELECT f0840_cv as cv, f0840_razon_social as cliente, to_char(f0840_fecha,'yyyy-MM-dd') as fecha"
        csql += " FROM camocontrol.tb0840_cotizaciones_cguno_encabezado"
        csql += " WHERE f0840_fecha BETWEEN '" & f_inicio & "' and '" & f_fin & "'"
        csql += " ORDER BY f0840_cv ASC "
        'MsgBox(csql)
        otb_cv_encabezado = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_cv_encabezado.DataSource = otb_cv_encabezado
        dg_cv_encabezado.AutoResizeColumns()
        dg_cv_encabezado.ReadOnly = True



        'Dim ocolum As New DataGridViewCheckBoxColumn
        'ocolum.HeaderText = "Despachar"
        'ocolum.Name = "dgocell_crear_despacho"
        'dg_remision_encabezado.Columns.Add(ocolum)


        csql = "SELECT f0841_id_det_cv as id, f0841_cv as cv, f0841_referencia as ref, f0841_descripcion as descripcion,"
        csql += " f0841_bodega as bodega, f0841_unidad as unidad, f0841_pedido::int as pedido,"
        csql += " f0841_despachado:: int as despachado,"
        csql += " f0841_faltante:: int as faltante, to_char(f0841_valor_cv,'LFM9,999,999.00') as valor,"
        csql += " f0841_id_motivo as id_motivo,"
        csql += " coalesce(f0842_motivo , 'ND') as motivo"
        csql += " FROM camocontrol.tb0841_cotizaciones_cguno_detalle"
        csql += " join camocontrol.tb0840_cotizaciones_cguno_encabezado"
        csql += " on f0840_cv = f0841_cv"
        csql += " left join camocontrol.tb0842_motivos_faltantes"
        csql += " on f0842_id_motivo = f0841_id_motivo"
        csql += " WHERE f0840_fecha BETWEEN '" & f_inicio & "' and '" & f_fin & "'"
        csql += " order by f0841_cv, f0841_descripcion;"
        otb_cv_detalle = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = "SELECT f0842_id_motivo, f0842_motivo"
        csql += " From camocontrol.tb0842_motivos_faltantes;"
        otb_motivos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub filtrar_otb_cv_detalle(ByVal cv As String)
        Dim productos As New DataView(otb_cv_detalle)
        productos.RowFilter = "cv = '" & cv & "'"
        dg_cv_detalle.DataSource = productos

    End Sub

    Private Sub dg_cv_encabezado_Click(sender As Object, e As EventArgs) Handles dg_cv_encabezado.Click
        If dg_cv_encabezado.Rows.Count = 0 Then
            Exit Sub
        End If
        filtrar_otb_cv_detalle(dg_cv_encabezado.CurrentRow.Cells("cv").Value)
    End Sub

    Private Sub dg_cv_encabezado_Scroll(sender As Object, e As ScrollEventArgs) Handles dg_cv_encabezado.Scroll
        dg_cv_detalle.DataSource = ""
    End Sub

    Private Sub dg_cv_detalle_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dg_cv_detalle.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)

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

    Private Sub dg_cv_detalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cv_detalle.CellEndEdit
        Actualizar_cotizacion()
    End Sub
    Private Sub Actualizar_cotizacion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0841_cotizaciones_cguno_detalle set "
        csql += "f0841_id_motivo = @f0841_id_motivo"
        csql += " where f0841_id_det_cv = @f0841_id_det_cv"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        Crear_parametros_item(ocmd)
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
        MostrarDescipcionMotivo()
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub Crear_parametros_item(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0841_id_det_cv", NpgsqlDbType.Integer).Value = dg_cv_detalle.CurrentRow.Cells("id").Value
        ocmd.Parameters.Add("@f0841_id_motivo", NpgsqlDbType.Integer).Value = dg_cv_detalle.CurrentRow.Cells("id_motivo").Value
    End Sub
    Private Sub MostrarDescipcionMotivo()
        If verror = "N" Then
            Dim mtvo As String
            Dim orow() As DataRow
            orow = otb_motivos.Select("f0842_id_motivo = '" & dg_cv_detalle.CurrentRow.Cells("id_motivo").Value & "'")
            If orow.Length > 0 Then
                mtvo = orow(0)(1)
                dg_cv_detalle.CurrentRow.Cells("motivo").Value = mtvo
            Else
                MsgBox("Motivo no existe", MsgBoxStyle.Critical)
                dg_cv_detalle.CurrentRow.Cells("motivo").Value = "ND"
            End If

        End If

    End Sub

    Private Sub dg_cv_encabezado_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cv_encabezado.CellEnter
        If dg_cv_encabezado.Rows.Count = 0 Then
            Exit Sub
        End If
        filtrar_otb_cv_detalle(dg_cv_encabezado.CurrentRow.Cells("cv").Value)

    End Sub

    Private Sub dg_cv_detalle_DataSourceChanged(sender As Object, e As EventArgs) Handles dg_cv_detalle.DataSourceChanged
        'MsgBox(dg_cv_detalle.DataSource)
        If dg_cv_detalle.ColumnCount > 2 Then

            dg_cv_detalle.Columns("id").ReadOnly = True
            dg_cv_detalle.Columns("cv").ReadOnly = True 'dg_remision_encabezado.Columns("id").ReadOnly = True
            dg_cv_detalle.Columns("ref").ReadOnly = True 'dg_remision_encabezado.Columns("remision").ReadOnly = True
            dg_cv_detalle.Columns("descripcion").ReadOnly = True
            dg_cv_detalle.Columns("bodega").ReadOnly = True
            dg_cv_detalle.Columns("unidad").ReadOnly = True
            dg_cv_detalle.Columns("pedido").ReadOnly = True
            dg_cv_detalle.Columns("despachado").ReadOnly = True
            dg_cv_detalle.Columns("faltante").ReadOnly = True
            dg_cv_detalle.Columns("valor").ReadOnly = True
            dg_cv_detalle.Columns("motivo").ReadOnly = True
        End If
    End Sub
End Class
