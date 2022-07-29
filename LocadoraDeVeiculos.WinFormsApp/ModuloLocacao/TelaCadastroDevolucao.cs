using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
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
    public partial class TelaCadastroDevolucao : Form
    {
        Locacao locacao;
        private const decimal precoGasolina = 5;
        int countClickBotaoCalcular = 0;
        string kilometragemSemEspaco = "";

        public TelaCadastroDevolucao(List<Taxa> taxas, Locacao locacao)
        {
            InitializeComponent();
            dtpDevolucao.MinDate = DateTime.Today.Date;
            CarregarTaxas(taxas);
            CarregarTaxasJaAdicionadas(locacao);
        }

        private void CarregarTaxas(List<Taxa> taxas)
        {
            cbTaxa.Items.Clear();

            foreach (var item in taxas)
            {
                cbTaxa.Items.Add(item);
            }
        }

        private void CarregarTaxasJaAdicionadas(Locacao locacao)
        {
            foreach (var item in locacao.Taxas)
            {
                listTaxas.Items.Add(item);
            }
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }
        public Locacao Locacao
        {
            get
            {
                return locacao;
            }
            set
            {
                tbKm.Text = "";
                locacao = value;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (countClickBotaoCalcular != 0)
            {
                if (Convert.ToInt32(kilometragemSemEspaco) < locacao.KmCarro)
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape("'Km do Carro' deve ser maior ou igual do que quando retirado na locadora");
                    DialogResult = DialogResult.None;
                    return;
                }

                var resultadoValidacao = GravarRegistro(locacao);

                if (resultadoValidacao.IsFailed)
                {
                    string erro = resultadoValidacao.Errors[0].Message;

                    if (erro.StartsWith("Falha no sistema"))
                    {
                        MessageBox.Show(erro,
                        "Inserção de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                        DialogResult = DialogResult.None;
                    }
                }
            }
            else
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Calcule o valor da devolução antes de cadastra-lá");
                DialogResult = DialogResult.None;
            }
        }
    

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (CalculaValor() == -1)
                return;

            countClickBotaoCalcular = countClickBotaoCalcular + 1;
            labelValor.Text = "R$ " + CalculaValor();
        }

        private decimal CalculaValor()
        {
            decimal valorDoCombustivel = 0;
            decimal valorDoKmRodado = 0;

            #region Verificação se a kilometragem esta correta
            kilometragemSemEspaco = tbKm.Text.Replace(" ", "");

            if (kilometragemSemEspaco.Length == 0)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'KM do Carro'");
                DialogResult = DialogResult.None;

                return -1;
            }

            if (cbNivel.SelectedIndex == -1)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Selecione o nível do tanque");
                DialogResult = DialogResult.None;

                return -1;
            }
            #endregion

            if (cbNivel.Text != "100" && cbNivel.Text != "0")
            {
                valorDoCombustivel = ((locacao.Veiculo.CapacidadeDoTanque * (100 - Convert.ToDecimal(cbNivel.Text))) / 100) * precoGasolina;
                locacao.Valor = locacao.Valor + valorDoCombustivel;
            }

            if (cbNivel.Text == "0")
            {
                valorDoCombustivel = locacao.Veiculo.CapacidadeDoTanque * precoGasolina;
                locacao.Valor = locacao.Valor + valorDoCombustivel;
            }

            valorDoKmRodado = (Convert.ToInt32(tbKm.Text) - locacao.KmCarro) * locacao.Plano.PrecoKm;
            locacao.Valor = locacao.Valor + valorDoKmRodado;

            decimal multa = locacao.Valor / 10;

            if (dtpDevolucao.Value.Date > locacao.DataDevolucao.Date)
            {
                locacao.Valor = locacao.Valor + multa;
            }

            return locacao.Valor;
        }

        private void btnAdicionarTaxa_Click(object sender, EventArgs e)
        {
            if(cbTaxa.SelectedIndex == -1)
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
            locacao.Taxas.Add((Taxa)cbTaxa.SelectedItem);
            locacao.Valor = locacao.Valor + ((Taxa)cbTaxa.SelectedItem).Valor;
            cbTaxa.SelectedIndex = -1;
        }
    }   
}
