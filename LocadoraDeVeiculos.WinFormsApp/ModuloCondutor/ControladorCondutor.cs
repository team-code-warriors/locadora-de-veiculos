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
        private TabelaCondutoresControl tabelaCondutores;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(ServicoCondutor servicoCondutor)
        {
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            TelaCadastroCondutor tela = new TelaCadastroCondutor();

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

            var funcionarioSelecionado = resultado.Value;

            var tela = new TelaCadastroCondutor();

            tela.Condutor = funcionarioSelecionado.Clonar();

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

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o condutor?", "Exclusão de condutor",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(funcionarioSelecionado);

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
                List<Condutor> condutores = repositorioCondutor.SelecionarTodos();

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
