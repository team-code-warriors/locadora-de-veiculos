using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloGrupoDeVeiculos
{
    [TestClass]
    public class ValidadorGrupoDeVeiculosTest
    {
        private readonly GrupoDeVeiculos grupo;
        private readonly ValidadorGrupoDeVeiculos validador;

        public ValidadorGrupoDeVeiculosTest()
        {
            grupo = new()
            {
                Nome = "SUV",
            };

            validador = new ValidadorGrupoDeVeiculos();
        }

        [TestMethod]
        public void Nome_Nao_Pode_Ser_Nulo()
        {
            // arrange
            grupo.Nome = null;

            // action
            var resultado = validador.TestValidate(grupo);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Nao_Pode_Ser_Vazio()
        {
            // arrange
            grupo.Nome = "";

            // action
            var resultado = validador.TestValidate(grupo);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ter_No_Minimo_2_Caracteres()
        {
            // arrange
            grupo.Nome = "a";

            // action
            var resultado = validador.TestValidate(grupo);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }
    }
}
