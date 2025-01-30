using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.CarCommands;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(x => x.CarId == command.CarId);
            value.Fuel = command.Fuel;
            value.Name = command.Name;
            value.Seat = command.Seat;
            value.BrandId = command.BrandId;
            value.BigImageUrl = command.BigImageUrl;
            value.Km = command.Km;
            value.CoverImageUrle = command.CoverImageUrle;

            value.Luggage=command.Luggage;
            value.Transmisson=command.Transmisson;
            

            await _repository.UpdateAsync(value);
        }

    }
}
