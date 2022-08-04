using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaOrm : IRepositorioPlanoDeCobranca
    {
        private DbSet<PlanoDeCobranca> planos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioPlanoDeCobrancaOrm(IContextoPersistencia contextoPersistencia)
        {
            this.dbContext = (LocadoraDeVeiculosDbContext)contextoPersistencia;
            planos = dbContext.Set<PlanoDeCobranca>();
        }
        public void Editar(PlanoDeCobranca registro)
        {
            planos.Update(registro);
        }

        public void Excluir(PlanoDeCobranca registro)
        {
            planos.Remove(registro);
        }

        public void Inserir(PlanoDeCobranca novoRegistro)
        {
            planos.Add(novoRegistro);
        }

        public PlanoDeCobranca SelecionarPorId(Guid id)
        {
            return planos.SingleOrDefault(x => x.Id == id);
        }

        public List<PlanoDeCobranca> SelecionarTodos()
        {
            return planos.Include(x => x.GrupoVeiculo).ToList();
        }

        public PlanoDeCobranca SelecionarPlanoPorGrupo(Guid id)
        {
            return planos.FirstOrDefault(x => x.GrupoVeiculo.Id == id);
        }

        public PlanoDeCobranca SelecionarPlanoPorTipoPlano(string tipoPlano)
        {
            return planos.FirstOrDefault(x => x.TipoPlano == tipoPlano);
        }
    }
}
