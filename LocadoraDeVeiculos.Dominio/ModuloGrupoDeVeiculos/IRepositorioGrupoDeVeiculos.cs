using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public interface IRepositorioGrupoDeVeiculos : IRepositorio<GrupoDeVeiculos>
    {
        public GrupoDeVeiculos SelecionarGrupoPorNome(string nome);
    }
}
