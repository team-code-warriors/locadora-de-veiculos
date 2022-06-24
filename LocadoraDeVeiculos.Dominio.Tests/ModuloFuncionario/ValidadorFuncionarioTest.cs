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
    }
}
