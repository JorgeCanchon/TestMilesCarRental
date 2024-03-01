using Microsoft.EntityFrameworkCore;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Domain.Common;
using MilesCarRental.Domain.Entities;
using System.Reflection;

namespace MilesCarRental.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService): base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public DbSet<Pais> Paises { get; set; } = null!;
        public DbSet<Ciudad> Ciudades { get; set; } = null!;
        public DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public DbSet<Localidad> Localidades { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.Entries<AuditableBaseEntity>().ToList().ForEach(entry =>
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            });
            return base.SaveChangesAsync(cancellationToken);
        }

        public void Seed(ApplicationDbContext context)
        {
            //Agregar Paises
            var colombia = new Pais { Nombre = "Colombia", Created = DateTime.Now };

            context.Paises.AddRange(colombia);
            context.SaveChanges();

            //Agregar Ciudades
            var bogota = new Ciudad { Nombre = "Bogota", PaisId = colombia.Id, Created = DateTime.Now };
            var medellin = new Ciudad { Nombre = "Medellin", PaisId = colombia.Id, Created = DateTime.Now };
            var cali = new Ciudad { Nombre = "Cali", PaisId = colombia.Id, Created = DateTime.Now };
            var pereira = new Ciudad { Nombre = "Pereira", PaisId = colombia.Id, Created = DateTime.Now };

            context.Ciudades.AddRange(bogota, medellin, cali, pereira);
            context.SaveChanges();

            //Agregar Localidades
            var aeropuertoDorado = new Localidad { Nombre = "Aeropuerto El Dorado", Direccion = "Calle 26 #103-9", Created = DateTime.Now, CiudadId = bogota.Id };
            var ccAndino = new Localidad { Nombre = "Centro Comercial Andino", Direccion = "Cra. 11, 82-71", Created = DateTime.Now, CiudadId = bogota.Id };
            var exito70 = new Localidad { Nombre = "Exito la 70", Direccion = "Cra. 70 #43 - 31", Created = DateTime.Now, CiudadId = medellin.Id };
            var aeropuertoOlaya = new Localidad { Nombre = "Aeropuerto Olaya Herrera", Direccion = "Cra. 65 #13-157", Created = DateTime.Now, CiudadId = medellin.Id };

            context.Localidades.AddRange(aeropuertoDorado, ccAndino, exito70, aeropuertoOlaya);
            context.SaveChanges();

            //Agegar Vehiculos
            var renault = new Vehiculo { Marca = "Renault", Placa = "RGT123", LocalidadRecogidaId = aeropuertoDorado.Id, LocalidadDevolucionId = aeropuertoDorado.Id, Created = DateTime.Now };
            var chevrolet = new Vehiculo { Marca = "Chevrolet", Placa = "TZX123", LocalidadRecogidaId = exito70.Id, LocalidadDevolucionId = exito70.Id, Created = DateTime.Now };
            var nissan = new Vehiculo { Marca = "Nissan", Placa = "AAA123", LocalidadRecogidaId = aeropuertoDorado.Id, LocalidadDevolucionId = exito70.Id, Created = DateTime.Now };
            var honda = new Vehiculo { Marca = "Honda", Placa = "BBB123", LocalidadRecogidaId = exito70.Id, LocalidadDevolucionId = aeropuertoDorado.Id, Created = DateTime.Now };

            context.Vehiculos.AddRange(renault, chevrolet, nissan, honda);
            context.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Sqlite:Autoincrement", true)
                  .HasAnnotation("MySql:ValueGeneratedOnAdd", true);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
