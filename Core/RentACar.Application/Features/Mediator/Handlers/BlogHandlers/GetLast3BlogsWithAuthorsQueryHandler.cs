using MediatR;
using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.BlogInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        //private readonly IRepository<Blog> _repository ;
        private readonly IBlogRepository _repository;
        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            //var value = await _repository.GetAllAsync(order: x => x.OrderByDescending(b => b.BlogId),takecount:3,include:x=>x.Include(b=>b.Author));
            var value = await _repository.GetLast3BlogWithAuthors();
            return value.Select(x => new GetLast3BlogsWithAuthorsQueryResult
            {
                AuthorName=x.Author.Name,
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
