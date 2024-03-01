using MilesCarRental.Domain.Common;

namespace MilesCarRental.Domain.Entities
{
    public class Ciudad : AuditableBaseEntity
    {
        public string Nombre { get; set; } = null!;
        public int IdPais { get; set; }
        public virtual Pais Pais { get; set; } = null!;
    }
}
