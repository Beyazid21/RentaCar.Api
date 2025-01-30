using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Commands.ServiceCommands;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.ServiceId == request.ServiceId);

            value.Description = request.Description;
            value.Title = request.Title;
            value.IconUrl = request.IconUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
