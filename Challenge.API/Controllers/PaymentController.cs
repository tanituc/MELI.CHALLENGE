namespace Challenge.API.Controllers
{
    using Challenge.Data;
    using Challenge.Service;
    using Challenge.Service.Interfaces;
    using Challenge.Shared.Models;
    using Challenge.Shared.DTOs;
    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        private readonly ChallengeContext context;

        public PaymentController(ChallengeContext context)
        {
            this.context = context;
            paymentService = new PaymentService(this.context);
        }
        [HttpGet]
        public async Task<IList<Payment>> Get()
        {
            return await paymentService.Get();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            Payment payment = await paymentService.GetDetails(id);
            return payment == null ? NotFound() : Ok(payment);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PaymentPost payment)
        {
            var paymentSaved = await paymentService.Post(payment);
            return CreatedAtAction("Post", paymentSaved.Id, paymentSaved);
        }
        [HttpPut]
        public async Task<IActionResult> Put(PaymentPut payment)
        {
            Payment paymentUpdated = await paymentService.Put(payment);
            return CreatedAtAction("Put", paymentUpdated.Id, paymentUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Payment payment)
        {
            if (payment == null) return NotFound();
            paymentService.Delete(payment);
            return NoContent();
        }
    }
}
