Imports System.ComponentModel

Public Class fm_0300_formulacion_tree_view
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_item_clonar As Integer
    Private otipo_nota As String

    'Private$vf_otabla_permisos$As DataTable
    Private new_name_file As String = ""
    Private modificacion_activada As String = "N"
    Private oconn_form As NpgsqlConnection
    Private ocmd As NpgsqlCommand

    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private verror_cargue As String = "N"
    Private cargue_bloqueado As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String

    Private otb_items_plantillas As DataTable
    Private otb_plantillas As DataTable
    Private otb_items_programa_produccion As DataTable
    Private otb_rama_programa_produccion As DataTable

    Private path_estructura_filtrado As String = ""
    Private id_estructura_padre_filtrado As Integer
    Private id_item_seleccionado As Integer

    'Public nodo_padre_tag As String = ""
    Private nodo_seleccionado As TreeNode
    Private nodo_hijo_tag As String = ""
    Private filtro_rama As String = "N"
    Private cantidad_produccion_bache As Decimal  'tamaño del bache para el item que solicito formulacion


    Private Sub fm_0300_formulacion_tree_view_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        cargar_info_plantillas()

        'Lleno el treeview
        TreeView1.Nodes.Clear()
        CrearNodosDelPadre(Nothing)
        'TreeView1.Nodes.Item(0).Expand()
    End Sub

    Private Sub cargar_info_plantillas()
        'Cargo informacion de las plantillas y sus items
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-06", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        otb_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-07", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        otb_items_plantillas = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub

    Private Sub CrearNodosDelPadre(ByVal nodePadre As TreeNode)
        Dim cantidad_requerida As Decimal = 0
        If tx_cantidad_produccion.Text.Trim <> "" Then
            cantidad_requerida = tx_cantidad_produccion.Text
        End If


        'Primero identifico la plantilla
        Dim dataviewplantilla As New DataView
        Dim filtro_plantilla As String = "f0350_id_item = '" & id_item_clonar & "'" _
                                         & " and f0350_activa = 'S'"
        dataviewplantilla = New DataView(otb_plantillas, filtro_plantilla, "", DataViewRowState.CurrentRows)
        For Each orowplantilla As DataRowView In dataviewplantilla
            cantidad_produccion_bache = orowplantilla("f0350_produccion_x_bache")
            If cantidad_requerida = 0 Then
                cantidad_requerida = orowplantilla("f0350_produccion_x_bache")
                tx_cantidad_produccion.Text = CDec(orowplantilla("f0350_produccion_x_bache"))
            End If
            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = "   ( " & orowplantilla("f0300_id_item").ToString().Trim() & " )  --  " _
                                & orowplantilla("descripcion_larga").ToString().Trim() & " {  Bache Produccion: " _
                                & CDec(orowplantilla("f0350_produccion_x_bache")).ToString("N1") _
                                & " " & orowplantilla("f0002_unidad_medicion") & "}"
            nuevoNodo.Text += " << #Baches: " & (cantidad_requerida / cantidad_produccion_bache).ToString("N1") _
                        & " de " & cantidad_produccion_bache.ToString("N1") & " >> }"

            nuevoNodo.Tag = orowplantilla("f0300_id_item").ToString().Trim()
            nuevoNodo.Name = 10000000 + orowplantilla("f0300_id_item")

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If
            'llenar_rama_arbol_secuencia(orowplantilla("f0300_id_item"), nuevoNodo, orowplantilla("f0350_produccion_x_bache"))
            'MsgBox(cantidad_produccion_bache)
            llenar_rama_arbol_secuencia(orowplantilla("f0300_id_item"), nuevoNodo, cantidad_requerida)
        Next
    End Sub

    Private Sub llenar_rama_arbol_secuencia(ByVal id_item_padre As String, ByVal nodePadre As TreeNode, cantidad As Decimal)
        'Lleno como nodos los semiproductos del producto_terminado
        'Primero identifico la plantilla
        'MsgBox(cantidad)
        Dim dataviewplantilla As New DataView
        Dim filtro_plantilla As String = "f0350_id_item = '" & id_item_padre & "'" _
                                         & " and f0350_activa = 'S'"
        dataviewplantilla = New DataView(otb_plantillas, filtro_plantilla, "", DataViewRowState.CurrentRows)
        For Each orowplantilla As DataRowView In dataviewplantilla
            'Identifico los items de la plantilla
            Dim dataviewitemsplantilla As New DataView
            dataviewitemsplantilla = New DataView(otb_items_plantillas, "f0351_id_plantilla = '" & orowplantilla("f0350_id_plantilla") & "'", "", DataViewRowState.CurrentRows)
            For Each orowitemsplantilla As DataRowView In dataviewitemsplantilla
                Dim cantidad_item As Decimal = (cantidad / orowplantilla("f0350_produccion_x_bache")) * orowitemsplantilla("f0351_cantidad")
                'Buscar informacion de la plantilla del item para determinar el numero de baches en los que se produciria la cantidad requerida
                Dim dataviewplantillaitem As New DataView
                dataviewplantillaitem = New DataView(otb_plantillas, "f0350_id_item = '" & orowitemsplantilla("f0351_id_item") & "'" _
                                         & " and f0350_activa = 'S'", "", DataViewRowState.CurrentRows)
                Dim bache_prod_item As Decimal
                For Each orowplantillaitem As DataRowView In dataviewplantillaitem
                    bache_prod_item = orowplantillaitem("f0350_produccion_x_bache")
                Next

                Dim nuevoNodo2 As New TreeNode
                Dim texto_nodo As String
                Dim semiproducto As String = "N"
                texto_nodo = "     ( " & orowitemsplantilla("f0351_id_item") & " )  --  " & orowitemsplantilla("f0300_descripcion_item").ToString _
                    & " { Cantidad Requerida: " _
                    & cantidad_item.ToString("N1") & " " & orowitemsplantilla("f0002_unidad_medicion")
                If orowitemsplantilla("f0300_id_tipo_item").ToString = "25" Then
                    texto_nodo += " << #Baches: " & (cantidad_item / bache_prod_item).ToString("N1") _
                        & " de " & bache_prod_item.ToString("N1") & " >> }"
                    semiproducto = "S"
                Else
                    texto_nodo += " }"
                    semiproducto = "N"
                End If
                'para agregar solo los items tipo semiproductos
                'If semiproducto = "S" Then
                nuevoNodo2.Text = texto_nodo
                nuevoNodo2.Tag = orowitemsplantilla("f0351_id_item")
                nuevoNodo2.Name = orowitemsplantilla("f0351_id_elemento")
                ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                ' del primer nivel que no dependen de otro nodo.
                If nodePadre Is Nothing Then
                    TreeView1.Nodes.Add(nuevoNodo2)
                Else
                    ' se añade el nuevo nodo al nodo padre.
                    nodePadre.Nodes.Add(nuevoNodo2)
                End If
                llenar_rama_arbol_secuencia(orowitemsplantilla("f0351_id_item"), nuevoNodo2, cantidad_item)
                'End If
            Next
        Next
    End Sub

    Private Sub bt_recalcular_Click(sender As Object, e As EventArgs) Handles bt_recalcular.Click
        'Lleno el treeview
        TreeView1.Nodes.Clear()
        CrearNodosDelPadre(Nothing)
    End Sub

    Private Sub tx_cantidad_produccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tx_cantidad_produccion.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = False
        End If
        If e.KeyChar = "." Or e.KeyChar = "," Then
            e.Handled = False
        End If
    End Sub

    Private Sub tx_cantidad_produccion_Validating(sender As Object, e As CancelEventArgs) Handles tx_cantidad_produccion.Validating
        If tx_cantidad_produccion.Text.Trim = "" Or CDec(tx_cantidad_produccion.Text) = 0 Then
            tx_cantidad_produccion.Text = 1
        End If
        tx_cantidad_produccion.Text = CDec(tx_cantidad_produccion.Text)
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        id_item_seleccionado = e.Node.Tag.ToString
        lb_id_item.Text = e.Node.Tag.ToString
        nodo_seleccionado = e.Node
    End Sub

    Private Sub bt_abrir_item_Click(sender As Object, e As EventArgs) Handles bt_abrir_item.Click

        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_item As New camocontrol.fm_0300_gestion_items
        'oform_grilla_programacion.ods_hijo = ods
        oform_item.id_item = id_item_seleccionado

        oform_item.vf_oform_padre = Me
        oform_item.vg_id_cia = vg_id_cia
        oform_item.vg_usuario_autoriza = vg_usuario_autoriza
        oform_item.ShowDialog()
        cargar_info_plantillas()
        nodo_seleccionado.Expand()
        nodo_seleccionado.ForeColor = Color.Red
    End Sub

    Private Sub bt_abrir_plantilla_activa_Click(sender As Object, e As EventArgs) Handles bt_abrir_plantilla_activa.Click
        Dim id_plantilla_activa As Integer
        'Buscar informacion de la plantilla del item para determinar el numero de baches en los que se produciria la cantidad requerida
        Dim dataviewplantillaitem As New DataView
        dataviewplantillaitem = New DataView(otb_plantillas, "f0350_id_item = '" & id_item_seleccionado & "'" _
                                         & " and f0350_activa = 'S'", "", DataViewRowState.CurrentRows)
        For Each orowplantillaitem As DataRowView In dataviewplantillaitem
            id_plantilla_activa = (orowplantillaitem("f0350_id_plantilla"))
        Next
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_exp_materiales As New camocontrol.fm_0300_formulacion
        oform_exp_materiales.vf_oform_padre = Me
        oform_exp_materiales.vg_usuario_autoriza = vg_usuario_autoriza
        oform_exp_materiales.vg_id_cia = vg_id_cia
        oform_exp_materiales.id_plantilla = id_plantilla_activa
        oform_exp_materiales.id_item_padre = id_item_seleccionado
        oform_exp_materiales.vf_elemento_nuevo = "N"
        oform_exp_materiales.ShowDialog()
        cargar_info_plantillas()
        nodo_seleccionado.Expand()
        nodo_seleccionado.ForeColor = Color.Red

    End Sub
End Class
