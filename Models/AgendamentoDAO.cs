using SistemaBelezaCrystal.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace SistemaBelezaCrystal.Models
{
    public class AgendamentoDAO
    {
        private readonly Conexao _conexao;

        public AgendamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // Método para Inserir Agendamento
        public void Inserir(Agendamento agendamento)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                INSERT INTO agendamento
                (data_age, horario_age, id_cli_fk, id_ser_fk, id_fun_fk, id_sta_fk)
                VALUES
                (@_data, @_horario, @_cliente, @_servico, @_funcionario, @_status)");

                comando.Parameters.AddWithValue("@_data", agendamento.Data);
                comando.Parameters.AddWithValue("@_horario", agendamento.Horario);
                comando.Parameters.AddWithValue("@_cliente", agendamento.IdClienteFk);
                comando.Parameters.AddWithValue("@_servico", agendamento.IdServicoFk);
                comando.Parameters.AddWithValue("@_funcionario", agendamento.IdFuncionarioFk);
                comando.Parameters.AddWithValue("@_status", agendamento.IdStatusFk);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir agendamento: " + ex.Message);
            }
        }

        // Método para Listar todos os Agendamentos
        public List<Agendamento> ListarTodos()
        {
            var lista = new List<Agendamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM agendamento");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var agendamento = new Agendamento
                {
                    Id = leitor.GetInt32("id_age"),
                    Data = leitor.GetDateTime("data_age"),
                    Horario = leitor.GetTimeSpan("horario_age"),
                    IdClienteFk = leitor.GetInt32("id_cli_fk"),
                    IdServicoFk = leitor.GetInt32("id_ser_fk"),
                    IdFuncionarioFk = leitor.GetInt32("id_fun_fk"),
                    IdStatusFk = leitor.GetInt32("id_sta_fk")
                };

                lista.Add(agendamento);
            }

            leitor.Close();
            return lista;
        }
    }
}
