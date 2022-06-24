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
        private Cliente? cliente;
        private ValidadorCliente validador;

        public ValidadorClienteTest()
        {
            validador = new();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Nome = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            cliente = NovoCliente();

            cliente.Nome = "@Lucas";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Email = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }

        [TestMethod]
        public void Cpf_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Cpf = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Cpf);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Telefone = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }

        [TestMethod]
        public void Cnh_deve_ser_obrigatorio()
        {
            cliente = NovoCliente();

            cliente.Cnh = null;

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Cnh);
        }

        [TestMethod]
        public void CNH_deve_ser_valida()
        {
            cliente = NovoCliente();

            cliente.Cnh = "12345678901";

            TestValidationResult<Cliente> resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Cnh);
        }

        private Cliente NovoCliente()
        {
            return new Cliente
            {
                Nome = "Lucas",
                Email = "lucas@gmail.com",
                Cpf = "111.222.333-44",
                Telefone = "9999999999",
                Cnh = "12345678901",
            };
        }
    }
}
