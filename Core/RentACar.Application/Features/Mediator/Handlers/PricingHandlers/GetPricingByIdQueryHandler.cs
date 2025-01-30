using MediatR;
using RentACar.Application.Features.Mediator.Queries.PricingQueries;
using RentACar.Application.Features.Mediator.Results.LoacationResults;
using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Results.PricingResults;

namespace RentACar.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(predicate: x => x.PricingId == request.Id);

            return new GetPricingByIdQueryResult
            {
                PricingId = value.PricingId,
                Name = value.Name,

            };
        }
    }
}
