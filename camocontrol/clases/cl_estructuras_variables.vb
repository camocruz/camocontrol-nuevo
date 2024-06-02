Public Class cl_estructuras_variables
    'Estructura creada para almacenar datos de items movimientos de inventario
    Public Structure info_item_mov_inventario
        Public rango_item() As Decimal  '1=id_item, 2=cantidad, 3 {1 entrada; 2 salida}
        Public id_item As Integer
        Public cantidad As Decimal
        Public tipo_movimiento As Integer '{1 entrada; 2 salida}
        Public clasificador As Integer
        Public info_trazabilidad As DataTable
    End Structure
End Class
