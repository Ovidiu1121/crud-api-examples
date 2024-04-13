using FootballMatchCrudApi.Dto;
using FootballMatchCrudApi.Matches.Model;

namespace FootballMatchCrudApi.Matches.Repository.interfaces
{
    public interface IFootballMatchRepository
    {
        Task<IEnumerable<FootballMatch>> GetAllAsync();
        Task<FootballMatch> GetByStadiumAsync(string stadium);
        Task<FootballMatch> GetByScoreAsync(string score);
        Task<FootballMatch> CreateMatch(CreateMatchRequest request);
        Task<FootballMatch> UpdateMatch(UpdateMatchRequest request);
        Task<FootballMatch> DeleteMatchByStadium(string stadium);
    }
}
