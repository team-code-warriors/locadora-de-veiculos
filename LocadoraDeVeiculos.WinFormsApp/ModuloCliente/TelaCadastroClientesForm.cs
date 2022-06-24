using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
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

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    public partial class TelaCadastroClientesForm : Form
    {
        ValidadorRegex validador = new ValidadorRegex();
        public TelaCadastroClientesForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        private Cliente cliente;

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        public Cliente Cliente
        {
            get 
            { 
                return cliente; 
            }
            set 
            { 
                cliente = value; 

                txtNome.Text = cliente.Nome;
                txtEmail.Text = cliente.Email;
                txtCpf.Text = cliente.Cpf;
                txtTelefone.Text = cliente.Telefone;
                txtCnh.Text = cliente.Cnh;
            }
        }

        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Cnh = txtCnh.Text;

            if (validador.ApenasLetras(txtNome.Text) && validador.ApenasNumeros(txtCpf.Text))
            {
                var resultadoValidacao = GravarRegistro(cliente);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Insira um CPF válido e um nOME válido",
                "Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

                return;
            }
        }
    }
}