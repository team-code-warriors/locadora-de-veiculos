using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public interface IRepositorioPlanoDeCobranca : IRepositorio<PlanoDeCobranca>
    {
        public PlanoDeCobranca SelecionarPlanoPorGrupo(Guid id);
        public PlanoDeCobranca SelecionarPlanoPorTipoPlano(string tipoPlano);
    }
}
