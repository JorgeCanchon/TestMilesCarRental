using MediatR;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;

namespace MilesCarRental.Application.UseCases.Ciudades.Queries.GetAllCiudadesById
{
    public record GetAllCiudadesByIdQuery : IRequest<Response<CiudadDTO>> 
    {
        public int Id { get; set; }
    }
}
