using MediatR;

using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using Microsoft.EntityFrameworkCore;

namespace RentACar.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(predicate:x=>x.BlogId==request.Id,include:x=>x.Include(b=>b.Author));

            return new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
            Title = value.Title,    
            CreatedDate = value.CreatedDate,
            CoverImageUrl = value.CoverImageUrl,
            CategoryId = value.CategoryId,
             AuthorId = value.AuthorId,
             Description = value.Description,
             AuthorImageUrl=value.Author.ImageUrl,
             AuthorDescription=value.Author.Description,
             AuthorName=value.Author.Name,


            };
        }
    }
}
