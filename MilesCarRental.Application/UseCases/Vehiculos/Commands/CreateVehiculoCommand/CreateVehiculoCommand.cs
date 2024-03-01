using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Vehiculos.Commands.CreateVehiculoCommand
{
    public record CreateVehiculoCommand : IRequest<Response<int>>
    {
        public string Marca { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public bool Disponible { get; set; }
        public int LocalidadRecogidaId { get; set; }
        public int LocalidadDevolucionId { get; set; }
    }
}
