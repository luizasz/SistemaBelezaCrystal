using SistemaBelezaCrystal.Config;
using SistemaBelezaCrystal.Models;

namespace AppExemplo.Models
{
    public class AgendamentoDAO
    {

        private readonly Conexao _conexao;

        public AgendamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Agendamento> ListarTodos()
        {
            var lista = new List<Agendamento>();

            // Cria o comando SQL para buscar todos os cargos
            var comando = _conexao.CreateCommand("SELECT * FROM Agendamento");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var agendamento = new Agendamento
                {
                    Id = leitor.GetInt32("id_age"),
                    Data = leitor.GetDateTime("data_age"),
                    Horario = leitor.GetTimeSpan("horario_age"),
                    IdStatus = leitor.GetInt32("id_sta_fk"),
                    IdServico = leitor.GetInt32("id_ser_fk"),
                    IdFuncionario = leitor.GetInt32("id_fun_fk"),
                    IdCliente = leitor.GetInt32("id_cli_fk")
                };

                lista.Add(agendamento);
            }

            return lista;
        }
    }
}
