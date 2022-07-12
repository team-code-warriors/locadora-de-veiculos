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

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cnh", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-mail"},

            };
            return colunas;
        }

        public Guid ObtemNumeroCondutorSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        internal void AtualizarRegistros(List<Condutor> condutores)
        {
            grid.Rows.Clear();

            foreach (var condutor in condutores)
            {
                grid.Rows.Add(condutor.Id, condutor.Cliente.Nome, condutor.Nome, condutor.Cpf, condutor.Cnh, condutor.Telefone, condutor.Email);
            }
        }
    }
}
