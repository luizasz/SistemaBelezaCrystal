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
        var comando = _conexao.CreateCommand(
            "INSERT INTO fornecedor VALUES (null, @_nome_fantasia, @_razao_social, @_proprietario, @_cnpj, @_inscricao_estadual, @_telefone, @_email, @_endereco, @_bairro, @_cidade, @_estado, @_cep, @_tributacao, @_produtos_fornecidos, @_id_situacao_fk)"
        );

        comando.Parameters.AddWithValue("@_nome_fantasia", fornecedor.NomeFantasia);
        comando.Parameters.AddWithValue("@_razao_social", fornecedor.RazaoSocial);
        comando.Parameters.AddWithValue("@_proprietario", fornecedor.Proprietario);
        comando.Parameters.AddWithValue("@_cnpj", fornecedor.Cnpj);
        comando.Parameters.AddWithValue("@_inscricao_estadual", fornecedor.InscricaoEstadual);
        comando.Parameters.AddWithValue("@_telefone", fornecedor.Telefone);
        comando.Parameters.AddWithValue("@_email", fornecedor.Email);
        comando.Parameters.AddWithValue("@_endereco", fornecedor.Endereco);
        comando.Parameters.AddWithValue("@_bairro", fornecedor.Bairro);
        comando.Parameters.AddWithValue("@_cidade", fornecedor.Cidade);
        comando.Parameters.AddWithValue("@_estado", fornecedor.Estado);
        comando.Parameters.AddWithValue("@_cep", fornecedor.Cep);
        comando.Parameters.AddWithValue("@_tributacao", fornecedor.Tributacao);
        comando.Parameters.AddWithValue("@_produtos_fornecidos", fornecedor.ProdutosFornecidos);
        comando.Parameters.AddWithValue("@_id_situacao_fk", fornecedor.IdSituacaoFk);

        comando.ExecuteNonQuery();

      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Fornecedor> ListarTodos()
    {
      var lista = new List<Fornecedor>();

      var comando = _conexao.CreateCommand("SELECT * FROM fornecedor");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var fornecedor = new Fornecedor
        {
          Id = leitor.GetInt32("id_for"),
          NomeFantasia = leitor.GetString("nome_fantasia_for"),
          RazaoSocial = leitor.GetString("razao_social_for"),
          Proprietario = leitor.GetString("proprietario_for"),
          Cnpj = leitor.GetString("cnpj_for"),
          InscricaoEstadual = leitor.GetString("inscricao_estadual_for"),
          Telefone = leitor.GetString("telefone_for"),
          Email = leitor.GetString("email_for"),
          Endereco = leitor.GetString("endereco_for"),
          Bairro = leitor.GetString("bairro_for"),
          Cidade = leitor.GetString("cidade_for"),
          Estado = leitor.GetString("estado_for"),
          Cep = leitor.GetString("cep_for"),
          Tributacao = leitor.GetString("tributacao_for"),
          ProdutosFornecidos = leitor.GetString("produtos_fornecidos_for"),
          IdSituacaoFk = leitor.GetInt32("id_sit_fk")
        };

        lista.Add(fornecedor);
      }

      return lista;
    }

  }
}