using Challenge.Data;
using Challenge.Service.Interfaces;
using Challenge.Shared.MockUpData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Service
{
    public class MockUpService : IMockUpService
    {
        private readonly ChallengeContext context;
        public MockUpService(ChallengeContext context)
        { 
            this.context = context;
        }
        public async Task InitializeDataBase()
        {
            MockUpData data = new MockUpData();
            context.Payments.RemoveRange(context.Payments);
            context.Users.RemoveRange(context.Users);
            context.Users.AddRange(data.users);
            context.Payments.AddRange(data.payments);
            context.SaveChangesAsync();
        }
    }
}
