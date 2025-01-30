using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;
using RentACar.Application.Features.Mediator.Results.LoacationResults;

namespace RentACar.Application.Locations.Mediator.Handlers.LoacationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(predicate: x => x.LocationId == request.Id);

            return new GetLocationByIdQueryResult
            {
                LocationId = value.LocationId,
                Name = value.Name,

            };
        }
    }
}
