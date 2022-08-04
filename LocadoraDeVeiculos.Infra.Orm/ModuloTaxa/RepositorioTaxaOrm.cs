using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : IRepositorioTaxa
    {
        private DbSet<Taxa> taxas;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioTaxaOrm(IContextoPersistencia contextoPersistencia)
        {
            this.dbContext = (LocadoraDeVeiculosDbContext)contextoPersistencia;
            taxas = dbContext.Set<Taxa>();
        }

        public void Editar(Taxa registro)
        {
            taxas.Update(registro);
        }

        public void Excluir(Taxa registro)
        {
            taxas.Remove(registro);
        }

        public void Inserir(Taxa novoRegistro)
        {
            taxas.Add(novoRegistro);
        }

        public Taxa SelecionarPorId(Guid id)
        {
            return taxas.SingleOrDefault(x => x.Id == id);
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return taxas.FirstOrDefault(x => x.Descricao == descricao);
        }

        public List<Taxa> SelecionarTodos()
        {
            return taxas.ToList();
        }
    }
}
