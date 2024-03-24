using AutoMapper;
using StudentCrudApi.Data;
using StudentCrudApi.Students.Model;
using StudentCrudApi.Students.Repository.interfaces;
using System.Data.Entity;

namespace StudentCrudApi.Students.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await this._context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
           return await _context.Students.FirstOrDefaultAsync(obj => obj.id.Equals(id));
        }

        public async Task<Student> GetByNameAsync(string name)
        {
            return await _context.Students.FirstOrDefaultAsync(obj => obj.name.Equals(name));
        }
    }
}
