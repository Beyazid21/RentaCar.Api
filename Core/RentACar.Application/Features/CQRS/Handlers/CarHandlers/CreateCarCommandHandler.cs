using RentaCar.Domain.Entities;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car()
            {
                BigImageUrl = command.BigImageUrl,
                BrandId = command.BrandId,
                CoverImageUrle = command.CoverImageUrle,
                Fuel=command.Fuel,
                Km=command.Km,
                Luggage=command.Luggage,    
                Seat=command.Seat,
                Name=command.Name,  
                Transmisson = command.Transmisson   ,
                

            });

        }
    }
}
