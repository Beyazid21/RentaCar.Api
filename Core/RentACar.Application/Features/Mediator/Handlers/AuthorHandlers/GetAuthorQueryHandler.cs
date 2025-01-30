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
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;


        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                Name = x.Name,
                Description = x.Description,
                ImageUrl=x.ImageUrl,    
                
            }).ToList();
        }
    }
}

