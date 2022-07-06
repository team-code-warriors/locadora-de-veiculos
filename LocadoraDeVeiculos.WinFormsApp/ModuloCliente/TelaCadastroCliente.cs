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

                tfNome.Text = cliente.Nome;
                tfEmail.Text = cliente.Email;
                tfEndereco.Text = cliente.Endereco;
                tfCpf.Text = cliente.Cpf;
                tfCnpj.Text = cliente.Cnpj;
                tfTelefone.Text = cliente.Telefone;
            }
        }

        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            #region Verificação se algum radiobutton está selecionado

            if (rbPessoaFisica.Checked == false && rbPessoaJuridica.Checked == false)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Selecione pessoa 'Física' ou pessoa 'Jurídica'.");
                DialogResult = DialogResult.None;

                return;
            }

            #endregion

            cliente.Nome = tfNome.Text;
            cliente.Email = tfEmail.Text;
            cliente.Telefone = tfTelefone.Text;
            cliente.Endereco = tfEndereco.Text;

            #region Verificações se o cpf ou o cnpj está informado

            if (tfCpf.Text == "   ,   ,   -")
            {
                cliente.Cpf = "              ";
            }else
            {
                cliente.Cpf = tfCpf.Text;
            }

            if (tfCnpj.Text == "  ,   ,   /    -")
            {
                cliente.Cnpj = "                  ";
            }else
            {
                cliente.Cnpj = tfCnpj.Text;
            }

            if (cliente.Cnpj == "                  " && cliente.Cpf == "              ")
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Cpf ou Cnpf deve ser informado.");
                DialogResult = DialogResult.None;

                return;
            }

            #endregion

            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void rbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            tfCnpj.Clear();
            tfCnpj.Enabled = false;
            tfCpf.Enabled = true;
        }

        private void rbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            tfCpf.Clear();
            tfCpf.Enabled=false;
            tfCnpj.Enabled = true;
        }
    }
}