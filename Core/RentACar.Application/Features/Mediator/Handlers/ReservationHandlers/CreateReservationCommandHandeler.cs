
using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Commands.ReservationCommands;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandeler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandeler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Age = request.Age,
                CarId = request.CarId,
                Description = request.Description,
                DriverLicenseYear = request.DriverLicenseYear,
                DropOffLocationId = request.DropOffLocationId,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                PickUpLocationId = request.PickUpLocationId,
                Surname = request.Surname,
                Status = "Rezerv alındı"
            });
        }
    }
}
