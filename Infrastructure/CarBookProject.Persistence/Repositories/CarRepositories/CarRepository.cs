using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositoies.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsListWithBrand()
        {
            var values = await _context.Cars.Include(c => c.Brand).ToListAsync();
            return values;
        }

        public async Task<List<Car>> GetLast5CarsWithBrand()
        {
            var values = await _context.Cars.Include(x => x.Brand).OrderByDescending(c => c.CarID).Take(5).ToListAsync();
            return values;
        }
    }
}
