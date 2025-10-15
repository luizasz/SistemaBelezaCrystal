using SistemaBelezaCrystal.Config;
using SistemaBelezaCrystal.Models;

namespace AppExemplo.Models
{
  public class CargoDAO
  {
    private readonly Conexao _conexao;

    public CargoDAO(Conexao conexao)
    {
      _conexao = conexao;
    }

    public List<Cargo> Listar()
    {
      var lista = new List<Cargo>();

      // Cria o comando SQL para buscar todos os cargos
      var comando = _conexao.CreateCommand("SELECT * FROM cargo");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var cargo = new Cargo
        {
          Id = leitor.GetInt32("id_car"),
          Nome = leitor.GetString("nome_car")
        };

        lista.Add(cargo);
      }

      return lista;
    }
  }
}
