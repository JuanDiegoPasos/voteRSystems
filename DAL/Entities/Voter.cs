using System.ComponentModel.DataAnnotations;

namespace Shopping.DAL.Entities
{
    public class Voter : AuditBase
    {
        [Display(Name = "Nombre del votante")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")] //longitud maxima
        public string Name { get; set; }

        [Display(Name = "Correo electrónico único")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")] //longitud maxima

        public string Email { get; set; }

        [Display(Name = "¿Ya votó?")]
        public bool HasVoted { get; set; } = false;

        public Vote? Vote { get; set; }
    }
}
