using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.CommentQueries;
using RentACar.Application.Features.Mediator.Results.CommentResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CommentHandlers
{
    
    public class GetCommentCountByBlogIdQueryHandler:IRequestHandler<GetCommentCountByBlogIdQuery,GetCommentCountByBlogIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentCountByBlogIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentCountByBlogIdQueryResult> Handle(GetCommentCountByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync(predicate: x => x.BlogId == request.BlogId);
            var CommentCount=values.Count();
            return new GetCommentCountByBlogIdQueryResult { Count = CommentCount };
        }
    }
}
