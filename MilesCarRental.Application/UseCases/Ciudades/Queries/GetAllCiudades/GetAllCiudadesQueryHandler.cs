using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;


namespace MilesCarRental.Application.UseCases.Ciudades.Queries.GetAllCiudades
{
    public class GetAllCiudadesQueryHandler : IRequestHandler<GetAllCiudadesQuery, Response<List<CiudadDTO>>>
    {
        private readonly IRepositoryAsync<Ciudad> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCiudadesQueryHandler(IRepositoryAsync<Ciudad> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<List<CiudadDTO>>> Handle(GetAllCiudadesQuery request, CancellationToken cancellationToken)
        {
            var ciudads = await _repositoryAsync.ListAsync();
            if (!ciudads.Any())
            {
                throw new KeyNotFoundException($"No existen registros para mostrar");
            }

            var dto = _mapper.Map<List<CiudadDTO>>(ciudads);
            return new Response<List<CiudadDTO>>(dto);
        }
    }
}
