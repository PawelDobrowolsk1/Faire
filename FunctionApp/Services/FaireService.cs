using FunctionApp.Models.FaireModels;
using FunctionApp.Services.IServices;
using Newtonsoft.Json;
using RestSharp;

namespace FunctionApp.Services
{
    public class FaireService : IFaireService
    {
        public List<FaireOrder> GetOrders()
        {
            using (var client = new RestClient())
            {
                var request = new RestRequest("https://www.faire.com/api/v1/orders");
                request.AddHeader("X-FAIRE-ACCESS-TOKEN", Environment.GetEnvironmentVariable("X_FAIRE_ACCESS_TOKEN"));

                //request to server
                var response = client.GetAsync(request).Result;
                var contentJson = response.Content.ToString();
                var data = JsonConvert.DeserializeObject<FaireRoot>(contentJson);

                return data.orders;
            }
        }
    }
}
