using MilesCarRental.Domain.Common;

namespace MilesCarRental.Domain.Entities
{
    public class Pais : AuditableBaseEntity
    {
        public string Nombre { get; set; } = null!;
    }
}
