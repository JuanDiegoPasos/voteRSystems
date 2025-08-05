using Shopping.DAL.Entities;

namespace Shopping.Domain.Interfaces
{
    public interface ICandidateService
    {
        Task<Candidate> CreateCandidateAsync(Candidate candidate);

        Task<Candidate> GetCandidateByIdAsync(Guid id);

        Task<IEnumerable<Candidate>> GetCandidatesAsync();

        Task<bool> DeleteCandidateAsync(Guid id);

    }
}

