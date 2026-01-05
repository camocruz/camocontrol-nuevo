Public Class fm_0200_tercero_sucursal
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    Public id_tercero As String
    '$Public$vf_elemento_nuevo As String = "N"

    ' Propiedad pública para devolver el valor de ciudad, direccion
    Private _resultado As DtoTercero
    Public ReadOnly Property Resultado As DtoTercero
        Get
            Return _resultado
        End Get
    End Property




    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private verror_grabar As String = ""
    Private vexiste As String = "N"
    Private verror As String = "N"

    Private id_punto_entrega As Integer
    Private id_ciudad_punto As String = ""
    Private direccion_punto As String = ""

    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell
    Private ochkgrid As DataGridViewCheckBoxCell

    Private orow_tercero As DataRow
    Private otb_ciudades As DataTable
    Private otb_puntos_entrega As DataTable

    Private eliminar_dgrow As String = "N"
    Private index_dgrow_eliminar As Integer


    Private Sub fm_0200_tercero_sucursal_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        'vf_var_config_archivos = "CD-ITM"
        'vf_var_config_notas = "TN-ITM-001"
        vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        vf_elemento_nuevo = "N"
        'cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo,
        '                                                       vg_usuario_autoriza, Me,
        '                                                       vf_id_notas_archivos, vf_otipo_nota,
        '                                                       vf_var_config_archivos)

        'MsgBox(vf_elemento_nuevo)
        'gestiono_permisos_basicos
        'cl_gestion_permisos.gestionar_permisos_botones_basicos(vg_id_cia, vf_otabla_permisos, vf_elemento_nuevo, vg_usuario_autoriza, Me)

        csql = "select f0052_codigo_ciudad, f0052_ciudad || ' - ' || f0051_departamento as ciudad" _
            & " from " & database.obtener_esquema & ".tb0052_ciudades" _
            & " join " & database.obtener_esquema & ".tb0051_departamentos" _
            & " on f0051_codigo_departamento = f0052_codigo_departamento" _
            & " order By ciudad"
        otb_ciudades = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        With cm_ciudad
            'Valor que se muestra al usuario
            .DisplayMember = "ciudad"
            'Valor interno que almacena el objeto
            .ValueMember = "f0052_codigo_ciudad"
            'Origen de Datos del ComboBox
            .DataSource = otb_ciudades
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.SelectedIndex = -1
        End With
        'cargamos la informacion de la sucursal.
        If id_tercero <> 0 Then
            csql = "select * from " & database.obtener_esquema & ".tb0200_terceros" _
                & " where f0200_id_cia = '" & vg_id_cia & "' and f0200_id_tercero = '" & id_tercero & "'"
            Dim otb_tercero As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            For Each orow As DataRow In otb_tercero.Rows
                orow_tercero = orow
            Next
            'MsgBox(id_tercero & " - " & otb_tercero.Rows.Count & " -- " & orow_tercero("f0200_ciudad_nacimiento"))
            tx_id_tercero.Text = id_tercero
            tx_nombre.Text = orow_tercero("f0200_nombres")
            tx_direccion.Text = orow_tercero("f0200_direccion_residencia").ToString
            cm_ciudad.SelectedValue = orow_tercero("f0200_ciudad_residencia")
            tx_notas_varias.Text = orow_tercero("f0200_notas_varias")
            tx_nombre_contacto.Text = orow_tercero("f0200_nombre_contacto")
            tx_telefono_fijo.Text = orow_tercero("f0200_telefono_fijo")
            tx_celular.Text = orow_tercero("f0200_telefono_celular")
            tx_email.Text = orow_tercero("f0200_correo_electronico")

        End If
    End Sub


    Private Sub agregar_fila_dg_puntos(ByVal orow As DataRow)

        'Crea objeto fila del Datagridview
        orowgrid = New DataGridViewRow

        'Crea columna 1
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = CInt(orow.Item("f0202_id_punto_entrega"))
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 2
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("ciudad")
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 3
        otextgrid = New DataGridViewTextBoxCell
        otextgrid.Value = orow.Item("f0202_direccion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        orowgrid.Cells.Add(otextgrid)

        'Crea columna 13
        'otextgrid = New DataGridViewTextBoxCell
        'CDate(tx_fecha_hora.Text).ToString("yyyy/MM/dd")
        'otextgrid.Value = orow.Item("f0700_observacion").ToString
        'otextgrid.MaxInputLength = 100
        'Agrega columna al objeto fila
        'orowgrid.Cells.Add(otextgrid)

    End Sub

    Private Sub grabar_nuevo_punto()

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "insert into " + database.obtener_esquema + ".tb0202_sucursales_puntos_entrega" _
            & " (" _
            & " f0202_id_cia, f0202_id_tercero, f0202_id_ciudad, f0202_direccion," _
            & " f0202_fm, f0202_usuario_crear," _
            & " f0202_usuario_modificar" _
            & ") values" _
            & " (" _
            & " @f0202_id_cia, @f0202_id_tercero, @f0202_id_ciudad, @f0202_direccion," _
            & " @f0202_fm, @f0202_usuario_crear," _
            & " @f0202_usuario_modificar" _
            & ")"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0202_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0202_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0202_id_ciudad", NpgsqlDbType.Varchar).Value = id_ciudad_punto
        ocmd.Parameters.Add("f0202_direccion", NpgsqlDbType.Varchar).Value = direccion_punto
        ocmd.Parameters.Add("f0202_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("f0202_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0202_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! grabando tercero" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error grabando punto" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub crear_parametros_tb_terceros(ByVal ocmd As NpgsqlCommand)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0202_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0202_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0202_id_ciudad", NpgsqlDbType.Varchar).Value = id_ciudad_punto
        ocmd.Parameters.Add("f0202_direccion", NpgsqlDbType.Varchar).Value = direccion_punto
        ocmd.Parameters.Add("f0202_id_punto_entrega", NpgsqlDbType.Integer).Value = id_punto_entrega
        ocmd.Parameters.Add("f0202_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("f0202_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0202_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
    End Sub

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        Dim respuesta As String = "N"
        respuesta = comunes.g_mensaje_YesNo("Actualizar Sucursal", "Desea Actualizar la Sucursal?")
        If respuesta = "N" Then
            Exit Sub
        End If
        actualizar_tercero()
        If verror = "N" Then
            'Asigno los valores a la propiedad Resultado para devolverlos al formulario padre
            _resultado = New DtoTercero With {
                .Id_tercero = id_tercero,
                .Ciudad = cm_ciudad.Text,
                .Id_Ciudad = cm_ciudad.SelectedValue.ToString(),
                .Direccion = tx_direccion.Text
            }
            MsgBox("Actualizado", MsgBoxStyle.Information, "Actualizar")
            Me.DialogResult = DialogResult.OK
            vcerrar = "S"
            Me.Close()
        Else
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub actualizar_tercero()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0200_terceros set" _
            & " f0200_nombres = @f0200_nombres," _
            & " f0200_ciudad_residencia = @f0200_ciudad_residencia," _
            & " f0200_direccion_residencia = @f0200_direccion_residencia," _
            & " f0200_notas_varias = @f0200_notas_varias," _
            & " f0200_nombre_contacto = @f0200_nombre_contacto," _
            & " f0200_telefono_fijo = @f0200_telefono_fijo," _
            & " f0200_telefono_celular = @f0200_telefono_celular," _
            & " f0200_correo_electronico = @f0200_correo_electronico," _
            & " f0200_fm = @f0200_fm," _
            & " f0200_usuario_modificar = @f0200_usuario_modificar" _
            & " where f0200_id_tercero = @f0200_id_tercero"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_nombres", NpgsqlDbType.Varchar).Value = tx_nombre.Text
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0200_ciudad_residencia", NpgsqlDbType.Varchar).Value = cm_ciudad.SelectedValue
        ocmd.Parameters.Add("f0200_direccion_residencia", NpgsqlDbType.Varchar).Value = tx_direccion.Text
        ocmd.Parameters.Add("f0200_notas_varias", NpgsqlDbType.Varchar).Value = tx_notas_varias.Text
        ocmd.Parameters.Add("f0200_nombre_contacto", NpgsqlDbType.Varchar).Value = tx_nombre_contacto.Text
        ocmd.Parameters.Add("f0200_telefono_fijo", NpgsqlDbType.Varchar).Value = tx_telefono_fijo.Text
        ocmd.Parameters.Add("f0200_telefono_celular", NpgsqlDbType.Varchar).Value = tx_celular.Text
        ocmd.Parameters.Add("f0200_correo_electronico", NpgsqlDbType.Varchar).Value = tx_email.Text

        ocmd.Parameters.Add("f0200_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora
        ocmd.Parameters.Add("f0200_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0200_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza

        verror = "N"
        Try
            ocmd.ExecuteNonQuery()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Actualizar Tercero! " + vbCrLf + ex.ToString)
        End Try
    End Sub

    Private Sub bt_editar_Click(sender As Object, e As EventArgs) Handles bt_editar.Click
        bt_grabar.Enabled = True
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click

    End Sub
End Class
