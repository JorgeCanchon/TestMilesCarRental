using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Paises.Queries.GetAllPaises
{
    public record GetAllPaisesQuery : IRequest<Response<List<PaisDTO>>> { }
}
