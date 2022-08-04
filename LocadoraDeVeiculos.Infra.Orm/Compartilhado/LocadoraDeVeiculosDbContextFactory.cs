using LocadoraDeVeiculos.Infra.Configs;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public class LocadoraDeVeiculosDbContextFactory : IDesignTimeDbContextFactory<LocadoraDeVeiculosDbContext>
    {
        ConfiguracaoAplicacao configuracao;

        public LocadoraDeVeiculosDbContext CreateDbContext(string[] args)
        {
            configuracao = new ConfiguracaoAplicacao();
            return new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
        }
    }
}
