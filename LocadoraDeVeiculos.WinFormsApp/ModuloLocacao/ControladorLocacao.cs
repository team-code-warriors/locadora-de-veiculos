using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Configs;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TabelaLocacaoControl tabelaLocacoes;
        private readonly ServicoLocacao servicoLocacao;
        private readonly ServicoFuncionario servicoFuncionario;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoVeiculo servicoVeiculo;
        private readonly ServicoPlanoDeCobranca servicoPlano;
        private readonly ServicoTaxa servicoTaxa;
        ConfiguracaoAplicacao configuracao;

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoFuncionario servicoFuncionario, ServicoCondutor servicoCondutor, ServicoVeiculo servicoVeiculo, ServicoPlanoDeCobranca servicoPlano, ServicoTaxa servicoTaxa, ConfiguracaoAplicacao configuracao)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoFuncionario = servicoFuncionario;
            this.servicoCondutor = servicoCondutor;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoPlano = servicoPlano;
            this.servicoTaxa = servicoTaxa;
            this.configuracao = configuracao;
        }

        public override void Excluir()
        {
            var id = tabelaLocacoes.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                    "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?", "Exclusão de Locação",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Inserir()
        {
            var resultadoSelecaoFuncionarios = servicoFuncionario.SelecionarTodos();

            if (resultadoSelecaoFuncionarios.IsFailed)
            {
                string erro = resultadoSelecaoFuncionarios.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoCondutores = servicoCondutor.SelecionarTodos();

            if (resultadoSelecaoCondutores.IsFailed)
            {
                string erro = resultadoSelecaoCondutores.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoVeiculos = servicoVeiculo.SelecionarTodos();

            if (resultadoSelecaoVeiculos.IsFailed)
            {
                string erro = resultadoSelecaoVeiculos.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoPlanos = servicoPlano.SelecionarTodos();

            if (resultadoSelecaoPlanos.IsFailed)
            {
                string erro = resultadoSelecaoPlanos.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoTaxas = servicoTaxa.SelecionarTodos();

            if (resultadoSelecaoTaxas.IsFailed)
            {
                string erro = resultadoSelecaoTaxas.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroLocacao tela = new TelaCadastroLocacao(
                resultadoSelecaoFuncionarios.Value,
                resultadoSelecaoCondutores.Value,
                resultadoSelecaoVeiculos.Value,
                resultadoSelecaoPlanos.Value,
                resultadoSelecaoTaxas.Value);

            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarLocacoes();
            }
        }

        private void CarregarLocacoes()
        {
            var resultado = servicoLocacao.SelecionarPorLocacaoAtivaEInativa();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                tabelaLocacoes.AtualizarRegistros(locacoes);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} locação(ões)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Devolver()
        {
            var id = tabelaLocacoes.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                    "Cadastro de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Cadastro de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            var resultadoSelecaoTaxas = servicoTaxa.SelecionarTodos();

            if (resultadoSelecaoTaxas.IsFailed)
            {
                string erro = resultadoSelecaoTaxas.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroDevolucao tela = new TelaCadastroDevolucao(resultadoSelecaoTaxas.Value, locacaoSelecionada, configuracao);

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = servicoLocacao.Devolver;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacoes();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            tabelaLocacoes = new TabelaLocacaoControl();

            CarregarLocacoes();

            return tabelaLocacoes;
        }
    }
}
