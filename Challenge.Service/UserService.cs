using Challenge.Data;
using Challenge.Service.Interfaces;
using Challenge.Shared;
using Challenge.Shared.DBModels;
using Challenge.Shared.DTOs;
using Challenge.Shared.PolyEnums;
using Challenge.ToolKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Service
{
    public class UserService : IUserService
    {
        private readonly ChallengeContext context;
        PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
        public UserService(ChallengeContext context)
        {
            this.context = context;
        }

        public async Task Delete(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<IList<User>> Get() => await context.Users.ToListAsync();

        public async Task<User> GetDetails(Guid id) => await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User> Post(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Put(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<UserRiskValidationResponse> UserRiskValidation(Guid userId)
        {
            UserRiskValidationResponse userRiskValidationResponse = new();
            User user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) throw new ExceptionManager.NoUserException();

            List<Payment> payments = await context.Payments.Where(p => p.UserId == userId).ToListAsync();

            userRiskValidationResponse.RejectedPaymentsQuantityLastDay = 
                payments.Count(
                        p => p.StatusId == singleton.statuses.Find(x=> x.Value == "Rejected").Id && p.PaymentDate > DateTime.Now.AddDays(-1)
                    );
            userRiskValidationResponse.TotalAmmountLastWeek = payments.Where(x => x.PaymentDate > DateTime.Now.AddDays(-7)).Sum(x => x.AmmountUSD);

            userRiskValidationResponse.IsNewId = user.CreatedDate > DateTime.Now.AddDays(-7);

            return userRiskValidationResponse;
        }
    }
}
