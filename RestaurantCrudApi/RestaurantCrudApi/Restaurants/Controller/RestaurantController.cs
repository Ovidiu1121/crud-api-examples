using Microsoft.AspNetCore.Mvc;
using RestaurantCrudApi.Dto;
using RestaurantCrudApi.Restaurants.Model;
using RestaurantCrudApi.Restaurants.Repository.interfaces;

namespace RestaurantCrudApi.Restaurants.Controller
{
    [ApiController]
    [Route("restaurant/api/v1")]
    public class RestaurantController: ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;

        private IRestaurantRepository _restaurantRepository;


        public RestaurantController(ILogger<RestaurantController> logger, IRestaurantRepository restaurantRepository)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAll()
        {
            var restaurants = await _restaurantRepository.GetAllAsync();
            return Ok(restaurants);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetById(int id)
        {
            var restaurants = await _restaurantRepository.GetByIdAsync(id);
            return Ok(restaurants);
        }

        [HttpGet("location")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetByLocation(string location)
        {
            var restaurants = await _restaurantRepository.GetByLocationAsync(location);
            return Ok(restaurants);
        }

        [HttpPost("/createRestaurant")]
        public async Task<ActionResult<Restaurant>> CreateRestaurant([FromBody] CreateRestaurantRequest request)
        {
            var products = await _restaurantRepository.Create(request);

            return Ok(products);
        }

    }
}
