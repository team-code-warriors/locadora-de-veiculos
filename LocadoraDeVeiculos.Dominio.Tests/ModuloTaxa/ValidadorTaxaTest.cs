using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloTaxa
{
    [TestClass]
    public class ValidadorTaxaTest 
    {
        private readonly Taxa taxa;
        private readonly ValidadorTaxa validador;
        public ValidadorTaxaTest()
        {
            taxa = new()
            {
                Descricao = "Cadeira de bebê",
                Valor = 45.5,
                TipoCalculo = "Fixo"
            };

            validador = new ValidadorTaxa();
        }
        [TestMethod]
        public void Descricao_Nao_Pode_Ser_Nulo()
        {
            // arrange
            taxa.Descricao = null;

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Descricao);
        }

        [TestMethod]
        public void Descricao_Nao_Pode_Ser_Vazio()
        {
            // arrange
            taxa.Descricao = "";

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Descricao);
        }

        [TestMethod]
        public void Descricao_Deve_Ter_No_Minimo_2_Caracteres()
        {
            // arrange
            taxa.Descricao = "a";

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Descricao);
        }

        //[TestMethod]
        //public void Valor_Aceita_Apenas_Numeros()
        //{

        //}

        [TestMethod]
        public void Valor_Deve_Ser_Maior_Que_0()
        {
            // arrange
            taxa.Valor = 0;

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Valor);
        }

        [TestMethod]
        public void TipoCalculo_Nao_Pode_Ser_Nulo()
        {
            // arrange
            taxa.TipoCalculo = null;

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.TipoCalculo);
        }

        [TestMethod]
        public void TipoCalculo_Nao_Pode_Ser_Vazio()
        {
            // arrange
            taxa.TipoCalculo = "";

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.TipoCalculo);
        }
    }
}
