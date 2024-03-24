using Microsoft.AspNetCore.Mvc;
using UserCrudApi.Users.Model;
using UserCrudApi.Users.Repository.interfaces;

namespace UserCrudApi.Users.Controllers
{
    [ApiController]
    [Route("user/api/v1")]
    public class UserController:ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users=await _userRepository.GetAllAsync();
            return Ok(users);   
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<User>>>GetById(int id)
        {
            var users=await _userRepository.GetByIdAsync(id);
            return Ok(users);
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<User>>>GetByName(string name)
        {
            var users=await _userRepository.GetByNameAsync(name);
            return Ok(users);
        }

    }
}
