﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.FeatureCommands;
using RentACar.Application.Features.Mediator.Queries.TagCloudQueries;



namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());

            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TagCloudListByBlogId(int id)
        {
            var values = await _mediator.Send(new GetTagCloudsByBlogIdQuery(id));

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {

            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yeni mashin ozelliyi elave olundu");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok(" mashin yenilendi");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("masin silindi");
        }


    }
}
