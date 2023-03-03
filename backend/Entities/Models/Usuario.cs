using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Senha { get; set; }

        [Required]
        [StringLength(200)]
        public string SenhaHash { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(400)]
        public string Imagem { get; set; }
    }
}