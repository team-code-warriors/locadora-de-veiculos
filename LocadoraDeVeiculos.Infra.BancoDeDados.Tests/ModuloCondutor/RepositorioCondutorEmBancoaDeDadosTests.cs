using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDeDadosTests : IntegrationTestBase
    {
        private RepositorioClienteEmBancoDeDados repositorioCliente;
        private RepositorioCondutorEmBancoDeDados repositorio;

        public RepositorioCondutorEmBancoDeDadosTests()
        {
            repositorioCliente = new RepositorioClienteEmBancoDeDados();
            repositorio = new RepositorioCondutorEmBancoDeDados();
        }

        private Cliente NovoCliente()
        {
            Cliente c = new Cliente("Lucas Bleyer", "lucas@gmail.com", "Lages", "111.222.333-44", "43.367.658/0001-49", "(11) 99999-9999");
            repositorioCliente.Inserir(c);

            return c;
        }

        private Condutor NovoCondutor()
        {
            return new Condutor(NovoCliente(), "Lucas Bleyer", "111.222.333-44", "12345678901", DateTime.Now.Date, "lucas@gmail.com", "(11) 99999-9999", "Lages");
        }


        [TestMethod]
        public void Deve_inserir_novo_condutor()
        {
            //arrange
            var condutor = NovoCondutor();

            //action
            repositorio.Inserir(condutor);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(condutor.Id);

            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_editar_informacoes_do_condutor()
        {
            //arrange
            var condutor = NovoCondutor();
            repositorio.Inserir(condutor);
            condutor.Nome = "Lucas Bleyer";
            condutor.Email = "lucas@gmail.com";
            condutor.Endereco = "Lages";
            condutor.Cpf = "111.999.333-44";
            condutor.Cnh = "12345678901";
            condutor.Telefone = "(52) 23456-1234";

            //action
            repositorio.Editar(condutor);

            //assert
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //arrange           
            var condutor = NovoCondutor();
            repositorio.Inserir(condutor);

            //action           
            repositorio.Excluir(condutor);

            //assert
            repositorio.SelecionarPorId(condutor.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_condutor()
        {
            //arrange          
            var condutor = NovoCondutor();
            repositorio.Inserir(condutor);

            //action
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            //assert
            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(condutor, condutorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_condutores()
        {
            //arrange
            var c0 = new Condutor(NovoCliente(), "Lucas Bleyer", "111.222.333-44", "12345678901", DateTime.Now.Date, "lucas@gmail.com", "(11) 99999-9999", "Lages");
            var c1 = new Condutor(NovoCliente(), "Ane Grizotti", "111.222.333-44", "12345678901", DateTime.Now.Date, "ane@gmail.com", "(11) 99999-9999", "Lages");
            var c2 = new Condutor(NovoCliente(), "Daniel Zanoni", "111.222.333-44", "12345678901", DateTime.Now.Date, "daniel@gmail.com", "(11) 99999-9999", "Lages");

            var repositorio = new RepositorioCondutorEmBancoDeDados();
            repositorio.Inserir(c0);
            repositorio.Inserir(c1);
            repositorio.Inserir(c2);

            //action
            var condutores = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, condutores.Count);

            Assert.AreEqual(c0.Nome, condutores[0].Nome);
            Assert.AreEqual(c1.Nome, condutores[1].Nome);
            Assert.AreEqual(c2.Nome, condutores[2].Nome);
        }
    }
}