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
        private readonly ServicoLocacao servico;
        private readonly LocadoraDeVeiculosDbContext dbContext;
        private IContextoPersistencia contextoPersistencia;
        byte[] byteItems = new byte[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 };

        public RepositorioLocacaoOrmTest()
        {
            dbContext = new LocadoraDeVeiculosDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DbLocadoraDeVeiculosTestes;Integrated Security=True;Pooling=False");
            this.repositorio = new RepositorioLocacaoOrm(dbContext);
            this.servico = new ServicoLocacao(repositorio, contextoPersistencia);
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
            servico.Inserir(locacao);

            //assert
            var locacaoEncontrada = servico.SelecionarPorId(locacao.Id);

            locacaoEncontrada.Should().NotBeNull();
            locacaoEncontrada.Should().Be(locacao);
        }
    }
}
