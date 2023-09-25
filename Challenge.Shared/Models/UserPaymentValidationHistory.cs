namespace Challenge.Shared.Models
{
    public class UserPaymentValidationHistory
    {
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool IsValidProcess { get; set; }
        public string Reason { get; set; }
    }
}
