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
        private DbSet<Condutor> planos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioCondutorOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            planos = dbContext.Set<Condutor>();
            this.dbContext = dbContext;
        }
        public void Editar(Condutor registro)
        {
            planos.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            planos.Remove(registro);
        }

        public void Inserir(Condutor novoRegistro)
        {
            planos.Add(novoRegistro);
        }

        public Condutor SelecionarPorId(Guid id)
        {
            return planos.SingleOrDefault(x => x.Id == id);
        }

        public List<Condutor> SelecionarTodos()
        {
            return planos.ToList();
        }

        public Condutor SelecionarCondutorPorCliente(Guid id)
        {
            return planos.FirstOrDefault(x => x.Cliente.Id == id);
        }

        public Condutor SelecionarCondutorPorCpf (string cpf)
        {
            return planos.FirstOrDefault(x => x.Cpf == cpf);
        }
    }
}
