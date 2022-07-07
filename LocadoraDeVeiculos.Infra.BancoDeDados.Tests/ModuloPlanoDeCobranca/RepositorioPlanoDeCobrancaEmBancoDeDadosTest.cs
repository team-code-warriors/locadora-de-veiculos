using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaEmBancoDeDadosTest : IntegrationTestBase
    {
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo;
        private RepositorioPlanoDeCobrancaEmBancoDeDados repositorio;

        public RepositorioPlanoDeCobrancaEmBancoDeDadosTest()
        {
            repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
            repositorio = new RepositorioPlanoDeCobrancaEmBancoDeDados();

        }

        private GrupoDeVeiculos NovoGrupo()
        {
            GrupoDeVeiculos grupo = new GrupoDeVeiculos("SUV");
            repositorioGrupo.Inserir(grupo);

            return grupo;
        }

        private PlanoDeCobranca NovoPlano()
        {
            return new PlanoDeCobranca(NovoGrupo(), "Plano Diário", 100, 0, 10);
        }

        [TestMethod]
        public void Deve_inserir_um_plano()
        {
            //arrange
            var plano = NovoPlano();
            repositorio.Inserir(plano);

            //action
            var planoEncontrado = repositorio.SelecionarPorId(plano.Id);

            //assert
            planoEncontrado.Should().NotBeNull();
            planoEncontrado.Should().Be(plano);
        }

        [TestMethod]
        public void Deve_editar_informacoes_plano()
        {
            //arrange
            var plano = NovoPlano();
            repositorio.Inserir(plano);

            //action 
            plano.TipoPlano = "KM Livre";
            plano.ValorDiaria = 1000;
            plano.KmIncluso = 0;
            plano.PrecoKm = 10;

            repositorio.Editar(plano);

            //assert
            var planoEncontrado = repositorio.SelecionarPorId(plano.Id);

            planoEncontrado.Should().NotBeNull();
            planoEncontrado.Should().Be(plano);
        }

        [TestMethod]
        public void Deve_excluir_plano()
        {
            //arrange
            var plano = NovoPlano();
            repositorio.Inserir(plano);

            //action           
            repositorio.Excluir(plano);

            //assert
            repositorio.SelecionarPorId(plano.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_plano()
        {
            //arrange
            var plano = NovoPlano();
            repositorio.Inserir(plano);

            //action
            var planoEncontrado = repositorio.SelecionarPorId(plano.Id);

            //assert
            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(plano, planoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_planos()
        {
            //arrange
            var p0 = new PlanoDeCobranca(NovoGrupo(), "KM Livre", 1090, 10, 10);
            var p1 = new PlanoDeCobranca(NovoGrupo(), "KM Controlado", 100, 150, 10);
            var p2 = new PlanoDeCobranca(NovoGrupo(), "Plano Diário", 50, 10, 10);

            repositorio.Inserir(p0);
            repositorio.Inserir(p1);
            repositorio.Inserir(p2);

            //action
            var planos = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(p0.TipoPlano, planos[0].TipoPlano);
            Assert.AreEqual(p1.TipoPlano, planos[1].TipoPlano);
            Assert.AreEqual(p2.TipoPlano, planos[2].TipoPlano);
            Assert.AreEqual(3, planos.Count);
        }
    }
}
