namespace ConversorBack.DTOs
{
    public class ActivateSubscriptionDto
    {
        public int UserID { get; set; }
        public int newSubscriptionId { get; set; }
        public int newTotalConversions { get; set; }
    }
}
