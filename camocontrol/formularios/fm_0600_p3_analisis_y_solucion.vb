Imports System.ComponentModel

Public Class fm_0600_p3_analisis_y_solucion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_accion As Integer
    Public nivel_cumplimiento As String = String.Empty
    '$Public$vf_elemento_nuevo As String = "N"
    Public id_estructura As Integer
    Public path_accion_base As String 'el path del numero de accion raiz o del problema analizado
    Public orow_info_accion As DataRow 'contiene el registro completo de la tabla de la accion principal.
    Public trasladar As String = "N"
    Public mef_seleccionado As Integer
    'Public origen_falla_seleccionado As Integer 'No estoy usando esta variable
    Public subfuentedefallaselecc As Integer

    'Private oform_mover As New camocontrol.fm_0100_trasladar_ramal
    Private oform_mover As camocontrol.fm_0100_trasladar_ramal

    Private tipo_registro As String
    Private id_accion_padre As String 'el id de la accion seleccionada para crearle un hijo
    Private path_padre As String 'el path de la accion, causa, tarea seleccionada para crearle un hijo
    Private fuente_padre As Integer 'la fuente de la accion padre.
    Private usuario_creador As String = ""
    Private usuario_receptor As String = ""
    Private usuario_evaluador As String = ""
    Private actividad_cerrada As String = "N" 'Si una actividad fue cerrada queda bloqueada
    Private fila_seleccionada As Integer
    Private id_estructura_secundaria As Integer 'Se usa para cuando en el plan un arbol tendra otra estructura

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
    Private fila_actual As Integer 'fila actualmente activa en el datagrid
    Private tipo_nota As String = ""

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell

    Private otb_info_personal As DataTable
    Private otb_estructura_mantenimiento As DataTable
    Private otb_acciones_hijos As DataTable
    Private otb_subfuente As DataTable
    Private otb_info_mef As DataTable

    Private Sub fm_0600_p3_analisis_y_solucion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        ' Set the Format type and the CustomFormat string.
        dtp_limite.Format = DateTimePickerFormat.Custom
        dtp_limite.CustomFormat = "yyyy/MM/dd  HH:mm"
        tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
        tx_id_accion.Enabled = False
        tx_id_accion.Text = id_accion
        rb_porque.Checked = True

        tx_cumplimiento.Text = CInt(nivel_cumplimiento).ToString & "%" 'cl_utilidades_gestion_acciones.obtener_nivel_cumplimiento_actual(id_accion, tipo_nota).ToString & "%"

        dg_analisis.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_analisis.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_analisis.AllowUserToAddRows = False
        dg_analisis.AllowUserToDeleteRows = False
        dg_analisis.ReadOnly = True
        path_accion_base = path_accion_base & id_accion & "-"
        cargar_datatable()
        cargar_grilla()
        fuente_padre = orow_info_accion("f0600_id_fuente_accion")
        subfuentedefallaselecc = orow_info_accion("f0600_id_subfuente")
        mef_seleccionado = orow_info_accion("f0600_id_mef")
        cargar_combo_subfuente()
        cargar_combo_mef()
        cm_mef.SelectedValue = mef_seleccionado
        tx_subfuente.Text = subfuentedefallaselecc
        tx_MEF.Text = mef_seleccionado


        'tx_mef.Text = cm_mef.Text

        If orow_info_accion("f0600_fecha_limite").ToString = "" Then
            dtp_limite.Visible = False
        Else
            dtp_limite.Value = orow_info_accion("f0600_fecha_limite")
        End If
        usuario_receptor = orow_info_accion("f0600_responsable")
    End Sub

    Public Sub refrescar_grilla()
        dg_analisis.Rows.Clear()
        cargar_datatable()
        cargar_grilla()
        'Para dejar seleccionado el mismo elemento que se abrio
        dg_analisis.FirstDisplayedScrollingRowIndex = fila_actual
        dg_analisis.CurrentCell = dg_analisis.Rows.Item(fila_actual).Cells(0)
    End Sub


    Private Sub cargar_datatable()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0600-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", path_accion_base)
        otb_acciones_hijos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        'MsgBox(otb_acciones_hijos.Rows.Count) 
        'f_inicio f0600_path,
    End Sub

    Private Function determinar_si_hay_plan_accion()
        Dim hay_plan As String = "N"
        Dim orows() As DataRow
        orows = otb_acciones_hijos.Select("f0600_id_tipo_registro = '03'")
        'MsgBox(orows.Count)
        Return hay_plan
    End Function

    Private Sub cargar_grilla()
        crear_ramal(path_accion_base, "", "S")
    End Sub
    Private Sub crear_ramal(ByVal path_accion As String, ByVal numeral As String, ByVal f_raiz As String)
        Dim dv_datos As New DataView(otb_acciones_hijos)
        Dim dv_filter As String
        dv_filter = "f0600_path = '" & path_accion & "'"
        dv_datos.RowFilter = dv_filter
        dv_datos.Sort = "f0600_id_tipo_registro desc"
        Dim i As Integer = 1
        Dim n_numeral As String = ""
        Dim a As Integer
        For Each orow As DataRowView In dv_datos
            n_numeral = numeral & i & "."
            agregar_fila_Acciones(orow, n_numeral)
            i = i + 1
            If n_numeral.Length = 2 Then
                a = dg_analisis.Rows.Count
                dg_analisis.Rows.Item(a - 1).DefaultCellStyle.BackColor = Color.LightGreen
            End If
            If n_numeral.Length = 4 Then
                a = dg_analisis.Rows.Count
                dg_analisis.Rows.Item(a - 1).DefaultCellStyle.BackColor = Color.LightBlue
            End If
            If orow("f0600_id_tipo_registro").ToString = "01" Then
                a = dg_analisis.Rows.Count
                dg_analisis.Rows.Item(a - 1).DefaultCellStyle.BackColor = Color.OrangeRed
            End If
            If orow("f0600_id_tipo_registro").ToString = "02" Then
                'a = dg_analisis.Rows.Count
                'dg_analisis.Rows.Item(a - 1).DefaultCellStyle.BackColor = Color.LightBlue
            End If
            If orow("f0600_id_tipo_accion").ToString = "06" Then
                a = dg_analisis.Rows.Count
                'dg_analisis.Rows.Item(a - 1).DefaultCellStyle.BackColor = Color.LightSeaGreen
            End If
            crear_ramal(orow("f0600_path").ToString & orow("f0600_id_accion").ToString & "-", n_numeral, "N")
            If f_raiz = "S" Then
                dg_analisis.Rows.Add("")
                a = dg_analisis.Rows.Count
                dg_analisis.Rows.Item(a - 1).Height = 15
                dg_analisis.Rows.Item(a - 1).DefaultCellStyle.BackColor = Color.Thistle
                'dg_analisis.Rows.Item(a - 1).DividerHeight = 20
            End If
        Next
        'MsgBox(dv_datos.Count & " " & dv_filter)
    End Sub
    Private Sub agregar_fila_Acciones(ByVal orow As DataRowView, ByVal numeral As String) 'ojo, este trabaja con un dataview, no con datatable

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0600_id_accion"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        If orow.Item("f0600_id_tipo_registro").ToString = "02" Or orow.Item("f0600_id_tipo_registro").ToString = "07" Then
            otextgrid.Value = ""
        Else
            otextgrid.Value = orow.Item("responsable").ToString
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        If orow.Item("f0600_id_tipo_registro").ToString = "02" Or orow.Item("f0600_id_tipo_registro").ToString = "07" Then
            otextgrid.Value = ""
        Else
            otextgrid.Value = orow.Item("f0603_descriptor_estado").ToString
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        otextgrid = New DataGridViewTextBoxCell
        If orow.Item("f0600_id_tipo_registro").ToString = "02" Or orow.Item("f0600_id_tipo_registro").ToString = "07" Then
            otextgrid.Value = ""
        Else
            otextgrid.Value = CInt(orow.Item("f0600_nivel_cumplimiento"))
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 5
        otextgrid = New DataGridViewTextBoxCell
        If orow.Item("f0600_id_tipo_registro").ToString = "02" Or orow.Item("f0600_id_tipo_registro").ToString = "07" Then
            otextgrid.Value = ""
        Else
            If orow.Item("f0600_id_tipo_registro").ToString = "01" Then
                otextgrid.Value = orow.Item("f_ocurrencia").ToString
            Else
                otextgrid.Value = orow.Item("f_inicio").ToString
            End If
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        If orow.Item("f0600_id_tipo_registro").ToString = "02" Or orow.Item("f0600_id_tipo_registro").ToString = "07" Then
            otextgrid.Value = ""
        Else
            otextgrid.Value = orow.Item("f_fin").ToString
        End If
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        otextgrid = New DataGridViewTextBoxCell
        Select Case orow.Item("f0600_id_tipo_registro").ToString
            Case "01"
                otextgrid.Value = numeral & "   " & "Plan Relacionado: " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
            Case "02"
                otextgrid.Value = numeral & "   " & "Porque: " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
            Case "03"
                'If orow.Item("f0600_id_tipo_accion").ToString = "06" Then
                'otextgrid.Value = numeral & "   " & "Correctivo: " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
                'Else
                'otextgrid.Value = numeral & "   " & "Actividad: " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
                'End If
                otextgrid.Value = numeral & "   " & orow.Item("f0602_descriptor_tipo").ToString & ": " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
            Case "04"
                otextgrid.Value = numeral & "   " & "Actividad Repetitiva: " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
            Case "07"
                otextgrid.Value = numeral & "   " & "Grupo: " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
            Case Else
                otextgrid.Value = numeral & "   " & "Especial: " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
        End Select
        'f0602_descriptor_tipo
        'otextgrid.Value = numeral & "   " & orow.Item("f0602_descriptor_tipo").ToString & ": " & Mid(Trim(orow.Item("f0600_descripcion").ToString), 1, 100)
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 8
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("descripcion_codigo").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_analisis.Rows.Add(orowgrid)
    End Sub
    Private Sub buscar_info_accion(accion As Integer)
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0600_acciones" _
            & " where f0600_id_accion = '" & accion & "'"
        otb_acciones_hijos = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim tipo_nota As String = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia)
        'tx_cumplimiento.Text = cl_utilidades_gestion_acciones.obtener_nivel_cumplimiento_actual(id_accion, tipo_nota).ToString & "%"
        For Each orow As DataRow In otb_acciones_hijos.Rows
            path_padre = orow("f0600_path")
            id_estructura_secundaria = orow("f0600_id_estructura")
        Next
    End Sub
    Private Sub bt_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_nuevo.Click
        If tx_id_seleccionado.Text = "" Then
            'path_padre = "-"
            buscar_info_accion(id_accion)
            id_accion_padre = id_accion
            fila_seleccionada = 1
        Else
            buscar_info_accion(tx_id_seleccionado.Text)
            id_accion_padre = tx_id_seleccionado.Text
            fila_seleccionada = dg_analisis.CurrentRow.Index
        End If
        If rb_porque.Checked = True Then
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_causa As New camocontrol.fm_0600_gestion_causas
            'oform_grilla_programacion.ods_hijo = ods
            oform_causa.vf_oform_padre = Me
            oform_causa.vg_id_cia = vg_id_cia
            oform_causa.id_accion = id_accion
            oform_causa.id_accion_principal = id_accion
            oform_causa.id_estructura = id_estructura_secundaria
            oform_causa.id_accion_padre = id_accion_padre
            oform_causa.path_padre = path_padre
            oform_causa.orow_info_accion = orow_info_accion
            oform_causa.vf_elemento_nuevo = "S"
            oform_causa.vg_usuario_autoriza = vg_usuario_autoriza
            oform_causa.ShowDialog()
        Else
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_programar_actividad As New camocontrol.fm_0600_gestion_tareas
            'oform_grilla_programacion.ods_hijo = ods
            oform_programar_actividad.vf_oform_padre = Me
            oform_programar_actividad.bt_actividades_hijo.Visible = False
            oform_programar_actividad.vg_id_cia = vg_id_cia
            oform_programar_actividad.vg_usuario_autoriza = vg_usuario_autoriza
            oform_programar_actividad.cm_emisor.Enabled = False
            oform_programar_actividad.id_accion_padre = id_accion_padre
            oform_programar_actividad.fuente_padre = fuente_padre
            If orow_info_accion("f0600_id_accion_principal").ToString = "" Then
                oform_programar_actividad.id_accion_principal = id_accion
            Else
                oform_programar_actividad.id_accion_principal = orow_info_accion("f0600_id_accion_principal")
            End If

            oform_programar_actividad.path_padre = path_padre
            oform_programar_actividad.id_estructura = id_estructura_secundaria
            oform_programar_actividad.vf_elemento_nuevo = "S"
            oform_programar_actividad.ShowDialog()
        End If
        dg_analisis.Rows.Clear()
        cargar_datatable()
        cargar_grilla()
        If orow_info_accion("f0600_id_estado_accion") = "01" Or orow_info_accion("f0600_id_estado_accion") = "02" Then '02 = sin contestar , 01 = sin notificar
            Dim dv_tareas As New DataView(otb_acciones_hijos)
            Dim dv_filter As String
            dv_filter = "f0600_id_tipo_registro = '03' or f0600_id_tipo_registro = '04'"
            dv_tareas.RowFilter = dv_filter
            If dv_tareas.Count > 0 Then
                'cambiamos el estado de la accion a implementacion.
                cl_utilidades_gestion_acciones.cambiar_estado_accion(id_accion, "03")
                orow_info_accion("f0600_id_estado_accion") = "03"
                Dim txt_seguimiento As String
                txt_seguimiento = "PLANIFICA ACTIVIDADES: " & vbCrLf _
                & "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Planificó la primera accion en la fecha: " _
                & comunes.g_fechahora.ToString("yyyy/MM/dd  HH:mm")
                cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia)
            End If
        End If
        If dg_analisis.Rows.Count > 0 Then
            'Para dejar seleccionado el mismo elemento que se abrio
            'buscar_accion_en_grilla(tx_id_seleccionado.Text)
            dg_analisis.FirstDisplayedScrollingRowIndex = fila_seleccionada
            dg_analisis.CurrentCell = dg_analisis.Rows.Item(fila_seleccionada).Cells(0)
        End If

    End Sub

