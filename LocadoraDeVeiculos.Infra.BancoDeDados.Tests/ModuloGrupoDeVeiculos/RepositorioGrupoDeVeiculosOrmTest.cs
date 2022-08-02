using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using FluentAssertions;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloGrupoDeVeiculos
{
    [TestClass]
    public class RepositorioGrupoDeVeiculosOrmTest : IntegrationTestBase
    {
        private RepositorioGrupoDeVeiculoOrm repositorio;
        private LocadoraDeVeiculosDbContext dbContext;

        public RepositorioGrupoDeVeiculosOrmTest()
        {
            dbContext = new LocadoraDeVeiculosDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DbLocadoraDeVeiculosTestes;Integrated Security=True;Pooling=False");
            repositorio = new RepositorioGrupoDeVeiculoOrm(dbContext);
        }

        private GrupoDeVeiculos NovoGrupo()
        {
            return new GrupoDeVeiculos("Econômico");
        }

        [TestMethod]
        public void Deve_inserir_um_grupo()
        {
            //arrange
            var grupo = NovoGrupo();

            //action
            repositorio.Inserir(grupo);
            dbContext.SaveChanges();

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(grupo.Id);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupo);
        }
        [TestMethod]
        public void Deve_editar_informacoes_grupo()
        {
            //arrange
            var grupo = NovoGrupo();
            repositorio.Inserir(grupo);
            dbContext.SaveChanges();

            //action 
            grupo.Nome = "Esportivo";
            repositorio.Editar(grupo);
            dbContext.SaveChanges();

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(grupo.Id);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupo);
        }


        [TestMethod]
        public void Deve_excluir_grupo()
        {
            //arrange
            var grupo = NovoGrupo();
            repositorio.Inserir(grupo);
            dbContext.SaveChanges();

            //action           
            repositorio.Excluir(grupo);
            dbContext.SaveChanges();

            //assert
            repositorio.SelecionarPorId(grupo.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_grupo()
        {
            //arrange
            var grupo = NovoGrupo();
            repositorio.Inserir(grupo);
            dbContext.SaveChanges();

            //action
            var grupoEncontrado = repositorio.SelecionarPorId(grupo.Id);

            //assert
            Assert.IsNotNull(grupoEncontrado);
            Assert.AreEqual(grupo, grupoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_grupos_de_veiculos()
        {
            //arrange
            var g0 = new GrupoDeVeiculos("Uber");
            var g1 = new GrupoDeVeiculos("SUV");
            var g2 = new GrupoDeVeiculos("Esportivo");

            var repositorio = new RepositorioGrupoDeVeiculosEmBancoDeDados();
            repositorio.Inserir(g0);
            dbContext.SaveChanges();
            repositorio.Inserir(g1);
            dbContext.SaveChanges();
            repositorio.Inserir(g2);
            dbContext.SaveChanges();

            //action
            var grupos = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, grupos.Count);

            Assert.AreEqual(g0.Nome, grupos[0].Nome);
            Assert.AreEqual(g1.Nome, grupos[1].Nome);
            Assert.AreEqual(g2.Nome, grupos[2].Nome);
            Assert.AreEqual(3, grupos.Count);
        }
    }
}