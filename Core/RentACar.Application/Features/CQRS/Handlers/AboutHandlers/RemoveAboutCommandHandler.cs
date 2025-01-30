using RentaCar.Domain.Entities;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About > _repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAboutCommand command)
        {
            var value=await _repository.GetByIdAsync(x => x.AboutId == command.Id);
            await _repository.RemoveAsync(value);
            
        }
    }
}
