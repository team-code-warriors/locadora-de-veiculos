using System.ComponentModel;

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
