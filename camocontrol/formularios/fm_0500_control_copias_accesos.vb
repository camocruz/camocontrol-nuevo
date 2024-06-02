Public Class fm_0500_control_copias_accesos
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public id_despacho As Integer
    Public mostrar_solo_despacho As String = "S"

    Private otipo_nota As String

    Public id_documento As Integer = 0
    Public config_archivos As String

    'Private$vf_otabla_permisos$As DataTable
    Private id_cargo As Integer = 0
    Private id_tercero As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private verror_cargue As String = "N"
    Private cargue_bloqueado As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private orowgrid As DataGridViewRow
    Private ocmb_grid As DataGridViewComboBoxCell
    Private otextgrid As DataGridViewTextBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell
    Private obuttongrid As DataGridViewButtonCell
    Private olinkcell As DataGridViewLinkCell

    Private otb_cargos As DataTable
    Private otb_cargos_grid As DataTable
    Private otb_empleados As DataTable
    Private doc_ed As Integer
    Private otipo_rel As String = ""

    Private Sub fm_0500_control_copias_accesos_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        otb_cargos = comunes.suministrar_otb_info_cargos(vg_id_cia, "S")
        otb_empleados = comunes.suministrar_otb_info_personal(vg_id_cia, "S")

        dg_cargos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_cargos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_cargos.AllowUserToAddRows = True
        dg_cargos.AllowUserToDeleteRows = True
        'otb_info_personal = comunes.suministrar_otb_info_personal(vg_id_cia, "S")
        'otb_personal_grillas = otb_info_personal.Copy
        With dgocell_cargo_cm_cargo
            'Valor que se muestra al usuario
            .DisplayMember = "f0240_cargo"
            'Valor interno que almacena el objeto
            .ValueMember = "f0240_id_cargo"
            'Origen de Datos del ComboBox
            .DataSource = otb_cargos
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        End With

        dg_personas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        dg_personas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dg_personas.AllowUserToAddRows = True
        dg_personas.AllowUserToDeleteRows = True
        With dgocell_personas_cm_nombre_funcionario
            'Valor que se muestra al usuario
            .DisplayMember = "nombre"
            'Valor interno que almacena el objeto
            .ValueMember = "f0200_id_tercero"
            'Origen de Datos del ComboBox
            .DataSource = otb_empleados
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        End With

        actualizar_grillas()
    End Sub
    Private Sub actualizar_grillas()
        csql = "SELECT f0505_id_documento, f0505_id_cargo, f0505_ubicacion, f0505_impreso, f0505_digital," ', f0240_cargo
        csql += " f0505_gest_registo, f0505_cargo_referenciado"
        csql += " FROM " & database.obtener_esquema & ".tb0505_copias_controladas_cargos"
        'csql += " join " & database.obtener_esquema & ".tb0240_cargos_compania on f0240_id_cargo = f0505_id_cargo"
        csql += " where f0505_id_documento = '" & id_documento & "' and f0505_id_cia = '" & vg_id_cia & "'"
        Dim otb_cargos_autorizados As DataTable
        'dg_cargos.Rows.Clear()
        otb_cargos_autorizados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_cargos_autorizados.Rows
            agregar_fila_control_Accesos(orow, dg_cargos, "f0240_cargo", "f0240_id_cargo", otb_cargos)
        Next

        csql = "SELECT f0506_id_documento, f0506_id_tercero,"
        csql += " f0506_ubicacion, f0506_impreso, f0506_digital,"
        csql += " f0506_gest_registo, f0506_cargo_referenciado"
        csql += " FROM " & database.obtener_esquema & ".tb0506_copias_controladas_funcionarios"
        csql += " join " & database.obtener_esquema & ".tb0200_terceros on f0200_id_tercero = f0506_id_tercero"
        csql += " where f0506_id_documento = '" & id_documento & "' and f0506_id_cia = '" & vg_id_cia & "'"
        'csql += " and "
        Dim otb_funcionarios_autorizados As DataTable
        'dg_personas.Rows.Clear()
        otb_funcionarios_autorizados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        For Each orow As DataRow In otb_funcionarios_autorizados.Rows
            agregar_fila_control_Accesos(orow, dg_personas, "nombre", "f0200_id_tercero", otb_empleados)
        Next
    End Sub
    Private Sub agregar_fila_control_Accesos(ByVal orow As DataRow, ByVal dg_grid As DataGridView,
                                             ByVal displaymem As String, ByVal valuemem As String, ByVal otb As DataTable)
        'Crea objeto fila del Datagridview
        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1 -- esta oculta
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item(1)
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2 -- esta oculta
        ocmb_grid = New DataGridViewComboBoxCell
        ocmb_grid.Value = orow.Item(1)
        With ocmb_grid
            'Valor que se muestra al usuario
            .DisplayMember = displaymem
            'Valor interno que almacena el objeto
            .ValueMember = valuemem
            'Origen de Datos del ComboBox
            .DataSource = otb
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        End With
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ocmb_grid)

        'Crea columna 3 -- esta oculta
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item(2)
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 4 -- esta oculta
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item(3) = "S" Then
            ochkgrid.Value = -1
        Else
            ochkgrid.Value = 0
        End If
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna 5 -- esta oculta
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item(4) = "S" Then
            ochkgrid.Value = -1
        Else
            ochkgrid.Value = 0
        End If
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna 6 -- esta oculta
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item(5) = "S" Then
            ochkgrid.Value = -1
        Else
            ochkgrid.Value = 0
        End If
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ochkgrid)

        'Crea columna 7 -- esta oculta
        ochkgrid = New DataGridViewCheckBoxCell
        If orow.Item(6) = "S" Then
            ochkgrid.Value = -1
        Else
            ochkgrid.Value = 0
        End If
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(ochkgrid)

        'Finalmente, agrega el objeto rowgrid (con todas las columnas llenas) al DatagridView
        dg_grid.Rows.Add(orowgrid)
    End Sub

    Private Sub dg_cargos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cargos.CellClick
        'MsgBox(dg_cargos.CurrentRow.Cells("dgocell_cargo_ubicacion").Value)
        id_cargo = dg_cargos.CurrentRow.Cells("dgocell_cargo_id_cargo").Value
    End Sub

    Private Sub dg_cargos_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dg_cargos.UserDeletingRow
        If Not MessageBox.Show("Desea borrar este registro?", "Borrando", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            e.Cancel = True
        Else
            borrar_copia_cargo()
        End If
    End Sub

    Private Sub dg_cargos_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dg_cargos.RowValidating
        If dg_cargos.CurrentRow.IsNewRow = True Then
            Exit Sub
        End If
        If dg_cargos.IsCurrentRowDirty = False Then
            Exit Sub
        End If

        verror_requisitos = "N"

        If IsNothing(dg_cargos.CurrentRow.Cells("dgocell_cargo_cm_cargo").Value) = True Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina un Cargo"
        Else
            dg_cargos.CurrentRow.Cells("dgocell_cargo_id_cargo").Value = dg_cargos.CurrentRow.Cells("dgocell_cargo_cm_cargo").Value
        End If

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Information, "Info")
            e.Cancel = True
        End If

        If dg_cargos.CurrentRow.IsNewRow = True Then
            grabar_nueva_copia_cargo()
        Else
            If id_cargo <> dg_cargos.CurrentRow.Cells("dgocell_cargo_cm_cargo").Value Then
                borrar_copia_cargo()
                id_cargo = dg_cargos.CurrentRow.Cells("dgocell_cargo_cm_cargo").Value
                grabar_nueva_copia_cargo()
            Else
                editar_copia_cargo()
            End If
        End If
    End Sub
    Private Sub grabar_nueva_copia_cargo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0505_copias_controladas_cargos" _
                & " (f0505_id_cia, f0505_id_documento, f0505_id_cargo," _
                & " f0505_ubicacion, f0505_impreso, f0505_digital, f0505_gest_registo, f0505_cargo_referenciado," _
                & " f0505_usuario_crear, f0505_usuario_modificar, f0505_fm)" _
                & " VALUES" _
                & " (@f0505_id_cia, @f0505_id_documento, @f0505_id_cargo," _
                & " @f0505_ubicacion, @f0505_impreso, @f0505_digital, @f0505_gest_registo, @f0505_cargo_referenciado," _
                & " @f0505_usuario_crear, @f0505_usuario_modificar, @f0505_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_copias_cargos(ocmd)

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

    Private Sub editar_copia_cargo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "UPDATE " & database.obtener_esquema & ".tb0505_copias_controladas_cargos SET"
        csql += " f0505_id_cia = @f0505_id_cia,"
        csql += " f0505_id_documento = @f0505_id_documento,"
        csql += " f0505_id_cargo = @f0505_id_cargo,"
        csql += " f0505_ubicacion = @f0505_ubicacion,"
        csql += " f0505_impreso = @f0505_impreso,"
        csql += " f0505_digital = @f0505_digital,"
        csql += " f0505_gest_registo = @f0505_gest_registo,"
        csql += " f0505_cargo_referenciado = @f0505_cargo_referenciado,"
        csql += " f0505_usuario_crear = @f0505_usuario_crear,"
        csql += " f0505_usuario_modificar = @f0505_usuario_modificar,"
        csql += " f0505_fm = @f0505_fm"
        csql += " where f0505_id_documento = @f0505_id_documento and f0505_id_cargo = @f0505_id_cargo"
        csql += " and f0505_id_cia = @f0505_id_cia"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_copias_cargos(ocmd)

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

    Private Sub crear_parametros_copias_cargos(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0505_id_documento", NpgsqlDbType.Integer).Value = id_documento
        ocmd.Parameters.Add("@f0505_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0505_id_cargo", NpgsqlDbType.Integer).Value = id_cargo

        If IsNothing(dg_cargos.CurrentRow.Cells("dgocell_cargo_ubicacion").Value) = True Then
            ocmd.Parameters.Add("@f0505_ubicacion", NpgsqlDbType.Varchar).Value = "ND"
            dg_cargos.CurrentRow.Cells("dgocell_cargo_ubicacion").Value = "ND"
        Else
            ocmd.Parameters.Add("@f0505_ubicacion", NpgsqlDbType.Varchar).Value = dg_cargos.CurrentRow.Cells("dgocell_cargo_ubicacion").Value.ToString.ToUpper()
        End If

        If dg_cargos.CurrentRow.Cells("dgocell_cargo_chk_c_controlada").Value = 0 Then
            ocmd.Parameters.Add("@f0505_impreso", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0505_impreso", NpgsqlDbType.Varchar).Value = "S"
        End If
        If dg_cargos.CurrentRow.Cells("dgocell_cargo_chk_c_digital").Value = 0 Then
            ocmd.Parameters.Add("@f0505_digital", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0505_digital", NpgsqlDbType.Varchar).Value = "S"
        End If
        'dgocell_cargo_chk_g_registro
        If dg_cargos.CurrentRow.Cells("dgocell_cargo_chk_g_registro").Value = 0 Then
            ocmd.Parameters.Add("@f0505_gest_registo", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0505_gest_registo", NpgsqlDbType.Varchar).Value = "S"
        End If
        If dg_cargos.CurrentRow.Cells("dgocell_cargo_chk_c_ferenciado").Value = 0 Then
            ocmd.Parameters.Add("@f0505_cargo_referenciado", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0505_cargo_referenciado", NpgsqlDbType.Varchar).Value = "S"
        End If
        ocmd.Parameters.Add("@f0505_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0505_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0505_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub

    Private Sub borrar_copia_cargo()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "DELETE FROM " & database.obtener_esquema & ".tb0505_copias_controladas_cargos"
        csql += " where f0505_id_documento = @f0505_id_documento and f0505_id_cargo = @f0505_id_cargo"
        csql += " and f0505_id_cia = @f0505_id_cia"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_copias_cargos(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0505_id_documento", NpgsqlDbType.Integer).Value = id_documento
        ocmd.Parameters.Add("@f0505_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0505_id_cargo", NpgsqlDbType.Integer).Value = id_cargo


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

    '------------------------------------- control de copias por terceros

    Private Sub dg_personas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_personas.CellClick
        id_tercero = dg_personas.CurrentRow.Cells("dgocell_personas_id_tercero").Value
    End Sub

    Private Sub dg_personas_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dg_personas.UserDeletingRow
        If Not MessageBox.Show("Desea borrar este registro?", "Borrando", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            e.Cancel = True
        Else
            borrar_copia_tercero()
        End If
    End Sub

    Private Sub dg_personas_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dg_personas.RowValidating
        If dg_personas.CurrentRow.IsNewRow = True Then
            Exit Sub
        End If
        If dg_personas.IsCurrentRowDirty = False Then
            Exit Sub
        End If

        verror_requisitos = "N"

        If IsNothing(dg_personas.CurrentRow.Cells("dgocell_personas_cm_nombre_funcionario").Value) = True Then
            verror_requisitos = "S"
            vmensaje_requisitos = "Defina un Funcionario"
        Else
            dg_personas.CurrentRow.Cells("dgocell_personas_id_tercero").Value = dg_personas.CurrentRow.Cells("dgocell_personas_cm_nombre_funcionario").Value
        End If

        If verror_requisitos = "S" Then
            MsgBox(vmensaje_requisitos, MsgBoxStyle.Information, "Info")
            e.Cancel = True
        End If

        If dg_personas.CurrentRow.IsNewRow = True Then
            grabar_nueva_copia_tercero()
        Else
            If id_tercero <> dg_personas.CurrentRow.Cells("dgocell_personas_cm_nombre_funcionario").Value Then
                borrar_copia_tercero()
                id_tercero = dg_personas.CurrentRow.Cells("dgocell_personas_cm_nombre_funcionario").Value
                grabar_nueva_copia_tercero()
            Else
                editar_copia_tercero()
            End If
        End If
    End Sub

    Private Sub grabar_nueva_copia_tercero()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0506_copias_controladas_funcionarios" _
                & " (f0506_id_cia, f0506_id_documento, f0506_id_tercero," _
                & " f0506_ubicacion, f0506_impreso, f0506_digital, f0506_gest_registo, f0506_cargo_referenciado," _
                & " f0506_usuario_crear, f0506_usuario_modificar, f0506_fm)" _
                & " VALUES" _
                & " (@f0506_id_cia, @f0506_id_documento, @f0506_id_tercero," _
                & " @f0506_ubicacion, @f0506_impreso, @f0506_digital, @f0506_gest_registo, @f0506_cargo_referenciado," _
                & " @f0506_usuario_crear, @f0506_usuario_modificar, @f0506_fm)"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_copias_terceros(ocmd)

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

    Private Sub editar_copia_tercero()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "UPDATE " & database.obtener_esquema & ".tb0506_copias_controladas_funcionarios SET"
        csql += " f0506_id_cia = @f0506_id_cia,"
        csql += " f0506_id_documento = @f0506_id_documento,"
        csql += " f0506_id_tercero = @f0506_id_tercero,"
        csql += " f0506_ubicacion = @f0506_ubicacion,"
        csql += " f0506_impreso = @f0506_impreso,"
        csql += " f0506_digital = @f0506_digital,"
        csql += " f0506_gest_registo = @f0506_gest_registo,"
        csql += " f0506_cargo_referenciado = @f0506_cargo_referenciado,"
        csql += " f0506_usuario_crear = @f0506_usuario_crear,"
        csql += " f0506_usuario_modificar = @f0506_usuario_modificar,"
        csql += " f0506_fm = @f0506_fm"
        csql += " where f0506_id_documento = @f0506_id_documento and f0506_id_tercero = @f0506_id_tercero"
        csql += " and f0506_id_cia = @f0506_id_cia"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        crear_parametros_copias_terceros(ocmd)

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

    Private Sub crear_parametros_copias_terceros(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0506_id_documento", NpgsqlDbType.Integer).Value = id_documento
        ocmd.Parameters.Add("@f0506_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0506_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero

        If IsNothing(dg_personas.CurrentRow.Cells("dgocell_personas_ubicacion").Value) = True Then
            ocmd.Parameters.Add("@f0506_ubicacion", NpgsqlDbType.Varchar).Value = "ND"
            dg_personas.CurrentRow.Cells("dgocell_personas_ubicacion").Value = "ND"
        Else
            ocmd.Parameters.Add("@f0506_ubicacion", NpgsqlDbType.Varchar).Value = dg_personas.CurrentRow.Cells("dgocell_personas_ubicacion").Value.ToString.ToUpper()
        End If

        If dg_personas.CurrentRow.Cells("dgocell_perosnas_chk_c_controlada").Value = 0 Then
            ocmd.Parameters.Add("@f0506_impreso", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0506_impreso", NpgsqlDbType.Varchar).Value = "S"
        End If
        If dg_personas.CurrentRow.Cells("dgocell_personas_chk_c_digital").Value = 0 Then
            ocmd.Parameters.Add("@f0506_digital", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0506_digital", NpgsqlDbType.Varchar).Value = "S"
        End If
        If dg_personas.CurrentRow.Cells("dgocell_perosnas_chk_g_registro").Value = 0 Then
            ocmd.Parameters.Add("@f0506_gest_registo", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0506_gest_registo", NpgsqlDbType.Varchar).Value = "S"
        End If
        If dg_personas.CurrentRow.Cells("dgocell_personas_chk_c_ferenciado").Value = 0 Then
            ocmd.Parameters.Add("@f0506_cargo_referenciado", NpgsqlDbType.Varchar).Value = "N"
        Else
            ocmd.Parameters.Add("@f0506_cargo_referenciado", NpgsqlDbType.Varchar).Value = "S"
        End If
        ocmd.Parameters.Add("@f0506_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0506_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0506_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
    End Sub

    Private Sub borrar_copia_tercero()
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "DELETE FROM " & database.obtener_esquema & ".tb0506_copias_controladas_funcionarios"
        csql += " where f0506_id_documento = @f0506_id_documento and f0506_id_tercero = @f0506_id_tercero"
        csql += " and f0506_id_cia = @f0506_id_cia"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_copias_cargos(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("@f0506_id_documento", NpgsqlDbType.Integer).Value = id_documento
        ocmd.Parameters.Add("@f0506_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0506_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero


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
End Class
