using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieCrudApi.Data;
using MovieCrudApi.Movies.Model;
using MovieCrudApi.Movies.Repository.interfaces;

namespace MovieCrudApi.Movies.Repository
{
    public class MovieRepository:IMovieRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovieRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
           return await _context.Movies.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Movie> GetByTitleAsync(string title)
        {
            return await _context.Movies.SingleOrDefaultAsync(x => x.Title.Equals(title));
        }
    }
}
