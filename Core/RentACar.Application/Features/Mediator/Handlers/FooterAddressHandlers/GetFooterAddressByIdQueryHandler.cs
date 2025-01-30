using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;
using RentACar.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace RentACar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(predicate: x => x.FooterAddressId == request.Id);

            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressId = value.FooterAddressId,
                Phone = value.Phone,
                Email = value.Email,
                Description = value.Description,
                Address = value.Address,


            };
        }
    }
}
