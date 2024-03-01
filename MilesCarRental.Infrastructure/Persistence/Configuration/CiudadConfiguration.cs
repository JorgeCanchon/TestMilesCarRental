using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Infrastructure.Persistence.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("Ciudad");
            builder.HasKey(propiedad => propiedad.Id);

            builder.Property(propiedad => propiedad.Id).HasColumnName("Id");

            builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.PaisId)
               .HasColumnName("PaisId")
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(p => p.Created)
                .HasColumnName("FechaCreacion")
                .HasMaxLength(30);

            builder.Property(p => p.LastModified)
                .HasColumnName("UltimaFechaModificacion")
                .HasMaxLength(30);
        }
    }
}
