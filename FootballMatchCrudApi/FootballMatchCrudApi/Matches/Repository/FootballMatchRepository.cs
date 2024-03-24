using AutoMapper;
using FootballMatchCrudApi.Data;
using FootballMatchCrudApi.Matches.Model;
using FootballMatchCrudApi.Matches.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FootballMatchCrudApi.Matches.Repository
{
    public class FootballMatchRepository : IFootballMatchRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FootballMatchRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FootballMatch>> GetAllAsync()
        {
            return await _context.Matches.ToListAsync();
        }

        public async Task<FootballMatch> GetByScoreAsync(string score)
        {
            return await _context.Matches.FirstOrDefaultAsync(x => x.Score == score);
        }

        public async Task<FootballMatch> GetByStadiumAsync(string stadium)
        {
            return _context.Matches.FirstOrDefault(x => x.Stadium == stadium);
        }
    }
}
