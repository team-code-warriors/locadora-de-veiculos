using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : IRepositorioCondutor
    {
        private DbSet<Condutor> condutores;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioCondutorOrm(IContextoPersistencia contextoPersistencia)
        {
            this.dbContext = (LocadoraDeVeiculosDbContext)contextoPersistencia;
            condutores = dbContext.Set<Condutor>();

        }
        public void Editar(Condutor registro)
        {
            condutores.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            condutores.Remove(registro);
        }

        public void Inserir(Condutor novoRegistro)
        {
            condutores.Add(novoRegistro);
        }

        public Condutor SelecionarPorId(Guid id)
        {
            return condutores.SingleOrDefault(x => x.Id == id);
        }

        public List<Condutor> SelecionarTodos()
        {
            return condutores.Include(x => x.Cliente).ToList();
        }

        public Condutor SelecionarCondutorPorCliente(Guid id)
        {
            return condutores.FirstOrDefault(x => x.Cliente.Id == id);
        }

        public Condutor SelecionarCondutorPorCpf (string cpf)
        {
            return condutores.FirstOrDefault(x => x.Cpf == cpf);
        }
    }
}
