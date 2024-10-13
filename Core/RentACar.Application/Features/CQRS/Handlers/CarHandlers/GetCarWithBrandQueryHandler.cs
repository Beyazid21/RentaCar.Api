using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Interfaces.CarInterfaces;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var value = await _repository.GetCarsListWithBrand();

            return value.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName=x.Brand.Model,
                CarId = x.CarId,
                Name = x.Name,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrle = x.CoverImageUrle,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Seat = x.Seat,
                Transmisson = x.Transmisson,
            }).ToList();
        }
    }
}
