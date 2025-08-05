using System.ComponentModel.DataAnnotations;

namespace Shopping.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required] 
        public virtual Guid Id { get; set; }
        
    }
}
