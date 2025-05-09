﻿using Microsoft.EntityFrameworkCore;
using RentaCar.Domain.Entities;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentaCarContext _context;

        public CarRepository(RentaCarContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            var value =_context.Cars.Count();
            return value;   
        }

        public async Task<List<Car>> GetCarsListWithBrand()
        {
            return await _context.Cars.Include(c => c.Brand).ToListAsync();

        }

       

        public async Task<List<Car>> GetLast5CarsListWithBrand()
        {
           return await _context.Cars.Include(c=>c.Brand).OrderByDescending(x=>x.CarId).Take(5).ToListAsync();
        }
    }
}
