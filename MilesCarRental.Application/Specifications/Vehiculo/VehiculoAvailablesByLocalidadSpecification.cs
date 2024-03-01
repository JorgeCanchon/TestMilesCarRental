using Ardalis.Specification;

namespace MilesCarRental.Application.Specifications.Vehiculo
{
    public class VehiculoAvailablesByLocalidadSpecification : Specification<Domain.Entities.Vehiculo>
    {
        public VehiculoAvailablesByLocalidadSpecification(int localidadRecogidaId, int localidadDevolucionId)
        {
            Query.Where(vehiculo => vehiculo.LocalidadRecogidaId == localidadRecogidaId && 
                vehiculo.LocalidadDevolucionId == localidadDevolucionId && vehiculo.Disponible);
        }
    }
}