#Region "Eventos del gatagridview"

    Private Sub dg_analisis_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_analisis.CellClick
        If dg_analisis.Rows.Count = 0 Then
            Exit Sub
        End If
        tx_id_seleccionado.Text = dg_analisis.CurrentRow.Cells("dgocell_id").Value

        If trasladar = "S" Then
            'oform_mover.id_padre = id_accion
            oform_mover.valor_raiz = "-" & id_accion & "-"
            oform_mover.otabla = "tb0600_acciones"
            oform_mover.campo_id = "f0600_id_accion"
            oform_mover.campo_path = "f0600_path"
            oform_mover.campo_dependencia = "f0600_id_accion_padre"
            oform_mover.campo_agrupacion_principal = "f0600_id_accion_principal"
            If oform_mover.rb_padre.Checked = True Then
                oform_mover.lb_padre.Text = dg_analisis.CurrentRow.Cells("dgocell_id").Value
                oform_mover.id_padre = dg_analisis.CurrentRow.Cells("dgocell_id").Value
            Else
                oform_mover.lb_hijo.Text = dg_analisis.CurrentRow.Cells("dgocell_id").Value
                oform_mover.id_hijo = dg_analisis.CurrentRow.Cells("dgocell_id").Value
                fila_actual = dg_analisis.CurrentRow.Index
            End If
            If oform_mover.chk_raiz.Checked = True Then
                oform_mover.id_padre = id_accion
                oform_mover.valor_raiz = "-" & id_accion & "-"
            End If
        End If

    End Sub

    Private Sub dg_analisis_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_analisis.CellDoubleClick
        If dg_analisis.Rows.Count = 0 Or dg_analisis.CurrentRow.Cells("dgocell_id").Value.ToString = "" Then
            Exit Sub
        End If
        If tx_id_seleccionado.Text = "" Then
            'path_padre = "-"
            buscar_info_accion(id_accion)
            id_accion_padre = id_accion
            fila_seleccionada = 1
        Else
            buscar_info_accion(tx_id_seleccionado.Text)
            id_accion_padre = tx_id_seleccionado.Text
            fila_seleccionada = dg_analisis.CurrentRow.Index
        End If
        'para volver a este mismo row
        fila_seleccionada = dg_analisis.CurrentRow.Index

        Dim nombre_columna As String = dg_analisis.Columns(dg_analisis.CurrentCell.ColumnIndex).Name
        Select Case nombre_columna
            Case "dgocell_id"
                'buscamos el tipo de actividad en la datatable
                Dim orowactividad As DataRow() = otb_acciones_hijos.Select("f0600_id_accion ='" & tx_id_seleccionado.Text & "'")
                For Each Row As DataRow In orowactividad
                    tipo_registro = Row("f0600_id_tipo_registro")
                Next
        End Select
        If tipo_registro = "02" Or tipo_registro = "07" Then '02 = causa  '07 = grupo
            'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
            'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
            Dim oform_causa As New camocontrol.fm_0600_gestion_causas
            'oform_grilla_programacion.ods_hijo = ods
            oform_causa.vf_oform_padre = Me
            oform_causa.vg_id_cia = vg_id_cia
            oform_causa.id_accion = tx_id_seleccionado.Text
            oform_causa.id_estructura = id_estructura
            oform_causa.id_accion_padre = id_accion_padre
            oform_causa.path_padre = path_padre
            oform_causa.orow_info_accion = orow_info_accion
            oform_causa.vf_elemento_nuevo = "N"
            oform_causa.vg_usuario_autoriza = vg_usuario_autoriza
            oform_causa.ShowDialog()
        Else
            cl_utilidades_gestion_acciones.abrir_actividad(tx_id_seleccionado.Text, vg_usuario_autoriza, vg_id_cia)
        End If
        dg_analisis.Rows.Clear()
        cargar_datatable()
        cargar_grilla()
        'MsgBox(fila_seleccionada)
        'Para dejar seleccionado el mismo elemento que se abrio
        buscar_accion_en_grilla(tx_id_seleccionado.Text)
        'dg_analisis.FirstDisplayedScrollingRowIndex = fila_seleccionada
        'dg_analisis.CurrentCell = dg_analisis.Rows.Item(fila_seleccionada).Cells(0)
    End Sub
