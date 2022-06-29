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
        private readonly RepositorioFuncionarioEmBancoDeDados repositorioFuncionario;
        private TabelaFuncionarioControl tabelaFuncionarios;
        public ControladorFuncionario(RepositorioFuncionarioEmBancoDeDados repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();
            tela.Funcionario = new Funcionario();

            tela.GravarRegistro = repositorioFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public override void Editar()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Edição de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();

            tela.Funcionario = funcionarioSelecionado.Clonar();

            tela.GravarRegistro = repositorioFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public override void Excluir()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Exclusão de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o funcionário?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionarios();
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

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var numero = tabelaFuncionarios.ObtemNumeroFuncionarioSelecionado();

            return repositorioFuncionario.SelecionarPorId(numero);
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionarios.AtualizarRegistros(funcionarios);

            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");

        }
    }

}

