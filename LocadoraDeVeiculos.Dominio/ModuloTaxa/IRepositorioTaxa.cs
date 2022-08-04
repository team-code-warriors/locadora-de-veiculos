using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        public Taxa SelecionarTaxaPorDescricao(string descricao);
    }
}
