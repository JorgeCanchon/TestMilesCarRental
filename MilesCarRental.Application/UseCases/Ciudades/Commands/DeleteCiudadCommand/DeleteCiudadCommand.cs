using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Ciudades.Commands.DeleteCiudadCommand
{
    public record DeleteCiudadCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
