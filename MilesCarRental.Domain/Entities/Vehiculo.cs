using MilesCarRental.Domain.Common;

namespace MilesCarRental.Domain.Entities
{
    public class Vehiculo : AuditableBaseEntity
    {
        public string Marca { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public int IdLocalidadRecogida { get; set; }
        public virtual Localidad LocalidadRecogida { get; set; }
        public int IdLocalidadDevolucion { get; set; }
        public virtual Localidad LocalidadDevolucion { get; set; } 

    }
}
