using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente SelecionarClientePorCpf(string cpf);

        Cliente SelecionarClientePorCnpj(string cnpj);

    }
}
