using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.ServiceQueries;
using RentACar.Application.Features.Mediator.Results.ServiceResults;
using RentACar.Application.Interfaces;

namespace RentACar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;
        public GetTestimonialQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetServiceQueryResult
            {
                ServiceId = x.ServiceId,
                IconUrl = x.IconUrl,
                Title = x.Title,
                Description = x.Description
            }).ToList();
        }
    }
}
