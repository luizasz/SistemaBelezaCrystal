using SistemaBelezaCrystal.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace SistemaBelezaCrystal.Models
{
    public class FuncionarioDAO
    {
        private readonly Conexao _conexao;

        public FuncionarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // MÉTODO PARA INSERIR FUNCIONÁRIO
        public void Inserir(Funcionario funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO funcionario 
                    (nome_fun, data_nascimento_fun, cpf_fun, rg_fun, telefone_fun, endereco_fun, bairro_fun, 
                     cidade_fun, estado_fun, cep_fun, email_fun, salario_fun, id_car_fk, id_sit_fk)
                    VALUES 
                    (@_nome, @_dataNascimento, @_cpf, @_rg, @_telefone, @_endereco, @_bairro, 
                     @_cidade, @_estado, @_cep, @_email, @_salario, @_cargo, @_situacao)");

                comando.Parameters.AddWithValue("@_nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@_dataNascimento", funcionario.DataNascimento);
                comando.Parameters.AddWithValue("@_cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@_rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@_telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@_endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@_bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@_cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@_estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@_cep", funcionario.Cep);
                comando.Parameters.AddWithValue("@_email", funcionario.Email);
                comando.Parameters.AddWithValue("@_salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@_cargo", funcionario.IdCargo);
                comando.Parameters.AddWithValue("@_situacao", funcionario.IdSituacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir funcionário: " + ex.Message);
            }
        }

        // MÉTODO PARA LISTAR TODOS OS FUNCIONÁRIOS
        public List<Funcionario> ListarTodos()
        {
            var lista = new List<Funcionario>();

            var comando = _conexao.CreateCommand("SELECT * FROM funcionario");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var funcionario = new Funcionario
                {
                    Id = leitor.GetInt32("id_fun"),
                    Nome = leitor.GetString("nome_fun"),
                    DataNascimento = leitor.GetDateTime("data_nascimento_fun"),
                    Cpf = leitor.GetString("cpf_fun"),
                    Rg = leitor.GetString("rg_fun"),
                    Telefone = leitor.GetString("telefone_fun"),
                    Endereco = leitor.GetString("endereco_fun"),
                    Bairro = leitor.GetString("bairro_fun"),
                    Cidade = leitor.GetString("cidade_fun"),
                    Estado = leitor.GetString("estado_fun"),
                    Cep = leitor.GetString("cep_fun"),
                    Email = leitor.GetString("email_fun"),
                    Salario = leitor.GetDouble("salario_fun"),
                    IdCargo = leitor.GetInt32("id_car_fk"),
                    IdSituacao = leitor.GetInt32("id_sit_fk")
                };

                lista.Add(funcionario);
            }

            leitor.Close();
            return lista;
        }
    }
}