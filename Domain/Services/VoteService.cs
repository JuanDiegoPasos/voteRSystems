using Microsoft.EntityFrameworkCore;
using Shopping.DAL;
using Shopping.DAL.Entities;
using Shopping.Domain.Interfaces;

namespace Shopping.Domain.Services
{
    public class VoteService : IVoteService
    {
        private readonly DataBaseContext _context;

        public VoteService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Vote> GetVoteByIdAsync(Guid id)
        {
            try
            {
                var vote = await _context.Votes.FirstOrDefaultAsync(v => v.Id == id);
                if (vote == null)
                {
                    throw new Exception("Este usuario ya está registrado como votante.");
                }
                return vote;
                }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
        public async Task<IEnumerable<Vote>> GetVotesAsync()
        {
            try
            {
                return await _context.Votes.ToListAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Vote> CreateVoteAsync(Vote vote)
        {
            try
            {
                var voter = await _context.Voters.FirstOrDefaultAsync(v => v.Id == vote.VoterId);

                if (voter == null)
                    throw new Exception("Votante no encontrado.");

                if (voter.HasVoted)
                    throw new Exception("Este votante ya ha votado.");

                var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Id == vote.CandidateId);

                if (candidate == null)
                    throw new Exception("Candidato no encontrado.");

                vote.Id = Guid.NewGuid();
                voter.HasVoted = true;
                candidate.Votes++;
                _context.Votes.Add(vote);
                await _context.SaveChangesAsync();

                return vote;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<StatisticsResponseDto> GetStatisticsAsync()
        {
            var totalVotes = await _context.Votes.CountAsync();
            var totalVotersVoted = await _context.Voters.CountAsync(v => v.Vote != null);

            var candidates = await _context.Candidates
                .Select(c => new StatisticsDto
                {
                    CandidateName = c.Name,
                    Party = c.Party,
                    TotalVotes = c.ReceivedVotes.Count,
                    VotePercentage = totalVotes == 0 ? 0 : Math.Round((double)c.ReceivedVotes.Count * 100 / totalVotes, 2)
                })
                .ToListAsync();

            return new StatisticsResponseDto
            {
                TotalVotersVoted = totalVotersVoted,
                Candidates = candidates
            };
        }
        public async Task<bool> DeleteVoteAsync(Guid id)
        {
            try
            {
                var vote = await GetVoteByIdAsync(id);

                if (vote == null)
                {
                    return false;
                }
                _context.Votes.Remove(vote);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }

        }
    }
}
