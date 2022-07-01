using LocadoraDeVeiculos.Dominio.ModuloCondutor;
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

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCondutor
{
    public partial class TabelaCondutoresControl : UserControl
    {
        public TabelaCondutoresControl()
        {
            InitializeComponent();

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cnpj", HeaderText = "CNPJ"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataValidadeCnh", HeaderText = "Validade Cnh"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},
            };
            return colunas;
        }

        public int ObtemNumeroCondutorSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        internal void AtualizarRegistros(List<Condutor> condutores)
        {
            grid.Rows.Clear();

            foreach (var condutor in condutores)
            {
                grid.Rows.Add(condutor.Id, condutor.Cliente.Nome, condutor.Cliente.Cpf, condutor.Cliente.Cnpj, condutor.Cnh, condutor.DataValidadeCnh, condutor.Cliente.Email, condutor.Cliente.Telefone, condutor.Cliente.Endereco);
            }
        }
    }
}
