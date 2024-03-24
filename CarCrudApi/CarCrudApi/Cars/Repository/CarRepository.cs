using AutoMapper;
using CarCrudApi.Cars.Model;
using CarCrudApi.Cars.Repository.interfaces;
using CarCrudApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CarCrudApi.Cars.Repository
{
    public class CarRepository : ICarRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetByBrandAsync(string brand)
        {
            return await _context.Cars.ForEachAsync(car => car.Brand.Equals(brand));
        }
    }
}
