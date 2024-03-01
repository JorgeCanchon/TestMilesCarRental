using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Specifications.Ciudad;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Ciudades.Queries.GetAllCiudadesById
{
    public class GetAllCiudadesByIdQueryHandler : IRequestHandler<GetAllCiudadesByIdQuery, Response<CiudadDTO>>
    {
        private readonly IRepositoryAsync<Ciudad> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCiudadesByIdQueryHandler(IRepositoryAsync<Ciudad> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<CiudadDTO>> Handle(GetAllCiudadesByIdQuery request, CancellationToken cancellationToken)
        {
            var ciudad = await _repositoryAsync.FirstOrDefaultAsync(new CiudadByIdSpecification(request.Id));

            if (ciudad == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            var dto = _mapper.Map<CiudadDTO>(ciudad);
            return new Response<CiudadDTO>(dto);
        }
    }
}
