using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobrancas;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Configs;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TabelaLocacaoControl tabelaLocacoes;
        private readonly ServicoLocacao servicoLocacao;
        private readonly ServicoFuncionario servicoFuncionario;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoVeiculo servicoVeiculo;
        private readonly ServicoPlanoDeCobranca servicoPlano;
        private readonly ServicoTaxa servicoTaxa;
        ConfiguracaoAplicacao configuracao;

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoFuncionario servicoFuncionario, ServicoCondutor servicoCondutor, ServicoVeiculo servicoVeiculo, ServicoPlanoDeCobranca servicoPlano, ServicoTaxa servicoTaxa, ConfiguracaoAplicacao configuracao)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoFuncionario = servicoFuncionario;
            this.servicoCondutor = servicoCondutor;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoPlano = servicoPlano;
            this.servicoTaxa = servicoTaxa;
            this.configuracao = configuracao;
        }

        public override void Excluir()
        {
            var id = tabelaLocacoes.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                    "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?", "Exclusão de Locação",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Inserir()
        {
            var resultadoSelecaoFuncionarios = servicoFuncionario.SelecionarTodos();

            if (resultadoSelecaoFuncionarios.IsFailed)
            {
                string erro = resultadoSelecaoFuncionarios.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoCondutores = servicoCondutor.SelecionarTodos();

            if (resultadoSelecaoCondutores.IsFailed)
            {
                string erro = resultadoSelecaoCondutores.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoVeiculos = servicoVeiculo.SelecionarTodos();

            if (resultadoSelecaoVeiculos.IsFailed)
            {
                string erro = resultadoSelecaoVeiculos.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoPlanos = servicoPlano.SelecionarTodos();

            if (resultadoSelecaoPlanos.IsFailed)
            {
                string erro = resultadoSelecaoPlanos.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoTaxas = servicoTaxa.SelecionarTodos();

            if (resultadoSelecaoTaxas.IsFailed)
            {
                string erro = resultadoSelecaoTaxas.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroLocacao tela = new TelaCadastroLocacao(
                resultadoSelecaoFuncionarios.Value,
                resultadoSelecaoCondutores.Value,
                resultadoSelecaoVeiculos.Value,
                resultadoSelecaoPlanos.Value,
                resultadoSelecaoTaxas.Value);

            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarLocacoes();
            }
        }

        private void CarregarLocacoes()
        {
            var resultado = servicoLocacao.SelecionarPorLocacaoAtivaEInativa();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                tabelaLocacoes.AtualizarRegistros(locacoes);

                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} locação(ões)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void GerarPdf()
        {
            var id = tabelaLocacoes.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locaçãp primeiro",
                "Edição de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            string diretorio = @"C:\Pdf\";

            if (!System.IO.Directory.Exists(diretorio))
                System.IO.Directory.CreateDirectory(diretorio);

            var tituloTexto = $"Locação de - {locacaoSelecionada.Condutor}";

            Document doc = new Document(PageSize.A4);
            doc.SetMargins(20, 20, 20, 50);

            string caminhoEArquivo = diretorio + locacaoSelecionada.Condutor.Nome + ".pdf";

            if (File.Exists(caminhoEArquivo) == true)
                File.Delete(caminhoEArquivo);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoEArquivo, FileMode.Create));

            doc.Open();


            Paragraph titulo = new Paragraph();
            titulo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add($"{tituloTexto}\n\n");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));
            string conteudo = $"\nId: {locacaoSelecionada.Id}\n" +
                               $"Funcionário: {locacaoSelecionada.Funcionario}\n" +
                               $"Condutor: {locacaoSelecionada.Condutor}\n" +
                               $"Veículo: {locacaoSelecionada.Veiculo}\n" +
                               $"Plano: {locacaoSelecionada.Plano}\n" +
                               $"Dt. de Locação: {locacaoSelecionada.DataLocacao}\n" +
                               $"Dt. de Devolução Prevista: {locacaoSelecionada.DataDevolucao}\n" +
                               $"Km's Rodados: {locacaoSelecionada.Veiculo.Kilometragem}\n" +
                               $"Valor Previsto: {locacaoSelecionada.Valor}\n";

            conteudo = conteudo + "Taxas:\n";

            foreach (var taxa in locacaoSelecionada.Taxas)
            {
                conteudo = conteudo + taxa.Descricao + "\n";
            }
            
            conteudo = conteudo + $"Status da Locação: {locacaoSelecionada.Status}";

            conteudo = conteudo + "\n\n\n\n";

            paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16);
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table1 = new PdfPTable(1);
            table1.AddCell($"\nId:\n {locacaoSelecionada.Id}\n\t");
            PdfPTable tableCondutor = new PdfPTable(1);
            table1.AddCell($"\nCondutor: \n{locacaoSelecionada.Condutor}\n\t");

            PdfPTable tableVeiculo = new PdfPTable(1);
            tableVeiculo.AddCell($"Veículo: \n{locacaoSelecionada.Veiculo}\t");

            PdfPTable table2 = new PdfPTable(2);
            table2.AddCell($"Km's Rodados: \n{locacaoSelecionada.Veiculo.Kilometragem}\t");

            PdfPTable table3 = new PdfPTable(2);
            table3.AddCell($"Plano:  {locacaoSelecionada.Plano}\t");
            table3.AddCell($"Valor Previsto:  {locacaoSelecionada.Valor:c}\t");

            PdfPTable table4 = new PdfPTable(1);
            table4.AddCell($"Data de Locação: {locacaoSelecionada.DataLocacao}\t");

            PdfPTable tableDevolutiva = new PdfPTable(1);
            tableDevolutiva.AddCell($"Data de Devolução Prevista: {locacaoSelecionada.DataDevolucao}\t");

            doc.Add(table1);
            doc.Add(table2);
            doc.Add(table3);
            doc.Add(table4);
            doc.Add(tableCondutor);
            doc.Add(tableDevolutiva);
            doc.Add(tableVeiculo);

            doc.Close();

            var processo = new Process();
            processo.StartInfo = new ProcessStartInfo(diretorio)
            {
                UseShellExecute = true
            };
            processo.Start();
        }

        public override void Devolver()
        {
            var id = tabelaLocacoes.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                    "Cadastro de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Cadastro de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            var resultadoSelecaoTaxas = servicoTaxa.SelecionarTodos();

            if (resultadoSelecaoTaxas.IsFailed)
            {
                string erro = resultadoSelecaoTaxas.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroDevolucao tela = new TelaCadastroDevolucao(resultadoSelecaoTaxas.Value, locacaoSelecionada, configuracao);

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = servicoLocacao.Devolver;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacoes();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            tabelaLocacoes = new TabelaLocacaoControl();

            CarregarLocacoes();

            return tabelaLocacoes;
        }
    }
}
