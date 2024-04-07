using CountryCrduApi.Countries.Model;
using CountryCrduApi.Countries.Repository.interfaces;
using CountryCrduApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CountryCrduApi.Countries.Controller
{

    [ApiController]
    [Route("country/api/v1")]
    public class CountryControler: ControllerBase
    {

        private readonly ILogger _logger;

        private ICountryRepository _countryRepository;

        public CountryControler(ILogger<CountryControler> logger, ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        {
            var countries = await _countryRepository.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("/name")]
        public async Task<ActionResult<IEnumerable<Country>>> GetByName(string name)
        {
            var countries = await _countryRepository.GetByNameAsync(name);
            return Ok(countries);
        }

        [HttpGet("/population")]
        public async Task<ActionResult<IEnumerable<Country>>> GetByPopulation(int population)
        {
            var countries = await _countryRepository.GetByPopulationAsync(population);
            return Ok(countries);
        }

        [HttpPost("/createCountry")]
        public async Task<ActionResult<Country>> CreateCountry([FromBody] CreateCountryRequest request)
        {
            var country = await _countryRepository.CreateCountry(request);

            return Ok(country);
        }

        [HttpPut("/updateCountry")]
        public async Task<ActionResult<Country>> UpdateCountry([FromQuery] int id, UpdateCountryRequest request)
        {
            var country = await _countryRepository.UpdateCountry(id, request);

            return Ok(country);
        }

        [HttpDelete("/deleteById")]
        public async Task<ActionResult<Country>> DeleteCountry([FromQuery] int id)
        {
            var country = await _countryRepository.DeleteCountryById(id);

            return Ok(country);
        }

    }
}
