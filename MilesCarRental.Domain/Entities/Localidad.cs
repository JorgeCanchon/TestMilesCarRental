using MilesCarRental.Domain.Common;

namespace MilesCarRental.Domain.Entities
{
    public class Localidad : AuditableBaseEntity
    {
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; } = null!;
    }
}
