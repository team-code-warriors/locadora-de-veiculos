using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private readonly Funcionario funcionario;
        private readonly ValidadorFuncionario validador;
        public ValidadorFuncionarioTest()
        {
            funcionario = new()
            {
                Nome = "Ane Luisy",
                Salario = 1000,
                DataAdmissao = DateTime.Now.Date,
                Login = "ane.lg",
                Senha = "abc123",
                TipoPerfil = "Comum"
            };

            validador = new ValidadorFuncionario();
        }

        [TestMethod]
        public void Nome_Nao_Pode_Ser_Nulo()
        {
            // arrange
            funcionario.Nome = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Nao_Pode_Ser_Vazio()
        {
            // arrange
            funcionario.Nome = "";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ter_No_Minimo_2_Caracteres()
        {
            // arrange
            funcionario.Nome = "a";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Salario_Deve_Ser_Maior_Que_0()
        {
            // arrange
            funcionario.Salario = 0;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Salario);
        }

        [TestMethod]
        public void Login_Nao_Pode_Ser_Nulo()
        {
            // arrange
            funcionario.Login = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Login);
        }

        [TestMethod]
        public void Login_Nao_Pode_Ser_Vazio()
        {
            // arrange
            funcionario.Login = "";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Login);
        }

        [TestMethod]
        public void Login_Deve_Ter_No_Minimo_3_Caracteres()
        {
            // arrange
            funcionario.Login = "a";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Login);
        }

        [TestMethod]
        public void Senha_Nao_Pode_Ser_Nulo()
        {
            // arrange
            funcionario.Senha = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Senha);
        }

        [TestMethod]
        public void Senha_Nao_Pode_Ser_Vazio()
        {
            // arrange
            funcionario.Senha = "";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Senha);
        }

        [TestMethod]
        public void Senha_Deve_Ter_No_Minimo_3_Caracteres()
        {
            // arrange
            funcionario.Senha = "a";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Senha);
        }

        [TestMethod]
        public void TipoPerfil_Nao_Pode_Ser_Nulo()
        {
            // arrange
            funcionario.TipoPerfil = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.TipoPerfil);
        }

        [TestMethod]
        public void TipoPerfil_Nao_Pode_Ser_Vazio()
        {
            // arrange
            funcionario.TipoPerfil = "";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.TipoPerfil);
        }
    }
}
