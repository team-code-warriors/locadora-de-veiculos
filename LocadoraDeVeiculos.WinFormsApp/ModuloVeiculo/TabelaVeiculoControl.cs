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

                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número" },
            };

            return colunas;
        }
        public int ObtemNumeroVeiculoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
        //internal void AtualizarRegistros(List<Veiculo> veiculo)
        //{
        //    grid.Rows.Clear();

        //    foreach (var Veiculo in veiculo)
        //    {
        //        grid.Rows.Add(veiculo.Id, veiculo.Nome);
        //    }
        //}
    }
}
