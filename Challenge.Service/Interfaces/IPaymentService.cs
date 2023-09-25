namespace Challenge.Service.Interfaces
{
    using Challenge.Shared.DBModels;
    using Challenge.Shared.DTOs;

    public interface IPaymentService
    {
        public Task<Payment> GetDetails(Guid id);
        public Task<IList<Payment>> Get();
        public Task<Payment> Post(PaymentPost payment);
        public Task<Payment> Put (PaymentPut payment);
        public Task Delete(Payment payment);
    }
}
