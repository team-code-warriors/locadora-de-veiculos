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
            //locacao.Valor = Convert.ToDecimal(labelValor.Text.Replace("R$", ""));

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
            labelValor.Text = "R$0";
        }

        private decimal CalculaValor()
        {
            //int diasDeAluguel = (dtpDevolucao.Value < locacao.DataDevolucao);
            //decimal valorTaxas = 0;

            //decimal valorDiaria = ((PlanoDeCobranca)cbPlano.SelectedItem).ValorDiaria;

            //foreach (var item in taxas)
            //{
            //    valorTaxas = +item.Valor;
            //}

            //return valorTaxas + (diasDeAluguel * valorDiaria);

            return 0;
        }
    }   
}
