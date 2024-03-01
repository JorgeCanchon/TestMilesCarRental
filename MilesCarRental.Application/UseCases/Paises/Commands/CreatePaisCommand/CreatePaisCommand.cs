using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Paises.Commands.CreatePaisCommand
{
    public record CreatePaisCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; } = null!;
    }
}
