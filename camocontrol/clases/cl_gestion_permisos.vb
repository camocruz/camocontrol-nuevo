Public Class cl_gestion_permisos
    Dim ocmd As NpgsqlCommand ' objeto que va a contener el o los comandos a ejecutar tipo postgresql
    Dim oconexion As NpgsqlConnection ' objeto que va a contener la conexion a postgresql
    Dim odr As NpgsqlDataReader ' objeto data reader donde se guardan los registros que trae un select
    Dim vexiste As String = "N" 'variable bandera para saber si un select trajo o no datos
    Dim ocmd1 As NpgsqlCommand
    Dim vf_otabla_permisos As DataTable
    Private oconn_form As NpgsqlConnection
    Private csql As String = ""
    Private verror As String = ""
    Private vusuario As String = ""
    Public Shared Function todas_opciones_de_control()
        Dim csql As String
        Dim otb_controles_controlados As DataTable
        csql = "SELECT *" _
        + " FROM " + database.obtener_esquema + ".tb0020_opciones_control order by f0020_codigo"
        otb_controles_controlados = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Return otb_controles_controlados
    End Function
    Public Shared Sub activar_control_si_tiene_permiso(vf_otabla_permisos As DataTable,
                                                         name_form As String, ctrl As Control, ocontexto_form As String)
        Dim controlado As String = "N"
        Dim autorizado As String = "N"
        Dim permitir As String = "N"
        Dim otb_controles_controlados As DataTable
        Dim octrlaut As Boolean = True
        Dim vusuario As String
        vusuario = camocontrol.formulario_inicio.vlogin2.Trim 'el usuario actual del software
        otb_controles_controlados = camocontrol.formulario_inicio.otb_controles_controlados
        Dim name_control As String = ctrl.Name
        Dim controles_controlados() As DataRow = otb_controles_controlados.Select("f0020_formulario = '" & name_form & "' and f0020_control = '" & name_control & "'")
        If controles_controlados.Length >= 1 Then
            controlado = "S"
            'MsgBox("Controlado: " & controlado)
        End If
        Dim controles_autorizados() As DataRow = vf_otabla_permisos.Select("f0020_formulario = '" & name_form & "'" _
                                                                        & " and f0020_control = '" & name_control & "'" _
                                                                        & " and f0022_acceso = " & octrlaut _
                                                                        & " and f0020_contexto = '" & ocontexto_form & "'")
        If controles_autorizados.Length >= 1 Then
            autorizado = "S"
            'MsgBox("Autorizado: " & autorizado)
        End If
        If controlado = "S" Then
            If autorizado = "N" Then
                permitir = "N"
            Else
                permitir = "S"
            End If
        Else
            permitir = "S"
        End If
        If CInt(vusuario.Trim).ToString = "1" Then
            permitir = "S"
        End If
        'MsgBox("Permitir: " & permitir)
        If permitir = "S" Then
            If ctrl.GetType().Name.ToString = "CheckBox" Then
                'MsgBox(ctrl.Name)
                ctrl.Enabled = True
            End If
            If ctrl.GetType().Name.ToString = "Button" Then
                'MsgBox(ctrl.Name)
                ctrl.Enabled = True
            End If
            If ctrl.GetType().Name.ToString = "DataGridView" Then
                'MsgBox(ctrl.Name)
                Dim a As DataGridView = ctrl
                a.ReadOnly = False
            End If
            If ctrl.GetType().Name.ToString = "MenuStrip" Then
                Dim a As MenuStrip = ctrl
                a.Enabled = True
            End If
        Else
            If ctrl.GetType().Name.ToString = "CheckBox" Then
                'MsgBox(ctrl.Name)
                ctrl.Enabled = False
            End If
            If ctrl.GetType().Name.ToString = "Button" Then
                'MsgBox(ctrl.Name)
                ctrl.Enabled = False
            End If
            If ctrl.GetType().Name.ToString = "DataGridView" Then
                'MsgBox(ctrl.Name)
                Dim a As DataGridView = ctrl
                a.ReadOnly = True
            End If
            If ctrl.GetType().Name.ToString = "MenuStrip" Then
                Dim a As MenuStrip = ctrl
                a.Enabled = False
            End If
        End If
        'Return permitir
    End Sub
    Public Shared Function todas_opciones()
        Dim olistaopciones As New List(Of cl_opciones)()
        Dim csql As String = ""
        Dim odr As NpgsqlDataReader
        Dim vexiste As String = "N"
        csql = "SELECT *" _
        + " FROM " + database.obtener_esquema + ".tb0020_opciones_control order by f0020_codigo"

        odr = database.get_data_reader(csql)
        vexiste = "N"
        While odr.Read
            vexiste = "S"
            olistaopciones.Add(New cl_opciones() With {
            .codigo = odr.Item("f0020_codigo"),
            .formulario = odr.Item("f0020_formulario"),
            .control = odr.Item("f0020_control") _
            .contexto = odr.Item("f0020_contexto")
            })
        End While
        odr.Close()
        Return olistaopciones
    End Function
    Public Shared Function identificar_permisos_usuario(ByVal vusuario As String, ByVal formulario As String, ocontexto_form As String)
        Dim vf_otabla_permisos As DataTable
        Dim oconn_form As NpgsqlConnection
        'crea el dataset de los permisos de usuario, se puede especificar el formulario
        Dim csql As String = ""
        Dim sel As String
        If formulario = "" Then
            sel = ""
            'sel = " where tb_usuarios_permiso.usuario = '" + vusuario + "'"
        Else
            sel = " where tb0020_opciones_control.f0020_formulario = '" & formulario.Trim & "'" ' and f0020_contexto = '" & ocontexto_form & "'"
            'sel = " where usuario = '" + vusuario + "' and tb_opciones.formulario = '" & formulario & "'"
        End If
        csql = "select * from " & database.obtener_esquema & ".tb0020_opciones_control" _
        & " left join " & database.obtener_esquema & ".tb0022_usuarios_permiso" _
        & " on tb0020_opciones_control.f0020_codigo = tb0022_usuarios_permiso.f0022_codigo and tb0022_usuarios_permiso.f0022_id_usuario='" & vusuario.Trim & "'" _
        & sel & "order by f0020_codigo"

        'csql = "select tb_usuarios_permiso.usuario, tb_usuarios_permiso.id_opcion, tb_opciones.formulario," _
        '& " tb_opciones.control from " & database.obtener_esquema & ".tb_usuarios_permiso" _
        '& " inner join " & database.obtener_esquema & ".tb_opciones ON tb_usuarios_permiso.id_opcion = tb_opciones.codigo" _
        '& sel

        oconn_form = database.obtener_conexion()

        'Define un DataAdapter que va a ser un enlace con la Base de Datos (Imagen de la Base de datos en memoria)
        Dim oda As New NpgsqlDataAdapter(csql, oconn_form)
        'Define DataSet que es una representación en Memoria de las tablas de la Base de Datos
        Dim ods As New DataSet
        'Si ya existe el Data Table creado, lo borra
        If ods.Tables.Contains("permisos") Then
            ods.Tables("permisos").Clear()
        End If

        'Llenamos el dataAdapter con el query definido arriba, y le damos nombre a la tabla que se creará en memoria
        oda.Fill(ods, "permisos")

        vf_otabla_permisos = ods.Tables("permisos")
        'MsgBox(otabla.Rows.Count)
        oconn_form.Close()
        Return vf_otabla_permisos
    End Function
    Public Shared Function identificar_un_permiso_especial_usuario(ByVal nombre_permiso As String,
                                                                   ByVal vg_usuario_autoriza As String)
        Dim permiso As String = "N"
        Dim csql As String
        csql = "select * from " & database.obtener_esquema & ".tb0020_opciones_control" _
        & " join " & database.obtener_esquema & ".tb0022_usuarios_permiso" _
        & " on tb0020_opciones_control.f0020_codigo = tb0022_usuarios_permiso.f0022_codigo and tb0022_usuarios_permiso.f0022_id_usuario='" & vg_usuario_autoriza.Trim & "'" _
        & " where f0020_control = '" & nombre_permiso & "'"
        Dim otabla As DataTable
        otabla = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otabla.Rows.Count = 1 Then
            permiso = "S"
        End If
        Return permiso
    End Function
    Public Shared Function identificar_permisos_especiales_formularios(ByVal nombre_permiso As String,
                                                                       ByVal vf_otabla_permisos As DataTable,
                                                                       ByVal vg_usuario_autoriza As String)
        Dim orow_permiso As DataRow()
        Dim autorizado As String = "N"
        If vg_usuario_autoriza = "00000001" Then
            autorizado = "S"
            Return autorizado
            Exit Function
        End If
        Dim criteria As String = "f0020_control = '" & nombre_permiso & "'"
        'MsgBox(criteria)
        orow_permiso = vf_otabla_permisos.Select(criteria)
        If orow_permiso.Length = 0 Then
            Return autorizado
            Exit Function
        End If
        'cl_utilidades_datatables.visualizar_datos_visor("", "", "", "", {}, vf_otabla_permisos)
        If IsDBNull(orow_permiso(0)("f0022_acceso")) = False Then
            autorizado = "S"
        End If
        Return autorizado
    End Function

    'Esta funcion se usa cuendo estan definido el vf_id_notas_archivos de lo contrario se deben
    'inhabilitar los botones basicos por codigo en el formulario.
    'Lo que ocurre es que el boton grabar no se habilita.
    Public Shared Sub gestionar_permisos_botones_basicos(ByVal vg_id_cia As String,
                                                         ByVal vf_otabla_permisos As DataTable,
                                                         ByVal vf_elemento_nuevo As String,
                                                         ByVal vg_usuario_autoriza As String,
                                                         ByVal formulario As Object,
                                                         Optional vf_id_notas_archivos As String = "",
                                                         Optional tipo_nota As String = "",
                                                         Optional vf_var_config_archivos As String = "")
        Dim P_grabar As String = "N"
        Dim P_editar As String = "N"
        Dim P_nuevos_r As String = "N"
        Dim P_anular As String = "N"
        Dim P_generar_reporte As String = "N"
        Dim P_consultar_notas_propias As String = "N"
        Dim P_consultar_total_notas As String = "N"
        Dim P_exportar_info_notas As String = "N"
        Dim P_consultar_archivos_propios As String = "N"
        Dim P_consultar_total_archivos As String = "N"
        'MsgBox("dentro de permisos vf_nuevo: " & vf_elemento_nuevo)
        'Identifico permisos basicos de gestion de registros
        P_editar = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_editar", vf_otabla_permisos, vg_usuario_autoriza)
        Dim btn_editar = formulario.controls.find("bt_editar", True)
        P_grabar = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_grabar", vf_otabla_permisos, vg_usuario_autoriza)
        Dim btn_grabar = formulario.controls.find("bt_grabar", True)
        P_nuevos_r = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_nuevo", vf_otabla_permisos, vg_usuario_autoriza)
        Dim btn_nuevos_r = formulario.controls.find("bt_nuevo", True)
        P_anular = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_anular", vf_otabla_permisos, vg_usuario_autoriza)
        Dim btn_anular = formulario.controls.find("bt_anular", True)
        P_generar_reporte = cl_gestion_permisos.identificar_permisos_especiales_formularios("bt_generar_informe", vf_otabla_permisos, vg_usuario_autoriza)
        Dim btn_generar_reporte = formulario.controls.find("bt_generar_informe", True)
        P_consultar_notas_propias = cl_gestion_permisos.identificar_permisos_especiales_formularios("CONS_PROP_NOTAS", vf_otabla_permisos, vg_usuario_autoriza)
        P_consultar_total_notas = cl_gestion_permisos.identificar_permisos_especiales_formularios("CONS_TOT_NOTAS", vf_otabla_permisos, vg_usuario_autoriza)
        Dim btn_gestionar_notas = formulario.controls.find("bt_g_notas", True)
        P_consultar_archivos_propios = cl_gestion_permisos.identificar_permisos_especiales_formularios("CONS_PROP_ARCHIVO", vf_otabla_permisos, vg_usuario_autoriza)
        P_consultar_total_archivos = cl_gestion_permisos.identificar_permisos_especiales_formularios("CONS_TOT_ARCHIVO", vf_otabla_permisos, vg_usuario_autoriza)
        Dim btn_gestionar_archivos = formulario.controls.find("bt_g_archivos", True)
        'MsgBox("HOLA permiso: " & P_consultar_archivos_propios & " - " & P_anular)
        btn_grabar(0).Enabled = False
        btn_editar(0).Enabled = False
        If P_editar = "S" Then
            'MsgBox("Hola1")
            'MsgBox(vf_id_notas_archivos.Trim)
            If vf_id_notas_archivos.Trim <> "" And vf_id_notas_archivos <> "0" Then
                btn_editar(0).Enabled = True
                'MsgBox("Hola2")
            End If
        End If
        'MsgBox("vf_elemento_nuevo: " & P_nuevos_r)
        If P_nuevos_r = "S" Then
            btn_nuevos_r(0).Enabled = True
            If vf_elemento_nuevo = "S" Then
                btn_grabar(0).Enabled = True
            End If
        End If
        If vf_elemento_nuevo = "S" Then
            btn_nuevos_r(0).enabled = False
            btn_anular(0).enabled = False
            btn_generar_reporte(0).Enabled = False
            btn_gestionar_archivos(0).enabled = False
            btn_gestionar_notas(0).enabled = False
        Else
            If P_nuevos_r = "S" Then
                btn_nuevos_r(0).enabled = True
            Else
                btn_nuevos_r(0).enabled = False
            End If
            If P_anular = "S" Then
                btn_anular(0).enabled = True
            Else
                btn_anular(0).enabled = False
            End If
            If P_generar_reporte = "S" Then
                btn_generar_reporte(0).Enabled = True
            Else
                btn_generar_reporte(0).Enabled = False
            End If
            If P_consultar_archivos_propios = "S" Or P_consultar_total_archivos = "S" Then
                btn_gestionar_archivos(0).enabled = True
            Else
                btn_gestionar_archivos(0).enabled = False
            End If
            If P_consultar_notas_propias = "S" Or P_consultar_total_notas = "S" Then
                btn_gestionar_notas(0).enabled = True
            Else
                btn_gestionar_notas(0).enabled = False
            End If
        End If
        'MsgBox(tipo_nota)
        If tipo_nota <> "" And vf_id_notas_archivos <> "" Then
            btn_gestionar_notas(0).Text = cl_gestion_anotaciones.calcular_cantidad_notas_asociadas(tipo_nota, vf_id_notas_archivos, vg_id_cia)
            'MsgBox("calcula: " & btn_gestionar_notas(0).Text)
        End If
        'MsgBox(vf_var_config_archivos & " - " & vf_id_notas_archivos)
        If vf_var_config_archivos <> "" And vf_id_notas_archivos <> "" Then
            Dim vf_name_files As String = ""
            vf_name_files = comunes.suministrar_valor_variable_configuracion(vf_var_config_archivos & "-001",
                                                                             vg_id_cia)
            vf_name_files += "-" & vf_id_notas_archivos.ToString.PadLeft(8, "0")
            formulario.vf_name_files = vf_name_files
            btn_gestionar_archivos(0).Text = cl_utilidades_gestion_documentos.calcular_cantidad_archivos_asociados(vf_var_config_archivos & "-001",
                                                                                                                   vf_id_notas_archivos, vg_id_cia)
            'MsgBox("Hizo")
        End If

    End Sub

    Public Shared Function GetTypeControls(Of T As Control)( _
    ByVal parentContainer As Control, ByVal includeInheritedControls As Boolean) As List(Of T)

        ' <summary>
        ' Obtiene una colección con los controles de un determinado
        ' tipo existentes en un contenedor superior.
        ' </summary>
        ' <typeparam name="T">Tipo de control que se desea obtener.</typeparam>
        ' <param name="parentContainer">Objeto Control que actua de
        'contenedor para el tipo de control que se desea obtener.</param>
        ' <param name="includeInheritedControls">Indica si se incluyen en la
        ' colección aquellos controles que heredan de la clase especificada.</param>
        ' <returns></returns>
        ' <remarks></remarks>

        If (parentContainer Is Nothing) Then Return Nothing
        Dim controls As New List(Of T)
        ' System.Type para el tipo de dato especificado.
        '
        Dim typeT As Type = GetType(T)
        For Each ctrl As Control In parentContainer.Controls
            If (includeInheritedControls) Then
                'If (TypeOf ctrl Is T) Then _
                controls.Add(DirectCast(ctrl, T))
            Else
                ' System.Type del control.
                '
                Dim typeControl As Type = ctrl.GetType()
                'If (typeControl.Equals(typeT)) Then _
                controls.Add(DirectCast(ctrl, T))
            End If
            controls.AddRange(cl_gestion_permisos.GetTypeControls(Of T)(ctrl, includeInheritedControls))
        Next
        Return controls
        'la forma de usar esta funcion en un formulario es:
        'Dim ctrls As List(Of Control) = cl_gestion_permisos.GetTypeControls(Of Control)(Me, True)
        'MsgBox(Me.Name)
        ' Obtenemos todos los controles xxx que se encuentren puedo especificar el tipo de control control
        ' tanto en el formulario como en cualquier otro control
        ' contenedor existente en el formulario actual.
        'For Each ctrl As Control In ctrls
        'MsgBox(ctrl.Name)
        'MsgBox(ctrl.GetType().ToString)
        'Next


    End Function
    Public Shared Function habilitarcontroles(Of T As Control)(ByVal parentContainer As Control, ByVal includeInheritedControls As Boolean, ByVal otabla As DataTable, ocontexto_form As String)

        ' <summary>
        ' Obtiene una colección con los controles de un determinado
        ' tipo existentes en un contenedor superior.
        ' </summary>
        ' <typeparam name="T">Tipo de control que se desea obtener.</typeparam>
        ' <param name="parentContainer">Objeto Control que actua de
        'contenedor para el tipo de control que se desea obtener.</param>
        ' <param name="includeInheritedControls">Indica si se incluyen en la
        ' colección aquellos controles que heredan de la clase especificada.</param>
        ' <returns></returns>
        ' <remarks></remarks>
        Dim vusuario As String
        vusuario = camocontrol.formulario_inicio.vlogin2.Trim 'el usuario actual del software

        If CInt(vusuario.Trim).ToString = "1" Then Return Nothing 'no se protege nada si el usuario es el administrador

        If (parentContainer Is Nothing) Then Return Nothing
        Dim controls As New List(Of T)
        ' System.Type para el tipo de dato especificado.
        '
        Dim typeT As Type = GetType(T)
        For Each ctrl As Control In parentContainer.Controls
            If ctrl.GetType().Name.ToString = "CheckBox" Then
                'MsgBox(ctrl.Name)
                For Each orow As DataRow In otabla.Rows 'ods.Tables("turnos").Rows
                    If UCase(Trim(orow("f0020_control").ToString)) = UCase(ctrl.Name.Trim) Then
                        If DBNull.Value.Equals(orow("f0022_acceso")) Then
                            'Trim(nconsecutivo.ToString("F0")).PadLeft(10, "0")
                            'MsgBox("NO Esta en los permisos")
                            ctrl.Enabled = False
                        End If
                    End If
                Next
            End If
            If ctrl.GetType().Name.ToString = "Button" Then
                'MsgBox(ctrl.Name)
                For Each orow As DataRow In otabla.Rows 'ods.Tables("turnos").Rows
                    If UCase(Trim(orow("f0020_control").ToString)) = UCase(ctrl.Name.Trim) Then
                        If DBNull.Value.Equals(orow("f0022_acceso")) Or orow("f0020_contexto") <> ocontexto_form Then
                            'Trim(nconsecutivo.ToString("F0")).PadLeft(10, "0")
                            'MsgBox("NO Esta en los permisos")
                            ctrl.Enabled = False
                        End If
                    End If
                Next
            End If
            If ctrl.GetType().Name.ToString = "TextBox" Then
                'MsgBox(ctrl.Name)
                For Each orow As DataRow In otabla.Rows 'ods.Tables("turnos").Rows
                    If UCase(Trim(orow("f0020_control").ToString)) = UCase(ctrl.Name.Trim) Then
                        If DBNull.Value.Equals(orow("f0022_acceso")) Or orow("f0020_contexto") <> ocontexto_form Then
                            'Trim(nconsecutivo.ToString("F0")).PadLeft(10, "0")
                            'MsgBox("NO Esta en los permisos")
                            ctrl.Enabled = False
                        End If
                    End If
                Next
            End If
            If ctrl.GetType().Name.ToString = "DataGridView" Then
                'MsgBox(ctrl.Name)
                For Each orow As DataRow In otabla.Rows 'ods.Tables("turnos").Rows
                    If UCase(Trim(orow("f0020_control").ToString)) = UCase(ctrl.Name.Trim) Then
                        If DBNull.Value.Equals(orow("f0022_acceso")) Then
                            Dim a As DataGridView = ctrl
                            a.ReadOnly = True
                            'Trim(nconsecutivo.ToString("F0")).PadLeft(10, "0")
                            'MsgBox("NO Esta en los permisos")
                            'ctrl.ReadOnly = True
                        End If
                    End If
                Next
            End If
            If ctrl.GetType().Name.ToString = "MenuStrip" Then
                Dim a As MenuStrip = ctrl
                Dim permisos2 As New cl_gestion_permisos
                For Each miitem As ToolStripMenuItem In a.Items
                    'MsgBox(" item del menu: " & miitem.Name)
                    For Each orow As DataRow In otabla.Rows 'ods.Tables("turnos").Rows
                        'MsgBox("opciones que se analizan : " & orow("control"))
                        If UCase(Trim(orow("f0020_control").ToString)) = UCase(Trim(miitem.Name.ToString)) Then
                            'MsgBox(orow("control") & " igual a " & miitem.Name)
                            If DBNull.Value.Equals(orow("f0022_acceso")) Then
                                miitem.Enabled = False
                                miitem.DropDownItems.Clear()
                            End If
                        End If
                    Next
                    permisos2.recorrer_MenuStrip(miitem, otabla)
                Next

                'Dim a As MenuStrip = ctrl
                'Dim permisos2 As New cl_gestion_permisos
                'For Each miitem As ToolStripMenuItem In a.Items
                'MsgBox(miitem.Name.ToString)
                'permisos2.recorrer_MenuStrip(miitem)
                'Next
            End If
            'MsgBox(ctrl.GetType().ToString)
            controls.AddRange(cl_gestion_permisos.habilitarcontroles(Of T)(ctrl, includeInheritedControls, otabla, ocontexto_form))
        Next
        Return controls
        'la forma de usar esta funcion en un formulario es:
        'Dim ctrls As List(Of Control) = cl_gestion_permisos.GetTypeControls(Of Control)(Me, True)
        'MsgBox(Me.Name)
        ' Obtenemos todos los controles xxx que se encuentren puedo especificar el tipo de control control
        ' tanto en el formulario como en cualquier otro control
        ' contenedor existente en el formulario actual.
        'For Each ctrl As Control In ctrls
        'MsgBox(ctrl.Name)
        'MsgBox(ctrl.GetType().ToString)
        'Next
    End Function

    Public Sub recorrer_MenuStrip(ByVal Oneitem As ToolStripMenuItem, ByVal otabla As DataTable)
        'Esta funcion me permite recorrer los subitems en un MenuStrip y validar permisos
        Try
            For Each otroItem As ToolStripMenuItem In Oneitem.DropDownItems
                'valor &= otroItem.Text & ";"
                For Each orow As DataRow In otabla.Rows 'ods.Tables("turnos").Rows
                    If orow("f0020_control") = otroItem.Name Then
                        If DBNull.Value.Equals(orow("f0022_acceso")) Then
                            otroItem.Enabled = False
                            otroItem.DropDownItems.Clear()
                            'MsgBox("hola")
                        End If
                    End If
                Next
                If otroItem.DropDownItems.Count > 0 Then recorrer_MenuStrip(otroItem, otabla)
            Next
        Catch ex As Exception

        End Try

    End Sub

End Class
