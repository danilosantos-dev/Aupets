using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities.DataTransferObjects
{
    public class PrestadorForUpdateDto
    {
        [Required(ErrorMessage = "Campo obrigatório: Razao Social")]
        [StringLength(60, ErrorMessage = "A Razao Sozial não pode ultrapassar 60 caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Nome Fantasia")]
        [StringLength(60, ErrorMessage = "O Nome Fantasia não pode ultrapassar 60 caracteres")]
        public string NomeFantasia { get; set; }
        
        [StringLength(2000, ErrorMessage = "Sobre não pode ultrapassar 60 caracteres")]
        public string Sobre { get; set; }

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
        [StringLength(8, ErrorMessage = "O Cep não pode ultrapassar 8 caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Nome Numero")]
        [StringLength(8, ErrorMessage = "O Nome Fantasia não pode ultrapassar 8 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Atuação")]
        public string Atuacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Especializacao")]
        public string Especializacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Imagem")]
        public IFormFile Imagem { get; set; }

        [StringLength(100, ErrorMessage = "A Url não pode ultrapassar 100 caracteres")]
        public string UrlSite { get; set; }
    }
}