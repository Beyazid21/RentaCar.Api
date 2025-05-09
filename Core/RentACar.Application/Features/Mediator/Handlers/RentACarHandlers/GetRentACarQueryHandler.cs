﻿using MediatR;
using RentACar.Application.Features.Mediator.Queries.RentACarQueries;
using RentACar.Application.Features.Mediator.Results.RentACarResults;
using RentACar.Application.Interfaces.RentACarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
           var values=await _repository.GetByFilterAsync(x=>x.LocationId==request.LocationId && x.Available==request.Available);

      
            return values.Select(x=>new GetRentACarQueryResult {
                
                
                CarId=x.CarId,
                Amount=x.Car.CarPricings.Where(x=>x.Pricing.Name=="Günlük").Select(x=>x.Amount).FirstOrDefault(),

                Brand=x.Car.Brand.Model,
                Model=x.Car.Name,
                CoverImageUrl=x.Car.CoverImageUrle
            
            
            }
            
            
            ).ToList();
          
        }
    }
}
