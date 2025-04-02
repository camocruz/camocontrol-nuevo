Public Class fm_0100_trasladar_ramal
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Public otipo_ramal As Integer = 1 '1 estructura de manto, 2 accion sgc
    Public formulario_origen As String
    Public valor_raiz As String 'valor que se escribira en el path cuando el elemento es raizal
    Public id_padre As Integer
    Public id_hijo As Integer
    Public otabla As String
    Public campo_id As String
    Public campo_path As String
    Public campo_dependencia As String
    Public campo_agrupacion_principal As String
    Public otb_listado_elementos_a_trasladar As DataTable = Nothing 'se usa cuando se desea trasladar varios elementos a una solo elemento padre.

    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private verror As String = "S"

    Private csql As String
    Private otb_info_padre As DataTable
    Private otb_info_hijo As DataTable
    Private tipo_registro_padre As String = ""
    Private tipo_registro_hijo As String = ""
    Private parada_produccion_padre As String = ""
    Private parada_produccion_hijo As String = ""
    Private emisor_padre As String
    Private emisor_hijo As String
    Private accion_principal As Integer
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String

    Private Sub fm_0100_trasladar_ramal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        Dim vf_otabla_permisos As DataTable
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        'Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = cl_gestion_permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        Select Case otipo_ramal
            Case 1 'estructura de mantenimiento
                txt_id_hijo.Visible = False
                txt_id_padre.Visible = False
            Case 2 'acciones del sgc acciones
                txt_id_hijo.Visible = True
                txt_id_padre.Visible = True
                chk_raiz.Enabled = False
                rb_hijo.Enabled = False
                rb_padre.Enabled = False

                otabla = "tb0600_acciones"
                campo_id = "f0600_id_accion"
                campo_path = "f0600_path"
                campo_dependencia = "f0600_id_accion_padre"
                campo_agrupacion_principal = "f0600_id_accion_principal"
            Case 3 'acciones del sgc acciones que se va a configurar como Re-Ejecucion.
                txt_id_hijo.Visible = True
                txt_id_padre.Visible = True
                chk_raiz.Enabled = False
                rb_hijo.Enabled = False
                rb_padre.Enabled = False

                otabla = "tb0600_acciones"
                campo_id = "f0600_id_accion"
                campo_path = "f0600_path"
                campo_dependencia = "f0600_id_accion_padre"
                campo_agrupacion_principal = "f0600_id_accion_principal"

                csql = "select f0200_id_tercero, f0200_apellido1 || ' ' || f0200_apellido2 || ' ' || f0200_nombres as nombre" _
                   & " from " & database.obtener_esquema & ".tb0200_terceros" _
                   & " where f0200_id_cia = '" & vg_id_cia & "'" & " and f0200_ind_empleado = 'S'" _
                   & " order by nombre"
                Dim otb_responsable As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

                With cm_responsable
                    'Valor que se muestra al usuario
                    .DisplayMember = "nombre"
                    'Valor interno que almacena el objeto
                    .ValueMember = "f0200_id_tercero"
                    'Origen de Datos del ComboBox
                    .DataSource = otb_responsable
                    .DropDownStyle = ComboBoxStyle.DropDown
                    .AutoCompleteMode = AutoCompleteMode.Suggest
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                    .SelectedIndex = -1
                End With


            Case Else
                MsgBox("Error de tipo de caso")
        End Select
        If ocontexto_form = "trasladar varias acciones hacia una accion padre" Then
            txt_id_hijo.Enabled = False
        End If
    End Sub
    Private Sub fm_0100_trasladar_ramal_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        rb_padre.Checked = True
        lb_padre.Text = "ND"
        lb_hijo.Text = "ND"
        chk_raiz.Checked = False
    End Sub

    Private Sub chk_raiz_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_raiz.CheckStateChanged

        If chk_raiz.Checked = True Then
            rb_padre.Enabled = False
            rb_hijo.Checked = True
            lb_padre.Text = "Raiz"
        Else
            rb_padre.Enabled = True
            rb_padre.Checked = True
            lb_padre.Text = "ND"
        End If
    End Sub
    Private Sub validar_info_padre(oid_accion As String)
        If oid_accion = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina una actividad padre!"
            Exit Sub
        End If
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0600_acciones" _
            & " where f0600_id_accion = '" & oid_accion & "'"
        otb_info_padre = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_padre.Rows
            tipo_registro_padre = orow("f0600_id_tipo_registro")
            valor_raiz = orow("f0600_path") & oid_accion & "-"
            id_padre = oid_accion
            emisor_padre = orow("f0600_emisor")
            If orow("f0600_tipo_docto_padre") = "RP" Then
                parada_produccion_padre = "S"
            End If
        Next
        If tipo_registro_padre = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "La actividad padre no existe!"
        End If
    End Sub
    Private Sub validar_info_hijo(oid_accion As String)
        If oid_accion = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina una actividad hijo!"
            Exit Sub
        End If
        csql = "select *" _
            & " from " & database.obtener_esquema & ".tb0600_acciones" _
            & " where f0600_id_accion = '" & oid_accion & "'"
        otb_info_padre = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_info_padre.Rows
            tipo_registro_hijo = orow("f0600_id_tipo_registro")
            id_hijo = oid_accion
            emisor_hijo = orow("f0600_emisor")
            If orow("f0600_tipo_docto_padre") = "RP" Then
                parada_produccion_hijo = "S"
            End If
        Next
        If tipo_registro_hijo = "" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "La actividad hijo no existe!"
        End If
        If tipo_registro_hijo = "01" Then
            'verror_requisitos = "S"
            'vmensaje_requisitos = "La actividad hijo no puede ser un plan de accion!"
        End If
    End Sub
    Private Sub validar_cambios_solo_creador()
        Dim p_cambios As String = "N"
        If (vg_usuario_autoriza <> emisor_padre Or vg_usuario_autoriza <> emisor_hijo) And vg_usuario_autoriza <> "00000001" Then
            p_cambios = "N"
        Else
            p_cambios = "S"
        End If
        If otipo_ramal = 3 Then   '3 = 'acciones del sgc acciones que se va a configurar como Re-Ejecucion.
            'Se da acceso a realizar cambios puesto que si llego hasta este punto es porque se le dio permiso
            'para realizar el traslado de la actividad y reportarla como re-ejecucion.
            p_cambios = "S"
        End If
        If p_cambios = "N" Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Solo el emisor de ambas actividades puede realizar este cambio!"
        End If
    End Sub
    Private Sub validar_responsable()
        If cm_responsable.SelectedIndex = -1 Then
            vmensaje_requisitos = "Debe seleccionar un responsable de la Re-Ejecucion."
            verror_requisitos = "S"
        End If
    End Sub
    Private Sub bt_trasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_trasladar.Click
        Select Case otipo_ramal
            Case 1 'estructura de mantenimiento
                trasladar_estructura()
            Case 2  'acciones del sgc acciones
                trasladar_acciones()
            Case 3  'acciones del sgc acciones
                trasladar_acciones()
                'Actualizo la informacion en la accion hijo para asignar la responsabilidad de la reejecucion.

            Case Else
                MsgBox("Error de tipo de caso")
        End Select

        If formulario_origen = "fm_0100_estructura_mantenimiento" Then
            'funcion que recalculara las estructuras padre de la estructura de mantenimiento.
            cl_utilidades_gestion_mantenimiento.actualizar_estructura_padre(vg_id_cia)
            cl_utilidades_gestion_mantenimiento.actualizar_hijos_de_maquinas(vg_id_cia)
            'funcion que recalculara las estructuras padre de la estructura de mantenimiento.
            cl_utilidades_gestion_mantenimiento.actualizar_estructura_padre(vg_id_cia)
            vf_oform_padre.actualizar_arbol()
        End If

        If formulario_origen = "fm_0600_p3_analisis_y_solucion" Then
            vf_oform_padre.refrescar_grilla()
            vf_oform_padre.trasladar = "N"
        End If
        MsgBox("Traslado completado.", MsgBoxStyle.Information, "Traslado")
        Dispose()
    End Sub

    Private Sub asignar_responsable_reejecucion()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0600_acciones set "
        csql += "f0600_re_ejecucion = @f0600_re_ejecucion,"
        csql += "f0600_funcionario_re_ejecucion = @f0600_funcionario_re_ejecucion"
        csql += " where f0600_id_accion = @f0600_id_accion"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_reejecucion(ocmd)
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
    Private Sub crear_parametros_reejecucion(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0600_id_accion", NpgsqlDbType.Integer).Value = txt_id_hijo.Text
        ocmd.Parameters.Add("@f0600_re_ejecucion", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("@f0600_funcionario_re_ejecucion", NpgsqlDbType.Varchar).Value = cm_responsable.SelectedValue.ToString
    End Sub

    Private Sub trasladar_acciones()
        If IsNothing(otb_listado_elementos_a_trasladar) = True Then
            'Quiere desir que tomo el dato desde el formulario
            ' Declare variables for DataColumn and DataRow objects.
            Dim ocolumn As DataColumn
            Dim orow As DataRow
            otb_listado_elementos_a_trasladar = New DataTable
            ' Create new DataColumn, set DataType, ColumnName 
            ' and add to DataTable.    
            ocolumn = New DataColumn()
            ocolumn.DataType = System.Type.GetType("System.Int32")
            ocolumn.ColumnName = "id_acc"
            ' Add the Column to the DataColumnCollection.
            otb_listado_elementos_a_trasladar.Columns.Add(ocolumn)

            orow = otb_listado_elementos_a_trasladar.NewRow()
            orow("id_acc") = txt_id_hijo.Text
            otb_listado_elementos_a_trasladar.Rows.Add(orow)
        End If

        'EN ESTA SECCION SE REVALIDA LA IDENTIDAD DEL USUARIO
        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        autoriza = "N"
        Dim oform_login As New camocontrol.login
        'oform_grilla_programacion.ods_hijo = ods
        oform_login.vf_oform_padre = Me
        oform_login.paso_autorizacion = "S"
        oform_login.ShowDialog()
        If autoriza = "N" Then
            Exit Sub
        End If

        verror_requisitos = "N"
        validar_info_padre(txt_id_padre.Text)
        For Each orow As DataRow In otb_listado_elementos_a_trasladar.Rows
            validar_info_hijo(orow("id_acc"))
            'MsgBox(orow("id_acc"))
        Next
        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If otipo_ramal = 3 Then
            'la accion hijo debe tener un responsable por la reejecucion.
            validar_responsable()
        Else
            validar_cambios_solo_creador()
        End If

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        'funcion que traslada el ramal
        If otb_listado_elementos_a_trasladar.Rows.Count = 0 Then
            Exit Sub
        End If

        'Padre e hijo son registros de parada de produccion
        If tipo_registro_padre = "01" And parada_produccion_padre = "S" _
               And tipo_registro_hijo = "01" And parada_produccion_hijo = "S" _
            Then

        End If

        'El padre fue una actividad que genero una parada de produccion
        If tipo_registro_padre = "03" _
               And tipo_registro_hijo = "01" And parada_produccion_hijo = "S" _
            Then
            'hay que tener en cuenta que se podria seleccionar una actividad hija de una parada de produccion

        End If


        For Each orow As DataRow In otb_listado_elementos_a_trasladar.Rows
            validar_info_hijo(orow("id_acc"))
            cl_utilidades_gestion_acciones.trasladar_ramal(valor_raiz, id_padre, id_hijo, otabla, campo_id, campo_path, campo_dependencia, campo_agrupacion_principal)
        Next

        If otipo_ramal = 3 Then 'Actualizo la informacion en la accion hijo para asignar la responsabilidad de la reejecucion.
            asignar_responsable_reejecucion()
        End If

    End Sub
    Private Sub trasladar_estructura()
        If lb_hijo.Text = "ND" Or lb_padre.Text = "ND" Then
            MsgBox("Debe seleccionar el elemento padre y el elemento hijo", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        'funcion que traslada el ramal
        cl_utilidades_gestion_acciones.trasladar_ramal(valor_raiz, id_padre, id_hijo, otabla, campo_id, campo_path, campo_dependencia, campo_agrupacion_principal)

    End Sub
    Private Sub bt_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_cerrar.Click
        Dispose()
    End Sub

    Private Sub txt_id_padre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_id_padre.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txt_id_hijo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_id_hijo.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
    End Sub
End Class
