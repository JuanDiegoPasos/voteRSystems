using Microsoft.EntityFrameworkCore;
using Shopping.DAL;
using Shopping.DAL.Entities;
using Shopping.Domain.Interfaces;

namespace Shopping.Domain.Services
{
    public class VoterService : IVoterService
    {
        private readonly DataBaseContext _context;

        public VoterService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Voter>> GetVotersAsync()
        {
            try
            {
                return await _context.Voters.ToListAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Voter> GetVoterByIdAsync(Guid id)
        {
            try
            {
                var voter = await _context.Voters.FirstOrDefaultAsync(v => v.Id == id);
                if (voter == null)
                {
                    throw new Exception("Este usuario ya está registrado como votante.");
                }
                return voter;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Voter> CreateVoterAsync(Voter voter)
        {
            try
            {
                if (await _context.Candidates.FindAsync(voter.Id) != null)
                {
                    throw new Exception("Este usuario ya está registrado como Candidato.");
                }
                voter.Id = Guid.NewGuid();
                _context.Voters.Add(voter);
                await _context.SaveChangesAsync();

                return voter;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }


        public async Task<bool> DeleteVoterAsync(Guid id)
        {
            try
            {
                var voter = await GetVoterByIdAsync(id);

                if (voter == null)
                {
                    return false;
                }
                _context.Voters.Remove(voter);
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
