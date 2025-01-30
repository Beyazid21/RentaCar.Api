using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;

using RentACar.Application.Features.Mediator.Commands.BrandCommand;

namespace RentACar.Application.Brands.Mediator.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommand>
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.BrandId == request.Id);

            await _repository.RemoveAsync(value);
        }
    }
}
