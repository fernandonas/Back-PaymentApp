using Application.Models.PaymentType;
using Application.Services.PaymentTypeService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] PaymentTypeRequest request)
        {
            await _paymentTypeService.Add(request);
            return NoContent();
        }

        [HttpGet]
        [Route("")]
        public IList<PaymentTypeResponse> GetAll()
        {
            return _paymentTypeService.GetAll();
        }

        [HttpDelete]
        [Route("")]
        public Task Detele([FromQuery] Guid id)
        {
            return _paymentTypeService.Delete(id);
        }

        [HttpPut]
        [Route("{id}")]
        public Task Update(Guid id, [FromBody] PaymentTypeRequest request)
        {
            return _paymentTypeService.Update(id, request);
        }
    }
}
