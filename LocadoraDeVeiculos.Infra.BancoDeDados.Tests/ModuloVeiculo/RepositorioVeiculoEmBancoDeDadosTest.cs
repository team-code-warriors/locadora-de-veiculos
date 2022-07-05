using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDeDadosTest : IntegrationTestBase
    {
        private RepositorioVeiculoEmBancoDeDados repositorio;
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo;

        public RepositorioVeiculoEmBancoDeDadosTest()
        {
            repositorio = new RepositorioVeiculoEmBancoDeDados();
        }

        private Veiculo NovoVeiculo()
        {
            return new Veiculo("Spider", "Ferrari", "2021", "Automático", "Vermelho", "333-BCD",
                0, "Gasolina", 100, repositorioGrupo.SelecionarPorId(0));
        }

        [TestMethod]
        public void Deve_inserir_um_veiculo()
        {
            //arrange
            var veiculo = NovoVeiculo();

            //action
            repositorio.Inserir(veiculo);

            //assert
            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_editar_informacoes_veiculo()
        {
            //arrange
            var veiculo = NovoVeiculo();
            repositorio.Inserir(veiculo);

            //action
            veiculo.Modelo = "Ferrari Italia 458";
            veiculo.GrupoDeVeiculos = repositorioGrupo.SelecionarPorId(1);
            veiculo.Fabricante = "Ferrari";
            veiculo.Ano = "2012";
            veiculo.Cambio = "Manual";
            veiculo.Placa = "4445-CCC";
            veiculo.Kilometragem = 31000;
            veiculo.TipoDeCombustivel = "Gasolina";
            veiculo.CapacidadeDoTanque = 95;
            repositorio.Editar(veiculo);

            //assert
            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_excluir_grupo()
        {
            //arrange
            var veiculo = NovoVeiculo();
            repositorio.Inserir(veiculo);

            //action
            repositorio.Excluir(veiculo);

            //assert
            repositorio.SelecionarPorId(veiculo.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_veiculo()
        {
            //arrange
            var veiculo = NovoVeiculo();
            repositorio.Inserir(veiculo);

            //action
            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            //assert
            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo, veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_veiculos()
        {
            //arrange
            var v0 = new Veiculo("Roma", "Ferrari", "2015", "Automático", "Preto", "1234-BCD",
                0, "Gasolina", 100, repositorioGrupo.SelecionarPorId(0));
            var v1 = new Veiculo("SF90", "Ferrari", "2010", "Automático", "Amarelo", "1234-BCD",
                0, "Gasolina", 100, repositorioGrupo.SelecionarPorId(0));

            var repositorio = new RepositorioVeiculoEmBancoDeDados();
            repositorio.Inserir(v0);
            repositorio.Inserir(v1);

            //action
            var veiculos = repositorio.SelecionarTodos();
            var grupos = repositorioGrupo.SelecionarTodos();

            //assert
            Assert.AreEqual(2, veiculos.Count);

            Assert.AreEqual(v0.Modelo, v0.Fabricante, v0.Ano, v0.Cambio, v0.Cor, v0.Placa,
                v0.TipoDeCombustivel, v0.CapacidadeDoTanque, grupos[0].Nome);
            Assert.AreEqual(v1.Modelo, v1.Fabricante, v1.Ano, v1.Cambio, v1.Cor, v1.Placa,
                v1.TipoDeCombustivel, v1.CapacidadeDoTanque, grupos[1].Nome);
            Assert.AreEqual(2, veiculos.Count);
        }
    }
}
