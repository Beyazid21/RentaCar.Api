using RentACar.Application.Features.CQRS.Queries.BannerQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Features.CQRS.Queries.CarQueries;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);

            return new GetCarByIdQueryResult
            {
              CarId= value.CarId,   
              Transmisson=value.Transmisson,
              Seat=value.Seat,
              Luggage=value.Luggage,
              Km=value.Km,
              Fuel=value.Fuel,
              BigImageUrl=value.BigImageUrl,
              BrandId=value.BrandId,
              CoverImageUrle=value.CoverImageUrle,
              Name = value.Name 
            };
        }
    }
}

