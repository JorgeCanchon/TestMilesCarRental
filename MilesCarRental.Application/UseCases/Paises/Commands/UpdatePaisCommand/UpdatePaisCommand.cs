using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Paises.Commands.UpdatePaisCommand
{
    public record UpdatePaisCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
