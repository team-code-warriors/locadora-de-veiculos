using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public virtual void Devolver() { }
        public virtual void GerarPdf() { }
        public abstract UserControl ObtemListagem();
        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();
    }
}
