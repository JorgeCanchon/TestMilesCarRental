using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Localidades.Commands.CreateLocalidadCommand
{
    public record CreateLocalidadCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int CiudadId { get; set; }
    }
}
