using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario funcionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", funcionario.Id);
            comando.Parameters.AddWithValue("NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("SALARIO", funcionario.Salario);
            comando.Parameters.AddWithValue("DATAADMISSAO", funcionario.DataAdmissao);
            comando.Parameters.AddWithValue("LOGIN", funcionario.Login);
            comando.Parameters.AddWithValue("SENHA", funcionario.Senha);
            comando.Parameters.AddWithValue("TIPOPERFIL", funcionario.TipoPerfil);
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            int id = Convert.ToInt32(leitorFuncionario["ID"]);
            string nome = Convert.ToString(leitorFuncionario["NOME"]);
            double salario = Convert.ToDouble(leitorFuncionario["SALARIO"]);
            DateTime dataAdmissao = Convert.ToDateTime(leitorFuncionario["DATAADMISSAO"]);
            string login = Convert.ToString(leitorFuncionario["LOGIN"]);
            string senha = Convert.ToString(leitorFuncionario["SENHA"]);
            string tipoPerfil = Convert.ToString(leitorFuncionario["TIPOPERFIL"]);

            return new Funcionario()
            {
                Id = id,
                Nome = nome,
                Salario = salario,
                DataAdmissao = dataAdmissao,
                Login = login,
                Senha = senha,
                TipoPerfil = tipoPerfil
            };
        }
    }
}
