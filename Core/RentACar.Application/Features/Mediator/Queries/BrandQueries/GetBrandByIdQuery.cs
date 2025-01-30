using MediatR;
using RentACar.Application.Features.Mediator.Results.BrandResults;


namespace RentACar.Application.Features.Mediator.Queries.BrandQueries
{
    public class GetBrandByIdQuery:IRequest<GetBrandByIdQueryResult>
    {
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; } 
    }
}
