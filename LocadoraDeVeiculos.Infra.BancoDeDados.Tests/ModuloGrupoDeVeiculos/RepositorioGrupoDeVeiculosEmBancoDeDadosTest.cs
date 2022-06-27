using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using FluentAssertions;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloGrupoDeVeiculos
{
    [TestClass]
    public class RepositorioGrupoDeVeiculosEmBancoDeDadosTest : IntegrationTestBase
    {
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorio;

        public RepositorioGrupoDeVeiculosEmBancoDeDadosTest()
        {
            repositorio = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        }

        private GrupoDeVeiculos NovoGrupo()
        {
            return new GrupoDeVeiculos("Econômico");
        }

        [TestMethod]
        public void Deve_inserir_grupo_de_veiculos()
        {
            //arrange
            var grupo = NovoGrupo();

            //action
            repositorio.Inserir(grupo);

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(grupo.Id);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_editar_grupo_de_veiculos()
        {
            //arrange
            var grupo = NovoGrupo();
            repositorio.Inserir(grupo);

            grupo.Nome = "Uber";

            //action
            repositorio.Editar(grupo);

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(grupo.Id);

            grupoEncontrado.Should().NotBeNull();
            grupoEncontrado.Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_excluir_grupo_de_veiculos()
        {
            //arrange           
            var grupo = NovoGrupo();
            repositorio.Inserir(grupo);

            //action           
            repositorio.Excluir(grupo);

            //assert
            repositorio.SelecionarPorId(grupo.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_grupo_de_veiculos()
        {
            //arrange          
            var grupo = NovoGrupo();
            repositorio.Inserir(grupo);

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
            repositorio.Inserir(g1);
            repositorio.Inserir(g2);

            //action
            var grupos = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, grupos.Count);

            Assert.AreEqual(g0.Nome, grupos[0].Nome);
            Assert.AreEqual(g1.Nome, grupos[1].Nome);
            Assert.AreEqual(g2.Nome, grupos[2].Nome);
        }
    }
}
