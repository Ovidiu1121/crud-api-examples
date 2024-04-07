using Microsoft.AspNetCore.Mvc;
using MovieCrudApi.Dto;
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

        [HttpGet("/id")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetById(int id)
        {
            var movies = await _movieRepository.GetByIdAsync(id);
            return Ok(movies);
        }

        [HttpGet("/title")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetByTitle(string title)
        {
            var movies = await _movieRepository.GetByTitleAsync(title);
            return Ok(movies);
        }

        [HttpPost("/createMovie")]
        public async Task<ActionResult<Movie>> CreateMovie([FromBody] CreateMovieRequest request)
        {
            var products = await _movieRepository.CreateMovie(request);

            return Ok(products);
        }

        [HttpPut("/updateMovie")]
        public async Task<ActionResult<Movie>> UpdateMovie([FromQuery] int id, UpdateMovieRequest request)
        {
            var movie = await _movieRepository.UpdateMovie(id, request);

            return Ok(movie);
        }

        [HttpDelete("/deleteById")]
        public async Task<ActionResult<Movie>> DeleteMovie([FromQuery] int id)
        {
            var movie = await _movieRepository.DeleteMovieById(id);

            return Ok(movie);
        }

    }
}
