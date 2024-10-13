using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces;
using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.CategoryResults;

namespace RentACar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();

            return value.Select(x => new GetCategoryQueryResult
            {
             CategoryId = x.CategoryId,
             Name = x.Name,
            }).ToList();
        }
    }
}
