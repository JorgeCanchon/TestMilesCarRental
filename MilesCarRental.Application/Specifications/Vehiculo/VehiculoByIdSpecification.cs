using Ardalis.Specification;

namespace MilesCarRental.Application.Specifications.Vehiculo
{
    public class VehiculoByIdSpecification : Specification<Domain.Entities.Vehiculo>
    {
        public VehiculoByIdSpecification(int id)
        {
            Query.Where(vehiculo => vehiculo.Id == id);
        }
    }
}
