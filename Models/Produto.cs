namespace SistemaBelezaCrystal.Models
{
    public class Produto
    {
        public int Id {get; set; }
        public string? Nome {get; set; }
        public double Preco {get; set; }
        public DateTime Validade {get; set; }
        public int Unidade {get; set; }
        public string? Marca {get; set; }
        public string? Tipo {get; set; }
        public int EstoqueMinimo {get; set; }
        public int EstoqueMaximo {get; set; }
        public int IdFornecedor {get; set; }
        public int IdCategoria {get; set; }
        public int IdSituacao { get; set; }
    }
}