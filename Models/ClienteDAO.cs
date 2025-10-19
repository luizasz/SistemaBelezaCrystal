using SistemaBelezaCrystal.Config;
using SistemaBelezaCrystal.Models;

namespace AppExemplo.Models
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;

        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "INSERT INTO cliente VALUES (null, @_nome_cli, @_cpf_cli, @_telefone_cli, @_endereco_cli, @_bairro_cli, @_cidade_cli, @_estado_cli, @_cep_cli, @_complemento_cli, @_email_cli, @_observacoes_cli, @_id_sex_fk, @_id_sit_fk)"
                );

                comando.Parameters.AddWithValue("@_nome_cli", cliente.Nome);
                comando.Parameters.AddWithValue("@_cpf_cli", cliente.CPF);
                comando.Parameters.AddWithValue("@_telefone_cli", cliente.Telefone);
                comando.Parameters.AddWithValue("@_endereco_cli", cliente.Endereco);
                comando.Parameters.AddWithValue("@_bairro_cli", cliente.Bairro);
                comando.Parameters.AddWithValue("@_cidade_cli", cliente.Cidade);
                comando.Parameters.AddWithValue("@_estado_cli", cliente.Estado);
                comando.Parameters.AddWithValue("@_cep_cli", cliente.Cep);
                comando.Parameters.AddWithValue("@_complemento_cli", cliente.Complemento);
                comando.Parameters.AddWithValue("@_email_cli", cliente.Email);
                comando.Parameters.AddWithValue("@_observacoes_cli", cliente.Observacoes);
                comando.Parameters.AddWithValue("@_id_sex_fk", cliente.IdSexoFk);
                comando.Parameters.AddWithValue("@_id_sit_fk", cliente.IdSituacaoFk);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cliente> ListarTodos()
        {
            var lista = new List<Cliente>();

            var comando = _conexao.CreateCommand("SELECT * FROM cliente");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente
                {
                    Id = leitor.GetInt32("id_cli"),
                    Nome = leitor.GetString("nome_cli"),
                    CPF = leitor.GetString("cpf_cli"),
                    Telefone = leitor.GetString("telefone_cli"),
                    Endereco = leitor.GetString("endereco_cli"),
                    Bairro = leitor.GetString("bairro_cli"),
                    Cidade = leitor.GetString("cidade_cli"),
                    Estado = leitor.GetString("estado_cli"),
                    Cep = leitor.GetString("cep_cli"),
                    Complemento = leitor.GetString("complemento_cli"),
                    Email = leitor.GetString("email_cli"),
                    Observacoes = leitor.GetString("observacoes_cli"),
                    IdSexoFk = leitor.GetInt32("id_sex_fk"),
                    IdSituacaoFk = leitor.GetInt32("id_sit_fk")
                };

                lista.Add(cliente);
            }

            return lista;
        }
    }
}
