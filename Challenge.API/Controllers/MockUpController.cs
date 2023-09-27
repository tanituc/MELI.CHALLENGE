using Challenge.Data;
using Challenge.Service.Interfaces;
using Challenge.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockUpController : ControllerBase
    {
        private readonly IMockUpService mockUpService;
        private readonly ChallengeContext context;

        public MockUpController(ChallengeContext context)
        {
            this.context = context;
            mockUpService = new MockUpService(this.context);
        }
        [HttpGet]
        public async Task<IActionResult> InitializeDataBase() {
            await mockUpService.InitializeDataBase();
            return Ok();
        }
    }
   
}
