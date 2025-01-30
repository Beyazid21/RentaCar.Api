using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;
using RentACar.Application.Features.Mediator.Results.LoacationResults;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.CarPricingInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingQueryHandler(ICarPricingRepository repositor)
        {
            _repository = repositor;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarsWithPricing();

            return value.Select(x => new GetCarPricingQueryResult
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Model,
                Model = x.Car.Name,
                CarPricingId = x.CarPricingId,
                CoverImageUrl = x.Car.CoverImageUrle,
                CarId= x.CarId
            }).ToList();
        }
    }
}
