using AutoMapper;
using RestaurantCrudApi.Data;
using RestaurantCrudApi.Restaurants.Model;
using RestaurantCrudApi.Restaurants.Repository.interfaces;
using System.Data.Entity;

namespace RestaurantCrudApi.Restaurants.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(obj => obj.Id.Equals(id));
        }

        public async Task<Restaurant> GetByLocationAsync(string location)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(obj => obj.Location.Equals(location));
        }
    }
}
