using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private TabelaFuncionarioControl tabelaFuncionarios;
        private readonly ServicoFuncionario servicoFuncionario;
        public ControladorFuncionario(ServicoFuncionario servicoFuncionario)
        {
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroFuncionario();

            tela.Funcionario = new Funcionario();

            tela.GravarRegistro = servicoFuncionario.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public override void Editar()
        {
            var id = tabelaFuncionarios.ObtemNumeroFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoFuncionario.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            var tela = new TelaCadastroFuncionario();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = servicoFuncionario.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            var id = tabelaFuncionarios.ObtemNumeroFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoFuncionario.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o funcionário?", "Exclusão de Funcionário",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionarios();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaFuncionarios = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return tabelaFuncionarios;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxFuncionario();
        }

        private void CarregarFuncionarios()
        {
            var resultado = servicoFuncionario.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Funcionario> funcionarios = resultado.Value;

                tabelaFuncionarios.AtualizarRegistros(funcionarios);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Funcionário",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

