using MediatR;

using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingQuery());

            return Ok(values);
        }

		[HttpGet]

		public async Task<IActionResult> GetCarPricingWithTimePeriod()
		{
			var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());

			return Ok(values);
		}
	}
}
