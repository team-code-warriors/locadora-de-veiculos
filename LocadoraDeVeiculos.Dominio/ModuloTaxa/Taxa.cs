using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public Taxa()
        {
        }

        public string Descricao { get; set; }
        public double Valor { get; set; }

        public string TipoCalculo { get; set; }

        public Taxa(string descricao, double valor, string tipoCalculo)
        {
            Descricao = descricao;
            Valor = valor;
            TipoCalculo = tipoCalculo;
        }

        public override bool Equals(object? obj)
        {
            return obj is Taxa taxa &&
                   Id == taxa.Id &&
                   Descricao == taxa.Descricao &&
                   Valor == taxa.Valor &&
                   TipoCalculo == taxa.TipoCalculo;
        }

        public Taxa Clonar()
        {
            return MemberwiseClone() as Taxa;
        }
    }
}
