using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Localidades.Queries.GetLocalidadById
{
    public record GetLocalidadByIdQuery : IRequest<Response<LocalidadDTO>>
    { 
        public int Id { get; set; }
    }
}
