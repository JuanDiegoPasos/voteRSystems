using Shopping.DAL.Entities;

namespace Shopping.Domain.Interfaces
{
    public interface IVoteService
    {
        Task<IEnumerable<Vote>> GetVotesAsync();

        Task<Vote> CreateVoteAsync(Vote vote);

        Task<Vote> GetVoteByIdAsync(Guid id);

        Task<bool> DeleteVoteAsync(Guid id);

        Task<StatisticsResponseDto> GetStatisticsAsync();

    }
}
