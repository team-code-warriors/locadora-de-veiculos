using Autofac;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Configs;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraDeVeiculos.WinFormsApp.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.ModuloCondutor;
using LocadoraDeVeiculos.WinFormsApp.ModuloConfiguracao;
using LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinFormsApp.ModuloLocacao;
using LocadoraDeVeiculos.WinFormsApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinFormsApp.ModuloTaxa;
using LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorComAutofac()
        {
            var builder = new ContainerBuilder();

            builder.Register((x) => new ConfiguracaoAplicacao().ConnectionStrings)
                 .As<ConnectionStrings>()
                 .SingleInstance(); 

            builder.RegisterType<ConfiguracaoAplicacao>()
                .SingleInstance();

            builder.RegisterType<LocadoraDeVeiculosDbContext>().As<IContextoPersistencia>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioClienteOrm>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>();
            builder.RegisterType<ControladorCliente>();

            builder.RegisterType<RepositorioGrupoDeVeiculoOrm>().As<IRepositorioGrupoDeVeiculos>();
            builder.RegisterType<ServicoGrupoDeVeiculo>();
            builder.RegisterType<ControladorGrupoDeVeiculos>();

            builder.RegisterType<RepositorioFuncionarioOrm>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>();
            builder.RegisterType<ControladorFuncionario>();

            builder.RegisterType<RepositorioCondutorOrm>().As<IRepositorioCondutor>();
            builder.RegisterType<ServicoCondutor>();
            builder.RegisterType<ControladorCondutor>();

            builder.RegisterType<RepositorioTaxaOrm>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>();
            builder.RegisterType<ControladorTaxa>();

            builder.RegisterType<RepositorioPlanoDeCobrancaOrm>().As<IRepositorioPlanoDeCobranca>();
            builder.RegisterType<ServicoPlanoDeCobranca>();
            builder.RegisterType<ControladorPlanoDeCobranca>();

            builder.RegisterType<RepositorioVeiculoOrm>().As<IRepositorioVeiculo>();
            builder.RegisterType<ServicoVeiculo>();
            builder.RegisterType<ControladorVeiculo>();

            builder.RegisterType<ControladorConfiguracao>().AsSelf();

            builder.RegisterType<RepositorioLocacaoOrm>().As<IRepositorioLocacao>();
            builder.RegisterType<ServicoLocacao>();
            builder.RegisterType<ControladorLocacao>();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
