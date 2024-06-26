﻿using AutoMapper;
using FootballMatchCrudApi.Data;
using FootballMatchCrudApi.Dto;
using FootballMatchCrudApi.Matches.Model;
using FootballMatchCrudApi.Matches.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballMatchCrudApi.Matches.Repository
{
    public class FootballMatchRepository:IFootballMatchRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FootballMatchRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FootballMatch> CreateMatch(CreateMatchRequest request)
        {
            var match = _mapper.Map<FootballMatch>(request);

            _context.Matches.Add(match);

            await _context.SaveChangesAsync();

            return match;
        }

        public async Task<FootballMatch> DeleteMatchByStadium(string stadium)
        {
            var match = await _context.Matches.FindAsync(stadium);

            _context.Matches.Remove(match);

            await _context.SaveChangesAsync();

            return match;
        }

        public async Task<IEnumerable<FootballMatch>> GetAllAsync()
        {
            return await _context.Matches.ToListAsync();
        }

        public async Task<FootballMatch> GetByScoreAsync(string score)
        {
            return await _context.Matches.FirstOrDefaultAsync(obj => obj.Score.Equals(score));
        }

        public async Task<FootballMatch> GetByStadiumAsync(string stadium)
        {
            return await _context.Matches.FirstOrDefaultAsync(obj => obj.Stadium.Equals(stadium));
        }

        public async Task<FootballMatch> UpdateMatch(UpdateMatchRequest request)
        {

            var match = await _context.Matches.FindAsync(request.Id);

            match.Stadium= request.Stadium ?? match.Stadium;
            match.Score= request.Score ?? match.Score;
            match.Country=request.Country ?? match.Country;

            _context.Matches.Update(match);

            await _context.SaveChangesAsync();

            return match;
        }
    }
}
