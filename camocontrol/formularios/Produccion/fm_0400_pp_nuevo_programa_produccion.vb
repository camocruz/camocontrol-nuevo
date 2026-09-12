Public Class fm_0400_pp_nuevo_programa_produccion
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_prog_prod As Integer
    Public id_item_clonar As Integer 'Es el id del item padre de todo el arbol
    Public id_item_pp As Integer 'el f0401_id_ipp de un programa de produccion.
    Public tree_path_base As String
    Public nodo_buscar As String = ""

    Public proceder_edicion_ipp As String
    ' DIV = La ipp se dividira en varias ipps diferentes
    ' MOD = La ipp solo modificara sus valores
    Public otb_edicion As DataTable 'Datatable que almacenara los datos de edicion del IPP

    Private otipo_nota As String

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private otb_items_plantillas As DataTable
    Private otb_plantillas As DataTable
    Private otb_items_programa_produccion As DataTable
    Private otb_reportes_produccion As DataTable

    Private path_estructura_filtrado As String = ""
    Private id_estructura_padre_filtrado As Integer


    Private tipo_registro As String
    Private numero_registro As Integer = 0
    Private filtro_rama As String = "N"
    Private cantidad_dimanica As Decimal 'Cantidad que usare para asignar cantidad de items de acuerdo a recorrido por treeview
    Private cantidad_produccion As Decimal  'Cantidad requerida en un OP
    Private fecha_op_inicio As Date
    Private fecha_op_final As Date
    Private id_item_seleccionado_tree As Integer 'El id_item del nodo seleccionado
    Public name_nodo_creado As String
    Private id_ipp_nodo_padre As String 'el id_ipp del nodo inicial de un ramal del arbol
    Private item_principal_seleccionado_tree As String = "N"

    Private Sub fm_0400_pp_nuevo_programa_produccion_Load(sender As Object, e As EventArgs) Handles Me.Load
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

    Private Function nuevo_encabezado_prog_prod() As Integer
        'RETURNING Permite obtener el ID sin hacer otra consulta.
        'Se puede usar asi:
        'Dim idNuevo As Integer = nuevo_encabezado_prog_prod()
        Dim fechaAct As Date = comunes.g_fechahora

        Dim sql As String =
    $"INSERT INTO {database.obtener_esquema}.tb0400_programa_produccion
      (f0400_id_cia, f0400_nombre, f0400_fecha_inicio, f0400_fecha_final,
       f0400_usuario_modificar, f0400_usuario_crear, f0400_fm)
     VALUES
      (@id_cia, @nombre, @fecha_inicio, @fecha_final,
       @usuario_modificar, @usuario_crear, @fm)
     RETURNING f0400_id_pp;"

        Try
            Using conn As NpgsqlConnection = database.obtener_conexion(),
              cmd As New NpgsqlCommand(sql, conn)

                cmd.Parameters.Add("@id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
                cmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar).Value = tx_nombre.Text
                cmd.Parameters.Add("@fecha_inicio", NpgsqlDbType.Timestamp).Value = dtp_f_ini.Value
                cmd.Parameters.Add("@fecha_final", NpgsqlDbType.Timestamp).Value = dtp_f_fin.Value
                cmd.Parameters.Add("@usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
                cmd.Parameters.Add("@usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
                cmd.Parameters.Add("@fm", NpgsqlDbType.Timestamp).Value = fechaAct

                cmd.Prepare()

                ' Ejecuta y obtiene el ID insertado
                Dim nuevoId As Integer = CInt(cmd.ExecuteScalar())
                Return nuevoId

            End Using

        Catch ex As Exception
            MsgBox("Error al insertar encabezado del programa de producción:" & vbCrLf &
               ex.Message & vbCrLf &
               "SQL: " & sql)
            Return -1
        End Try

    End Function

    Private Sub bt_grabar_Click(sender As Object, e As EventArgs) Handles bt_grabar.Click
        'Validar que el nombre del programa de producción no esté vacío
        If String.IsNullOrWhiteSpace(tx_nombre.Text) Then
            MsgBox("El nombre del programa de producción no puede estar vacío.", MsgBoxStyle.Exclamation, "Validación")
            Return
        End If

        nuevo_encabezado_prog_prod()
        Me.Dispose()
    End Sub
End Class
