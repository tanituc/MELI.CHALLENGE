using Challenge.Service.Interfaces;
using Challenge.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Service
{
    public class PaymentService : IPaymentService
    {
        public PaymentValidationResponse ProcessPayment()
        {
            PaymentValidationResponse paymentValidationResponse = new();
            paymentValidationResponse.IsNewId = ValidateNewUser();
            paymentValidationResponse.TotalAmountLastWeek = CalculateTotalAmmount();
            paymentValidationResponse.RejectedPaymentsQuantityLastDay = GetRejectedProducts();
            return new PaymentValidationResponse();
        }

        private int GetRejectedProducts()
        {
            throw new NotImplementedException();
        }

        private double CalculateTotalAmmount()
        {
            throw new NotImplementedException();
        }

        private bool ValidateNewUser()
        {
            return false;
        }

    }
}
