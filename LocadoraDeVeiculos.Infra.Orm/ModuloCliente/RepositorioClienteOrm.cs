using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : IRepositorioCliente
    {
        private DbSet<Cliente> clientes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioClienteOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            clientes = dbContext.Set<Cliente>();
            this.dbContext = dbContext;
        }

        public void Inserir(Cliente novoRegistro)
        {
            clientes.Add(novoRegistro);
        }

        public void Editar(Cliente registro)
        {
            clientes.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            clientes.Remove(registro);
        }

        public Cliente SelecionarPorId(Guid id)
        {
            return clientes.SingleOrDefault(x => x.Id == id);
        }

        public List<Cliente> SelecionarTodos()
        {
            return clientes.ToList();
        }

        public Cliente SelecionarClientePorCpf(string cpf)
        {
            return clientes.FirstOrDefault(x => x.Cpf == cpf);
        }

        public Cliente SelecionarClientePorCnpj(string cnpj)
        {
            return clientes.FirstOrDefault(x => x.Cnpj == cnpj);
        }
    }
}
