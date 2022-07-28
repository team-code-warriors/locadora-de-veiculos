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

        public TelaCadastroDevolucao(Locacao locacao)
        {
            this.locacao = locacao;
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int resultadoComparacaoDatas = (locacao.DataLocacao - dtpDevolucao.Value).Days;
            int resultadoComparacaoKm = (locacao.KmCarro - Convert.ToInt32(tbKm.Text));

            decimal resultadoPrecoKm = locacao.Plano.PrecoKm * resultadoComparacaoKm;
            decimal resultadoDiaria = locacao.Plano.ValorDiaria * resultadoComparacaoDatas;
            decimal resultadoCapacidadeDoTanque = (((locacao.Veiculo.CapacidadeDoTanque * Convert.ToInt32(cbNivel.Text)) / 100) * precoGasolina);

            decimal cont = 0;
            foreach (var item in locacao.Taxas)
            {
                cont =+ item.Valor;
            }

            decimal resultado = resultadoPrecoKm + resultadoDiaria + resultadoCapacidadeDoTanque + cont;

            labelValor.Text = Convert.ToString("R$ "+resultado);
        }
    }   
}
