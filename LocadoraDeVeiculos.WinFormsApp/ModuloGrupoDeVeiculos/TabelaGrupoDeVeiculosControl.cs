using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos
{
    public partial class TabelaGrupoDeVeiculosControl : UserControl
    {
        public TabelaGrupoDeVeiculosControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

            };

            return colunas;
        }

        public int ObtemNumeroTaxaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

        internal void AtualizarRegistros(List<GrupoDeVeiculos> grupos)
        {
            grid.Rows.Clear();

            foreach (var grupoDeVeiculos in grupos)
            {

                grid.Rows.Add(grupoDeVeiculos.Id ,grupoDeVeiculos.Nome);
            }
        }
    }
}