#End Region

#Region "Busqueda de accion en grilla"
    Private Sub buscar_accion_en_grilla(ByVal id_accion_buscada As String)
        If id_accion_buscada = "" Then
            Exit Sub
        End If
        Try
            For Each row As DataGridViewRow In dg_analisis.Rows
                If row.Cells("dgocell_id").Value = id_accion_buscada Then
                    'MsgBox("hola")
                    'Para dejar seleccionado el mismo elemento que se abrio
                    dg_analisis.FirstDisplayedScrollingRowIndex = row.Index
                    dg_analisis.CurrentCell = dg_analisis.Rows.Item(row.Index).Cells(0)
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("No se puede realizar la búsqueda por: " & ex.Message)
        End Try
    End Sub

    Private Sub tx_buscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_buscar.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            buscar_accion_en_grilla(tx_buscar.Text)
            tx_buscar.Text = ""
        End If
    End Sub
#End Region

#Region "Traslado de Ramal"
    Private Sub bt_trasladar_ramal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_trasladar_ramal.Click
        'Pregunta si realmente desea crear un nuevo elemento
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Trasladar Ramal", "Desea trasladar un ramal de un lugar a otro?")
        If respuesta = "N" Then
            Exit Sub
        End If

        trasladar = "S"
        oform_mover = New camocontrol.fm_0100_trasladar_ramal
        oform_mover.vf_oform_padre = Me
        oform_mover.formulario_origen = Me.Name
        oform_mover.Text = "Trasladar Ramal Analisis"
        oform_mover.Show()

    End Sub
