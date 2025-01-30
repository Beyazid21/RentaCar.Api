using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult actionResult()
        {
            return Ok("Isledi");
        }
    }
}
