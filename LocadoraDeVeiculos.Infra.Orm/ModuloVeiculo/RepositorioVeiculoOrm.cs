using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : IRepositorioVeiculo
    {
        private DbSet<Veiculo> veiculos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioVeiculoOrm(IContextoPersistencia contextoPersistencia)
        {
            this.dbContext = (LocadoraDeVeiculosDbContext)contextoPersistencia;
            veiculos = dbContext.Set<Veiculo>();
        }

        public void Editar(Veiculo registro)
        {
            veiculos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            veiculos.Remove(registro);
        }

        public void Inserir(Veiculo novoRegistro)
        {
            veiculos.Add(novoRegistro);
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return veiculos.SingleOrDefault(x => x.Id == id);
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return veiculos.FirstOrDefault(x => x.Placa == placa);  
        }

        public List<Veiculo> SelecionarTodos()
        {
            return veiculos.Include(x => x.GrupoDeVeiculos).ToList();
        }
    }
}
