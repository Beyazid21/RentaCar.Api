using MediatR;
using RentACar.Application.Features.Mediator.Results.BlogResults;


namespace RentACar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdQuery:IRequest<GetBlogByIdQueryResult>
    {
        public GetBlogByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