#End Region

    Private Sub bt_seguimientos_Click(sender As Object, e As EventArgs) Handles bt_seguimientos.Click
        cl_gestion_anotaciones.consultar_anotaciones_acciones(id_accion, tipo_nota, vg_usuario_autoriza, vg_id_cia, "ST-0606-01", "1")
    End Sub

    Private Sub bt_fecha_limite_Click(sender As Object, e As EventArgs) Handles bt_fecha_limite.Click
        Dim nueva_fecha_hora As String
        Dim vieja_fecha As Date = dtp_limite.Value
        Dim fecha_limite_maxima As Date
        Dim fecha_emision As Date
        Dim nueva_fecha_limite As Date
        fecha_emision = orow_info_accion("f0600_fecha_emision")
        fecha_limite_maxima = cl_utilidades_gestion_acciones.identificar_fecha_maxima_cierre_x_fuente(orow_info_accion("f0600_id_fuente_accion"), fecha_emision)
        'MsgBox(fecha_limite_maxima)
        'MsgBox(Now())
        verror_requisitos = "N"
        validar_cambio_solo_receptor()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        nueva_fecha_hora = comunes.formulario_fecha_hora(dtp_limite.Value)
        If nueva_fecha_hora = "ND" Then
            Exit Sub
        End If
        If CDate(nueva_fecha_hora) = vieja_fecha Then
            Exit Sub
        End If
        nueva_fecha_limite = CDate(nueva_fecha_hora)
        If nueva_fecha_limite > fecha_limite_maxima And vg_usuario_autoriza <> "00000001" Then
            If vieja_fecha = fecha_limite_maxima Then
                MsgBox("La fecha límite actual no puede ser extendida por configuración del sistema.", MsgBoxStyle.Information, "No autorizado")
                Exit Sub
            End If
            nueva_fecha_limite = fecha_limite_maxima
        End If
        'If CDate(nueva_fecha_hora) > comunes.g_fechahora Then
        'MsgBox("Fecha no valida. Es mayor a la fecha actual", MsgBoxStyle.Critical, "Error")
        'Exit Sub
        'End If
        Dim owhere As String
        owhere = "where f0600_id_accion = '" & id_accion & "'"
        'If vf_elemento_nuevo = "N" Then
        comunes.actualizar_campo_date_tabla("tb0600_acciones", "f0600_fecha_limite", nueva_fecha_limite, owhere)
        dtp_limite.Value = nueva_fecha_limite
        dtp_limite.Visible = True
        'agregar nota registrando el cambio
        If orow_info_accion("f0600_fecha_limite").ToString <> "" Then
            Dim txt_seguimiento As String
            txt_seguimiento = "CAMBIO FECHA LIMITE: " & vbCrLf
            txt_seguimiento += "El Usuario: " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & " Realizo el siguiente cambio:" & vbCrLf
            txt_seguimiento += "Cambio de: (" + vieja_fecha.ToString("yyyy/MM/dd  HH:mm") + ") a: (" + nueva_fecha_limite.ToString("yyyy/MM/dd  HH:mm") + ")"
            cl_gestion_anotaciones.grabar_nuevo_seguimiento(id_accion, txt_seguimiento, tipo_nota, vg_id_cia)
        Else
            If determinar_si_hay_plan_accion() = "S" Then
                cl_utilidades_gestion_acciones.cambiar_estado_accion(id_accion, "03")
            Else
                cl_utilidades_gestion_acciones.cambiar_estado_accion(id_accion, "13")
            End If
        End If
        If CDate(nueva_fecha_hora) > fecha_limite_maxima Then
            MsgBox("El registro se actualizo con la fecha limite maxima permitida.", MsgBoxStyle.Information, "Actualizado")
        Else
            MsgBox("Fecha actualizada", MsgBoxStyle.Information, "Actualizado")
        End If
    End Sub

    Private Sub validar_cambio_solo_receptor()
        Dim p_cambios As String = "N"
        'If vf_elemento_nuevo = "N" Then
        If vg_usuario_autoriza <> usuario_receptor And vg_usuario_autoriza <> "00000001" Then
            p_cambios = "N"
        Else
            p_cambios = "S"
        End If
        If vg_usuario_autoriza = usuario_evaluador Then
            p_cambios = "S"
        End If
        If p_cambios = "N" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Solo el receptor o el evaluador pueden realizar cambios en este campo!"
        End If
        'End If
    End Sub

