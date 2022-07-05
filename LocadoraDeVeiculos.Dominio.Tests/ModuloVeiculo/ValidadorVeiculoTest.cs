using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using FluentValidation.TestHelper;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloVeiculo
{
    [TestClass]
    public class ValidadorVeiculoTest
    {
        private readonly Veiculo veiculo;
        private readonly ValidadorVeiculo validador;

        public ValidadorVeiculoTest()
        {
            veiculo = new Veiculo()
            {
                Modelo = "Aventador",
                Fabricante = "Lamborghini",
                Ano = 2017,
                Cambio = "Automático",
                Cor = "Amarelo",
                Placa = "5678-ABCD",
                Kilometragem = 30,
                TipoDeCombustivel = "Gasolina",
                CapacidadeDoTanque = 100
            };

            validador = new ValidadorVeiculo();
        }
        #region Testes Modelo
        [TestMethod]
        public void Modelo_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Modelo = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Modelo);
        }

        [TestMethod]
        public void Modelo_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Modelo = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Modelo);
        }

        [TestMethod]
        public void Modelo_Deve_Ter_No_Minimo_2_Caracteres()
        {
            //arrange
            veiculo.Modelo = "a";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Modelo);
        }
        #endregion

        #region Testes Fabricante
        [TestMethod]
        public void Fabricante_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Fabricante = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Fabricante);
        }

        [TestMethod]
        public void Fabricante_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Fabricante = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Fabricante);
        }

        [TestMethod]
        public void Fabricante_Deve_Ter_No_Minimo_2_Caracteres()
        {
            //arrange
            veiculo.Fabricante = "a";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Fabricante);
        }
        #endregion


    }
}
