using MediatR;
using RentACar.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACar.Application.Features.Mediator.Results.StatisticsResults;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceCarForWeeklyQueryHandler : IRequestHandler<GetAvgRentPriceCarForWeeklyQuery, GetAvgRentPriceCarForWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceCarForWeeklyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceCarForWeeklyQueryResult> Handle(GetAvgRentPriceCarForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceCarForWeekly();
            return new GetAvgRentPriceCarForWeeklyQueryResult
            { Price = value };
        }
    }
}