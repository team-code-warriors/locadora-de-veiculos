using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloGrupoDeVeiculos
{
    public partial class TelaCadastroGrupoDeVeiculos : Form
    {
        public TelaCadastroGrupoDeVeiculos()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        private GrupoDeVeiculos grupo;

        public Func<GrupoDeVeiculos, Result<GrupoDeVeiculos>> GravarRegistro { get; set; }

        public GrupoDeVeiculos Grupo
        {
            get { return grupo; }
            set
            {
                grupo = value;
                textBoxNome.Text = grupo.Nome;
            }
        }
        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            grupo.Nome = textBoxNome.Text;

            var resultadoValidacao = GravarRegistro(grupo);

            if (resultadoValidacao.IsSuccess == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
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

