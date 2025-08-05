using Microsoft.AspNetCore.Mvc;
using Shopping.DAL.Entities;
using Shopping.Domain.Interfaces;
using System.Linq;

namespace Shopping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;


        }
        [HttpGet("GetAll")]

        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidatesAsync()
        {
            var candidates = await _candidateService.GetCandidatesAsync();
            if (candidates == null || !candidates.Any()) return NotFound();

            return Ok(candidates);
        }

        [HttpGet("GetById/{id}")]

        public async Task<ActionResult<Candidate>> GetCandidateByIdAsync(Guid id)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null) return NotFound();

            return Ok(candidate);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Candidate>> CreateCandidateAsync(Candidate candidate)
        {
            try
            {
                var newCandidate = await _candidateService.CreateCandidateAsync(candidate);
                if (newCandidate == null) return NotFound();
                return Ok(newCandidate);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"{candidate.Name} ya existe");
                return Conflict(ex.Message);
            }

        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Candidate>> DeleteCandidateAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var deletedCandidate = await _candidateService.DeleteCandidateAsync(id);
            if (deletedCandidate == false) return NotFound();
            return Ok(deletedCandidate);
        }
    }
}
