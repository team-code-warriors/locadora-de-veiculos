using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxa
{
    internal class ControladorTaxa : ControladorBase
    {
        private TabelaTaxaControl tabelaTaxas;
        private readonly ServicoTaxa servicoTaxa;
        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroTaxa();

            tela.Taxa = new Taxa();

            tela.GravarRegistro = servicoTaxa.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                    "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultado.Value;

            var tela = new TelaCadastroTaxa();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = servicoTaxa.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoTaxa.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a taxa?", "Exclusão de Taxa",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoTaxa.Excluir(taxaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxas();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   

        public override UserControl ObtemListagem()
        {
            tabelaTaxas = new TabelaTaxaControl();

            CarregarTaxas();

            return tabelaTaxas;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxa();
        }

        private void CarregarTaxas()
        {
            var resultado = servicoTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxa> taxas = resultado.Value;

                tabelaTaxas.AtualizarRegistros(taxas);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxa(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Taxa",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
