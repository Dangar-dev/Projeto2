﻿using System.Data;
using Projeto2.Models;

namespace Projeto2.Repositorio
{
    public class ProdutoRepositorio
    {
        public readonly string _connectionString;

        public ProdutoRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AdicionarProduto(Produto produto)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "INSERT INTO Produto (Nome, Descricao, Preco) VALUES (@Nome, @Descricao, @Preco)";
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                cmd.ExecuteNonQuery();
            }
        }
    }
}