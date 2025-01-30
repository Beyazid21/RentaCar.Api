using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;
using RentACar.Application.Interfaces;
using RentACar.Application.Locations.Mediator.Queries.FooterAddressQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    
    public class GetFooterAddressQueryHandler:IRequestHandler<GetFooterAddressQuery,List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                FooterAddressId = x.FooterAddressId,
                Phone = x.Phone,
            }).ToList();
        }
    }
}
