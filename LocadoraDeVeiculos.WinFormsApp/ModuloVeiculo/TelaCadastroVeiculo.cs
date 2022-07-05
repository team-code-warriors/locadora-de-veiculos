using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
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

namespace LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        ValidadorRegex validador = new ValidadorRegex();
        RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();

        public TelaCadastroVeiculo(List<GrupoDeVeiculos> grupos)
        {
            InitializeComponent();
            CarregarGrupos(grupos);
            this.ConfigurarTela();
        }

        private Veiculo veiculo;

        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }
            set
            {
                veiculo = value;

                tfModelo.Text = veiculo.Modelo;
                tfFabricante.Text = veiculo.Fabricante;
                tfAno.Text = veiculo.Ano.ToString();
                cbCambio.SelectedItem = veiculo.Cambio;
                tfCor.Text = veiculo.Cor;
                tfPlaca.Text = veiculo.Placa;
                tfKilometragem.Text = veiculo.Kilometragem.ToString();
                cbCombustivel.SelectedItem = veiculo.TipoDeCombustivel;
                tfCapacidadeDoTanque.Text = veiculo.CapacidadeDoTanque.ToString();
                cbGrupoDeVeiculos.SelectedItem = veiculo.GrupoDeVeiculos;
            }
        }


        private void CarregarGrupos(List<GrupoDeVeiculos> grupos)
        {
            cbGrupoDeVeiculos.Items.Clear();

            foreach (var item in grupos)
            {
                cbGrupoDeVeiculos.Items.Add(item);
            }
        }

        private void ValidaCampos()
        {
            //if (!validador.ApenasLetrasENumeros(tfModelo.Text))
            //{
            //    TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um modelo válido no campo 'Modelo'");
            //    DialogResult = DialogResult.None;

            //    return;
            //}


            if (!validador.ApenasLetras(tfFabricante.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um fabricante válido no campo 'Fabricante'");
                DialogResult = DialogResult.None;

                return;
            }

            if (!validador.ApenasLetras(tfCor.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira uma cor válida no campo 'Cor'");
                DialogResult = DialogResult.None;

                return;
            }

            //if (!validador.ApenasLetrasENumeros(tfPlaca.Text))
            //{
            //    TelaMenuPrincipal.Instancia.AtualizarRodape("Insira uma placa válida no campo 'Placa'");
            //    DialogResult = DialogResult.None;

            //    return;
            //}


            if (!validador.ApenasNumerosInteiros(tfKilometragem.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira uma kilometragem válida no campo 'Kilometragem'");
                DialogResult = DialogResult.None;

                return;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            veiculo.Modelo = tfModelo.Text;
            veiculo.Fabricante = tfFabricante.Text;
            veiculo.Ano = Convert.ToInt32(tfAno.Text);
            veiculo.Cambio = Convert.ToString(cbCambio.SelectedItem);
            veiculo.Cor = tfCor.Text;
            veiculo.Placa = tfPlaca.Text;
            veiculo.Kilometragem = Convert.ToInt32(tfKilometragem.Text);
            veiculo.TipoDeCombustivel = Convert.ToString(cbCombustivel.SelectedItem);
            veiculo.GrupoDeVeiculos = (GrupoDeVeiculos)cbGrupoDeVeiculos.SelectedItem;

            ValidaCampos();
            string valorComPonto = tfCapacidadeDoTanque.Text.Replace(",", ".");
            string valorComVirgula = tfCapacidadeDoTanque.Text.Replace(".", ",");

            if (!validador.ApenasNumerosInteirosOuDecimais(valorComPonto))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira uma capacidade válida no campo 'Capacidade do Tanque'");
                DialogResult = DialogResult.None;

                return;
            }

            veiculo.CapacidadeDoTanque = Convert.ToDecimal(valorComVirgula);

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
