using FootballMatchCrudApi.Matches.Model;
using System.Text.RegularExpressions;

namespace FootballMatchCrudApi.Matches.Repository.interfaces
{
    public interface IFootballMatchRepository
    {
        Task<IEnumerable<FootballMatch>> GetAllAsync();
        Task<FootballMatch> GetByStadiumAsync(string stadium);
        Task<FootballMatch> GetByScoreAsync(string score);
    }
}
