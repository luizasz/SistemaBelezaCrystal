using SistemaBelezaCrystal.Config;
using SistemaBelezaCrystal.Models;

namespace AppExemplo.Models
{
  public class FornecedorDAO
  {

    private readonly Conexao _conexao;

    public FornecedorDAO(Conexao conexao)
    {
      _conexao = conexao;
    }

    public void Inserir(Fornecedor fornecedor)
    {
      try
      {
        var comando = _conexao.CreateCommand("INSERT INTO fornecedor VALUES (null, null, @_nome, @_descricao, @_qtd, @_preco)");

        comando.Parameters.AddWithValue("@_nome", fornecedor.Nome);
        comando.Parameters.AddWithValue("@_descricao", fornecedor.Descricao);
        comando.Parameters.AddWithValue("@_qtd", fornecedor.Quantidade);
        comando.Parameters.AddWithValue("@_preco", fornecedor.Preco);

        comando.ExecuteNonQuery();

      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Produto> ListarTodos()
    {
      var lista = new List<Produto>();

      var comando = _conexao.CreateCommand("SELECT * FROM produto");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var produto = new Produto
        {
          Id = leitor.GetInt32("id_pro"),
          Nome = leitor.GetString("nome_pro"),
          Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_pro")) ? "" : leitor.GetString("descricao_pro"),
          Quantidade = leitor.GetInt32("quantidade_pro"),
          Preco = leitor.GetDecimal("preco_pro")
        };

        lista.Add(produto);
      }

      return lista;
    }

  }
}