#Region "GESTION MEF Y subfuente"

    Private Sub cargar_combo_subfuente()
        'Cargo las sub fuentes
        csql = "SELECT f0611_id_sub_fuente as id, f0611_sub_fuente as descripcion" _
        & " FROM " & database.obtener_esquema & ".tb0611_mef_sub_fuentes_acc" _
        & " where f0611_id_fuente = " & fuente_padre
        otb_subfuente = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_subfuente
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion"
            'Valor interno que almacena el objeto
            .ValueMember = "id"
            'Origen de Datos del ComboBox
            .DataSource = otb_subfuente
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = subfuentedefallaselecc
        End With
    End Sub
    Private Sub cargar_combo_mef()
        Dim id_subfuenteselect As Integer = 0
        If cm_subfuente.SelectedIndex <> -1 Then
            id_subfuenteselect = cm_subfuente.SelectedValue
        End If
        csql = "SELECT f0609_id_mef as id, f0609_mef as descripcion" _
            & " FROM camocontrol.tb0609_modos_efectos_falla" _
            & " join camocontrol.tb0612_mef_x_sub_fuente on f0609_id_mef = f0612_id_mef" _
            & " where f0612_id_sub_fuente = '" & id_subfuenteselect & "'" _
            & " union" _
            & " SELECT f0609_id_mef as id, f0609_mef as descripcion" _
            & " FROM camocontrol.tb0609_modos_efectos_falla" _
            & " where f0609_id_mef = '" & mef_seleccionado & "'" _
            & " order by descripcion"
        otb_info_mef = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_mef
            'Valor que se muestra al usuario
            .DisplayMember = "descripcion"
            'Valor interno que almacena el objeto
            .ValueMember = "id"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_mef
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
            '.SelectedValue = mef_seleccionado
        End With
    End Sub

