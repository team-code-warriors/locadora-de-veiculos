using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
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

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxa
{
    public partial class TelaCadastroTaxa : Form
    {
        ValidadorRegex validador = new ValidadorRegex();
        RepositorioTaxaEmBancoDeDados repositorio = new RepositorioTaxaEmBancoDeDados();
        public TelaCadastroTaxa()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        private Taxa taxa;

        public Func<Taxa, Result<Taxa>> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get { return taxa; }
            set
            {
                taxa = value;
                CarregaTela();
            }
        }

        private void CarregaTela()
        {
            tbNumero.Text = taxa.Id.ToString();
            tbDescricao.Text = taxa.Descricao;

            if (taxa.Valor == 0)
            {
                tbValor.Text = "";
            }
            else
            {
                tbValor.Text = taxa.Valor.ToString();
            }
            cbTipoCalculo.SelectedItem = taxa.TipoCalculo;
        }

        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            taxa.Descricao = tbDescricao.Text;

            #region Validação se o valor esta correto

            string valorComPonto = tbValor.Text.Replace(",", ".");
            string valorComVirgula = tbValor.Text.Replace(".", ",");

            if (!validador.ApenasNumerosInteirosOuDecimais(valorComPonto))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'Valor'.");
                DialogResult = DialogResult.None;

                return;
            }

            #endregion

            taxa.Valor = Convert.ToDecimal(valorComVirgula);
            taxa.TipoCalculo = (string)cbTipoCalculo.SelectedItem;

            var resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}

