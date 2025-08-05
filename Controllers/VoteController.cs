using Microsoft.AspNetCore.Mvc;
using Shopping.DAL.Entities;
using Shopping.Domain.Interfaces;
using System.Linq;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }
        [HttpGet("GetAll")]

        public async Task<ActionResult<IEnumerable<Vote>>> GetVotesAsync()
        { 
            var votes = await _voteService.GetVotesAsync();
            if (votes == null || !votes.Any()) return NotFound();
            
            return Ok(votes);
        }

        [HttpGet("GetById/{id}")]

        public async Task<ActionResult<Vote>> GetVoteByIdAsync(Guid id)
        {
            var vote = await _voteService.GetVoteByIdAsync(id);
            if (vote  == null) return NotFound();

            return Ok(vote);
        }

        [HttpPost("Create")]

        public async Task<ActionResult<Vote>> CreateVoteAsync(Vote vote)
        {
            try
            {
                var newVote = await _voteService.CreateVoteAsync(vote);
                if (newVote == null) return NotFound();
                return Ok(newVote);  
            }   
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"{vote.Id} voto ya existe");
                return Conflict(ex.Message);
            }   
        
        }

        [HttpGet("statistics")]
        public async Task<ActionResult<StatisticsResponseDto>> GetStatistics()
        {
            return Ok(await _voteService.GetStatisticsAsync());
        }



        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Vote>> DeleteVoteAsync(Guid id)
        {
                if (id == Guid.Empty) return BadRequest("El ID no es valido");
                var deletedVote = await _voteService.DeleteVoteAsync(id);
                if (deletedVote == false) return NotFound();
                return Ok(deletedVote);
        }
    }
}
