using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobrancas : ControladorBase
    {
        private readonly RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlano;
        private readonly RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        private TabelaPlanoDeCobrancaControl tabelaPlano;
        private readonly ServicoPlanoDeCobranca servicoPlano;
        public ControladorPlanoDeCobrancas(RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlano, ServicoPlanoDeCobranca servicoPlano)
        {
            this.repositorioPlano = repositorioPlano;
            this.servicoPlano = servicoPlano;
        }

        public override void Inserir()
        {
            var grupos = repositorioGrupo.SelecionarTodos();

            TelaCadastroPlanoDeCobranca tela = new TelaCadastroPlanoDeCobranca(grupos);
            tela.Plano = new PlanoDeCobranca();

            tela.GravarRegistro = servicoPlano.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Editar()
        {
            PlanoDeCobranca planoSelecionado = ObtemPlanoSelecionado();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Edição de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var grupos = repositorioGrupo.SelecionarTodos();

            TelaCadastroPlanoDeCobranca tela = new TelaCadastroPlanoDeCobranca(grupos);

            tela.Plano = planoSelecionado.Clonar();

            tela.GravarRegistro = servicoPlano.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Excluir()
        {
            PlanoDeCobranca planoSelecionado = ObtemPlanoSelecionado();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Exclusão de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o plano?",
                "Exclusão de Planos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPlano.Excluir(planoSelecionado);
                CarregarPlanos();
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

        private PlanoDeCobranca ObtemPlanoSelecionado()
        {
            var numero = tabelaPlano.ObtemNumeroPlanoSelecionado();

            return repositorioPlano.SelecionarPorId(numero);
        }

        private void CarregarPlanos()
        {
            List<PlanoDeCobranca> planos = repositorioPlano.SelecionarTodos();

            tabelaPlano.AtualizarRegistros(planos);

            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {planos.Count} plano(s)");

        }
    }
}
