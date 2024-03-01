using Ardalis.Specification;


namespace MilesCarRental.Application.Specifications.Localidad
{
    public class LocalidadByIdSpecification : Specification<Domain.Entities.Localidad>
    {
        public LocalidadByIdSpecification(int id)
        {
            Query.Where(localidad => localidad.Id == id);
        }
    }
}
