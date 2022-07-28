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
        public DateTime dataLocacao;
        public decimal valorDiaria;
        public int KmCarro;
        public decimal PrecoKm;
        public decimal CapacidadeDoTanque;
        public decimal PrecoGasolina = 5;
        public List<Taxa> Taxas;

        public TelaCadastroDevolucao(Locacao locacao)
        {
            locacao.DataLocacao = dataLocacao;
            locacao.Plano.ValorDiaria = valorDiaria;
            locacao.KmCarro = KmCarro;
            locacao.Plano.PrecoKm = PrecoKm;
            locacao.Veiculo.CapacidadeDoTanque = CapacidadeDoTanque;

            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int resultadoComparacaoDatas = (dataLocacao - dtpDevolucao.Value).Days;
            int resultadoComparacaoKm = (KmCarro - Convert.ToInt32(tbKm.Text));

            decimal resultadoPrecoKm = PrecoKm * resultadoComparacaoKm;
            decimal resultadoDiaria = valorDiaria * resultadoComparacaoDatas;
            decimal resultadoCapacidadeDoTanque = (((CapacidadeDoTanque * Convert.ToInt32(cbNivel.Text)) / 100) * PrecoGasolina);

            decimal cont = 0;
            foreach (var item in Taxas)
            {
                cont =+ item.Valor;
            }

            decimal resultado = resultadoPrecoKm + resultadoDiaria + resultadoCapacidadeDoTanque + cont;

            labelValor.Text = Convert.ToString("R$ "+resultado);
        }
    }   
}
