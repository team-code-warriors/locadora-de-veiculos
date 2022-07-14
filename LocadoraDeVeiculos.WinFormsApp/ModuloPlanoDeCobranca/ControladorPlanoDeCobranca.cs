using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobrancas : ControladorBase
    {
        private readonly RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        private TabelaPlanoDeCobrancaControl tabelaPlano;
        private readonly ServicoPlanoDeCobranca servicoPlano;
        public ControladorPlanoDeCobrancas(ServicoPlanoDeCobranca servicoPlano)
        {
            this.servicoPlano = servicoPlano;
        }

        public override void Inserir()
        {
            var grupos = repositorioGrupo.SelecionarTodos();

            var tela = new TelaCadastroPlanoDeCobranca(grupos);

            tela.Plano = new PlanoDeCobranca();

            tela.GravarRegistro = servicoPlano.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Editar()
        {
            var id = tabelaPlano.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                    "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlano.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultado.Value;

            var grupos = repositorioGrupo.SelecionarTodos();

            var tela = new TelaCadastroPlanoDeCobranca(grupos);

            tela.Plano = planoSelecionado.Clonar();

            tela.GravarRegistro = servicoPlano.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanos();
        }

        public override void Excluir()
        {
            var id = tabelaPlano.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                    "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoPlano.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Plano de Cobraça", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano?", "Exclusão de Plano de Cobrança",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlano.Excluir(planoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Plano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaPlano = new TabelaPlanoDeCobrancaControl();

            CarregarPlanos();

            return tabelaPlano;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoDeCobranca();
        }

        private void CarregarPlanos()
        {
            var resultado = servicoPlano.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoDeCobranca> planos = resultado.Value;

                tabelaPlano.AtualizarRegistros(planos);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {planos.Count} plano(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Plano de Cobrança",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
