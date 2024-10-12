using RentaCar.Domain.Entities;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var value=await _repository.GetAllAsync();

            return value.Select(x=>new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                Description=x.Description,
                Title=x.Title,
                VideoUrl=x.VideoUrl,    
                VieoDescription=x.VieoDescription,
                
            }).ToList();
        }
    }
}
