using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloPlanoDeCobranca
{
    [TestClass]
    public class ValidadorPlanoDeCobrancaTest
    {
        private readonly PlanoDeCobranca plano;
        private readonly ValidadorPlanoDeCobranca validador;

        public ValidadorPlanoDeCobrancaTest()
        {
            plano = new()
            {
                GrupoVeiculo = new()
                {
                    Nome = "SUV",
                },

                TipoPlano = "Plano Diário",
                ValorDiaria = 100,
                KmIncluso = 0,
                PrecoKm = 10
        };

            validador = new ValidadorPlanoDeCobranca();
        }

        [TestMethod]
        public void Grupo_Nao_Pode_Ser_Nulo()
        {
            // arrange
            plano.GrupoVeiculo = null;

            // action
            var resultado = validador.TestValidate(plano);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.GrupoVeiculo);
        }

        [TestMethod]
        public void TipoPlano_Nao_Pode_Ser_Nulo()
        {
            // arrange
            plano.TipoPlano = null;

            // action
            var resultado = validador.TestValidate(plano);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.TipoPlano);
        }

        [TestMethod]
        public void TipoPlano_Nao_Pode_Ser_Vazio()
        {
            // arrange
            plano.TipoPlano = "";

            // action
            var resultado = validador.TestValidate(plano);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.TipoPlano);
        }

        [TestMethod]
        public void ValorDiaria_Deve_Ser_Maior_Que_0()
        {
            // arrange
            plano.ValorDiaria = 0;

            // action
            var resultado = validador.TestValidate(plano);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ValorDiaria);
        }
    }
}
