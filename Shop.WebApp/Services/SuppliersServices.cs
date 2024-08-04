using Shop.WebApp.Interfaces;
using Shop.WebApp.Models.Suppliers;
using Newtonsoft.Json;
using Shop.WebApp.Models.Suppliers.Result;
using Shop.Suppliers.Application.Dtos;

namespace Shop.WebApp.Services
{
    public class SuppliersServices : ISuppliersServices
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<SuppliersServices> Logger;
        private readonly IHttpClientFactory ClientFactory;
        private readonly string BaseUrl;

        public SuppliersServices(IConfiguration configuration, ILogger<SuppliersServices> logger, IHttpClientFactory clientFactory)
        {
            Configuration = configuration;
            Logger = logger;
            ClientFactory = clientFactory;
            BaseUrl = Configuration["apiConfig:BaseUrlSupplier"];
        }

        public async Task<SuppliersListGetResult> GetSuppliers()
        {
            var result = new SuppliersListGetResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{BaseUrl}GetSupplier");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SuppliersListGetResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error obteniendo la lista de suplidores.");
                result.success = false;
                result.message = ("Error obteniendo la lista de suplidores.");
            }
            return result;
        }

        public async Task<SuppliersGetResult> GetSuppliersById(int id)
        {
           var result = new SuppliersGetResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{BaseUrl}GetSuppliersById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, $"Error obteniendo el suplidor con ID {id}");
                result.success = false;
                result.message = $"Error obteniendo el suplidor con ID {id}.";
            }
            return result;
        }

        public async Task<SuppliersSaveResult> SuppliersSave(SuppliersSaveModel suppliersSaveModel)
        {
            var result = new SuppliersSaveResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(suppliersSaveModel), System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{BaseUrl}SuppliersSave", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SuppliersSaveResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error guardando el suplidor");
                result.success = false;
                result.message = "Error guardando el suplidor.";
            }
            return result;
        }

       public async Task<SuppliersUpdateResult> SuppliersUpdate(SuppliersUpdateModel suppliersUpdateModel)
        {
            var result = new SuppliersUpdateResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(suppliersUpdateModel), System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"{BaseUrl}SuppliersUpdate", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SuppliersUpdateResult>(apiResponse);
                }
            }
            catch(Exception ex)
            { 
                Logger.LogError(ex, "Error actualizando el suplidor");
                result.success = false;
                result.message = "Error actualizando el suplidor.";
            }
            return result;
        }
    }
}
