using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Vehiculos.Queries.GetVehiculosAvailables
{
    public record GetVehiculosAvailablesQuery : IRequest<Response<List<VehiculoDTO>>>
    {
        public int LocalidadRecogidaId { get; set; }
        public int LocalidadDevolucionId { get; set; }
    }
}
