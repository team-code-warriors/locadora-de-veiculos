using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public interface IRepositorioPlanoDeCobranca : IRepositorio<PlanoDeCobranca>
    {
        public PlanoDeCobranca SelecionarPlanoPorGrupo(Guid id);
        public PlanoDeCobranca SelecionarPlanoPorTipoPlano(string tipoPlano);
    }
}
