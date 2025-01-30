using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Interfaces.BlogInterfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
 private readonly RentaCarContext _context;

        public BlogRepository(RentaCarContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetLast3BlogWithAuthors()
        {
           return await _context.Blogs.OrderByDescending(x=>x.BlogId).Take(3).Include(x=>x.Author).ToListAsync();   
        }
    }
}
