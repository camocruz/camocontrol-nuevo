Public Class cl_utilidades_gestion_mantenimiento
    Public Shared Sub actualizar_maquina_padre_de_las_maquinas()
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0100_estructura_mantenimiento set"
        csql += " f0100_id_maquina_padre = f0100_id_estructura"
        csql += " where f0100_id_tipo_estructura = '00000003'"

        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_grabar_elemento_mantenimiento(ocmd)
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
    Public Shared Sub actualizar_estructura_padre(ByVal id_cia As String)
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0100_estructura_mantenimiento set"
        csql += " f0100_estructura_padre = coalesce((string_to_array(f0100_path,'-'))[array_length((string_to_array(f0100_path,'-')),1) - 1]::int,0)"
        csql += " where f0100_id_cia = '" & id_cia & "'"

        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_grabar_elemento_mantenimiento(ocmd)
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
    Public Shared Sub actualizar_hijos_de_maquinas(ByVal id_cia As String)
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "WITH maquinas AS (" _
          & "select * from camocontrol.tb0100_estructura_mantenimiento" _
          & " where f0100_id_tipo_estructura = '00000003' and f0100_id_cia = '" & id_cia & "'" _
          & ")" _
          & " update camocontrol.tb0100_estructura_mantenimiento set" _
          & " f0100_id_maquina_padre = maquinas.f0100_id_estructura," _
          & " f0100_codigo = maquinas.f0100_codigo || '-' || tb0100_estructura_mantenimiento.f0100_id_estructura" _
          & " from maquinas" _
          & " where substring(tb0100_estructura_mantenimiento.f0100_path || tb0100_estructura_mantenimiento.f0100_id_estructura || '-' from 1 for length(maquinas.f0100_path || maquinas.f0100_id_estructura || '-' )) = maquinas.f0100_path || maquinas.f0100_id_estructura || '-'" _
          & " and tb0100_estructura_mantenimiento.f0100_id_tipo_estructura <> '00000003';"

        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_grabar_elemento_mantenimiento(ocmd)
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            'ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un Error al Compilar comando! " + ex.ToString)
        End Try
        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un Error al Actualizar ! " + vbCrLf + ex.ToString)
            End Try
        End If
        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Public Shared Sub recover_elementos_maquina_ppal1(ByVal vg_id_cia As String)
        'Recalcula los elemntos que pertencen a las maquinas de la compañia.
        Dim csql As String
        csql = "Select *" _
            & " FROM " & database.obtener_esquema & ".tb0100_estructura_mantenimiento" _
            & " where f0100_id_tipo_estructura = '00000003' and f0100_id_cia = '" & vg_id_cia & "'"
        Dim otb_maquinas As DataTable
        otb_maquinas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        If otb_maquinas.Rows.Count > 0 Then
            Dim path_maquina As String
            For Each orow As DataRow In otb_maquinas.Rows
                path_maquina = orow("f0100_path") & orow("f0100_id_estructura") & "-"
                cl_utilidades_gestion_mantenimiento.recover_elementos_maquina_secundario2(orow("f0100_id_estructura"), path_maquina)
            Next
        End If
    End Sub
    Public Shared Sub recover_elementos_maquina_secundario2(ByVal id_maquina_padre As Integer, ByVal path_maquina_padre As String)
        'Actualiza los elementos a una determinada maquina.
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0100_estructura_mantenimiento set "
        csql += "f0100_id_maquina_padre = '" & id_maquina_padre & "'"
        csql += " where substring(f0100_path || f0100_id_estructura || '-' from 1 for " & Len(path_maquina_padre) & ") = '" & path_maquina_padre & "'"
        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_grabar_elemento_mantenimiento(ocmd)
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
    Public Shared Sub recetear_elementos_maquina2()
        Dim csql As String
        Dim oconn_form As NpgsqlConnection
        Dim verror As String = "N"
        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()
        'actualizacion parametrizada
        csql = "update " + database.obtener_esquema + ".tb0100_estructura_mantenimiento set "
        csql += "f0100_id_maquina_padre = NULL"

        Dim ocmd As New NpgsqlCommand(csql, oconn_form)
        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_grabar_elemento_mantenimiento(ocmd)
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
    Public Shared Function suministrar_estructura_mantenimiento(ByVal vg_id_cia As String,
                                                  ByVal vg_usuario_autoriza As String,
                                                  Optional id_estructura_base As Integer = 0)
        Dim id_estructura As String = ""
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_estructura As New camocontrol.fm_0100_estructura_mantenimiento_identificador
        'oform_grilla_programacion.ods_hijo = ods
        oform_estructura.vg_id_cia = vg_id_cia
        If id_estructura_base <> 0 Then
            oform_estructura.id_estructura = id_estructura_base
        End If
        oform_estructura.vg_usuario_autoriza = vg_usuario_autoriza
        oform_estructura.ShowDialog()
        id_estructura = oform_estructura.id_estructura
        oform_estructura.Close()
        Return id_estructura
    End Function

End Class
