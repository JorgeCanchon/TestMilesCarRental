using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Localidades.Queries.GetAllLocalidades
{
    public class GetAllLocalidadesQueryHandler : IRequestHandler<GetAllLocalidadesQuery, Response<List<LocalidadDTO>>>
    {
        private readonly IRepositoryAsync<Localidad> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllLocalidadesQueryHandler(IRepositoryAsync<Localidad> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<List<LocalidadDTO>>> Handle(GetAllLocalidadesQuery request, CancellationToken cancellationToken)
        {
            var localidads = await _repositoryAsync.ListAsync();
            if (!localidads.Any())
            {
                throw new KeyNotFoundException($"No existen registros para mostrar");
            }

            var dto = _mapper.Map<List<LocalidadDTO>>(localidads);
            return new Response<List<LocalidadDTO>>(dto);
        }
    }
}
