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
        int countClickBotaoCalcular = 0;
        public TelaCadastroLocacao(List<Funcionario> funcionarios, List<Condutor> condutores, List<Veiculo> veiculos, List<PlanoDeCobranca> planos, List<Taxa> taxas)
        {
            InitializeComponent();
            dtpLocacao.MinDate = DateTime.Today.Date;
            dtpDevolucao.MinDate = DateTime.Today.Date.AddDays(1);
            dtpDevolucao.MaxDate = DateTime.Today.Date.AddDays(30);
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
                tbKm.Text = "";
                CarregaTela();
            }
        }

        private void CarregaTela()
        {
            cbFuncionario.SelectedItem = locacao.Funcionario;
            cbCondutor.SelectedItem = locacao.Condutor;
            cbVeiculo.SelectedItem = locacao.Veiculo;
            cbPlano.SelectedItem = locacao.Plano;

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
            if (countClickBotaoCalcular != 0) {
                locacao.Funcionario = (Funcionario)cbFuncionario.SelectedItem;
                locacao.Condutor = (Condutor)cbCondutor.SelectedItem;
                VerificaValidadeCnhCondutor();
                locacao.Veiculo = (Veiculo)cbVeiculo.SelectedItem;
                locacao.Plano = (PlanoDeCobranca)cbPlano.SelectedItem;
                locacao.DataLocacao = dtpLocacao.Value;
                locacao.DataDevolucao = dtpDevolucao.Value;

                #region Verificação se a kilometragem esta correta
                string kilometragemSemEspaco = tbKm.Text.Replace(" ", "");

                if (kilometragemSemEspaco.Length == 0)
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'KM do Carro'");
                    DialogResult = DialogResult.None;

                    return;
                }
                #endregion

                locacao.KmCarro = Convert.ToInt32(tbKm.Text);
                locacao.Valor = Convert.ToDecimal(labelValor.Text.Replace("R$", ""));
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
            }else
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Calcule o valor da locação antes de cadastra-lá");
                DialogResult = DialogResult.None;
            }
        }

        private void VerificaValidadeCnhCondutor()
        {
            Condutor condutorSelecionado = (Condutor)cbCondutor.SelectedItem;

            if (condutorSelecionado.DataValidadeCnh.Date < DateTime.Today.Date)
            {
                MessageBox.Show("A CNH do condutor está expirada",
                      "Cadastro de Locações", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void btnAdicionarTaxa_Click(object sender, EventArgs e)
        {
            if (cbTaxa.SelectedIndex == -1)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Selecione uma taxa primeiro");
                DialogResult = DialogResult.None;
                return;
            }

            if (listTaxas.Items.Contains(cbTaxa.SelectedItem))
            {
                cbTaxa.SelectedIndex = -1;
                TelaMenuPrincipal.Instancia.AtualizarRodape("'Taxa' já adicionada");
                DialogResult = DialogResult.None;
                return;
            }

            listTaxas.Items.Add(cbTaxa.SelectedItem);
            taxas.Add((Taxa)cbTaxa.SelectedItem);
            cbTaxa.SelectedIndex = -1;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            countClickBotaoCalcular = countClickBotaoCalcular + 1;
            if (CalculaValor() == -1)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("'Plano' não deve ser nulo");
                DialogResult = DialogResult.None;
                return;
            }
            labelValor.Text = "R$ " + CalculaValor();
        }

        private decimal CalculaValor()
        {
            TimeSpan diasDeAluguel = (dtpDevolucao.Value.Date.Subtract(dtpLocacao.Value.Date));
            int dias = Convert.ToInt32(diasDeAluguel.Days);

            decimal valorTaxas = 0;

            if (cbPlano.SelectedItem == null)
            {
                return -1;
            }

            decimal valorDiaria = ((PlanoDeCobranca)cbPlano.SelectedItem).ValorDiaria;

            foreach (var item in taxas)
            {
                valorTaxas = +item.Valor;
            }

            return valorTaxas + (dias * valorDiaria);
            
        }
    }
}
