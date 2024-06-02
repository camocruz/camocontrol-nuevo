Public Class ejemplo

    ' Return a list of customers.
    Private Function GetCustomers() As List(Of Customer)
        Return New List(Of Customer) From
            {
                New Customer With {.CustomerID = 1, .CompanyName = "Contoso, Ltd", .City = "Halifax", .Country = "Canada"},
                New Customer With {.CustomerID = 2, .CompanyName = "Margie's Travel", .City = "Redmond", .Country = "United States"},
                New Customer With {.CustomerID = 3, .CompanyName = "Fabrikam, Inc.", .City = "Vancouver", .Country = "Canada"}
            }
    End Function

    ' Return a list of orders.
    Private Function GetOrders() As List(Of Order)
        Return New List(Of Order) From
            {
                New Order With {.CustomerID = 1, .Amount = "200.00"},
                New Order With {.CustomerID = 3, .Amount = "600.00"},
                New Order With {.CustomerID = 1, .Amount = "300.00"},
                New Order With {.CustomerID = 2, .Amount = "100.00"},
                New Order With {.CustomerID = 3, .Amount = "800.00"}
            }
    End Function

    ' Customer Class.
    Private Class Customer
        Public Property CustomerID As Integer
        Public Property CompanyName As String
        Public Property City As String
        Public Property Country As String
    End Class

    ' Order Class.
    Private Class Order
        Public Property CustomerID As Integer
        Public Property Amount As Decimal
    End Class


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'obtener la informacion en la datatable
        Dim otb_compras As DataTable
        Dim csql As String
        csql = comunes.suministrar_valor_variable_configuracion("ST-0300-08", "00000001")
        csql = csql.Replace("$df001$", "camocontrol")
        csql = csql.Replace("$001$", "2020-03-01")
        csql = csql.Replace("$002$", "2020-04-17")
        otb_compras = cl_utilidades_datatables.cargar_informacion_postgres(csql)

        Dim conteoServiosManto As Integer = Aggregate orow In otb_compras.AsEnumerable
                                 Where orow.Item("item") = "SERVICIO MANTENIMIENTO" Into Count()




        Dim ocompras2 = From orow In otb_compras.AsEnumerable
                        Where orow("item") = "SERVICIO MANTENIMIENTO"
                        Select orow

        Dim ocompras3 = From orow In otb_compras.Rows
                        Where orow("item") = "SERVICIO MANTENIMIENTO"
                        Select orow("item")

        'Dim aa = ocompras2.CopyToDataTable
        'dgw1.DataSource = aa
        'Dim a As Integer = ocompras.Count

        ' Obtain a list of customers.
        Dim customers As List(Of Customer) = GetCustomers()


        '' Return customers that are grouped based on country.
        Dim countries = From cust In customers
                        Order By cust.Country, cust.City
                        Group By CountryName = cust.Country
                        Into CustomersInCountry = Group, Count()
                        Order By CountryName

        '' Output the results.
        Dim txsalida As String = String.Empty
        For Each country In countries
            txsalida += country.CountryName & " count=" & country.Count & vbCrLf

            For Each customer In country.CustomersInCountry
                txsalida += ("   " & customer.CompanyName & "  " & customer.City) & vbCrLf
            Next
        Next
        TextBox1.Text = txsalida
    End Sub
End Class