using SistemaBelezaCrystal.Config;
using SistemaBelezaCrystal.Models;

namespace AppExemplo.Models
{
  public class ServicoDAO
  {

    private readonly Conexao _conexao;

    public ServicoDAO(Conexao conexao)
    {
      _conexao = conexao;
    }

    public void Inserir(Servico servico)
    {
      try
      {
        var comando = _conexao.CreateCommand(
            "INSERT INTO servico VALUES (null, @_nome, @_valor, @_duracao, @_id_categoria_k)"
        );

        comando.Parameters.AddWithValue("@_nome", servico.Nome);
        comando.Parameters.AddWithValue("@_valor", servico.Valor);
        comando.Parameters.AddWithValue("@_duracao", servico.Duracao);
        comando.Parameters.AddWithValue("@_cnpj", servico.IdCategoriaFk);

        comando.ExecuteNonQuery();

      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Servico> ListarTodos()
    {
      var lista = new List<Servico>();

      var comando = _conexao.CreateCommand("SELECT * FROM servico");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var servico = new Servico
        {
          Id = leitor.GetInt32("id_ser"),
          Nome = leitor.GetString("nome_ser"),
          Valor = leitor.GetDouble("preco_ser"),
          Duracao = leitor.GetTimeSpan("duracao_ser"),
          IdCategoriaFk = leitor.GetInt32("id_cat_fk"),
        };

        lista.Add(servico);
      }

      return lista;
    }

  }
}