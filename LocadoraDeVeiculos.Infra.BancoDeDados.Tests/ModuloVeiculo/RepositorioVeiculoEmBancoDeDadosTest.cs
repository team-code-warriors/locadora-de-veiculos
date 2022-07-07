using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDeDadosTest : IntegrationTestBase
    {
        private RepositorioVeiculoEmBancoDeDados repositorio;
        private RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo;
        byte[] byteItems = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 };

        public RepositorioVeiculoEmBancoDeDadosTest()
        {
            repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
            repositorio = new RepositorioVeiculoEmBancoDeDados();
        }

        private GrupoDeVeiculos NovoGrupo()
        {
            GrupoDeVeiculos grupo = new GrupoDeVeiculos("SUV");
            repositorioGrupo.Inserir(grupo);

            return grupo;
        }

        private Veiculo NovoVeiculo()
        {
            return new Veiculo("Spider", "Ferrari", 2021, "Automático", "Vermelho", "333ABCD",
                0, "Gasolina", 10.00m, NovoGrupo(), byteItems);
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
            veiculo.Fabricante = "Ferrari";
            veiculo.Ano = 2012;
            veiculo.Cambio = "Manual";
            veiculo.Placa = "4445CCC";
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
            var v0 = new Veiculo("Roma", "Ferrari", 2015, "Automático", "Preto", "6789BCD", 0, "Gasolina", 100, NovoGrupo(), byteItems);
            var v1 = new Veiculo("SF90", "Ferrari", 2010, "Automático", "Amarelo", "1234BCD", 10, "Gasolina", 100, NovoGrupo(), byteItems);
            var v2 = new Veiculo("Focus", "Ford", 2000, "Manual", "Preto", "0000BCD", 80, "Gasolina", 100, NovoGrupo(), byteItems);

            var repositorio = new RepositorioVeiculoEmBancoDeDados();
            repositorio.Inserir(v0);
            repositorio.Inserir(v1);
            repositorio.Inserir(v2);

            //action
            var veiculos = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(v0.Placa, veiculos[0].Placa);
            Assert.AreEqual(v1.Placa, veiculos[1].Placa);
            Assert.AreEqual(v2.Placa, veiculos[2].Placa);
            Assert.AreEqual(3, veiculos.Count);
        }
    }
}
