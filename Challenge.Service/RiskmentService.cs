using Challenge.Data;
using Challenge.Service.Interfaces;
using Challenge.Shared;
using Challenge.Shared.DTOs;
using Challenge.Shared.Models;
using Challenge.ToolKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Service
{
    public class RiskmentService : IRiskmentService
    {
        private readonly ChallengeContext context;
        private PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
        public RiskmentService() { }
        public RiskmentService(ChallengeContext context)
        {
            this.context = context;
        }
        public async Task<UserRiskValidationResponse> UserRiskValidation(Guid userId)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) throw new ExceptionManager.NoUserException();
            List<Payment> payments = await context.Payments.Where(p => p.UserId == userId).ToListAsync();
            return CreateUserRiskValidation(payments, user);
        }
        private int CalculateRejectedPaymentsQuantityLastDay(List<Payment> payments)
        {
            Guid RejectedStatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id;
            return payments.Count(p => p.StatusId == RejectedStatusId && p.PaymentDate > DateTime.Now.AddDays(-1));
        }

        private double CalculateTotalAmmountLastWeek(List<Payment> payments)
        {
            Guid ApprovedStatusId = singleton.statuses.Find(x => x.Value == "Approved").Id;
            return Math.Round(payments.Where(x => x.PaymentDate > DateTime.Now.AddDays(-7) && x.StatusId == ApprovedStatusId).Sum(x => x.AmmountUSD), 2 );
        }
        private bool ValidateUser7Days(User user) => user.CreatedDate > DateTime.Now.AddDays(-7);

        public UserRiskValidationResponse CreateUserRiskValidation(List<Payment> payments, User user) =>
            new UserRiskValidationResponse()
            {
                RejectedPaymentsQuantityLastDay = CalculateRejectedPaymentsQuantityLastDay(payments),
                TotalAmmountLastWeek = CalculateTotalAmmountLastWeek(payments),
                IsNewId = ValidateUser7Days(user)
            };
    }
}
