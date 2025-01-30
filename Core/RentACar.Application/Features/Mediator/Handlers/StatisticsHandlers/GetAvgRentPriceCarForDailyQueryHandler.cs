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
    public class GetAvgRentPriceCarForDailyQueryHandler : IRequestHandler<GetAvgRentPriceCarForDailyQuery, GetAvgRentPriceCarForDailyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceCarForDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceCarForDailyQueryResult> Handle(GetAvgRentPriceCarForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceCarForDaily();
            return new GetAvgRentPriceCarForDailyQueryResult
            { Price = value };
        }
    }
}
