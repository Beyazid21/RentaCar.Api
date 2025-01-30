using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.FeatureCommands;
using RentACar.Application.Features.Mediator.Queries.FeatureQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator ;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> FeatureList()
        {
            var values =await _mediator.Send(new GetFeatureQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {

            var value=await _mediator.Send(new GetFeatureByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateFeature(CreateFeatureCommandHandler command)
        {
            await _mediator.Send(command);
            return Ok("Yeni mashin ozelliyi elave olundu");    
        }

        [HttpPut]

        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok(" mashin yenilendi");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("masin silindi");
        }


    }
}
