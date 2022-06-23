using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxa
{
    internal class ControladorTaxa : ControladorBase
    {
        private readonly RepositorioTaxaEmBancoDeDados repositorioTaxa;
        private TabelaTaxaControl tabelaTaxas;
        public ControladorTaxa(RepositorioTaxaEmBancoDeDados repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroTaxa tela = new TelaCadastroTaxa();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = repositorioTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxa tela = new TelaCadastroTaxa();

            tela.Taxa = taxaSelecionada.Clonar();

            tela.GravarRegistro = repositorioTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
                "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
        }

        public override UserControl ObtemListagem()
        {
            //if (tabelaContatos == null)
            tabelaTaxas = new TabelaTaxaControl();

            CarregarTaxas();

            return tabelaTaxas;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxa();
        }

        private Taxa ObtemTaxaSelecionada()
        {
            var numero = tabelaTaxas.ObtemNumeroTaxaSelecionada();

            return repositorioTaxa.SelecionarPorId(numero);
        }

        private void CarregarTaxas()
        {
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();

            tabelaTaxas.AtualizarRegistros(taxas);

            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxa(s)");

        }
    }
}
