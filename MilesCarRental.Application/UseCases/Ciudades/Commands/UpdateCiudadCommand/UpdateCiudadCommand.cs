using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Ciudades.Commands.UpdateCiudadCommand
{
    public record UpdateCiudadCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int PaisId { get; set; }
    }
}
