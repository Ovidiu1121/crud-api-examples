using FootballMatchCrudApi.Dto;
using FootballMatchCrudApi.Matches.Model;
using FootballMatchCrudApi.Matches.Repository.interfaces;
using FootballMatchCrudApi.Matches.Service.Interfaces;
using FootballMatchCrudApi.System.Constant;
using FootballMatchCrudApi.System.Exceptions;

namespace FootballMatchCrudApi.Matches.Service
{
    public class MatchCommandService: IMatchCommandService
    {

        private IFootballMatchRepository _repository;

        public MatchCommandService(IFootballMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<FootballMatch> CreateMatch(CreateMatchRequest request)
        {
            FootballMatch match = await _repository.GetByStadiumAsync(request.Stadium);

            if (match!=null)
            {
                throw new ItemAlreadyExists(Constants.MATCH_ALREADY_EXIST);
            }

            match=await _repository.CreateMatch(request);
            return match;
        }

        public async Task<FootballMatch> DeleteMatch(string stadium)
        {
            FootballMatch match = await _repository.GetByStadiumAsync(stadium);

            if (match!=null)
            {
                throw new ItemDoesNotExist(Constants.MATCH_DOES_NOT_EXIST);
            }

            await _repository.DeleteMatchByStadium(stadium);
            return match;
        }

        public async Task<FootballMatch> UpdateMatch(UpdateMatchRequest request)
        {
            FootballMatch match = await _repository.GetByStadiumAsync(request.Stadium);

            if (match!=null)
            {
                throw new ItemDoesNotExist(Constants.MATCH_DOES_NOT_EXIST);
            }

            match = await _repository.UpdateMatch(request);
            return match;
        }
    }
}
