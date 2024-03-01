using MediatR;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Paises.Commands.DeletePaisCommand
{
    public record DeletePaisCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
