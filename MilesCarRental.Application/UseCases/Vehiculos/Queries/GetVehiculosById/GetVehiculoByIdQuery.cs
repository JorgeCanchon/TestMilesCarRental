using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Vehiculos.Queries.GetVehiculosById
{
    public record GetVehiculoByIdQuery : IRequest<Response<VehiculoDTO>>
    {
        public int Id { get; set; }
    }
}
