using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Commands.CommentCommands;
using RentACar.Application.Features.Mediator.Queries.CommentQueries;
using RentACar.Application.Features.RepositoryPattern;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CommentList()
        {

            return Ok(_repository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {

            return Ok(_repository.GetById(id));
        }

        [HttpGet("{id}")]
        public IActionResult CommentListByBlog(int id)
        {

            return Ok(_repository.GetCommentsByBlogId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
           await _mediator.Send(command);

            return Ok("Yeni comment elave olundu");
        }
        [HttpPut]
        public IActionResult RemoveComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);

            return Ok("Yeni comment elave olundu");
        }

        [HttpDelete]
        public IActionResult RemoveComment(Comment comment)
        {
            var value = _repository.GetById(comment.CommentId);
            value.Desciption = comment.Desciption;
            value.CreatedDate = comment.CreatedDate;
            value.Name = comment.Name;
            value.BlogId = comment.BlogId;
            _repository.Update(value);

            return Ok("Yeni comment elave olundu");
        }


        [HttpGet("{id}")]
        public  async Task<IActionResult> CommentCountByBlogId(int id)
        {

            var count=await _mediator.Send(new GetCommentCountByBlogIdQuery (id));

            return Ok(count);
        }



    }
}
