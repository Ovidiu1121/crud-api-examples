using FootballMatchCrudApi.Dto;
using FootballMatchCrudApi.Matches.Model;
using Microsoft.AspNetCore.Mvc;

namespace FootballMatchCrudApi.Matches.Controller.Interfaces
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class MatchApiController:ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(statusCode: 200, type: typeof(IEnumerable<FootballMatch>))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<IEnumerable<FootballMatch>>> GetAll();

        [HttpPost("create")]
        [ProducesResponseType(statusCode: 201, type: typeof(FootballMatch))]
        [ProducesResponseType(statusCode: 400, type: typeof(String))]
        public abstract Task<ActionResult<FootballMatch>> CreateMatch([FromBody] CreateMatchRequest request);

        [HttpPut("update")]
        [ProducesResponseType(statusCode: 202, type: typeof(FootballMatch))]
        [ProducesResponseType(statusCode: 400, type: typeof(String))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<FootballMatch>> UpdateMatch([FromBody] UpdateMatchRequest request);

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(statusCode: 202, type: typeof(FootballMatch))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<FootballMatch>> DeleteMatch([FromRoute] string stadium);

        [HttpGet("stadium")]
        [ProducesResponseType(statusCode: 202, type: typeof(FootballMatch))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<FootballMatch>> GetByStadiumRoute([FromRoute] string stadium);
    }
}
