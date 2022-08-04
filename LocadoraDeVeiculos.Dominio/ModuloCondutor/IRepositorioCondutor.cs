using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        public Condutor SelecionarCondutorPorCliente(Guid id);
        public Condutor SelecionarCondutorPorCpf(string cpf);
    }
}
