using HotelCrudApi.Hotels.Model;
using HotelCrudApi.Hotels.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelCrudApi.Hotels.Controller
{
    [ApiController]
    [Route("hotel/api/v1")]
    public class ControllerHotel: ControllerBase
    {

        private ILogger _logger;
        private IHotelRepository _hotelRepository;

        public ControllerHotel(ILogger<ControllerHotel > logger, IHotelRepository hotelRepository)
        {
            _logger = logger;
            _hotelRepository = hotelRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAll()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            return Ok(hotels);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetById(int id)
        {
            var hotels = await _hotelRepository.GetByIdAsync(id);
            return Ok(hotels);
        }

        [HttpGet("title")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetByTitle(string name)
        {
            var hotels = await _hotelRepository.GetByNameAsync(name);
            return Ok(hotels);
        }

    }
}
