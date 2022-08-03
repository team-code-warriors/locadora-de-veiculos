using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class MapeadorCondutor : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Cnh).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(500)").IsRequired();
            builder.HasOne(x => x.Cliente).WithMany().OnDelete(DeleteBehavior.NoAction);
        }

    }
}
