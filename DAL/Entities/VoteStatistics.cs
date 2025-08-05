
namespace Shopping.DAL.Entities
{
    public class StatisticsDto
    {
        public string CandidateName { get; set; }
        public string Party { get; set; }
        public int TotalVotes { get; set; }
        public double VotePercentage { get; set; }
    }

    public class StatisticsResponseDto
    {
        public int TotalVotersVoted { get; set; }
        public List<StatisticsDto> Candidates { get; set; }
    }
}
