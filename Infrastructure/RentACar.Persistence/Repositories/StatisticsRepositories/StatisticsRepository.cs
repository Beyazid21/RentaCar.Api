using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly RentaCarContext _context;

        public StatisticsRepository(RentaCarContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxComment()
        {
            throw new NotImplementedException();
        }

        public string GetBrandNameByMaxCar()
        {
            string brandname = _context.Brands
         .Include(x => x.Cars) // Hər brendi ilə əlaqəli maşınları gətir
         .OrderByDescending(x => x.Cars.Count) // Maşınların sayına görə azalan sırala
         .Select(x => x.Model) // Yalnız adını seç
         .First(); // İlk elementi götür

            return brandname;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceCarForDaily()
        {
            decimal value = _context.CarPricings.Include(x=>x.Pricing).Where(x => x.Pricing.Name == "Günlük").Average(x=>x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceCarForMonthly()
        {
            decimal value = _context.CarPricings.Include(x => x.Pricing).Where(x => x.Pricing.Name == "Aylıq").Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceCarForWeekly()
        {
            decimal value = _context.CarPricings.Include(x => x.Pricing).Where(x => x.Pricing.Name == "Həftəlik").Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {


            string Model= _context.CarPricings.Include(x=>x.Car).Include(x => x.Pricing).Where(x=>x.Pricing.Name=="Günlük").OrderByDescending(x=>x.Amount).Select(x=>x.Car.Name).First();
            return Model;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            string Model = _context.CarPricings.Include(x => x.Car).Include(x => x.Pricing).Where(x => x.Pricing.Name == "Günlük").OrderByDescending(x => x.Amount).Select(x => x.Car.Name).Last();
            return Model;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektirik" ).Count();

            return value;
        }

        public int GetCarCountByFuelGasolineorDiesel()
        {
            var value= _context.Cars.Where(x=>x.Fuel=="Benzin" || x.Fuel=="Dizel").Count();

            return value;
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            var value= _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmisson == "Avtomat").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value=_context.GetLocations.Count();
            return value;
        }
    }
}
