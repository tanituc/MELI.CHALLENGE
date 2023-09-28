namespace Challenge.Shared.DTOs
{
    public class PaymentPost
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public Guid StatusId { get; set; }
        public double Ammount { get; set; }
    }
}
