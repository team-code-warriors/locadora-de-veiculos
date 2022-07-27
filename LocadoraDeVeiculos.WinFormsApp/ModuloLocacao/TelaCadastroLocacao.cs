using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
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

namespace LocadoraDeVeiculos.WinFormsApp.ModuloLocacao
{
    public partial class TelaCadastroLocacao : Form
    {
        List<Taxa> taxas = new List<Taxa>();
        public TelaCadastroLocacao(List<Funcionario> funcionarios, List<Condutor> condutores, List<Veiculo> veiculos, List<PlanoDeCobranca> planos, List<Taxa> taxas)
        {
            InitializeComponent();
            CarregarFuncionarios(funcionarios);
            CarregarCondutores(condutores);
            CarregarVeiculos(veiculos);
            CarregarPlanos(planos);
            CarregarTaxas(taxas);
            this.ConfigurarTela();
        }

        private Locacao locacao;

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao Locacao
        {
            get
            {
                return locacao;
            }
            set
            {
                locacao = value;

                CarregaTela();
            }
        }

        private void CarregaTela()
        {
            cbFuncionario.SelectedItem = locacao.Funcionario;
            cbCondutor.SelectedItem = locacao.Condutor;
            cbVeiculo.SelectedItem = locacao.Veiculo;
            cbPlano.SelectedItem = locacao.Plano;
            tbKm.Text = locacao.KmCarro.ToString();

            if (locacao.Taxas != null)
            {
                foreach (var item in locacao.Taxas)
                {
                    listTaxas.Items.Add(item);
                }
            }

        }

        private void CarregarTaxas(List<Taxa> taxas)
        {
            cbTaxa.Items.Clear();

            foreach (var item in taxas)
            {
                cbTaxa.Items.Add(item);
            }
        }

        private void CarregarPlanos(List<PlanoDeCobranca> planos)
        {
            cbPlano.Items.Clear();

            foreach (var item in planos)
            {
                cbPlano.Items.Add(item);
            }
        }

        private void CarregarVeiculos(List<Veiculo> veiculos)
        {
            cbVeiculo.Items.Clear();

            foreach (var item in veiculos)
            {
                cbVeiculo.Items.Add(item);
            }
        }

        private void CarregarCondutores(List<Condutor> condutores)
        {
            cbCondutor.Items.Clear();

            foreach (var item in condutores)
            {
                cbCondutor.Items.Add(item);
            }
        }

        private void CarregarFuncionarios(List<Funcionario> funcionarios)
        {
            cbFuncionario.Items.Clear();

            foreach (var item in funcionarios)
            {
                cbFuncionario.Items.Add(item);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            locacao.Funcionario = (Funcionario)cbFuncionario.SelectedItem;
            locacao.Condutor = (Condutor)cbCondutor.SelectedItem;
            locacao.Veiculo = (Veiculo)cbVeiculo.SelectedItem;
            locacao.Plano = (PlanoDeCobranca)cbPlano.SelectedItem;
            locacao.DataLocacao = dtpLocacao.Value;
            locacao.DataDevolucao = dtpDevolucao.Value;
            locacao.KmCarro = Convert.ToInt32(tbKm.Text);
            locacao.Taxas = taxas;

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnAdicionarTaxa_Click(object sender, EventArgs e)
        {
            listTaxas.Items.Add(cbTaxa.SelectedItem);
            taxas.Add((Taxa)cbTaxa.SelectedItem);
            cbTaxa.SelectedIndex = -1;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

        }
    }
}
