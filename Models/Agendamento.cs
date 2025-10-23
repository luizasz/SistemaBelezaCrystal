namespace SistemaBelezaCrystal.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Horario { get; set; }
        public int IdClienteFk { get; set; }
        public int IdServicoFk { get; set; }
        public int IdFuncionarioFk { get; set; }
        public int IdStatusFk { get; set; }
    }
}