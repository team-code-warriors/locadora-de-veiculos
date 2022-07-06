using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {

        private readonly RepositorioCondutorEmBancoDeDados repositorioCondutor;
        private readonly RepositorioClienteEmBancoDeDados repositorioCliente = new RepositorioClienteEmBancoDeDados();
        private TabelaCondutoresControl tabelaCondutor;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(RepositorioCondutorEmBancoDeDados repositorioCondutor, ServicoCondutor servicoCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            var clientes = repositorioCliente.SelecionarTodos();

            TelaCadastroCondutor tela = new TelaCadastroCondutor(clientes);
            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Editar()
        {
            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var clientes = repositorioCliente.SelecionarTodos();

            TelaCadastroCondutor tela = new TelaCadastroCondutor(clientes);

            tela.Condutor = condutorSelecionado.Clonar();

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Excluir()
        {
            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este condutor?",
                "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCondutor.Excluir(condutorSelecionado);
                CarregarCondutores();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            tabelaCondutor = new TabelaCondutoresControl();

            CarregarCondutores();

            return tabelaCondutor;
        }

        private Condutor ObtemCondutorSelecionado()
        {
            var numero = tabelaCondutor.ObtemNumeroCondutorSelecionado();

            return repositorioCondutor.SelecionarPorId(numero);
        }

        private void CarregarCondutores()
        {
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos();

            tabelaCondutor.AtualizarRegistros(condutores);

            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");

        }
    }
}
