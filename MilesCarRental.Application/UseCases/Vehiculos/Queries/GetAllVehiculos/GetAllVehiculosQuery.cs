using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Vehiculos.Queries.GetAllVehiculos
{
    public record GetAllVehiculosQuery : IRequest<Response<List<VehiculoDTO>>> { }
}
