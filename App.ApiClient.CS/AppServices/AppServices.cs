using App.ApiClient.CS.Config;
using App.ApiClient.CS.Factories;
using App.ApiClient.CS.Services.SpecificServices;
using System.Security.Cryptography;

namespace App.ApiClient.CS
{
    public static class AppServices
    {
        public static readonly SiesaClientFactory SiesaFactory;

        static AppServices()
        {
            var config = new SiesaConfig
            {
                BaseUrl = "https://api.siesacloud.com/",
                ConniKey = "ff96a448b64d3a764b2501749fd6e354",
                ConniToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjNiZjFiNGE5LTY3ZDUtNGU5MC1iYmI1LWJiMjRiNGJjY2U5NiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcHJpbWFyeXNpZCI6IjZiY2FhMDAwLTRkNTYtNGMwYS1iODRmLTcxY2JhMWM5NWNjMCJ9.6mqPMJgJwaUU2VCjdvTfIx_TXJGVOy2AZN6d7pZXo-Y",
                ClientId = "BNvQCwIKFzDP51D1QkzObw4Es79ELWTRG0jN0X1sL1dUJKe0"
            };

            SiesaFactory = new SiesaClientFactory(config);
        }
    }
}

//4.Uso desde cualquier parte (VB o C#)
//
//Desde VB (mientras migras):
//Dim baseService = App.ApiClient.CS.AppServices.SiesaFactory.CreateBaseService()
//Dim servicio = New OrdenCompraApiService(baseService)

//Dim ordenes = Await servicio.ObtenerOrdenesCompraAsync(9174, "f420_rowid > 7")

//
//Desde C# (cuando migres):
//var baseService = AppServices.SiesaFactory.CreateBaseService();
//var servicio = new OrdenCompraApiService(baseService);

//var ordenes = await servicio.ObtenerOrdenesCompraAsync(9174, "f420_rowid > 7");

//


