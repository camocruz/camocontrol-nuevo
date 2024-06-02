Public Class fm_0600_estadisticas_usuario
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

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
    Private csql_receptor As String
    Private csql_evaluador As String
    Private csql_emisor As String

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private otb_unidad_tiempo As DataTable

    Private otb_info_personal As DataTable
    Private otb_estructura_mantenimiento As DataTable
    Private otb_accion As DataTable
    Private otb_fuentes As DataTable
    Private form_cargado As String = "N"

    Private Sub fm_0600_estadisticas_usuario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0601_fuentes_acciones" _
            & " order by f0601_descriptor_fuente"
        Dim otb_fuentes_temporal As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        otb_fuentes = New DataTable
        'Formateo la tabla creando las columnas
        Dim column1 As DataColumn = New DataColumn("id")
        column1.DataType = System.Type.GetType("System.String")
        Dim column2 As DataColumn = New DataColumn("fuente")
        column2.DataType = System.Type.GetType("System.String")
        otb_fuentes.Columns.Add(column1)
        otb_fuentes.Columns.Add(column2)
        'Agrego el primer row 
        Dim orow As DataRow
        orow = otb_fuentes.NewRow
        orow.Item("id") = "0"
        orow.Item("fuente") = "TODAS LAS FUENTES"
        otb_fuentes.Rows.Add(orow)
        'Agrego los demas rows con todas las fuentes creadas recorriendo la datatable
        For Each orow2 As DataRow In otb_fuentes_temporal.Rows
            orow = otb_fuentes.NewRow
            orow.Item("id") = orow2("f0601_id_fuente")
            orow.Item("fuente") = orow2("f0601_descriptor_fuente")
            otb_fuentes.Rows.Add(orow)
        Next
        With cm_fuente_accion
            'Valor que se muestra al usuario
            .DisplayMember = "fuente"
            'Valor interno que almacena el objeto
            .ValueMember = "id"
            'Origen de Datos del ComboBox
            .DataSource = otb_fuentes
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = 0
        End With


        cl_utilidades_gestion_acciones.actualizar_estado_acciones(0, vg_usuario_autoriza, vg_id_cia) 'Actualizamos el estado de todas las acciones
        cargar_grilla_receptor()
        cargar_grilla_evaluador()
        cargar_grilla_emisor()


        form_cargado = "S"
    End Sub
    Private Sub cargar_grilla_receptor()
        Dim ofuente As String = ""
        If cm_fuente_accion.SelectedValue = "0" Then
            ofuente = "f0600_id_fuente_accion"
        Else
            ofuente = "'" & cm_fuente_accion.SelectedValue & "'"
        End If

        csql_receptor = "SELECT f0605_descriptor_tipo_registro, f0603_descriptor_estado, count(f0600_id_estado_accion) as cantidad" _
            & " FROM " & database.obtener_esquema & ".tb0600_acciones" _
                & " Join " & database.obtener_esquema & ".tb0603_estados_acciones" _
                    & " on f0600_id_estado_accion = f0603_id_estado_accion" _
                & " Join " & database.obtener_esquema & ".tb0605_tipos_registro_acciones" _
                    & " on f0600_id_tipo_registro = f0605_id_tipo_registro" _
                & " where f0600_anulado = 'N' and f0600_id_tipo_registro <> '02' and f0600_responsable = '" & vg_usuario_autoriza & "'" _
                & " and f0600_id_fuente_accion = " & ofuente _
                & " group by f0605_descriptor_tipo_registro, f0603_descriptor_estado, f0600_id_estado_accion" _
                & " order by f0605_descriptor_tipo_registro, f0603_descriptor_estado"
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql_receptor)
        formatear_grid(dg_acciones_receptor)
        For Each orow As DataRow In otb_accion.Rows
            agregar_fila_dg(orow, dg_acciones_receptor)
        Next
        dg_acciones_receptor.Rows.Add("Todos", "Todos", otb_accion.Compute("Sum(cantidad)", "").ToString)
        Label9.Text = "Total: " & otb_accion.Compute("Sum(cantidad)", "").ToString
    End Sub
    Private Sub cargar_grilla_evaluador()
        Dim ofuente As String = ""
        If cm_fuente_accion.SelectedValue = "0" Then
            ofuente = "f0600_id_fuente_accion"
        Else
            ofuente = "'" & cm_fuente_accion.SelectedValue & "'"
        End If

        csql_evaluador = "SELECT f0605_descriptor_tipo_registro, f0603_descriptor_estado, count(f0600_id_estado_accion) as cantidad" _
        & " FROM " & database.obtener_esquema & ".tb0600_acciones" _
        & " Join " & database.obtener_esquema & ".tb0603_estados_acciones" _
            & " on f0600_id_estado_accion = f0603_id_estado_accion" _
        & " Join " & database.obtener_esquema & ".tb0605_tipos_registro_acciones" _
            & " on f0600_id_tipo_registro = f0605_id_tipo_registro" _
        & " where f0600_anulado = 'N' and f0600_id_tipo_registro <> '02' and f0600_evaluador = '" & vg_usuario_autoriza & "'" _
        & " and f0600_id_fuente_accion = " & ofuente _
        & " group by f0605_descriptor_tipo_registro, f0603_descriptor_estado, f0600_id_estado_accion" _
        & " order by f0605_descriptor_tipo_registro, f0603_descriptor_estado"
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql_evaluador)
        formatear_grid(dg_acciones_evaluador)
        For Each orow As DataRow In otb_accion.Rows
            agregar_fila_dg(orow, dg_acciones_evaluador)
        Next
        dg_acciones_evaluador.Rows.Add("Todos", "Todos", otb_accion.Compute("Sum(cantidad)", "").ToString)
        Label8.Text = "Total: " & otb_accion.Compute("Sum(cantidad)", "").ToString
    End Sub
    Private Sub cargar_grilla_emisor()
        Dim ofuente As String = ""
        If cm_fuente_accion.SelectedValue = "0" Then
            ofuente = "f0600_id_fuente_accion"
        Else
            ofuente = "'" & cm_fuente_accion.SelectedValue & "'"
        End If

        csql_emisor = "SELECT f0605_descriptor_tipo_registro, f0603_descriptor_estado, count(f0600_id_estado_accion) as cantidad" _
        & " FROM " & database.obtener_esquema & ".tb0600_acciones" _
        & " Join " & database.obtener_esquema & ".tb0603_estados_acciones" _
            & " on f0600_id_estado_accion = f0603_id_estado_accion" _
        & " Join " & database.obtener_esquema & ".tb0605_tipos_registro_acciones" _
            & " on f0600_id_tipo_registro = f0605_id_tipo_registro" _
        & " where f0600_anulado = 'N' and f0600_id_tipo_registro <> '02' and f0600_emisor = '" & vg_usuario_autoriza & "'" _
        & " and f0600_id_fuente_accion = " & ofuente _
        & " group by f0605_descriptor_tipo_registro, f0603_descriptor_estado, f0600_id_estado_accion" _
        & " order by f0605_descriptor_tipo_registro, f0603_descriptor_estado"
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql_emisor)
        formatear_grid(dg_acciones_emisor)
        For Each orow As DataRow In otb_accion.Rows
            agregar_fila_dg(orow, dg_acciones_emisor)
        Next
        dg_acciones_emisor.Rows.Add("Todos", "Todos", otb_accion.Compute("Sum(cantidad)", "").ToString)
        Label7.Text = "Total: " & otb_accion.Compute("Sum(cantidad)", "").ToString
    End Sub
    Private Sub formatear_grid(ByVal dg As Object)
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToResizeColumns = True
        dg.AllowUserToResizeRows = False
        dg.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg.Rows.Clear()
        'dg_lista_turnos.RowHeadersVisible = False
    End Sub
    Private Sub agregar_fila_dg(ByVal orow As DataRow, ByVal dg As Object)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0605_descriptor_tipo_registro")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0603_descriptor_estado")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("cantidad")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg.Rows.Add(orowgrid)
    End Sub

    Private Sub dg_acciones_receptor_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_acciones_receptor.CellDoubleClick
        If dg_acciones_receptor.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim otipo As String = "'" & dg_acciones_receptor.CurrentRow.Cells.Item(0).Value & "'"
        Dim oestado As String = "'" & dg_acciones_receptor.CurrentRow.Cells.Item(1).Value & "'"
        If otipo = "'Todos'" Then
            otipo = "f0605_descriptor_tipo_registro"
            oestado = "f0603_descriptor_estado"
        End If
        Dim ofuente As String = ""
        If cm_fuente_accion.SelectedValue = "0" Then
            ofuente = "f0600_id_fuente_accion"
        Else
            ofuente = "'" & cm_fuente_accion.SelectedValue & "'"
        End If

        csql = "SELECT f0600_id_accion as id_accion," _
                & " f0605_descriptor_tipo_registro as tipo," _
                & " f0603_descriptor_estado as estado," _
                & " f0600_titulo as titulo," _
                & " f0600_descripcion as descripcion," _
                & " to_char(f0600_fecha_inicio, 'YYYY-MM-DD') as f_inicio," _
                & " to_char(f0600_fecha_inicio, 'HH12:MI AM') as h_inicio," _
                & " tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable," _
                & " tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador," _
                & " f0601_descriptor_fuente as fuente, to_char(f0600_fr, 'YYYY-MM-DD') as f_registro" _
            & " FROM " & database.obtener_esquema & ".tb0600_acciones" _
                & " Join " & database.obtener_esquema & ".tb0603_estados_acciones" _
                    & " on f0600_id_estado_accion = f0603_id_estado_accion" _
                & " Join " & database.obtener_esquema & ".tb0605_tipos_registro_acciones" _
                    & " on f0600_id_tipo_registro = f0605_id_tipo_registro" _
                & " join " & database.obtener_esquema & ".tb0601_fuentes_acciones" _
                    & " on f0600_id_fuente_accion = f0601_id_fuente" _
                & " join " & database.obtener_esquema & ".tb0200_terceros as tb_responsable" _
                        & " on f0600_responsable = tb_responsable.f0200_id_tercero" _
                & " join " & database.obtener_esquema & ".tb0200_terceros as tb_evaluador" _
                        & " on f0600_evaluador = tb_evaluador.f0200_id_tercero" _
                & " where f0600_anulado = 'N' and f0605_descriptor_tipo_registro = " & otipo & " and " _
                & " f0603_descriptor_estado = " & oestado & " and f0600_responsable = '" & vg_usuario_autoriza & "'" _
                & " and f0600_id_fuente_accion = " & ofuente _
                & " order by f0605_descriptor_tipo_registro, f0603_descriptor_estado"
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.titulo_formulario = "Consulta Acciones y Tareas (Receptor)"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.ShowDialog()
        cargar_grilla_receptor()
    End Sub

    Private Sub dg_acciones_evaluador_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_acciones_evaluador.CellDoubleClick
        If dg_acciones_evaluador.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim otipo As String = "'" & dg_acciones_evaluador.CurrentRow.Cells.Item(0).Value & "'"
        Dim oestado As String = "'" & dg_acciones_evaluador.CurrentRow.Cells.Item(1).Value & "'"
        If otipo = "'Todos'" Then
            otipo = "f0605_descriptor_tipo_registro"
            oestado = "f0603_descriptor_estado"
        End If

        Dim ofuente As String = ""
        If cm_fuente_accion.SelectedValue = "0" Then
            ofuente = "f0600_id_fuente_accion"
        Else
            ofuente = "'" & cm_fuente_accion.SelectedValue & "'"
        End If

        csql = "SELECT f0600_id_accion as id_accion," _
                & " f0605_descriptor_tipo_registro as tipo," _
                & " f0603_descriptor_estado as estado," _
                & " f0600_titulo as titulo," _
                & " f0600_descripcion as descripcion," _
                & " to_char(f0600_fecha_inicio, 'YYYY-MM-DD') as f_inicio," _
                & " to_char(f0600_fecha_inicio, 'HH12:MI AM') as h_inicio," _
                & " tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable," _
                & " tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador," _
                & " f0601_descriptor_fuente as fuente, to_char(f0600_fr, 'YYYY-MM-DD') as f_registro" _
            & " FROM " & database.obtener_esquema & ".tb0600_acciones" _
                & " Join " & database.obtener_esquema & ".tb0603_estados_acciones" _
                    & " on f0600_id_estado_accion = f0603_id_estado_accion" _
                & " Join " & database.obtener_esquema & ".tb0605_tipos_registro_acciones" _
                    & " on f0600_id_tipo_registro = f0605_id_tipo_registro" _
                & " join " & database.obtener_esquema & ".tb0601_fuentes_acciones" _
                    & " on f0600_id_fuente_accion = f0601_id_fuente" _
                & " join " & database.obtener_esquema & ".tb0200_terceros as tb_responsable" _
                        & " on f0600_responsable = tb_responsable.f0200_id_tercero" _
                & " join " & database.obtener_esquema & ".tb0200_terceros as tb_evaluador" _
                        & " on f0600_evaluador = tb_evaluador.f0200_id_tercero" _
                & " where f0600_anulado = 'N' and f0605_descriptor_tipo_registro = " & otipo & " and " _
                & " f0603_descriptor_estado = " & oestado & " and f0600_evaluador = '" & vg_usuario_autoriza & "'" _
                & " and f0600_id_fuente_accion = " & ofuente _
                & " order by f0605_descriptor_tipo_registro, f0603_descriptor_estado"
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.titulo_formulario = "Consulta Acciones y Tareas (Evaluador)"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.ShowDialog()
        cargar_grilla_evaluador()
    End Sub

    Private Sub dg_acciones_emisor_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_acciones_emisor.CellDoubleClick
        If dg_acciones_emisor.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim otipo As String = "'" & dg_acciones_emisor.CurrentRow.Cells.Item(0).Value & "'"
        Dim oestado As String = "'" & dg_acciones_emisor.CurrentRow.Cells.Item(1).Value & "'"
        If otipo = "'Todos'" Then
            otipo = "f0605_descriptor_tipo_registro"
            oestado = "f0603_descriptor_estado"
        End If

        Dim ofuente As String = ""
        If cm_fuente_accion.SelectedValue = "0" Then
            ofuente = "f0600_id_fuente_accion"
        Else
            ofuente = "'" & cm_fuente_accion.SelectedValue & "'"
        End If

        csql = "SELECT f0600_id_accion as id_accion," _
                & " f0605_descriptor_tipo_registro as tipo," _
                & " f0603_descriptor_estado as estado," _
                & " f0600_titulo as titulo," _
                & " f0600_descripcion as descripcion," _
                & " to_char(f0600_fecha_inicio, 'YYYY-MM-DD') as f_inicio," _
                & " to_char(f0600_fecha_inicio, 'HH12:MI AM') as h_inicio," _
                & " tb_responsable.f0200_apellido1 || ' ' || tb_responsable.f0200_apellido2 || ' ' || tb_responsable.f0200_nombres as responsable," _
                & " tb_evaluador.f0200_apellido1 || ' ' || tb_evaluador.f0200_apellido2 || ' ' || tb_evaluador.f0200_nombres as evaluador," _
                & " f0601_descriptor_fuente as fuente, to_char(f0600_fr, 'YYYY-MM-DD') as f_registro" _
            & " FROM " & database.obtener_esquema & ".tb0600_acciones" _
                & " Join " & database.obtener_esquema & ".tb0603_estados_acciones" _
                    & " on f0600_id_estado_accion = f0603_id_estado_accion" _
                & " Join " & database.obtener_esquema & ".tb0605_tipos_registro_acciones" _
                    & " on f0600_id_tipo_registro = f0605_id_tipo_registro" _
                & " join " & database.obtener_esquema & ".tb0601_fuentes_acciones" _
                    & " on f0600_id_fuente_accion = f0601_id_fuente" _
                & " join " & database.obtener_esquema & ".tb0200_terceros as tb_responsable" _
                        & " on f0600_responsable = tb_responsable.f0200_id_tercero" _
                & " join " & database.obtener_esquema & ".tb0200_terceros as tb_evaluador" _
                        & " on f0600_evaluador = tb_evaluador.f0200_id_tercero" _
                & " where f0600_anulado = 'N' and f0605_descriptor_tipo_registro = " & otipo & " and " _
                & " f0603_descriptor_estado = " & oestado & " and f0600_emisor = '" & vg_usuario_autoriza & "'" _
                & " and f0600_id_fuente_accion = " & ofuente _
                & " order by f0605_descriptor_tipo_registro, f0603_descriptor_estado"
        otb_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        oform_mostrar_datos.titulo_formulario = "Consulta Acciones y Tareas (Emisor)"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.ShowDialog()
        cargar_grilla_emisor()
    End Sub

    Private Sub tx_actividad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tx_actividad.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub bt_abrir_actividad_Click(sender As System.Object, e As System.EventArgs) Handles bt_abrir_actividad.Click
        Dim id_accion As Integer
        If tx_actividad.Text = "" Then
            MsgBox("Defina un numero de actividad", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        id_accion = tx_actividad.Text
        'ajecutamos clase que abre el formulario adecuado segun el tipo de actividad
        cl_utilidades_gestion_acciones.abrir_actividad(id_accion, vg_usuario_autoriza, vg_id_cia)
    End Sub

    Private Sub cm_fuente_accion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cm_fuente_accion.SelectedValueChanged
        If form_cargado = "S" Then
            'MsgBox("Hola")
            cargar_grilla_receptor()
            cargar_grilla_evaluador()
            cargar_grilla_emisor()
        End If
    End Sub
End Class
