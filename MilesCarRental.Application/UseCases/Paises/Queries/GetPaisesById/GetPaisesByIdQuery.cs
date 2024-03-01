using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Paises.Queries.GetPaisesById
{
    public record GetPaisesByIdQuery : IRequest<Response<PaisDTO>>
    {
        public int Id { get; set; }
    }
}
