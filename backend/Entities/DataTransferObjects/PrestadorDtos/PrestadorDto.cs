using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class PrestadorDto
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Sobre { get; set; }
        public string TipoPessoa { get; set; }
        public string CnpjCpf { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Atuacao { get; set; }
        public string Especializacao { get; set; }
        public string Imagem { get; set; }
        public string UrlSite { get; set; }
        public Status Status { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<EspecializacaoPrestador> Especializacoes { get; set; }
        public ICollection<AtuacaoPrestador> Atuacoes { get; set; }

    }
}