using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.ServiceQueries;
using RentACar.Application.Features.Mediator.Results.ServiceResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(predicate: x => x.ServiceId == request.Id);

            return new GetServiceByIdQueryResult
            {
                ServiceId = value.ServiceId,

                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title,

            };
        }
    }
}
