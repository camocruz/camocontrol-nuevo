Imports System
Imports System.Collections
Imports System.Globalization
Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq
Imports RestSharp


Public Class fm_0800_cargar_rm
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""
    '$Public$vf_elemento_nuevo As String = "S"

    Private otb_remisiones_sin_despacho_asignado As DataTable
    Private otb_tipos_recaudos As DataTable
    Private otb_registros_grabados As DataTable
    Private otb_clientes As DataTable
    Private otb_ciudades As DataTable
    Private otb_items As DataTable
    Private otb_items_cg As DataTable
    Private verror As String = "S"
    Private verror_requisitos As String = "N"
    Private vmensaje_requisitos As String
    Private csql As String
    Private oconn_form As NpgsqlConnection
    Private oda As NpgsqlDataAdapter
    Private ocmd As NpgsqlCommand

    Private DtoDgEnEdicion As New DtoTercero
    Private UltimoDoctoCia1 As Integer = 0
    Private UltimoDoctoCia2 As Integer = 0
    Private ofiscal As String = "1"
    Private numero_rm As String = ""
    Private id_encabezado As Integer
    Private fecha_documento_rm As Date
    Private codigo_cliente As String = ""
    Private digito_verificacion As String = ""
    Private razon_social As String = ""
    Private ciudad_cliente As String = ""
    Private id_ciudad_cliente As String = ""
    Private direccion As String = ""
    Private id_sucursal_fact As String = ""
    Private nombre_vendedor As String = ""
    Private codigo_vendedor As String = ""
    Private referencia_1 As String = ""
    Private referencia_2 As String = ""
    Private cantidad_producto As Decimal = 0
    Private cantidad_producto_original As Decimal = 0
    Private factor_empaque_siesa As Integer = 1
    Private descripcion_producto As String = ""
    Private falla_items As String = "N"
    Private txt_falla_item As String = ""
    Private id_bodega As String = ""

    Private id_factura As Integer
    Private id_cia_factura As Integer = 0
    Private num_factura As String = ""
    Private id_sucursal_unoee As String = ""
    Private tx_fecha_factura As String = ""
    Private subtotal_factura As Decimal
    Private descuento_factura As Decimal
    Private iva_factura As Decimal
    Private total_factura As Decimal
    Private factura_anulada_cg As String
    Private remision_factura As String

    Private id_item_producto As Integer
    Private item_valor_unitario As Decimal
    Private item_valor_impuestos As Decimal
    Private item_valor_neto As Decimal
    Private total_producto As Decimal

    Public ciudad_equivalente_actualizada As String = "N"
    Public id_ciudad As String
    Public id_tercero As String
    Public direccion_despacho As String
    Public ciudad_despacho As String

    Private Sub fm_0800_cargar_rm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'SECCION QUE CONTROLA LOS PERMISOS DE LOS USUARIOS
        Dim vusuario As String
        vusuario = formulario_inicio.vlogin2.Trim 'el usuario actual del software 000000001234
        'MsgBox(PrySidoc.Menu.vlogin2)
        'Conseguimos los permisos del usuario en el formulario
        Dim permisos As New cl_gestion_permisos
        vf_otabla_permisos = permisos.identificar_permisos_usuario(vusuario, Me.Name, ocontexto_form) 'llenamos el datatable con los permisos
        Dim ctrls As List(Of Control) = cl_gestion_permisos.habilitarcontroles(Of Control)(Me, True, vf_otabla_permisos, ocontexto_form)
        '**********************

        dg_remision_encabezado.AllowUserToAddRows = False
        dg_remision_encabezado.AllowUserToDeleteRows = False
        dg_remision_encabezado.AllowUserToResizeColumns = True
        dg_remision_encabezado.AllowUserToResizeRows = False
        dg_remision_encabezado.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige
        '1. Cargar clientes y ciudades
        cargar_otb_clientes()
        cargar_otb_ciudades()
        cargar_otb_items_cg()
        '2. Cargar remisiones sin asignar
        cargar_dg_remisiones_sin_asignar()
    End Sub
    Private Sub cargar_otb_clientes()
        csql = "select * from " & database.obtener_esquema & ".tb0200_terceros" _
            & " where f0200_id_cia = '" & vg_id_cia & "' and f0200_anulado = 'N'" ' and f0200_ind_cliente = 'S'"
        otb_clientes = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub cargar_otb_ciudades()
        csql = "select f0052_codigo_ciudad, f0052_ciudad, f0052_codigo_departamento," _
               & " f0052_ciudad || ' - ' || f0051_departamento AS destino" _
               & " from " & database.obtener_esquema & ".tb0052_ciudades" _
               & " JOIN " & database.obtener_esquema & ".tb0051_departamentos ON f0051_codigo_departamento = f0052_codigo_departamento"
        otb_ciudades = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub cargar_otb_items_cg()
        'Para calcular la cantidad de cajas a despachar debo traer la informacion de los
        'items del cg, e identificar el factor de empaque.
        csql = "select * from " & database.obtener_esquema & ".tb0408_items_cg;"
        otb_items_cg = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub
    Private Sub grabar_encabezado_rm()
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)
        'Creamos la remision en la bd
        csql = "insert into " + database.obtener_esquema + ".tb0850_remisiones_cguno_encabezado" _
            & " (" _
            & " f0850_rm, f0850_id_cia, f0850_codigo_tercero, f0850_dig_ver," _
            & " f0850_id_cia_unoee, f0850_consec_doc_unoee," _
            & " f0850_fecha_documento, f0850_razon_social," _
            & " f0850_ciudad_destino, f0850_direccion_destino," _
            & " f0850_codigo_vendedor, f0850_nombre_vendedor," _
            & " f0850_usuario_crear, f0850_id_tercero," _
            & " f0850_usuario_modificar, f0850_ofi, f0850_id_sucursal_fact, f0850_id_ciudad_destino" _
            & ") values" _
            & " (" _
            & " @f0850_rm, @f0850_id_cia, @f0850_codigo_tercero, @f0850_dig_ver," _
            & " @f0850_id_cia_unoee, @f0850_consec_doc_unoee," _
            & " @f0850_fecha_documento, @f0850_razon_social," _
            & " @f0850_ciudad_destino, @f0850_direccion_destino," _
            & " @f0850_codigo_vendedor, @f0850_nombre_vendedor," _
            & " @f0850_usuario_crear, @f0850_id_tercero," _
            & " @f0850_usuario_modificar, @f0850_ofi, @f0850_id_sucursal_fact, @f0850_id_ciudad_destino" _
            & ")" _
            & " RETURNING f0850_id_rm"


        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0850_rm", NpgsqlDbType.Varchar).Value = numero_rm
        ocmd.Parameters.Add("f0850_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0850_codigo_tercero", NpgsqlDbType.Varchar).Value = codigo_cliente
        ocmd.Parameters.Add("f0850_dig_ver", NpgsqlDbType.Varchar).Value = digito_verificacion
        ocmd.Parameters.Add("f0850_fecha_documento", NpgsqlDbType.Timestamp).Value = fecha_documento_rm
        ocmd.Parameters.Add("f0850_razon_social", NpgsqlDbType.Varchar).Value = razon_social
        ocmd.Parameters.Add("f0850_ciudad_destino", NpgsqlDbType.Varchar).Value = ciudad_cliente
        ocmd.Parameters.Add("f0850_direccion_destino", NpgsqlDbType.Varchar).Value = direccion
        ocmd.Parameters.Add("f0850_codigo_vendedor", NpgsqlDbType.Varchar).Value = codigo_vendedor
        ocmd.Parameters.Add("f0850_nombre_vendedor", NpgsqlDbType.Varchar).Value = nombre_vendedor
        ocmd.Parameters.Add("f0850_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0850_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0850_ofi", NpgsqlDbType.Varchar).Value = ofiscal
        ocmd.Parameters.Add("f0850_id_sucursal_fact", NpgsqlDbType.Varchar).Value = id_sucursal_fact
        ocmd.Parameters.Add("f0850_id_cia_unoee", NpgsqlDbType.Integer).Value = id_cia_factura
        ocmd.Parameters.Add("f0850_consec_doc_unoee", NpgsqlDbType.Integer).Value = id_factura
        ocmd.Parameters.Add("f0850_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0850_id_ciudad_destino", NpgsqlDbType.Varchar).Value = id_ciudad_cliente
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nueva falla! " + vbCrLf + ex.ToString + vbCrLf + csql)
        End Try
        Try
            id_encabezado = ocmd.ExecuteScalar()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al crear remision ! " + vbCrLf + ex.ToString)
        End Try

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub grabar_detalle_rm()
        'MsgBox("ENTRO")
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "insert into " + database.obtener_esquema + ".tb0851_remisiones_cguno_detalle" _
            & " (" _
            & " f0851_id_rm, f0851_rm, f0851_id_cia, f0851_referencia_1, f0851_referencia_2," _
            & " f0851_descripcion, f0851_cantidad, f0851_cantidad_origen, f0851_factor_empaque_siesa," _
            & " f0851_val_unit, f0851_iva, f0851_val_tot," _
            & " f0851_usuario_crear," _
            & " f0851_usuario_modificar" _
            & ") values" _
            & " (" _
            & " @f0851_id_rm, @f0851_rm, @f0851_id_cia, @f0851_referencia_1, @f0851_referencia_2," _
            & " @f0851_descripcion, @f0851_cantidad, @f0851_cantidad_origen, @f0851_factor_empaque_siesa," _
            & " @f0851_val_unit, @f0851_iva, @f0851_val_tot," _
            & " @f0851_usuario_crear," _
            & " @f0851_usuario_modificar" _
            & ")"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0851_id_rm", NpgsqlDbType.Integer).Value = id_encabezado
        ocmd.Parameters.Add("f0851_rm", NpgsqlDbType.Varchar).Value = numero_rm
        ocmd.Parameters.Add("f0851_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0851_referencia_1", NpgsqlDbType.Varchar).Value = referencia_1
        ocmd.Parameters.Add("f0851_referencia_2", NpgsqlDbType.Varchar).Value = referencia_2
        ocmd.Parameters.Add("f0851_descripcion", NpgsqlDbType.Varchar).Value = descripcion_producto
        ocmd.Parameters.Add("f0851_cantidad", NpgsqlDbType.Numeric).Value = cantidad_producto
        ocmd.Parameters.Add("f0851_cantidad_origen", NpgsqlDbType.Numeric).Value = cantidad_producto_original
        ocmd.Parameters.Add("f0851_factor_empaque_siesa", NpgsqlDbType.Integer).Value = factor_empaque_siesa
        ocmd.Parameters.Add("f0851_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0851_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0851_val_unit", NpgsqlDbType.Numeric).Value = item_valor_unitario
        ocmd.Parameters.Add("f0851_iva", NpgsqlDbType.Numeric).Value = item_valor_impuestos
        ocmd.Parameters.Add("f0851_val_tot", NpgsqlDbType.Numeric).Value = item_valor_neto
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
                MsgBox("Hubo un error grabando detalle rm" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Function verificar_que_rm_no_este_programada(ByVal id_rm As String)
        Dim rm_programada As String = "N"
        csql = "select * from " & database.obtener_esquema & ".tb0850_remisiones_cguno_encabezado" _
            & " where f0850_id_cia = '" & vg_id_cia & "' and " & "f0850_rm = '" & id_rm & "' and f0850_anulado = 'N'" _
            & " and f0850_id_despacho is not null"
        Dim otb_rm As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        If otb_rm.Rows.Count > 0 Then
            rm_programada = "S"
        End If
        Return rm_programada
    End Function
    Private Sub cargar_dg_remisiones_sin_asignar()
        cargar_otb_remisiones_sin_asignar()
        'Dim ocolum_sel As New DataColumn
        otb_remisiones_sin_despacho_asignado.Columns.Add("sel", Type.GetType("System.Boolean"))

        dg_remision_encabezado.DataSource = otb_remisiones_sin_despacho_asignado
        dg_remision_encabezado.AutoResizeColumns()
        dg_remision_encabezado.Columns("id_rm").ReadOnly = True 'dg_remision_encabezado.Columns("id").ReadOnly = True
        dg_remision_encabezado.Columns("rm").ReadOnly = True 'dg_remision_encabezado.Columns("remision").ReadOnly = True
        dg_remision_encabezado.Columns("cliente").ReadOnly = True
        dg_remision_encabezado.Columns("ciudad").ReadOnly = True
        dg_remision_encabezado.Columns("direccion").ReadOnly = True
        dg_remision_encabezado.Columns("fecha").ReadOnly = True
        dg_remision_encabezado.Columns("nit").ReadOnly = True
        dg_remision_encabezado.Columns("vendedor").ReadOnly = True
        dg_remision_encabezado.Columns("vendedor").Width = 100
        dg_remision_encabezado.Columns("id_tercero").Visible = False
        dg_remision_encabezado.Columns("id_tercero").ReadOnly = True
        dg_remision_encabezado.Columns("id_suc_unoee").Visible = False
        dg_remision_encabezado.Columns("id_suc_unoee").ReadOnly = True
        dg_remision_encabezado.Columns("nit_vendedor").Visible = False
        dg_remision_encabezado.Columns("nit_vendedor").ReadOnly = True
        dg_remision_encabezado.Columns("id_ciudad").Visible = False
        dg_remision_encabezado.Columns("id_ciudad").ReadOnly = True
        'Dim ocolum As New DataGridViewCheckBoxColumn
        'ocolum.HeaderText = "Despachar"
        'ocolum.Name = "dgocell_crear_despacho"
        'dg_remision_encabezado.Columns.Add(ocolum)

        lb_total_rms.Text = dg_remision_encabezado.Rows.Count & "   Registros."
    End Sub

    Private Sub cargar_otb_remisiones_sin_asignar()
        dg_remision_encabezado.Columns.Clear()
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-03", vg_id_cia)
        csql = Replace(csql, "$df001$", database.obtener_esquema)
        csql = Replace(csql, "$001$", vg_id_cia)
        otb_remisiones_sin_despacho_asignado = cl_utilidades_datatables.cargar_informacion_postgres(csql)
    End Sub



    Private Sub bt_generar_despacho_Click(sender As Object, e As EventArgs) Handles bt_generar_despacho.Click
        Dim fecha_act As Date = comunes.g_fechahora
        'VALIDO SI FECHA DE MOVIMIENTO ESTA HABILITADA
        Dim fechavalidada As String()
        fechavalidada = cl_utilidades_gestion_compras.ValidarFechaMovimiento(fecha_act, vg_id_cia)
        If fechavalidada(1) = "N" Then
            MsgBox(fechavalidada(2), MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        'Cargamos la datatable con todos los items
        otb_items = cl_utilidades_gestion_compras.suministrar_tabla_items(vg_id_cia)

        Dim otb_rm_sel As New DataTable

        ' Create four typed columns in the DataTable.
        otb_rm_sel.Columns.Add("id_rm", GetType(Integer))
        otb_rm_sel.Columns.Add("rm", GetType(String))
        otb_rm_sel.Columns.Add("nit", GetType(String))
        otb_rm_sel.Columns.Add("cliente", GetType(String))
        otb_rm_sel.Columns.Add("id_tercero", GetType(String))
        otb_rm_sel.Columns.Add("ciudad", GetType(String))
        otb_rm_sel.Columns.Add("direccion", GetType(String))
        otb_rm_sel.Columns.Add("vendedor", GetType(String))
        otb_rm_sel.Columns.Add("nit_vendedor", GetType(String))
        otb_rm_sel.Columns.Add("id_ciudad", GetType(String))

        Dim oselected As String 'para identificar cuales regsitrso fueron selecccionados por el checkbox
        For Each orow As DataGridViewRow In dg_remision_encabezado.Rows
            oselected = orow.Cells("sel").Value.ToString
            If oselected = "True" Then
                otb_rm_sel.Rows.Add(orow.Cells("id_rm").Value,
                                    orow.Cells("rm").Value,
                                    orow.Cells("nit").Value,
                                    orow.Cells("cliente").Value,
                                    orow.Cells("id_tercero").Value,
                                    orow.Cells("ciudad").Value,
                                    orow.Cells("direccion").Value,
                                    orow.Cells("vendedor").Value,
                                    orow.Cells("nit_vendedor").Value,
                                    orow.Cells("id_ciudad").Value)
            End If
        Next

        'validamos que se hallan seleccionado tadas las remisiones del mismo cliente
        Dim remision As String = ""
        Dim id_encabezado As Integer
        Dim cliente As String = ""
        Dim id_terceroCliente As String = ""
        Dim ciudad As String = ""
        Dim direccion As String = ""
        Dim nit As String = ""
        Dim digv As String = ""
        Dim cvendedor As String = ""
        Dim id_tercero_vendedor As String = ""
        Dim cant_sel As Integer
        Dim cant_pend As Integer
        Dim id_ciudad As String = ""
        Dim generar_despacho As String = "S"
        Dim id_despacho As String = ""
        Dim falla_inventario As String = "N"
        Dim otx_inventario_insuficiente As String = "Inventario insuficiente para el producto:" & vbCrLf
        Dim desc_inv As String = "S" 'Para saber si controlar inventarios de PT.
        desc_inv = comunes.suministrar_valor_variable_configuracion("CONFIG-0300-03", vg_id_cia)
        For Each orow As DataRow In otb_rm_sel.Rows
            generar_despacho = "S"
            verror = "N"
            remision = orow("rm")
            id_terceroCliente = orow("id_tercero")
            id_encabezado = orow("id_rm")
            cliente = orow("cliente")
            nit = orow("nit")
            ciudad = orow("ciudad")
            id_ciudad = orow("id_ciudad")
            direccion = orow("direccion")
            cvendedor = orow("vendedor")
            id_tercero_vendedor = orow("nit_vendedor")
            'Verificamos seleccion completa
            cant_sel = buscar_cantidad_registros_mismo_cliente(otb_rm_sel, cliente, ciudad, direccion)
            cant_pend = buscar_cantidad_registros_mismo_cliente(otb_remisiones_sin_despacho_asignado, cliente, ciudad, direccion)
            If cant_sel <> cant_pend Then
                MsgBox("No estan todas las remisiones seleccionadas para:" & vbCrLf _
                       & "Cliente     : " & cliente & vbCrLf _
                       & "Ciudad     : " & ciudad & vbCrLf _
                       & "Direccion : " & direccion & vbCrLf _
                       & cant_sel & " seleccionadas de " & cant_pend & " pendientes." & vbCrLf & vbCrLf _
                       & "NO SE GENERA ORDEN DE CARGUE.", MsgBoxStyle.Exclamation, "Info")
                generar_despacho = "N"
                verror = "S"
            End If
            'verifico que todos los items estan identificados
            falla_items = "N"
            identificar_item_remision(id_encabezado)
            If falla_items = "S" Then
                generar_despacho = "N"
                Dim tx As String = "No se cargo por falla en items la REMISION: " & remision & vbCrLf & vbCrLf
                MsgBox(tx & txt_falla_item, MsgBoxStyle.Information, "Info")
                verror = "S"
            End If
            'Identifico el vendedor
            ' Buscar id_tercero en tb_clientes que tiene todos los terceros
            Dim error_vendedor As String = "N"
            Dim filavendedor = (From c In otb_clientes.AsEnumerable()
                                Where c.Field(Of String)("f0200_id") = id_tercero_vendedor
                                Select c).FirstOrDefault()
            If filavendedor IsNot Nothing Then
                id_tercero_vendedor = filavendedor.Field(Of String)("f0200_id_tercero")
            Else
                error_vendedor = "S"
            End If
            If error_vendedor = "S" Then
                generar_despacho = "N"
                MsgBox("No se cargo la REMISION: " & remision & vbCrLf & vbCrLf & "Vendedor no definido", MsgBoxStyle.Exclamation, "Info")
                verror = "S"
            End If


            'Identifico que exista ciudad y direccion de despacho
            If ciudad = "" Or direccion = "" Then
                generar_despacho = "N"
                MsgBox("No se cargo la REMISION: " & remision & vbCrLf & vbCrLf & "Ciudad o Direccion no definidos", MsgBoxStyle.Exclamation, "Info")
                verror = "S"
            End If
            If generar_despacho = "S" Then
                'Dim otb_list_clientes As DataTable = otb_rm_sel.DefaultView.ToTable(True, "cliente")
                'MsgBox(otb_list_clientes.Rows.Count)

                'Verifico que la rm no este programada, dos usuarios con el mismo form abierto....
                Dim rm_programada As String = "N"
                rm_programada = verificar_que_rm_no_este_programada(id_encabezado)
                If rm_programada = "N" Then
                    'Descontamos del inventario los productos remisionados
                    'Verifico si se debe descontar de inventario cuando se remisiona.
                    If desc_inv = "S" Then
                        'verifico inventario para cada producto remisionado.
                        csql = "select * from " & database.obtener_esquema & ".tb0851_remisiones_cguno_detalle" _
                            & " where f0851_id_rm = '" & id_encabezado & "'"
                        Dim otb_productos_rm As DataTable
                        otb_productos_rm = cl_utilidades_datatables.cargar_informacion_postgres(csql)
                        'Primero valido existencias
                        Dim inventario As Decimal = 0
                        Dim cant_desp As Decimal = 0
                        For Each orow_prod As DataRow In otb_productos_rm.Rows
                            inventario = cl_utilidades_gestion_compras.suministrar_inventario_item_bodega(id_bodega, orow_prod("f0851_id_item"))
                            cant_desp = orow_prod("f0851_cantidad")
                            If inventario - cant_desp < 0 Then
                                Dim orow_item As DataRow()
                                orow_item = otb_items.Select("f0300_id_item = '" & orow_prod("f0851_id_item") & "'", "")
                                otx_inventario_insuficiente += orow_prod("f0851_rm") & ": " & "(" _
                                    & orow_prod("f0851_id_item") & ") - " & orow_item(0)("descripcion_larga") _
                                    & " Inv: " & inventario.ToString("F2") & " Req: " & cant_desp.ToString("F2") & vbCrLf
                                falla_inventario = "S"
                            End If
                        Next
                        If falla_inventario = "S" Then
                            MsgBox(otx_inventario_insuficiente, MsgBoxStyle.Exclamation, "Info")
                        Else
                            'Creo el nuevo documento
                            Dim ofecha As DateTime = comunes.g_fechahora
                            Dim consecutivo As Integer = cl_utilidades_gestion_compras.suministrar_consecutivo_nuevo_documento_mov_inventario(5, vg_id_cia)
                            Dim cod_documento As String = "RMS-" & consecutivo.ToString.PadLeft(8, "0")
                            Dim docto_origen As String = "f0850_id_rm-" & id_encabezado
                            cl_utilidades_gestion_compras.grabar_nuevo_documento_mov_inventario(cod_documento, id_bodega, 5, ofecha, vg_usuario_autoriza, vg_id_cia,
                                                                                                docto_origen, remision)
                            Dim ocont As Integer = 1
                            For Each orow_prod As DataRow In otb_productos_rm.Rows
                                'descargo los productos de inventario
                                cl_utilidades_gestion_compras.grabar_nuevo_movimiento_inventario(cod_documento, id_bodega, ocont,
                                                                                                 orow_prod("f0851_id_item"), 0,
                                                                                                 orow_prod("f0851_cantidad"),
                                                                                                 ofecha, vg_usuario_autoriza,
                                                                                                 vg_id_cia)
                                ocont += 1
                            Next
                        End If
                    End If

                    If falla_inventario = "N" Then
                        'Asignamos un despacho
                        id_despacho = gestionar_despacho_para_remision(id_terceroCliente, id_tercero_vendedor, "24", direccion, id_ciudad)
                        'Asignamos la Remision al despacho
                        asignar_despacho_y_tercero_a_remision(id_despacho, id_encabezado, id_terceroCliente)
                        'identificamos el total de unidades remisionadas
                        Dim tot_unid_rem As Decimal
                        tot_unid_rem = consultar_total_unidades_remisionadas(id_despacho)
                        'actualizamos en el despacho el total de cajas remisionadas
                        actualizar_tot_unid_remisionadas_despacho(id_despacho, tot_unid_rem)
                    End If
                End If
            End If
        Next
        If verror = "N" Then
            If falla_inventario = "S" Then
                MsgBox("Falla en alguna(s) REMISIONES por inventario insuficiente!!!", MsgBoxStyle.Information, "Info")
            Else
                MsgBox("Remisiones programadas", MsgBoxStyle.Information, "Info")
            End If
            Dispose()
        End If
    End Sub

    Private Function consultar_total_unidades_remisionadas(ByVal id_despacho As Integer)
        csql = comunes.suministrar_valor_variable_configuracion("ST-0800-19", vg_id_cia)
        csql = csql.Replace("$df001$", database.obtener_esquema)
        csql = csql.Replace("$001$", id_despacho)
        Dim otb_tot_unid_rem As DataTable
        otb_tot_unid_rem = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim tot_unid_rem As Decimal = 0
        If otb_tot_unid_rem.Rows.Count <> 0 Then
            For Each orow As DataRow In otb_tot_unid_rem.Rows
                tot_unid_rem = orow("ped")
            Next
        End If
        Return tot_unid_rem
    End Function

    Private Sub actualizar_tot_unid_remisionadas_despacho(ByVal id_despacho As Integer, ByVal unid_rem As Decimal)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0800_despachos_comercial set" _
                    & " f0800_tot_cajas_aprobadas = @f0800_tot_cajas_aprobadas" _
                    & " where f0800_id_despacho = @f0800_id_despacho"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0800_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("f0800_tot_cajas_aprobadas", NpgsqlDbType.Numeric).Value = unid_rem
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! asignar tercero a remision" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al asignar tercero a remision" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub bt_anular_Click(sender As Object, e As EventArgs) Handles bt_anular.Click
        Dim oselected As String 'para identificar cuales regsitrso fueron selecccionados por el checkbox
        Dim id_rm As Integer
        'Verifico que haya al menos una remision seleccionada
        Dim remision_seleccionada As String = "N"
        For Each orow As DataGridViewRow In dg_remision_encabezado.Rows
            oselected = orow.Cells("sel").Value.ToString
            If oselected = "True" Then
                remision_seleccionada = "S"
            End If
        Next
        If remision_seleccionada = "N" Then
            MsgBox("No hay remisiones seleccionadas para anular.", MsgBoxStyle.Exclamation, "Info")
            Exit Sub
        End If

        Dim anular_msg As MsgBoxResult
        anular_msg = MsgBox("Se procederá a anular las remisiones seleccionadas." & vbCrLf _
                         & "¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmar")
        If anular_msg = MsgBoxResult.No Then
            Exit Sub
        End If
        For Each orow As DataGridViewRow In dg_remision_encabezado.Rows
            oselected = orow.Cells("sel").Value.ToString
            If oselected = "True" Then
                id_rm = orow.Cells("id_rm").Value
                'Verifico que la rm no este programada, dos usuarios con el mismo form abierto....
                Dim rm_programada As String = "N"
                rm_programada = verificar_que_rm_no_este_programada(id_rm)
                If rm_programada = "N" Then
                    anular_remision(id_rm)
                End If
            End If
        Next
        If verror = "N" Then
            MsgBox("Remisiones Anuladas", MsgBoxStyle.Information, "Info")
            'muestro las remisiones sin agignar a un despacho
            cargar_dg_remisiones_sin_asignar()
        End If
    End Sub

    Private Sub anular_remision(ByVal id_rm As Integer)
        csql = "select * from " & database.obtener_esquema & ".fnc_800_03_anularremisionunoee('" & id_rm & "', '" & vg_usuario_autoriza & "')"
        verror = cl_utilidades_datatables.ejecutar_csql(csql)
        'MsgBox("Remision Anulada: " & id_rm)
    End Sub

    'Buscamos en el listado de pendientes despachos al mismo cliente sin identificar
    Private Function buscar_cantidad_registros_mismo_cliente(ByVal otb As DataTable,
                                                             ByVal cliente As String,
                                                             ByVal ciudad As String,
                                                             ByVal direccion As String)
        Dim cantidad As Integer
        Dim apariciones As DataRow()
        apariciones = otb.Select("cliente = '" & cliente & "' and" _
                                & " ciudad = '" & ciudad & "' and" _
                                & " direccion = '" & direccion & "'")
        cantidad = apariciones.Count
        Return cantidad
    End Function
    Private Sub actualizar_tercero(ByVal id_tercero As String, ByVal direccion As String,
                                   razon_social As String, id_ciudad As String)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0200_terceros set" _
                    & " f0200_nombres = @f0200_nombres," _
                    & " f0200_ciudad_residencia = @f0200_ciudad_residencia," _
                    & " f0200_direccion_residencia = @f0200_direccion_residencia," _
                    & " f0200_fm = @f0200_fm," _
                    & " f0200_usuario_modificar = @f0200_usuario_modificar" _
                    & " where f0200_id_tercero = @f0200_id_tercero"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0200_ciudad_residencia", NpgsqlDbType.Varchar).Value = id_ciudad
        ocmd.Parameters.Add("f0200_direccion_residencia", NpgsqlDbType.Varchar).Value = direccion
        ocmd.Parameters.Add("f0200_nombres", NpgsqlDbType.Varchar).Value = razon_social
        ocmd.Parameters.Add("f0200_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0200_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar tercero" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error actualizando tercero" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub crear_nuevo_tercero(ByVal nit As String, ByVal dig_verific As String,
                                    ByVal razon_soc As String, ByVal direccion As String, ByVal id_ciudad As String, ByVal id_sucursal_fact As String)
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "insert into " + database.obtener_esquema + ".tb0200_terceros" _
            & " (" _
            & " f0200_id_cia, f0200_id_tercero, f0200_nombres," _
            & " f0200_ind_cliente, f0200_id, f0200_dig_ver_nit," _
            & " f0200_ciudad_residencia, f0200_direccion_residencia," _
            & " f0200_id_tipo_identificacion, f0200_usuario_crear," _
            & " f0200_usuario_modificar, f0200_id_sucursal_unoee" _
            & ") values" _
            & " (" _
            & " @f0200_id_cia, @f0200_id_tercero, @f0200_nombres," _
            & " @f0200_ind_cliente, @f0200_id, @f0200_dig_ver_nit," _
            & " @f0200_ciudad_residencia, @f0200_direccion_residencia," _
            & " @f0200_id_tipo_identificacion, @f0200_usuario_crear," _
            & " @f0200_usuario_modificar, @f0200_id_sucursal_unoee" _
            & ")" _
            & " RETURNING f0200_id_tercero"

        ocmd.CommandText = csql

        id_tercero = cl_utilidades_datatables.obtener_nuevo_consecutivo_tablas("f0200_id_tercero", "tb0200_terceros").ToString.PadLeft(8, "0")

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0200_id", NpgsqlDbType.Varchar).Value = nit
        ocmd.Parameters.Add("f0200_dig_ver_nit", NpgsqlDbType.Varchar).Value = dig_verific
        ocmd.Parameters.Add("f0200_ciudad_residencia", NpgsqlDbType.Varchar).Value = id_ciudad
        ocmd.Parameters.Add("f0200_direccion_residencia", NpgsqlDbType.Varchar).Value = direccion
        ocmd.Parameters.Add("f0200_id_tipo_identificacion", NpgsqlDbType.Varchar).Value = "NIT"
        ocmd.Parameters.Add("f0200_nombres", NpgsqlDbType.Varchar).Value = razon_soc
        ocmd.Parameters.Add("f0200_ind_cliente", NpgsqlDbType.Varchar).Value = "S"
        ocmd.Parameters.Add("f0200_usuario_modificar", NpgsqlDbType.Varchar).Value = "00000001"
        ocmd.Parameters.Add("f0200_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0200_id_sucursal_unoee", NpgsqlDbType.Varchar).Value = id_sucursal_fact
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
                MsgBox("Hubo un error grabando nuevo tercero" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub actualizar_sucursal_tercero(ByVal _IdTtercero As String, _IdSucursalUnoee As String)
        'cuando se crea un nuevo tercero se debe asignar un unico codigo de sucursal debido a al constraint de unicidad

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0200_terceros set" _
                    & " f0200_id_sucursal_unoee = @f0200_id_sucursal_unoee," _
                    & " f0200_ind_cliente = 'S'" _
                    & " where f0200_id_tercero = @f0200_id_tercero"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = _IdTtercero
        ocmd.Parameters.Add("f0200_id_sucursal_unoee", NpgsqlDbType.Varchar).Value = _IdSucursalUnoee

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar codigo sucursal" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error actualizando codigo sucursal" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub actualizar_datos_encabezado_factura(ByVal f0850_id_rm As Integer, ciudad As String, direccion As String, id_ciudad As String)
        '
        'cuando se crea un nuevo tercero se debe asignar un unico codigo de sucursal debido a al constraint de unicidad
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0850_remisiones_cguno_encabezado set" _
                    & " f0850_ciudad_destino = @f0850_ciudad_destino," _
                    & " f0850_direccion_destino = @f0850_direccion_destino," _
                    & " f0850_id_ciudad_destino = @f0850_id_ciudad_destino" _
                    & " where f0850_id_rm = @f0850_id_rm"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0850_id_rm", NpgsqlDbType.Integer).Value = f0850_id_rm
        ocmd.Parameters.Add("f0850_ciudad_destino", NpgsqlDbType.Varchar).Value = ciudad
        ocmd.Parameters.Add("f0850_direccion_destino", NpgsqlDbType.Varchar).Value = direccion
        ocmd.Parameters.Add("f0850_id_ciudad_destino", NpgsqlDbType.Varchar).Value = id_ciudad

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un Error al Compilar comando! actualizar codigo sucursal" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un Error actualizando codigo sucursal" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub
    Private Sub AsignarTerceroCamoTodosEncabezadosNitSucursal(_nit As String, _id_tercero As String, _sucUnoEE As String,
                                                              _ciudad As String, _direccion As String, _id_ciudad As String)
        '
        'cuando se crea un nuevo tercero se debe asignar un unico codigo de sucursal debido a al constraint de unicidad
        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0850_remisiones_cguno_encabezado Set" _
                    & " f0850_ciudad_destino = @f0850_ciudad_destino," _
                    & " f0850_direccion_destino = @f0850_direccion_destino," _
                    & " f0850_id_ciudad_destino = @f0850_id_ciudad_destino," _
                    & " f0850_id_tercero = @f0850_id_tercero" _
                    & " where f0850_anulado = 'N' and f0850_id_cia = '" & vg_id_cia & "'" _
                    & " And f0850_id_despacho Is null" _
                    & " And f0850_codigo_tercero = @f0850_codigo_tercero And f0850_id_sucursal_fact = @f0850_id_sucursal_fact"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0850_ciudad_destino", NpgsqlDbType.Varchar).Value = _ciudad
        ocmd.Parameters.Add("f0850_direccion_destino", NpgsqlDbType.Varchar).Value = _direccion
        ocmd.Parameters.Add("f0850_id_tercero", NpgsqlDbType.Varchar).Value = _id_tercero
        ocmd.Parameters.Add("f0850_codigo_tercero", NpgsqlDbType.Varchar).Value = _nit
        ocmd.Parameters.Add("f0850_id_sucursal_fact", NpgsqlDbType.Varchar).Value = _sucUnoEE
        ocmd.Parameters.Add("f0850_id_ciudad_destino", NpgsqlDbType.Varchar).Value = _id_ciudad
        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! asignando tercero" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error asignando tercero" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Sub identificar_item_remision(ByVal id_rem As Integer)
        Dim otb_items_rm As DataTable
        csql = "select * from " & database.obtener_esquema & ".tb0851_remisiones_cguno_detalle" _
            & " where f0851_id_rm = '" & id_rem & "'"
        otb_items_rm = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim id_item As Integer
        Dim id_rm_det As Integer
        Dim producto As String
        Dim ref1 As String = ""
        Dim ref2 As String = ""
        Dim FactorEmpaqueItemCg As Integer = 1
        Dim FactorEmpaqueSiesa As Integer = 1
        txt_falla_item = ""
        For Each orow As DataRow In otb_items_rm.Rows
            'Primero identifico el id_item
            id_item = 0
            id_rm_det = orow("f0851_id_rm_det")
            producto = orow("f0851_descripcion")
            ref1 = orow("f0851_referencia_1")
            ref2 = orow("f0851_referencia_2")

            FactorEmpaqueSiesa =
            If(IsDBNull(orow("f0851_factor_empaque_siesa")),
                0,
                Convert.ToInt32(orow("f0851_factor_empaque_siesa")))

            Dim info_item_cg As DtoItemCg = ObtenerDatosItemCG(ref1)
            FactorEmpaqueItemCg = If(info_item_cg?.Factor_empaque, 0)

            'Los factores de empaque no pueden ser cero o uno o diferentes
            ' Determinar si hay falla en los factores de empaque
            'Dim hayFalla As Boolean =
            '    (FactorEmpaqueItemCg <= 1) OrElse
            '    (FactorEmpaqueSiesa <= 1 AndAlso FactorEmpaqueSiesa <> FactorEmpaqueItemCg)

            'If hayFalla Then
            '    falla_items = "S"
            '    txt_falla_item =
            '        "Los factores de empaque de un Item en CAMO no pueden ser = 1 o diferentes entre CAMO y SIESA para:" & vbCrLf &
            '        producto & vbCrLf &
            '        " ( " & ref1 & " ) ( " & ref2 & " ) " & vbCrLf &
            '        " El factor de empaque debe ser el número de unidades que se despacha por caja o equivalente"
            'End If

            Dim otb_item_identificado() As DataRow
            'MsgBox(otb_items.Rows.Count)
            otb_item_identificado = otb_items.Select("f0300_referencia = '" & ref1 & "'") ' and f0300_referencia_empaque = '" & ref2 & "'")
            If otb_item_identificado.Length = 0 Then
                falla_items = "S"
                txt_falla_item = "No hay creado un Item en CAMO para:" & vbCrLf & producto & vbCrLf _
                    & " ( " & ref1 & " ) ( " & ref2 & " ) " & vbCrLf
            Else
                If otb_item_identificado.Length = 1 Then
                    For Each orow2 As DataRow In otb_item_identificado
                        id_item = orow2("f0300_id_item")
                        actualizar_item_de_remision(id_rm_det, id_item)
                    Next
                Else
                    falla_items = "S"
                    txt_falla_item = "Hay multiples items que coinciden con las referencias:" _
                           & vbCrLf & ref1 & vbCrLf & ref2 & vbCrLf
                End If
            End If
        Next
    End Sub

    Private Sub actualizar_item_de_remision(ByVal id_rm_det As String, ByVal id_item As Integer)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0851_remisiones_cguno_detalle set" _
                    & " f0851_id_item = '" & id_item & "'" _
                    & " where f0851_id_rm_det = '" & id_rm_det & "'"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        'ocmd.Parameters.Clear()
        'ocmd.Parameters.Add("f0200_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        'ocmd.Parameters.Add("f0200_fm", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! actualizar Item" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error actualizando Item" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub

    Private Function grabar_nuevo_despacho(ByVal id_tercero As String, ByVal id_vendedor As String, ByVal direccion_despacho As String, ByVal ciudad_despacho As String, ByVal id_bodega_despacho As String)
        Dim oid_despacho As Integer = 0
        'los datos de la ciudad de destino ya los obtuve cuando indetifique el tercero en el sub gestionar_identificacion_cliente.

        'Instancia la conexión que estará vigente para todas las operaciones CRUD
        oconn_form = database.obtener_conexion()

        'Inserción parametrizada
        csql = "INSERT INTO " & database.obtener_esquema & ".tb0800_despachos_comercial" _
                & " (f0800_id_cia," _
                & " f0800_cliente, f0800_vendedor," _
                & " f0800_id_ciudad_destino, f0800_direccion_destino," _
                & " f0800_usuario_modificar, f0800_usuario_crear, f0800_fm, f0800_id_bodega)" _
                & " VALUES" _
                & " (@f0800_id_cia," _
                & " @f0800_cliente, @f0800_vendedor," _
                & " @f0800_id_ciudad_destino, @f0800_direccion_destino," _
                & " @f0800_usuario_modificar, @f0800_usuario_crear, @f0800_fm, @f0800_id_bodega)" _
                & " RETURNING f0800_id_despacho;"

        ocmd = database.obtener_comando(oconn_form)
        ocmd.CommandText = csql
        'crear_parametros_pedido(ocmd)
        ocmd.Parameters.Clear()
        Dim fecha_actual As Date = comunes.g_fechahora
        ocmd.Parameters.Add("@f0800_id_cia", NpgsqlDbType.Varchar).Value = vg_id_cia
        ocmd.Parameters.Add("@f0800_cliente", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("@f0800_vendedor", NpgsqlDbType.Varchar).Value = id_vendedor
        ocmd.Parameters.Add("@f0800_id_ciudad_destino", NpgsqlDbType.Varchar).Value = ciudad_despacho
        ocmd.Parameters.Add("@f0800_direccion_destino", NpgsqlDbType.Varchar).Value = direccion_despacho
        ocmd.Parameters.Add("@f0800_usuario_modificar", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_usuario_crear", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("@f0800_fm", NpgsqlDbType.Timestamp).Value = fecha_actual
        ocmd.Parameters.Add("@f0800_id_bodega", NpgsqlDbType.Integer).Value = CInt(id_bodega_despacho)

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando nuevo despacho! " + vbCrLf + ex.ToString + vbCrLf + csql)
        End Try
        If verror = "N" Then
            Try
                'Compila el comando en la Base de datos.
                ocmd.Prepare()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Compilar comando nueva falla! " + vbCrLf + ex.ToString + vbCrLf + csql)
            End Try
            Try
                oid_despacho = ocmd.ExecuteScalar()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al Grabar nuevo despacho! " + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
        Return oid_despacho
    End Function

    Private Function gestionar_despacho_para_remision(ByVal id_tercero As String, ByVal id_vendedor As String,
                                                      ByVal id_bodega As String, ByVal direccion_despacho As String, ByVal id_ciudad_despacho As String)
        csql = "select * from " & database.obtener_esquema & ".fnc_800_01_gestionar_despacho_pt_desde_rm(" _
        & "'" & id_tercero & "'," & id_bodega & ")"
        Dim otb As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)
        Dim id_despacho As Integer = otb.Rows.Item(0).Field(Of Integer)(0)

        'MsgBox(id_despacho)
        If id_despacho = 0 Then
            id_despacho = grabar_nuevo_despacho(id_tercero, id_vendedor, direccion_despacho, id_ciudad_despacho, id_bodega)
        End If
        Return id_despacho
    End Function

    Private Sub asignar_despacho_y_tercero_a_remision(ByVal id_despacho As Integer, ByVal id_rm As Integer,
                                                      ByVal id_tercero As String)

        'Conectar base en postgres para actualizar tabla
        oconn_form = database.obtener_conexion()
        ocmd = database.obtener_comando(oconn_form)

        csql = "update " + database.obtener_esquema + ".tb0850_remisiones_cguno_encabezado set" _
                    & " f0850_id_despacho = @f0850_id_despacho," _
                    & " f0850_id_tercero = @f0850_id_tercero," _
                    & " f0850_usuario_asigna_despacho = @f0850_usuario_asigna_despacho," _
                    & " f0850_fecha_asignacion_despacho = @f0850_fecha_asignacion_despacho" _
                    & " where f0850_id_rm = @f0850_id_rm and f0850_anulado = 'N'"

        ocmd.CommandText = csql

        'Inserción parametrizada
        'crear_parametros_tb_terceros(ocmd)
        ocmd.Parameters.Clear()
        ocmd.Parameters.Add("f0850_id_despacho", NpgsqlDbType.Integer).Value = id_despacho
        ocmd.Parameters.Add("f0850_id_rm", NpgsqlDbType.Integer).Value = id_rm
        ocmd.Parameters.Add("f0850_id_tercero", NpgsqlDbType.Varchar).Value = id_tercero
        ocmd.Parameters.Add("f0850_usuario_asigna_despacho", NpgsqlDbType.Varchar).Value = vg_usuario_autoriza
        ocmd.Parameters.Add("f0850_fecha_asignacion_despacho", NpgsqlDbType.Timestamp).Value = comunes.g_fechahora

        verror = "N"
        Try
            'Compila el comando en la Base de datos.
            ocmd.Prepare()
        Catch ex As Exception
            verror = "S"
            MsgBox("Hubo un error al Compilar comando! asignar tercero a remision" + vbCrLf + ex.ToString)
        End Try

        If verror = "N" Then
            Try
                ocmd.ExecuteNonQuery()
            Catch ex As Exception
                verror = "S"
                MsgBox("Hubo un error al asignar tercero a remision" + vbCrLf + ex.ToString)
            End Try
        End If

        ocmd = Nothing
        oconn_form.Close()
    End Sub


    'AQUI INICIA LAS FUNCIONES DE IMPORTACION DE FACTURAS DE CGUNO

    Private Async Function CargarPaginaAsync(numPag As Integer) As Task(Of DataTable)

        Dim options As New RestClientOptions("https://apiqa.siesacloud.com") With {
        .Timeout = TimeSpan.FromMinutes(5)
    }

        Dim client As New RestClient(options)

        Dim filtro As String = "(f350_id_cia = 1 and f350_consec_docto >" & UltimoDoctoCia1.ToString() & ") or (f350_id_cia = 2 and f350_consec_docto > " & UltimoDoctoCia2.ToString() & ")"

        Dim filtroCodificado As String = Uri.EscapeDataString(filtro)

        Dim fullUrl As String =
        "https://api.siesacloud.com/connekta/siesa/estandar/consulta/v3" &
        "?idCompania=9174" &
        "&descripcion=API_v2_Ventas_Facturas_DesdePedido" &
        $"&paginacion=numPag={numPag}|tamPag=100" &
        $"&parametros={filtroCodificado}"

        Dim request As New RestRequest(fullUrl, Method.Get)

        request.AddHeader("client_id", "BNvQCwIKFzDP51D1QkzObw4Es79ELWTRG0jN0X1sL1dUJKe0")
        request.AddHeader("ConniKey", "ff96a448b64d3a764b2501749fd6e354")
        request.AddHeader("ConniToken", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjNiZjFiNGE5LTY3ZDUtNGU5MC1iYmI1LWJiMjRiNGJjY2U5NiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcHJpbWFyeXNpZCI6IjZiY2FhMDAwLTRkNTYtNGMwYS1iODRmLTcxY2JhMWM5NWNjMCJ9.6mqPMJgJwaUU2VCjdvTfIx_TXJGVOy2AZN6d7pZXo-Y")
        Dim response As RestResponse = Await client.ExecuteAsync(request)

        If Not response.IsSuccessful Then
            Return Nothing
        End If

        Dim json As JObject = JObject.Parse(response.Content)

        If json("codigo") IsNot Nothing AndAlso json("codigo").ToString() = "1" Then
            Return Nothing
        End If

        Dim tablaJson As JArray = CType(json("detalle")("Table"), JArray)

        If tablaJson Is Nothing OrElse tablaJson.Count = 0 Then
            Return Nothing
        End If

        Return tablaJson.ToObject(Of DataTable)()

    End Function

    Private Async Function ObtenerTotalPaginasYRegistrosAsync() As Task(Of (totalPaginas As Integer, totalRegistros As Integer))

        Dim pagina As Integer = 1
        Dim totalPaginas As Integer = 0
        Dim totalRegistros As Integer = 0

        While True

            Dim dtPagina As DataTable = Await CargarPaginaAsync(pagina)

            If dtPagina Is Nothing Then
                Exit While
            End If

            totalPaginas += 1
            totalRegistros += dtPagina.Rows.Count

            pagina += 1
        End While

        Return (totalPaginas, totalRegistros)

    End Function

    Private Async Function CargarTodasLasPaginasAsync() As Task(Of DataTable)

        ' 1. Obtener total de páginas y registros
        Dim info = Await ObtenerTotalPaginasYRegistrosAsync()
        Dim totalPaginas = info.totalPaginas
        Dim totalRegistros = info.totalRegistros

        If totalPaginas = 0 Then
            Return Nothing
        End If

        ' 2. Configurar barra de progreso
        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = totalPaginas
        ProgressBar1.Value = 0

        lblPaginas.Text = $"Páginas cargadas: 0 / {totalPaginas}"
        'lblRegistros.Text = $"Registros totales: 0 / {totalRegistros}"

        ' 3. Cargar todas las páginas
        Dim tablaFinal As New DataTable()
        Dim primeraVez As Boolean = True
        Dim pagina As Integer = 1
        Dim registrosAcumulados As Integer = 0

        While pagina <= totalPaginas

            Dim dtPagina As DataTable = Await CargarPaginaAsync(pagina)

            If dtPagina Is Nothing Then
                Exit While
            End If

            If primeraVez Then
                tablaFinal = dtPagina.Clone()
                primeraVez = False
            End If

            For Each fila As DataRow In dtPagina.Rows
                tablaFinal.ImportRow(fila)
            Next

            registrosAcumulados += dtPagina.Rows.Count

            ' Actualizar UI
            ProgressBar1.Value = pagina
            lblPaginas.Text = $"Páginas cargadas: {pagina} / {totalPaginas}"
            lblRegistros.Text = $"Registros totales: {registrosAcumulados} / {totalRegistros}"

            pagina += 1
        End While

        Return tablaFinal

    End Function



    Private Function GenerarEncabezadoYDetalleLINQ(dtOriginal As DataTable) As (Encabezado As DataTable, Detalle As DataTable)

        ' ============================
        ' 1. ENCABEZADO: valores únicos por combinación de campos
        ' ============================
        Dim encabezadoQuery = dtOriginal.AsEnumerable().
        GroupBy(Function(r) New With {
            Key .cia = r("f350_id_cia"),
            Key .tipo = r("f350_id_tipo_docto"),
            Key .consec = r("f350_consec_docto"),
            Key .fecha = r("f350_fecha"),
            Key .notas = r("f350_notas"),
            Key .nitFact = r("f200_nit_fact"),
            Key .razonFact = r("f200_razon_social_fact"),
            Key .sucursal = r("f461_id_sucursal_fact"),
            Key .nitVend = r("f200_nit_vendedor"),
            Key .razonVend = r("f200_razon_social_vendedor")
        }).
        Select(Function(g) g.First())

        Dim dtEncabezado As DataTable = encabezadoQuery.CopyToDataTable()

        ' ============================
        ' 2. DETALLE: todas las líneas con campos específicos
        ' ============================
        ' Crear estructura del DataTable Detalle
        Dim dtDetalle As New DataTable("Detalle")

        dtDetalle.Columns.Add("f350_id_cia", GetType(Integer))
        dtDetalle.Columns.Add("f350_id_tipo_docto", GetType(String))
        dtDetalle.Columns.Add("f350_consec_docto", GetType(Integer))
        dtDetalle.Columns.Add("f120_id", GetType(String))
        dtDetalle.Columns.Add("f120_referencia", GetType(String))
        dtDetalle.Columns.Add("f120_descripcion", GetType(String))
        dtDetalle.Columns.Add("f470_cant_1", GetType(Decimal))
        dtDetalle.Columns.Add("f470_id_unidad_medida", GetType(String))
        dtDetalle.Columns.Add("f470_factor", GetType(Decimal))
        dtDetalle.Columns.Add("f470_precio_uni", GetType(Decimal))
        dtDetalle.Columns.Add("f470_vlr_imp", GetType(Decimal))
        dtDetalle.Columns.Add("f470_vlr_neto", GetType(Decimal))

        ' Llenar usando LINQ + LoadDataRow (más rápido que Rows.Add)
        dtOriginal.AsEnumerable().
    Select(Function(r) dtDetalle.LoadDataRow(New Object() {
        r("f350_id_cia"),
        r("f350_id_tipo_docto"),
        r("f350_consec_docto"),
        r("f120_id"),
        r("f120_referencia"),
        r("f120_descripcion"),
        r("f470_cant_1"),
        r("f470_id_unidad_medida"),
        r("f470_factor"),
        r("f470_precio_uni"),
        r("f470_vlr_imp"),
        r("f470_vlr_neto")
    }, False)).ToList()

        Return (dtEncabezado, dtDetalle)

    End Function

    Private Async Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        ' Identifico los ultimos documentos cargados para cada compañia
        Dim ultimos As Dictionary(Of Integer, Integer) = IdentificarUltimaFacturaImportada()
        UltimoDoctoCia1 = ultimos(1)
        UltimoDoctoCia2 = ultimos(2)
        'MsgBox("Ultimo Cia 1: " & maxCia1 & vbCrLf & "Ultimo Cia 2: " & maxCia2)

        Dim dt As DataTable = Await CargarTodasLasPaginasAsync()

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron registros en ninguna página.")
            Exit Sub
        End If

        Dim resultado = GenerarEncabezadoYDetalleLINQ(dt)

        Dim dtEncabezado As DataTable = resultado.Encabezado
        Dim dtDetalle As DataTable = resultado.Detalle

        'RECORRER EL ENCABEZADO PARA GRABAR EN BD

        For Each rowEncabezado As DataRow In dtEncabezado.Rows
            'Asignar variables globales para grabar
            Select Case rowEncabezado("f350_id_cia").ToString()
                Case "1"
                    ofiscal = "1"
                Case "2"
                    ofiscal = "3"
                Case Else
                    ofiscal = "9" 'Por defecto
            End Select
            id_cia_factura = rowEncabezado("f350_id_cia")
            id_factura = rowEncabezado("f350_consec_docto")
            numero_rm = rowEncabezado("f350_id_tipo_docto") & "-" & rowEncabezado("f350_id_cia") & "-" & rowEncabezado("f350_consec_docto").ToString.PadLeft(6, "0")
            fecha_documento_rm = rowEncabezado("f350_fecha").ToString() 'Mid(rowEncabezado("f350_fecha").ToString(), 1, 10)
            razon_social = rowEncabezado("f200_razon_social_fact").ToString()
            codigo_cliente = rowEncabezado("f200_nit_fact").ToString()
            digito_verificacion = ""
            ciudad_cliente = ""
            direccion = ""
            id_sucursal_fact = rowEncabezado("f461_id_sucursal_fact").ToString()
            codigo_vendedor = rowEncabezado("f200_nit_vendedor").ToString()
            nombre_vendedor = rowEncabezado("f200_razon_social_vendedor").ToString()

            'COMO LOS DATOS IMPORTADOS NO TIENEN VALORES DE DIRECCION Y CIUDAD DEL CLIENTE, SE DEBE BUSCAR EN LA TABLA DE TERCEROS
            Dim info = ObtenerDatosPorId(codigo_cliente, id_sucursal_fact)

            Dim cter As String = ""
            cter = info.Id_tercero

            Select Case True
                Case IsNumeric(cter)
                    'SI ENCONTRO EL TERCERO
                    id_tercero = info.Id_tercero
                    direccion = info.Direccion
                    ciudad_cliente = info.Ciudad
                    id_ciudad_cliente = info.Id_Ciudad
                    'MsgBox("Tercero encontrado: " & id_tercero & " - " & razon_social)
                    'Verificar si el tercero tiene sucursal asignada
                    If info.Suc_Unoee = "" Then
                        'Actualizar sucursal del tercero
                        id_sucursal_unoee = id_sucursal_fact
                        actualizar_sucursal_tercero(id_tercero, id_sucursal_fact)
                    End If
                Case cter = "ND"
                    'NO ENCONTRO EL TERCERO, SE DEBE CREAR
                    'Crear nuevo tercero
                    'MsgBox("El cliente con NIT " & codigo_cliente & " no existe en la base de datos. Se creará un nuevo tercero.")
                    crear_nuevo_tercero(codigo_cliente, digito_verificacion, razon_social, direccion, ciudad_cliente, id_sucursal_fact)
                    'ACTUALIZAR EL DATATABLE otb_clientes PARA QUE LA PROXIMA VEZ NO TENGA QUE VOLVER A CREARLO
                    cargar_otb_clientes()
                Case Else
                    id_tercero = ""
            End Select

            grabar_encabezado_rm()



            'Obtener el ID de la factura recién creada (si es necesario)
            'id_factura = ObtenerIdFacturaRecienCreada() 'Implementar esta función si es necesario
            'Recorrer detalle para esta factura
            Dim detallesFactura = dtDetalle.AsEnumerable().
                Where(Function(r) r("f350_id_cia") = rowEncabezado("f350_id_cia") AndAlso
                                    r("f350_id_tipo_docto") = rowEncabezado("f350_id_tipo_docto") AndAlso
                                    r("f350_consec_docto") = rowEncabezado("f350_consec_docto"))
            For Each rowDetalle As DataRow In detallesFactura
                'Asignar variables globales para grabar detalle
                'numero_rm = numero_rm 'ya esta definido desde el encabezado
                referencia_1 = rowDetalle("f120_referencia")
                referencia_2 = rowDetalle("f470_id_unidad_medida") 'ESTE VALOR NO ES EL QUE SE USA EN 8.5 AQUI PONEN VALOR DISTRACTOR
                descripcion_producto = rowDetalle("f120_descripcion")
                'Para calcular la cantidad de cajas a despachar debo traer la informacion de los
                'items del cg, e identificar el factor de empaque.
                Dim info_item_cg As DtoItemCg = ObtenerDatosItemCG(referencia_1)
                Dim factor_empaque = info_item_cg.Factor_empaque
                If referencia_2.Trim = "UND" Then
                    cantidad_producto = rowDetalle("f470_cant_1") / info_item_cg.Factor_empaque
                Else
                    cantidad_producto = rowDetalle("f470_cant_1") / rowDetalle("f470_factor")
                End If
                cantidad_producto_original = rowDetalle("f470_cant_1")
                factor_empaque_siesa = rowDetalle("f470_factor")
                item_valor_unitario = rowDetalle("f470_precio_uni")
                item_valor_impuestos = rowDetalle("f470_vlr_imp")
                item_valor_neto = rowDetalle("f470_vlr_neto")

                grabar_detalle_rm()
            Next
        Next

        'muestro las remisiones sin agignar a un despacho
        cargar_dg_remisiones_sin_asignar()

        ' Mostrar total de registros del encabezado
        lblRegistros.Text = $"Registros totales (encabezado): {dtEncabezado.Rows.Count}"

    End Sub

    Private Function IdentificarUltimaFacturaImportada() As Dictionary(Of Integer, Integer)
        ' Retorna un diccionario con el consecutivo máximo por compañía (1 y 2).
        ' Llaves: id_cia (Integer). Valores: max(f0850_consec_docto) (Integer).
        Dim resultados As New Dictionary(Of Integer, Integer)
        resultados(1) = 0
        resultados(2) = 0

        csql = "select f0850_id_cia_unoee, coalesce(max(f0850_consec_doc_unoee), 0) as ultimo " _
         & "from " & database.obtener_esquema & ".tb0850_remisiones_cguno_encabezado " _
         & "where f0850_id_cia_unoee in (1,2) and f0850_anulado = 'N'" _
         & "group by f0850_id_cia_unoee"

        Dim otb As DataTable = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        If otb IsNot Nothing AndAlso otb.Rows.Count > 0 Then
            For Each orow As DataRow In otb.Rows
                Dim idCia As Integer = 0
                Dim ultimo As Integer = 0
                Integer.TryParse(orow("f0850_id_cia_unoee").ToString(), idCia)
                Integer.TryParse(orow("ultimo").ToString(), ultimo)
                If idCia = 1 OrElse idCia = 2 Then
                    resultados(idCia) = ultimo
                End If
            Next
        End If

        Return resultados
    End Function


    'Identificar el numero de sucursales asociadas a un cliente, el valor que identifica el cliente es el f0200_id que es el NIT
    Public Function ObtenerDatosPorId(idBuscado As String, id_sucursal_fact As String) As DtoTercero

        Dim resultado As New DtoTercero()

        ' Filtrar registros del cliente
        Dim filas = From f In otb_clientes.AsEnumerable()
                    Where f.Field(Of String)("f0200_id") = idBuscado
                    Select f

        Dim cantidad As Integer = filas.Count()

        ' --- Caso 0 registros ---
        If cantidad = 0 Then
            resultado.Id_tercero = "ND"
            resultado.Id_Ciudad = ""
            resultado.Ciudad = ""
            resultado.Direccion = ""
            resultado.Suc_Unoee = ""
            Return resultado
        End If

        ' --- Caso 1 registro ---
        If cantidad = 1 Then
            Dim fila = filas.First()
            Return ConstruirResultadoDesdeFila(fila)
        End If

        ' --- Caso más de 1 registro ---
        ' Buscar si existe uno con la sucursal igual a id_sucursal_fact
        Dim filaMatch = (From f In filas
                         Where f.Field(Of String)("f0200_id_sucursal_unoee") = id_sucursal_fact
                         Select f).FirstOrDefault()

        If filaMatch IsNot Nothing Then
            Return ConstruirResultadoDesdeFila(filaMatch)
        End If

        ' Si no hay coincidencia con la sucursal
        resultado.Id_tercero = "Varios"
        resultado.Id_Ciudad = ""
        resultado.Ciudad = ""
        resultado.Direccion = ""
        resultado.Suc_Unoee = ""
        Return resultado

    End Function

    'Identificar la informacion de los items cg para calcular cajas a despachar
    Public Function ObtenerDatosItemCG(referencia As String) As DtoItemCg
        Dim resultado As New DtoItemCg()
        ' Filtrar registros del item cg
        Dim filas = From f In otb_items_cg.AsEnumerable()
                    Where f.Field(Of String)("f0408_referencia") = referencia
                    Select f

        Dim fila = filas.First()
        resultado.Referencia = fila.Field(Of String)("f0408_referencia")
        resultado.Factor_empaque = fila.Field(Of Decimal)("f0408_factor_empaque")
        Return resultado
    End Function

    'Identificar la informacion de la sucursal usando el id_tercero
    Public Function ObtenerDatosPorIdTercero(idTercero As String) As DtoTercero

        Dim resultado As New DtoTercero()

        ' Filtrar registros del cliente
        Dim filas = From f In otb_clientes.AsEnumerable()
                    Where f.Field(Of String)("f0200_id_tercero") = idTercero
                    Select f

        Dim fila = filas.First()

        Return ConstruirResultadoDesdeFila(fila)

    End Function

    Private Function ConstruirResultadoDesdeFila(fila As DataRow) As DtoTercero
        Dim r As New DtoTercero()

        Dim idTercero As String = fila.Field(Of String)("f0200_id_tercero")
        Dim idCiudad As String = fila.Field(Of String)("f0200_ciudad_residencia")
        Dim direccion As String = fila.Field(Of String)("f0200_direccion_residencia")
        Dim sucUnoee As String = fila.Field(Of String)("f0200_id_sucursal_unoee")
        Dim Nit As String = fila.Field(Of String)("f0200_id")

        ' Buscar ciudad en tb_ciudades
        Dim ciudadNombre As String = ""
        Dim filaCiudad = (From c In otb_ciudades.AsEnumerable()
                          Where c.Field(Of String)("f0052_codigo_ciudad") = idCiudad
                          Select c).FirstOrDefault()

        If filaCiudad IsNot Nothing Then
            ciudadNombre = filaCiudad.Field(Of String)("destino")
        End If

        r.Id_tercero = idTercero
        r.Id_Ciudad = idCiudad
        r.Ciudad = ciudadNombre
        r.Direccion = direccion
        r.Suc_Unoee = sucUnoee
        r.Nit = Nit

        Return r
    End Function

    Private Sub bt_asignar_sucursal_Click(sender As Object, e As EventArgs) Handles bt_asignar_sucursal.Click
        Dim filtro As String = ""
        If Tx_Nit.Text <> "" Then
            filtro = "nit LIKE '%" & Tx_Nit.Text.Trim & "%'"
        Else
            MsgBox("Seleccione un registro", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ' Si hay asignado un tercero, editar ese tercero
        If tx_id_tercero.Text.Trim <> "" Then
            Dim actualizado As String = "N"
            actualizado = abrir_form_sucursal(DtoDgEnEdicion.Id_tercero)
            If actualizado = "S" Then
                cargar_otb_clientes()
                'Traigo el id_ciudad y la direccion del tercero actualizado
                Dim _dto1 As DtoTercero = ObtenerDatosPorIdTercero(DtoDgEnEdicion.Id_tercero)
                DtoDgEnEdicion.Id_Ciudad = _dto1.Id_Ciudad
                DtoDgEnEdicion.Direccion = _dto1.Direccion
                ' Buscar ciudad en tb_ciudades
                Dim filaCiudad1 = (From c In otb_ciudades.AsEnumerable()
                                   Where c.Field(Of String)("f0052_codigo_ciudad") = DtoDgEnEdicion.Id_Ciudad
                                   Select c).FirstOrDefault()
                If filaCiudad1 IsNot Nothing Then
                    DtoDgEnEdicion.Ciudad = filaCiudad1.Field(Of String)("destino")
                End If
                actualizar_datos_encabezado_factura(DtoDgEnEdicion.Id_Docto_Gestion, DtoDgEnEdicion.Ciudad, DtoDgEnEdicion.Direccion, DtoDgEnEdicion.Id_Ciudad)
                cargar_dg_remisiones_sin_asignar()
                Exit Sub
            End If
            Exit Sub
        End If

        ' Si hay varias sucursales para el NIT, abrir buscador para seleccionar la correcta
        Dim _id_tercero As String = ""
        _id_tercero = comunes.Buscador_Terceros("ST-0210-02", vg_id_cia, vg_usuario_autoriza, filtro)
        If _id_tercero = "" Then
            MsgBox("No se seleccionó ningún tercero.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'validar que no se haya seleccionado un cliente diferente o una sucursal que ya este asignada
        verror = "N"
        Dim info = ObtenerDatosPorIdTercero(_id_tercero)
        If info.Nit <> DtoDgEnEdicion.Nit Then
            verror = "S"
            MsgBox("El tercero seleccionado no coincide con el NIT ingresado.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If info.Suc_Unoee <> "" Then
            verror = "S"
            MsgBox("El tercero seleccionado ya tiene una sucursal asignada: " & info.Suc_Unoee, MsgBoxStyle.Critical)
            Exit Sub
        End If
        DtoDgEnEdicion.Id_tercero = _id_tercero
        ' Actualizar la sucursal del tercero seleccionado cambiar direccion y ciudad  
        'id_sucursal_unoee = tx_id_sucursal_unoee.Text.Trim
        'Dim id_rm As String = Tx_IdRm.Text.Trim
        actualizar_sucursal_tercero(DtoDgEnEdicion.Id_tercero, DtoDgEnEdicion.Suc_Unoee)
        cargar_otb_clientes()
        'Traigo el id_ciudad y la direccion del tercero actualizado
        Dim _dto2 As DtoTercero = ObtenerDatosPorIdTercero(DtoDgEnEdicion.Id_tercero)
        DtoDgEnEdicion.Id_Ciudad = _dto2.Id_Ciudad
        DtoDgEnEdicion.Direccion = _dto2.Direccion
        ' Buscar ciudad en tb_ciudades
        Dim filaCiudad2 = (From c In otb_ciudades.AsEnumerable()
                           Where c.Field(Of String)("f0052_codigo_ciudad") = DtoDgEnEdicion.Id_Ciudad
                           Select c).FirstOrDefault()
        If filaCiudad2 IsNot Nothing Then
            DtoDgEnEdicion.Ciudad = filaCiudad2.Field(Of String)("destino")
        End If

        'Actualizo los datos del encabezado con los nuevos datos del tercero
        AsignarTerceroCamoTodosEncabezadosNitSucursal(DtoDgEnEdicion.Nit, _dto2.Id_tercero,
                                                      DtoDgEnEdicion.Suc_Unoee, DtoDgEnEdicion.Ciudad,
                                                      _dto2.Direccion, _dto2.Id_Ciudad)
        cargar_otb_remisiones_sin_asignar()
        cargar_dg_remisiones_sin_asignar()
    End Sub
    Private Function abrir_form_sucursal(id_tercero As String)
        Dim actualizado As String = "N"
        Using frm As New camocontrol.fm_0200_tercero_sucursal
            frm.vf_oform_padre = Me
            frm.vg_id_cia = vg_id_cia
            frm.vg_usuario_autoriza = vg_usuario_autoriza
            frm.vf_elemento_nuevo = "N"
            frm.id_tercero = id_tercero

            If frm.ShowDialog() = DialogResult.OK Then
                'DtoDgEnEdicion = frm.Resultado 'NO ES NECESARIO RETORNAR EL DTO PORUQE SOLO SE ACTUALIZO LA CIUDAD Y DIRECCION Y BORRA EL ID_RM
                actualizado = "S"
            Else
                MessageBox.Show("Operación Cancelada")
            End If
        End Using
        Return actualizado
    End Function
    Private Sub dg_remision_encabezado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_remision_encabezado.CellClick
        If dg_remision_encabezado.Rows.Count = 0 Then
            Exit Sub
        End If
        If dg_remision_encabezado.CurrentRow IsNot Nothing Then
            Dim val = dg_remision_encabezado.CurrentRow.Cells("nit").Value
            Tx_Nit.Text = If(val Is Nothing OrElse IsDBNull(val), String.Empty, val.ToString())
            DtoDgEnEdicion.Nit = Tx_Nit.Text
            val = dg_remision_encabezado.CurrentRow.Cells("id_tercero").Value
            tx_id_tercero.Text = If(val Is Nothing OrElse IsDBNull(val), String.Empty, val.ToString())
            DtoDgEnEdicion.Id_tercero = tx_id_tercero.Text
            val = dg_remision_encabezado.CurrentRow.Cells("id_rm").Value
            Tx_IdRm.Text = If(val Is Nothing OrElse IsDBNull(val), String.Empty, val.ToString())
            DtoDgEnEdicion.Id_Docto_Gestion = Tx_IdRm.Text
            val = dg_remision_encabezado.CurrentRow.Cells("id_suc_unoee").Value
            tx_id_sucursal_unoee.Text = If(val Is Nothing OrElse IsDBNull(val), String.Empty, val.ToString())
            DtoDgEnEdicion.Suc_Unoee = tx_id_sucursal_unoee.Text
        End If
    End Sub
End Class

Public Class DtoItemCg
    Public Property Referencia As String
    Public Property Factor_empaque As Integer
End Class
