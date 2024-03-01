using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Vehiculos.Commands.DeleteVehiculoCommand
{
    public record DeleteVehiculoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
