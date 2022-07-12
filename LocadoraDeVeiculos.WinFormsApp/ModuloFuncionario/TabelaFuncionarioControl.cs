using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
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

namespace LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "DataAdmissao", HeaderText = "Admissão"}, 

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoPerfil", HeaderText = "Tipo de Perfil"},
            };

            return colunas;
        }

        public Guid ObtemNumeroFuncionarioSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        internal void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (var funcionario in funcionarios)
            {
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.DataAdmissao, funcionario.TipoPerfil);
            }
        }
    }
}
