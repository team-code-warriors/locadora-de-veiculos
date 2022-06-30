using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloPlanoDeCobranca
{
    public partial class TelaCadastroPlanoDeCobranca : Form
    {
        RepositorioPlanoDeCobrancaEmBancoDeDados repositorio = new RepositorioPlanoDeCobrancaEmBancoDeDados();
        ValidadorRegex validador = new ValidadorRegex();

        public TelaCadastroPlanoDeCobranca(List<GrupoDeVeiculos> grupos)
        {
            InitializeComponent();
            this.ConfigurarTela();
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

        public Func<PlanoDeCobranca, ValidationResult> GravarRegistro { get; set; }

        public PlanoDeCobranca Plano
        {
            get { return plano; }
            set
            {
                plano = value;
                cbGrupo.SelectedItem = plano.GrupoVeiculo;
                cbTipoPlano.SelectedItem = plano.TipoPlano;

                if (plano.ValorDiaria == 0)
                {
                    tbValorDiaria.Text = "";
                }
                else
                {
                    tbValorDiaria.Text = plano.ValorDiaria.ToString();
                }

                if (plano.KmIncluso == 0)
                {
                    tbKmIncluso.Text = "";
                }
                else
                {
                    tbKmIncluso.Text = plano.KmIncluso.ToString();
                }

                if (plano.PrecoKm == 0)
                {
                    tbPrecoKm.Text = "";
                }
                else
                {
                    tbPrecoKm.Text = plano.PrecoKm.ToString();
                }
            }
        }

        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            plano.GrupoVeiculo = (GrupoDeVeiculos)cbGrupo.SelectedItem;
            plano.TipoPlano = (string)cbTipoPlano.SelectedItem;
            plano.ValorDiaria = Convert.ToDecimal(tbValorDiaria.Text);
            plano.KmIncluso = Convert.ToInt32(tbKmIncluso.Text);
            plano.PrecoKm = Convert.ToDecimal(tbPrecoKm.Text);

            var resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
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
    }
}
