
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly RepositorioClienteEmBancoDeDados repositorioCliente;
        private TabelaClientesControl tabelaClientes;
        private readonly ServicoCliente servicoCliente;

        public ControladorCliente(RepositorioClienteEmBancoDeDados repositorioCliente, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaCadastroCliente tela = new TelaCadastroCliente();
            tela.Cliente = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Editar()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCliente tela = new TelaCadastroCliente();

            tela.Cliente = clienteSelecionado.Clonar();

            tela.GravarRegistro = servicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Excluir()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este cliente?",
                "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCliente.Excluir(clienteSelecionado);
                CarregarClientes();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            tabelaClientes = new TabelaClientesControl();

            CarregarClientes();

            return tabelaClientes;
        }

        private Cliente ObtemClienteSelecionado()
        {
            var numero = tabelaClientes.ObtemNumeroClienteSelecionado();

            return repositorioCliente.SelecionarPorId(numero);
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientes);

            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");

        }
    }
}
