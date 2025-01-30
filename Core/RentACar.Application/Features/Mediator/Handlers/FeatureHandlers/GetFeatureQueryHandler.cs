using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Features.Mediator.Queries.FeatureQueries;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using RentACar.Application.Interfaces;

namespace RentACar.Application.Features.Mediator.Handlers.FeatureHandlers
{
   
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;
    
        
public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
         var value=await _repository.GetAllAsync();

            return value.Select(x=>new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Name=x.Name,
            }).ToList();
        }
    }
}
