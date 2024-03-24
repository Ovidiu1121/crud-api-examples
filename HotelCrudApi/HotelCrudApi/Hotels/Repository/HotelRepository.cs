using AutoMapper;
using HotelCrudApi.Data;
using HotelCrudApi.Hotels.Model;
using HotelCrudApi.Hotels.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelCrudApi.Hotels.Repository
{
    public class HotelRepository:IHotelRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HotelRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Hotel> GetByNameAsync(string name)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }
    }
}
