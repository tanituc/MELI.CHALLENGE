using Challenge.Shared.DBModels;
using Challenge.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Service.Interfaces
{
    public interface IPaymentService
    {
        public PaymentValidationResponse PaymentValidation(Guid id);
    }
}
