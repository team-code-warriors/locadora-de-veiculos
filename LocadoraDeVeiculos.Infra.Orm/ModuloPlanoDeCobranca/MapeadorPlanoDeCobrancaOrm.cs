using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobrancaOrm : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TBPlanoDeCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.TipoPlano).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.ValorDiaria).IsRequired();
            builder.Property(x => x.KmIncluso).IsRequired();
            builder.Property(x => x.PrecoKm).IsRequired();
            builder.HasOne(x => x.GrupoVeiculo);
        }
    }
}
