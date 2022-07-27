using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly ServicoCliente servicoCliente;
        private TabelaCondutoresControl tabelaCondutores;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(ServicoCondutor servicoCondutor, ServicoCliente servicoCliente)
        {
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            var resultadoSelecaoClientes = servicoCliente.SelecionarTodos();

            if (resultadoSelecaoClientes.IsFailed)
            {
                string erro = resultadoSelecaoClientes.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroCondutor tela = new TelaCadastroCondutor(resultadoSelecaoClientes.Value);

            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Editar()
        {
            var id = tabelaCondutores.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            var resultadoSelecaoClientes = servicoCliente.SelecionarTodos();

            if (resultadoSelecaoClientes.IsFailed)
            {
                string erro = resultadoSelecaoClientes.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroCondutor tela = new TelaCadastroCondutor(resultadoSelecaoClientes.Value);

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = servicoCondutor.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Excluir()
        {
            var id = tabelaCondutores.ObtemIdCondutorSelecionado();

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o condutor?", "Exclusão de condutor",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(condutorSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCondutores();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            tabelaCondutores = new TabelaCondutoresControl();

            CarregarCondutores();

            return tabelaCondutores;
        }
        private void CarregarCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                tabelaCondutores.AtualizarRegistros(condutores);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
            } 
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
