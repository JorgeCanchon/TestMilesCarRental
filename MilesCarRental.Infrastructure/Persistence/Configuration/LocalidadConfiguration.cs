using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Infrastructure.Persistence.Configuration
{
    public class LocalidadConfiguration : IEntityTypeConfiguration<Localidad>
    {
        public void Configure(EntityTypeBuilder<Localidad> builder)
        {
            builder.ToTable("Localidad");
            builder.HasKey(propiedad => propiedad.Id);

            //builder.OwnsOne(cb => cb.Ciudad);

            builder.Property(propiedad => propiedad.Id).HasColumnName("Id");

            builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Direccion)
                .HasColumnName("Direccion")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.IdCiudad)
               .HasColumnName("IdCiudad")
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
