﻿using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloPlanoDeCobranca
{
    public partial class TelaCadastroPlanoDeCobranca : Form
    {
        ValidadorRegex validador = new ValidadorRegex();

        public TelaCadastroPlanoDeCobranca(List<GrupoDeVeiculos> grupos)
        {
            InitializeComponent();
            this.ConfigurarTela();
            ConfiguracoesIniciaisTela();
            CarregarGrupos(grupos);
        }

        private void CarregarGrupos(List<GrupoDeVeiculos> grupos)
        {
            cbGrupo.Items.Clear();

            foreach (var item in grupos)
            {
                cbGrupo.Items.Add(item);
            }
        }

        private PlanoDeCobranca plano;

        public Func<PlanoDeCobranca, Result<PlanoDeCobranca>> GravarRegistro { get; set; }

        public PlanoDeCobranca Plano
        {
            get { return plano; }
            set
            {
                plano = value;
                CarregaTela();

            }
        }

        private void CarregaTela()
        {
            cbGrupo.SelectedItem = plano.GrupoVeiculo;
            cbTipoPlano.SelectedItem = plano.TipoPlano;

            tbValorDiaria.Text = plano.ValorDiaria.ToString();
            tbKmIncluso.Text = plano.KmIncluso.ToString();
            tbPrecoKm.Text = plano.PrecoKm.ToString();
        }

        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            #region Validações se preço da diária, km incluso e preço km estão no formato correto
            string valorComPontoDiaria = tbValorDiaria.Text.Replace(",", ".");
            string valorComVirgulaDiaria = tbValorDiaria.Text.Replace(".", ",");

            if (!validador.ApenasNumerosInteirosOuDecimais(valorComPontoDiaria))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'Valor da Diária'.");
                DialogResult = DialogResult.None;

                return;
            }

            string valorComPontoKmIncluso = tbKmIncluso.Text.Replace(",", ".");
            string valorComVirgulaKmIncluso = tbKmIncluso.Text.Replace(".", ",");

            if (!validador.ApenasNumerosInteirosOuDecimais(valorComPontoKmIncluso))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'KM Incluso'.");
                DialogResult = DialogResult.None;

                return;
            }

            string valorComPontoPrecoKm = tbPrecoKm.Text.Replace(",", ".");
            string valorComVirgulaPrecoKm = tbPrecoKm.Text.Replace(".", ",");

            if (!validador.ApenasNumerosInteirosOuDecimais(valorComPontoPrecoKm))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'Preço por KM'.");
                DialogResult = DialogResult.None;

                return;
            }

            #endregion

            plano.GrupoVeiculo = (GrupoDeVeiculos)cbGrupo.SelectedItem;
            plano.TipoPlano = (string)cbTipoPlano.SelectedItem;
            plano.ValorDiaria = Convert.ToDecimal(valorComVirgulaDiaria);
            plano.KmIncluso = Convert.ToDecimal(valorComVirgulaKmIncluso);
            plano.PrecoKm = Convert.ToDecimal(valorComVirgulaPrecoKm);

            var resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void TelaCadastroContatosForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroContatosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTipoPlano.Enabled = true;
        }

        private void ConfiguracoesIniciaisTela()
        {
            cbTipoPlano.Enabled = false;
            tbValorDiaria.Enabled = false;
            tbKmIncluso.Enabled = false;
            tbPrecoKm.Enabled = false;
        }

        private void cbTipoPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTipoPlano.SelectedItem == "Plano Diário")
            {
                tbValorDiaria.Clear();
                tbKmIncluso.Clear();
                tbPrecoKm.Clear();

                tbKmIncluso.Text = "0";
                tbKmIncluso.Enabled = false;

                tbValorDiaria.Enabled = true;
                tbPrecoKm.Enabled = true;
            }
            else if (cbTipoPlano.SelectedItem == "KM Controlado")
            {
                tbValorDiaria.Clear();
                tbKmIncluso.Clear();
                tbPrecoKm.Clear();

                tbValorDiaria.Enabled = true;
                tbKmIncluso.Enabled = true;
                tbPrecoKm.Enabled = true;

            }
            else if (cbTipoPlano.SelectedItem == "KM Livre")
            {
                tbValorDiaria.Clear();
                tbKmIncluso.Clear();
                tbPrecoKm.Clear();

                tbKmIncluso.Text = "0";
                tbKmIncluso.Enabled = false;
                tbPrecoKm.Text = "0";
                tbPrecoKm.Enabled = false;

                tbValorDiaria.Enabled = true;
            }
        }
    }
}
