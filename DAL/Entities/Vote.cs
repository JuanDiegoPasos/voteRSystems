using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.DAL.Entities
{
    public class Vote : AuditBase
    {
        [Display(Name = "Votante")] //cambiar alias
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public Guid VoterId { get; set; }

        [ForeignKey(nameof(VoterId))]
        public Voter? Voter { get; set; }

        [Display(Name = "Candidato seleccionado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public Guid CandidateId { get; set; }

        [ForeignKey(nameof(CandidateId))]
        public Candidate? Candidate { get; set; }
    }
}
