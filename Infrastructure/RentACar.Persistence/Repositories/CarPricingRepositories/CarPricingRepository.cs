using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Interfaces.CarPricingInterface;
using RentACar.Persistence.Context;


namespace RentACar.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly RentaCarContext _context ;

        public CarPricingRepository(RentaCarContext context)
        {
            _context = context;
        }

		public async Task<List<CarPricing>> GetCarPricingWithTimePeriod()
		{
			var values=await _context.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(x=>x.Pricing).ToListAsync();
            return values;
		}

		public async Task<List<CarPricing>> GetCarsWithPricing()
        {
          var value=await _context.CarPricings.Include(x=>x.Car).ThenInclude(x=>x.Brand).Include(x=>x.Pricing).Where(x=>x.Pricing.PricingId==2).ToListAsync();

            return value;
        }
    }
}
