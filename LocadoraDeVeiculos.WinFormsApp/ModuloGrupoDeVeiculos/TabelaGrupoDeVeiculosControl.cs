using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;


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

        public Guid ObtemNumeroGrupoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
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
