using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public class GrupoDeVeiculos : EntidadeBase<GrupoDeVeiculos>
    {
        public GrupoDeVeiculos() { }

        public string Nome { get; set; }

        public GrupoDeVeiculos(string nome)
        {
            Nome = nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is GrupoDeVeiculos grupoDeVeiculos &&
                Id == grupoDeVeiculos.Id &&
                Nome == grupoDeVeiculos.Nome;
        }
        public GrupoDeVeiculos Clonar()
        {
            return MemberwiseClone() as GrupoDeVeiculos;
        }
    }
}
