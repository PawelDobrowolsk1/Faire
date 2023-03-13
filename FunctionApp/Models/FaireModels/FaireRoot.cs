namespace FunctionApp.Models.FaireModels
{
    public class FaireRoot
    {
        public int page { get; set; }
        public int limit { get; set; }
        public List<FaireOrder> orders { get; set; }
    }
}
