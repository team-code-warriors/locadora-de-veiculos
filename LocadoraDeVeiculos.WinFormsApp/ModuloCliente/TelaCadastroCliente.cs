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
            cliente.Nome = tfNome.Text;
            cliente.Email = tfEmail.Text;
            cliente.Endereco = tfEndereco.Text;
            cliente.Cpf = tfCpf.Text;
            cliente.Cnpj = tfCnpj.Text;
            cliente.Telefone = tfTelefone.Text;

            if(!validador.ApenasLetras(tfNome.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um nome válido no campo 'Nome'");
                DialogResult = DialogResult.None;

                return;
            }

            //if (!validador.ApenasNumeros(tfCnh.Text))
            //{
            //    TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'CNH'");
            //    DialogResult = DialogResult.None;

            //    return;
            //}

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

            tfCnpj.Enabled = false;
            tfCpf.Enabled = true;
        }

        private void rbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {

            tfCpf.Enabled=false;
            tfCnpj.Enabled = true;
        }
    }
}