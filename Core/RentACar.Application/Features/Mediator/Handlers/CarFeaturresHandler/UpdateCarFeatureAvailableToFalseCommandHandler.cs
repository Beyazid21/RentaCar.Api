using MediatR;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.CarFeaturesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeaturresHandler
{
    public class UpdateCarFeatureAvailableToFalseCommandHandler : IRequestHandler<UpdateCarFeatureAvailableToFalseCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureAvailableToFalseCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvailableToFalseCommand request, CancellationToken cancellationToken)
        {
            await _repository.ChangeToFalse(request.CarFeatureIds);
        }
    }
}