#Region "Crear nuevo MEF o Origen"
    Private Sub bt_mef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_mef.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mef As New camocontrol.fm_0600_p3_mef
        'oform_grilla_programacion.ods_hijo = ods
        oform_mef.vf_oform_padre = Me
        oform_mef.vg_id_cia = vg_id_cia
        oform_mef.id_accion = id_accion
        oform_mef.id_estructura = id_estructura
        oform_mef.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mef.vf_elemento_nuevo = "S"
        oform_mef.ShowDialog()
        cargar_combo_subfuente()
        'cm_mef.SelectedValue = mef_seleccionado
        'tx_mef.Text = cm_mef.Text
    End Sub
#End Region

#Region "Eventos Controles Gestion del MEF"
    Private Sub tx_MEF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_MEF.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If tx_MEF.Text = "" Then
                tx_MEF.Text = "1"
            End If
            cm_mef.SelectedValue = tx_MEF.Text
            gestionar_cambio_mef_y_origen(cm_mef, tx_MEF, mef_seleccionado)
        End If
    End Sub
    Private Sub cm_mef_Validating(sender As Object, e As CancelEventArgs) Handles cm_mef.Validating
        gestionar_cambio_mef_y_origen(cm_mef, tx_MEF, mef_seleccionado)
    End Sub



