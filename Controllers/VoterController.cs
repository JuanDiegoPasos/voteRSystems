using Microsoft.AspNetCore.Mvc;
using Shopping.DAL.Entities;
using Shopping.Domain.Interfaces;
using System.Linq;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly IVoterService _voterService;

        public VoterController(IVoterService voterService)
        {
            _voterService = voterService;
        }
        [HttpGet("GetAll")]

        public async Task<ActionResult<IEnumerable<Voter>>> GetVotersAsync()
        { 
            var voters = await _voterService.GetVotersAsync();
            if (voters == null || !voters.Any()) return NotFound();
            
            return Ok(voters);
        }

        [HttpGet("GetById/{id}")]

        public async Task<ActionResult<Voter>> GetVoterByIdAsync(Guid id)
        {
            var voter = await _voterService.GetVoterByIdAsync(id);
            if (voter  == null) return NotFound();

            return Ok(voter);
        }

        [HttpPost("Create")]

        public async Task<ActionResult<Voter>> CreateVoterAsync(Voter voter)
        {
            try
            {
                var newVoter = await _voterService.CreateVoterAsync(voter);
                if (newVoter == null) return NotFound();
                return Ok(newVoter);  
            }   
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"{voter.Name} ya existe");
                return Conflict(ex.Message);
            }   
        
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Voter>> DeleteVoterAsync(Guid id)
        {
                if (id == Guid.Empty) return BadRequest("El ID no es valido");
                var deletedVoter = await _voterService.DeleteVoterAsync(id);
                if (deletedVoter == false) return NotFound();
                return Ok(deletedVoter);
        }
    }
}
