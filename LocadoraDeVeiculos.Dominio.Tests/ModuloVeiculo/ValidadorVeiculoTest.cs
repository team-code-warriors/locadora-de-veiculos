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
                GrupoDeVeiculos = new()
                {
                    Nome = "SUV",
                },

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

        [TestMethod]
        public void Cambio_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Cambio = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cambio);
        }

        [TestMethod]
        public void Cambio_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Cambio = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cambio);
        }

        [TestMethod]
        public void Cor_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Cor = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cor);
        }

        [TestMethod]
        public void Cor_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Cor = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cor);
        }

        [TestMethod]
        public void Cor_Deve_Ter_No_Minimo_2_Caracteres()
        {
            //arrange
            veiculo.Cor = "a";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cor);
        }

        [TestMethod]
        public void Placa_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.Placa = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Placa);
        }

        [TestMethod]
        public void Placa_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.Placa = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Placa);
        }

        [TestMethod]
        public void Placa_Deve_Ter_7_Caracteres()
        {
            //arrange
            veiculo.Placa = "a";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.Placa);
        }

        [TestMethod]
        public void TipoCombustivel_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.TipoDeCombustivel = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.TipoDeCombustivel);
        }

        [TestMethod]
        public void TipoCombustivel_Nao_Pode_Ser_Vazio()
        {
            //arrange
            veiculo.TipoDeCombustivel = "";

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.TipoDeCombustivel);
        }

        [TestMethod]
        public void CapacidadeTanque_Deve_Ser_Maior_Que_0()
        {
            //arrange
            veiculo.CapacidadeDoTanque = 0;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.CapacidadeDoTanque);
        }

        [TestMethod]
        public void GrupoVeiculos_Nao_Pode_Ser_Nulo()
        {
            //arrange
            veiculo.GrupoDeVeiculos = null;

            //action
            var resultado = validador.TestValidate(veiculo);

            //assert
            resultado.ShouldHaveValidationErrorFor(v => v.GrupoDeVeiculos);
        }

    }
}
