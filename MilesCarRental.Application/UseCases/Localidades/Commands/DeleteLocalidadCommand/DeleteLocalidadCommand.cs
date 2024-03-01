using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Localidades.Commands.DeleteLocalidadCommand
{
    public record DeleteLocalidadCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
