namespace SistemaBelezaCrystal.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Horario { get; set; }
        public int IdCliente { get; set; }
        public int IdServico { get; set; }
        public int IdFuncionario { get; set; }
        public int IdStatus { get; set; }
    }
}