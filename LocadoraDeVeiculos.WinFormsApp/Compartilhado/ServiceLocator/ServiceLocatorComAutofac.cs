using Autofac;
using FluentValidation;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Configs;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraDeVeiculos.WinFormsApp.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.ModuloCondutor;
using LocadoraDeVeiculos.WinFormsApp.ModuloConfiguracao;
using LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinFormsApp.ModuloLocacao;
using LocadoraDeVeiculos.WinFormsApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinFormsApp.ModuloTaxa;
using LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.RegisterType<RepositorioClienteEmBancoDeDados>().AsSelf();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioGrupoDeVeiculosEmBancoDeDados>().AsSelf();
            builder.RegisterType<ServicoGrupoDeVeiculo>().AsSelf();
            builder.RegisterType<ControladorGrupoDeVeiculos>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioEmBancoDeDados>().AsSelf();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioCondutorEmBancoDeDados>().AsSelf();
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioTaxaEmBancoDeDados>().AsSelf();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioPlanoDeCobrancaEmBancoDeDados>().AsSelf();
            builder.RegisterType<ServicoPlanoDeCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoDeCobranca>().AsSelf();

            builder.RegisterType<RepositorioVeiculoEmBancoDeDados>().AsSelf();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            builder.RegisterType<RepositorioLocacaoOrm>().AsSelf();
            builder.RegisterType<ServicoLocacao>().AsSelf();
            builder.RegisterType<ControladorLocacao>().AsSelf();

            builder.RegisterType<ControladorConfiguracao>().AsSelf();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }

        public Servico GetServico<Entidade, Servico, Tvalidador>()
            where Servico : ServicoBase<Entidade, Tvalidador>
            where Entidade : EntidadeBase<Entidade>
            where Tvalidador : AbstractValidator<Entidade>
        {
            return container.Resolve<Servico>();
        }
    }
}
