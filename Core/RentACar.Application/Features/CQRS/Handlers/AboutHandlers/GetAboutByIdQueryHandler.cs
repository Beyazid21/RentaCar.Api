using RentaCar.Domain.Entities;
using RentACar.Application.Features.CQRS.Queries.AboutQuesires;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);

            return new GetAboutByIdQueryResult
            {
                AboutId=value.AboutId,
                Description=value.Description,
                ImageUrl=value.ImageUrl,
                Title=value.Title,
            };
        }
    }
}
