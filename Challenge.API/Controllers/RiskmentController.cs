using Challenge.Data;
using Challenge.Service.Interfaces;
using Challenge.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskmentController : ControllerBase
    {
        private readonly ChallengeContext context;
        private readonly IRiskmentService riskmentService;
        public RiskmentController(ChallengeContext context)
        {
            this.context = context;
            riskmentService = new RiskmentService(this.context);
        }
        [HttpGet("User/{id}")]
        [Description("Comprobar en base al id de un usuario los riesgos")]
        public async Task<IActionResult> UserRiskmentValidation(Guid id)
        {
            var userRiskValidationResponse = await riskmentService.UserRiskValidation(id);
            return userRiskValidationResponse == null ? NotFound() : Ok(userRiskValidationResponse);
        }
    }
}
