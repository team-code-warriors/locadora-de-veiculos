using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    public class MapeadorVeiculoOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Modelo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Fabricante).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.Cambio).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Kilometragem).IsRequired();
            builder.Property(x => x.TipoDeCombustivel).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.CapacidadeDoTanque).IsRequired();
            builder.Property(x => x.GrupoDeVeiculos);
        }
    }
}
