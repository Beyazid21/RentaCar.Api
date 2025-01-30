using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Commands.FeatureCommands;

namespace RentACar.Application.TagClouds.Mediator.Handlers.TagCloudHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public RemoveServiceCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.TagCloudId == request.Id);

            await _repository.RemoveAsync(value);
        }
    }
}
