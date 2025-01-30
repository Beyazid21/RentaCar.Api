using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Commands.BlogCommands;

namespace RentACar.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public RemoveServiceCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.BlogId == request.Id);

            await _repository.RemoveAsync(value);
        }
    }
}
