using CarCrudApi.Cars.Model;
using CarCrudApi.Cars.Repository.interfaces;
using CarCrudApi.Dto;
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

        [HttpGet("/brand")]
        public async Task<ActionResult<IEnumerable<Car>>> GetByBrand(string brand)
        {
            var car = await _carRepository.GetByBrandAsync(brand);
            return Ok(car);
        }


        [HttpGet("/id")]
        public async Task<ActionResult<IEnumerable<Car>>> GetById(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            return Ok(car);
        }

        [HttpPost("/createCar")]
        public async Task<ActionResult<Car>> CreateCar([FromBody] CreateCarRequest request)
        {
            var car = await _carRepository.CreateCar(request);

            return Ok(car);
        }

        [HttpPut("/updateCar")]
        public async Task<ActionResult<Car>> UpdateCAr([FromQuery] int id, UpdateCarRequest request)
        {
            var car = await _carRepository.UpdateCar(id, request);

            return Ok(car);
        }

        [HttpDelete("/deleteById")]
        public async Task<ActionResult<Car>> DeleteCar([FromQuery] int id)
        {
            var car = await _carRepository.DeleteCarById(id);

            return Ok(car);
        }

    }
}
