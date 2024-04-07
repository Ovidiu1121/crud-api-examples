using FootballMatchCrudApi.Dto;
using FootballMatchCrudApi.Matches.Model;
using FootballMatchCrudApi.Matches.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballMatchCrudApi.Matches.Controller
{
    [ApiController]
    [Route("match/api/v1")]
    public class MatchControler: ControllerBase
    {

        private readonly ILogger _logger;

        private IFootballMatchRepository _footballMatchRepository;

        public MatchControler(ILogger<MatchControler> logger, IFootballMatchRepository footballMatchRepository)
        {
            _logger = logger;
            _footballMatchRepository = footballMatchRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<FootballMatch>>> GetAll()
        {
            var animals = await _footballMatchRepository.GetAllAsync();
            return Ok(animals);
        }

        [HttpGet("/stadium")]
        public async Task<ActionResult<IEnumerable<FootballMatch>>> GetByStadium(string stadium)
        {
            var animals = await _footballMatchRepository.GetByStadiumAsync(stadium);
            return Ok(animals);
        }

        [HttpGet("/score")]
        public async Task<ActionResult<IEnumerable<FootballMatch>>> GetByScore(string score)
        {
            var animals = await _footballMatchRepository.GetByScoreAsync(score);
            return Ok(animals);
        }

        [HttpPost("/createMatch")]
        public async Task<ActionResult<FootballMatch>> CreateMatch([FromBody] CreateMatchRequest request)
        {
            var match = await _footballMatchRepository.CreateMatch(request);

            return Ok(match);
        }

        [HttpPut("/updateMatch")]
        public async Task<ActionResult<FootballMatch>> UpdateMatch([FromQuery] int id, UpdateMatchRequest request)
        {
            var match = await _footballMatchRepository.UpdateMatch(id, request);

            return Ok(match);
        }

        [HttpDelete("/deleteById")]
        public async Task<ActionResult<FootballMatch>> DeleteMatch([FromQuery] int id)
        {
            var match = await _footballMatchRepository.DeleteMatchById(id);

            return Ok(match);
        }
    }
}
