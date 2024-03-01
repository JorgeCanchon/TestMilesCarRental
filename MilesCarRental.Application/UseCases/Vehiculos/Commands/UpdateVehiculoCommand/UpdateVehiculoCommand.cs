using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Vehiculos.Commands.UpdateVehiculoCommand
{
    public record UpdateVehiculoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Marca { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public bool Disponible { get; set; }
        public int LocalidadRecogidaId { get; set; }
        public int LocalidadDevolucionId { get; set; }
    }
}
