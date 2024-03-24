using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCrudApi.Data;
using UserCrudApi.Users.Model;
using UserCrudApi.Users.Repository.interfaces;

namespace UserCrudApi.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
           return await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(x =>x.Name.Equals(name));
        }
    }
}
