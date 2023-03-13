namespace FunctionApp.Models.FaireModels
{
    public class FaireOrder
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string state { get; set; }
        public List<FaireItem> items { get; set; }
        public FaireAddress address { get; set; }
        public string retailer_id { get; set; }
        public FairePayoutCosts payout_costs { get; set; }
        public string source { get; set; }
    }
}
