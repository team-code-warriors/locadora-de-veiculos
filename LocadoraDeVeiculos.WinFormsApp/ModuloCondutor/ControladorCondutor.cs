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
        private readonly RepositorioClienteEmBancoDeDados repositorioCliente = new RepositorioClienteEmBancoDeDados();
        private TabelaCondutoresControl tabelaCondutores;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(ServicoCondutor servicoCondutor)
        {
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
            var id = tabelaCondutores.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            var clientes = repositorioCliente.SelecionarTodos();

            var tela = new TelaCadastroCondutor(clientes);

            tela.Condutor = condutorSelecionado.Clonar();

            tela.GravarRegistro = servicoCondutor.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Excluir()
        {
            var id = tabelaCondutores.ObtemIdCondutorSelecionado();

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o condutor?", "Exclusão de condutor",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(condutorSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCondutores();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            tabelaCondutores = new TabelaCondutoresControl();

            CarregarCondutores();

            return tabelaCondutores;
        }
        private void CarregarCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                tabelaCondutores.AtualizarRegistros(condutores);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
            } 
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
