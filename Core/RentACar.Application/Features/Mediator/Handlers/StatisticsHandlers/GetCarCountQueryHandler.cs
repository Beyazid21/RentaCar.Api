using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACar.Application.Features.Mediator.Results.StatisticsResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
       private readonly IRepository<Car>  _repository;

        public GetCarCountQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var count = values.Count;
            return new GetCarCountQueryResult { CarCount=count};
        }
    }
}
