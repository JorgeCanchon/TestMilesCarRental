using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Infrastructure.Persistence.Configuration
{
    public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("Vehiculo");
            builder.HasKey(propiedad => propiedad.Id);

            //builder.OwnsOne(cb => cb.LocalidadDevolucion);
            //builder.OwnsOne(cb => cb.LocalidadRecogida);

            builder.Property(propiedad => propiedad.Id).HasColumnName("Id");

            builder.Property(p => p.Marca)
                .HasColumnName("Marca")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Placa)
                .HasColumnName("Placa")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.Disponible)
               .HasColumnName("Disponible")
               .IsRequired();

            builder.Property(p => p.LocalidadRecogidaId)
               .HasColumnName("LocalidadRecogidaId")
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(p => p.LocalidadDevolucionId)
               .HasColumnName("LocalidadDevolucionId")
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
