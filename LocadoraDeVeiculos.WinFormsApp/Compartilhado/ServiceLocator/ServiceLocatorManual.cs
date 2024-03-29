﻿using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
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
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;

        public ServiceLocatorManual()
        {
            controladores = new Dictionary<string, ControladorBase>();

            ConfigurarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }

        private void ConfigurarControladores()
        {
            ConfiguracaoAplicacao configuracao = new ConfiguracaoAplicacao();

            var contextoDadosOrm = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);

            var repositorioFuncionario = new RepositorioFuncionarioOrm(contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, contextoDadosOrm);
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));

            var repositorioTaxa = new RepositorioTaxaOrm(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));

            var repositorioGrupo = new RepositorioGrupoDeVeiculoOrm(contextoDadosOrm);
            var servicoGrupo = new ServicoGrupoDeVeiculo(repositorioGrupo, contextoDadosOrm);
            controladores.Add("ControladorGrupoDeVeiculos", new ControladorGrupoDeVeiculos(servicoGrupo));

            var repositorioPlano = new RepositorioPlanoDeCobrancaOrm(contextoDadosOrm);
            var servicoPlano = new ServicoPlanoDeCobranca(repositorioPlano, contextoDadosOrm);
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoPlano, servicoGrupo));

            var repositorioCliente = new RepositorioClienteOrm(contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente, contextoDadosOrm);
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));

            var repositorioCondutor = new RepositorioCondutorOrm(contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor, contextoDadosOrm);
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutor, servicoCliente));

            var repositorioVeiculo = new RepositorioVeiculoOrm(contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, contextoDadosOrm);
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo, servicoGrupo));

            var configuracaoAplicacao = new ConfiguracaoAplicacao();
            controladores.Add("ControladorConfiguracao", new ControladorConfiguracao(configuracaoAplicacao));

            var repositorioLocacao = new RepositorioLocacaoOrm(contextoDadosOrm);
            var servicoLocacao = new ServicoLocacao(repositorioLocacao, contextoDadosOrm);
            controladores.Add("ControladorLocacao", new ControladorLocacao(servicoLocacao, servicoFuncionario, servicoCondutor, servicoVeiculo, servicoPlano, servicoTaxa, configuracaoAplicacao));

        }
    }
}
