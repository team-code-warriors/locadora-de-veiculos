using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            GrupoDeVeiculos grupoSelecionado = ObtemTaxaSelecionada();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoDeVeiculos tela = new TelaCadastroGrupoDeVeiculos();

            tela.Grupo = grupoSelecionado.Clonar();

            tela.GravarRegistro = repositorioGrupo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            GrupoDeVeiculos grupoSelecionado = ObtemTaxaSelecionada();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
                "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioGrupo.Excluir(grupoSelecionado);
                CarregarTaxas();
            }
        }

        public override UserControl ObtemListagem()
        {
            //if (tabelaContatos == null)
            tabelaGrupo = new TabelaGrupoDeVeiculosControl();

            CarregarTaxas();

            return tabelaGrupo;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoDeVeiculos();
        }

        private GrupoDeVeiculos ObtemTaxaSelecionada()
        {
            var numero = tabelaGrupo.ObtemNumeroTaxaSelecionada();

            return repositorioGrupo.SelecionarPorId(numero);
        }

        private void CarregarTaxas()
        {
            List<GrupoDeVeiculos> grupos = repositorioGrupo.SelecionarTodos();

            tabelaGrupo.AtualizarRegistros(grupos);

            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s)");

        }
    }
}
