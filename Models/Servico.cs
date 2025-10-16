namespace SistemaBelezaCrystal.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public TimeSpan Duracao { get; set; }
        public int IdCategoriaFk  { get; set; }
    }
}