using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private readonly Cliente cliente;
        private readonly ValidadorCliente validador;

        public ValidadorClienteTest()
        {
            cliente = new()
            {
                Nome = "Lucas Bleyer",
                Email = "lucas@gmail.com",
                Endereco = "Lages",
                Cpf = "111.222.333-44",
                Telefone = "11999999999",
                Cnh = "123456789101"
            };
            validador = new ValidadorCliente();
        }

        [TestMethod]
        public void Nome_Nao_Pode_Ser_Nulo()
        {
            // arrange
            cliente.Nome = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Nao_Pode_Ser_Vazio()
        {
            // arrange
            cliente.Nome = "";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ter_No_Minimo_2_Caracteres()
        {
            // arrange
            cliente.Nome = "a";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Email_Nao_Pode_Ser_Nulo()
        {
            // arrange
            cliente.Email = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
        }

        [TestMethod]
        public void Email_Nao_Pode_Ser_Vazio()
        {
            // arrange
            cliente.Email = "";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
        }

        [TestMethod]
        public void Email_Deve_Ter_No_Minimo_5_Caracteres()
        {
            // arrange
            cliente.Email = "a";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
        }

        [TestMethod]
        public void Endereco_Nao_Pode_Ser_Nulo()
        {
            // arrange
            cliente.Endereco = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }

        [TestMethod]
        public void Endereco_Nao_Pode_Ser_Vazio()
        {
            // arrange
            cliente.Endereco = "";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }

        [TestMethod]
        public void Endereco_Deve_Ter_No_Minimo_2_Caracteres()
        {
            // arrange
            cliente.Endereco = "a";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }

        [TestMethod]
        public void Cpf_Nao_Pode_Ser_Nulo()
        {
            // arrange
            cliente.Cpf = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cpf_Nao_Pode_Ser_Vazio()
        {
            // arrange
            cliente.Cpf = "";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cpf_Deve_Ter_No_Minimo_14_Caracteres()
        {
            // arrange
            cliente.Cpf = "11";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cpf_Deve_Ter_No_Maximo_14_Caracteres()
        {
            // arrange
            cliente.Cpf = "111111111111111111111111";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Telefone_Nao_Pode_Ser_Nulo()
        {
            // arrange
            cliente.Telefone = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }

        [TestMethod]
        public void Telefone_Nao_Pode_Ser_Vazio()
        {
            // arrange
            cliente.Telefone = "";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }

        [TestMethod]
        public void Telefone_Deve_Ter_No_Minimo_11_Caracteres()
        {
            // arrange
            cliente.Telefone = "12";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }

        [TestMethod]
        public void Telefone_Deve_Ter_No_Maximo_11_Caracteres()
        {
            // arrange
            cliente.Telefone = "1111111111111111111112";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }

        [TestMethod]
        public void Cnh_Nao_Pode_Ser_Nulo()
        {
            // arrange
            cliente.Cnh = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cnh);
        }

        [TestMethod]
        public void Cnh_Nao_Pode_Ser_Vazio()
        {
            // arrange
            cliente.Cnh = "";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cnh);
        }

        [TestMethod]
        public void Cnh_Deve_Ter_No_Minimo_10_Caracteres()
        {
            // arrange
            cliente.Cnh = "1";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cnh);
        }

        [TestMethod]
        public void Cnh_Deve_Ter_No_Maximo_10_Caracteres()
        {
            // arrange
            cliente.Cnh = "111111111111111111111111111";

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cnh);
        }
    }
}
