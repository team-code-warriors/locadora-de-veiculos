using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado
{
    public static class Db
    {
        public static string enderecoBanco =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog=DbLocadoraDeVeiculos;
                Integrated Security=True;
                Pooling=False";

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}
