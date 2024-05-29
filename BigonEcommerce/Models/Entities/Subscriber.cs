namespace BigonEcommerce.Models.Entities
{
    public class Subscriber
    {
        public string EMailAdress { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }

    }
}
