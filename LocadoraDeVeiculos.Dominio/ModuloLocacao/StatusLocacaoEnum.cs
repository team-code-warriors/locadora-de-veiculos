using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public enum StatusLocacaoEnum
    {
        [Description("Ativa")]
        Ativa,

        [Description("Inativa")]
        Inativa,

        [Description("Fechada")]
        Fechada,
    }
}
