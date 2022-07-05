using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        RepositorioClienteEmBancoDeDados repositorioCliente = new RepositorioClienteEmBancoDeDados();

        public override void ConfigurarParametros(Condutor registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("CLIENTE_ID", registro.Cliente.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF", registro.Cpf);
            comando.Parameters.AddWithValue("CNH", registro.Cnh);
            comando.Parameters.AddWithValue("DATAVALIDADECNH", registro.DataValidadeCnh);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["ID"]);
            int idCliente = Convert.ToInt32(leitorRegistro["CLIENTE_ID"]);
            string nome = Convert.ToString(leitorRegistro["NOME"]);
            string cpf = Convert.ToString(leitorRegistro["CPF"]);
            string cnh = Convert.ToString(leitorRegistro["CNH"]);
            DateTime dataValidadeCnh = Convert.ToDateTime(leitorRegistro["DATAVALIDADECNH"]);
            string email = Convert.ToString(leitorRegistro["EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["TELEFONE"]);
            string endereco = Convert.ToString(leitorRegistro["ENDERECO"]);

            var condutor = new Condutor
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Cnh = cnh,
                DataValidadeCnh = dataValidadeCnh,
                Email = email,
                Telefone = telefone,
                Endereco = endereco,
                Cliente = repositorioCliente.SelecionarPorId(idCliente)
            };
            
            return condutor;
        }
    }
}