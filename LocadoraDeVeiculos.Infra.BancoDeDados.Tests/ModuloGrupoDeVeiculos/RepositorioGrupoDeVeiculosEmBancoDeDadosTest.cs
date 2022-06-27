using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloGrupoDeVeiculos
{
    [TestClass]
    public class RepositorioGrupoDeVeiculosEmBancoDeDadosTest
    {
        private GrupoDeVeiculos grupo;
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorio;

        public RepositorioGrupoDeVeiculosEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBGRUPODEVEICULOS; DBCC CHECKIDENT (TBGRUPODEVEICULOS, RESSED, 0)");

            grupo = new GrupoDeVeiculos();
            grupo.Nome = "Econômicos";

            repositorio = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        }

        [TestMethod]
        public void Deve_inserir_grupo_de_veiculos()
        {
            repositorio.Inserir(grupo);

            var grupoEncontrado = repositorio.SelecionarPorId(grupo.Id);

            Assert.IsNotNull(grupoEncontrado);
            Assert.AreEqual(grupo, grupoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_grupo_de_veiculos()
        {
            //arrange
            repositorio.Inserir(grupo);

            //action
            grupo.Nome = "Uber";

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(grupo.Id);

            Assert.IsNotNull(grupoEncontrado);
            Assert.AreEqual(grupo, grupoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_grupo_de_veiculos()
        {
            //arrange           
            repositorio.Inserir(grupo);

            //action           
            repositorio.Excluir(grupo);

            //assert
            var grupoEncontrado = repositorio.SelecionarPorId(grupo.Id);
            Assert.IsNull(grupoEncontrado);
        }
    }
}
