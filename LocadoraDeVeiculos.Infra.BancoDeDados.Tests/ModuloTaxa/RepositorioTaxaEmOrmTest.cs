using FluentAssertions;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using LocadoraDeVeiculos.Infra.Configs;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaEmOrmTest : IntegrationTestBase
    {

        private RepositorioTaxaOrm repositorio;
        private LocadoraDeVeiculosDbContext dbContext;

        public RepositorioTaxaEmOrmTest()
        {
            ConnectionStrings connectionString = new ConnectionStrings();
            connectionString.SqlServer = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DbLocadoraDeVeiculosTestes;Integrated Security=True;Pooling=False";
            dbContext = new LocadoraDeVeiculosDbContext(connectionString);
            repositorio = new RepositorioTaxaOrm(dbContext);
        }

        private Taxa NovaTaxa()
        {
            return new Taxa("Cadeira de bebê", 25, "Fixo");
        }

        [TestMethod]
        public void Deve_inserir_uma_taxa()
        {
            //arrange
            var taxa = NovaTaxa();

            //action
            repositorio.Inserir(taxa);
            dbContext.SaveChanges();

            //assert
            var taxaEncontrada = repositorio.SelecionarPorId(taxa.Id);

            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_editar_informacoes_taxa()
        {
            //arrange
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);
            dbContext.SaveChanges();

            taxa.Descricao = "GPS";
            taxa.Valor = 100;
            taxa.TipoCalculo = "Diário";

            //action
            repositorio.Editar(taxa);
            dbContext.SaveChanges();

            //assert
            var taxaEncontrada = repositorio.SelecionarPorId(taxa.Id);

            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_excluir_taxa()
        {
            //arrange           
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);
            dbContext.SaveChanges();

            //action           
            repositorio.Excluir(taxa);
            dbContext.SaveChanges();

            //assert
            repositorio.SelecionarPorId(taxa.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_uma_taxa()
        {
            //arrange          
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);
            dbContext.SaveChanges();

            //action
            var taxaEncontrada = repositorio.SelecionarPorId(taxa.Id);

            //assert
            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_todas_as_taxas()
        {
            //arrange
            var t0 = new Taxa("taxa 1", 10, "Fixo");
            var t1 = new Taxa("taxa 2", 20, "Fixo");
            var t2 = new Taxa("taxa 3", 30, "Diário");

            var repositorio = new RepositorioTaxaEmBancoDeDados();
            repositorio.Inserir(t0);
            dbContext.SaveChanges();
            repositorio.Inserir(t1);
            dbContext.SaveChanges();
            repositorio.Inserir(t2);
            dbContext.SaveChanges();

            //action
            var taxas = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, taxas.Count);

            Assert.AreEqual(t0.Descricao, taxas[0].Descricao);
            Assert.AreEqual(t1.Descricao, taxas[1].Descricao);
            Assert.AreEqual(t2.Descricao, taxas[2].Descricao);
        }
    }
}
