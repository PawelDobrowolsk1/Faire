namespace FunctionApp.Models.BaselinkerModels
{
    public class BaselinkerPayoutCosts
    {
        public int payout_fee_cents { get; set; }
        public int payout_fee_bps { get; set; }
        public int commission_cents { get; set; }
        public int commission_bps { get; set; }
    }
}
