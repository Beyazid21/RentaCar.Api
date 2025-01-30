using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.FooterAddressHandlers;
using RentACar.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentACar.Application.FooterAddresss.Mediator.Queries.FooterAddressQueries;
using RentACar.Application.Locations.Mediator.Queries.FooterAddressQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   
        public class FooterAddresssController : ControllerBase
        {
            private readonly IMediator _mediator;

            public FooterAddresssController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet]

            public async Task<IActionResult> FooterAddressList()
            {
                var values = await _mediator.Send(new GetFooterAddressQuery());

                return Ok(values);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetFooterAddress(int id)
            {

                var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));

                return Ok(value);
            }

            [HttpPost]

            public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
            {
                await _mediator.Send(command);
                return Ok("Yeni melumat ozelliyi elave olundu");
            }

            [HttpPut]

            public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
            {
                await _mediator.Send(command);
                return Ok(" melumat yenilendi");
            }

            [HttpDelete("{id}")]

            public async Task<IActionResult> RemoveFooterAddress(int id)
            {
                await _mediator.Send(new RemoveFooterAddressCommand(id));
                return Ok("melumat silindi");
            }


        }
    }

