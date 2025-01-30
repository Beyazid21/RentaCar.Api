using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.BrandCommand;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Queries.CarFeaturesQueries;

namespace RentACar.WebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeaturesByCarIdQuery(id));

            return Ok(values);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAvailableToTrue(UpdateCarFeatureAvailableToTrueCommand command)
        {
            await _mediator.Send(command);
            return Ok(" CarFeature yenilendi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAvailableToFalse(UpdateCarFeatureAvailableToFalseCommand command)
        {
            await _mediator.Send(command);
            return Ok(" CarFeature yenilendi");
        }

        [HttpPost]

        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("  Yeni avtomobil xusisiyyeti elave olundu");
        }

    }
}
