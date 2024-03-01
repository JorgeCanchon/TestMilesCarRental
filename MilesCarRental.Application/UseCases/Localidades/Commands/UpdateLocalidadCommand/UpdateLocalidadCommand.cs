using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Localidades.Commands.UpdateLocalidadCommand
{
    public record  UpdateLocalidadCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int CiudadId { get; set; }
    }
}
