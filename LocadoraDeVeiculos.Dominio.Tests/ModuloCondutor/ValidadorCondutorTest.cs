using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        private readonly ValidadorCondutor validador;

        public ValidadorCondutorTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Cliente_Nao_Pode_Ser_Nulo()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cliente = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cliente);
        }

        [TestMethod]
        public void Nome_Nao_Pode_Ser_Nulo()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Nome = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }


        [TestMethod]
        public void Nome_Deve_Ter_No_Minimo_2_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Nome = "a";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Email_Nao_Pode_Ser_Nulo()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Email = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
        }


        [TestMethod]
        public void Email_Deve_Ter_No_Minimo_5_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Email = "a";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
        }

        [TestMethod]
        public void Endereco_Nao_Pode_Ser_Nulo()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Endereco = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }

        [TestMethod]
        public void Endereco_Deve_Ter_No_Minimo_2_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Endereco = "a";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }

        [TestMethod]
        public void Cpf_Nao_Pode_Ser_Nulo()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cpf = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cpf_Nao_Pode_Ser_Vazio()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cpf = "";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cpf_Deve_Ter_No_Minimo_14_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cpf = "11";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cpf_Deve_Ter_No_Maximo_14_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cpf = "111111111111111111111111";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }


        [TestMethod]
        public void Telefone_Nao_Pode_Ser_Nulo()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Telefone = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }


        [TestMethod]
        public void Telefone_Deve_Ter_No_Minimo_11_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Telefone = "12";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }

        [TestMethod]
        public void Telefone_Deve_Ter_No_Maximo_11_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Telefone = "1111111111111111111112";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }


        [TestMethod]
        public void Cnh_deve_ser_obrigatorio()
        {
            //arrange
            var condutor = NovoCondutor();
            condutor.Cnh = "";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnh);
        }

        [TestMethod]
        public void Cnh_deve_ser_valida()
        {
            //arrange
            var condutor = NovoCondutor();
            condutor.Cnh = "123";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnh);
        }


        private Condutor NovoCondutor()
        {
            return new Condutor
            {
                Nome = "Lucas",
                Cpf = "111.111.111-11",
                Endereco = "Lages",
                Cnh = "01234567891",
                DataValidadeCnh = DateTime.Now.Date,
                Telefone = "12988754461",
                Email = "lucas@gmail.com",
            };
        }
    }
}