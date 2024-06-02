Public Class fm_0002_unidades_medicion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Private otb_unidades_medicion As DataTable
    Private id_unidad As String = ""

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private verror As String = "S"

    Private csql As String

    Private Sub fm_0002_unidades_medicion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bt_grabar.Enabled = False
        bt_anular.Enabled = False
        llenar_grilla_unid()
    End Sub
    Private Sub llenar_grilla_unid()
        csql = "select * from " & database.obtener_esquema & ".tb0002_unidades_medicion" _
            & " join " & database.obtener_esquema & ".tb0003_tipos_unidades_medicion" _
                & " on f0002_id_tipo_unidad = f0003_id_tipo_unidad" _
            & " where f0002_id_cia = '" & vg_id_cia & "'" _
            & " order by f0002_sigla_unidad_medicion"
        otb_unidades_medicion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        dg_unidades_medicion.Rows.Clear()
        formatear_grdg_unidades_mediciones()
        For Each orow As DataRow In otb_unidades_medicion.Rows
            agregar_fila_dg_unidades(orow)
        Next
    End Sub
    Private Sub formatear_grdg_unidades_mediciones()
        dg_unidades_medicion.AllowUserToAddRows = False
        dg_unidades_medicion.AllowUserToDeleteRows = False
        dg_unidades_medicion.AllowUserToResizeColumns = True
        dg_unidades_medicion.AllowUserToResizeRows = False
        dg_unidades_medicion.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        'dg_lista_turnos.RowHeadersVisible = False
    End Sub
    Private Sub agregar_fila_dg_unidades(ByVal orow As DataRow)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0002_id_unidad_medicion"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0002_sigla_unidad_medicion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0002_sigla_unidad_cguno").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0002_unidad_medicion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0003_tipo_unidad_medicion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)


        'crea columna 1
        obtngrid = New DataGridViewButtonCell
        obtngrid.Value = "Ver"
        orowgrid.Cells.Add(obtngrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_unidades_medicion.Rows.Add(orowgrid)
    End Sub

    Private Sub dg_unidades_medicion_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_unidades_medicion.CellClick
        If dg_unidades_medicion.Rows.Count = 0 Then
            Exit Sub
        End If
        id_unidad = dg_unidades_medicion.CurrentRow.Cells("ocell_dgunid_id").Value.ToString.PadLeft(8, "0")

        If dg_unidades_medicion.Columns(dg_unidades_medicion.CurrentCell.ColumnIndex).Name = "ocell_btver" Then
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_unidad As New camocontrol.fm_0002_edicion_unidades_medicion
            'oform_grilla_programacion.ods_hijo = ods
            oform_unidad.vf_oform_padre = Me
            oform_unidad.vg_usuario_autoriza = vg_usuario_autoriza
            oform_unidad.vg_id_cia = vg_id_cia
            oform_unidad.id_unidad = id_unidad
            oform_unidad.vnuevo = "N"
            oform_unidad.ShowDialog()
            llenar_grilla_unid()
        End If
    End Sub

    Private Sub bt_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nuevo.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_unidad As New camocontrol.fm_0002_edicion_unidades_medicion
        'oform_grilla_programacion.ods_hijo = ods
        oform_unidad.vf_oform_padre = Me
        oform_unidad.vg_usuario_autoriza = vg_usuario_autoriza
        oform_unidad.vg_id_cia = vg_id_cia
        oform_unidad.id_unidad = id_unidad
        oform_unidad.vnuevo = "S"
        oform_unidad.ShowDialog()
        llenar_grilla_unid()
    End Sub
End Class
