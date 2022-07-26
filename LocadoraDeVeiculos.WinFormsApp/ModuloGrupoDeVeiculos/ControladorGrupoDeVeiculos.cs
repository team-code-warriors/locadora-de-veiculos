using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos
{
    public class ControladorGrupoDeVeiculos : ControladorBase
    {
        private TabelaGrupoDeVeiculosControl tabelaGrupo;
        private readonly ServicoGrupoDeVeiculo servicoGrupo;
        public ControladorGrupoDeVeiculos(ServicoGrupoDeVeiculo servicoGrupo)
        {
            this.servicoGrupo = servicoGrupo;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoDeVeiculos tela = new TelaCadastroGrupoDeVeiculos();
            tela.Grupo = new GrupoDeVeiculos();

            tela.GravarRegistro = servicoGrupo.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupos();
            }
        }

        public override void Editar()
        {
            var id = tabelaGrupo.ObtemNumeroGrupoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo primeiro",
                "Edição de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoGrupo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultadoSelecao.Value;

            var tela = new TelaCadastroGrupoDeVeiculos();

            tela.Grupo = grupoSelecionado;

            tela.GravarRegistro = servicoGrupo.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Excluir()
        {
            var id = tabelaGrupo.ObtemNumeroGrupoSelecionado();

            var resultadoSelecao = servicoGrupo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultadoSelecao.Value;

            if(MessageBox.Show("Dseja realmente excluir o Grupo de Veículo?", "Exclusão de Grupo de Veículos",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupo.Excluir(grupoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Grupos de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoDeVeiculos();
        }
        public override UserControl ObtemListagem()
        {
            tabelaGrupo = new TabelaGrupoDeVeiculosControl();

            CarregarGrupos();

            return tabelaGrupo;
        }
        private void CarregarGrupos()
        {
            var resultado = servicoGrupo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<GrupoDeVeiculos> grupos = resultado.Value;

                tabelaGrupo.AtualizarRegistros(grupos);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {grupos.Count} veículos");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
