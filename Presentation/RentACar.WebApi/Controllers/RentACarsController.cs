﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.RentACarQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetRentACarListByLocation(int locationId ,bool available)
        
        
        {
            GetRentACarQuery query = new GetRentACarQuery();
            query.LocationId = locationId;
            query.Available = available;

            var values = await _mediator.Send(query);

            return Ok(values);
       
        }




    }
}
