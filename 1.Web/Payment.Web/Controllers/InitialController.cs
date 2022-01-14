using Microsoft.AspNetCore.Mvc;

namespace Payment.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        [HttpGet]
        public string Message()
        {
            return "Initial message from PaymentApp.";
        }
    }
}
