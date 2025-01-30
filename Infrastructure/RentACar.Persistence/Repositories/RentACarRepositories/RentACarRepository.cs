using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Interfaces.RentACarInterfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly RentaCarContext _context;

        public RentACarRepository(RentaCarContext context)
        {
            _context = context;
        }

        public async Task<List<RentCar>> GetByFilterAsync(Expression<Func<RentCar, bool>> filter)
        {
           var values=_context.RentCars.Where(filter).Include(x=>x.Car).ThenInclude(x=>x.Brand).Include(x=>x.Car).ThenInclude(x=>x.CarPricings).ThenInclude(x=>x.Pricing);

            return await values.ToListAsync();
        }
    }
}
