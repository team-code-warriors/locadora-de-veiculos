using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", cliente.Id);
            comando.Parameters.AddWithValue("NOME", cliente.Nome);
            comando.Parameters.AddWithValue("EMAIL", cliente.Email);
            comando.Parameters.AddWithValue("CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("CNH", cliente.Cnh);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {
            int id = Convert.ToInt32(leitorCliente["ID"]);
            string nome = Convert.ToString(leitorCliente["NOME"]);
            string email = Convert.ToString(leitorCliente["EMAIL"]);
            string cpf = Convert.ToString(leitorCliente["CPF"]);
            string telefone = Convert.ToString(leitorCliente["TELEFONE"]);
            string cnh = Convert.ToString(leitorCliente["CNH"]);

            return new Cliente()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Cpf = cpf,
                Telefone = telefone,
                Cnh = cnh
            };
        }
    }
}
