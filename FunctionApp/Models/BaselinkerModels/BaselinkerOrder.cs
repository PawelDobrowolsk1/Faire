namespace FunctionApp.Models.BaselinkerModels
{
    public class BaselinkerOrder
    {
        public int order_status_id { get; set; } = 8069;
        public int source_id { get; set; } = 1024;
        public string id { get; set; }
        public List<BaselinkerItem> items { get; set; }
        public BaselinkerAddress address { get; set; }
        public string retailer_id { get; set; }
        public BaselinkerPayoutCosts payout_costs { get; set; }
    }
}
