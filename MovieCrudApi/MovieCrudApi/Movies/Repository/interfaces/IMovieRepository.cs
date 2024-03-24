using MovieCrudApi.Movies.Model;

namespace MovieCrudApi.Movies.Repository.interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetByTitleAsync(string title);
    }
}
