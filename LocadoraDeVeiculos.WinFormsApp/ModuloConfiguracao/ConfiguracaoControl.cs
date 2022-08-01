using LocadoraDeVeiculos.Infra.Configs;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloConfiguracao
{
    public partial class ConfiguracaoControl : UserControl
    {
        private ConfiguracaoAplicacao configuracao;
        ValidadorRegex validador = new ValidadorRegex();
        string valorAux = "";

        public ConfiguracaoControl(ConfiguracaoAplicacao configuracao)
        {
            InitializeComponent();
            this.configuracao = new ConfiguracaoAplicacao();
            CarregarValorGasolina();
            CarregarLog();
        }

        private void CarregarLog()
        {
            txtDiretorioLogs.Text = configuracao.ConfiguracaoLogs.DiretorioSaida;
            tbConnection.Text = configuracao.ConnectionStrings.SqlServer;
        }

        private void CarregarValorGasolina()
        {
            textBoxValor.Text = configuracao.ConfiguracaoPrecoGasolina.PrecoGasolina;
            txtDiretorioLogs.Text = configuracao.ConfiguracaoLogs.DiretorioSaida;
            tbConnection.Text = configuracao.ConnectionStrings.SqlServer;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            #region valida valor
            string valorComPonto = textBoxValor.Text.Replace(",", ".");

            if (!validador.ApenasNumerosInteirosOuDecimais(valorComPonto))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira um número válido no campo 'Valor da Gasolina'.");

                return;
            }
            #endregion

            configuracao.ConfiguracaoPrecoGasolina.PrecoGasolina = textBoxValor.Text;

            string caminho = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caminhoJson = Path.Combine(caminho, "ConfiguracaoAplicacao.json");

            string json = JsonConvert.SerializeObject(configuracao, Formatting.Indented);
            File.WriteAllText(caminhoJson, json);

            MessageBox.Show("Configuração gravadas. Reinicie a aplicação para carregar o(s) novo(s) valor(es).", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
