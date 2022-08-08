using FluentAssertions;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using LocadoraDeVeiculos.Infra.Configs;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteOrmTests : IntegrationTestBase
    {
        private RepositorioClienteOrm repositorio;
        private LocadoraDeVeiculosDbContext dbContext;

        public RepositorioClienteOrmTests(IContextoPersistencia contextoPersistencia)
        {
            this.dbContext = (LocadoraDeVeiculosDbContext)contextoPersistencia;
            repositorio = new RepositorioClienteOrm(dbContext);
        }

        private Cliente NovoCliente()
        {
            return new Cliente("Lucas Bleyer", "lucas@gmail.com", "Lages", "111.222.333-44", "43.367.658/0001-49", "(11) 99999-9999");
        }

        [TestMethod]
        public void Deve_inserir_novo_cliente()
        {
            //arrange
            var cliente = NovoCliente();

            //action
            repositorio.Inserir(cliente);
            dbContext.SaveChanges();

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
            dbContext.SaveChanges();
            cliente.Nome = "Lucas Silva";
            cliente.Email = "lucassilva@gmail.com";
            cliente.Endereco = "Lages";
            cliente.Cpf = "111.999.333-44";
            cliente.Cnpj = "43.367.658/0001-49";
            cliente.Telefone = "(99) 99999-9999";

            //action
            repositorio.Editar(cliente);
            dbContext.SaveChanges();

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
            dbContext.SaveChanges();

            //action           
            repositorio.Excluir(cliente);
            dbContext.SaveChanges();

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
            dbContext.SaveChanges();

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
            var c0 = new Cliente("Lucas", "lucas@gmail.com", "Lages", "111.222.333-44", "33.367.658/3333-33", "(11) 99999-9999");
            var c1 = new Cliente("Ane", "ane@gmail.com", "Lages", "555.666.777-88", "43.367.658/0001-49", "(22) 99999-9999");
            var c2 = new Cliente("Daniel", "daniel@gmail.com", "Lages", "999.888.777-66", "43.367.658/0001-49", "(33) 99999-9999");

            var repositorio = new RepositorioClienteEmBancoDeDados();
            repositorio.Inserir(c0);
            dbContext.SaveChanges();
            repositorio.Inserir(c1);
            dbContext.SaveChanges();
            repositorio.Inserir(c2);
            dbContext.SaveChanges();

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