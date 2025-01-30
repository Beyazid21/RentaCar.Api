using MediatR;
using RentACar.Application.Features.Mediator.Results.CommentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentCountByBlogIdQuery : IRequest<GetCommentCountByBlogIdQueryResult>
    {
        public GetCommentCountByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }

        public int BlogId { get; set; } 
    }
}
