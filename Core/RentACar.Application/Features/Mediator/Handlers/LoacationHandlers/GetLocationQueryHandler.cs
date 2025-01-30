using MediatR;

using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;
using RentACar.Application.Features.Mediator.Results.LoacationResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Locations.Mediator.Queries.FooterAddressQueries
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;
        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                Name = x.Name,
            }).ToList();
        }
    }
}
