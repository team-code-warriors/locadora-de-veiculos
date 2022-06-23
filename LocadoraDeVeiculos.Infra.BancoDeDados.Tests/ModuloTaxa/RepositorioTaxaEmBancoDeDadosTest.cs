using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaEmBancoDeDadosTest : IntegrationTestBase
    {

        private RepositorioTaxaEmBancoDeDados repositorio;

        public RepositorioTaxaEmBancoDeDadosTest()
        {
            repositorio = new RepositorioTaxaEmBancoDeDados();
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

            taxa.Descricao = "GPS";
            taxa.Valor = 100;
            taxa.TipoCalculo = "Diário";

            //action
            repositorio.Editar(taxa);

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

            //action           
            repositorio.Excluir(taxa);

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
            repositorio.Inserir(t1);
            repositorio.Inserir(t2);

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
