Public Class fm_0300_explosion_prog_prod
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"
    Public otipo_nota As String = ""

    Public id_plantilla As Integer
    Public id_item_padre As Integer

    'Private$vf_otabla_permisos$As DataTable

    Private odr As NpgsqlDataReader
    Private oconn_form As NpgsqlConnection

    Private ocmd As NpgsqlCommand
    Private ocmd_update As NpgsqlCommand
    Private csql As String = ""
    Private vcerrar As String = "N"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String = ""
    Private vexiste As String = ""
    Private vdia_semana As String = ""
    Private vcodigo_conductor As String = ""
    Private vnuevo_registro As String = "S"
    Private verror As String = "N"
    Private item_salida_plantilla As Integer
    Private cantidad_bache_global As Decimal
    Private otb_items As DataTable
    Private otb_formula As DataTable
    Private otb_plantillas As DataTable
    Private otb_items_todas_plantillas As DataTable
    Private otb_costo_items As DataTable
    Private ocosto As Decimal = 0
    Private h_operario As Decimal = 0
    Private h_operario_lider As Decimal = 0
    Private h_supervisor As Decimal = 0
    Private relacionar_explosion As String = "N"


    Public orow_item_calculadora(3) As String
    Private orowgrid As DataGridViewRow
    Private ocelgrid As DataGridViewCell
    Private otextgrid As DataGridViewTextBoxCell
    Private obtngrid As DataGridViewButtonCell
    Private ocmb_grid As DataGridViewComboBoxCell


    Private Sub fm_0300_explosion_prog_prod_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        otb_items_todas_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-06", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        otb_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

    End Sub

    Private Sub bt_generar_explosion_Click(sender As Object, e As EventArgs) Handles bt_generar_explosion.Click
        relacionar_explosion = "N"
        generar_explosion()
    End Sub

    Private Sub bt_relacionar_items_Click(sender As Object, e As EventArgs) Handles bt_relacionar_items.Click
        relacionar_explosion = "S"
        generar_explosion()
    End Sub

    Private Sub generar_explosion()
        'Creo la tabla de items programados
        csql = comunes.suministrar_valor_variable_configuracion("ST-0400-10", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        'Clipboard.SetDataObject(csql)
        'MsgBox("clipboard")
        'Exit Sub
        Dim otb_items_programados As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim otb_formula As DataTable = Nothing
        Dim contador As Integer = 1
        'inicializo el arreglo de matriz escalonada cob valores de 0
        'Dim array_costos_sugeridos As Decimal()() = llenar_array_costos_sugeridos()
        'MsgBox("plantillas: " & otb_plantillas.Rows.Count & " items plantillas: " & otb_items_todas_plantillas.Rows.Count)
        Dim otb1 As New DataTable
        Dim cant_pend As Decimal = 0
        For Each orow As DataRow In otb_items_programados.Rows
            otb1 = Nothing
            'generaremos la explosion de materiales de las cantidades pendientes por produccion.
            'no se tomaran en cuenta valores negativos o velores de 0
            cant_pend = orow("pendiente") 'orow("f0401_cantidad")
            If cant_pend > 0 Then
                If orow("f0300_id_tipo_item").ToString = "15" Then
                    'otb1 = cl_utilidades_gestion_compras.entregar_formula_item(orow("f0401_id_item"), vg_id_cia, otb_costo_items, array_costos_sugeridos)
                    otb1 = cl_utilidades_gestion_compras.formulacion_entregar_formula_item(orow("f0401_id_item"), cant_pend,
                                                                                           "id_ipp: " & orow("f0401_id_ipp") & ".",
                                                                                       otb_plantillas, otb_items_todas_plantillas, 1)

                    If IsNothing(otb1) = False Then
                        If otb1.Rows.Count > 300 Then
                            MsgBox(orow("f0401_id_item") & " Item con Iteracion infinita")
                        End If
                        For Each orow2 As DataRow In otb1.Rows
                            orow2("cantidad") = Math.Round(orow2("cantidad"), 2)
                            If relacionar_explosion = "N" Then
                                orow2("path") = orow("f0401_id_prog_prod")
                                orow2("agrupacion") = orow("f0400_nombre")
                                orow2("id_elemento") = "1"
                                orow2("nombre_proceso") = "Explosion"
                            End If
                        Next
                        'cl_utilidades_datatables.exportar_datatable_excel(otb1)
                        'MsgBox(otb1.Rows.Count)
                        If contador = 1 Then
                            otb_formula = otb1
                        Else
                            otb_formula.Merge(otb1)
                        End If
                        contador += 1
                    Else
                        MsgBox("Error en la formulacion de: " & orow("f0401_id_item"))
                    End If

                    'Label1.Text = 
                End If
            End If
        Next
        'MsgBox("Salio")
        MsgBox("Salio: " & otb_formula.Rows.Count)

        Dim oview As New DataView(otb_formula)
        oview.Sort = "id_item"
        Dim ntable As DataTable = oview.ToTable

        cl_utilidades_datatables.datatable_to_csv_filesavedialog(ntable, True, vg_id_cia)

        'cl_utilidades_datatables.exportar_datatable_excel(otb_formula)
        cl_utilidades_datatables.visualizar_datos_visor("", "", vg_usuario_autoriza, "Explosion", {}, ntable)
    End Sub
End Class
