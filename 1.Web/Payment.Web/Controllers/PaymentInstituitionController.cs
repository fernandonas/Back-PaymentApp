using Microsoft.AspNetCore.Mvc;
using Payment.Application.Models.PaymentInstituition;
using Payment.Application.Services.PaymentInstituitionService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentInstituitionController : ControllerBase
    {
        private readonly IPaymentInstituitionService _paymentIstituitionService;

        public PaymentInstituitionController(IPaymentInstituitionService paymentInstituitionService)
        {
            _paymentIstituitionService = paymentInstituitionService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] PaymentInstituitionRequestModel request)
        {
            await _paymentIstituitionService.Add(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("")]
        public async Task Detele([FromQuery] Guid id)
        {
            await _paymentIstituitionService.Delete(id);
        }

        [HttpGet]
        [Route("")]
        public IList<PaymentInstituitionResponseModel> GetAll()
        {
            return _paymentIstituitionService.GetAll();
        }

        [HttpPut]
        [Route("{id}")]
        public Task Update(Guid id, [FromBody] PaymentInstituitionRequestModel request)
        {
            return _paymentIstituitionService.Update(id, request);
        }
    }
}
