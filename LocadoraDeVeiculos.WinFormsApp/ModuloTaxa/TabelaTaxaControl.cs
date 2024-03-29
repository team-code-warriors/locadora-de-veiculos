﻿using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxa
{
    public partial class TabelaTaxaControl : UserControl
    {
        public TabelaTaxaControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descricão"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCalculo", HeaderText = "Tipo de Cálculo"},
            };

            return colunas;
        }

        public Guid ObtemNumeroTaxaSelecionada()
        {
            return grid.SelecionarNumero<Guid>();
        }

        internal void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();

            foreach (var taxa in taxas)
            {
                grid.Rows.Add(taxa.Id, taxa.Descricao, taxa.Valor, taxa.TipoCalculo);
            }
        }
    }
}
