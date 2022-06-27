using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDeDadosTests : IntegrationTestBase
    {
        private RepositorioClienteEmBancoDeDados repositorio;

        public RepositorioClienteEmBancoDeDadosTests()
        {
            repositorio = new RepositorioClienteEmBancoDeDados();
        }

        private Cliente NovoCliente()
        {
            return new Cliente("Lucas Bleyer", "lucas@gmail.com", "Lages", "111.222.333-44", "11999999999", "123456789101");
        }

        [TestMethod]
        public void Deve_inserir_novo_cliente()
        {
            //arrange
            var cliente = NovoCliente();

            //action
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_editar_informacoes_do_Clienter()
        {
            //arrange
            var cliente = NovoCliente();
            repositorio.Inserir(cliente);
            cliente.Nome = "Lucas Silva";
            cliente.Email = "lucassilva@gmail.com";
            cliente.Endereco = "Lages";
            cliente.Cpf = "111.999.333-44";
            cliente.Telefone = "88999999999";
            cliente.Cnh = "123456789199";

            //action
            repositorio.Editar(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange           
            var cliente = NovoCliente();
            repositorio.Inserir(cliente);

            //action           
            repositorio.Excluir(cliente);

            //assert
            repositorio.SelecionarPorId(cliente.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_cliente()
        {
            //arrange          
            var cliente = NovoCliente();
            repositorio.Inserir(cliente);

            //action
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            //assert
            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_clientes()
        {
            //arrange
            var c0 = new Cliente("Lucas", "lucas@gmail.com", "Lages", "111.222.333-44", "88999999999", "12988754461");
            var c1 = new Cliente("Ane", "ane@gmail.com", "Lages", "555.666.777-88", "55999999999", "12988754461");
            var c2 = new Cliente("Daniel", "daniel@gmail.com", "Lages", "999.888.777-66", "66999999999", "12988754461");

            var repositorio = new RepositorioClienteEmBancoDeDados();
            repositorio.Inserir(c0);
            repositorio.Inserir(c1);
            repositorio.Inserir(c2);

            //action
            var clientes = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, clientes.Count);

            Assert.AreEqual(c0.Nome, clientes[0].Nome);
            Assert.AreEqual(c1.Nome, clientes[1].Nome);
            Assert.AreEqual(c2.Nome, clientes[2].Nome);

        }
    }
}
