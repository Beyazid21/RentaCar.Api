using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Commands.FooterAddressHandlers;

namespace RentACar.Application.FooterAddresss.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.FooterAddressId == request.FooterAddressId);

            value.Phone=request.Phone;
            value.Address=request.Address;
            value.Description=request.Description;
            value.Email=request.Email;  

            await _repository.UpdateAsync(value);
        }
    }
}
