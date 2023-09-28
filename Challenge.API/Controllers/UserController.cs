namespace Challenge.API.Controllers
{
    using Challenge.Data;
    using Challenge.Service;
    using Challenge.Service.Interfaces;
    using Challenge.Shared.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ChallengeContext context;
        private readonly IUserService userService;
        public UserController(ChallengeContext context)
        {
            this.context = context;
            userService = new UserService(this.context);
        }
        [HttpGet]
        public async Task<IList<User>> Get()
        {
            return await userService.Get();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var user = await userService.GetDetails(id);
            return user == null ? NotFound() : Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            var savedUser = await userService.Post(user);
            return CreatedAtAction("Post", savedUser.Id, savedUser);
        }
        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            var savedUser = await userService.Put(user);
            return CreatedAtAction("Put", savedUser.Id, savedUser);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(User user)
        {
            if (user == null) return NotFound();
            await userService.Delete(user);
            return NoContent();
        }
    }
}
