using MediatR;
using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorsQueryHandler : IRequestHandler<GetAllBlogsWithAuthorsQuery, List<GetAllBlogsWithAuthorsQueryResult>>
    {
      private readonly  IRepository<Blog> _repository ;

        public GetAllBlogsWithAuthorsQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorsQueryResult>> Handle(GetAllBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync(include:x=>x.Include(x=>x.Author).Include(x=>x.Category));

            return value.Select(x=>new GetAllBlogsWithAuthorsQueryResult 
            { 
            AuthorId = x.AuthorId,
            CategoryId = x.CategoryId,
            AuthorName=x.Author.Name,
            CategoryName=x.Category.Name,
            BlogId=x.BlogId,
            CoverImageUrl=x.CoverImageUrl,
            CreatedDate=x.CreatedDate,
            Title=x.Title,
            Description=x.Description,
            AuthorDescription=x.Author.Description,
            AuthorImageUrl=x.Author.ImageUrl,   
            }).ToList();
        }
    }
}
