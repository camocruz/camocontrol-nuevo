Imports System.ComponentModel

Public Class fm_0600_gestion_seguimiento
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public trasladar As String = "N"
    '$Public$vf_elemento_nuevo As String = "N"

    Public id_accion As Integer
    Public id_seguimiento_accion As Integer
    Public id_seguimiento_accion_padre As Integer
    Public vrespuesta As String = "N" 'Indica si el registro que se esta gestionando es una respuesta
    Public vrespondido As String = "N" 'Indica si se genero un registro de respuesta al actual
    Public id_registro_respuesta As Integer 'Cuando se crea una respuestas aqui se almacena el id creado
    Public id_seg_personal As Integer 'Indica el id del registro del funcionario que se selecciona en dg_personal
    Public tipo_nota As String = "" 'Para clasificar las notas segun el tipo documento al que se anexen
    Public ocomportamiento As String = "" 'Para habilitar, ocultar controles segun necesidades
    Public otipo_seguimiento As Integer = 1 'valores  que puede tomar del cm_tipo_seguimiento y se usa para determinar el comportamiento del formulario

    Private new_name_file As String = ""

    Private usuario_creador As String = ""
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet

    Private orowgrid As DataGridViewRow
    Private ocmb_grid As DataGridViewComboBoxCell
    Private otextgrid As DataGridViewTextBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell
    Private obuttongrid As DataGridViewButtonCell
    Private olinkcell As DataGridViewLinkCell

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vexiste As String = "N"
    Private vmensaje_requisitos As String

    Private id_accion_principal As Integer
    Private id_accion_padre As Integer
    Private id_tipo_registro As Integer
    Private id_estado_actual As String


    'informaciones para programar nuevas tareas repetitivas
    Private tarea_repetitiva As String = "N"
    Private repeticion_programada As String = "N"
    Private periodo_nueva_repeticion As Integer = 0
    Private repeticiones_programadas As Integer
    Private repeticiones_ejecutadas As Integer = 0
    Private estado_accion_padre As String = String.Empty
    Private duracion As TimeSpan
    Private nueva_fecha_inicio As Date
    Private nueva_fecha_limite As Date

    Private evaluador_accion As String = ""
    Private id_tercero As String = ""
    Private intervalo As TimeSpan
    Private tiempo_restar As Integer = 0
    Private tiempo_extra As Integer = 0
    Private extra_dom As String = "N"
    Private accion_cumplida As String = "N"
    'f0607_r_lectura, f0607_fecha_lectura, f0607_r_respuesta, f0607_id_respuesta
    Private r_lectura As String = "N"
    Private fecha_lectura As Date
    Private r_respuesta As String = "N"
    Private cumplimiento_actual As Integer = 0
    Private evaluador_lider As String = "N"

    Private otb_info_accion As DataTable
    Private otb_info_accion_padre As DataTable
    Private otb_info_personal As DataTable
    Private otb_info_seguimiento As DataTable
    Private otb_info_personal_seg As DataTable
    Private otb_unidad_tiempo As DataTable
    Private otb_personal_grillas As DataTable
    Private otb_tipos_seguimiento As DataTable


    Private Sub fm_0600_gestion_seguimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        evaluador_lider = cl_gestion_permisos.identificar_permisos_especiales_formularios("EVAL_LIDER", vf_otabla_permisos, vg_usuario_autoriza)
        formatear_segun_contexto()

        bt_anular.Enabled = False
        bt_nuevo.Enabled = False
        bt_generar_informe.Enabled = True
        bt_g_notas.Enabled = False
        bt_g_archivos.Enabled = False
        bt_nuevo_soporte.Enabled = False
        bt_ver_archivos_asociados.Enabled = False
        cm_responsable.Enabled = False
        tx_id_seguimiento.Enabled = False
        cargar_combo_responsable()
        otb_personal_grillas = otb_info_personal.Copy
        traer_info_accion()
        'cumplimiento_actual = cl_utilidades_gestion_acciones.obtener_nivel_cumplimiento_actual(id_accion, tipo_nota)
        tx_cumplimiento.Text = cumplimiento_actual


        Dim hora_actual As DateTime = comunes.g_fechahora
        ' Set the Format type and the CustomFormat string.
        dtp_fecha_inicio.Value = hora_actual
        dtp_fecha_inicio.Format = DateTimePickerFormat.Custom
        dtp_fecha_inicio.CustomFormat = "yyyy/MM/dd  HH:mm"

        ' Set the Format type and the CustomFormat string.
        dtp_fecha_fin.Value = hora_actual
        dtp_fecha_fin.Format = DateTimePickerFormat.Custom
        dtp_fecha_fin.CustomFormat = "yyyy/MM/dd  HH:mm"

        calcular_tiempo()

        formatear_datagrid()

        csql = "select * from " & database.obtener_esquema & ".tb0608_tipos_seguimiento"
        otb_tipos_seguimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_tipo_seguimiento
            'Valor que se muestra al usuario
            .DisplayMember = "f0608_tipo_seguimiento"
            'Valor interno que almacena el objeto
            .ValueMember = "f0608_id_tipo_seguimiento"
            'Origen de Datos del ComboBox
            .DataSource = otb_tipos_seguimiento
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = otipo_seguimiento
        End With

        'activar_columnas_dg_personal()

        With dgocell_id_tercero
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_personal_grillas
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        End With

        If vf_elemento_nuevo = "N" Then
            cargar_seguimiento_existente(id_seguimiento_accion)
            'No debe poder forzar el cierre. solo desde un seguimiento nuevo.
            bt_forzar_cierre.Enabled = False
            activar_columnas_dg_personal()
        Else
            bt_editar.Enabled = False
            tx_cumplimiento.Enabled = True
            tx_anotacion.ReadOnly = False
            'dg_personal.Enabled = True
            dg_personal.ReadOnly = False
            'Para activar el cierre forzado de una accion
            If evaluador_accion = vg_usuario_autoriza Or vg_usuario_autoriza = "00000001" Then
                bt_forzar_cierre.Enabled = True
            Else
                bt_forzar_cierre.Enabled = False
                cl_gestion_permisos.activar_control_si_tiene_permiso(vf_otabla_permisos, Me.Name, bt_forzar_cierre, "")
            End If
            activar_columnas_dg_personal()
        End If
    End Sub

    Private Sub cargar_seguimiento_existente(oid_seguimiento As Integer)
        bt_grabar.Enabled = False
        cm_tipo_seguimiento.Enabled = False
        tx_cumplimiento.Enabled = False
        tx_anotacion.ReadOnly = True
        'dg_personal.Enabled = False
        dg_personal.ReadOnly = True
        csql = "select * from " & database.obtener_esquema & ".tb0606_seguimientos_acciones" _
            & " where f0606_id_seguimiento_accion = '" & oid_seguimiento & "'"
        otb_info_seguimiento = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_seguimiento.Rows
            tx_id_seguimiento.Text = orow("f0606_id_seguimiento_accion").ToString
            id_accion = orow("f0606_id_documento")
            tipo_nota = orow("f0606_tipo_nota")
            otipo_seguimiento = orow("f0606_id_tipo_seguimiento")
            linklabel_id_accion.Text = orow("f0606_id_documento").ToString
            dtp_fecha_inicio.Value = orow("f0606_fecha_inicio")
            dtp_fecha_fin.Value = orow("f0606_fecha_fin")
            tx_cumplimiento.Text = CInt(orow("f0606_nivel_cumplimiento"))
            tx_anotacion.Text = orow("f0606_seguimiento_accion")
            cm_responsable.SelectedValue = orow("f0606_usuario_crear")
            cm_tipo_seguimiento.SelectedValue = orow("f0606_id_tipo_seguimiento")
            usuario_creador = orow("f0606_usuario_crear")
        Next
        activar_columnas_dg_personal() 'dar formato al dg
        calcular_tiempo()
        cargar_funcionarios()

        formatear_segun_contexto()

        'PARA CONTROLAR LA INFORMACION DE LOS DOCUMENTOS ASOCIADOS
        new_name_file = comunes.suministrar_valor_variable_configuracion("CD-NTA-001", vg_id_cia)
        new_name_file += "-" & tx_id_seguimiento.Text.PadLeft(8, "0")
        calcular_archivos_asociados()
        bt_nuevo_soporte.Enabled = True
        bt_ver_archivos_asociados.Enabled = True
    End Sub

    Private Sub formatear_segun_contexto()

        Select Case ocomportamiento
            Case "1"
                'Todo queda habilitado
            Case "2"
                Label5.Visible = False
                linklabel_id_accion.Visible = False
                tx_cumplimiento.Visible = False
                cm_tipo_seguimiento.Enabled = False
        End Select
    End Sub
    Private Sub formatear_datagrid()
        dg_personal.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_personal.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_personal.AllowUserToAddRows = True
        dg_personal.AllowUserToDeleteRows = True
        dg_personal.Columns("dgochk_r_lectura").ReadOnly = True

    End Sub
    Private Sub cargar_funcionarios()
        Dim seleyo As String = "N"
        dg_personal.Rows.Clear()
        csql = "select * from " & database.obtener_esquema & ".tb0607_seg_acc_personal" _
                        & " where f0607_id_seguimiento_accion = '" & id_seguimiento_accion & "'" _
                        & " and f0607_anulado = 'N'" _
                        & " order by f0607_id_seg_personal"
        otb_info_personal_seg = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_personal_seg.Rows
            agregar_fila_personal(orow)
            'orow.Item("f0607_id_respuesta").ToString()
            If orow("f0607_id_tercero") = vg_usuario_autoriza Then
                'Graba fecha de lectura
                If (orow("f0607_r_lectura") = "S" Or orow("f0607_r_respuesta") = "S") And IsDBNull(orow("f0607_fecha_lectura")) = True Then
                    grabar_fecha_lectura_seguimiento()
                    seleyo = "S"
                End If
            End If
        Next
        If seleyo = "S" Then
            cargar_funcionarios()
        End If
    End Sub
    Private Sub grabar_fecha_lectura_seguimiento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        csql = "update " + database.obtener_esquema + ".tb0607_seg_acc_personal set "
        csql += "f0607_fecha_lectura = @f0607_fecha_lectura,"
        csql += "f0607_leido = 'S'"
        csql += " where f0607_id_seguimiento_accion = '" & tx_id_seguimiento.Text & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0607_fecha_lectura", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar fecha lectura! " + vbCrLf + ex.ToString)
        End Try
        If verror = "N" Then
            MsgBox("Fecha de lectura de nota reportada!", MsgBoxStyle.Information, "Informacion")
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub grabar_id_seguimiento_de_respuesta()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        csql = "update " + database.obtener_esquema + ".tb0607_seg_acc_personal set "
        csql += "f0607_id_respuesta = @f0607_id_respuesta,"
        csql += "f0607_respondido = 'S'"
        csql += " where f0607_id_seg_personal = '" & id_seg_personal & "'"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0607_id_respuesta", NpgsqlDbType.Integer).Value = id_seguimiento_accion
        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar seguimiento respuesta! " + vbCrLf + ex.ToString)
        End Try
        If verror = "N" Then
            'MsgBox("Respuesta reportada!", MsgBoxStyle.Information, "Informacion")
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub cargar_combo_responsable()
        csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
            & " from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "'" _
            & " order by nombre"
        otb_info_personal = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_responsable
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_info_personal
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedValue = vg_usuario_autoriza
        End With
    End Sub
    Private Sub dtp_fecha_inicio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtp_fecha_inicio.Validating
        calcular_tiempo()
    End Sub
    Private Sub dtp_fecha_fin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtp_fecha_fin.Validating
        calcular_tiempo()
    End Sub
    Private Sub tx_duracion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_duracion.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
    Private Sub tx_duracion_Validating(sender As Object, e As CancelEventArgs) Handles tx_duracion.Validating
        dtp_fecha_fin.Value = DateAdd(DateInterval.Minute, CInt(tx_duracion.Text), dtp_fecha_inicio.Value)
        calcular_tiempo()
    End Sub
    Private Sub calcular_tiempo()
        intervalo = dtp_fecha_fin.Value - dtp_fecha_inicio.Value
        Dim minut As Long = DateDiff(DateInterval.Minute, dtp_fecha_inicio.Value, dtp_fecha_fin.Value)
        tx_duracion.Text = minut.ToString.PadLeft(2, "0")
        lb_duracion.Text = intervalo.Days.ToString.PadLeft(2, "0") & " dias " & intervalo.Hours.ToString.PadLeft(2, "0") & " horas " _
        & intervalo.Minutes.ToString.PadLeft(2, "0") & " minutos"
        'tx_intervalo_horas.Text = Decimal.Round(intervalo.TotalHours, 2, MidpointRounding.AwayFromZero)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub traer_info_accion()
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones" _
            & " where f0600_id_accion = '" & id_accion & "'"
        otb_info_accion = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_accion.Rows
            repeticion_programada = orow("f0600_repeticion_programada")
            evaluador_accion = orow("f0600_evaluador").ToString
            tarea_repetitiva = orow("f0600_repetitiva")
            cumplimiento_actual = CInt(orow("f0600_nivel_cumplimiento"))
            If IsDBNull(orow("f0600_id_accion_padre")) Then
                id_accion_padre = 0
            Else
                id_accion_padre = orow("f0600_id_accion_padre")
            End If
            If IsDBNull(orow("f0600_id_accion_principal")) Then
                id_accion_principal = 0
            Else
                id_accion_principal = orow("f0600_id_accion_principal")
            End If
            'Try
            '    id_accion_padre = orow("f0600_id_accion_padre")
            'Catch ex As Exception
            '    id_accion_padre = 0
            'End Try
            'Try
            '    id_accion_principal = orow("f0600_id_accion_principal")
            'Catch ex As Exception
            '    id_accion_principal = 0
            'End Try
        Next
        csql = "select * from " & database.obtener_esquema & ".tb0600_acciones" _
                & " where f0600_id_accion = '" & id_accion_padre & "'"
        otb_info_accion_padre = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_accion_padre.Rows
            repeticiones_programadas = orow("f0600_repeticiones_programadas")
            repeticiones_ejecutadas = orow("f0600_repeticiones_ejecutadas")
            estado_accion_padre = orow("f0600_id_estado_accion")
        Next
    End Sub

    Private Sub dg_personal_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_personal.CellClick
        Dim nombre_columna As String = dg_personal.Columns(dg_personal.CurrentCell.ColumnIndex).Name
        If dg_personal.Rows.Count = 0 Or dg_personal.CurrentRow.IsNewRow = True Or vf_elemento_nuevo = "S" Then
            Exit Sub
        End If
        If nombre_columna = "dgocell_id_respuesta" Then
            'Si lo que vamos a gestionar es la respuesta
            If dg_personal.CurrentCell.Value.ToString = "Responder" And vg_usuario_autoriza = dg_personal.CurrentRow.Cells("dgocell_id_tercero").Value Then
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_seguimientos As New camocontrol.fm_0600_gestion_seguimiento
                oform_seguimientos.Text = "Respuesta a Seguimiento"
                oform_seguimientos.vf_oform_padre = Me
                oform_seguimientos.vg_id_cia = vg_id_cia
                oform_seguimientos.tipo_nota = tipo_nota
                oform_seguimientos.id_accion = id_accion
                oform_seguimientos.id_seguimiento_accion_padre = id_seguimiento_accion
                oform_seguimientos.vrespuesta = "S"
                oform_seguimientos.id_seg_personal = dg_personal.CurrentRow.Cells("dgocell_id_seg_personal").Value
                oform_seguimientos.vg_usuario_autoriza = vg_usuario_autoriza
                oform_seguimientos.vf_elemento_nuevo = "S"
                oform_seguimientos.ShowDialog()
                cargar_funcionarios()
                Exit Sub
            End If
            If dg_personal.CurrentCell.Value.ToString <> "Responder" And dg_personal.CurrentCell.Value.ToString <> "" Then
                'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
                'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
                Dim oform_seguimientos As New camocontrol.fm_0600_gestion_seguimiento
                'oform_grilla_programacion.ods_hijo = ods
                oform_seguimientos.vf_oform_padre = Me
                oform_seguimientos.vg_id_cia = vg_id_cia
                oform_seguimientos.id_accion = id_accion
                oform_seguimientos.tipo_nota = tipo_nota
                oform_seguimientos.id_seguimiento_accion = dg_personal.CurrentCell.Value
                oform_seguimientos.vf_elemento_nuevo = "N"
                oform_seguimientos.vg_usuario_autoriza = vg_usuario_autoriza
                oform_seguimientos.ShowDialog()
            End If

        End If
    End Sub

    Private Sub dg_personal_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg_personal.RowsAdded
        Try
            'dg_personal.CurrentRow.Cells("dgochk_r_lectura").Value = 1
        Catch ex As Exception

        End Try
    End Sub
    Private Sub agregar_fila_personal(ByVal orow As DataRow)
        'Crea objeto fila del Datagridview
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0607_id_seg_personal").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 1
        ocmb_grid = New DataGridViewComboBoxCell
        ocmb_grid.Value = orow.Item("f0607_id_tercero").ToString
        With ocmb_grid
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_personal_grillas
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        End With
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ocmb_grid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0607_tiempo_restar").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0607_tiempo_extra").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item("f0607_extra_dominical").ToString = "N" Then
            ochkgrid.Value = 0
        Else
            ochkgrid.Value = -1
        End If
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna 5
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item("f0607_r_lectura").ToString = "N" Then
            ochkgrid.Value = 0
        Else
            ochkgrid.Value = -1
        End If
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna 6
        otextgrid = New DataGridViewTextBoxCell
        If orow.Item("f0607_fecha_lectura").ToString = "" Then
            otextgrid.Value = ""
        Else
            otextgrid.Value = CDate(orow.Item("f0607_fecha_lectura")).ToString("yyyy/MM/dd HH:mm")
        End If
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 7
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item("f0607_r_respuesta").ToString = "N" Then
            ochkgrid.Value = 0
        Else
            ochkgrid.Value = -1
        End If
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna 8
        olinkcell = New DataGridViewLinkCell
        If orow.Item("f0607_id_respuesta").ToString = "" And orow.Item("f0607_r_respuesta").ToString = "S" Then
            olinkcell.Value = "Responder"
        Else
            olinkcell.Value = orow.Item("f0607_id_respuesta").ToString
        End If
        orowgrid.Cells.Add(olinkcell)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_personal.Rows.Add(orowgrid)
    End Sub
    Private Function grabar_nuevo_seguimiento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0606_seguimientos_acciones" _
                & " (f0606_id_documento, f0606_id_cia, f0606_seguimiento_accion, f0606_nivel_cumplimiento," _
                & " f0606_fecha_inicio, f0606_fecha_fin, f0606_id_tipo_seguimiento, f0606_tipo_nota," _
                & " f0606_usuario_crear, f0606_usuario_modificar, f0606_fm)" _
                & " VALUES" _
                & " (@f0606_id_documento, @f0606_id_cia, @f0606_seguimiento_accion, @f0606_nivel_cumplimiento," _
                & " @f0606_fecha_inicio, @f0606_fecha_fin, @f0606_id_tipo_seguimiento, @f0606_tipo_nota," _
                & " @f0606_usuario_crear, @f0606_usuario_modificar, @f0606_fm)" _
                & " RETURNING f0606_id_seguimiento_accion;"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_seguimiento(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! " + ex.ToString)
        End Try
        Dim id_nuevo As Integer = 0
        If verror = "N" Then
            Try
                id_nuevo = ocmd.ExecuteScalar()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        If verror = "N" Then
            'Actualizamos el nivel de cumplimiento en el registro de la accion.
            If tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia) Then
                actualizar_nivel_cumplimiento_accion(id_accion, CInt(tx_cumplimiento.Text.Trim).ToString.PadLeft(3, "0"))
            End If
        End If
        Return id_nuevo
    End Function
    Private Sub crear_parametros_seguimiento(ByVal ocmd As NpgsqlCommand)
        Dim txt_seguimiento As String = ""
        ocmd.Parameters.Clear()
        If vf_elemento_nuevo = "N" Then
            ocmd.Parameters.Add("@f0606_id_seguimiento_accion", NpgsqlDbType.Integer).Value = id_seguimiento_accion
        End If
        ocmd.Parameters.Add("@f0606_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0606_id_documento", NpgsqlDbType.Integer).Value = id_accion
        If vrespuesta = "S" Then
            txt_seguimiento = "RESPUESTA A SOLICITUD " & id_seguimiento_accion_padre & " DE " & comunes.traer_nombre_usuario(vg_usuario_autoriza) & vbCrLf
        End If

        If (evaluador_accion = vg_usuario_autoriza Or vg_usuario_autoriza = "00000001" Or evaluador_lider = "S") And CInt(tx_cumplimiento.Text.Trim) = 100 Then
            If cumplimiento_actual = 100 Then
                txt_seguimiento += "AMPLIACION O ACLARACION: " & vbCrLf & UCase(tx_anotacion.Text.ToString.Trim)
            Else
                txt_seguimiento += "CIERRE DE LA ACCION: " & vbCrLf & UCase(tx_anotacion.Text.ToString.Trim)
            End If

        Else
            txt_seguimiento += UCase(tx_anotacion.Text.ToString.Trim)
        End If
        ocmd.Parameters.Add("@f0606_seguimiento_accion", NpgsqlDbType.Varchar).Value = txt_seguimiento
        ocmd.Parameters.Add("@f0606_nivel_cumplimiento", NpgsqlDbType.Varchar).Value = CInt(tx_cumplimiento.Text.Trim).ToString.PadLeft(3, "0")
        ocmd.Parameters.Add("@f0606_fecha_inicio", NpgsqlDbType.Timestamp).Value = dtp_fecha_inicio.Value
        ocmd.Parameters.Add("@f0606_fecha_fin", NpgsqlDbType.Timestamp).Value = dtp_fecha_fin.Value
        ocmd.Parameters.Add("@f0606_id_tipo_seguimiento", NpgsqlDbType.Integer).Value = CInt(cm_tipo_seguimiento.SelectedValue)
        ocmd.Parameters.Add("@f0606_tipo_nota", NpgsqlDbType.Varchar).Value = tipo_nota
        ocmd.Parameters.Add("@f0606_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0606_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0606_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub
    Private Sub actualizar_nivel_cumplimiento_accion(ByVal id_accion As Integer, ByVal nivel_cumplimiento As String)
        'Dim csql As String = ""
        'Dim oconn_form As NpgsqlConnection
        'Dim verror As String = "N"

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set " _
            & "f0600_nivel_cumplimiento = '" & nivel_cumplimiento & "'" _
            & " where f0600_id_accion = '" & id_accion & "'"
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        'ocmd.Parameters.Clear()
        'ocmd.Parameters.Add("@fecha_actual", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar ! " + vbCrLf + ex.ToString)
        End Try
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub grabar_personal()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0607_seg_acc_personal" _
                & " (f0607_id_seguimiento_accion, f0607_id_tercero, f0607_tiempo_restar," _
                & " f0607_tiempo_extra, f0607_extra_dominical," _
                & " f0607_usuario_crear, f0607_usuario_modificar, f0607_fm," _
                & " f0607_r_lectura, f0607_r_respuesta)" _
                & " VALUES" _
                & " (@f0607_id_seguimiento_accion, @f0607_id_tercero, @f0607_tiempo_restar," _
                & " @f0607_tiempo_extra, @f0607_extra_dominical," _
                & " @f0607_usuario_crear, @f0607_usuario_modificar, @f0607_fm," _
                & " @f0607_r_lectura, @f0607_r_respuesta)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_personal(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando personal! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar personal! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub crear_parametros_personal(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0607_id_seguimiento_accion", NpgsqlDbType.Integer).Value = id_seguimiento_accion
        ocmd.Parameters.Add("@f0607_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("@f0607_tiempo_restar", NpgsqlDbType.Integer).Value = tiempo_restar
        ocmd.Parameters.Add("@f0607_tiempo_extra", NpgsqlDbType.Integer).Value = tiempo_extra
        ocmd.Parameters.Add("@f0607_extra_dominical", NpgsqlDbType.Varchar).Value = extra_dom
        ocmd.Parameters.Add("@f0607_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0607_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0607_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("@f0607_r_lectura", NpgsqlDbType.Varchar).Value = r_lectura
        ocmd.Parameters.Add("@f0607_r_respuesta", NpgsqlDbType.Varchar).Value = r_respuesta
    End Sub
    Private Sub actualizar_seguimiento()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0606_seguimientos_acciones set "
        csql += "f0606_id_documento = @f0606_id_documento,"
        csql += "f0606_seguimiento_accion = @f0606_seguimiento_accion,"
        csql += "f0606_nivel_cumplimiento = @f0606_nivel_cumplimiento,"
        csql += "f0606_fecha_inicio = @f0606_fecha_inicio, "
        csql += "f0606_fecha_fin = @f0606_fecha_fin,"
        csql += "f0606_fm = @f0606_fm,"
        csql += "f0606_usuario_modificar = @f0606_usuario_modificar"
        csql += " where f0606_id_seguimiento_accion = @f0606_id_seguimiento_accion"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_seguimiento(ocmd)
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
    Private Sub actualizar_listado_personal()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        If vexiste = "S" Then
            csql = "update " + database.obtener_esquema + ".tb0607_seg_acc_personal set "
            csql += "f0607_tiempo_restar = @f0607_tiempo_restar,"
            csql += "f0607_tiempo_extra = @f0607_tiempo_extra,"
            csql += "f0607_extra_dominical = @f0607_extra_dominical,"
            csql += "f0607_usuario_modificar = @f0607_usuario_modificar,"
            csql += "f0607_fm = @f0607_fm,"
            csql += "f0607_r_lectura = @f0607_r_lectura, "
            csql += "f0607_r_respuesta = @f0607_r_respuesta"
            csql += " where f0607_id_seguimiento_accion = @f0607_id_seguimiento_accion and f0607_id_tercero = @f0607_id_tercero"
        Else
            csql = "update " + database.obtener_esquema + ".tb0607_seg_acc_personal set "
            csql += "f0607_anulado = 'S',"
            csql += "f0607_usuario_anular = @f0607_usuario_modificar,"
            csql += "f0607_fm = @f0607_fm"
            csql += " where f0607_id_seguimiento_accion = @f0607_id_seguimiento_accion and f0607_id_tercero = @f0607_id_tercero and f0607_anulado = 'N'"
        End If
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_personal(ocmd)
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
    Private Sub validar_cumplimiento()
        accion_cumplida = "N"
        If IsNumeric(tx_cumplimiento.Text) = False Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El porcentaje de cumplimiento debe ser numerico"
            tx_cumplimiento.Text = cumplimiento_actual
            Exit Sub
        End If
        If CInt(tx_cumplimiento.Text) > 100 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "El porcentaje de cumplimiento no puede ser superior a 100"
            tx_cumplimiento.Text = cumplimiento_actual
            Exit Sub
        End If
        If CInt(tx_cumplimiento.Text) = 100 Then
            accion_cumplida = "S"
        End If
    End Sub
    Private Sub validar_tipo_seguimiento()
        If cm_tipo_seguimiento.SelectedIndex = -1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Seleccione un tipo de seguimiento."
        End If
    End Sub
    Private Sub tx_cumplimiento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tx_cumplimiento.Validating
        validar_cumplimiento()
    End Sub
    Private Sub validar_fechas()
        If dtp_fecha_fin.Value < dtp_fecha_inicio.Value Then
            verror_requisitos = "S"
            vmensaje_requisitos = "La fecha final no puede ser menor que la fecha inicial"
        End If
        If dtp_fecha_fin.Value > comunes.g_fechahora Then
            verror_requisitos = "S"
            vmensaje_requisitos = "La fecha final no puede ser mayor que la fecha actual del sistema"
        End If
        If cm_tipo_seguimiento.SelectedValue = 2 And dtp_fecha_fin.Value = dtp_fecha_inicio.Value Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Las fecha Inicial y Final no pueden ser iguales. "
        End If
    End Sub
    Private Sub validar_seguimiento()
        If tx_anotacion.Text.Trim.ToString = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "No hay una nota de seguimiento"
        End If
    End Sub
    Private Sub validar_cambio_visto_otros_usuarios()
        If dg_personal.Rows.Count = 1 Then
            Exit Sub
        End If
        Dim visto As String = "N"
        For Each orow As DataGridViewRow In dg_personal.Rows
            If orow.Cells("dgocell_fecha_lectura").Value <> "" Or orow.Cells("dgocell_id_respuesta").Value <> "" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Este seguimiento ya fue gestionado por otro funcionario. No se puede modificar."
            End If
        Next

    End Sub
    Private Sub validar_personal()
        If cm_tipo_seguimiento.SelectedValue = 1 Then
            Exit Sub
        End If
        If dg_personal.Rows.Count = 1 Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina personal seguimiento"
            Exit Sub
        End If
        For Each orow As DataGridViewRow In dg_personal.Rows
            tiempo_restar = orow.Cells("dgocell_restar_tiempo").Value
            If IsDBNull(tiempo_restar) = True Then
                tiempo_restar = 0
            End If
            tiempo_extra = orow.Cells("dgocell_minutos_extras").Value
            If IsDBNull(tiempo_extra) = True Then
                tiempo_extra = 0
            End If
            If orow.IsNewRow = False Then
                If CInt(intervalo.TotalMinutes) <= tiempo_restar And tiempo_restar > 0 Then
                    verror_requisitos = "S"
                    vmensaje_requisitos = "Se esta restando un tiempo mayor o igual al usado en la actividad!"
                End If
            End If
        Next
    End Sub
    Private Sub validar_personal_doble()
        Dim id_row As Integer
        For Each orow As DataGridViewRow In dg_personal.Rows
            If orow.IsNewRow = False Then
                Try
                    'Si falla quiere decir que no se selecciono a ningun funcionario.
                    id_tercero = orow.Cells("dgocell_id_tercero").Value.ToString
                Catch ex As Exception
                    verror_requisitos = "S"
                    vmensaje_requisitos = "Personal asociado sin seleccionar. Elimine registros erroneos!"
                    Exit Sub
                End Try

                id_row = orow.Index
                For Each orow2 As DataGridViewRow In dg_personal.Rows
                    If orow2.IsNewRow = False Then
                        If id_row <> orow2.Index Then
                            If id_tercero = orow2.Cells("dgocell_id_tercero").Value.ToString Then
                                verror_requisitos = "S"
                                vmensaje_requisitos = "Hay un funcionario duplicado!"
                            End If
                        End If
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub validar_cambios_solo_creador()
        If vg_usuario_autoriza <> usuario_creador And vg_usuario_autoriza <> "00000001" Then
            If vf_elemento_nuevo = "N" Then
                verror_requisitos = "S"
                vmensaje_requisitos = "Solo el emisor puede realizar cambios en este registro!"
            End If
        End If
    End Sub
    Private Sub grabar_cambios_personal()
        'actualizo los registros existentes que coincidan en la tabla y la grilla
        For Each orow As DataGridViewRow In dg_personal.Rows
            If orow.IsNewRow = False Then
                id_tercero = orow.Cells("dgocell_id_tercero").Value.ToString
                tiempo_restar = orow.Cells("dgocell_restar_tiempo").Value
                tiempo_extra = orow.Cells("dgocell_minutos_extras").Value
                If orow.Cells("dg_ochk_dominical").Value = 0 Then
                    extra_dom = "N"
                Else
                    extra_dom = "S"
                End If
                'f0607_r_lectura, f0607_fecha_lectura, f0607_r_respuesta, f0607_id_respuesta
                If orow.Cells("dgochk_r_lectura").Value = 0 Then
                    r_lectura = "N"
                Else
                    r_lectura = "S"
                End If
                If orow.Cells("dgochk_r_respuesta").Value = 0 Then
                    r_respuesta = "N"
                Else
                    r_respuesta = "S"
                End If
                If IsDBNull(tiempo_restar) = True Then
                    tiempo_restar = 0
                End If
                vexiste = "N"
                For Each orow2 As DataRow In otb_info_personal_seg.Rows
                    If id_tercero = orow2("f0607_id_tercero").ToString Then
                        vexiste = "S"
                        actualizar_listado_personal()
                        'MsgBox(id_tercero & "--" & orow2("f0607_id_tercero").ToString)
                    End If
                Next
                If vexiste = "N" Then 'el tercero no existe en la tabla entonces en nuevo
                    grabar_personal()
                End If
            End If
        Next
        'anulo los registros que no existan en la grilla
        For Each orow As DataRow In otb_info_personal_seg.Rows
            id_tercero = orow("f0607_id_tercero").ToString
            vexiste = "N"
            For Each orow2 As DataGridViewRow In dg_personal.Rows
                If orow2.IsNewRow = False Then
                    'MsgBox(id_tercero & "=" & orow2.Cells("dgocell_id_tercero").Value.ToString)
                    If id_tercero = orow2.Cells("dgocell_id_tercero").Value.ToString Then
                        vexiste = "S"
                        'MsgBox("Encontrado")
                    End If
                End If
            Next
            If vexiste = "N" Then
                'MsgBox("Borrar: " & id_tercero)
                actualizar_listado_personal()
            End If
        Next
    End Sub
    Private Sub bt_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_grabar.Click
        verror_requisitos = "N"
        validar_tipo_seguimiento()
        validar_fechas()
        validar_cumplimiento()
        validar_seguimiento()
        validar_personal()
        validar_personal_doble()
        validar_cambios_solo_creador()
        'Anulo esta validacion debido a que no funciona correctamente.
        'validar_cambio_visto_otros_usuarios()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            id_seguimiento_accion = grabar_nuevo_seguimiento()
            'id_seguimiento_accion = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0606_id_seguimiento_accion", "f0606_usuario_crear", vg_usuario_autoriza, "tb0606_seguimientos_acciones")
            For Each orow As DataGridViewRow In dg_personal.Rows
                id_tercero = orow.Cells("dgocell_id_tercero").Value
                tiempo_restar = orow.Cells("dgocell_restar_tiempo").Value
                tiempo_extra = orow.Cells("dgocell_minutos_extras").Value
                If orow.Cells("dg_ochk_dominical").Value = 0 Then
                    extra_dom = "N"
                Else
                    extra_dom = "S"
                End If
                If orow.Cells("dgochk_r_lectura").Value = 0 Then
                    r_lectura = "N"
                Else
                    r_lectura = "S"
                End If
                If orow.Cells("dgochk_r_respuesta").Value = 0 Then
                    r_respuesta = "N"
                Else
                    r_respuesta = "S"
                End If
                If IsDBNull(tiempo_restar) = True Then
                    tiempo_restar = 0
                End If
                If orow.IsNewRow = False Then
                    grabar_personal()
                End If
            Next
            If vrespuesta = "S" Then 'Si es una respuesta actualizamos el id_respuesta en tabla de personal
                grabar_id_seguimiento_de_respuesta()
            End If
        Else 'debemos actualizar seguimiento existente
            'Pregunta si realmente desea grabar cambios
            Dim respuesta As String = "N"
            respuesta = comunes.g_mensaje_YesNo("Grabar Cambios", "Desea grabar cambios en este registro?")
            If respuesta = "N" Then
                Exit Sub
            End If
            actualizar_seguimiento()
            grabar_cambios_personal()
        End If
        If verror = "N" Then
            If tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia) Then
                If accion_cumplida = "S" Then 'en el seguimiento se coloca 100%
                    If repeticion_programada = "N" Then

                        If repeticiones_ejecutadas < repeticiones_programadas And estado_accion_padre <> "08" Then
                            grabar_nueva_tarea()
                            actualizar_accion_principal()
                            repeticion_programada = "S"
                        End If
                    End If
                End If
                actualizar_estado_accion()
            End If
            vf_elemento_nuevo = "N"
            MsgBox("Registro grabado", MsgBoxStyle.Information, "Grabar")
        End If
        'Dispose()
        cargar_seguimiento_existente(id_seguimiento_accion)
    End Sub
    Private Sub grabar_nueva_tarea()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0600_acciones" _
                & " (f0600_id_cia, f0600_id_accion_padre, f0600_id_accion_principal," _
                & " f0600_id_estructura, f0600_titulo, f0600_descripcion, f0600_id_estado_accion," _
                & " f0600_id_fuente_accion, f0600_unidad_duracion, f0600_duracion," _
                & " f0600_id_tipo_accion, f0600_responsable, f0600_evaluador, f0600_id_tipo_registro," _
                & " f0600_emisor, f0600_fecha_inicio, f0600_path," _
                & " f0600_usuario_modificar, f0600_usuario_crear, f0600_fm, f0600_fecha_limite," _
                & " f0600_repetitiva, f0600_repeticiones_ejecutadas, f0600_repeticiones_programadas)" _
                & " VALUES" _
                & " (@f0600_id_cia, @f0600_id_accion_padre, @f0600_id_accion_principal," _
                & " @f0600_id_estructura, @f0600_titulo, @f0600_descripcion, @f0600_id_estado_accion," _
                & " @f0600_id_fuente_accion, @f0600_unidad_duracion, @f0600_duracion," _
                & " @f0600_id_tipo_accion, @f0600_responsable, @f0600_evaluador, @f0600_id_tipo_registro," _
                & " @f0600_emisor, @f0600_fecha_inicio, @f0600_path," _
                & " @f0600_usuario_modificar, @f0600_usuario_crear, @f0600_fm, @f0600_fecha_limite," _
                & " @f0600_repetitiva, @f0600_repeticiones_ejecutadas, @f0600_repeticiones_programadas)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_tarea(ocmd)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nueva falla! " + vbCrLf + ex.ToString + vbCrLf + csql)
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
    Private Sub crear_parametros_tarea(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()

        csql = "SELECT *" _
            & " FROM " & database.obtener_esquema & ".tb0002_unidades_medicion" _
            & " where f0002_id_tipo_unidad = '00000005'"
        otb_unidad_tiempo = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        For Each orow As DataRow In otb_info_accion_padre.Rows
            ocmd.Parameters.Add("@f0600_id_cia", NpgsqlDbType.Varchar).Value = orow("f0600_id_cia")
            ocmd.Parameters.Add("@f0600_id_accion_principal", NpgsqlDbType.Integer).Value = CInt(orow("f0600_id_accion"))
            ocmd.Parameters.Add("@f0600_id_accion_padre", NpgsqlDbType.Integer).Value = CInt(orow("f0600_id_accion"))
            ocmd.Parameters.Add("@f0600_path", NpgsqlDbType.Varchar).Value = orow("f0600_path") & id_accion_padre & "-"
            ocmd.Parameters.Add("@f0600_id_estructura", NpgsqlDbType.Integer).Value = CInt(orow("f0600_id_estructura"))
            ocmd.Parameters.Add("@f0600_titulo", NpgsqlDbType.Varchar).Value = orow("f0600_titulo")
            ocmd.Parameters.Add("@f0600_descripcion", NpgsqlDbType.Varchar).Value = orow("f0600_descripcion")
            ocmd.Parameters.Add("@f0600_id_tipo_registro", NpgsqlDbType.Varchar).Value = "03" 'es una tarea normal
            ocmd.Parameters.Add("@f0600_id_fuente_accion", NpgsqlDbType.Integer).Value = CInt(orow("f0600_id_fuente_accion"))
            ocmd.Parameters.Add("@f0600_id_tipo_accion", NpgsqlDbType.Varchar).Value = orow("f0600_id_tipo_accion")
            ocmd.Parameters.Add("@f0600_id_estado_accion", NpgsqlDbType.Varchar).Value = "03" '03 = implementacion 'orow("f0600_id_estado_accion")
            ocmd.Parameters.Add("@f0600_unidad_duracion", NpgsqlDbType.Varchar).Value = orow("f0600_unidad_duracion")
            ocmd.Parameters.Add("@f0600_duracion", NpgsqlDbType.Integer).Value = CInt(orow("f0600_duracion"))
            ocmd.Parameters.Add("@f0600_responsable", NpgsqlDbType.Varchar).Value = orow("f0600_responsable")
            ocmd.Parameters.Add("@f0600_evaluador", NpgsqlDbType.Varchar).Value = orow("f0600_evaluador")
            ocmd.Parameters.Add("@f0600_emisor", NpgsqlDbType.Varchar).Value = orow("f0600_emisor")
            'calcular nueva fecha de inicio
            Dim fecha_ini As Date = dtp_fecha_fin.Value
            nueva_fecha_inicio = DateAdd(DateInterval.Day, orow("f0600_periodo_repeticion"), CDate(fecha_ini.ToString("yyyy/MM/dd")))
            ocmd.Parameters.Add("@f0600_fecha_inicio", NpgsqlDbType.Timestamp).Value = nueva_fecha_inicio
            ocmd.Parameters.Add("@f0600_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
            ocmd.Parameters.Add("@f0600_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
            ocmd.Parameters.Add("@f0600_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
            'calcular nueva fecha de finalizacion
            Dim odatarow() As DataRow = otb_unidad_tiempo.Select("f0002_id_unidad_medicion = '" & orow("f0600_unidad_duracion") & "'")
            For Each orow2 As DataRow In odatarow
                nueva_fecha_limite = DateAdd(DateInterval.Second, (orow2("f0002_factor_conversion") * orow("f0600_duracion")), nueva_fecha_inicio)
            Next
            ocmd.Parameters.Add("@f0600_fecha_limite", NpgsqlDbType.Timestamp).Value = nueva_fecha_limite
            ocmd.Parameters.Add("@f0600_repetitiva", NpgsqlDbType.Varchar).Value = "S"
            ocmd.Parameters.Add("@f0600_repeticiones_ejecutadas", NpgsqlDbType.Integer).Value = repeticiones_ejecutadas + 1
            ocmd.Parameters.Add("@f0600_repeticiones_programadas", NpgsqlDbType.Integer).Value = repeticiones_programadas
        Next
    End Sub
    Private Sub actualizar_estado_accion(Optional oforzar_cierre As String = "N")
        Dim ejecutar_grabado As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada

        If accion_cumplida = "S" Then 'en el seguimiento se coloca 100%
            ejecutar_grabado = "S"
            If evaluador_accion = vg_usuario_autoriza Or
                   vg_usuario_autoriza = "00000001" Or
                   oforzar_cierre = "S" Or
                   evaluador_lider = "S" Then
                '& " f0600_repeticiones_indefinidas = 'N'," _
                csql = "update " + database.obtener_esquema + ".tb0600_acciones set" _
                & " f0600_id_estado_accion = '08'," _
                & " f0600_repeticion_programada = '" & repeticion_programada & "'," _
                & " f0600_fecha_cierre = @fecha_actual" _
                & " where f0600_id_accion = '" & id_accion & "'"
            Else
                csql = "update " + database.obtener_esquema + ".tb0600_acciones set" _
                & " f0600_id_estado_accion = '06'," _
                & " f0600_repeticion_programada = '" & repeticion_programada & "'" _
                & " where f0600_id_accion = '" & id_accion & "'"
            End If
        End If
        If CInt(tx_cumplimiento.Text) < 100 And cumplimiento_actual = 100 Then
            ejecutar_grabado = "S"
            Dim estado_Acc As String = "07" '07 Vencida, 03 Implementacion
            Dim fecha_final_Acc As DateTime
            fecha_final_Acc = otb_info_accion.Rows.Item(0).Field(Of DateTime)("f0600_fecha_limite")
            If fecha_final_Acc > comunes.g_fechahora() Then
                estado_Acc = "03"
            End If

            csql = "update " + database.obtener_esquema + ".tb0600_acciones set" _
                & " f0600_id_estado_accion = '" & estado_Acc & "'," _
                & " f0600_repeticion_programada = '" & repeticion_programada & "'" _
                & " where f0600_id_accion = '" & id_accion & "'"
        End If
        If ejecutar_grabado = "N" Then
            Exit Sub
        End If
        'Crear el comando
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql

        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@fecha_actual", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar estado" + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Actualizar ! estado" + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub actualizar_accion_principal()
        Dim estado_ppal As String
        If repeticiones_programadas = repeticiones_ejecutadas + 1 Then
            estado_ppal = "06"
        Else
            estado_ppal = "03"
        End If
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set " _
                    & " f0600_repeticiones_ejecutadas = '" & repeticiones_ejecutadas + 1 & "'," _
                    & " f0600_id_estado_accion = '" & estado_ppal & "'" _
                    & " where f0600_id_accion = '" & id_accion_principal & "'"
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
    Private Sub cm_tipo_seguimiento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm_tipo_seguimiento.Validating
        If vf_elemento_nuevo = "S" Then
            dg_personal.Rows.Clear()
        End If
        If cm_tipo_seguimiento.SelectedIndex = -1 Then
            cm_tipo_seguimiento.SelectedValue = 1
            Exit Sub
        End If
        otipo_seguimiento = cm_tipo_seguimiento.SelectedValue
        activar_columnas_dg_personal()
    End Sub
    Private Sub activar_columnas_dg_personal()
        Select Case otipo_seguimiento
            Case 1
                dg_personal.Columns("dgocell_restar_tiempo").Visible = False
                dg_personal.Columns("dgocell_minutos_extras").Visible = False
                dg_personal.Columns("dg_ochk_dominical").Visible = False
                dg_personal.Columns("dgocell_fecha_lectura").Visible = True
                dg_personal.Columns("dgocell_id_respuesta").Visible = True
                dg_personal.Columns("dgochk_r_lectura").Visible = True
                dg_personal.Columns("dgochk_r_respuesta").Visible = True
                dtp_fecha_fin.Enabled = False
                dtp_fecha_inicio.Enabled = False
                tx_duracion.ReadOnly = True
                Dim hora_actual As DateTime = comunes.g_fechahora
                'dtp_fecha_inicio.Value = hora_actual
                'dtp_fecha_fin.Value = hora_actual
            Case 2
                dg_personal.Columns("dgocell_restar_tiempo").Visible = True
                dg_personal.Columns("dgocell_minutos_extras").Visible = True
                dg_personal.Columns("dg_ochk_dominical").Visible = True
                dg_personal.Columns("dgocell_fecha_lectura").Visible = False
                dg_personal.Columns("dgocell_id_respuesta").Visible = False
                dg_personal.Columns("dgochk_r_lectura").Visible = False
                dg_personal.Columns("dgochk_r_respuesta").Visible = False
                dtp_fecha_fin.Enabled = True
                dtp_fecha_inicio.Enabled = True
                tx_duracion.ReadOnly = False
        End Select
    End Sub
    Private Sub calcular_archivos_asociados()
        lb_total_soportes.Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados("CD-NTA-001", tx_id_seguimiento.Text, vg_id_cia)
    End Sub
    Private Sub bt_nuevo_soporte_Click(sender As System.Object, e As System.EventArgs) Handles bt_nuevo_soporte.Click
        cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo("CD-NTA", tx_id_seguimiento.Text, vg_id_cia, vg_usuario_autoriza, "N")
        calcular_archivos_asociados()
    End Sub
    Private Sub bt_ver_archivos_asociados_Click(sender As System.Object, e As System.EventArgs) Handles bt_ver_archivos_asociados.Click
        csql = "SELECT f0503_id_archivo as id_file, f0503_ed as documento, f0503_descripcion_archivo as descripcion," _
    & " to_char(f0503_fr, 'YYYY-MM-DD HH12:MI AM') as fecha_carga, f0503_nombre_original as origen" _
    & " from " & database.obtener_esquema & ".tb0503_archivos_asociados" _
    & " where f0503_nombre_archivo = '" & new_name_file & "' and f0503_id_cia = '" & vg_id_cia & "'" _
    & " order by f0503_id_archivo desc"
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_archivos As New camocontrol.fm_visor_datos
        oform_mostrar_archivos.vf_oform_padre = Me
        oform_mostrar_archivos.csql = csql
        oform_mostrar_archivos.titulo_formulario = "Archivos Asociados"
        oform_mostrar_archivos.vg_id_cia = vg_id_cia
        oform_mostrar_archivos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_archivos.ShowDialog()
    End Sub
    Private Sub bt_editar_Click(sender As System.Object, e As System.EventArgs) Handles bt_editar.Click
        verror_requisitos = "N"
        validar_cambios_solo_creador()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        bt_grabar.Enabled = True
        tx_cumplimiento.Enabled = True
        tx_anotacion.ReadOnly = False
        dg_personal.ReadOnly = False
    End Sub
    Private Sub linklabel_id_accion_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linklabel_id_accion.LinkClicked
        If IsNumeric(linklabel_id_accion.Text) = True Then
            cl_utilidades_gestion_acciones.abrir_actividad(linklabel_id_accion.Text, vg_usuario_autoriza, vg_id_cia)
        End If
    End Sub

    Private Sub bt_actividades_prog_Click(sender As System.Object, e As System.EventArgs) Handles bt_actividades_prog.Click
        MsgBox("Deshabilitado")
    End Sub

    Private Sub bt_forzar_cierre_Click(sender As Object, e As EventArgs) Handles bt_forzar_cierre.Click
        'Pregunta si realmente desea grabar cambios
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Forzar Cierre", "Desea forzar el cierre de esta actividad?")
        If respuesta = "N" Then
            Exit Sub
        End If

        verror_requisitos = "N"
        validar_tipo_seguimiento()
        validar_fechas()
        validar_cumplimiento()
        validar_seguimiento()
        validar_personal()
        validar_personal_doble()
        validar_cambios_solo_creador()
        'validacion anulada porque no funciona adecuadamente
        'validar_cambio_visto_otros_usuarios()
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If vf_elemento_nuevo = "S" Then
            tx_anotacion.Text = "CIERRE FORZADO SIN CUMPLIR OBJETIVO O META!" & vbCrLf & tx_anotacion.Text
            id_seguimiento_accion = grabar_nuevo_seguimiento()
            'id_seguimiento_accion = cl_utilidades_datatables.consultar_consecutivo_creado_tablas("f0606_id_seguimiento_accion", "f0606_usuario_crear", vg_usuario_autoriza, "tb0606_seguimientos_acciones")
            For Each orow As DataGridViewRow In dg_personal.Rows
                id_tercero = orow.Cells("dgocell_id_tercero").Value
                tiempo_restar = orow.Cells("dgocell_restar_tiempo").Value
                If orow.Cells("dgochk_r_lectura").Value = 0 Then
                    r_lectura = "N"
                Else
                    r_lectura = "S"
                End If
                If orow.Cells("dgochk_r_respuesta").Value = 0 Then
                    r_respuesta = "N"
                Else
                    r_respuesta = "S"
                End If
                If IsDBNull(tiempo_restar) = True Then
                    tiempo_restar = 0
                End If
                If orow.IsNewRow = False Then
                    grabar_personal()
                End If
            Next
            If vrespuesta = "S" Then 'Si es una respuesta actualizamos el id_respuesta en tabla de personal
                grabar_id_seguimiento_de_respuesta()
            End If
        End If
        If verror = "N" Then
            'Para que se cierre debemos definir la accion como cumplida
            accion_cumplida = "S"
            If tipo_nota = comunes.suministrar_valor_variable_configuracion("TN-ACC-001", vg_id_cia) Then
                If accion_cumplida = "S" Then 'en el seguimiento se coloca 100%
                    If repeticion_programada = "N" Then
                        If repeticiones_ejecutadas < repeticiones_programadas Then
                            grabar_nueva_tarea()
                            actualizar_accion_principal()
                            repeticion_programada = "S"
                        End If
                    End If
                End If
                actualizar_estado_accion("S")
            End If
            vf_elemento_nuevo = "N"
            MsgBox("Registro grabado", MsgBoxStyle.Information, "Grabar")
        End If
        'Dispose()
        cargar_seguimiento_existente(id_seguimiento_accion)
    End Sub

    Private Sub bt_generar_informe_Click(sender As Object, e As EventArgs) Handles bt_generar_informe.Click
        If tx_id_seguimiento.Text.Trim = "" Then
            MsgBox("Actividad fallida", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        cl_informes_comunes.reporte_seguimiento_anotacion(vg_id_cia, tx_id_seguimiento.Text)
    End Sub
End Class
