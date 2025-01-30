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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(x => x.BlogId == request.BlogId);

            value.AuthorId = request.AuthorId;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Title = request.Title;
            value.CategoryId = request.CategoryId;
            value.CreatedDate = request.CreatedDate;
            

            await _repository.UpdateAsync(value);
        }
    }
}
