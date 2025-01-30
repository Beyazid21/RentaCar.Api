using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Commands.AuthorCommands;

namespace RentACar.Application.Authors.Mediator.Handlers.AuthorHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public RemoveServiceCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.AuthorId == request.Id);

            await _repository.RemoveAsync(value);
        }
    }
}
