using AnimalCrudApi.Animals.Model;
using AnimalCrudApi.Animals.Repository.interfaces;
using AnimalCrudApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AnimalCrudApi.Controllers
{
    [ApiController]
    [Route("animal/api/v1")]
    public class AnimalController: ControllerBase
    {
        private readonly ILogger _logger;

        private IAnimalRepository _animalRepository;

        public AnimalController(ILogger<AnimalController>logger, IAnimalRepository animalRepository)
        {
            _logger = logger;
            _animalRepository = animalRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAll()
        {
            var animals=await _animalRepository.GetAllAsync();
            return Ok(animals);
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetName(string name)
        {
            var animals = await _animalRepository.GetByNameAsync(name);
            return Ok(animals);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetId(int id)
        {
            var animals = await _animalRepository.GetByIdAsync(id);
            return Ok(animals);
        }

        [HttpPost("createAnimal")]
        public async Task<ActionResult<Animal>> CreateProduct([FromBody] CreateAnimalRequest request)
        {
            var animal = await _animalRepository.CreateAnimal(request);

            return Ok(animal);
        }

        [HttpPut("/updateAnimal")]
        public async Task<ActionResult<Animal>> UpdateAnimal([FromQuery] int id, UpdateAnimalRequest request)
        {
            var animal = await _animalRepository.UpdateAnimal(id, request);

            return Ok(animal);
        }

        [HttpDelete("/deleteById")]
        public async Task<ActionResult<Animal>> DeleteAnimal([FromQuery] int id)
        {
            var animal = await _animalRepository.DeleteAnimalById(id);

            return Ok(animal);
        }


    }
}
