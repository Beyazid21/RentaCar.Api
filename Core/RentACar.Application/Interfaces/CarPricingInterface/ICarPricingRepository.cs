using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.CarPricingInterface
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarsWithPricing();

        Task<List<CarPricing>> GetCarPricingWithTimePeriod();

    }
}
