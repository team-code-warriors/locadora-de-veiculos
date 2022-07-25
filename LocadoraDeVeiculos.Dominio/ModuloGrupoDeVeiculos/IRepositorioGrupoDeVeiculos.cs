using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public interface IRepositorioGrupoDeVeiculos : IRepositorio<GrupoDeVeiculos>
    {
        public GrupoDeVeiculos SelecionarGrupoPorNome(string nome);
    }
}
