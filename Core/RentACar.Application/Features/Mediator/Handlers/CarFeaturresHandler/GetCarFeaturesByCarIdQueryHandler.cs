using MediatR;
using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.CarFeaturesQueries;
using RentACar.Application.Features.Mediator.Results.CarFeaturesResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeaturresHandler
{
    
    public class GetCarFeaturesByCarIdQueryHandler : IRequestHandler<GetCarFeaturesByCarIdQuery, List<GetCarFeaturesByCarIdQueryResult>>
    {
        private readonly IRepository<CarFeature> _repository;

        public GetCarFeaturesByCarIdQueryHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeaturesByCarIdQueryResult>> Handle(GetCarFeaturesByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync(include:x=>x.Include(x=>x.Feature),predicate: x => x.CarId == request.CarId);

            return values.Select(x=>new GetCarFeaturesByCarIdQueryResult
            {
              
                Available = x.Available,
                CarFeatureId=x.CarFeatureId,
                FeatureId=x.FeatureId,
                FeatureName=x.Feature.Name,

            }).ToList();    
          
        }
    }
}
