using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.BrandQueries;
using RentACar.Application.Features.Mediator.Queries.CarSingleQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarSingleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarSingleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> CarDetail(int id)
        {
            var values = await _mediator.Send(new GetCarSingleByCarIdQuery(id));

            return Ok(values);
        }
    }
}
