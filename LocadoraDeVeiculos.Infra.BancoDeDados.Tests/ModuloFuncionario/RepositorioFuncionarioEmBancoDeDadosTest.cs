using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloFuncionario
{
    [TestClass]
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

        [TestMethod]
        public void Deve_inserir_um_funcionario()
        {
            //arrange
            var funcionario = NovoFuncionario();

            //action
            repositorio.Inserir(funcionario);

            //assert
            var taxaEncontrada = repositorio.SelecionarPorId(funcionario.Id);

            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_editar_informacoes_funcionario()
        {
            //arrange
            var funcionario = NovoFuncionario();
            repositorio.Inserir(funcionario);

            funcionario.Nome = "Lucas";
            funcionario.Salario = 800;
            funcionario.DataAdmissao = DateTime.Now.Date;
            funcionario.Login = "lucasb";
            funcionario.Senha = "senha123";
            funcionario.TipoPerfil = "Administrador";

            //action
            repositorio.Editar(funcionario);

            //assert
            var taxaEncontrada = repositorio.SelecionarPorId(funcionario.Id);

            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange           
            var funcionario = NovoFuncionario();
            repositorio.Inserir(funcionario);

            //action           
            repositorio.Excluir(funcionario);

            //assert
            repositorio.SelecionarPorId(funcionario.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_funcionario()
        {
            //arrange          
            var funcionario = NovoFuncionario();
            repositorio.Inserir(funcionario);

            //action
            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.Id);

            //assert
            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todas_as_taxas()
        {
            //arrange
            var f0 = new Funcionario("Ane Luisy", 1000, DateTime.Now.Date, "anelg", "senha11313", "Comum");
            var f1 = new Funcionario("Lucas", 1040, DateTime.Now.Date, "lucasbleyer", "senha1999", "Comum");
            var f2 = new Funcionario("Daniel", 2000, DateTime.Now.Date, "danielz", "senha7788", "Administrador");

            var repositorio = new RepositorioFuncionarioEmBancoDeDados();
            repositorio.Inserir(f0);
            repositorio.Inserir(f1);
            repositorio.Inserir(f2);

            //action
            var funcionarios = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, funcionarios.Count);

            Assert.AreEqual(f0.Nome, funcionarios[0].Nome);
            Assert.AreEqual(f1.Nome, funcionarios[1].Nome);
            Assert.AreEqual(f2.Nome, funcionarios[2].Nome);
        }
    }
}
