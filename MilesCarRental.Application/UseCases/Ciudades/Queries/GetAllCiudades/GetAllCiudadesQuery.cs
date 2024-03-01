using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Ciudades.Queries.GetAllCiudades
{
    public record GetAllCiudadesQuery : IRequest<Response<List<CiudadDTO>>> { }
}
