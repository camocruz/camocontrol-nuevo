Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data

Public Module JsonToTablesHelper

    Public Function GenerarEncabezadoYDetalle(json As String,
                                              rutaTabla As String,
                                              columnasEncabezado As IEnumerable(Of String)
                                             ) As (Encabezado As DataTable, Detalle As DataTable)

        Dim root As JObject = JObject.Parse(json)

        ' Navegar la ruta dinámica (ej: "detalle.Table")
        Dim partes = rutaTabla.Split("."c)
        Dim token As JToken = root

        For Each p As String In partes

            If token Is Nothing Then
                Throw New Exception($"Ruta inválida: el nodo '{p}' no existe en el JSON.")
            End If

            token = token(p)

        Next

        Dim jArray As JArray = CType(token, JArray)

        ' Crear DataTable de detalle
        Dim dtDetalle As New DataTable("Detalle")

        ' Detectar columnas dinámicamente
        For Each prop As JProperty In jArray.First.Children(Of JProperty)()
            dtDetalle.Columns.Add(prop.Name, GetType(Object))
        Next

        ' Poblar detalle
        For Each item As JObject In jArray
            Dim row = dtDetalle.NewRow()
            For Each col As DataColumn In dtDetalle.Columns
                row(col.ColumnName) = item(col.ColumnName)
            Next
            dtDetalle.Rows.Add(row)
        Next

        ' Crear encabezado agrupado (sin argumentos con nombre)
        Dim dtEncabezado As DataTable =
            dtDetalle.DefaultView.ToTable(
                "Encabezado",
                True,
                columnasEncabezado.ToArray()
            )

        Return (dtEncabezado, dtDetalle)

        ' Ejemplo de uso: ( para la consulta de API_v2_Inventarios_InvFecha)
        '        Dim columnas = {
        '    "f120_id_cia",
        '    "f150_id",
        '    "f120_id",
        '    "f120_referencia"
        '}

        '        Dim resultado = JsonToTablesHelper.GenerarEncabezadoYDetalle(
        '                    json,
        '                    "detalle.Table",
        '                    columnas
        '                )

        '        Dim dtEnc = resultado.Encabezado
        '        Dim dtDet = resultado.Detalle

    End Function

End Module