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

namespace RentACar.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;


        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetBlogQueryResult
            {
                BlogId = x.BlogId,
                AuthorId = x.AuthorId,
                 CategoryId = x.CategoryId,
                 CoverImageUrl = x.CoverImageUrl,
                 CreatedDate = x.CreatedDate,
                  Title = x.Title,
            }).ToList();
        }
    }
}
