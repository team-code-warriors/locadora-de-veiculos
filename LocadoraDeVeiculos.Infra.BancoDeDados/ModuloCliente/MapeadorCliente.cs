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
            comando.Parameters.AddWithValue("ENDERECO", cliente.Endereco);
            comando.Parameters.AddWithValue("CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("CNPJ", cliente.Cnpj);
            comando.Parameters.AddWithValue("TELEFONE", cliente.Telefone);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {
            var id = Guid.Parse(leitorCliente["CLIENTE_ID"].ToString());
            string nome = Convert.ToString(leitorCliente["CLIENTE_NOME"]);
            string email = Convert.ToString(leitorCliente["CLIENTE_EMAIL"]);
            string endereco = Convert.ToString(leitorCliente["CLIENTE_ENDERECO"]);
            string cpf = Convert.ToString(leitorCliente["CLIENTE_CPF"]);
            string cnpj = Convert.ToString(leitorCliente["CLIENTE_CNPJ"]);
            string telefone = Convert.ToString(leitorCliente["CLIENTE_TELEFONE"]);

            return new Cliente()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Endereco = endereco,
                Cpf = cpf,
                Cnpj = cnpj,
                Telefone = telefone,
            };
        }
    }
}
