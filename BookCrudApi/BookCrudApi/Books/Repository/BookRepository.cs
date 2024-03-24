using AutoMapper;
using BookCrudApi.Books.Model;
using BookCrudApi.Books.Repository.interfaces;
using BookCrudApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BookCrudApi.Books.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
           return await _context.Books.FirstOrDefaultAsync(x => x.Id.Equals(id));
            
        }

        public async Task<Book> GetByTitleAsync(string title)
        {
           return await _context.Books.FirstOrDefaultAsync(x =>x.Title.Equals(title));
        }
    }
}
