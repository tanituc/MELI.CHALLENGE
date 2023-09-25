namespace Challenge.Shared.DTOs
{
    public class UserRiskValidationResponse
    {
        public bool     IsNewId { get; set; }
        public int      RejectedPaymentsQuantityLastDay { get; set; }
        public double   TotalAmmountLastWeek { get; set; }
    }
}
