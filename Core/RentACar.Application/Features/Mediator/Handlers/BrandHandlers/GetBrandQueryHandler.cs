using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.BrandQueries;
using RentACar.Application.Features.Mediator.Results.BrandResults;



namespace RentACar.Application.Brands.Mediator.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, List<GetBrandQueryResult>>
    {
        private readonly IRepository<Brand> _repository;


        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetBrandQueryResult
            {
                BrandId = x.BrandId,
                Model = x.Model,
            }).ToList();
        }
    }
}
