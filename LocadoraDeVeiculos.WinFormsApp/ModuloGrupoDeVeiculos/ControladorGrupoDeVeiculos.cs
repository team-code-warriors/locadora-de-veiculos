using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos
{
    internal class ControladorGrupoDeVeiculos : ControladorBase
    {
        private readonly RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo;
        private TabelaGrupoDeVeiculosControl tabelaGrupo;
        public ControladorGrupoDeVeiculos(RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoDeVeiculos tela = new TelaCadastroGrupoDeVeiculos();
            tela.Grupo = new GrupoDeVeiculos();

            tela.GravarRegistro = repositorioGrupo.Inserir;

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

            tela.GravarRegistro = repositorioGrupo.Editar;

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
