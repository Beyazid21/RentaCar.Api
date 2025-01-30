using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Commands.FooterAddressHandlers;

namespace RentACar.Application.FooterAddresss.Mediator.Queries.FooterAddressQueries
{
   
        public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
        {
            private readonly IRepository<FooterAddress> _repository;

            public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new FooterAddress
                {
                  Address = request.Address,
                  Description = request.Description,
                  Email = request.Email,
                  Phone = request.Phone,
                  
                  
                });
            }
        }
    }

