using FootballMatchCrudApi.Dto;
using FootballMatchCrudApi.Matches.Model;

namespace FootballMatchCrudApi.Matches.Service.Interfaces
{
    public interface IMatchCommandService
    {
        Task<FootballMatch> CreateMatch(CreateMatchRequest request);
        Task<FootballMatch> UpdateMatch(UpdateMatchRequest request);
        Task<FootballMatch> DeleteMatch(string stadium);

    }
}
