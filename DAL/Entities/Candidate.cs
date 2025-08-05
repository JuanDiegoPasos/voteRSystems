using System.ComponentModel.DataAnnotations;

namespace Shopping.DAL.Entities
{
    public class Candidate : AuditBase
    {
        [Display(Name = "Nombre del candidato")] //cambiar alias
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")] //longitud maxima
        public string Name { get; set; }

        [Display(Name = "Partido político")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? Party { get; set; }

        [Display(Name = "Cantidad de votos")]
        public int Votes { get; set; } = 0;

        public ICollection<Vote>? ReceivedVotes { get; set; }

    }
}
