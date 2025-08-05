using Microsoft.EntityFrameworkCore;
using Shopping.DAL;
using Shopping.DAL.Entities;
using Shopping.Domain.Interfaces;

namespace Shopping.Domain.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly DataBaseContext _context;

        public CandidateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
        {
            try
            {
                return await _context.Candidates.ToListAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Candidate> GetCandidateByIdAsync(Guid id)
        {
            try
            {
                var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Id == id);
                if (candidate == null)
                {
                    throw new Exception("Este candidato no existe");
                }
                return candidate;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Candidate> CreateCandidateAsync(Candidate candidate)
        {
            try
            {
                if (await _context.Voters.FindAsync(candidate.Id) != null)
                {
                    throw new Exception("Este usuario ya está registrado como votante.");
                }
                candidate.Id = Guid.NewGuid();
                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();

                return candidate;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
        public async Task<bool> DeleteCandidateAsync(Guid id)
        {
            try
            {
                var candidate = await GetCandidateByIdAsync(id);

                if (candidate == null)
                {
                    throw new Exception("El id candidato no existe.");
                }
                _context.Candidates.Remove(candidate);
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