#End Region

#Region "Eventos Controles Gestion Origen De Falla"

    Private Sub cm_subfuente_Validating(sender As Object, e As CancelEventArgs) Handles cm_subfuente.Validating
        tx_subfuente.Text = ""
        If cm_subfuente.SelectedIndex <> -1 Then
            cargar_combo_mef()
            tx_subfuente.Text = cm_subfuente.SelectedValue
            If tx_MEF.Text <> "" Then
                cm_mef.SelectedValue = tx_MEF.Text
            End If
        Else
            subfuentedefallaselecc = 0
        End If
        gestionar_cambio_mef_y_origen(cm_subfuente, tx_subfuente, subfuentedefallaselecc)
    End Sub
    Private Sub tx_subfuente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_subfuente.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If tx_subfuente.Text = "" Then
                subfuentedefallaselecc = 0
                cm_subfuente.SelectedItem = -1
            Else
                cm_subfuente.SelectedValue = tx_subfuente.Text
            End If
            gestionar_cambio_mef_y_origen(cm_subfuente, tx_subfuente, subfuentedefallaselecc)
        End If
    End Sub

#End Region

#Region "Validacion y grabado en BD"
    Private Sub gestionar_cambio_mef_y_origen(combo As ComboBox, textb As TextBox, valor_seleccionado As Integer)
        'No hay cambio
        If combo.SelectedValue = valor_seleccionado Then
            Exit Sub
        End If
        'Ya existe un valor valido pero selecciono un valor no valido
        If combo.SelectedIndex = -1 And textb.Text <> "" Then
            MsgBox("Valor no pertenece al listado", MsgBoxStyle.Information, "Error")
            combo.SelectedValue = valor_seleccionado
            textb.Text = valor_seleccionado
            Exit Sub
        End If
        'valor definido no corresponde a ningun valor de la lista
        If combo.SelectedIndex = -1 Then
            MsgBox("Valor no pertenece al listado", MsgBoxStyle.Information, "Error")
            combo.SelectedValue = valor_seleccionado
            textb.Text = ""
            Exit Sub
        Else
            textb.Text = combo.SelectedValue
        End If

        'Pregunta si desea actualizar el valor
        'Dim respuesta As String = "N"
        'respuesta = comunes.g_mensaje_YesNo("Actualizar MEF", "Desea actulauzar el MEF?")
        'If respuesta = "N" Then
        '    textb.Text = valor_seleccionado
        '    combo.SelectedValue = valor_seleccionado
        '    Exit Sub
        'End If

        If combo IsNot cm_mef Then
            subfuentedefallaselecc = combo.SelectedValue
        Else
            mef_seleccionado = combo.SelectedValue
        End If
        textb.Text = combo.SelectedValue
        'ejecuto el grabado
        actualizar_mef_y_origen()
    End Sub
    Private Sub actualizar_mef_y_origen()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set " _
                    & " f0600_id_mef = '" & mef_seleccionado & "'," _
                    & " f0600_id_subfuente = '" & subfuentedefallaselecc & "'" _
                    & " where f0600_id_accion = '" & id_accion & "'"
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
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
        ocmd = Nothing
        oconn_form.Close()
    End Sub

#End Region

#End Region

End Class
