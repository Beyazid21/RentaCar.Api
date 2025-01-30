using MediatR;
using RentACar.Application.Features.Mediator.Queries.BrandQueries;
using RentACar.Application.Features.Mediator.Results.BrandResults;
using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, GetBrandByIdQueryResult>
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(predicate: x => x.BrandId == request.Id);

            return new GetBrandByIdQueryResult
            {
                BrandId = value.BrandId,
                Model = value.Model,

            };
        }
    }
}
