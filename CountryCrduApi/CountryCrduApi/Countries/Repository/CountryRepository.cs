using AutoMapper;
using CountryCrduApi.Countries.Model;
using CountryCrduApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CountryCrduApi.Countries.Repository.interfaces
{
    public class CountryRepository : ICountryRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetByNameAsync(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Country> GetByPopulationAsync(int population)
        {
            return _context.Countries.FirstOrDefault(x => x.Population == population);
        }
    }
}
