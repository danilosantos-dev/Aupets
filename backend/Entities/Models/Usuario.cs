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
        [Column("NomeUsuario")]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(200)]
        [Column("SenhaUsuario")]
        public string Senha { get; set; }

        [Required]
        [StringLength(200)]
        public string SenhaHash { get; set; }

        [Required]
        [EmailAddress]
        [Column("EmailUsuario")]
        public string Email { get; set; }

        [StringLength(400)]
        [Column("ImagemUsuario")]
        public string Imagem { get; set; }

        [Required]
        public bool EAdmin { get; set; }
    }
}