using AnimalCrudApi.Animals.Model;
using AnimalCrudApi.Animals.Repository.interfaces;
using AnimalCrudApi.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrudApi.Animals.Repository
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AnimalRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<Animal> GetByIdAsync(int id)
        {
            return await _context.Animals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Animal> GetByNameAsync(string name)
        {
            return _context.Animals.FirstOrDefault(x => x.Name == name);
        }
    }
}
