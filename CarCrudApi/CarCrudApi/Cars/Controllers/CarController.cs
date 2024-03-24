using CarCrudApi.Cars.Model;
using CarCrudApi.Cars.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarCrudApi.Cars.Controllers
{
    [ApiController]
    [Route("car/api/v1")]
    public class CarController:ControllerBase
    {

        private readonly ILogger<CarController> _logger;

        private ICarRepository _carRepository;

        public CarController(ILogger<CarController> logger,ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        [HttpGet("all")]

        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            var cars = await _carRepository.GetAllAsync();
            return Ok(cars);
        }

    }
}
