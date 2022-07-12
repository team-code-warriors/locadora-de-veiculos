using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        public TabelaVeiculoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Fabricante", HeaderText = "Fabricante" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor" },

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoDeVeiculos", HeaderText = "Grupo" },
            };

            return colunas;
        }
        public Guid ObtemNumeroVeiculoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        internal void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();

            foreach (var veiculo in veiculos)
            {
                grid.Rows.Add(veiculo.Id, veiculo.Modelo, veiculo.Fabricante, veiculo.Ano, veiculo.Cor, veiculo.GrupoDeVeiculos.Nome);
            }
        }
    }
}
