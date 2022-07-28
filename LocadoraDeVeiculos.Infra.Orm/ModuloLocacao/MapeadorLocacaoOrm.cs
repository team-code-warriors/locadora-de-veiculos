using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.DataLocacao).IsRequired();
            builder.Property(x => x.DataDevolucao).IsRequired();
            builder.Property(x => x.KmCarro).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Valor).IsRequired();

            builder.HasOne(x => x.Funcionario)
                .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Condutor)
                .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Veiculo)
                .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Plano)
              .WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
