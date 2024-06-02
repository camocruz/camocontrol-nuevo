Public Class fm_0500_digitalizar_soporte
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Private vf_var_config_notas As String
    Private vf_var_config_archivos As String
    Private vf_name_files As String
    Private vf_otipo_nota As String = ""

    Private usuario_creador As String = ""
    Private usuario_evaluador As String = ""
    Private actividad_cerrada As String = "N" 'Si una actividad fue cerrada queda bloqueada
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private odr As NpgsqlDataReader
    Private ods As New DataSet
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String

    Private otb_registro As DataTable
    Private codigo_documento As String
    Private oexiste As String = "N"
    Private csql As String
    Private odir_captura As String
    Private id_registro As Integer
    Private modo_captura As String = "M"  'M = Manual    A = Automatico




    Private Sub fm_0500_digitalizar_soporte_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        'VARIABLES DE CONFIGURACION DE NOTAS Y ARCHIVOS ASOCIADOS"
        vf_var_config_archivos = "CD-BKC"
        'vf_var_config_notas = "TN-BKC-001"
        'vf_otipo_nota = comunes.suministrar_valor_variable_configuracion(vf_var_config_notas, vg_id_cia)
        lb_existencia.Text = ""
    End Sub
    Private Sub definir_directorio()
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        'dialog.SelectedPath = "C:\"
        dialog.Description = "Seleccione la carpeta que contine los archivos"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            odir_captura = dialog.SelectedPath
            If odir_captura.Last = "\" Then
                tx_path_dir.Text = odir_captura
            Else
                tx_path_dir.Text = odir_captura & "\"
            End If

            'actualizo el directorio para cargue automatico
            formulario_inicio.vg_path_carg_aut = tx_path_dir.Text
            End If
    End Sub

    Private Sub bt_definir_directorio_Click(sender As Object, e As EventArgs) Handles bt_definir_directorio.Click
        definir_directorio()
    End Sub
    Private Function identificar_existencia()
        Dim id As Integer = 0
        'Doy formato al codigo del documento
        codigo_documento = tx_tipo.Text.Trim.ToUpper & "-" & tx_consecutivo.Text.Trim.ToUpper.PadLeft(8, "0")
        'me aseguro que no tenga espacios
        codigo_documento = Replace(codigo_documento, " ", "")
        'Identifico si el documento ya existe digitalizado
        csql = "select f0550_id_registro from " & database.obtener_esquema & ".tb0550_registros"
        csql += " where f0550_id_documento = '" & codigo_documento & "' and f0550_id_cia = '" & vg_id_cia & "'"
        otb_registro = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_registro.Rows.Count > 0 Then
            'el registro ya existe
            id = otb_registro(0)("f0550_id_registro")
        End If
        Return id
    End Function
    Private Sub procesar_registros()

        'Los permisos de acceso a digitalizar los controlo en el menu de inicio
        'por esta razon los deshabilite.
        Dim p_add_archivos As String = "N"
        If IsNothing(vf_otabla_permisos) = False Then
            'p_add_archivos = cl_gestion_permisos.identificar_permisos_especiales_formularios("ADD_ARCHIVO", vf_otabla_permisos, vg_usuario_autoriza)
        End If
        If p_add_archivos = "N" Then
            'MsgBox("No tiene permisos para adicionar archivos", MsgBoxStyle.Information, "Info")
            'Exit Sub
        End If
        If tx_path_dir.Text = "" Then
            MsgBox("Primero defina una carpeta de captura", MsgBoxStyle.Information, "Error")
            'definir_directorio()
            Exit Sub
        End If

        'Identifico si el documento ya existe digitalizado
        id_registro = identificar_existencia()

        csql = "select f0550_id_registro from " & database.obtener_esquema & ".tb0550_registros"
        csql += " where f0550_id_documento = '" & codigo_documento & "' and f0550_id_cia = '" & vg_id_cia & "'"
        otb_registro = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If id_registro > 0 Then
            'el registro ya existe
            MsgBox("este registro ya existe")
        Else
            'el registro no existe y debo crearlo
            'Este es un ensayo para no tener que hacer una consulta posterior para identificar
            'el numero de registro creado, el returning me entrega una tabla despues de realizar el insert
            csql = "INSERT INTO " & database.obtener_esquema & ".tb0550_registros"
            csql += " (f0550_id_cia, f0550_id_documento, f0550_tipo,"
            csql += " f0550_usuario_modificar, f0550_usuario_crear)"
            csql += " VALUES"
            csql += " ('" & vg_id_cia & "', '" & codigo_documento & "', 'BKC',"
            csql += " '" & vg_usuario_autoriza & "', '" & vg_usuario_autoriza & "')"
            csql += " ON CONFLICT (f0550_id_documento) DO UPDATE SET f0550_id_documento = EXCLUDED.f0550_id_documento"
            csql += " RETURNING f0550_id_registro"

            otb_registro = cl_utilidades_datatables.cargar_informacion_postgres(csql)
            'Aqui consigo el numero del registro creado
            id_registro = otb_registro(0)(0)
        End If

        'procesamos los documentos
        If modo_captura = "M" Then
            cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo(vf_var_config_archivos, id_registro, vg_id_cia, vg_usuario_autoriza, "N", tx_path_dir.Text)
        Else
            cl_utilidades_gestion_documentos.capturar_archivos_segun_tipo(vf_var_config_archivos, id_registro, vg_id_cia, vg_usuario_autoriza, "S", tx_path_dir.Text)
        End If
        tx_path_dir.Text = formulario_inicio.vg_path_carg_aut
        tx_tipo.Text = ""
        tx_consecutivo.Text = ""
        lb_existencia.Text = ""
        tx_tipo.Focus()
    End Sub
    Private Sub bt_cargue_manual_Click(sender As Object, e As EventArgs) Handles bt_cargue_manual.Click
        modo_captura = "M"
        procesar_registros()
    End Sub

    Private Sub bt_cargue_automatico_Click(sender As Object, e As EventArgs) Handles bt_cargue_automatico.Click
        modo_captura = "A"
        procesar_registros()
    End Sub

    Private Sub tx_consecutivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_consecutivo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Dim oreg As Integer = 0
            oreg = identificar_existencia()
            If oreg = 0 Then
                lb_existencia.Text = "Reg. Nuevo"
            Else
                lb_existencia.Text = "Reg. Existente"
            End If
        End If
    End Sub

End Class
