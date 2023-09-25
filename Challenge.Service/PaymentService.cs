namespace Challenge.Service
{
    using Challenge.Data;
    using Challenge.ExternalServices;
    using Challenge.Service.Interfaces;
    using Challenge.Shared;
    using Challenge.Shared.DBModels;
    using Challenge.Shared.DTOs;
    using Challenge.Shared.PolyEnums;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PaymentService : IPaymentService
    {
        private readonly ChallengeContext context;
        PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
        public PaymentService(ChallengeContext context)
        {
            this.context = context;
        }

        public async Task<Payment> GetDetails(Guid id) => await context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        public async Task<IList<Payment>> Get() => await context.Payments.ToListAsync();
        public async Task<Payment> Post(PaymentPost payment)
        {
            Payment paymentToSave = new();

            Countries.Country? country = singleton.countries.Find(x => x.Id == payment.CountryId);
            if (country == null) throw new Exception();

            Statuses.Status? status = singleton.statuses.Find(x => x.Id == payment.StatusId);
            if(status == null) throw new Exception();

            paymentToSave.CountryId = country.Id;
            paymentToSave.Country = country.Name;
            paymentToSave.Currency = country.Currency;
            paymentToSave.PaymentDate = DateTime.Now;
            paymentToSave.UserId = payment.UserId;
            paymentToSave.StatusId = status.Id;
            paymentToSave.Id = payment.Id;
            paymentToSave.Ammount = payment.Ammount;
            paymentToSave.AmmountUSD = CurrencyConverter.ConvertARStoUSD(payment.Ammount);
            await context.Payments.AddAsync(paymentToSave);
            await context.SaveChangesAsync();
            return paymentToSave;
        }

        public async Task<Payment> Put(PaymentPut payment)
        {
            Payment paymentToSave = new();
            Countries.Country? country = singleton.countries.Find(x => x.Id == payment.CountryId);
            if (country == null) throw new Exception();

            Statuses.Status? status = singleton.statuses.Find(x => x.Id == payment.StatusId);
            if (status == null) throw new Exception();
            paymentToSave.CountryId = country.Id;
            paymentToSave.Currency = country.Currency;
            paymentToSave.Country = country.Name;
            paymentToSave.PaymentDate = payment.PaymentDate;
            paymentToSave.UserId = payment.UserId;
            paymentToSave.StatusId = payment.StatusId;
            paymentToSave.Id = payment.Id;
            paymentToSave.Ammount = payment.Ammount;
            paymentToSave.AmmountUSD = CurrencyConverter.ConvertARStoUSD(payment.Ammount);
            context.Payments.Update(paymentToSave);
            await context.SaveChangesAsync();
            return paymentToSave;
        }
        public async Task Delete(Payment payment)
        {
            context.Payments.Remove(payment);
            await context.SaveChangesAsync();
        }

    }
}
