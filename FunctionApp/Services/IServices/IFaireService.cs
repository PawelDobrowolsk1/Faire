using FunctionApp.Models.FaireModels;

namespace FunctionApp.Services.IServices
{
    public interface IFaireService
    {
        public List<FaireOrder> GetOrders();
    }
}
