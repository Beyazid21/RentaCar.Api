using MediatR;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;


namespace RentACar.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery:IRequest<GetTagCloudByIdQueryResult>
    {
        public GetTagCloudByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; } 
    }
}
