using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos
{
    public class ControladorGrupoDeVeiculos : ControladorBase
    {
        private readonly RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo;
        private readonly RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlano = new RepositorioPlanoDeCobrancaEmBancoDeDados();
        private readonly RepositorioVeiculoEmBancoDeDados repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();
        private TabelaGrupoDeVeiculosControl tabelaGrupo;
        private readonly ServicoGrupoDeVeiculo servicoGrupo;
        public ControladorGrupoDeVeiculos(RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo, ServicoGrupoDeVeiculo servicoGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
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
            GrupoDeVeiculos grupoSelecionado = ObtemGrupoSelecionado();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo primeiro",
                "Edição de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoDeVeiculos tela = new TelaCadastroGrupoDeVeiculos();

            tela.Grupo = grupoSelecionado.Clonar();

            tela.GravarRegistro = servicoGrupo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupos();
            }
        }

        public override void Excluir()
        {
            GrupoDeVeiculos grupoSelecionado = ObtemGrupoSelecionado();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo primeiro",
                "Exclusão de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var planos = repositorioPlano.SelecionarTodos();

            foreach (var item in planos)
            {
                if (item.GrupoVeiculo.Nome == grupoSelecionado.Nome)
                {
                    MessageBox.Show("Este Grupo de Veículos esta atrelado a um Plano de Cobrança e não pode ser excluído",
                    "Exclusão de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            var veiculos = repositorioVeiculo.SelecionarTodos();

            foreach (var item in veiculos)
            {
                if (item.GrupoDeVeiculos.Nome == grupoSelecionado.Nome)
                {
                    MessageBox.Show("Este Grupo de Veículos esta atrelado a um Veículo e não pode ser excluído",
                    "Exclusão de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o grupo?",
                "Exclusão de Grupos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioGrupo.Excluir(grupoSelecionado);
                CarregarGrupos();
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaGrupo = new TabelaGrupoDeVeiculosControl();

            CarregarGrupos();

            return tabelaGrupo;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoDeVeiculos();
        }

        private GrupoDeVeiculos ObtemGrupoSelecionado()
        {
            var numero = tabelaGrupo.ObtemNumeroGrupoSelecionado();

            return repositorioGrupo.SelecionarPorId(numero);
        }

        private void CarregarGrupos()
        {
            List<GrupoDeVeiculos> grupos = repositorioGrupo.SelecionarTodos();

            tabelaGrupo.AtualizarRegistros(grupos);

            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s)");

        }
    }
}
