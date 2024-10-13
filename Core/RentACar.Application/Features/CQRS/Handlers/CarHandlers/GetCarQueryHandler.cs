using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.CarResults;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetCarQueryResult
            {
                CarId = x.CarId,
              Name = x.Name,
              BigImageUrl = x.BigImageUrl,
              BrandId = x.BrandId,
              CoverImageUrle = x.CoverImageUrle,
              Fuel = x.Fuel ,
              Km = x.Km ,
              Luggage = x.Luggage ,
              Seat = x.Seat ,
              Transmisson = x.Transmisson ,
            }).ToList();
        }
    }
}
