using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Interfaces.TagCloudInterfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly RentaCarContext _context;

        public TagCloudRepository(RentaCarContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogId(int blogid)
        {
            var values = await _context.TagClouds.Where(x => x.BlogId == blogid).ToListAsync();

            return values;
        }
    }
}
