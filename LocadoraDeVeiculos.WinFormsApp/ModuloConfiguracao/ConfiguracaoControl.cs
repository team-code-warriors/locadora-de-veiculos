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
        public ConfiguracaoControl(ConfiguracaoAplicacao configuracao)
        {
            InitializeComponent();
            this.configuracao = new ConfiguracaoAplicacao();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Configuração gravadas", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
