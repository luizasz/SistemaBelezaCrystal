using SistemaBelezaCrystal.Config;
using SistemaBelezaCrystal.Models;

namespace AppExemplo.Models
{
  public class CategoriaDAO
  {
    private readonly Conexao _conexao;

    public CategoriaDAO(Conexao conexao)
    {
      _conexao = conexao;
    }

    public List<Categoria> Listar()
    {
      var lista = new List<Categoria>();

      // Cria o comando SQL para buscar todos os cargos
      var comando = _conexao.CreateCommand("SELECT * FROM categoria");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var categoria = new Categoria
        {
          Id = leitor.GetInt32("id_cat"),
          Nome = leitor.GetString("nome_cat"),
          Descricao = leitor.GetString("descricao_cat"),
          IdSituacao = leitor.GetInt32("id_sit_fk")
        };

        lista.Add(categoria);
      }

      return lista;
    }
  }
}
