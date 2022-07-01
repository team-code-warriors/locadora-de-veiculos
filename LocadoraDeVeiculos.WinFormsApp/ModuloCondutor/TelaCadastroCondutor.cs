using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
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

        public TelaCadastroCondutor(List<Cliente> clientes)
        {
            InitializeComponent();
            CarregarClientes(clientes);
            PreencherCampos(clientes);
            this.ConfigurarTela();

            dtpData.MaxDate = DateTime.Now.Date;
        }

        public TelaCadastroCondutor()
        {
            InitializeComponent();
            this.ConfigurarTela();

            dtpData.MaxDate = DateTime.Now.Date;
        }

        private Condutor condutor;

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        public Condutor Condutor
        {
            get
            {
                return condutor;
            }
            set
            {
                condutor = value;

                tfNome.Text = Condutor.Cliente.Nome;
                tfCpf.Text = Condutor.Cliente.Cpf;
                tfCnh.Text = Condutor.Cnh;
                dtpData.Value = DateTime.Now.Date;
                tfEmail.Text = Condutor.Cliente.Email;
                tfTelefone.Text = Condutor.Cliente.Telefone;
                tfEndereco.Text = Condutor.Cliente.Endereco;
            }
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cbCliente.Items.Clear();

            foreach (var item in clientes)
            {
                cbCliente.Items.Add(item);
            }
        }

        public void PreencherCampos(List<Cliente> clientes)
        {
            if (cbCliente.Items.Count == 0 && cbxClienteCondutor.Checked)
            {
                foreach (var c in clientes)
                {
                    tfNome.Text = c.Nome;
                    //tfCpfCnpj.Text = c.Cpf;
                    //tfCpfCnpj.Text = c.Cnpj;
                    tfEmail.Text = c.Email;
                    tfTelefone.Text = c.Telefone;
                    tfEndereco.Text = c.Endereco;
                }
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            condutor.Cliente.Nome = tfNome.Text;
            //condutor.Cliente.Cpf = tfCpfCnpj.Text;
            //condutor.Cliente.Cnpj = tfCpfCnpj.Text;
            condutor.Cnh = tfCnh.Text;
            condutor.DataValidadeCnh = dtpData.Value;
            condutor.Cliente.Email = tfEmail.Text;
            condutor.Cliente.Telefone = tfTelefone.Text;
            condutor.Cliente.Endereco = tfEndereco.Text;

            if (!validador.ApenasNumerosInteiros(tfCnh.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'CNH'");
                DialogResult = DialogResult.None;

                return;
            }

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        } 
    }
}
