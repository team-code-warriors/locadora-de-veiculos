using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloLocacao
{
    [TestClass]
    public class ValidadorLocacaoTest
    {
        private Locacao locacao;
        private readonly ValidadorLocacao validador;

        public ValidadorLocacaoTest()
        {
            validador = new();
        }
    }
}
