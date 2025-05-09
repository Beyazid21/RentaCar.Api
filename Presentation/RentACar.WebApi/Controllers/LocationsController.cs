﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.LocationCommands;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;



namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {

            var value = await _mediator.Send(new GetLocationByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yeni mekan ozelliyi elave olundu");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok(" mekan yenilendi");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("mekan silindi");
        }


    }
}
