namespace Challenge.Shared.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid StatusId { get; set; }
        public Guid CountryId { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public double Ammount { get; set; }
        public double AmmountUSD { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
