using Challenge.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Service.Interfaces
{
    public interface IRiskmentService
    {
        public Task<UserRiskValidationResponse> UserRiskValidation(Guid id);
    }
}
