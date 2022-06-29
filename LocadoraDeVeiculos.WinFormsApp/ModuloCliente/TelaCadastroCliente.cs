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
    public partial class TelaCadastroCliente : Form
    {
        ValidadorRegex validador = new ValidadorRegex();
        public TelaCadastroCliente()
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
                txtEndereco.Text = cliente.Endereco;
                txtCpf.Text = cliente.Cpf;
                txtTelefone.Text = cliente.Telefone;
                txtCnh.Text = cliente.Cnh;
            }
        }

        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Cnh = txtCnh.Text;

            if(!validador.ApenasLetras(txtNome.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um nome válido no campo 'Nome'");
                DialogResult = DialogResult.None;

                return;
            }

            if (!validador.ApenasNumeros(txtCnh.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'CNH'");
                DialogResult = DialogResult.None;

                return;
            }

            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }
    }
}