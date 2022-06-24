using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
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

namespace LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionario : Form
    {
        ValidadorRegex validador = new ValidadorRegex();
        RepositorioFuncionarioEmBancoDeDados repositorio = new RepositorioFuncionarioEmBancoDeDados();
        public TelaCadastroFuncionario()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        private Funcionario funcionario;

        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set
            {
                funcionario = value;

                tbNumero.Text = funcionario.Id.ToString();
                tbNome.Text = funcionario.Nome;
                if (funcionario.Salario == 0)
                {
                    tbSalario.Text = "";
                }
                else
                {
                    tbSalario.Text = funcionario.Salario.ToString();
                }
                dtpData.Value = DateTime.Now.Date;
                tbLogin.Text = funcionario.Login;
                tbSenha.Text = funcionario.Senha;
                cbTipoPerfil.SelectedItem = funcionario.TipoPerfil;
            }
        }

        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            funcionario.Nome = tbNome.Text;
            funcionario.Login = tbLogin.Text;

            if (validador.ApenasNumeros(tbSalario.Text) && validador.ApenasLetras(tbNome.Text))
            {
                funcionario.Salario = Convert.ToDouble(tbSalario.Text);
                funcionario.DataAdmissao = dtpData.Value;
                funcionario.Senha = tbSenha.Text;
                funcionario.TipoPerfil = (string)cbTipoPerfil.SelectedItem;

                var resultadoValidacao = GravarRegistro(funcionario);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Insira um número válido no campo 'Salário' e um nome válido no campo 'Nome'",
                "Cadastro de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

                return;
            }
        }

        private void TelaCadastroContatosForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroContatosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }
    }
}
