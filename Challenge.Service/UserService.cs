using Challenge.Data;
using Challenge.Service.Interfaces;
using Challenge.Shared;
using Challenge.Shared.Models;
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
        public UserService() { }
        public UserService(ChallengeContext context)
        {
            this.context = context;
        }

        public async Task Delete(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<IList<User>> Get() 
            => await context.Users.ToListAsync();

        public async Task<User> GetDetails(Guid id) 
            => await context.Users.FirstOrDefaultAsync(u => u.Id == id);

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
        
    }
}
