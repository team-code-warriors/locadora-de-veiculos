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
        public void Nome_deve_ser_obrigatorio()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Nome = "";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Nome = "@123";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Cpf_deve_ser_obrigatorio()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Cpf = "";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cpf);
        }

        [TestMethod]
        public void Cpf_deve_ser_valido()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Cpf = "123456";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cpf);
        }

        [TestMethod]
        public void Cnpj_deve_ser_valido()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Cnpj = "123456";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnpj);
        }

        [TestMethod]
        public void Cnh_deve_ser_obrigatorio()
        {
            //arrange
            condutor = NovoCondutor();

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
            condutor = NovoCondutor();

            condutor.Cnh = "123";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Cnh);
        }

        [TestMethod]
        public void DataVencimento_deve_ser_valida()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.DataValidadeCnh = DateTime.MaxValue;

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.DataValidadeCnh);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Telefone = "";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_ser_valido()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Telefone = "129887";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Email = "";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Email);
        }

        [TestMethod]
        public void Endereco_deve_ser_obrigatoria()
        {
            //arrange
            condutor = NovoCondutor();

            condutor.Endereco = "";

            //action
            TestValidationResult<Condutor> resultado = validador.TestValidate(condutor);

            //assert
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