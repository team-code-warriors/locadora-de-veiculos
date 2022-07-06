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
        private Condutor? condutor;
        private readonly ValidadorCondutor validador;

        public ValidadorCondutorTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Cliente_Nao_Pode_Ser_Nulo()
        public void Nome_deve_ser_obrigatorio()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cliente = null;
            //arrange
            condutor = NovoCondutor();

            // action
            var resultado = validador.TestValidate(condutor);
            condutor.Nome = "";

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cliente);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Nome_Nao_Pode_Ser_Nulo()
        public void Nome_deve_ser_valido()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Nome = null;
            //arrange
            condutor = NovoCondutor();

            // action
            var resultado = validador.TestValidate(condutor);
            condutor.Nome = "@123";

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }


        [TestMethod]
        public void Nome_Deve_Ter_No_Minimo_2_Caracteres()
        public void Cpf_deve_ser_obrigatorio()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Nome = "a";
            //arrange
            condutor = NovoCondutor();

            // action
            var resultado = validador.TestValidate(condutor);
            condutor.Cpf = "";

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cpf);
        }

        [TestMethod]
        public void Email_Nao_Pode_Ser_Nulo()
        public void Cpf_deve_ser_valido()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Email = null;
            //arrange
            condutor = NovoCondutor();

            // action
            var resultado = validador.TestValidate(condutor);
            condutor.Cpf = "123456";

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cpf);
        }


        [TestMethod]
        public void Email_Deve_Ter_No_Minimo_5_Caracteres()
        public void Cnpj_deve_ser_valido()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Email = "a";
            //arrange
            condutor = NovoCondutor();

            // action
            var resultado = validador.TestValidate(condutor);
            condutor.Cnpj = "123456";

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnpj);
        }

        [TestMethod]
        public void Endereco_Nao_Pode_Ser_Nulo()
        public void Cnh_deve_ser_obrigatorio()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Endereco = null;
            //arrange
            condutor = NovoCondutor();

            // action
            var resultado = validador.TestValidate(condutor);
            condutor.Cnh = "";

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnh);
        }

        [TestMethod]
        public void Endereco_Deve_Ter_No_Minimo_2_Caracteres()
        public void Cnh_deve_ser_valida()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Endereco = "a";
            //arrange
            condutor = NovoCondutor();

            // action
            var resultado = validador.TestValidate(condutor);
            condutor.Cnh = "123";

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

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
            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnh);
        }

        [TestMethod]
        public void Cpf_Nao_Pode_Ser_Vazio()
        public void DataVencimento_deve_ser_valida()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cpf = "";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }
            //arrange
            condutor = NovoCondutor();

        [TestMethod]
        public void Cpf_Deve_Ter_No_Minimo_14_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cpf = "11";
            condutor.DataValidadeCnh = DateTime.MaxValue;

            // action
            var resultado = validador.TestValidate(condutor);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.DataValidadeCnh);
        }

        [TestMethod]
        public void Cpf_Deve_Ter_No_Maximo_14_Caracteres()
        public void Telefone_deve_ser_obrigatorio()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Cpf = "111111111111111111111111";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

            //arrange
            condutor = NovoCondutor();

        [TestMethod]
        public void Telefone_Nao_Pode_Ser_Nulo()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Telefone = null;
            condutor.Telefone = "";

            // action
            var resultado = validador.TestValidate(condutor);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }


        [TestMethod]
        public void Telefone_Deve_Ter_No_Minimo_11_Caracteres()
        public void Telefone_deve_ser_valido()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Telefone = "12";

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }
            //arrange
            condutor = NovoCondutor();

        [TestMethod]
        public void Telefone_Deve_Ter_No_Maximo_11_Caracteres()
        {
            // arrange
            var condutor = NovoCondutor();
            condutor.Telefone = "1111111111111111111112";
            condutor.Telefone = "129887";

            // action
            var resultado = validador.TestValidate(condutor);
            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }


        [TestMethod]
        public void Cnh_deve_ser_obrigatorio()
        public void Email_deve_ser_obrigatorio()
        {
            //arrange
            var condutor = NovoCondutor();
            condutor.Cnh = "";
            condutor = NovoCondutor();

            condutor.Email = "";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnh);
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Email);
        }

        [TestMethod]
        public void Cnh_deve_ser_valida()
        public void Endereco_deve_ser_obrigatoria()
        {
            //arrange
            var condutor = NovoCondutor();
            condutor.Cnh = "123";
            condutor = NovoCondutor();

            condutor.Endereco = "";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnh);
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Endereco);
        }


        private Condutor NovoCondutor()
        {
            return new Condutor
            {
                Nome = "Lucas",
                Cpf = "111.111.111-11",
                Cnpj = "43.367.658/0001-49",
                Endereco = "Lages",
                Cnh = "01234567891",
                DataValidadeCnh = DateTime.Now.Date,
                Telefone = "12988754461",
                Email = "lucas@gmail.com",
            };
        }
    }
}
}
