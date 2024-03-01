using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Localidades.Queries.GetAllLocalidades
{
    public record GetAllLocalidadesQuery : IRequest<Response<List<LocalidadDTO>>> { }
}
