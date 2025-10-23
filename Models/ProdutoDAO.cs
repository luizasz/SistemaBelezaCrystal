using SistemaBelezaCrystal.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace SistemaBelezaCrystal.Models
{
    public class ProdutoDAO
    {
        private readonly Conexao _conexao;

        public ProdutoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // MÉTODO PARA INSERIR PRODUTOS
        public void Inserir(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    INSERT INTO produto
                    (nome_prod, preco_prod, validade_prod, marca_prod, tipo_prod, unidade_prod,
                    estoque_minimo_prod, estoque_maximo_prod, id_for_fk, id_sit_fk)
                    VALUES
                    (@_nome, @_preco, @_validade, @_marca, @_tipo, @_unidade,
                    @_estoqueMinimo, @_estoqueMaximo, @_fornecedor, @_situacao)");

                comando.Parameters.AddWithValue("@_nome", produto.Nome);
                comando.Parameters.AddWithValue("@_preco", produto.Preco);
                comando.Parameters.AddWithValue("@_validade", produto.Validade);
                comando.Parameters.AddWithValue("@_marca", produto.Marca);
                comando.Parameters.AddWithValue("@_tipo", produto.Tipo);
                comando.Parameters.AddWithValue("@_unidade", produto.Unidade);
                comando.Parameters.AddWithValue("@_estoqueMinimo", produto.EstoqueMinimo);
                comando.Parameters.AddWithValue("@_estoqueMaximo", produto.EstoqueMaximo);
                comando.Parameters.AddWithValue("@_fornecedor", produto.IdFornecedorFk);
                comando.Parameters.AddWithValue("@_situacao", produto.IdSituacaoFk);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir produto: " + ex.Message);
            }
        }

        // MÉTODO PARA LISTAR TODOS OS PRODUTOS
        public List<Produto> ListarTodos()
        {
            var lista = new List<Produto>();

            var comando = _conexao.CreateCommand("SELECT * FROM produto;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var produto = new Produto
                {
                    Id = leitor.GetInt32("id_prod"),
                    Nome = DAOHelper.GetString(leitor, "nome_prod"),
                    Preco = DAOHelper.GetDouble(leitor, "preco_prod"),
                    Validade = DAOHelper.GetDateTime(leitor, "validade_prod") ?? DateTime.MinValue,
                    Marca = DAOHelper.GetString(leitor, "marca_prod"),
                    Tipo = DAOHelper.GetString(leitor, "tipo_prod"),
                    Unidade = leitor.GetInt32("unidade_prod"),
                    EstoqueMinimo = leitor.GetInt32("estoque_minimo_prod"),
                    EstoqueMaximo = leitor.GetInt32("estoque_maximo_prod"),
                    IdFornecedorFk = leitor.GetInt32("id_for_fk"),
                    IdSituacaoFk = leitor.GetInt32("id_sit_fk")
                };

                lista.Add(produto);
            }

            leitor.Close();
            return lista;
        }

        // MÉTODO PARA BUSCAR PRODUTO POR ID
        public Produto? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand("SELECT * FROM produto WHERE id_prod = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            Produto? produto = null;

            if (leitor.Read())
            {
                produto = new Produto
                {
                    Id = leitor.GetInt32("id_prod"),
                    Nome = DAOHelper.GetString(leitor, "nome_prod"),
                    Preco = DAOHelper.GetDouble(leitor, "preco_prod"),
                    Validade = DAOHelper.GetDateTime(leitor, "validade_prod") ?? DateTime.MinValue,
                    Marca = DAOHelper.GetString(leitor, "marca_prod"),
                    Tipo = DAOHelper.GetString(leitor, "tipo_prod"),
                    Unidade = leitor.GetInt32("unidade_prod"),
                    EstoqueMinimo = leitor.GetInt32("estoque_minimo_prod"),
                    EstoqueMaximo = leitor.GetInt32("estoque_maximo_prod"),
                    IdFornecedorFk = leitor.GetInt32("id_for_fk"),
                    IdSituacaoFk = leitor.GetInt32("id_sit_fk")
                };
            }

            leitor.Close();
            return produto;
        }

        // MÉTODO PARA ATUALIZAR PRODUTO
        public void Atualizar(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    UPDATE produto 
                    SET nome_prod = @_nome,
                        preco_prod = @_preco,
                        validade_prod = @_validade,
                        marca_prod = @_marca,
                        tipo_prod = @_tipo,
                        unidade_prod = @_unidade,
                        estoque_minimo_prod = @_estoqueMinimo,
                        estoque_maximo_prod = @_estoqueMaximo,
                        id_for_fk = @_fornecedor,
                        id_sit_fk = @_situacao
                    WHERE id_prod = @_id;");

                comando.Parameters.AddWithValue("@_id", produto.Id);
                comando.Parameters.AddWithValue("@_nome", produto.Nome);
                comando.Parameters.AddWithValue("@_preco", produto.Preco);
                comando.Parameters.AddWithValue("@_validade", produto.Validade);
                comando.Parameters.AddWithValue("@_marca", produto.Marca);
                comando.Parameters.AddWithValue("@_tipo", produto.Tipo);
                comando.Parameters.AddWithValue("@_unidade", produto.Unidade);
                comando.Parameters.AddWithValue("@_estoqueMinimo", produto.EstoqueMinimo);
                comando.Parameters.AddWithValue("@_estoqueMaximo", produto.EstoqueMaximo);
                comando.Parameters.AddWithValue("@_fornecedor", produto.IdFornecedorFk);
                comando.Parameters.AddWithValue("@_situacao", produto.IdSituacaoFk);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar produto: " + ex.Message);
            }
        }

        // MÉTODO PARA EXCLUIR PRODUTO
        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE FROM produto WHERE id_prod = @id;");
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto: " + ex.Message);
            }
        }
    }
}
