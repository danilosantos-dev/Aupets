using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Prestador")]
    public class Prestador
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [StringLength(255)]
        public string RazaoSocial { get; set; }

        [Required]
        [StringLength(255)]
        public string NomeFantasia { get; set; }

        [Required]
        [StringLength(1)]
        public string TipoPessoa { get; set; }

        [Required]
        [StringLength(18)]
        public string CnpjCpf { get; set; }

        [Required]
        [StringLength(255)]
        public string Endereco { get; set; }

        [StringLength(255)]
        public string Complemento { get; set; }

        [Required]
        [StringLength(255)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(255)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(9)]
        public string Cep { get; set; }

        [Required]
        [StringLength(6)]
        public string Numero { get; set; }

        [StringLength(100)]
        public string Atuacao { get; set; }

        [Required]
        [StringLength(100)]
        public string Especializacao { get; set; }

        [StringLength(400)]
        public string Imagem { get; set; }

        [StringLength(255)]
        public string UrlSite { get; set; }        
        
        [Required]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}