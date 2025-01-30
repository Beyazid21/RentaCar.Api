using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;
using RentACar.Application.Features.Mediator.Results.LoacationResults;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.CarPricingInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly IRepository<CarPricing> _repository ;

		public GetCarPricingWithTimePeriodQueryHandler(IRepository<CarPricing> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync(
	include: x => x.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing),
	predicate: x => x.Pricing.Name == "Günlük" || x.Pricing.Name == "Həftəlik" || x.Pricing.Name == "Aylıq"
);

			var groupedCars = values
	   .GroupBy(x => x.CarId)
	   .Select(g => new GetCarPricingWithTimePeriodQueryResult
	   {
		   Model = g.First().Car.Name, // Maşın adı
		   CoverImageUrl=g.First().Car.CoverImageUrle,
		   BrandName = g.First().Car.Brand.Model,
		   AmountDaily = g.FirstOrDefault(x => x.Pricing.Name == "Günlük")?.Amount ?? 0,
		   AmountWeekly = g.FirstOrDefault(x => x.Pricing.Name == "Həftəlik")?.Amount ?? 0,
		   AmountMonthly = g.FirstOrDefault(x => x.Pricing.Name == "Aylıq")?.Amount ?? 0
	   })
	   .ToList();
			return groupedCars;


		}
	}
}
