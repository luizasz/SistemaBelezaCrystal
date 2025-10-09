namespace SistemaBelezaCrystal.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string Proprietario { get; set; }

        public string Cnpj { get; set; }

        public string InscricaoEstadual { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }

        public string Tributacao { get; set; }

        public string ProdutosFornecidos { get; set; }

        public int IdSituacaoFk { get; set; }
    }
}
