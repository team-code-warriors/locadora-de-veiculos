using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
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
    public partial class TabelaPlanoDeCobrancaControl : UserControl
    {
        public TabelaPlanoDeCobrancaControl()
        {
            InitializeComponent();

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculo", HeaderText = "Grupo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoPlano", HeaderText = "Plano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiaria", HeaderText = "Diária"},

                new DataGridViewTextBoxColumn { DataPropertyName = "KmIncluso", HeaderText = "KM Inclu."},

                new DataGridViewTextBoxColumn { DataPropertyName = "PrecoKm", HeaderText = "Preço/KM"},

            };

            return colunas;
        }

        public int ObtemNumeroPlanoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        internal void AtualizarRegistros(List<PlanoDeCobranca> planos)
        {
            grid.Rows.Clear();

            foreach (var planoDeCobranca in planos)
            {
                grid.Rows.Add(planoDeCobranca.Id,
                    planoDeCobranca.GrupoVeiculo,
                    planoDeCobranca.TipoPlano,
                    planoDeCobranca.ValorDiaria,
                    planoDeCobranca.KmIncluso,
                    planoDeCobranca.PrecoKm);
            }
        }
    }
}
