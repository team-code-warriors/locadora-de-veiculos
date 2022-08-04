using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly ServicoGrupoDeVeiculo servicoGrupo;
        private TabelaVeiculoControl tabelaVeiculo;
        private readonly ServicoVeiculo servicoVeiculo;

        public ControladorVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupoDeVeiculo servicoGrupo)
        {
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupo = servicoGrupo;
        }

        public override void Inserir()
        {
            var resultadoSelecaoGrupos = servicoGrupo.SelecionarTodos();

            if (resultadoSelecaoGrupos.IsFailed)
            {
                string erro = resultadoSelecaoGrupos.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo(resultadoSelecaoGrupos.Value);

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
            var id = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                "Edição de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);
            
            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            var resultadoSelecaoGrupos = servicoGrupo.SelecionarTodos();

            if (resultadoSelecaoGrupos.IsFailed)
            {
                string erro = resultadoSelecaoGrupos.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo(resultadoSelecaoGrupos.Value);

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarVeiculos();
            
        }

        public override void Excluir()
        {
            var id = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                "Exclusão de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir este veículo?",
                "Exclusão de Veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();

                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }
        public override UserControl ObtemListagem()
        {
            tabelaVeiculo = new TabelaVeiculoControl();

            CarregarVeiculos();

            return tabelaVeiculo;
        }
        private void CarregarVeiculos()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veículo(s)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
