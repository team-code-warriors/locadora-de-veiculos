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
            var id = Guid.Parse(leitorRegistro["CONDUTOR_ID"].ToString());
            string nome = Convert.ToString(leitorRegistro["CONDUTOR_NOME"]);
            string cpf = Convert.ToString(leitorRegistro["CONDUTOR_CPF"]);
            string cnh = Convert.ToString(leitorRegistro["CONDUTOR_CNH"]);
            DateTime dataValidadeCnh = Convert.ToDateTime(leitorRegistro["CONDUTOR_DATAVALIDADECNH"]);
            string email = Convert.ToString(leitorRegistro["CONDUTOR_EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["CONDUTOR_TELEFONE"]);
            string endereco = Convert.ToString(leitorRegistro["CONDUTOR_ENDERECO"]);

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
            };

            var cliente = new MapeadorCliente().ConverterRegistro(leitorRegistro);
            condutor.Cliente = cliente;

            return condutor;
        }
    }
}