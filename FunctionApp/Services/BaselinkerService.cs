using FunctionApp.Models.BaselinkerModels;
using FunctionApp.Services.IServices;
using Newtonsoft.Json;
using RestSharp;

namespace FunctionApp.Services
{
    public class BaselinkerService : IBaselinkerService
    {
        public void AddOrders(List<BaselinkerOrder> orders)
        {
            if (orders.Count > 0)
            {
                using (var client = new RestClient())
                {

                    var request = new RestRequest("https://api.baselinker.com/connector.php");
                    request.AddHeader("X-BLToken", Environment.GetEnvironmentVariable("X_BLToken"));
                    request.AddParameter("method", "addOrder");

                    //request to server for each order
                    foreach (var order in orders)
                    {
                        var JsonOrder = JsonConvert.SerializeObject(order);
                        request.AddParameter("parameters", JsonOrder);
                        var result = client.PostAsync(request).Result;
                    }
                }
            }
        }
    }
}

