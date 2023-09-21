using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Shared.DTOs
{
    public class PaymentValidation
    {
        public bool IsNewId;
        public int RejectedProductsQuantityLastDay;
        public double TotalAmountLastWeek;
    }
}
