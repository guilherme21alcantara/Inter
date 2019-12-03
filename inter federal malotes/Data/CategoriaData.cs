using System.Data.SqlClient;
using System.Collections.Generic;
using ECommerce.Models;

namespace ECommerce.Data
{
    /*
    public class CategoriaData : Data
    {
        public List<Categoria> Read()
        {
            List<Categoria> lista = new List<Categoria>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Categoria";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Categoria c = new Categoria();
                c.IdCategoria = (int)reader["IdCategoria"];
                c.Nome = (string)reader["Nome"];

                lista.Add(c);
            }

            return lista;
        }
    }
    */
}