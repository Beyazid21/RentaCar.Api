using MediatR;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudsByBlogIdQuery:IRequest<List<GetTagCloudsByBlogIdQueryResult>>
    {
        public GetTagCloudsByBlogIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
