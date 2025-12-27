Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.Text.Json
Imports System.Text.Json.Serialization

Public Class Pedido
    <JsonPropertyName("Encabezado")>
    Public Property Encabezado As PedidoEncabezado

    <JsonPropertyName("Detalle")>
    Public Property Detalle As List(Of PedidoDetalleItem)

    Public Shared Function FromJson(json As String) As Pedido
        Dim options As New JsonSerializerOptions With {
            .PropertyNameCaseInsensitive = True,
            .AllowTrailingCommas = True
        }
        Return JsonSerializer.Deserialize(Of Pedido)(json, options)
    End Function
End Class

Public Class PedidoEncabezado
    <JsonPropertyName("id_pedido")>
    Public Property IdPedido As Integer

    <JsonPropertyName("id_compañia")>
    Public Property IdCompania As String

    <JsonPropertyName("fecha")>
    Public Property Fecha As DateTime

    <JsonPropertyName("cliente_id")>
    Public Property ClienteId As String

    <JsonPropertyName("cliente_nombre")>
    Public Property ClienteNombre As String

    <JsonPropertyName("direccion_envio")>
    Public Property DireccionEnvio As String

    <JsonPropertyName("ciudad_envio")>
    Public Property CiudadEnvio As String

    <JsonPropertyName("código_vendedor")>
    Public Property CodigoVendedor As String

    <JsonPropertyName("nombre_vendedor")>
    Public Property NombreVendedor As String

    <JsonPropertyName("moneda")>
    Public Property Moneda As String

    <JsonPropertyName("subtotal")>
    Public Property Subtotal As Decimal

    <JsonPropertyName("descuento")>
    Public Property Descuento As Decimal

    <JsonPropertyName("impuestos")>
    Public Property Impuestos As Decimal

    <JsonPropertyName("retenciones")>
    Public Property Retenciones As Decimal

    <JsonPropertyName("total")>
    Public Property Total As Decimal
End Class

Public Class PedidoDetalleItem
    <JsonPropertyName("producto_id")>
    Public Property ProductoId As String

    <JsonPropertyName("descripción")>
    Public Property Descripcion As String

    <JsonPropertyName("unidad_medida")>
    Public Property UnidadMedida As String

    <JsonPropertyName("cantidad")>
    Public Property Cantidad As Decimal

    <JsonPropertyName("precio_unitario")>
    Public Property PrecioUnitario As Decimal

    <JsonPropertyName("impuesto_iva")>
    Public Property ImpuestoIva As Decimal

    <JsonPropertyName("total_linea")>
    Public Property TotalLinea As Decimal
End Class