using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado
{
    public static class FormExtensions
    {
        public static void ConfigurarTela(this Form tela)
        {
            tela.FormBorderStyle = FormBorderStyle.FixedDialog;
            tela.StartPosition = FormStartPosition.CenterScreen;
            tela.MaximizeBox = false;
            tela.MinimizeBox = false;
            tela.ShowIcon = false;
            tela.ShowInTaskbar = false;
        }
    }
}
