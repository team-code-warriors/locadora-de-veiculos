using LocadoraDeVeiculos.Dominio.ModuloCliente;
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
        public TelaCadastroClientesForm()
        {
            InitializeComponent();
        }

        private Cliente cliente;

        public Func<Cliente, Cliente> ClienteFunc { get; set; }

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

            //var resultadoValidacao = gravarRegistro(cliente);

            //if (resultadoValidacao.IsValid == false)
            //{
            //    string erro = resultadoValidacao.Errors[0].ErrorMessage;

            //    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

            //    DialogResult = DialogResult.None;
            //}
        }
    }
}