using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculo
{
    public class RepositorioGrupoDeVeiculoOrm : IRepositorioGrupoDeVeiculos
    {

        private DbSet<GrupoDeVeiculos> grupos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioGrupoDeVeiculoOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            grupos = dbContext.Set<GrupoDeVeiculos>();
            this.dbContext = dbContext;
        }
        public void Editar(GrupoDeVeiculos registro)
        {
            grupos.Update(registro);
        }

        public void Excluir(GrupoDeVeiculos registro)
        {
            grupos.Remove(registro);
        }

        public void Inserir(GrupoDeVeiculos novoRegistro)
        {
            grupos.Add(novoRegistro);
        }

        public GrupoDeVeiculos SelecionarGrupoPorNome(string nome)
        {
            return grupos.FirstOrDefault(x => x.Nome == nome);
        }

        public GrupoDeVeiculos SelecionarPorId(Guid id)
        {
            return grupos.SingleOrDefault(x => x.Id == id);
        }

        public List<GrupoDeVeiculos> SelecionarTodos()
        {
            return grupos.ToList();
        }
    }
}
