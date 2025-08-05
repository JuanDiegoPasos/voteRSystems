using Shopping.DAL.Entities;

namespace Shopping.Domain.Interfaces
{
    public interface IVoterService
    {
        Task<IEnumerable<Voter>> GetVotersAsync();

        Task<Voter> CreateVoterAsync(Voter voter);

        Task<Voter> GetVoterByIdAsync(Guid id);

        Task<bool> DeleteVoterAsync(Guid id);

    }
}
