using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.BrandCommand;
using RentACar.Application.Features.Mediator.Queries.BrandQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> BrandList()
        {
            var values = await _mediator.Send(new GetBrandQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {

            var value = await _mediator.Send(new GetBrandByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yeni Marka ozelliyi elave olundu");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _mediator.Send(command);
            return Ok(" Marka yenilendi");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _mediator.Send(new RemoveBrandCommand(id));
            return Ok("Marka silindi");
        }


    }
}
