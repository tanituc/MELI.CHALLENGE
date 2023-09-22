using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Shared.DBModels
{
    public class Payment
    {
        public Guid     Id { get; set; }
        public Guid     UserId { get; set; }
        public string   Country { get; set; }
        public string   Currency { get; set; }
        public float    TotalAmmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid     StatusId { get; set; }

    }
}
