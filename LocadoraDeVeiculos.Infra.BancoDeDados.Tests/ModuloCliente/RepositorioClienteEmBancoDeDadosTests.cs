using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDeDadosTests
    {
        private Cliente cliente;
        private RepositorioClienteEmBancoDeDados repositorio;

        public RepositorioClienteEmBancoDeDadosTests()
        {
            Db.ExecutarSql("DELETE FROM [TBCLIENT]; DBCC CHECKIDENT (TBCLIENT, RESEED, 0)");
            cliente = new Cliente("Lucas", "lucas@gmail.com", "111.222.333-44", "999999999", "12988754461");
            repositorio = new RepositorioClienteEmBancoDeDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_clietne()
        {
            //action
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
            cliente.Should().Be(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_do_Clienter()
        {
            //arrange                      
            repositorio.Inserir(cliente);

            //action
            cliente.Nome = "Lucas Bleyer";
            cliente.Email = "lucas@gmail.com";
            cliente.Cpf = "111.222.333-44";
            cliente.Telefone = "999999999";
            cliente.Cnh = "123456789101";

            repositorio.Editar(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
            cliente.Should().Be(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange           
            repositorio.Inserir(cliente);

            //action           
            repositorio.Excluir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_cliente()
        {
            //arrange          
            repositorio.Inserir(cliente);

            //action
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
            cliente.Should().Be(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_clientes()
        {
            //arrange
            var cliente1 = new Cliente("Lucas", "lucas@gmail.com", "111.222.333-44", "999999999", "12988754461");
            var cliente2 = new Cliente("Ane", "ane@gmail.com", "555.666.777-88", "999999999", "12988754461");
            var cliente3 = new Cliente("Daniel", "daniel@gmail.com", "999.888.777-66", "999999999", "12988754461");

            repositorio.Inserir(cliente1);
            repositorio.Inserir(cliente2);
            repositorio.Inserir(cliente3);

            //action
            var clientes = repositorio.SelecionarTodos();

            //assert
            clientes.Count.Should().Be(3);

            clientes[0].Should().Be(cliente1);
            clientes[1].Should().Be(cliente2);
            clientes[2].Should().Be(cliente3);

        }
    }
}
