using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Ciudades.Commands.CreateCiudadCommand
{
    public record CreateCiudadCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; } = null!;
        public int PaisId { get; set; }
    }
}
