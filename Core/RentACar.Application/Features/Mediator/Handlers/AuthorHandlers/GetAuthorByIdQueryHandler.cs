using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Results.AuthorResults;
using RentACar.Application.Features.Mediator.Queries.AuthorQueries;

namespace RentACar.Application.Authors.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(predicate: x => x.AuthorId == request.Id);

            return new GetAuthorByIdQueryResult
            {
                AuthorId = value.AuthorId,
                Name = value.Name,
                Description = value.Description,
                ImageUrl = value.ImageUrl,

            };
        }
    }
}
