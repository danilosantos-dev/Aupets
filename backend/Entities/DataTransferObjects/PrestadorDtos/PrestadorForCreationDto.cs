using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class PrestadorForCreationDto
    {
        [Required(ErrorMessage = "Campo obrigatório: Razao Social")]
        [StringLength(60, ErrorMessage = "A Razao Sozial não pode ultrapassar 60 caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Nome Fantasia")]
        [StringLength(60, ErrorMessage = "O Nome Fantasia não pode ultrapassar 60 caracteres")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Escolha uma opção:")]
        public string TipoPessoa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Cpf/Cnpj ")]
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Endereço")]
        [StringLength(60, ErrorMessage = "O Endereco não pode ultrapassar 60 caracteres")]
        public string Endereco { get; set; }

        [StringLength(60, ErrorMessage = "O Complemento não pode ultrapassar 60 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Bairro ")]
        [StringLength(60, ErrorMessage = "O Bairro não pode ultrapassar 60 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Cidade")]
        [StringLength(60, ErrorMessage = "A Cidade não pode ultrapassar 60 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Nome Numero")]
        [StringLength(8, ErrorMessage = "O número não pode ultrapassar 8 caracteres")] 
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Atuação")]
        public string Atuacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Especializacao")]
        public string Especializacao { get; set; }

        public string Imagem { get; set; }

        [StringLength(100, ErrorMessage = "O UrlSite não pode ultrapassar 100 caracteres")]
        public string UrlSite { get; set; }

        [Required]
        public string UsuarioId { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}