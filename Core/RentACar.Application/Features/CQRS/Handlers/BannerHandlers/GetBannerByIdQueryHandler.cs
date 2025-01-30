using RentaCar.Domain.Entities;
using RentACar.Application.Features.CQRS.Queries.BannerQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers
{

    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value=await _repository.GetByIdAsync(predicate: x => x.BannerId == query.Id);

            return new GetBannerByIdQueryResult
            {
                BannerId = value.BannerId,
                Description = value.Description,
                Title = value.Title,
                VideoUrl = value.VideoUrl,
                VieoDescription = value.VieoDescription,
            };
        }
    }
}
