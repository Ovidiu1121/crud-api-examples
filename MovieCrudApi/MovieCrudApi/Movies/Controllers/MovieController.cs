using Microsoft.AspNetCore.Mvc;
using MovieCrudApi.Movies.Model;
using MovieCrudApi.Movies.Repository.interfaces;

namespace MovieCrudApi.Movies.Controllers
{
    [ApiController]
    [Route("movie/api/v1")]   
    public class MovieController: ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        private IMovieRepository _movieRepository;


        public MovieController(ILogger<MovieController> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetById(int id)
        {
            var movies = await _movieRepository.GetByIdAsync(id);
            return Ok(movies);
        }

        [HttpGet("title")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetByTitle(string title)
        {
            var movies = await _movieRepository.GetByTitleAsync(title);
            return Ok(movies);
        }

    }
}
