using CountryCrduApi.Countries.Model;
using CountryCrduApi.Countries.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CountryCrduApi.Countries.Controller
{
    public class CountryControler: ControllerBase
    {

        private readonly ILogger _logger;

        private ICountryRepository _animalRepository;

        public CountryControler(ILogger<CountryControler> logger, ICountryRepository animalRepository)
        {
            _logger = logger;
            _animalRepository = animalRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        {
            var countries = await _animalRepository.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Country>>> GetByName(string name)
        {
            var countries = await _animalRepository.GetByNameAsync(name);
            return Ok(countries);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Country>>> GetByPopulation(int population)
        {
            var countries = await _animalRepository.GetByPopulationAsync(population);
            return Ok(countries);
        }

    }
}
