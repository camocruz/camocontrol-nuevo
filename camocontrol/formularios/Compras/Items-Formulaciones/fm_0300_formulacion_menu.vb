Public Class fm_0300_formulacion_menu
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Public id_prog_prod As Integer
    Public id_item As Integer
    Public id_item_pp As Integer 'el id del item de un programa de produccion.
    Public tree_path_base As String

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

    Public nodo_padre_tag As String = ""
    Private nodo_hijo_tag As String = ""
    Private filtro_rama As String = "N"
    Private cantidad_dimanica As Decimal 'Cantidad que usare para asignar cantidad de items de acuerdo a recorrido por treeview
    Private cantidad_produccion As Decimal  'Cantidad requerida en un OP
    Private fecha_op_inicio As Date
    Private fecha_op_final As Date


    Private Sub fm_0300_formulacion_menu_Load(sender As Object, e As EventArgs) Handles Me.Load
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


    Private Sub bt_listado_plantillas_Click(sender As Object, e As EventArgs) Handles bt_listado_plantillas.Click
        'recuerda llamo al visor de datos de esta manera para dejar activado el boton de nuevo para nuevas plantillas.
        Dim csql As String = comunes.suministrar_valor_variable_configuracion("ST-0300-04", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", vg_id_cia)
        csql = csql.Replace("$002$", id_item)

        'Instanciamos el formulario como un objeto de la clase fm_grilla_turnos
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_mostrar_datos As New camocontrol.fm_visor_datos
        oform_mostrar_datos.vf_oform_padre = Me
        oform_mostrar_datos.csql = csql
        'definimos el contexto para habilitar el boton nuevo
        oform_mostrar_datos.ocontexto_form = "nueva explosion de materiales"
        oform_mostrar_datos.titulo_formulario = "Lista de Plantillas de Produccion"
        oform_mostrar_datos.vg_id_cia = vg_id_cia
        oform_mostrar_datos.vg_usuario_autoriza = vg_usuario_autoriza
        oform_mostrar_datos.id_oreg_padre = id_item
        oform_mostrar_datos.ShowDialog()
    End Sub

    Private Sub bt_formulacion_actual_Click(sender As Object, e As EventArgs) Handles bt_formulacion_actual.Click
        'Instanciamos el formulario como un objeto de la clase fm_0100_estructura_mantenimiento
        'Esto es necesario hacerlo cuando antes de mostrar el formulario debemos configurarle valores previos
        Dim oform_catalogo_items As New camocontrol.fm_0300_formulacion_tree_view
        oform_catalogo_items.vf_oform_padre = Me
        oform_catalogo_items.vg_usuario_autoriza = vg_usuario_autoriza
        oform_catalogo_items.vg_id_cia = vg_id_cia
        oform_catalogo_items.id_item_clonar = id_item
        oform_catalogo_items.vf_elemento_nuevo = "N"
        'oform_catalogo_items.vf_elemento_nuevo = "N"
        oform_catalogo_items.ShowDialog()
    End Sub
End Class
