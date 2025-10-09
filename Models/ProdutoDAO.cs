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

        // Método para Inserir Produtos 
        public void Inserir(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                INSERT INTO produto
                (nome_prod, preco_prod, validade_prod, marca_prod, tipo_prod, unidade_prod, 
                estoque_minimo_prod, estoque_maximo_prod,id_for_fk, id_cat_fk, id_sit_fk)
                VALUES
                (@_nome, @_preco, @_validade, @_marca, @_tipo, @_unidade, @_estoqueMinimo, 
                @_estoqueMaximo, @_fornecedor, @_categoria, @_situacao)");

                comando.Parameters.AddWithValue("@_nome", produto.Nome);
                comando.Parameters.AddWithValue("@_preco", produto.Preco);
                comando.Parameters.AddWithValue("@_validade", produto.Validade);
                comando.Parameters.AddWithValue("@_marca", produto.Marca);
                comando.Parameters.AddWithValue("@_tipo", produto.Tipo);
                comando.Parameters.AddWithValue("@_unidade", produto.Unidade);
                comando.Parameters.AddWithValue("@_estoqueMinimo", produto.EstoqueMinimo);
                comando.Parameters.AddWithValue("@_estoqueMaximo", produto.EstoqueMaximo);
                comando.Parameters.AddWithValue("@_fornecedor", produto.IdFornecedor);
                comando.Parameters.AddWithValue("@_categoria", produto.IdCategoria);
                comando.Parameters.AddWithValue("@_situacao", produto.IdSituacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir produto: " + ex.Message);
            }
        }

        // Método para Listar todos os Produtos
        public List<Produto> ListarTodos()
        {
            var lista = new List<Produto>();

            var comando = _conexao.CreateCommand("SELECT * FROM produto");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var produto = new Produto
                {
                    Id = leitor.GetInt32("id_prod"),
                    Nome = leitor.GetString("nome_prod"),
                    Preco = leitor.GetDouble("preco_prod"),
                    Validade = leitor.GetDateTime("validade_prod"),
                    Marca = leitor.GetString("marca_prod"),
                    Tipo = leitor.GetString("tipo_prod"),
                    Unidade = leitor.GetInt32("unidade_prod"),
                    EstoqueMinimo = leitor.GetInt32("estoque_minimo_prod"),
                    EstoqueMaximo = leitor.GetInt32("estoque_maximo_prod"),
                    IdFornecedor = leitor.GetInt32("id_for_fk"),
                    IdCategoria = leitor.GetInt32("id_cat_fk"),
                    IdSituacao = leitor.GetInt32("id_sit_fk")
                };

                lista.Add(produto);
            }

            leitor.Close();
            return lista;
            
        }
    }
}