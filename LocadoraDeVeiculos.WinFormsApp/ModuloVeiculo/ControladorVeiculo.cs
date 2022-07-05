using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly RepositorioVeiculoEmBancoDeDados repositorioVeiculo;
        private readonly RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        private TabelaVeiculoControl tabelaVeiculo;
        private readonly ServicoVeiculo servicoVeiculo;

        public ControladorVeiculo(RepositorioVeiculoEmBancoDeDados repositorioVeiculo, ServicoVeiculo servicoVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.servicoVeiculo = servicoVeiculo;
        }

        public override void Inserir()
        {
            var grupos = repositorioGrupo.SelecionarTodos();

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo(grupos);
            tela.Veiculo = new Veiculo();

            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Editar()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                "Edição de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var grupos = repositorioGrupo.SelecionarTodos();

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo(grupos);

            tela.Veiculo = veiculoSelecionado.Clonar();

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Excluir()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                "Exclusão de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este veículo?",
                "Exclusão de Veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioVeiculo.Excluir(veiculoSelecionado);
                CarregarVeiculos();
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaVeiculo = new TabelaVeiculoControl();

            CarregarVeiculos();

            return tabelaVeiculo;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }

        private Veiculo ObtemVeiculoSelecionado()
        {
            var numero = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();

            return repositorioVeiculo.SelecionarPorId(numero);
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = repositorioVeiculo.SelecionarTodos();

            tabelaVeiculo.AtualizarRegistros(veiculos);

            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veículo(s)");

        }


    }
}
