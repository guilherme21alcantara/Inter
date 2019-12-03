using System.Data.SqlClient;
using ECommerce.Models;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public class ProdutoData : Data
    {
        // métodos para manipular a tabela Produto do banco de dados:
        public List<Produto> Read()
        {
            List<Produto> lista = new List<Produto>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = "SELECT * FROM v_produto";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Produto p = new Produto();
                p.IdProduto = (int)reader["IdProduto"];
                p.Descricao = (string)reader["Descricao"];
                p.Categoria = (string)reader["Categoria"];
                p.Valor = (decimal)reader["Valor"];                

                lista.Add(p);
            }

            return lista;
        }

        public void Create(Produto e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Produto
                                VALUES(@desc, @categoria, @valor)";

            cmd.Parameters.AddWithValue("@desc", e.Descricao);
            cmd.Parameters.AddWithValue("@categoria", e.Categoria);
            cmd.Parameters.AddWithValue("@valor", e.Valor);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Produto WHERE IdProduto=@id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public Produto Read(int id)
        {
            Produto p = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Produto
                                WHERE IdProduto = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                p = new Produto{
                    IdProduto = (int)reader["IdProduto"],
                    Descricao = (string)reader["Descricao"],
                    Categoria = (string)reader["Categoria"],
                    Valor = (decimal)reader["Valor"]
                };
            }

            return p;
        }

        public void Update(Produto e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Produto 
                                SET Descricao = @desc,
                                    Categoria = @categoria, 
                                    Valor = @valor
                                WHERE IdProduto = @id";

            cmd.Parameters.AddWithValue("@desc", e.Descricao);
            cmd.Parameters.AddWithValue("@categoria", e.Categoria);
            cmd.Parameters.AddWithValue("@valor", e.Valor);

            cmd.ExecuteNonQuery();
        }
    }
}