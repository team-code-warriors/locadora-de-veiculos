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

        public TelaCadastroDevolucao()
        {
            InitializeComponent();
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
                locacao = value;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
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
    

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            labelValor.Text = "R$ " + CalculaValor();
        }

        private decimal CalculaValor()
        {
            decimal valorDoCombustivel = 0;
            decimal valorDoKmRodado = 0;
            decimal multa = locacao.Valor/10;

            if (dtpDevolucao.Value.Date > locacao.DataDevolucao.Date)
            {
                locacao.Valor = locacao.Valor + multa;
            }

            if (cbNivel.Text != "100" && cbNivel.Text != "0")
            {
                valorDoCombustivel = ((locacao.Veiculo.CapacidadeDoTanque * Convert.ToDecimal(cbNivel.Text)) / 100) * precoGasolina;
                locacao.Valor = locacao.Valor + valorDoCombustivel;
            }

            if (cbNivel.Text == "0")
            {
                valorDoCombustivel = locacao.Veiculo.CapacidadeDoTanque * precoGasolina;
                locacao.Valor = locacao.Valor + valorDoCombustivel;
            }

            valorDoKmRodado = (Convert.ToInt32(tbKm.Text) - locacao.KmCarro) * locacao.Plano.PrecoKm;

            return locacao.Valor + valorDoKmRodado;
        }
    }   
}
