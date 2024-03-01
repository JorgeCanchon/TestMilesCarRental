using Ardalis.Specification;

namespace MilesCarRental.Application.Specifications.Ciudad
{
    public class CiudadByIdSpecification : Specification<Domain.Entities.Ciudad>
    {
        public CiudadByIdSpecification(int id)
        {
            Query.Where(ciudad => ciudad.Id == id);
        }
    }
}
