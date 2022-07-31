using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloLocacao
{
    [TestClass]
    public class ValidadorLocacaoTest
    {
        public ValidadorLocacaoTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        byte[] byteItems = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 };

        private Cliente NovoCliente()
        {
            return new Cliente("Lucas Bleyer", "lucas@gmail.com", "Lages", "111.222.333-44", "43.367.658/0001-49", "(11) 99999-9999");
        }

        private Condutor NovoCondutor()
        {
            return new Condutor(NovoCliente(), "Lucas Bleyer", "111.222.333-44", "12345678901", DateTime.Now.Date, "lucas@gmail.com", "(11) 99999-9999", "Lages");
        }

        private GrupoDeVeiculos NovoGrupo()
        {
            return new GrupoDeVeiculos("SUV");
        }

        private PlanoDeCobranca NovoPlano()
        {
            return new PlanoDeCobranca(NovoGrupo(), "Plano Diário", 100, 10, 10);
        }

        private Funcionario NovoFuncionario()
        {
            return new Funcionario("Fabricio Silva", 1000, DateTime.Today.Date, "fabsilv11", "123453fab", "Comum");
        }

        private Taxa NovaTaxa()
        {
            return new Taxa("GPS", 10, "Fixo");
        }

        private Veiculo NovoVeiculo()
        {
            return new Veiculo("Focus", "Ford", 2000, "Manual", "Branco", "AAAA124", 100, "Gasolina", 1000, NovoGrupo(), byteItems);
        }

        [TestMethod]
        public void Funcionario_Locacao_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao(null, NovoCondutor(), NovoVeiculo(), NovoPlano(), new List<Taxa>(), DateTime.Today.Date, DateTime.Today.Date, 100, StatusLocacaoEnum.Ativa);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Funcionario' não pode ser nulo.", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("'Funcionario' deve ser informado.", resultado.Errors[1].ErrorMessage);
        }

        [TestMethod]
        public void Condutor_Locacao_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao(NovoFuncionario(), null, NovoVeiculo(), NovoPlano(), new List<Taxa>(), DateTime.Today.Date, DateTime.Today.Date, 100, StatusLocacaoEnum.Ativa);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Condutor' não pode ser nulo.", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("'Condutor' deve ser informado.", resultado.Errors[1].ErrorMessage);
        }

        [TestMethod]
        public void Veiculo_Locacao_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao(NovoFuncionario(), NovoCondutor(), null, NovoPlano(), new List<Taxa>(), DateTime.Today.Date, DateTime.Today.Date, 100, StatusLocacaoEnum.Ativa);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Veiculo' não pode ser nulo.", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("'Veiculo' deve ser informado.", resultado.Errors[1].ErrorMessage);
        }

        [TestMethod]
        public void Plano_Locacao_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao(NovoFuncionario(), NovoCondutor(), NovoVeiculo(), null, new List<Taxa>(), DateTime.Today.Date, DateTime.Today.Date, 100, StatusLocacaoEnum.Ativa);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Plano' não pode ser nulo.", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("'Plano' deve ser informado.", resultado.Errors[1].ErrorMessage);
        }
    }
}
