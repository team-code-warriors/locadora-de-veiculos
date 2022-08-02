using FluentAssertions;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoOrmTest : IntegrationTestBase
    {
        private readonly RepositorioLocacaoOrm repositorio;
        private readonly LocadoraDeVeiculosDbContext dbContext;
        byte[] byteItems = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 };

        public RepositorioLocacaoOrmTest()
        {
            dbContext = new LocadoraDeVeiculosDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DbLocadoraDeVeiculosTestes;Integrated Security=True;Pooling=False");
            this.repositorio = new RepositorioLocacaoOrm(dbContext);
        }

        #region criação de instancias
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

        private Locacao NovaLocacao()
        {
            return new Locacao(NovoFuncionario(), NovoCondutor(), NovoVeiculo(), NovoPlano(), new List<Taxa>(), DateTime.Today.Date, DateTime.Today.Date.AddDays(1), 100, StatusLocacaoEnum.Ativa);
        }
        #endregion

        [TestMethod]
        public void Deve_inserir_uma_locacao()
        {
            //arrange
            var locacao = NovaLocacao();
            locacao.Valor = 100;

            //action
            repositorio.Inserir(locacao);
            dbContext.SaveChanges();

            //assert
            var locacaoEncontrada = repositorio.SelecionarPorId(locacao.Id);

            locacaoEncontrada.Should().NotBeNull();
            locacaoEncontrada.Should().Be(locacao);
        }

        [TestMethod]
        public void Deve_excluir_uma_locacao()
        {
            //arrange
            var locacao = NovaLocacao();
            locacao.Valor = 100;
            repositorio.Inserir(locacao);
            dbContext.SaveChanges();
            repositorio.Devolver(repositorio.SelecionarPorId(locacao.Id));
            dbContext.SaveChanges();

            //action
            repositorio.Excluir(locacao);
            dbContext.SaveChanges();

            //assert
            var locacaoEncontrada = repositorio.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().NotBeNull();
            locacaoEncontrada.Status.Should().Be(StatusLocacaoEnum.Fechada);
        }

        [TestMethod]
        public void Deve_devolver_uma_locacao()
        {
            //arrange
            var locacao = NovaLocacao();
            locacao.Valor = 100;
            repositorio.Inserir(locacao);
            dbContext.SaveChanges();

            var locacoes = repositorio.SelecionarTodos();

            //action
            repositorio.Devolver(locacao);
            dbContext.SaveChanges();

            //assert
            var locacaoEncontrada = repositorio.SelecionarPorId(locacao.Id);

            locacaoEncontrada.Should().NotBeNull();
            locacaoEncontrada.Status.Should().Be(StatusLocacaoEnum.Inativa);
        }

        [TestMethod]
        public void Deve_selecionar_uma_locacao()
        {
            //arrange
            var locacao = NovaLocacao();
            locacao.Valor = 100;
            repositorio.Inserir(locacao);
            dbContext.SaveChanges();

            //action
            var locacaoEncontrada = repositorio.SelecionarPorId(locacao.Id);

            //assert
            Assert.IsNotNull(locacaoEncontrada);
            Assert.AreEqual(locacao, locacaoEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_todas_locacacoes()
        {
            //arrange
            var locacao1 = NovaLocacao();
            locacao1.Valor = 100;
            repositorio.Inserir(locacao1);
            dbContext.SaveChanges();

            var locacao2 = NovaLocacao();
            locacao2.Valor = 200;
            repositorio.Inserir(locacao2);
            dbContext.SaveChanges();

            //action
            var locacoes = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(2, locacoes.Count);

            Assert.AreEqual(locacao1.Valor, locacoes[0].Valor);
            Assert.AreEqual(locacao2.Valor, locacoes[1].Valor);
        }

        [TestMethod]
        public void Deve_selecionar_locacoes_ativas_e_inativas()
        {
            //arrange
            var locacao1 = NovaLocacao();
            locacao1.Valor = 100;
            locacao1.Status = StatusLocacaoEnum.Inativa;
            repositorio.Inserir(locacao1);
            dbContext.SaveChanges();

            var locacao2 = NovaLocacao();
            locacao2.Valor = 200;
            locacao2.Status = StatusLocacaoEnum.Ativa;
            repositorio.Inserir(locacao2);
            dbContext.SaveChanges();

            var locacao3 = NovaLocacao();
            locacao3.Valor = 300;
            locacao3.Status = StatusLocacaoEnum.Fechada;
            repositorio.Inserir(locacao3);
            dbContext.SaveChanges();

            //action
            var locacoes = repositorio.SelecionarPorLocacaoAtivaEInativa();

            //assert
            Assert.AreEqual(2, locacoes.Count);

            Assert.AreEqual(locacao1.Status, locacoes[0].Status);
            Assert.AreEqual(locacao2.Status, locacoes[1].Status);
        }

    }
}
