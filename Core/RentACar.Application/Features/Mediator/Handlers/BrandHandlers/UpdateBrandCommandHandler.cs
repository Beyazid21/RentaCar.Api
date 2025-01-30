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
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.BrandId == request.BrandId);

            value.Model = request.Model;

            await _repository.UpdateAsync(value);
        }
    }
}
