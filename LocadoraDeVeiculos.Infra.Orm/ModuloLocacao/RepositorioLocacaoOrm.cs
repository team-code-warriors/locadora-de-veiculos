using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : IRepositorioLocacao
    {
        private DbSet<Locacao> locacoes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioLocacaoOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            locacoes = dbContext.Set<Locacao>();
            this.dbContext = dbContext;
        }

        public void Excluir(Locacao registro)
        {
            locacoes.Update(registro);
        }

        public void Inserir(Locacao novoRegistro)
        {
            locacoes.Add(novoRegistro);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            return locacoes.SingleOrDefault(x => x.Id == id);
        }

        public List<Locacao> SelecionarTodos()
        {
            return locacoes
                .Include(x => x.Funcionario)
                .Include(x => x.Condutor)
                .Include(x => x.Veiculo)
                .Include(x => x.Plano)
                .Include(x => x.Taxas)
                .ToList();
        }
    }
}
