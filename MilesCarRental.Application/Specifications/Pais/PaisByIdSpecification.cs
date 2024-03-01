using Ardalis.Specification;

namespace MilesCarRental.Application.Specifications.Pais
{
    public class PaisByIdSpecification : Specification<Domain.Entities.Pais>
    {
        public PaisByIdSpecification(int id)
        {
            Query.Where(pais => pais.Id == id);
        }
    }
}
