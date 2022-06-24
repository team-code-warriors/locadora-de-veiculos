using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDeDadosTest : IntegrationTestBase
    {
        private RepositorioFuncionarioEmBancoDeDados repositorio;

        public RepositorioFuncionarioEmBancoDeDadosTest()
        {
            repositorio = new RepositorioFuncionarioEmBancoDeDados();
        }

        private Funcionario NovoFuncionario()
        {
            return new Funcionario("Ane Luisy", 1000, DateTime.Now.Date, "ane.lg", "123abc", "Comum");
        }
    }
}
