using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Interfaces.CarFeaturesInterface;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly RentaCarContext _context;

        public CarFeatureRepository(RentaCarContext context)
        {
            _context = context;
        }

        public async Task ChangeToFalse(List<int> ints)
        {
            var values = await _context.CarFeature
       .Where(x => ints.Contains(x.CarFeatureId))
       .ToListAsync();

            // Hər bir tapılmış qeydi "Available = false" olaraq dəyişdiririk
            foreach (var value in values)
            {
                value.Available = false;
            }

            // Dəyişiklikləri saxlayırıq
            await _context.SaveChangesAsync();

        }

        public async Task ChangeToTrue(List<int> ints)
        {
            var values = await _context.CarFeature
     .Where(x => ints.Contains(x.CarFeatureId))
     .ToListAsync();

        
            foreach (var value in values)
            {
                value.Available = true;
            }

            // Dəyişiklikləri saxlayırıq
            await _context.SaveChangesAsync();
        }

        public async Task CreateCarFeatureByCarId(CarFeature carFeature)
        {
            await _context.CarFeature.AddAsync(carFeature);
            await _context.SaveChangesAsync();
        }
    }
}
