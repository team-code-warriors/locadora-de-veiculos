using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCondutor
{
    public partial class TelaCadastroCondutor : Form
    {
        ValidadorRegex validador = new ValidadorRegex();
        RepositorioClienteEmBancoDeDados repositorioCliente = new RepositorioClienteEmBancoDeDados();

        public TelaCadastroCondutor(List<Cliente> clientes)
        {
            InitializeComponent();
            CarregarClientes(clientes);
            this.ConfigurarTela();
        }

        private Condutor condutor;

        public Func<Condutor, Result<Condutor>> GravarRegistro { get; set; }

        public Condutor Condutor
        {
            get
            {
                return condutor;
            }
            set
            {
                condutor = value;

                CarregaTela();
            }
        }

        private void CarregaTela()
        {
            cbCliente.SelectedItem = condutor.Cliente;
            tfNome.Text = condutor.Nome;
            tfCpf.Text = condutor.Cpf;
            tfCnh.Text = condutor.Cnh;
            //dtpData.Value = DateTime.Now.Date;
            tfEmail.Text = condutor.Email;
            tfTelefone.Text = condutor.Telefone;
            tfEndereco.Text = condutor.Telefone;
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cbCliente.Items.Clear();

            foreach (var item in clientes)
            {
                cbCliente.Items.Add(item);
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            condutor.Cliente = (Cliente)cbCliente.SelectedItem;
            condutor.Nome = tfNome.Text;
            condutor.Cpf = tfCpf.Text;
            condutor.DataValidadeCnh = dtpData.Value;
            condutor.Email = tfEmail.Text;
            condutor.Telefone = tfTelefone.Text;
            condutor.Endereco = tfEndereco.Text;

            #region Verifica se a CNH esta na validade

            if (dtpData.Value < DateTime.Today)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("A 'CNH' está vencida.");
                DialogResult = DialogResult.None;

                return;
            }

            #endregion

            condutor.Cnh = tfCnh.Text;

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void cbxClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex == -1)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Selecione um 'Cliente' primeiro");
                DialogResult = DialogResult.None;

                return;
            }

            if(cbxClienteCondutor.Checked == true)
            {
                BuscarCliente();
            }

            if (cbxClienteCondutor.Checked == false)
            {
                LimparCampos();
            }
        }

        private void LimparCampos()
        {
            tfNome.Clear();
            tfCpf.Clear();
            tfEmail.Clear();
            tfTelefone.Clear();
            tfCnh.Clear();
            tfEndereco.Clear();
        }

        private void BuscarCliente()
        {
            var clientes = repositorioCliente.SelecionarTodos();

            var clienteSelecionado = (Cliente)cbCliente.SelectedItem;

            foreach (var cliente in clientes)
            {
                if (clienteSelecionado.Nome == cliente.Nome)
                {
                    if(clienteSelecionado.Cpf != "              ")
                    {
                        tfNome.Text = cliente.Nome;
                        tfCpf.Text = cliente.Cpf;
                        tfEmail.Text = cliente.Email;
                        tfTelefone.Text = cliente.Telefone;
                        tfEndereco.Text = cliente.Endereco;
                    }
                    else
                    {
                        cbxClienteCondutor.Checked = false;
                        TelaMenuPrincipal.Instancia.AtualizarRodape("Você não pode cadastrar uma Empresa como Condutor. Preencha os dados.");
                        DialogResult = DialogResult.None;

                        return;
                    }

                }
            }
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparCampos();
            cbxClienteCondutor.Checked = false;
        }
    }
}
