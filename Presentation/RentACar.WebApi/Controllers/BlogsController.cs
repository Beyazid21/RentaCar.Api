﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RentACar.Application.Features.Mediator.Commands.BlogCommands;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {

            var value = await _mediator.Send(new GetBlogByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yeni Blog ozelliyi elave olundu");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok(" Blog yenilendi");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog silindi");
        }

        [HttpGet]

        public async Task<IActionResult> Lat3BlogsWithAuthorList()
        {
            var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());

            return Ok(values);

        }

        [HttpGet]

        public async Task<IActionResult> AllBlogsWithAuthorList()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorsQuery());

            return Ok(values);

        }
    } }

