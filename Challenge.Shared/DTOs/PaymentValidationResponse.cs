using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Shared.DTOs
{
    public class PaymentValidationResponse
    {
        public bool   IsNewId;
        public int    RejectedPaymentsQuantityLastDay;
        public double TotalAmountLastWeek;
    }
}
