using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Commands.BrandCommand;


namespace RentACar.Application.Brands.Mediator.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand>
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Brand
            {
                Model = request.Model,
            });
        }
    }
}
