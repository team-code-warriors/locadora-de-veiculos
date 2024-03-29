﻿using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using FluentResults;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        ValidadorRegex validador = new ValidadorRegex();
        public string caminhoFoto = "";

        public TelaCadastroVeiculo(List<GrupoDeVeiculos> grupos)
        {
            InitializeComponent();
            CarregarGrupos(grupos);
            this.ConfigurarTela();
        }

        private Veiculo veiculo;

        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }
            set
            {
                veiculo = value;

                CarregaTela();
            }
        }

        private void CarregaTela()
        {
            tfModelo.Text = veiculo.Modelo;
            tfFabricante.Text = veiculo.Fabricante;
            if (veiculo.Ano == 0)
            {
                tfAno.Text = "";
            }
            else
            {
                tfAno.Text = veiculo.Ano.ToString();
            }
            cbCambio.SelectedItem = veiculo.Cambio;
            tfCor.Text = veiculo.Cor;
            tfPlaca.Text = veiculo.Placa;
            if (veiculo.Kilometragem == 0)
            {
                tfKilometragem.Text = "";
            }
            else
            {
                tfKilometragem.Text = veiculo.Kilometragem.ToString();
            }
            cbCombustivel.SelectedItem = veiculo.TipoDeCombustivel;
            if (veiculo.CapacidadeDoTanque == 0)
            {
                tfCapacidadeDoTanque.Text = "";
            }
            else
            {
                tfCapacidadeDoTanque.Text = veiculo.CapacidadeDoTanque.ToString();
            }
            cbGrupoDeVeiculos.SelectedItem = veiculo.GrupoDeVeiculos;

            if (veiculo.Foto != null)
                CarregaImagem();
        }

        private void CarregaImagem()
        {
            using (var img = new MemoryStream(veiculo.Foto))
            {
                pictureBoxImagem.Image = Image.FromStream(img);
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            veiculo.Fabricante = tfFabricante.Text;

            #region Verificação se o ano está correto
            string anoSemEspaco = tfAno.Text.Replace(" ", "");

            if (anoSemEspaco.Length != 4)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um ano válido no campo 'Ano'");
                DialogResult = DialogResult.None;

                return;
            }
            #endregion

            veiculo.Ano = Convert.ToInt32(tfAno.Text);
            veiculo.Cambio = Convert.ToString(cbCambio.SelectedItem);
            veiculo.Cor = tfCor.Text;

            #region Verificação se a kilometragem esta correta
            string kilometragemSemEspaco = tfKilometragem.Text.Replace(" ", "");

           if(kilometragemSemEspaco.Length == 0)
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'Kilometragem'");
                DialogResult = DialogResult.None;

                return;
            }
            #endregion

            veiculo.Kilometragem = Convert.ToInt32(tfKilometragem.Text);
            veiculo.TipoDeCombustivel = Convert.ToString(cbCombustivel.SelectedItem);
            veiculo.GrupoDeVeiculos = (GrupoDeVeiculos)cbGrupoDeVeiculos.SelectedItem;

            #region Verificações se o modelo e a placa estão corretos
            if (!validador.ApenasLetrasENumeros(tfModelo.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um modelo válido no campo 'Modelo'");
                DialogResult = DialogResult.None;

                return;
            }

            if (!validador.ApenasLetrasENumeros(tfPlaca.Text))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira uma placa válida no campo 'Placa'");
                DialogResult = DialogResult.None;

                return;
            }

            string valorComPonto = tfCapacidadeDoTanque.Text.Replace(",", ".");
            string valorComVirgula = tfCapacidadeDoTanque.Text.Replace(".", ",");

            if (!validador.ApenasNumerosInteirosOuDecimais(valorComPonto))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira uma capacidade válida no campo 'Capacidade do Tanque'");
                DialogResult = DialogResult.None;

                return;
            }

            #endregion

            veiculo.Modelo = tfModelo.Text;
            veiculo.Placa = tfPlaca.Text;
            veiculo.CapacidadeDoTanque = Convert.ToDecimal(valorComVirgula);

            if (caminhoFoto != "")
                veiculo.Foto = GetFoto(caminhoFoto);

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsSuccess == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "|*.jpg; *.jpeg; *.png; *.jfif;";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                caminhoFoto = openFile.FileName;
            }

            if (caminhoFoto != "")
            {
                pictureBoxImagem.Load(caminhoFoto);
            }
        }

        private byte[] GetFoto(string caminhoFoto)
        {
            byte[] imagem;
            using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    imagem = reader.ReadBytes((int)stream.Length);
                }
            }

            return imagem;
        }
    }
}
