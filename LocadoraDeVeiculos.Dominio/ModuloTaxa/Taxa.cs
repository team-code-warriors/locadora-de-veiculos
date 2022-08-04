using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public Taxa()
        {
        }

        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public string TipoCalculo { get; set; }

        public List<Locacao> Locacoes;

        public Taxa(string descricao, Decimal valor, string tipoCalculo)
        {
            Descricao = descricao;
            Valor = valor;
            TipoCalculo = tipoCalculo;
        }



        public Taxa Clonar()
        {
            return MemberwiseClone() as Taxa;
        }

        public override string ToString()
        {
            return Descricao;
        }

        public override bool Equals(object? obj)
        {
            return obj is Taxa taxa &&
                   Id.Equals(taxa.Id) &&
                   Descricao == taxa.Descricao &&
                   Valor == taxa.Valor &&
                   TipoCalculo == taxa.TipoCalculo &&
                   EqualityComparer<List<Locacao>>.Default.Equals(Locacoes, taxa.Locacoes);
        }
    }
}
