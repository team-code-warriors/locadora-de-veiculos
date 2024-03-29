﻿using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

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

        public Guid ObtemNumeroPlanoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
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
