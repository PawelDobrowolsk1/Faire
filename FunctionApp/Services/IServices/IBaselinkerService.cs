using FunctionApp.Models.BaselinkerModels;

namespace FunctionApp.Services.IServices
{
    public interface IBaselinkerService
    {
        public void AddOrders(List<BaselinkerOrder> orders);
    }
}
